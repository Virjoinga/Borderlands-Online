using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;
using Core;
using Photon;
using UnityEngine;
using XsdSettings;

public class MatchmakingService : Photon.MonoBehaviour
{
	public class FindMeAPlaylistAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		public int m_characterId;

		public int m_playlistId;

		public Playlist m_playList;

		public void c7cc9411392f033dee9802f9b9ca15b21(int c5dfde30d8784694fb9999709d290e6c4, int ca1fe61abde52868f679caf67108b2858)
		{
			m_characterId = c5dfde30d8784694fb9999709d290e6c4;
			m_playlistId = ca1fe61abde52868f679caf67108b2858;
			c92c7f03b81b92c00ce0b49a2b9058106 = 60f;
		}

		public override void Start()
		{
			base.Start();
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(1, false);
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(2, false);
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(3, false);
			m_playList = c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(m_playlistId);
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
			array[0] = "FindMeAPlaylistAsyncTask.Start for Playlist [";
			array[1] = m_playlistId;
			array[2] = "][";
			array[3] = m_playList.m_name;
			array[4] = "][";
			array[5] = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_debugInfo_Version;
			array[6] = "]";
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_privateSessionName != string.Empty)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "JoinRoom [" + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_privateSessionName + "]");
						PhotonNetwork.cbed89c6829274cdc65c25ca1f298510b(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_privateSessionName);
						return;
					}
				}
			}
			RoomInfo[] array2 = PhotonNetwork.c92c6e1cf92474e71bd25add4065075be();
			if (array2.Length > 0)
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
				RoomInfo[] array3 = array2;
				foreach (RoomInfo roomInfo in array3)
				{
					object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
					array4[0] = "Room [";
					array4[1] = roomInfo.cd99af21e22e356018b8f72d4a7e4872a;
					array4[2] = " ";
					array4[3] = roomInfo.playerCount;
					array4[4] = "/";
					array4[5] = roomInfo.c0b46a01b8c5164654f47e46e1eeb023d;
					array4[6] = "]";
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array4));
					if (!roomInfo.cd99af21e22e356018b8f72d4a7e4872a.Contains(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_debugInfo_Version))
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
					if (!roomInfo.cd99af21e22e356018b8f72d4a7e4872a.Contains(m_playList.m_name))
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
					if (roomInfo.playerCount >= roomInfo.c0b46a01b8c5164654f47e46e1eeb023d)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "JoinRoom [" + roomInfo.cd99af21e22e356018b8f72d4a7e4872a + "]");
						PhotonNetwork.cbed89c6829274cdc65c25ca1f298510b(roomInfo.cd99af21e22e356018b8f72d4a7e4872a);
						return;
					}
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
			}
			Hashtable hashtable = new Hashtable();
			GamemodeType gamemodeType = c6921a12df59fc1206bd8bea12427f9af(m_playList.m_gameMode);
			hashtable["PlaylistId"] = m_playlistId;
			hashtable["VersionId"] = string.Empty;
			hashtable["GameMode"] = (int)gamemodeType;
			hashtable["ForceStartGameTime"] = 0;
			hashtable["Difficulty"] = (int)c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_difficulty;
			PlayerProperties playerProperties = c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccc826da979542be7370386df94069f47();
			if (playerProperties == null)
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
				hashtable["LevelledMatchmaking"] = false;
			}
			else
			{
				hashtable["PlayerLevel"] = playerProperties.m_level;
			}
			switch (gamemodeType)
			{
			case GamemodeType.GamemodePvE:
			case GamemodeType.GamemodeSurvival:
				hashtable["JoinInProgress"] = true;
				hashtable["GroupMatchmakingEnabled"] = true;
				break;
			case GamemodeType.GamemodeDeathmatch:
			case GamemodeType.GamemodeTeamDeathmatch:
				hashtable["JoinInProgress"] = true;
				hashtable["GroupMatchmakingEnabled"] = true;
				if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
				{
					break;
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
				hashtable["GroupGame"] = true;
				break;
			case GamemodeType.GamemodeTutorial:
				hashtable["JoinInProgress"] = m_playList.m_maxPlayerCount > 1;
				hashtable["IsOpen"] = m_playList.m_maxPlayerCount > 1;
				break;
			default:
				hashtable["JoinInProgress"] = true;
				hashtable["GroupMatchmakingEnabled"] = false;
				hashtable["LevelledMatchmaking"] = false;
				break;
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "JoinRandomRoom []");
			PhotonNetwork.cfbfcc20bd35df7e2bf18d44b273b8627(hashtable, 0);
		}

		public override void OnJoinedRoom()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}

		public override void OnPhotonJoinRoomFailed()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_JoinRoomFail);
		}

		public override void OnPhotonRandomJoinFailed()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_JoinRoomFail);
		}
	}

	public class JoinRoomAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		public string m_roomName;

		public void c7cc9411392f033dee9802f9b9ca15b21(string c37dc4ee4a3a694110f0e0eb7b086137a)
		{
			m_roomName = c37dc4ee4a3a694110f0e0eb7b086137a;
			c92c7f03b81b92c00ce0b49a2b9058106 = 60f;
		}

		public override void Start()
		{
			base.Start();
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(1, false);
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(2, false);
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(3, false);
			PhotonNetwork.cbed89c6829274cdc65c25ca1f298510b(m_roomName);
		}

		public override void OnJoinedRoom()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}

		public override void OnPhotonJoinRoomFailed()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_JoinRoomFail);
		}
	}

	public class StartPvPMatchAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		public int m_instanceId;

		private GamemodeType m_gamemode;

		public void c7cc9411392f033dee9802f9b9ca15b21(int cdb1e09e6b4d62165e7b6544e99a268f0, GamemodeType c33491fef5353a204dd899a389fc7ec52)
		{
			m_instanceId = cdb1e09e6b4d62165e7b6544e99a268f0;
			m_gamemode = c33491fef5353a204dd899a389fc7ec52;
			c92c7f03b81b92c00ce0b49a2b9058106 = 60f;
		}

		public override void Start()
		{
			base.Start();
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(1, false);
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(2, false);
			PhotonNetwork.cda9bc04ce8997ffe268cc6b552dd0dca(3, false);
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			dictionary.Add(0, (int)m_gamemode);
			dictionary.Add(1, m_instanceId);
			Dictionary<byte, object> customOpParameters = dictionary;
			PhotonNetwork.networkingPeer.OpCustom(127, customOpParameters, true);
		}

		public override void OnJoinedRoom()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}

		public override void OnPhotonJoinRoomFailed()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_JoinRoomFail);
		}
	}

	public class LeaveRoomAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		public void c7cc9411392f033dee9802f9b9ca15b21()
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
		}

		public override void Start()
		{
			base.Start();
			if (!PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
				if (PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0 != null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							PhotonNetwork.c518ef3edadd378ef9ae215e96fa4e4fa();
							return;
						}
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}

		public override void OnLeftRoom()
		{
			if (c762acfd9de32c566fab82e7bbfb0e93f())
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
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}
	}

	public enum RequestStatus
	{
		None = 0,
		Pending = 1,
		Succeed = 2,
		Failure = 3
	}

	private static MatchmakingService s_instance;

	private PlayListSetup m_playlistSetup;

	public Dictionary<int, int> m_playlistprogressionmapping = new Dictionary<int, int>
	{
		{ 2, 1 },
		{ 5, 2 },
		{ 4, 3 },
		{ 3, 4 },
		{ 1, 5 }
	};

	private Lobby m_myPvpRoom;

	private bool m_isRematching;

	private List<GameOwnerChangedListener> mGameOwnerChangedListeners;

	private List<KickedFromGameListener> mKickedFromGameListeners;

	[CompilerGenerated]
	private static Action<KickedFromGameListener> _003C_003Ef__am_0024cache7;

	public static MatchmakingService c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private void Awake()
	{
		if (s_instance != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "MatchmakingService is already initialized");
		}
		s_instance = this;
	}

	private void Start()
	{
		mGameOwnerChangedListeners = new List<GameOwnerChangedListener>();
		mKickedFromGameListeners = new List<KickedFromGameListener>();
		if (!string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_autoTestCase))
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = 0;
		}
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/Playlist");
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(ca9cad829e4dd05f43bca7b10961ac7b6.cc1720d05c75832f704b87474932341c3()));
			m_playlistSetup = xmlSerializer.Deserialize(stringReader) as PlayListSetup;
		}
		finally
		{
			if (stringReader != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		PhotonNetwork.networkingPeer.c71111ea3c8afdb98963505d86a8495b6(136, OnKickPlayerFromGameResponse);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(197, OnGameOwnerChangedEvent);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(196, OnKickedFromGameEvent);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c91b3622e4ee80042eaa2142a7f639e56(OnPlayerJoinPvPRoom);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c2316a0f8fb386cbc58a94d362e891b2e(OnPlayerLeavePvPRoom);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c8a889a9c4828e990e77121594dbad509(OnPvPRoomOwnerChange);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca7fda1e916bc5dc8a532dbb050f61829(OnPvPRoomClose);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c49e6a046e282568081061bce76751216(OnGroupJoinPvPRoom);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c09adc6e0d66196a91d10a204adb4660c(OnGroupLeavePvPRoom);
	}

	public Playlist c8e693f5f3ec2e82bd093c9a5d56bdf43()
	{
		return c2718b579e09549a1cd47620188a40a38(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
	}

	public Playlist c2718b579e09549a1cd47620188a40a38(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_playlistSetup.m_playlists.Length; i++)
		{
			if (m_playlistSetup.m_playlists[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				return m_playlistSetup.m_playlists[i];
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public Playlist c2e7bb39e76e20727d1aba6604464614e(string ca52db4ecb147839553b6d7ab8d5814ee)
	{
		for (int i = 0; i < m_playlistSetup.m_playlists.Length; i++)
		{
			Playlist playlist = m_playlistSetup.m_playlists[i];
			for (int j = 0; j < playlist.m_sceneToPlay.Length; j++)
			{
				if (!(playlist.m_sceneToPlay[j] == ca52db4ecb147839553b6d7ab8d5814ee))
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return playlist;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_0052;
				}
				continue;
				end_IL_0052:
				break;
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

	public Playlist c9bdc2c0504907130c26fceebf8d21879(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		for (int i = 0; i < m_playlistSetup.m_playlists.Length; i++)
		{
			if (!(m_playlistSetup.m_playlists[i].m_name == cd99af21e22e356018b8f72d4a7e4872a))
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
				return m_playlistSetup.m_playlists[i];
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public int c1eee25b05f5fe01bc9f3961e576f7fd9(int cae86b07dc522772c3c56bb1c87f6b283)
	{
		if (m_playlistprogressionmapping.ContainsKey(cae86b07dc522772c3c56bb1c87f6b283))
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
					return m_playlistprogressionmapping[cae86b07dc522772c3c56bb1c87f6b283];
				}
			}
		}
		return -1;
	}

	private void OnFindPvPRoom(Lobby room)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnFindPvPRoom - " + Time.time);
		m_myPvpRoom = room;
		cfad162916de36b64bb6dfc6dc92711b9();
	}

	public void cc244d573983559acb0dfb881b1e2f5bf()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.ReMatch");
		m_isRematching = true;
		if (m_myPvpRoom != null)
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
					OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce30914cedf948c8ebefe3783fb6c7f87(OnLeavePvPRoom);
					return;
				}
			}
		}
		OnLeavePvPRoom(true);
	}

	private void OnLeavePvPRoom(bool success)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnLeavePvPRoom - " + Time.time);
		m_myPvpRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
		if (m_isRematching)
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
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf919217c11722f259176c952c8aba513(OnCreateRematchLobby, true);
			m_isRematching = false;
		}
		m_isRematching = false;
	}

	private void OnCreateRematchLobby(Lobby newLobby)
	{
		m_myPvpRoom = newLobby;
		Playlist playlist = c5ee19dc8d4cccf5ae2de225410458b86.c8e693f5f3ec2e82bd093c9a5d56bdf43();
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5e5cc544f50051d78abdccc1aec483a8(OnFindPvPRoom, c6921a12df59fc1206bd8bea12427f9af(playlist.m_gameMode), playlist.m_id, ELevelDifficulty.Normal);
	}

	public void c10594d4e276bc6df144aea45627e66b5()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.CancelPvP - " + Time.time);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce30914cedf948c8ebefe3783fb6c7f87(OnLeavePvPRoom);
	}

	public void c4127346f42cb6f7c99d066e3b2267b05()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.CancelInstance - " + Time.time);
		PhotonNetwork.c093a0227be03dbb9e0754429e5fd2fb1();
	}

	public static GamemodeType c6921a12df59fc1206bd8bea12427f9af(string c720d75e2694fbd0aac052968b071e27d)
	{
		if (c720d75e2694fbd0aac052968b071e27d.Equals("GameModeTown", StringComparison.OrdinalIgnoreCase))
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
					return GamemodeType.GamemodeTown;
				}
			}
		}
		if (c720d75e2694fbd0aac052968b071e27d.Equals("GameModePvE", StringComparison.OrdinalIgnoreCase))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return GamemodeType.GamemodePvE;
				}
			}
		}
		if (c720d75e2694fbd0aac052968b071e27d.Equals("GameModeSurvival", StringComparison.OrdinalIgnoreCase))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return GamemodeType.GamemodeSurvival;
				}
			}
		}
		if (c720d75e2694fbd0aac052968b071e27d.Equals("GameModePvP", StringComparison.OrdinalIgnoreCase))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return GamemodeType.GamemodeDeathmatch;
				}
			}
		}
		if (c720d75e2694fbd0aac052968b071e27d.Equals("GameModeTeamDeathmatch", StringComparison.OrdinalIgnoreCase))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return GamemodeType.GamemodeTeamDeathmatch;
				}
			}
		}
		if (c720d75e2694fbd0aac052968b071e27d.Equals("GamemodeTutorial", StringComparison.OrdinalIgnoreCase))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return GamemodeType.GamemodeTutorial;
				}
			}
		}
		return GamemodeType.None;
	}

	public static bool c28b45877056e09d3c4d6fa790a1517aa(GamemodeType c7c285f21497bec76d425ba4a0a524b46)
	{
		if (c7c285f21497bec76d425ba4a0a524b46 != GamemodeType.GamemodeDeathmatch)
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
			if (c7c285f21497bec76d425ba4a0a524b46 != GamemodeType.GamemodeTeamDeathmatch)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		return true;
	}

	public void cf70dbfb77ed1d082ec3085179bf9b181(int c5dfde30d8784694fb9999709d290e6c4)
	{
		NetworkingPeer networkingPeer = PhotonNetwork.networkingPeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		networkingPeer.c50190e0c5838cf36bc56ebceb28dcdaa(136, array);
	}

	private void OnKickPlayerFromGameResponse(short OperationResponse, Dictionary<byte, object> parameters)
	{
	}

	public void ce0eb81fc15ab0213fb685c0a2747ae61(KickedFromGameListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		mKickedFromGameListeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void ce83c0c5ef7d1885b5d53eac92618628e(KickedFromGameListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		mKickedFromGameListeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	private void OnKickedFromGameEvent(Dictionary<byte, object> parameters)
	{
		List<KickedFromGameListener> list = mKickedFromGameListeners;
		if (_003C_003Ef__am_0024cache7 == null)
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
			_003C_003Ef__am_0024cache7 = delegate(KickedFromGameListener c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cache7);
	}

	public void cbd72e4957e78d4aad908e05119be5be8(GameOwnerChangedListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		mGameOwnerChangedListeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void ce926b675f684653fdd9abccb18081e17(GameOwnerChangedListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		mGameOwnerChangedListeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	private void OnGameOwnerChangedEvent(Dictionary<byte, object> parameters)
	{
		mGameOwnerChangedListeners.ForEach(delegate(GameOwnerChangedListener c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9((int)parameters[0]);
		});
	}

	private void cfad162916de36b64bb6dfc6dc92711b9()
	{
		if (m_myPvpRoom == null)
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
		if (m_myPvpRoom.Owner != OnlineService.s_characterId)
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
		if (m_myPvpRoom.HasGameStarted)
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
			Playlist playlist = c2718b579e09549a1cd47620188a40a38(m_myPvpRoom.Playlist);
			if (m_myPvpRoom.c6bd4b9ef67e1accad2d94e7d188d4456 < playlist.m_minPlayerCountToStart)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (m_myPvpRoom.IsGroupGame)
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
				if (m_myPvpRoom.GameMode == GamemodeType.GamemodeTeamDeathmatch)
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
					if (m_myPvpRoom.IsGroupGame)
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
						break;
					}
					if (m_myPvpRoom.c6bd4b9ef67e1accad2d94e7d188d4456 <= 1)
					{
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
			m_myPvpRoom.HasGameStarted = true;
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = playlist.m_id;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.CheckPvPStartCondition - " + m_myPvpRoom.Playlist);
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.ceba244211ce5e4e3f8e412a840ec284b("OnGoToInstance", m_myPvpRoom.Playlist, m_myPvpRoom.GameMode);
			return;
		}
	}

	private void OnPlayerJoinPvPRoom(Presence newPlayer)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnPlayerJoinPvPRoom - " + newPlayer.mCharacterId);
		if (m_myPvpRoom == null)
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
					return;
				}
			}
		}
		m_myPvpRoom.c824d853466705b61a4e964c504c0da81(newPlayer);
		cfad162916de36b64bb6dfc6dc92711b9();
	}

	private void OnGroupJoinPvPRoom(int newGroupId)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnGroupJoinPvPRoom - " + newGroupId);
		cfad162916de36b64bb6dfc6dc92711b9();
	}

	private void OnPlayerLeavePvPRoom(int characterId)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnPlayerLeavePvPRoom - " + characterId);
		if (m_myPvpRoom == null)
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
					return;
				}
			}
		}
		if (characterId == OnlineService.s_characterId)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					m_myPvpRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
					return;
				}
			}
		}
		m_myPvpRoom.c7e6306ae6375d9ab6d595d202da0b160(characterId);
	}

	private void OnGroupLeavePvPRoom(int groupId)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnGroupLeavePvPRoom - " + groupId);
		if (m_myPvpRoom == null)
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
					return;
				}
			}
		}
		if (groupId != GroupManager.c71f6ce28731edfd43c976fbd57c57bea().m_nGroupId)
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
			m_myPvpRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnPvPRoomOwnerChange(int newOwnerCharacterId)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "MatchmakingService.OnPvPRoomOwnerChange[";
		array[1] = newOwnerCharacterId;
		array[2] = "] - ";
		array[3] = Time.time;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		if (m_myPvpRoom == null)
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
					return;
				}
			}
		}
		m_myPvpRoom.Owner = newOwnerCharacterId;
	}

	private void OnPvPRoomClose()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "MatchmakingService.OnPvPRoomClose - " + Time.time);
		m_myPvpRoom = c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e;
	}

	[CompilerGenerated]
	private static void c462aefcb47c4ee5e57c274b18ae97640(KickedFromGameListener c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9();
	}
}
