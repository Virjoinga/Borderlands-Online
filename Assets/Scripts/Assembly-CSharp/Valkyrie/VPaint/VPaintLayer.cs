using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using A;
using UnityEngine;

namespace Valkyrie.VPaint
{
	[Serializable]
	public class VPaintLayer
	{
		public bool foldout;

		public string name = "Layer";

		public int tag;

		public List<VPaintVertexData> paintData = new List<VPaintVertexData>();

		public VPaintBlendMode blendMode;

		public bool enabled = true;

		public float opacity = 1f;

		public bool maskR = true;

		public bool maskG = true;

		public bool maskB = true;

		public bool maskA = true;

		public int selectedColor;

		public VPaintVertexData GetOrCreate(VPaintObject vc)
		{
			if (vc == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
			}
			VPaintVertexData vPaintVertexData = Get(vc);
			if (vPaintVertexData != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return vPaintVertexData;
					}
				}
			}
			vPaintVertexData = new VPaintVertexData();
			vPaintVertexData.vpaintObject = vc;
			Color[] array = vc.cae38ccf90cf33a547b0b84a6fe0425f0();
			vPaintVertexData.colors = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(array.Length);
			vPaintVertexData.transparency = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(array.Length);
			paintData.Add(vPaintVertexData);
			return vPaintVertexData;
		}

		public VPaintVertexData Get(IVPaintIdentifier vc)
		{
			if (vc == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
			}
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (!vc.IsEqualTo(vPaintVertexData.identifier))
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return vPaintVertexData;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				return null;
			}
		}

		public void Remove(IVPaintIdentifier vc)
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (!vPaintVertexData.identifier.IsEqualTo(vc))
				{
					continue;
				}
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
				paintData.RemoveAt(i);
				i--;
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

		public VPaintLayer Clone()
		{
			VPaintLayer vPaintLayer = new VPaintLayer();
			using (List<VPaintVertexData>.Enumerator enumerator = paintData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintVertexData current = enumerator.Current;
					vPaintLayer.paintData.Add(current.Clone());
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					break;
				}
			}
			vPaintLayer.blendMode = blendMode;
			vPaintLayer.name = name;
			vPaintLayer.tag = tag;
			vPaintLayer.opacity = opacity;
			vPaintLayer.enabled = enabled;
			vPaintLayer.maskR = maskR;
			vPaintLayer.maskG = maskG;
			vPaintLayer.maskB = maskB;
			vPaintLayer.maskA = maskA;
			return vPaintLayer;
		}

		public void Merge(VPaintLayer layer, [Optional] Color baseColor)
		{
			using (List<VPaintVertexData>.Enumerator enumerator = layer.paintData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintVertexData current = enumerator.Current;
					VPaintVertexData vPaintVertexData = Get(current.identifier);
					Color[] c7088de59e49f7108f520cf7e0bae167e = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
					float[] c7088de59e49f7108f520cf7e0bae167e2 = cc85691b95eca272682421b44175d2a17.c7088de59e49f7108f520cf7e0bae167e;
					if (vPaintVertexData != null)
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c7088de59e49f7108f520cf7e0bae167e = vPaintVertexData.colors;
						c7088de59e49f7108f520cf7e0bae167e2 = vPaintVertexData.transparency;
					}
					else
					{
						c7088de59e49f7108f520cf7e0bae167e = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(current.colors.Length);
						for (int i = 0; i < c7088de59e49f7108f520cf7e0bae167e.Length; i++)
						{
							c7088de59e49f7108f520cf7e0bae167e[i] = baseColor;
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						c7088de59e49f7108f520cf7e0bae167e2 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(current.transparency.Length);
						vPaintVertexData = new VPaintVertexData();
						vPaintVertexData.colors = c7088de59e49f7108f520cf7e0bae167e;
						vPaintVertexData.transparency = c7088de59e49f7108f520cf7e0bae167e2;
						vPaintVertexData.colorer = current.colorer;
						paintData.Add(vPaintVertexData);
					}
					VPaintUtility.MergeColors(c7088de59e49f7108f520cf7e0bae167e, c7088de59e49f7108f520cf7e0bae167e2, current.colors, current.transparency, layer.blendMode, layer.opacity, layer.maskR, layer.maskG, layer.maskB, layer.maskA);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}

		public void Apply()
		{
			using (List<VPaintVertexData>.Enumerator enumerator = paintData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintVertexData current = enumerator.Current;
					if (current.vpaintObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					}
					else
					{
						current.vpaintObject.cbec59bd01f76e4395aca1fade53c4ae3(current.colors);
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}

		public void Sanitize()
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (!(vPaintVertexData.colorer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (4)
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
				paintData.RemoveAt(i--);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		public void Sanitize(List<IVPaintIdentifier> colorers)
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (!vPaintVertexData.colorer)
				{
					while (true)
					{
						switch (5)
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
					paintData.RemoveAt(i--);
					continue;
				}
				bool flag = false;
				IVPaintIdentifier identifier = vPaintVertexData.identifier;
				int num = 0;
				while (true)
				{
					if (num < colorers.Count)
					{
						IVPaintIdentifier obj = colorers[num];
						if (identifier.IsEqualTo(obj))
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
							flag = true;
							break;
						}
						num++;
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					break;
				}
				if (flag)
				{
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				paintData.RemoveAt(i--);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		public void CleanZeroTransparency()
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				float[] transparency = vPaintVertexData.transparency;
				int num = 0;
				while (true)
				{
					if (num < transparency.Length)
					{
						float num2 = transparency[num];
						if (num2 != 0f)
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
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							break;
						}
						num++;
						continue;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					paintData.RemoveAt(i--);
					break;
				}
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
