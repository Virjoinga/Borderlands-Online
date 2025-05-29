using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using A;
using Core;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;
using UnityEngine;
using XsdSettings;

internal class NetworkingPeer : LoadbalancingPeer, IPhotonPeerListener
{
	private enum InstantiateState
	{
		Success = 0,
		Fail = 1,
		Pending = 2
	}

	private class InstantiatingPhotonViews
	{
		public GameObject instantiateHelper;

		public int instantiationId;

		public GameObject resourceGameObject;

		public string prefabName;

		public Vector3 position;

		public Quaternion rotation;

		public PhotonPlayer photonPlayer;

		public int serverTime;

		public int group;

		public int objLevelPrefix;

		public object[] incomingInstantiationData;
	}

	protected internal const string CurrentSceneProperty = "curScn";

	public string mAppVersion;

	public string mAppId;

	private string masterServerAddress;

	private string playername = string.Empty;

	private IPhotonPeerListener externalListener;

	private JoinType mLastJoinType;

	private bool mPlayernameHasToBeUpdated;

	private Queue<string> mFallbackSessions;

	public Dictionary<int, PhotonPlayer> mActors = new Dictionary<int, PhotonPlayer>();

	public PhotonPlayer[] mOtherPlayerListCopy = c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(0);

	public PhotonPlayer[] mPlayerListCopy = c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(0);

	public PhotonPlayer mMasterClient;

	public bool requestSecurity = true;

	private Dictionary<Type, List<MethodInfo>> monoRPCMethodsCache = new Dictionary<Type, List<MethodInfo>>();

	public static bool UsePrefabCache = false;

	public static Dictionary<string, GameObject> PrefabCache = new Dictionary<string, GameObject>();

	public Dictionary<string, RoomInfo> mGameList = new Dictionary<string, RoomInfo>();

	public RoomInfo[] mGameListCopy = c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(0);

	public bool insideLobby;

	public Dictionary<int, GameObject> instantiatedObjects = new Dictionary<int, GameObject>();

	public HashSet<int> allowedReceivingGroups = new HashSet<int>();

	private HashSet<int> blockSendingGroups = new HashSet<int>();

	protected internal Dictionary<int, PhotonView> photonViewList = new Dictionary<int, PhotonView>();

	protected internal short currentLevelPrefix;

	private Dictionary<Type, Dictionary<PhotonNetworkingMessage, MethodInfo>> cachedMethods = new Dictionary<Type, Dictionary<PhotonNetworkingMessage, MethodInfo>>();

	private List<PhotonView> photonViews = new List<PhotonView>();

	private List<PhotonView> photonActiveViews = new List<PhotonView>();

	private List<PhotonView> CollectViews = new List<PhotonView>();

	private List<PhotonView> BroadcastViews = new List<PhotonView>();

	private Dictionary<int, float> peerRoundTripTimes = new Dictionary<int, float>();

	private PhotonChannel m_pingChannel = new PhotonChannel(5);

	private int m_viewUpdateCount;

	private int m_lastUpdatedPlayerIndex;

	public NetworkingPriority networkingPriority = NetworkingPriority.c5ee19dc8d4cccf5ae2de225410458b86;

	private bool m_instantiatePending;

	public string maccount;

	public string mpwd;

	public string mToken;

	private List<InstantiatingPhotonViews> instantiatingPhotonViews = new List<InstantiatingPhotonViews>();

	private List<InstantiatingPhotonViews> removingInstantiatingPhotonViews = new List<InstantiatingPhotonViews>();

	private Dictionary<int, object[]> tempInstantiationData = new Dictionary<int, object[]>();

	protected internal bool loadingLevelAndPausedNetwork;

	private Dictionary<int, int> networkStat = new Dictionary<int, int>();

	private Dictionary<int, int> networkStatRCV = new Dictionary<int, int>();

	private Dictionary<byte, OperationResponseCallback> mOperationResponseCallbacks = new Dictionary<byte, OperationResponseCallback>();

	private Dictionary<byte, EventCallback> mEventCallbacks = new Dictionary<byte, EventCallback>();

	[CompilerGenerated]
	private static Comparison<PhotonView> _003C_003Ef__am_0024cache3A;

	[CompilerGenerated]
	private static Comparison<PhotonView> _003C_003Ef__am_0024cache3B;

	[CompilerGenerated]
	private static Func<int, byte> _003C_003Ef__am_0024cache3C;

	private bool MasterConnection { get; set; }

	private bool FirstConnectMaster { get; set; }

