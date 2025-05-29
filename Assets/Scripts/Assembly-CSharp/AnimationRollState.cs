using UnityEngine;

public class AnimationRollState : AnimationManagerState
{
	private const string DODGE_TAG = "Roll";

	private bool m_rollStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public bool m_isDodgeRight = true;

	public bool m_isSideStep;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetBool("IsCrouching"))
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
			if (m_isSideStep)
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
				if (m_isDodgeRight)
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
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 4);
				}
				else
				{
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 3);
				}
			}
			else if (m_isDodgeRight)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 2);
			}
			else
			{
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 1);
			}
		}
		else if (m_isDodgeRight)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 2);
		}
		else
		{
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 1);
		}
		m_rollStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_rollStarted)
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
					if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
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
						if (m_animatorInfo.IsTag("Roll"))
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
							break;
						}
					}
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 0);
					base.m_status = AnimationStatus.SUCCESS;
					return;
				}
			}
		}
		if (!m_animatorInfo.IsTag("Roll"))
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
			m_rollStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("RollStatus", 0);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
