using System;
using UnityEngine;
using pumpkin.geom;
using pumpkin.uniSWFInternal;
using pumpkin.uniSWFInternal.pro;
using pumpkin.uniSWFInternal.utils;

namespace pumpkin.display
{
	public class BitmapData : IBitmapDrawable
	{
		protected static GameObject g_DrawCamObject;

		internal static bool m_lcheck = false;

		protected Texture2D m_Texture;

		protected int m_Width = 0;

		protected int m_Height = 0;

		protected BitmapDataTextureMode m_TextureMode;

		public int width
		{
			get
			{
				return m_Width;
			}
		}

		public int height
		{
			get
			{
				return m_Height;
			}
		}

		public int potWidth
		{
			get
			{
				return m_Texture.width;
			}
		}

		public int potHeight
		{
			get
			{
				return m_Texture.height;
			}
		}

		public Texture2D texture
		{
			get
			{
				return m_Texture;
			}
		}

		public BitmapDataTextureMode textureMode
		{
			get
			{
				return m_TextureMode;
			}
		}

		public BitmapData(int width, int height, bool transparent = true, BitmapDataTextureMode textureMode = BitmapDataTextureMode.Padd)
		{
			_initCtor(width, height, transparent, Color.white, textureMode);
		}

		public BitmapData(int width, int height, bool transparent, Color fillColor, BitmapDataTextureMode textureMode = BitmapDataTextureMode.Padd)
		{
			_initCtor(width, height, transparent, fillColor, textureMode);
		}

		protected void _initCtor(int width, int height, bool transparent, Color fillColor, BitmapDataTextureMode mode)
		{
			m_Width = width;
			m_Height = height;
			m_TextureMode = mode;
			m_Texture = new Texture2D(TextureMathUtils.UpToPower2(width), TextureMathUtils.UpToPower2(height), (!transparent) ? TextureFormat.RGB24 : TextureFormat.ARGB32, false);
			int num = m_Texture.width * m_Texture.height;
			Color[] array = new Color[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = fillColor;
			}
			m_Texture.SetPixels(array);
		}

		public void clear()
		{
			clear(Color.clear);
		}

		public void clear(Color fillColor)
		{
			int num = m_Texture.width * m_Texture.height;
			Color[] array = new Color[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = fillColor;
			}
			m_Texture.SetPixels(array);
		}

		public void draw(IBitmapDrawable source, Matrix matrix = null, ColorTransform colorTransform = null, int blendMode = 0, Rectangle clipRect = null, bool smoothing = false)
		{
			if (!m_lcheck)
			{
				if (!UniSWFLicense.isPro())
				{
					throw new Exception(UniSWFLicense.PRO_WARNING_STR);
				}
				m_lcheck = true;
			}
			if (source is BitmapData)
			{
				source = new Bitmap(source as BitmapData);
			}
			DisplayObject displayObject = source as DisplayObject;
			if (displayObject != null)
			{
				Matrix matrix2 = displayObject.getMatrix();
				DisplayObjectContainer parent = displayObject.parent;
				if (parent != null)
				{
					parent.removeChild(displayObject);
				}
				Matrix matrix3 = displayObject.getMatrix();
				if (matrix != null)
				{
					displayObject.setMatrix(matrix);
				}
				else
				{
					displayObject.setMatrix(new Matrix());
				}
				Camera camera;
				MovieClipOverlayCameraBehaviour movieClipOverlayCameraBehaviour;
				if (!g_DrawCamObject)
				{
					g_DrawCamObject = new GameObject();
					camera = g_DrawCamObject.AddComponent<Camera>();
					camera.orthographic = true;
					camera.enabled = true;
					camera.name = "DynCamera";
					movieClipOverlayCameraBehaviour = g_DrawCamObject.AddComponent<MovieClipOverlayCameraBehaviour>();
				}
				else
				{
					movieClipOverlayCameraBehaviour = g_DrawCamObject.GetComponent<MovieClipOverlayCameraBehaviour>();
					movieClipOverlayCameraBehaviour.enabled = true;
					movieClipOverlayCameraBehaviour.camera.enabled = true;
					camera = movieClipOverlayCameraBehaviour.gameObject.GetComponent<Camera>();
					movieClipOverlayCameraBehaviour.updateCalcDrawOffsets();
				}
				camera.backgroundColor = Color.white;
				movieClipOverlayCameraBehaviour.camera.depth = 999f;
				Stage stage = movieClipOverlayCameraBehaviour.stage;
				stage.setMatrix(new Matrix());
				stage.addChild(displayObject);
				Rect rect = displayObject.getBounds(displayObject.parent).rect;
				displayObject.x += 0f - rect.x;
				displayObject.y += 0f - rect.y;
				RTTDisplayObjectRenderer.drawCameraToBitmap(rect, camera, m_Texture);
				m_Width = (int)rect.width;
				m_Height = (int)rect.height;
				if (parent != null)
				{
					parent.addChild(displayObject);
				}
				displayObject.setMatrix(matrix3);
				movieClipOverlayCameraBehaviour.enabled = false;
				movieClipOverlayCameraBehaviour.camera.enabled = false;
				movieClipOverlayCameraBehaviour.camera.targetTexture = null;
				stage.removeAllChildren();
				UnityEngine.Object.Destroy(g_DrawCamObject);
				g_DrawCamObject = null;
			}
		}

		public void _dev_draw(IBitmapDrawable source, bool autoSize = true)
		{
			if (!m_lcheck)
			{
				if (!UniSWFLicense.isPro())
				{
					throw new Exception(UniSWFLicense.PRO_WARNING_STR);
				}
				m_lcheck = true;
			}
			if (source is BitmapData)
			{
				source = new Bitmap(source as BitmapData);
			}
			DisplayObject displayObject = source as DisplayObject;
			if (displayObject != null)
			{
				Matrix matrix = displayObject.getMatrix();
				DisplayObjectContainer parent = displayObject.parent;
				if (parent != null)
				{
					parent.removeChild(displayObject);
				}
				Matrix matrix2 = displayObject.getMatrix();
				displayObject.setMatrix(new Matrix());
				GameObject gameObject = new GameObject();
				Camera camera = gameObject.AddComponent<Camera>();
				camera.orthographic = true;
				camera.enabled = true;
				camera.name = "DynCamera";
				MovieClipOverlayCameraBehaviour movieClipOverlayCameraBehaviour = gameObject.AddComponent<MovieClipOverlayCameraBehaviour>();
				movieClipOverlayCameraBehaviour.camera.depth = 999f;
				Stage stage = movieClipOverlayCameraBehaviour.stage;
				stage.addChild(displayObject);
				Rect rect = displayObject.getBounds(displayObject.parent).rect;
				displayObject.x += 0f - rect.x;
				displayObject.y += 0f - rect.y;
				RTTDisplayObjectRenderer.drawCameraToBitmap(rect, camera, m_Texture);
				m_Width = (int)rect.width;
				m_Height = (int)rect.height;
				if (parent != null)
				{
					parent.addChild(displayObject);
				}
				displayObject.setMatrix(matrix2);
				movieClipOverlayCameraBehaviour.enabled = false;
				movieClipOverlayCameraBehaviour.camera.enabled = false;
				stage.removeAllChildren();
			}
		}

		public Color getColor(int x, int y)
		{
			return texture.GetPixel(x, texture.height - y);
		}

		public void setColor(int x, int y, Color color)
		{
			texture.SetPixel(x, texture.height - y, color);
		}
	}
}
