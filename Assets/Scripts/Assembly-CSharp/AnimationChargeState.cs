using A;
using UnityEngine;

public class AnimationChargeState : AnimationManagerState
{
	private const string CHARGE_START_TAG = "ChargeStart";

	private const string CHARGE_END_TAG = "ChargeEnd";

	private const string CHARGE_LOOP_TAG = "ChargeLoop";

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private bool m_chargePreStarted;

	private bool m_chargeEndStarted;

	private EAnimationChargeStep m_animationChargeStep;

	public EAnimationChargeStep ce8aefb20ab2781fdc33c39eb5ef73a9b
	{
		get
		{
			return m_animationChargeStep;
		}
		set
		{
			m_animationChargeStep = value;
		}
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargePre;
		m_chargePreStarted = false;
		m_chargeEndStarted = false;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeStart", true);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeLoop", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeEnd", false);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (ce8aefb20ab2781fdc33c39eb5ef73a9b == EAnimationChargeStep.ChargePre)
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
					if (m_chargePreStarted)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								if (m_animatorInfo.IsTag("ChargeStart"))
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
									if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
										break;
									}
								}
								ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargeLoop;
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeStart", false);
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeLoop", true);
								return;
							}
						}
					}
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeStart", true);
					if (!m_animatorInfo.IsTag("ChargeStart"))
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
						if (!m_animatorInfo.IsTag("ChargeLoop"))
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
							break;
						}
					}
					m_chargePreStarted = true;
					m_startTime = m_animatorInfo.normalizedTime;
					return;
				}
			}
		}
		if (ce8aefb20ab2781fdc33c39eb5ef73a9b == EAnimationChargeStep.ChargeLoop)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c0bbe9d2cb572db72fe286ed663f87001();
					c5eb81eadc10961f3bdda71ab7b98333a();
					if (m_animatorInfo.IsTag("ChargeEnd"))
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargeReach;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (ce8aefb20ab2781fdc33c39eb5ef73a9b != EAnimationChargeStep.ChargeReach)
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
			if (m_chargeEndStarted)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (m_animatorInfo.IsTag("ChargeEnd"))
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
							if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
								break;
							}
						}
						ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargeFinish;
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeEnd", false);
						base.m_status = AnimationStatus.SUCCESS;
						return;
					}
				}
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeLoop", false);
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeEnd", true);
			if (!m_animatorInfo.IsTag("ChargeEnd"))
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
				m_chargeEndStarted = true;
				m_startTime = m_animatorInfo.normalizedTime;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		ce8aefb20ab2781fdc33c39eb5ef73a9b = EAnimationChargeStep.ChargeNull;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeStart", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeLoop", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bChargeEnd", true);
	}

	private void c0bbe9d2cb572db72fe286ed663f87001()
	{
		if (m_AnimationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		float t = Mathf.Lerp(0.2f, 1f, 1f - m_destinationDistanceFactor);
		m_AnimationManagerFSM.transform.forward = Vector3.Slerp(m_AnimationManagerFSM.transform.forward, m_destinationFacing, t).normalized;
		m_turnAngle = 0f;
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("TurnAngle", m_turnAngle);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsTurning", false);
	}

	private void c5eb81eadc10961f3bdda71ab7b98333a()
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
		float t = Mathf.Lerp(0f, 0.8f, 1f - m_destinationDistanceFactor);
		m_AnimationManagerFSM.transform.position = Vector3.Lerp(m_AnimationManagerFSM.transform.position, m_destinationPosition, t);
		m_AnimationManagerFSM.GetComponent<EntityNpc>().c3bf54d312726877e5f77b6d475aef510();
	}
}
