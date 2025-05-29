using A;
using UnityEngine;

public class AnimationCoverFireState : AnimationManagerState
{
	private const string FIRE_TAG = "Fire";

	public AnimationEventController m_animationEventController;

	public EAnimationFireStep m_fireStep;

	private float m_fireDuration;

	private float m_fireTime;

	private float m_fireIdleDuration;

	private float m_fireIdleTime;

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
		m_fireTime = m_fireDuration;
		m_fireIdleTime = m_fireIdleDuration;
		if (m_fireTime < 0f)
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
			m_fireTime = 1f;
		}
		if (m_fireIdleTime < 0f)
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
			m_fireIdleTime = 1f;
		}
		base.m_status = AnimationStatus.RUNNING;
		m_animationEventController = m_AnimationManagerFSM.m_animationEventController;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 5);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
		m_fireStep = EAnimationFireStep.FireShooting;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_fireStep == EAnimationFireStep.FireShooting)
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
					if (m_fireTime <= 0f)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								m_fireStep = EAnimationFireStep.FireIdle;
								if (m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				switch (2)
				{
				case 0:
					break;
				default:
					if (m_fireIdleTime <= 0f)
					{
						while (true)
						{
							switch (1)
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
			switch (6)
			{
			case 0:
				continue;
			}
			base.m_status = AnimationStatus.SUCCESS;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animationEventController.OnBanditShootStop();
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", false);
	}
}
