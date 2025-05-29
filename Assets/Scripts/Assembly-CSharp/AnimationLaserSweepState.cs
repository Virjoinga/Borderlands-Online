using UnityEngine;

public class AnimationLaserSweepState : AnimationManagerState
{
	private string m_animationTag = "LaserSweep";

	private bool m_sweepStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public bool m_triggetHitEvent { get; set; }

	public AnimationLaserSweepState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "LaserSweep";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLaserSweep", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
		if (m_AnimationManagerFSM.m_isHumanoid)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
		}
		m_sweepStarted = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_sweepStarted)
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
					if (m_animatorInfo.IsTag(m_animationTag))
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
						if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
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
					base.m_status = AnimationStatus.SUCCESS;
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLaserSweep", false);
					return;
				}
			}
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLaserSweep", true);
		if (!m_animatorInfo.IsTag(m_animationTag))
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
			m_sweepStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.m_status = AnimationStatus.SUCCESS;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLaserSweep", false);
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
	}
}
