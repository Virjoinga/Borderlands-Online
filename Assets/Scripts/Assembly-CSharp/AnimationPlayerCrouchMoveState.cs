public class AnimationPlayerCrouchMoveState : PlayerAnimationState
{
	private float m_moveSpeed;

	private float m_moveDirection;

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

	public AnimationPlayerCrouchMoveState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerCrouchMove";
	}

	public void c139222162aeb0051ac37d9635fe73e12(float cf6e1a5c5132a48f8bc47958d2be74c56, float caa3dce1583965bb94b42bc2dc68988fe)
	{
		m_moveSpeed = cf6e1a5c5132a48f8bc47958d2be74c56;
		m_moveDirection = caa3dce1583965bb94b42bc2dc68988fe;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
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
			float moveDirection = m_moveDirection;
			if (!(moveDirection < 22.5f))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!((double)moveDirection > 337.5))
				{
					if (moveDirection < 67.5f)
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
						moveDirection = 45f;
					}
					else if (moveDirection < 112.5f)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						moveDirection = 90f;
					}
					else if (moveDirection < 157.5f)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						moveDirection = 45f;
						if (m_moveSpeed > 0f)
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
							m_moveSpeed *= -1f;
						}
					}
					else if (moveDirection < 202.5f)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						moveDirection = 0f;
						if (m_moveSpeed > 0f)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							m_moveSpeed *= -1f;
						}
					}
					else if (moveDirection < 247.5f)
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
						moveDirection = -45f;
						if (m_moveSpeed > 0f)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							m_moveSpeed *= -1f;
						}
					}
					else if (moveDirection < 292.5f)
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
						moveDirection = -90f;
					}
					else
					{
						moveDirection = -45f;
					}
					goto IL_018d;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			moveDirection = 0f;
			goto IL_018d;
			IL_018d:
			c06739986a9474e249bf49d8330a68ce0("bMove", true);
			c06739986a9474e249bf49d8330a68ce0("bIdle", false);
			c4363c9ee832d0d0155375ca61d99d853("fDirection", moveDirection / 180f);
			c4363c9ee832d0d0155375ca61d99d853("fSpeed", m_moveSpeed);
			c06739986a9474e249bf49d8330a68ce0("bIsCrouch", true);
			if (!base.c90e194560a86112d38f669898a54a249)
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
				ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_CrouchMove);
				cb306162a8032e25a87c8a3cfc617cc8c("fDirection", moveDirection);
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
	}
}
