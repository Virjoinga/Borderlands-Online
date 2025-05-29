using UnityEngine;

public class AnimationFireFullBodyState : AnimationFireState
{
	public bool m_fallBackAfterShot;

	public bool m_shotPending;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_shotPending = false;
		if (!c3d0559469e7e55959d2a7d0e6f765380())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			int num;
			if (m_fallBackAfterShot)
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
				num = 0;
			}
			else
			{
				num = 1;
			}
			int value = num;
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("StanceMode", value);
			return;
		}
	}

	public bool c3d0559469e7e55959d2a7d0e6f765380()
	{
		if (m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_MidgetShotgunner)
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
					return true;
				}
			}
		}
		return false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_fireStep == EAnimationFireStep.FireShooting)
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
					base.m_status = AnimationStatus.RUNNING;
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
								m_firstShotPending = false;
								m_lastShotPending = true;
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", false);
								return;
							}
						}
					}
					m_fireTime -= Time.deltaTime;
					return;
				}
			}
		}
		if (m_fireStep == EAnimationFireStep.FireIdle)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (m_fireIdleTime <= 0f)
					{
						while (true)
						{
							switch (7)
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
			switch (1)
			{
			case 0:
				continue;
			}
			if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0).IsTag("Fire"))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			base.m_status = AnimationStatus.SUCCESS;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.m_status = AnimationStatus.SUCCESS;
		m_firstShotPending = false;
		m_lastShotPending = false;
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", false);
	}
}
