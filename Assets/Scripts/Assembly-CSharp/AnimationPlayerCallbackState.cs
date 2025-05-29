using UnityEngine;

public class AnimationPlayerCallbackState : PlayerAnimationState
{
	private const string m_tag = "Callback";

	public float m_netLantency;

	private AnimatorStateInfo m_animatorInfo;

	private bool m_bFirstTickInTag;

	private float m_startTime;

	private float m_length_anim;

	public AnimationPlayerCallbackState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerCallback";
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
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_Callback);
		}
		c06739986a9474e249bf49d8330a68ce0("bCallback", true);
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		caa231e4235a543923de9b9aa13e09304();
	}

	private void caa231e4235a543923de9b9aa13e09304()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, 1);
		if (!m_animatorInfo.IsTag("Callback"))
		{
			while (true)
			{
				switch (5)
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
		}
		if (!c7ab5b7aef9fa6ca72da8afdd1de01d10(0.97f))
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
			base.m_status = AnimationStatus.SUCCESS;
			c06739986a9474e249bf49d8330a68ce0("bCallback", false);
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
		c06739986a9474e249bf49d8330a68ce0("bCallback", false);
	}

	private bool c7ab5b7aef9fa6ca72da8afdd1de01d10(float ca30f1ce8175fcc366fda26a89783560a)
	{
		return Time.time - m_startTime > m_length_anim * ca30f1ce8175fcc366fda26a89783560a;
	}
}