	public string cfaf3019f7ecd761fdf3b10bd42b280fc
	{
		get
		{
			return playername;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
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
				if (value.Equals(playername))
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (mLocalActor != null)
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
					mLocalActor.cd99af21e22e356018b8f72d4a7e4872a = value;
				}
				playername = value;
				if (cd5c21181722b9f8923dabeb52013c258 == null)
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
					cd15ea4c0b41287c8a2c242480449a1c4();
					return;
				}
			}
		}
	}

	public PeerState State { get; internal set; }

	public Room cd5c21181722b9f8923dabeb52013c258
	{
		get
		{
			if (mRoomToGetInto != null)
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
				if (mRoomToGetInto.isLocalClientInside)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return mRoomToGetInto;
						}
					}
				}
			}
			return null;
		}
	}

	internal Room mRoomToGetInto { get; set; }

	public PhotonPlayer mLocalActor { get; internal set; }

	public string mGameserver { get; internal set; }

	public int mQueuePosition { get; internal set; }

	public int mPlayersOnMasterCount { get; internal set; }

	public int mGameCount { get; internal set; }

	public int mPlayersInRoomsCount { get; internal set; }

	public int grossInstantiateData { get; private set; }

	public int grossInstantiateDataRCV { get; private set; }

	public NetworkingPeer(IPhotonPeerListener c472a3b7c9dbd0d177f87c4386db7570d, string c19a5aefdbd5c59a20d37538b900a551f, ConnectionProtocol c0973ff69a357598ff19d26dd4c8f20a9)
		: base(c472a3b7c9dbd0d177f87c4386db7570d, c0973ff69a357598ff19d26dd4c8f20a9)
	{
		base.Listener = this;
		externalListener = c472a3b7c9dbd0d177f87c4386db7570d;
		cfaf3019f7ecd761fdf3b10bd42b280fc = c19a5aefdbd5c59a20d37538b900a551f;
		mLocalActor = new PhotonPlayer(true, -1, playername);
		ca7051da8e9918f1f9ead7bef8d5c95de(mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3, mLocalActor);
		State = global::PeerState.PeerCreated;
		mFallbackSessions = new Queue<string>();
		base.ChannelCount = 3;
		MasterConnection = true;
		FirstConnectMaster = true;
	}

	public void Reset()
	{
		FirstConnectMaster = true;
	}

	public ReadOnlyCollection<PhotonView> c576f1120fff1daec1eed262d16cd8625()
	{
		return photonViews.AsReadOnly();
	}

	public ReadOnlyCollection<PhotonView> c7a16247bc5d88b42dbabe627f5962c2e()
	{
		return photonActiveViews.AsReadOnly();
	}

	public void c7a16247bc5d88b42dbabe627f5962c2e(out List<PhotonView> cf6759adb49f9f5b7c419697ac8bd0f43)
	{
		cf6759adb49f9f5b7c419697ac8bd0f43 = photonActiveViews;
	}

	public float c802128e3d024dd79aaf8dc5f4b18f6a0(int c41a218288823eedce4b520981ea598ef)
	{
		float value = 0f;
		if (peerRoundTripTimes.TryGetValue(c41a218288823eedce4b520981ea598ef, out value))
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
					return value;
				}
			}
		}
		return 0f;
	}

	public float c339b3c229d7f882ba09af8a661a021e8()
	{
		float num = 0f;
		if (peerRoundTripTimes.Count > 0)
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
			num = float.MaxValue;
		}
		Dictionary<int, float>.Enumerator enumerator = peerRoundTripTimes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!(enumerator.Current.Value < num))
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
			num = enumerator.Current.Value;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return num;
		}
	}

	public override bool Connect(string serverAddress, string appID)
	{
		if (PhotonNetwork.c900460744ca8a86df35ccfe02fc5acbd == global::PeerState.Disconnecting)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "ERROR: Cannot connect to Photon while Disconnecting. Connection failed.");
					return false;
				}
			}
		}
		if (string.IsNullOrEmpty(masterServerAddress))
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
			masterServerAddress = serverAddress;
		}
		mAppId = appID.Trim();
		bool flag = base.Connect(serverAddress, string.Empty);
		int state;
		if (flag)
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
			state = 2;
		}
		else
		{
			state = 18;
		}
		State = (PeerState)state;
		return flag;
	}

	public override void Disconnect()
	{
		if (base.PeerState == PeerStateValue.Disconnected)
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
					if ((int)base.DebugOut >= 2)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								DebugReturn(DebugLevel.WARNING, string.Format("Can't execute Disconnect() while not connected. Nothing changed. State: {0}", State));
								return;
							}
						}
					}
					return;
				}
			}
		}
		base.Disconnect();
		State = global::PeerState.Disconnecting;
		cd6dc8abf43021dddac7da19de2d488f0();
		c3c5f89cb6a2b80518f211800a20ae336();
	}

	private void c06d6442ad9d793db50b4128c63748199()
	{
		base.Disconnect();
		State = global::PeerState.DisconnectingFromMasterserver;
		c3c5f89cb6a2b80518f211800a20ae336();
	}

	private void c6b1f6ebed2d829baa34ef76b35faae89()
	{
		base.Disconnect();
		State = global::PeerState.DisconnectingFromGameserver;
		cd6dc8abf43021dddac7da19de2d488f0();
	}

	private void c3c5f89cb6a2b80518f211800a20ae336()
	{
		if (!insideLobby)
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
		c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnLeftLobby, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
		insideLobby = false;
	}

	private void cd6dc8abf43021dddac7da19de2d488f0()
	{
		bool flag = mRoomToGetInto != c58acf0753df8febfcec856ec9ffff66c.c7088de59e49f7108f520cf7e0bae167e;
		bool num;
		if (mRoomToGetInto != null)
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
			num = mRoomToGetInto.c67310dbe99bce4fde88aae0e8960d168;
		}
		else
		{
			num = PhotonNetwork.c0dbabee0b7d4bab75f679a04a95a4a7f;
		}
		bool flag2 = num;
		mRoomToGetInto = c58acf0753df8febfcec856ec9ffff66c.c7088de59e49f7108f520cf7e0bae167e;
		mActors = new Dictionary<int, PhotonPlayer>();
		mPlayerListCopy = c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(0);
		mOtherPlayerListCopy = c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(0);
		mMasterClient = c753457029073de95298730c041a2b844.c7088de59e49f7108f520cf7e0bae167e;
		allowedReceivingGroups = new HashSet<int>();
		blockSendingGroups = new HashSet<int>();
		mGameList = new Dictionary<string, RoomInfo>();
		mGameListCopy = c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(0);
		networkingPriority.cac7688b05e921e2be3f92479ba44b4a8();
		instantiatingPhotonViews = new List<InstantiatingPhotonViews>();
		removingInstantiatingPhotonViews = new List<InstantiatingPhotonViews>();
		c47a09570985116e9e55e611716c53bbe(-1);
		if (flag2)
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
			List<GameObject> list = new List<GameObject>(instantiatedObjects.Values);
			using (Dictionary<int, PhotonView>.ValueCollection.Enumerator enumerator = photonViewList.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PhotonView current = enumerator.Current;
					if (!(current != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (current.c4888a6d1dea202176b2cd777ad28f3a6)
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
					if (!(current.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					list.Add(current.gameObject);
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0188;
					}
					continue;
					end_IL_0188:
					break;
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				GameObject gameObject = list[num2];
				if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if ((int)base.DebugOut >= 5)
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
						DebugReturn(DebugLevel.ALL, "Network destroy Instantiated GO: " + gameObject.name);
					}
					c13c17c1e00c5e4fc1833ef858d92cb77(gameObject);
				}
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
			instantiatedObjects = new Dictionary<int, GameObject>();
			PhotonNetwork.manuallyAllocatedViewIds = new List<int>();
			PhotonNetwork.lastUsedViewSubId = 0;
			PhotonNetwork.lastUsedViewSubIdStatic = 0;
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
				continue;
			}
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnLeftRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			return;
		}
	}

	private void c13c17c1e00c5e4fc1833ef858d92cb77(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		PhotonView[] componentsInChildren = c68eeb75ae8e0180ebe74a7f42c8bcf3f.GetComponentsInChildren<PhotonView>(true);
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			if (!(photonView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			photonView.destroyedByPhotonNetworkOrQuit = true;
			c97ffe8eafefa0eb594f4fc597de59226(photonView);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			UnityEngine.Object.Destroy(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
			return;
		}
	}

	private void cfcb836df8befca88a49988e5eb2e0eba(Hashtable c409129e403832642d20f53a4226efd28, Hashtable c15a4fdc48895422fd36dee2c19218688, int cb2cabee973f5f20c3991e0ae4cd4ae10)
	{
		if (cd5c21181722b9f8923dabeb52013c258 != null)
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
			if (c409129e403832642d20f53a4226efd28 != null)
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
				cd5c21181722b9f8923dabeb52013c258.cd044c9cb28b3007bfdd98781f1a72634(c409129e403832642d20f53a4226efd28);
				if (PhotonNetwork.c9bea90d20d3b9c1060b684f2bc77db82)
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
					ce24ae7eda88a0a7db54f496822feaa00();
				}
			}
		}
		if (c15a4fdc48895422fd36dee2c19218688 == null)
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
			if (c15a4fdc48895422fd36dee2c19218688.Count <= 0)
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
				if (cb2cabee973f5f20c3991e0ae4cd4ae10 > 0)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
						{
							PhotonPlayer photonPlayer = ceff8946cf24e72dd9ea8047ab447f350(cb2cabee973f5f20c3991e0ae4cd4ae10);
							if (photonPlayer != null)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										break;
									default:
										photonPlayer.cb0dbb1e66069845b8379c37136865ca4(c6f5237cebc4aabf78798471fa844dd14(c15a4fdc48895422fd36dee2c19218688, cb2cabee973f5f20c3991e0ae4cd4ae10));
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
				IEnumerator enumerator = c15a4fdc48895422fd36dee2c19218688.Keys.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						int num = (int)current;
						Hashtable hashtable = (Hashtable)c15a4fdc48895422fd36dee2c19218688[current];
						string cd99af21e22e356018b8f72d4a7e4872a = (string)hashtable[byte.MaxValue];
						PhotonPlayer photonPlayer2 = ceff8946cf24e72dd9ea8047ab447f350(num);
						if (photonPlayer2 == null)
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
							photonPlayer2 = new PhotonPlayer(false, num, cd99af21e22e356018b8f72d4a7e4872a);
							ca7051da8e9918f1f9ead7bef8d5c95de(num, photonPlayer2);
						}
						photonPlayer2.cb0dbb1e66069845b8379c37136865ca4(hashtable);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable == null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_0159;
							}
							continue;
							end_IL_0159:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
	}

	private void ca7051da8e9918f1f9ead7bef8d5c95de(int c29a834d12d3895f5680e69a30e6cd9a3, PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (!mActors.ContainsKey(c29a834d12d3895f5680e69a30e6cd9a3))
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
					mActors[c29a834d12d3895f5680e69a30e6cd9a3] = ceb41162a7cd2a1d5c4a03830e02b4198;
					c255df638fce998c47e6557eaba795701();
					return;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Adding player twice: " + c29a834d12d3895f5680e69a30e6cd9a3);
	}

	private void c45d6ce1eabe3a9e89281a38caea5e87e(int c29a834d12d3895f5680e69a30e6cd9a3, PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		mActors.Remove(c29a834d12d3895f5680e69a30e6cd9a3);
		networkingPriority.c45d6ce1eabe3a9e89281a38caea5e87e(ceb41162a7cd2a1d5c4a03830e02b4198);
		peerRoundTripTimes.Remove(c29a834d12d3895f5680e69a30e6cd9a3);
		if (ceb41162a7cd2a1d5c4a03830e02b4198.isLocal)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c255df638fce998c47e6557eaba795701();
			return;
		}
	}

	private void c255df638fce998c47e6557eaba795701()
	{
		mPlayerListCopy = c8be6916b4ce3d671057da0998674a500.c0a0cdf4a196914163f7334d9b0781a04(mActors.Count);
		mActors.Values.CopyTo(mPlayerListCopy, 0);
		List<PhotonPlayer> list = new List<PhotonPlayer>();
		PhotonPlayer[] array = mPlayerListCopy;
		foreach (PhotonPlayer photonPlayer in array)
		{
			if (photonPlayer.isLocal)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			list.Add(photonPlayer);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			mOtherPlayerListCopy = list.ToArray();
			return;
		}
	}

	private void c96f15e0f592cb1920546b183cf59f100()
	{
		using (Dictionary<int, PhotonView>.ValueCollection.Enumerator enumerator = photonViewList.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PhotonView current = enumerator.Current;
				current.lastOnSerializeDataSentPerPlayer.Clear();
				current.firstSent = true;
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

	private void cbdae083d4bb2e479cfb718503a916178(int c1fcca35699f8d2167a0da927444e9283)
	{
		if ((int)base.DebugOut >= 3)
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
			DebugReturn(DebugLevel.INFO, "HandleEventLeave actorNr: " + c1fcca35699f8d2167a0da927444e9283);
		}
		if (c1fcca35699f8d2167a0da927444e9283 >= 0)
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
			if (mActors.ContainsKey(c1fcca35699f8d2167a0da927444e9283))
			{
				PhotonPlayer photonPlayer = ceff8946cf24e72dd9ea8047ab447f350(c1fcca35699f8d2167a0da927444e9283);
				if (photonPlayer == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: HandleEventLeave for actorID=" + c1fcca35699f8d2167a0da927444e9283 + " has no PhotonPlayer!");
				}
				if (mMasterClient != null)
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
					if (mMasterClient.c29a834d12d3895f5680e69a30e6cd9a3 == c1fcca35699f8d2167a0da927444e9283)
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
						mMasterClient = c753457029073de95298730c041a2b844.c7088de59e49f7108f520cf7e0bae167e;
					}
				}
				ced143055c8d12fa6d54c60ad061f9bb1(c1fcca35699f8d2167a0da927444e9283);
				if (cd5c21181722b9f8923dabeb52013c258 != null)
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
					if (cd5c21181722b9f8923dabeb52013c258.c67310dbe99bce4fde88aae0e8960d168)
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
						cc699b379927298a8be1bc2ede0079994(photonPlayer, true);
					}
				}
				c45d6ce1eabe3a9e89281a38caea5e87e(c1fcca35699f8d2167a0da927444e9283, photonPlayer);
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = photonPlayer;
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonPlayerDisconnected, array);
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
		if ((int)base.DebugOut < 1)
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
			DebugReturn(DebugLevel.ERROR, string.Format("Received event Leave for unknown actorNumber: {0}", c1fcca35699f8d2167a0da927444e9283));
			return;
		}
	}

	private void ced143055c8d12fa6d54c60ad061f9bb1(int cb60ea1236d30d1bd0b5295c462ff2fee)
	{
		int num = int.MaxValue;
		if (mMasterClient != null)
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
			if (mActors.ContainsKey(mMasterClient.c29a834d12d3895f5680e69a30e6cd9a3))
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
		}
		using (Dictionary<int, PhotonPlayer>.KeyCollection.Enumerator enumerator = mActors.Keys.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				if (cb60ea1236d30d1bd0b5295c462ff2fee != -1)
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
					if (cb60ea1236d30d1bd0b5295c462ff2fee == current)
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
						continue;
					}
				}
				if (current >= num)
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
				num = current;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00a2;
				}
				continue;
				end_IL_00a2:
				break;
			}
		}
		if (mMasterClient != null)
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
			if (mMasterClient.c29a834d12d3895f5680e69a30e6cd9a3 == num)
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
				break;
			}
		}
		bool flag = mMasterClient != c753457029073de95298730c041a2b844.c7088de59e49f7108f520cf7e0bae167e;
		mMasterClient = mActors[num];
		if (!flag)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = mMasterClient;
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnMasterClientSwitched, array);
			return;
		}
	}

	private Hashtable c6f5237cebc4aabf78798471fa844dd14(Hashtable c3aa9fea8c8f603f879dba8953ea14aa9, int c69f92abf82891a726d320565a4b46747)
	{
		if (c3aa9fea8c8f603f879dba8953ea14aa9.ContainsKey(c69f92abf82891a726d320565a4b46747))
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
					return (Hashtable)c3aa9fea8c8f603f879dba8953ea14aa9[c69f92abf82891a726d320565a4b46747];
				}
			}
		}
		return c3aa9fea8c8f603f879dba8953ea14aa9;
	}

	private PhotonPlayer ceff8946cf24e72dd9ea8047ab447f350(int c971e5554515aa942515c80324d1526ac)
	{
		if (mActors != null)
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
			if (mActors.ContainsKey(c971e5554515aa942515c80324d1526ac))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return mActors[c971e5554515aa942515c80324d1526ac];
					}
				}
			}
		}
		return null;
	}

	private void cd15ea4c0b41287c8a2c242480449a1c4()
	{
		if (State == global::PeerState.Joining)
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
					mPlayernameHasToBeUpdated = true;
					return;
				}
			}
		}
		if (mLocalActor == null)
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
			mLocalActor.cd99af21e22e356018b8f72d4a7e4872a = cfaf3019f7ecd761fdf3b10bd42b280fc;
			Hashtable hashtable = new Hashtable();
			hashtable[byte.MaxValue] = cfaf3019f7ecd761fdf3b10bd42b280fc;
			c3a0951743c01f7942b6400256e038385(mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3, hashtable, true, 0);
			mPlayernameHasToBeUpdated = false;
			return;
		}
	}

	private void c82a4193ab99ee3e1b68478aa9d56c8c5(OperationResponse cce7ce3ed228d51c35130fa4898c77ee7)
	{
		if (cce7ce3ed228d51c35130fa4898c77ee7.ReturnCode != 0)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					byte operationCode = cce7ce3ed228d51c35130fa4898c77ee7.OperationCode;
					switch (operationCode)
					{
					default:
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						if (operationCode != 198)
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
							break;
						}
						goto case 127;
					case 227:
						DebugReturn(DebugLevel.ERROR, "Create failed on GameServer. Changing back to MasterServer. Msg: " + cce7ce3ed228d51c35130fa4898c77ee7.DebugMessage);
						c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonCreateRoomFailed, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
						break;
					case 127:
					case 226:
						if (mFallbackSessions.Count > 0)
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
							string text = mFallbackSessions.Dequeue();
							mRoomToGetInto = new Room(text, mRoomToGetInto.ce640f5adbb33c511c28e1250d8608dd4);
							c4abb80911dadab3f96ba18e7705bb9db(text, mRoomToGetInto.ce640f5adbb33c511c28e1250d8608dd4);
						}
						else
						{
							DebugReturn(DebugLevel.WARNING, "Join failed on GameServer. Changing back to MasterServer. Msg: " + cce7ce3ed228d51c35130fa4898c77ee7.DebugMessage);
							if (cce7ce3ed228d51c35130fa4898c77ee7.ReturnCode == 32758)
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
								DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Most likely the game became empty during the switch to GameServer.");
							}
							c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
						}
						break;
					case 225:
						DebugReturn(DebugLevel.WARNING, "Join failed on GameServer. Changing back to MasterServer. Msg: " + cce7ce3ed228d51c35130fa4898c77ee7.DebugMessage);
						if (cce7ce3ed228d51c35130fa4898c77ee7.ReturnCode == 32758)
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
							DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Most likely the game became empty during the switch to GameServer.");
						}
						c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
						break;
					}
					c6b1f6ebed2d829baa34ef76b35faae89();
					return;
				}
				}
			}
		}
		State = global::PeerState.Joined;
		mRoomToGetInto.isLocalClientInside = true;
		Hashtable c15a4fdc48895422fd36dee2c = (Hashtable)cce7ce3ed228d51c35130fa4898c77ee7[249];
		Hashtable c409129e403832642d20f53a4226efd = (Hashtable)cce7ce3ed228d51c35130fa4898c77ee7[248];
		cfcb836df8befca88a49988e5eb2e0eba(c409129e403832642d20f53a4226efd, c15a4fdc48895422fd36dee2c, 0);
		int c0bd3dfeaeba2e4f0683e462008a4d = (int)cce7ce3ed228d51c35130fa4898c77ee7[254];
		c47a09570985116e9e55e611716c53bbe(c0bd3dfeaeba2e4f0683e462008a4d);
		ced143055c8d12fa6d54c60ad061f9bb1(-1);
		if (mPlayernameHasToBeUpdated)
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
			cd15ea4c0b41287c8a2c242480449a1c4();
		}
		switch (cce7ce3ed228d51c35130fa4898c77ee7.OperationCode)
		{
		case 227:
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnCreatedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			break;
		case 226:
			break;
		case 225:
			break;
		}
	}

	private Hashtable c10784d1cf252b4e2680185ea41e29848()
	{
		if (PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198 != null)
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
					return PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.c851686ef62470f37b12330382531e202;
				}
			}
		}
		Hashtable hashtable = new Hashtable();
		hashtable[byte.MaxValue] = cfaf3019f7ecd761fdf3b10bd42b280fc;
		return hashtable;
	}

	public void c47a09570985116e9e55e611716c53bbe(int c0bd3dfeaeba2e4f0683e462008a4d725)
	{
		if (mLocalActor == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, string.Format("Local actor is null or not in mActors! mLocalActor: {0} mActors==null: {1} newID: {2}", mLocalActor, mActors == cd9080a06c481fa2cb7d837a22e980df4.c7088de59e49f7108f520cf7e0bae167e, c0bd3dfeaeba2e4f0683e462008a4d725));
		}
		if (mActors.ContainsKey(mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3))
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
			mActors.Remove(mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3);
		}
		mLocalActor.c1f4bf1012509b3cca22015d985496450(c0bd3dfeaeba2e4f0683e462008a4d725);
		mActors[mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3] = mLocalActor;
		c255df638fce998c47e6557eaba795701();
	}

	public bool c801fb2e013d68d11ac76bea0784a40c3(string c1f7c2fc950f696c563315e5f82d048ef, bool cb4040e85ef24e4c9dea5dfc714598840, bool c5168d3b88f2be16369b322f43806da6a, byte c0b46a01b8c5164654f47e46e1eeb023d, bool c67310dbe99bce4fde88aae0e8960d168, Hashtable c4e3a4419df98fc37d124b71bf492078b, string[] c1b09a32c25c3773378bddebf5c74b063)
	{
		mRoomToGetInto = new Room(c1f7c2fc950f696c563315e5f82d048ef, c4e3a4419df98fc37d124b71bf492078b, cb4040e85ef24e4c9dea5dfc714598840, c5168d3b88f2be16369b322f43806da6a, c0b46a01b8c5164654f47e46e1eeb023d, c67310dbe99bce4fde88aae0e8960d168, c1b09a32c25c3773378bddebf5c74b063);
		return base.c01fd1557d36bde4a054dbe40540eaaea(c1f7c2fc950f696c563315e5f82d048ef, cb4040e85ef24e4c9dea5dfc714598840, c5168d3b88f2be16369b322f43806da6a, c0b46a01b8c5164654f47e46e1eeb023d, c67310dbe99bce4fde88aae0e8960d168, c4e3a4419df98fc37d124b71bf492078b, c10784d1cf252b4e2680185ea41e29848(), c1b09a32c25c3773378bddebf5c74b063);
	}

	public bool cae1b51ba9a6af8beb635eb3abce8405c(Query c27323aa13bfba26a627057af3c513966, int cbd27e27b8828e4abd80513cb973357c9 = 50)
	{
		return cae1b51ba9a6af8beb635eb3abce8405c(c27323aa13bfba26a627057af3c513966.Parameters, c27323aa13bfba26a627057af3c513966.Operations, cbd27e27b8828e4abd80513cb973357c9);
	}

	public bool c4abb80911dadab3f96ba18e7705bb9db(string c1f7c2fc950f696c563315e5f82d048ef, Hashtable ce640f5adbb33c511c28e1250d8608dd4 = null)
	{
		mRoomToGetInto = new Room(c1f7c2fc950f696c563315e5f82d048ef, cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e);
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)246] = maccount;
		hashtable[(byte)253] = true;
		hashtable[(byte)249] = true;
		if (ce640f5adbb33c511c28e1250d8608dd4 != null)
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
			object key = (byte)247;
			int num;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("PlaylistId"))
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
				num = (int)ce640f5adbb33c511c28e1250d8608dd4["PlaylistId"];
			}
			else
			{
				num = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId;
			}
			hashtable[key] = num;
			object key2 = (byte)245;
			int num2;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("GameMode"))
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
				num2 = (int)ce640f5adbb33c511c28e1250d8608dd4["GameMode"];
			}
			else
			{
				num2 = -1;
			}
			hashtable[key2] = num2;
			object key3 = (byte)244;
			int num3;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("PlayerLevel"))
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
				num3 = (int)ce640f5adbb33c511c28e1250d8608dd4["PlayerLevel"];
			}
			else
			{
				num3 = -1;
			}
			hashtable[key3] = num3;
			object key4 = (byte)243;
			int num4;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("ForceStartGameTime"))
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
				num4 = (int)ce640f5adbb33c511c28e1250d8608dd4["ForceStartGameTime"];
			}
			else
			{
				num4 = 0;
			}
			hashtable[key4] = num4;
			object key5 = (byte)242;
			int num5;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("JoinInProgress"))
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
				num5 = (((bool)ce640f5adbb33c511c28e1250d8608dd4["JoinInProgress"]) ? 1 : 0);
			}
			else
			{
				num5 = 1;
			}
			hashtable[key5] = (byte)num5 != 0;
			object key6 = (byte)241;
			int num6;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("GroupMatchmakingEnabled"))
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
				num6 = (((bool)ce640f5adbb33c511c28e1250d8608dd4["GroupMatchmakingEnabled"]) ? 1 : 0);
			}
			else
			{
				num6 = 0;
			}
			hashtable[key6] = (byte)num6 != 0;
			object key7 = (byte)240;
			int num7;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("LevelledMatchmaking"))
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
				num7 = (((bool)ce640f5adbb33c511c28e1250d8608dd4["LevelledMatchmaking"]) ? 1 : 0);
			}
			else
			{
				num7 = 0;
			}
			hashtable[key7] = (byte)num7 != 0;
			object key8 = (byte)239;
			int num8;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("Difficulty"))
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
				num8 = (int)ce640f5adbb33c511c28e1250d8608dd4["Difficulty"];
			}
			else
			{
				num8 = 0;
			}
			hashtable[key8] = num8;
			object key9 = (byte)253;
			int num9;
			if (ce640f5adbb33c511c28e1250d8608dd4.ContainsKey("IsOpen"))
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
				num9 = (((bool)ce640f5adbb33c511c28e1250d8608dd4["IsOpen"]) ? 1 : 0);
			}
			else
			{
				num9 = 1;
			}
			hashtable[key9] = (byte)num9 != 0;
		}
		else
		{
			hashtable[(byte)247] = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId;
		}
		Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
		hashtable[(byte)248] = (byte)playlist.m_minPlayerCountToStart;
		hashtable[byte.MaxValue] = (byte)playlist.m_maxPlayerCount;
		if (!hashtable.ContainsKey((byte)245))
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
			hashtable[(byte)245] = (int)MatchmakingService.c6921a12df59fc1206bd8bea12427f9af(playlist.m_gameMode);
		}
		return c4a277d4f554bad523114dd245412c8e9(c1f7c2fc950f696c563315e5f82d048ef, c10784d1cf252b4e2680185ea41e29848(), hashtable);
	}

	public override bool c6715dd5fbd319c6fb14b86148a6be9fe(Hashtable cc216f23dc2f7b783e32208e7241b9544, byte c8dc74ab19c3c6f5ead0a1fc2cc03de95, Hashtable c8c2e47dcaa928f76d9c8c2a8d9da77eb, MatchmakingMode ccd174d743f15030d5636ccf8809f60a5)
	{
		mRoomToGetInto = new Room(null, cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e);
		return base.c6715dd5fbd319c6fb14b86148a6be9fe(cc216f23dc2f7b783e32208e7241b9544, c8dc74ab19c3c6f5ead0a1fc2cc03de95, c8c2e47dcaa928f76d9c8c2a8d9da77eb, ccd174d743f15030d5636ccf8809f60a5);
	}

	public override bool c6f33dc92a2ac4dceb4bc67bd73340658(string c0f2c35402a8abd489481ccc7869a969c, string c6c1b51e64722c3393756046248a04833, string c4c413a97799e43eb07112adf9641c30e, string cb292fbb0d136ed940c5827add605879c)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = c6c1b51e64722c3393756046248a04833;
		dictionary[224] = c0f2c35402a8abd489481ccc7869a969c;
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		if (MasterConnection)
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
			if (FirstConnectMaster)
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
				if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_enableSndaLogin)
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
					dictionary[104] = c4c413a97799e43eb07112adf9641c30e;
					dictionary[109] = cb292fbb0d136ed940c5827add605879c;
					dictionary[105] = (byte)1;
				}
				else
				{
					dictionary[221] = c4c413a97799e43eb07112adf9641c30e;
					dictionary[105] = (byte)0;
				}
				goto IL_0102;
			}
		}
		dictionary[110] = OnlineService.s_accountId;
		dictionary[221] = mToken;
		dictionary[105] = (byte)2;
		goto IL_0102;
		IL_0102:
		dictionary[0] = OnlineService.s_characterId;
		return OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	public virtual bool c54053354c2f7c1c50dd8ddd80d1d2507()
	{
		if (State != global::PeerState.Joining)
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
					DebugReturn(DebugLevel.ERROR, string.Format("NetworkingPeer.OpCancelJoin() - ERROR: We are not currently joining a game (Current state = {0}).", State));
					return false;
				}
			}
		}
		return OpCustom(167, null, true, 0);
	}

	public virtual bool c46ffaa7512d43a16a25cb7dcff65a646()
	{
		if (State != global::PeerState.Joined)
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
					DebugReturn(DebugLevel.ERROR, "NetworkingPeer::leaveGame() - ERROR: no game is currently joined");
					return false;
				}
			}
		}
		return OpCustom(254, null, true, 0);
	}

	public override bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, byte cf3bbbff54c9fdae94b8cb8bfd3e5d14d, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83)
	{
		if (PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					return false;
				}
			}
		}
		return base.c3f632fdd31c8a3f2463924fbc1ced8b4(cdf46071c2725c9ab47a01b833f484416, cf3bbbff54c9fdae94b8cb8bfd3e5d14d, c98406db696ab6ddbd25ee108c3e91e6a, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83);
	}

	public override bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83, int[] c566ca11545011ee633a4806eae49c18d, EventCaching c67915f2da62d83244da1e904f44dcc85)
	{
		if (PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					return false;
				}
			}
		}
		return base.c3f632fdd31c8a3f2463924fbc1ced8b4(cdf46071c2725c9ab47a01b833f484416, c98406db696ab6ddbd25ee108c3e91e6a, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83, c566ca11545011ee633a4806eae49c18d, c67915f2da62d83244da1e904f44dcc85);
	}

	public override bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83, EventCaching c67915f2da62d83244da1e904f44dcc85, ReceiverGroup c07ee15f749989c77886061e981f42097)
	{
		if (PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					return false;
				}
			}
		}
		return base.c3f632fdd31c8a3f2463924fbc1ced8b4(cdf46071c2725c9ab47a01b833f484416, c98406db696ab6ddbd25ee108c3e91e6a, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83, c67915f2da62d83244da1e904f44dcc85, c07ee15f749989c77886061e981f42097);
	}

	public override bool cef1172883a0398e2b7732b3c47c7ce2b(byte[] c908877424278e67b8777768f58b51b37, byte[] c439c34a0599f27e1c487623d2bdf47e9)
	{
		if (PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					return false;
				}
			}
		}
		return base.cef1172883a0398e2b7732b3c47c7ce2b(c908877424278e67b8777768f58b51b37, c439c34a0599f27e1c487623d2bdf47e9);
	}

	public void DebugReturn(DebugLevel level, string message)
	{
		externalListener.DebugReturn(level, message);
	}

	public void OnOperationResponse(OperationResponse operationResponse)
	{
		if (PhotonNetwork.networkingPeer.State == global::PeerState.Disconnecting)
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
					if ((int)base.DebugOut >= 3)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								DebugReturn(DebugLevel.INFO, "OperationResponse ignored while disconnecting: " + operationResponse.OperationCode);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (operationResponse == null)
		{
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
		if (operationResponse.ReturnCode == 0)
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
			if ((int)base.DebugOut >= 3)
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
				DebugReturn(DebugLevel.INFO, operationResponse.ToString());
			}
		}
		else if ((int)base.DebugOut >= 2)
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
			if (operationResponse.ReturnCode == -3)
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
				DebugReturn(DebugLevel.WARNING, "Operation could not be executed yet. Wait for state JoinedLobby or ConnectedToMaster and their respective callbacks before calling OPs. Client must be authorized.");
			}
			DebugReturn(DebugLevel.WARNING, operationResponse.ToStringFull());
		}
		byte operationCode = operationResponse.OperationCode;
		switch (operationCode)
		{
		default:
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (operationCode != 198)
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
				if (operationCode != 127)
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
					if (operationCode != 167)
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
						if (mOperationResponseCallbacks.ContainsKey(operationResponse.OperationCode))
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
							mOperationResponseCallbacks[operationResponse.OperationCode](operationResponse.ReturnCode, operationResponse.Parameters);
						}
						else
						{
							if ((int)base.DebugOut < 1)
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
							DebugReturn(DebugLevel.ERROR, string.Format("operationResponse unhandled: {0}", operationResponse.ToString()));
						}
						break;
					}
					goto case 254;
				}
			}
			goto case 225;
		case 230:
			if (operationResponse.ReturnCode != 0)
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
				if ((int)base.DebugOut >= 1)
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
					DebugReturn(DebugLevel.ERROR, string.Format("Authentication failed: '{0}' Code: {1}", operationResponse.DebugMessage, operationResponse.ReturnCode));
				}
				if (operationResponse.ReturnCode == -2)
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
					DebugReturn(DebugLevel.ERROR, string.Format("If you host Photon yourself, make sure to start the 'Instance LoadBalancing'", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
				}
				if (operationResponse.ReturnCode == short.MaxValue)
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
					DebugReturn(DebugLevel.ERROR, string.Format("The appId this client sent is unknown on the server (Cloud). Check settings. If using the Cloud, check account.", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
				}
				Disconnect();
				State = global::PeerState.Disconnecting;
				if (operationResponse.ReturnCode == 32757)
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
					DebugReturn(DebugLevel.ERROR, string.Format("Currently, the limit of users is reached for this title. Try again later. Disconnecting", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonMaxCccuReached, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
					array[0] = DisconnectCause.MaxCcuReached;
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectionFail, array);
				}
				else
				{
					if (operationResponse.ReturnCode != 32756)
					{
						break;
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
					DebugReturn(DebugLevel.ERROR, string.Format("The used master server address is not available with the subscription currently used. Got to Photon Cloud Dashboard or change URL. Disconnecting", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
					array2[0] = DisconnectCause.InvalidRegion;
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectionFail, array2);
				}
				break;
			}
			if (MasterConnection)
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
				if (FirstConnectMaster)
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
					if (operationResponse.Parameters.ContainsKey(221))
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
						mToken = (string)operationResponse[221];
						PhotonNetwork.onlinePeer.mToken = mToken;
						OnlineService.s_accountId = (int)operationResponse[110];
					}
					if (operationResponse.Parameters.ContainsKey(220))
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
						OnlineService.s_serverVersionId = (string)operationResponse[220];
					}
					FirstConnectMaster = false;
				}
			}
			if (State != global::PeerState.Connected)
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
				if (State != global::PeerState.ConnectedComingFromGameserver)
				{
					if (State != global::PeerState.ConnectedToGameserver)
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
					State = global::PeerState.Joining;
					if (mLastJoinType != JoinType.JoinGame)
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
						if (mLastJoinType != JoinType.JoinRandomGame)
						{
							if (mLastJoinType != 0)
							{
								break;
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
							c801fb2e013d68d11ac76bea0784a40c3(mRoomToGetInto.cd99af21e22e356018b8f72d4a7e4872a, mRoomToGetInto.c150264a18c2cb408479d3f072cac8cc1, mRoomToGetInto.c03aa7b834eddec9c2cc57f448c34caff, (byte)mRoomToGetInto.c0b46a01b8c5164654f47e46e1eeb023d, mRoomToGetInto.c67310dbe99bce4fde88aae0e8960d168, mRoomToGetInto.ce640f5adbb33c511c28e1250d8608dd4, mRoomToGetInto.propertiesListedInLobby);
							break;
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
					c4abb80911dadab3f96ba18e7705bb9db(mRoomToGetInto.cd99af21e22e356018b8f72d4a7e4872a, mRoomToGetInto.ce640f5adbb33c511c28e1250d8608dd4);
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
			}
			if (operationResponse.Parameters.ContainsKey(223))
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
				mQueuePosition = (int)operationResponse[223];
				if (mQueuePosition > 0)
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
					if (State == global::PeerState.ConnectedComingFromGameserver)
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
						State = global::PeerState.QueuedComingFromGameserver;
					}
					else
					{
						State = global::PeerState.Queued;
					}
					break;
				}
			}
			if (PhotonNetwork.c2d7a0c5838aaa0006b15e2b02f9c76ab)
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
				ccc5b4825f60778430d18dd8b6dc97037();
				State = global::PeerState.Authenticated;
				if (operationResponse.Parameters.ContainsKey(108))
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
					object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
					array3[0] = (string)operationResponse.Parameters[108];
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToMaster, array3);
				}
				else
				{
					object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
					array4[0] = string.Empty;
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToMaster, array4);
				}
				break;
			}
			State = global::PeerState.ConnectedToMaster;
			if (operationResponse.Parameters.ContainsKey(108))
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
				object[] array5 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array5[0] = (string)operationResponse.Parameters[108];
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToMaster, array5);
			}
			else
			{
				object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array6[0] = string.Empty;
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToMaster, array6);
			}
			break;
		case 227:
			if (State != global::PeerState.Joining)
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
				if (operationResponse.ReturnCode != 0)
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
					if ((int)base.DebugOut >= 1)
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
						DebugReturn(DebugLevel.ERROR, string.Format("createGame failed, client stays on masterserver: {0}.", operationResponse.ToStringFull()));
					}
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonCreateRoomFailed, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
					break;
				}
				string text2 = (string)operationResponse[byte.MaxValue];
				if (!string.IsNullOrEmpty(text2))
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
					mRoomToGetInto.cd99af21e22e356018b8f72d4a7e4872a = text2;
				}
				mGameserver = (string)operationResponse[230];
				string text3 = mGameserver;
				char[] array7 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array7[0] = ':';
				string[] array8 = text3.Split(array7);
				if (array8[0].Equals("127.0.0.1"))
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
					string serverAddress = base.ServerAddress;
					char[] array9 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array9[0] = ':';
					string text4 = serverAddress.Split(array9)[0];
					mGameserver = text4 + ":" + array8[1];
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "New GameServer: " + mGameserver);
				c06d6442ad9d793db50b4128c63748199();
				mLastJoinType = JoinType.CreateGame;
			}
			else
			{
				c82a4193ab99ee3e1b68478aa9d56c8c5(operationResponse);
			}
			break;
		case 225:
		case 226:
			if (State != global::PeerState.Joining)
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
				if (operationResponse.ReturnCode != 0)
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
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
					if ((int)base.DebugOut < 2)
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
					DebugReturn(DebugLevel.WARNING, string.Format("JoinRandom failed (no open game). Client stays on masterserver: {0}.", operationResponse.ToStringFull()));
					break;
				}
				string c37dc4ee4a3a694110f0e0eb7b086137a = (string)operationResponse[byte.MaxValue];
				Hashtable cc79e01f9e3ac59fac4e1629a832b9edb = (Hashtable)operationResponse[248];
				Hashtable hashtable2 = (Hashtable)operationResponse[234];
				mFallbackSessions.Clear();
				if (hashtable2 != null)
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
					IDictionaryEnumerator enumerator2 = hashtable2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							string item = (string)enumerator2.Current;
							mFallbackSessions.Enqueue(item);
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_08ab;
							}
							continue;
							end_IL_08ab:
							break;
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator2 as IDisposable;
						if (disposable2 == null)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
									goto end_IL_08c4;
								}
								continue;
								end_IL_08c4:
								break;
							}
						}
						else
						{
							disposable2.Dispose();
						}
					}
				}
				mRoomToGetInto = new Room(c37dc4ee4a3a694110f0e0eb7b086137a, cc79e01f9e3ac59fac4e1629a832b9edb);
				mGameserver = (string)operationResponse[230];
				string text5 = mGameserver;
				char[] array10 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array10[0] = ':';
				string[] array11 = text5.Split(array10);
				if (array11[0].Equals("127.0.0.1"))
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
					string serverAddress2 = base.ServerAddress;
					char[] array12 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
					array12[0] = ':';
					string text6 = serverAddress2.Split(array12)[0];
					mGameserver = text6 + ":" + array11[1];
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "New GameServer: " + mGameserver);
				c06d6442ad9d793db50b4128c63748199();
				mLastJoinType = JoinType.JoinGame;
			}
			else
			{
				c82a4193ab99ee3e1b68478aa9d56c8c5(operationResponse);
			}
			break;
		case 229:
			State = global::PeerState.JoinedLobby;
			insideLobby = true;
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnJoinedLobby, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			break;
		case 228:
			State = global::PeerState.Authenticated;
			c3c5f89cb6a2b80518f211800a20ae336();
			break;
		case 254:
			c6b1f6ebed2d829baa34ef76b35faae89();
			break;
		case 251:
		{
			Hashtable c15a4fdc48895422fd36dee2c = (Hashtable)operationResponse[249];
			Hashtable c409129e403832642d20f53a4226efd = (Hashtable)operationResponse[248];
			cfcb836df8befca88a49988e5eb2e0eba(c409129e403832642d20f53a4226efd, c15a4fdc48895422fd36dee2c, 0);
			break;
		}
		case 221:
		{
			Hashtable hashtable = (Hashtable)operationResponse.Parameters[222];
			IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					string text = (string)dictionaryEntry.Key;
					Room room = new Room(text, (Hashtable)dictionaryEntry.Value);
					if (room.removedFromList)
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
						mGameList.Remove(text);
					}
					else
					{
						mGameList[text] = room;
					}
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0ac3;
					}
					continue;
					end_IL_0ac3:
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
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_0adc;
						}
						continue;
						end_IL_0adc:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			mGameListCopy = c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(mGameList.Count);
			mGameList.Values.CopyTo(mGameListCopy, 0);
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnReceivedRoomListUpdate, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			break;
		}
		case 197:
		{
			bool result = (bool)operationResponse.Parameters[0];
			OnAccessSingleton<IGameInvitationService, GameInvitationService, GameInvitationServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.OnIsFriendsGameJoinable(result);
			break;
		}
		case 252:
		case 253:
			break;
		}
		externalListener.OnOperationResponse(operationResponse);
	}

	public void OnStatusChanged(StatusCode statusCode)
	{
		if ((int)base.DebugOut >= 3)
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
			DebugReturn(DebugLevel.INFO, string.Format("OnStatusChanged: {0}", statusCode.ToString()));
		}
		DisconnectCause disconnectCause;
		object[] array2;
		switch (statusCode)
		{
		case StatusCode.Connect:
			if (State == global::PeerState.ConnectingToGameserver)
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
				if ((int)base.DebugOut >= 5)
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
					DebugReturn(DebugLevel.ALL, "Connected to gameserver.");
				}
				State = global::PeerState.ConnectedToGameserver;
				MasterConnection = false;
			}
			else
			{
				if ((int)base.DebugOut >= 5)
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
					DebugReturn(DebugLevel.ALL, "Connected to masterserver.");
				}
				if (State == global::PeerState.Connecting)
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
					c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToPhoton, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
					State = global::PeerState.Connected;
				}
				else
				{
					State = global::PeerState.ConnectedComingFromGameserver;
				}
				MasterConnection = true;
			}
			if (requestSecurity)
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
				EstablishEncryption();
			}
			else
			{
				if (c6f33dc92a2ac4dceb4bc67bd73340658(mAppId, mAppVersion, maccount, mpwd))
				{
					break;
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
				externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
			}
			break;
		case StatusCode.Disconnect:
			if (State == global::PeerState.DisconnectingFromMasterserver)
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
				if (!Connect(mGameserver, mAppId))
				{
					break;
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
				State = global::PeerState.ConnectingToGameserver;
			}
			else if (State == global::PeerState.DisconnectingFromGameserver)
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
				if (!Connect(masterServerAddress, mAppId))
				{
					break;
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
				State = global::PeerState.ConnectingToMasterserver;
			}
			else
			{
				cd6dc8abf43021dddac7da19de2d488f0();
				State = global::PeerState.PeerCreated;
				Reset();
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnDisconnectedFromPhoton, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			}
			break;
		case StatusCode.SecurityExceptionOnConnect:
		case StatusCode.ExceptionOnConnect:
		{
			State = global::PeerState.PeerCreated;
			disconnectCause = (DisconnectCause)statusCode;
			object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
			array6[0] = disconnectCause;
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnFailedToConnectToPhoton, array6);
			break;
		}
		case StatusCode.Exception:
		{
			if (State == global::PeerState.Connecting)
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
				DebugReturn(DebugLevel.WARNING, "Exception while connecting to: " + base.ServerAddress + ". Check if the server is available.");
				if (base.ServerAddress != null)
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
					if (!base.ServerAddress.StartsWith("127.0.0.1"))
					{
						goto IL_0336;
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
				DebugReturn(DebugLevel.WARNING, "The server address is 127.0.0.1 (localhost): Make sure the server is running on this machine. Android and iOS emulators have their own localhost.");
				if (base.ServerAddress == mGameserver)
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
					DebugReturn(DebugLevel.WARNING, "This might be a misconfiguration in the game server config. You need to edit it to a (public) address.");
				}
				goto IL_0336;
			}
			State = global::PeerState.PeerCreated;
			disconnectCause = (DisconnectCause)statusCode;
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = disconnectCause;
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectionFail, array);
			goto IL_037a;
		}
		case StatusCode.InternalReceiveException:
		case StatusCode.TimeoutDisconnect:
		case StatusCode.DisconnectByServer:
		case StatusCode.DisconnectByServerUserLimit:
		case StatusCode.DisconnectByServerLogic:
			if (State == global::PeerState.Connecting)
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
				object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array3[0] = statusCode;
				array3[1] = " while connecting to: ";
				array3[2] = base.ServerAddress;
				array3[3] = ". Check if the server is available.";
				DebugReturn(DebugLevel.WARNING, string.Concat(array3));
				State = global::PeerState.PeerCreated;
				disconnectCause = (DisconnectCause)statusCode;
				object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array4[0] = disconnectCause;
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnFailedToConnectToPhoton, array4);
			}
			else
			{
				State = global::PeerState.PeerCreated;
				disconnectCause = (DisconnectCause)statusCode;
				object[] array5 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array5[0] = disconnectCause;
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectionFail, array5);
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Disconnect because of: " + Enum.GetName(Type.GetTypeFromHandle(c9d50f7d6aa9212e70cbe26d7f7b15877.cc1720d05c75832f704b87474932341c3()), statusCode));
			Disconnect();
			break;
		case StatusCode.EncryptionEstablished:
			if (c6f33dc92a2ac4dceb4bc67bd73340658(mAppId, mAppVersion, maccount, mpwd))
			{
				break;
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
			externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
			break;
		case StatusCode.EncryptionFailedToEstablish:
			externalListener.DebugReturn(DebugLevel.ERROR, string.Concat("Encryption wasn't established: ", statusCode, ". Going to authenticate anyways."));
			if (c6f33dc92a2ac4dceb4bc67bd73340658(mAppId, mAppVersion, maccount, mpwd))
			{
				break;
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
			externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
			break;
		default:
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "CommandBufferSize is " + base.CommandBufferSize);
			DebugReturn(DebugLevel.ERROR, "Received unknown status code: " + statusCode);
			break;
		case StatusCode.QueueOutgoingReliableWarning:
		case StatusCode.QueueOutgoingUnreliableWarning:
		case StatusCode.SendError:
		case StatusCode.QueueOutgoingAcksWarning:
		case StatusCode.QueueSentWarning:
			break;
			IL_037a:
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Disconnect because of: " + Enum.GetName(Type.GetTypeFromHandle(c9d50f7d6aa9212e70cbe26d7f7b15877.cc1720d05c75832f704b87474932341c3()), statusCode));
			Disconnect();
			break;
			IL_0336:
			State = global::PeerState.PeerCreated;
			disconnectCause = (DisconnectCause)statusCode;
			array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = disconnectCause;
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnFailedToConnectToPhoton, array2);
			goto IL_037a;
		}
		externalListener.OnStatusChanged(statusCode);
	}

	public void OnEvent(EventData photonEvent)
	{
		if ((int)base.DebugOut >= 3)
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
			DebugReturn(DebugLevel.INFO, string.Format("OnEvent: {0}", photonEvent.ToString()));
		}
		int num = -1;
		PhotonPlayer photonPlayer = c753457029073de95298730c041a2b844.c7088de59e49f7108f520cf7e0bae167e;
		if (photonEvent.Parameters.ContainsKey(254))
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
			num = (int)photonEvent[254];
			if (mActors.ContainsKey(num))
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
				photonPlayer = mActors[num];
			}
		}
		switch (photonEvent.Code)
		{
		case 230:
		{
			mGameList = new Dictionary<string, RoomInfo>();
			Hashtable hashtable5 = (Hashtable)photonEvent[222];
			IDictionaryEnumerator enumerator2 = hashtable5.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DictionaryEntry dictionaryEntry2 = (DictionaryEntry)enumerator2.Current;
					string text2 = (string)dictionaryEntry2.Key;
					mGameList[text2] = new RoomInfo(text2, (Hashtable)dictionaryEntry2.Value);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_0185;
					}
					continue;
					end_IL_0185:
					break;
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator2 as IDisposable;
				if (disposable2 == null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_019e;
						}
						continue;
						end_IL_019e:
						break;
					}
				}
				else
				{
					disposable2.Dispose();
				}
			}
			mGameListCopy = c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(mGameList.Count);
			mGameList.Values.CopyTo(mGameListCopy, 0);
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnReceivedRoomListUpdate, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			break;
		}
		case 229:
		{
			Hashtable hashtable4 = (Hashtable)photonEvent[222];
			IDictionaryEnumerator enumerator = hashtable4.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
					string text = (string)dictionaryEntry.Key;
					Room room = new Room(text, (Hashtable)dictionaryEntry.Value);
					if (room.removedFromList)
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
						mGameList.Remove(text);
					}
					else
					{
						mGameList[text] = room;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0291;
					}
					continue;
					end_IL_0291:
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
						switch (4)
						{
						case 0:
							break;
						default:
							goto end_IL_02aa;
						}
						continue;
						end_IL_02aa:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			mGameListCopy = c048cf01642a92d2fde58530d372626a4.c0a0cdf4a196914163f7334d9b0781a04(mGameList.Count);
			mGameList.Values.CopyTo(mGameListCopy, 0);
			c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnReceivedRoomListUpdate, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			break;
		}
		case 228:
			if (photonEvent.Parameters.ContainsKey(223))
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
				mQueuePosition = (int)photonEvent[223];
			}
			else
			{
				DebugReturn(DebugLevel.ERROR, "Event QueueState must contain position!");
			}
			if (mQueuePosition != 0)
			{
				break;
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
			if (PhotonNetwork.c2d7a0c5838aaa0006b15e2b02f9c76ab)
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
				ccc5b4825f60778430d18dd8b6dc97037();
				State = global::PeerState.Authenticated;
			}
			else
			{
				State = global::PeerState.ConnectedToMaster;
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnConnectedToMaster, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			}
			break;
		case 226:
			mPlayersInRoomsCount = (int)photonEvent[229];
			mPlayersOnMasterCount = (int)photonEvent[227];
			mGameCount = (int)photonEvent[228];
			break;
		case byte.MaxValue:
		{
			Hashtable cc79e01f9e3ac59fac4e1629a832b9edb = (Hashtable)photonEvent[249];
			if (photonPlayer == null)
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
				bool c9f86d965ca220e54c03c3844c19b202f = mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3 == num;
				ca7051da8e9918f1f9ead7bef8d5c95de(num, new PhotonPlayer(c9f86d965ca220e54c03c3844c19b202f, num, cc79e01f9e3ac59fac4e1629a832b9edb));
				c96f15e0f592cb1920546b183cf59f100();
			}
			if (mActors[num] == mLocalActor)
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
				int[] array2 = (int[])photonEvent[252];
				int[] array3 = array2;
				foreach (int num9 in array3)
				{
					if (mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3 == num9)
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
					if (mActors.ContainsKey(num9))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "creating player");
					ca7051da8e9918f1f9ead7bef8d5c95de(num9, new PhotonPlayer(false, num9, string.Empty));
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
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnJoinedRoom, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			}
			else
			{
				object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
				array4[0] = mActors[num];
				c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage.OnPhotonPlayerConnected, array4);
			}
			break;
		}
		case 254:
			cbdae083d4bb2e479cfb718503a916178(num);
			break;
		case 253:
		{
			int num2 = (int)photonEvent[253];
			Hashtable c409129e403832642d20f53a4226efd = cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e;
			Hashtable c15a4fdc48895422fd36dee2c = cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e;
			if (num2 == 0)
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
				c409129e403832642d20f53a4226efd = (Hashtable)photonEvent[251];
			}
			else
			{
				c15a4fdc48895422fd36dee2c = (Hashtable)photonEvent[251];
			}
			cfcb836df8befca88a49988e5eb2e0eba(c409129e403832642d20f53a4226efd, c15a4fdc48895422fd36dee2c, num2);
			break;
		}
		case 200:
			c24ba2f644674bb9b246cce0b35f058cc(photonEvent[245] as Hashtable, photonPlayer);
			break;
		case 201:
		case 206:
		{
			Hashtable hashtable = (Hashtable)photonEvent[245];
			int networkTime = (int)hashtable[(byte)0];
			short correctPrefix = -1;
			short num3 = 1;
			for (short num4 = num3; num4 < hashtable.Count; num4++)
			{
				Hashtable hashtable2 = hashtable[num4] as Hashtable;
				int num5 = (int)hashtable2[(byte)0];
				PhotonView photonView = cf3f639d9f53429a8af80536a64470f83(num5);
				if (photonView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					photonView.OnSerializeRead(hashtable2, photonPlayer, networkTime, correctPrefix);
				}
				else
				{
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "can't find PhotonView " + num5 + " on event SendSerialize");
				}
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
			break;
		}
		case 202:
			ccc94c604b2052f09e290f808f38e7bd8((Hashtable)photonEvent[245], photonPlayer, null, false);
			break;
		case 203:
			if (photonPlayer != null)
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
				if (photonPlayer.ca3052869987fcf5688487de12414faab)
				{
					PhotonNetwork.c518ef3edadd378ef9ae215e96fa4e4fa();
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
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat("Error: Someone else(", photonPlayer, ") then the masterserver requests a disconnect!"));
			break;
		case 204:
		{
			Hashtable hashtable6 = (Hashtable)photonEvent[245];
			int num10 = (int)hashtable6[(byte)0];
			PhotonView photonView2 = cf3f639d9f53429a8af80536a64470f83(num10);
			if (photonView2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "INFO: This view has already been destroyed. view ID=" + num10);
			}
			else if (photonPlayer == null)
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
				object[] array5 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
				array5[0] = "ERROR: Illegal destroy request on view ID=";
				array5[1] = num10;
				array5[2] = " from player/actorNr: ";
				array5[3] = num;
				array5[4] = " view=";
				array5[5] = photonView2;
				array5[6] = "  orgPlayer=";
				array5[7] = photonPlayer;
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array5));
			}
			else
			{
				c5204a3cd31d565129c4cb4c2f22a3c08(photonView2, true);
			}
			break;
		}
		case 207:
		{
			Hashtable hashtable3 = (Hashtable)photonEvent[245];
			float num6 = (float)hashtable3[0];
			int num7 = (byte)hashtable3[1];
			if (num7 == mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3)
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
				if (!hashtable3.ContainsKey(2))
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
				float num8 = Time.realtimeSinceStartup - num6;
				if (!peerRoundTripTimes.ContainsKey((byte)hashtable3[2]))
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
					peerRoundTripTimes[(byte)hashtable3[2]] = num8;
				}
				else
				{
					float from = peerRoundTripTimes[(byte)hashtable3[2]];
					peerRoundTripTimes[(byte)hashtable3[2]] = Mathf.Lerp(from, num8, 0.1f);
				}
			}
			else
			{
				hashtable3[2] = (byte)mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3;
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = num7;
				c3f632fdd31c8a3f2463924fbc1ced8b4(207, hashtable3, true, 0, array);
			}
			break;
		}
		default:
			if (mEventCallbacks.ContainsKey(photonEvent.Code))
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
				mEventCallbacks[photonEvent.Code](photonEvent.Parameters);
			}
			else
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error. Unhandled event: " + photonEvent);
			}
			break;
		}
		externalListener.OnEvent(photonEvent);
	}

	public static void c5e9ce18181f1685b5f6c71a7e11aba31(PhotonNetworkingMessage c26f03899c35d1ac1f355f402d99cd956, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		MonoBehaviour[] array = (MonoBehaviour[])UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c5540110e9ec814342f8178e1b6119a0b.cc1720d05c75832f704b87474932341c3()));
		foreach (MonoBehaviour monoBehaviour in array)
		{
			if (hashSet.Contains(monoBehaviour.gameObject))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			hashSet.Add(monoBehaviour.gameObject);
			if (c90ecb087828ed9ceb9c00eafb6d52f4c != null)
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
				if (c90ecb087828ed9ceb9c00eafb6d52f4c.Length == 1)
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
					monoBehaviour.SendMessage(c26f03899c35d1ac1f355f402d99cd956.ToString(), c90ecb087828ed9ceb9c00eafb6d52f4c[0], SendMessageOptions.DontRequireReceiver);
					continue;
				}
			}
			monoBehaviour.SendMessage(c26f03899c35d1ac1f355f402d99cd956.ToString(), c90ecb087828ed9ceb9c00eafb6d52f4c, SendMessageOptions.DontRequireReceiver);
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

	public void c24ba2f644674bb9b246cce0b35f058cc(Hashtable c8fd38fcc5630365dbf56444d5399c571, PhotonPlayer c979ec2891bdf45f616bb8a2b2b7051d5)
	{
		if (c8fd38fcc5630365dbf56444d5399c571 != null)
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
			if (c8fd38fcc5630365dbf56444d5399c571.ContainsKey((byte)0))
			{
				int num = (int)c8fd38fcc5630365dbf56444d5399c571[(byte)0];
				int num2 = 0;
				if (c8fd38fcc5630365dbf56444d5399c571.ContainsKey((byte)1))
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
					num2 = (short)c8fd38fcc5630365dbf56444d5399c571[(byte)1];
				}
				string text = (string)c8fd38fcc5630365dbf56444d5399c571[(byte)3];
				object[] array = (object[])c8fd38fcc5630365dbf56444d5399c571[(byte)4];
				if (array == null)
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
					array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0);
				}
				PhotonView photonView = cf3f639d9f53429a8af80536a64470f83(num);
				if (photonView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
						{
							object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
							array2[0] = "Received RPC \"";
							array2[1] = text;
							array2[2] = "\" for viewID ";
							array2[3] = num;
							array2[4] = " but this PhotonView does not exist!";
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array2));
							return;
						}
						}
					}
				}
				if (photonView.c26bc9278762c84e1e76177f085674c7e != num2)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
						{
							object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(9);
							array3[0] = "Received RPC \"";
							array3[1] = text;
							array3[2] = "\" on viewID ";
							array3[3] = num;
							array3[4] = " with a prefix of ";
							array3[5] = num2;
							array3[6] = ", our prefix is ";
							array3[7] = photonView.c26bc9278762c84e1e76177f085674c7e;
							array3[8] = ". The RPC has been ignored.";
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array3));
							return;
						}
						}
					}
				}
				if (photonView.preInstantiate)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							photonView.bufferedRPC.Add(new Pair<Hashtable, PhotonPlayer>(c8fd38fcc5630365dbf56444d5399c571, c979ec2891bdf45f616bb8a2b2b7051d5));
							return;
						}
					}
				}
				if (text == string.Empty)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							DebugReturn(DebugLevel.ERROR, "Malformed RPC; this should never occur.");
							return;
						}
					}
				}
				if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
					photonView.c527d35a2bd1b8768af0cd94afeb762c5(text, Utils.c48ad35a6532e0c5642de63db021aab5a(c8fd38fcc5630365dbf56444d5399c571));
				}
				if ((int)base.DebugOut >= 5)
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
					DebugReturn(DebugLevel.ALL, "Received RPC; " + text);
				}
				if (photonView.group != 0)
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
					if (!allowedReceivingGroups.Contains(photonView.group))
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
				}
				Type[] array4 = Type.EmptyTypes;
				if (array.Length > 0)
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
					array4 = cac2af44509abdc0f40c5fbd0631742be.c0a0cdf4a196914163f7334d9b0781a04(array.Length);
					int num3 = 0;
					foreach (object obj in array)
					{
						if (obj == null)
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
							array4[num3] = null;
						}
						else
						{
							array4[num3] = obj.GetType();
						}
						num3++;
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
				int num4 = 0;
				int num5 = 0;
				MonoBehaviour[] components = photonView.GetComponents<MonoBehaviour>();
				foreach (MonoBehaviour monoBehaviour in components)
				{
					if (monoBehaviour == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "ERROR You have missing MonoBehaviours on your gameobjects!");
						continue;
					}
					Type type = monoBehaviour.GetType();
					List<MethodInfo> list = cce47f0cd4e7e30c8446a51a49b89eb24.c7088de59e49f7108f520cf7e0bae167e;
					if (monoRPCMethodsCache.ContainsKey(type))
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
						list = monoRPCMethodsCache[type];
					}
					if (list == null)
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
						List<MethodInfo> list2 = new List<MethodInfo>();
						MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						for (int k = 0; k < methods.Length; k++)
						{
							if (!methods[k].IsDefined(Type.GetTypeFromHandle(cf0376bd51987598cc5dc652ee4f3da53.cc1720d05c75832f704b87474932341c3()), false))
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
							list2.Add(methods[k]);
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
						monoRPCMethodsCache[type] = list2;
						list = list2;
					}
					if (list == null)
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
						continue;
					}
					for (int l = 0; l < list.Count; l++)
					{
						MethodInfo methodInfo = list[l];
						if (!(methodInfo.Name == text))
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
						num5++;
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (parameters.Length == array4.Length)
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
							if (!cf7431136fa9d1150165726869571b670(parameters, array4))
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
							num4++;
							object obj2 = methodInfo.Invoke(monoBehaviour, array);
							if (methodInfo.ReturnType != Type.GetTypeFromHandle(cf09b6be9ab5afc78cbfc07d687efb188.cc1720d05c75832f704b87474932341c3()))
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
							monoBehaviour.StartCoroutine((IEnumerator)obj2);
						}
						else if (parameters.Length - 1 == array4.Length)
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
							if (!cf7431136fa9d1150165726869571b670(parameters, array4))
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
							if (parameters[parameters.Length - 1].ParameterType != Type.GetTypeFromHandle(c64d22c563daac7b0ebe4ab441aaab885.cc1720d05c75832f704b87474932341c3()))
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
							num4++;
							int c24d168bafd94cfd3e438faef12da2b5c = (int)c8fd38fcc5630365dbf56444d5399c571[(byte)2];
							object[] array5 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(array.Length + 1);
							array.CopyTo(array5, 0);
							array5[array5.Length - 1] = new PhotonMessageInfo(c979ec2891bdf45f616bb8a2b2b7051d5, c24d168bafd94cfd3e438faef12da2b5c, photonView);
							object obj3 = methodInfo.Invoke(monoBehaviour, array5);
							if (methodInfo.ReturnType != Type.GetTypeFromHandle(cf09b6be9ab5afc78cbfc07d687efb188.cc1720d05c75832f704b87474932341c3()))
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
							monoBehaviour.StartCoroutine((IEnumerator)obj3);
						}
						else
						{
							if (parameters.Length != 1)
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
							if (!parameters[0].ParameterType.IsArray)
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
							num4++;
							object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
							array6[0] = array;
							object obj4 = methodInfo.Invoke(monoBehaviour, array6);
							if (methodInfo.ReturnType != Type.GetTypeFromHandle(cf09b6be9ab5afc78cbfc07d687efb188.cc1720d05c75832f704b87474932341c3()))
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
							monoBehaviour.StartCoroutine((IEnumerator)obj4);
						}
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
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					if (num4 == 1)
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
						string text2 = string.Empty;
						foreach (Type type2 in array4)
						{
							if (text2 != string.Empty)
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
								text2 += ", ";
							}
							if (type2 == null)
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
								text2 += "null";
							}
							else
							{
								text2 += type2.Name;
							}
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							if (num4 == 0)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										break;
									default:
									{
										if (num5 == 0)
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
												{
													object[] array7 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
													array7[0] = "PhotonView with ID ";
													array7[1] = num;
													array7[2] = " has no method \"";
													array7[3] = text;
													array7[4] = "\" marked with the [RPC](C#) or @RPC(JS) property!";
													DebugReturn(DebugLevel.ERROR, string.Concat(array7));
													return;
												}
												}
											}
										}
										object[] array8 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
										array8[0] = "PhotonView with ID ";
										array8[1] = num;
										array8[2] = " has no method \"";
										array8[3] = text;
										array8[4] = "\" that takes ";
										array8[5] = array4.Length;
										array8[6] = " argument(s): ";
										array8[7] = text2;
										DebugReturn(DebugLevel.ERROR, string.Concat(array8));
										return;
									}
									}
								}
							}
							object[] array9 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(11);
							array9[0] = "PhotonView with ID ";
							array9[1] = num;
							array9[2] = " has ";
							array9[3] = num4;
							array9[4] = " methods \"";
							array9[5] = text;
							array9[6] = "\" that takes ";
							array9[7] = array4.Length;
							array9[8] = " argument(s): ";
							array9[9] = text2;
							array9[10] = ". Should be just one?";
							DebugReturn(DebugLevel.ERROR, string.Concat(array9));
							return;
						}
					}
				}
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
		DebugReturn(DebugLevel.ERROR, "Malformed RPC; this should never occur.");
	}

	private bool cf7431136fa9d1150165726869571b670(ParameterInfo[] c90ecb087828ed9ceb9c00eafb6d52f4c, Type[] c6cbad6b6a42014c8e0ff04ffe3bbd150)
	{
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.Length < c6cbad6b6a42014c8e0ff04ffe3bbd150.Length)
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
					return false;
				}
			}
		}
		int num = 0;
		foreach (Type type in c6cbad6b6a42014c8e0ff04ffe3bbd150)
		{
			if (type != null)
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
				if (c90ecb087828ed9ceb9c00eafb6d52f4c[num].ParameterType != type)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
			}
			num++;
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

	internal Hashtable c953a4225d60af4de6285142d21ca8c0f(string c9c536cdaad24471d7a448d2853440144, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, int c6279c42b47398c5e401c1cff54ce61c2, int[] c3f47233cc9d2d81f7c2763360eb5fde0, object[] c591d56a94543e3559945c497f37126c4, bool ce0b39cbbddfe1243a0f44f562dbb31bd)
	{
		int num = c3f47233cc9d2d81f7c2763360eb5fde0[0];
		Hashtable hashtable = new Hashtable();
		int num2 = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_itstantiateObjectDic.FindIndex((string c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.Equals(c9c536cdaad24471d7a448d2853440144));
		if (num2 >= 0)
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
			hashtable[(byte)0] = num2;
		}
		else
		{
			hashtable[(byte)0] = c9c536cdaad24471d7a448d2853440144;
		}
		if (cef9712200bbe2c3873eec3ca2e18a595 != Vector3.zero)
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
			hashtable[(byte)1] = cef9712200bbe2c3873eec3ca2e18a595;
		}
		if (c4ea6de03c1203f2470a6677821ad93f0 != Quaternion.identity)
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
			hashtable[(byte)2] = c4ea6de03c1203f2470a6677821ad93f0;
		}
		if (c6279c42b47398c5e401c1cff54ce61c2 != 0)
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
			hashtable[(byte)3] = c6279c42b47398c5e401c1cff54ce61c2;
		}
		if (c3f47233cc9d2d81f7c2763360eb5fde0.Length > 1)
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
			hashtable[(byte)4] = c3f47233cc9d2d81f7c2763360eb5fde0;
		}
		if (c591d56a94543e3559945c497f37126c4 != null)
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
			hashtable[(byte)5] = c591d56a94543e3559945c497f37126c4;
		}
		if (currentLevelPrefix > 0)
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
			hashtable[(byte)8] = currentLevelPrefix;
		}
		hashtable[(byte)6] = base.ServerTimeInMilliSeconds;
		hashtable[(byte)7] = num;
		int num3;
		if (ce0b39cbbddfe1243a0f44f562dbb31bd)
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
			num3 = 5;
		}
		else
		{
			num3 = 4;
		}
		EventCaching c67915f2da62d83244da1e904f44dcc = (EventCaching)num3;
		grossInstantiateData += Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable);
		c3f632fdd31c8a3f2463924fbc1ced8b4(202, hashtable, true, 0, c67915f2da62d83244da1e904f44dcc, ReceiverGroup.Others);
		return hashtable;
	}

	internal GameObject ccc94c604b2052f09e290f808f38e7bd8(Hashtable c98406db696ab6ddbd25ee108c3e91e6a, PhotonPlayer c1ffbed4a781051881c8fac731543b807, GameObject c04883b4d8c8b49e15db00331e17c6937, bool c4f6ad49c6f3556f9f65da7793278cf60)
	{
		grossInstantiateDataRCV += Utils.c48ad35a6532e0c5642de63db021aab5a(c98406db696ab6ddbd25ee108c3e91e6a);
		string empty = string.Empty;
		if (c98406db696ab6ddbd25ee108c3e91e6a[(byte)0] is string)
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
			empty = (string)c98406db696ab6ddbd25ee108c3e91e6a[(byte)0];
		}
		else
		{
			int index = (int)c98406db696ab6ddbd25ee108c3e91e6a[(byte)0];
			empty = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_itstantiateObjectDic[index];
		}
		int num = (int)c98406db696ab6ddbd25ee108c3e91e6a[(byte)6];
		int num2 = (int)c98406db696ab6ddbd25ee108c3e91e6a[(byte)7];
		Vector3 vector;
		if (c98406db696ab6ddbd25ee108c3e91e6a.ContainsKey((byte)1))
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
			vector = (Vector3)c98406db696ab6ddbd25ee108c3e91e6a[(byte)1];
		}
		else
		{
			vector = Vector3.zero;
		}
		Quaternion quaternion = Quaternion.identity;
		if (c98406db696ab6ddbd25ee108c3e91e6a.ContainsKey((byte)2))
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
			quaternion = (Quaternion)c98406db696ab6ddbd25ee108c3e91e6a[(byte)2];
		}
		int group = 0;
		if (c98406db696ab6ddbd25ee108c3e91e6a.ContainsKey((byte)3))
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
			group = (int)c98406db696ab6ddbd25ee108c3e91e6a[(byte)3];
		}
		short num3 = 0;
		if (c98406db696ab6ddbd25ee108c3e91e6a.ContainsKey((byte)8))
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
			num3 = (short)c98406db696ab6ddbd25ee108c3e91e6a[(byte)8];
		}
		int[] array;
		if (c98406db696ab6ddbd25ee108c3e91e6a.ContainsKey((byte)4))
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
			array = (int[])c98406db696ab6ddbd25ee108c3e91e6a[(byte)4];
		}
		else
		{
			int[] array2 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = num2;
			array = array2;
		}
		object[] array3;
		if (c98406db696ab6ddbd25ee108c3e91e6a.ContainsKey((byte)5))
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
			array3 = (object[])c98406db696ab6ddbd25ee108c3e91e6a[(byte)5];
		}
		else
		{
			array3 = c5045159a57582d4577b6fa1bce364dca.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (c4f6ad49c6f3556f9f65da7793278cf60)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (c04883b4d8c8b49e15db00331e17c6937 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c04883b4d8c8b49e15db00331e17c6937 = ResourcesLoader.c4e95594aa6d23f20094cfec50ccb1899(empty);
						if (c04883b4d8c8b49e15db00331e17c6937 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + empty + "]. Please verify you have this gameobject in a Resources folder.");
									return null;
								}
							}
						}
					}
					PhotonView[] array4 = c04883b4d8c8b49e15db00331e17c6937.cb0af1eac32d2112bb0cc859a7ed20362();
					if (array4.Length != array.Length)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								throw new Exception("Error in Instantiation! The resource's PhotonView count is not the same as in incoming data.");
							}
						}
					}
					for (int i = 0; i < array.Length; i++)
					{
						array4[i].ce57f12a4f7e693a5fe0c4049dc56fa7c = array[i];
						array4[i].c26bc9278762c84e1e76177f085674c7e = num3;
						array4[i].instantiationId = num2;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
						{
							c2ca898d0fe48fbc0edb2ac1c230f5a4d(num2, array3);
							GameObject gameObject = ResourcesLoader.c2d63b1bf24325b01b8a5a703c64d91f2(empty, vector, quaternion);
							for (int j = 0; j < array.Length; j++)
							{
								array4[j].ce57f12a4f7e693a5fe0c4049dc56fa7c = 0;
								array4[j].c26bc9278762c84e1e76177f085674c7e = -1;
								array4[j].prefixBackup = -1;
								array4[j].instantiationId = -1;
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
								{
									c4db74f047af6093dfe1aae77c34821d6(num2);
									if (instantiatedObjects.ContainsKey(num2))
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
										GameObject gameObject2 = instantiatedObjects[num2];
										string text = string.Empty;
										if (gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
											PhotonView[] array5 = gameObject2.cb0af1eac32d2112bb0cc859a7ed20362();
											PhotonView[] array6 = array5;
											foreach (PhotonView photonView in array6)
											{
												if (photonView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
												}
												else
												{
													text = text + photonView.ToString() + ", ";
												}
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
										object[] array7 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
										array7[0] = gameObject;
										array7[1] = num2;
										array7[2] = instantiatedObjects.Count;
										array7[3] = gameObject2;
										array7[4] = text;
										array7[5] = PhotonNetwork.lastUsedViewSubId;
										array7[6] = PhotonNetwork.lastUsedViewSubIdStatic;
										array7[7] = photonViewList.Count;
										DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Format("Adding GO \"{0}\" (instantiationID: {1}) to instantiatedObjects failed. instantiatedObjects.Count: {2}. Object taking the same place: {3}. Views on it: {4}. PhotonNetwork.lastUsedViewSubId: {5} PhotonNetwork.lastUsedViewSubIdStatic: {6} this.photonViewList.Count {7}.)", array7));
									}
									instantiatedObjects.Add(num2, gameObject);
									object[] array8 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
									array8[0] = new PhotonMessageInfo(c1ffbed4a781051881c8fac731543b807, num, c56ecf3283d235e852cde628d84d7b371.c7088de59e49f7108f520cf7e0bae167e);
									MonoBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>();
									foreach (MonoBehaviour monoBehaviour in componentsInChildren)
									{
										MethodInfo methodInfo = c37886ec92280a4613e176e93a6cbbb2b(monoBehaviour, PhotonNetworkingMessage.OnPhotonInstantiate);
										if (methodInfo != null)
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
											object obj = methodInfo.Invoke(monoBehaviour, array8);
											if (methodInfo.ReturnType == Type.GetTypeFromHandle(cf09b6be9ab5afc78cbfc07d687efb188.cc1720d05c75832f704b87474932341c3()))
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
												monoBehaviour.StartCoroutine((IEnumerator)obj);
											}
										}
									}
									while (true)
									{
										switch (2)
										{
										case 0:
											break;
										default:
											return gameObject;
										}
									}
								}
								}
							}
						}
						}
					}
				}
				}
			}
		}
		GameObject gameObject3 = new GameObject("InstantiateHelper_" + num2);
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject3.transform.parent = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform;
		}
		InstantiatingPhotonViews instantiatingPhotonViews = new InstantiatingPhotonViews();
		instantiatingPhotonViews.instantiateHelper = gameObject3;
		for (int m = 0; m < array.Length; m++)
		{
			gameObject3.AddComponent<PhotonView>();
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			PhotonView[] components = gameObject3.GetComponents<PhotonView>();
			string text2 = string.Empty;
			for (int n = 0; n < array.Length; n++)
			{
				text2 += array[n];
				components[n].ce57f12a4f7e693a5fe0c4049dc56fa7c = array[n];
				components[n].group = group;
				components[n].c332524fa6b5f6c2dfdb5f39c56de7f45 = array3;
				components[n].preInstantiate = true;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				instantiatingPhotonViews.instantiationId = num2;
				instantiatingPhotonViews.photonPlayer = c1ffbed4a781051881c8fac731543b807;
				instantiatingPhotonViews.position = vector;
				instantiatingPhotonViews.rotation = quaternion;
				instantiatingPhotonViews.resourceGameObject = c04883b4d8c8b49e15db00331e17c6937;
				instantiatingPhotonViews.prefabName = empty;
				instantiatingPhotonViews.serverTime = num;
				instantiatingPhotonViews.group = group;
				instantiatingPhotonViews.objLevelPrefix = num3;
				instantiatingPhotonViews.incomingInstantiationData = array3;
				this.instantiatingPhotonViews.Add(instantiatingPhotonViews);
				return null;
			}
		}
	}

	private InstantiateState c7fa32383a5ce873d881c010490922c96(InstantiatingPhotonViews ce02e13b33631f517a7ad32b37a06af5d)
	{
		if (ce02e13b33631f517a7ad32b37a06af5d.group != 0)
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
			if (!allowedReceivingGroups.Contains(ce02e13b33631f517a7ad32b37a06af5d.group))
			{
				goto IL_004c;
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
		if (m_instantiatePending)
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
			goto IL_004c;
		}
		if (ce02e13b33631f517a7ad32b37a06af5d.resourceGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			ce02e13b33631f517a7ad32b37a06af5d.resourceGameObject = ResourcesLoader.c4e95594aa6d23f20094cfec50ccb1899(ce02e13b33631f517a7ad32b37a06af5d.prefabName);
			if (ce02e13b33631f517a7ad32b37a06af5d.resourceGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + ce02e13b33631f517a7ad32b37a06af5d.prefabName + "]. Please verify you have this gameobject in a Resources folder.");
						return InstantiateState.Fail;
					}
				}
			}
		}
		PhotonView[] components = ce02e13b33631f517a7ad32b37a06af5d.instantiateHelper.GetComponents<PhotonView>();
		PhotonView[] array = components;
		foreach (PhotonView c7f473b48a30daeb33aad838f3ba0b15c in array)
		{
			c97ffe8eafefa0eb594f4fc597de59226(c7f473b48a30daeb33aad838f3ba0b15c);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			PhotonView[] array2 = ce02e13b33631f517a7ad32b37a06af5d.resourceGameObject.cb0af1eac32d2112bb0cc859a7ed20362();
			if (array2.Length != components.Length)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						throw new Exception("Error in Instantiation! The resource's PhotonView count is not the same as in incoming data.");
					}
				}
			}
			for (int j = 0; j < components.Length; j++)
			{
				array2[j].ce57f12a4f7e693a5fe0c4049dc56fa7c = components[j].ce57f12a4f7e693a5fe0c4049dc56fa7c;
				array2[j].c26bc9278762c84e1e76177f085674c7e = ce02e13b33631f517a7ad32b37a06af5d.objLevelPrefix;
				array2[j].instantiationId = ce02e13b33631f517a7ad32b37a06af5d.instantiationId;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				c2ca898d0fe48fbc0edb2ac1c230f5a4d(ce02e13b33631f517a7ad32b37a06af5d.instantiationId, ce02e13b33631f517a7ad32b37a06af5d.incomingInstantiationData);
				m_instantiatePending = true;
				GameObject gameObject = ResourcesLoader.c2d63b1bf24325b01b8a5a703c64d91f2(ce02e13b33631f517a7ad32b37a06af5d.prefabName, ce02e13b33631f517a7ad32b37a06af5d.position, ce02e13b33631f517a7ad32b37a06af5d.rotation);
				for (int k = 0; k < components.Length; k++)
				{
					array2[k].ce57f12a4f7e693a5fe0c4049dc56fa7c = 0;
					array2[k].c26bc9278762c84e1e76177f085674c7e = -1;
					array2[k].prefixBackup = -1;
					array2[k].instantiationId = -1;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					c4db74f047af6093dfe1aae77c34821d6(ce02e13b33631f517a7ad32b37a06af5d.instantiationId);
					PhotonView[] array3 = components;
					foreach (PhotonView photonView in array3)
					{
						if (photonView.lastOnSerializeDataReceived != null)
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
							cf3f639d9f53429a8af80536a64470f83(photonView.ce57f12a4f7e693a5fe0c4049dc56fa7c).lastOnSerializeDataReceived = photonView.lastOnSerializeDataReceived;
							cf3f639d9f53429a8af80536a64470f83(photonView.ce57f12a4f7e693a5fe0c4049dc56fa7c).OnSerializeRead(photonView.lastOnSerializeDataReceived, ce02e13b33631f517a7ad32b37a06af5d.photonPlayer, ce02e13b33631f517a7ad32b37a06af5d.serverTime, 0);
						}
						if (photonView.bufferedRPC.Count == 0)
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
						using (List<Pair<Hashtable, PhotonPlayer>>.Enumerator enumerator = photonView.bufferedRPC.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Pair<Hashtable, PhotonPlayer> current = enumerator.Current;
								c24ba2f644674bb9b246cce0b35f058cc(current.Left, current.Right);
							}
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									goto end_IL_02bc;
								}
								continue;
								end_IL_02bc:
								break;
							}
						}
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						UnityEngine.Object.Destroy(ce02e13b33631f517a7ad32b37a06af5d.instantiateHelper);
						object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
						array4[0] = new PhotonMessageInfo(ce02e13b33631f517a7ad32b37a06af5d.photonPlayer, ce02e13b33631f517a7ad32b37a06af5d.serverTime, c56ecf3283d235e852cde628d84d7b371.c7088de59e49f7108f520cf7e0bae167e);
						MonoBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>();
						foreach (MonoBehaviour monoBehaviour in componentsInChildren)
						{
							MethodInfo methodInfo = c37886ec92280a4613e176e93a6cbbb2b(monoBehaviour, PhotonNetworkingMessage.OnPhotonInstantiate);
							if (methodInfo == null)
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
							object obj = methodInfo.Invoke(monoBehaviour, array4);
							if (methodInfo.ReturnType != Type.GetTypeFromHandle(cf09b6be9ab5afc78cbfc07d687efb188.cc1720d05c75832f704b87474932341c3()))
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
							PhotonHandler.SP.StartCoroutine((IEnumerator)obj);
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return InstantiateState.Success;
									}
								}
							}
							return InstantiateState.Fail;
						}
					}
				}
			}
		}
		IL_004c:
		return InstantiateState.Pending;
	}

	private void c2ca898d0fe48fbc0edb2ac1c230f5a4d(int c5f667af3a7d9823b53bdd74efef4f072, object[] c332524fa6b5f6c2dfdb5f39c56de7f45)
	{
		tempInstantiationData[c5f667af3a7d9823b53bdd74efef4f072] = c332524fa6b5f6c2dfdb5f39c56de7f45;
	}

	public object[] cf9db7686d6df61be354660a9684790c6(int c5f667af3a7d9823b53bdd74efef4f072)
	{
		object[] value = c5045159a57582d4577b6fa1bce364dca.c7088de59e49f7108f520cf7e0bae167e;
		if (c5f667af3a7d9823b53bdd74efef4f072 == 0)
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
					return null;
				}
			}
		}
		tempInstantiationData.TryGetValue(c5f667af3a7d9823b53bdd74efef4f072, out value);
		return value;
	}

	private void c4db74f047af6093dfe1aae77c34821d6(int c5f667af3a7d9823b53bdd74efef4f072)
	{
		tempInstantiationData.Remove(c5f667af3a7d9823b53bdd74efef4f072);
	}

	public void c8ef81fcccf6abc1c374efe36516b49fd()
	{
		GameObject[] array = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(instantiatedObjects.Count);
		instantiatedObjects.Values.CopyTo(array, 0);
		foreach (GameObject gameObject in array)
		{
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			else
			{
				cb6e59f148cd5a994857c3d7623cab3f9(gameObject, false);
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (instantiatedObjects.Count > 0)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "RemoveAllInstantiatedObjects() this.instantiatedObjects.Count should be 0 by now.");
			}
			instantiatedObjects = new Dictionary<int, GameObject>();
			return;
		}
	}

	public void c25ff6a61adf58242bd658adf180a3823(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198, bool cb711caa356a383fb1b35fba3629dc4dc)
	{
		GameObject[] array = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(instantiatedObjects.Count);
		instantiatedObjects.Values.CopyTo(array, 0);
		foreach (GameObject gameObject in array)
		{
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				continue;
			}
			PhotonView[] componentsInChildren = gameObject.GetComponentsInChildren<PhotonView>();
			int num = componentsInChildren.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					PhotonView photonView = componentsInChildren[num];
					if (photonView.c60085480ef91f270ea43e325ca766ead == ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3)
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
						cb6e59f148cd5a994857c3d7623cab3f9(gameObject, cb711caa356a383fb1b35fba3629dc4dc);
						break;
					}
					num--;
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
				break;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void cb6e59f148cd5a994857c3d7623cab3f9(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f, bool cb711caa356a383fb1b35fba3629dc4dc)
	{
		if (c68eeb75ae8e0180ebe74a7f42c8bcf3f == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (base.DebugOut == DebugLevel.ERROR)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								DebugReturn(DebugLevel.ERROR, "Can't remove instantiated GO if it's null.");
								return;
							}
						}
					}
					return;
				}
			}
		}
		int num = cce00c62160e5ebfb1592369cbe6f2c66(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
		if (num == -1)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (base.DebugOut == DebugLevel.ERROR)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								DebugReturn(DebugLevel.ERROR, "Can't find GO in instantiation list. Object: " + c68eeb75ae8e0180ebe74a7f42c8bcf3f);
								return;
							}
						}
					}
					return;
				}
			}
		}
		instantiatedObjects.Remove(num);
		PhotonView[] componentsInChildren = c68eeb75ae8e0180ebe74a7f42c8bcf3f.GetComponentsInChildren<PhotonView>(true);
		for (int num2 = componentsInChildren.Length - 1; num2 >= 0; num2--)
		{
			PhotonView photonView = componentsInChildren[num2];
			if (photonView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			}
			else
			{
				c5204a3cd31d565129c4cb4c2f22a3c08(photonView, cb711caa356a383fb1b35fba3629dc4dc);
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if ((int)base.DebugOut >= 5)
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
				DebugReturn(DebugLevel.ALL, "Network destroy Instantiated GO: " + c68eeb75ae8e0180ebe74a7f42c8bcf3f.name);
			}
			c13c17c1e00c5e4fc1833ef858d92cb77(c68eeb75ae8e0180ebe74a7f42c8bcf3f);
			return;
		}
	}

	public int cce00c62160e5ebfb1592369cbe6f2c66(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		int result = -1;
		if (c68eeb75ae8e0180ebe74a7f42c8bcf3f == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugReturn(DebugLevel.ERROR, "GetInstantiatedObjectsId() for GO == null.");
					return result;
				}
			}
		}
		PhotonView[] array = c68eeb75ae8e0180ebe74a7f42c8bcf3f.cb0af1eac32d2112bb0cc859a7ed20362();
		if (array != null)
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
			if (array.Length > 0)
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
				if (array[0] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return array[0].instantiationId;
						}
					}
				}
			}
		}
		if (base.DebugOut == DebugLevel.ALL)
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
			DebugReturn(DebugLevel.ALL, "GetInstantiatedObjectsId failed for GO: " + c68eeb75ae8e0180ebe74a7f42c8bcf3f);
		}
		return result;
	}

	private void c48c0410d0c41a5bf8a81d12437b47b4a(int cc1e605135415e42ae6d2361c6781c8ac, int c69f92abf82891a726d320565a4b46747)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)7] = cc1e605135415e42ae6d2361c6781c8ac;
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c69f92abf82891a726d320565a4b46747;
		c3f632fdd31c8a3f2463924fbc1ced8b4(202, hashtable, true, 0, array, EventCaching.RemoveFromRoomCache);
	}

	private void cf558d8ad9dba7b53bc81b033edcfcc27(int c69f92abf82891a726d320565a4b46747)
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c69f92abf82891a726d320565a4b46747;
		c3f632fdd31c8a3f2463924fbc1ced8b4(202, null, true, 0, array, EventCaching.RemoveFromRoomCache);
	}

	public void cc699b379927298a8be1bc2ede0079994(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198, bool cb711caa356a383fb1b35fba3629dc4dc)
	{
		c25ff6a61adf58242bd658adf180a3823(ceb41162a7cd2a1d5c4a03830e02b4198, cb711caa356a383fb1b35fba3629dc4dc);
		PhotonView[] array = (PhotonView[])UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c47d1e566ef1e4c97112f15ca22498e59.cc1720d05c75832f704b87474932341c3()));
		for (int num = array.Length - 1; num >= 0; num--)
		{
			PhotonView photonView = array[num];
			if (photonView.c706ea4155b03100282fe553e4d0be557 == ceb41162a7cd2a1d5c4a03830e02b4198)
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
				c5204a3cd31d565129c4cb4c2f22a3c08(photonView, cb711caa356a383fb1b35fba3629dc4dc);
			}
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

	public void c5204a3cd31d565129c4cb4c2f22a3c08(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, bool cb711caa356a383fb1b35fba3629dc4dc)
	{
		if (!cb711caa356a383fb1b35fba3629dc4dc)
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
			if (!ca4187010cdd35921f11dd5df8ccc23e3.c6971afb2ced2e6c56d327fce1c3bca83)
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
				if (mMasterClient != mLocalActor)
				{
					goto IL_0076;
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
			Hashtable hashtable = new Hashtable();
			hashtable[(byte)0] = ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c;
			c3f632fdd31c8a3f2463924fbc1ced8b4(204, hashtable, true, 0, EventCaching.DoNotCache, ReceiverGroup.Others);
		}
		goto IL_0076;
		IL_0076:
		if (!ca4187010cdd35921f11dd5df8ccc23e3.c6971afb2ced2e6c56d327fce1c3bca83)
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
			if (mMasterClient != mLocalActor)
			{
				goto IL_00ab;
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
		c2b4c9018817e93481982b6ddc148afed(ca4187010cdd35921f11dd5df8ccc23e3);
		goto IL_00ab;
		IL_00ab:
		if (ca4187010cdd35921f11dd5df8ccc23e3.instantiationId == ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c)
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
			int c60085480ef91f270ea43e325ca766ead = ca4187010cdd35921f11dd5df8ccc23e3.c60085480ef91f270ea43e325ca766ead;
			c48c0410d0c41a5bf8a81d12437b47b4a(ca4187010cdd35921f11dd5df8ccc23e3.instantiationId, c60085480ef91f270ea43e325ca766ead);
		}
		if ((int)base.DebugOut >= 5)
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
			DebugReturn(DebugLevel.ALL, "Network destroy PhotonView GO: " + ca4187010cdd35921f11dd5df8ccc23e3.gameObject.name);
		}
		c13c17c1e00c5e4fc1833ef858d92cb77(ca4187010cdd35921f11dd5df8ccc23e3.gameObject);
	}

	public PhotonView cf3f639d9f53429a8af80536a64470f83(int ce57f12a4f7e693a5fe0c4049dc56fa7c)
	{
		PhotonView value = c56ecf3283d235e852cde628d84d7b371.c7088de59e49f7108f520cf7e0bae167e;
		photonViewList.TryGetValue(ce57f12a4f7e693a5fe0c4049dc56fa7c, out value);
		if (value == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PhotonView[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c47d1e566ef1e4c97112f15ca22498e59.cc1720d05c75832f704b87474932341c3())) as PhotonView[];
			PhotonView[] array2 = array;
			foreach (PhotonView photonView in array2)
			{
				if (photonView.ce57f12a4f7e693a5fe0c4049dc56fa7c != ce57f12a4f7e693a5fe0c4049dc56fa7c)
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
					return photonView;
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
		return value;
	}

	public void c4417d094281af564a587065a579930ba(PhotonView c7f473b48a30daeb33aad838f3ba0b15c)
	{
		if (!Application.isPlaying)
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
					photonViewList = new Dictionary<int, PhotonView>();
					return;
				}
			}
		}
		if (c7f473b48a30daeb33aad838f3ba0b15c.subId == 0)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!photonViewList.ContainsKey(c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					photonViewList.Add(c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c, c7f473b48a30daeb33aad838f3ba0b15c);
					photonViews.Add(c7f473b48a30daeb33aad838f3ba0b15c);
					if (c7f473b48a30daeb33aad838f3ba0b15c.c201e69461401637f68794a86ca99b782())
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
						photonActiveViews.Add(c7f473b48a30daeb33aad838f3ba0b15c);
						if (c7f473b48a30daeb33aad838f3ba0b15c.synchronizationDir == SynchronizationDir.Broadcast)
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
							BroadcastViews.Add(c7f473b48a30daeb33aad838f3ba0b15c);
						}
						if (c7f473b48a30daeb33aad838f3ba0b15c.synchronizationDir == SynchronizationDir.Collect)
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
							CollectViews.Add(c7f473b48a30daeb33aad838f3ba0b15c);
						}
					}
					if ((int)base.DebugOut >= 5)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								DebugReturn(DebugLevel.ALL, "Registered PhotonView: " + c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(c7f473b48a30daeb33aad838f3ba0b15c != photonViewList[c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c]))
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Format("PhotonView ID duplicate found: {0}. On objects: {1} and {2}. Maybe one wasn't destroyed on scene load?! Check for 'DontDestroyOnLoad'.", c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c, c7f473b48a30daeb33aad838f3ba0b15c, photonViewList[c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c]));
			return;
		}
	}

	public void c97ffe8eafefa0eb594f4fc597de59226(PhotonView c7f473b48a30daeb33aad838f3ba0b15c)
	{
		if (!Application.isPlaying)
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
					photonViewList = new Dictionary<int, PhotonView>();
					return;
				}
			}
		}
		PhotonView value = c56ecf3283d235e852cde628d84d7b371.c7088de59e49f7108f520cf7e0bae167e;
		photonViewList.TryGetValue(c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c, out value);
		if (value == c7f473b48a30daeb33aad838f3ba0b15c)
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
			photonViewList.Remove(c7f473b48a30daeb33aad838f3ba0b15c.ce57f12a4f7e693a5fe0c4049dc56fa7c);
		}
		photonViews.Remove(c7f473b48a30daeb33aad838f3ba0b15c);
		photonActiveViews.Remove(c7f473b48a30daeb33aad838f3ba0b15c);
		BroadcastViews.Remove(c7f473b48a30daeb33aad838f3ba0b15c);
		CollectViews.Remove(c7f473b48a30daeb33aad838f3ba0b15c);
		networkingPriority.OnRemovePhotonView(c7f473b48a30daeb33aad838f3ba0b15c);
	}

	public void c2b4c9018817e93481982b6ddc148afed(int cf90c133f6a5c8156aba8d56ffbdef857)
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cf90c133f6a5c8156aba8d56ffbdef857;
		c3f632fdd31c8a3f2463924fbc1ced8b4(200, null, true, 0, array, EventCaching.RemoveFromRoomCache);
	}

	public void c24a5383c72642b308da7a3f4043b0bf0(int cf90c133f6a5c8156aba8d56ffbdef857)
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cf90c133f6a5c8156aba8d56ffbdef857;
		c3f632fdd31c8a3f2463924fbc1ced8b4(0, null, true, 0, array, EventCaching.RemoveFromRoomCache);
	}

	private void c760045939a7fce4bc3228a2bc96fe2c2()
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[244] = (byte)0;
		dictionary[247] = (byte)7;
		OpCustom(253, dictionary, true, 0);
	}

	public void c2b4c9018817e93481982b6ddc148afed(PhotonView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (!mLocalActor.ca3052869987fcf5688487de12414faab)
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
			if (ca4187010cdd35921f11dd5df8ccc23e3.c706ea4155b03100282fe553e4d0be557 != mLocalActor)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "Error, cannot remove cached RPCs on a PhotonView thats not ours! ";
						array[1] = ca4187010cdd35921f11dd5df8ccc23e3.c706ea4155b03100282fe553e4d0be557;
						array[2] = " scene: ";
						array[3] = ca4187010cdd35921f11dd5df8ccc23e3.c4888a6d1dea202176b2cd777ad28f3a6;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
						return;
					}
					}
				}
			}
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)0] = ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c;
		c3f632fdd31c8a3f2463924fbc1ced8b4(200, hashtable, true, 0, EventCaching.RemoveFromRoomCache, ReceiverGroup.Others);
	}

	public void c8c6965cfbe25e116b57410f152db9a9e(int c6279c42b47398c5e401c1cff54ce61c2)
	{
		using (Dictionary<int, PhotonView>.Enumerator enumerator = photonViewList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PhotonView value = enumerator.Current.Value;
				if (value.group != c6279c42b47398c5e401c1cff54ce61c2)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c2b4c9018817e93481982b6ddc148afed(value);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void ccf8bc3f00101ac6e04b7ed4720c536da(short c26bc9278762c84e1e76177f085674c7e)
	{
		currentLevelPrefix = c26bc9278762c84e1e76177f085674c7e;
	}

	public void c19fd12ed98be2a9174d53644dc9757c8(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, string ca57789de86459caf1b0cd284afe32a38, PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198, bool c975f237222e991e51b0b1732262bfdfa, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		if (blockSendingGroups.Contains(ca4187010cdd35921f11dd5df8ccc23e3.group))
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
		if (ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c < 1)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = "Illegal view ID:";
			array[1] = ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c;
			array[2] = " method: ";
			array[3] = ca57789de86459caf1b0cd284afe32a38;
			array[4] = " GO:";
			array[5] = ca4187010cdd35921f11dd5df8ccc23e3.gameObject.name;
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
		}
		if ((int)base.DebugOut >= 3)
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
			object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array2[0] = "Sending RPC \"";
			array2[1] = ca57789de86459caf1b0cd284afe32a38;
			array2[2] = "\" to player[";
			array2[3] = ceb41162a7cd2a1d5c4a03830e02b4198;
			array2[4] = "]";
			DebugReturn(DebugLevel.INFO, string.Concat(array2));
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)0] = ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c;
		if (ca4187010cdd35921f11dd5df8ccc23e3.c26bc9278762c84e1e76177f085674c7e > 0)
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
			hashtable[(byte)1] = (short)ca4187010cdd35921f11dd5df8ccc23e3.c26bc9278762c84e1e76177f085674c7e;
		}
		hashtable[(byte)2] = base.ServerTimeInMilliSeconds;
		hashtable[(byte)3] = ca57789de86459caf1b0cd284afe32a38;
		hashtable[(byte)4] = c90ecb087828ed9ceb9c00eafb6d52f4c;
		if (mLocalActor == ceb41162a7cd2a1d5c4a03830e02b4198)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					c24ba2f644674bb9b246cce0b35f058cc(hashtable, ceb41162a7cd2a1d5c4a03830e02b4198);
					return;
				}
			}
		}
		if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
			ca4187010cdd35921f11dd5df8ccc23e3.c527d35a2bd1b8768af0cd94afeb762c5(ca57789de86459caf1b0cd284afe32a38, Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable));
		}
		int[] array3 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
		array3[0] = ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3;
		int[] c566ca11545011ee633a4806eae49c18d = array3;
		c3f632fdd31c8a3f2463924fbc1ced8b4(200, hashtable, c975f237222e991e51b0b1732262bfdfa, 0, c566ca11545011ee633a4806eae49c18d);
	}

	public void c19fd12ed98be2a9174d53644dc9757c8(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, string ca57789de86459caf1b0cd284afe32a38, PhotonTargets c82fcbab5e578dc3a31c1f662916bd87e, bool c975f237222e991e51b0b1732262bfdfa, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		if (blockSendingGroups.Contains(ca4187010cdd35921f11dd5df8ccc23e3.group))
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
		if (ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c < 1)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = "Illegal view ID:";
			array[1] = ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c;
			array[2] = " method: ";
			array[3] = ca57789de86459caf1b0cd284afe32a38;
			array[4] = " GO:";
			array[5] = ca4187010cdd35921f11dd5df8ccc23e3.gameObject.name;
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
		}
		if ((int)base.DebugOut >= 3)
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
			object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array2[0] = "Sending RPC \"";
			array2[1] = ca57789de86459caf1b0cd284afe32a38;
			array2[2] = "\" to ";
			array2[3] = c82fcbab5e578dc3a31c1f662916bd87e;
			DebugReturn(DebugLevel.INFO, string.Concat(array2));
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)0] = ca4187010cdd35921f11dd5df8ccc23e3.ce57f12a4f7e693a5fe0c4049dc56fa7c;
		if (ca4187010cdd35921f11dd5df8ccc23e3.c26bc9278762c84e1e76177f085674c7e > 0)
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
			hashtable[(byte)1] = (short)ca4187010cdd35921f11dd5df8ccc23e3.c26bc9278762c84e1e76177f085674c7e;
		}
		hashtable[(byte)2] = base.ServerTimeInMilliSeconds;
		hashtable[(byte)3] = ca57789de86459caf1b0cd284afe32a38;
		hashtable[(byte)4] = c90ecb087828ed9ceb9c00eafb6d52f4c;
		if (c82fcbab5e578dc3a31c1f662916bd87e == PhotonTargets.All)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
						ca4187010cdd35921f11dd5df8ccc23e3.c527d35a2bd1b8768af0cd94afeb762c5(ca57789de86459caf1b0cd284afe32a38, Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable));
					}
					c3f632fdd31c8a3f2463924fbc1ced8b4(200, (byte)ca4187010cdd35921f11dd5df8ccc23e3.group, hashtable, c975f237222e991e51b0b1732262bfdfa, 0);
					c24ba2f644674bb9b246cce0b35f058cc(hashtable, mLocalActor);
					return;
				}
			}
		}
		if (c82fcbab5e578dc3a31c1f662916bd87e == PhotonTargets.Others)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
						ca4187010cdd35921f11dd5df8ccc23e3.c527d35a2bd1b8768af0cd94afeb762c5(ca57789de86459caf1b0cd284afe32a38, Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable));
					}
					c3f632fdd31c8a3f2463924fbc1ced8b4(200, (byte)ca4187010cdd35921f11dd5df8ccc23e3.group, hashtable, c975f237222e991e51b0b1732262bfdfa, 0);
					return;
				}
			}
		}
		if (c82fcbab5e578dc3a31c1f662916bd87e == PhotonTargets.AllBuffered)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
						ca4187010cdd35921f11dd5df8ccc23e3.c527d35a2bd1b8768af0cd94afeb762c5(ca57789de86459caf1b0cd284afe32a38, Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable));
					}
					c3f632fdd31c8a3f2463924fbc1ced8b4(200, hashtable, c975f237222e991e51b0b1732262bfdfa, 0, EventCaching.AddToRoomCache, ReceiverGroup.Others);
					c24ba2f644674bb9b246cce0b35f058cc(hashtable, mLocalActor);
					return;
				}
			}
		}
		if (c82fcbab5e578dc3a31c1f662916bd87e == PhotonTargets.OthersBuffered)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
						ca4187010cdd35921f11dd5df8ccc23e3.c527d35a2bd1b8768af0cd94afeb762c5(ca57789de86459caf1b0cd284afe32a38, Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable));
					}
					c3f632fdd31c8a3f2463924fbc1ced8b4(200, hashtable, c975f237222e991e51b0b1732262bfdfa, 0, EventCaching.AddToRoomCache, ReceiverGroup.Others);
					return;
				}
			}
		}
		if (c82fcbab5e578dc3a31c1f662916bd87e == PhotonTargets.MasterClient)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (mMasterClient == mLocalActor)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								c24ba2f644674bb9b246cce0b35f058cc(hashtable, mLocalActor);
								return;
							}
						}
					}
					if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914)
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
						ca4187010cdd35921f11dd5df8ccc23e3.c527d35a2bd1b8768af0cd94afeb762c5(ca57789de86459caf1b0cd284afe32a38, Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable));
					}
					c3f632fdd31c8a3f2463924fbc1ced8b4(200, hashtable, c975f237222e991e51b0b1732262bfdfa, 0, EventCaching.DoNotCache, ReceiverGroup.MasterClient);
					return;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Unsupported target enum: " + c82fcbab5e578dc3a31c1f662916bd87e);
	}

	public void cda9bc04ce8997ffe268cc6b552dd0dca(int c6279c42b47398c5e401c1cff54ce61c2, bool cbf402c82d0fffee7c8f37c98e456b8f8)
	{
		if (c6279c42b47398c5e401c1cff54ce61c2 <= 0)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: PhotonNetwork.SetReceivingEnabled was called with an illegal group number: " + c6279c42b47398c5e401c1cff54ce61c2 + ". The group number should be at least 1.");
					return;
				}
			}
		}
		if (cbf402c82d0fffee7c8f37c98e456b8f8)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (!allowedReceivingGroups.Contains(c6279c42b47398c5e401c1cff54ce61c2))
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
							{
								allowedReceivingGroups.Add(c6279c42b47398c5e401c1cff54ce61c2);
								byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(1);
								array[0] = (byte)c6279c42b47398c5e401c1cff54ce61c2;
								byte[] c439c34a0599f27e1c487623d2bdf47e = array;
								cef1172883a0398e2b7732b3c47c7ce2b(null, c439c34a0599f27e1c487623d2bdf47e);
								return;
							}
							}
						}
					}
					return;
				}
			}
		}
		if (!allowedReceivingGroups.Contains(c6279c42b47398c5e401c1cff54ce61c2))
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
			allowedReceivingGroups.Remove(c6279c42b47398c5e401c1cff54ce61c2);
			byte[] array2 = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = (byte)c6279c42b47398c5e401c1cff54ce61c2;
			byte[] c908877424278e67b8777768f58b51b = array2;
			cef1172883a0398e2b7732b3c47c7ce2b(c908877424278e67b8777768f58b51b, ced713f4048066e18a81f8423323d26ee.c7088de59e49f7108f520cf7e0bae167e);
			return;
		}
	}

	public void c2a8c532fff5faa34b206b73bfc4009ee(int c6279c42b47398c5e401c1cff54ce61c2, bool cbf402c82d0fffee7c8f37c98e456b8f8)
	{
		if (!cbf402c82d0fffee7c8f37c98e456b8f8)
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
					blockSendingGroups.Add(c6279c42b47398c5e401c1cff54ce61c2);
					return;
				}
			}
		}
		blockSendingGroups.Remove(c6279c42b47398c5e401c1cff54ce61c2);
	}

	public void c27479e14c852f4d5c80f387af40d1263()
	{
		if (loadingLevelAndPausedNetwork)
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
			if (!PhotonNetwork.c195baff01be84d431dc217cf68ed2569)
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
				loadingLevelAndPausedNetwork = false;
				PhotonNetwork.c195baff01be84d431dc217cf68ed2569 = true;
			}
		}
		List<int> list = new List<int>();
		using (Dictionary<int, PhotonView>.Enumerator enumerator = photonViewList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, PhotonView> current = enumerator.Current;
				PhotonView value = current.Value;
				if (!(value == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				list.Add(current.Key);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0098;
				}
				continue;
				end_IL_0098:
				break;
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			int ce57f12a4f7e693a5fe0c4049dc56fa7c = list[i];
			c97ffe8eafefa0eb594f4fc597de59226(cf3f639d9f53429a8af80536a64470f83(ce57f12a4f7e693a5fe0c4049dc56fa7c));
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (list.Count <= 0)
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
				if ((int)base.DebugOut < 3)
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
					DebugReturn(DebugLevel.INFO, "Removed " + list.Count + " scene view IDs from last scene.");
					return;
				}
			}
		}
	}

	public void ca8dab3ae6f9ebf52cc4b1fddadc882d1()
	{
		for (int i = 0; i < this.instantiatingPhotonViews.Count; i++)
		{
			InstantiatingPhotonViews instantiatingPhotonViews = this.instantiatingPhotonViews[i];
			bool flag = true;
			if (instantiatingPhotonViews.instantiateHelper != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				PhotonView[] components = instantiatingPhotonViews.instantiateHelper.GetComponents<PhotonView>();
				PhotonView[] array = components;
				int num = 0;
				while (true)
				{
					if (num < array.Length)
					{
						PhotonView photonView = array[num];
						if (photonView.synchronization != 0)
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
							if (photonView.lastOnSerializeDataReceived == null)
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
								flag = false;
								break;
							}
						}
						num++;
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
					break;
				}
				if (!flag)
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
				m_instantiatePending = false;
				InstantiateState instantiateState = c7fa32383a5ce873d881c010490922c96(instantiatingPhotonViews);
				if (instantiateState == InstantiateState.Pending)
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
				removingInstantiatingPhotonViews.Add(instantiatingPhotonViews);
				if (instantiateState != InstantiateState.Fail)
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
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = "Fail to instantiate ";
				array2[1] = instantiatingPhotonViews.instantiationId;
				array2[2] = "->:";
				array2[3] = instantiatingPhotonViews.prefabName;
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array2));
			}
			else
			{
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, instantiatingPhotonViews.instantiationId + " have no instantiateHelper");
				removingInstantiatingPhotonViews.Add(instantiatingPhotonViews);
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (removingInstantiatingPhotonViews.Count <= 0)
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
				using (List<InstantiatingPhotonViews>.Enumerator enumerator = removingInstantiatingPhotonViews.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						InstantiatingPhotonViews current = enumerator.Current;
						this.instantiatingPhotonViews.Remove(current);
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_01c8;
						}
						continue;
						end_IL_01c8:
						break;
					}
				}
				removingInstantiatingPhotonViews.Clear();
				return;
			}
		}
	}

	public void c43a56291b587958528031d32d2c20b39()
	{
		m_viewUpdateCount++;
		if (!PhotonNetwork.c1f4a1fd51cd6406ba683224b3b608838)
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
			if (PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (mActors == null)
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
				if (mActors.Count <= 1)
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
				if (m_viewUpdateCount % m_pingChannel.m_sendingInterval == 0)
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
					c8c71a22931019d5a72a2c7c3b156ecbd();
				}
				int count = photonActiveViews.Count;
				for (int i = 0; i < count; i++)
				{
					PhotonView photonView = photonActiveViews[i];
					photonView.c99624460050f8ad93a15b773f70fe6aa();
					if (!(photonView.observed != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (photonView.synchronization == ViewSynchronization.Off)
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
					if (!photonView.gameObject.activeInHierarchy)
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
						continue;
					}
					if (photonView.c706ea4155b03100282fe553e4d0be557 == mLocalActor)
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
						if (photonView.synchronizationDir == SynchronizationDir.Broadcast)
						{
							goto IL_019a;
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
					if (photonView.c706ea4155b03100282fe553e4d0be557 != mLocalActor)
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
						if (photonView.synchronizationDir == SynchronizationDir.Collect)
						{
							goto IL_019a;
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
					if (!photonView.c4888a6d1dea202176b2cd777ad28f3a6)
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
					if (mMasterClient != mLocalActor)
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
					goto IL_019a;
					IL_019a:
					if (blockSendingGroups.Contains(photonView.group))
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
						photonView.OnSerializeToStream();
						photonView.OnSerializeWrite();
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									cf707cb470fca12391b8aaef32322896d();
									return;
								}
							}
						}
					}
					c1bbfe42ac0471c6adedd6eaf31621c4c();
					return;
				}
			}
		}
	}

	private void cf707cb470fca12391b8aaef32322896d()
	{
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		Dictionary<int, Hashtable> dictionary2 = new Dictionary<int, Hashtable>();
		if (c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			for (int i = 0; i < c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_grids.Count; i++)
			{
				Grid grid = c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_grids[i];
				List<PhotonView> views = grid.m_views;
				int count = views.Count;
				if (views == null)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (grid.m_newcomersID.Count != 0)
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
					dictionary.Clear();
					dictionary2.Clear();
					for (int j = 0; j < count; j++)
					{
						PhotonView photonView = views[j];
						if (!photonView.c6de514d9171b3e8447c88ef03e6c1f57())
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
						if (photonView.synchronizationDir != 0)
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
						Hashtable hashtable = photonView.c286c8ba4a1de9af2c2d0ed5b33e6f9f2();
						if (hashtable.Count == 0)
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
							continue;
						}
						if (photonView.synchronization != ViewSynchronization.ReliableDeltaCompressed)
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
							if (photonView.synchronization != ViewSynchronization.Reliable)
							{
								if (!dictionary2.ContainsKey(photonView.group))
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
									dictionary2[photonView.group] = new Hashtable();
									dictionary2[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
								}
								Hashtable hashtable2 = dictionary2[photonView.group];
								hashtable2.Add((short)hashtable2.Count, hashtable);
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
						}
						if (!hashtable.ContainsKey((byte)1))
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
							if (!hashtable.ContainsKey((byte)2))
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
						}
						if (!dictionary.ContainsKey(photonView.group))
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
							dictionary[photonView.group] = new Hashtable();
							dictionary[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
						}
						Hashtable hashtable3 = dictionary[photonView.group];
						hashtable3.Add((short)hashtable3.Count, hashtable);
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
					using (Dictionary<int, Hashtable>.Enumerator enumerator = dictionary.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							c3f632fdd31c8a3f2463924fbc1ced8b4(206, enumerator.Current.Value, true, 0, grid.m_newcomersID.ToArray());
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_02c9;
							}
							continue;
							end_IL_02c9:
							break;
						}
					}
					using (Dictionary<int, Hashtable>.Enumerator enumerator2 = dictionary2.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							c3f632fdd31c8a3f2463924fbc1ced8b4(201, enumerator2.Current.Value, false, 1, grid.m_newcomersID.ToArray());
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								goto end_IL_032a;
							}
							continue;
							end_IL_032a:
							break;
						}
					}
				}
				if (grid.m_settlersID.Count != 0)
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
					dictionary.Clear();
					dictionary2.Clear();
					int num = 0;
					int num2 = 0;
					while (true)
					{
						if (num2 < count)
						{
							PhotonView photonView2 = views[num2];
							if (photonView2.c6de514d9171b3e8447c88ef03e6c1f57())
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
								if (photonView2.synchronizationDir == SynchronizationDir.Broadcast)
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
									Hashtable hashtable4 = photonView2.c7e614d8d6b76bb3757d65a2fa141a4f5();
									if (hashtable4.Count == 0)
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
									}
									else
									{
										if (num >= grid.m_maxUpdateViews)
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
											break;
										}
										num++;
										if (photonView2.synchronization != ViewSynchronization.ReliableDeltaCompressed)
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
											if (photonView2.synchronization != ViewSynchronization.Reliable)
											{
												if (!dictionary2.ContainsKey(photonView2.group))
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
													dictionary2[photonView2.group] = new Hashtable();
													dictionary2[photonView2.group][(byte)0] = base.ServerTimeInMilliSeconds;
												}
												Hashtable hashtable5 = dictionary2[photonView2.group];
												hashtable5.Add((short)hashtable5.Count, hashtable4);
												goto IL_0558;
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
										if (!hashtable4.ContainsKey((byte)1))
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
											if (!hashtable4.ContainsKey((byte)2))
											{
												goto IL_0558;
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
										if (!dictionary.ContainsKey(photonView2.group))
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
											dictionary[photonView2.group] = new Hashtable();
											dictionary[photonView2.group][(byte)0] = base.ServerTimeInMilliSeconds;
										}
										Hashtable hashtable6 = dictionary[photonView2.group];
										hashtable6.Add((short)hashtable6.Count, hashtable4);
									}
								}
							}
							goto IL_0558;
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
						break;
						IL_0558:
						num2++;
					}
					using (Dictionary<int, Hashtable>.Enumerator enumerator3 = dictionary.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							KeyValuePair<int, Hashtable> current = enumerator3.Current;
							c3f632fdd31c8a3f2463924fbc1ced8b4(206, grid.m_id, current.Value, true, 0);
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								goto end_IL_05b4;
							}
							continue;
							end_IL_05b4:
							break;
						}
					}
					using (Dictionary<int, Hashtable>.Enumerator enumerator4 = dictionary2.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							KeyValuePair<int, Hashtable> current2 = enumerator4.Current;
							c3f632fdd31c8a3f2463924fbc1ced8b4(201, grid.m_id, current2.Value, false, 1);
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_0610;
							}
							continue;
							end_IL_0610:
							break;
						}
					}
				}
				grid.OnNetworkingUpdated();
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
		dictionary.Clear();
		dictionary2.Clear();
		for (int k = 0; k < CollectViews.Count; k++)
		{
			PhotonView photonView3 = CollectViews[k];
			if (!photonView3.c6de514d9171b3e8447c88ef03e6c1f57())
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
			Hashtable hashtable7 = photonView3.c7e614d8d6b76bb3757d65a2fa141a4f5();
			if (hashtable7.Count == 0)
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
				continue;
			}
			int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = photonView3.c706ea4155b03100282fe553e4d0be557.c29a834d12d3895f5680e69a30e6cd9a3;
			if (photonView3.synchronization != ViewSynchronization.ReliableDeltaCompressed)
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
				if (photonView3.synchronization != ViewSynchronization.Reliable)
				{
					Hashtable hashtable8 = new Hashtable();
					hashtable8[(byte)0] = base.ServerTimeInMilliSeconds;
					hashtable8[(short)1] = hashtable7;
					c3f632fdd31c8a3f2463924fbc1ced8b4(201, hashtable8, false, 1, array);
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
			}
			Hashtable hashtable9 = new Hashtable();
			hashtable9[(byte)0] = base.ServerTimeInMilliSeconds;
			hashtable9[(short)1] = hashtable7;
			c3f632fdd31c8a3f2463924fbc1ced8b4(206, hashtable9, true, 0, array);
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

	public void c1bbfe42ac0471c6adedd6eaf31621c4c(bool c69eb734beca3f0c5cc0f1f2510214d75 = false)
	{
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		Dictionary<int, Hashtable> dictionary2 = new Dictionary<int, Hashtable>();
		int num = 0;
		int num2 = mOtherPlayerListCopy.Length;
		if (c69eb734beca3f0c5cc0f1f2510214d75)
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
			num2 /= 2;
		}
		int num3 = m_lastUpdatedPlayerIndex;
		while (num3 < num2)
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
			if (num3 < mOtherPlayerListCopy.Length)
			{
				m_lastUpdatedPlayerIndex = num3;
				num = 0;
				dictionary.Clear();
				dictionary2.Clear();
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = mOtherPlayerListCopy[num3].c29a834d12d3895f5680e69a30e6cd9a3;
				PhotonPlayer photonPlayer = mOtherPlayerListCopy[num3];
				List<PhotonView> list = photonViews;
				int count = list.Count;
				if (list == null)
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
				for (int i = 0; i < count; i++)
				{
					PhotonView photonView = list[i];
					if (!photonView.c6de514d9171b3e8447c88ef03e6c1f57())
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
					if (photonView.synchronizationDir == SynchronizationDir.Collect)
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
						if (photonView.c706ea4155b03100282fe553e4d0be557 != photonPlayer)
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
							continue;
						}
					}
					photonView.ce7224fe810211212d4efda44323c8acd(photonPlayer);
					float num4 = networkingPriority.c9f0427d35dc233bd7b8a42190cf6c521(photonView, photonPlayer);
					if (num4 > 66f)
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
						networkingPriority.cb89e07214016d9bbd73aa8e8589a34d4(photonView, photonPlayer);
						continue;
					}
					bool flag = false;
					double value;
					if (photonView.m_lastUpdateTimePerPlayer.TryGetValue(photonPlayer, out value))
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
						if (photonView.lastTimeDataSend > value)
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
							if ((double)Time.time > value + 5.0)
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
								flag = true;
							}
						}
					}
					else
					{
						flag = true;
					}
					if (num >= PhotonNetwork.BandwidthCap)
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
						if (!flag)
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
							if (num4 > 0f)
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
								networkingPriority.cb89e07214016d9bbd73aa8e8589a34d4(photonView, photonPlayer);
								continue;
							}
						}
					}
					Hashtable hashtable = photonView.c6c0b3fb0659036072b3905bd91be4cdf(photonPlayer, flag);
					if (hashtable.Count == 0)
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
						continue;
					}
					double value2;
					if (photonView.m_lastUpdateTimePerPlayer.TryGetValue(photonPlayer, out value2))
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
						photonView.m_updateIntervalPerPlayer[photonPlayer] = (double)Time.time - value2;
					}
					photonView.m_lastUpdateTimePerPlayer[photonPlayer] = Time.time;
					networkingPriority.ca8318c9648d918e3470bd193031f5434(photonView, photonPlayer);
					num += Utils.c48ad35a6532e0c5642de63db021aab5a(hashtable);
					if (photonView.synchronization != ViewSynchronization.ReliableDeltaCompressed)
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
						if (photonView.synchronization != ViewSynchronization.Reliable)
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
							if (!flag)
							{
								if (!dictionary2.ContainsKey(photonView.group))
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
									dictionary2[photonView.group] = new Hashtable();
									dictionary2[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
								}
								Hashtable hashtable2 = dictionary2[photonView.group];
								hashtable2.Add((short)hashtable2.Count, hashtable);
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
						}
					}
					if (!hashtable.ContainsKey((byte)1))
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
						if (!hashtable.ContainsKey((byte)2))
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
					}
					if (!dictionary.ContainsKey(photonView.group))
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
						dictionary[photonView.group] = new Hashtable();
						dictionary[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
					}
					Hashtable hashtable3 = dictionary[photonView.group];
					hashtable3.Add((short)hashtable3.Count, hashtable);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					using (Dictionary<int, Hashtable>.Enumerator enumerator = dictionary.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							c3f632fdd31c8a3f2463924fbc1ced8b4(206, enumerator.Current.Value, true, 1, array);
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								goto end_IL_043d;
							}
							continue;
							end_IL_043d:
							break;
						}
					}
					using (Dictionary<int, Hashtable>.Enumerator enumerator2 = dictionary2.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							c3f632fdd31c8a3f2463924fbc1ced8b4(201, enumerator2.Current.Value, false, 2, array);
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								goto end_IL_0493;
							}
							continue;
							end_IL_0493:
							break;
						}
					}
					num3++;
					break;
				}
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
			break;
		}
		m_lastUpdatedPlayerIndex = num3;
		if (m_lastUpdatedPlayerIndex < mOtherPlayerListCopy.Length)
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
			m_lastUpdatedPlayerIndex = 0;
			return;
		}
	}

	public void c8c71a22931019d5a72a2c7c3b156ecbd()
	{
		Hashtable hashtable = new Hashtable();
		int i = 0;
		if (mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3 != mMasterClient.c29a834d12d3895f5680e69a30e6cd9a3)
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
			for (; i < mOtherPlayerListCopy.Length; i++)
			{
				hashtable.Clear();
				hashtable[0] = Time.realtimeSinceStartup;
				hashtable[1] = (byte)mLocalActor.c29a834d12d3895f5680e69a30e6cd9a3;
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = mOtherPlayerListCopy[i].c29a834d12d3895f5680e69a30e6cd9a3;
				c3f632fdd31c8a3f2463924fbc1ced8b4(207, hashtable, true, 0, array);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void c7e607af4052ac0565f3255f8289253b6(MonoBehaviour c00c5a51bf36801ca184ca18e0ccea941, PhotonStream c3b767e219cd722522367d9d5e52f00a9, PhotonMessageInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c3b767e219cd722522367d9d5e52f00a9;
		array[1] = c00bb86ffbeb6764fbe60d7b64859db7f;
		MethodInfo methodInfo = c37886ec92280a4613e176e93a6cbbb2b(c00c5a51bf36801ca184ca18e0ccea941, PhotonNetworkingMessage.OnPhotonSerializeView);
		if (methodInfo != null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					object obj = methodInfo.Invoke(c00c5a51bf36801ca184ca18e0ccea941, array);
					if (methodInfo.ReturnType == Type.GetTypeFromHandle(cf09b6be9ab5afc78cbfc07d687efb188.cc1720d05c75832f704b87474932341c3()))
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								PhotonHandler.SP.StartCoroutine((IEnumerator)obj);
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array2[0] = "Tried to run ";
		array2[1] = PhotonNetworkingMessage.OnPhotonSerializeView;
		array2[2] = ", but this method was missing on: ";
		array2[3] = c00c5a51bf36801ca184ca18e0ccea941;
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array2));
	}

	public MethodInfo c37886ec92280a4613e176e93a6cbbb2b(MonoBehaviour c00c5a51bf36801ca184ca18e0ccea941, PhotonNetworkingMessage c61a79f1bbfc63e4abc9f6c85dabe940c)
	{
		Type type = c00c5a51bf36801ca184ca18e0ccea941.GetType();
		if (!cachedMethods.ContainsKey(type))
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
			Dictionary<PhotonNetworkingMessage, MethodInfo> value = new Dictionary<PhotonNetworkingMessage, MethodInfo>();
			cachedMethods.Add(type, value);
		}
		Dictionary<PhotonNetworkingMessage, MethodInfo> dictionary = cachedMethods[type];
		if (!dictionary.ContainsKey(c61a79f1bbfc63e4abc9f6c85dabe940c))
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
			Type[] array;
			if (c61a79f1bbfc63e4abc9f6c85dabe940c == PhotonNetworkingMessage.OnPhotonSerializeView)
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
				array = cac2af44509abdc0f40c5fbd0631742be.c0a0cdf4a196914163f7334d9b0781a04(2);
				array[0] = Type.GetTypeFromHandle(cdffc6449c3814eba53cf17036d8b1523.cc1720d05c75832f704b87474932341c3());
				array[1] = Type.GetTypeFromHandle(c64d22c563daac7b0ebe4ab441aaab885.cc1720d05c75832f704b87474932341c3());
			}
			else if (c61a79f1bbfc63e4abc9f6c85dabe940c == PhotonNetworkingMessage.OnPhotonInstantiate)
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
				array = cac2af44509abdc0f40c5fbd0631742be.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = Type.GetTypeFromHandle(c64d22c563daac7b0ebe4ab441aaab885.cc1720d05c75832f704b87474932341c3());
			}
			else
			{
				if (c61a79f1bbfc63e4abc9f6c85dabe940c != PhotonNetworkingMessage.OnPhotonEvaluate)
				{
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Invalid PhotonNetworkingMessage!");
					return null;
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
				array = cac2af44509abdc0f40c5fbd0631742be.c0a0cdf4a196914163f7334d9b0781a04(2);
				array[0] = Type.GetTypeFromHandle(ca6c9a067d647bca38ad26420c7729e7a.cc1720d05c75832f704b87474932341c3());
				array[1] = Type.GetTypeFromHandle(cbf5cc040e16c0e0be83a7fed8598e44f.cc1720d05c75832f704b87474932341c3());
			}
			MethodInfo method = c00c5a51bf36801ca184ca18e0ccea941.GetType().GetMethod(string.Concat(c61a79f1bbfc63e4abc9f6c85dabe940c, string.Empty), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array, ca95f15dcddce0f9ac9ab17fc6b303700.c7088de59e49f7108f520cf7e0bae167e);
			if (method != null)
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
				dictionary.Add(c61a79f1bbfc63e4abc9f6c85dabe940c, method);
			}
		}
		if (dictionary.ContainsKey(c61a79f1bbfc63e4abc9f6c85dabe940c))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return dictionary[c61a79f1bbfc63e4abc9f6c85dabe940c];
				}
			}
		}
		return null;
	}

	public void ca0ec1e9e542d79bb6f94ab88b2982b8c()
	{
		networkingPriority.c6c6cbb0045146f9b0a890f787bad6e4d();
	}

	protected internal void ce24ae7eda88a0a7db54f496822feaa00()
	{
		if (PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0 == null)
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
			if (!PhotonNetwork.c9bea90d20d3b9c1060b684f2bc77db82)
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
				if (PhotonNetwork.ca3052869987fcf5688487de12414faab)
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
					string text = (string)PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0.ce640f5adbb33c511c28e1250d8608dd4["curScn"];
					if (string.IsNullOrEmpty(text))
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
						if (!(text != Application.loadedLevelName))
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
							PhotonNetwork.cc470f09a50548899d959dcf8e6a205f7(text);
							return;
						}
					}
				}
			}
		}
	}

	public void c46fc13c7a1f8093eb8c7ab700c70b599()
	{
		for (int i = 0; i < photonViews.Count; i++)
		{
			photonViews[i].grossRPCSize = 0;
			photonViews[i].grossSerializeSize = 0;
			photonViews[i].sizePerMethod.Clear();
			photonViews[i].grossRPCSizeRCV = 0;
			photonViews[i].grossSerializeSizeRCV = 0;
			photonViews[i].sizePerMethodRCV.Clear();
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
			networkStat.Clear();
			grossInstantiateData = 0;
			return;
		}
	}

	public List<PhotonView> c37edcd428b1153e146e65b2236f4bc0f()
	{
		List<PhotonView> list = new List<PhotonView>();
		list.AddRange(photonViews);
		if (_003C_003Ef__am_0024cache3A == null)
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
			_003C_003Ef__am_0024cache3A = (PhotonView c92796054b53538d6ad3ca14be8d69eb0, PhotonView c2aa9a45106c929d3e048f32dbf78d07c) => c2aa9a45106c929d3e048f32dbf78d07c.c82aa1e6f06bc147778156b8e1e96e1d8 - c92796054b53538d6ad3ca14be8d69eb0.c82aa1e6f06bc147778156b8e1e96e1d8;
		}
		list.Sort(_003C_003Ef__am_0024cache3A);
		return list;
	}

	public List<PhotonView> cdc416e24ee3e72a003d9282736af0d86()
	{
		List<PhotonView> list = new List<PhotonView>();
		list.AddRange(photonViews);
		if (_003C_003Ef__am_0024cache3B == null)
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
			_003C_003Ef__am_0024cache3B = (PhotonView c92796054b53538d6ad3ca14be8d69eb0, PhotonView c2aa9a45106c929d3e048f32dbf78d07c) => c2aa9a45106c929d3e048f32dbf78d07c.c1097797f47f6121a2daef2c9d735cf19 - c92796054b53538d6ad3ca14be8d69eb0.c1097797f47f6121a2daef2c9d735cf19;
		}
		list.Sort(_003C_003Ef__am_0024cache3B);
		return list;
	}

	public int cd3ab481409345f82017e9a6226db4847()
	{
		int num = grossInstantiateData;
		for (int i = 0; i < photonViews.Count; i++)
		{
			networkStat[photonViews[i].ce57f12a4f7e693a5fe0c4049dc56fa7c] = photonViews[i].c82aa1e6f06bc147778156b8e1e96e1d8;
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
			using (Dictionary<int, int>.ValueCollection.Enumerator enumerator = networkStat.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					num += current;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					return num;
				}
			}
		}
	}

	public int c56a7efd3d4c0feb181da5e6e0caccd11()
	{
		int num = grossInstantiateDataRCV;
		for (int i = 0; i < photonViews.Count; i++)
		{
			networkStatRCV[photonViews[i].ce57f12a4f7e693a5fe0c4049dc56fa7c] = photonViews[i].c1097797f47f6121a2daef2c9d735cf19;
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
			using (Dictionary<int, int>.ValueCollection.Enumerator enumerator = networkStatRCV.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					num += current;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					return num;
				}
			}
		}
	}

	public void c89f9569b4330d0286992724cb1480f55(byte cdf46071c2725c9ab47a01b833f484416, EventCallback c2db84530ef366a6deb001d449d4aa151)
	{
		if (mEventCallbacks.ContainsKey(cdf46071c2725c9ab47a01b833f484416))
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
					throw new ArgumentException(string.Format("RegisterEventCallback: Already registered a callback for event code {0}", cdf46071c2725c9ab47a01b833f484416), "eventCode");
				}
			}
		}
		mEventCallbacks[cdf46071c2725c9ab47a01b833f484416] = c2db84530ef366a6deb001d449d4aa151;
	}

	public void cd2a2d8015f4353872adfa786778b2898(byte cdf46071c2725c9ab47a01b833f484416)
	{
		mEventCallbacks.Remove(cdf46071c2725c9ab47a01b833f484416);
	}

	public bool c71111ea3c8afdb98963505d86a8495b6(byte c9f7e586bb3f27d35994b3e3029d2bbce, OperationResponseCallback c2db84530ef366a6deb001d449d4aa151)
	{
		if (mOperationResponseCallbacks.ContainsKey(c9f7e586bb3f27d35994b3e3029d2bbce))
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
		mOperationResponseCallbacks[c9f7e586bb3f27d35994b3e3029d2bbce] = c2db84530ef366a6deb001d449d4aa151;
		return true;
	}

	public void c70c342bd044a12574e7a34217617fe88(byte c9f7e586bb3f27d35994b3e3029d2bbce)
	{
		mOperationResponseCallbacks.Remove(c9f7e586bb3f27d35994b3e3029d2bbce);
	}

	public bool c50190e0c5838cf36bc56ebceb28dcdaa(byte c9f7e586bb3f27d35994b3e3029d2bbce, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		bool flag = true;
		IEnumerable<int> source = Enumerable.Range(0, c90ecb087828ed9ceb9c00eafb6d52f4c.Length);
		if (_003C_003Ef__am_0024cache3C == null)
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
			_003C_003Ef__am_0024cache3C = (int c5ebdc65d5cb420faf7ba524809963aa9) => (byte)c5ebdc65d5cb420faf7ba524809963aa9;
		}
		Dictionary<byte, object> customOpParameters = source.ToDictionary(_003C_003Ef__am_0024cache3C, (int c5ebdc65d5cb420faf7ba524809963aa9) => c90ecb087828ed9ceb9c00eafb6d52f4c[c5ebdc65d5cb420faf7ba524809963aa9]);
		return OpCustom(c9f7e586bb3f27d35994b3e3029d2bbce, customOpParameters, true);
	}

	public override bool c9c0b2e8af95df448eba53aabb19dcc0d(Hashtable c409129e403832642d20f53a4226efd28, bool c046f81605d5aacb6375ca5e9ced6b5fd, byte c38308765846f10101d4b827067dd8f83)
	{
		if (MasterConnection)
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
		return base.c9c0b2e8af95df448eba53aabb19dcc0d(c409129e403832642d20f53a4226efd28, c046f81605d5aacb6375ca5e9ced6b5fd, c38308765846f10101d4b827067dd8f83);
	}

	protected override bool c3a0951743c01f7942b6400256e038385(int c69f92abf82891a726d320565a4b46747, Hashtable c3aa9fea8c8f603f879dba8953ea14aa9, bool c046f81605d5aacb6375ca5e9ced6b5fd, byte c38308765846f10101d4b827067dd8f83)
	{
		if (MasterConnection)
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
					return false;
				}
			}
		}
		return base.c3a0951743c01f7942b6400256e038385(c69f92abf82891a726d320565a4b46747, c3aa9fea8c8f603f879dba8953ea14aa9, c046f81605d5aacb6375ca5e9ced6b5fd, c38308765846f10101d4b827067dd8f83);
	}

	[CompilerGenerated]
	private static int c06682c4e4b5e308d1c9be809de4b248d(PhotonView c92796054b53538d6ad3ca14be8d69eb0, PhotonView c2aa9a45106c929d3e048f32dbf78d07c)
	{
		return c2aa9a45106c929d3e048f32dbf78d07c.c82aa1e6f06bc147778156b8e1e96e1d8 - c92796054b53538d6ad3ca14be8d69eb0.c82aa1e6f06bc147778156b8e1e96e1d8;
	}

	[CompilerGenerated]
	private static int c92b1de79ea6711f1d28d79f9107cae79(PhotonView c92796054b53538d6ad3ca14be8d69eb0, PhotonView c2aa9a45106c929d3e048f32dbf78d07c)
	{
		return c2aa9a45106c929d3e048f32dbf78d07c.c1097797f47f6121a2daef2c9d735cf19 - c92796054b53538d6ad3ca14be8d69eb0.c1097797f47f6121a2daef2c9d735cf19;
	}

	[CompilerGenerated]
	private static byte cd6806fbe2356d74d67341b5ecf454fc6(int c5ebdc65d5cb420faf7ba524809963aa9)
	{
		return (byte)c5ebdc65d5cb420faf7ba524809963aa9;
	}
}
