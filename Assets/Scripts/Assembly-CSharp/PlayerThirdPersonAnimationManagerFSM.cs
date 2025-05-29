using System;
using System.Collections.Generic;
using System.Text;
using A;
using BHV;
using Core;
using UnityEngine;
using XsdSettings;

public class PlayerThirdPersonAnimationManagerFSM : AnimationManagerFSM
{
	public Animator m_firstPersonAnimator;

	public Animator m_inventoryAnimator;

	public float m_movementSyncVelocity;

	public bool m_isPlayerLocal;

	public FireTiming m_fireTiming;

	private BHVTaskManager m_taskManager;

	private bool m_isAngularVelocityActive = true;

	private float m_angularVelocityYaw;

	private float m_angularVelocityMaxYaw;

	private float m_angularVelocityPitch;

	private float m_angularVelocityMaxPitch;

	private RuntimeAnimatorController m_firstPersonControllerSMG;

	private RuntimeAnimatorController m_firstPersonControllerShotgun;

	private RuntimeAnimatorController m_firstPersonControllerSniper;

	private RuntimeAnimatorController m_firstPersonControllerPistol;

	private RuntimeAnimatorController m_firstPersonControllerCombatRifle;

	private RuntimeAnimatorController m_firstPersonControllerTown;

	private RuntimeAnimatorController m_thirdPersonControllerGame;

	private RuntimeAnimatorController m_thirdPersonControllerTown;

	private short m_shootPitch;

	private byte m_inputFrameFlag;

	public MecanimAnimatorGraph m_AnimatorGraph;

	private StatePriorityManage m_priorityMgr;

	private TransitionHistoryManage m_transitionHistoryMgr;

	private bool m_isSetDefaultWeaponPending;

	private AnimationLightHurtState m_lightHurtState;

	private List<float> m_jumpTimeQueue;

	public GameObject m_InventoryViewWeaponClone;

	public bool m_blockShootingThisFrame;

	private float m_previousLightHurtTime = -1f;

	private Vector3 m_previousPosition = Vector3.zero;

	private Vector3 m_localVelocity = Vector3.zero;

	private c46099de2cc6e7023f3abcc78fd614b34<float> m_previousVelocity = new c46099de2cc6e7023f3abcc78fd614b34<float>(5);

	public void c79de174b1f9f37df95aa5af926c9e7b8()
	{
		string path = "Entities/Player_Mecanim/Siren_1st_Controller_SMG";
		m_firstPersonControllerSMG = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_1st_Controller_Shotgun";
		m_firstPersonControllerShotgun = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_1st_Controller_Sniper";
		m_firstPersonControllerSniper = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_1st_Controller_RepeaterPistol";
		m_firstPersonControllerPistol = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_1st_Controller_CombatRifle";
		m_firstPersonControllerCombatRifle = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_1st_Controller_Town";
		m_firstPersonControllerTown = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_3rd_Controller_runtime";
		m_thirdPersonControllerGame = (RuntimeAnimatorController)Resources.Load(path);
		path = "Entities/Player_Mecanim/Siren_3rd_Controller_Town";
		m_thirdPersonControllerTown = (RuntimeAnimatorController)Resources.Load(path);
	}

