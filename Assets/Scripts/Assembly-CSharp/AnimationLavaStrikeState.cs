public class AnimationLavaStrikeState : AnimationManagerState
{
	private const string LavaStrike_TAG = "LavaStrike";

	private const string LavaStrike_JumpLoop_TAG = "JumpLoop";

	public bool m_bLavaStrikeEnd;

	public bool m_bJumpLoop;

	private bool m_bLanded;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_bLavaStrikeEnd = false;
		m_bLanded = false;
		m_bJumpLoop = false;
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bStartLavaStrikeJump", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLavaStrikeJumpLand", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLavaStrikeEnd", false);
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_bLavaStrikeEnd)
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
					return;
				}
			}
		}
		if (!m_bJumpLoop)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0).IsTag("JumpLoop"))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				m_bJumpLoop = true;
			}
		}
		if (!m_bLanded)
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
			if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("LavaStrike", 0.98f) != AnimationStatus.SUCCESS)
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
				m_bLavaStrikeEnd = true;
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLavaStrikeEnd", true);
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bStartLavaStrikeJump", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLavaStrikeJumpLand", true);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLavaStrikeEnd", true);
			return;
		}
	}

	public void OnLanded()
	{
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLavaStrikeJumpLand", true);
			m_bLanded = true;
			return;
		}
	}
}
