using UnityEngine;

public class AnimationPlayerThrowGrenadeState : PlayerAnimationState
{
	public delegate void SpawnGrenadeDelegate();

	private const string THROWGRENADE_TAG = "ThrowGrenade";

	public bool m_throwStartedFirst;

	public bool m_throwStartedThird;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTimeThird;

	private float m_animationDuration;

	private float m_networkLatency;

	public SpawnGrenadeDelegate m_spawnGrenadeDelegate;

	public float cffdc2a7192ade7030de312fde24fa44e
	{
		get
		{
			return m_networkLatency;
		}
		set
		{
			m_networkLatency = value;
		}
	}

	public AnimationPlayerThrowGrenadeState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerThrowGrenade";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_throwStartedFirst = false;
		m_throwStartedThird = false;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_ThrowGrenade);
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		cbb6235da15f631876b2c80db52d2d808();
	}

	public void cbb6235da15f631876b2c80db52d2d808()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, 1);
		if (m_throwStartedThird)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_animatorInfo.IsTag("ThrowGrenade"))
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
						if (!(Time.time - m_startTimeThird > m_animationDuration * 0.9f))
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
					base.m_status = AnimationStatus.SUCCESS;
					c06739986a9474e249bf49d8330a68ce0("bThrowGrenade", false);
					return;
				}
			}
		}
		c06739986a9474e249bf49d8330a68ce0("bThrowGrenade", true);
		if (!m_animatorInfo.IsTag("ThrowGrenade"))
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
			m_throwStartedThird = true;
			m_startTimeThird = Time.time;
			m_animationDuration = m_animatorInfo.length;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		c06739986a9474e249bf49d8330a68ce0("bThrowGrenade", false);
		base.m_status = AnimationStatus.SUCCESS;
	}
}
