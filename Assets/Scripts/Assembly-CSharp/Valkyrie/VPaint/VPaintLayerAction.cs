using System;
using System.Collections.Generic;
using UnityEngine;

namespace Valkyrie.VPaint
{
	[Serializable]
	public class VPaintLayerAction
	{
		public float hueAdjustment;

		public float saturationAdjustment = 1f;

		public float brightnessAdjustment = 1f;

		public float opacityAdjustment = 1f;

		public float contrastAdjustment = 1f;

		public float contrastThreshhold = 0.5f;

		public Color tintColor = Color.yellow;

		public float tintColorOpacity = 1f;

		public bool tintUseValue;

		public bool tintInvertUseValue;

		public void Apply(ref Color c, ref float t, VPaintActionType type)
		{
			HSBColor hSBColor = new HSBColor(c);
			switch (type)
			{
			case VPaintActionType.Brightness:
				if (brightnessAdjustment < 1f)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					hSBColor.b = Mathf.Lerp(0f, hSBColor.b, brightnessAdjustment);
				}
				else if (1f < brightnessAdjustment)
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
					hSBColor.b = Mathf.Lerp(hSBColor.b, 1f, brightnessAdjustment - 1f);
				}
				c = hSBColor.ToColor();
				break;
			case VPaintActionType.Saturation:
				hSBColor.s *= saturationAdjustment;
				c = hSBColor.ToColor();
				break;
			case VPaintActionType.HueShift:
				hSBColor.h += hueAdjustment / 360f;
				if (1f < hSBColor.h)
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
					hSBColor.h -= 1f;
				}
				c = hSBColor.ToColor();
				break;
			case VPaintActionType.Contrast:
				if (1f < contrastAdjustment)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							c.a = Mathf.Pow(c.a + contrastThreshhold, contrastAdjustment) - contrastThreshhold;
							c.r = Mathf.Pow(c.r + contrastThreshhold, contrastAdjustment) - contrastThreshhold;
							c.g = Mathf.Pow(c.g + contrastThreshhold, contrastAdjustment) - contrastThreshhold;
							c.b = Mathf.Pow(c.b + contrastThreshhold, contrastAdjustment) - contrastThreshhold;
							return;
						}
					}
				}
				c = Color.Lerp(Color.grey, c, contrastAdjustment);
				break;
			case VPaintActionType.TintColor:
			{
				float num = tintColorOpacity;
				if (tintUseValue)
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
					if (tintInvertUseValue)
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
						num *= hSBColor.b;
					}
					else
					{
						num *= 1f - hSBColor.b;
					}
				}
				c = Color.Lerp(c, tintColor, num);
				break;
			}
			case VPaintActionType.OpacityAdjustment:
				t = Mathf.Clamp01(t * opacityAdjustment);
				break;
			}
		}

		public void ApplyTo(VPaintLayer layer, params VPaintActionType[] types)
		{
			using (List<VPaintVertexData>.Enumerator enumerator = layer.paintData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintVertexData current = enumerator.Current;
					Color[] colors = current.colors;
					float[] transparency = current.transparency;
					int num = 0;
					while (num < colors.Length)
					{
						foreach (VPaintActionType type in types)
						{
							Apply(ref colors[num], ref transparency[num], type);
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							num++;
							break;
						}
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_0085;
						}
						continue;
						end_IL_0085:
						break;
					}
					current.colors = colors;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
