using A;
using BHV;
using UnityEngine;

public class AnimationHurtState : AnimationManagerState
{
	private const string HURT_TAG = "InjuryReaction";

	private const string HURTLIGHT_TAG = "HurtLight";

	public bool m_hurtStarted;

	public EDamageType m_damageType;

	public int m_heavyHurtAnimIndex;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_damageType == EDamageType.DT_Critical)
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
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsInjured", true);
			}
			else if (m_damageType == EDamageType.DT_Heavy)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iHeavyHitType", m_heavyHurtAnimIndex);
				m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHeavyHit", true);
			}
			m_hurtStarted = false;
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(0);
		if (m_damageType == EDamageType.DT_Critical)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_hurtStarted)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
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
									if (m_animatorInfo.IsTag("InjuryReaction"))
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
								m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsInjured", false);
								base.m_status = AnimationStatus.SUCCESS;
								return;
							}
						}
					}
					if (m_animatorInfo.IsTag("InjuryReaction"))
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								m_startTime = m_animatorInfo.normalizedTime;
								m_hurtStarted = true;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_damageType != EDamageType.DT_Heavy)
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
			if (m_hurtStarted)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.98f))
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							if (m_animatorInfo.IsTag("InjuryReaction"))
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
						m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHeavyHit", false);
						base.m_status = AnimationStatus.SUCCESS;
						return;
					}
				}
			}
			if (!m_animatorInfo.IsTag("InjuryReaction"))
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
				m_startTime = m_animatorInfo.normalizedTime;
				m_hurtStarted = true;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsInjured", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHurtLight", false);
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHeavyHit", false);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
