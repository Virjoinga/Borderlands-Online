using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.geom;
using pumpkin.swf;

namespace pumpkin.display
{
	public class Graphics
	{
		public delegate bool HitTestDelegate(float x, float y);

		public List<GraphicsDrawOP> drawOPs = new List<GraphicsDrawOP>();

		public HitTestDelegate hitTestCallback = null;

		private Vector2 m_BoundsTopLeft = default(Vector2);

		private Vector2 m_BoundsBottomRight = default(Vector2);

		protected bool m_PerPixelHitTest = false;

		public uint dirtyMask = uint.MaxValue;

		private static bool g_GetPixel_shown = false;

		public bool perPixelHitTestEnabled
		{
			get
			{
				return m_PerPixelHitTest;
			}
			set
			{
				dirtyMask |= 2u;
				m_PerPixelHitTest = value;
			}
		}

		public void clear()
		{
			m_BoundsTopLeft.x = 0f;
			m_BoundsTopLeft.y = 0f;
			m_BoundsBottomRight.x = 0f;
			m_BoundsBottomRight.y = 0f;
			drawOPs.Clear();
			dirtyMask |= 2u;
		}

		public GraphicsDrawOP drawSolidRectangle(Color c, float x, float y, float width, float height)
		{
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			Material material = new Material(TextureManager.baseColorShader);
			material.color = c;
			return drawRectUV(material, default(Rect), x, y, width, height);
		}

		public GraphicsDrawOP drawRectUV(Texture texture, Rect srcRect, Rect drawRect)
		{
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			Material material = new Material(TextureManager.baseBitmapShader);
			material.mainTexture = texture;
			return drawRectUV(material, srcRect, drawRect);
		}

		public GraphicsDrawOP drawRectUV(Material material, Rect srcRect, Rect drawRect)
		{
			return drawRectUV(material, srcRect, drawRect.x, drawRect.y, drawRect.width, drawRect.height);
		}

		public GraphicsDrawOP drawRectUV(Material material, Rect srcRect, float x, float y, float width, float height)
		{
			dirtyMask |= 2u;
			GraphicsDrawOP graphicsDrawOP = new GraphicsDrawOP();
			graphicsDrawOP.material = material;
			graphicsDrawOP.drawSrcRect = srcRect;
			graphicsDrawOP.srcRect = srcRect;
			graphicsDrawOP.x = x;
			graphicsDrawOP.y = y;
			graphicsDrawOP.width = width;
			graphicsDrawOP.height = height;
			graphicsDrawOP.drawWidth = width;
			graphicsDrawOP.drawHeight = height;
			if (drawOPs.Count == 0)
			{
				m_BoundsTopLeft.x = x;
				m_BoundsTopLeft.y = y;
				m_BoundsBottomRight.x = x + width;
				m_BoundsBottomRight.y = y + height;
			}
			else
			{
				if (x < m_BoundsTopLeft.x)
				{
					m_BoundsTopLeft.x = x;
				}
				if (y < m_BoundsTopLeft.y)
				{
					m_BoundsTopLeft.y = y;
				}
				if (x + width > m_BoundsBottomRight.x)
				{
					m_BoundsBottomRight.x = x + width;
				}
				if (y + height > m_BoundsBottomRight.y)
				{
					m_BoundsBottomRight.y = y + height;
				}
			}
			drawOPs.Add(graphicsDrawOP);
			return graphicsDrawOP;
		}

		public void cacheBounds()
		{
			m_BoundsTopLeft.x = 0f;
			m_BoundsTopLeft.y = 0f;
			m_BoundsBottomRight.x = 0f;
			m_BoundsBottomRight.y = 0f;
			for (int i = 0; i < drawOPs.Count; i++)
			{
				GraphicsDrawOP graphicsDrawOP = drawOPs[i];
				float x = graphicsDrawOP.x;
				float y = graphicsDrawOP.y;
				float drawWidth = graphicsDrawOP.drawWidth;
				float drawHeight = graphicsDrawOP.drawHeight;
				if (x < m_BoundsTopLeft.x || i == 0)
				{
					m_BoundsTopLeft.x = x;
				}
				if (y < m_BoundsTopLeft.y || i == 0)
				{
					m_BoundsTopLeft.y = y;
				}
				if (x + drawWidth > m_BoundsBottomRight.x || i == 0)
				{
					m_BoundsBottomRight.x = x + drawWidth;
				}
				if (y + drawHeight > m_BoundsBottomRight.y || i == 0)
				{
					m_BoundsBottomRight.y = y + drawHeight;
				}
			}
		}

		public Rectangle getBounds()
		{
			return new Rectangle(m_BoundsTopLeft.x, m_BoundsTopLeft.y, m_BoundsBottomRight.x - m_BoundsTopLeft.x, m_BoundsBottomRight.y - m_BoundsTopLeft.y);
		}

