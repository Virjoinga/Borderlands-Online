using A;
using Core;
using UnityEngine;
using XsdSettings;

public class PlayerWeaponAnimationManagerFSM : AnimationManagerFSM
{
	public enum E_WeaponAnimation
	{
		Idle = 0,
		Draw = 1,
		Fire = 2,
		Reload = 3
	}

	public Animator m_weaponAnimator;

	public bool m_isPlayerLocal;

	public EntityWeapon m_entityWeapon;

	private bool m_firePending;

	private bool m_reloadPending;

	private bool m_clearPending;

	private RuntimeAnimatorController m_weaponControllerSMG;

	private RuntimeAnimatorController m_weaponControllerShotgun;

	private RuntimeAnimatorController m_weaponControllerSniper;

	private RuntimeAnimatorController m_weaponControllerPistol;

	private RuntimeAnimatorController m_weaponControllerCombatRifle;

	private float m_weaponMode;

	private PlayerThirdPersonAnimationManagerFSM m_playerAnimationManager;

	public void c79de174b1f9f37df95aa5af926c9e7b8()
	{
		string path = "Entities/Player_Mecanim/WPN_SMG_Controller";
		m_weaponControllerSMG = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/WPN_Shotgun_Controller";
		m_weaponControllerShotgun = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/WPN_Sniper_Controller";
		m_weaponControllerSniper = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/WPN_RepeaterPistol_Controller";
		m_weaponControllerPistol = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/WPN_CombatRifle_Controller";
		m_weaponControllerCombatRifle = (RuntimeAnimatorController)Resources.Load(path);
		ca3a93dab876a263826750cdd7ef70f9c();
	}

