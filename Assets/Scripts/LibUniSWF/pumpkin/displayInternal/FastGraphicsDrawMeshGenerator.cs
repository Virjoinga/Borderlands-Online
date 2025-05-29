using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.geom;

namespace pumpkin.displayInternal
{
	public class FastGraphicsDrawMeshGenerator : IGraphicsGenerator
	{
		public static int PHASE_SCAN = 0;

		public static int PHASE_BUILD = 1;

		public float zSpace = 0.1f;

		public float zContainerSpace = 0f;

		public int allocBuffer = 0;

		public Mesh mesh_0;

		public Mesh mesh_1;

		private bool m_meshSwitch = true;

		public int phaseId = 0;

		internal FastList<MeshGenRenderGroup> renderGroups;

		internal MeshGenRenderGroup currentRenderGroup;

		internal Dictionary<int, int[]> indexCache = new Dictionary<int, int[]>();

		internal FastList<GraphicsDrawOP>[] lastDrawOps;

		internal int lastDrawOpsUseCnt = 0;

		internal FastList<Material> materials;

		internal SwfGraphicsRenderState renderState;

		public float zDrawOffset;

		public int vertId = 0;

		public Material currentMaterial;

		public int statTotalTriangles = 0;

		public int statMaterialsGrouped = 0;

		public int allocCnt = 0;

		public int dirtyCnt = 0;

		public Stage stage;

		public List<int[]> allocPool = new List<int[]>();

		private Vector3[] vertices;

		private Vector2[] UVs;

		private Color[] colors;

		private FastList<int[]> indexMap;

		public int maxIndexCachePoolCount = 64;

		public bool useVertexMatrix = false;

		public Matrix4x4 vertexMatrix;

		public Vector3 drawOffset = Vector3.zero;

		public Mesh m_Mesh0;

		public Mesh m_Mesh1;

		public bool m_Ping = false;

		private MeshGeneratorOptions m_Options = new MeshGeneratorOptions();

		public SimpleStageRenderResult m_SimpleMeshResult = new SimpleStageRenderResult();

		public MeshGeneratorOptions meshGeneratorOptions
		{
			get
			{
				return m_Options;
			}
			set
			{
				m_Options = value;
			}
		}

		public FastGraphicsDrawMeshGenerator()
		{
			renderState = default(SwfGraphicsRenderState);
			renderGroups = new FastList<MeshGenRenderGroup>();
			lastDrawOps = new FastList<GraphicsDrawOP>[32];
			materials = new FastList<Material>();
			indexMap = new FastList<int[]>();
		}

