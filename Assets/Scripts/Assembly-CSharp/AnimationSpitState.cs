public class AnimationSpitState : AnimationManagerState
{
	public int m_spitAttackIndex;

	public bool m_bSpitAttackAnimFinished;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_bSpitAttackAnimFinished = false;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bSpitAttack", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("SpitAttackIndex", m_spitAttackIndex);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("spit", 0.98f) != AnimationStatus.SUCCESS)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bSpitAttack", false);
			m_bSpitAttackAnimFinished = true;
			return;
		}
	}

	public void c026b86b80b40f849c0d707e8b70266be(bool c7ef6ecddc707d90e932678816b6b955b)
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bSpitAttack", c7ef6ecddc707d90e932678816b6b955b);
	}
}
