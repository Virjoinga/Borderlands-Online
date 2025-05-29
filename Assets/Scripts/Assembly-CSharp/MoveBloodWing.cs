using A;
using BHV_Skill;
using Photon;
using UnityEngine;
using XsdSettings;

public class MoveBloodWing : Photon.MonoBehaviour
{
	public enum LifeEndType
	{
		Explosion = 0,
		FlyBack = 1,
		PlayerDie = 2
	}

	public enum TargetType
	{
		FlyingAway = 0,
		TurningBack = 1,
		FlyingBack = 2,
		Dive = 3,
		Dead = 4,
		Hover = 5,
		Chase = 6
	}

	public enum ColliderType
	{
		Enviorment = 0,
		Npc = 1,
		Player_TeamMate = 2,
		Player_Enemy = 3,
		Unknown = 4
	}

	private TargetType m_target;

	private Animator m_animator;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime_dive = -1f;

	private float m_length_dive;

	private EntityPlayer m_owner_player;

	private PlayerController m_playercontroller;

	public VFXManager m_vfxMgr;

	private float m_delay_networkDestroy = 3f;

	private Vector3 m_pos_whenFlyBack = Vector3.zero;

	private float m_progress;

	private float m_velocity_flyback = -1f;

	private bool m_bFirstTick;

	private Vector3 m_offset_spawnpoint = new Vector3(-0.2f, 0.8f, 0.5f);

	private BHVSkillSettingsFireBird m_setting;

	private float m_flyaway_leftTime;

	private float m_flashVfxPeriod = 1f;

	private float m_flashVfxTime;

	private Utils.Timer m_chainTimer = new Utils.Timer();

	private int m_chainNum;

	private int[] m_chainRandomAngles = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(3);

	private Entity m_chase_target;

	private float m_chase_radius = 2f;

	private Vector3 m_chaseHoverDir = Vector3.zero;

	private void Awake()
	{
		m_animator = GetComponent<Animator>();
		m_vfxMgr = GetComponent<VFXManager>();
	}