		public virtual bool renderStage(Stage stage)
		{
			this.stage = stage;
			allocCnt = 0;
			statTotalTriangles = 0;
			statMaterialsGrouped = 0;
			phaseId = PHASE_SCAN;
			renderGroups.Clear();
			currentRenderGroup = null;
			materials.Clear();
			currentMaterial = null;
			vertId = 0;
			dirtyCnt = 0;
			renderState.blendMode = 0;
			renderState.colorTransform.r = (renderState.colorTransform.g = (renderState.colorTransform.b = (renderState.colorTransform.a = 1f)));
			renderState.parentHasClipRect = false;
			renderState.clipRectParent = null;
			renderState.clipRectCached = false;
			renderDisplayObjectContainer(stage, renderState);
			if (renderGroups.IndexOf(currentRenderGroup) == -1 && currentRenderGroup != null)
			{
				renderGroups.Add(currentRenderGroup);
			}
			vertId = 0;
			for (int i = 0; i < renderGroups.Count; i++)
			{
				if (renderGroups.m_Buffer == null)
				{
					break;
				}
				if (renderGroups.m_Buffer[i] == null)
				{
					break;
				}
				vertId += renderGroups[i].drawOps.Count * 4;
			}
			indexMap.Clear();
			if (vertices == null || vertId > vertices.Length)
			{
				if (vertices == null)
				{
					vertices = new Vector3[vertId];
					UVs = new Vector2[vertId];
					colors = new Color[vertId];
					allocCnt++;
				}
				else
				{
					Array.Resize(ref vertices, vertId);
					Array.Resize(ref UVs, vertId);
					Array.Resize(ref colors, vertId);
				}
			}
			vertId = 0;
			zDrawOffset = 0f;
			for (int j = 0; j < renderGroups.Count; j++)
			{
				FastList<GraphicsDrawOP> drawOps = renderGroups[j].drawOps;
				if (drawOps == null)
				{
					continue;
				}
				int[] array = null;
				int num = drawOps.Count * 6;
				for (int k = 0; k < allocPool.Count; k++)
				{
					if (allocPool[k].Length == num)
					{
						array = allocPool[k];
						Array.Clear(array, 0, array.Length);
						allocPool.RemoveAt(k);
						break;
					}
				}
				if (array == null)
				{
					array = new int[num];
					allocCnt++;
				}
				int num2 = 0;
				for (int l = 0; l < drawOps.Count; l++)
				{
					GraphicsDrawOP graphicsDrawOP = drawOps[l];
					if (graphicsDrawOP._cachedVertices != null)
					{
						UVs[vertId] = graphicsDrawOP._cachedUVs[0];
						UVs[vertId + 1] = graphicsDrawOP._cachedUVs[1];
						UVs[vertId + 2] = graphicsDrawOP._cachedUVs[2];
						UVs[vertId + 3] = graphicsDrawOP._cachedUVs[3];
						colors[vertId] = graphicsDrawOP._cachedColors[0];
						colors[vertId + 1] = graphicsDrawOP._cachedColors[1];
						colors[vertId + 2] = graphicsDrawOP._cachedColors[2];
						colors[vertId + 3] = graphicsDrawOP._cachedColors[3];
						vertices[vertId] = graphicsDrawOP._cachedVertices[0];
						vertices[vertId + 1] = graphicsDrawOP._cachedVertices[1];
						vertices[vertId + 2] = graphicsDrawOP._cachedVertices[2];
						vertices[vertId + 3] = graphicsDrawOP._cachedVertices[3];
						array[num2++] = vertId;
						array[num2++] = vertId + 1;
						array[num2++] = vertId + 3;
						array[num2++] = vertId + 3;
						array[num2++] = vertId + 1;
						array[num2++] = vertId + 2;
						vertId += 4;
						zDrawOffset -= zSpace;
					}
				}
				indexMap.Add(array);
				materials.Add(renderGroups[j].material);
			}
			if (useVertexMatrix)
			{
				Matrix4x4 matrix4x = vertexMatrix;
				for (int m = 0; m < vertices.Length; m++)
				{
					vertices[m] = matrix4x.MultiplyVector(vertices[m]) + drawOffset;
				}
			}
			Mesh currentMesh = getCurrentMesh();
			currentMesh.Clear();
			currentMesh.vertices = vertices;
			currentMesh.uv = UVs;
			currentMesh.colors = colors;
			currentMesh.subMeshCount = indexMap.Count;
			for (int n = 0; n < indexMap.Count; n++)
			{
				currentMesh.SetTriangles(indexMap[n], n);
			}
			for (int num3 = 0; num3 < indexMap.Count; num3++)
			{
				Array.Clear(indexMap[num3], 0, indexMap[num3].Length);
				allocPool.Add(indexMap[num3]);
			}
			while (allocPool.Count > maxIndexCachePoolCount)
			{
				allocPool.RemoveAt(0);
			}
			if (m_Options.doubleBuffered)
			{
				m_Ping = !m_Ping;
			}
			return true;
		}

		public Mesh applyToMeshRenderer(MeshRenderer meshRenderer)
		{
			Mesh currentMesh = getCurrentMesh();
			currentMesh.vertices = vertices;
			currentMesh.uv = UVs;
			currentMesh.colors = colors;
			if ((bool)meshRenderer && materials != null && materials.Count > 0)
			{
				meshRenderer.materials = materials.ToArray();
			}
			return currentMesh;
		}

