using System.Collections.Generic;
using A;
using BHV_Skill;
using UnityEngine;
using XsdSettings;

public class BerserkManage : PlayerSkillManage
{
	public enum BerserkPhase
	{
		Ready = 0,
		Berserking = 1,
		Dashing = 2,
		Punch = 3,
		Cooling = 4
	}

	private float m_berserk_start;

	private float m_berserk_end;

	private float m_cooldown_start;

	private float m_cooldown_end;

	private BerserkPhase m_phase;

	private int m_rageNum = 3;

	private int m_leftRageNum = 3;

	private BHVSkillSettingsBerserk m_settings;

	private int m_dmg_inRange;

	private float m_rate_cooldown = 1f;

	private Utils.Timer m_cooldownRateTimer = new Utils.Timer();

	private int m_meleeSkill_num;

	public int ca6c6123730b2f01b0c916df905aad16f
	{
		get
		{
			return m_meleeSkill_num;
		}
		set
		{
			m_meleeSkill_num = value;
		}
	}

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		m_skillId_begin_include = ESkillType.BerserkFirstAction;
		m_skillId_end_exclude = ESkillType.TurretFirstAction;
		m_settings = cd3d8b35d2647005675ba92178c253805<BHVSkillSettingsBerserk>();
		m_skillInfo.m_current_skillID = SkillID.Berserk;
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.BerserkStomp, OnStomp);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.BerserkPunchEnd, OnPunchEnd);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.BerserkDashEnd, OnDashEnd);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.BerserkDashStateExit, OnDashStateExit);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.BerserkCoolDownStart, OnCoolDownStart);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.SkillExit, OnSkillExit);
	}

	public override void Update()
	{
		base.Update();
		float num = 0f;
		switch (m_phase)
		{
		case BerserkPhase.Berserking:
			num = Mathf.Clamp((Time.time - m_berserk_start) / (m_berserk_end - m_berserk_start), 0f, 1f);
			OnUpdateProgress_Skill(num);
			if (num >= 1f)
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
				cf29d92cf53090f29251f502d8ab0cc05(BerserkPhase.Cooling);
				c8201c053deb0d077d2657fdda21867c8();
				OnSkillEvent(SkillEvent.SkillExit);
				OnSkillEvent(SkillEvent.BerserkCoolDownStart);
				c858bfa99c220805954194514fbb0c610();
			}
			c2750e73d7a0e76aed016e99f6a769a13(ceba5deaef448cf68b43d477d263bdf17());
			break;
		case BerserkPhase.Dashing:
			c3c771101f272bf1bf4841fb1b0831fa6();
			break;
		case BerserkPhase.Cooling:
			num = Mathf.Clamp((Time.time - m_cooldown_start) * m_rate_cooldown / (m_cooldown_end - m_cooldown_start), 0f, 1f);
			OnUpdateProgress_CoolDown(num);
			if (!(num >= 1f))
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
			OnSkillEvent(SkillEvent.BerserkCoolDownEnd);
			m_phase = BerserkPhase.Ready;
			break;
		}
		if (!m_cooldownRateTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			c345668581513b1e2f6bd5de89756b9dd();
			return;
		}
	}

	public override float cba71a23bdb67f16190ef730e9b8368b9()
	{
		float num = 1f;
		if (m_phase == BerserkPhase.Berserking)
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
			num = m_settings.m_fireRate;
			num *= m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BerserkFireRate);
		}
		if (m_playerOwner.c3941dac8608f650ceb15dc36294a741c().c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun)
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
			float num2 = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.TriggerDownFireRateBoost);
			if (num2 > 1f)
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
				AnimationPlayerFireState animationPlayerFireState = m_animationMgr.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerFire)) as AnimationPlayerFireState;
				int value = (int)(animationPlayerFireState.cb1d2e2a39a3e6e0b1c0410414e4f6365() / m_settings.m_fireBoostInterval) + 1;
				value = Mathf.Clamp(value, 1, m_settings.m_fireBoostMaxPow);
				num *= Mathf.Pow(num2, value);
			}
		}
		return num;
	}

	public override void OnTriggerAction(float _delay)
	{
		m_animDelay = _delay;
	}

	public override void OnSkillTask(ESkillStatePhase _phase)
	{
		if (_phase == ESkillStatePhase.First)
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
					OnBerserkTask_1st();
					return;
				}
			}
		}
		if (_phase != ESkillStatePhase.Second)
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
			OnBerserkTask_2nd();
			return;
		}
	}

	private void OnBerserkTask_1st()
	{
		m_meleeSkill_num = 0;
		m_phase = BerserkPhase.Berserking;
		m_playerOwner.c098a9e3bea516a2ee4b9e6170de0b3e6(m_animDelay);
		OnSkillEvent(SkillEvent.BerserkChargeStart);
		m_berserk_start = Time.time;
		m_berserk_end = Time.time + c94ce42c8036c46b4b3e8327e21fffce0();
		m_leftRageNum = m_rageNum;
		m_dmg_inRange = 0;
	}

	private void OnBerserkTask_2nd()
	{
		m_phase = BerserkPhase.Dashing;
		m_playerOwner.c531fa1904aba5c91f9ea2d5bfd5e19e2(m_animDelay);
		OnSkillEvent(SkillEvent.BerserkDashStart);
		c6eb2695eb8c7e4e60396c781791597bc(false);
	}

	private float c94ce42c8036c46b4b3e8327e21fffce0()
	{
		return m_settings.m_duration * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ExtendRangeDuration);
	}

	public override bool c5989500ec6e64423320cf907a28c4cd1()
	{
		bool flag = false;
		if (m_phase == BerserkPhase.Ready)
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
		if (m_phase == BerserkPhase.Berserking)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return !m_animationMgr.ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerBerserkCharge);
				}
			}
		}
		return false;
	}

	public override float c468fbfea492ec867a1235b96939944ea(float c9f45936f2c17ac69988f93398e451ad5)
	{
		BerserkPhase berserkPhase = cd183a5dbb084bdf2992464c044efe530();
		if (berserkPhase != BerserkPhase.Dashing)
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
			if (berserkPhase != BerserkPhase.Punch)
			{
				return c9f45936f2c17ac69988f93398e451ad5;
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
		return c9f45936f2c17ac69988f93398e451ad5 * m_settings.m_rotationMultiplier;
	}

	public override Vector3 c74699dab1caa7a33358332f2adcd2f23(Vector3 ce7083ddfe8079e1afb14ce01648c5d92)
	{
		BerserkPhase berserkPhase = cd183a5dbb084bdf2992464c044efe530();
		if (berserkPhase != BerserkPhase.Dashing)
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
			if (berserkPhase != BerserkPhase.Punch)
			{
				goto IL_006a;
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
		if (base.cd7688bb64fe5a3b2c83a8ce5891f00aa)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					ce7083ddfe8079e1afb14ce01648c5d92.x *= 0.2f;
					ce7083ddfe8079e1afb14ce01648c5d92.z *= 0.2f;
					return ce7083ddfe8079e1afb14ce01648c5d92;
				}
			}
		}
		goto IL_006a;
		IL_006a:
		return ce7083ddfe8079e1afb14ce01648c5d92;
	}

	public override void OnPlayerRespawn()
	{
		cac7688b05e921e2be3f92479ba44b4a8();
	}

	public override void OnLeaveSession()
	{
	}

	private void cac7688b05e921e2be3f92479ba44b4a8()
	{
		OnSkillEvent(SkillEvent.BerserkCoolDownStart);
		OnSkillEvent(SkillEvent.BerserkCoolDownEnd);
		base.cd7688bb64fe5a3b2c83a8ce5891f00aa = false;
		m_phase = BerserkPhase.Ready;
	}

	public override void OnPostAssembly()
	{
		c6eb2695eb8c7e4e60396c781791597bc(false);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_Berserk_CureHeart, m_playerOwner.transform);
	}

	public override bool cdbe6e0582d3cd852a5ba1af0c375d570(EntityWeapon c63e77db49ee63186e474d32152b9912c)
	{
		int result;
		if (m_phase == BerserkPhase.Berserking)
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
			result = ((c63e77db49ee63186e474d32152b9912c.c729ce3b5f48e0eac3a7ead97b1d02f8d().c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override int c9a052dde945512b2cc3dba220f073664(int c7ac2b014c9a1e2781ac116cc2fdaf591, float c9c14a8c95c2b692926b3e06f5b03883d)
	{
		int result = c7ac2b014c9a1e2781ac116cc2fdaf591;
		float num = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ConsumeNoAmmo);
		if (num > 0f)
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
			if (c9c14a8c95c2b692926b3e06f5b03883d <= num)
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
				result = 0;
			}
		}
		return result;
	}

	public override int c7e67956d6ba1aa89d73314b76e1a2506(int c99e61eced0a1e01a6fc25d26ba70db65)
	{
		return c99e61eced0a1e01a6fc25d26ba70db65 + (int)m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BulletPerShot);
	}

	public override void OnDamaged(DamageContext context)
	{
		if (m_phase == BerserkPhase.Berserking)
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
			if (context.m_victim == m_playerOwner)
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
				if (context.m_killer != m_playerOwner)
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
					m_dmg_inRange += context.m_damageInfo.m_shieldDamagePoints + context.m_damageInfo.m_healthDamagePoints;
				}
			}
		}
		if (m_phase != BerserkPhase.Cooling)
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
			if (!(context.m_victim == m_playerOwner))
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
				if (!(context.m_killer != m_playerOwner))
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
					m_rate_cooldown = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.AccelCooldownWhenHurt);
					m_cooldownRateTimer.Start(2.5f);
					return;
				}
			}
		}
	}

	private void c345668581513b1e2f6bd5de89756b9dd()
	{
		m_rate_cooldown = 1f;
	}

	public override void OnPlayerKillEnemy(Entity _enemy, KillContext _context)
	{
	}

	public override bool cad91320deb5a8ef065bc5ee36fea3e2e()
	{
		bool result = false;
		float num = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.DespHealthPercent);
		if (num > 0f)
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
			float num2 = (float)m_playerOwner.c5ca38fad98337fc5c7255384b2cd1a86().ca2ff7a501878363cb1d5f0472e306620() / (float)m_playerOwner.c5ca38fad98337fc5c7255384b2cd1a86().ccfad1bf47b003333c5ddd084f14d33e7();
			if (num2 < num)
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
				result = true;
			}
		}
		return result;
	}

	public override void c36677ec303a1d28a6920e312ed95c716(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
	}

	public override bool cf5261b7a90515bca15928ed9a04778d0()
	{
		if (m_phase == BerserkPhase.Berserking)
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
			int num = (int)m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BerserkPunchCount);
			if (m_meleeSkill_num < num)
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
		return false;
	}

	private void c858bfa99c220805954194514fbb0c610()
	{
		if (m_dmg_inRange <= 0)
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
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Player_BerserkStomp);
			return;
		}
	}

	private void c3c771101f272bf1bf4841fb1b0831fa6()
	{
		if (m_playerOwner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_settings == null)
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
		List<Entity> list = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cb8a72c40c1b6db1b4a333f6af978a477();
		for (int i = 0; i < list.Count; i++)
		{
			Entity entity = list[i];
			if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EquipmentInventoryEntity equipmentInventoryEntity = entity.c5ca38fad98337fc5c7255384b2cd1a86();
			if (equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			}
			else if (equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620() <= 0)
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
			}
			else if (c52b0e4c302961935453bec436d84dc68(entity))
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
				if (!(Vector3.Distance(m_playerOwner.transform.position, entity.transform.position) < m_settings.m_punchRadius))
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
				Vector3 vector = m_playerOwner.transform.TransformDirection(Vector3.forward);
				Vector3 vector2 = entity.transform.position - m_playerOwner.transform.position;
				if (!(Vector3.Dot(vector, vector2) > 0f))
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
				if (!(Vector3.Angle(vector, vector2) < m_settings.m_punchAngle * 0.5f))
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
					OnSkillEvent(SkillEvent.BerserkDashEnd);
					ca1e2b924e9c89118aad60da409cb8df9();
					c22f04f0e766948c10c2bc20cc7c5b102();
					return;
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
				return;
			}
		}
	}

	private void c61f7cc76502ae403b6f529af06696410()
	{
	}

	private bool c52b0e4c302961935453bec436d84dc68(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		if (m_playerOwner == c6e853f452cc819532893b63942b8ed3d)
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
					return true;
				}
			}
		}
		if (c6e853f452cc819532893b63942b8ed3d.ceb10167333758220ffb9bc66317ad763() == m_playerOwner.ceb10167333758220ffb9bc66317ad763())
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
			if (!m_playerOwner.cad418535912a1c3cb6ea0ce1e4cbd114())
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
		return false;
	}

	private float ceba5deaef448cf68b43d477d263bdf17()
	{
		return m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.RegenAmmoSpeed);
	}

	private void c28af39704109f6eee9e62ae5af94fce2()
	{
		EntityShield entityShield = m_playerOwner.c136b0f223897fdf01d18a9a5e3745433();
		if (!(entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			entityShield.c0f566cbc91a795394e7799bfdbd784f8();
			return;
		}
	}

	private void c28af39704109f6eee9e62ae5af94fce2(float c4137c9b4d8c16b4f81b6060933e9e663)
	{
		EntityShield entityShield = m_playerOwner.c136b0f223897fdf01d18a9a5e3745433();
		if (!(entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			int num = entityShield.m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25();
			int cefda2fdc3ce4e04f38bab77fc = num + (int)(c4137c9b4d8c16b4f81b6060933e9e663 * (float)entityShield.m_shieldPoints.c17a506784adea8f822bee98ad9dba710());
			entityShield.m_shieldPoints.ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc);
			return;
		}
	}

	private void ca20604f52b6d2891efcf2ab36ea5aad7()
	{
		m_playerOwner.c3941dac8608f650ceb15dc36294a741c().c35c521e0bb18cb1199c9161f7daddfd7(999);
	}

	private void OnStomp()
	{
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Player_BerserkStomp);
		c6eb2695eb8c7e4e60396c781791597bc(true);
		if (m_playerOwner.caac907d451029d68503484a63934c93f())
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
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Berserk_StompShock_1st);
		}
		else
		{
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Player_BerserkStatus);
		}
		c7ea93eff4556f728a660618f05c98866(cd0d33a0343a3de936182a8c95fcaaf5f());
		cd8bca5d7418d88151f7430a66654f7ba();
		c22f04f0e766948c10c2bc20cc7c5b102();
		c28af39704109f6eee9e62ae5af94fce2();
		ca20604f52b6d2891efcf2ab36ea5aad7();
	}

	private void OnDashEnd()
	{
		if (!m_playerOwner.ce003fe849cc45b85ca4570109817c796())
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
			base.cd7688bb64fe5a3b2c83a8ce5891f00aa = true;
			m_phase = BerserkPhase.Punch;
		}
		m_playerOwner.cf513ff9980e016604182063a6fba6ce5(0f);
		OnSkillEvent(SkillEvent.BerserkPunchStart);
	}

	private void OnPunchEnd()
	{
		if (!m_playerOwner.ce003fe849cc45b85ca4570109817c796())
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
			cf29d92cf53090f29251f502d8ab0cc05(BerserkPhase.Cooling);
			c8201c053deb0d077d2657fdda21867c8();
		}
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkStatus);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkAirflow);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkDust);
	}

	private void OnDashStateExit()
	{
		if (!m_playerOwner.ce003fe849cc45b85ca4570109817c796())
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
			cf29d92cf53090f29251f502d8ab0cc05(BerserkPhase.Cooling);
			c8201c053deb0d077d2657fdda21867c8();
		}
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkStatus);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkAirflow);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkDust);
	}

	private void OnCoolDownStart()
	{
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkStatus);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkAirflow);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Player_BerserkDust);
		c6eb2695eb8c7e4e60396c781791597bc(false);
	}

	private void cf29d92cf53090f29251f502d8ab0cc05(BerserkPhase cedbe4529e02a385561d13fa067c5b14e)
	{
		m_phase = cedbe4529e02a385561d13fa067c5b14e;
	}

	private void OnSkillExit()
	{
		c5bcd25e79a5daf6cca97aeb0d2878004();
	}

	private void c5bcd25e79a5daf6cca97aeb0d2878004()
	{
	}

	private void c7ea93eff4556f728a660618f05c98866(int c383d2257867582abb4c90a879c4dda2c)
	{
	}

	private void cd8bca5d7418d88151f7430a66654f7ba()
	{
	}

	public void c22f04f0e766948c10c2bc20cc7c5b102()
	{
	}

	private float cd81453a0a38c5a93f130c6cef8ab7b69()
	{
		float stompRadius = m_settings.m_stompRadius;
		return stompRadius * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BerserkStompRadius);
	}

	private int cd0d33a0343a3de936182a8c95fcaaf5f()
	{
		float num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(m_playerOwner.c7513e66c4e0fc55e6fea9dd9cb8b9943());
		float num2 = m_settings.m_stompDamage * num;
		return (int)(num2 * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BerserkStompDamage));
	}

	public void ca1e2b924e9c89118aad60da409cb8df9()
	{
	}

	private int c729ef0e0b78213342daa84f7fc00eb89()
	{
		float num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(m_playerOwner.c7513e66c4e0fc55e6fea9dd9cb8b9943());
		return (int)(m_settings.m_punchDamage * num * m_playerOwner.ca61d6db905e9724fdacd777186a9df71());
	}

	public BerserkPhase cd183a5dbb084bdf2992464c044efe530()
	{
		return m_phase;
	}

	private void c8201c053deb0d077d2657fdda21867c8()
	{
		m_cooldown_start = Time.time;
		m_cooldown_end = Time.time + c5e9db9a512d77f6ceb8e4cf0ab1230d0();
	}

	private float c5e9db9a512d77f6ceb8e4cf0ab1230d0()
	{
		return m_settings.m_cooldown * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BerserkCoolDownDuration);
	}

	public void c5b66bbc9fbd5c36731d817ab86894762()
	{
		if (m_phase != BerserkPhase.Berserking)
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
			if (m_leftRageNum <= 0)
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
				float num = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BerserkRageDuration);
				m_berserk_end += num;
				m_leftRageNum--;
				return;
			}
		}
	}

	public override void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		if (_event != SkillEvent.BerserkExplodeOnHit)
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
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Player_BerserkStomp);
			return;
		}
	}
}
