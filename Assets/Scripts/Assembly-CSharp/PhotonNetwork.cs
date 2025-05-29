using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using ExitGames.Client.Photon;
using UnityEngine;

public static class PhotonNetwork
{
	public const string versionPUN = "1.18";

	public const string serverSettingsAssetFile = "PhotonServerSettings";

	public const string serverSettingsAssetPath = "Assets/Tools/Photon Unity Networking/Resources/PhotonServerSettings.asset";

	internal static readonly PhotonHandler photonMono;

	internal static readonly NetworkingPeer networkingPeer;

	internal static readonly OnlineServerPeer onlinePeer;

	public static readonly int MAX_VIEW_IDS;

	internal static ServerSettings PhotonServerSettings;

	public static float precisionForVectorSynchronization;

	public static float precisionForQuaternionSynchronization;

	public static float precisionForFloatSynchronization;

	public static int BandwidthCap;

	public static PhotonLogLevel logLevel;

	public static bool UsePrefabCache;

	public static Dictionary<string, GameObject> PrefabCache;

	private static bool isOfflineMode;

	private static bool offlineMode_inRoom;

	private static bool _mAutomaticallySyncScene;

	private static bool m_autoCleanUpPlayerObjects;

	private static bool autoJoinLobbyField;

	private static int sendInterval;

	private static int sendIntervalOnSerialize;

	private static bool m_isMessageQueueRunning;

	internal static int lastUsedViewSubId;

	internal static int lastUsedViewSubIdStatic;

	internal static List<int> manuallyAllocatedViewIds;

