using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.geom;
using pumpkin.swf;
using pumpkin.utils;

namespace pumpkin.displayInternal
{
	[Serializable]
	public class GraphicsMeshGenerator : IGraphicsGenerator
	{
		public const int PHASE_SCAN = 0;

		public const int PHASE_BUILD = 1;

		public const int PHASE_NULL = 2;

		public Material currentMaterial;

		private int subMeshId = 0;

		public bool generateNormals = false;

		public float zSpace = 0.0001f;

		public float zContainerSpace = 0f;

		public bool enableCache = true;

		public bool simpleGeneration = true;

		public Vector3[] vertices = new Vector3[0];

		public Vector3[] normals = new Vector3[0];

		public Vector2[] UVs = new Vector2[0];

		public Color[] colors = new Color[0];

		public List<Material> materialList = new List<Material>();

		public List<int[]> submeshIndices = new List<int[]>();

		protected float zDrawOffset = 0f;

		protected int quadCount;

		protected int phaseId = 0;

		protected int numVerts = 0;

		protected int numUVs = 0;

		protected int numColours = 0;

		protected int numIndex = 0;

		protected int VertId = 0;

		protected int UVId = 0;

		protected int ColourId = 0;

		protected int triId = 0;

		protected Stage stage;

		public int updateCounter = -2;

		public Mesh mesh_0;

		public Mesh mesh_1;

		private bool m_meshSwitch = true;

		private SwfGraphicsRenderState renderState = default(SwfGraphicsRenderState);

		private Vector2 tmpUv;

		private Vector2 lowerLeftUV;

		private Vector2 UVDimensions;

		private Color white = Color.white;

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

		public bool renderStage(Stage stage)
		{
			this.stage = stage;
			submeshIndices.Clear();
			materialList.Clear();
			currentMaterial = null;
			subMeshId = -1;
			quadCount = 0;
			zDrawOffset = 0f;
			phaseId = 0;
			numVerts = 0;
			numUVs = 0;
			numColours = 0;
			numIndex = 0;
			renderState.blendMode = 0;
			renderState.colorTransform.r = (renderState.colorTransform.g = (renderState.colorTransform.b = (renderState.colorTransform.a = 1f)));
			renderState.parentHasClipRect = false;
			renderState.clipRectParent = null;
			renderState.clipRectCached = false;
			renderDisplayObjectContainer(stage);
			materialList.Add(currentMaterial);
			submeshIndices.Add(new int[numIndex]);
			Mesh currentMesh = getCurrentMesh();
			currentMesh.Clear();
			if (vertices.Length != numVerts)
			{
				vertices = new Vector3[numVerts];
				if (generateNormals)
				{
					normals = new Vector3[numVerts];
				}
			}
			if (UVs.Length != numUVs)
			{
				UVs = new Vector2[numUVs];
			}
			if (colors.Length != numColours)
			{
				colors = new Color[numColours];
			}
			currentMaterial = null;
			subMeshId = -1;
			quadCount = 0;
			zDrawOffset = 0f;
			phaseId = 1;
			VertId = 0;
			UVId = 0;
			ColourId = 0;
			triId = 0;
			renderState.blendMode = 0;
			renderState.colorTransform.r = (renderState.colorTransform.g = (renderState.colorTransform.b = (renderState.colorTransform.a = 1f)));
			renderState.parentHasClipRect = false;
			renderState.clipRectParent = null;
			renderState.clipRectCached = false;
			renderDisplayObjectContainer(stage);
			updateCounter = Time.frameCount;
			if (m_Options.doubleBuffered)
			{
				m_meshSwitch = !m_meshSwitch;
			}
			return true;
		}

		public Mesh applyToMeshRenderer(MeshRenderer meshRenderer)
		{
			Mesh currentMesh = getCurrentMesh();
			currentMesh.vertices = vertices;
			if (generateNormals)
			{
				currentMesh.normals = normals;
			}
			currentMesh.uv = UVs;
			currentMesh.colors = colors;
			if ((bool)meshRenderer)
			{
				meshRenderer.materials = materialList.ToArray();
			}
			currentMesh.subMeshCount = submeshIndices.Count;
			for (int i = 0; i < submeshIndices.Count; i++)
			{
				int[] triangles = submeshIndices[i];
				currentMesh.SetTriangles(triangles, i);
			}
			return currentMesh;
		}

