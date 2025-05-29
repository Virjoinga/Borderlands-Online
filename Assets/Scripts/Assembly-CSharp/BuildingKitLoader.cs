using System.Collections.Generic;
using A;
using UnityEngine;

public abstract class BuildingKitLoader
{
	private static Dictionary<uint, object> m_cache = new Dictionary<uint, object>();

	private uint m_hashcode;

	public static bool c7eaa89766a0eddbc8b8e99acaf413fb6(uint cc584cc0d388b61d19d26e1dcdd9be909, out object cebae66039aadeac8deb1211786332a72)
	{
		return m_cache.TryGetValue(cc584cc0d388b61d19d26e1dcdd9be909, out cebae66039aadeac8deb1211786332a72);
	}

	public static void c9172684ab57085e2a77c2a3af69cb426(uint cc584cc0d388b61d19d26e1dcdd9be909, object cebae66039aadeac8deb1211786332a72)
	{
		m_cache.Add(cc584cc0d388b61d19d26e1dcdd9be909, cebae66039aadeac8deb1211786332a72);
	}

	public static void c858d49c3aa8b8f3ea460cdf0aaa021bc(uint cc584cc0d388b61d19d26e1dcdd9be909, bool c16fed10d80d0723c8b80302097bb64d7)
	{
		object value;
		if (!m_cache.TryGetValue(cc584cc0d388b61d19d26e1dcdd9be909, out value))
		{
			return;
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
			Object @object = value as Object;
			if (c16fed10d80d0723c8b80302097bb64d7)
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
				if (!(@object is GameObject))
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
					if (!(@object is Component))
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
						Resources.UnloadAsset(@object);
						goto IL_006a;
					}
				}
			}
			Object.DestroyImmediate(@object);
			goto IL_006a;
			IL_006a:
			m_cache.Remove(cc584cc0d388b61d19d26e1dcdd9be909);
			return;
		}
	}

	public static void cce62ef65db31b242011481c0ca422b8d()
	{
		using (Dictionary<uint, object>.Enumerator enumerator = m_cache.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Object @object = enumerator.Current.Value as Object;
				if (!(@object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Object.Destroy(@object);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_005b;
				}
				continue;
				end_IL_005b:
				break;
			}
		}
		m_cache.Clear();
	}

	private uint c9204beecb9c4db36f11fd0a30e1d689d()
	{
		if (m_hashcode == 0)
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
			m_hashcode = c4cd4ae93a018bdeba99fff632cb3f04a() + Utility.cf642a65627df2adf4e90330457651907(GetType().ToString());
		}
		return m_hashcode;
	}

	private object cba02ca1a8a050ac54c694317b191cc63(uint cc584cc0d388b61d19d26e1dcdd9be909)
	{
		object obj = c38aeacc59bd560b59403945ae7996d79();
		m_cache.Add(cc584cc0d388b61d19d26e1dcdd9be909, obj);
		return obj;
	}

	public object c588e7dbcd383d8230b2d83d7b44af23b()
	{
		uint num = c9204beecb9c4db36f11fd0a30e1d689d();
		object value = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_cache.TryGetValue(num, out value))
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
			value = cba02ca1a8a050ac54c694317b191cc63(num);
		}
		return value;
	}

	public void c73b071ad863418024417716b8be899d1(bool c16fed10d80d0723c8b80302097bb64d7)
	{
		uint cc584cc0d388b61d19d26e1dcdd9be = c9204beecb9c4db36f11fd0a30e1d689d();
		c858d49c3aa8b8f3ea460cdf0aaa021bc(cc584cc0d388b61d19d26e1dcdd9be, c16fed10d80d0723c8b80302097bb64d7);
	}

	public bool cc0a53fa7d0e20f793f5143d553cd734f()
	{
		uint key = c9204beecb9c4db36f11fd0a30e1d689d();
		return m_cache.ContainsKey(key);
	}

	protected abstract uint c4cd4ae93a018bdeba99fff632cb3f04a();

	protected abstract object c38aeacc59bd560b59403945ae7996d79();
}