	public static bool c1f4a1fd51cd6406ba683224b3b608838
	{
		get
		{
			if (cb738f1c8fa2a9da52b69537c9ef77993)
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
						return true;
					}
				}
			}
			return c47231586e002b82f52ad04d3a847f6a2 == ConnectionState.Connected;
		}
	}

	public static ConnectionState c47231586e002b82f52ad04d3a847f6a2
	{
		get
		{
			if (cb738f1c8fa2a9da52b69537c9ef77993)
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
						return ConnectionState.Connected;
					}
				}
			}
			if (networkingPeer == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return ConnectionState.Disconnected;
					}
				}
			}
			switch (networkingPeer.PeerState)
			{
			default:
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					return ConnectionState.Disconnected;
				}
			case PeerStateValue.Disconnected:
				return ConnectionState.Disconnected;
			case PeerStateValue.Connecting:
				return ConnectionState.Connecting;
			case PeerStateValue.Connected:
				return ConnectionState.Connected;
			case PeerStateValue.Disconnecting:
				return ConnectionState.Disconnecting;
			case PeerStateValue.InitializingApplication:
				return ConnectionState.InitializingApplication;
			}
		}
	}

	public static PeerState c900460744ca8a86df35ccfe02fc5acbd
	{
		get
		{
			if (cb738f1c8fa2a9da52b69537c9ef77993)
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
						return PeerState.Connected;
					}
				}
			}
			if (networkingPeer == null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return PeerState.Disconnected;
					}
				}
			}
			return networkingPeer.State;
		}
	}

	public static Room c3202f32ecb834b115326e72e13e35ff0
	{
		get
		{
			if (isOfflineMode)
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
						if (offlineMode_inRoom)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
									return new Room("OfflineRoom", new Hashtable());
								}
							}
						}
						return null;
					}
				}
			}
			return networkingPeer.cd5c21181722b9f8923dabeb52013c258;
		}
	}

	public static PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198
	{
		get
		{
			if (networkingPeer == null)
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
			return networkingPeer.mLocalActor;
		}
	}

	public static PhotonPlayer c740a8e9baf3963e5b095694dde6b5bd4
	{
		get
		{
			if (networkingPeer == null)
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
						return null;
					}
				}
			}
			return networkingPeer.mMasterClient;
		}
	}

	public static string cabd15f81c79912cd94358a0debf95ca1
	{
		get
		{
			return networkingPeer.cfaf3019f7ecd761fdf3b10bd42b280fc;
		}
		set
		{
			networkingPeer.cfaf3019f7ecd761fdf3b10bd42b280fc = value;
		}
	}

	public static PhotonPlayer[] cfac6072a14e502241f3c58a1c87edcfd
	{
		get
		{
			if (networkingPeer == null)
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
						return c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(0);
					}
				}
			}
			return networkingPeer.mPlayerListCopy;
		}
	}

	public static PhotonPlayer[] cd1c27f0d3521b33d514d4c1be3e770bf
	{
		get
		{
			if (networkingPeer == null)
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
						return c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(0);
					}
				}
			}
			return networkingPeer.mOtherPlayerListCopy;
		}
	}

	public static bool cb738f1c8fa2a9da52b69537c9ef77993
	{
		get
		{
			return isOfflineMode;
		}
		set
		{
			if (value == isOfflineMode)
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
			if (value)
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
				if (c1f4a1fd51cd6406ba683224b3b608838)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Can't start OFFLINE mode while connected!");
							return;
						}
					}
				}
			}
			networkingPeer.Disconnect();
			isOfflineMode = value;
			if (isOfflineMode)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToPhoton, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
						networkingPeer.c47a09570985116e9e55e611716c53bbe(1);
						networkingPeer.mMasterClient = ceb41162a7cd2a1d5c4a03830e02b4198;
						return;
					}
				}
			}
			networkingPeer.c47a09570985116e9e55e611716c53bbe(-1);
			networkingPeer.mMasterClient = c753457029073de95298730c041a2b844.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	[Obsolete("Used for compatibility with Unity networking only.")]
	public static int cee0dfe9eccd111cbc699b089803e7fda
	{
		get
		{
			if (c3202f32ecb834b115326e72e13e35ff0 == null)
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
						return 0;
					}
				}
			}
			return c3202f32ecb834b115326e72e13e35ff0.c0b46a01b8c5164654f47e46e1eeb023d;
		}
		set
		{
			c3202f32ecb834b115326e72e13e35ff0.c0b46a01b8c5164654f47e46e1eeb023d = value;
		}
	}

	public static bool c9bea90d20d3b9c1060b684f2bc77db82
	{
		get
		{
			return _mAutomaticallySyncScene;
		}
		set
		{
			_mAutomaticallySyncScene = value;
			if (!_mAutomaticallySyncScene)
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
				if (c3202f32ecb834b115326e72e13e35ff0 == null)
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
					networkingPeer.ce24ae7eda88a0a7db54f496822feaa00();
					return;
				}
			}
		}
	}

	public static bool c0dbabee0b7d4bab75f679a04a95a4a7f
	{
		get
		{
			return m_autoCleanUpPlayerObjects;
		}
		set
		{
			if (c3202f32ecb834b115326e72e13e35ff0 != null)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Setting autoCleanUpPlayerObjects while in a room is not supported.");
			}
			m_autoCleanUpPlayerObjects = value;
		}
	}

	public static bool c2d7a0c5838aaa0006b15e2b02f9c76ab
	{
		get
		{
			return autoJoinLobbyField;
		}
		set
		{
			autoJoinLobbyField = value;
		}
	}

	public static bool c2ebc20f6de827cc08eea9e2569f10710
	{
		get
		{
			return networkingPeer.insideLobby;
		}
	}

	public static int cdf9a39b9b00c5bc0c0d5701ce9fd8578
	{
		get
		{
			return 1000 / sendInterval;
		}
		set
		{
			sendInterval = 1000 / value;
			if (photonMono != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				photonMono.updateInterval = sendInterval;
			}
			if (value >= cd70da6845185cd76f7e07c2e822481bc)
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
				cd70da6845185cd76f7e07c2e822481bc = value;
				return;
			}
		}
	}

	public static int cd70da6845185cd76f7e07c2e822481bc
	{
		get
		{
			return 1000 / sendIntervalOnSerialize;
		}
		set
		{
			if (value > cdf9a39b9b00c5bc0c0d5701ce9fd8578)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error, can not set the OnSerialize SendRate more often then the overall SendRate");
				value = cdf9a39b9b00c5bc0c0d5701ce9fd8578;
			}
			sendIntervalOnSerialize = 1000 / value;
			if (!(photonMono != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				photonMono.updateIntervalOnSerialize = sendIntervalOnSerialize;
				return;
			}
		}
	}

	public static bool c195baff01be84d431dc217cf68ed2569
	{
		get
		{
			return m_isMessageQueueRunning;
		}
		set
		{
			if (value == m_isMessageQueueRunning)
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
			networkingPeer.IsSendingOnlyAcks = !value;
			m_isMessageQueueRunning = value;
			if (value)
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
				PhotonHandler.c40ea94b900b535d69b3dc0b94566ddd4();
				return;
			}
		}
	}

	public static int c499bf72a3dc784749f502ba132c655dd
	{
		get
		{
			return networkingPeer.LimitOfUnreliableCommands;
		}
		set
		{
			networkingPeer.LimitOfUnreliableCommands = value;
		}
	}

	public static double cad9f703d862495149cd6bddd080f050b
	{
		get
		{
			if (cb738f1c8fa2a9da52b69537c9ef77993)
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
						return Time.time;
					}
				}
			}
			return (double)(uint)networkingPeer.ServerTimeInMilliSeconds / 1000.0;
		}
	}

	public static bool ca3052869987fcf5688487de12414faab
	{
		get
		{
			if (cb738f1c8fa2a9da52b69537c9ef77993)
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
						return true;
					}
				}
			}
			return networkingPeer.mMasterClient == networkingPeer.mLocalActor;
		}
	}

	public static bool cef03eae567e7f28f253960743b86e665
	{
		get
		{
			int result;
			if (!ca3052869987fcf5688487de12414faab)
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
				result = ((c3202f32ecb834b115326e72e13e35ff0 != c58acf0753df8febfcec856ec9ffff66c.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public static int c92dd9e2e3b465c55d84ee80a388de293
	{
		get
		{
			return networkingPeer.mPlayersOnMasterCount;
		}
	}

	public static int c1d8f4d2b09a3010fe2f31afa8ad6ab9b
	{
		get
		{
			return networkingPeer.mPlayersInRoomsCount;
		}
	}

	public static int cda5944de66bc99fa0f56c25ffdabec59
	{
		get
		{
			return networkingPeer.mPlayersInRoomsCount + networkingPeer.mPlayersOnMasterCount;
		}
	}

	public static int c4dc4b21a74da701d31659ae6e1c61cf3
	{
		get
		{
			if (c2ebc20f6de827cc08eea9e2569f10710)
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
						return c92c6e1cf92474e71bd25add4065075be().Length;
					}
				}
			}
			return networkingPeer.mGameCount;
		}
	}

	public static bool c01fb44a84b234955e072426cda6b8914
	{
		get
		{
			return networkingPeer.TrafficStatsEnabled;
		}
		set
		{
			networkingPeer.TrafficStatsEnabled = value;
		}
	}

	static PhotonNetwork()
	{
		MAX_VIEW_IDS = 100000;
		PhotonServerSettings = (ServerSettings)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("PhotonServerSettings", Type.GetTypeFromHandle(c0819a578e1afa8e2acd2def723f0d421.cc1720d05c75832f704b87474932341c3()));
		precisionForVectorSynchronization = 9.9E-05f;
		precisionForQuaternionSynchronization = 1f;
		precisionForFloatSynchronization = 0.01f;
		BandwidthCap = 100;
		logLevel = PhotonLogLevel.ErrorsOnly;
		UsePrefabCache = false;
		PrefabCache = new Dictionary<string, GameObject>();
		isOfflineMode = false;
		offlineMode_inRoom = false;
		_mAutomaticallySyncScene = false;
		m_autoCleanUpPlayerObjects = true;
		autoJoinLobbyField = true;
		sendInterval = 10;
		sendIntervalOnSerialize = 66;
		m_isMessageQueueRunning = true;
		lastUsedViewSubId = 0;
		lastUsedViewSubIdStatic = 0;
		manuallyAllocatedViewIds = new List<int>();
		Application.runInBackground = true;
		GameObject gameObject = new GameObject();
		photonMono = gameObject.AddComponent<PhotonHandler>();
		gameObject.name = "PhotonMono";
		gameObject.hideFlags = HideFlags.HideInHierarchy;
		GameObject gameObject2 = new GameObject();
		gameObject2.AddComponent<PhotonRecvHandler>();
		gameObject2.name = "PhotonRECV";
		gameObject2.hideFlags = HideFlags.HideInHierarchy;
		networkingPeer = new NetworkingPeer(photonMono, string.Empty, ConnectionProtocol.Udp);
		networkingPeer.LimitOfUnreliableCommands = 100;
		GameObject gameObject3 = new GameObject();
		OnlinePeerHandler c472a3b7c9dbd0d177f87c4386db7570d = gameObject3.AddComponent<OnlinePeerHandler>();
		gameObject3.name = "PhotonOnline";
		gameObject3.hideFlags = HideFlags.HideInHierarchy;
		onlinePeer = new OnlineServerPeer(c472a3b7c9dbd0d177f87c4386db7570d, ConnectionProtocol.Udp);
		CustomTypes.c57e4d4cd41f3be21d7e24a71aa08c6ba();
	}

	public static void c648541fb156a9d9dbca6397c4abab0ce()
	{
		networkingPeer.TrafficStatsReset();
		networkingPeer.c46fc13c7a1f8093eb8c7ab700c70b599();
	}

	public static string cc7503ef97e1b7265b48ab37f60e170b1()
	{
		if (networkingPeer != null)
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
			if (!cb738f1c8fa2a9da52b69537c9ef77993)
			{
				return networkingPeer.VitalStatsToString(false);
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
		}
		return "Offline or in OfflineMode. No VitalStats available.";
	}

	public static void cc72e0e316e12e9e36080c2336aa68c2e()
	{
		PhotonHandler[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c99a31a2a2bd9e09b0570ca72ec94069a.cc1720d05c75832f704b87474932341c3())) as PhotonHandler[];
		if (array == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (array.Length <= 0)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Cleaning up hidden PhotonHandler instances in scene. Please save it. This is not an issue.");
				PhotonHandler[] array2 = array;
				foreach (PhotonHandler photonHandler in array2)
				{
					photonHandler.gameObject.hideFlags = HideFlags.None;
					if (photonHandler.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (photonHandler.gameObject.name == "PhotonMono")
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
							UnityEngine.Object.DestroyImmediate(photonHandler.gameObject);
						}
					}
					UnityEngine.Object.DestroyImmediate(photonHandler);
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
	}

	public static void cc6f98a090034673f27addfaabd176e0f(string cd74188a7969ea2c999bbfcfdd816f094)
	{
		if (PhotonServerSettings == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Can't connect: Loading settings failed. ServerSettings asset must be in any 'Resources' folder as: PhotonServerSettings");
					return;
				}
			}
		}
		if (PhotonServerSettings.HostType == ServerSettings.HostingOption.OfflineMode)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					cb738f1c8fa2a9da52b69537c9ef77993 = true;
					return;
				}
			}
		}
		cfb4b113d4d6dee3922de175866313174(PhotonServerSettings.ServerAddress, PhotonServerSettings.ServerPort, PhotonServerSettings.AppID, cd74188a7969ea2c999bbfcfdd816f094, string.Empty, string.Empty);
	}

	[Obsolete("This method is obsolete; use ConnectUsingSettings with the gameVersion argument instead")]
	public static void cc6f98a090034673f27addfaabd176e0f()
	{
		cc6f98a090034673f27addfaabd176e0f("1.0");
	}

	[Obsolete("This method is obsolete; use Connect with the gameVersion argument instead")]
	public static void cfb4b113d4d6dee3922de175866313174(string ce4c253674eeb8857a96a9a931342747a, int c5c985c685b7526fbdadd031d9dc846d0, string c838dcbdabcfbf5222ac964c81f0fef5e)
	{
		cfb4b113d4d6dee3922de175866313174(ce4c253674eeb8857a96a9a931342747a, c5c985c685b7526fbdadd031d9dc846d0, c838dcbdabcfbf5222ac964c81f0fef5e, "1.0", string.Empty, string.Empty);
	}

	public static void cfb4b113d4d6dee3922de175866313174(string ce4c253674eeb8857a96a9a931342747a, int c5c985c685b7526fbdadd031d9dc846d0, string c9431b2ab295d7c2a3400b2fa319f2763, string cd74188a7969ea2c999bbfcfdd816f094, string c4ae384bbd6931efdcdcc85c03ae9aeaa = "", string cb292fbb0d136ed940c5827add605879c = "")
	{
		if (c5c985c685b7526fbdadd031d9dc846d0 <= 0)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Aborted Connect: invalid port: " + c5c985c685b7526fbdadd031d9dc846d0);
					return;
				}
			}
		}
		if (ce4c253674eeb8857a96a9a931342747a.Length <= 2)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Aborted Connect: invalid serverAddress: " + ce4c253674eeb8857a96a9a931342747a);
					return;
				}
			}
		}
		if (networkingPeer.PeerState != 0)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Connect() only works when disconnected. Current state: " + networkingPeer.PeerState);
					return;
				}
			}
		}
		if (cb738f1c8fa2a9da52b69537c9ef77993)
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
			cb738f1c8fa2a9da52b69537c9ef77993 = false;
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Shut down offline mode due to a connect attempt");
		}
		if (!c195baff01be84d431dc217cf68ed2569)
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
			c195baff01be84d431dc217cf68ed2569 = true;
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Forced enabling of isMessageQueueRunning because of a Connect()");
		}
		ce4c253674eeb8857a96a9a931342747a = ce4c253674eeb8857a96a9a931342747a + ":" + c5c985c685b7526fbdadd031d9dc846d0;
		networkingPeer.mAppVersion = cd74188a7969ea2c999bbfcfdd816f094;
		networkingPeer.maccount = c4ae384bbd6931efdcdcc85c03ae9aeaa;
		networkingPeer.mpwd = cb292fbb0d136ed940c5827add605879c;
		networkingPeer.Connect(ce4c253674eeb8857a96a9a931342747a, c9431b2ab295d7c2a3400b2fa319f2763);
	}

	public static void c36588361fa2310a4571d2d4ff01ea51f()
	{
		if (cb738f1c8fa2a9da52b69537c9ef77993)
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
					cb738f1c8fa2a9da52b69537c9ef77993 = false;
					networkingPeer.State = PeerState.Disconnecting;
					networkingPeer.OnStatusChanged(StatusCode.Disconnect);
					return;
				}
			}
		}
		if (networkingPeer == null)
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
		networkingPeer.Disconnect();
		if (onlinePeer == null)
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
			onlinePeer.Disconnect();
			return;
		}
	}

	[Obsolete("Used for compatibility with Unity networking only. Encryption is automatically initialized while connecting.")]
	public static void c536b68a5ff55528eccdda6c5601227f7()
	{
	}

	public static void c60aadf937663066892a3364d647feb60(string c37dc4ee4a3a694110f0e0eb7b086137a)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "this custom props " + ceb41162a7cd2a1d5c4a03830e02b4198.customProperties.c6aba88300c0d1ecf7ee0f1db776d8306());
		if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.ConnectedToGameserver)
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
			if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joining)
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
				if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joined)
				{
					if (c3202f32ecb834b115326e72e13e35ff0 != null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "CreateRoom aborted: You are already in a room!");
								return;
							}
						}
					}
					if (cb738f1c8fa2a9da52b69537c9ef77993)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								offlineMode_inRoom = true;
								NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnCreatedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
								NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnJoinedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
								return;
							}
						}
					}
					networkingPeer.c801fb2e013d68d11ac76bea0784a40c3(c37dc4ee4a3a694110f0e0eb7b086137a, true, true, 0, c0dbabee0b7d4bab75f679a04a95a4a7f, null, c7e77aa637b9ae1290617ecc771e6c274.c7088de59e49f7108f520cf7e0bae167e);
					return;
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
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "CreateRoom aborted: You are already connecting to a room!");
	}

	public static void c60aadf937663066892a3364d647feb60(string c37dc4ee4a3a694110f0e0eb7b086137a, bool cb4040e85ef24e4c9dea5dfc714598840, bool c5168d3b88f2be16369b322f43806da6a, int c0b46a01b8c5164654f47e46e1eeb023d)
	{
		c60aadf937663066892a3364d647feb60(c37dc4ee4a3a694110f0e0eb7b086137a, cb4040e85ef24e4c9dea5dfc714598840, c5168d3b88f2be16369b322f43806da6a, c0b46a01b8c5164654f47e46e1eeb023d, null, c7e77aa637b9ae1290617ecc771e6c274.c7088de59e49f7108f520cf7e0bae167e);
	}

	public static void c60aadf937663066892a3364d647feb60(string c37dc4ee4a3a694110f0e0eb7b086137a, bool cb4040e85ef24e4c9dea5dfc714598840, bool c5168d3b88f2be16369b322f43806da6a, int c0b46a01b8c5164654f47e46e1eeb023d, Hashtable c808744fac31e30ed2a1677188e2e2146, string[] c21ce5c605cfa17cdebc2aabc44d3afd6)
	{
		if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joining)
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
			if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joined)
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
				if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.ConnectedToGameserver)
				{
					if (c3202f32ecb834b115326e72e13e35ff0 != null)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "CreateRoom aborted: You are already in a room!");
								return;
							}
						}
					}
					if (cb738f1c8fa2a9da52b69537c9ef77993)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								offlineMode_inRoom = true;
								NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnCreatedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
								return;
							}
						}
					}
					if (c0b46a01b8c5164654f47e46e1eeb023d > 255)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: CreateRoom called with " + c0b46a01b8c5164654f47e46e1eeb023d + " maxplayers. This has been reverted to the max of 255 players because internally a 'byte' is used.");
						c0b46a01b8c5164654f47e46e1eeb023d = 255;
					}
					networkingPeer.c801fb2e013d68d11ac76bea0784a40c3(c37dc4ee4a3a694110f0e0eb7b086137a, cb4040e85ef24e4c9dea5dfc714598840, c5168d3b88f2be16369b322f43806da6a, (byte)c0b46a01b8c5164654f47e46e1eeb023d, c0dbabee0b7d4bab75f679a04a95a4a7f, c808744fac31e30ed2a1677188e2e2146, c21ce5c605cfa17cdebc2aabc44d3afd6);
					return;
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
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "CreateRoom aborted: You can only create a room while not currently connected/connecting to a room.");
	}

	public static void cbed89c6829274cdc65c25ca1f298510b(RoomInfo c958a509eeb000317cf94e5d890c4de5a)
	{
		if (c958a509eeb000317cf94e5d890c4de5a == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "JoinRoom aborted: you passed a NULL room");
					return;
				}
			}
		}
		cbed89c6829274cdc65c25ca1f298510b(c958a509eeb000317cf94e5d890c4de5a.cd99af21e22e356018b8f72d4a7e4872a);
	}

	public static void cbed89c6829274cdc65c25ca1f298510b(string c37dc4ee4a3a694110f0e0eb7b086137a)
	{
		if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joining)
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
			if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joined)
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
				if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.ConnectedToGameserver)
				{
					if (c3202f32ecb834b115326e72e13e35ff0 != null)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "JoinRoom aborted: You are already in a room!");
								return;
							}
						}
					}
					if (c37dc4ee4a3a694110f0e0eb7b086137a == string.Empty)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "JoinRoom aborted: You must specifiy a room name!");
								return;
							}
						}
					}
					if (cb738f1c8fa2a9da52b69537c9ef77993)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								offlineMode_inRoom = true;
								NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnJoinedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
								return;
							}
						}
					}
					networkingPeer.c4abb80911dadab3f96ba18e7705bb9db(c37dc4ee4a3a694110f0e0eb7b086137a, cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e);
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
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "JoinRoom aborted: You can only join a room while not currently connected/connecting to a room.");
	}

	public static void cfbfcc20bd35df7e2bf18d44b273b8627()
	{
		cfbfcc20bd35df7e2bf18d44b273b8627(null, 0);
	}

	public static void cfbfcc20bd35df7e2bf18d44b273b8627(Hashtable cc216f23dc2f7b783e32208e7241b9544, byte c8dc74ab19c3c6f5ead0a1fc2cc03de95)
	{
		cfbfcc20bd35df7e2bf18d44b273b8627(cc216f23dc2f7b783e32208e7241b9544, c8dc74ab19c3c6f5ead0a1fc2cc03de95, MatchmakingMode.FillRoom);
	}

	public static void cfbfcc20bd35df7e2bf18d44b273b8627(Hashtable cc216f23dc2f7b783e32208e7241b9544, byte c8dc74ab19c3c6f5ead0a1fc2cc03de95, MatchmakingMode ccd174d743f15030d5636ccf8809f60a5)
	{
		if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joining)
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
			if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joined)
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
				if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.ConnectedToGameserver)
				{
					if (c3202f32ecb834b115326e72e13e35ff0 != null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "JoinRandomRoom aborted: You are already in a room!");
								return;
							}
						}
					}
					if (cb738f1c8fa2a9da52b69537c9ef77993)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								offlineMode_inRoom = true;
								NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnJoinedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
								return;
							}
						}
					}
					Hashtable hashtable = new Hashtable();
					hashtable.cf7c1c7a7b045d5d6df74fc02c9a94917(cc216f23dc2f7b783e32208e7241b9544);
					if (c8dc74ab19c3c6f5ead0a1fc2cc03de95 > 0)
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
						hashtable[byte.MaxValue] = c8dc74ab19c3c6f5ead0a1fc2cc03de95;
					}
					networkingPeer.c6715dd5fbd319c6fb14b86148a6be9fe(hashtable, 0, null, ccd174d743f15030d5636ccf8809f60a5);
					return;
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
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "JoinRandomRoom aborted: You can only join a room while not currently connected/connecting to a room.");
	}

	public static void c0518072442c60d48f51bda13225408e4(Query c27323aa13bfba26a627057af3c513966, int cbd27e27b8828e4abd80513cb973357c9 = 50)
	{
		networkingPeer.cae1b51ba9a6af8beb635eb3abce8405c(c27323aa13bfba26a627057af3c513966, cbd27e27b8828e4abd80513cb973357c9);
	}

	public static void c093a0227be03dbb9e0754429e5fd2fb1()
	{
		if (!cb738f1c8fa2a9da52b69537c9ef77993)
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
			if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joining)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Format("PhotonNetwork: No join attempt in progress to cancel (State = {0})", c900460744ca8a86df35ccfe02fc5acbd));
						return;
					}
				}
			}
		}
		if (cb738f1c8fa2a9da52b69537c9ef77993)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					offlineMode_inRoom = false;
					NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnLeftRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
					return;
				}
			}
		}
		networkingPeer.c54053354c2f7c1c50dd8ddd80d1d2507();
	}

	public static void c518ef3edadd378ef9ae215e96fa4e4fa()
	{
		if (!cb738f1c8fa2a9da52b69537c9ef77993)
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
			if (c900460744ca8a86df35ccfe02fc5acbd != PeerState.Joined)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork: Error, you cannot leave a room if you're not in a room!(1)");
						return;
					}
				}
			}
		}
		if (c3202f32ecb834b115326e72e13e35ff0 == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork: Error, you cannot leave a room if you're not in a room!(2)");
					return;
				}
			}
		}
		if (cb738f1c8fa2a9da52b69537c9ef77993)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					offlineMode_inRoom = false;
					NetworkingPeer.c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnLeftRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
					return;
				}
			}
		}
		networkingPeer.c46ffaa7512d43a16a25cb7dcff65a646();
	}

	public static RoomInfo[] c92c6e1cf92474e71bd25add4065075be()
	{
		if (cb738f1c8fa2a9da52b69537c9ef77993)
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
					return c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(0);
				}
			}
		}
		if (networkingPeer == null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(0);
				}
			}
		}
		return networkingPeer.mGameListCopy;
	}

	public static void c78d9650862a02be6a187d77cf3250192(Hashtable ce640f5adbb33c511c28e1250d8608dd4)
	{
		if (ce640f5adbb33c511c28e1250d8608dd4 == null)
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
			ce640f5adbb33c511c28e1250d8608dd4 = new Hashtable();
			IEnumerator enumerator = ceb41162a7cd2a1d5c4a03830e02b4198.customProperties.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					ce640f5adbb33c511c28e1250d8608dd4[(string)current] = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_0065;
					}
					continue;
					end_IL_0065:
					break;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_007b;
						}
						continue;
						end_IL_007b:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
		if (c3202f32ecb834b115326e72e13e35ff0 != null)
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
			if (c3202f32ecb834b115326e72e13e35ff0.isLocalClientInside)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						ceb41162a7cd2a1d5c4a03830e02b4198.ccd6fde3cd72529d9bc2523ed219b2bd4(ce640f5adbb33c511c28e1250d8608dd4);
						return;
					}
				}
			}
		}
		ceb41162a7cd2a1d5c4a03830e02b4198.cb0dbb1e66069845b8379c37136865ca4(ce640f5adbb33c511c28e1250d8608dd4);
	}

	public static int cd9d8abcd8b021274e1896fa28d342267()
	{
		int num = cd9d8abcd8b021274e1896fa28d342267(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3);
		manuallyAllocatedViewIds.Add(num);
		return num;
	}

	public static void cd0cd5f73c2743d963c9e6453565e5a00(int ce57f12a4f7e693a5fe0c4049dc56fa7c)
	{
		manuallyAllocatedViewIds.Remove(ce57f12a4f7e693a5fe0c4049dc56fa7c);
		if (!networkingPeer.photonViewList.ContainsKey(ce57f12a4f7e693a5fe0c4049dc56fa7c))
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, string.Format("Unallocated manually used viewID: {0} but found it used still in a PhotonView: {1}", ce57f12a4f7e693a5fe0c4049dc56fa7c, networkingPeer.photonViewList[ce57f12a4f7e693a5fe0c4049dc56fa7c]));
			return;
		}
	}

	private static int cd9d8abcd8b021274e1896fa28d342267(int cf7005beb75ee79ff6b82c543057315e1)
	{
		if (cf7005beb75ee79ff6b82c543057315e1 == 0)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int num = lastUsedViewSubIdStatic;
					int num2 = cf7005beb75ee79ff6b82c543057315e1 * MAX_VIEW_IDS;
					for (int i = 1; i < MAX_VIEW_IDS; i++)
					{
						num = (num + 1) % MAX_VIEW_IDS;
						if (num == 0)
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
						}
						else
						{
							int num3 = num + num2;
							if (!networkingPeer.photonViewList.ContainsKey(num3))
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										lastUsedViewSubIdStatic = num;
										return num3;
									}
								}
							}
						}
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							throw new Exception(string.Format("AllocateViewID() failed. Room (user {0}) is out of subIds, as all room viewIDs are used.", cf7005beb75ee79ff6b82c543057315e1));
						}
					}
				}
				}
			}
		}
		int num4 = lastUsedViewSubId;
		int num5 = cf7005beb75ee79ff6b82c543057315e1 * MAX_VIEW_IDS;
		for (int j = 1; j < MAX_VIEW_IDS; j++)
		{
			num4 = (num4 + 1) % MAX_VIEW_IDS;
			if (num4 == 0)
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
				continue;
			}
			int num6 = num4 + num5;
			if (networkingPeer.photonViewList.ContainsKey(num6))
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
			if (manuallyAllocatedViewIds.Contains(num6))
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
				lastUsedViewSubId = num4;
				return num6;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			throw new Exception(string.Format("AllocateViewID() failed. User {0} is out of subIds, as all viewIDs are used.", cf7005beb75ee79ff6b82c543057315e1));
		}
	}

	private static int[] cd0283bde1ce3109eec2646b70e23d16b(int c7078b79e94078996f6e53ef57f365d29)
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(c7078b79e94078996f6e53ef57f365d29);
		for (int i = 0; i < c7078b79e94078996f6e53ef57f365d29; i++)
		{
			array[i] = cd9d8abcd8b021274e1896fa28d342267(0);
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
			return array;
		}
	}

	public static GameObject c90236f85f4a0b603b56f8daf34c2279e(string c9c536cdaad24471d7a448d2853440144, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, int c6279c42b47398c5e401c1cff54ce61c2)
	{
		return c90236f85f4a0b603b56f8daf34c2279e(c9c536cdaad24471d7a448d2853440144, cef9712200bbe2c3873eec3ca2e18a595, c4ea6de03c1203f2470a6677821ad93f0, c6279c42b47398c5e401c1cff54ce61c2, c5045159a57582d4577b6fa1bce364dca.c7088de59e49f7108f520cf7e0bae167e);
	}

	public static GameObject c90236f85f4a0b603b56f8daf34c2279e(string c9c536cdaad24471d7a448d2853440144, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, int c6279c42b47398c5e401c1cff54ce61c2, object[] c591d56a94543e3559945c497f37126c4)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + c9c536cdaad24471d7a448d2853440144 + "] as the game is not connected.");
					return null;
				}
			}
		}
		GameObject gameObject = ResourcesLoader.c4e95594aa6d23f20094cfec50ccb1899(c9c536cdaad24471d7a448d2853440144);
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + c9c536cdaad24471d7a448d2853440144 + "]. Please verify you have this gameobject in a Resources folder (and not in a subfolder)");
					return null;
				}
			}
		}
		if (gameObject.GetComponent<PhotonView>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + c9c536cdaad24471d7a448d2853440144 + "] as it has no PhotonView attached to the root.");
					return null;
				}
			}
		}
		Component[] componentsInChildren = gameObject.GetComponentsInChildren<PhotonView>(true);
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(componentsInChildren.Length);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = cd9d8abcd8b021274e1896fa28d342267(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			Hashtable c98406db696ab6ddbd25ee108c3e91e6a = networkingPeer.c953a4225d60af4de6285142d21ca8c0f(c9c536cdaad24471d7a448d2853440144, cef9712200bbe2c3873eec3ca2e18a595, c4ea6de03c1203f2470a6677821ad93f0, c6279c42b47398c5e401c1cff54ce61c2, array, c591d56a94543e3559945c497f37126c4, false);
			return networkingPeer.ccc94c604b2052f09e290f808f38e7bd8(c98406db696ab6ddbd25ee108c3e91e6a, networkingPeer.mLocalActor, gameObject, true);
		}
	}

	public static GameObject c7b017a7a2a47b0e278741de2d03d84ee(string c9c536cdaad24471d7a448d2853440144, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, int c6279c42b47398c5e401c1cff54ce61c2, object[] c591d56a94543e3559945c497f37126c4)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (!ca3052869987fcf5688487de12414faab)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error [InstantiateSceneObject]: Only the master client can Instantiate scene objects");
					return null;
				}
			}
		}
		GameObject gameObject = ResourcesLoader.c4e95594aa6d23f20094cfec50ccb1899(c9c536cdaad24471d7a448d2853440144);
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [" + c9c536cdaad24471d7a448d2853440144 + "]. Please verify you have this gameobject in a Resources folder (and not in a subfolder)");
					return null;
				}
			}
		}
		if (gameObject.GetComponent<PhotonView>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [" + c9c536cdaad24471d7a448d2853440144 + "] as it has no PhotonView attached to the root.");
					return null;
				}
			}
		}
		Component[] array = gameObject.cb0af1eac32d2112bb0cc859a7ed20362();
		int[] array2 = cd0283bde1ce3109eec2646b70e23d16b(array.Length);
		if (array2 == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array3[0] = "PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [";
					array3[1] = c9c536cdaad24471d7a448d2853440144;
					array3[2] = "] as no ViewIDs are free to use. Max is: ";
					array3[3] = MAX_VIEW_IDS;
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array3));
					return null;
				}
				}
			}
		}
		Hashtable c98406db696ab6ddbd25ee108c3e91e6a = networkingPeer.c953a4225d60af4de6285142d21ca8c0f(c9c536cdaad24471d7a448d2853440144, cef9712200bbe2c3873eec3ca2e18a595, c4ea6de03c1203f2470a6677821ad93f0, c6279c42b47398c5e401c1cff54ce61c2, array2, c591d56a94543e3559945c497f37126c4, true);
		return networkingPeer.ccc94c604b2052f09e290f808f38e7bd8(c98406db696ab6ddbd25ee108c3e91e6a, networkingPeer.mLocalActor, gameObject, true);
	}

	public static int c22e2236f573c63e3c4ebe74a77e5061a()
	{
		return networkingPeer.RoundTripTime;
	}

	public static void c25e7107659f9ffa07e1557e0fe8aeb79()
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		while (networkingPeer.SendOutgoingCommands())
		{
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

	public static void c8f3f2d9cc4e09c681410abc2a111c6f8(PhotonPlayer c2959699e7ee95d5ce5836dfabe97713a)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (!ceb41162a7cd2a1d5c4a03830e02b4198.ca3052869987fcf5688487de12414faab)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "CloseConnection: Only the masterclient can kick another player.");
		}
		if (c2959699e7ee95d5ce5836dfabe97713a == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "CloseConnection: No such player connected!");
					return;
				}
			}
		}
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c2959699e7ee95d5ce5836dfabe97713a.c29a834d12d3895f5680e69a30e6cd9a3;
		networkingPeer.c3f632fdd31c8a3f2463924fbc1ced8b4(203, null, true, 0, array);
	}

	public static void c365a77c63c91e13de4ca19c9a953aa5e(PhotonView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (ca4187010cdd35921f11dd5df8ccc23e3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (ca4187010cdd35921f11dd5df8ccc23e3.c6971afb2ced2e6c56d327fce1c3bca83)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (ca4187010cdd35921f11dd5df8ccc23e3.instantiationId > 0)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									networkingPeer.c5204a3cd31d565129c4cb4c2f22a3c08(ca4187010cdd35921f11dd5df8ccc23e3, false);
									return;
								}
							}
						}
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Use PhotonNetwork.Destroy(view) only on PhotonViews created with PhotonNetwork.Instantiate(). GameObject not destroyed: " + ca4187010cdd35921f11dd5df8ccc23e3.gameObject);
						return;
					}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat("Destroy: Could not destroy view ID [", ca4187010cdd35921f11dd5df8ccc23e3, "]. Does not exist, or is not ours!"));
	}

	public static void c365a77c63c91e13de4ca19c9a953aa5e(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		PhotonView component = c68eeb75ae8e0180ebe74a7f42c8bcf3f.GetComponent<PhotonView>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Cannot call Destroy(GameObject go); on the gameobject \"" + c68eeb75ae8e0180ebe74a7f42c8bcf3f.name + "\" as it has no PhotonView attached.");
					return;
				}
			}
		}
		if (component.c6971afb2ced2e6c56d327fce1c3bca83)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					int num = networkingPeer.cce00c62160e5ebfb1592369cbe6f2c66(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
					if (num <= 0)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Use PhotonNetwork.Destroy() only on GameObjects created with PhotonNetwork.Instantiate(). GameObject not destroyed: " + c68eeb75ae8e0180ebe74a7f42c8bcf3f);
								return;
							}
						}
					}
					networkingPeer.cb6e59f148cd5a994857c3d7623cab3f9(c68eeb75ae8e0180ebe74a7f42c8bcf3f, false);
					return;
				}
				}
			}
		}
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = "Cannot call Destroy(GameObject go); on the gameobject \"";
		array[1] = c68eeb75ae8e0180ebe74a7f42c8bcf3f.name;
		array[2] = "\" as we don't control it (Owner: ";
		array[3] = component.c706ea4155b03100282fe553e4d0be557;
		array[4] = ").";
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
	}

	public static void cc699b379927298a8be1bc2ede0079994(PhotonPlayer cb56b9f1eda3cadf034bd5a2639a3cc2f)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (!ceb41162a7cd2a1d5c4a03830e02b4198.ca3052869987fcf5688487de12414faab)
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
			if (cb56b9f1eda3cadf034bd5a2639a3cc2f != ceb41162a7cd2a1d5c4a03830e02b4198)
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat("Couldn't destroy objects for player \"", cb56b9f1eda3cadf034bd5a2639a3cc2f, "\" as we are not the masterclient."));
				return;
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
		networkingPeer.cc699b379927298a8be1bc2ede0079994(cb56b9f1eda3cadf034bd5a2639a3cc2f, false);
	}

	public static void c8ef81fcccf6abc1c374efe36516b49fd()
	{
		if (ca3052869987fcf5688487de12414faab)
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
					networkingPeer.c8ef81fcccf6abc1c374efe36516b49fd();
					return;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Couldn't call RemoveAllInstantiatedObjects as only the master client is allowed to call this.");
	}

	public static void c8ef81fcccf6abc1c374efe36516b49fd(PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab8)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (!ceb41162a7cd2a1d5c4a03830e02b4198.ca3052869987fcf5688487de12414faab)
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
			if (c8bb3a6115f009b6d03350a85a41ecab8 != ceb41162a7cd2a1d5c4a03830e02b4198)
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat("Couldn't RemoveAllInstantiatedObjects for player \"", c8bb3a6115f009b6d03350a85a41ecab8, "\" as only the master client or the player itself is allowed to call this."));
				return;
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
		networkingPeer.c25ff6a61adf58242bd658adf180a3823(c8bb3a6115f009b6d03350a85a41ecab8, false);
	}

	internal static void c19fd12ed98be2a9174d53644dc9757c8(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, string ca57789de86459caf1b0cd284afe32a38, PhotonTargets c82fcbab5e578dc3a31c1f662916bd87e, bool c975f237222e991e51b0b1732262bfdfa, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (c3202f32ecb834b115326e72e13e35ff0 == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Cannot send RPCs in Lobby! RPC dropped.");
					return;
				}
			}
		}
		if (networkingPeer != null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					networkingPeer.c19fd12ed98be2a9174d53644dc9757c8(ca4187010cdd35921f11dd5df8ccc23e3, ca57789de86459caf1b0cd284afe32a38, c82fcbab5e578dc3a31c1f662916bd87e, c975f237222e991e51b0b1732262bfdfa, c90ecb087828ed9ceb9c00eafb6d52f4c);
					return;
				}
			}
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Could not execute RPC " + ca57789de86459caf1b0cd284afe32a38 + ". Possible scene loading in progress?");
	}

	internal static void c19fd12ed98be2a9174d53644dc9757c8(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, string ca57789de86459caf1b0cd284afe32a38, PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab8, bool c975f237222e991e51b0b1732262bfdfa, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (c3202f32ecb834b115326e72e13e35ff0 == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Cannot send RPCs in Lobby, only processed locally");
					return;
				}
			}
		}
		if (ceb41162a7cd2a1d5c4a03830e02b4198 == null)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error; Sending RPC to player null! Aborted \"" + ca57789de86459caf1b0cd284afe32a38 + "\"");
		}
		if (networkingPeer != null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					networkingPeer.c19fd12ed98be2a9174d53644dc9757c8(ca4187010cdd35921f11dd5df8ccc23e3, ca57789de86459caf1b0cd284afe32a38, c8bb3a6115f009b6d03350a85a41ecab8, c975f237222e991e51b0b1732262bfdfa, c90ecb087828ed9ceb9c00eafb6d52f4c);
					return;
				}
			}
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Could not execute RPC " + ca57789de86459caf1b0cd284afe32a38 + ". Possible scene loading in progress?");
	}

	public static void c2b4c9018817e93481982b6ddc148afed()
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		c2b4c9018817e93481982b6ddc148afed(ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	public static void c2b4c9018817e93481982b6ddc148afed(PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab8)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (!c8bb3a6115f009b6d03350a85a41ecab8.isLocal)
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
			if (!ca3052869987fcf5688487de12414faab)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error; Only the MasterClient can call RemoveRPCs for other players.");
						return;
					}
				}
			}
		}
		networkingPeer.c2b4c9018817e93481982b6ddc148afed(c8bb3a6115f009b6d03350a85a41ecab8.c29a834d12d3895f5680e69a30e6cd9a3);
	}

	public static void ca63e8fda19213bb676c46e58d8bd8879()
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		ca63e8fda19213bb676c46e58d8bd8879(ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	public static void ca63e8fda19213bb676c46e58d8bd8879(PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab8)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		if (!c8bb3a6115f009b6d03350a85a41ecab8.isLocal)
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
			if (!ca3052869987fcf5688487de12414faab)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error; Only the MasterClient can call RemoveAllBufferedMessages for other players.");
						return;
					}
				}
			}
		}
		networkingPeer.c24a5383c72642b308da7a3f4043b0bf0(c8bb3a6115f009b6d03350a85a41ecab8.c29a834d12d3895f5680e69a30e6cd9a3);
	}

	public static void c2b4c9018817e93481982b6ddc148afed(PhotonView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		networkingPeer.c2b4c9018817e93481982b6ddc148afed(ca4187010cdd35921f11dd5df8ccc23e3);
	}

	public static void c8c6965cfbe25e116b57410f152db9a9e(int c6279c42b47398c5e401c1cff54ce61c2)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		networkingPeer.c8c6965cfbe25e116b57410f152db9a9e(c6279c42b47398c5e401c1cff54ce61c2);
	}

	public static void cda9bc04ce8997ffe268cc6b552dd0dca(int c6279c42b47398c5e401c1cff54ce61c2, bool cbf402c82d0fffee7c8f37c98e456b8f8)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
		networkingPeer.cda9bc04ce8997ffe268cc6b552dd0dca(c6279c42b47398c5e401c1cff54ce61c2, cbf402c82d0fffee7c8f37c98e456b8f8);
	}

	public static void c2a8c532fff5faa34b206b73bfc4009ee(int c6279c42b47398c5e401c1cff54ce61c2, bool cbf402c82d0fffee7c8f37c98e456b8f8)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
					return;
				}
			}
		}
		networkingPeer.c2a8c532fff5faa34b206b73bfc4009ee(c6279c42b47398c5e401c1cff54ce61c2, cbf402c82d0fffee7c8f37c98e456b8f8);
	}

	public static void ccf8bc3f00101ac6e04b7ed4720c536da(short c26bc9278762c84e1e76177f085674c7e)
	{
		if (!c85f9b0804b8ac6f1c13ee274f35b49c9())
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
					return;
				}
			}
		}
		networkingPeer.ccf8bc3f00101ac6e04b7ed4720c536da(c26bc9278762c84e1e76177f085674c7e);
	}

	private static bool c85f9b0804b8ac6f1c13ee274f35b49c9()
	{
		if (networkingPeer != null)
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
			if (!cb738f1c8fa2a9da52b69537c9ef77993)
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
				if (!c1f4a1fd51cd6406ba683224b3b608838)
				{
					goto IL_0042;
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
			}
			return true;
		}
		goto IL_0042;
		IL_0042:
		DebugUtils.s_debugInfoSync.m_enabled = false;
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Cannot send messages when not connected; Either connect to Photon OR use offline mode!");
		return false;
	}

	public static void cc470f09a50548899d959dcf8e6a205f7(int cfc252e63fa558d5a367d539bc215e640)
	{
		c195baff01be84d431dc217cf68ed2569 = false;
		networkingPeer.loadingLevelAndPausedNetwork = true;
		Application.LoadLevel(cfc252e63fa558d5a367d539bc215e640);
	}

	public static void cc470f09a50548899d959dcf8e6a205f7(string c7cfa459897587e04e9d8e9bd63800d77)
	{
		c195baff01be84d431dc217cf68ed2569 = false;
		networkingPeer.loadingLevelAndPausedNetwork = true;
		Application.LoadLevel(c7cfa459897587e04e9d8e9bd63800d77);
	}

	public static float c802128e3d024dd79aaf8dc5f4b18f6a0(int c29a834d12d3895f5680e69a30e6cd9a3)
	{
		return networkingPeer.c802128e3d024dd79aaf8dc5f4b18f6a0(c29a834d12d3895f5680e69a30e6cd9a3);
	}

	public static float c339b3c229d7f882ba09af8a661a021e8()
	{
		return networkingPeer.c339b3c229d7f882ba09af8a661a021e8();
	}
}
