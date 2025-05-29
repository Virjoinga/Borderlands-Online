using UnityEngine;

public class AnimationThrowWeaponState : AnimationManagerState
{
	private const string THROW_TAG = "ThrowWeapon";

	public bool m_throwStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private int m_throwLayerIndex;

	public bool m_readyToLaunch;

	public bool m_spawnNewWeapon;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_throwStarted = false;
		m_throwLayerIndex = 0;
		m_readyToLaunch = false;
		m_spawnNewWeapon = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(m_throwLayerIndex);
		if (m_throwStarted)
		{
			while (true)
			{
				switch (1)
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
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						if (m_animatorInfo.IsTag("ThrowWeapon"))
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
							break;
						}
					}
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bThrowWeapon", false);
					base.m_status = AnimationStatus.SUCCESS;
					return;
				}
			}
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bThrowWeapon", true);
		if (!m_animatorInfo.IsTag("ThrowWeapon"))
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
			m_throwStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bThrowWeapon", false);
	}
}
