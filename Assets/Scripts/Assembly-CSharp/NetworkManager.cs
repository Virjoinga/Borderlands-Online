using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using Photon;
using UnityEngine;
using XsdSettings;

public class NetworkManager : Photon.MonoBehaviour
{
	public class AuthenticateAsyncTask : c89c54c08043729ce8a5a497efa546af3
	{
		private const int m_serverPort = 5055;

		public string m_login;

		public void c7cc9411392f033dee9802f9b9ca15b21(string c6edd70e9abfc5caaadd56b5820917981)
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
			m_login = c6edd70e9abfc5caaadd56b5820917981;
		}

		public void c7cc9411392f033dee9802f9b9ca15b21()
		{
			c92c7f03b81b92c00ce0b49a2b9058106 = 30f;
			m_login = ShandaWrapper.ShandaTicket;
		}

		public override void Start()
		{
			base.Start();
			if (!PhotonNetwork.c1f4a1fd51cd6406ba683224b3b608838)
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
						PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(158, c5ee19dc8d4cccf5ae2de225410458b86.OnGPKDynCodeEvent);
						PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(157, c5ee19dc8d4cccf5ae2de225410458b86.OnGPKAuthDataEvent);
						PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(62, c5ee19dc8d4cccf5ae2de225410458b86.OnGPKAuthReplyResponse);
						PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(230, OnAuthenticate);
						PhotonNetwork.cfb4b113d4d6dee3922de175866313174(c06ca0e618478c23eba3419653a19760f<OnlineService>.c5ee19dc8d4cccf5ae2de225410458b86.c69d53a7a913a53ac0795177e0d9ce893(), 5055, ShandaWrapper.ApplicationName, c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_debugInfo_Version, m_login, "*");
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
		}

