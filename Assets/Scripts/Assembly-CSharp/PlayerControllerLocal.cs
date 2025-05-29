using A;

public class PlayerControllerLocal : PlayerController
{
	private PlayerWeaponAnimationManagerFSM m_playerWeaponAnimationManagerFSM;

	private ShootingTestMenu m_shootingTestMenu;

	public override void Start()
	{
		base.Start();
		m_playerBehavior = GetComponent<PlayerBehavior>();
		m_playerThirdPersonAnimationManagerFSM.m_isPlayerLocal = true;
		m_playerWeaponAnimationManagerFSM = GetComponent<PlayerWeaponAnimationManagerFSM>();
		m_playerWeaponAnimationManagerFSM.m_isPlayerLocal = true;
		m_shootingTestMenu = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<ShootingTestMenu>();
	}

	protected override void FixedUpdate()
	{
		if (m_shootingTestMenu != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_shootingTestMenu.enabled)
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
				m_shootingTestMenu.c6c6cbb0045146f9b0a890f787bad6e4d();
			}
		}
		c7a4cd134dc4f26ca7677c388bc980404();
		m_inInput.ccf3411e5323c009014d6dd8d3521f827();
		c213197d435573d9c89181e39ae5e148c();
		m_playerThirdPersonAnimationManagerFSM.cc8a58c63cfa3dbcb328f6c53367c1781(m_playerBehavior.c86f11bcf921576e291dec189a4fa5416(), m_playerBehavior.cfd4613bd0d4dba1d6c84fa3cc04873ac());
		base.FixedUpdate();
	}

	private void c213197d435573d9c89181e39ae5e148c()
	{
		if (m_playerBehavior.cade5de2c3f4c8548cddac952328dbd08())
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
			c4e73d24478878d4c6d94bef4abaa315a();
		}
		if (m_playerBehavior.c78ca1a7bffb374a7bbec338c3208c4b5())
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
			c1fc97d9000793496ac114d06521f85a0(m_playerBehavior.c5c09844fd0f91323d4862a0049207950());
		}
		if (m_playerBehavior.cc398985de9cbef8f2199a7f1eebc37dd())
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
			c0d43c193dd223e1cac7446c51748121a();
		}
		if (m_playerBehavior.ca4315eacba51144e39f7013a08e650ec())
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
			c9d878a0c8ef401a60f254a868331d1bd();
			c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_use_skill");
			c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_use_secondary");
		}
		if (m_playerBehavior.c1d750be162b222bedb13c5c1a88eac75())
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
			ce2d31574942eb4096a689fa7573ca86e();
		}
		if (m_playerBehavior.c3d9edee0a5ee12ca677409daf26f3e9f())
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
			c0411698b20c1e5ea7a3daa619b2a2b43();
		}
		if (m_playerBehavior.c212938a308d79596b1acd410e24ec08d())
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
			cca50d90a16c827944406599b9940ea35();
		}
		if (m_playerBehavior.c4d927c91307ef767ba359c476291c950())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c2410e88016c14e3d45907364a377ea73(true);
					return;
				}
			}
		}
		c2410e88016c14e3d45907364a377ea73(false);
		if (!m_inInput.cb261500372fa488b369e9159a002977a())
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
			if (!c212938a308d79596b1acd410e24ec08d())
			{
				if (m_inInput.c8cc0ce1bacf416fdd879d1e63947960f())
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
						{
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c5c6d9b37e66c45c8c7187665713ece00();
							EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
							if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										entityWeapon.ce2f1a825ffeb786635c45df12ef45235();
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c5c6d9b37e66c45c8c7187665713ece00();
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c5c6d9b37e66c45c8c7187665713ece00(E_SCOPE_TYPE.E_NONE);
		EntityWeapon entityWeapon2 = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (!(entityWeapon2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			entityWeapon2.ce2f1a825ffeb786635c45df12ef45235();
			return;
		}
	}

	public void OnAnimationStart_Aim()
	{
		if ((bool)m_entity)
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
			if ((bool)m_entity.c3941dac8608f650ceb15dc36294a741c())
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
				if (m_entity.c3941dac8608f650ceb15dc36294a741c().c09a173327ea9e510fbbae5150bf9d2e2())
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							m_entity.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(true);
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c5c6d9b37e66c45c8c7187665713ece00(E_SCOPE_TYPE.E_SNIPER);
							return;
						}
					}
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().c5c6d9b37e66c45c8c7187665713ece00(E_SCOPE_TYPE.E_NONE);
	}
}
