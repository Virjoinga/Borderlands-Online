using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using Valkyrie.VPaint;

[AddComponentMenu("VPaint/VPaint Group")]
[ExecuteInEditMode]
public class VPaintGroup : MonoBehaviour
{
	[HideInInspector]
	public List<VPaintObject> colorers = new List<VPaintObject>();

	[HideInInspector]
	public VPaintLayerStack layerStack = new VPaintLayerStack();

	public AutoApplySchedule autoApplySchedule;

	public bool autoLoadInEditor = true;

	[NonSerialized]
	public VPaintLayer paintLayer;

	[HideInInspector]
	public List<VPaintVertexCache> vertexCache = new List<VPaintVertexCache>();

	public VPaintLayerStack c135385e08496fcca21471b77ea858c83()
	{
		return layerStack;
	}

	public VPaintObject[] c8b195e34e254337f1d8b4813dc4289cb()
	{
		for (int i = 0; i < colorers.Count; i++)
		{
			if ((bool)colorers[i])
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			colorers.RemoveAt(i--);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return colorers.ToArray();
		}
	}

	public VPaintLayer ccbc87ebda900f0023be7af7d689855d0()
	{
		return new VPaintLayer();
	}

	public void c8f10145c3b3b77935c63194a8e938911(VPaintObject c7a5e49d5775fcf1af2ecf7eb5baae8c0)
	{
		if (!c7a5e49d5775fcf1af2ecf7eb5baae8c0)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		if (colorers.Contains(c7a5e49d5775fcf1af2ecf7eb5baae8c0))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (c7a5e49d5775fcf1af2ecf7eb5baae8c0.cdde5b1604999906d214f0b05ebcc515b() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "VPaint Object is missing a mesh.");
					return;
				}
			}
		}
		colorers.Add(c7a5e49d5775fcf1af2ecf7eb5baae8c0);
		vertexCache.Add(new VPaintVertexCache
		{
			vpaintObject = c7a5e49d5775fcf1af2ecf7eb5baae8c0,
			vertices = c7a5e49d5775fcf1af2ecf7eb5baae8c0.cdde5b1604999906d214f0b05ebcc515b().vertices
		});
	}

	public void c9d2ab171676b5985d1c9bd19af06a0f9(VPaintObject c7a5e49d5775fcf1af2ecf7eb5baae8c0)
	{
		colorers.Remove(c7a5e49d5775fcf1af2ecf7eb5baae8c0);
		vertexCache.RemoveAll((VPaintVertexCache cebae66039aadeac8deb1211786332a72) => cebae66039aadeac8deb1211786332a72.vpaintObject == c7a5e49d5775fcf1af2ecf7eb5baae8c0);
	}

	private void Awake()
	{
		if (!Application.isPlaying)
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
					if (autoLoadInEditor)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								c7bf42af57574bc29c352a54914d44300();
								return;
							}
						}
					}
					return;
				}
			}
		}
		paintLayer = layerStack.GetMergedLayer();
		if (autoApplySchedule != AutoApplySchedule.OnAwake)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			c7bf42af57574bc29c352a54914d44300();
			return;
		}
	}

	private void Start()
	{
		if (!Application.isPlaying)
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
					return;
				}
			}
		}
		if (autoApplySchedule != 0)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			c7bf42af57574bc29c352a54914d44300();
			return;
		}
	}

	[ContextMenu("Apply")]
	public void c7bf42af57574bc29c352a54914d44300()
	{
		if (paintLayer == null)
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
			paintLayer = layerStack.GetMergedLayer();
		}
		using (List<VPaintVertexData>.Enumerator enumerator = paintLayer.paintData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintVertexData current = enumerator.Current;
				VPaintObject vpaintObject = current.vpaintObject;
				if (!vpaintObject)
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
				}
				else
				{
					vpaintObject.cbec59bd01f76e4395aca1fade53c4ae3(current.colors);
				}
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

	public void ca524a46b1f0bd01a3f6a79c361f6edeb()
	{
		c9add0fc6f673d28cd3cf224b797c9226(layerStack.layers);
	}

	private void c9add0fc6f673d28cd3cf224b797c9226(List<VPaintLayer> ce1172b4b55725537b5b7cd439888b0db)
	{
		using (List<VPaintObject>.Enumerator enumerator = colorers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintObject current = enumerator.Current;
				current.colorsBuilder = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
				current.transparencyBuilder = cc85691b95eca272682421b44175d2a17.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (7)
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
		List<VPaintObject> list = new List<VPaintObject>();
		using (List<VPaintLayer>.Enumerator enumerator2 = ce1172b4b55725537b5b7cd439888b0db.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				VPaintLayer current2 = enumerator2.Current;
				if (!current2.enabled)
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
				}
				else
				{
					cd1fe9a7b1f1669b2890c9b9531c0c686(current2, list);
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_009f;
				}
				continue;
				end_IL_009f:
				break;
			}
		}
		using (List<VPaintObject>.Enumerator enumerator3 = list.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				VPaintObject current3 = enumerator3.Current;
				current3.c2399496032f40ebe7a98946db00a141d();
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

	private void cd1fe9a7b1f1669b2890c9b9531c0c686(VPaintLayer c329db3bbe38dc031eb08c342538daa1a, List<VPaintObject> cf34125c1350ef81851553dd11268b3c2)
	{
		using (List<VPaintObject>.Enumerator enumerator = colorers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintObject current = enumerator.Current;
				if (!current)
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
					continue;
				}
				VPaintVertexData vPaintVertexData = c329db3bbe38dc031eb08c342538daa1a.Get(current);
				if (vPaintVertexData == null)
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				cd6bbcbdbe0b15e8469e3bf2c0ce9d36f(current, c329db3bbe38dc031eb08c342538daa1a, vPaintVertexData);
				if (cf34125c1350ef81851553dd11268b3c2.Contains(current))
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
				cf34125c1350ef81851553dd11268b3c2.Add(current);
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

	private void cd6bbcbdbe0b15e8469e3bf2c0ce9d36f(VPaintObject c7a5e49d5775fcf1af2ecf7eb5baae8c0, VPaintLayer c329db3bbe38dc031eb08c342538daa1a, VPaintVertexData c591d56a94543e3559945c497f37126c4)
	{
		if (c7a5e49d5775fcf1af2ecf7eb5baae8c0.colorsBuilder == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c7a5e49d5775fcf1af2ecf7eb5baae8c0.colorsBuilder = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(c591d56a94543e3559945c497f37126c4.colors.Length);
		}
		if (c7a5e49d5775fcf1af2ecf7eb5baae8c0.transparencyBuilder == null)
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
			c7a5e49d5775fcf1af2ecf7eb5baae8c0.transparencyBuilder = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(c591d56a94543e3559945c497f37126c4.colors.Length);
		}
		VPaintUtility.MergeColors(c7a5e49d5775fcf1af2ecf7eb5baae8c0.colorsBuilder, c7a5e49d5775fcf1af2ecf7eb5baae8c0.transparencyBuilder, c591d56a94543e3559945c497f37126c4.colors, c591d56a94543e3559945c497f37126c4.transparency, c329db3bbe38dc031eb08c342538daa1a.blendMode, c329db3bbe38dc031eb08c342538daa1a.opacity, c329db3bbe38dc031eb08c342538daa1a.maskR, c329db3bbe38dc031eb08c342538daa1a.maskG, c329db3bbe38dc031eb08c342538daa1a.maskB, c329db3bbe38dc031eb08c342538daa1a.maskA);
	}

	public void c78187a560f4a2da49f8b8eb101090e35(List<VPaintObject> cdb3984e0a3ec0385a33f28c796b62eb0)
	{
		using (List<VPaintObject>.Enumerator enumerator = cdb3984e0a3ec0385a33f28c796b62eb0.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintObject current = enumerator.Current;
				cd6bbcbdbe0b15e8469e3bf2c0ce9d36f(current);
			}
			while (true)
			{
				switch (7)
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

	private void cd6bbcbdbe0b15e8469e3bf2c0ce9d36f(VPaintObject c7a5e49d5775fcf1af2ecf7eb5baae8c0)
	{
		c7a5e49d5775fcf1af2ecf7eb5baae8c0.colorsBuilder = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
		c7a5e49d5775fcf1af2ecf7eb5baae8c0.transparencyBuilder = cc85691b95eca272682421b44175d2a17.c7088de59e49f7108f520cf7e0bae167e;
		using (List<VPaintLayer>.Enumerator enumerator = layerStack.layers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintLayer current = enumerator.Current;
				if (!current.enabled)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					continue;
				}
				VPaintVertexData vPaintVertexData = current.Get(c7a5e49d5775fcf1af2ecf7eb5baae8c0);
				if (vPaintVertexData == null)
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
					cd6bbcbdbe0b15e8469e3bf2c0ce9d36f(c7a5e49d5775fcf1af2ecf7eb5baae8c0, current, vPaintVertexData);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_007f;
				}
				continue;
				end_IL_007f:
				break;
			}
		}
		c7a5e49d5775fcf1af2ecf7eb5baae8c0.c2399496032f40ebe7a98946db00a141d();
	}

	public void cd12ee23d6524f7f3d22fa4b518e3a7c0()
	{
		List<VPaintObject> list = new List<VPaintObject>();
		using (List<VPaintObject>.Enumerator enumerator = colorers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintObject current = enumerator.Current;
				VPaintObject[] componentsInChildren = current.GetComponentsInChildren<VPaintObject>();
				VPaintObject[] array = componentsInChildren;
				foreach (VPaintObject item in array)
				{
					if (list.Contains(item))
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
					list.Add(item);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0082;
				}
				continue;
				end_IL_0082:
				break;
			}
		}
		using (List<VPaintObject>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				VPaintObject current2 = enumerator2.Current;
				VPaintVertexData vPaintVertexData = paintLayer.Get(current2);
				if (vPaintVertexData == null)
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
				}
				else
				{
					current2.c7899a4aee7acd811f3e5f88c012a79af(vPaintVertexData.colors);
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

	public IEnumerator c9a63a5adf105f5b88fe7bda732e3e81e(VPaintGroup c82fcbab5e578dc3a31c1f662916bd87e, float cad9f703d862495149cd6bddd080f050b)
	{
		VPaintLayer myBaseLayer = paintLayer;
		VPaintLayer targetBaseLayer = c82fcbab5e578dc3a31c1f662916bd87e.paintLayer;
		List<IEnumerator> routines = new List<IEnumerator>();
		VPaintObject[] array = c8b195e34e254337f1d8b4813dc4289cb();
		foreach (VPaintObject obj in array)
		{
			if (!c82fcbab5e578dc3a31c1f662916bd87e.colorers.Contains(obj))
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
				continue;
			}
			int colorLength = obj.cdde5b1604999906d214f0b05ebcc515b().colors.Length;
			VPaintVertexData baseData = myBaseLayer.Get(obj);
			Color[] baseColors2 = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
			if (baseData == null)
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
				baseColors2 = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(colorLength);
			}
			else
			{
				baseColors2 = baseData.colors;
			}
			VPaintVertexData targetData = targetBaseLayer.Get(obj);
			Color[] targetColors2 = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
			if (targetData == null)
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
				targetColors2 = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(colorLength);
			}
			else
			{
				targetColors2 = targetData.colors;
			}
			routines.Add(VPaintUtility.LerpColors(obj, baseColors2, targetColors2, cad9f703d862495149cd6bddd080f050b));
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
		while (true)
		{
			bool b = true;
			using (List<IEnumerator>.Enumerator enumerator = routines.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IEnumerator r = enumerator.Current;
					if (!r.MoveNext())
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
					b = false;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0239;
					}
					continue;
					end_IL_0239:
					break;
				}
			}
			if (b)
			{
				break;
			}
			yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				break;
			default:
				yield break;
			}
		}
	}
}
