using A;

public class AnimationPlayerIdleState : PlayerAnimationState
{
	private float m_moveSpeed;

	public float c1c067e605f60d78f4fd6324f61461644
	{
		get
		{
			return m_moveSpeed;
		}
		set
		{
			m_moveSpeed = value;
		}
	}

	public AnimationPlayerIdleState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerIdle";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		c06739986a9474e249bf49d8330a68ce0("bMove", false);
		c06739986a9474e249bf49d8330a68ce0("bIdle", true);
		c4363c9ee832d0d0155375ca61d99d853("fSpeed", 0f);
		c4363c9ee832d0d0155375ca61d99d853("fDirection", 0f);
		c06739986a9474e249bf49d8330a68ce0("bIsCrouch", false);
		if (!base.c90e194560a86112d38f669898a54a249)
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
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_StandIdle);
			cb306162a8032e25a87c8a3cfc617cc8c("fDirection", 0f);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if ((bool)m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		base.m_status = AnimationStatus.SUCCESS;
	}
}
