using A;

public class AnimationCriticalState : AnimationManagerState
{
	public bool m_bStruggleEnd;

	public AnimationCriticalState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "Critical";
		m_bStruggleEnd = false;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCritical", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsStruggleLoopEnd", false);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("struggle_end", 0.98f) != AnimationStatus.SUCCESS)
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
			m_bStruggleEnd = true;
			return;
		}
	}

	public void c2cb84426c1cd54153f2ec195afb13f78(bool c264d2bfc7a6722a1ec958f4ad8e574da)
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsStruggleLoopEnd", c264d2bfc7a6722a1ec958f4ad8e574da);
	}

	public void c9b705087038f2941555886d276842c8f(bool cdd3539aa25155bd08e63e7c838cf4fb9)
	{
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCritical", cdd3539aa25155bd08e63e7c838cf4fb9);
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCritical", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsStruggleLoopEnd", true);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}
}
