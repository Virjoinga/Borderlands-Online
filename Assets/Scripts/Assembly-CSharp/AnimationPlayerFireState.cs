using A;
using UnityEngine;
using XsdSettings;

public class AnimationPlayerFireState : PlayerAnimationState
{
	private const string FIRE_TAG = "Fire";

	private const int FIRE_LAYER = 1;

	private AnimatorStateInfo m_animatorInfo;

	private PlayerThirdPersonAnimationManagerFSM m_AnimManager;

	private float m_weaponMode;

	private float m_fireHolding_duration;

	private PlayerBehavior m_inner_playerBehavior;

	private bool m_shotEndPending;

	private PlayerBehavior c328fedfde69ab19889e405d6a3181971
	{
		get
		{
			if (m_inner_playerBehavior == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_inner_playerBehavior = c4a92afe664b68f75e668116af19e84e9().GetComponent<PlayerBehavior>();
			}
			return m_inner_playerBehavior;
		}
	}

	public AnimationPlayerFireState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerFire";
	}

	public void c488a5d9b6ef4e88a4cb2dbac8edc0297()
	{
		if (m_AnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_AnimManager = m_AnimationManagerFSM as PlayerThirdPersonAnimationManagerFSM;
		}
		m_AnimManager.m_fireTiming.c9a389dd79eaea383a5e989d84c81999e += cc2c7f5972c3eec27b68443ae1139796d;
		m_AnimManager.m_fireTiming.c749853ab2b0cf1752d83b5b74e1b5c8b += c8be080a011bf6d284c5e117e272d2aac;
		m_AnimManager.m_fireTiming.c8051c5853c2fcf9140b211bece88cbe8 += c63ec8fab39bd74b71c8225d6fe10e245;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
		m_weaponMode = ((PlayerThirdPersonAnimationManagerFSM)m_AnimationManagerFSM).c21c1c32fc4adafd3ac60f9fcd0faf29f();
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
			cb306162a8032e25a87c8a3cfc617cc8c("fWeaponMode", m_weaponMode);
			ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFromAimFire", false);
		}
		c4363c9ee832d0d0155375ca61d99d853("fWeaponMode", m_weaponMode);
		m_shotEndPending = false;
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(base.c90e194560a86112d38f669898a54a249, 1);
		if (m_AnimManager.m_fireTiming.c7e777222e47f1ee4717fef2f2dbc3ad9())
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
			if (m_animatorInfo.IsTag("Fire"))
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
				c44687deb2cece187dc78b8ce7fd0ad4e(false);
			}
		}
		if (c328fedfde69ab19889e405d6a3181971.cade5de2c3f4c8548cddac952328dbd08())
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
			m_fireHolding_duration += Time.deltaTime;
		}
		else
		{
			m_fireHolding_duration = 0f;
		}
		if (!base.c90e194560a86112d38f669898a54a249)
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
			if (!(m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				AnimatorStateInfo currentAnimatorStateInfo = m_firstPersonAnimator.GetCurrentAnimatorStateInfo(0);
				if (m_firstPersonAnimator.IsInTransition(1))
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							if (m_firstPersonAnimator.GetNextAnimatorStateInfo(1).IsTag("Idle"))
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										break;
									default:
										m_shotEndPending = true;
										return;
									}
								}
							}
							return;
						}
					}
				}
				if (!m_shotEndPending)
				{
					return;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					if (currentAnimatorStateInfo.loop)
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
						m_firstPersonAnimator.Play(currentAnimatorStateInfo.nameHash, 0, 0.01f);
					}
					m_shotEndPending = false;
					return;
				}
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		base.m_status = AnimationStatus.SUCCESS;
		m_fireHolding_duration = 0f;
		c5f374473e23855e729a2686870c654f1(false, 0f);
		c44687deb2cece187dc78b8ce7fd0ad4e(false);
		if (!base.c90e194560a86112d38f669898a54a249)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFromFire", true);
			if (!m_shotEndPending)
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
				AnimatorStateInfo currentAnimatorStateInfo = m_firstPersonAnimator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo.loop)
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
					m_firstPersonAnimator.Play(currentAnimatorStateInfo.nameHash, 0, 0.01f);
				}
				m_shotEndPending = false;
				return;
			}
		}
	}

	public float cb1d2e2a39a3e6e0b1c0410414e4f6365()
	{
		return m_fireHolding_duration;
	}

	private void c8be080a011bf6d284c5e117e272d2aac(float c1d93a9e83f8dde168e98b33ea93a6f7a)
	{
		if (c4d927c91307ef767ba359c476291c950())
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
		c5f374473e23855e729a2686870c654f1(true, c1d93a9e83f8dde168e98b33ea93a6f7a);
	}

	private void c5f374473e23855e729a2686870c654f1(bool c93f525ed928b54f8eb035ee537387461, float c1d93a9e83f8dde168e98b33ea93a6f7a)
	{
		if (!m_AnimManager.cae80661bfeb2c6b447dae85baad4777d())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
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
						ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFire", false);
					}
					c06739986a9474e249bf49d8330a68ce0("bFire", false);
					return;
				}
			}
		}
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
			ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFire", c93f525ed928b54f8eb035ee537387461);
			cb306162a8032e25a87c8a3cfc617cc8c("fFireSpeed", c1d93a9e83f8dde168e98b33ea93a6f7a);
		}
		c06739986a9474e249bf49d8330a68ce0("bFire", c93f525ed928b54f8eb035ee537387461);
		c4363c9ee832d0d0155375ca61d99d853("fFireSpeed", c1d93a9e83f8dde168e98b33ea93a6f7a);
		if (!(m_AnimationManagerFSM.m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			EntityWeapon entityWeapon = ((EntityPlayer)m_AnimationManagerFSM.m_entity).c3941dac8608f650ceb15dc36294a741c();
			if (!(entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type != WeaponType.ShotGun)
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
					if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type != WeaponType.SniperRifle)
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
				c4363c9ee832d0d0155375ca61d99d853("fFireSpeed", 0.5f);
				return;
			}
		}
	}

	private void cc2c7f5972c3eec27b68443ae1139796d()
	{
		if (c4d927c91307ef767ba359c476291c950())
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
					return;
				}
			}
		}
		c44687deb2cece187dc78b8ce7fd0ad4e(true);
	}

	private void c44687deb2cece187dc78b8ce7fd0ad4e(bool c93f525ed928b54f8eb035ee537387461)
	{
		if (!m_AnimManager.cae80661bfeb2c6b447dae85baad4777d())
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
						ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFire", false);
					}
					c06739986a9474e249bf49d8330a68ce0("bFire", false);
					return;
				}
			}
		}
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
			if (m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!m_firstPersonAnimator.GetBool("bRecoilExit_1st"))
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
					ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFire", c93f525ed928b54f8eb035ee537387461);
				}
			}
		}
		c06739986a9474e249bf49d8330a68ce0("bFire", c93f525ed928b54f8eb035ee537387461);
	}

	private void c63ec8fab39bd74b71c8225d6fe10e245()
	{
		if (c4d927c91307ef767ba359c476291c950())
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
		c5f374473e23855e729a2686870c654f1(false, 0f);
		c44687deb2cece187dc78b8ce7fd0ad4e(false);
	}

	private bool c4d927c91307ef767ba359c476291c950()
	{
		return c328fedfde69ab19889e405d6a3181971.c4d927c91307ef767ba359c476291c950();
	}
}
