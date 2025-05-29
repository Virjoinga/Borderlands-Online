using A;
using UnityEngine;

public class AnimationPlayerPickupWeaponState : PlayerAnimationState
{
	public enum EAnimationPickupStep
	{
		SwitchNull = 0,
		SwitchDown = 1,
		SwitchWeapon = 2,
		SwitchUp = 3,
		SwitchFinish = 4
	}

	private const string SWITCHUP_TAG = "SwitchUp";

	public bool m_pickupStarted;

	private AnimatorStateInfo m_animatorInfo;

	private float m_startTime;

	private EntityWeapon m_nextWeapon;

	private EntityPlayer m_entityPlayer;

	private int m_pickupWeaponLayer;

	public EAnimationPickupStep m_pickupStep;

	public AnimationPlayerPickupWeaponState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerPickupWeapon";
	}

	public void c6c718e75c647ef3e7bb161260ec25d23(EntityWeapon c69bf0840711997fc24c93a36e45706e0, EntityPlayer cc292a78271891d4e9a7145978b66846f)
	{
		m_nextWeapon = c69bf0840711997fc24c93a36e45706e0;
		m_entityPlayer = cc292a78271891d4e9a7145978b66846f;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		m_pickupStarted = false;
		m_pickupWeaponLayer = 1;
		if (base.c90e194560a86112d38f669898a54a249)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_pickupWeaponLayer = 0;
		}
		base.m_status = AnimationStatus.RUNNING;
		m_pickupStep = EAnimationPickupStep.SwitchWeapon;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		if (base.c90e194560a86112d38f669898a54a249)
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
			cc121b465eb26f2b29daeccb3096b618d();
		}
		c2fd8b1f91e3e84a38ae9a04fd4391d43();
	}

	public void cc121b465eb26f2b29daeccb3096b618d()
	{
		if (m_pickupStep == EAnimationPickupStep.SwitchWeapon)
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
					ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_PickUp);
					return;
				}
			}
		}
		if (m_pickupStep == EAnimationPickupStep.SwitchUp)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (m_pickupStep != EAnimationPickupStep.SwitchFinish)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c2fd8b1f91e3e84a38ae9a04fd4391d43()
	{
		m_pickupWeaponLayer = 1;
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(false, m_pickupWeaponLayer);
		if (m_pickupStep == EAnimationPickupStep.SwitchWeapon)
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
					m_pickupStarted = false;
					c06739986a9474e249bf49d8330a68ce0("bPickUp", true);
					if (m_entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_nextWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_entityPlayer.c554459b1136a15a5b4817abd6efd4e80(m_nextWeapon);
							if (base.c6e68afa0a7f820f050de4b96ae1be367 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								base.c6e68afa0a7f820f050de4b96ae1be367.ca3a93dab876a263826750cdd7ef70f9c();
							}
						}
					}
					m_pickupStep = EAnimationPickupStep.SwitchUp;
					return;
				}
			}
		}
		if (m_pickupStep == EAnimationPickupStep.SwitchUp)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (m_pickupStarted)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								if (m_animatorInfo.IsTag("SwitchUp"))
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
									if (!c4d656ad63e3960e094afed8e06b599f1(m_animatorInfo, m_startTime, 0.97f))
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
								m_pickupStep = EAnimationPickupStep.SwitchFinish;
								return;
							}
						}
					}
					if (m_animatorInfo.IsTag("SwitchUp"))
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								m_pickupStarted = true;
								m_startTime = m_animatorInfo.normalizedTime;
								c06739986a9474e249bf49d8330a68ce0("bPickUp", false);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_pickupStep != EAnimationPickupStep.SwitchFinish)
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
			c06739986a9474e249bf49d8330a68ce0("bPickUp", false);
			base.m_status = AnimationStatus.SUCCESS;
			return;
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if (base.c90e194560a86112d38f669898a54a249)
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
		}
		c06739986a9474e249bf49d8330a68ce0("bPickUp", false);
		base.m_status = AnimationStatus.SUCCESS;
		m_entityPlayer.OnSwitchWeaponDone();
	}
}
