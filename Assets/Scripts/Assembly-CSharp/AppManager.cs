using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class AppManager : c06ca0e618478c23eba3419653a19760f<AppManager>
{
	public string m_autoTestCase = string.Empty;

	[HideInInspector]
	public bool m_offlineMode;

	public string m_level;

	[HideInInspector]
	public UnityEngine.Object m_levelObject;

	public string m_gameType = "GamemodePvE";

	public string m_privateSessionName;

	public ELevelDifficulty m_difficulty;

	public OnlineService.ServerFrameWorkEnv m_serverEnvironment = OnlineService.ServerFrameWorkEnv.Dev;

	public bool m_logNetworkProfile;

	public bool m_logGameProfile;

	public bool m_disableLevelledMatchmaking;

	public bool m_enableSndaLogin;

	public float m_serviceProcessingTime;

	public string[] m_sceneToPlay = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);

	public bool m_usePlaylistId;

	public bool m_skipTutorial;

	public int m_playlistId = -1;

	public string m_serverIP = "127.0.0.1";

	public string m_language = "CHI";

	public string m_gameServerName;

	public string m_statsDBAddress = "127.0.0.1";

	public bool m_isReadyToLoadResources;

	public string m_debugInfo_Version = "undefined";

	public StringBuilder m_displayedVersionId = new StringBuilder();

	private GameFlowManager m_gameFlowMng;

	private GameUIManager m_gameUIMng;

	private FrontEndStepManager m_frontEndMgr;

	public int BandwidthCap;

	public int PriorityInspector;

	protected float accum;

	protected int frames;

	[HideInInspector]
	public uint m_memCur;

	[HideInInspector]
	public uint m_memPeak;

	[HideInInspector]
	public float m_fps;

	[HideInInspector]
	public float frequency = 0.5f;

	public bool m_gameServerInstance;

	public int m_pvpRoomId;

	private Utils.Timer m_shutdownTimer = new Utils.Timer();

	private ProfilerManager m_profilerManager;

	private DebugInfoManager m_debugInfoManager;

	public GameObject m_manager;

	private GUIStyle m_style;

	private static readonly string CONFIGURATION_PREFIX = "f";

	private static readonly string OBFUSCATION_SUFFIX = "_CO";

	private float m_lastTimeRleaseMemory;

	public bool OnlineHostMinResMode { get; private set; }

	public GlobalSettings m_globalSettings { get; private set; }

	public GameUIManager cad4d42df23ad826d4b65d44d510c01a3()
	{
		return m_gameUIMng;
	}

	protected override void Awake()
	{
		base.gameObject.AddComponent<ShandaWrapper>();
		m_enableSndaLogin = false;
		m_offlineMode = false;
		base.Awake();
		GameObject gameObject = UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("ProdUtils/FinalInfo")) as GameObject;
		gameObject.transform.parent = base.gameObject.transform;
		OnlineHostMinResMode = false;
		Application.targetFrameRate = 30;
		string[] c7088de59e49f7108f520cf7e0bae167e = c7e77aa637b9ae1290617ecc771e6c274.c7088de59e49f7108f520cf7e0bae167e;
		c7088de59e49f7108f520cf7e0bae167e = Environment.GetCommandLineArgs();
		string[] array = c7088de59e49f7108f520cf7e0bae167e;
		foreach (string text in array)
		{
			if (!text.Contains("-logfile:"))
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
			char[] array2 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = ':';
			string[] array3 = text.Split(array2);
			if (array3.Length <= 1)
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
			c585561a7e2d1fad0661d8f890537fed4.c5871675a9f1c5f7e18d2787277f85f73 = array3[1];
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			base.gameObject.AddComponent<c585561a7e2d1fad0661d8f890537fed4>();
			cd5a961aa2700fcb29e23fc32ba71d4d5(c7088de59e49f7108f520cf7e0bae167e);
			base.gameObject.AddComponent<AssetBundleManager>();
			PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993 = m_offlineMode;
			UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
			ce517a87030ffb0fb05a919e560f27603();
			StartCoroutine(caf5f83d87bf3cbd766022e9d0d5e406c());
			return;
		}
	}

	private void OnDestroy()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AppManager.OnDestroy");
		cd0d3ccfb4be037b6387155072223230e();
	}

	private void ce517a87030ffb0fb05a919e560f27603()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/GlobalSettings");
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c8df9174f1061b66e38a35bdc70f6abc4.cc1720d05c75832f704b87474932341c3()));
			m_globalSettings = xmlSerializer.Deserialize(stringReader) as GlobalSettings;
		}
		finally
		{
			if (stringReader != null)
			{
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
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		m_debugInfoManager = base.gameObject.AddComponent<DebugInfoManager>();
		base.gameObject.AddComponent<MecanimEventSetupHelper>();
		m_gameFlowMng = base.gameObject.AddComponent<GameFlowManager>();
		base.gameObject.AddComponent<ce9388431a2de8f3d6a4d9565d5f8f8a0>();
		base.gameObject.AddComponent<cc3d8f9888524f253f9d1a8618103803b>();
		base.gameObject.AddComponent<PlayerManager>();
		base.gameObject.AddComponent<InstantiateManager>();
		base.gameObject.AddComponent<EntityManager>();
		base.gameObject.AddComponent<LevelingManager>();
		base.gameObject.AddComponent<ScoringManager>();
		base.gameObject.AddComponent<StatisticsManager>();
		base.gameObject.AddComponent<GuildProgressionSetting>();
		base.gameObject.AddComponent<InputManager>();
		base.gameObject.AddComponent<DebugCamera>();
		AudioManager.c7cc9411392f033dee9802f9b9ca15b21();
		base.gameObject.AddComponent<BadAssLocalizion>();
		m_gameUIMng = base.gameObject.AddComponent<UniUIManager>();
		m_frontEndMgr = base.gameObject.AddComponent<FrontEndStepManager>();
		base.gameObject.AddComponent<ca3a00e0940eecb5ec7ffca2967d5423a>();
		base.gameObject.AddComponent<EchoMessageManager>();
		base.gameObject.AddComponent<GuidanceTipsManager>();
		m_gameUIMng.cd93285db16841148ed53a5bbeb35cf20();
		base.gameObject.AddComponent<QualityManager>();
		base.gameObject.AddComponent<GraphicsMgr>().ccc9d3a38966dc10fedb531ea17d24611();
		base.gameObject.AddComponent<GameSettingMgr>();
		base.gameObject.AddComponent<AvatarGeneratorService>();
		base.gameObject.AddComponent<OnlineService>();
		base.gameObject.AddComponent<MatchmakingService>();
		base.gameObject.AddComponent<ItemGeneratorService>();
		base.gameObject.AddComponent<WeaponFactory>();
		base.gameObject.AddComponent<LevelLoadingManager>();
		if (string.IsNullOrEmpty(m_autoTestCase))
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
			m_gameFlowMng.cdcc658e3c5be5baafd088fd0bf889371();
		}
		else
		{
			base.gameObject.AddComponent<AutoTestManager>();
		}
		if (m_logGameProfile)
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
			if (!UnityEngine.Debug.isDebugBuild)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "ProfilerManager only work under development build");
			}
			m_profilerManager = new ProfilerManager();
			m_profilerManager.Start();
		}
		c0073e976dc9e2a1f1c4be43f137499d4();
		Application.backgroundLoadingPriority = ThreadPriority.Normal;
	}

	private void Update()
	{
		if (m_logGameProfile)
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
			m_profilerManager.Update();
		}
		if (!m_isReadyToLoadResources)
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
			m_isReadyToLoadResources = Application.CanStreamedLevelBeLoaded("ResourcesLoading");
			if (c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c82d25d4a3c65793b74a7b71fddbe6daa)
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
				if (!c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd98d9a2301263ca1632655555e2f9bfa)
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
					m_isReadyToLoadResources = false;
				}
			}
			if (m_isReadyToLoadResources)
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
				base.gameObject.AddComponent<WeaponGeneratorService>();
				if (!string.IsNullOrEmpty(m_autoTestCase))
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
					m_playlistId = AutoTestUtility.c642bbf8d1fedcf6b86a1198b396dedbf(m_autoTestCase);
					AutoTestUtility.c1830583ece68f3e786cc89e71f4c1599();
					GetComponent<AutoTestManager>().c515f796a94abd08a45b1f67775e1da8d(m_autoTestCase);
				}
			}
		}
		if (m_shutdownTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			cd0d3ccfb4be037b6387155072223230e();
		}
		accum += Time.timeScale / Time.deltaTime;
		frames++;
		WindowsDLLHandler.c2069c18ea416ca4dbc2348f8910f5629(out m_memCur, out m_memPeak);
		if (!PhotonNetwork.ca3052869987fcf5688487de12414faab)
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
			if (!(DebugUtils.s_debugInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!DebugUtils.s_debugInfoSync.m_enabled)
				{
					return;
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
		}
	}

	private IEnumerator caf5f83d87bf3cbd766022e9d0d5e406c()
	{
		while (true)
		{
			m_fps = accum / (float)frames;
			accum = 0f;
			frames = 0;
			yield return new WaitForSeconds(frequency);
		}
	}

	private void cd5a961aa2700fcb29e23fc32ba71d4d5(string[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		bool flag = true;
		m_offlineMode = false;
		m_usePlaylistId = false;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c != null)
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
			foreach (string text in c90ecb087828ed9ceb9c00eafb6d52f4c)
			{
				if (text.Contains("-server:"))
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
					char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array[0] = ':';
					string[] array2 = text.Split(array);
					if (array2.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-server:" + array2[1]);
					m_serverEnvironment = OnlineService.ServerFrameWorkEnv.Custom;
					m_serverIP = array2[1];
				}
				else if (text.Contains("-playlist:"))
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
					char[] array3 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array3[0] = ':';
					string[] array4 = text.Split(array3);
					if (array4.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-playlist:" + array4[1]);
					m_playlistId = Convert.ToInt32(array4[1]);
					m_usePlaylistId = true;
				}
				else if (text.Contains("-privatecode:"))
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
					char[] array5 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array5[0] = ':';
					string[] array6 = text.Split(array5);
					if (array6.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-privatecode:" + array6[1]);
					m_privateSessionName = array6[1];
				}
				else if (text.Contains("-usecache"))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-usecache");
					flag = false;
				}
				else if (text.Contains("-profilelog"))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-profilelog");
					m_logGameProfile = true;
				}
				else if (text.Contains("-autotest:"))
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
					char[] array7 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array7[0] = ':';
					string[] array8 = text.Split(array7);
					if (array8.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-autotest:" + array8[1]);
					m_autoTestCase = array8[1];
					m_usePlaylistId = true;
				}
				else if (text.Contains("-levelledmatchmaking:"))
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
					char[] array9 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array9[0] = ':';
					string[] array10 = text.Split(array9);
					if (array10.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-levelledmatchmaking:" + array10[1]);
					m_disableLevelledMatchmaking = !Convert.ToBoolean(array10[1]);
				}
				else if (text.Contains("-language:"))
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
					char[] array11 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array11[0] = ':';
					string[] array12 = text.Split(array11);
					if (array12.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-language:" + array12[1]);
					m_language = array12[1];
				}
				else if (text.Contains("-difficulty:"))
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
					char[] array13 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array13[0] = ':';
					string[] array14 = text.Split(array13);
					if (array14.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-difficulty:" + array14[1]);
					int result;
					if (int.TryParse(array14[1], out result))
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
						m_difficulty = (ELevelDifficulty)result;
					}
					else
					{
						m_difficulty = (ELevelDifficulty)(int)Enum.Parse(Type.GetTypeFromHandle(c502b71eebfc3eee8b8a18088135c30b8.cc1720d05c75832f704b87474932341c3()), array14[1]);
					}
				}
				else if (text.Contains("-gameservername:"))
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
					char[] array15 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array15[0] = ':';
					string[] array16 = text.Split(array15);
					if (array16.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, text);
					m_gameServerName = array16[1];
				}
				else if (text.Contains("-statdb"))
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
					char[] array17 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array17[0] = ':';
					string[] array18 = text.Split(array17);
					if (array18.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, text);
					m_statsDBAddress = array18[1];
				}
				else if (text.Contains("-skiptutorial"))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-skiptutorial");
					m_skipTutorial = true;
				}
				else if (text.Contains("-sndalogin"))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, text);
					m_enableSndaLogin = true;
				}
				else if (text.Contains("-version:"))
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
					char[] array19 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array19[0] = ':';
					string[] array20 = text.Split(array19);
					if (array20.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-version:" + array20[1]);
					m_debugInfo_Version = array20[1];
				}
				else if (text.Contains("-areaid:"))
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
					char[] array21 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array21[0] = ':';
					string[] array22 = text.Split(array21);
					if (array22.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-areaid:" + array22[1]);
					int result2;
					if (!int.TryParse(array22[1], out result2))
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
					ShandaWrapper.AreaID = result2;
				}
				else
				{
					if (!text.Contains("-groupid:"))
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
					char[] array23 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array23[0] = ':';
					string[] array24 = text.Split(array23);
					if (array24.Length <= 1)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "-groupid:" + array24[1]);
					int result3;
					if (!int.TryParse(array24[1], out result3))
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
					ShandaWrapper.GroupId = result3;
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
		}
		if (!flag)
		{
			return;
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

	public void c5a4ebf25aa046ef293fa9ea449fcbb09()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AppManager.QuitApp");
		if (m_shutdownTimer.cb261500372fa488b369e9159a002977a())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_shutdownTimer.Start(2f);
			return;
		}
	}

	private void cd0d3ccfb4be037b6387155072223230e()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AppManager.Shutdown");
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Application.Quit()");
		Application.Quit();
	}

	private void OnGUI()
	{
		if (m_style == null)
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
			m_style = new GUIStyle(GUI.skin.label);
		}
		GUILayout.BeginArea(new Rect(0f, 2f, Screen.width - 10, Screen.width - 100));
		m_style.normal.textColor = Color.white;
		m_style.alignment = TextAnchor.LowerRight;
		if (!string.IsNullOrEmpty(m_debugInfo_Version))
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
			GUILayout.Label(m_displayedVersionId.ToString(), m_style, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		}
		if (!string.IsNullOrEmpty(OnlineService.s_serverVersionId))
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
			GUILayout.Label(OnlineService.s_serverVersionId, m_style, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		}
		GUILayout.EndArea();
	}

	private void c0073e976dc9e2a1f1c4be43f137499d4()
	{
		m_displayedVersionId.Append(CONFIGURATION_PREFIX);
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("VersionInfo", Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3()));
		if (null == textAsset)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "Couldn't find VersionInfo.txt resource");
		}
		else
		{
			StringReader stringReader = new StringReader(textAsset.text);
			try
			{
				string text = stringReader.ReadLine();
				if (string.IsNullOrEmpty(text))
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, "Couldn't find valid version info - this is OK for local builds");
						break;
					}
				}
				else
				{
					m_debugInfo_Version = text;
				}
			}
			finally
			{
				if (stringReader != null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						((IDisposable)stringReader).Dispose();
						break;
					}
				}
			}
		}
		if (!string.IsNullOrEmpty(m_debugInfo_Version))
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
			m_displayedVersionId.Append(m_debugInfo_Version);
		}
		MethodInfo method = GetType().GetMethod("ReadVersionInfo", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method != null)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "This version appears to not be obfuscated");
		}
		else
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "This version appears to be obfuscated");
			m_displayedVersionId.Append(OBFUSCATION_SUFFIX);
		}
		m_debugInfoManager.cb88230e79e2ff2cd996739455e38a008 = m_debugInfo_Version;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Read version info: " + m_debugInfo_Version);
	}

	public void c6738a99a1dd128185a2728e161db856b(bool ce35e1bf21c4f977537893add89ae7c9a)
	{
		float time = Time.time;
		if (time - m_lastTimeRleaseMemory > 3f)
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
			m_lastTimeRleaseMemory = time;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AppManager ReleaseMemory - " + Time.time);
			Pickable.LightPillarManager.ccf24681862bae286c19d5c9b16296be5.c43fd40a8b21ccbced26910ee5cae6c87();
			if (!ce35e1bf21c4f977537893add89ae7c9a)
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
				BuildingKitLoader.cce62ef65db31b242011481c0ca422b8d();
				c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c9984361ac943dc8858e866d1e158927b();
			}
			else
			{
				c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c9984361ac943dc8858e866d1e158927b();
				if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
					cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c6738a99a1dd128185a2728e161db856b();
				}
			}
			ResourcesLoader.c9984361ac943dc8858e866d1e158927b();
			Resources.UnloadUnusedAssets();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AppManager ReleaseMemory Done- " + Time.time);
	}

	public void cc26edc12ccc7060d40b0aaea9f5e22ee(bool c533c1c1772760aeafba37f6bdb966900 = false)
	{
		if (c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.cac7688b05e921e2be3f92479ba44b4a8();
		}
		List<string> list = new List<string>();
		using (Dictionary<string, BaseAssetBundle>.Enumerator enumerator = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, BaseAssetBundle> current = enumerator.Current;
				if (!current.Key.StartsWith("uniswf_"))
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
				list.Add(current.Key);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_0097;
				}
				continue;
				end_IL_0097:
				break;
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c023f6d02221ee56c20921f9cd2e22441(list[i], c533c1c1772760aeafba37f6bdb966900);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.ce6106566ea862da64238f154db641dac();
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(cbb7eb9da7b34ed2d998f9a826f2af269.cc1720d05c75832f704b87474932341c3()));
			for (int j = 0; j < array.Length; j++)
			{
				Material material = (Material)array[j];
				if (!(material.name == "Transparent/DiffuseDoubeSided"))
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
					if (!material.name.ToLower().Contains(".swf_"))
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
				}
				if (!(material.mainTexture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				UnityEngine.Object.Destroy(material);
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

	public FrontEndStepManager.StepState c117524158ae198f8e66c3d5e543aeb9b()
	{
		return m_frontEndMgr.c350c64083eadfb4a76f2dba7c66fd0be;
	}

	public DNACreateBehaviour ccb151936e291c93d0cc4f2fd87c06fb6()
	{
		return base.gameObject.GetComponent<DNACreateBehaviour>();
	}
}