	private void Start()
	{
		c71e2faacad39f5de99408bee4edd5367();
		ccc9d3a38966dc10fedb531ea17d24611();
		m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FireBirdSpawn);
		m_bFirstTick = true;
		c07fb8a46859cab851160660a7268f2b0();
		if (!m_owner_player.c02f3d4a4e7d1edee179f9bf7e16aeb82.caa378d123472dde8837de8804cbf0182(ESkillType.Ignition))
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
			m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.c6eb2695eb8c7e4e60396c781791597bc(true);
			return;
		}
	}

	private void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_setting = m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.cd3d8b35d2647005675ba92178c253805<BHVSkillSettingsFireBird>();
		m_flyaway_leftTime = cabcbcec1a966ff76a9224f70b1600872();
		base.transform.localScale *= m_setting.m_sizeScale;
		Transform transform = m_owner_player.GetComponent<PlayerController>().ce2053aa14178b14997db504c8a6e907e();
		base.transform.position = transform.position + transform.TransformDirection(m_offset_spawnpoint);
		m_progress = 0f;
		base.transform.LookAt(transform.position + transform.TransformDirection(Vector3.up).normalized * 100f);
	}

	private void FixedUpdate()
	{
		if (base.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (base.transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_target == TargetType.FlyingAway)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					Vector3 translation = base.transform.forward * m_setting.m_flyaway_velocity * Time.deltaTime;
					base.transform.Translate(translation, Space.World);
					m_flyaway_leftTime -= Time.deltaTime;
					m_progress = Mathf.Clamp(1f - m_flyaway_leftTime / m_setting.m_flyaway_duration, 0f, 1f);
					if (m_flyaway_leftTime <= 0f)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								m_progress = 1f;
								FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[FlyingAway]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
								m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FirebirdReachEnd);
								if (m_target == TargetType.FlyingAway)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
											FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[FlyingAway]  Error! Still in FlyingAway");
											OnLifeEnd(LifeEndType.FlyBack);
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
		if (m_target == TargetType.Chase)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (m_chase_target != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_chase_target.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							base.transform.position = m_chase_target.transform.position - m_chaseHoverDir * m_chase_radius;
						}
					}
					m_flyaway_leftTime -= Time.deltaTime;
					m_progress = Mathf.Clamp(1f - m_flyaway_leftTime / m_setting.m_flyaway_duration, 0f, 1f);
					if (m_flyaway_leftTime <= 0f)
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
						m_progress = 1f;
						FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Chase]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
						m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FirebirdReachEnd);
					}
					c35a5665a531a78a4cedb29a94028276b();
					return;
				}
			}
		}
		if (m_target == TargetType.FlyingBack)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					Vector3 vector = c02b19f62d7d6f7ea45dfcfe42d99eeb4();
					Vector3 normalized = (vector - base.transform.position).normalized;
					Vector3 translation2 = normalized * c82109a39ab329a941cc786f2c7c25353() * Time.deltaTime;
					base.transform.Translate(translation2, Space.World);
					base.transform.LookAt(vector);
					Vector3 a = c02b19f62d7d6f7ea45dfcfe42d99eeb4();
					float num = Vector3.Distance(base.transform.position, m_pos_whenFlyBack);
					float num2 = Vector3.Distance(a, m_pos_whenFlyBack) - m_setting.m_radius_recall;
					m_progress = Mathf.Clamp(num / num2, 0f, 1f);
					float num3 = Vector3.Distance(a, base.transform.position);
					if (num3 < m_setting.m_radius_recall)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[FlyingBack]  OnLifeEnd(LifeEndType.FlyBack)");
								m_progress = 1f;
								m_vfxMgr.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_FireBird_Absorb);
								OnLifeEnd(LifeEndType.FlyBack);
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		if (m_target != TargetType.Hover)
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
			m_flyaway_leftTime -= Time.deltaTime;
			m_progress = Mathf.Clamp(1f - m_flyaway_leftTime / m_setting.m_flyaway_duration, 0f, 1f);
			if (m_flyaway_leftTime <= 0f)
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
				FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Hover]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
				m_progress = 1f;
				m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FirebirdReachEnd);
			}
			c35a5665a531a78a4cedb29a94028276b();
			Vector3 translation3 = base.transform.up * 0.25f * Time.deltaTime;
			base.transform.Translate(translation3, Space.World);
			base.transform.LookAt(c02b19f62d7d6f7ea45dfcfe42d99eeb4());
			return;
		}
	}

	private void c35a5665a531a78a4cedb29a94028276b()
	{
		m_flashVfxTime -= Time.deltaTime;
		if (!(m_flashVfxTime <= 0f))
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
			m_flashVfxTime = m_flashVfxPeriod;
			m_vfxMgr.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_FireBird_Flash);
			return;
		}
	}

	private void Update()
	{
		cb2b6932cf7402bdf1920675fb7417f2f();
		c49e6172754a3b4baa8cd50fa1485e147();
		ccdbc9f06f661db539d117ed8714235ba();
		c2f549b4d21457e368db93cf84d1d1b43();
		ce47d7ddbe00f90d1675ee1d48f8e0c47();
	}

	private void cb2b6932cf7402bdf1920675fb7417f2f()
	{
		if (!m_bFirstTick)
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
			m_bFirstTick = false;
			m_vfxMgr.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_FireBird_Tailing, base.transform);
			m_vfxMgr.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_FireBird_WingTips_L, base.transform);
			m_vfxMgr.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_FireBird_WingTips_R, base.transform);
			return;
		}
	}

	private void c2f549b4d21457e368db93cf84d1d1b43()
	{
		m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnUpdateProgress_Skill(m_progress);
	}

	private void c9672f03f52a02794cdca6f2a14aa88b2()
	{
		if (m_target != TargetType.Dead)
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
			m_delay_networkDestroy -= Time.deltaTime;
			if (!(m_delay_networkDestroy <= 0f))
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
				cbd408c443c38ec2d0b3c6b598aabee15();
				return;
			}
		}
	}

	private void c49e6172754a3b4baa8cd50fa1485e147()
	{
		if (m_target != TargetType.Dive)
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
			m_animatorInfo = m_animator.GetCurrentAnimatorStateInfo(0);
			if (m_animatorInfo.IsTag("End"))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Update_DiveAnim  IsTag(End)]  OnLifeEnd(LifeEndType.Explosion)");
						OnLifeEnd(LifeEndType.Explosion);
						return;
					}
				}
			}
			if (!m_animatorInfo.IsTag("Dive"))
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
			if (m_startTime_dive < 0f)
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
				m_startTime_dive = Time.time;
				m_length_dive = m_animatorInfo.length;
			}
			if (!c7ab5b7aef9fa6ca72da8afdd1de01d10(0.95f))
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
				FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Update_DiveAnim AtAnimLength(0.95f)]  OnLifeEnd(LifeEndType.Explosion)");
				OnLifeEnd(LifeEndType.Explosion);
				return;
			}
		}
	}

	private void ccdbc9f06f661db539d117ed8714235ba()
	{
		if (m_target != TargetType.TurningBack)
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
			m_animatorInfo = m_animator.GetCurrentAnimatorStateInfo(0);
			if (m_animatorInfo.IsTag("End"))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Update_TurnBackAnim  IsTag(End)]  OnLifeEnd(LifeEndType.Explosion)");
						OnLifeEnd(LifeEndType.Explosion);
						return;
					}
				}
			}
			if (!m_animatorInfo.IsTag("ReCall"))
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
			if (m_startTime_dive < 0f)
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
				m_startTime_dive = Time.time;
				m_length_dive = m_animatorInfo.length;
			}
			if (!c7ab5b7aef9fa6ca72da8afdd1de01d10(0.8f))
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
				FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Update_TurnBackAnim AtAnimLength(0.8f)]  OnFlyBack()");
				m_animator.SetBool("bReCall", false);
				OnFlyBack();
				return;
			}
		}
	}

	public void OnLifeEnd(LifeEndType _type)
	{
		FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[OnLifeEnd] Enter");
		cf29d92cf53090f29251f502d8ab0cc05(TargetType.Dead);
		cce6adadf40a70610ce3ae5dd40479620();
		if (_type == LifeEndType.Explosion)
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
					cd8d5436b0bbcdf2fee98678e1327bba1();
					FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[OnLifeEnd] OnSkillEvent(SkillEvent.FireBirdExplode)");
					m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FireBirdExplode);
					return;
				}
			}
		}
		if (_type != LifeEndType.FlyBack)
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
			FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[OnLifeEnd] OnSkillEvent(SkillEvent.FireBirdAbsorb)");
			m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FireBirdAbsorb);
			return;
		}
	}

	private void ce47d7ddbe00f90d1675ee1d48f8e0c47()
	{
		if (!m_chainTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			if (m_chainNum <= 0)
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
				m_chainNum--;
				if (m_chainNum > 0)
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
					m_chainTimer.Start(m_setting.m_chainInterval);
				}
				c831bc9b47718dc268a0148cd051a24a7(c423c82b60606470cae291fa7b0327360(m_chainNum));
				return;
			}
		}
	}

	private void cd8d5436b0bbcdf2fee98678e1327bba1()
	{
		c831bc9b47718dc268a0148cd051a24a7(base.transform.position);
		m_chainNum = (int)m_owner_player.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FirebirdExplodeChainNum);
		if (m_chainNum <= 0)
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
			m_chainTimer.Start(m_setting.m_chainInterval);
			return;
		}
	}

	private void c831bc9b47718dc268a0148cd051a24a7(Vector3 c2b467f5db1c8d952ae548daac0aeb759)
	{
		m_vfxMgr.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_FireBird_Burst, c2b467f5db1c8d952ae548daac0aeb759, Quaternion.identity);
	}

	private void c07fb8a46859cab851160660a7268f2b0()
	{
		if (base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45 == null)
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
			m_chainRandomAngles[0] = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[1];
			m_chainRandomAngles[1] = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[2];
			m_chainRandomAngles[2] = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[3];
			return;
		}
	}

	private Vector3 c423c82b60606470cae291fa7b0327360(int cafa0d5e23a9ceb3de45a25d5526eb91b)
	{
		float angle = m_chainRandomAngles[cafa0d5e23a9ceb3de45a25d5526eb91b];
		Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.up);
		return base.transform.position + quaternion * (Vector3.forward * m_setting.m_chainRadius);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (m_owner_player == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_target == TargetType.Dive)
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
			if (m_target == TargetType.Dead)
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
				if (m_target == TargetType.TurningBack)
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
				switch (ce2c5616e22f3b37781e14d7f8838b0a2(other.gameObject))
				{
				case ColliderType.Enviorment:
					m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FirebirdCollideEnviorment);
					break;
				case ColliderType.Npc:
					break;
				case ColliderType.Player_Enemy:
					break;
				case ColliderType.Player_TeamMate:
					break;
				}
				return;
			}
		}
	}

	private ColliderType ce2c5616e22f3b37781e14d7f8838b0a2(GameObject c92be84c2929e14255cef0634f9677b3f)
	{
		string text = LayerMask.LayerToName(c92be84c2929e14255cef0634f9677b3f.layer);
		if (text.Equals("Default"))
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
					if (c92be84c2929e14255cef0634f9677b3f.GetComponent<EntityNpc>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return ColliderType.Npc;
							}
						}
					}
					if (c92be84c2929e14255cef0634f9677b3f.GetComponent<MinimapSwitch>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return ColliderType.Unknown;
							}
						}
					}
					return ColliderType.Enviorment;
				}
			}
		}
		if (text.Equals("Walkable"))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return ColliderType.Enviorment;
				}
			}
		}
		return ColliderType.Unknown;
	}

	private void c71e2faacad39f5de99408bee4edd5367()
	{
		if (base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45 == null)
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
			int c35f98ccbfa8c6bf09319c620b21b5dc = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[0];
			m_owner_player = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c35f98ccbfa8c6bf09319c620b21b5dc) as EntityPlayer;
			FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[SetOwner] SetFirebird(this)");
			m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.ccd4b1b5dac40c581cbd4343173219b40(this);
			return;
		}
	}

	public EntityPlayer c44e36d96da2cfca88d9eef88ae429482()
	{
		return m_owner_player;
	}

	public bool cfaee34552f2202ce84c963cb57f1406f()
	{
		return m_target == TargetType.FlyingAway;
	}

	public void OnFlyBack()
	{
		FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[OnFlyBack]");
		cf29d92cf53090f29251f502d8ab0cc05(TargetType.FlyingBack);
		m_pos_whenFlyBack = base.transform.position;
		m_progress = 0f;
	}

	public void OnTurnBack()
	{
		m_progress = 0f;
		c92b89f5a79387369b87a316c34324d65();
	}

	public TargetType cd183a5dbb084bdf2992464c044efe530()
	{
		return m_target;
	}

	private void cf29d92cf53090f29251f502d8ab0cc05(TargetType cedbe4529e02a385561d13fa067c5b14e)
	{
		FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[SetPhase] " + cedbe4529e02a385561d13fa067c5b14e);
		m_target = cedbe4529e02a385561d13fa067c5b14e;
	}

	private Vector3 c02b19f62d7d6f7ea45dfcfe42d99eeb4()
	{
		if (m_playercontroller == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playercontroller = m_owner_player.GetComponent<PlayerController>();
		}
		return m_owner_player.transform.position + Vector3.up * m_playercontroller.c0441e7262bf7c2dce29506ef75c60d86();
	}

	public bool ce003fe849cc45b85ca4570109817c796()
	{
		return m_target == TargetType.Dead;
	}

	private void cce6adadf40a70610ce3ae5dd40479620()
	{
		SkinnedMeshRenderer[] componentsInChildren = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			renderer.enabled = false;
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
			m_vfxMgr.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_FireBird_WingTips_L);
			m_vfxMgr.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_FireBird_WingTips_R);
			m_vfxMgr.c9d956169d3ec6aad567c376ca656c922(ENPCParticleType.E_FireBird_Tailing);
			m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.c6eb2695eb8c7e4e60396c781791597bc(false);
			return;
		}
	}

	private void cbd408c443c38ec2d0b3c6b598aabee15()
	{
	}

	private void OnDestroy()
	{
		if (!(m_owner_player != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_owner_player.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent(SkillEvent.FirebirdDestroyed);
			return;
		}
	}

	public void cc8d33f790843351dbc36fc0105e5b071()
	{
		FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[PlayAnim_Dive]");
		cf29d92cf53090f29251f502d8ab0cc05(TargetType.Dive);
		m_animator.SetBool("bDive", true);
	}

	private void c92b89f5a79387369b87a316c34324d65()
	{
		FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[PlayAnim_TurnBack]");
		cf29d92cf53090f29251f502d8ab0cc05(TargetType.TurningBack);
		m_animator.SetBool("bReCall", true);
	}

	public void cb9245dab7c5332b4090e1f2166812d8b()
	{
		FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[PlayAnim_Hover]");
		cf29d92cf53090f29251f502d8ab0cc05(TargetType.Hover);
		m_animator.SetBool("bHover", true);
		m_vfxMgr.c9d956169d3ec6aad567c376ca656c922(ENPCParticleType.E_FireBird_Tailing);
	}

	private bool c7ab5b7aef9fa6ca72da8afdd1de01d10(float ca30f1ce8175fcc366fda26a89783560a)
	{
		return Time.time - m_startTime_dive > m_length_dive * ca30f1ce8175fcc366fda26a89783560a;
	}

	private float c82109a39ab329a941cc786f2c7c25353()
	{
		if (m_velocity_flyback < 0f)
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
			m_velocity_flyback = m_setting.m_flyback_initVelocity;
		}
		else
		{
			m_velocity_flyback += m_setting.m_flyback_accel * Time.deltaTime;
		}
		return m_velocity_flyback;
	}

	private float cabcbcec1a966ff76a9224f70b1600872()
	{
		return m_setting.m_flyaway_duration * m_owner_player.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FirebirdDuration);
	}

	public void c116d84b25e343a44c548e2955559606a(Entity c640836cc925d59650a72d53cc3825d87)
	{
		m_chase_target = c640836cc925d59650a72d53cc3825d87;
		cf29d92cf53090f29251f502d8ab0cc05(TargetType.Chase);
		m_animator.SetBool("bHover", true);
		m_chaseHoverDir = (c640836cc925d59650a72d53cc3825d87.transform.position - base.transform.position).normalized;
	}
}
