using A;
using BHV;
using UnityEngine;

public class AnimationFireState : AnimationManagerState
{
	protected const string FIRE_TAG = "Fire";

	protected const string STAND_TAG = "CombatStandIdle";

	protected const string CROUCH_TAG = "CombatCrouchIdle";

	public AnimationEventController m_animationEventController;

	public EAnimationFireStep m_fireStep;

	public BHVStance m_stance = BHVStance.INVALID;

	protected EntityNpc m_entityNPC;

	public bool m_firstShotPending;

	public bool m_lastShotPending;

	protected float m_fireDuration;

	protected float m_fireTime;

	protected float m_fireIdleDuration;

	protected float m_fireIdleTime;

	public float cfd7a98e9e0dc6e7b96d719aa7ca13c98
	{
		get
		{
			return m_fireDuration;
		}
		set
		{
			m_fireDuration = value;
		}
	}

	public float c927347792f0c19e41f1b6fa39d6db3fd
	{
		get
		{
			return m_fireIdleDuration;
		}
		set
		{
			m_fireIdleDuration = value;
		}
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", true);
		m_fireTime = m_fireDuration;
		m_fireIdleTime = m_fireIdleDuration;
		m_firstShotPending = true;
		m_lastShotPending = false;
		if (m_fireTime < 0f)
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
			m_fireTime = 3f;
		}
		if (m_fireIdleTime < 0f)
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
			m_fireIdleTime = 1f;
		}
		base.m_status = AnimationStatus.PREPARE;
		m_animationEventController = m_AnimationManagerFSM.m_animationEventController;
		if (m_AnimationManagerFSM.m_isHumanoid)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
		}
		m_fireStep = EAnimationFireStep.FireShooting;
		if (m_AnimationManagerFSM.m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_entityNPC = (EntityNpc)m_AnimationManagerFSM.m_entity;
		}
		if (m_entityNPC.m_subType != EntityNpc.EntitySubType.CHR_MidgetShotgunner)
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
			int value = (int)Random.Range(0f, 1.99f);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("StanceMode", value);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_entityNPC.m_subType != EntityNpc.EntitySubType.CHR_BadassBanditKiller)
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
				if (m_entityNPC.m_subType != EntityNpc.EntitySubType.CHR_BanditKiller)
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
					if (m_entityNPC.m_subType != EntityNpc.EntitySubType.CHR_BanditRaider)
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
						if (m_entityNPC.m_subType != EntityNpc.EntitySubType.CHR_BanditScout)
						{
							goto IL_017d;
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
			}
			int value = 0;
			bool value2 = false;
			if (m_stance == BHVStance.STAND)
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
				if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0).IsTag("CombatCrouchIdle"))
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
					value = 0;
				}
				else
				{
					value = 2;
					value2 = false;
				}
			}
			else if (m_stance == BHVStance.CROUCH)
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
				if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0).IsTag("CombatStandIdle"))
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
					value = 1;
				}
				else
				{
					value = 2;
					value2 = true;
				}
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", value2);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("StanceMode", value);
			goto IL_017d;
			IL_017d:
			if (m_fireStep == EAnimationFireStep.FireShooting)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						base.m_status = AnimationStatus.RUNNING;
						if (m_fireTime <= 0f)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									m_fireStep = EAnimationFireStep.FireIdle;
									m_firstShotPending = false;
									m_lastShotPending = true;
									if (m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
										m_animationEventController.OnBanditShootStop();
									}
									m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", false);
									return;
								}
							}
						}
						m_fireTime -= Time.deltaTime;
						if (m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						return;
					}
				}
			}
			if (m_fireStep == EAnimationFireStep.FireIdle)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (m_fireIdleTime <= 0f)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									m_fireStep = EAnimationFireStep.FireFinish;
									return;
								}
							}
						}
						m_fireIdleTime -= Time.deltaTime;
						return;
					}
				}
			}
			if (m_fireStep != EAnimationFireStep.FireFinish)
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
				base.m_status = AnimationStatus.SUCCESS;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.m_status = AnimationStatus.SUCCESS;
		m_firstShotPending = false;
		m_lastShotPending = false;
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animationEventController.OnBanditShootStop();
		}
		if (!(m_AnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", false);
				return;
			}
		}
	}
}
