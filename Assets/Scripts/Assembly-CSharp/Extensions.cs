using System;
using System.Collections;
using A;
using ExitGames.Client.Photon;
using UnityEngine;

public static class Extensions
{
	public static PhotonView[] cb0af1eac32d2112bb0cc859a7ed20362(this GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		return c68eeb75ae8e0180ebe74a7f42c8bcf3f.GetComponentsInChildren<PhotonView>(true);
	}

	public static PhotonView cf3f639d9f53429a8af80536a64470f83(this GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		return c68eeb75ae8e0180ebe74a7f42c8bcf3f.GetComponent<PhotonView>();
	}

	public static bool ce5aad699df330ff708587e4fabea8cbb(this Vector3 c82fcbab5e578dc3a31c1f662916bd87e, Vector3 cb3d2bffae21da96491575e42414232f7, float c449aa207fc922f9776dbf83e86619954)
	{
		int result;
		if (c82fcbab5e578dc3a31c1f662916bd87e.x.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.x, c449aa207fc922f9776dbf83e86619954))
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
			if (c82fcbab5e578dc3a31c1f662916bd87e.y.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.y, c449aa207fc922f9776dbf83e86619954))
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
				result = (c82fcbab5e578dc3a31c1f662916bd87e.z.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.z, c449aa207fc922f9776dbf83e86619954) ? 1 : 0);
				goto IL_0066;
			}
		}
		result = 0;
		goto IL_0066;
		IL_0066:
		return (byte)result != 0;
	}

	public static bool ce5aad699df330ff708587e4fabea8cbb(this Vector2 c82fcbab5e578dc3a31c1f662916bd87e, Vector2 cb3d2bffae21da96491575e42414232f7, float c449aa207fc922f9776dbf83e86619954)
	{
		int result;
		if (c82fcbab5e578dc3a31c1f662916bd87e.x.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.x, c449aa207fc922f9776dbf83e86619954))
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
			result = (c82fcbab5e578dc3a31c1f662916bd87e.y.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.y, c449aa207fc922f9776dbf83e86619954) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool ce5aad699df330ff708587e4fabea8cbb(this Quaternion c82fcbab5e578dc3a31c1f662916bd87e, Quaternion cb3d2bffae21da96491575e42414232f7, float c449aa207fc922f9776dbf83e86619954)
	{
		int result;
		if (c82fcbab5e578dc3a31c1f662916bd87e.x.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.x, c449aa207fc922f9776dbf83e86619954))
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
			if (c82fcbab5e578dc3a31c1f662916bd87e.y.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.y, c449aa207fc922f9776dbf83e86619954))
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
				if (c82fcbab5e578dc3a31c1f662916bd87e.z.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.z, c449aa207fc922f9776dbf83e86619954))
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
					result = (c82fcbab5e578dc3a31c1f662916bd87e.w.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f7.w, c449aa207fc922f9776dbf83e86619954) ? 1 : 0);
					goto IL_0088;
				}
			}
		}
		result = 0;
		goto IL_0088;
		IL_0088:
		return (byte)result != 0;
	}

	public static bool ce5aad699df330ff708587e4fabea8cbb(this float c82fcbab5e578dc3a31c1f662916bd87e, float cb3d2bffae21da96491575e42414232f7, float c0e3fbb208c8fbba42badd948d21e3a1f)
	{
		return Mathf.Abs(c82fcbab5e578dc3a31c1f662916bd87e - cb3d2bffae21da96491575e42414232f7) < c0e3fbb208c8fbba42badd948d21e3a1f;
	}

	public static void c4870536122cdf9c0c87c4a4301fe4e4d(this IDictionary c82fcbab5e578dc3a31c1f662916bd87e, IDictionary c1f06db306159d29a86891b2e64717f06)
	{
		if (c1f06db306159d29a86891b2e64717f06 == null)
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
			if (c82fcbab5e578dc3a31c1f662916bd87e.Equals(c1f06db306159d29a86891b2e64717f06))
			{
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
			IEnumerator enumerator = c1f06db306159d29a86891b2e64717f06.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					c82fcbab5e578dc3a31c1f662916bd87e[current] = c1f06db306159d29a86891b2e64717f06[current];
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
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_0077;
						}
						continue;
						end_IL_0077:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
	}

	public static void cf7c1c7a7b045d5d6df74fc02c9a94917(this IDictionary c82fcbab5e578dc3a31c1f662916bd87e, IDictionary c1f06db306159d29a86891b2e64717f06)
	{
		if (c1f06db306159d29a86891b2e64717f06 == null)
		{
			return;
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
			if (c82fcbab5e578dc3a31c1f662916bd87e.Equals(c1f06db306159d29a86891b2e64717f06))
			{
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
			IEnumerator enumerator = c1f06db306159d29a86891b2e64717f06.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (!(current is string))
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
					c82fcbab5e578dc3a31c1f662916bd87e[current] = c1f06db306159d29a86891b2e64717f06[current];
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_0089;
						}
						continue;
						end_IL_0089:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
	}

	public static string c6aba88300c0d1ecf7ee0f1db776d8306(this IDictionary c6fbf9bf303de8f447f09fde3a44278f2)
	{
		return SupportClass.DictionaryToString(c6fbf9bf303de8f447f09fde3a44278f2, false);
	}

	public static Hashtable c63ac2d1d584ae86a3fc3c43c687fc6b2(this IDictionary cd3fd8cff9444e8e69036b2b139290946)
	{
		Hashtable hashtable = new Hashtable();
		IDictionaryEnumerator enumerator = cd3fd8cff9444e8e69036b2b139290946.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				if (!(dictionaryEntry.Key is string))
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
				hashtable[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				return hashtable;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_007a;
					}
					continue;
					end_IL_007a:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public static void c028f18d8b9153b0aa6726dae9f6cd04f(this IDictionary cd3fd8cff9444e8e69036b2b139290946)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(cd3fd8cff9444e8e69036b2b139290946.Count);
		cd3fd8cff9444e8e69036b2b139290946.Keys.CopyTo(array, 0);
		foreach (object key in array)
		{
			if (cd3fd8cff9444e8e69036b2b139290946[key] != null)
			{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cd3fd8cff9444e8e69036b2b139290946.Remove(key);
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

	public static bool c1a84901a0a9ec83a0000feb026941d27(this int[] c82fcbab5e578dc3a31c1f662916bd87e, int cdcadbb39118f25a16287bcb9738cad5e)
	{
		for (int i = 0; i < c82fcbab5e578dc3a31c1f662916bd87e.Length; i++)
		{
			if (c82fcbab5e578dc3a31c1f662916bd87e[i] != cdcadbb39118f25a16287bcb9738cad5e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}
}
