using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using A;
using Core;
using UnityEngine;

public class AssetBundleManager : c06ca0e618478c23eba3419653a19760f<AssetBundleManager>
{
	public const string VERSION_BUNDLE_NAME = "VersionTable.assetbundle";

	private Dictionary<string, BaseAssetBundle> m_wwws = new Dictionary<string, BaseAssetBundle>();

	private Dictionary<uint, AssetBundleInfo> m_versionTable;

	private HashSet<string> m_retainedBundles = new HashSet<string>();

	public bool cd98d9a2301263ca1632655555e2f9bfa
	{
		get
		{
			return m_versionTable != cf6640a2528af649f645fa18b48073914.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	public Dictionary<string, BaseAssetBundle> c2db49eb57b860f27c56d506da7c57f6d
	{
		get
		{
			return m_wwws;
		}
	}

	public bool c82d25d4a3c65793b74a7b71fddbe6daa
	{
		get
		{
			int result;
			if (Application.platform != RuntimePlatform.WindowsWebPlayer)
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
				result = ((Application.platform == RuntimePlatform.OSXWebPlayer) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	private string c9293f048e682fa6f18ce3f9184bc56a2
	{
		get
		{
			if (c82d25d4a3c65793b74a7b71fddbe6daa)
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
						return Application.dataPath + "/assetbundles/";
					}
				}
			}
			return "file://" + Application.dataPath + "/../assetbundles/";
		}
	}

	private void Start()
	{
		if (!c82d25d4a3c65793b74a7b71fddbe6daa)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			StartCoroutine(cf9e6cab13222e7529cb0204f1391c0eb());
			return;
		}
	}

	private IEnumerator cf9e6cab13222e7529cb0204f1391c0eb()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LoadVersionTable Start");
		WWW versionTableWWW = new WWW(c9293f048e682fa6f18ce3f9184bc56a2 + "VersionTable.assetbundle");
		m_wwws.Add("VersionTable.assetbundle", new InGameAssetBundle(versionTableWWW));
		yield return versionTableWWW;
		Object asset = cc287004e3f873904ffcdfe194323b23f("VersionTable.assetbundle").cbe31762a9894d52384000afa6c237832;
		TextAsset text_asset = asset as TextAsset;
		MemoryStream stream = new MemoryStream(text_asset.bytes);
		BinaryFormatter bFormatter = new BinaryFormatter();
		uint[] values = bFormatter.Deserialize(stream) as uint[];
		stream.Close();
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LoadVersionTable End");
		m_versionTable = new Dictionary<uint, AssetBundleInfo>();
		for (int i = 0; i < values.Length; i += 3)
		{
			m_versionTable.Add(values[i], new AssetBundleInfo((int)values[i + 1], values[i + 2]));
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
			yield break;
		}
	}

	private bool ce850bc48eace7e78a0b86510aed7355e(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		return ccc3a743cfeeaa8212871445f2d92eb9a.ToLower().StartsWith("uniswf_");
	}

