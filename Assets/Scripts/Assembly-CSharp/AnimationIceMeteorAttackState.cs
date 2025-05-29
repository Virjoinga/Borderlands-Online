using UnityEngine;

public class AnimationIceMeteorAttackState : AnimationManagerState
{
	private const string METEORSTART_TAG = "IceMeteorStart";

	private const string METEORLOOP_TAG = "IceMeteorLoop";

	private const string METEOREND_TAG = "IceMeteorEnd";

	public EAnimationMeteorStep m_meteorStep;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private bool m_meteorPreStarted;

	private bool m_meteorEndStarted;

	public AnimationIceMeteorAttackState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "IceMeteorAttack";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_meteorPreStarted = false;
		m_meteorEndStarted = false;
		m_meteorStep = EAnimationMeteorStep.MeteorPre;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorStart", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorLoop", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorEnd", false);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_meteorStep == EAnimationMeteorStep.MeteorPre)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_meteorPreStarted)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								if (m_animatorInfo.IsTag("IceMeteorStart"))
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
									if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
									{
										return;
									}
									while (true)
									{
										switch (2)
										{
										case 0:
											continue;
										}
										break;
									}
								}
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorStart", false);
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorLoop", true);
								m_meteorStep = EAnimationMeteorStep.MeteorLoop;
								return;
							}
						}
					}
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorStart", true);
					if (!m_animatorInfo.IsTag("IceMeteorStart"))
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
						if (!m_animatorInfo.IsTag("IceMeteorLoop"))
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
							break;
						}
					}
					m_meteorPreStarted = true;
					m_startTime = m_animatorInfo.normalizedTime;
					return;
				}
			}
		}
		if (m_meteorStep == EAnimationMeteorStep.MeteorLoop)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (m_animatorInfo.IsTag("IceMeteorEnd"))
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								m_meteorStep = EAnimationMeteorStep.MeteorFinish;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_meteorStep != EAnimationMeteorStep.MeteorFinish)
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
			if (m_meteorEndStarted)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (m_animatorInfo.IsTag("IceMeteorEnd"))
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
							if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
							{
								return;
							}
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorEnd", false);
						base.m_status = AnimationStatus.SUCCESS;
						return;
					}
				}
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorLoop", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorEnd", true);
			if (!m_animatorInfo.IsTag("IceMeteorEnd"))
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_meteorEndStarted = true;
				m_startTime = m_animatorInfo.normalizedTime;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorStart", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorLoop", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMeteorEnd", true);
	}
}
