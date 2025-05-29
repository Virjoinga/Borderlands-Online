using UnityEngine;

public class AnimationRailgunAttackState : AnimationManagerState
{
	private const string RAILGUN_TAG = "Railgun";

	public int m_railgunAttackIndex;

	public bool m_attackStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_attackStarted = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_attackStarted)
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
					if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
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
						if (m_animatorInfo.IsTag("Railgun"))
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
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bRailgunAttack", false);
					base.m_status = AnimationStatus.SUCCESS;
					return;
				}
			}
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bRailgunAttack", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iRailgunAttackIndex", m_railgunAttackIndex);
		if (!m_animatorInfo.IsTag("Railgun"))
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
			m_attackStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bRailgunAttack", false);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
