using UnityEngine;

public class AnimationPlayerMeleeState : PlayerAnimationState
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

	public AnimationPlayerMeleeState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerMelee";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
		m_timing = MeleeTiming.FirstTick;
		int layer;
		if (base.c90e194560a86112d38f669898a54a249)
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
					switch (6)
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
				ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_Melee);
			}
			c06739986a9474e249bf49d8330a68ce0("bMelee", true);
			m_timing = MeleeTiming.WaitForTransitionFinish;
			break;
		case MeleeTiming.WaitForTransitionFinish:
			if (!m_animatorInfo.IsTag("Melee"))
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
				c06739986a9474e249bf49d8330a68ce0("bMelee", false);
				m_timing = MeleeTiming.Playing;
				return;
			}
		case MeleeTiming.Playing:
			if (m_animatorInfo.IsTag("Melee"))
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
				if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
					break;
				}
			}
			m_timing = MeleeTiming.Finish;
			break;
		case MeleeTiming.Finish:
			base.m_status = AnimationStatus.SUCCESS;
			c06739986a9474e249bf49d8330a68ce0("bMelee", false);
			break;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
		c06739986a9474e249bf49d8330a68ce0("bMelee", false);
		c4a92afe664b68f75e668116af19e84e9().m_pending_melee = false;
	}
}