		private void renderDisplayObjectContainer(DisplayObjectContainer parent)
		{
			if (phaseId == 0 || phaseId == 1)
			{
			}
			if (!parent.visible)
			{
				return;
			}
			for (int i = 0; i < parent.numChildren; i++)
			{
				DisplayObject childAt = parent.getChildAt(i);
				if (childAt is pumpkin.display.Sprite)
				{
					renderSprite(childAt as pumpkin.display.Sprite);
				}
				else if (childAt is DisplayObjectContainer)
				{
					renderDisplayObjectContainer(childAt as DisplayObjectContainer);
				}
			}
		}

		private void renderSprite(pumpkin.display.Sprite sprite)
		{
			if (sprite.visible)
			{
				pumpkin.display.Graphics graphics = sprite.graphics;
				bool parentHasClipRect = renderState.parentHasClipRect;
				if (sprite.hasClipRect)
				{
					renderState.parentHasClipRect = true;
					renderState.clipRectParent = sprite;
					renderState.clipRectCached = false;
				}
				renderGraphics(graphics, sprite);
				renderDisplayObjectContainer(sprite);
				if (!parentHasClipRect && renderState.parentHasClipRect)
				{
					renderState.parentHasClipRect = false;
					renderState.clipRectParent = null;
					renderState.clipRectCached = false;
				}
				zDrawOffset += zContainerSpace;
			}
		}

