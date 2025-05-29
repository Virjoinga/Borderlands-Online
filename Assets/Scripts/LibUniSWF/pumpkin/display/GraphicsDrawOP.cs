using UnityEngine;
using pumpkin.displayInternal;
using pumpkin.geom;

namespace pumpkin.display
{
	public class GraphicsDrawOP
	{
		public Material material;

		public Rect drawSrcRect;

		public float drawWidth;

		public float drawHeight;

		public bool flipped = false;

		public Rect srcRect;

		public float x;

		public float y;

		public float width;

		public float height;

		public Color color = Color.white;

		public int pixelSnapping = 0;

		public object userData = null;

		private Rect calcClipping_resultZero = default(Rect);

		private Rect calcClipping_result;

		public SimpleVectorShape simpleVectorShape;

		public Vector3[] _cachedVertices = null;

		public Vector2[] _cachedUVs = null;

		public Color[] _cachedColors = null;

		public Matrix matrix;

		public Vector2 calcFromUV(float x, float y)
		{
			Texture mainTexture = material.mainTexture;
			Vector2 vector = matrix.transformPoint(new Vector2(x, y));
			return new Vector2(vector.x / (float)mainTexture.width, 1f - vector.y / (float)mainTexture.height);
		}

		internal Rect calcClipping(Sprite parent, Rect clipRect)
		{
			Matrix fullMatrix = parent.getFullMatrix();
			fullMatrix.invert();
			float num = clipRect.x * fullMatrix.a + clipRect.y * fullMatrix.c + fullMatrix.tx;
			float num2 = clipRect.x * fullMatrix.b + clipRect.y * fullMatrix.d + fullMatrix.ty;
			float num3 = fullMatrix.a * clipRect.width;
			float num4 = fullMatrix.d * clipRect.height;
			float num5 = x;
			float num6 = y;
			float num7 = x + width;
			float num8 = y + height;
			float num9 = num;
			float num10 = num2;
			float num11 = num9 + num3;
			float num12 = num10 + num4;
			float num13 = ((!(num5 < num9)) ? num5 : num9);
			float num14 = ((!(num7 > num11)) ? num7 : num11);
			if (num14 <= num13)
			{
				return calcClipping_resultZero;
			}
			float num15 = ((!(num6 < num10)) ? num6 : num10);
			float num16 = ((!(num8 > num12)) ? num8 : num12);
			if (num16 <= num15)
			{
				return calcClipping_resultZero;
			}
			calcClipping_result.x = num13;
			calcClipping_result.y = num15;
			calcClipping_result.width = num14 - num13;
			calcClipping_result.height = num16 - num15;
			return calcClipping_result;
		}
	}
}
