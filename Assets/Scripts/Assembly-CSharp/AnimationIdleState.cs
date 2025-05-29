using BHV;

public class AnimationIdleState : AnimationManagerState
{
	public BHVStressLevel m_stressLevel;

	public AnimationIdleState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "Idle";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
			if (!m_AnimationManagerFSM.m_isHumanoid)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 0);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
				return;
			}
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", m_stressLevel == BHVStressLevel.RELAX);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
	}
}
