public class AnimationWebTrapState : AnimationManagerState
{
	private string m_animationTag = "ThrowWebTrap";

	public bool m_bThrowWebTrap;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_bThrowWebTrap = false;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bThrowWebTrap", true);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba(m_animationTag, 0.98f) != AnimationStatus.SUCCESS)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.m_status = AnimationStatus.SUCCESS;
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bThrowWebTrap", false);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bThrowWebTrap", false);
	}
}
