using A;
using BHV_Skill;
using Core;
using UnityEngine;
using XsdSettings;

public class FirebirdManage : PlayerSkillManage
{
	public class FirebirdBehavior : BaseSkillBehavior
	{
		protected FirebirdManage m_firebird_owner;

		public FirebirdBehavior(PlayerSkillManage cf811c0d5de19d7fe22be8d61350b722d)
			: base(cf811c0d5de19d7fe22be8d61350b722d)
		{
			m_firebird_owner = m_owner as FirebirdManage;
		}

		public virtual void OnReachEnd()
		{
		}

		public virtual void OnCollideEnviorment()
		{
		}
	}

	public class RecallBehavior : FirebirdBehavior
	{
		public RecallBehavior(PlayerSkillManage cf811c0d5de19d7fe22be8d61350b722d)
			: base(cf811c0d5de19d7fe22be8d61350b722d)
		{
		}

		public override void OnFirstAction()
		{
			m_firebird_owner.c0ede17d97028c85b620ddc81c28c44bc();
			m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdAnimStart);
		}

		public override void OnSecondAction()
		{
			m_firebird_owner.cbf6ee8d0f09235c4d61e190487395572();
			m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdTurnStart);
		}

		public override bool c2176115289098326a113fedc4000e330()
		{
			MoveBloodWing.TargetType targetType = m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().cd183a5dbb084bdf2992464c044efe530();
			return targetType == MoveBloodWing.TargetType.FlyingAway;
		}

		public override void OnReachEnd()
		{
			m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdDive);
			m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().cc8d33f790843351dbc36fc0105e5b071();
		}

		public override void OnCollideEnviorment()
		{
			m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdDive);
			m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().cc8d33f790843351dbc36fc0105e5b071();
		}
	}

	public class HoverBehavior : FirebirdBehavior
	{
		public HoverBehavior(PlayerSkillManage cf811c0d5de19d7fe22be8d61350b722d)
			: base(cf811c0d5de19d7fe22be8d61350b722d)
		{
		}

		public override void OnFirstAction()
		{
			m_firebird_owner.c0ede17d97028c85b620ddc81c28c44bc();
			m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdAnimStart);
		}

		public override void OnSecondAction()
		{
			if (!(m_firebird_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_firebird_owner.cbf6ee8d0f09235c4d61e190487395572();
				m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdDive);
				MoveBloodWing moveBloodWing = m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d();
				if (!moveBloodWing)
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
					moveBloodWing.cc8d33f790843351dbc36fc0105e5b071();
					return;
				}
			}
		}

		public override bool c2176115289098326a113fedc4000e330()
		{
			MoveBloodWing.TargetType targetType = m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().cd183a5dbb084bdf2992464c044efe530();
			int result;
			if (targetType != 0)
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
				if (targetType != MoveBloodWing.TargetType.Hover)
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
					result = ((targetType == MoveBloodWing.TargetType.Chase) ? 1 : 0);
					goto IL_0040;
				}
			}
			result = 1;
			goto IL_0040;
			IL_0040:
			return (byte)result != 0;
		}

		public override void OnReachEnd()
		{
			if (!(m_firebird_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					c3e45855b170d32c9cab624e8abd48e4f("[OnReachEnd  OK]");
					m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().m_vfxMgr.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_FireBird_Absorb);
					m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().OnLifeEnd(MoveBloodWing.LifeEndType.FlyBack);
					return;
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
			c3e45855b170d32c9cab624e8abd48e4f("[OnReachEnd  fail]");
		}

		public override void OnCollideEnviorment()
		{
			if (!(m_firebird_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					c3e45855b170d32c9cab624e8abd48e4f("[OnCollideEnviorment  OK]");
					m_firebird_owner.c3061c8f328ea8634f9bced6dab80aa4d().cb9245dab7c5332b4090e1f2166812d8b();
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
			c3e45855b170d32c9cab624e8abd48e4f("[OnCollideEnviorment  fail]");
		}
	}

	private BHVSkillSettingsFireBird m_settings;

	private MoveBloodWing m_firebird;

	public float m_cooldown_StartTime;

	public float m_cooldown_FinishTime;

	private float m_time_firebirdSpawn;

	private FirebirdBehavior c401396769a26a1a3c0e4cbecef0937a4(FireBirdBehaviorType c935987f73baf44c6b1a90e3919e6d098)
	{
		if (c935987f73baf44c6b1a90e3919e6d098 != 0)
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
					if (c935987f73baf44c6b1a90e3919e6d098 != FireBirdBehaviorType.Hover)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid FireBird Behavior: " + c935987f73baf44c6b1a90e3919e6d098);
								return null;
							}
						}
					}
					return new HoverBehavior(this);
				}
			}
		}
		return new RecallBehavior(this);
	}

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		m_skillId_begin_include = ESkillType.FirebirdFirstAction;
		m_skillId_end_exclude = ESkillType.BerserkFirstAction;
		m_settings = cd3d8b35d2647005675ba92178c253805<BHVSkillSettingsFireBird>();
		m_behavior = c401396769a26a1a3c0e4cbecef0937a4(m_settings.m_behavior);
		m_skillInfo.m_current_skillID = SkillID.FireBird;
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.ToSpawnFireBird, c595cd7fd1d0e6a90126cba0c671274b3);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FireBirdTurnStart, OnCallback);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FireBirdAbsorb, OnAbsorb);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FireBirdExplode, OnExplode);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FirebirdDestroyed, OnFirebirdDestroy);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FirebirdReachEnd, (m_behavior as FirebirdBehavior).OnReachEnd);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FirebirdCollideEnviorment, (m_behavior as FirebirdBehavior).OnCollideEnviorment);
		c2b15824eb5a2e2532e68e0501319ae90(SkillEvent.FireBirdSpawn, OnFirebirdSpawn);
	}

	public override void Update()
	{
		base.Update();
		ccfee34ed4f4edfa2dabf15024ef5f962();
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
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c3536236f69002b26addec689ed17dc6f().OnFirstAction();
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
			switch (3)
			{
			case 0:
				continue;
			}
			c3536236f69002b26addec689ed17dc6f().OnSecondAction();
			return;
		}
	}

	public override bool c5989500ec6e64423320cf907a28c4cd1()
	{
		if (!m_animationMgr.ccdc879751e4e899129390bfd75c37e16("PlayerFireBird"))
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
		return true;
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
		if ((bool)m_firebird)
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
			m_firebird.OnLifeEnd(MoveBloodWing.LifeEndType.PlayerDie);
			m_firebird = c59c5c0b0869474d780e5dd01a6bc28a2.c7088de59e49f7108f520cf7e0bae167e;
		}
		OnSkillEvent(SkillEvent.FireBirdCoolDownEnd);
		m_cooldown_FinishTime = 0f;
		cbef9051399f4beb7c8592e94d08bd887(0f);
	}

	public override void ccd4b1b5dac40c581cbd4343173219b40(MoveBloodWing c5f80bb56b3443c5a87b3da1802de1944)
	{
		m_firebird = c5f80bb56b3443c5a87b3da1802de1944;
	}

	public override void OnPostAssembly()
	{
		c6eb2695eb8c7e4e60396c781791597bc(false);
		m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType.E_Berserk_CureHeart, m_playerOwner.transform);
	}

	public override void OnDamaged(DamageContext context)
	{
	}

	public override void c36677ec303a1d28a6920e312ed95c716(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
	}

	private void OnFirebirdSpawn()
	{
		m_time_firebirdSpawn = Time.time;
	}

	private bool c74f4f474364244cf24757b71fae47901(float c704812431a0b104a6ced6cea948cd0e8)
	{
		return Time.time <= m_time_firebirdSpawn + c704812431a0b104a6ced6cea948cd0e8;
	}

	private void cbef9051399f4beb7c8592e94d08bd887(float ce73d765983baf18e1ce790677407ba18)
	{
	}

	private void OnAbsorb()
	{
		c3e45855b170d32c9cab624e8abd48e4f("[OnAbsorb] m_firebird = null");
		m_firebird = c59c5c0b0869474d780e5dd01a6bc28a2.c7088de59e49f7108f520cf7e0bae167e;
		Vector3 c912f9ac7e315af00d7f70e9f885160e = new Vector3(0f, 1.2f, 0f);
		float num = m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.RefillShield);
		if (num > 0f)
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
			m_playerOwner.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Player_AbsorbFirebird, m_playerOwner, m_playerOwner.transform, c912f9ac7e315af00d7f70e9f885160e, Quaternion.identity, 3f);
		}
		m_cooldown_StartTime = Time.time;
		m_cooldown_FinishTime = Time.time + m_settings.m_cooldown_flyback;
		cbef9051399f4beb7c8592e94d08bd887(m_cooldown_FinishTime);
	}

	private void OnExplode()
	{
		c3e45855b170d32c9cab624e8abd48e4f("[OnExplode] m_firebird = null");
		m_firebird = c59c5c0b0869474d780e5dd01a6bc28a2.c7088de59e49f7108f520cf7e0bae167e;
		m_cooldown_StartTime = Time.time;
		m_cooldown_FinishTime = Time.time + c0a0d6d1480a8b139b304da0cab6f25a8();
		cbef9051399f4beb7c8592e94d08bd887(m_cooldown_FinishTime);
	}

	private void OnCallback()
	{
		m_firebird.OnTurnBack();
	}

	private void c595cd7fd1d0e6a90126cba0c671274b3()
	{
	}

	private void OnFirebirdDestroy()
	{
	}

	private void ccfee34ed4f4edfa2dabf15024ef5f962()
	{
		float num = 0f;
		if (m_cooldown_FinishTime <= 0f)
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
			num = 0f;
		}
		else
		{
			num = (Time.time - m_cooldown_StartTime) / (m_cooldown_FinishTime - m_cooldown_StartTime);
			num = Mathf.Clamp(num, 0f, 1f);
			if (num >= 1f)
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
				OnSkillEvent(SkillEvent.FireBirdCoolDownEnd);
				m_cooldown_FinishTime = 0f;
			}
		}
		OnUpdateProgress_CoolDown(num);
	}

	private void c0ede17d97028c85b620ddc81c28c44bc()
	{
		m_playerOwner.c65a04969a82d5af643e40146d4397416(m_animDelay);
	}

	private void cbf6ee8d0f09235c4d61e190487395572()
	{
		m_playerOwner.cdae2d559d2cfebf7e06a8b2042b62a34(m_animDelay);
	}

	public MoveBloodWing c3061c8f328ea8634f9bced6dab80aa4d()
	{
		return m_firebird;
	}

	private float c0a0d6d1480a8b139b304da0cab6f25a8()
	{
		return m_settings.m_cooldown_explode * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FirebirdExplodeCooldown);
	}

	public static void c3e45855b170d32c9cab624e8abd48e4f(string cb62856f97160e0e91c381afede4ffb7a)
	{
	}
}
