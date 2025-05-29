using A;
using UnityEngine;
using XsdSettings;

public class AnimationPlayerAimState : PlayerAnimationState
{
	private AnimatorStateInfo m_animatorInfo;

	private bool m_bTriggerOnce = true;

	private EntityPlayer m_player;

	private int m_aimLayer;

	private PlayerThirdPersonAnimationManagerFSM m_AnimManager;

	private bool m_isAiming;

	public bool c4d927c91307ef767ba359c476291c950
	{
		get
		{
			return m_isAiming;
		}
		set
		{
			m_isAiming = value;
		}
	}

	public AnimationPlayerAimState()
	{
		ca5a2b345087379ea02ec4ca950356e9f = "PlayerAim";
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		base.m_status = AnimationStatus.RUNNING;
		m_aimLayer = 1;
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
			m_aimLayer = 0;
			m_player = m_AnimationManagerFSM.m_entity as EntityPlayer;
			m_bTriggerOnce = true;
		}
		c72b3c27a6fa6d78ff19fb51b8ce6fa72(false);
		c83a0fc745a819b8b4faef9be73c285c0();
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
		c06739986a9474e249bf49d8330a68ce0("bIsAiming", true);
		if (!base.c90e194560a86112d38f669898a54a249)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID.ID_1st_Aim);
			m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(base.c90e194560a86112d38f669898a54a249, m_aimLayer);
			if (m_bTriggerOnce)
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
				if (m_animatorInfo.IsTag("Aim"))
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
					m_bTriggerOnce = false;
					if (m_player != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_player.GetComponent<PlayerControllerLocal>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_player.GetComponent<PlayerControllerLocal>().OnAnimationStart_Aim();
							m_player.cce8a06f9d2b6de4283a2b9ecd4e2b29e(true);
						}
					}
					if (c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d() != null)
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
						c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().cf91ae5249669b02f125e35baedef33f7(true);
					}
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
						ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFromFire", false);
					}
				}
			}
			m_animatorInfo = ca18251f94792b5764ab1a1024333abfb(base.c90e194560a86112d38f669898a54a249, 1);
			if (!m_animatorInfo.IsTag("AimFire"))
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
				ccadff0d4c94e9a3efd1c9a959fd4b0b9("bAimFire", false);
				return;
			}
		}
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		base.caeee91e34d54e1e41ab1b380f7d8c9a4();
		if ((bool)m_player)
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
			m_player.cce8a06f9d2b6de4283a2b9ecd4e2b29e(false);
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
			ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID.ID_1st_Aim);
			ccadff0d4c94e9a3efd1c9a959fd4b0b9("bFromAimFire", true);
		}
		c06739986a9474e249bf49d8330a68ce0("bIsAiming", false);
		base.m_status = AnimationStatus.SUCCESS;
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
			if (m_player != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_player.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
			}
		}
		c72b3c27a6fa6d78ff19fb51b8ce6fa72(true);
		c63ec8fab39bd74b71c8225d6fe10e245();
		c8344ac1f19645011e00bc2352df5ddd2();
	}

	private void c83a0fc745a819b8b4faef9be73c285c0()
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

	private void c8344ac1f19645011e00bc2352df5ddd2()
	{
		m_AnimManager.m_fireTiming.c9a389dd79eaea383a5e989d84c81999e -= cc2c7f5972c3eec27b68443ae1139796d;
		m_AnimManager.m_fireTiming.c749853ab2b0cf1752d83b5b74e1b5c8b -= c8be080a011bf6d284c5e117e272d2aac;
		m_AnimManager.m_fireTiming.c8051c5853c2fcf9140b211bece88cbe8 -= c63ec8fab39bd74b71c8225d6fe10e245;
	}

	private void c8be080a011bf6d284c5e117e272d2aac(float c1d93a9e83f8dde168e98b33ea93a6f7a)
	{
		if (!base.c90e194560a86112d38f669898a54a249)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c09a173327ea9e510fbbae5150bf9d2e2())
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
				ccadff0d4c94e9a3efd1c9a959fd4b0b9("bAimFire", true);
				return;
			}
		}
	}

	private void cc2c7f5972c3eec27b68443ae1139796d()
	{
		if (!base.c90e194560a86112d38f669898a54a249)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!ca3c4840b736e6f69c25fa3cf8cc606bd())
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
				if (c09a173327ea9e510fbbae5150bf9d2e2())
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
					ccadff0d4c94e9a3efd1c9a959fd4b0b9("bAimFire", true);
					return;
				}
			}
		}
	}

	private void c63ec8fab39bd74b71c8225d6fe10e245()
	{
		if (!base.c90e194560a86112d38f669898a54a249)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c09a173327ea9e510fbbae5150bf9d2e2())
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
				ccadff0d4c94e9a3efd1c9a959fd4b0b9("bAimFire", false);
				return;
			}
		}
	}

	private bool c09a173327ea9e510fbbae5150bf9d2e2()
	{
		if (m_player != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_player.c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_player.c3941dac8608f650ceb15dc36294a741c().c09a173327ea9e510fbbae5150bf9d2e2();
					}
				}
			}
		}
		return false;
	}

	private bool ca3c4840b736e6f69c25fa3cf8cc606bd()
	{
		if (m_player != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityWeapon entityWeapon = m_player.c3941dac8608f650ceb15dc36294a741c();
			if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				WeaponDNA weaponDNA = entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d();
				if (weaponDNA != null)
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
					switch (weaponDNA.m_type)
					{
					case WeaponType.SMG:
						return true;
					case WeaponType.CombatRifle:
						return true;
					case WeaponType.RepeaterPistol:
						return true;
					}
				}
			}
		}
		return false;
	}
}
