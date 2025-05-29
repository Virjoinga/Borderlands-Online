using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioResourceManager : AudioSubsystem
{
	public const string AUDIO_RESOURCES_CONFIG_PATH = "Audio/Resource/";

	private const string AUDIO_POOLS_NAME = "AudioPools";

	private Dictionary<string, UnityEngine.Object> m_audioResources = new Dictionary<string, UnityEngine.Object>();

	private HashSet<string> m_retainedResources = new HashSet<string>();

	private Dictionary<string, List<string>> m_audioResInfo = new Dictionary<string, List<string>>();

	private GameObject m_poolsContainerGO;

	private Dictionary<string, PrefabPool> m_audioPrefabPools = new Dictionary<string, PrefabPool>();

	private bool m_isLoading;

	public bool m_enableAssetbundle;

	public bool c739bc996d272aeac228d6b5198b164d2
	{
		get
		{
			return m_isLoading;
		}
	}

	public Dictionary<string, List<string>> cafed98b485ede18e66d06b578ac92d23()
	{
		return m_audioResInfo;
	}

	protected override bool c636d1ce20de5e9ba30d812014e152d16()
	{
		m_enableAssetbundle = true;
		c4d1b29281b96e13180f3a95f39800651();
		return true;
	}

	protected override void cb14749be8b076f79fe42c8d8bee20c8a()
	{
	}

	public override void c6738a99a1dd128185a2728e161db856b()
	{
		Dictionary<string, UnityEngine.Object> dictionary = new Dictionary<string, UnityEngine.Object>();
		Dictionary<string, UnityEngine.Object>.Enumerator enumerator = m_audioResources.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!m_retainedResources.Contains(enumerator.Current.Key))
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
			dictionary.Add(enumerator.Current.Key, enumerator.Current.Value);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			m_audioResources = dictionary;
			if (m_enableAssetbundle)
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
				Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
				Dictionary<string, List<string>>.Enumerator enumerator2 = m_audioResInfo.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					List<string> value = enumerator2.Current.Value;
					if (value.Count == 0)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Found audio bundle containing no resources: " + enumerator2.Current.Key);
						continue;
					}
					if (!m_retainedResources.Contains(value[0]))
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
					dictionary2.Add(enumerator2.Current.Key, value);
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
				m_audioResInfo = dictionary2;
			}
			c5fa615f5692e289a3db9fb22ef1cefb9();
			return;
		}
	}

	public void c7868c1f01d2505d185b6c0fe2bd93abd()
	{
	}

	public override void Update()
	{
	}

	public GameObject cd5ef7246c436154c165ae5cdac3f0918(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		if (m_audioResources.ContainsKey(cd99af21e22e356018b8f72d4a7e4872a))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return (GameObject)m_audioResources[cd99af21e22e356018b8f72d4a7e4872a];
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, cd99af21e22e356018b8f72d4a7e4872a + " missing in AudioResourceManager");
		return null;
	}

	public void c3db66e14e48af5530e0853bc83d25a6f()
	{
		using (Dictionary<string, UnityEngine.Object>.Enumerator enumerator = m_audioResources.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, UnityEngine.Object> current = enumerator.Current;
				GameObject gameObject = UnityEngine.Object.Instantiate(current.Value) as GameObject;
				gameObject.name = current.Value.name;
				gameObject.transform.parent = c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.transform;
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

	public bool c5bfff12d9b3b500ed49872cd606ffa44(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		return m_audioResInfo.ContainsKey(cd99af21e22e356018b8f72d4a7e4872a);
	}

	public bool c8a3e20cbb1a0f01c8d52d7bfc64bfd44(string cd99af21e22e356018b8f72d4a7e4872a, UnityEngine.Object[] c633ba514513654371e7840224d9972f9, bool ce2c08a86d2ad40f2406fcd143d735ddb = false)
	{
		bool result = false;
		if (c5bfff12d9b3b500ed49872cd606ffa44(cd99af21e22e356018b8f72d4a7e4872a))
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioPackage:" + cd99af21e22e356018b8f72d4a7e4872a + ".assetbundle is already loaded.");
			result = false;
		}
		else
		{
			List<string> list = new List<string>();
			m_audioResInfo.Add(cd99af21e22e356018b8f72d4a7e4872a, list);
			for (int i = 0; i < c633ba514513654371e7840224d9972f9.Length; i++)
			{
				if (!(c633ba514513654371e7840224d9972f9[i] is GameObject))
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
				if (!((GameObject)c633ba514513654371e7840224d9972f9[i]).GetComponent<AudioEventResponser>())
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
				string name = c633ba514513654371e7840224d9972f9[i].name;
				if (m_audioResources.ContainsKey(name))
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
					if (m_retainedResources.Contains(name))
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Ignoring load of audio resource: " + name + " because it's retained");
						if (ce2c08a86d2ad40f2406fcd143d735ddb)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Mixing retained and non-retained mode for audio resource:" + name + " in 2 different packages!");
					}
					else
					{
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****Same audio prefab:" + name + " in 2 packages!");
					}
					continue;
				}
				m_audioResources.Add(name, c633ba514513654371e7840224d9972f9[i]);
				if (ce2c08a86d2ad40f2406fcd143d735ddb)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Retaining audio resource: " + name);
					m_retainedResources.Add(name);
				}
				list.Add(name);
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
		}
		return result;
	}

	public IEnumerator c51989e5eff27ea24d05531bbbf9de22b(string cd1e3dee5c83b42041dac36bf26b36d23, bool ce2c08a86d2ad40f2406fcd143d735ddb = false)
	{
		string resourcePath = "Audio/Resource/" + cd1e3dee5c83b42041dac36bf26b36d23;
		TextAsset audioResList = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(resourcePath) as TextAsset;
		if (audioResList == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, cd1e3dee5c83b42041dac36bf26b36d23 + " missing");
					yield break;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Load audio configure file: " + cd1e3dee5c83b42041dac36bf26b36d23 + ".xml");
		m_isLoading = true;
		AudioPackageList packageList = c583a8974cc4926ccb282aacb6aba8fa8.c7088de59e49f7108f520cf7e0bae167e;
		try
		{
			StringReader reader = new StringReader(audioResList.text);
			try
			{
				XmlSerializer serializer = new XmlSerializer(Type.GetTypeFromHandle(c8e3593affa6940694abd637dbaea6f54.cc1720d05c75832f704b87474932341c3()));
				packageList = serializer.Deserialize(reader) as AudioPackageList;
			}
			finally
			{
				if (reader != null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						((IDisposable)reader).Dispose();
						break;
					}
				}
			}
			ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(audioResList);
		}
		catch (Exception ex)
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = "Failed loading AudioPackageList @: ";
			array[1] = resourcePath;
			array[2] = " caused by: ";
			array[3] = ex.Message;
			array[4] = "\nfrom: ";
			array[5] = ex.StackTrace;
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, string.Concat(array));
		}
		if (packageList != null)
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
			for (int i = 0; i < packageList.m_packages.Length; i++)
			{
				string packageName = packageList.m_packages[i] + ".assetbundle";
				if (m_audioResInfo.ContainsKey(packageName))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "AudioPackage:" + packageName + ".assetbundle is already loaded.");
					continue;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Loading audio package:" + packageName);
				yield return c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c38aeacc59bd560b59403945ae7996d79(packageName, null, null, ce2c08a86d2ad40f2406fcd143d735ddb));
				UnityEngine.Object[] audioObjs = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(packageName).c6a2c96c95dbb6d94ab759d22726b0440();
				if (audioObjs == null)
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
					c8a3e20cbb1a0f01c8d52d7bfc64bfd44(packageName, audioObjs, ce2c08a86d2ad40f2406fcd143d735ddb);
				}
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Totally audio prefabs:" + m_audioResources.Count);
		}
		m_isLoading = false;
		yield return 0;
	}

	private PrefabPool c9cc077b5944a2298aaffd5f5651fdc8e(string c45fd7f5a766449817c6df573f08ae226)
	{
		if (m_audioPrefabPools == null)
		{
			while (true)
			{
				switch (3)
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
		if (m_poolsContainerGO == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		GameObject gameObject = cd5ef7246c436154c165ae5cdac3f0918(c45fd7f5a766449817c6df573f08ae226);
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		gameObject.name = c45fd7f5a766449817c6df573f08ae226;
		PrefabPool prefabPool = new PrefabPool(gameObject, m_poolsContainerGO);
		m_audioPrefabPools.Add(c45fd7f5a766449817c6df573f08ae226, prefabPool);
		return prefabPool;
	}

	private void c5fa615f5692e289a3db9fb22ef1cefb9()
	{
		Dictionary<string, PrefabPool>.Enumerator enumerator = m_audioPrefabPools.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Value.Reset();
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
			m_audioPrefabPools.Clear();
			return;
		}
	}

	private PrefabPool ca8123ed27ef422593eefb7ba2ec259de(string c45fd7f5a766449817c6df573f08ae226, bool c5df2e331654bcef8864ad50ecee678c3)
	{
		PrefabPool value = cfc32b285ca9fe3f2f552d2470ce9458a.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_audioPrefabPools.TryGetValue(c45fd7f5a766449817c6df573f08ae226, out value))
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
			if (c5df2e331654bcef8864ad50ecee678c3)
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
				value = c9cc077b5944a2298aaffd5f5651fdc8e(c45fd7f5a766449817c6df573f08ae226);
			}
		}
		return value;
	}

	public GameObject c329d38a43c8592a63c19f7f24569be54(string c45fd7f5a766449817c6df573f08ae226, GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		PrefabPool prefabPool = ca8123ed27ef422593eefb7ba2ec259de(c45fd7f5a766449817c6df573f08ae226, true);
		if (prefabPool == null)
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
					return null;
				}
			}
		}
		return prefabPool.c3bbc599e9b8f85f2f044dfd09efdfc1a(c0b8b4f11377b8a222dc728ff2c622559);
	}

	public void c0ff8eff4666ce864dea315d6be106481(GameObject cd449ecea6415dabd2e93005b704ea736)
	{
		PrefabPool prefabPool = ca8123ed27ef422593eefb7ba2ec259de(cd449ecea6415dabd2e93005b704ea736.name, false);
		if (prefabPool == null)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Unexpected null pool for: " + cd449ecea6415dabd2e93005b704ea736.name);
					return;
				}
			}
		}
		prefabPool.c6f00f93ae7322a2e474ac89d787bab88(cd449ecea6415dabd2e93005b704ea736);
	}

	private void c4d1b29281b96e13180f3a95f39800651()
	{
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Creating audio pools container");
		m_poolsContainerGO = new GameObject();
		m_poolsContainerGO.name = "AudioPools";
		m_poolsContainerGO.hideFlags = HideFlags.DontSave;
		UnityEngine.Object.DontDestroyOnLoad(m_poolsContainerGO);
		if (!c06ca0e618478c23eba3419653a19760f<AudioManager>.c5def92cf2ece25f46fbe9356a28a245b)
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
			Utils.cee1496692d8e43aa68171d8c01774b76(m_poolsContainerGO, c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject);
			return;
		}
	}
}
