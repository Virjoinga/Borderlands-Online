using System;
using A;
using BHV;
using Core;
using UnityEngine;
using XsdSettings;

public class PlayerController : MonoBehaviour
{
	protected EntityPlayer m_entity;

	protected PlayerThirdPersonAnimationManagerFSM m_playerThirdPersonAnimationManagerFSM;

	protected InstanceInput m_inInput;

	protected PlayerBehavior m_playerBehavior;

	protected float m_retargetScaleMultiplier = 1f;

	protected float m_moveSpeedMultiplier = 1f;

	protected int m_webSlowFactor;

	private float m_firstPersonHeightFactor = 1f;

	private IBadAssCharacterMotor m_motor;

	private Vector3 m_desiredVelocity = Vector3.zero;

	private float m_desiredVelocityDeltaTime;

	private Transform m_pitchNode;

	private Vector3 m_lastPitchUp;

	private Vector3 m_pitchUpDelta;

	private BHVFirstPersonSettings m_firstPersonSettings;

	private PlayerAction m_authorizedActions;

	private Transform m_pitchNodeRaw;

	private Transform m_pitchNodeAdjuster;

	private bool m_knockingBack;

	private float m_knockStartTime;

	private Vector3 m_knockBackDir;

	private bool m_bBerserkDash;

	public bool adjustpitchNode = true;

	private Vector3 realPos;

	private Vector3 m_lastPitchUpLateUpdate;

	private Vector3 m_lastLastPitchUpLateUpdate;

	private Vector3 m_lastLastLastPitchUpLateUpdate;

	public virtual void Awake()
	{
		m_pitchNode = new GameObject("DefaultPitchNode").transform;
		m_pitchNode.parent = base.transform;
	}

