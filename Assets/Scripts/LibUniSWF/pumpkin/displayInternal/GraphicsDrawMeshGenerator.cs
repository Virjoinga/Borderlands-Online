using System;
using System.Collections;
using UnityEngine;
using pumpkin.display;
using pumpkin.geom;
using pumpkin.swf;
using pumpkin.utils;

namespace pumpkin.displayInternal
{
	public class GraphicsDrawMeshGenerator : IGraphicsGenerator
	{
		public Material currentMaterial;

		private int subMeshId = 0;

		public static int PHASE_SCAN = 0;

		public static int PHASE_BUILD = 1;

		public static int PHASE_NULL = 2;

		public float zSpace = 0.1f;

		public float zContainerSpace = 0f;

		public Vector3[] vertices = new Vector3[0];

		public Vector2[] UVs = new Vector2[0];

		public Color[] colors = new Color[0];

		public ArrayList materialList = new ArrayList();

		public ArrayList submeshIndices = new ArrayList();

		public bool enableCache = false;

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

		public static bool enableSubPixel_uv = false;

		public static bool enableSubPixel_vert = true;

		private Vector2 tmpUv;

		private Vector2 lowerLeftUV;

		private Vector2 UVDimensions;

		private Color white = Color.white;

		private ArrayList meshes = new ArrayList();

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
			phaseId = PHASE_SCAN;
			numVerts = 0;
			numUVs = 0;
			numColours = 0;
			numIndex = 0;
			SwfGraphicsRenderState renderState = default(SwfGraphicsRenderState);
			renderState.blendMode = 0;
			renderState.colorTransform.r = (renderState.colorTransform.g = (renderState.colorTransform.b = (renderState.colorTransform.a = 1f)));
			renderState.parentHasClipRect = false;
			renderState.clipRectParent = null;
			renderState.clipRectCached = false;
			renderDisplayObjectContainer(stage, renderState);
			materialList.Add(currentMaterial);
			submeshIndices.Add(new int[numIndex]);
			Mesh currentMesh = getCurrentMesh();
			currentMesh.Clear();
			if (vertices.Length != numVerts)
			{
				vertices = new Vector3[numVerts];
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
			phaseId = PHASE_BUILD;
			VertId = 0;
			UVId = 0;
			ColourId = 0;
			triId = 0;
			renderState.blendMode = 0;
			renderState.colorTransform.r = (renderState.colorTransform.g = (renderState.colorTransform.b = (renderState.colorTransform.a = 1f)));
			renderState.parentHasClipRect = false;
			renderState.clipRectParent = null;
			renderState.clipRectCached = false;
			renderDisplayObjectContainer(stage, renderState);
			updateCounter = Time.frameCount;
			currentMesh.vertices = vertices;
			currentMesh.uv = UVs;
			currentMesh.colors = colors;
			currentMesh.subMeshCount = submeshIndices.Count;
			for (int i = 0; i < submeshIndices.Count; i++)
			{
				int[] triangles = (int[])submeshIndices[i];
				currentMesh.SetTriangles(triangles, i);
			}
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
			currentMesh.uv = UVs;
			currentMesh.colors = colors;
			if ((bool)meshRenderer)
			{
				meshRenderer.materials = (Material[])materialList.ToArray(typeof(Material));
			}
			currentMesh.subMeshCount = submeshIndices.Count;
			for (int i = 0; i < submeshIndices.Count; i++)
			{
				int[] triangles = (int[])submeshIndices[i];
				currentMesh.SetTriangles(triangles, i);
			}
			return currentMesh;
		}

