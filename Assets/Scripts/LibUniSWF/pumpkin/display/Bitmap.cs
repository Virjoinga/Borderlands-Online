using UnityEngine;

namespace pumpkin.display
{
	public class Bitmap : Sprite
	{
		protected Texture2D texture;

		protected GraphicsDrawOP op;

		public Bitmap(Texture2D texture, float width = 0f, float height = 0f, string pixelSnapping = "auto", bool smoothing = true)
		{
			this.texture = texture;
			if (width <= 0f)
			{
				width = texture.width;
			}
			if (height <= 0f)
			{
				height = texture.height;
			}
			op = graphics.drawRectUV(texture, new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, width, height));
			op.pixelSnapping = ((pixelSnapping == "always") ? 1 : 0);
		}

		public Bitmap(Texture2D texture, Rect srcRect, float width = 0f, float height = 0f, bool srcRectPixelSpace = true, string pixelSnapping = "auto", bool smoothing = true)
		{
			this.texture = texture;
			if (width <= 0f)
			{
				width = texture.width;
			}
			if (height <= 0f)
			{
				height = texture.height;
			}
			if (srcRectPixelSpace)
			{
				srcRect.x /= texture.width;
				srcRect.y /= texture.height;
				srcRect.width /= texture.width;
				srcRect.height /= texture.height;
			}
			op = graphics.drawRectUV(texture, srcRect, new Rect(0f, 0f, width, height));
			op.pixelSnapping = ((pixelSnapping == "always") ? 1 : 0);
		}

		public Bitmap(BitmapData bitmapData, string pixelSnapping = "auto", bool smoothing = true)
		{
			texture = bitmapData.texture;
			int num = bitmapData.width;
			int num2 = bitmapData.height;
			Rect srcRect = new Rect(0f, 0f, 1f, 1f);
			if (bitmapData.textureMode == BitmapDataTextureMode.Padd)
			{
				srcRect.width = (float)bitmapData.width / (float)bitmapData.potWidth;
				srcRect.height = (float)bitmapData.height / (float)bitmapData.potHeight;
			}
			op = graphics.drawRectUV(texture, srcRect, new Rect(0f, 0f, num, num2));
			op.pixelSnapping = ((pixelSnapping == "always") ? 1 : 0);
		}
	}
}
