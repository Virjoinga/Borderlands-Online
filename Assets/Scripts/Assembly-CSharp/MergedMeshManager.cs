using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class MergedMeshManager : MonoBehaviour
{
	private static Dictionary<uint, List<int>> m_hashcodeToId = new Dictionary<uint, List<int>>();

	private uint m_hashcode;

	private bool m_inited;

	public static void cef68b3e88f6b33439885b9403199853b(GameObject c50e98ae53441addf0757e788dbbc59d4, uint cc584cc0d388b61d19d26e1dcdd9be909, bool ce5d70af3e8007333051fcb4ad110da66 = false)
	{
		if (!cd9231b0c0b8aec9d28ccd4f31151e741(c50e98ae53441addf0757e788dbbc59d4, cc584cc0d388b61d19d26e1dcdd9be909))
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
					return;
				}
			}
		}
		if (m_hashcodeToId.ContainsKey(cc584cc0d388b61d19d26e1dcdd9be909))
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
			m_hashcodeToId[cc584cc0d388b61d19d26e1dcdd9be909].Add(c50e98ae53441addf0757e788dbbc59d4.GetInstanceID());
		}
		else
		{
			m_hashcodeToId.Add(cc584cc0d388b61d19d26e1dcdd9be909, new List<int> { c50e98ae53441addf0757e788dbbc59d4.GetInstanceID() });
			BuildingKitLoader.c9172684ab57085e2a77c2a3af69cb426(cc584cc0d388b61d19d26e1dcdd9be909, c50e98ae53441addf0757e788dbbc59d4.GetComponent<SkinnedMeshRenderer>().sharedMesh);
		}
		MergedMeshManager mergedMeshManager = c50e98ae53441addf0757e788dbbc59d4.AddComponent<MergedMeshManager>();
		if (!ce5d70af3e8007333051fcb4ad110da66)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			mergedMeshManager.ccc9d3a38966dc10fedb531ea17d24611(cc584cc0d388b61d19d26e1dcdd9be909);
			return;
		}
	}

	public void ccc9d3a38966dc10fedb531ea17d24611(uint cc584cc0d388b61d19d26e1dcdd9be909)
	{
		m_hashcode = cc584cc0d388b61d19d26e1dcdd9be909;
		m_inited = true;
	}

	public static void cbb095e7528094c5de72868b1811f5a4a()
	{
		List<uint> list = new List<uint>();
		Dictionary<uint, List<int>>.Enumerator enumerator = m_hashcodeToId.GetEnumerator();
		while (enumerator.MoveNext())
		{
			uint key = enumerator.Current.Key;
			if (enumerator.Current.Value.Count != 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			BuildingKitLoader.c858d49c3aa8b8f3ea460cdf0aaa021bc(key, false);
			list.Add(key);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			for (int i = 0; i < list.Count; i++)
			{
				m_hashcodeToId.Remove(list[i]);
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

	private void OnDestroy()
	{
		if (!m_hashcodeToId.ContainsKey(m_hashcode))
		{
			return;
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
			m_hashcodeToId[m_hashcode].Remove(base.gameObject.GetInstanceID());
			return;
		}
	}

	private static bool cd9231b0c0b8aec9d28ccd4f31151e741(GameObject c50e98ae53441addf0757e788dbbc59d4, uint cc584cc0d388b61d19d26e1dcdd9be909)
	{
		SkinnedMeshRenderer component = c50e98ae53441addf0757e788dbbc59d4.GetComponent<SkinnedMeshRenderer>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Merge mesh manager can only hold instances with skinned mesh renderer component");
					return false;
				}
			}
		}
		if (component.sharedMesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "A mesh must be assigned to the skinned mesh renderer bound to merged mesh manager");
					return false;
				}
			}
		}
		List<int> value;
		if (m_hashcodeToId.TryGetValue(cc584cc0d388b61d19d26e1dcdd9be909, out value))
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
			if (value.Contains(c50e98ae53441addf0757e788dbbc59d4.GetInstanceID()))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "That instance is already referenced into the merged mesh manager");
						return false;
					}
				}
			}
		}
		return true;
	}
}
