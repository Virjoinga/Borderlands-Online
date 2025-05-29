using A;
using BHV;
using UnityEngine;

public class AnimationLightHurtState : AnimationManagerState
{
	private const string HURTLIGHT_TAG = "HurtLight";

	private int m_hurtLightLayer;

	public bool m_hurtStarted;

	public EDamageType m_damageType;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private bool m_isHurtPending;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_hurtLightLayer = m_AnimationManagerFSM.c43e01190c713db1f8a78d1529ae2d2ed("HurtLight");
		c85617fdafe8c0daa6977b54ed54c179a();
	}

	public void c85617fdafe8c0daa6977b54ed54c179a()
	{
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
			if (m_damageType != EDamageType.DT_Light)
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
				if (m_damageType != EDamageType.DT_Light_Critical)
				{
					goto IL_006c;
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHurtLight", true);
			goto IL_006c;
		}
		goto IL_0073;
		IL_006c:
		m_hurtStarted = false;
		goto IL_0073;
		IL_0073:
		base.m_status = AnimationStatus.RUNNING;
		m_isHurtPending = true;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_isHurtPending)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHurtLight", true);
					m_isHurtPending = false;
					return;
				}
			}
		}
		if (m_damageType != EDamageType.DT_Light)
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
			if (m_damageType != EDamageType.DT_Light_Critical)
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
		m_animatorInfo = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(m_hurtLightLayer);
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
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						if (m_animatorInfo.IsTag("HurtLight"))
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
					base.m_status = AnimationStatus.SUCCESS;
					return;
				}
			}
		}
		if (!m_animatorInfo.IsTag("HurtLight"))
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHurtLight", false);
			m_hurtStarted = true;
			m_startTime = m_animatorInfo.normalizedTime;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bHurtLight", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}
}
