using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class Session : c06ca0e618478c23eba3419653a19760f<Session>
{
	private List<PlayerInfoSync> m_allPlayers = new List<PlayerInfoSync>(8);

	private PlayerInfoSync m_localPlayer;

	private SessionLogic m_logic;

	private byte m_mapLoadingCount;

	private double m_startTime;

	public bool m_showTimerOnScreen;

	[HideInInspector]
	public GameObject m_playerDirectory;

	private string m_mapName;

	private string m_gamemodeName;

	private string m_instanceName;

	private ELevelDifficulty m_difficulty;

	private bool m_isATown;

	private bool m_isSessionReportReady;

	private CutScene m_currentCutscene;

	public string c9d8ee6a5af1e2ca6cb9e7b7a609a6d69()
	{
		return m_instanceName;
	}

	public ELevelDifficulty cfee2582eaf7bd61748c6f890c1e9365d()
	{
		return m_difficulty;
	}

	public int cff61fc67eb6ac43c4cb6125ccbc8857c()
	{
		return 0;
	}

	public byte cdbdfc7767749324b8b1cdac1ae6b9f5b()
	{
		return m_mapLoadingCount;
	}

	public string ce5a94914572053ccdd4c35353ff8d650()
	{
		return m_mapName;
	}

	public string c1492faa4c1a9b76581845cee4d47d460()
	{
		IHostSession hostSession = c8762b0b9a035bab0b07fd588a158cd62();
		if (hostSession != null)
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
					return hostSession.cdc780a4f7ed24542cc09a5fdd06846a6().c1492faa4c1a9b76581845cee4d47d460();
				}
			}
		}
		return m_gamemodeName;
	}

	public double c94ce42c8036c46b4b3e8327e21fffce0()
	{
		return NetworkManager.c0001f5085e474065d3cb214356d1ba19() - m_startTime;
	}

	public double c09c52444051469bac987251aa703ac39()
	{
		return m_startTime;
	}

	public void cf835d249689e450eb7d006607c8f4570(double c592b1b34fa6feaa20881961dad7218bf)
	{
		m_startTime = c592b1b34fa6feaa20881961dad7218bf;
	}

	public bool c28b45877056e09d3c4d6fa790a1517aa()
	{
		int result;
		if (!(c1492faa4c1a9b76581845cee4d47d460() == "GameModePvP"))
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
			result = ((c1492faa4c1a9b76581845cee4d47d460() == "GamemodeTeamDeathmatch") ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool cd3175a878e297c0e31b1ccfc0307f2b4()
	{
		return c1492faa4c1a9b76581845cee4d47d460() == "GamemodeTutorial";
	}

	public bool c0fa185c7b0349f8cb220d2aefb47d990()
	{
		return c1492faa4c1a9b76581845cee4d47d460() == "GamemodeTeamDeathmatch";
	}

	public bool c45c9d44751117fd2457b8e19283bfa51()
	{
		return m_isATown;
	}

	public bool c5d990cbeec5731a071ad4e21a2ad1d91()
	{
		IHostSession hostSession = c8762b0b9a035bab0b07fd588a158cd62();
		bool result;
		if (hostSession != null)
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
			result = hostSession.c5d990cbeec5731a071ad4e21a2ad1d91();
		}
		else
		{
			result = null != m_currentCutscene;
		}
		return result;
	}

	public bool c3a7a710a3394a641829894c7a3254abe()
	{
		return m_isSessionReportReady;
	}

	public void c4b8a1cb99146168143f14eed33617a47()
	{
		m_isSessionReportReady = true;
	}

	public void cebe62854ec37f29d056b2acdf39b98b2(string ca437db6d1a465c4b9dfa4a10899f8b8d, string c33491fef5353a204dd899a389fc7ec52)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "SetMapAndModeName:" + ca437db6d1a465c4b9dfa4a10899f8b8d + " mode:" + c33491fef5353a204dd899a389fc7ec52);
		m_mapName = ca437db6d1a465c4b9dfa4a10899f8b8d;
		m_gamemodeName = c33491fef5353a204dd899a389fc7ec52;
		m_isATown = m_gamemodeName == "GameModeTown";
		m_mapLoadingCount++;
		m_logic.OnMapChange();
	}

	public void c0d9c8316ee1c20e101fdb8296d17b24a(string c806f28438ef18823ada83a6d56d2fe21, ELevelDifficulty c46b57735a769802f4565a74b7185cc1f)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = "SetInstanceNameAndDifficulty[";
		array[1] = c806f28438ef18823ada83a6d56d2fe21;
		array[2] = "|";
		array[3] = c46b57735a769802f4565a74b7185cc1f;
		array[4] = "]";
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
		m_instanceName = c806f28438ef18823ada83a6d56d2fe21;
		m_difficulty = c46b57735a769802f4565a74b7185cc1f;
	}

	public bool c8266bc69cb6d3069bbd1b800662e5dbd()
	{
		return m_logic.m_isMapLoaded;
	}

	public IHostSession c8762b0b9a035bab0b07fd588a158cd62()
	{
		return null;
	}

	public IClientSession c28e186fb4c5763bc506c3ae8af6b71d2()
	{
		return m_logic as ClientSession;
	}

	protected override void Awake()
	{
		base.Awake();
		if (PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0 == null)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Session.Awake - room is null, this is serious doctor? ]");
		}
		else
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Session.Awake - room[" + PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0.cd99af21e22e356018b8f72d4a7e4872a + "]");
		}
		m_mapName = string.Empty;
		base.gameObject.transform.parent = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform;
		m_playerDirectory = new GameObject("Players");
		m_playerDirectory.transform.parent = base.transform;
		if (!string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_autoTestCase))
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
			base.gameObject.AddComponent<AutoTestSync>();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "AddComponent AutoTestSync");
		}
		m_logic = new ClientSession();
		m_logic.cd93285db16841148ed53a5bbeb35cf20();
		m_logic.cad90a477761d59d842235621762e4fe8();
	}

	private void Update()
	{
		m_logic.c6c6cbb0045146f9b0a890f787bad6e4d();
	}

	public virtual void OnDestroy()
	{
		m_logic.c5c15220c3e633306fef152f245ce53fa();
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "Session::OnDestroy - " + m_gamemodeName);
		cb51b20659db02f1337e05f5112f44d56();
	}

	private void cb51b20659db02f1337e05f5112f44d56()
	{
		if (c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c16724d551ad0986ab23e0697bcedb358(Entity.EntityType.None);
		}
		m_allPlayers.Clear();
	}

	public void c57e4d4cd41f3be21d7e24a71aa08c6ba(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		m_allPlayers.Add(ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	public void cf5212e6903ec0c0b27816142c32a2d13(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (m_localPlayer == ceb41162a7cd2a1d5c4a03830e02b4198)
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
			m_localPlayer = c7cfa05fd8fe0a2d1791d3ae1202ecb42.c7088de59e49f7108f520cf7e0bae167e;
		}
		m_allPlayers.Remove(ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	public int c2ac3e7adcbabdeb8274d837bbb6a6d5a()
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			hashSet.Add(m_allPlayers[i].m_teamID);
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
			return hashSet.Count;
		}
	}

	public Camera c9b8520ec6a4150dd7666e0725a4423e4()
	{
		if (c8458d28cbbf3db75361c95db115cef56() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		return entityPlayer.cc6a7269e9ea93e537de47dc752b09a86().camera;
	}

	public PlayerInfoSync c8458d28cbbf3db75361c95db115cef56()
	{
		if (m_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_localPlayer;
				}
			}
		}
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			if (m_allPlayers[i].m_id != NetworkManager.cf6124bd5254101846a57acc03f545846())
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
				m_localPlayer = m_allPlayers[i];
				return m_localPlayer;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public PlayerInfoSync cb062638207d3746ee631744a4709b38f(int c41a218288823eedce4b520981ea598ef)
	{
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			if (m_allPlayers[i].m_id != c41a218288823eedce4b520981ea598ef)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_allPlayers[i];
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public PlayerInfoSync c8cf93402888880ff350d877e135603b6(int c1cc10478b0fb75a49477a8f3df0d162c)
	{
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			if (m_allPlayers[i].m_characterId != c1cc10478b0fb75a49477a8f3df0d162c)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_allPlayers[i];
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public PlayerInfoSync c6942e99b8bfd23b756f3823eb623581a(int c24a23635a8b6b95d7730eefdf77f7b9e)
	{
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			if (m_allPlayers[i].m_accountId != c24a23635a8b6b95d7730eefdf77f7b9e)
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
				return m_allPlayers[i];
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public PlayerInfoSync cb062638207d3746ee631744a4709b38f(string c0d0487bbb50c49dbc1c8096a9ec78c33)
	{
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			if (!(m_allPlayers[i].m_name == c0d0487bbb50c49dbc1c8096a9ec78c33))
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
				return m_allPlayers[i];
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public PlayerInfoSync c28296aaabdb7ddfba47ef5559c1df883(int c5dfde30d8784694fb9999709d290e6c4)
	{
		for (int i = 0; i < m_allPlayers.Count; i++)
		{
			if (m_allPlayers[i].m_characterId != c5dfde30d8784694fb9999709d290e6c4)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_allPlayers[i];
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public int c64f58cc60811857c739035f7a63f475c()
	{
		return m_allPlayers.Count;
	}

	public void c7822eacaa3505f8c170e4316704ac984(out List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e538)
	{
		c9c8de68aa0982db2bbd496692c37e538 = m_allPlayers;
	}

	public void c68fd59435d154e97d7b60dac8301ed39(string ca52db4ecb147839553b6d7ab8d5814ee)
	{
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c68fd59435d154e97d7b60dac8301ed39(ca52db4ecb147839553b6d7ab8d5814ee);
	}

	public void OnGoToSubInstance(string mapName)
	{
		if (m_logic == null)
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
					return;
				}
			}
		}
		m_logic.OnGoToSubInstance(mapName);
	}

	public void OnGoToInstance()
	{
		if (m_logic == null)
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
		m_logic.OnGoToInstance();
	}

	public bool cb9efc4af2006b47000b468b9df139a30()
	{
		return m_logic.cb9efc4af2006b47000b468b9df139a30();
	}

	public void c228cd5253b68fa5d8c2b33af0db7ebb4(CutScene ccb44ce70b62ec38fc49b5c685554a017)
	{
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			PlayerInfoSync playerInfoSync = c9c8de68aa0982db2bbd496692c37e[i];
			EntityPlayer entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			}
			else if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
				if (playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a != PlayerInfoSync.PlayerState.Spawned)
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
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
				ccb44ce70b62ec38fc49b5c685554a017.gameObject.SetActive(true);
				entityPlayer.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(true);
				m_currentCutscene = ccb44ce70b62ec38fc49b5c685554a017;
			}
			else
			{
				entityPlayer.c6a81925b944ea7d0f6008bd83da0380d(true);
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c49fd3d63b08aab39adae6cda3ec40c66(CutScene ccb44ce70b62ec38fc49b5c685554a017)
	{
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			PlayerInfoSync playerInfoSync = c9c8de68aa0982db2bbd496692c37e[i];
			EntityPlayer entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			}
			else if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
				if (playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a != PlayerInfoSync.PlayerState.Spawned)
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
				ccb44ce70b62ec38fc49b5c685554a017.gameObject.SetActive(false);
				entityPlayer.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
				m_currentCutscene = c034aad9523d82621b4a2dfaff5de15fe.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				entityPlayer.c6a81925b944ea7d0f6008bd83da0380d(false);
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
