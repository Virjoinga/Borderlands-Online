using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class PlayerResourcesLoader : c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerResourcesLoader>
{
	public const string ASSETBUNDLE_EXTENSION = ".assetbundle";

	public const string PLAYER_RESOURCES_RESOURCE_PATH = "Audio/Resource/PlayerAudioResources";

	private PlayerResources m_resources;

	[CompilerGenerated]
	private static Func<string, string> _003C_003Ef__am_0024cache1;

	public PlayerResourcesLoader()
	{
		c38aeacc59bd560b59403945ae7996d79();
	}

	public bool ca313a312936f07500f062c86d835f60c()
	{
		return null != m_resources;
	}

	private void c38aeacc59bd560b59403945ae7996d79()
	{
		try
		{
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Audio/Resource/PlayerAudioResources") as TextAsset;
			StringReader stringReader = new StringReader(textAsset.text);
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c6df06bf56d1e366c1b78700bfb1befa7.cc1720d05c75832f704b87474932341c3()));
				m_resources = xmlSerializer.Deserialize(stringReader) as PlayerResources;
			}
			finally
			{
				if (stringReader != null)
				{
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
						((IDisposable)stringReader).Dispose();
						break;
					}
				}
			}
			ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(textAsset);
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Failed loading player resources: " + ex.Message + "\nfrom: " + ex.StackTrace);
			m_resources = c183d0a2b3b64561d7cf0880cf56b4ce5.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	private static List<string> c258a3364a55c20733c74811b6262c7bc(IEnumerable<string> c99e3d0b4ce51c8a7f689a835d475a34b)
	{
		IEnumerable<string> source = c99e3d0b4ce51c8a7f689a835d475a34b.Distinct();
		if (_003C_003Ef__am_0024cache1 == null)
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
			_003C_003Ef__am_0024cache1 = (string cf5d861c74bc5f76089eaa0e6f21526c0) => cf5d861c74bc5f76089eaa0e6f21526c0 + ".assetbundle";
		}
		return source.Select(_003C_003Ef__am_0024cache1).ToList();
	}

	private AvatarType[] c230626c879ff1648fa1a706c791c7a07()
	{
		AvatarType[] array = ca16b084112ef26a4bd93564281f7e0c0.c0a0cdf4a196914163f7334d9b0781a04(4);
		for (int i = 0; i < 4; i++)
		{
			array[i] = (AvatarType)i;
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
			return array;
		}
	}

	public List<string> ccdf641fee83157b3c6c8f22823c89292(AvatarType c63132f2d3c0a9069ea15ea2b1105548a, AvatarType[] ced8a5c17bd182bbde8c9af920619280a = null)
	{
		if (!ca313a312936f07500f062c86d835f60c())
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "GetPlayerAssetBundleNames: PlayerResources not loaded");
					return null;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Listing game map player audio bundles, with local avatar: " + c63132f2d3c0a9069ea15ea2b1105548a);
		List<string> list = new List<string>();
		list.AddRange(c9d129bbbf8ae757523dd6df5b2a467bf());
		string[] array = cbabddcda4419321b7370b4444407cb7c(c63132f2d3c0a9069ea15ea2b1105548a, true);
		if (array != null)
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
			list.AddRange(array);
		}
		if (ced8a5c17bd182bbde8c9af920619280a == null)
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
			ced8a5c17bd182bbde8c9af920619280a = c230626c879ff1648fa1a706c791c7a07();
		}
		AvatarType[] array2 = ced8a5c17bd182bbde8c9af920619280a;
		foreach (AvatarType cfe0a1153f61dcdf419049830449301da in array2)
		{
			string[] array3 = cbabddcda4419321b7370b4444407cb7c(cfe0a1153f61dcdf419049830449301da, false);
			if (array3 == null)
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
			list.AddRange(array3);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return c258a3364a55c20733c74811b6262c7bc(list);
		}
	}

	public List<string> c550863df1f9cadf29cfb256b0d29b0b7(AvatarType c63132f2d3c0a9069ea15ea2b1105548a)
	{
		if (!ca313a312936f07500f062c86d835f60c())
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "GetPlayerAssetBundleNames: PlayerResources not loaded");
					return null;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Audio, "Listing town map player audio bundles, with local avatar: " + c63132f2d3c0a9069ea15ea2b1105548a);
		List<string> list = new List<string>();
		list.AddRange(ca4ba278a06ce60c2adba95b8e62bba3c());
		PlayerResources.BundleSet[] playerTownBundleSets = m_resources.m_playerTownBundleSets;
		foreach (PlayerResources.BundleSet bundleSet in playerTownBundleSets)
		{
			if (bundleSet.m_bundles == null)
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
			list.AddRange(bundleSet.m_bundles);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return c258a3364a55c20733c74811b6262c7bc(list);
		}
	}

	private string[] c9d129bbbf8ae757523dd6df5b2a467bf()
	{
		if (!ca313a312936f07500f062c86d835f60c())
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "PlayerResources already loaded");
					return null;
				}
			}
		}
		return m_resources.m_commonBundleSet.m_bundles;
	}

	private string[] ca4ba278a06ce60c2adba95b8e62bba3c()
	{
		if (!ca313a312936f07500f062c86d835f60c())
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "PlayerResources already loaded");
					return null;
				}
			}
		}
		return m_resources.m_commonTownBundleSet.m_bundles;
	}

	private string[] cbabddcda4419321b7370b4444407cb7c(AvatarType cfe0a1153f61dcdf419049830449301da, bool c4a6e6d49df602dd45f92e2a331424c21)
	{
		if (!ca313a312936f07500f062c86d835f60c())
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "PlayerResources already loaded");
					return null;
				}
			}
		}
		PlayerResources.BundleSet[] array;
		if (c4a6e6d49df602dd45f92e2a331424c21)
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
			array = m_resources.m_localPlayerBundleSets;
		}
		else
		{
			array = m_resources.m_classSpecificBundleSets;
		}
		PlayerResources.BundleSet[] array2 = array;
		PlayerResources.BundleSet bundleSet = array2[(int)cfe0a1153f61dcdf419049830449301da];
		return bundleSet.m_bundles;
	}

	[CompilerGenerated]
	private static string cff9d10169398ee65ea2cb7ca61228c19(string cf5d861c74bc5f76089eaa0e6f21526c0)
	{
		return cf5d861c74bc5f76089eaa0e6f21526c0 + ".assetbundle";
	}
}