		private void renderGraphics(pumpkin.display.Graphics gfx, pumpkin.display.Sprite parent)
		{
			int[] array = null;
			int inheritedBlendMode = parent.getInheritedBlendMode();
			if (phaseId == 0 || phaseId == 1)
			{
			}
			if (!parent.visible)
			{
				return;
			}
			int count = gfx.drawOPs.Count;
			for (int i = 0; i < count; i++)
			{
				GraphicsDrawOP graphicsDrawOP = gfx.drawOPs[i];
				if (graphicsDrawOP.material == null)
				{
					continue;
				}
				if (inheritedBlendMode != 0 && graphicsDrawOP.material.shader != TextureManager.baseBitmapAddShader)
				{
					graphicsDrawOP.material = TextureManager.instance.createCovertyToAdditive(graphicsDrawOP.material);
				}
				if (phaseId == 0)
				{
					if (currentMaterial != graphicsDrawOP.material)
					{
						subMeshId++;
						if ((bool)currentMaterial)
						{
							materialList.Add(currentMaterial);
							submeshIndices.Add(new int[numIndex]);
							triId = 0;
							numIndex = 0;
						}
						currentMaterial = graphicsDrawOP.material;
					}
					if (graphicsDrawOP.simpleVectorShape != null)
					{
						int num = graphicsDrawOP.simpleVectorShape.vertices.Length;
						numVerts += num;
						numUVs += num;
						numColours += num;
						if (graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex == null)
						{
							Triangulator triangulator = new Triangulator(graphicsDrawOP.simpleVectorShape.vertices);
							triangulator.Triangulate();
							graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex = triangulator.Triangulate();
						}
						numIndex += graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex.Length;
						quadCount += num;
					}
					else
					{
						numVerts += 4;
						numUVs += 4;
						numColours += 4;
						numIndex += 6;
						quadCount++;
					}
					zDrawOffset += zSpace;
				}
				else
				{
					if (phaseId != 1)
					{
						continue;
					}
					if (currentMaterial != graphicsDrawOP.material)
					{
						subMeshId++;
						currentMaterial = graphicsDrawOP.material;
						triId = 0;
						array = submeshIndices[subMeshId];
					}
					Matrix matrix = parent._fastGetFullMatrixRef();
					if (graphicsDrawOP.simpleVectorShape != null)
					{
						Color color = renderState.colorTransform * graphicsDrawOP.color;
						for (int j = 0; j < graphicsDrawOP.simpleVectorShape.vertices.Length; j++)
						{
							Vector2 vector = graphicsDrawOP.simpleVectorShape.vertices[j];
							Vector3 vector2 = matrix.transformVector3Static(vector.x, vector.y, zDrawOffset);
							vertices[VertId++] = vector2;
							UVs[UVId++] = graphicsDrawOP.simpleVectorShape.uv[j];
							colors[ColourId++] = graphicsDrawOP.simpleVectorShape.colors[j] * color;
						}
						array = submeshIndices[subMeshId];
						for (int k = 0; k < graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex.Length; k++)
						{
							array[triId++] = graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex[k] + quadCount;
						}
						quadCount += graphicsDrawOP.simpleVectorShape.vertices.Length;
					}
					else
					{
						float x = graphicsDrawOP.x;
						float y = graphicsDrawOP.y;
						float num2 = graphicsDrawOP.drawWidth;
						float num3 = graphicsDrawOP.drawHeight;
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
						lowerLeftUV.x = drawSrcRect.x;
						lowerLeftUV.y = 1f - drawSrcRect.y;
						UVDimensions.x = drawSrcRect.width;
						UVDimensions.y = drawSrcRect.height;
						if (graphicsDrawOP.matrix != null)
						{
							UVs[UVId++] = graphicsDrawOP.calcFromUV(x + num2, y);
							UVs[UVId++] = graphicsDrawOP.calcFromUV(x + num2, y + num3);
							UVs[UVId++] = graphicsDrawOP.calcFromUV(x, y + num3);
							UVs[UVId++] = graphicsDrawOP.calcFromUV(x, y);
						}
						else
						{
							tmpUv.x = lowerLeftUV.x + UVDimensions.x;
							tmpUv.y = lowerLeftUV.y;
							UVs[UVId++] = tmpUv;
							tmpUv.x = lowerLeftUV.x + UVDimensions.x;
							tmpUv.y = lowerLeftUV.y - UVDimensions.y;
							UVs[UVId++] = tmpUv;
							tmpUv.x = lowerLeftUV.x;
							tmpUv.y = lowerLeftUV.y - UVDimensions.y;
							UVs[UVId++] = tmpUv;
							tmpUv.x = lowerLeftUV.x;
							tmpUv.y = lowerLeftUV.y;
							UVs[UVId++] = tmpUv;
						}
						if (!simpleGeneration)
						{
							colors[ColourId++] = white;
							colors[ColourId++] = white;
							colors[ColourId++] = white;
							colors[ColourId++] = white;
						}
						else
						{
							Color color2 = parent.getInheritedColor() * graphicsDrawOP.color;
							colors[ColourId++] = color2;
							colors[ColourId++] = color2;
							colors[ColourId++] = color2;
							colors[ColourId++] = color2;
						}
						bool flipped = graphicsDrawOP.flipped;
						int vertId = VertId;
						if (flipped)
						{
							vertices[VertId++] = matrix.transformVector3Static(x, y, zDrawOffset);
							vertices[VertId++] = matrix.transformVector3Static(x, y + num3, zDrawOffset);
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y + num3, zDrawOffset);
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y, zDrawOffset);
						}
						else
						{
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y, zDrawOffset);
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y + num3, zDrawOffset);
							vertices[VertId++] = matrix.transformVector3Static(x, y + num3, zDrawOffset);
							vertices[VertId++] = matrix.transformVector3Static(x, y, zDrawOffset);
						}
						if (generateNormals)
						{
							normals[vertId++] = Vector3.forward;
							normals[vertId++] = Vector3.forward;
							normals[vertId++] = Vector3.forward;
							normals[vertId++] = Vector3.forward;
						}
						if (!simpleGeneration && (parent.rotateX != 0f || parent.rotateY != 0f || parent.rotateZ != 0f))
						{
							Quaternion q = Quaternion.Euler(parent.rotateX, parent.rotateY, parent.rotateZ);
							Matrix4x4 matrix4x = Utils.MatrixFromQuaternion(q);
							vertices[VertId - 4] = matrix4x.MultiplyVector(vertices[VertId - 4]);
							vertices[VertId - 3] = matrix4x.MultiplyVector(vertices[VertId - 3]);
							vertices[VertId - 2] = matrix4x.MultiplyVector(vertices[VertId - 2]);
							vertices[VertId - 1] = matrix4x.MultiplyVector(vertices[VertId - 1]);
						}
						if (array == null)
						{
							array = submeshIndices[subMeshId];
						}
						int num4 = quadCount * 4;
						array[triId++] = num4;
						array[triId++] = num4 + 1;
						array[triId++] = num4 + 3;
						array[triId++] = num4 + 3;
						array[triId++] = num4 + 1;
						array[triId++] = num4 + 2;
						quadCount++;
					}
					zDrawOffset += zSpace;
				}
			}
		}

		public void drawMeshNow(Matrix4x4 camMatrix, Vector3 drawOffset, Vector3 drawScale)
		{
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
			currentMesh.Clear();
			currentMesh.vertices = vertices;
			if (generateNormals)
			{
				currentMesh.normals = normals;
			}
			currentMesh.uv = UVs;
			currentMesh.colors = colors;
			currentMesh.subMeshCount = submeshIndices.Count;
			for (int i = 0; i < submeshIndices.Count; i++)
			{
				int[] triangles = submeshIndices[i];
				currentMesh.SetTriangles(triangles, i);
			}
			m_SimpleMeshResult.materials = materialList.ToArray();
			m_SimpleMeshResult.mesh = currentMesh;
			return m_SimpleMeshResult;
		}
	}
}
