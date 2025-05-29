using UnityEngine;

namespace pumpkin.displayInternal
{
	internal class UVPixelRect
	{
		public float pX;

		public float pY;

		public float pW;

		public float pH;

		public float uX;

		public float uY;

		public float uW;

		public float uH;

		public UVPixelRect(float pX, float pY, float pW, float pH, float uX, float uY, float uW, float uH)
		{
			this.pX = pX;
			this.pY = pY;
			this.pW = pW;
			this.pH = pH;
			this.uX = uX;
			this.uY = uY;
			this.uW = uW;
			this.uH = uH;
		}

		public float setWidthPixels(float newWidth)
		{
			float num = uW / pW;
			pW = newWidth;
			uW = pW * num;
			return pW;
		}

		public float setHeightPixels(float newHeight)
		{
			float num = uH / pH;
			pH = newHeight;
			uH = pH * num;
			return pH;
		}

		public float setXPixels(float newX)
		{
			float num = uW / pW;
			float num2 = newX - pX;
			pX = newX;
			uX += num2 * num;
			return pX;
		}

		public float setYPixels(float newY)
		{
			float num = uH / pH;
			float num2 = newY - pY;
			pY = newY;
			uY += num2 * num;
			return pY;
		}

		public override string ToString()
		{
			return "UVPixelRect( " + pX + ", " + pY + ", " + pW + ", " + pH + ", " + uX + ", " + uY + ", " + uW + ", " + uH + " )";
		}

		public string ToStringWithPixels(Texture tex)
		{
			return "UVPixelRect( " + pX + ", " + pY + ", " + pW + ", " + pH + ", " + uX * (float)tex.width + ", " + uY * (float)tex.height + ", " + uW * (float)tex.width + ", " + uH * (float)tex.height + " )";
		}
	}
}
