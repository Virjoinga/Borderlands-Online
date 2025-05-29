using A;

public class AnimationJumpOnSpotState : AnimationManagerState
{
	private const string JUMPONSPOT_TAG = "JumpOnSpot";

	private const float THRESHOLD = 0.9f;

	public bool m_jumpOnSpotHit;

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpOnSpot", true);
		m_jumpOnSpotHit = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (m_AnimationManagerFSM.c0682f58328f23f63387e2fc5249a2cba("JumpOnSpot", 0.98f) == AnimationStatus.SUCCESS)
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
			base.m_status = AnimationStatus.SUCCESS;
		}
		if (!m_jumpOnSpotHit)
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
			if (!(m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_JumpOnSpot, 0f, false);
				m_jumpOnSpotHit = false;
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bJumpOnSpot", false);
	}
}
