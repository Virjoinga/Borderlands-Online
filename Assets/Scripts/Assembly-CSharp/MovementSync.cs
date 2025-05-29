using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class MovementSync : MonoBehaviour, IPhotonView, IPhotonSerializeView, IPhotonEvaluate
{
	private class TeleportRequest
	{
		public Vector3 m_pos;

		public Quaternion m_rot;

		public TeleportRequest(Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48)
		{
			m_pos = c330987c4414f384d6c951ab9f68460d8;
			m_rot = c2a8e8b393b40d6cde9e5177c7a9adb48;
		}
	}

	public enum BlendingType
	{
		Perpendicular = 0,
		Simple = 1,
		None = 2
	}

	[HideInInspector]
	public float m_animationTime;

	[HideInInspector]
	public float m_speed;

	[HideInInspector]
	public float m_turnAngle;

	public bool m_debug;

	public bool drawHostTP = true;

	public bool drawClientTP = true;

	public bool drawExtraClientTP = true;

	public bool m_correctingPos = true;

	private RingBuffer m_clientTimePos;

	private RingBuffer m_hostTimePos;

	private RingBuffer m_clientOfHostTimePos;

	private RingBuffer m_extrapolatedBuffer;

	private Entity m_entity;

	private double m_lastHostNetworkTime;

	private TimePos m_lastProcessedHostTP;

	private IBadAssCharacterMotor m_characterMotor;

	private InterpolateManager m_interpolater;

	public int lastEvaluatedPriority;

	private List<TeleportRequest> m_teleportRequests = new List<TeleportRequest>();

	public BlendingType m_blendingType;

	private IMvtSyncListener m_listener;

	private Vector3 correctPlayerPos = Vector3.zero;

	private Quaternion correctPlayerRot = Quaternion.identity;

	private double m_lastRecvClientTime;

	public double m_serverPackThreshold = 0.20000000298023224;

	public float m_disThreshold = 0.2f;

	public float m_blendfactor = 0.2f;

	public float m_MaxDisByBlend = 1f;

	private Vector3 myPosAtServerTime;

	public bool m_enableMoveLog;

	public bool m_enableMoveLine;

	public bool m_enableFallProtection;

	private bool m_followServerMovement;

	public float m_LastCorrectDis;

	private bool m_teleporting;

	private float m_teleportTimeStamp;

	private double m_teleportNetworkTimeStamp;

	private int offset;

	public PhotonView photonView { get; set; }

	public Vector3 localVelocity { get; private set; }

	public Vector3 Velocity { get; private set; }

	public float c1d076d8aaabeb171d01b8502d3217ec0
	{
		get
		{
			return m_interpolater.c301abaf24d40e2b3ae13b805bee85325() / 2f;
		}
		private set
		{
			c1d076d8aaabeb171d01b8502d3217ec0 = value;
		}
	}

	public MovementSync()
	{
		Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		myPosAtServerTime = c36964cf41281414170f34ee68bef6c;
		m_enableFallProtection = true;
		m_followServerMovement = true;
		base._002Ector();
	}

	public Vector3 c2bd9fae70103c995b0a0530f39169e62()
	{
		return Velocity;
	}

	private void Awake()
	{
		m_clientTimePos = new RingBuffer(3000, true);
		m_hostTimePos = new RingBuffer(300, true);
		m_clientOfHostTimePos = new RingBuffer(300, true);
		m_interpolater = new InterpolateManager(this, c8acd8065691c036d0349f7e79249bf8d.c7088de59e49f7108f520cf7e0bae167e);
		m_extrapolatedBuffer = new RingBuffer(300, true);
	}

	private void Start()
	{
		m_entity = GetComponent<Entity>();
		m_characterMotor = (IBadAssCharacterMotor)GetComponent(Type.GetTypeFromHandle(ccb2c22bcfee08b93405b7f92e89d5415.cc1720d05c75832f704b87474932341c3()));
		if (!NetworkManager.c00c3ec658bbd0ff2568a3b72647806e1())
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
			if (photonView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!photonView.c6971afb2ced2e6c56d327fce1c3bca83)
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
					myPosAtServerTime = correctPlayerPos;
				}
			}
		}
		m_interpolater.c93dfb7ce3d15c238cd4b633889858ffb(m_entity.c9b6d1d87bef7b03dad787ff0031551ee());
	}

	public byte c4bf858e68ee07ec82395a0cfc6da6def(EntityPlayer cc292a78271891d4e9a7145978b66846f)
	{
		if (cc292a78271891d4e9a7145978b66846f == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (cc292a78271891d4e9a7145978b66846f.cbe65aaa5561a0ba002aca1f0c8498077() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		byte b = 0;
		if (cc292a78271891d4e9a7145978b66846f.cbe65aaa5561a0ba002aca1f0c8498077().cb261500372fa488b369e9159a002977a())
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
			b = (byte)(b | 1u);
		}
		if (cc292a78271891d4e9a7145978b66846f.cbe65aaa5561a0ba002aca1f0c8498077().c7201a6224668404b44ad10a24fe68d67())
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
			b = (byte)(b | 0x40u);
		}
		if (cc292a78271891d4e9a7145978b66846f.cbe65aaa5561a0ba002aca1f0c8498077().c8cc0ce1bacf416fdd879d1e63947960f())
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
			b = (byte)(b | 2u);
		}
		if (cc292a78271891d4e9a7145978b66846f.cbe65aaa5561a0ba002aca1f0c8498077().cdc79bb1740f1c70185840b061137dea8())
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
			b = (byte)(b | 4u);
		}
		if (cc292a78271891d4e9a7145978b66846f.cbe65aaa5561a0ba002aca1f0c8498077().c4d927c91307ef767ba359c476291c950())
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
			b = (byte)(b | 0x80u);
		}
		return b;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					EntityPlayer entityPlayer = m_entity as EntityPlayer;
					if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entityPlayer.cd95354b53e674ec7dc9594e66e4d316f() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
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
					if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().c2d17ea39faa888e633ce06615ddf5c6a != PlayerInfoSync.PlayerState.Spawned)
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
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(base.transform.position);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8((short)(base.transform.localEulerAngles.y * 100f));
					if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								stream.caf7283cc5cd9725a88a9cdfa630d92f8(entityPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum);
								stream.caf7283cc5cd9725a88a9cdfa630d92f8(c4bf858e68ee07ec82395a0cfc6da6def(entityPlayer));
								stream.caf7283cc5cd9725a88a9cdfa630d92f8((short)entityPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_pitch16);
								return;
							}
						}
					}
					if (m_entity is EntityNpc)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								stream.caf7283cc5cd9725a88a9cdfa630d92f8((short)(m_animationTime * 100f));
								stream.caf7283cc5cd9725a88a9cdfa630d92f8((short)(m_speed * 100f));
								stream.caf7283cc5cd9725a88a9cdfa630d92f8((short)(m_turnAngle * 100f));
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		correctPlayerPos = (Vector3)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		short num = (short)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		float y = (ushort)num / 100;
		int c54c75a1eaccb56ae03a0d1c56438d1d = 0;
		byte b = 0;
		short num2 = 0;
		EntityPlayer entityPlayer2 = m_entity as EntityPlayer;
		if (entityPlayer2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c54c75a1eaccb56ae03a0d1c56438d1d = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			b = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			num2 = (short)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			if (!entityPlayer2.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
				((PlayerThirdPersonAnimationManagerFSM)entityPlayer2.cb8119a2676bfbd4df00a9ed683eed91a()).ceb2fe0373fe25e1666c9c5232f2fc11c(b, num2);
			}
		}
		else if (m_entity is EntityNpc)
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
			short num3 = (short)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_animationTime = (ushort)num3 / 100;
			num3 = (short)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_speed = (ushort)num3 / 100;
			num3 = (short)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_turnAngle = (float)num3 / 100f;
		}
		correctPlayerRot = Quaternion.Euler(0f, y, 0f);
		m_lastRecvClientTime = Time.time;
		TimePos timePos = new TimePos(m_lastRecvClientTime, correctPlayerPos, correctPlayerRot, info.c24d168bafd94cfd3e438faef12da2b5c, c54c75a1eaccb56ae03a0d1c56438d1d);
		TimePos timePos2 = (TimePos)m_hostTimePos.cef0e77f01549f5bca5df565d45cc1a90();
		if (timePos2 != null)
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
			if (timePos2.m_frameNum == timePos.m_frameNum)
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
				if (timePos2.m_networkTimeStamp == timePos.m_networkTimeStamp)
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
		}
		if (timePos.m_networkTimeStamp < m_teleportNetworkTimeStamp)
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
		m_hostTimePos.cd6aca5b3793f791cfc489609e675c90b(timePos);
		m_interpolater.OnNewTPArrived(timePos);
	}

	public void OnPhotonEvaluate(PhotonPlayer player, ref PhotonPriority priority)
	{
		Session c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86;
		if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c5ee19dc8d4cccf5ae2de225410458b.c45c9d44751117fd2457b8e19283bfa51())
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
				PlayerInfoSync playerInfoSync = c5ee19dc8d4cccf5ae2de225410458b.cb062638207d3746ee631744a4709b38f(player.c29a834d12d3895f5680e69a30e6cd9a3);
				if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
					if (entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						float num = Vector3.Distance(entity.transform.position, base.transform.position);
						priority.priority = Mathf.Max(40 * (int)num, 500);
						if (m_entity is EntityPlayer)
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
							if (m_entity.cd95354b53e674ec7dc9594e66e4d316f().m_id == player.c29a834d12d3895f5680e69a30e6cd9a3)
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
								priority.priority = 130;
							}
						}
					}
				}
			}
			priority.priority = 0;
		}
		lastEvaluatedPriority = priority.priority;
	}

	private void FixedUpdate()
	{
		if (m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_teleportRequests.Count > 0)
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
				for (int i = 0; i < m_teleportRequests.Count; i++)
				{
					cb9efaee1f60aa83adaa8ffc2ba5bfd4b(m_teleportRequests[i].m_pos, m_teleportRequests[i].m_rot);
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
				m_teleportRequests.Clear();
			}
		}
		int c54c75a1eaccb56ae03a0d1c56438d1d = Time.frameCount;
		if (m_entity is EntityPlayer)
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
			c54c75a1eaccb56ae03a0d1c56438d1d = (m_entity as EntityPlayer).cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum;
		}
		TimePos timePos = new TimePos(Time.time, base.transform.position, c54c75a1eaccb56ae03a0d1c56438d1d);
		if (m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f() == 0)
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
			m_clientTimePos.cd6aca5b3793f791cfc489609e675c90b(timePos);
		}
		else
		{
			TimePos timePos2 = (TimePos)m_clientTimePos.cef0e77f01549f5bca5df565d45cc1a90();
			if (!timePos2.Equals(timePos))
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
				m_clientTimePos.cd6aca5b3793f791cfc489609e675c90b(timePos);
			}
		}
		if (!NetworkManager.c00c3ec658bbd0ff2568a3b72647806e1())
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
			if (photonView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_entity.caac907d451029d68503484a63934c93f())
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
					cf87f49d4e33f91237a8a54aedb51a4ab();
				}
				else
				{
					cdf1673221e3a3e5e9bb9d0d07224afc6();
				}
			}
		}
		else
		{
			int num = m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f();
			if (num > 4)
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
				TimePos timePos3 = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num - 1);
				TimePos timePos4 = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num - 5);
				Vector3 vector = timePos3.m_position - timePos4.m_position;
				double num2 = timePos3.m_time - timePos4.m_time;
				Velocity = vector / (float)num2;
				localVelocity = base.transform.InverseTransformDirection(Velocity);
			}
			else
			{
				localVelocity = Vector3.zero;
				Velocity = Vector3.zero;
			}
		}
		if (!m_enableFallProtection)
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
			c8be49d6f8b2a50b6ebc554fad90ff431();
			return;
		}
	}

	private void Update()
	{
		if (m_debug)
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
					if (!base.gameObject.transform.FindChild("debugMovement"))
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
							{
								Camera[] componentsInChildren = base.gameObject.GetComponentsInChildren<Camera>();
								for (int i = 0; i < componentsInChildren.Length; i++)
								{
									DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "deactive" + componentsInChildren[i].gameObject.name);
									componentsInChildren[i].gameObject.SetActive(false);
								}
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
									{
										GameObject gameObject = new GameObject("debugMovement");
										gameObject.AddComponent<Camera>();
										gameObject.transform.parent = base.gameObject.transform;
										gameObject.transform.localPosition = new Vector3(0f, 10f, -4f);
										gameObject.camera.transform.localRotation = Quaternion.Euler(60f, 0f, 0f);
										return;
									}
									}
								}
							}
							}
						}
					}
					return;
				}
			}
		}
		if (!base.gameObject.transform.FindChild("debugMovement"))
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
			UnityEngine.Object.Destroy(base.gameObject.transform.FindChild("debugMovement").gameObject);
			Camera[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Camera>(true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "active" + componentsInChildren2[j].gameObject.name);
				componentsInChildren2[j].gameObject.SetActive(true);
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
	}

	private void cb9efaee1f60aa83adaa8ffc2ba5bfd4b(Vector3 c36743296764bc459581f3834b3a14625, Quaternion c751ec223abe1319c3ce091bb02d3672b)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = "DoTeleportMe ";
		array[1] = m_entity.name;
		array[2] = " - before : pos ";
		array[3] = base.transform.position;
		array[4] = " - rot ";
		array[5] = base.transform.rotation;
		array[6] = " teleportRot:";
		array[7] = c751ec223abe1319c3ce091bb02d3672b;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		base.transform.position = c36743296764bc459581f3834b3a14625;
		if (m_entity is EntityPlayer)
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
			(m_entity as EntityPlayer).c95b58ea1846fc7087c97f6018072d7de(c751ec223abe1319c3ce091bb02d3672b);
		}
		else
		{
			base.transform.rotation = c751ec223abe1319c3ce091bb02d3672b;
			if (m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_entity.cb8119a2676bfbd4df00a9ed683eed91a() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_entity.cb8119a2676bfbd4df00a9ed683eed91a().OnTeleportMe(c36743296764bc459581f3834b3a14625);
				}
			}
		}
		m_clientTimePos.cac7688b05e921e2be3f92479ba44b4a8();
		m_hostTimePos.cac7688b05e921e2be3f92479ba44b4a8();
		m_interpolater.cac7688b05e921e2be3f92479ba44b4a8();
		m_clientOfHostTimePos.cac7688b05e921e2be3f92479ba44b4a8();
		object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array2[0] = "DoTeleportMe ";
		array2[1] = m_entity.name;
		array2[2] = " - after : pos ";
		array2[3] = base.transform.position;
		array2[4] = " - rot ";
		array2[5] = base.transform.rotation;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array2));
		m_teleporting = false;
	}

	[RPC]
	private void RPC_TeleportMe(Vector3 teleportPos, Quaternion teleportRot, PhotonMessageInfo info)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = "RPC_TeleportMe  teleportPos: ";
		array[1] = teleportPos;
		array[2] = " teleportRot:";
		array[3] = teleportRot;
		array[4] = "at:";
		array[5] = Time.time;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		m_teleportRequests.Add(new TeleportRequest(teleportPos, teleportRot));
		m_teleporting = true;
		m_teleportTimeStamp = Time.fixedTime;
		m_teleportNetworkTimeStamp = info.c24d168bafd94cfd3e438faef12da2b5c;
	}

	public void c88b49dc0432dffa0f75de3d5ec1c1946(Vector3 c36743296764bc459581f3834b3a14625, Quaternion c751ec223abe1319c3ce091bb02d3672b)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "RequestTeleportMe";
		array[1] = c36743296764bc459581f3834b3a14625;
		array[2] = ":";
		array[3] = c751ec223abe1319c3ce091bb02d3672b;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		base.transform.position = c36743296764bc459581f3834b3a14625;
		if (m_entity is EntityPlayer)
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
			(m_entity as EntityPlayer).c95b58ea1846fc7087c97f6018072d7de(c751ec223abe1319c3ce091bb02d3672b);
		}
		else
		{
			base.transform.rotation = c751ec223abe1319c3ce091bb02d3672b;
		}
		object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array2[0] = c36743296764bc459581f3834b3a14625;
		array2[1] = c751ec223abe1319c3ce091bb02d3672b;
		if (!(photonView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_TeleportMe", PhotonTargets.All, array2);
			return;
		}
	}

	public void c284c367e9c4fb46c610a5744293d502e(bool c232363d391ddf136de98040c51b456ba)
	{
		m_followServerMovement = c232363d391ddf136de98040c51b456ba;
	}

	private void cdf1673221e3a3e5e9bb9d0d07224afc6()
	{
		int num = m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f();
		if (num > 4)
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
			TimePos timePos = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num - 1);
			TimePos timePos2 = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num - 5);
			Vector3 vector = timePos.m_position - timePos2.m_position;
			double num2 = timePos.m_time - timePos2.m_time;
			Velocity = vector / (float)num2;
			localVelocity = base.transform.InverseTransformDirection(Velocity);
		}
		else
		{
			localVelocity = Vector3.zero;
			Velocity = Vector3.zero;
		}
		if (photonView.c6971afb2ced2e6c56d327fce1c3bca83)
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
			Vector3 c1ee6942d87425aaba61e92e238828f3b = base.transform.position;
			Quaternion cd5176331b6ee3998bc728ffe1f99f = base.transform.rotation;
			if (m_interpolater.ca4fc83532a6c52f344916ec7e089bf68(ref c1ee6942d87425aaba61e92e238828f3b, ref cd5176331b6ee3998bc728ffe1f99f))
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
				m_extrapolatedBuffer.cd6aca5b3793f791cfc489609e675c90b(c1ee6942d87425aaba61e92e238828f3b);
			}
			if (m_followServerMovement)
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
				base.transform.position = c1ee6942d87425aaba61e92e238828f3b;
				base.transform.rotation = cd5176331b6ee3998bc728ffe1f99f;
			}
			for (int num3 = m_hostTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f(); num3 >= 2; num3--)
			{
				TimePos timePos3 = (TimePos)m_hostTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num3 - 1);
				if (timePos3.m_position.ce5aad699df330ff708587e4fabea8cbb(base.transform.position, 0.001f))
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							if (m_listener != null)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										break;
									default:
										m_listener.OnMvtSyncReachPosition(timePos3);
										return;
									}
								}
							}
							return;
						}
					}
				}
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

	private void cf87f49d4e33f91237a8a54aedb51a4ab()
	{
		TimePos timePos = (TimePos)m_hostTimePos.cef0e77f01549f5bca5df565d45cc1a90();
		if (timePos == null)
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
			if (timePos.m_frameNum == -1)
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
			if (m_lastProcessedHostTP == null)
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
				m_lastProcessedHostTP = timePos;
			}
			if (m_lastProcessedHostTP.m_frameNum < timePos.m_frameNum)
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
				int num = 0;
				m_lastHostNetworkTime = timePos.m_networkTimeStamp;
				double num2 = timePos.m_networkTimeStamp - (double)((float)offset * Time.fixedDeltaTime) - m_lastProcessedHostTP.m_networkTimeStamp;
				num = (int)(num2 / (double)Time.fixedDeltaTime);
				if (num2 - (double)((float)num * Time.fixedDeltaTime) > 0.01600000075995922)
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
					num++;
				}
				offset += num - (timePos.m_frameNum - offset - m_lastProcessedHostTP.m_frameNum);
				m_lastProcessedHostTP = timePos;
				m_lastHostNetworkTime = timePos.m_networkTimeStamp;
			}
			else
			{
				if (m_lastProcessedHostTP.m_frameNum != timePos.m_frameNum)
				{
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array[0] = "host movement order corrupted:";
					array[1] = timePos.m_frameNum;
					array[2] = " should >";
					array[3] = m_lastProcessedHostTP.m_frameNum;
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array));
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
				if (m_lastHostNetworkTime > timePos.m_networkTimeStamp)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array2[0] = "host movement order corrupted:";
						array2[1] = timePos.m_networkTimeStamp;
						array2[2] = " should >";
						array2[3] = m_lastHostNetworkTime;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array2));
						return;
					}
				}
				if (!(m_lastHostNetworkTime < timePos.m_networkTimeStamp))
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
				int num3 = 0;
				m_lastHostNetworkTime = timePos.m_networkTimeStamp;
				double num4 = timePos.m_networkTimeStamp - (double)((float)offset * Time.fixedDeltaTime) - m_lastProcessedHostTP.m_networkTimeStamp;
				num3 = (int)(num4 / (double)Time.fixedDeltaTime);
				if (num4 - (double)((float)num3 * Time.fixedDeltaTime) > 0.01600000075995922)
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
					num3++;
				}
				offset += num3;
			}
			Debug.cd311b36270223e532813522a1f24cc90(timePos.m_position, Vector3.up, Color.white, 10f);
			bool flag = false;
			if (timePos.m_frameNum <= 0)
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
				int num5 = m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f() - 1;
				while (true)
				{
					if (num5 >= 0)
					{
						TimePos timePos2 = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num5);
						if (timePos2.m_frameNum == timePos.m_frameNum)
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
							TimePos timePos3 = timePos2;
							TimePos c7088de59e49f7108f520cf7e0bae167e = ccce271d6a1498f3fd505c1bacbc33a92.c7088de59e49f7108f520cf7e0bae167e;
							float num6 = Vector3.Distance(timePos.m_position, timePos2.m_position);
							if (offset > 0)
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
								for (int i = -1; i <= offset + 1; i++)
								{
									if (num5 + i >= m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f())
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
									c7088de59e49f7108f520cf7e0bae167e = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num5 + i);
									if (c7088de59e49f7108f520cf7e0bae167e == null)
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
									if (!((double)Vector3.Distance(timePos.m_position, c7088de59e49f7108f520cf7e0bae167e.m_position) < (double)num6 - 0.1))
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
									num6 = Vector3.Distance(timePos.m_position, c7088de59e49f7108f520cf7e0bae167e.m_position);
									timePos3 = c7088de59e49f7108f520cf7e0bae167e;
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
							if (offset < 0)
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
								for (int num7 = 1; num7 >= offset - 1; num7--)
								{
									if (num5 + num7 < m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f())
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
										c7088de59e49f7108f520cf7e0bae167e = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num5 + num7);
										if (c7088de59e49f7108f520cf7e0bae167e != null)
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
											if ((double)Vector3.Distance(timePos.m_position, c7088de59e49f7108f520cf7e0bae167e.m_position) < (double)num6 - 0.1)
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
												num6 = Vector3.Distance(timePos.m_position, c7088de59e49f7108f520cf7e0bae167e.m_position);
												timePos3 = c7088de59e49f7108f520cf7e0bae167e;
											}
										}
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
							offset = timePos3.m_frameNum - timePos.m_frameNum;
							myPosAtServerTime = timePos3.m_position;
							m_clientOfHostTimePos.cd6aca5b3793f791cfc489609e675c90b(new TimePos(timePos3));
							flag = true;
							break;
						}
						num5--;
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
					break;
				}
				if (flag)
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
					if (m_correctingPos)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
							{
								Vector3 vector = timePos.m_position - myPosAtServerTime;
								for (int num8 = m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f() - 1; num8 >= num5; num8--)
								{
									TimePos timePos4 = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(num8);
									Ray ray = new Ray(timePos4.m_position, vector);
									RaycastHit cab3b059ef8d7994c0474c0fc10a08d;
									if (m_characterMotor.ce43542aec9cbb169187d2e5eafe6dc72(ray.origin, ray.direction, vector.magnitude, out cab3b059ef8d7994c0474c0fc10a08d))
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
										object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
										array3[0] = "corrector:";
										array3[1] = vector.magnitude;
										array3[2] = " through ";
										array3[3] = cab3b059ef8d7994c0474c0fc10a08d.collider;
										array3[4] = ":";
										array3[5] = cab3b059ef8d7994c0474c0fc10a08d.distance;
										DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array3));
										vector = vector.normalized * Mathf.Max(0f, cab3b059ef8d7994c0474c0fc10a08d.distance);
									}
									Debug.cd311b36270223e532813522a1f24cc90(timePos4.m_position, vector, Color.green, 100f);
									timePos4.m_position += vector;
								}
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
									{
										m_LastCorrectDis = vector.magnitude;
										TimePos timePos5 = (TimePos)m_clientTimePos.cef0e77f01549f5bca5df565d45cc1a90();
										base.transform.position = timePos5.m_position;
										return;
									}
									}
								}
							}
							}
						}
					}
				}
				m_LastCorrectDis = 0f;
				return;
			}
		}
	}

	private bool c85e4aba6d728bf44d008cd016d298402(RingBuffer c41ec38993d2186bd5a591d7f4358f6e4, double cad9f703d862495149cd6bddd080f050b, ref Vector3 cab43bf2e365fd2bf568d9cdda58d7479)
	{
		return false;
	}

	private void c93aca1574414662debcb4061d835a9fc()
	{
	}

	private void cc7e5a5560f263b374abd5a43b0f37ee6()
	{
	}

	private void cd1e22fe51e423fb0a4c1c4f72d498e97()
	{
	}

	private void c8be49d6f8b2a50b6ebc554fad90ff431()
	{
		if (!((double)base.transform.position.y + 0.4 < (double)m_entity.c4c38fdc58f120e1209ca439fa8ee5818().y))
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
			base.transform.position = m_entity.c4c38fdc58f120e1209ca439fa8ee5818();
			return;
		}
	}

	public void c333bdcbd737ec713b3d38fa471251021(IMvtSyncListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
	}

	public void c322e3e8e33c9861d877c6feb14c64b0c()
	{
	}

	private void OnDrawGizmos()
	{
		if (drawHostTP)
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
			if (m_hostTimePos != null)
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
				for (int i = 0; i < m_hostTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f(); i++)
				{
					TimePos timePos = (TimePos)m_hostTimePos.c588e7dbcd383d8230b2d83d7b44af23b(i);
					Gizmos.color = Color.black;
					Gizmos.DrawSphere(timePos.m_position, 0.06f);
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
		if (drawClientTP)
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
			if (m_clientTimePos != null)
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
				for (int j = 0; j < m_clientTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f(); j++)
				{
					TimePos timePos2 = (TimePos)m_clientTimePos.c588e7dbcd383d8230b2d83d7b44af23b(j);
					Gizmos.color = Color.green;
					Gizmos.DrawSphere(timePos2.m_position, 0.055f);
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
		if (drawExtraClientTP)
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
			if (m_clientTimePos != null)
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
				for (int k = 0; k < m_extrapolatedBuffer.ca0dc0c335bcd7a0d16510da3a64d1c4f(); k++)
				{
					Gizmos.color = Color.red;
					Gizmos.DrawSphere((Vector3)m_extrapolatedBuffer.c588e7dbcd383d8230b2d83d7b44af23b(k), 0.055f);
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
		if (m_clientOfHostTimePos != null)
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
			for (int l = 0; l < m_clientOfHostTimePos.ca0dc0c335bcd7a0d16510da3a64d1c4f(); l++)
			{
				TimePos timePos3 = (TimePos)m_clientOfHostTimePos.c588e7dbcd383d8230b2d83d7b44af23b(l);
				Gizmos.color = Color.magenta;
				Gizmos.DrawSphere(timePos3.m_position, 0.05f);
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
		Gizmos.DrawRay(new Ray(base.gameObject.transform.position, localVelocity));
	}
}
