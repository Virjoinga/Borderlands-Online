using UnityEngine;

public class AnimationSummonExtraNPCState : AnimationManagerState
{
	private const string SUMMON_TAG = "SummonNPC";

	public bool m_summonStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public AnimationSummonExtraNPCState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "SummonExtraNPC";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_summonStarted = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_summonStarted)
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
					if (m_animatorInfo.IsTag("SummonNPC"))
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
						if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
					}
					base.m_status = AnimationStatus.SUCCESS;
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bSummonNPC", false);
					return;
				}
			}
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bSummonNPC", true);
		if (!m_animatorInfo.IsTag("SummonNPC"))
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
			m_summonStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bSummonNPC", false);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
