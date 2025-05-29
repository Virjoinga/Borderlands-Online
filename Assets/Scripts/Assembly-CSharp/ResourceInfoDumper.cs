using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using A;
using UnityEngine;

public class ResourceInfoDumper
{
	public static bool s_includePrefab = true;

	public static void ccfc2341b9294f74f3b204f5d1e8d2fb9(string c8aa0e7ee156ed339de23d3fe5557b916 = "", string cb79b8911eb9af66441e604223827f9a7 = "ResourceInfo.txt")
	{
		s_includePrefab = !s_includePrefab;
		StringBuilder stringBuilder = new StringBuilder(1024);
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650()))
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
				stringBuilder.AppendLine("CurrentScene:" + c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650());
			}
		}
		uint cb427f3b34793a41fc0b9945d1a5b8bfe;
		uint cd6be154afb6313aa3a63ad0f408b5db;
		WindowsDLLHandler.c2069c18ea416ca4dbc2348f8910f5629(out cb427f3b34793a41fc0b9945d1a5b8bfe, out cd6be154afb6313aa3a63ad0f408b5db);
		stringBuilder.AppendLine("Cur:" + (float)cb427f3b34793a41fc0b9945d1a5b8bfe / 1048576f + "Mb");
		stringBuilder.AppendLine("Peak:" + (float)cd6be154afb6313aa3a63ad0f408b5db / 1048576f + "Mb");
		stringBuilder.AppendLine("usedHeapSize:" + (float)Profiler.usedHeapSize / 1048576f + "Mb");
		stringBuilder.AppendLine("GetMonoHeapSize:" + (float)Profiler.GetMonoHeapSize() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetMonoUsedSize:" + (float)Profiler.GetMonoUsedSize() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetTotalAllocatedMemory:" + (float)Profiler.GetTotalAllocatedMemory() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetTotalReservedMemory:" + (float)Profiler.GetTotalReservedMemory() / 1048576f + "Mb");
		stringBuilder.AppendLine("GetTotalUnusedReservedMemory:" + (float)Profiler.GetTotalUnusedReservedMemory() / 1048576f + "Mb");
		if (c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			using (Dictionary<string, BaseAssetBundle>.Enumerator enumerator = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					stringBuilder.AppendLine("Assetbundle:" + enumerator.Current.Key);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_025c;
					}
					continue;
					end_IL_025c:
					break;
				}
			}
		}
		HashSet<UnityEngine.Object> hashSet = new HashSet<UnityEngine.Object>();
		UnityEngine.Object[] array = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(cf6981d21273aef65606028b1cc654277.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array);
		c2b16ad4f9918b404bdb0e13751cbcc5d("Texture:", array, stringBuilder);
		UnityEngine.Object[] array2 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(c645d910e3695e61a822e1ecb2fa8414e.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array2);
		c2b16ad4f9918b404bdb0e13751cbcc5d("AudioClip:", array2, stringBuilder);
		UnityEngine.Object[] array3 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(cc472452b886dabc19106d46e678ad778.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array3);
		c2b16ad4f9918b404bdb0e13751cbcc5d("Mesh:", array3, stringBuilder);
		UnityEngine.Object[] array4 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(cbb7eb9da7b34ed2d998f9a826f2af269.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array4);
		c2b16ad4f9918b404bdb0e13751cbcc5d("Material:", array4, stringBuilder);
		UnityEngine.Object[] array5 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(cc30ad18d9004f6c9825d2221f535b10a.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array5);
		c2b16ad4f9918b404bdb0e13751cbcc5d("GameObject:", array5, stringBuilder);
		UnityEngine.Object[] array6 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(c807125da529472dde348b176f177735e.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array6);
		c2b16ad4f9918b404bdb0e13751cbcc5d("Component:", array6, stringBuilder);
		UnityEngine.Object[] array7 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(ce0e5ba718d04af1940e66363d350c409.cc1720d05c75832f704b87474932341c3()));
		hashSet.UnionWith(array7);
		c2b16ad4f9918b404bdb0e13751cbcc5d("Animation:", array7, stringBuilder);
		UnityEngine.Object[] array8 = c2583b1a7ebc247567013c95b2d42b9c5(Type.GetTypeFromHandle(c21ee453ba7700fb19a2fce2faed35b78.cc1720d05c75832f704b87474932341c3()));
		List<UnityEngine.Object> list = new List<UnityEngine.Object>();
		for (int i = 0; i < array8.Length; i++)
		{
			if (hashSet.Contains(array8[i]))
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			list.Add(array8[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			c2b16ad4f9918b404bdb0e13751cbcc5d("Object:", list.ToArray(), stringBuilder);
			c8c16c8536ac68ea4934e9f906b58b34f(c8aa0e7ee156ed339de23d3fe5557b916, cb79b8911eb9af66441e604223827f9a7, stringBuilder);
			return;
		}
	}

	private static UnityEngine.Object[] c2583b1a7ebc247567013c95b2d42b9c5(Type cfb603d7f5cf6bb1f5d80dbc0c1ea2121)
	{
		if (s_includePrefab)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return Resources.FindObjectsOfTypeAll(cfb603d7f5cf6bb1f5d80dbc0c1ea2121);
				}
			}
		}
		return UnityEngine.Object.FindObjectsOfType(cfb603d7f5cf6bb1f5d80dbc0c1ea2121);
	}

	private static void c2b16ad4f9918b404bdb0e13751cbcc5d(string c26bc9278762c84e1e76177f085674c7e, string[] c3d318e9f6f5c135e187b1976432c83f2, StringBuilder c726525c5f994511bf6f28d060f97469e)
	{
		for (int i = 0; i < c3d318e9f6f5c135e187b1976432c83f2.Length; i++)
		{
			c726525c5f994511bf6f28d060f97469e.AppendLine(c26bc9278762c84e1e76177f085674c7e + c3d318e9f6f5c135e187b1976432c83f2[i]);
		}
		while (true)
		{
			switch (4)
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

	public static void c2b16ad4f9918b404bdb0e13751cbcc5d(string c26bc9278762c84e1e76177f085674c7e, UnityEngine.Object[] cb3a21065d7c368bbfd0b5b0b54e27bdc, StringBuilder c726525c5f994511bf6f28d060f97469e)
	{
		float num = 0f;
		List<string> list = new List<string>();
		for (int i = 0; i < cb3a21065d7c368bbfd0b5b0b54e27bdc.Length; i++)
		{
			string text = string.Empty;
			if (Debug.c4b0ae5e507763df8457b3a358cf48432)
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
				float num2 = (float)Profiler.GetRuntimeMemorySize(cb3a21065d7c368bbfd0b5b0b54e27bdc[i]) / 1048576f;
				text = string.Empty + num2 + "mb ";
				num += num2;
				text += " ";
				text += cb3a21065d7c368bbfd0b5b0b54e27bdc[i].name;
				text += " ";
				text += cb3a21065d7c368bbfd0b5b0b54e27bdc[i].GetType().ToString();
				if (cb3a21065d7c368bbfd0b5b0b54e27bdc[i] is Material)
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
					if (((Material)cb3a21065d7c368bbfd0b5b0b54e27bdc[i]).mainTexture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						text += " null";
					}
					else
					{
						text += " tex:";
						text += ((Material)cb3a21065d7c368bbfd0b5b0b54e27bdc[i]).mainTexture.GetType().ToString();
						text += " ";
						text += ((Material)cb3a21065d7c368bbfd0b5b0b54e27bdc[i]).mainTexture.name;
					}
				}
			}
			list.Add(text);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			list.Sort();
			c2b16ad4f9918b404bdb0e13751cbcc5d(c26bc9278762c84e1e76177f085674c7e, list.ToArray(), c726525c5f994511bf6f28d060f97469e);
			c726525c5f994511bf6f28d060f97469e.AppendLine(string.Format("total of {0}: {1}", c26bc9278762c84e1e76177f085674c7e, num));
			return;
		}
	}

	private static void c8c16c8536ac68ea4934e9f906b58b34f(string c8aa0e7ee156ed339de23d3fe5557b916, string cb79b8911eb9af66441e604223827f9a7, StringBuilder c726525c5f994511bf6f28d060f97469e)
	{
		string text = DateTime.Now.ToString("yy_MM_dd_H_mm_ss_");
		object obj;
		if (s_includePrefab)
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
			obj = "AllObjects_";
		}
		else
		{
			obj = "SceneObjects_";
		}
		string text2 = (string)obj;
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = c8aa0e7ee156ed339de23d3fe5557b916;
		array[1] = text2;
		array[2] = text;
		array[3] = "_client_";
		array[4] = cb79b8911eb9af66441e604223827f9a7;
		StreamWriter streamWriter = new StreamWriter(string.Concat(array));
		streamWriter.Write(c726525c5f994511bf6f28d060f97469e.ToString());
		streamWriter.Close();
	}
}
