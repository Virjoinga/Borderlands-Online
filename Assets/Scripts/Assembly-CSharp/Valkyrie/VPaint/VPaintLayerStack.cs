using System;
using System.Collections.Generic;
using A;
using UnityEngine;

namespace Valkyrie.VPaint
{
	[Serializable]
	public class VPaintLayerStack
	{
		public List<VPaintLayer> layers = new List<VPaintLayer>();

		public int currentLayer;

		public void Clear()
		{
			layers.Clear();
		}

		public VPaintLayerStack Clone()
		{
			VPaintLayerStack vPaintLayerStack = new VPaintLayerStack();
			using (List<VPaintLayer>.Enumerator enumerator = layers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintLayer current = enumerator.Current;
					vPaintLayerStack.layers.Add(current.Clone());
				}
				while (true)
				{
					switch (5)
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
			return vPaintLayerStack;
		}

		public VPaintLayer NewLayer()
		{
			VPaintLayer vPaintLayer = new VPaintLayer();
			layers.Add(vPaintLayer);
			return vPaintLayer;
		}

		public List<VPaintLayer> GetActiveLayers()
		{
			List<VPaintLayer> list = new List<VPaintLayer>();
			using (List<VPaintLayer>.Enumerator enumerator = layers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintLayer current = enumerator.Current;
					if (!current.enabled)
					{
						continue;
					}
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
					list.Add(current);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return list;
				}
			}
		}

		public VPaintLayer GetMergedLayer()
		{
			return GetMergedLayer(c68001b6ae1264b5fcdf63d3f8c7a545a.c7088de59e49f7108f520cf7e0bae167e);
		}

		public VPaintLayer GetMergedLayer(VPaintLayer baseLayer)
		{
			VPaintLayer c7088de59e49f7108f520cf7e0bae167e = c68001b6ae1264b5fcdf63d3f8c7a545a.c7088de59e49f7108f520cf7e0bae167e;
			if (baseLayer == null)
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
				c7088de59e49f7108f520cf7e0bae167e = new VPaintLayer();
			}
			else
			{
				c7088de59e49f7108f520cf7e0bae167e = baseLayer.Clone();
			}
			Color c36964cf41281414170f34ee68bef6c = default(Color);
			for (int i = 0; i < layers.Count; i++)
			{
				VPaintLayer vPaintLayer = layers[i];
				if (!vPaintLayer.enabled)
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
				}
				else
				{
					VPaintLayer vPaintLayer2 = c7088de59e49f7108f520cf7e0bae167e;
					c67da02ed34f2b38120196017e8aed320.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
					vPaintLayer2.Merge(vPaintLayer, c36964cf41281414170f34ee68bef6c);
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				return c7088de59e49f7108f520cf7e0bae167e;
			}
		}

		public void Collapse()
		{
			layers = new List<VPaintLayer> { GetMergedLayer() };
		}

		public void Sanitize()
		{
			using (List<VPaintLayer>.Enumerator enumerator = layers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintLayer current = enumerator.Current;
					current.Sanitize();
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
					return;
				}
			}
		}

		public void Sanitize(List<IVPaintIdentifier> colorers)
		{
			using (List<VPaintLayer>.Enumerator enumerator = layers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VPaintLayer current = enumerator.Current;
					current.Sanitize(colorers);
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
					return;
				}
			}
		}
	}
}
