using System;
using A;
using UnityEngine;

[Serializable]
public class ServerSettings : ScriptableObject
{
	public enum HostingOption
	{
		NotSet = 0,
		PhotonCloud = 1,
		SelfHosted = 2,
		OfflineMode = 3
	}

	public static string DefaultCloudServerUrl = "app-eu.exitgamescloud.com";

	public static string[] CloudServerRegionNames;

	public static string[] CloudServerRegionPrefixes;

	public static string DefaultServerAddress;

	public static int DefaultMasterPort;

	public static string DefaultAppID;

	public HostingOption HostType;

	public string ServerAddress = DefaultServerAddress;

	public int ServerPort = 5055;

	public string AppID = string.Empty;

	[HideInInspector]
	public bool DisableAutoOpenWizard;

	static ServerSettings()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "EU";
		array[1] = "US";
		array[2] = "Asia";
		array[3] = "Japan";
		CloudServerRegionNames = array;
		string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(4);
		array2[0] = "app-eu";
		array2[1] = "app-us";
		array2[2] = "app-asia";
		array2[3] = "app-jp";
		CloudServerRegionPrefixes = array2;
		DefaultServerAddress = "127.0.0.1";
		DefaultMasterPort = 5055;
		DefaultAppID = "Master";
	}

	public static int cb58d60d766e940ab22c1dbed96012407(string cb0c1ef29c7fcbdd20452581d386ee8c8)
	{
		int result = 0;
		for (int i = 0; i < CloudServerRegionPrefixes.Length; i++)
		{
			if (!cb0c1ef29c7fcbdd20452581d386ee8c8.StartsWith(CloudServerRegionPrefixes[i]))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return i;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return result;
		}
	}

	public static string cd4300adfdd367aadf7f5fcbfdfdafdfb(int cb0547a98c4a52714637b441647d85643)
	{
		return DefaultCloudServerUrl.Replace("app-eu", CloudServerRegionPrefixes[cb0547a98c4a52714637b441647d85643]);
	}

	public void c4ecac04fd729bdbff42882124b19c2f4(string cc73d3ce3cfb868326e6aa7aa210b6b63, int cb0547a98c4a52714637b441647d85643)
	{
		HostType = HostingOption.PhotonCloud;
		AppID = cc73d3ce3cfb868326e6aa7aa210b6b63;
		ServerAddress = cd4300adfdd367aadf7f5fcbfdfdafdfb(cb0547a98c4a52714637b441647d85643);
		ServerPort = DefaultMasterPort;
	}

	public void c3c9a75a4dacccce85cf49d140b124f9a(string ce4c253674eeb8857a96a9a931342747a, int cc5538009852c9f12ecbbaa0b1c0818c9, string c17ba694ce106ceb60005c4e2573af752)
	{
		HostType = HostingOption.SelfHosted;
		string appID;
		if (c17ba694ce106ceb60005c4e2573af752 != null)
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
			appID = c17ba694ce106ceb60005c4e2573af752;
		}
		else
		{
			appID = DefaultAppID;
		}
		AppID = appID;
		ServerAddress = ce4c253674eeb8857a96a9a931342747a;
		ServerPort = cc5538009852c9f12ecbbaa0b1c0818c9;
	}

	public override string ToString()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "ServerSettings: ";
		array[1] = HostType;
		array[2] = " ";
		array[3] = ServerAddress;
		return string.Concat(array);
	}
}