		private void renderDisplayObjectContainer(DisplayObjectContainer parent, SwfGraphicsRenderState renderState)
		{
			if (!parent.visible)
			{
				return;
			}
			if (phaseId == PHASE_SCAN || phaseId == PHASE_BUILD)
			{
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
			if (!parent.visible || parent.alpha <= 0f)
			{
				return;
			}
			if (phaseId == PHASE_SCAN || phaseId == PHASE_BUILD)
			{
			}
			for (int i = 0; i < gfx.drawOPs.Count; i++)
			{
				GraphicsDrawOP graphicsDrawOP = gfx.drawOPs[i];
				if (graphicsDrawOP.material == null)
				{
					continue;
				}
				if (renderState.blendMode != 0 && graphicsDrawOP.material.shader != TextureManager.baseBitmapAddShader)
				{
					Texture mainTexture = graphicsDrawOP.material.mainTexture;
					graphicsDrawOP.material = new Material(TextureManager.baseBitmapAddShader);
					graphicsDrawOP.material.mainTexture = mainTexture;
				}
				if (stage.enableAlphaMask)
				{
					DisplayObject inheritedMask = parent.getInheritedMask();
					if (inheritedMask != null && inheritedMask is pumpkin.display.Sprite)
					{
						if (graphicsDrawOP.material.shader != TextureManager.baseBitmapMaskShader && graphicsDrawOP.material.shader != TextureManager.baseColorShader)
						{
							Texture texture = null;
							texture = graphicsDrawOP.material.mainTexture;
							GraphicsDrawOP graphicsOpInDisplayObject = getGraphicsOpInDisplayObject(inheritedMask);
							if (graphicsOpInDisplayObject != null && texture != null)
							{
								Texture mainTexture2 = graphicsOpInDisplayObject.material.mainTexture;
								graphicsDrawOP.material = new Material(TextureManager.baseBitmapMaskShader);
								graphicsDrawOP.material.mainTexture = texture;
								graphicsDrawOP.material.SetTexture("_MaskTex", mainTexture2);
							}
						}
						if (graphicsDrawOP.material.shader == TextureManager.baseBitmapMaskShader)
						{
							updateMask(inheritedMask, parent, graphicsDrawOP.material);
						}
					}
					else if (!(graphicsDrawOP.material.shader == TextureManager.baseBitmapMaskShader))
					{
					}
				}
				if (phaseId == PHASE_SCAN)
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
					if (phaseId != PHASE_BUILD)
					{
						continue;
					}
					if (currentMaterial != graphicsDrawOP.material)
					{
						subMeshId++;
						currentMaterial = graphicsDrawOP.material;
						triId = 0;
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
						int[] array = (int[])submeshIndices[subMeshId];
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
						float inZ = zDrawOffset;
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
						if (enableSubPixel_uv && !TextureManager.isOpenGL && currentMaterial.HasProperty("_MainTex"))
						{
							Vector2 vector3 = new Vector2(1f / (float)currentMaterial.mainTexture.width, 1f / (float)currentMaterial.mainTexture.height);
							Vector2 vector4 = new Vector2(vector3.x * 0.5f, vector3.y * 0.5f);
							lowerLeftUV.x += vector4.x;
							lowerLeftUV.y += vector4.y;
							UVDimensions.x -= vector4.x;
							UVDimensions.y -= vector4.y;
							UVs[UVId - 4] = new Vector2(lowerLeftUV.x + UVDimensions.x, lowerLeftUV.y);
							UVs[UVId - 3] = new Vector2(lowerLeftUV.x + UVDimensions.x, lowerLeftUV.y - UVDimensions.y);
							UVs[UVId - 2] = new Vector2(lowerLeftUV.x, lowerLeftUV.y - UVDimensions.y);
							UVs[UVId - 1] = new Vector2(lowerLeftUV.x, lowerLeftUV.y);
						}
						Color color2 = renderState.colorTransform * graphicsDrawOP.color;
						colors[ColourId++] = color2;
						colors[ColourId++] = color2;
						colors[ColourId++] = color2;
						colors[ColourId++] = color2;
						if (graphicsDrawOP.flipped)
						{
							vertices[VertId++] = matrix.transformVector3Static(x, y, inZ);
							vertices[VertId++] = matrix.transformVector3Static(x, y + num3, inZ);
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y + num3, inZ);
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y, inZ);
						}
						else
						{
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y, inZ);
							vertices[VertId++] = matrix.transformVector3Static(x + num2, y + num3, inZ);
							vertices[VertId++] = matrix.transformVector3Static(x, y + num3, inZ);
							vertices[VertId++] = matrix.transformVector3Static(x, y, inZ);
						}
						if (enableSubPixel_vert)
						{
							Vector3 one = Vector3.one;
							Vector3 vector5 = ((!TextureManager.isOpenGL) ? (one * 0.5f) : Vector3.zero);
							if (graphicsDrawOP.pixelSnapping != 0)
							{
								vertices[VertId - 4].x = Mathf.Floor(vertices[VertId - 4].x);
								vertices[VertId - 4].y = Mathf.Floor(vertices[VertId - 4].y);
								vertices[VertId - 3].x = Mathf.Floor(vertices[VertId - 3].x);
								vertices[VertId - 3].y = Mathf.Floor(vertices[VertId - 3].y);
								vertices[VertId - 2].x = Mathf.Floor(vertices[VertId - 2].x);
								vertices[VertId - 2].y = Mathf.Floor(vertices[VertId - 2].y);
								vertices[VertId - 1].x = Mathf.Floor(vertices[VertId - 1].x);
								vertices[VertId - 1].y = Mathf.Floor(vertices[VertId - 1].y);
							}
							vertices[VertId - 4] -= vector5;
							vertices[VertId - 3] -= vector5;
							vertices[VertId - 2] -= vector5;
							vertices[VertId - 1] -= vector5;
						}
						if (parent.rotateX != 0f || parent.rotateY != 0f || parent.rotateZ != 0f)
						{
							Quaternion q = Quaternion.Euler(parent.rotateX, parent.rotateY, parent.rotateZ);
							Matrix4x4 matrix4x = Utils.MatrixFromQuaternion(q);
							vertices[VertId - 4] = matrix4x.MultiplyVector(vertices[VertId - 4]);
							vertices[VertId - 3] = matrix4x.MultiplyVector(vertices[VertId - 3]);
							vertices[VertId - 2] = matrix4x.MultiplyVector(vertices[VertId - 2]);
							vertices[VertId - 1] = matrix4x.MultiplyVector(vertices[VertId - 1]);
						}
						if (subMeshId >= submeshIndices.Count)
						{
							break;
						}
						int[] array2 = (int[])submeshIndices[subMeshId];
						array2[triId++] = quadCount * 4;
						array2[triId++] = quadCount * 4 + 1;
						array2[triId++] = quadCount * 4 + 3;
						array2[triId++] = quadCount * 4 + 3;
						array2[triId++] = quadCount * 4 + 1;
						array2[triId++] = quadCount * 4 + 2;
						quadCount++;
					}
					zDrawOffset += zSpace;
				}
			}
		}

		private void updateMask(DisplayObject maskSprite, DisplayObject sprite, Material maskedMaterial)
		{
			Matrix matrix = maskSprite.getFullMatrix().clone();
			Matrix matrix2 = sprite.getFullMatrix().clone();
			Vector2 vector = matrix.transformPoint(Vector2.zero);
			Vector2 vector2 = matrix2.transformPoint(Vector2.zero);
			Vector2 vector3 = new Vector2(matrix2.getScaleX(), matrix2.getScaleY());
			Vector2 vector4 = new Vector2(matrix.getScaleX(), matrix.getScaleY());
			float num = maskSprite.rotation - sprite.rotation;
			Matrix matrix3 = new Matrix(vector3.x * (1f / vector4.x), 0f, 0f, (0f - vector3.y) * (1f / vector4.y), 0f, 0f);
			float rad = (float)((double)num * Math.PI / 180.0);
			matrix3.rotate(rad);
			maskedMaterial.SetVector("_Matrix2D", new Vector4(matrix3.a, matrix3.b, matrix3.c, matrix3.d));
			Matrix matrix4 = new Matrix(1f, 0f, 0f, 1f, vector.x - vector2.x, vector.y - vector2.y);
			rad = (float)((double)(0f - maskSprite.rotation) * Math.PI / 180.0);
			matrix4.rotate(rad);
			Vector2 vector5 = matrix4.transformPoint(Vector2.zero);
			maskedMaterial.SetFloat("_tX", (0f - vector5.x / (float)maskedMaterial.mainTexture.width) * (1f / vector4.x));
			maskedMaterial.SetFloat("_tY", vector5.y / (float)maskedMaterial.mainTexture.height * (1f / vector4.y));
		}

		private GraphicsDrawOP getGraphicsOpInDisplayObject(DisplayObject parent)
		{
			if (parent is pumpkin.display.Sprite)
			{
				pumpkin.display.Sprite sprite = parent as pumpkin.display.Sprite;
				if (sprite.graphics.drawOPs.Count > 0)
				{
					return sprite.graphics.drawOPs[0];
				}
			}
			if (parent is DisplayObjectContainer || parent is MovieClip)
			{
				DisplayObjectContainer displayObjectContainer = parent as DisplayObjectContainer;
				for (int i = 0; i < displayObjectContainer.numChildren; i++)
				{
					GraphicsDrawOP graphicsOpInDisplayObject = getGraphicsOpInDisplayObject(displayObjectContainer.getChildAt(i));
					if (graphicsOpInDisplayObject != null)
					{
						return graphicsOpInDisplayObject;
					}
				}
			}
			return null;
		}

		public void drawMeshNow(Matrix4x4 camMatrix, Vector3 drawOffset, Vector3 drawScale)
		{
			drawOffset.z += 1f;
			drawScale.z = drawScale.x;
			Matrix4x4 matrix4x = Matrix4x4.TRS(drawOffset, Quaternion.identity, drawScale);
			matrix4x = camMatrix * matrix4x;
			Mesh currentMesh = getCurrentMesh();
			currentMesh.subMeshCount = submeshIndices.Count;
			for (int i = 0; i < submeshIndices.Count; i++)
			{
				Material material = (Material)materialList[i];
				if (!(material == null) && material.SetPass(0))
				{
					UnityEngine.Graphics.DrawMeshNow(currentMesh, matrix4x, i);
				}
			}
		}

		public void drawMeshTest(Matrix4x4 camMatrix, Vector3 drawOffset, Vector3 drawScale)
		{
			drawScale.z = drawScale.x * -10f;
			Matrix4x4 matrix4x = Matrix4x4.TRS(drawOffset, Quaternion.identity, drawScale);
			matrix4x = camMatrix * matrix4x;
			while (meshes.Count < submeshIndices.Count)
			{
				meshes.Add(new Mesh());
			}
			Mesh currentMesh = getCurrentMesh();
			currentMesh.subMeshCount = submeshIndices.Count;
			for (int i = 0; i < submeshIndices.Count; i++)
			{
				Mesh mesh = (Mesh)meshes[i];
				mesh.Clear();
				mesh.vertices = vertices;
				mesh.uv = UVs;
				mesh.colors = colors;
				mesh.triangles = (int[])submeshIndices[i];
				Material material = (Material)materialList[i];
				UnityEngine.Graphics.DrawMesh(mesh, matrix4x, material, 0, null, 0, null);
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
			m_SimpleMeshResult.materials = (Material[])materialList.ToArray(typeof(Material));
			m_SimpleMeshResult.mesh = currentMesh;
			return m_SimpleMeshResult;
		}
	}
}
