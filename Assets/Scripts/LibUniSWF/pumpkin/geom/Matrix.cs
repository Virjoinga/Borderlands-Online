using System;
using UnityEngine;
using pumpkin.geom.structs;

namespace pumpkin.geom
{
	public class Matrix
	{
		public float a = 1f;

		public float b = 0f;

		public float c = 0f;

		public float d = 1f;

		public float tx = 0f;

		public float ty = 0f;

		private static Vector3 transformVector3Static_res = default(Vector3);

		public Matrix()
		{
			a = 1f;
			b = 0f;
			c = 0f;
			d = 1f;
			tx = 0f;
			ty = 0f;
		}

		public Matrix(float a, float b, float c, float d, float tx, float ty)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
			this.tx = tx;
			this.ty = ty;
		}

		public Matrix clone()
		{
			return new Matrix(a, b, c, d, tx, ty);
		}

		public void setRotation(float inTa)
		{
			setRotation(inTa, 1f);
		}

		public void setRotation(float inTa, float inScale)
		{
			a = (float)Math.Cos(inTa) * inScale;
			c = (float)Math.Sin(inTa) * inScale;
			b = 0f - c;
			d = a;
		}

		public Matrix invert()
		{
			float num = a * d - b * c;
			if (num == 0f)
			{
				a = (b = (c = (d = 0f)));
				tx = 0f - tx;
				ty = 0f - ty;
			}
			else
			{
				num = 1f / num;
				float num2 = d * num;
				d = a * num;
				a = num2;
				b *= 0f - num;
				c *= 0f - num;
				float num3 = (0f - a) * tx - c * ty;
				ty = (0f - b) * tx - d * ty;
				tx = num3;
			}
			return this;
		}

		public Vector2 transformPoint(Vector2 inPos)
		{
			return new Vector2(inPos.x * a + inPos.y * c + tx, inPos.x * b + inPos.y * d + ty);
		}

		public Vector3 transformVector3(Vector3 inPos)
		{
			return new Vector3(inPos.x * a + inPos.y * c + tx, inPos.x * b + inPos.y * d + ty);
		}

		internal Vector3 transformVector3Static(float inX, float inY, float inZ)
		{
			transformVector3Static_res.x = inX * a + inY * c + tx;
			transformVector3Static_res.y = inX * b + inY * d + ty;
			transformVector3Static_res.z = inZ;
			return transformVector3Static_res;
		}

		public Vector3 transformVector3(float inX, float inY, float inZ)
		{
			return new Vector3(inX * a + inY * c + tx, inX * b + inY * d + ty, inZ);
		}

		public void translate(float inX, float inY)
		{
			tx += inX;
			ty += inY;
		}

		public void rotate(float rad)
		{
			float num = (float)Math.Cos(rad);
			float num2 = (float)Math.Sin(rad);
			float num3 = a * num - b * num2;
			b = a * num2 + b * num;
			a = num3;
			float num4 = c * num - d * num2;
			d = c * num2 + d * num;
			c = num4;
			float num5 = tx * num - ty * num2;
			ty = tx * num2 + ty * num;
			tx = num5;
		}

		public void scale(float inSX, float inSY)
		{
			a *= inSX;
			b *= inSY;
			c *= inSX;
			d *= inSY;
			tx *= inSX;
			ty *= inSY;
		}

		public void concat(Matrix m)
		{
			float num = a * m.a + b * m.c;
			b = a * m.b + b * m.d;
			a = num;
			float num2 = c * m.a + d * m.c;
			d = c * m.b + d * m.d;
			c = num2;
			float num3 = tx * m.a + ty * m.c + m.tx;
			ty = tx * m.b + ty * m.d + m.ty;
			tx = num3;
		}

		public Matrix mult(Matrix m)
		{
			Matrix matrix = new Matrix();
			matrix.a = a * m.a + b * m.c;
			matrix.b = a * m.b + b * m.d;
			matrix.c = c * m.a + d * m.c;
			matrix.d = c * m.b + d * m.d;
			matrix.tx = tx * m.a + ty * m.c + m.tx;
			matrix.ty = tx * m.b + ty * m.d + m.ty;
			return matrix;
		}

