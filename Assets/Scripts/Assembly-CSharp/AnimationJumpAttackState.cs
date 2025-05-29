using A;
using UnityEngine;

public class AnimationJumpAttackState : AnimationManagerState
{
	private const string JUMP_ATTACK_TAKEOFF_TAG = "JumpAttackTakeOff";

	private const string JUMP_ATTACK_LAND_TAG = "JumpAttackLand";

	private const string JUMP_ATTACK_LOOP_TAG = "JumpAttackLoop";

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private bool m_takeoffStarted;

	private bool m_landStarted;

	private EAnimationJumpStep m_animationJumpStep;

	public EAnimationJumpStep c4de9959131c2e376835be9d32b952b04
	{
		get
		{
			return m_animationJumpStep;
		}
		set
		{
			m_animationJumpStep = value;
		}
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpPre;
		m_takeoffStarted = false;
		m_landStarted = false;
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLoop", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bForceIdle", false);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpNull)
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
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpPre)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (m_takeoffStarted)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								if (m_animatorInfo.IsTag("JumpAttackTakeOff"))
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
									if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
										break;
									}
								}
								c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLoop;
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLoop", true);
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", false);
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", false);
								return;
							}
						}
					}
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", true);
					if (!m_animatorInfo.IsTag("JumpAttackTakeOff"))
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
						if (!m_animatorInfo.IsTag("JumpAttackLoop"))
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
							break;
						}
					}
					m_takeoffStarted = true;
					m_startTime = m_animatorInfo.normalizedTime;
					return;
				}
			}
		}
		if (c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLoop)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (m_animatorInfo.IsTag("JumpAttackLand"))
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLand;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpLand)
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
			if (m_landStarted)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (m_animatorInfo.IsTag("JumpAttackLand"))
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
							if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
						c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpFinish;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", false);
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLoop", false);
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", true);
						base.m_status = AnimationStatus.SUCCESS;
						return;
					}
				}
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", true);
			if (!m_animatorInfo.IsTag("JumpAttackLand"))
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
				m_landStarted = true;
				m_startTime = m_animatorInfo.normalizedTime;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (m_AnimationManagerFSM.m_fullBodyNextState == AnimationStateFSM.JumpAttackCrash)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", false);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLoop", false);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", false);
			}
			else
			{
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackTakeOff", false);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLoop", false);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackLand", true);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bForceIdle", true);
			}
			c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpNull;
			return;
		}
	}
}
