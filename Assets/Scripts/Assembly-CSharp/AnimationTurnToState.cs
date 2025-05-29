public class AnimationTurnToState : AnimationManagerState
{
	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
			if (!m_AnimationManagerFSM.m_isHumanoid)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("CrouchStatus", 0);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCrouching", false);
				return;
			}
		}
	}
}