	public virtual void Start()
	{
		m_entity = GetComponent<EntityPlayer>();
		AvatarType avatarType = m_entity.cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
		AvatarType avatarType2 = avatarType;
		if (avatarType2 != 0)
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
			if (avatarType2 != AvatarType.SOLDIER)
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
				m_retargetScaleMultiplier = 0.92f;
			}
		}
		else
		{
			m_retargetScaleMultiplier = 1f;
		}
		m_inInput = GetComponent<InstanceInput>();
		m_motor = (IBadAssCharacterMotor)GetComponent(Type.GetTypeFromHandle(ccb2c22bcfee08b93405b7f92e89d5415.cc1720d05c75832f704b87474932341c3()));
		m_playerThirdPersonAnimationManagerFSM = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		m_playerBehavior = (PlayerBehavior)GetComponent(Type.GetTypeFromHandle(c0f5d17a33d8cd277a8ef3e79eecf4a03.cc1720d05c75832f704b87474932341c3()));
		BHVTaskManager bHVTaskManager = m_entity.c9b6d1d87bef7b03dad787ff0031551ee();
		m_firstPersonSettings = bHVTaskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>();
		c70f73cd269322091076d0bdd9f50e27c();
	}

	public virtual void Update()
	{
		c5ac07b51ae71d40cd68d6c59dc9a39b1(Time.deltaTime);
		cf6d13369bfe58cb51873fb954772b80a();
	}

	private void LateUpdate()
	{
		if (adjustpitchNode)
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
			Vector3 vector = base.transform.InverseTransformDirection(c3da29d17f9b89d8fc45789df0d6bd430());
			m_pitchNode.localPosition -= vector;
		}
		Vector3 view = Vector3.Lerp(m_lastLastLastPitchUpLateUpdate, c8760391d0bea1fb1158ddfc6b9f642a4(), 0.3f);
		m_pitchNode.rotation.SetLookRotation(view, Vector3.up);
		m_lastLastLastPitchUpLateUpdate = m_lastLastPitchUpLateUpdate;
		m_lastLastPitchUpLateUpdate = m_lastPitchUpLateUpdate;
		m_lastPitchUpLateUpdate = m_pitchNode.up;
	}

	private void c70f73cd269322091076d0bdd9f50e27c()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
					m_authorizedActions = (PlayerAction)4199;
					return;
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cd3175a878e297c0e31b1ccfc0307f2b4())
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					m_authorizedActions = (PlayerAction)8191;
					return;
				}
			}
		}
		m_authorizedActions = (PlayerAction)3;
	}

	public void cb96bf03f67eb5295e81ce489d4b82bea(PlayerAction c78ce8d1ee0a4b0c54eb88b1cec5c48b7)
	{
		m_authorizedActions = c78ce8d1ee0a4b0c54eb88b1cec5c48b7;
	}

	public bool c3f5a0de60e63b40404559fa7bafafee2(PlayerAction c861de212c63da4e42109937e3cac1a44)
	{
		return (m_authorizedActions & c861de212c63da4e42109937e3cac1a44) != 0;
	}

	private void c5dfd692baf59326fa95f05a5a39d0a92(Vector3 c8219c6868423de9618a622239ee682ba)
	{
		m_desiredVelocity = c8219c6868423de9618a622239ee682ba;
	}

	private void c8fefa6172dc7c8828f7b869e3fcb16f4(float c2002bb238c228cf502166e05c0d89311)
	{
		m_desiredVelocityDeltaTime = c2002bb238c228cf502166e05c0d89311;
	}

	public void c63ee313b87b770d38877f71939e90417(float c41372251925d6a785ff80b08d32bcc2c)
	{
		int num;
		if (m_webSlowFactor > 0)
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
			num = 1;
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		if (c41372251925d6a785ff80b08d32bcc2c < 1f)
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
			m_webSlowFactor++;
		}
		else
		{
			m_webSlowFactor--;
		}
		if (flag)
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
			if (m_webSlowFactor == 0)
			{
				goto IL_0090;
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
		if (flag)
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
			break;
		}
		if (m_webSlowFactor <= 0)
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
		goto IL_0090;
		IL_0090:
		float value = m_moveSpeedMultiplier * c41372251925d6a785ff80b08d32bcc2c;
		m_moveSpeedMultiplier = Mathf.Clamp(value, 0.01f, 1f);
	}

	public void c15206bb0d3ef42ea679c4698dced3dd1(float c93c4582bbbadf578fc8ce409cca152bd)
	{
		m_moveSpeedMultiplier = c93c4582bbbadf578fc8ce409cca152bd;
	}

	public float cde3473b2f8e41fee852784334ce69c8d()
	{
		return m_moveSpeedMultiplier;
	}

	public void c942f30413f4166213a90c3567ae1489b()
	{
		m_moveSpeedMultiplier = 1f;
		m_webSlowFactor = 0;
	}

	public void c3eaf7e24e28d40faca678a6afc594878(Transform c5199ef9e3a20dc1c114167d1f9c51189, Transform c1b02648180643012971751ce1724f946, Transform c961c3dfd8836fbda5b333b740e76f20d)
	{
		m_pitchNode = c5199ef9e3a20dc1c114167d1f9c51189;
		m_pitchNodeRaw = c961c3dfd8836fbda5b333b740e76f20d;
		m_pitchNodeAdjuster = c1b02648180643012971751ce1724f946;
	}

	protected void c7a4cd134dc4f26ca7677c388bc980404()
	{
		if (!(m_pitchNodeAdjuster != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_pitchNodeRaw != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_pitchNodeAdjuster.localPosition = new Vector3(m_pitchNodeRaw.localPosition.y, 0f - m_pitchNodeRaw.localPosition.z, m_pitchNodeRaw.localPosition.x);
				m_pitchNodeAdjuster.localRotation = Quaternion.Euler(270f, 90f, 0f);
				return;
			}
		}
	}

	public Transform ce2053aa14178b14997db504c8a6e907e()
	{
		return m_pitchNode;
	}

	protected virtual void FixedUpdate()
	{
		m_motor.c9cd9d634c23883f713b1e7dc6def6a1e(c0441e7262bf7c2dce29506ef75c60d86());
		c21e0fc3678c8cbada3c2757d6f1f3888();
		cc8721c43c6e57798e362118ca5e545b5();
	}

	private void c21e0fc3678c8cbada3c2757d6f1f3888()
	{
		if (m_motor == null)
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
		if (m_knockingBack)
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
			m_motor.c99cb1807ef027ac299c6fe9a57d28006(true);
			m_motor.c5dfd692baf59326fa95f05a5a39d0a92(m_knockBackDir * m_retargetScaleMultiplier * m_moveSpeedMultiplier);
			m_motor.c60a6395cd90cf9a40262240e16874381(Time.fixedDeltaTime);
			if (Time.fixedTime - m_knockStartTime > 1f)
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
				m_knockingBack = false;
			}
		}
		else if (m_bBerserkDash)
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
			m_motor.c99cb1807ef027ac299c6fe9a57d28006(false);
			m_motor.c5dfd692baf59326fa95f05a5a39d0a92(ce2b895837d2965922a68c856f476e6e4() * m_retargetScaleMultiplier * m_moveSpeedMultiplier);
			m_motor.c60a6395cd90cf9a40262240e16874381(Time.fixedDeltaTime);
		}
		else
		{
			m_motor.c99cb1807ef027ac299c6fe9a57d28006(m_inInput.c8cc0ce1bacf416fdd879d1e63947960f());
			m_motor.c5dfd692baf59326fa95f05a5a39d0a92(ca919d93c7985247f98500bd80f05ff52() * m_retargetScaleMultiplier * m_moveSpeedMultiplier);
			m_motor.c60a6395cd90cf9a40262240e16874381(Time.fixedDeltaTime);
		}
		m_motor.cf6d13369bfe58cb51873fb954772b80a();
	}

	private void c5ac07b51ae71d40cd68d6c59dc9a39b1(float c2002bb238c228cf502166e05c0d89311)
	{
		if (m_inInput.c7201a6224668404b44ad10a24fe68d67())
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
			m_firstPersonHeightFactor -= c2002bb238c228cf502166e05c0d89311 * m_firstPersonSettings.m_crouchDownSpeed;
			if (m_firstPersonHeightFactor < 0f)
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
				m_firstPersonHeightFactor = 0f;
			}
		}
		else
		{
			m_firstPersonHeightFactor += c2002bb238c228cf502166e05c0d89311 * m_firstPersonSettings.m_standUpSpeed;
			if (m_firstPersonHeightFactor > 1f)
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
				m_firstPersonHeightFactor = 1f;
			}
		}
		m_entity.m_entityHeight = c0441e7262bf7c2dce29506ef75c60d86();
	}

	private void cf6d13369bfe58cb51873fb954772b80a()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
		BHVMovementSpeed cf6e1a5c5132a48f8bc47958d2be74c = BHVMovementSpeed.INVALID;
		if (m_inInput.cb261500372fa488b369e9159a002977a())
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
			cf6e1a5c5132a48f8bc47958d2be74c = BHVMovementSpeed.SPRINT;
		}
		else if (m_inInput.cdc79bb1740f1c70185840b061137dea8())
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
			if (m_inInput.c4d927c91307ef767ba359c476291c950())
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
				cf6e1a5c5132a48f8bc47958d2be74c = BHVMovementSpeed.WALK;
			}
			else
			{
				cf6e1a5c5132a48f8bc47958d2be74c = BHVMovementSpeed.RUN;
			}
		}
		m_playerThirdPersonAnimationManagerFSM.c139222162aeb0051ac37d9635fe73e12(cf6e1a5c5132a48f8bc47958d2be74c, m_inInput.c7461901730f520d365b9e384aa821620(), m_inInput.c7201a6224668404b44ad10a24fe68d67(), m_inInput.c8cc0ce1bacf416fdd879d1e63947960f(), m_inInput.c4d927c91307ef767ba359c476291c950());
	}

	private Quaternion c62bfc57bf3cce677f4213562ec79daad()
	{
		return Quaternion.Euler(0f, m_inInput.c0124f6c859e33c1d30d93e866a126f3f(), 0f);
	}

	private Quaternion cf3733f3212fe7a06635d50a09b18a083()
	{
		return Quaternion.Euler(m_inInput.c860b20a36d422451f98fcb15cc16813b(), 0f, 0f);
	}

	private void cc8721c43c6e57798e362118ca5e545b5()
	{
		if (!m_entity.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
					if (m_pitchNode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								m_pitchNode.localRotation = Quaternion.Euler(0f, 270f, 270f - m_playerThirdPersonAnimationManagerFSM.c860b20a36d422451f98fcb15cc16813b());
								m_pitchNode.localPosition = Vector3.up * c0441e7262bf7c2dce29506ef75c60d86();
								m_pitchNode.localPosition += c1a53b45c4e304dfaa2022e79f79a4680() * Vector3.back;
								if (m_playerThirdPersonAnimationManagerFSM.m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
											m_playerThirdPersonAnimationManagerFSM.m_animationEventController.c1388b070a9ff180c6a0efe41ddf70e31(ce2053aa14178b14997db504c8a6e907e().position + c8760391d0bea1fb1158ddfc6b9f642a4());
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
		m_entity.transform.rotation = c62bfc57bf3cce677f4213562ec79daad();
		if (m_pitchNode == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		m_pitchNode.localRotation = Quaternion.Euler(0f, 270f, 270f - m_inInput.c860b20a36d422451f98fcb15cc16813b());
		m_pitchNode.localRotation *= m_playerBehavior.ce4f354aefe25b1e9ab3bac6e5807a384();
		m_pitchNode.localPosition = Vector3.up * c0441e7262bf7c2dce29506ef75c60d86();
		m_pitchNode.localPosition += c1a53b45c4e304dfaa2022e79f79a4680() * (m_pitchNode.localRotation * Vector3.down);
		m_pitchUpDelta = m_pitchNode.up - m_lastPitchUp;
		m_lastPitchUp = m_pitchNode.up;
	}

	public void c758f3560939f4f4f4649685139ccadc4(Quaternion c4ea6de03c1203f2470a6677821ad93f0, float c929d6dc26794b71ada3b76f22282c0f2)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
		m_pitchNode.localRotation = Quaternion.Euler(0f, 270f, 270f - m_inInput.c860b20a36d422451f98fcb15cc16813b());
		m_pitchNode.localRotation *= c4ea6de03c1203f2470a6677821ad93f0;
		m_pitchNode.localPosition = Vector3.up * c0441e7262bf7c2dce29506ef75c60d86();
		m_pitchNode.localPosition += c929d6dc26794b71ada3b76f22282c0f2 * (m_pitchNode.localRotation * Vector3.down);
		m_pitchUpDelta = m_pitchNode.up - m_lastPitchUp;
		m_lastPitchUp = m_pitchNode.up;
	}

	private float c1a53b45c4e304dfaa2022e79f79a4680()
	{
		return m_playerBehavior.c1a53b45c4e304dfaa2022e79f79a4680();
	}

	public Vector3 c8760391d0bea1fb1158ddfc6b9f642a4()
	{
		return m_pitchNode.up;
	}

	public Vector3 c194dc32812949364e4b91bc6d94a4f68()
	{
		return m_pitchUpDelta;
	}

	public Vector3 c3be03b1daae1e93e9a0633a6c86aa45b()
	{
		return base.transform.position + Vector3.up * c0441e7262bf7c2dce29506ef75c60d86();
	}

	public float c0441e7262bf7c2dce29506ef75c60d86()
	{
		if (m_entity.cf1bd1736812e2b58e29ab4a7df48f8fc != null)
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
					return Mathf.Lerp(m_entity.cf1bd1736812e2b58e29ab4a7df48f8fc.m_crouchHeight, m_entity.cf1bd1736812e2b58e29ab4a7df48f8fc.m_standHeight, m_firstPersonHeightFactor);
				}
			}
		}
		return 0f;
	}

	private Vector3 ca919d93c7985247f98500bd80f05ff52()
	{
		Vector3 direction = m_inInput.c7461901730f520d365b9e384aa821620();
		direction = base.transform.TransformDirection(direction).normalized;
		direction *= cb798560b7f53d16ffb4774e49cc3de27();
		Debug.cd311b36270223e532813522a1f24cc90(base.transform.position, direction, Color.magenta);
		return direction;
	}

	private float cb798560b7f53d16ffb4774e49cc3de27()
	{
		if (m_inInput.c8cc0ce1bacf416fdd879d1e63947960f())
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
					return 1f;
				}
			}
		}
		if (m_inInput.c7201a6224668404b44ad10a24fe68d67())
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return m_firstPersonSettings.m_crouchWalkSpeed;
				}
			}
		}
		if (m_inInput.c4d927c91307ef767ba359c476291c950())
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return m_firstPersonSettings.m_standWalkSpeed;
				}
			}
		}
		if (m_inInput.cb261500372fa488b369e9159a002977a())
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return m_firstPersonSettings.m_standSprintSpeed;
				}
			}
		}
		return m_firstPersonSettings.m_standRunSpeed;
	}

	private Vector3 c3da29d17f9b89d8fc45789df0d6bd430()
	{
		return m_motor.c02ba69b872ce3005f0d20ea25e9b15cf().frameOffset;
	}

	private Vector3 cd14a4f332d5e21de36e3b56057d09000()
	{
		return m_motor.c02ba69b872ce3005f0d20ea25e9b15cf().frameVelocity;
	}

	public void c2752f2e288d1e93ed4cdbb91832ec547(Vector3 c9a096c7639549cf7066d5ed203ecbab1)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "KnockBack->" + c9a096c7639549cf7066d5ed203ecbab1);
		m_knockStartTime = Time.time;
		m_knockingBack = true;
		m_knockBackDir = c9a096c7639549cf7066d5ed203ecbab1;
	}

	public bool cae80661bfeb2c6b447dae85baad4777d()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Fire))
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
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_playerThirdPersonAnimationManagerFSM.cae80661bfeb2c6b447dae85baad4777d();
	}

	public bool c8a149fd030504a4c5ee8f69d01a26c52()
	{
		if (cae80661bfeb2c6b447dae85baad4777d())
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
					return c4e73d24478878d4c6d94bef4abaa315a();
				}
			}
		}
		return false;
	}

	protected bool c4e73d24478878d4c6d94bef4abaa315a()
	{
		TargetingManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86;
		if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 c71901ec11266e4ff3ff61e7a7c65e = Vector3.zero;
			Vector3 c53e28ddc28cda4d72c55c784c38a6f = Vector3.zero;
			if (c5ee19dc8d4cccf5ae2de225410458b.m_aimedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				TargetingService.c760d3f1e0187364b0fdafcaa9ea76863(c5ee19dc8d4cccf5ae2de225410458b.m_aimedEntity, out c71901ec11266e4ff3ff61e7a7c65e, out c53e28ddc28cda4d72c55c784c38a6f);
			}
			EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
			if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (m_playerThirdPersonAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							float cb5cbb485927e8a6e9a71fe800cc5a = entityWeapon.c7792c484b60d7c05b9ef0053fa855896();
							m_playerThirdPersonAnimationManagerFSM.cfeb8ead5b51f4278fe8c3b81b3277fbe(cb5cbb485927e8a6e9a71fe800cc5a);
						}
						entityWeapon.c4e73d24478878d4c6d94bef4abaa315a();
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool c219a72dae1bf057dec472ae4c07937d6()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return entityWeapon.m_ammoCount <= 0;
				}
			}
		}
		return false;
	}

	public bool cc398985de9cbef8f2199a7f1eebc37dd()
	{
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		return m_playerThirdPersonAnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerReload);
	}

	public bool c964ae19cf2139567e0ea1ed244cde093()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.ReloadWeapon))
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
					return false;
				}
			}
		}
		EquipmentInventoryEntity equipmentInventoryEntity = m_entity.c5ca38fad98337fc5c7255384b2cd1a86();
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (!(equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				if (equipmentInventoryEntity.c5c30fc221fd2805f9535a08995b34b98(entityWeapon.c83e548e5608cd7f222098a6966b16545()) <= 0)
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
				bool flag = true;
				if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					flag = m_playerThirdPersonAnimationManagerFSM.c964ae19cf2139567e0ea1ed244cde093();
				}
				if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					int num;
					if (flag)
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
						num = ((!entityWeapon.ce5917fae4691059097d3504b1f180305()) ? 1 : 0);
					}
					else
					{
						num = 0;
					}
					flag = (byte)num != 0;
				}
				return flag;
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
		return false;
	}

	protected void c0d43c193dd223e1cac7446c51748121a()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (!(entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			entityWeapon.c0d43c193dd223e1cac7446c51748121a();
			return;
		}
	}

	public bool c611613a4cdf13c7acc73007bf65a3d2c(byte c793014f9fd028450a4a9908376309f26)
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.SwitchWeapon))
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
		if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(c793014f9fd028450a4a9908376309f26) == null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_playerThirdPersonAnimationManagerFSM.c2e00749553dc3b611c72dd1c9d1ad46c();
	}

	public void c1fc97d9000793496ac114d06521f85a0(byte c793014f9fd028450a4a9908376309f26)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb71c24b68b65fe176d7936520d63a102(c793014f9fd028450a4a9908376309f26);
	}

	public bool c35c68db077c9e358c1d58e59d105d1ca()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Crouch))
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
					return false;
				}
			}
		}
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_playerThirdPersonAnimationManagerFSM.c35c68db077c9e358c1d58e59d105d1ca();
	}

	public bool cf2c2e13913fe2591bb62635eab3e3271()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Crouch))
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
		return m_motor.cbcfd3b06e164a3e40fe416ad7dd0e1c7(base.transform.position, m_firstPersonSettings.m_standHeight);
	}

	public bool c93a1503d0dae992d88a73cc17682ad31()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Jump))
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
		if (!m_motor.c4ea65a191eec783b57d9624a6d06cf30())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_playerThirdPersonAnimationManagerFSM.c93a1503d0dae992d88a73cc17682ad31();
	}

	public bool c8cc0ce1bacf416fdd879d1e63947960f()
	{
		if (m_motor.c4ea65a191eec783b57d9624a6d06cf30())
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
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		return m_playerThirdPersonAnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerJump);
	}

	public bool c1aeae0a71b089f0b72d6f76062f51163()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Aim))
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
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_playerThirdPersonAnimationManagerFSM.c1aeae0a71b089f0b72d6f76062f51163();
	}

	protected void c2410e88016c14e3d45907364a377ea73(bool c8d758a37579717dcb98faf54f550d86e)
	{
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c8d758a37579717dcb98faf54f550d86e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					m_playerThirdPersonAnimationManagerFSM.c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerAim);
					return;
				}
			}
		}
		if (m_playerThirdPersonAnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerAim))
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
			m_playerThirdPersonAnimationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("PlayerAim").caeee91e34d54e1e41ab1b380f7d8c9a4();
		}
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().cf91ae5249669b02f125e35baedef33f7(false);
	}

	public bool ce3904876c92a696689165a6348ded9f6()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.LaunchSkill))
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
					return false;
				}
			}
		}
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!m_playerThirdPersonAnimationManagerFSM.c5989500ec6e64423320cf907a28c4cd1())
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}

	protected void c9d878a0c8ef401a60f254a868331d1bd()
	{
		m_entity.ca2deb9a5d1216bb1f968806841f1236f();
	}

	public bool c69e93962e1ca78e26e0c6dfcd5b44426()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Interact))
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
		return c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c69e93962e1ca78e26e0c6dfcd5b44426();
	}

	protected void ce2d31574942eb4096a689fa7573ca86e()
	{
		m_entity.ce2d31574942eb4096a689fa7573ca86e();
	}

	public bool c9ebaaf97541199e490a4e6249772a282()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.ThrowGrenade))
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
		bool flag = true;
		if (m_playerThirdPersonAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			flag = m_playerThirdPersonAnimationManagerFSM.c634ca231e8b1a7ec56e967a2d0928ca8();
		}
		int result;
		if (flag)
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
			result = ((m_entity.c5ca38fad98337fc5c7255384b2cd1a86().cc0b9d3080e1a0c182204b250d657b977() > 0) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	protected void c0411698b20c1e5ea7a3daa619b2a2b43()
	{
		if (!(m_entity is EntityPlayer))
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
			EntityPlayer entity = m_entity;
			entity.c0411698b20c1e5ea7a3daa619b2a2b43();
			return;
		}
	}

	public bool cab804f2f3e0598357bf19fd25b1d3faf()
	{
		if (!c3f5a0de60e63b40404559fa7bafafee2(PlayerAction.Melee))
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
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityPlayer entity = m_entity;
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		int result;
		if (!entity.m_pending_melee)
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
			result = (m_playerThirdPersonAnimationManagerFSM.c3eb03f897188a31b6772dd6177162d14() ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	protected void cca50d90a16c827944406599b9940ea35()
	{
		if (!(m_entity is EntityPlayer))
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
			EntityPlayer entity = m_entity;
			entity.cca50d90a16c827944406599b9940ea35();
			return;
		}
	}

	public bool c212938a308d79596b1acd410e24ec08d()
	{
		if (m_playerThirdPersonAnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		return m_playerThirdPersonAnimationManagerFSM.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerMelee);
	}

	public void cac28add6f0f77b12f9bb06daca29063e(bool c93f525ed928b54f8eb035ee537387461)
	{
		m_bBerserkDash = c93f525ed928b54f8eb035ee537387461;
	}

	private Vector3 ce2b895837d2965922a68c856f476e6e4()
	{
		return base.transform.TransformDirection(Vector3.forward).normalized * 10f;
	}
}
