using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using Photon;
using UnityEngine;

[AddComponentMenu("Miscellaneous/Photon View")]
public class PhotonView : Photon.MonoBehaviour
{
	public int subId;

	public int ownerId;

	private int m_viewID;

	private PhotonPlayer m_owner;

	[NonSerialized]
	public List<Pair<Hashtable, PhotonPlayer>> bufferedRPC;

	public int group;

	public int prefixBackup = -1;

	public int m_priority;

	public int m_priorityRunTime;

	[NonSerialized]
	public bool preInstantiate;

	[NonSerialized]
	public bool firstSent = true;

	private object[] instantiationDataField;

	protected internal Dictionary<PhotonPlayer, object[]> lastOnSerializeDataSentPerPlayer = new Dictionary<PhotonPlayer, object[]>();

	protected internal Dictionary<PhotonPlayer, Hashtable> lastOnSerializeDataRecvPerPlayer = new Dictionary<PhotonPlayer, Hashtable>();

	protected internal Dictionary<PhotonPlayer, double> m_lastUpdateTimePerPlayer = new Dictionary<PhotonPlayer, double>();

	protected internal Dictionary<PhotonPlayer, double> m_updateIntervalPerPlayer = new Dictionary<PhotonPlayer, double>();

	protected internal BolBitArray m_compressedBit;

	protected internal Dictionary<PhotonPlayer, BolBitArray> accCompressedBitRecvPerPlayer = new Dictionary<PhotonPlayer, BolBitArray>();

	protected internal Hashtable lastOnSerializeDataReceived;

	protected internal object[] lastOnSerializeSentFullData;

	protected internal object[] lastOnSerializeSentCmpsData;

	public double lastTimeDataSend;

	public Component observed;

	public SynchronizationDir synchronizationDir;

	public ViewSynchronization synchronization;

	public OnSerializeTransform onSerializeTransformOption = OnSerializeTransform.PositionAndRotation;

	public OnSerializeRigidBody onSerializeRigidBodyOption = OnSerializeRigidBody.All;

	private PhotonStream m_outStream = new PhotonStream(true, c5045159a57582d4577b6fa1bce364dca.c7088de59e49f7108f520cf7e0bae167e);

	private PhotonMessageInfo m_outMessageInfo;

	private Hashtable m_outEventData = new Hashtable();

	private object[] m_fullContent;

	private object[] m_compressedContent;

	private int m_compressedNum;

	private List<int> valuesThatAreChangedToNull = new List<int>();

	private bool m_somethingLeftToSend;

	public int instantiationId;

	private bool didAwake;

	protected internal bool destroyedByPhotonNetworkOrQuit;

	public int grossSerializeSize;

	public int grossRPCSize;

	public Dictionary<string, int> sizePerMethod = new Dictionary<string, int>();

	public int grossSerializeSizeRCV;

	public int grossRPCSizeRCV;

	public Dictionary<string, int> sizePerMethodRCV = new Dictionary<string, int>();