	public uint c5c3c145d54edc727770887f87bea1217(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		if (c82d25d4a3c65793b74a7b71fddbe6daa)
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
			if (Caching.enabled)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						uint key = Utility.cf642a65627df2adf4e90330457651907(ccc3a743cfeeaa8212871445f2d92eb9a.ToLower());
						return m_versionTable[key].m_size;
					}
					}
				}
			}
		}
		return 1u;
	}

	public IEnumerator c38aeacc59bd560b59403945ae7996d79(string ccc3a743cfeeaa8212871445f2d92eb9a, FuncBase cca176ecac42174beb5209935e1a9ee70 = null, object cd22aa6735988e8e65acbd503f3870e3e = null, bool ce2c08a86d2ad40f2406fcd143d735ddb = false)
	{
		while (c82d25d4a3c65793b74a7b71fddbe6daa)
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
			if (!cd98d9a2301263ca1632655555e2f9bfa)
			{
				yield return 0;
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
			break;
		}
		while (c82d25d4a3c65793b74a7b71fddbe6daa)
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
			if (!Caching.enabled)
			{
				break;
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
			if (!Caching.ready)
			{
				yield return 0;
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
			break;
		}
		yield return cd52e62b61b8693fbba532123c5709cba(ccc3a743cfeeaa8212871445f2d92eb9a);
		if (ce2c08a86d2ad40f2406fcd143d735ddb)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Retaining asset bundle: " + ccc3a743cfeeaa8212871445f2d92eb9a);
			m_retainedBundles.Add(ccc3a743cfeeaa8212871445f2d92eb9a);
		}
		if (cca176ecac42174beb5209935e1a9ee70 == null)
		{
			yield break;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			cca176ecac42174beb5209935e1a9ee70(cd22aa6735988e8e65acbd503f3870e3e);
			yield break;
		}
	}

	public IEnumerator cad618dcc0547ebee513a30332046d81f(List<string> cb3a762f1b21f5f2a03be22ad987c0f0b, FuncBase cca176ecac42174beb5209935e1a9ee70 = null, object cd22aa6735988e8e65acbd503f3870e3e = null, bool ce2c08a86d2ad40f2406fcd143d735ddb = false, int c6279c42b47398c5e401c1cff54ce61c2 = 0)
	{
		if (c6279c42b47398c5e401c1cff54ce61c2 < 1)
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
			c6279c42b47398c5e401c1cff54ce61c2 = cb3a762f1b21f5f2a03be22ad987c0f0b.Count;
		}
		int i = 0;
		while (i < cb3a762f1b21f5f2a03be22ad987c0f0b.Count)
		{
			int num;
			if (cb3a762f1b21f5f2a03be22ad987c0f0b.Count - i < c6279c42b47398c5e401c1cff54ce61c2)
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
				num = cb3a762f1b21f5f2a03be22ad987c0f0b.Count - i;
			}
			else
			{
				num = c6279c42b47398c5e401c1cff54ce61c2;
			}
			int mod = num;
			List<string> checklist = cb3a762f1b21f5f2a03be22ad987c0f0b.GetRange(i, mod);
			for (int k = 0; k < checklist.Count; k++)
			{
				StartCoroutine(c38aeacc59bd560b59403945ae7996d79(checklist[k], null, null, ce2c08a86d2ad40f2406fcd143d735ddb));
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				int loaded2 = 0;
				while (true)
				{
					loaded2 = 0;
					for (int j = 0; j < checklist.Count; j++)
					{
						string bundleName = checklist[j];
						if (!m_wwws.ContainsKey(bundleName))
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
						if (!c65c2e0643566a30963cf509aec1dbee7(bundleName))
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
						loaded2++;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						yield return new WaitForEndOfFrame();
						if (loaded2 != checklist.Count)
						{
							break;
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_022a;
							}
							continue;
							end_IL_022a:
							break;
						}
						i += mod;
						goto end_IL_0151;
					}
					continue;
					end_IL_0151:
					break;
				}
				break;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (cca176ecac42174beb5209935e1a9ee70 == null)
			{
				yield break;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				cca176ecac42174beb5209935e1a9ee70(cd22aa6735988e8e65acbd503f3870e3e);
				yield break;
			}
		}
	}

	private WWW cd52e62b61b8693fbba532123c5709cba(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		BaseAssetBundle value = c5e56f3c05d9376417dd653c24d17fd8c.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_wwws.TryGetValue(ccc3a743cfeeaa8212871445f2d92eb9a, out value))
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
			if (c82d25d4a3c65793b74a7b71fddbe6daa)
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
				if (Caching.enabled)
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
					bool flag = true;
					int num = 0;
					uint num2 = Utility.cf642a65627df2adf4e90330457651907(ccc3a743cfeeaa8212871445f2d92eb9a.ToLower());
					AssetBundleInfo value2;
					if (m_versionTable.TryGetValue(num2, out value2))
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
						num = value2.m_version;
					}
					else
					{
						flag = false;
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "m_versionTable Doesn't Contains [";
						array[1] = num2;
						array[2] = "] of ";
						array[3] = ccc3a743cfeeaa8212871445f2d92eb9a;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, string.Concat(array));
					}
					if (flag)
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
						object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array2[0] = "LoadFromCacheOrDownload - ";
						array2[1] = ccc3a743cfeeaa8212871445f2d92eb9a;
						array2[2] = " - ";
						array2[3] = num;
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array2));
						value = new InGameAssetBundle(WWW.LoadFromCacheOrDownload(c9293f048e682fa6f18ce3f9184bc56a2 + ccc3a743cfeeaa8212871445f2d92eb9a, num));
						m_wwws.Add(ccc3a743cfeeaa8212871445f2d92eb9a, value);
					}
					goto IL_01db;
				}
			}
			WWW wWW = new WWW(c9293f048e682fa6f18ce3f9184bc56a2 + ccc3a743cfeeaa8212871445f2d92eb9a);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "GetWWW " + ccc3a743cfeeaa8212871445f2d92eb9a + " - " + wWW.error);
			value = new InGameAssetBundle(wWW);
			m_wwws.Add(ccc3a743cfeeaa8212871445f2d92eb9a, value);
		}
		else if (m_retainedBundles.Contains(ccc3a743cfeeaa8212871445f2d92eb9a))
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Ignoring load for retained asset bundle: " + ccc3a743cfeeaa8212871445f2d92eb9a);
		}
		else
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Try to load already loaded Asset Bundle: [" + c9293f048e682fa6f18ce3f9184bc56a2 + ccc3a743cfeeaa8212871445f2d92eb9a + "]");
			value = c5e56f3c05d9376417dd653c24d17fd8c.c7088de59e49f7108f520cf7e0bae167e;
		}
		goto IL_01db;
		IL_01db:
		object result;
		if (value != null)
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
			result = ((InGameAssetBundle)value).m_www;
		}
		else
		{
			result = null;
		}
		return (WWW)result;
	}

	public Object ca587b9b39577370b2b93809ea02165bc(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		BaseAssetBundle value = c5e56f3c05d9376417dd653c24d17fd8c.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_wwws.TryGetValue(ccc3a743cfeeaa8212871445f2d92eb9a, out value))
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "In AssetBundleManager.GetMainAsset: [" + ccc3a743cfeeaa8212871445f2d92eb9a + "] not loaded");
					return null;
				}
			}
		}
		return value.cbe31762a9894d52384000afa6c237832;
	}

	public BaseAssetBundle cc287004e3f873904ffcdfe194323b23f(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		BaseAssetBundle value = c5e56f3c05d9376417dd653c24d17fd8c.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_wwws.TryGetValue(ccc3a743cfeeaa8212871445f2d92eb9a, out value))
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "In AssetBundleManager.GetAssetBundle [ " + ccc3a743cfeeaa8212871445f2d92eb9a + "] not loaded");
		}
		return value;
	}

	public bool c1a84901a0a9ec83a0000feb026941d27(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		return m_wwws.ContainsKey(ccc3a743cfeeaa8212871445f2d92eb9a);
	}

	public bool c65c2e0643566a30963cf509aec1dbee7(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		if (c82d25d4a3c65793b74a7b71fddbe6daa)
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
			if (!cd98d9a2301263ca1632655555e2f9bfa)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)cc287004e3f873904ffcdfe194323b23f(ccc3a743cfeeaa8212871445f2d92eb9a);
		if (inGameAssetBundle.m_www == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return inGameAssetBundle.m_www.isDone;
	}

	public bool c65c2e0643566a30963cf509aec1dbee7(string[] ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		for (int i = 0; i < ccc3a743cfeeaa8212871445f2d92eb9a.Length; i++)
		{
			if (!m_wwws.ContainsKey(ccc3a743cfeeaa8212871445f2d92eb9a[i]))
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
						return false;
					}
				}
			}
			if (c65c2e0643566a30963cf509aec1dbee7(ccc3a743cfeeaa8212871445f2d92eb9a[i]))
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
				return false;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return true;
		}
	}

	public float c911b31a1a7387d3854cd33c617dd4b3f(string ccc3a743cfeeaa8212871445f2d92eb9a)
	{
		if (c82d25d4a3c65793b74a7b71fddbe6daa)
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
			if (!cd98d9a2301263ca1632655555e2f9bfa)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return 0f;
					}
				}
			}
		}
		InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)cc287004e3f873904ffcdfe194323b23f(ccc3a743cfeeaa8212871445f2d92eb9a);
		if (inGameAssetBundle == null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return 0f;
				}
			}
		}
		WWW www = inGameAssetBundle.m_www;
		if (www == null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return 0f;
				}
			}
		}
		return www.progress;
	}

	public void c1c729e95f2ac60ec91fb0f073386b3cf(List<string> c99e3d0b4ce51c8a7f689a835d475a34b, bool cdf2c0327e37f5ab0b0a1383cc8a98074 = false)
	{
		for (int i = 0; i < c99e3d0b4ce51c8a7f689a835d475a34b.Count; i++)
		{
			c023f6d02221ee56c20921f9cd2e22441(c99e3d0b4ce51c8a7f689a835d475a34b[i], cdf2c0327e37f5ab0b0a1383cc8a98074);
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
			return;
		}
	}

	public void c023f6d02221ee56c20921f9cd2e22441(string ccc3a743cfeeaa8212871445f2d92eb9a, bool cdf2c0327e37f5ab0b0a1383cc8a98074 = false)
	{
		BaseAssetBundle value = c5e56f3c05d9376417dd653c24d17fd8c.c7088de59e49f7108f520cf7e0bae167e;
		if (m_retainedBundles.Contains(ccc3a743cfeeaa8212871445f2d92eb9a))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Ignoring unload for retained bundle: " + ccc3a743cfeeaa8212871445f2d92eb9a);
					return;
				}
			}
		}
		if (!m_wwws.TryGetValue(ccc3a743cfeeaa8212871445f2d92eb9a, out value))
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
			Object cbe31762a9894d52384000afa6c = value.cbe31762a9894d52384000afa6c237832;
			if (c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (cbe31762a9894d52384000afa6c != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.c48e1453cceb6aadac64f47c441c1f427(cbe31762a9894d52384000afa6c.name);
				}
			}
			value.c023f6d02221ee56c20921f9cd2e22441(cdf2c0327e37f5ab0b0a1383cc8a98074);
			m_wwws.Remove(ccc3a743cfeeaa8212871445f2d92eb9a);
			return;
		}
	}

	public void c9984361ac943dc8858e866d1e158927b(bool cdf2c0327e37f5ab0b0a1383cc8a98074 = false)
	{
		if (c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.ce6106566ea862da64238f154db641dac();
		}
		Dictionary<string, BaseAssetBundle> dictionary = new Dictionary<string, BaseAssetBundle>();
		using (Dictionary<string, BaseAssetBundle>.Enumerator enumerator = m_wwws.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, BaseAssetBundle> current = enumerator.Current;
				string key = current.Key;
				if (m_retainedBundles.Contains(key))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Ignoring unload for retained bundle: " + key);
					dictionary.Add(current.Key, current.Value);
				}
				else
				{
					if (current.Value == null)
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
					current.Value.c023f6d02221ee56c20921f9cd2e22441(cdf2c0327e37f5ab0b0a1383cc8a98074);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_00da;
				}
				continue;
				end_IL_00da:
				break;
			}
		}
		m_wwws.Clear();
		m_wwws = c2ae472bc18fef148bf3b3b44c40f69c5.c7088de59e49f7108f520cf7e0bae167e;
		m_wwws = dictionary;
	}
}
