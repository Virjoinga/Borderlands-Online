public class AnimationBurrowState : AnimationManagerState
{
	private const string ANIM_BURROW_ENTER = "BurrowEnter";

	private const string ANIM_BURROW_EXIT = "BurrowExit";

	private const string PARAM_ENTER = "bBurrowEnter";

	private const string PARAM_EXIT = "bBurrowExit";

	private bool m_bPlayBurrowOutDust;

	private EAnimationBurrowStep m_animationBurrowStep;

	public EAnimationBurrowStep c1f794dd9234741183dc11abed251450b
	{
		get
		{
			return m_animationBurrowStep;
		}
		set
		{
			m_animationBurrowStep = value;
		}
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_bPlayBurrowOutDust = true;
		c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowEnter;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowEnter", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowExit", false);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (c1f794dd9234741183dc11abed251450b == EAnimationBurrowStep.BurrowEnter)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("BurrowEnter", 0.98f) == AnimationStatus.SUCCESS)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowWait;
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowEnter", false);
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowExit", false);
								if ((bool)m_VFXManager)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Burrow);
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (c1f794dd9234741183dc11abed251450b == EAnimationBurrowStep.BurrowWait)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (c1f794dd9234741183dc11abed251450b != EAnimationBurrowStep.BurrowExit)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowExit", true);
			if ((bool)m_VFXManager)
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
				if (m_bPlayBurrowOutDust)
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
					if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("BurrowExit", 0.2f) == AnimationStatus.SUCCESS)
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
						m_bPlayBurrowOutDust = false;
						m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Burrow);
					}
				}
			}
			if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("BurrowExit", 0.98f) != AnimationStatus.SUCCESS)
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
				c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowFinish;
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowExit", false);
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		c1f794dd9234741183dc11abed251450b = EAnimationBurrowStep.BurrowNull;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowEnter", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bBurrowExit", true);
	}
}
