using System;
using System.Collections;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class EntityWeapon : EntityObject
{
	public class RecoilSettings
	{
		public float m_randomOffsetMin;

		public float m_randomOffsetMax;

		public float m_offsetMin;

		public float m_offsetMax;

		public float m_reducingRateActive;

		public float m_reducingRateOnIdle;

		public void c894b9071105744959beb786b2750c4ef()
		{
			if (m_reducingRateActive <= float.Epsilon)
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
				m_reducingRateActive = 0.1f;
			}
			if (!(m_reducingRateOnIdle <= float.Epsilon))
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
				m_reducingRateOnIdle = 0.1f;
				return;
			}
		}
	}

	public class WanderManage
	{
		public float m_k_Radius;

		public float m_k_Speed;

		public float m_k_Accel;

		public float m_k_Decel;

		public float m_k_Accel_Distance;

		public float m_k_Decel_Distance;

		private Vector2 m_pos = Vector2.zero;

		private Vector2 m_start = Vector2.zero;

		private Vector2 m_end = Vector2.zero;

		private Vector2 m_delta = Vector2.zero;

		private float m_totaldist;

		private float m_progress;

		private float m_dist;

		private float m_current_speed;

		private EntityWeapon m_owner;

		private float m_modifier = 1f;

		public WanderManage(EntityWeapon cf811c0d5de19d7fe22be8d61350b722d)
		{
			m_owner = cf811c0d5de19d7fe22be8d61350b722d;
		}

		private float cbb3fdf04d2941080d5b0152765b8e292()
		{
			if (m_progress <= m_k_Accel_Distance)
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
				m_current_speed += m_k_Accel * Time.deltaTime;
			}
			else if (m_progress >= 1f - m_k_Decel_Distance)
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
				m_current_speed -= m_k_Decel * Time.deltaTime;
			}
			else
			{
				m_current_speed = m_k_Speed;
			}
			m_current_speed = Mathf.Clamp(m_current_speed, 0.1f, m_k_Speed);
			m_current_speed *= m_modifier;
			return m_current_speed;
		}

		public void Update()
		{
			if (!m_owner)
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
			if (m_totaldist <= 0f)
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
				cdae67ebe6e8319e7aa943dc58c0cd78f();
			}
			m_dist += cbb3fdf04d2941080d5b0152765b8e292() * Time.deltaTime;
			m_progress = Mathf.Clamp(m_dist / m_totaldist, 0f, 1f);
			Vector2 vector = Vector2.Lerp(m_start, m_end, m_progress);
			m_delta = vector - m_pos;
			m_pos = vector;
			if (!(m_dist >= m_totaldist))
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
				cdae67ebe6e8319e7aa943dc58c0cd78f();
				return;
			}
		}

		private void cdae67ebe6e8319e7aa943dc58c0cd78f()
		{
			c10f4f5305135ec3e4d5f3ea03ecc15b8();
			m_start = m_end;
			m_end = c204696fd0d9722c51c7dde81bc67b3d8();
			m_totaldist = Vector2.Distance(m_start, m_end);
			m_progress = 0f;
			m_dist = 0f;
			m_delta = Vector2.zero;
		}

		private void c10f4f5305135ec3e4d5f3ea03ecc15b8()
		{
			m_modifier = 1f;
			if (!(m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_owner.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (m_owner.m_owner.c6420f67f9249b1d533531d9f351a36e0() != EntityType.Player)
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
						EntityPlayer entityPlayer = (EntityPlayer)m_owner.m_owner;
						if (!(entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							if (entityPlayer.c8461c34c06edbd90bf4b90de8c15863f == null)
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
								m_modifier = entityPlayer.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WeaponSway);
								return;
							}
						}
					}
				}
			}
		}

		private Vector2 c204696fd0d9722c51c7dde81bc67b3d8()
		{
			Vector2 zero = Vector2.zero;
			float f = UnityEngine.Random.Range(0f, 1f) * 360f * ((float)Math.PI / 180f);
			zero.x = Mathf.Cos(f) * m_k_Radius * m_modifier;
			zero.y = Mathf.Sin(f) * m_k_Radius * m_modifier;
			return zero;
		}

		public Quaternion cb0bfc00f58d5c1b6c62b57d395d37c9d()
		{
			return Quaternion.Euler(m_pos.x, 0f, m_pos.y);
		}

		public float ccb06a75f06c324eada17773dc99efb6b()
		{
			return m_delta.x;
		}

		public float c33b81ab194703a85ac0990aebde19532()
		{
			return m_delta.y;
		}
	}

	public enum ReloadType
	{
		Invalid = -1,
		Standard = 0,
		CustomA = 1,
		CustomB = 2,
		Max = 3
	}

	public enum ScopeMaskType
	{
		NoScope = 0,
		Scope01 = 1,
		Scope02 = 2,
		Scope03 = 3,
		Scope04 = 4,
		Scope05 = 5,
		Scope06 = 6,
		Max = 7
	}

	public enum BurstFireStage
	{
		NoneBurst = 0,
		Bursting = 1
	}

	public WanderManage m_wander_manager;

	public readonly Quaternion originalRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));

	private WeaponDNA m_dna;

	private bool startedInstanciatingModel;

	public float m_nextFireTime;

	private float m_lastFireTime;

	private float m_lastUpdateSpreadTime;

	public Vector3 m_fireDirection;

	public Vector3 m_fireOrigin;

	public int m_ammoCount;

	[HideInInspector]
	public bool m_isReady;

	private float m_currentSpread;

	private float m_innerSpread;

	private PerViewWeaponParam m_currentView;

	private PerViewWeaponParam m_normalView;

	private PerViewWeaponParam m_zoomView;

	public bool m_isAimActive;

	private ParticleSystem m_flashMuzzle;

	private GameObject m_shotTraceGameObject;

	private ParticleSystem m_shotTrace;

	private Animation m_muzzleFlashLight;

	private ParticleSystem m_bulletEjection;

	private bool m_hasScope;

	public bool m_noBulletSpray;

	private bool m_isDataDirty;

	private int m_ammoCountToSend;

	public Material m_thrWpnMat;

	private float m_reloadPercentage;

	public SkinnedMeshRenderer mWpnRenderer;

	private int m_random_index;

	private float m_recoilOffsetYaw;

	private float m_recoilOffsetPitch;

	private float m_recoilOffsetKickBack;

	private int m_randomRecoilIndex;

	private RecoilSettings m_recoilSettingsYaw = new RecoilSettings();

	private RecoilSettings m_recoilSettingsPitch = new RecoilSettings();

	private RecoilSettings m_recoilSettingsKickBack = new RecoilSettings();

	private ItemManufacturer m_manufacturer;

	private float m_dynamicFireRate;

	private int m_dynamicBulletBurst;

	private int m_fixedBulletBurst;

	private float m_delayTimeAfterBurst = 0.5f;

	public float m_BurstFinishTime;

	private BurstFireStage m_burstFireStage;

	private int m_level;

	private int m_firstFireFrame;

	private int m_firstFireAmmo;

	private float m_bulletOffsetStart;

	public WeaponAttribute m_attribute { get; private set; }

	public static AttackInfo.ElementalType c338e1019b68c1ba415414bd8d6cd4cae(WeaponAttribute c6d6a730e61547c3a746fdd931bc37afc)
	{
		return (AttackInfo.ElementalType)IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(c6d6a730e61547c3a746fdd931bc37afc.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalType) as IntAttributeValue);
	}

	public override AttackInfo.ElementalType c338e1019b68c1ba415414bd8d6cd4cae()
	{
		return c338e1019b68c1ba415414bd8d6cd4cae(m_attribute);
	}

	public void c68cd0a841e044876d964965d7ec944bd(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		m_dna = caedbc1db6c28d44eab6021e7d674eab3;
	}

	public WeaponDNA c729ce3b5f48e0eac3a7ead97b1d02f8d()
	{
		return m_dna;
	}

	public override int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		return m_level;
	}

	public byte c7f910426b3f87db67b8af4c62170e282(WeaponSubPart c716466036ca83f8907f5a0c81b0e432d)
	{
		return m_dna.c7f910426b3f87db67b8af4c62170e282(c716466036ca83f8907f5a0c81b0e432d);
	}

	public override void c1c5a947f5f8c009fe6fac45c9e29ad1d(Entity c706ea4155b03100282fe553e4d0be557)
	{
		if (c706ea4155b03100282fe553e4d0be557 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Skeleton skeleton = c706ea4155b03100282fe553e4d0be557.ccd8e6ea278245d0f158036267242e60f();
		if (skeleton == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		WeaponType weaponType = c83e548e5608cd7f222098a6966b16545();
		Transform transform = skeleton.cf40f1411a71635238075b839a6650d91(weaponType);
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array[0] = "No weapon Node for Weapontype[";
					array[1] = weaponType;
					array[2] = "] on [";
					array[3] = c706ea4155b03100282fe553e4d0be557.name;
					array[4] = "]";
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array));
					return;
				}
				}
			}
		}
		base.transform.parent = transform;
		base.gameObject.SetActive(true);
		c2cf125a3ac2861ae411123eacb7237b1();
		mWpnRenderer = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			if (NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea() == null)
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
				if (!NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cd885bd4479d20f52c6f209bf46f58b98)
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
					if (!mWpnRenderer)
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
						mWpnRenderer.enabled = false;
						return;
					}
				}
			}
		}
	}

	public override void c67c35955d666a0c6fe54cd6e348b1675()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			if ((bool)mWpnRenderer)
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
				mWpnRenderer.enabled = true;
			}
		}
		base.gameObject.SetActive(false);
	}

	public override bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_isReady;
	}

	public void c8427a60c8a870df8389ec09a90588877(bool c87b995380f7a20665c44dc0d85627df1)
	{
		SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			componentInChildren.enabled = !c87b995380f7a20665c44dc0d85627df1;
			return;
		}
	}

	public bool c09a173327ea9e510fbbae5150bf9d2e2()
	{
		return m_hasScope;
	}

	public void cfed448b0ca902482df4dd659ecb277bd(bool c232363d391ddf136de98040c51b456ba)
	{
		m_isAimActive = c232363d391ddf136de98040c51b456ba;
		if (m_isAimActive)
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
					m_currentView = m_zoomView;
					return;
				}
			}
		}
		m_currentView = m_normalView;
	}

	public bool cc93370e457eb4094fe6253d1b18437ca()
	{
		if (c83e548e5608cd7f222098a6966b16545() != WeaponType.ShotGun)
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
			if (c83e548e5608cd7f222098a6966b16545() != WeaponType.SniperRifle)
			{
				return (double)FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRate) as FloatAttributeValue) > 5.0;
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
		return false;
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
					m_ammoCountToSend = -1;
					if (m_isDataDirty)
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
						m_ammoCountToSend = m_ammoCount;
						m_isDataDirty = false;
					}
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_ammoCountToSend);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_random_index);
					return;
				}
			}
		}
		int num = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		if (num != -1)
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
			m_ammoCount = num;
		}
		m_random_index = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
	}

	public override void Start()
	{
		base.Start();
		if (m_dna == null)
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
			ItemDNA itemDNA = c9fc033d895059e2080450369e258d5f0()[0] as ItemDNA;
			m_dna = itemDNA.ca79da172938fdc8c067fb64242b6174a();
		}
		m_wander_manager = new WanderManage(this);
		m_level = m_dna.m_level;
		c8fb765ceb375501f00e7dc41af21c7ea(m_dna);
		if (c9fc033d895059e2080450369e258d5f0() != null)
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
			int num = (int)c9fc033d895059e2080450369e258d5f0()[2];
			if (num != -1)
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
				if (num != PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3)
				{
					goto IL_00c3;
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
			cd93c0dd53b810158c02385f682094c2c();
		}
		else
		{
			cd93c0dd53b810158c02385f682094c2c();
		}
		goto IL_00c3;
		IL_00c3:
		if ((bool)AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new Fire());
			m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new Reload());
		}
		m_random_index = 0;
	}

	public void c8fb765ceb375501f00e7dc41af21c7ea(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		m_attribute = caedbc1db6c28d44eab6021e7d674eab3.m_attribute;
		m_reloadPercentage = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ReloadPercentage) as FloatAttributeValue);
		m_manufacturer = (ItemManufacturer)IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ManufactureType) as IntAttributeValue);
		m_dynamicBulletBurst = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomFiringBurst) as IntAttributeValue);
		m_fixedBulletBurst = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomFiringBurst) as IntAttributeValue);
		m_delayTimeAfterBurst = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.DelayTimeAfterBurst) as FloatAttributeValue);
		if (ca5bd9cea1cbcb16947182f8e75ef28ba() != 0)
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
			m_hasScope = true;
		}
		m_normalView = new PerViewWeaponParam();
		m_normalView.m_AccuracyMax = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyMax) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_AccuracyMin = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyMin) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_AccuracyDecrease = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyDecrease) as FloatAttributeValue);
		m_normalView.m_AccuracyRegenerationRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyRegenerationRateActive) as FloatAttributeValue);
		m_normalView.m_AccuracyRegenerationRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyRegenerationRateOnIdle) as FloatAttributeValue);
		m_normalView.m_InnerAccuracyMax = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyMax) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_InnerAccuracyMin = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyMin) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_InnerAccuracyDecrease = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyDecrease) as FloatAttributeValue);
		m_normalView.m_InnerAccuracyRegenerationRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyRegenerationRateActive) as FloatAttributeValue);
		m_normalView.m_recoverTime = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoverTime) as FloatAttributeValue);
		m_zoomView = new PerViewWeaponParam();
		m_zoomView.m_AccuracyMax = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyMaxZoom) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_AccuracyMin = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyMinZoom) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_AccuracyDecrease = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyDecreaseZoom) as FloatAttributeValue);
		m_zoomView.m_AccuracyRegenerationRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyRegenerationRateActiveZoom) as FloatAttributeValue);
		m_zoomView.m_AccuracyRegenerationRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyRegenerationRateOnIdleZoom) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracyMax = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyMax) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_InnerAccuracyMin = Mathf.Clamp(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyMin) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_InnerAccuracyDecrease = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyDecrease) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracyRegenerationRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyRegenerationRateActive) as FloatAttributeValue);
		m_zoomView.m_recoverTime = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomRecoverTime) as FloatAttributeValue);
		m_wander_manager.m_k_Radius = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomWanderRadius) as FloatAttributeValue);
		m_wander_manager.m_k_Speed = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomWanderSpeed) as FloatAttributeValue);
		m_wander_manager.m_k_Accel = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomWanderAccel) as FloatAttributeValue);
		m_wander_manager.m_k_Decel = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomWanderDecel) as FloatAttributeValue);
		m_wander_manager.m_k_Accel_Distance = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomWanderAccelDistance) as FloatAttributeValue);
		m_wander_manager.m_k_Decel_Distance = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomWanderDecelDistance) as FloatAttributeValue);
		m_normalView.m_InnerAccuracy = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyNormal) as FloatAttributeValue);
		m_normalView.m_InnerAccuracyRatio = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyRatioNormal) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracy = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyZoom) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracyRatio = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.InnerAccuracyRatioZoom) as FloatAttributeValue);
		m_currentView = m_normalView;
		m_currentSpread = m_currentView.m_AccuracyMax;
		m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
	}

	public void c147930320243a36aa445308f779c8e0e(int c6390c775dc481c07da81be0014af70ed)
	{
		m_ammoCount -= c6390c775dc481c07da81be0014af70ed;
	}

	public bool cf3dd6199fd2bdfa78a66320aa3cfe676()
	{
		return m_ammoCount <= 0;
	}

	public bool ce5917fae4691059097d3504b1f180305()
	{
		return m_ammoCount == c68ed8789a1e844cef343f5216d74d25f();
	}

	public void c35c521e0bb18cb1199c9161f7daddfd7(int c99e61eced0a1e01a6fc25d26ba70db65)
	{
		int max = c68ed8789a1e844cef343f5216d74d25f();
		m_ammoCount = Mathf.Clamp(m_ammoCount + c99e61eced0a1e01a6fc25d26ba70db65, 0, max);
	}

	public void c0d43c193dd223e1cac7446c51748121a()
	{
		bool flag = false;
		if (m_ammoCount <= 0)
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
			EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
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
				if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.cad91320deb5a8ef065bc5ee36fea3e2e())
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
					flag = true;
				}
			}
		}
		if (flag)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					ce064e019fd98ec37f858b03b015d2410();
					return;
				}
			}
		}
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Reload");
	}

	public void c4e73d24478878d4c6d94bef4abaa315a()
	{
		if (!c01ac61277643dcc871b0fd9206f52229())
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
			if (m_dna.m_type != WeaponType.ShotGun)
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
				if (m_dna.m_type != WeaponType.SniperRifle)
				{
					m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Fire", false, m_randomRecoilIndex);
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
			m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Fire", true, m_randomRecoilIndex);
			return;
		}
	}

	public void cd65b54c26e0c82a0470c549d2b13f4aa(Action.ActionMessage c861de212c63da4e42109937e3cac1a44)
	{
		m_randomRecoilIndex = c861de212c63da4e42109937e3cac1a44.m_param;
		m_firstFireFrame = c861de212c63da4e42109937e3cac1a44.m_frameNum;
		m_firstFireAmmo = m_ammoCount;
		if (!(m_nextFireTime < Time.fixedTime))
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
			if (!(Time.fixedTime - m_nextFireTime < Time.fixedDeltaTime))
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
				m_bulletOffsetStart = Time.fixedTime - Time.fixedDeltaTime - m_nextFireTime;
				return;
			}
		}
	}

	public void cb6eff0c11ae578b14e6b2e2feca5fd1a(Action.ActionMessage c861de212c63da4e42109937e3cac1a44, float ce5153005e58459c18774d81099f8d6d6)
	{
		if (m_firstFireAmmo <= 0)
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
		int num = 0;
		float num2 = 1f / c7792c484b60d7c05b9ef0053fa855896();
		float num3 = m_bulletOffsetStart;
		float num4 = (float)(c861de212c63da4e42109937e3cac1a44.m_frameNum - m_firstFireFrame) * Time.fixedDeltaTime;
		while (num3 <= num4)
		{
			num3 += num2;
			num++;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			float nextFireTime = Time.fixedTime + num3 - num4;
			int num5 = m_firstFireAmmo - num;
			if (m_ammoCount < num5)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						m_ammoCount = num5;
						m_nextFireTime = nextFireTime;
						return;
					}
				}
			}
			if (m_ammoCount <= num5)
			{
				return;
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

	private bool c01ac61277643dcc871b0fd9206f52229()
	{
		if (m_nextFireTime < Time.fixedTime)
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
			if (m_ammoCount > 0)
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

	public void c63121b3f50cf93ab203732688f5e98d1(float ce5153005e58459c18774d81099f8d6d6)
	{
		float num = 1f / c7792c484b60d7c05b9ef0053fa855896();
		int a = 0;
		num = 1f / c7792c484b60d7c05b9ef0053fa855896();
		if (!(Time.fixedTime - m_nextFireTime > Time.fixedDeltaTime))
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
			if (m_nextFireTime != 0f)
			{
				goto IL_0076;
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
		m_nextFireTime = Time.fixedTime - Time.fixedDeltaTime;
		goto IL_0076;
		IL_0076:
		if (m_nextFireTime < Time.fixedTime)
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
			a = (int)((Time.fixedTime - m_nextFireTime) / num) + 1;
		}
		a = Mathf.Min(a, IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.CurrentAmmoCount) as IntAttributeValue));
		int num2 = a;
		int num3 = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponProjectilesPerShot) as IntAttributeValue);
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
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
			if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.cdbe6e0582d3cd852a5ba1af0c375d570(this))
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
				float c9c14a8c95c2b692926b3e06f5b03883d = Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_random_index++);
				num2 = entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.c9a052dde945512b2cc3dba220f073664(a, c9c14a8c95c2b692926b3e06f5b03883d);
				num3 = entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.c7e67956d6ba1aa89d73314b76e1a2506(num3);
			}
		}
		c147930320243a36aa445308f779c8e0e(num2);
		if (m_burstFireStage == BurstFireStage.Bursting)
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
			m_dynamicBulletBurst -= num2;
			m_BurstFinishTime = Time.fixedTime;
			if (m_dynamicBulletBurst > 0)
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
				if (m_ammoCount > 0)
				{
					goto IL_01e2;
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
			m_burstFireStage = BurstFireStage.NoneBurst;
		}
		goto IL_01e2;
		IL_01e2:
		while (a > 0)
		{
			c939a63fc73c446ecd742b08660452702(num3, ce5153005e58459c18774d81099f8d6d6, num);
			a--;
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

	private void c939a63fc73c446ecd742b08660452702(int c09569f46c38b352a696d82ebb0801998, float ce5153005e58459c18774d81099f8d6d6, float c7a8a67136f76a77eae17215f84f42d90)
	{
		c3a404b44837c5f484f8286ccc137a1fe(m_nextFireTime);
		if (base.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_dna == null)
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
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (c09569f46c38b352a696d82ebb0801998 > 1)
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
			for (int i = 0; i < c09569f46c38b352a696d82ebb0801998; i++)
			{
				AttackInfo attackInfo = new AttackInfo(AttackSubType.ProjectileGeneric);
				if (m_dna != null)
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
					if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun)
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
						attackInfo.m_subType = AttackSubType.ProjectileShotgun;
					}
					if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.SniperRifle)
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
						attackInfo.m_subType = AttackSubType.ProjectileSniper;
					}
					if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.RepeaterPistol)
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
						attackInfo.m_subType = AttackSubType.ProjectilePistol;
					}
					if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.CombatRifle)
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
						attackInfo.m_subType = AttackSubType.ProjectileCombatRifle;
					}
				}
				attackInfo.m_attacker = cc7403315505256d19a7b92aa614a8f10();
				if (base.m_owner is EntityNpcSoldierTurret)
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
					attackInfo.m_owner = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer.cc7403315505256d19a7b92aa614a8f10();
					attackInfo.m_subType = AttackSubType.SkillTurretProjectile;
				}
				else
				{
					attackInfo.m_owner = base.m_owner.cc7403315505256d19a7b92aa614a8f10();
				}
				attackInfo.m_timeStamp = Time.time - ce5153005e58459c18774d81099f8d6d6;
				attackInfo.m_origin = cad7880776eb7b2ddfb106102d4c51bbf();
				attackInfo.m_direction = ca51cff3891be7d4fd8e63295bc512c4c(1f, 1f);
				int num = (int)FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponDamage) as FloatAttributeValue);
				if (base.m_owner is EntityNpcSoldierTurret)
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
					EntityPlayer relatedPlayer = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer;
					if (relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						num = PlayerSkillManage.c2dd18403fa78b17c55fa02287de38e78(relatedPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943(), num) * (int)relatedPlayer.ca61d6db905e9724fdacd777186a9df71();
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
					num = entityPlayer.c5e6c0e1345df3750fb99585be90b80c3(num);
				}
				int damagePoint = num / c09569f46c38b352a696d82ebb0801998;
				attackInfo.m_damagePoint = damagePoint;
				c06ca0e618478c23eba3419653a19760f<AttackManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6b07e4a0d8f8da69884b36612d555842(attackInfo);
				OnAttackToAt(attackInfo);
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
		else if (c09569f46c38b352a696d82ebb0801998 == 1)
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
			AttackInfo attackInfo2 = new AttackInfo(AttackSubType.ProjectileGeneric);
			if (m_dna != null)
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
				if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun)
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
					attackInfo2.m_subType = AttackSubType.ProjectileShotgun;
				}
				if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.SniperRifle)
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
					attackInfo2.m_subType = AttackSubType.ProjectileSniper;
				}
				if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.RepeaterPistol)
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
					attackInfo2.m_subType = AttackSubType.ProjectilePistol;
				}
				if (m_dna.c83e548e5608cd7f222098a6966b16545() == WeaponType.CombatRifle)
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
					attackInfo2.m_subType = AttackSubType.ProjectileCombatRifle;
				}
			}
			attackInfo2.m_attacker = cc7403315505256d19a7b92aa614a8f10();
			if (base.m_owner is EntityNpcSoldierTurret)
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
				attackInfo2.m_owner = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer.cc7403315505256d19a7b92aa614a8f10();
				attackInfo2.m_subType = AttackSubType.SkillTurretProjectile;
			}
			else
			{
				attackInfo2.m_owner = base.m_owner.cc7403315505256d19a7b92aa614a8f10();
			}
			attackInfo2.m_timeStamp = Time.time - ce5153005e58459c18774d81099f8d6d6;
			attackInfo2.m_origin = cad7880776eb7b2ddfb106102d4c51bbf();
			attackInfo2.m_direction = ca51cff3891be7d4fd8e63295bc512c4c(1f, 1f);
			attackInfo2.m_damagePoint = (int)FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponDamage) as FloatAttributeValue);
			if (base.m_owner is EntityNpcSoldierTurret)
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
				EntityPlayer relatedPlayer2 = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer;
				if (relatedPlayer2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					int cc94be3685c24bbbca06b26f5dc51a92c = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943();
					attackInfo2.m_damagePoint = PlayerSkillManage.c2dd18403fa78b17c55fa02287de38e78(cc94be3685c24bbbca06b26f5dc51a92c, attackInfo2.m_damagePoint) * (int)relatedPlayer2.ca61d6db905e9724fdacd777186a9df71();
				}
			}
			else if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				attackInfo2.m_damagePoint = entityPlayer.c5e6c0e1345df3750fb99585be90b80c3(attackInfo2.m_damagePoint);
			}
			c06ca0e618478c23eba3419653a19760f<AttackManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6b07e4a0d8f8da69884b36612d555842(attackInfo2);
			OnAttackToAt(attackInfo2);
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, m_dna.c5f6245b591c90000d8430fc1ca8cc4de() + "'s m_pellet < 0 !!!!");
		}
		m_currentSpread = Mathf.Clamp(m_currentSpread + m_currentView.m_AccuracyDecrease, m_currentView.m_AccuracyMax, m_currentView.m_AccuracyMin);
		m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
		m_lastFireTime = m_nextFireTime;
		m_nextFireTime += c7a8a67136f76a77eae17215f84f42d90;
		if (!c3c0e89817251f516722cc16989c59e21())
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
			c7449b87b4abb9e33cf179f366346aa7c();
			return;
		}
	}

	public bool c7f7043e0de2367bd0181a33839512fe5()
	{
		if (m_manufacturer == ItemManufacturer.Dahl)
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
			if (m_isAimActive)
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
				if (m_fixedBulletBurst > 0)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public bool c2ad87a1cfefcac8e88894aa679b33ca1()
	{
		if (m_manufacturer == ItemManufacturer.Dahl)
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
			if (m_isAimActive)
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
				if (m_fixedBulletBurst > 0)
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
					if (m_burstFireStage != BurstFireStage.Bursting)
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
						if (m_BurstFinishTime + m_delayTimeAfterBurst < Time.fixedTime)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									c96170ae6b60d73060b011c33cbfd2a30();
									return true;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	public void c96170ae6b60d73060b011c33cbfd2a30()
	{
		m_burstFireStage = BurstFireStage.Bursting;
		m_dynamicBulletBurst = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomFiringBurst) as IntAttributeValue);
	}

	public bool c0e97a4ad5a71613ca514fc6d82ba84bb()
	{
		return m_burstFireStage == BurstFireStage.Bursting;
	}

	private void OnAttackToAt(AttackInfo at)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (entityPlayer.cc6a7269e9ea93e537de47dc752b09a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c06ca0e618478c23eba3419653a19760f<ImpactManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c06ca0e618478c23eba3419653a19760f<ImpactManager>.c5ee19dc8d4cccf5ae2de225410458b86.c189918e11f8f4ad15b18a905c9adc502(at.m_origin, at.m_direction, c338e1019b68c1ba415414bd8d6cd4cae());
					}
				}
			}
			if (m_shotTrace != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (base.m_owner is EntityPlayer)
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
					Transform transform = ced69ef722ca6f581cc2cb268b54f5cf4();
					if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_shotTraceGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_shotTraceGameObject.transform.position = transform.position;
							RaycastHit hitInfo;
							if (Physics.Raycast(at.m_origin, at.m_direction, out hitInfo))
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
								m_shotTraceGameObject.transform.rotation = Quaternion.LookRotation(hitInfo.point - m_shotTraceGameObject.transform.position, Vector3.up);
							}
							else
							{
								m_shotTraceGameObject.transform.rotation = Quaternion.LookRotation(at.m_origin + at.m_direction * 3000f - m_shotTraceGameObject.transform.position, Vector3.up);
							}
						}
					}
				}
				m_shotTrace.Play();
			}
		}
		if (base.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!base.m_owner.caac907d451029d68503484a63934c93f())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					AnimationManager animationManager = base.m_owner.cb8119a2676bfbd4df00a9ed683eed91a();
					if (animationManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								animationManager.OnAttack();
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		if (base.m_owner.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
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
		base.m_owner.BroadcastMessage("OnAttack", SendMessageOptions.DontRequireReceiver);
		base.m_owner.BroadcastMessage("TriggerEffectByName", "OnAttack", SendMessageOptions.DontRequireReceiver);
	}

	public void cc30877fddf01a52230cfb5f75816e498(float c6c67184af2fd0b6d4c3609d2735b9de7, Action.ActionMessage c861de212c63da4e42109937e3cac1a44)
	{
		if (!base.m_owner)
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
			if (!base.m_owner.caac907d451029d68503484a63934c93f())
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
					{
						AnimationManager animationManager = base.m_owner.cb8119a2676bfbd4df00a9ed683eed91a();
						if ((bool)animationManager)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									base.m_owner.cb8119a2676bfbd4df00a9ed683eed91a().OnReload(c6c67184af2fd0b6d4c3609d2735b9de7);
									return;
								}
							}
						}
						return;
					}
					}
				}
			}
			base.m_owner.BroadcastMessage("OnReload", c6c67184af2fd0b6d4c3609d2735b9de7, SendMessageOptions.DontRequireReceiver);
			return;
		}
	}

	public void OnReloadAnimDone()
	{
		ce064e019fd98ec37f858b03b015d2410();
	}

	public void ce064e019fd98ec37f858b03b015d2410()
	{
		if (!base.m_owner)
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
			if (!base.m_owner.c5ca38fad98337fc5c7255384b2cd1a86())
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
				EquipmentInventoryEntity equipmentInventoryEntity = base.m_owner.c5ca38fad98337fc5c7255384b2cd1a86();
				int num = Mathf.Min(c68ed8789a1e844cef343f5216d74d25f() - m_ammoCount, equipmentInventoryEntity.c5c30fc221fd2805f9535a08995b34b98(m_attribute.m_weaponType));
				equipmentInventoryEntity.ce653df38cbca26f91f2e8654ccc7b048(equipmentInventoryEntity.c5c30fc221fd2805f9535a08995b34b98(m_attribute.m_weaponType) - num, m_attribute.m_weaponType);
				m_ammoCount += num;
				return;
			}
		}
	}

	public void c48f4b48b46aefe4d04b77e714729d9e8()
	{
		if (!base.m_owner)
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
			if (!base.m_owner.c5ca38fad98337fc5c7255384b2cd1a86())
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
				EquipmentInventoryEntity equipmentInventoryEntity = base.m_owner.c5ca38fad98337fc5c7255384b2cd1a86();
				int num = m_ammoCount + equipmentInventoryEntity.c5c30fc221fd2805f9535a08995b34b98(m_attribute.m_weaponType);
				int num2 = Mathf.Min(c68ed8789a1e844cef343f5216d74d25f(), num);
				int cfd8fa226b0f9739fe464bf6cf939f = num - num2;
				equipmentInventoryEntity.ce653df38cbca26f91f2e8654ccc7b048(cfd8fa226b0f9739fe464bf6cf939f, m_attribute.m_weaponType);
				m_ammoCount = num2;
				return;
			}
		}
	}

	public Transform cd1931e49a8ef19e9aa3033cc0e5b15e7()
	{
		if (base.gameObject.transform.childCount > 0)
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
					return base.gameObject.transform.GetChild(0).Find("b_body");
				}
			}
		}
		return null;
	}

	public Transform cd9f94a7dbaabf21910e57d865675ef67(string c8aa0e7ee156ed339de23d3fe5557b916)
	{
		Transform transform = cd1931e49a8ef19e9aa3033cc0e5b15e7();
		object result;
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			result = null;
		}
		else
		{
			result = transform.Find(c8aa0e7ee156ed339de23d3fe5557b916);
		}
		return (Transform)result;
	}

	public Transform c5a64eea3b500c4e5c237984da145338c()
	{
		if (c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun)
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
			int num = m_dna.c7f910426b3f87db67b8af4c62170e282(WeaponSubPart.ACC);
			num++;
			Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>(true);
			foreach (Transform transform in componentsInChildren)
			{
				if (!(transform.gameObject.name == "b_element_" + num))
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
				if (num != 5)
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
					return transform;
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
		return null;
	}

	public Transform ced69ef722ca6f581cc2cb268b54f5cf4()
	{
		int num = m_dna.c7f910426b3f87db67b8af4c62170e282(WeaponSubPart.BARREL);
		num++;
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>(true);
		foreach (Transform transform in componentsInChildren)
		{
			if (!(transform.gameObject.name == "b_muzzle_flash_" + num))
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
				return transform;
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			string text = "b_muzzle_flash_" + num;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "GetMuzzleTransform:" + text);
			return cd9f94a7dbaabf21910e57d865675ef67(text);
		}
	}

	public Transform c1aa27f5717c8559a49c1ddeb3a501fd6()
	{
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>(true);
		foreach (Transform transform in componentsInChildren)
		{
			if (!(transform.gameObject.name == "b_bullet_ejection"))
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
				return transform;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			string c8aa0e7ee156ed339de23d3fe5557b = "b_bullet_ejection";
			return cd9f94a7dbaabf21910e57d865675ef67(c8aa0e7ee156ed339de23d3fe5557b);
		}
	}

	public void cce6adadf40a70610ce3ae5dd40479620()
	{
	}

	public void cd93c0dd53b810158c02385f682094c2c()
	{
		if (startedInstanciatingModel)
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
			startedInstanciatingModel = true;
			StartCoroutine(cbc775b1e4ed2bdbdb83763a6bad6b652());
			return;
		}
	}

	private IEnumerator cbc775b1e4ed2bdbdb83763a6bad6b652()
	{
		yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc864175eadf2cb0caddb6b43308a8afe(m_dna, base.gameObject));
		BoxCollider boxColl = base.gameObject.GetComponent<BoxCollider>();
		if (boxColl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			boxColl = base.gameObject.AddComponent<BoxCollider>();
		}
		if (boxColl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			boxColl.size = new Vector3(0.1f, 0.1f, 0.1f);
			boxColl.center = new Vector3(0f, 0f, 0.3f);
			SkinnedMeshRenderer render = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			if (render != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				boxColl.size = new Vector3(Mathf.Max(0.1f, render.localBounds.extents.x * 2f), Mathf.Max(0.1f, render.localBounds.extents.y * 2f), Mathf.Max(0.1f, render.localBounds.extents.z * 2f));
				boxColl.center = render.localBounds.center;
				c1395e48881f07b054bc50fabaea80b76(base.gameObject, c338e1019b68c1ba415414bd8d6cd4cae());
			}
		}
		if (m_collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_collisionManager.cd93285db16841148ed53a5bbeb35cf20(false);
		}
		m_isReady = true;
	}

	public void cd2662e9afb6b96dba3deeda201efd9a2(Entity caadc19f3b6ef506913862a46cd09ddf6)
	{
		if (caadc19f3b6ef506913862a46cd09ddf6 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		c71e2faacad39f5de99408bee4edd5367(caadc19f3b6ef506913862a46cd09ddf6);
		Skeleton skeleton = caadc19f3b6ef506913862a46cd09ddf6.ccd8e6ea278245d0f158036267242e60f();
		if (skeleton == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		base.transform.parent = skeleton.cf50410620462e4c261abcb41d0a98221(c83e548e5608cd7f222098a6966b16545());
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		Collider component = GetComponent<Collider>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.enabled = false;
		}
		Rigidbody component2 = GetComponent<Rigidbody>();
		if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(component2);
		}
		base.gameObject.SetActive(true);
	}

	public void c959567c3d0deab4dacbe2081900e09fd(Entity caadc19f3b6ef506913862a46cd09ddf6)
	{
		if (caadc19f3b6ef506913862a46cd09ddf6 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		c71e2faacad39f5de99408bee4edd5367(caadc19f3b6ef506913862a46cd09ddf6);
		if (caadc19f3b6ef506913862a46cd09ddf6.c6420f67f9249b1d533531d9f351a36e0() != EntityType.Player)
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
			AnimationManagerFSM component = caadc19f3b6ef506913862a46cd09ddf6.GetComponent<AnimationManagerFSM>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component.m_animationEventController = caadc19f3b6ef506913862a46cd09ddf6.GetComponentInChildren<AnimationEventController>();
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
			if (caadc19f3b6ef506913862a46cd09ddf6.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
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
				c60bc72c7232e0af1f4bc4754774147a9();
				if (base.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (base.m_owner.caac907d451029d68503484a63934c93f())
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
						c2cf125a3ac2861ae411123eacb7237b1();
					}
				}
			}
			else
			{
				c71812e274f1771cf6d359215060ea358(caadc19f3b6ef506913862a46cd09ddf6);
			}
		}
		if (caadc19f3b6ef506913862a46cd09ddf6.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
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
			m_relatedPlayer = (EntityPlayer)caadc19f3b6ef506913862a46cd09ddf6;
		}
		else if (caadc19f3b6ef506913862a46cd09ddf6.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Npc)
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
		Skeleton skeleton = caadc19f3b6ef506913862a46cd09ddf6.ccd8e6ea278245d0f158036267242e60f();
		if (skeleton == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		base.transform.parent = skeleton.cf40f1411a71635238075b839a6650d91(c83e548e5608cd7f222098a6966b16545());
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
		Collider component2 = GetComponent<Collider>();
		if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component2.enabled = false;
		}
		Rigidbody component3 = GetComponent<Rigidbody>();
		if (component3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(component3);
		}
		base.gameObject.SetActive(false);
		base.transform.localRotation = originalRotation;
		c648824e172f398cca38d5ea4468fbaaa();
	}

	public void c2cf125a3ac2861ae411123eacb7237b1()
	{
		float c88e72398366d1e13e91e7ddc6855128b = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FirstPersonMeshFOV) as FloatAttributeValue);
		c2cf125a3ac2861ae411123eacb7237b1(c88e72398366d1e13e91e7ddc6855128b);
	}

	public void c2cf125a3ac2861ae411123eacb7237b1(float c88e72398366d1e13e91e7ddc6855128b)
	{
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (!entityPlayer)
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
			WeaponCameraControl componentInChildren = entityPlayer.GetComponentInChildren<WeaponCameraControl>();
			if (!componentInChildren)
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
				componentInChildren.c1464352f09fbabfd919a7e4e32f66660(c88e72398366d1e13e91e7ddc6855128b);
				Shader c7088de59e49f7108f520cf7e0bae167e = c87fc197b9b7c7e6233f47d9f7d914994.c7088de59e49f7108f520cf7e0bae167e;
				c7088de59e49f7108f520cf7e0bae167e = Shader.Find("Custom/ClearDepthFov");
				SkinnedMeshRenderer componentInChildren2 = GetComponentInChildren<SkinnedMeshRenderer>();
				if (m_thrWpnMat == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_thrWpnMat = UnityEngine.Object.Instantiate(componentInChildren2.material) as Material;
				}
				if (componentInChildren2.materials.Length > 1)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "the material number must be one for weapon!");
				}
				Material material = componentInChildren2.material;
				material.shader = c7088de59e49f7108f520cf7e0bae167e;
				material.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
				material.SetTexture("_Cube", c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_levelCubemap);
				return;
			}
		}
	}

	public void c494579b31bf3f1d0d5ce9a541799ca8c(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		SkinnedMeshRenderer[] componentsInChildren = GetComponentsInChildren<SkinnedMeshRenderer>(true);
		if (componentsInChildren.Length > 0)
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
			componentsInChildren[0].material.shader = Shader.Find("Custom/BOL_Wpn_MaskReflect");
			if (m_thrWpnMat != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (componentsInChildren[0].materials.Length > 1)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "The material number of weapon must be one!");
				}
				componentsInChildren[0].material.CopyPropertiesFromMaterial(m_thrWpnMat);
			}
		}
		UnityEngine.Object.Destroy(m_thrWpnMat);
		(c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer).m_equipedWeapon = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		m_relatedPlayer = c709fa52dfb309bbfe248c9f258832331.c7088de59e49f7108f520cf7e0bae167e;
		base.gameObject.SetActive(true);
		c71e2faacad39f5de99408bee4edd5367(c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e);
		base.transform.parent = c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_entityDirectory.transform;
		c22928ba890dffe12269121a385d5e069();
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.contacts.Length < 4)
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
			if (!(collision.collider is TerrainCollider))
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
				if (collision.gameObject.layer != LayerMask.NameToLayer("Walkable"))
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
			}
			if (!(m_rigidBody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_rigidBody.Sleep();
				return;
			}
		}
	}

	private void c71812e274f1771cf6d359215060ea358(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
		{
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
				return;
			}
		}
		AnimationEventController componentInChildren = c5d720f6d007abb0c4a21d6a654e405bb.GetComponentInChildren<AnimationEventController>();
		if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Transform transform = ced69ef722ca6f581cc2cb268b54f5cf4();
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "can't find muzzle flash");
				return;
			}
		}
		WeaponType weaponType = c83e548e5608cd7f222098a6966b16545();
		string c7088de59e49f7108f520cf7e0bae167e = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		string c7088de59e49f7108f520cf7e0bae167e2 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		string c8aa0e7ee156ed339de23d3fe5557b = c391c1b2b9d60b0a0c7112c21e5bb8297(c83e548e5608cd7f222098a6966b16545(), c338e1019b68c1ba415414bd8d6cd4cae());
		if (weaponType != 0)
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
			if (weaponType != WeaponType.RepeaterPistol)
			{
				if (weaponType == WeaponType.ShotGun)
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
					c7088de59e49f7108f520cf7e0bae167e = "Particles/PTL_Shotgun_Muzzle Flash_NPC";
					c7088de59e49f7108f520cf7e0bae167e2 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
				}
				else if (weaponType == WeaponType.SniperRifle)
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
					c7088de59e49f7108f520cf7e0bae167e = "Particles/PTL_Sniper_Muzzle_Flash_NPC";
					c7088de59e49f7108f520cf7e0bae167e2 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
				}
				else
				{
					c7088de59e49f7108f520cf7e0bae167e = "Particles/PTL_Smg_Muzzle Flash NPC";
					c7088de59e49f7108f520cf7e0bae167e2 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
				}
				goto IL_0115;
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
		c7088de59e49f7108f520cf7e0bae167e = "Particles/PTL_Smg_Muzzle Flash NPC";
		c7088de59e49f7108f520cf7e0bae167e2 = "Particles/PTL_Shooting Track_Continuous";
		goto IL_0115;
		IL_0115:
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c7088de59e49f7108f520cf7e0bae167e));
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			if (weaponType == WeaponType.ShotGun)
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
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
			}
			if (weaponType == WeaponType.SniperRifle)
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
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
			}
			componentInChildren.m_muzzleFlash = gameObject.GetComponent<ParticleSystem>();
			componentInChildren.m_muzzleFlash.loop = true;
			m_flashMuzzle = gameObject.particleSystem;
			m_flashMuzzle.loop = false;
			m_flashMuzzle.gameObject.SetActive(false);
		}
		if (weaponType == WeaponType.SniperRifle)
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
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Sniper_Muzzle_Resources"));
			if (gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				gameObject2.transform.parent = transform;
				gameObject2.transform.localPosition = Vector3.zero;
				componentInChildren.m_sniperLight = gameObject2.particleSystem;
				componentInChildren.m_sniperLight.loop = true;
			}
			GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Sniper_Camera_Glow"));
			if (gameObject3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				gameObject3.transform.parent = transform;
				gameObject3.transform.localPosition = Vector3.zero;
				gameObject3.transform.localRotation = Quaternion.identity;
				componentInChildren.m_cameraGlow = gameObject3;
				componentInChildren.m_cameraGlow.SetActive(false);
			}
		}
		if (c7088de59e49f7108f520cf7e0bae167e2 != null)
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
			m_shotTraceGameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c7088de59e49f7108f520cf7e0bae167e2));
			if (m_shotTraceGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_shotTraceGameObject.transform.parent = transform;
				m_shotTraceGameObject.transform.localPosition = Vector3.zero;
				m_shotTraceGameObject.transform.localRotation = Quaternion.AngleAxis(90f, Vector3.right);
				componentInChildren.m_coneFlash = m_shotTraceGameObject.GetComponent<ParticleSystem>();
				componentInChildren.m_coneFlash.loop = true;
				m_shotTrace = m_shotTraceGameObject.particleSystem;
				m_shotTrace.loop = false;
			}
		}
		GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b));
		if (gameObject4 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject4.transform.parent = transform;
			gameObject4.transform.localPosition = Vector3.zero;
			gameObject4.transform.localRotation = Quaternion.identity;
			componentInChildren.m_muzzleLight = gameObject4.GetComponent<Animation>();
			componentInChildren.m_muzzleLight.wrapMode = WrapMode.Loop;
			m_muzzleFlashLight = gameObject4.animation;
			m_muzzleFlashLight.wrapMode = WrapMode.Once;
		}
		if (weaponType != 0)
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
			c54a9f3c481345ca9b937dac9b3145510(transform);
			return;
		}
	}

	private void c39ab813baba2da33d3be85e2caa3749a(GameObject ca4addffa7dedfd07c558624500a28f1e, Transform c061e22bf0a0ff9cecb62b5d09b4cb3fb)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		if (ca4addffa7dedfd07c558624500a28f1e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "*****No flashMuzzle for the weapon*****");
					return;
				}
			}
		}
		ca4addffa7dedfd07c558624500a28f1e.name = "flashMuzzle";
		ca4addffa7dedfd07c558624500a28f1e.transform.parent = c061e22bf0a0ff9cecb62b5d09b4cb3fb;
		ca4addffa7dedfd07c558624500a28f1e.transform.localPosition = Vector3.zero;
		ca4addffa7dedfd07c558624500a28f1e.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
		ParticleSystem component = ca4addffa7dedfd07c558624500a28f1e.GetComponent<ParticleSystem>();
		Renderer renderer = component.renderer;
		if (!(renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (base.m_owner.caac907d451029d68503484a63934c93f())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						WeaponCameraControl componentInChildren = base.m_owner.GetComponentInChildren<WeaponCameraControl>();
						Material material = renderer.material;
						if ((bool)componentInChildren)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									if ((bool)material)
									{
										while (true)
										{
											switch (3)
											{
											case 0:
												break;
											default:
												material.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
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
			Shader c7088de59e49f7108f520cf7e0bae167e = c87fc197b9b7c7e6233f47d9f7d914994.c7088de59e49f7108f520cf7e0bae167e;
			c7088de59e49f7108f520cf7e0bae167e = Shader.Find("Particles/Additive");
			ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
			ParticleSystem[] array = componentsInChildren;
			foreach (ParticleSystem particleSystem in array)
			{
				Material[] materials = particleSystem.renderer.materials;
				foreach (Material material2 in materials)
				{
					material2.shader = c7088de59e49f7108f520cf7e0bae167e;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_019d;
					}
					continue;
					end_IL_019d:
					break;
				}
				particleSystem.renderer.material.shader = c7088de59e49f7108f520cf7e0bae167e;
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

	private void c9b5945b83179d18e0974ddff46a4f074(GameObject cb0d69f3f939c519fedada1aedd816bd3, Transform c061e22bf0a0ff9cecb62b5d09b4cb3fb)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		if (cb0d69f3f939c519fedada1aedd816bd3 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "*****No flashMuzzle for the weapon*****");
					return;
				}
			}
		}
		cb0d69f3f939c519fedada1aedd816bd3.name = "flashMuzzleLight";
		cb0d69f3f939c519fedada1aedd816bd3.transform.parent = c061e22bf0a0ff9cecb62b5d09b4cb3fb;
		cb0d69f3f939c519fedada1aedd816bd3.transform.localPosition = Vector3.zero;
		cb0d69f3f939c519fedada1aedd816bd3.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
	}

	private void cc805640357df6dcb7a8575bb39da7967()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		Transform transform = ced69ef722ca6f581cc2cb268b54f5cf4();
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		while (transform.childCount > 0)
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
			Transform child;
			if ((bool)(child = transform.GetChild(0)))
			{
				UnityEngine.Object.DestroyImmediate(child.gameObject);
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
			break;
		}
		c1395e48881f07b054bc50fabaea80b76(base.gameObject, c338e1019b68c1ba415414bd8d6cd4cae());
		GameObject ca4addffa7dedfd07c558624500a28f1e = ceab980ba9304b2ffa35f7640cccfe8fa(c83e548e5608cd7f222098a6966b16545(), c338e1019b68c1ba415414bd8d6cd4cae());
		GameObject cb0d69f3f939c519fedada1aedd816bd = c620bc7096b94c6fcf77b7e7250c647aa(c83e548e5608cd7f222098a6966b16545(), c338e1019b68c1ba415414bd8d6cd4cae());
		c39ab813baba2da33d3be85e2caa3749a(ca4addffa7dedfd07c558624500a28f1e, transform);
		c9b5945b83179d18e0974ddff46a4f074(cb0d69f3f939c519fedada1aedd816bd, transform);
		if (base.m_owner.caac907d451029d68503484a63934c93f())
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
			c54a9f3c481345ca9b937dac9b3145510(transform);
			return;
		}
	}

	public static void c1395e48881f07b054bc50fabaea80b76(GameObject ca6c88b9e81d117e1c288944c51e54602, AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d)
	{
		Color color = new Color(0.11372549f, 0.11372549f, 0.11372549f, 0.24313726f);
		Color color2 = new Color(0f, 0.23921569f, 38f / 51f, 0.47058824f);
		Color color3 = new Color(0.4862745f, 0.16862746f, 2f / 85f, 0.5882353f);
		Color color4 = new Color(4f / 51f, 0.39607844f, 1f / 85f, 0.5882353f);
		SkinnedMeshRenderer componentInChildren = ca6c88b9e81d117e1c288944c51e54602.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (componentInChildren.material == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			switch (cdde15e415d8c1cdd0d502ae01b80b58d)
			{
			case AttackInfo.ElementalType.None:
				componentInChildren.material.SetColor("_EmissiveColor", color);
				break;
			case AttackInfo.ElementalType.Fire:
				componentInChildren.material.SetColor("_EmissiveColor", color3);
				break;
			case AttackInfo.ElementalType.Shock:
				componentInChildren.material.SetColor("_EmissiveColor", color2);
				break;
			case AttackInfo.ElementalType.Corrosive:
				componentInChildren.material.SetColor("_EmissiveColor", color4);
				break;
			}
			return;
		}
	}

	private static GameObject ceab980ba9304b2ffa35f7640cccfe8fa(WeaponType c27b7430edc94b8f5b543605119ec4a72, AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d)
	{
		WeaponElementalManager component = c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc1971f70976931d09d855a4f000c417e().GetComponent<WeaponElementalManager>();
		string c8aa0e7ee156ed339de23d3fe5557b = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		int num = 0;
		while (true)
		{
			if (num < component.elementalConfigs.Length)
			{
				if (component.elementalConfigs[num].weapontype == c27b7430edc94b8f5b543605119ec4a72)
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
					if (component.elementalConfigs[num].elementaltype == cdde15e415d8c1cdd0d502ae01b80b58d)
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
						c8aa0e7ee156ed339de23d3fe5557b = "Particles/" + component.elementalConfigs[num].muzzleRescource;
						break;
					}
				}
				num++;
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
			break;
		}
		return (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b));
	}

	private static GameObject c620bc7096b94c6fcf77b7e7250c647aa(WeaponType c27b7430edc94b8f5b543605119ec4a72, AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d)
	{
		string c7088de59e49f7108f520cf7e0bae167e = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		c7088de59e49f7108f520cf7e0bae167e = c391c1b2b9d60b0a0c7112c21e5bb8297(c27b7430edc94b8f5b543605119ec4a72, cdde15e415d8c1cdd0d502ae01b80b58d);
		return (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c7088de59e49f7108f520cf7e0bae167e));
	}

	private static string c391c1b2b9d60b0a0c7112c21e5bb8297(WeaponType c27b7430edc94b8f5b543605119ec4a72, AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d)
	{
		WeaponElementalManager component = c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc1971f70976931d09d855a4f000c417e().GetComponent<WeaponElementalManager>();
		string result = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		int num = 0;
		while (true)
		{
			if (num < component.elementalConfigs.Length)
			{
				if (component.elementalConfigs[num].weapontype == c27b7430edc94b8f5b543605119ec4a72)
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
					if (component.elementalConfigs[num].elementaltype == cdde15e415d8c1cdd0d502ae01b80b58d)
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
						result = "Particles/" + component.elementalConfigs[num].lightRescource;
						break;
					}
				}
				num++;
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
			break;
		}
		return result;
	}

	private void c54a9f3c481345ca9b937dac9b3145510(Transform c2dce9d67cefa99abe7ec84729f52c4a1)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/WPN_ShootEffect_NPC"));
		if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			gameObject.transform.parent = c2dce9d67cefa99abe7ec84729f52c4a1;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			return;
		}
	}

	private void c75c5911f557649ea237305f0aa6ebfc2()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
		{
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
		if (m_shotTrace != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		string text2 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		WeaponType weaponType = c83e548e5608cd7f222098a6966b16545();
		if (weaponType != 0)
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
			if (weaponType != WeaponType.RepeaterPistol)
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
				if (weaponType != WeaponType.CombatRifle)
				{
					if (weaponType == WeaponType.ShotGun)
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
						text = "Particles/PTL_Shooting_Track_FirstPerson_Shotgun";
						text2 = "PTL_Shooting_Track_FirstPerson_Shotgun_Particle";
					}
					else if (weaponType == WeaponType.SniperRifle)
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
						text = "Particles/PTL_Shooting_Track_FirstPerson_Sniper";
						text2 = "PTL_Shooting_Track_FirstPerson_Sniper_Particle";
					}
					goto IL_00c5;
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
		text = "Particles/PTL_Shooting_Track_FirstPerson";
		text2 = "PTL_Shooting_Track_FirstPerson_Particle";
		goto IL_00c5;
		IL_00c5:
		if (text == null)
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
			m_shotTraceGameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(text));
			if (!(m_shotTraceGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Transform transform = m_shotTraceGameObject.transform.FindChild(text2);
				if (!(transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (!transform.gameObject.particleSystem)
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
						m_shotTrace = transform.gameObject.particleSystem;
						return;
					}
				}
			}
		}
	}

	private void c24b37dec6a0cea448d98217998c706c1()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		Transform transform = c1aa27f5717c8559a49c1ddeb3a501fd6();
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array[0] = "*****No bulletEjectionNode found for [";
					array[1] = base.name;
					array[2] = "] of type [";
					array[3] = c83e548e5608cd7f222098a6966b16545();
					array[4] = "]*****";
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat(array));
					return;
				}
				}
			}
		}
		while (transform.childCount > 0)
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
			Transform child;
			if ((bool)(child = transform.GetChild(0)))
			{
				UnityEngine.Object.DestroyImmediate(child.gameObject);
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
			break;
		}
		GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		switch (c83e548e5608cd7f222098a6966b16545())
		{
		case WeaponType.SMG:
			gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Bullet_Ejection_Smg"));
			break;
		case WeaponType.SniperRifle:
			gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Bullet_Ejection_Sniper"));
			break;
		case WeaponType.ShotGun:
			gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Bullet_Ejection_Shotgun"));
			break;
		case WeaponType.RepeaterPistol:
			gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Bullet_Ejection_Smg"));
			break;
		case WeaponType.CombatRifle:
			gameObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/PTL_Bullet_Ejection_Smg"));
			break;
		}
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "*****No bulletEjection for the weapon*****");
					return;
				}
			}
		}
		gameObject.transform.parent = transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		Renderer renderer = component.renderer;
		if (!(renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Material material = renderer.material;
			if (!material)
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
				WeaponCameraControl componentInChildren = base.m_owner.GetComponentInChildren<WeaponCameraControl>();
				if (!componentInChildren)
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
					material.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
					return;
				}
			}
		}
	}

	private void c60bc72c7232e0af1f4bc4754774147a9()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		cc805640357df6dcb7a8575bb39da7967();
		c75c5911f557649ea237305f0aa6ebfc2();
		c24b37dec6a0cea448d98217998c706c1();
	}

	public void OnPlayerRespawn()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		c75c5911f557649ea237305f0aa6ebfc2();
	}

	public void c22928ba890dffe12269121a385d5e069()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
			m_flashMuzzle = c7ef7670c971ed95fb3145d2539578635.c7088de59e49f7108f520cf7e0bae167e;
			m_bulletEjection = c7ef7670c971ed95fb3145d2539578635.c7088de59e49f7108f520cf7e0bae167e;
			m_muzzleFlashLight = c3f763cdb4e47492ee90f51d677b205cf.c7088de59e49f7108f520cf7e0bae167e;
			Transform transform = ced69ef722ca6f581cc2cb268b54f5cf4();
			if ((bool)transform)
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
				Transform transform2 = transform.FindChild("flashMuzzle");
				if (transform2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_flashMuzzle = transform2.GetComponent<ParticleSystem>();
				}
				if ((bool)transform.FindChild("flashMuzzleLight"))
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
					m_muzzleFlashLight = transform.FindChild("flashMuzzleLight").animation;
				}
			}
			else
			{
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
				array[0] = "*****flashMuzzleNode missing for [";
				array[1] = base.name;
				array[2] = "] of type [";
				array[3] = c83e548e5608cd7f222098a6966b16545();
				array[4] = "]*****";
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat(array));
			}
			Transform transform3 = c1aa27f5717c8559a49c1ddeb3a501fd6();
			if ((bool)transform3)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_bulletEjection = transform3.GetComponentInChildren<ParticleSystem>();
						return;
					}
				}
			}
			object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array2[0] = "*****bulletEjectionNode missing for [";
			array2[1] = base.name;
			array2[2] = "] of type [";
			array2[3] = c83e548e5608cd7f222098a6966b16545();
			array2[4] = "]*****";
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat(array2));
			return;
		}
	}

	private bool cd5fd5a68ca7f98b1fa84bf6f5038578d()
	{
		return IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.CanEjectBulletShells) as IntAttributeValue) > 0;
	}

	public ReloadType cb237f478d9e906a169ab28afa6ed8173()
	{
		return (ReloadType)IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ReloadType) as IntAttributeValue);
	}

	public ScopeMaskType ca5bd9cea1cbcb16947182f8e75ef28ba()
	{
		return (ScopeMaskType)IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ScopeMaskType) as IntAttributeValue);
	}

	public float c0debecd8729d45372929dc058e514e52()
	{
		float num = 1f;
		float num2 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.PutDownTime) as FloatAttributeValue);
		if (!(base.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (base.m_owner.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
			{
				return num2 * (base.m_owner as EntityPlayer).ccaf53be8b86b7016efd6970ff8c92ad3.c85f8da0801bec67f8d8eabc5fdb07dbb();
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
		return num2;
	}

	public float ca64315a1389d64b76a2d1d9832da0f3a()
	{
		float num = 1f;
		float num2 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.EquipTime) as FloatAttributeValue);
		if (!(base.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (base.m_owner.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
			{
				return num2 * (base.m_owner as EntityPlayer).ccaf53be8b86b7016efd6970ff8c92ad3.c85f8da0801bec67f8d8eabc5fdb07dbb();
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
		return num2;
	}

	public float cb4a75faedb5a5e266f1a6fbae8955f0a()
	{
		float num = 1f;
		float num2 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ReloadTime) as FloatAttributeValue);
		if (!(base.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (base.m_owner.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
			{
				return num2 * (base.m_owner as EntityPlayer).ccaf53be8b86b7016efd6970ff8c92ad3.c1234d6489af2ea5a3ff2b70ba1f6cc73();
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
		return num2;
	}

	public void c6f2004a1cbc439c9b630d1dd5c028bf3()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
			if (m_flashMuzzle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c22928ba890dffe12269121a385d5e069();
			}
			if (m_flashMuzzle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_hasScope)
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
					if (m_isAimActive)
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
						float num = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(WeaponStore.weaponStore.m_weaponDic[(int)c83e548e5608cd7f222098a6966b16545()].c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomEndFOV) as FloatAttributeValue);
						float num2 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomEndFOV) as FloatAttributeValue);
						float num3 = 0.005f * (num - num2);
						if (c83e548e5608cd7f222098a6966b16545() == WeaponType.RepeaterPistol)
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
							m_flashMuzzle.transform.localPosition = Vector3.back * (0.17f - num3);
						}
						else if (c83e548e5608cd7f222098a6966b16545() == WeaponType.SniperRifle)
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
							m_flashMuzzle.transform.localPosition = Vector3.back * (0.05f - num3);
						}
						else if (c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun)
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
							m_flashMuzzle.transform.localPosition = Vector3.back * (0.15f - num3);
						}
						else if (c83e548e5608cd7f222098a6966b16545() == WeaponType.CombatRifle)
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
							m_flashMuzzle.transform.localPosition = Vector3.back * (0.52f - num3);
						}
						else if (c83e548e5608cd7f222098a6966b16545() == WeaponType.SMG)
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
							m_flashMuzzle.transform.localPosition = Vector3.back * (0.08f - num3);
						}
					}
					else
					{
						m_flashMuzzle.transform.localPosition = Vector3.zero;
					}
				}
				m_flashMuzzle.gameObject.SetActive(true);
				m_flashMuzzle.Play();
			}
			if (m_muzzleFlashLight != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_muzzleFlashLight.clip != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_muzzleFlashLight.clip.name != null)
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
						m_muzzleFlashLight.CrossFade(m_muzzleFlashLight.clip.name, 0f);
					}
				}
			}
			if (!(base.m_owner is EntityPlayer))
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
				if (!cd5fd5a68ca7f98b1fa84bf6f5038578d())
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
					if (!(m_bulletEjection != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						m_bulletEjection.Emit(1);
						return;
					}
				}
			}
		}
	}

	private bool c3c0e89817251f516722cc16989c59e21()
	{
		if (m_noBulletSpray)
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
		return true;
	}

	private Vector3 ca51cff3891be7d4fd8e63295bc512c4c(float c47beedf037c7517d1f6fea297910519c, float c08e6add3944bb539bd63773d316812ad)
	{
		if (!c3c0e89817251f516722cc16989c59e21())
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
					return c56fad5727ffebf48f3df62074cd1bbe6();
				}
			}
		}
		float num = 0f;
		float num2 = Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomRecoilIndex++);
		float num3 = Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomRecoilIndex++);
		float num4 = Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomRecoilIndex++);
		float num5;
		if (num2 < m_currentView.m_InnerAccuracyRatio)
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
			num5 = cb29e6dbd1c18110dd8b9858b3b917fb3();
		}
		else
		{
			num5 = c5e2457e5f5a5ee09b8d116015736f31d();
		}
		num = num5;
		if (base.m_owner.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
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
			float num6 = 1f;
			if (m_isAimActive)
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
				num6 = 1f / ((EntityPlayer)base.m_owner).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ZoomAccuracy);
			}
			else
			{
				num6 = 1f / ((EntityPlayer)base.m_owner).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WeaponAccuracy);
			}
			num *= num6;
		}
		float num7 = num3 - 0.5f;
		float num8 = Mathf.Sqrt(1f - Mathf.Pow(2f * num7, 2f));
		Quaternion quaternion = Quaternion.Euler((num4 - 0.5f) * num8 * num, num7 * num, 0f);
		Vector3 direction = c56fad5727ffebf48f3df62074cd1bbe6();
		Vector3 vector = base.m_owner.transform.InverseTransformDirection(direction);
		vector = quaternion * vector;
		return base.m_owner.transform.TransformDirection(vector);
	}

	public override Vector3 c56fad5727ffebf48f3df62074cd1bbe6()
	{
		if (base.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return base.m_owner.c56fad5727ffebf48f3df62074cd1bbe6();
				}
			}
		}
		return base.c56fad5727ffebf48f3df62074cd1bbe6();
	}

	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		Debug.cd311b36270223e532813522a1f24cc90(cad7880776eb7b2ddfb106102d4c51bbf(), c56fad5727ffebf48f3df62074cd1bbe6() * 1000f);
	}

	public override Vector3 cad7880776eb7b2ddfb106102d4c51bbf()
	{
		if (base.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return base.m_owner.cad7880776eb7b2ddfb106102d4c51bbf();
				}
			}
		}
		return base.transform.position;
	}

	private float c5e2457e5f5a5ee09b8d116015736f31d()
	{
		return m_currentSpread * 0.12f;
	}

	private float cb29e6dbd1c18110dd8b9858b3b917fb3()
	{
		return m_innerSpread * 0.12f;
	}

	private void c3a404b44837c5f484f8286ccc137a1fe(float c28889657ea88db99166a8306576521b4)
	{
		float num = 0f;
		if (c28889657ea88db99166a8306576521b4 - m_lastFireTime > m_currentView.m_recoverTime)
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
			if (m_lastUpdateSpreadTime < m_lastFireTime + m_currentView.m_recoverTime)
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
				num = m_lastFireTime + m_currentView.m_recoverTime - m_lastUpdateSpreadTime;
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsPitch, ref m_recoilOffsetPitch, num, false);
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsYaw, ref m_recoilOffsetYaw, num, false);
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsKickBack, ref m_recoilOffsetKickBack, num, false);
				m_currentSpread = Mathf.Clamp(m_currentSpread - m_currentView.m_AccuracyRegenerationRateActive * (1000f * num), m_currentView.m_AccuracyMax, m_currentView.m_AccuracyMin);
				m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
				num = c28889657ea88db99166a8306576521b4 - m_lastFireTime - m_currentView.m_recoverTime;
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsPitch, ref m_recoilOffsetPitch, num, true);
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsYaw, ref m_recoilOffsetYaw, num, true);
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsKickBack, ref m_recoilOffsetKickBack, num, true);
				m_currentSpread = Mathf.Clamp(m_currentSpread - m_currentView.m_AccuracyRegenerationRateOnIdle * (1000f * num), m_currentView.m_AccuracyMax, m_currentView.m_AccuracyMin);
				m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
			}
			else
			{
				num = c28889657ea88db99166a8306576521b4 - m_lastUpdateSpreadTime;
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsPitch, ref m_recoilOffsetPitch, num, true);
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsYaw, ref m_recoilOffsetYaw, num, true);
				cd140f052112357f9e84e5657664160f7(m_recoilSettingsKickBack, ref m_recoilOffsetKickBack, num, true);
				m_currentSpread = Mathf.Clamp(m_currentSpread - m_currentView.m_AccuracyRegenerationRateOnIdle * (1000f * num), m_currentView.m_AccuracyMax, m_currentView.m_AccuracyMin);
				m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
				if (m_manufacturer == ItemManufacturer.Vladof)
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
					cfd5c39701b4945d170bd59a88d894d54(true);
				}
			}
		}
		else
		{
			num = c28889657ea88db99166a8306576521b4 - m_lastUpdateSpreadTime;
			cd140f052112357f9e84e5657664160f7(m_recoilSettingsPitch, ref m_recoilOffsetPitch, num, false);
			cd140f052112357f9e84e5657664160f7(m_recoilSettingsYaw, ref m_recoilOffsetYaw, num, false);
			cd140f052112357f9e84e5657664160f7(m_recoilSettingsKickBack, ref m_recoilOffsetKickBack, num, false);
			m_currentSpread = Mathf.Clamp(m_currentSpread - m_currentView.m_AccuracyRegenerationRateActive * (1000f * num), m_currentView.m_AccuracyMax, m_currentView.m_AccuracyMin);
			m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
			if (m_manufacturer == ItemManufacturer.Vladof)
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
				cfd5c39701b4945d170bd59a88d894d54();
			}
		}
		c4a74921343e7ac8979c2928eb859a3cb();
		m_lastUpdateSpreadTime = c28889657ea88db99166a8306576521b4;
	}

	public override void Update()
	{
		base.Update();
		if (base.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!(base.m_pickable == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (base.m_pickable.m_spinningToOwner)
				{
					goto IL_00a4;
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
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		}
		goto IL_00a4;
		IL_00a4:
		if (!c39df47367fa21412aabfef05d9972f8c())
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
			if (base.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (base.m_owner.caac907d451029d68503484a63934c93f())
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
					if (!m_isAimActive)
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
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c33d552efca40d63443e0a504daea3912(c5e2457e5f5a5ee09b8d116015736f31d() / 2f);
						m_burstFireStage = BurstFireStage.NoneBurst;
					}
					else
					{
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c33d552efca40d63443e0a504daea3912(FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyMaxZoom) as FloatAttributeValue) * 0.06f, FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.AccuracyMinZoom) as FloatAttributeValue) * 0.03f);
					}
				}
			}
			c3a404b44837c5f484f8286ccc137a1fe(Time.fixedTime);
			return;
		}
	}

	public void c6701dc281cbcd330b4dd9b8d790bab90(ref float c61c8f2ed680a81e6a732b5b181224697, ref float caffcc2863a479dfc06ba5e0962123717)
	{
		c61c8f2ed680a81e6a732b5b181224697 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomCameraAngularSpeedYaw) as FloatAttributeValue);
		caffcc2863a479dfc06ba5e0962123717 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomCameraAngularSpeedPitch) as FloatAttributeValue);
	}

	public void c7449b87b4abb9e33cf179f366346aa7c()
	{
		c590c8dccc628cb573151dc19bc6b7328(ref m_recoilSettingsYaw);
		m_recoilOffsetYaw += m_recoilSettingsYaw.m_randomOffsetMin + (m_recoilSettingsYaw.m_randomOffsetMax - m_recoilSettingsYaw.m_randomOffsetMin) * Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomRecoilIndex++);
		m_recoilOffsetYaw = Mathf.Clamp(m_recoilOffsetYaw, m_recoilSettingsYaw.m_offsetMin, m_recoilSettingsYaw.m_offsetMax);
		cf40305bb67d9e02d7dee3f86902b1649(ref m_recoilSettingsPitch);
		float num = m_recoilSettingsPitch.m_randomOffsetMin + (m_recoilSettingsPitch.m_randomOffsetMax - m_recoilSettingsPitch.m_randomOffsetMin) * Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomRecoilIndex++);
		float num2 = Mathf.Clamp(m_recoilOffsetPitch / m_recoilSettingsPitch.m_randomOffsetMax, FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchMulMin) as FloatAttributeValue), FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchMulMax) as FloatAttributeValue));
		num *= num2;
		m_recoilOffsetPitch += num;
		m_recoilOffsetPitch = Mathf.Clamp(m_recoilOffsetPitch, m_recoilSettingsPitch.m_offsetMin, m_recoilSettingsPitch.m_offsetMax);
		c268776d14847f8c011e4a364ffb53fba(ref m_recoilSettingsKickBack);
		m_recoilOffsetKickBack += m_recoilSettingsKickBack.m_randomOffsetMin + (m_recoilSettingsKickBack.m_randomOffsetMax - m_recoilSettingsKickBack.m_randomOffsetMin) * Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomRecoilIndex++);
		m_recoilOffsetKickBack = Mathf.Clamp(m_recoilOffsetKickBack, m_recoilSettingsKickBack.m_offsetMin, m_recoilSettingsKickBack.m_offsetMax);
		if (!m_isAimActive)
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
			float num3 = (base.m_owner as EntityPlayer).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WeaponRecoil);
			m_recoilOffsetYaw *= num3;
			m_recoilOffsetPitch *= num3;
			m_recoilOffsetKickBack *= num3;
			return;
		}
	}

	private void cd140f052112357f9e84e5657664160f7(RecoilSettings c7e6bfb9029303a26d69314500f450e13, ref float c52921fe9488ee3d539be727c81094423, float cad9f703d862495149cd6bddd080f050b, bool c67d548880fc4961d055e8c4b02be5133)
	{
		if (c67d548880fc4961d055e8c4b02be5133)
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
					if (c52921fe9488ee3d539be727c81094423.ce5aad699df330ff708587e4fabea8cbb(0f, 0.0001f))
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								c52921fe9488ee3d539be727c81094423 = 0f;
								return;
							}
						}
					}
					if (c52921fe9488ee3d539be727c81094423 > 0f)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								c52921fe9488ee3d539be727c81094423 -= c7e6bfb9029303a26d69314500f450e13.m_reducingRateOnIdle * cad9f703d862495149cd6bddd080f050b;
								if (c52921fe9488ee3d539be727c81094423 < 0f)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											c52921fe9488ee3d539be727c81094423 = 0f;
											return;
										}
									}
								}
								return;
							}
						}
					}
					if (c52921fe9488ee3d539be727c81094423 < 0f)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								c52921fe9488ee3d539be727c81094423 += c7e6bfb9029303a26d69314500f450e13.m_reducingRateOnIdle * cad9f703d862495149cd6bddd080f050b;
								if (c52921fe9488ee3d539be727c81094423 > 0f)
								{
									while (true)
									{
										switch (2)
										{
										case 0:
											break;
										default:
											c52921fe9488ee3d539be727c81094423 = 0f;
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
		if (c52921fe9488ee3d539be727c81094423.ce5aad699df330ff708587e4fabea8cbb(0f, 0.0001f))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					c52921fe9488ee3d539be727c81094423 = 0f;
					return;
				}
			}
		}
		if (c52921fe9488ee3d539be727c81094423 > 0f)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c52921fe9488ee3d539be727c81094423 -= c7e6bfb9029303a26d69314500f450e13.m_reducingRateActive * cad9f703d862495149cd6bddd080f050b;
					if (c52921fe9488ee3d539be727c81094423 < 0f)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								c52921fe9488ee3d539be727c81094423 = 0f;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(c52921fe9488ee3d539be727c81094423 < 0f))
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
			c52921fe9488ee3d539be727c81094423 += c7e6bfb9029303a26d69314500f450e13.m_reducingRateActive * cad9f703d862495149cd6bddd080f050b;
			if (!(c52921fe9488ee3d539be727c81094423 > 0f))
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
				c52921fe9488ee3d539be727c81094423 = 0f;
				return;
			}
		}
	}

	private void c4a74921343e7ac8979c2928eb859a3cb()
	{
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (!entityPlayer)
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
			entityPlayer.c758f3560939f4f4f4649685139ccadc4(Quaternion.Euler(m_recoilOffsetYaw, 0f, m_recoilOffsetPitch), m_recoilOffsetKickBack);
			return;
		}
	}

	public void c238e636f92b95aa1e2dc49a970f54faf(ref float cfee6ec9d0f72edba0c1441c31e6edd81, ref float ccc714c0eabb517feca15832e42c5ea24, ref float c929d6dc26794b71ada3b76f22282c0f2)
	{
		cfee6ec9d0f72edba0c1441c31e6edd81 = m_recoilOffsetPitch;
		ccc714c0eabb517feca15832e42c5ea24 = m_recoilOffsetYaw;
		c929d6dc26794b71ada3b76f22282c0f2 = m_recoilOffsetKickBack;
	}

	public void cfd5c39701b4945d170bd59a88d894d54(bool ceef6162f350373d3e1d411322532fe79 = false)
	{
		if (ceef6162f350373d3e1d411322532fe79)
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
					m_dynamicFireRate = 0f;
					return;
				}
			}
		}
		m_dynamicFireRate += FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRateIncrease) as FloatAttributeValue);
	}

	public float ca77cfbdd4dc868d27b96eca7fc5b33c4(float cefda2fdc3ce4e04f38bab77fc7998241)
	{
		ItemManufacturer manufacturer = m_manufacturer;
		if (manufacturer != 0)
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
			if (manufacturer != ItemManufacturer.Dahl)
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
			else if (m_isAimActive)
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
				if (m_fixedBulletBurst > 0)
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
					cefda2fdc3ce4e04f38bab77fc7998241 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.BurstFireRate) as FloatAttributeValue);
				}
			}
		}
		else
		{
			cefda2fdc3ce4e04f38bab77fc7998241 += m_dynamicFireRate;
			float num = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRateMax) as FloatAttributeValue);
			if (num > 0f)
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
				cefda2fdc3ce4e04f38bab77fc7998241 = Mathf.Clamp(cefda2fdc3ce4e04f38bab77fc7998241, 0f, num);
			}
			else
			{
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "Vladof weapon should have a fireRateMax bigger than 0, please check with desiger of weapon subpart setting");
			}
		}
		return cefda2fdc3ce4e04f38bab77fc7998241;
	}

	public float c7792c484b60d7c05b9ef0053fa855896()
	{
		if (m_attribute == null)
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
					return 0f;
				}
			}
		}
		float num = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRate) as FloatAttributeValue);
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			num *= entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.cba71a23bdb67f16190ef730e9b8368b9();
			num = ca77cfbdd4dc868d27b96eca7fc5b33c4(num);
		}
		return num;
	}

	public void c590c8dccc628cb573151dc19bc6b7328(ref RecoilSettings c90d73a207c8acaf9f3e8e66414df00bc)
	{
		if (m_attribute == null)
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
		if (m_isAimActive)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					c90d73a207c8acaf9f3e8e66414df00bc.m_randomOffsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomYawRandomOffsetMin) as FloatAttributeValue);
					c90d73a207c8acaf9f3e8e66414df00bc.m_randomOffsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomYawRandomOffsetMax) as FloatAttributeValue);
					c90d73a207c8acaf9f3e8e66414df00bc.m_offsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomYawOffsetMin) as FloatAttributeValue);
					c90d73a207c8acaf9f3e8e66414df00bc.m_offsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomYawOffsetMax) as FloatAttributeValue);
					c90d73a207c8acaf9f3e8e66414df00bc.m_reducingRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomYawReducingRateActive) as FloatAttributeValue);
					c90d73a207c8acaf9f3e8e66414df00bc.m_reducingRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomYawReducingRateOnIdle) as FloatAttributeValue);
					return;
				}
			}
		}
		c90d73a207c8acaf9f3e8e66414df00bc.m_randomOffsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilYawRandomOffsetMin) as FloatAttributeValue);
		c90d73a207c8acaf9f3e8e66414df00bc.m_randomOffsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilYawRandomOffsetMax) as FloatAttributeValue);
		c90d73a207c8acaf9f3e8e66414df00bc.m_offsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilYawOffsetMin) as FloatAttributeValue);
		c90d73a207c8acaf9f3e8e66414df00bc.m_offsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilYawOffsetMax) as FloatAttributeValue);
		c90d73a207c8acaf9f3e8e66414df00bc.m_reducingRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilYawReducingRateActive) as FloatAttributeValue);
		c90d73a207c8acaf9f3e8e66414df00bc.m_reducingRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilYawReducingRateOnIdle) as FloatAttributeValue);
		c90d73a207c8acaf9f3e8e66414df00bc.c894b9071105744959beb786b2750c4ef();
	}

	public void cf40305bb67d9e02d7dee3f86902b1649(ref RecoilSettings c35e01849ad4e3af4dc586a7e63dcee44)
	{
		if (m_isAimActive)
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
					c35e01849ad4e3af4dc586a7e63dcee44.m_randomOffsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomPitchRandomOffsetMin) as FloatAttributeValue);
					c35e01849ad4e3af4dc586a7e63dcee44.m_randomOffsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomPitchRandomOffsetMax) as FloatAttributeValue);
					c35e01849ad4e3af4dc586a7e63dcee44.m_offsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomPitchOffsetMin) as FloatAttributeValue);
					c35e01849ad4e3af4dc586a7e63dcee44.m_offsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomPitchOffsetMax) as FloatAttributeValue);
					c35e01849ad4e3af4dc586a7e63dcee44.m_reducingRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomPitchReducingRateActive) as FloatAttributeValue);
					c35e01849ad4e3af4dc586a7e63dcee44.m_reducingRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomPitchReducingRateOnIdle) as FloatAttributeValue);
					c35e01849ad4e3af4dc586a7e63dcee44.c894b9071105744959beb786b2750c4ef();
					return;
				}
			}
		}
		c35e01849ad4e3af4dc586a7e63dcee44.m_randomOffsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchRandomOffsetMin) as FloatAttributeValue);
		c35e01849ad4e3af4dc586a7e63dcee44.m_randomOffsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchRandomOffsetMax) as FloatAttributeValue);
		c35e01849ad4e3af4dc586a7e63dcee44.m_offsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchOffsetMin) as FloatAttributeValue);
		c35e01849ad4e3af4dc586a7e63dcee44.m_offsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchOffsetMax) as FloatAttributeValue);
		c35e01849ad4e3af4dc586a7e63dcee44.m_reducingRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchReducingRateActive) as FloatAttributeValue);
		c35e01849ad4e3af4dc586a7e63dcee44.m_reducingRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchReducingRateOnIdle) as FloatAttributeValue);
		c35e01849ad4e3af4dc586a7e63dcee44.c894b9071105744959beb786b2750c4ef();
	}

	public void c268776d14847f8c011e4a364ffb53fba(ref RecoilSettings c580c86feb29a5b9a26072281505b7201)
	{
		if (m_isAimActive)
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
					c580c86feb29a5b9a26072281505b7201.m_randomOffsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomKickBackRandomOffsetMin) as FloatAttributeValue);
					c580c86feb29a5b9a26072281505b7201.m_randomOffsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomKickBackRandomOffsetMax) as FloatAttributeValue);
					c580c86feb29a5b9a26072281505b7201.m_offsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomKickBackOffsetMin) as FloatAttributeValue);
					c580c86feb29a5b9a26072281505b7201.m_offsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomKickBackOffsetMax) as FloatAttributeValue);
					c580c86feb29a5b9a26072281505b7201.m_reducingRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomKickBackReducingRateActive) as FloatAttributeValue);
					c580c86feb29a5b9a26072281505b7201.m_reducingRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilZoomKickBackReducingRateOnIdle) as FloatAttributeValue);
					c580c86feb29a5b9a26072281505b7201.c894b9071105744959beb786b2750c4ef();
					return;
				}
			}
		}
		c580c86feb29a5b9a26072281505b7201.m_randomOffsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilKickBackRandomOffsetMin) as FloatAttributeValue);
		c580c86feb29a5b9a26072281505b7201.m_randomOffsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilKickBackRandomOffsetMax) as FloatAttributeValue);
		c580c86feb29a5b9a26072281505b7201.m_offsetMin = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilKickBackOffsetMin) as FloatAttributeValue);
		c580c86feb29a5b9a26072281505b7201.m_offsetMax = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilKickBackOffsetMax) as FloatAttributeValue);
		c580c86feb29a5b9a26072281505b7201.m_reducingRateActive = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilKickBackReducingRateActive) as FloatAttributeValue);
		c580c86feb29a5b9a26072281505b7201.m_reducingRateOnIdle = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilKickBackReducingRateOnIdle) as FloatAttributeValue);
		c580c86feb29a5b9a26072281505b7201.c894b9071105744959beb786b2750c4ef();
	}

	public void cf654a38dae47dfffc188331d5dd9b0bd()
	{
	}

	public void c3b8cee523fd6167d035ec82aaf8a4812()
	{
	}

	public void ce2f1a825ffeb786635c45df12ef45235()
	{
		m_currentSpread = Mathf.Max(m_currentView.m_AccuracyMax, m_currentView.m_AccuracyMin);
		m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
	}

	public WeaponType c83e548e5608cd7f222098a6966b16545()
	{
		return m_dna.c83e548e5608cd7f222098a6966b16545();
	}

	public float cfc0d5bc73e67cb355e0830c69ea8ffbb()
	{
		return m_reloadPercentage;
	}

	public int c68ed8789a1e844cef343f5216d74d25f()
	{
		int num = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ClipSize) as IntAttributeValue);
		if (base.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return num;
				}
			}
		}
		if (base.m_owner.c6420f67f9249b1d533531d9f351a36e0() == EntityType.Player)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return (int)((float)num * ((EntityPlayer)base.m_owner).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ClipSize));
				}
			}
		}
		return num;
	}

	public void OnCombatReload()
	{
	}

	public float cdbaa846b08ebd130487157e88e4cfe71()
	{
		float num = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalProcCoef) as FloatAttributeValue);
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3 is FirebirdManage)
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
				float num2 = entityPlayer.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WpnElementalProc);
				num *= num2;
			}
		}
		return num;
	}
}
