using System.Collections.Generic;
using UnityEngine;
using Valkyrie.VPaint;

public class VPaintStorageCache : ScriptableObject
{
	public VPaintLayerStack layerStack = new VPaintLayerStack();

	[SerializeField]
	[HideInInspector]
	public List<VPaintStorageObject> storageObjects = new List<VPaintStorageObject>();

	[HideInInspector]
	[SerializeField]
	public List<VPaintVertexCache> vertexCache = new List<VPaintVertexCache>();

	public VPaintGroup cd76eb53e0093683d6e2ba9199df32bfc(string cd99af21e22e356018b8f72d4a7e4872a, bool cc0659830caa48383efea8fc9e462c479 = true)
	{
		VPaintGroup vPaintGroup = new GameObject(cd99af21e22e356018b8f72d4a7e4872a).AddComponent<VPaintGroup>();
		VPaintLayerStack vPaintLayerStack = layerStack.Clone();
		List<VPaintObject> list = new List<VPaintObject>();
		list.AddRange(c4928dc16e9b7106a205e2713c2146cb5());
		using (List<VPaintLayer>.Enumerator enumerator = vPaintLayerStack.layers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintLayer current = enumerator.Current;
				using (List<VPaintVertexData>.Enumerator enumerator2 = current.paintData.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						VPaintVertexData current2 = enumerator2.Current;
						VPaintStorageObject cebae66039aadeac8deb1211786332a = current2.colorer as VPaintStorageObject;
						VPaintObject vPaintObject = c55b3c3bdd644312e1cd121abe4d9ef80(cebae66039aadeac8deb1211786332a);
						if (!vPaintObject)
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
						current2.vpaintObject = vPaintObject;
						if (list.Contains(vPaintObject))
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
						list.Add(vPaintObject);
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_00d6;
						}
						continue;
						end_IL_00d6:
						break;
					}
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_00fd;
				}
				continue;
				end_IL_00fd:
				break;
			}
		}
		if (cc0659830caa48383efea8fc9e462c479)
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
			using (List<VPaintVertexCache>.Enumerator enumerator3 = vertexCache.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					VPaintVertexCache current3 = enumerator3.Current;
					VPaintObject vPaintObject2 = c55b3c3bdd644312e1cd121abe4d9ef80(current3.obj as VPaintStorageObject);
					if (!vPaintObject2)
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
						vPaintGroup.vertexCache.Add(new VPaintVertexCache
						{
							vpaintObject = vPaintObject2,
							vertices = current3.vertices
						});
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_01a5;
					}
					continue;
					end_IL_01a5:
					break;
				}
			}
		}
		VPaintStorageCacheInstance vPaintStorageCacheInstance = vPaintGroup.gameObject.AddComponent<VPaintStorageCacheInstance>();
		vPaintStorageCacheInstance.vpaintStorageCache = this;
		vPaintStorageCacheInstance.vpaintGroup = vPaintGroup;
		using (List<VPaintObject>.Enumerator enumerator4 = list.GetEnumerator())
		{
			while (enumerator4.MoveNext())
			{
				VPaintObject current4 = enumerator4.Current;
				vPaintGroup.c8f10145c3b3b77935c63194a8e938911(current4);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_0209;
				}
				continue;
				end_IL_0209:
				break;
			}
		}
		vPaintGroup.layerStack = vPaintLayerStack;
		return vPaintGroup;
	}

	public virtual VPaintObject[] c4928dc16e9b7106a205e2713c2146cb5()
	{
		return null;
	}

	public virtual VPaintObject c55b3c3bdd644312e1cd121abe4d9ef80(VPaintStorageObject cebae66039aadeac8deb1211786332a72)
	{
		return null;
	}
}
