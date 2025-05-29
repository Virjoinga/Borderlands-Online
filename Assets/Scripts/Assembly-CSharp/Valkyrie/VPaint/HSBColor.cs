using System;
using A;
using UnityEngine;

namespace Valkyrie.VPaint
{
	[Serializable]
	public struct HSBColor
	{
		public float h;

		public float s;

		public float b;

		public float a;

		public HSBColor(float h, float s, float b, float a)
		{
			this.h = h;
			this.s = s;
			this.b = b;
			this.a = a;
		}

		public HSBColor(float h, float s, float b)
		{
			this.h = h;
			this.s = s;
			this.b = b;
			a = 1f;
		}

		public HSBColor(Color col)
		{
			HSBColor hSBColor = FromColor(col);
			h = hSBColor.h;
			s = hSBColor.s;
			b = hSBColor.b;
			a = hSBColor.a;
		}

		public static HSBColor FromColor(Color color)
		{
			HSBColor result = new HSBColor(0f, 0f, 0f, color.a);
			float r = color.r;
			float g = color.g;
			float num = color.b;
			float num2 = Mathf.Max(r, Mathf.Max(g, num));
			if (num2 <= 0f)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return result;
					}
				}
			}
			float num3 = Mathf.Min(r, Mathf.Min(g, num));
			float num4 = num2 - num3;
			if (num2 > num3)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (g == num2)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					result.h = (num - r) / num4 * 60f + 120f;
				}
				else if (num == num2)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					result.h = (r - g) / num4 * 60f + 240f;
				}
				else if (num > g)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					result.h = (g - num) / num4 * 60f + 360f;
				}
				else
				{
					result.h = (g - num) / num4 * 60f;
				}
				if (result.h < 0f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					result.h += 360f;
				}
			}
			else
			{
				result.h = 0f;
			}
			result.h *= 0.0027777778f;
			result.s = num4 / num2 * 1f;
			result.b = num2;
			return result;
		}

		public static Color ToColor(HSBColor hsbColor)
		{
			float value = hsbColor.b;
			float value2 = hsbColor.b;
			float value3 = hsbColor.b;
			if (hsbColor.s != 0f)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				float num = hsbColor.b;
				float num2 = hsbColor.b * hsbColor.s;
				float num3 = hsbColor.b - num2;
				float num4 = hsbColor.h * 360f;
				if (num4 < 60f)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					value = num;
					value2 = num4 * num2 / 60f + num3;
					value3 = num3;
				}
				else if (num4 < 120f)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					value = (0f - (num4 - 120f)) * num2 / 60f + num3;
					value2 = num;
					value3 = num3;
				}
				else if (num4 < 180f)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					value = num3;
					value2 = num;
					value3 = (num4 - 120f) * num2 / 60f + num3;
				}
				else if (num4 < 240f)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					value = num3;
					value2 = (0f - (num4 - 240f)) * num2 / 60f + num3;
					value3 = num;
				}
				else if (num4 < 300f)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					value = (num4 - 240f) * num2 / 60f + num3;
					value2 = num3;
					value3 = num;
				}
				else if (num4 <= 360f)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					value = num;
					value2 = num3;
					value3 = (0f - (num4 - 360f)) * num2 / 60f + num3;
				}
				else
				{
					value = 0f;
					value2 = 0f;
					value3 = 0f;
				}
			}
			return new Color(Mathf.Clamp01(value), Mathf.Clamp01(value2), Mathf.Clamp01(value3), hsbColor.a);
		}

		public Color ToColor()
		{
			return ToColor(this);
		}

		public override string ToString()
		{
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = "H:";
			array[1] = h;
			array[2] = " S:";
			array[3] = s;
			array[4] = " B:";
			array[5] = b;
			return string.Concat(array);
		}

		public static HSBColor Lerp(HSBColor a, HSBColor b, float t)
		{
			float num;
			for (num = Mathf.LerpAngle(a.h * 360f, b.h * 360f, t); num < 0f; num += 360f)
			{
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				while (num > 360f)
				{
					num -= 360f;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					return new HSBColor(num / 360f, Mathf.Lerp(a.s, b.s, t), Mathf.Lerp(a.b, b.b, t), Mathf.Lerp(a.a, b.a, t));
				}
			}
		}
	}
}