	public int c26bc9278762c84e1e76177f085674c7e
	{
		get
		{
			if (prefixBackup == -1)
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
				if (PhotonNetwork.networkingPeer != null)
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
					prefixBackup = PhotonNetwork.networkingPeer.currentLevelPrefix;
				}
			}
			return prefixBackup;
		}
		set
		{
			prefixBackup = value;
		}
	}

	public object[] c332524fa6b5f6c2dfdb5f39c56de7f45
	{
		get
		{
			if (!didAwake)
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
				instantiationDataField = PhotonNetwork.networkingPeer.cf9db7686d6df61be354660a9684790c6(instantiationId);
			}
			return instantiationDataField;
		}
		set
		{
			instantiationDataField = value;
		}
	}

	public int ce57f12a4f7e693a5fe0c4049dc56fa7c
	{
		get
		{
			return m_viewID;
		}
		set
		{
			int num;
			if (didAwake)
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
				num = ((subId == 0) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			ownerId = value / PhotonNetwork.MAX_VIEW_IDS;
			subId = value % PhotonNetwork.MAX_VIEW_IDS;
			m_viewID = ownerId * PhotonNetwork.MAX_VIEW_IDS + subId;
			if (!flag)
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
				PhotonNetwork.networkingPeer.c4417d094281af564a587065a579930ba(this);
				return;
			}
		}
	}

	public bool c4888a6d1dea202176b2cd777ad28f3a6
	{
		get
		{
			return ownerId == 0;
		}
	}

	public PhotonPlayer c706ea4155b03100282fe553e4d0be557
	{
		get
		{
			if (m_owner == null)
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
				m_owner = PhotonPlayer.cc896fd68f9e2e6f38fa11555857a60c8(ownerId);
			}
			return m_owner;
		}
	}

	public int c60085480ef91f270ea43e325ca766ead
	{
		get
		{
			return ownerId;
		}
	}

	public bool c6971afb2ced2e6c56d327fce1c3bca83
	{
		get
		{
			int result;
			if (ownerId != PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3)
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
				if (c4888a6d1dea202176b2cd777ad28f3a6)
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
					result = (PhotonNetwork.ca3052869987fcf5688487de12414faab ? 1 : 0);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public int c82aa1e6f06bc147778156b8e1e96e1d8
	{
		get
		{
			return grossSerializeSize + grossRPCSize;
		}
		private set
		{
		}
	}

	public int c1097797f47f6121a2daef2c9d735cf19
	{
		get
		{
			return grossSerializeSizeRCV + grossRPCSizeRCV;
		}
		private set
		{
		}
	}

	public int cc484401d276ed0c9292ee082b8c8fb1d(PhotonPlayer cbc409c28882b371b394d25bd4774efa0)
	{
		if (cbc409c28882b371b394d25bd4774efa0 != null)
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
			if (m_lastUpdateTimePerPlayer.ContainsKey(cbc409c28882b371b394d25bd4774efa0))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return (int)(((double)Time.time - m_lastUpdateTimePerPlayer[cbc409c28882b371b394d25bd4774efa0]) * 1000.0);
					}
				}
			}
		}
		return int.MaxValue;
	}

	public int c6694c55e257135c6953443da4001d4ff(PhotonPlayer cbc409c28882b371b394d25bd4774efa0)
	{
		if (cbc409c28882b371b394d25bd4774efa0 != null)
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
			if (m_updateIntervalPerPlayer.ContainsKey(cbc409c28882b371b394d25bd4774efa0))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return (int)(m_updateIntervalPerPlayer[cbc409c28882b371b394d25bd4774efa0] * 1000.0);
					}
				}
			}
		}
		return int.MaxValue;
	}

	public void Awake()
	{
		m_viewID = ownerId * PhotonNetwork.MAX_VIEW_IDS + subId;
		PhotonNetwork.networkingPeer.c4417d094281af564a587065a579930ba(this);
		instantiationDataField = PhotonNetwork.networkingPeer.cf9db7686d6df61be354660a9684790c6(instantiationId);
		didAwake = true;
		bufferedRPC = new List<Pair<Hashtable, PhotonPlayer>>();
		preInstantiate = false;
		if (observed is IPhotonView)
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
			IPhotonView photonView = (IPhotonView)observed;
			if (photonView.photonView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				photonView.photonView = this;
			}
		}
		m_outMessageInfo = new PhotonMessageInfo(PhotonNetwork.networkingPeer.mLocalActor, PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds, this);
	}

	public void OnApplicationQuit()
	{
		destroyedByPhotonNetworkOrQuit = true;
	}

	public void OnDestroy()
	{
		PhotonNetwork.networkingPeer.c97ffe8eafefa0eb594f4fc597de59226(this);
		if (!destroyedByPhotonNetworkOrQuit)
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
			if (!Application.isLoadingLevel)
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
				if (instantiationId > 0)
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
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array[0] = "OnDestroy() seems to be called without PhotonNetwork.Destroy()?! GameObject: ";
					array[1] = base.gameObject;
					array[2] = " Application.isLoadingLevel: ";
					array[3] = Application.isLoadingLevel;
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
				}
				else if (ce57f12a4f7e693a5fe0c4049dc56fa7c <= 0)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, string.Format("OnDestroy manually allocated PhotonView {0}. The viewID is 0. Was it ever (manually) set?", this));
				}
				else if (c6971afb2ced2e6c56d327fce1c3bca83)
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
					if (!PhotonNetwork.manuallyAllocatedViewIds.Contains(ce57f12a4f7e693a5fe0c4049dc56fa7c))
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, string.Format("OnDestroy manually allocated PhotonView {0}. The viewID is local (isMine) but not in manuallyAllocatedViewIds list. Use UnAllocateViewID() after you destroyed the PV.", this));
					}
				}
			}
		}
		if (!PhotonNetwork.networkingPeer.instantiatedObjects.ContainsKey(instantiationId))
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
			object arg = instantiationId;
			object arg2;
			if (Application.isLoadingLevel)
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
				arg2 = "Loading new scene caused this.";
			}
			else
			{
				arg2 = string.Empty;
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, string.Format("OnDestroy for PhotonView {0} but GO is still in instantiatedObjects. instantiationId: {1}. Use PhotonNetwork.Destroy(). {2}", this, arg, arg2));
			return;
		}
	}

	public void c19fd12ed98be2a9174d53644dc9757c8(string ca57789de86459caf1b0cd284afe32a38, PhotonTargets c82fcbab5e578dc3a31c1f662916bd87e, bool c975f237222e991e51b0b1732262bfdfa, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		PhotonNetwork.c19fd12ed98be2a9174d53644dc9757c8(this, ca57789de86459caf1b0cd284afe32a38, c82fcbab5e578dc3a31c1f662916bd87e, c975f237222e991e51b0b1732262bfdfa, c90ecb087828ed9ceb9c00eafb6d52f4c);
	}

	public void c19fd12ed98be2a9174d53644dc9757c8(string ca57789de86459caf1b0cd284afe32a38, PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab8, bool c975f237222e991e51b0b1732262bfdfa, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		PhotonNetwork.c19fd12ed98be2a9174d53644dc9757c8(this, ca57789de86459caf1b0cd284afe32a38, c8bb3a6115f009b6d03350a85a41ecab8, c975f237222e991e51b0b1732262bfdfa, c90ecb087828ed9ceb9c00eafb6d52f4c);
	}

	public void c19fd12ed98be2a9174d53644dc9757c8(string ca57789de86459caf1b0cd284afe32a38, PhotonTargets c82fcbab5e578dc3a31c1f662916bd87e, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		PhotonNetwork.c19fd12ed98be2a9174d53644dc9757c8(this, ca57789de86459caf1b0cd284afe32a38, c82fcbab5e578dc3a31c1f662916bd87e, true, c90ecb087828ed9ceb9c00eafb6d52f4c);
	}

	public void c19fd12ed98be2a9174d53644dc9757c8(string ca57789de86459caf1b0cd284afe32a38, PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab8, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		PhotonNetwork.c19fd12ed98be2a9174d53644dc9757c8(this, ca57789de86459caf1b0cd284afe32a38, c8bb3a6115f009b6d03350a85a41ecab8, true, c90ecb087828ed9ceb9c00eafb6d52f4c);
	}

	public static PhotonView c588e7dbcd383d8230b2d83d7b44af23b(Component c07d89e791d9882e4345ad1040077b340)
	{
		return c07d89e791d9882e4345ad1040077b340.GetComponent<PhotonView>();
	}

	public static PhotonView c588e7dbcd383d8230b2d83d7b44af23b(GameObject c044b40b02788dbb0c05ed0d774a93786)
	{
		return c044b40b02788dbb0c05ed0d774a93786.GetComponent<PhotonView>();
	}

	public static PhotonView cc896fd68f9e2e6f38fa11555857a60c8(int ce57f12a4f7e693a5fe0c4049dc56fa7c)
	{
		return PhotonNetwork.networkingPeer.cf3f639d9f53429a8af80536a64470f83(ce57f12a4f7e693a5fe0c4049dc56fa7c);
	}

	public override string ToString()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = ce57f12a4f7e693a5fe0c4049dc56fa7c;
		array[1] = base.gameObject.name;
		object obj;
		if (c4888a6d1dea202176b2cd777ad28f3a6)
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
			obj = "(scene)";
		}
		else
		{
			obj = string.Empty;
		}
		array[2] = obj;
		array[3] = c26bc9278762c84e1e76177f085674c7e;
		return string.Format("View ({3}){0} on {1} {2}", array);
	}

	public bool c6de514d9171b3e8447c88ef03e6c1f57()
	{
		return !m_outStream.c0c94263e548501b400c7350444d3fe35();
	}

	public void c99624460050f8ad93a15b773f70fe6aa()
	{
		m_outStream.cac7688b05e921e2be3f92479ba44b4a8();
	}

	public void OnSerializeToStream()
	{
		m_outStream.cac7688b05e921e2be3f92479ba44b4a8();
		if (observed is IPhotonSerializeView)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_outMessageInfo.c20b8dda8cbcdfbbc16c4d332102c641e();
					IPhotonSerializeView photonSerializeView = (IPhotonSerializeView)observed;
					photonSerializeView.OnPhotonSerializeView(m_outStream, m_outMessageInfo);
					if (m_outStream.c9a57a1c6eac92cceec2de50aa04e4757 == 0)
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
					return;
				}
				}
			}
		}
		if (observed is UnityEngine.MonoBehaviour)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					UnityEngine.MonoBehaviour c00c5a51bf36801ca184ca18e0ccea = (UnityEngine.MonoBehaviour)observed;
					m_outMessageInfo.c20b8dda8cbcdfbbc16c4d332102c641e();
					PhotonNetwork.networkingPeer.c7e607af4052ac0565f3255f8289253b6(c00c5a51bf36801ca184ca18e0ccea, m_outStream, m_outMessageInfo);
					if (m_outStream.c9a57a1c6eac92cceec2de50aa04e4757 == 0)
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
					return;
				}
				}
			}
		}
		if (observed is Transform)
		{
			while (true)
			{
				Transform transform;
				switch (1)
				{
				case 0:
					break;
				default:
					{
						transform = (Transform)observed;
						if (onSerializeTransformOption != 0)
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
							if (onSerializeTransformOption != OnSerializeTransform.PositionAndRotation)
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
								if (onSerializeTransformOption != OnSerializeTransform.All)
								{
									m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
									goto IL_015f;
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
						m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(transform.localPosition);
						goto IL_015f;
					}
					IL_01c2:
					if (onSerializeTransformOption != OnSerializeTransform.OnlyScale)
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
						if (onSerializeTransformOption != OnSerializeTransform.All)
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
							break;
						}
					}
					m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(transform.localScale);
					return;
					IL_015f:
					if (onSerializeTransformOption != OnSerializeTransform.OnlyRotation)
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
						if (onSerializeTransformOption != OnSerializeTransform.PositionAndRotation)
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
							if (onSerializeTransformOption != OnSerializeTransform.All)
							{
								m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
								goto IL_01c2;
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
					}
					m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(transform.localRotation);
					goto IL_01c2;
				}
			}
		}
		if (observed is Rigidbody)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					Rigidbody rigidbody = (Rigidbody)observed;
					if (onSerializeRigidBodyOption != OnSerializeRigidBody.OnlyAngularVelocity)
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
						m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(rigidbody.velocity);
					}
					else
					{
						m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
					}
					if (onSerializeRigidBodyOption != 0)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								m_outStream.caf7283cc5cd9725a88a9cdfa630d92f8(rigidbody.angularVelocity);
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Observed type is not serializable: " + observed.GetType());
	}

	public void OnSerializeWrite()
	{
		if (m_outStream.c0c94263e548501b400c7350444d3fe35())
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
			m_fullContent = m_outStream.data.ToArray();
			m_compressedNum = 0;
			m_somethingLeftToSend = true;
			if (m_compressedBit == null)
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
				m_compressedBit = new BolBitArray(m_fullContent.Length);
			}
			m_compressedBit.cd660fc4a18e29ee0236e3ea00091100a();
			if (synchronization != ViewSynchronization.ReliableDeltaCompressed)
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
				if (synchronization != ViewSynchronization.UnreliableDeltaCompressed)
				{
					goto IL_00b5;
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
			m_somethingLeftToSend = c83bbd0a1c3b4a63ee5e703bfe1c39832(m_fullContent);
			goto IL_00b5;
			IL_00b5:
			if (!m_somethingLeftToSend)
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
			lastTimeDataSend = Time.time;
			lastOnSerializeSentFullData = m_fullContent;
			return;
		}
	}

	public void ce7224fe810211212d4efda44323c8acd(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		BolBitArray value;
		if (accCompressedBitRecvPerPlayer.TryGetValue(ceb41162a7cd2a1d5c4a03830e02b4198, out value))
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
					value.caa9aa059f6d3891c4e705025ceae72f8(m_compressedBit);
					return;
				}
			}
		}
		accCompressedBitRecvPerPlayer[ceb41162a7cd2a1d5c4a03830e02b4198] = m_compressedBit.c6247b97516f0f47835aa21a8285ce7e5();
	}

	public Hashtable c286c8ba4a1de9af2c2d0ed5b33e6f9f2()
	{
		m_outEventData.Clear();
		m_outEventData[(byte)0] = m_viewID;
		m_outEventData[(byte)1] = m_fullContent;
		return m_outEventData;
	}

	public Hashtable c7e614d8d6b76bb3757d65a2fa141a4f5()
	{
		m_outEventData.Clear();
		if (m_somethingLeftToSend)
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
			m_outEventData[(byte)0] = m_viewID;
			if (m_compressedNum == 0)
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
				m_outEventData[(byte)1] = m_fullContent;
			}
			else
			{
				m_outEventData[(byte)2] = m_compressedContent;
				if (valuesThatAreChangedToNull.Count != 0)
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
					m_outEventData[(byte)3] = valuesThatAreChangedToNull.ToArray();
				}
			}
		}
		return m_outEventData;
	}

	public Hashtable c6c0b3fb0659036072b3905bd91be4cdf(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198, bool c5a0c40c126dd91c144b0bfd17d067a04)
	{
		m_outEventData.Clear();
		if (!m_somethingLeftToSend)
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
			if (!c5a0c40c126dd91c144b0bfd17d067a04)
			{
				goto IL_0192;
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
		m_outEventData[(byte)0] = m_viewID;
		if (!c5a0c40c126dd91c144b0bfd17d067a04)
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
			if (m_compressedNum != 0)
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
				if (accCompressedBitRecvPerPlayer[ceb41162a7cd2a1d5c4a03830e02b4198].c2597b50d417a76d0f3a2da9e6a95337b(m_compressedBit))
				{
					m_outEventData[(byte)2] = m_compressedContent;
					if (valuesThatAreChangedToNull.Count != 0)
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
						m_outEventData[(byte)3] = valuesThatAreChangedToNull.ToArray();
					}
					goto IL_00ff;
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
		m_outEventData[(byte)1] = m_fullContent;
		goto IL_00ff;
		IL_00ff:
		if (accCompressedBitRecvPerPlayer[ceb41162a7cd2a1d5c4a03830e02b4198].size != m_compressedBit.size)
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
			accCompressedBitRecvPerPlayer[ceb41162a7cd2a1d5c4a03830e02b4198].cdf9bd484c34b28bc08efb156117d4c00(m_compressedBit.size);
		}
		accCompressedBitRecvPerPlayer[ceb41162a7cd2a1d5c4a03830e02b4198].cf45e42101e33efef33d634d1d0a308e3();
		if (PhotonNetwork.networkingPeer.TrafficStatsEnabled)
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
			grossSerializeSize += Utils.c48ad35a6532e0c5642de63db021aab5a(m_outEventData);
		}
		goto IL_0192;
		IL_0192:
		return m_outEventData;
	}

	public void OnSerializeRead(Hashtable data, PhotonPlayer sender, int networkTime, short correctPrefix)
	{
		if (c26bc9278762c84e1e76177f085674c7e > 0)
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
			if (correctPrefix != c26bc9278762c84e1e76177f085674c7e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
						array[0] = "Received OnSerialization for view ID ";
						array[1] = ce57f12a4f7e693a5fe0c4049dc56fa7c;
						array[2] = " with prefix ";
						array[3] = correctPrefix;
						array[4] = ". Our prefix is ";
						array[5] = c26bc9278762c84e1e76177f085674c7e;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
						return;
					}
					}
				}
			}
		}
		if (!preInstantiate)
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
			if (group != 0)
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
				if (!PhotonNetwork.networkingPeer.allowedReceivingGroups.Contains(group))
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
		if (PhotonNetwork.networkingPeer.TrafficStatsEnabled)
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
			grossSerializeSizeRCV += Utils.c48ad35a6532e0c5642de63db021aab5a(data);
		}
		if (!c9ad96d84f89d174888932c7655d71a0b(this, sender, data))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array2[0] = "Skipping packet for ";
					array2[1] = base.name;
					array2[2] = " [";
					array2[3] = ce57f12a4f7e693a5fe0c4049dc56fa7c;
					array2[4] = "] as we haven't received a full packet for delta compression yet. This is OK if it happens for the first few frames after joining a game.";
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array2));
					return;
				}
				}
			}
		}
		lastOnSerializeDataReceived = data;
		if (sender != null)
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
			lastOnSerializeDataRecvPerPlayer[sender] = data;
		}
		if (observed is IPhotonSerializeView)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					object[] cc06f5ba84af5d3e05231605132ca = data[(byte)1] as object[];
					PhotonStream stream = new PhotonStream(false, cc06f5ba84af5d3e05231605132ca);
					PhotonMessageInfo info = new PhotonMessageInfo(sender, networkTime, this);
					IPhotonSerializeView photonSerializeView = (IPhotonSerializeView)observed;
					photonSerializeView.OnPhotonSerializeView(stream, info);
					return;
				}
				}
			}
		}
		if (observed is UnityEngine.MonoBehaviour)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					object[] cc06f5ba84af5d3e05231605132ca2 = data[(byte)1] as object[];
					UnityEngine.MonoBehaviour c00c5a51bf36801ca184ca18e0ccea = (UnityEngine.MonoBehaviour)observed;
					PhotonStream c3b767e219cd722522367d9d5e52f00a = new PhotonStream(false, cc06f5ba84af5d3e05231605132ca2);
					PhotonMessageInfo c00bb86ffbeb6764fbe60d7b64859db7f = new PhotonMessageInfo(sender, networkTime, this);
					PhotonNetwork.networkingPeer.c7e607af4052ac0565f3255f8289253b6(c00c5a51bf36801ca184ca18e0ccea, c3b767e219cd722522367d9d5e52f00a, c00bb86ffbeb6764fbe60d7b64859db7f);
					return;
				}
				}
			}
		}
		if (observed is Transform)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					object[] array3 = data[(byte)1] as object[];
					Transform transform = (Transform)observed;
					if (array3.Length >= 1)
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
						if (array3[0] != null)
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
							transform.localPosition = (Vector3)array3[0];
						}
					}
					if (array3.Length >= 2)
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
						if (array3[1] != null)
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
							transform.localRotation = (Quaternion)array3[1];
						}
					}
					if (array3.Length >= 3)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								if (array3[2] != null)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											transform.localScale = (Vector3)array3[2];
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		if (observed is Rigidbody)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					object[] array4 = data[(byte)1] as object[];
					Rigidbody rigidbody = (Rigidbody)observed;
					if (array4.Length >= 1)
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
						if (array4[0] != null)
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
							rigidbody.velocity = (Vector3)array4[0];
						}
					}
					if (array4.Length >= 2)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								if (array4[1] != null)
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											rigidbody.angularVelocity = (Vector3)array4[1];
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		if (preInstantiate)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Type of observed is unknown when receiving.");
			return;
		}
	}

	private bool c83bbd0a1c3b4a63ee5e703bfe1c39832(object[] c591d56a94543e3559945c497f37126c4)
	{
		m_compressedNum = 0;
		if (lastOnSerializeSentFullData == null)
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
				return true;
			}
		}
		object[] array = lastOnSerializeSentFullData;
		if (c591d56a94543e3559945c497f37126c4 == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return false;
			}
		}
		if (array.Length != c591d56a94543e3559945c497f37126c4.Length)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				m_compressedBit.cdf9bd484c34b28bc08efb156117d4c00(c591d56a94543e3559945c497f37126c4.Length);
				return true;
			}
		}
		if (m_compressedContent != null)
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
			if (c591d56a94543e3559945c497f37126c4.Length == m_compressedContent.Length)
			{
				goto IL_0097;
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
		m_compressedContent = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(c591d56a94543e3559945c497f37126c4.Length);
		goto IL_0097;
		IL_0097:
		Array.Clear(m_compressedContent, 0, m_compressedContent.Length);
		valuesThatAreChangedToNull.Clear();
		for (int i = 0; i < m_compressedContent.Length; i++)
		{
			object obj = c591d56a94543e3559945c497f37126c4[i];
			object c1444c3ec10ef341ecd4f6247b = array[i];
			if (cf2dc852cbf0274577dab9b8d1236b7a7(obj, c1444c3ec10ef341ecd4f6247b))
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
				m_compressedNum++;
				m_compressedBit.cd1109b7ea29846a9735888dcb26a97fe(i, false);
				continue;
			}
			m_compressedContent[i] = c591d56a94543e3559945c497f37126c4[i];
			if (obj != null)
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
			valuesThatAreChangedToNull.Add(i);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (m_compressedNum > 0)
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
				if (m_compressedNum == c591d56a94543e3559945c497f37126c4.Length)
				{
					while (true)
					{
						switch (1)
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
	}

	private bool c9ad96d84f89d174888932c7655d71a0b(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, PhotonPlayer c979ec2891bdf45f616bb8a2b2b7051d5, Hashtable c591d56a94543e3559945c497f37126c4)
	{
		if (c591d56a94543e3559945c497f37126c4.ContainsKey((byte)1))
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
					return true;
				}
			}
		}
		if (ca4187010cdd35921f11dd5df8ccc23e3.lastOnSerializeDataRecvPerPlayer.ContainsKey(c979ec2891bdf45f616bb8a2b2b7051d5))
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
			if (ca4187010cdd35921f11dd5df8ccc23e3.lastOnSerializeDataRecvPerPlayer[c979ec2891bdf45f616bb8a2b2b7051d5] != null)
			{
				object[] array = c591d56a94543e3559945c497f37126c4[(byte)2] as object[];
				if (array == null)
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
				int[] array2 = c591d56a94543e3559945c497f37126c4[(byte)3] as int[];
				if (array2 == null)
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
					array2 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(0);
				}
				object[] array3 = ca4187010cdd35921f11dd5df8ccc23e3.lastOnSerializeDataRecvPerPlayer[c979ec2891bdf45f616bb8a2b2b7051d5][(byte)1] as object[];
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null)
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
					if (array2.c1a84901a0a9ec83a0000feb026941d27(i))
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
					object obj = array3[i];
					array[i] = obj;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					c591d56a94543e3559945c497f37126c4[(byte)1] = array;
					return true;
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
		return false;
	}

	private bool cf2dc852cbf0274577dab9b8d1236b7a7(object ca3d8e9d8aa8654004cb491578986b996, object c1444c3ec10ef341ecd4f6247b3922171)
	{
		if (ca3d8e9d8aa8654004cb491578986b996 != null)
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
			if (c1444c3ec10ef341ecd4f6247b3922171 != null)
			{
				if (!ca3d8e9d8aa8654004cb491578986b996.Equals(c1444c3ec10ef341ecd4f6247b3922171))
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							if (ca3d8e9d8aa8654004cb491578986b996 is Vector3)
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
								Vector3 c82fcbab5e578dc3a31c1f662916bd87e = (Vector3)ca3d8e9d8aa8654004cb491578986b996;
								Vector3 cb3d2bffae21da96491575e42414232f = (Vector3)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f, PhotonNetwork.precisionForVectorSynchronization))
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							else if (ca3d8e9d8aa8654004cb491578986b996 is Vector2)
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
								Vector2 c82fcbab5e578dc3a31c1f662916bd87e2 = (Vector2)ca3d8e9d8aa8654004cb491578986b996;
								Vector2 cb3d2bffae21da96491575e42414232f2 = (Vector2)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e2.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f2, PhotonNetwork.precisionForVectorSynchronization))
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							else if (ca3d8e9d8aa8654004cb491578986b996 is Quaternion)
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
								Quaternion c82fcbab5e578dc3a31c1f662916bd87e3 = (Quaternion)ca3d8e9d8aa8654004cb491578986b996;
								Quaternion cb3d2bffae21da96491575e42414232f3 = (Quaternion)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e3.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f3, PhotonNetwork.precisionForVectorSynchronization))
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							else if (ca3d8e9d8aa8654004cb491578986b996 is float)
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
								float c82fcbab5e578dc3a31c1f662916bd87e4 = (float)ca3d8e9d8aa8654004cb491578986b996;
								float cb3d2bffae21da96491575e42414232f4 = (float)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e4.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f4, PhotonNetwork.precisionForFloatSynchronization))
								{
									while (true)
									{
										switch (4)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							return false;
						}
					}
				}
				return true;
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
		int result;
		if (ca3d8e9d8aa8654004cb491578986b996 == null)
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
			result = ((c1444c3ec10ef341ecd4f6247b3922171 == c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private void Update()
	{
		if (!(observed is IPhotonView))
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
			IPhotonView photonView = (IPhotonView)observed;
			if (!(photonView.photonView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				photonView.photonView = this;
				return;
			}
		}
	}

	public void c527d35a2bd1b8768af0cd94afeb762c5(string c7cdae6930a0074ceafa28c263abc80df, int cb413b63b20e71ae5c504b03471480e2a)
	{
		grossRPCSize += cb413b63b20e71ae5c504b03471480e2a;
		if (sizePerMethod.ContainsKey(c7cdae6930a0074ceafa28c263abc80df))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Dictionary<string, int> dictionary;
					Dictionary<string, int> dictionary2 = (dictionary = sizePerMethod);
					string key;
					string key2 = (key = c7cdae6930a0074ceafa28c263abc80df);
					int num = dictionary[key];
					dictionary2[key2] = num + cb413b63b20e71ae5c504b03471480e2a;
					return;
				}
				}
			}
		}
		sizePerMethod[c7cdae6930a0074ceafa28c263abc80df] = cb413b63b20e71ae5c504b03471480e2a;
	}

	public void ce1069b29dba97bf009b3c40b7b989382(string c7cdae6930a0074ceafa28c263abc80df, int cb413b63b20e71ae5c504b03471480e2a)
	{
		grossRPCSizeRCV += cb413b63b20e71ae5c504b03471480e2a;
		if (sizePerMethod.ContainsKey(c7cdae6930a0074ceafa28c263abc80df))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Dictionary<string, int> dictionary;
					Dictionary<string, int> dictionary2 = (dictionary = sizePerMethodRCV);
					string key;
					string key2 = (key = c7cdae6930a0074ceafa28c263abc80df);
					int num = dictionary[key];
					dictionary2[key2] = num + cb413b63b20e71ae5c504b03471480e2a;
					return;
				}
				}
			}
		}
		sizePerMethodRCV[c7cdae6930a0074ceafa28c263abc80df] = cb413b63b20e71ae5c504b03471480e2a;
	}

	public bool c201e69461401637f68794a86ca99b782()
	{
		int result;
		if (base.enabled)
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
			if (synchronization != 0)
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
				result = ((observed != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
				goto IL_0044;
			}
		}
		result = 0;
		goto IL_0044;
		IL_0044:
		return (byte)result != 0;
	}
}
