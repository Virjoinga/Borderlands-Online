using A;
using UnityEngine;

public class AnimationPlayerMeleeSkillState : PlayerAnimationState
{
	public enum MeleeTiming
	{
		FirstTick = 0,
		WaitForTransitionFinish = 1,
		Playing = 2,
		Finish = 3
	}

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private int m_layer;

	private MeleeTiming m_timing;

	public AnimationPlayerMeleeSkillState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerMeleeSkill";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		BerserkManage berserkManage = c4a92afe664b68f75e668116af19e84e9().ccaf53be8b86b7016efd6970ff8c92ad3 as BerserkManage;
		if (berserkManage != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			berserkManage.ca6c6123730b2f01b0c916df905aad16f++;
		}
		base.m_status = AnimationStatus.RUNNING;
		m_timing = MeleeTiming.FirstTick;
		int layer;
		if (base.c90e194560a86112d38f669898a54a249)
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
			layer = 0;
		}
		else
		{
			layer = 1;
		}
		m_layer = layer;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(base.c90e194560a86112d38f669898a54a249, m_layer);
		switch (m_timing)
		{
		case MeleeTiming.FirstTick:
			if (base.c90e194560a86112d38f669898a54a249)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_MeleeSkill);
			}
			c06739986a9474e249bf49d8330a68ce0("bMeleeSkill", true);
			m_timing = MeleeTiming.WaitForTransitionFinish;
			ccdbbc6879c7efc53e81b9c2fbaceead9().c6f2661406df861477b09a9ac6e05d089(ENPCParticleType.E_Player_BerserkPunch, c4a92afe664b68f75e668116af19e84e9().ccd8e6ea278245d0f158036267242e60f().transform, true, m_animatorInfo.length * 0.5f);
			if (!c4a92afe664b68f75e668116af19e84e9().caac907d451029d68503484a63934c93f())
			{
				break;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				ccdbbc6879c7efc53e81b9c2fbaceead9().c6f2661406df861477b09a9ac6e05d089(ENPCParticleType.E_Berserk_MeteorFist_1st, c4a92afe664b68f75e668116af19e84e9().ccd8e6ea278245d0f158036267242e60f().transform, false);
				return;
			}
		case MeleeTiming.WaitForTransitionFinish:
			if (!m_animatorInfo.IsTag("MeleeSkill"))
			{
				break;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				m_startTime = m_animatorInfo.normalizedTime;
				c06739986a9474e249bf49d8330a68ce0("bMeleeSkill", false);
				m_timing = MeleeTiming.Playing;
				return;
			}
		case MeleeTiming.Playing:
			if (m_animatorInfo.IsTag("MeleeSkill"))
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
				if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
				{
					break;
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
			m_timing = MeleeTiming.Finish;
			break;
		case MeleeTiming.Finish:
		{
			base.m_status = AnimationStatus.SUCCESS;
			c06739986a9474e249bf49d8330a68ce0("bMeleeSkill", false);
			BerserkManage berserkManage = c4a92afe664b68f75e668116af19e84e9().ccaf53be8b86b7016efd6970ff8c92ad3 as BerserkManage;
			if (!(berserkManage != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				break;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				berserkManage.ca1e2b924e9c89118aad60da409cb8df9();
				berserkManage.c22f04f0e766948c10c2bc20cc7c5b102();
				return;
			}
		}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
		c06739986a9474e249bf49d8330a68ce0("bMeleeSkill", false);
		c4a92afe664b68f75e668116af19e84e9().m_pending_melee = false;
	}
}
