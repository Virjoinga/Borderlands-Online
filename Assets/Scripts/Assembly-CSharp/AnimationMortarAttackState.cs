using UnityEngine;

public class AnimationMortarAttackState : AnimationManagerState
{
	private const string MORTARATTACK_TAG = "MortarAttack";

	public bool m_attackStarted;

	private AnimatorStateInfo m_animatorInfo;

	public float m_attackDuration;

	private float m_startTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_attackStarted = false;
		m_startTime = Time.time;
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
					if (Time.time - m_startTime >= m_attackDuration)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMortarAttack", false);
								base.m_status = AnimationStatus.SUCCESS;
								return;
							}
						}
					}
					return;
				}
			}
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMortarAttack", true);
		if (!m_animatorInfo.IsTag("MortarAttack"))
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
			m_attackStarted = true;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMortarAttack", false);
	}
}