		private void renderDisplayObjectContainer(DisplayObjectContainer parent, SwfGraphicsRenderState renderState)
		{
			if (!parent.visible)
			{
				return;
			}
			int blendMode = renderState.blendMode;
			if (parent.blendMode != 0)
			{
				renderState.blendMode = parent.blendMode;
			}
			Color colorTransform = renderState.colorTransform;
			renderState.colorTransform = parent.colorTransform * renderState.colorTransform;
			bool parentHasClipRect = renderState.parentHasClipRect;
			if (parent.hasClipRect)
			{
				renderState.parentHasClipRect = true;
				renderState.clipRectParent = parent;
				renderState.clipRectCached = false;
			}
			bool flag = parent is pumpkin.display.Sprite;
			if (flag)
			{
				pumpkin.display.Sprite sprite = parent as pumpkin.display.Sprite;
				renderGraphics(sprite.graphics, sprite, renderState);
			}
			for (int i = 0; i < parent.numChildren; i++)
			{
				DisplayObject childAt = parent.getChildAt(i);
				if (childAt is DisplayObjectContainer)
				{
					renderDisplayObjectContainer(childAt as DisplayObjectContainer, renderState);
				}
			}
			if (flag)
			{
				zDrawOffset += zContainerSpace;
			}
			if (!parentHasClipRect && renderState.parentHasClipRect)
			{
				renderState.parentHasClipRect = false;
				renderState.clipRectParent = null;
				renderState.clipRectCached = false;
			}
			renderState.colorTransform = colorTransform;
			renderState.blendMode = blendMode;
		}