		public void multNoCopy(Matrix m)
		{
			float num = a * m.a + b * m.c;
			float num2 = a * m.b + b * m.d;
			float num3 = c * m.a + d * m.c;
			float num4 = c * m.b + d * m.d;
			float num5 = tx * m.a + ty * m.c + m.tx;
			float num6 = tx * m.b + ty * m.d + m.ty;
			a = num;
			b = num2;
			c = num3;
			d = num4;
			tx = num5;
			ty = num6;
		}

		public void identity()
		{
			a = 1f;
			b = 0f;
			c = 0f;
			d = 1f;
			tx = 0f;
			ty = 0f;
		}

		public override string ToString()
		{
			return "matrix(" + a + ", " + b + ", " + c + ", " + d + ", " + tx + ", " + ty + ")";
		}

		public float getScaleX()
		{
			if (a < 0f)
			{
				return 0f - (float)Math.Sqrt(a * a + c * c);
			}
			return (float)Math.Sqrt(a * a + c * c);
		}

		public float getScaleY()
		{
			if (d < 0f)
			{
				return 0f - (float)Math.Sqrt(b * b + d * d);
			}
			return (float)Math.Sqrt(b * b + d * d);
		}

		public float getRotation()
		{
			double num = Math.Atan((0f - c) / a);
			float scaleX = getScaleX();
			double num2 = Math.Atan((0f - c) / a);
			double num3 = Math.Acos(a / scaleX);
			double num4 = num3 * (180.0 / Math.PI);
			num = ((num4 > 90.0 && num2 > 0.0) ? ((360.0 - num4) * Math.PI) : ((!(num4 < 90.0) || !(num2 < 0.0)) ? num3 : ((360.0 - num4) * Math.PI)));
			return (float)(num * (180.0 / Math.PI));
		}

		public Rect transformRect(Rect rectIn)
		{
			float num = a * rectIn.x + c * rectIn.y;
			float num2 = num;
			float num3 = b * rectIn.x + d * rectIn.y;
			float num4 = num;
			float num5 = a * (rectIn.x + rectIn.width) + c * rectIn.y;
			float num6 = b * (rectIn.x + rectIn.width) + d * rectIn.y;
			if (num5 < num)
			{
				num = num5;
			}
			if (num6 < num3)
			{
				num3 = num6;
			}
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (num6 > num4)
			{
				num4 = num6;
			}
			num5 = a * (rectIn.x + rectIn.width) + c * (rectIn.y + rectIn.height);
			num6 = b * (rectIn.x + rectIn.width) + d * (rectIn.y + rectIn.height);
			if (num5 < num)
			{
				num = num5;
			}
			if (num6 < num3)
			{
				num3 = num6;
			}
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (num6 > num4)
			{
				num4 = num6;
			}
			num5 = a * rectIn.x + c * (rectIn.y + rectIn.height);
			num6 = b * rectIn.x + d * (rectIn.y + rectIn.height);
			if (num5 < num)
			{
				num = num5;
			}
			if (num6 < num3)
			{
				num3 = num6;
			}
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (num6 > num4)
			{
				num4 = num6;
			}
			return new Rect(num + tx, num3 + ty, num2 - num, num4 - num3);
		}

		public Rectangle transformRect(Rectangle rectIn)
		{
			return new Rectangle(transformRect(rectIn.rect));
		}

		public void copyTo(Matrix to)
		{
			to.a = a;
			to.b = b;
			to.c = c;
			to.d = d;
			to.tx = tx;
			to.ty = ty;
		}

		public void copyToStruct(ref SMatrix to)
		{
			to.a = a;
			to.b = b;
			to.c = c;
			to.d = d;
			to.tx = tx;
			to.ty = ty;
		}
	}
}
