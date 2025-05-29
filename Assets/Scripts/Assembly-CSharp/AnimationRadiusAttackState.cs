using A;

public class AnimationRadiusAttackState : AnimationManagerState
{
	private const float THRESHOLD = 0.9f;

	private string m_animationTag = "AttackRadius";

	public bool m_radiusAttackHit;

	public bool m_bDoDamage;

	public AnimationRadiusAttackState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "RadiusAttack";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bAttackRadius", true);
		m_radiusAttackHit = false;
		m_bDoDamage = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba(m_animationTag, 0.98f) == AnimationStatus.SUCCESS)
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
			base.m_status = AnimationStatus.SUCCESS;
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bAttackRadius", false);
		}
		if (!m_radiusAttackHit)
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
			if (m_bDoDamage)
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
				if (m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_RadiusAttack, 0f, false);
				}
				m_bDoDamage = true;
				m_radiusAttackHit = false;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		if ((bool)m_VFXManager)
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
			m_VFXManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_RadiusAttack);
		}
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bAttackRadius", false);
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
	}
}