	public bool c24d7fad69de8d80f5c878f06cee12757()
	{
		EntityWeapon entityWeapon = GetComponent<EntityPlayer>().c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					cec0beff9147cfd69e0e037411c3e8fd6(entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type);
					int c27b7430edc94b8f5b543605119ec4a = (int)entityWeapon.c83e548e5608cd7f222098a6966b16545();
					cf67bda7000068610d1503420f469c0a3(c27b7430edc94b8f5b543605119ec4a);
					return true;
				}
				}
			}
		}
		return false;
	}

	public void cf67bda7000068610d1503420f469c0a3(int c27b7430edc94b8f5b543605119ec4a72)
	{
		if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iWeaponType", c27b7430edc94b8f5b543605119ec4a72);
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fDefaultPose", c27b7430edc94b8f5b543605119ec4a72);
				return;
			}
		}
	}

	private void c23c0a11d524c202856b2bed0816950a6()
	{
		for (int i = 0; i < m_firstPersonAnimator.layerCount; i++)
		{
			m_firstPersonAnimator.SetLayerWeight(i, 1f);
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
			return;
		}
	}

	public void c5dc1b6879970886d76af1f53e75eb849(Animator c147ee89dce997e916872a9ab40954015)
	{
		m_firstPersonAnimator = c147ee89dce997e916872a9ab40954015;
		c23c0a11d524c202856b2bed0816950a6();
	}

	public void cec0beff9147cfd69e0e037411c3e8fd6(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		if (m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			m_firstPersonAnimator.runtimeAnimatorController = m_firstPersonControllerTown;
			m_firstPersonAnimator.SetFloat("fWeaponType", (float)c27b7430edc94b8f5b543605119ec4a72);
		}
		else
		{
			switch (c27b7430edc94b8f5b543605119ec4a72)
			{
			case WeaponType.ShotGun:
				m_firstPersonAnimator.runtimeAnimatorController = m_firstPersonControllerShotgun;
				break;
			case WeaponType.SMG:
				m_firstPersonAnimator.runtimeAnimatorController = m_firstPersonControllerSMG;
				break;
			case WeaponType.SniperRifle:
				m_firstPersonAnimator.runtimeAnimatorController = m_firstPersonControllerSniper;
				break;
			case WeaponType.RepeaterPistol:
				m_firstPersonAnimator.runtimeAnimatorController = m_firstPersonControllerPistol;
				break;
			case WeaponType.CombatRifle:
				m_firstPersonAnimator.runtimeAnimatorController = m_firstPersonControllerCombatRifle;
				break;
			}
		}
		c4d834b619e6462cc9b9551c91bd19da5();
		c23c0a11d524c202856b2bed0816950a6();
	}

	private void ce66245b674b481e49306e9fe82cf26fd()
	{
		m_inventoryAnimator.applyRootMotion = false;
		m_inventoryAnimator.updateMode = AnimatorUpdateMode.Normal;
		m_inventoryAnimator.cullingMode = AnimatorCullingMode.BasedOnRenderers;
		m_inventoryAnimator.runtimeAnimatorController = m_thirdPersonControllerTown;
		for (int i = 0; i < m_inventoryAnimator.layerCount; i++)
		{
			m_inventoryAnimator.SetLayerWeight(i, 1f);
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
			return;
		}
	}

	public void c29a63c4e0ac26e5b18e60c8167b5f543(GameObject c4d8237f1d619a3dacf45bde317197964)
	{
		m_inventoryAnimator = c4d8237f1d619a3dacf45bde317197964.GetComponent<Animator>();
		ce66245b674b481e49306e9fe82cf26fd();
	}

	public GameObject cd6ae848bd7b355e87c47ead3c3deb3fb(bool c126ae9ebd0193d1bf2665ca9d1e5edb2)
	{
		if (m_inventoryAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_inventoryAnimator.gameObject.SetActive(c126ae9ebd0193d1bf2665ca9d1e5edb2);
					if (c126ae9ebd0193d1bf2665ca9d1e5edb2)
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
						PlayerFirstPersonInventoryManager component = m_inventoryAnimator.gameObject.GetComponent<PlayerFirstPersonInventoryManager>();
						if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							component.OnShowInventoryView();
						}
						SkinnedMeshRenderer[] componentsInChildren = m_inventoryAnimator.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
						foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
						{
							skinnedMeshRenderer.useLightProbes = false;
							skinnedMeshRenderer.castShadows = false;
							skinnedMeshRenderer.receiveShadows = false;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					return m_inventoryAnimator.gameObject;
				}
			}
		}
		return null;
	}

	public override void cfad7b897be050bfdbda2828a48ed8767(GameObject c71d5b01920f18d25ff230dd1573651cd)
	{
		m_animationHost = c71d5b01920f18d25ff230dd1573651cd;
		base.ccaaf181e61e5f9e050ba82237ed111a2 = m_animationHost.GetComponent<Animator>();
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			base.ccaaf181e61e5f9e050ba82237ed111a2.runtimeAnimatorController = m_thirdPersonControllerTown;
		}
		else
		{
			base.ccaaf181e61e5f9e050ba82237ed111a2.runtimeAnimatorController = m_thirdPersonControllerGame;
		}
		for (int i = 0; i < base.ccaaf181e61e5f9e050ba82237ed111a2.layerCount; i++)
		{
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetLayerWeight(i, 1f);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			m_modelScale = m_animationHost.transform.localScale.x;
			m_VFXManager = m_animationHost.GetComponent<VFXManager>();
			ca3581834a9207956f6744b50728ca55d();
			return;
		}
	}

	public float c21c1c32fc4adafd3ac60f9fcd0faf29f()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "EntityPlayer can't be null!");
					return 0f;
				}
			}
		}
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "EntityWeapon can't be null!");
					return 0f;
				}
			}
		}
		switch (entityWeapon.cb237f478d9e906a169ab28afa6ed8173())
		{
		case EntityWeapon.ReloadType.Invalid:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "Invalid Reload Type");
			return 0f;
		case EntityWeapon.ReloadType.Standard:
			return 0f;
		case EntityWeapon.ReloadType.CustomA:
			return 1f;
		case EntityWeapon.ReloadType.CustomB:
			return 2f;
		default:
			return 0f;
		}
	}

	public override void Start()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Animation, "PlayerTHirdPersonAnimationManager isPlayerLocal: " + m_isPlayerLocal);
		if (m_additiveStateMachine != null)
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
			c0863e4c849711eed38a60fb8e7267a47("LightHurt", m_additiveStateMachine);
			m_lightHurtState = c059bb29245b8e57e3b793798ddfdb249("LightHurt") as AnimationLightHurtState;
		}
		m_entity = GetComponent<EntityPlayer>();
		m_AudioCtl = GetComponent<BaseEventTriggerCtl>();
		base.ca3581834a9207956f6744b50728ca55d();
		m_canUseFacingLogic = true;
		m_movementSync = GetComponent<MovementSync>();
		c79de174b1f9f37df95aa5af926c9e7b8();
		m_isSetDefaultWeaponPending = true;
		m_taskManager = GetComponent<BHVTaskManager>();
		m_fireTiming = new FireTiming(this);
		m_AnimatorGraph = new MecanimAnimatorGraph(this);
		m_priorityMgr = new StatePriorityManage(this);
		m_transitionHistoryMgr = new TransitionHistoryManage(this);
		AnimationPlayerFireState animationPlayerFireState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerFire)) as AnimationPlayerFireState;
		animationPlayerFireState.c488a5d9b6ef4e88a4cb2dbac8edc0297();
	}

	public void c9b0f61c6abe1cf070cb85c7ef6bc07fa()
	{
		if (m_upperBodyStateMachine == null)
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
		if (m_upperBodyStateMachine.m_curState == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					m_upperBodyStateMachine.c3d651aa95fd9820e9e2c328cc63e13e9("Empty");
					return;
				}
			}
		}
		if (((AnimationManagerState)m_upperBodyStateMachine.m_curState).m_status != AnimationStatus.SUCCESS)
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
			m_upperBodyStateMachine.c3d651aa95fd9820e9e2c328cc63e13e9("Empty");
			return;
		}
	}

	public void c4355edc66bdd459bebab3228792a4426(AnimationStateFSM cf9e4ee4aad0dfef345efeacc8e9c1232)
	{
		if (m_upperBodyStateMachine == null)
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
					return;
				}
			}
		}
		string text = Utils.ccafcaf40248e9bbb1784d38d8b267eae(cf9e4ee4aad0dfef345efeacc8e9c1232);
		if (!m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(text))
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
			if (m_upperBodyStateMachine.ccbc3718dd3d0e1356fa98d45c46d48ea(text))
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
				c3d651aa95fd9820e9e2c328cc63e13e9(text, m_upperBodyStateMachine);
				return;
			}
		}
	}

	public void c72b3c27a6fa6d78ff19fb51b8ce6fa72(bool c5774dbf644199ba27a198318d2b320cb)
	{
		m_isAngularVelocityActive = c5774dbf644199ba27a198318d2b320cb;
	}

	public void cc8a58c63cfa3dbcb328f6c53367c1781(float c6a66922cc694d40509d65b50477caada, float cacd5614728818f499dd89763b018c37d)
	{
		if (!m_isAngularVelocityActive)
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
		m_angularVelocityMaxYaw += c6a66922cc694d40509d65b50477caada * m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_handsAngularSpeedMultiplierYaw;
		m_angularVelocityMaxYaw = Mathf.Clamp(m_angularVelocityMaxYaw, -1f, 1f);
		m_angularVelocityMaxPitch += cacd5614728818f499dd89763b018c37d * m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_handsAngularSpeedMultiplierPitch;
		m_angularVelocityMaxPitch = Mathf.Clamp(m_angularVelocityMaxPitch, -1f, 1f);
	}

	private void c737f0c75e2b4dbd4b749da1d0d22ae77()
	{
		if (m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		m_angularVelocityYaw = Mathf.Lerp(m_angularVelocityYaw, m_angularVelocityMaxYaw, m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_handsAngularSpeedEnterSpeedFactorYaw);
		m_angularVelocityMaxYaw = Mathf.Lerp(0f, m_angularVelocityMaxYaw, m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_handsAngularSpeedExitSpeedFactorYaw);
		m_angularVelocityPitch = Mathf.Lerp(m_angularVelocityPitch, m_angularVelocityMaxPitch, m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_handsAngularSpeedEnterSpeedFactorPitch);
		m_angularVelocityMaxPitch = Mathf.Lerp(0f, m_angularVelocityMaxPitch, m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_handsAngularSpeedExitSpeedFactorPitch);
		m_firstPersonAnimator.SetFloat("AngularVelocityYaw", m_angularVelocityYaw);
		m_firstPersonAnimator.SetFloat("AngularVelocityPitch", m_angularVelocityPitch);
	}

	public override void Update()
	{
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			base.ca3581834a9207956f6744b50728ca55d();
			base.c4004fed08fd0ad52f8c3b650da10e9cb = true;
		}
		else
		{
			base.ccaaf181e61e5f9e050ba82237ed111a2.feetPivotActive = 0f;
		}
		if (m_movementSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_movementSync = GetComponent<MovementSync>();
		}
		if (m_isSetDefaultWeaponPending)
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
			m_isSetDefaultWeaponPending = !c24d7fad69de8d80f5c878f06cee12757();
		}
		base.Update();
		c737f0c75e2b4dbd4b749da1d0d22ae77();
		cb3d98cf5adb41a9426a7d19f263ceaa3();
		c9b0f61c6abe1cf070cb85c7ef6bc07fa();
		m_AnimatorGraph.Update();
		cd1dc398c5cdbf78e4ef2e0b43dec77b7();
		if (m_isPlayerLocal)
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
			c7bf6926a661ff8c05f4d0517bcf55650();
			return;
		}
	}

	public void cb3d98cf5adb41a9426a7d19f263ceaa3()
	{
		m_fireTiming.Update();
		if (m_isPlayerLocal)
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
			if (m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (m_firstPersonAnimator.GetCurrentAnimatorStateInfo(1).IsTag("Idle"))
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									m_firstPersonAnimator.SetLayerWeight(1, 0f);
									return;
								}
							}
						}
						m_firstPersonAnimator.SetLayerWeight(1, 1f);
						return;
					}
				}
			}
		}
		if (!(m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				int num;
				if (!c1aeae0a71b089f0b72d6f76062f51163())
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
					if (!cae80661bfeb2c6b447dae85baad4777d())
					{
						num = 0;
						goto IL_0123;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				num = ((base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fSpeed") < 0.5f) ? 1 : 0);
				goto IL_0123;
				IL_0123:
				bool flag = (byte)num != 0;
				if (m_lightHurtState != null)
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
					int num2;
					if (flag)
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
						num2 = ((m_lightHurtState.m_status != AnimationStatus.RUNNING) ? 1 : 0);
					}
					else
					{
						num2 = 0;
					}
					flag = (byte)num2 != 0;
				}
				if (flag)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
						{
							m_animationEventController.m_enableAimIK = true;
							EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
							if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										m_animationEventController.m_currentWeaponType = entityWeapon.c83e548e5608cd7f222098a6966b16545();
										m_animationEventController.m_enableLeftHandIK = true;
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
				m_animationEventController.m_enableAimIK = false;
				m_animationEventController.m_enableLeftHandIK = false;
				return;
			}
		}
	}

	public override void OnAttack()
	{
		if (m_blockShootingThisFrame)
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
					return;
				}
			}
		}
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
			m_entity = GetComponent<EntityPlayer>();
		}
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (!(entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			float cb5cbb485927e8a6e9a71fe800cc5a = entityWeapon.c7792c484b60d7c05b9ef0053fa855896();
			cfeb8ead5b51f4278fe8c3b81b3277fbe(cb5cbb485927e8a6e9a71fe800cc5a);
			if (m_isPlayerLocal)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerAim))
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerFire);
									return;
								}
							}
						}
						return;
					}
				}
			}
			c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerFire);
			entityWeapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			cb144a99805a51ee4be6bfd823bde6471(entityWeapon);
			return;
		}
	}

	private void cb144a99805a51ee4be6bfd823bde6471(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545() == WeaponType.SniperRifle)
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
					m_AudioCtl.TriggerEventByName("Wep_Sniper_1stShoot_Rnd");
					return;
				}
			}
		}
		if (c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545() != WeaponType.ShotGun)
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
			m_AudioCtl.TriggerEventByName("Wep_Shotgun_1stShoot_Rnd");
			return;
		}
	}

	public void c45db0588e69aeb4ffd5cd6c61e636182(float c5559cbc3dfa3ff205bc7d6fc6e6c7560)
	{
		if (!(c5559cbc3dfa3ff205bc7d6fc6e6c7560 < 0f))
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
			if (!(c5559cbc3dfa3ff205bc7d6fc6e6c7560 > 1000f))
			{
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
					m_firstPersonAnimator.speed = c5559cbc3dfa3ff205bc7d6fc6e6c7560;
				}
				if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					base.ccaaf181e61e5f9e050ba82237ed111a2.speed = c5559cbc3dfa3ff205bc7d6fc6e6c7560;
					return;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "invalid playback speed");
	}

	public override void OnThrow(float networkLatency, AnimationPlayerThrowGrenadeState.SpawnGrenadeDelegate spawnGrenadeDelegate)
	{
		AnimationPlayerThrowGrenadeState animationPlayerThrowGrenadeState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerThrowGrenade)) as AnimationPlayerThrowGrenadeState;
		if (animationPlayerThrowGrenadeState != null)
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
			animationPlayerThrowGrenadeState.cffdc2a7192ade7030de312fde24fa44e = networkLatency;
			animationPlayerThrowGrenadeState.m_spawnGrenadeDelegate = spawnGrenadeDelegate;
		}
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerThrowGrenade);
	}

	public void OnThrowGrenade()
	{
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerThrowGrenade);
	}

	public void OnFireBird(float _netLatency)
	{
		AnimationPlayerFireBirdState animationPlayerFireBirdState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerFireBird)) as AnimationPlayerFireBirdState;
		animationPlayerFireBirdState.m_netLantency = _netLatency;
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerFireBird);
	}

	public void OnCallback(float _netLatency)
	{
		AnimationPlayerCallbackState animationPlayerCallbackState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerCallback)) as AnimationPlayerCallbackState;
		animationPlayerCallbackState.m_netLantency = _netLatency;
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerCallback);
	}

	public void OnBerserkCharge(float _netLatency)
	{
		AnimationPlayerBerserkChargeState animationPlayerBerserkChargeState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerBerserkCharge)) as AnimationPlayerBerserkChargeState;
		animationPlayerBerserkChargeState.m_netLantency = _netLatency;
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerBerserkCharge);
	}

	public void OnBerserkDash(float _netLatency)
	{
		AnimationPlayerBerserkDashState animationPlayerBerserkDashState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerBerserkDash)) as AnimationPlayerBerserkDashState;
		animationPlayerBerserkDashState.m_netLantency = _netLatency;
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerBerserkDash);
	}

	public void OnBerserkPunch(float _netLatency)
	{
		AnimationPlayerBerserkPunchState animationPlayerBerserkPunchState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerBerserkPunch)) as AnimationPlayerBerserkPunchState;
		animationPlayerBerserkPunchState.m_netLantency = _netLatency;
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerBerserkPunch);
	}

	public override void OnReload(float _netLatency)
	{
		m_blockShootingThisFrame = true;
		AnimationPlayerReloadState animationPlayerReloadState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerReload)) as AnimationPlayerReloadState;
		animationPlayerReloadState.m_netLantency = _netLatency;
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerReload);
	}

	public override void OnSwitchWeapon(EntityWeapon weapon)
	{
		if (weapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		int c27b7430edc94b8f5b543605119ec4a = (int)weapon.c83e548e5608cd7f222098a6966b16545();
		cf67bda7000068610d1503420f469c0a3(c27b7430edc94b8f5b543605119ec4a);
		AnimationPlayerSwitchWeaponState animationPlayerSwitchWeaponState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerSwitchWeapon)) as AnimationPlayerSwitchWeaponState;
		if (animationPlayerSwitchWeaponState != null)
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
			animationPlayerSwitchWeaponState.c6c718e75c647ef3e7bb161260ec25d23(weapon, m_entity as EntityPlayer);
		}
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerSwitchWeapon);
		if (!weapon.m_owner.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().c660501325b92420b182c10632cb9aa92(weapon.c729ce3b5f48e0eac3a7ead97b1d02f8d(), cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e);
			return;
		}
	}

	public override void OnPickUpWeapon(EntityWeapon weapon)
	{
		int c27b7430edc94b8f5b543605119ec4a = (int)weapon.c83e548e5608cd7f222098a6966b16545();
		cf67bda7000068610d1503420f469c0a3(c27b7430edc94b8f5b543605119ec4a);
		AnimationPlayerPickupWeaponState animationPlayerPickupWeaponState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerPickupWeapon)) as AnimationPlayerPickupWeaponState;
		if (animationPlayerPickupWeaponState != null)
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
			animationPlayerPickupWeaponState.c6c718e75c647ef3e7bb161260ec25d23(weapon, m_entity as EntityPlayer);
		}
		c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerPickupWeapon);
		if (!weapon.m_owner.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPlayerInfoView>().c660501325b92420b182c10632cb9aa92(null, weapon.c729ce3b5f48e0eac3a7ead97b1d02f8d());
			return;
		}
	}

	public override void OnMelee()
	{
		m_blockShootingThisFrame = true;
		c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMelee);
	}

	public void OnMeleeSkill()
	{
		m_blockShootingThisFrame = true;
		c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMeleeSkill);
	}

	public override void OnDamaged(DamageInfo damageInfo)
	{
		if (m_isPlayerLocal)
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
			if (!(Time.time - m_previousLightHurtTime > 0.2f))
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
				if (m_lightHurtState == null)
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
					m_lightHurtState.m_damageType = EDamageType.DT_Light;
					if (m_lightHurtState.m_status == AnimationStatus.RUNNING)
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
						m_lightHurtState.c85617fdafe8c0daa6977b54ed54c179a();
					}
					else
					{
						c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.LightHurt);
					}
					m_previousLightHurtTime = Time.time;
					return;
				}
			}
		}
	}

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
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
					return 3;
				}
			}
		}
		return 0;
	}

	public float c860b20a36d422451f98fcb15cc16813b()
	{
		ushort num = (ushort)m_shootPitch;
		float num2 = (float)(int)num / 100f;
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (base.ccaaf181e61e5f9e050ba82237ed111a2.GetBool("bIsCrouch"))
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
				if (num2 >= 320f)
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
					num2 -= 320f;
				}
				else
				{
					num2 += 40f;
				}
			}
		}
		return num2;
	}

	public void ceb2fe0373fe25e1666c9c5232f2fc11c(byte c7cfc0cfba350d1d54dc8022a0f1e4978, short c739fbd82ea9db866d18892a3b0252bbe)
	{
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerDie))
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
			if (m_movementSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_movementSync = GetComponent<MovementSync>();
			}
			m_shootPitch = c739fbd82ea9db866d18892a3b0252bbe;
			m_inputFrameFlag = c7cfc0cfba350d1d54dc8022a0f1e4978;
			return;
		}
	}

	private void c7bf6926a661ff8c05f4d0517bcf55650()
	{
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerDie))
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
			if (m_movementSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_movementSync = GetComponent<MovementSync>();
			}
			c3f6b585ab9ab3570feb36d9a24f12a33(m_inputFrameFlag);
			if (c4880eb34d77c2808dde2b9b170f32c11(m_inputFrameFlag))
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
			if (cc7eed69704e53faad9f509705b0a4ef9(m_inputFrameFlag))
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
			if (!cb12b42231e73600f3bcb92bd4bb57bf0(m_inputFrameFlag))
			{
				return;
			}
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
	}

	private bool cfd15d9212bd84f360a3eff3959f76f78(bool c8c88e584b876edd3d290582d5aeb387f, float c6a6a7b9acc631a7784548d6ec37fb6ce)
	{
		if (m_jumpTimeQueue == null)
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
			m_jumpTimeQueue = new List<float>();
		}
		if (c8c88e584b876edd3d290582d5aeb387f)
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
			float item = Time.time + c6a6a7b9acc631a7784548d6ec37fb6ce;
			m_jumpTimeQueue.Add(item);
		}
		bool result = false;
		for (int i = 0; i < m_jumpTimeQueue.Count; i++)
		{
			if (!(Time.time - m_jumpTimeQueue[i] >= 0f))
			{
				continue;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			result = true;
			m_jumpTimeQueue.RemoveAt(i);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return result;
		}
	}

	private bool c3f6b585ab9ab3570feb36d9a24f12a33(byte c7cfc0cfba350d1d54dc8022a0f1e4978)
	{
		bool flag = (c7cfc0cfba350d1d54dc8022a0f1e4978 & 0x80) != 0;
		if (flag)
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
			c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerAim);
		}
		else if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerAim))
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
			c059bb29245b8e57e3b793798ddfdb249("PlayerAim").caeee91e34d54e1e41ab1b380f7d8c9a4();
		}
		return flag;
	}

	private bool c4880eb34d77c2808dde2b9b170f32c11(byte c7cfc0cfba350d1d54dc8022a0f1e4978)
	{
		bool flag = (c7cfc0cfba350d1d54dc8022a0f1e4978 & 2) != 0;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			flag = cfd15d9212bd84f360a3eff3959f76f78(flag, m_movementSync.c1d076d8aaabeb171d01b8502d3217ec0);
		}
		bool flag2 = ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerJump);
		if (flag)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (flag2)
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
					if (c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.PlayerJump) == AnimationStatus.RUNNING)
					{
						goto IL_008f;
					}
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
				c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerJump);
				goto IL_008f;
				IL_008f:
				return true;
			}
		}
		if (flag2)
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
			AnimationPlayerJumpState animationPlayerJumpState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerJump)) as AnimationPlayerJumpState;
			if (animationPlayerJumpState.c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpPre)
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
				if (animationPlayerJumpState.c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpLoop)
				{
					if (animationPlayerJumpState.c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLand)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
					goto IL_00ff;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			animationPlayerJumpState.c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLand;
			return true;
		}
		goto IL_00ff;
		IL_00ff:
		return false;
	}

	private bool cc7eed69704e53faad9f509705b0a4ef9(byte c7cfc0cfba350d1d54dc8022a0f1e4978)
	{
		if ((c7cfc0cfba350d1d54dc8022a0f1e4978 & 0x40u) != 0)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						float ce7083ddfe8079e1afb14ce01648c5d = 0f;
						float c02742282011bbbd23d9cddd49045a = 0f;
						c4513a04b9a8dea6fb18bd60d276dd2a3(ref ce7083ddfe8079e1afb14ce01648c5d, ref c02742282011bbbd23d9cddd49045a);
						if ((c7cfc0cfba350d1d54dc8022a0f1e4978 & 4) == 0)
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
							if (!(ce7083ddfe8079e1afb14ce01648c5d > 0.1f))
							{
								if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerCrouchIdle))
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
									c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerCrouchIdle);
								}
								goto IL_00c6;
							}
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						AnimationPlayerCrouchMoveState animationPlayerCrouchMoveState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerCrouchMove)) as AnimationPlayerCrouchMoveState;
						animationPlayerCrouchMoveState.c139222162aeb0051ac37d9635fe73e12(0.2f, c02742282011bbbd23d9cddd49045a);
						if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerCrouchMove))
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
							c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerCrouchMove);
						}
						goto IL_00c6;
					}
					IL_00c6:
					return true;
				}
			}
		}
		return false;
	}

	private void cd1dc398c5cdbf78e4ef2e0b43dec77b7()
	{
		if (Time.deltaTime == 0f)
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
			m_localVelocity = (base.transform.position - m_previousPosition) / Time.deltaTime;
			m_localVelocity.y = 0f;
			m_previousVelocity.Add(m_localVelocity.magnitude);
			m_previousPosition = base.transform.position;
			return;
		}
	}

	private bool cb12b42231e73600f3bcb92bd4bb57bf0(byte c7cfc0cfba350d1d54dc8022a0f1e4978)
	{
		float ce7083ddfe8079e1afb14ce01648c5d = 0f;
		float c02742282011bbbd23d9cddd49045a = 0f;
		float num = 0.0002f;
		c4513a04b9a8dea6fb18bd60d276dd2a3(ref ce7083ddfe8079e1afb14ce01648c5d, ref c02742282011bbbd23d9cddd49045a);
		float magnitude = m_localVelocity.magnitude;
		bool c3231b2e139435eed95a398e3aa4ae19d = (c7cfc0cfba350d1d54dc8022a0f1e4978 & 1) != 0;
		if (c02742282011bbbd23d9cddd49045a > 150f)
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
			if (c02742282011bbbd23d9cddd49045a < 200f)
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
			}
		}
		if (ce7083ddfe8079e1afb14ce01648c5d <= num)
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
			if (magnitude <= num)
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
				if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerIdle))
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
					int num2 = 0;
					for (int i = 0; i < m_previousVelocity.Count; i++)
					{
						if (!(m_previousVelocity[i] < num))
						{
							continue;
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
						num2++;
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
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
						if (num2 >= m_previousVelocity.Count - 1)
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
							cb8143e0ffeea74468915c2603dbc50cd();
						}
					}
					else if (num2 > m_previousVelocity.Count / 2)
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
						cb8143e0ffeea74468915c2603dbc50cd();
					}
				}
				goto IL_0457;
			}
		}
		if (ce7083ddfe8079e1afb14ce01648c5d > num)
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
			if (magnitude > num)
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
				AnimationPlayerMoveState animationPlayerMoveState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
				int num3 = 0;
				float num4 = 0f;
				for (int j = 0; j < m_previousVelocity.Count; j++)
				{
					if (!(m_previousVelocity[j] > num))
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					num3++;
					num4 += m_previousVelocity[j];
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				float num5 = c12fc2527efdb84d111088a6feabce490(c3231b2e139435eed95a398e3aa4ae19d, num4 / (float)num3);
				if (num5 != base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fSpeed"))
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
				}
				if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerMove))
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
					c68c59ca222c591efc1f2e51bccc4d69e(num5, c02742282011bbbd23d9cddd49045a);
				}
				else
				{
					c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMove);
					animationPlayerMoveState.c139222162aeb0051ac37d9635fe73e12(num5, c02742282011bbbd23d9cddd49045a);
				}
				goto IL_0457;
			}
		}
		if (ce7083ddfe8079e1afb14ce01648c5d > num)
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
			if (magnitude <= num)
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
				if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerIdle))
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
				}
				else
				{
					int num6 = 0;
					for (int k = 0; k < m_previousVelocity.Count; k++)
					{
						if (!(m_previousVelocity[k] < num))
						{
							continue;
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
						num6++;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
						if (num6 >= m_previousVelocity.Count - 1)
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
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Default, "switch from move to idle ");
							cb8143e0ffeea74468915c2603dbc50cd();
						}
					}
					else if (num6 > m_previousVelocity.Count / 2)
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
						cb8143e0ffeea74468915c2603dbc50cd();
					}
				}
				goto IL_0457;
			}
		}
		int num7 = 0;
		float num8 = 0f;
		for (int l = 0; l < m_previousVelocity.Count; l++)
		{
			if (!(m_previousVelocity[l] > num))
			{
				continue;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			num7++;
			num8 += m_previousVelocity[l];
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
		AnimationPlayerMoveState animationPlayerMoveState2 = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
		float num9 = c12fc2527efdb84d111088a6feabce490(c3231b2e139435eed95a398e3aa4ae19d, num8 / (float)num7);
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerMove))
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
			if (num9 != base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fSpeed"))
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
			}
			c68c59ca222c591efc1f2e51bccc4d69e(num9, c02742282011bbbd23d9cddd49045a);
		}
		else if (num7 > m_previousVelocity.Count / 2)
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
			c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMove);
			animationPlayerMoveState2.c139222162aeb0051ac37d9635fe73e12(num9, c02742282011bbbd23d9cddd49045a);
		}
		goto IL_0457;
		IL_0457:
		return true;
	}

	private void cb8143e0ffeea74468915c2603dbc50cd()
	{
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerIdle))
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
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerMove))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					float num = Mathf.Abs(base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fSpeed"));
					if (num < 0.1f)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerIdle);
								return;
							}
						}
					}
					float cf6e1a5c5132a48f8bc47958d2be74c = Mathf.Lerp(num, 0f, 0.5f);
					float @float = base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fDirection");
					AnimationPlayerMoveState animationPlayerMoveState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
					animationPlayerMoveState.c139222162aeb0051ac37d9635fe73e12(cf6e1a5c5132a48f8bc47958d2be74c, @float);
					return;
				}
				}
			}
		}
		c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerIdle);
	}

	private void c68c59ca222c591efc1f2e51bccc4d69e(float c4d1772254d8fdbe76b928d55e57936d6, float c6864cfd883866ef756adba4687e9382a = 0f)
	{
		if (!ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerMove))
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
			c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMove);
		}
		float num = Mathf.Abs(base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fSpeed"));
		float cf6e1a5c5132a48f8bc47958d2be74c = c4d1772254d8fdbe76b928d55e57936d6;
		if (Mathf.Abs(c4d1772254d8fdbe76b928d55e57936d6 - num) > 0.05f)
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
			cf6e1a5c5132a48f8bc47958d2be74c = Mathf.Lerp(num, c4d1772254d8fdbe76b928d55e57936d6, 0.3f);
		}
		AnimationPlayerMoveState animationPlayerMoveState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
		animationPlayerMoveState.c139222162aeb0051ac37d9635fe73e12(cf6e1a5c5132a48f8bc47958d2be74c, c6864cfd883866ef756adba4687e9382a);
	}

	private float c714c1c33d466e894674983e2c8e2b691(c46099de2cc6e7023f3abcc78fd614b34<float> c53c1f3be4cf27897c702958821286b6e)
	{
		if (c53c1f3be4cf27897c702958821286b6e.Count <= 0)
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
					return 0f;
				}
			}
		}
		float num = 0f;
		for (int i = 0; i < c53c1f3be4cf27897c702958821286b6e.Count; i++)
		{
			num += c53c1f3be4cf27897c702958821286b6e[i];
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			float num2 = num / (float)c53c1f3be4cf27897c702958821286b6e.Count;
			float num3 = 0f;
			for (int j = 0; j < c53c1f3be4cf27897c702958821286b6e.Count; j++)
			{
				num3 += (c53c1f3be4cf27897c702958821286b6e[j] - num2) * (c53c1f3be4cf27897c702958821286b6e[j] - num2);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return (float)Math.Sqrt(num3 / (float)(c53c1f3be4cf27897c702958821286b6e.Count - 1));
			}
		}
	}

	private void c4513a04b9a8dea6fb18bd60d276dd2a3(ref float ce7083ddfe8079e1afb14ce01648c5d92, ref float c02742282011bbbd23d9cddd49045a565)
	{
		Vector3 vector = m_movementSync.Velocity;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			vector = m_localVelocity;
			vector.y = 0f;
		}
		vector.y = 0f;
		ce7083ddfe8079e1afb14ce01648c5d92 = vector.magnitude;
		Vector3 forward = base.transform.forward;
		forward.y = 0f;
		c02742282011bbbd23d9cddd49045a565 = BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(forward.normalized, vector.normalized);
	}

	private float c12fc2527efdb84d111088a6feabce490(bool c3231b2e139435eed95a398e3aa4ae19d, float c17bdff8ddcf7aa1110e138aa6e7c0069)
	{
		if (c3231b2e139435eed95a398e3aa4ae19d)
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
					return 0.6f;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return 0.4f;
				}
			}
		}
		if (c17bdff8ddcf7aa1110e138aa6e7c0069 > 3f)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return 0.4f;
				}
			}
		}
		return 0.2f;
	}

	public void c139222162aeb0051ac37d9635fe73e12(BHVMovementSpeed cf6e1a5c5132a48f8bc47958d2be74c56, Vector3 caa3dce1583965bb94b42bc2dc68988fe, bool cebf1f96a1726d778b7b00472d03c6fb6, bool caf7cdb206a7e0647ab250f98afcde9cc, bool c09bb900266547ba461d8d4d7dc843ba2)
	{
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerDie))
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
			if (c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.PlayerDie) == AnimationStatus.RUNNING)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		float num = 0f;
		switch (cf6e1a5c5132a48f8bc47958d2be74c56)
		{
		case BHVMovementSpeed.WALK:
			num = 0.2f;
			break;
		case BHVMovementSpeed.RUN:
			num = 0.4f;
			break;
		case BHVMovementSpeed.SPRINT:
			num = 0.6f;
			break;
		default:
			num = 0f;
			break;
		}
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if ((bool)entityWeapon)
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
			entityWeapon.cfed448b0ca902482df4dd659ecb277bd(c09bb900266547ba461d8d4d7dc843ba2);
		}
		if (c09bb900266547ba461d8d4d7dc843ba2)
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
			c4355edc66bdd459bebab3228792a4426(AnimationStateFSM.PlayerAim);
		}
		else if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerAim))
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
			c059bb29245b8e57e3b793798ddfdb249("PlayerAim").caeee91e34d54e1e41ab1b380f7d8c9a4();
		}
		if (cebf1f96a1726d778b7b00472d03c6fb6)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (num > 0.1f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							AnimationPlayerCrouchMoveState animationPlayerCrouchMoveState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerCrouchMove)) as AnimationPlayerCrouchMoveState;
							float caa3dce1583965bb94b42bc2dc68988fe2 = BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(Vector3.forward, caa3dce1583965bb94b42bc2dc68988fe);
							num = 0.2f;
							animationPlayerCrouchMoveState.c139222162aeb0051ac37d9635fe73e12(num, caa3dce1583965bb94b42bc2dc68988fe2);
							c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerCrouchMove);
							return;
						}
						}
					}
				}
				c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerCrouchIdle);
				return;
			}
		}
		if (caf7cdb206a7e0647ab250f98afcde9cc)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerJump))
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
				c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerJump);
				AnimationPlayerJumpState animationPlayerJumpState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerJump)) as AnimationPlayerJumpState;
				if (animationPlayerJumpState == null)
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
					if (!animationPlayerJumpState.c7e5c0cc1fae32a7779550f78113cc845())
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
						animationPlayerJumpState.c202233e8aff844f80007ac3ee8c065a8();
						return;
					}
				}
			}
		}
		AnimationPlayerJumpState animationPlayerJumpState2 = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerJump)) as AnimationPlayerJumpState;
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerJump))
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
			if (animationPlayerJumpState2.c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpPre)
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
				if (animationPlayerJumpState2.c4de9959131c2e376835be9d32b952b04 != EAnimationJumpStep.JumpLoop)
				{
					goto IL_0225;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			animationPlayerJumpState2.c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLand;
			goto IL_0225;
		}
		goto IL_0243;
		IL_0243:
		if (num > 0.1f)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					AnimationPlayerMoveState animationPlayerMoveState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
					float caa3dce1583965bb94b42bc2dc68988fe3 = BHVTaskUtils.cb9d402b3a18cd6eb6f306d1024377f7f(Vector3.forward, caa3dce1583965bb94b42bc2dc68988fe);
					animationPlayerMoveState.c139222162aeb0051ac37d9635fe73e12(num, caa3dce1583965bb94b42bc2dc68988fe3);
					c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMove);
					return;
				}
				}
			}
		}
		c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerIdle);
		return;
		IL_0225:
		if (animationPlayerJumpState2.c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLand)
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
			c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.PlayerMove);
		}
		goto IL_0243;
	}

	public bool c35c68db077c9e358c1d58e59d105d1ca()
	{
		return true;
	}

	public bool c93a1503d0dae992d88a73cc17682ad31()
	{
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerJump))
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
			AnimationPlayerJumpState animationPlayerJumpState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerJump)) as AnimationPlayerJumpState;
			if (animationPlayerJumpState != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return animationPlayerJumpState.c7e5c0cc1fae32a7779550f78113cc845();
					}
				}
			}
		}
		return true;
	}

	public bool c1aeae0a71b089f0b72d6f76062f51163()
	{
		return ccdc879751e4e899129390bfd75c37e16("PlayerAim");
	}

	public bool cae80661bfeb2c6b447dae85baad4777d()
	{
		int result;
		if (!m_blockShootingThisFrame)
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
			result = (ccdc879751e4e899129390bfd75c37e16("PlayerFire") ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void LateUpdate()
	{
		m_blockShootingThisFrame = false;
	}

	public bool c024fc7afe02ad5f93e51d401ea4df294()
	{
		if (m_isPlayerLocal)
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
			if (m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				AnimationInfo[] currentAnimationClipState = m_firstPersonAnimator.GetCurrentAnimationClipState(0);
				for (int i = 0; i < currentAnimationClipState.Length; i++)
				{
					AnimationInfo animationInfo = currentAnimationClipState[i];
					if (!(animationInfo.clip.name == "Sprint"))
					{
						continue;
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
					if (!(animationInfo.weight > 0.1f))
					{
						continue;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		return true;
	}

	public bool c964ae19cf2139567e0ea1ed244cde093()
	{
		return ccdc879751e4e899129390bfd75c37e16("PlayerReload");
	}

	public bool c3eb03f897188a31b6772dd6177162d14()
	{
		return ccdc879751e4e899129390bfd75c37e16("PlayerMelee");
	}

	public bool c2e00749553dc3b611c72dd1c9d1ad46c()
	{
		return ccdc879751e4e899129390bfd75c37e16("PlayerSwitchWeapon");
	}

	public bool c634ca231e8b1a7ec56e967a2d0928ca8()
	{
		return ccdc879751e4e899129390bfd75c37e16("PlayerThrowGrenade");
	}

	public bool c5989500ec6e64423320cf907a28c4cd1()
	{
		return (m_entity as EntityPlayer).ccaf53be8b86b7016efd6970ff8c92ad3.c5989500ec6e64423320cf907a28c4cd1();
	}

	public bool ccdc879751e4e899129390bfd75c37e16(string c24a8ce991b5cf9e0a8d8d9fc6f3ea8e1)
	{
		return m_priorityMgr.ccdc879751e4e899129390bfd75c37e16(c24a8ce991b5cf9e0a8d8d9fc6f3ea8e1);
	}

	public void cfeb8ead5b51f4278fe8c3b81b3277fbe(float cb5cbb485927e8a6e9a71fe800cc5a962)
	{
		m_fireTiming.OnTriggerFire(cb5cbb485927e8a6e9a71fe800cc5a962);
	}

	public override void cd6f933bd268aaf1967c46349307f50eb(bool cb3e620f7e2e0ab93c5a062a93fd9a505)
	{
		m_isSetDefaultWeaponPending = true;
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			base.ccaaf181e61e5f9e050ba82237ed111a2.applyRootMotion = cb3e620f7e2e0ab93c5a062a93fd9a505;
		}
		if (!(m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_firstPersonAnimator.applyRootMotion = false;
			return;
		}
	}

	public void cb9e2a49dfad452a80cafd1443a4c8914(bool c327312845de05014a38927582dda8616)
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		switch (entityWeapon.c83e548e5608cd7f222098a6966b16545())
		{
		case WeaponType.SMG:
			if (c327312845de05014a38927582dda8616)
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
						m_AudioCtl.TriggerEventByName("Wep_SMG_1stShoot_LS_Rnd");
						return;
					}
				}
			}
			m_AudioCtl.TriggerEventByName("Wep_SMG_1stShoot_LL_Rnd");
			break;
		case WeaponType.SniperRifle:
			m_AudioCtl.TriggerEventByName("Wep_Sniper_1stShoot_Rnd");
			break;
		case WeaponType.ShotGun:
			m_AudioCtl.TriggerEventByName("Wep_Shotgun_1stShoot_Rnd");
			break;
		case WeaponType.RepeaterPistol:
			if (c327312845de05014a38927582dda8616)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						m_AudioCtl.TriggerEventByName("Wep_Repeater_1stShoot_Low_Rnd");
						return;
					}
				}
			}
			m_AudioCtl.TriggerEventByName("Wep_Repeater_1stShoot_High_Rnd");
			break;
		case WeaponType.CombatRifle:
			if (c327312845de05014a38927582dda8616)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						m_AudioCtl.TriggerEventByName("Wep_CombatRifle_Low_Short_Rnd");
						return;
					}
				}
			}
			m_AudioCtl.TriggerEventByName("Wep_CombatRifle_Low_Rnd");
			break;
		}
	}

	public void cbcc9f13feb69381a684afb37e7174b1b()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		WeaponType weaponType = entityWeapon.c83e548e5608cd7f222098a6966b16545();
		if (weaponType != 0)
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
					if (weaponType != WeaponType.CombatRifle)
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
					m_AudioCtl.TriggerEventByName("Wep_CombatRifle_Low_Tail_Rnd");
					return;
				}
			}
		}
		m_AudioCtl.TriggerEventByName("Wep_SMG_Tail_L_Rnd");
	}

	private void c4d834b619e6462cc9b9551c91bd19da5()
	{
		if (!m_firstPersonAnimator.GetComponent<MecanimEventEmitter>())
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
			m_firstPersonAnimator.GetComponent<MecanimEventEmitter>().animatorController = m_firstPersonAnimator.runtimeAnimatorController;
			return;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("AnimationManagerFSM State:\n");
		using (Dictionary<string, ce972fd150f340044b329bd2758a9cacc>.Enumerator enumerator = m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				AnimationManagerState animationManagerState = (AnimationManagerState)enumerator.Current.Value;
				AnimationStatus status = animationManagerState.m_status;
				if (status != 0)
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
					if (status != AnimationStatus.PREPARE)
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
						if (status != AnimationStatus.RUNNING)
						{
							continue;
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
				}
				stringBuilder.Append("\t").Append(animationManagerState.ca5a2b345087379ea02ec4ca950356e9f).Append("\t : ")
					.Append(status.ToString())
					.Append("\n");
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_00d1;
				}
				continue;
				end_IL_00d1:
				break;
			}
		}
		if (m_upperBodyStateMachine != null)
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
			stringBuilder.Append("Upper body state:\n");
			using (Dictionary<string, ce972fd150f340044b329bd2758a9cacc>.Enumerator enumerator2 = m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					AnimationManagerState animationManagerState2 = (AnimationManagerState)enumerator2.Current.Value;
					AnimationStatus status2 = animationManagerState2.m_status;
					if (status2 != 0)
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
						if (status2 != AnimationStatus.PREPARE)
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
							if (status2 != AnimationStatus.RUNNING)
							{
								continue;
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
					}
					stringBuilder.Append("\t").Append(animationManagerState2.ca5a2b345087379ea02ec4ca950356e9f).Append("\t : ")
						.Append(status2.ToString())
						.Append("\n");
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_01ce;
					}
					continue;
					end_IL_01ce:
					break;
				}
			}
		}
		if (base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			stringBuilder.Append("Third Person Animator:\n");
			for (int i = 0; i < base.ccaaf181e61e5f9e050ba82237ed111a2.layerCount; i++)
			{
				if (base.ccaaf181e61e5f9e050ba82237ed111a2.IsInTransition(i))
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
					stringBuilder.Append("Transition:").Append(base.ccaaf181e61e5f9e050ba82237ed111a2.GetAnimatorTransitionInfo(i).normalizedTime).Append("\n");
					AnimationInfo[] nextAnimationClipState = base.ccaaf181e61e5f9e050ba82237ed111a2.GetNextAnimationClipState(i);
					for (int j = 0; j < nextAnimationClipState.Length; j++)
					{
						AnimationInfo animationInfo = nextAnimationClipState[j];
						stringBuilder.Append("\t").Append(animationInfo.clip.name).Append("\t weight:")
							.Append(animationInfo.weight.ToString("F2"))
							.Append("\n");
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
					continue;
				}
				AnimationInfo[] currentAnimationClipState = base.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimationClipState(i);
				for (int k = 0; k < currentAnimationClipState.Length; k++)
				{
					AnimationInfo animationInfo2 = currentAnimationClipState[k];
					stringBuilder.Append("\t").Append(animationInfo2.clip.name).Append("\t weight:")
						.Append(animationInfo2.weight.ToString("F2"))
						.Append("\n");
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
				AnimatorStateInfo currentAnimatorStateInfo = base.ccaaf181e61e5f9e050ba82237ed111a2.GetCurrentAnimatorStateInfo(i);
				if (!(currentAnimatorStateInfo.length > float.Epsilon))
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				stringBuilder.Append("---Length:").Append(currentAnimatorStateInfo.length.ToString("F2")).Append("\t normalizedTime:")
					.Append(currentAnimatorStateInfo.normalizedTime.ToString("F2"))
					.Append("\n");
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		if (m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			stringBuilder.Append("First Person Animator:\n");
			for (int l = 0; l < m_firstPersonAnimator.layerCount; l++)
			{
				if (m_firstPersonAnimator.IsInTransition(l))
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
					stringBuilder.Append("Transition:").Append(m_firstPersonAnimator.GetAnimatorTransitionInfo(l).normalizedTime).Append("\n");
					AnimationInfo[] nextAnimationClipState2 = m_firstPersonAnimator.GetNextAnimationClipState(l);
					for (int m = 0; m < nextAnimationClipState2.Length; m++)
					{
						AnimationInfo animationInfo3 = nextAnimationClipState2[m];
						stringBuilder.Append("\t").Append(animationInfo3.clip.name).Append("\t weight:")
							.Append(animationInfo3.weight.ToString("F2"))
							.Append("\n");
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
					continue;
				}
				AnimationInfo[] currentAnimationClipState2 = m_firstPersonAnimator.GetCurrentAnimationClipState(l);
				for (int n = 0; n < currentAnimationClipState2.Length; n++)
				{
					AnimationInfo animationInfo4 = currentAnimationClipState2[n];
					stringBuilder.Append("\t").Append(animationInfo4.clip.name).Append("\t weight:")
						.Append(animationInfo4.weight.ToString("F2"))
						.Append("\n");
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				AnimatorStateInfo currentAnimatorStateInfo2 = m_firstPersonAnimator.GetCurrentAnimatorStateInfo(l);
				if (!(currentAnimatorStateInfo2.length > float.Epsilon))
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				stringBuilder.Append("---Length:").Append(currentAnimatorStateInfo2.length.ToString("F2")).Append("\t normalizedTime:")
					.Append(currentAnimatorStateInfo2.normalizedTime.ToString("F2"))
					.Append("\n");
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		if (m_AnimatorGraph != null)
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
			stringBuilder.Append("Animator Graph:\n---Parameters : ");
			using (List<string>.Enumerator enumerator3 = m_AnimatorGraph.c8ce5a230d9f8687db39b5315551900fd().GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					string current = enumerator3.Current;
					if (!m_firstPersonAnimator.GetBool(current))
					{
						continue;
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
					stringBuilder.Append(current).Append(",");
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0778;
					}
					continue;
					end_IL_0778:
					break;
				}
			}
			stringBuilder.Append("\n");
			m_transitionHistoryMgr.Update();
			stringBuilder.Append("---Transition History: \n\t");
			stringBuilder.Append(m_transitionHistoryMgr.ToString());
			stringBuilder.Append("\n\n");
			AnimationPlayerFireState animationPlayerFireState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.PlayerFire)) as AnimationPlayerFireState;
			stringBuilder.Append("FireHolding:  ").Append(animationPlayerFireState.cb1d2e2a39a3e6e0b1c0410414e4f6365());
		}
		return stringBuilder.ToString();
	}

	public bool c04ca5acd4c692e7b2a810ed8ac4deeca()
	{
		if (base.ccaaf181e61e5f9e050ba82237ed111a2.GetBool("bMove"))
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
					return false;
				}
			}
		}
		if (ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM.PlayerJump))
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
			if (c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.PlayerJump) == AnimationStatus.RUNNING)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		return true;
	}

	public void ce9ffc91c96fab37637f0807e22fe4ba4()
	{
		PlayerInfoSync playerInfoSync = GetComponent<EntityPlayer>().cd95354b53e674ec7dc9594e66e4d316f();
		AvatarType avatarType = playerInfoSync.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
		base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("iAvatarType", (int)avatarType);
		base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bLocalPlayer", playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194());
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			base.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fDefaultPose", (float)avatarType);
			return;
		}
	}
}
