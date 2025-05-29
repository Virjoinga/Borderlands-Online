public class AnimationCoverIdleBeforeFireState : AnimationManagerState
{
	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if ((bool)m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsFiring", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 5);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
	}
}
