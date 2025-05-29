using A;

public class AnimationJumpAttackCrashState : AnimationManagerState
{
	private const string JUMP_ATTACK_CRASH_TAG = "JumpAttackCrash";

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackCrash", true);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("JumpAttackCrash", 0.98f) != AnimationStatus.SUCCESS)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.m_status = m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("JumpAttackCrash", 0.98f);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (!(m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpAttackCrash", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bForceIdle", true);
			return;
		}
	}
}