		[Obsolete("method renamed to hitTest")]
		public virtual bool HitTest(float x, float y)
		{
			return hitTest(x, y);
		}

		private bool inPoly(Vector2[] vert, float testX, float testY)
		{
			bool flag = false;
			int num = 0;
			int num2 = vert.Length - 1;
			while (num < vert.Length)
			{
				if (vert[num].y > testY != vert[num2].y > testY && testX < (vert[num2].x - vert[num].x) * (testY - vert[num].y) / (vert[num2].y - vert[num].y) + vert[num].x)
				{
					flag = !flag;
				}
				num2 = num++;
			}
			return flag;
		}

		public virtual bool hitTest(float x, float y)
		{
			if (hitTestCallback != null)
			{
				return hitTestCallback(x, y);
			}
			if (m_PerPixelHitTest)
			{
				for (int i = 0; i < drawOPs.Count; i++)
				{
					GraphicsDrawOP graphicsDrawOP = drawOPs[i];
					if (!(x >= graphicsDrawOP.x) || !(y >= graphicsDrawOP.y) || !(x < graphicsDrawOP.x + graphicsDrawOP.drawWidth) || !(y < graphicsDrawOP.y + graphicsDrawOP.drawHeight))
					{
						continue;
					}
					if (!graphicsDrawOP.material.HasProperty("_MainTex"))
					{
						m_PerPixelHitTest = false;
						continue;
					}
					Texture2D texture2D = graphicsDrawOP.material.mainTexture as Texture2D;
					if ((bool)texture2D)
					{
						try
						{
							float num = graphicsDrawOP.drawSrcRect.width * (float)texture2D.width / graphicsDrawOP.drawWidth;
							float num2 = graphicsDrawOP.drawSrcRect.height * (float)texture2D.height / graphicsDrawOP.drawHeight;
							if ((double)texture2D.GetPixel((int)(x * num + graphicsDrawOP.drawSrcRect.x * (float)texture2D.width), texture2D.height - (int)(y * num2 + graphicsDrawOP.drawSrcRect.y * (float)texture2D.height)).a > 0.1)
							{
								return true;
							}
							return false;
						}
						catch (UnityException ex)
						{
							if (Application.isEditor && !g_GetPixel_shown)
							{
								g_GetPixel_shown = true;
								Debug.LogWarning("" + ex);
							}
							m_PerPixelHitTest = false;
							return HitTest(x, y);
						}
					}
					return true;
				}
				return false;
			}
			for (int j = 0; j < drawOPs.Count; j++)
			{
				GraphicsDrawOP graphicsDrawOP2 = drawOPs[j];
				if (graphicsDrawOP2.simpleVectorShape != null && graphicsDrawOP2.simpleVectorShape.mouseEnabled && inPoly(graphicsDrawOP2.simpleVectorShape.vertices, x, y))
				{
					return true;
				}
				if (x >= graphicsDrawOP2.x && y >= graphicsDrawOP2.y && x < graphicsDrawOP2.x + graphicsDrawOP2.drawWidth && y < graphicsDrawOP2.y + graphicsDrawOP2.drawHeight)
				{
					return true;
				}
			}
			return false;
		}

		public void invalidateCache()
		{
			dirtyMask |= 2u;
		}

		public GraphicsDrawOP getDrawOPAt(int index)
		{
			return drawOPs[index];
		}

		public GraphicsDrawOP drawTile(Material material, Matrix matrix, float x, float y, float width, float height)
		{
			matrix = ((matrix == null) ? new Matrix() : matrix.clone().invert());
			dirtyMask |= 2u;
			GraphicsDrawOP graphicsDrawOP = new GraphicsDrawOP();
			graphicsDrawOP.material = material;
			graphicsDrawOP.x = x;
			graphicsDrawOP.y = y;
			graphicsDrawOP.width = width;
			graphicsDrawOP.height = height;
			graphicsDrawOP.drawWidth = width;
			graphicsDrawOP.drawHeight = height;
			graphicsDrawOP.matrix = matrix;
			if (drawOPs.Count == 0)
			{
				m_BoundsTopLeft.x = x;
				m_BoundsTopLeft.y = y;
				m_BoundsBottomRight.x = x + width;
				m_BoundsBottomRight.y = y + height;
			}
			else
			{
				if (x < m_BoundsTopLeft.x)
				{
					m_BoundsTopLeft.x = x;
				}
				if (y < m_BoundsTopLeft.y)
				{
					m_BoundsTopLeft.y = y;
				}
				if (x + width > m_BoundsBottomRight.x)
				{
					m_BoundsBottomRight.x = x + width;
				}
				if (y + height > m_BoundsBottomRight.y)
				{
					m_BoundsBottomRight.y = y + height;
				}
			}
			drawOPs.Add(graphicsDrawOP);
			return graphicsDrawOP;
		}
	}
}