		private void OnAuthenticate(short OperationResponse, Dictionary<byte, object> parameters)
		{
			PhotonNetwork.onlinePeer.c70c342bd044a12574e7a34217617fe88(230);
			if (OperationResponse == 0)
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
						c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Success);
						return;
					}
				}
			}
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_AuthenticationFail);
		}
	}

	public interface NetworkObserver
	{
		void OnPlayerLeaveSession(int playerId);
	}

	private static NetworkManager s_instance;

	private static byte[] s_dynCode;

	private static bool m_isDisconnected = true;

	private int m_PriorityInspectorPlayerIndex = 1;

	private Dictionary<byte, object> mCallResultDictionary;

	private bool mCallInProgress;

	private List<INetworkManagerListener> m_notificationListeners = new List<INetworkManagerListener>();

	private List<NetworkObserver> m_observers = new List<NetworkObserver>();

	private List<BadAssNetworkView> m_networkViews;

	public List<BadAssNetworkView> cd5b2d1a3a14637e9081fc019ba36ea0f
	{
		get
		{
			return m_networkViews;
		}
	}

	public static NetworkManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	public void cc7c09df5a4a467ee40cdda5047fd18d0(INetworkManagerListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_notificationListeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c31e47046c84e50120b5248468a55f966(INetworkManagerListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		if (!m_notificationListeners.Contains(c472a3b7c9dbd0d177f87c4386db7570d))
		{
			return;
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
			m_notificationListeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
			return;
		}
	}

	public void c146e4ed70154dda4f877e845c17beadb(NetworkObserver cfe3aada598d9d99f66541730305b3de0)
	{
		m_observers.Add(cfe3aada598d9d99f66541730305b3de0);
	}

	public void c6750fa0fcbeb3f33d6b1a22e0abe6316(NetworkObserver cfe3aada598d9d99f66541730305b3de0)
	{
		m_observers.Remove(cfe3aada598d9d99f66541730305b3de0);
	}

	private void Awake()
	{
		BolCustomType.c57e4d4cd41f3be21d7e24a71aa08c6ba();
		m_networkViews = new List<BadAssNetworkView>();
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "NetworkManager is already initialized");
		}
		s_instance = this;
	}

	private void Start()
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ccc9d3a38966dc10fedb531ea17d24611();
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ccc9d3a38966dc10fedb531ea17d24611();
	}

	private void Update()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_logNetworkProfile)
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
			if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
				if (Time.frameCount % 100 == 0)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Profile, "TrafficStatsOutgoing.TotalCommandBytes:" + (float)PhotonNetwork.networkingPeer.TrafficStatsOutgoing.TotalCommandBytes / (float)(PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000));
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Profile, "TrafficStatsIncoming.TotalCommandBytes:" + (float)PhotonNetwork.networkingPeer.TrafficStatsIncoming.TotalCommandBytes / (float)(PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000));
				}
			}
		}
		if (m_PriorityInspectorPlayerIndex < PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd.Length)
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
			NetworkingPriority.c5ee19dc8d4cccf5ae2de225410458b86.priorityInspector = PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd[m_PriorityInspectorPlayerIndex];
		}
		PhotonNetwork.BandwidthCap = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.BandwidthCap;
		m_PriorityInspectorPlayerIndex = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.PriorityInspector;
	}

	public void c067a069fc32be238b53d9b3e1725f179(BadAssNetworkView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		m_networkViews.Add(ca4187010cdd35921f11dd5df8ccc23e3);
	}

	public void c9102a7afa9603b27d23d3470c21b34c8(BadAssNetworkView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		m_networkViews.Remove(ca4187010cdd35921f11dd5df8ccc23e3);
	}

	public static int cf6124bd5254101846a57acc03f545846()
	{
		return PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3;
	}

	private void OnDisconnectedFromPhoton()
	{
		OnAccessSingleton<IAnnouncementService, AnnouncementService, AnnouncementServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5a21732345cea8239ce61ace459b93b1(OnAnnouncements);
		m_isDisconnected = true;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "OnDisconnectedFromPhoton from Photon." + Time.realtimeSinceStartup);
		for (int i = 0; i < m_notificationListeners.Count; i++)
		{
			m_notificationListeners[i].OnDisconnectedFromPhoton();
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_enableSndaLogin)
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
				if (!c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c3baaa4a6dea0fa0c8840ad6ec2f669bb(typeof(AuthenticateAsyncTask)))
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
							return;
						}
					}
				}
			}
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cdcc658e3c5be5baafd088fd0bf889371();
			return;
		}
	}

	private void OnConnectionFail(object parameters)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OnConnectionFail from Photon. StatusCode: ";
		array[1] = parameters;
		array[2] = "-";
		array[3] = Time.realtimeSinceStartup;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cdcc658e3c5be5baafd088fd0bf889371();
	}

	private void OnFailedToConnectToPhoton(object parameters)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OnFailedToConnectToPhoton from photon. StatusCode: ";
		array[1] = parameters;
		array[2] = "-";
		array[3] = Time.realtimeSinceStartup;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_enableSndaLogin)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cdcc658e3c5be5baafd088fd0bf889371();
	}

	private void OnConnectedToPhoton()
	{
		OnAccessSingleton<IAnnouncementService, AnnouncementService, AnnouncementServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce49f946c9c8003f00306f94e17ff7825(OnAnnouncements);
		m_isDisconnected = false;
	}

	private void OnReceivedRoomListUpdate()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "OnReceivedRoomListUpdate" + Time.realtimeSinceStartup);
	}

	private void OnJoinedRoom()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "OnJoinedRoom" + Time.realtimeSinceStartup);
		PhotonNetwork.c648541fb156a9d9dbca6397c4abab0ce();
		for (int i = 0; i < m_notificationListeners.Count; i++)
		{
			m_notificationListeners[i].OnJoinedRoom();
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

	private void OnPhotonJoinRoomFailed()
	{
		for (int i = 0; i < m_notificationListeners.Count; i++)
		{
			m_notificationListeners[i].OnPhotonJoinRoomFailed();
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

	private void OnPhotonRandomJoinFailed()
	{
		for (int i = 0; i < m_notificationListeners.Count; i++)
		{
			m_notificationListeners[i].OnPhotonRandomJoinFailed();
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
			return;
		}
	}

	public IEnumerator c36588361fa2310a4571d2d4ff01ea51f()
	{
		PhotonNetwork.c36588361fa2310a4571d2d4ff01ea51f();
		while (!m_isDisconnected)
		{
			yield return 0;
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
			while (PhotonNetwork.c47231586e002b82f52ad04d3a847f6a2 != 0)
			{
				yield return 0;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					yield break;
				}
			}
		}
	}

	public IEnumerator c4c1ac70d53ab42afe86bbfda86212944(byte c9f7e586bb3f27d35994b3e3029d2bbce, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OpOnlineCall...";
		array[1] = c9f7e586bb3f27d35994b3e3029d2bbce;
		array[2] = " - ";
		array[3] = Time.time;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		while (!PhotonNetwork.onlinePeer.mIsAuthenticated)
		{
			yield return 0;
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
			while (mCallInProgress)
			{
				yield return 0;
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
			while (!PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(c9f7e586bb3f27d35994b3e3029d2bbce, OnOperationResponse))
			{
				yield return 0;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				mCallInProgress = true;
				mCallResultDictionary = c1f3b72b0881ed84526c28aef688abd40.c7088de59e49f7108f520cf7e0bae167e;
				PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(c9f7e586bb3f27d35994b3e3029d2bbce, c90ecb087828ed9ceb9c00eafb6d52f4c);
				while (mCallInProgress)
				{
					yield return 0;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					PhotonNetwork.onlinePeer.c70c342bd044a12574e7a34217617fe88(c9f7e586bb3f27d35994b3e3029d2bbce);
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "...Done (OpOnlineCall)" + Time.realtimeSinceStartup);
					yield break;
				}
			}
		}
	}

	private void OnOperationResponse(short OperationResponse, Dictionary<byte, object> parameters)
	{
		mCallInProgress = false;
		mCallResultDictionary = parameters;
	}

	public Dictionary<byte, object> c575ae4265cfa47c31e6a70626457a2a8()
	{
		return mCallResultDictionary;
	}

	private void OnLeftLobby()
	{
	}

	private void OnPhotonCreateRoomFailed()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
	}

	private void OnLeftRoom()
	{
		for (int i = 0; i < m_notificationListeners.Count; i++)
		{
			m_notificationListeners[i].OnLeftRoom();
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
			Session session = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86;
			if ((bool)session)
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
				if (c449802e708e91a9150466060fbab2ad6())
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
					PhotonNetwork.c365a77c63c91e13de4ca19c9a953aa5e(session.gameObject);
				}
				else
				{
					Object.Destroy(session.gameObject);
				}
			}
			PhotonNetwork.c648541fb156a9d9dbca6397c4abab0ce();
			return;
		}
	}

	public void ca8938768aa17492184b45444497ec57b(GameObject c2008d5793f81ed289732e3227d73f220)
	{
	}

	private void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OnPhotonPlayerDisconnected: ";
		array[1] = player;
		array[2] = " - ";
		array[3] = player.c29a834d12d3895f5680e69a30e6cd9a3;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		if (!player.cd99af21e22e356018b8f72d4a7e4872a.Contains("Host"))
		{
			return;
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
			if (PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
				PhotonNetwork.c518ef3edadd378ef9ae215e96fa4e4fa();
				return;
			}
		}
	}

	private void OnActionLoaded()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Loading complete" + Time.realtimeSinceStartup);
	}

	public static bool c449802e708e91a9150466060fbab2ad6()
	{
		return PhotonNetwork.ca3052869987fcf5688487de12414faab;
	}

	public static bool c5878b2da4049b6b1fdfce34e8e7c030c()
	{
		return PhotonNetwork.c1f4a1fd51cd6406ba683224b3b608838;
	}

	public static bool caefb3a98af4426d2c9affa9caab55f3b()
	{
		return m_isDisconnected;
	}

	public static bool c00c3ec658bbd0ff2568a3b72647806e1()
	{
		return PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993;
	}

	public static double c0001f5085e474065d3cb214356d1ba19()
	{
		return PhotonNetwork.cad9f703d862495149cd6bddd080f050b;
	}

	public static int c22e2236f573c63e3c4ebe74a77e5061a()
	{
		return PhotonNetwork.c22e2236f573c63e3c4ebe74a77e5061a();
	}

	public static float c802128e3d024dd79aaf8dc5f4b18f6a0(int c29a834d12d3895f5680e69a30e6cd9a3)
	{
		return PhotonNetwork.c802128e3d024dd79aaf8dc5f4b18f6a0(c29a834d12d3895f5680e69a30e6cd9a3);
	}

	public static float c339b3c229d7f882ba09af8a661a021e8()
	{
		return PhotonNetwork.c339b3c229d7f882ba09af8a661a021e8();
	}

	public static float c474909384fe546f5cce7ffaeb4d12273()
	{
		return 1f / (float)PhotonNetwork.cd70da6845185cd76f7e07c2e822481bc;
	}

	public static void c1b4dc5ba75599afa71e4ac05df5cba95(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		PhotonNetwork.c365a77c63c91e13de4ca19c9a953aa5e(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
	}

	public static void c1b4dc5ba75599afa71e4ac05df5cba95(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PhotonNetwork.c365a77c63c91e13de4ca19c9a953aa5e(c5d720f6d007abb0c4a21d6a654e405bb.gameObject);
	}

	public void OnAnnouncements(Announcement[] announcement)
	{
		foreach (Announcement announcement2 in announcement)
		{
			string content = announcement2.Content;
			AnnouncementType type = announcement2.Type;
			if (type != 0)
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
				if (type != AnnouncementType.Broadcast)
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
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(content, DisplayTarget.Broadcast);
				}
			}
			else
			{
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(content, DisplayTarget.Event);
			}
			if (string.IsNullOrEmpty(announcement2.Content))
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ChatView>().cdf1b518a606ae8fae32a93c7d3abd6b2(ChatParameter.System, string.Empty, content, 0, string.Empty);
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

	private void OnGPKDynCodeEvent(Dictionary<byte, object> parameters)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "NetworkManager.OnGPKDynCodeEvent");
		s_dynCode = (byte[])parameters[0];
		ShandaWrapper.ca227271e272a3ddbfc646f54fb14ea53(s_dynCode);
	}

	private void OnGPKAuthDataEvent(Dictionary<byte, object> parameters)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "NetworkManager.OnGPKAuthDataEvent");
		byte[] c18e550f1027ab9e606a5d720bbb = (byte[])parameters[0];
		ShandaWrapper.ca4cbfff60fdab868f4e783c190d8f45d(ref c18e550f1027ab9e606a5d720bbb);
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c18e550f1027ab9e606a5d720bbb;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(62, array);
	}

	private void OnGPKAuthReplyResponse(short result, Dictionary<byte, object> parameters)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "NetworkManager.OnGPKAuthReplyResponse");
	}
}
