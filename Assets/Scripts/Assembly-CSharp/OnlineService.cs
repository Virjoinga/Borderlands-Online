using System.Collections.Generic;
using A;

public class OnlineService : c06ca0e618478c23eba3419653a19760f<OnlineService>
{
	public enum ServerFrameWorkEnv
	{
		Proto = 0,
		Dev = 1,
		Test = 2,
		Prod = 3,
		Latest = 4,
		Shard = 5,
		Custom = 6
	}

	public enum OnlineCallResultHashkey : byte
	{
		Dummy = 0,
		Result = 1
	}

	private Dictionary<ServerFrameWorkEnv, string> m_servers;

	public static string s_userName;

	public static int s_accountId;

	public static int s_characterId;

	public static string s_serverVersionId;

	public bool m_usePhotonOLCall = true;

	public readonly int m_serverPort = 2001;

	protected override void Awake()
	{
		base.Awake();
		m_servers = new Dictionary<ServerFrameWorkEnv, string>
		{
			{
				ServerFrameWorkEnv.Proto,
				"10.30.53.39"
			},
			{
				ServerFrameWorkEnv.Dev,
				"10.30.53.41"
			},
			{
				ServerFrameWorkEnv.Test,
				"10.30.48.159"
			},
			{
				ServerFrameWorkEnv.Prod,
				"10.30.53.34"
			},
			{
				ServerFrameWorkEnv.Latest,
				"10.30.48.171"
			},
			{
				ServerFrameWorkEnv.Shard,
				"116.247.99.206"
			},
			{
				ServerFrameWorkEnv.Custom,
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_serverIP
			}
		};
	}

	public static void c123f97c79fbb5492a276d756505ecfe3(string c22e40cc798c87cf3480508bd4c7dbe56)
	{
		s_userName = c22e40cc798c87cf3480508bd4c7dbe56;
	}

	public string c69d53a7a913a53ac0795177e0d9ce893()
	{
		return m_servers[c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_serverEnvironment];
	}

	public string c3c0729991ed521388db89bf6ac71dd2c()
	{
		return m_servers[ServerFrameWorkEnv.Proto];
	}

	public string c5a1ec2fc7ebd9b8a406cfe1970785899()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "http://";
		array[1] = c3c0729991ed521388db89bf6ac71dd2c();
		array[2] = ":";
		array[3] = m_serverPort;
		return string.Concat(array);
	}
}