	public void ca3a93dab876a263826750cdd7ef70f9c()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_entity = GetComponent<EntityPlayer>();
		}
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		m_entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (m_entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		m_entityWeapon.c22928ba890dffe12269121a385d5e069();
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.cec0beff9147cfd69e0e037411c3e8fd6(m_entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type);
			m_weaponMode = component.c21c1c32fc4adafd3ac60f9fcd0faf29f();
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "PlayerAnimationManager can't be null!");
		}
		m_weaponAnimator = m_entityWeapon.gameObject.GetComponentInChildren<Animator>();
		if (!(m_weaponAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			switch (m_entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type)
			{
			case WeaponType.ShotGun:
				m_weaponAnimator.runtimeAnimatorController = m_weaponControllerShotgun;
				break;
			case WeaponType.SMG:
				m_weaponAnimator.runtimeAnimatorController = m_weaponControllerSMG;
				break;
			case WeaponType.SniperRifle:
				m_weaponAnimator.runtimeAnimatorController = m_weaponControllerSniper;
				break;
			case WeaponType.RepeaterPistol:
				m_weaponAnimator.runtimeAnimatorController = m_weaponControllerPistol;
				break;
			case WeaponType.CombatRifle:
				m_weaponAnimator.runtimeAnimatorController = m_weaponControllerCombatRifle;
				break;
			}
			c4d834b619e6462cc9b9551c91bd19da5();
			m_weaponAnimator.applyRootMotion = false;
			for (int i = 0; i < m_weaponAnimator.layerCount; i++)
			{
				m_weaponAnimator.SetLayerWeight(i, 1f);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				m_clearPending = true;
				return;
			}
		}
	}

	public void cfb88a00b651eaeb68ad6b810776ca0e6(Animator c147ee89dce997e916872a9ab40954015)
	{
		m_weaponAnimator = c147ee89dce997e916872a9ab40954015;
		m_weaponAnimator.applyRootMotion = false;
		for (int i = 0; i < m_weaponAnimator.layerCount; i++)
		{
			m_weaponAnimator.SetLayerWeight(i, 1f);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public override void Start()
	{
		c79de174b1f9f37df95aa5af926c9e7b8();
	}

	public override void c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM cf9e4ee4aad0dfef345efeacc8e9c1232)
	{
		string text = Utils.ccafcaf40248e9bbb1784d38d8b267eae(cf9e4ee4aad0dfef345efeacc8e9c1232);
		if (m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(text))
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
					c3d651aa95fd9820e9e2c328cc63e13e9(text, m_animationStateMachine);
					return;
				}
			}
		}
		if (m_upperBodyStateMachine == null)
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
			if (!m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(text))
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
				c3d651aa95fd9820e9e2c328cc63e13e9(text, m_upperBodyStateMachine);
				return;
			}
		}
	}

	public override void Update()
	{
		if (m_weaponAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			ca3a93dab876a263826750cdd7ef70f9c();
			base.c4004fed08fd0ad52f8c3b650da10e9cb = false;
		}
		base.Update();
		cb3d98cf5adb41a9426a7d19f263ceaa3();
	}

	public void cb3d98cf5adb41a9426a7d19f263ceaa3()
	{
		if (m_entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
				return;
			}
		}
		if (m_weaponAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!m_isPlayerLocal)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		m_weaponAnimator.SetFloat("fWeaponMode", m_weaponMode);
		if (m_clearPending)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				OnAnimationStart(E_WeaponAnimation.Idle);
				m_weaponAnimator.SetBool("bClear", true);
				m_clearPending = false;
				return;
			}
		}
		m_weaponAnimator.SetBool("bClear", false);
		if (m_firePending)
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
			if (ca5253146bddb2e7aeb80747d3f6c4fef())
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
				if (!m_reloadPending)
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
					m_firePending = false;
					goto IL_0105;
				}
			}
		}
		m_weaponAnimator.SetBool("bFire", false);
		goto IL_0105;
		IL_0105:
		if (m_reloadPending)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					OnAnimationStart(E_WeaponAnimation.Reload);
					m_weaponAnimator.SetFloat("fReloadSpeed", m_entityWeapon.cb4a75faedb5a5e266f1a6fbae8955f0a());
					m_weaponAnimator.SetBool("bReload", true);
					m_weaponAnimator.SetBool("bFire", false);
					m_reloadPending = false;
					return;
				}
			}
		}
		m_weaponAnimator.SetBool("bReload", false);
	}

	private bool ca5253146bddb2e7aeb80747d3f6c4fef()
	{
		if (m_playerAnimationManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerAnimationManager = base.gameObject.GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		}
		if (m_playerAnimationManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return m_playerAnimationManager.c024fc7afe02ad5f93e51d401ea4df294();
				}
			}
		}
		return false;
	}

	private void OnAnimationStart(E_WeaponAnimation _weapon)
	{
		if (m_entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_weaponAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_entityWeapon.c83e548e5608cd7f222098a6966b16545() != WeaponType.ShotGun)
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
			if (_weapon == E_WeaponAnimation.Fire)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_weaponAnimator.speed = m_entityWeapon.c7792c484b60d7c05b9ef0053fa855896() / 0.7f;
						return;
					}
				}
			}
			m_weaponAnimator.speed = 1f;
			return;
		}
	}

	public override void OnAttack()
	{
		if (m_entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
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
		if (m_weaponAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		if (!m_isPlayerLocal)
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
			m_entityWeapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			OnAnimationStart(E_WeaponAnimation.Fire);
			m_weaponAnimator.SetBool("bFire", true);
			return;
		}
	}

	public void OnWeaponReload(float compasation)
	{
		if (!m_isPlayerLocal)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_reloadPending = true;
			return;
		}
	}

	public void OnSwitchWeapon(bool down)
	{
		if (m_entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
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
		if (m_weaponAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!m_isPlayerLocal)
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
			if (m_entityWeapon.c83e548e5608cd7f222098a6966b16545() != WeaponType.RepeaterPistol)
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
				if (down)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							m_weaponAnimator.SetBool("bSwitchWeapon", true);
							return;
						}
					}
				}
				m_weaponAnimator.SetBool("bSwitchWeapon", false);
				return;
			}
		}
	}

	private void c4d834b619e6462cc9b9551c91bd19da5()
	{
		if (m_weaponAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!m_weaponAnimator.GetComponent<MecanimEventEmitter>())
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
			m_weaponAnimator.GetComponent<MecanimEventEmitter>().animatorController = m_weaponAnimator.runtimeAnimatorController;
			return;
		}
	}
}
