using A;
using UnityEngine;

public class AnimationAlertState : AnimationManagerState
{
	private const string ALERT_TAG = "Alert";

	public bool m_alertStarted;

	public bool m_isWarning;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_isWarning)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsWarning", true);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsAlert", false);
			}
			else
			{
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsWarning", false);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsAlert", true);
			}
		}
		m_alertStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_alertStarted)
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
					if (m_isWarning)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								if (m_animatorInfo.IsTag("Alert"))
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
									if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
										break;
									}
								}
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsWarning", false);
								base.m_status = AnimationStatus.SUCCESS;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!m_animatorInfo.IsTag("Alert"))
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
			m_alertStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsAlert", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsWarning", false);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