		private void renderGraphics(pumpkin.display.Graphics gfx, pumpkin.display.Sprite parent, SwfGraphicsRenderState renderState)
		{
			int num = 0;
			for (int i = 0; i < gfx.drawOPs.Count; i++)
			{
				GraphicsDrawOP graphicsDrawOP = gfx.drawOPs[i];
				if (graphicsDrawOP.material == null)
				{
					continue;
				}
				if (currentMaterial != graphicsDrawOP.material)
				{
					if (currentRenderGroup != null)
					{
						renderGroups.Add(currentRenderGroup);
					}
					currentRenderGroup = renderGroups.GetUnusedList();
					if (currentRenderGroup == null)
					{
						currentRenderGroup = new MeshGenRenderGroup();
						allocCnt++;
					}
					else
					{
						currentRenderGroup.drawOps.Size = 0;
					}
					currentRenderGroup.screenBoundsDirty = true;
					currentRenderGroup.material = graphicsDrawOP.material;
					currentMaterial = graphicsDrawOP.material;
				}
				float x = graphicsDrawOP.x;
				float y = graphicsDrawOP.y;
				float num2 = graphicsDrawOP.drawWidth;
				float num3 = graphicsDrawOP.drawHeight;
				Matrix matrix = parent._fastGetFullMatrixRef();
				Rect drawSrcRect = graphicsDrawOP.drawSrcRect;
				if (stage.m_HasClipRect && renderState.parentHasClipRect)
				{
					Rect clipRect;
					if (!renderState.clipRectCached)
					{
						clipRect = (renderState.clipRect = renderState.clipRectParent.getInheritedClipRect());
						renderState.clipRectCached = true;
					}
					else
					{
						clipRect = renderState.clipRect;
					}
					if (clipRect.width != 0f && clipRect.height != 0f)
					{
						Rect rect = graphicsDrawOP.calcClipping(parent, clipRect);
						UVPixelRect uVPixelRect = new UVPixelRect(x, y, num2, num3, drawSrcRect.x, drawSrcRect.y, drawSrcRect.width, drawSrcRect.height);
						uVPixelRect.setWidthPixels(rect.width);
						uVPixelRect.setHeightPixels(rect.height);
						uVPixelRect.setXPixels(rect.x);
						uVPixelRect.setYPixels(rect.y);
						x = rect.x;
						y = rect.y;
						num2 = rect.width;
						num3 = rect.height;
						drawSrcRect.x = uVPixelRect.uX;
						drawSrcRect.y = uVPixelRect.uY;
						drawSrcRect.width = uVPixelRect.uW;
						drawSrcRect.height = uVPixelRect.uH;
					}
				}
				float x2 = drawSrcRect.x;
				float num4 = 1f - drawSrcRect.y;
				float width = drawSrcRect.width;
				float height = drawSrcRect.height;
				Vector2[] array = graphicsDrawOP._cachedUVs;
				if (array == null)
				{
					array = new Vector2[4];
				}
				array[0].x = x2 + width;
				array[0].y = num4;
				array[1].x = x2 + width;
				array[1].y = num4 - height;
				array[2].x = x2;
				array[2].y = num4 - height;
				array[3].x = x2;
				array[3].y = num4;
				graphicsDrawOP._cachedUVs = array;
				Color[] array2 = graphicsDrawOP._cachedColors;
				if (array2 == null)
				{
					array2 = new Color[4];
				}
				Color color = renderState.colorTransform * graphicsDrawOP.color;
				array2[0] = color;
				array2[1] = color;
				array2[2] = color;
				array2[3] = color;
				graphicsDrawOP._cachedColors = array2;
				Vector3[] array3 = graphicsDrawOP._cachedVertices;
				if (array3 == null)
				{
					array3 = new Vector3[4];
				}
				float inZ = zDrawOffset;
				if (graphicsDrawOP.flipped)
				{
					array3[0] = matrix.transformVector3Static(x, y, inZ);
					array3[1] = matrix.transformVector3Static(x, y + num3, inZ);
					array3[2] = matrix.transformVector3Static(x + num2, y + num3, inZ);
					array3[3] = matrix.transformVector3Static(x + num2, y, inZ);
				}
				else
				{
					array3[0] = matrix.transformVector3Static(x + num2, y, inZ);
					array3[1] = matrix.transformVector3Static(x + num2, y + num3, inZ);
					array3[2] = matrix.transformVector3Static(x, y + num3, inZ);
					array3[3] = matrix.transformVector3Static(x, y, inZ);
				}
				graphicsDrawOP._cachedVertices = array3;
				currentRenderGroup.drawOps.Add(graphicsDrawOP);
				vertId += 4;
			}
		}

		public void drawMeshNow(Matrix4x4 camMatrix, Vector3 drawOffset, Vector3 drawScale)
		{
			Mesh currentMesh = getCurrentMesh();
			drawOffset.z += 1f;
			drawScale.z = drawScale.x;
			Matrix4x4 matrix4x = Matrix4x4.TRS(drawOffset, Quaternion.identity, drawScale);
			matrix4x = camMatrix * matrix4x;
			currentMesh.subMeshCount = indexMap.Count;
			for (int i = 0; i < indexMap.Count; i++)
			{
				Material material = materials[i];
				if (!(material == null) && material.SetPass(0))
				{
					UnityEngine.Graphics.DrawMeshNow(currentMesh, matrix4x, i);
				}
			}
		}

		public Mesh getCurrentMesh()
		{
			if (m_meshSwitch)
			{
				if (mesh_0 == null)
				{
					mesh_0 = new Mesh();
					mesh_0.name = "mesh_0";
				}
				return mesh_0;
			}
			if (mesh_1 == null)
			{
				mesh_1 = new Mesh();
				mesh_1.name = "mesh_1";
			}
			return mesh_1;
		}

		public SimpleStageRenderResult getSimpleStageRenderResult()
		{
			Mesh currentMesh = getCurrentMesh();
			m_SimpleMeshResult.materials = materials.ToArray();
			m_SimpleMeshResult.mesh = currentMesh;
			return m_SimpleMeshResult;
		}
	}
}
