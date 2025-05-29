public class AnimationHoverPatrolState : AnimationManagerState
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
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fFlyingSpeed", 10f);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
	}
}
