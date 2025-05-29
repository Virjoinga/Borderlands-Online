using UnityEngine;

public class AnimationPlayerFireBirdState : PlayerAnimationState
{
	private const string m_tag = "FireBird";

	public float m_netLantency;

	private AnimatorStateInfo m_animatorInfo;

	private bool m_bFirstTickInTag;

	private float m_startTime;

	private float m_length_anim;

	public AnimationPlayerFireBirdState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerFireBird";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
		m_bFirstTickInTag = false;
		if (base.c90e194560a86112d38f669898a54a249)
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
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_FireBird);
		}
		c06739986a9474e249bf49d8330a68ce0("bFireBird", true);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		caa231e4235a543923de9b9aa13e09304();
	}

	private void caa231e4235a543923de9b9aa13e09304()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, 1);
		if (!m_animatorInfo.IsTag("FireBird"))
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
					return;
				}
			}
		}
		if (!m_bFirstTickInTag)
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
			m_bFirstTickInTag = true;
			m_startTime = Time.time;
			m_length_anim = m_animatorInfo.length;
			ccdbbc6879c7efc53e81b9c2fbaceead9().c6f2661406df861477b09a9ac6e05d089(ENPCParticleType.E_Player_HandFire, c4a92afe664b68f75e668116af19e84e9().ccd8e6ea278245d0f158036267242e60f().transform, true, m_length_anim);
		}
		if (!c7ab5b7aef9fa6ca72da8afdd1de01d10(0.97f))
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
			base.m_status = AnimationStatus.SUCCESS;
			c06739986a9474e249bf49d8330a68ce0("bFireBird", false);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
		c06739986a9474e249bf49d8330a68ce0("bFireBird", false);
		ccdbbc6879c7efc53e81b9c2fbaceead9().cea92255d82a6e0d2a5f50a107d781c56(ENPCParticleType.E_Player_HandFire);
	}

	private bool c7ab5b7aef9fa6ca72da8afdd1de01d10(float ca30f1ce8175fcc366fda26a89783560a)
	{
		return Time.time + m_netLantency - m_startTime > m_length_anim * ca30f1ce8175fcc366fda26a89783560a;
	}
}
