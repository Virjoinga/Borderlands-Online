using System;
using A;
using BHV;
using UnityEngine;
using XsdSettings;

public class PlayerBehavior : MonoBehaviour
{
	public enum KeyConflictFlag
	{
		None = 0,
		AimWin = 1,
		SprintWin = 2
	}

	private EntityPlayer m_entity;

	private PlayerController m_playerController;

	private BHVTaskManager m_taskManager;

	private IBadAssCharacterMotor m_motor;

	private BHVFirstPersonSettings m_firstPersonSettings;

	private bool m_isRunning;

	private bool m_isMovingForward;

	private bool m_isMovingBackward;

	private bool m_isMovingLeft;

	private bool m_isMovingRight;

	private bool m_isJumping;

	private bool m_isAiming;

	private bool m_isCrouching;

	private bool m_isFiring;

	private bool m_isAutoFiring;

	private bool m_isReloading;

	private bool m_isAutoReload;

	private bool m_isSwitchingWeapon;

	private bool m_isUsingSkill;

	private bool m_isInteracting;

	private bool m_isThrowing;

	private bool m_isMeleeing;

	private byte m_nextWeaponIndex;

	private byte m_previousWeaponIndex;

	private bool m_inverseMouse;

	private float m_yaw;

	private float m_pitch;

	private float m_angularVelocityYaw;

	private float m_angularVelocityPitch;

	private float m_recoilOffsetYaw;

	private float m_recoilOffsetPitch;

	private float m_recoilOffsetKickBack;

	private int m_randomIndex;

	private float m_nextFireTime;

	private EntityWeapon.RecoilSettings m_recoilSettingsYaw = new EntityWeapon.RecoilSettings();

	private EntityWeapon.RecoilSettings m_recoilSettingsPitch = new EntityWeapon.RecoilSettings();

	private EntityWeapon.RecoilSettings m_recoilSettingsKickBack = new EntityWeapon.RecoilSettings();

	private int m_lastInputTickCount;

	private float m_lastUpdateDeltaTime;

	private float m_AccmulatedRotationTime;

	public bool holdToCrouch;

	private Transform m_posToFollowByCamera;

	private Vector3 m_velocityOfCameraTarget = Vector3.zero;

	private Vector3 m_lastTargetPos;

	private Vector3 m_velocityOfMine = Vector3.zero;

	private Vector3 m_lastMinePos;

	private KeyConflictFlag m_conflictFlag;

	private void Start()
	{
		m_lastUpdateDeltaTime = Time.deltaTime;
		m_entity = GetComponent<EntityPlayer>();
		m_playerController = GetComponent<PlayerController>();
		m_taskManager = m_entity.c9b6d1d87bef7b03dad787ff0031551ee();
		m_motor = (IBadAssCharacterMotor)GetComponent(Type.GetTypeFromHandle(ccb2c22bcfee08b93405b7f92e89d5415.cc1720d05c75832f704b87474932341c3()));
		m_firstPersonSettings = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>();
		if (!(m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_entity.cd95354b53e674ec7dc9594e66e4d316f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!m_entity.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
					holdToCrouch = c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cbe5897c1bba97712ed8ffb95b193d497(SettingFunctionType.HoldCrouching);
					c3389544f22fed31da6c1ef5fb1f1ede8(c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c93a361c45829617f798f69b2d0c74a59(SettingFunctionType.MouseSensitivity));
					c3e1675ba5245fab3594c507dca5bd645(c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cbe5897c1bba97712ed8ffb95b193d497(SettingFunctionType.InvertMouse));
					return;
				}
			}
		}
	}

	public virtual void Update()
	{
		m_lastUpdateDeltaTime = Time.deltaTime;
		c1d083aaf39b2c8e15949997f050780ce();
	}

	public bool cb261500372fa488b369e9159a002977a()
	{
		return m_isRunning;
	}

	public bool c8cc0ce1bacf416fdd879d1e63947960f()
	{
		if (m_isJumping)
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
					return true;
				}
			}
		}
		if (m_motor == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_motor.c8cc0ce1bacf416fdd879d1e63947960f();
	}

	public bool c4d927c91307ef767ba359c476291c950()
	{
		return m_isAiming;
	}

	public bool c7201a6224668404b44ad10a24fe68d67()
	{
		return m_isCrouching;
	}

	public bool c951140c92ca71036302f26696e18751f()
	{
		return m_isMovingForward;
	}

	public bool c29aef5bca56d4364b401e4b0a37de51c()
	{
		return m_isMovingBackward;
	}

	public bool ca25425e29e88f33176c1022724eee2bb()
	{
		return m_isMovingLeft;
	}

	public bool c91579ebaaadce993ae1215fbdb24ab15()
	{
		return m_isMovingRight;
	}

	public bool cade5de2c3f4c8548cddac952328dbd08()
	{
		int result;
		if (!m_isFiring)
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
			result = (m_isAutoFiring ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool cc398985de9cbef8f2199a7f1eebc37dd()
	{
		return m_isReloading;
	}

	public bool ca4315eacba51144e39f7013a08e650ec()
	{
		return m_isUsingSkill;
	}

	public bool c78ca1a7bffb374a7bbec338c3208c4b5()
	{
		return m_isSwitchingWeapon;
	}

	public bool c1d750be162b222bedb13c5c1a88eac75()
	{
		return m_isInteracting;
	}

	public bool c3d9edee0a5ee12ca677409daf26f3e9f()
	{
		return m_isThrowing;
	}

	public bool c212938a308d79596b1acd410e24ec08d()
	{
		c4cd47251b66a298d77bc1a15013200f3();
		return m_isMeleeing;
	}

	public byte c5c09844fd0f91323d4862a0049207950()
	{
		return m_nextWeaponIndex;
	}

	public void cef9a15f55812dc1fbddb2da6f1d2e6f3(float ccc714c0eabb517feca15832e42c5ea24)
	{
		m_yaw = ccc714c0eabb517feca15832e42c5ea24;
	}

	public void c222a9c0d0fa89d627bd2ccdc0d9092fc(float cfee6ec9d0f72edba0c1441c31e6edd81)
	{
		m_pitch = cfee6ec9d0f72edba0c1441c31e6edd81;
	}

	public float c259f5ac0c9db15294799713b057316e2()
	{
		return c6fc49b73f745c2e4837b1bbaf188a366(m_yaw + m_recoilOffsetYaw);
	}

	public float c0ef1c2208343152444f9bd5c768b4232()
	{
		return c6fc49b73f745c2e4837b1bbaf188a366(m_pitch - m_recoilOffsetPitch);
	}

	public float c8a422b23a900df0a17ed453471c4e18a()
	{
		return c6fc49b73f745c2e4837b1bbaf188a366(m_yaw);
	}

	public float c9195c80922216a5abb5ecd0564707280()
	{
		return c6fc49b73f745c2e4837b1bbaf188a366(m_pitch);
	}

	public float c86f11bcf921576e291dec189a4fa5416()
	{
		return m_angularVelocityYaw;
	}

	public float cfd4613bd0d4dba1d6c84fa3cc04873ac()
	{
		return m_angularVelocityPitch;
	}

	public float c1a53b45c4e304dfaa2022e79f79a4680()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if ((bool)entityWeapon)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					float cfee6ec9d0f72edba0c1441c31e6edd = 0f;
					float ccc714c0eabb517feca15832e42c5ea = 0f;
					float c929d6dc26794b71ada3b76f22282c0f = 0f;
					entityWeapon.c238e636f92b95aa1e2dc49a970f54faf(ref cfee6ec9d0f72edba0c1441c31e6edd, ref ccc714c0eabb517feca15832e42c5ea, ref c929d6dc26794b71ada3b76f22282c0f);
					return c929d6dc26794b71ada3b76f22282c0f;
				}
				}
			}
		}
		return 0f;
	}

	public Quaternion ce4f354aefe25b1e9ab3bac6e5807a384()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if ((bool)entityWeapon)
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
					float cfee6ec9d0f72edba0c1441c31e6edd = 0f;
					float ccc714c0eabb517feca15832e42c5ea = 0f;
					float c929d6dc26794b71ada3b76f22282c0f = 0f;
					entityWeapon.c238e636f92b95aa1e2dc49a970f54faf(ref cfee6ec9d0f72edba0c1441c31e6edd, ref ccc714c0eabb517feca15832e42c5ea, ref c929d6dc26794b71ada3b76f22282c0f);
					return Quaternion.Euler(ccc714c0eabb517feca15832e42c5ea, 0f, cfee6ec9d0f72edba0c1441c31e6edd);
				}
				}
			}
		}
		return Quaternion.identity;
	}

	private void cb0236037ddc5cb3f09aa9c02cb399cf2()
	{
		if (m_playerController == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_entity.cd95354b53e674ec7dc9594e66e4d316f() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf5958ca7bf2c10a23368dbc19f24a619())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_isRunning = false;
				m_isMovingForward = false;
				m_isMovingBackward = false;
				m_isMovingLeft = false;
				m_isMovingRight = false;
				m_isJumping = false;
				m_isAiming = false;
				m_isFiring = false;
				m_isAutoFiring = false;
				m_isReloading = false;
				m_isAutoReload = false;
				m_isSwitchingWeapon = false;
				m_isUsingSkill = false;
				m_isInteracting = false;
				c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
				m_isThrowing = false;
				m_isMeleeing = false;
				return;
			}
		}
		if (m_lastInputTickCount == Time.frameCount)
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
		m_lastInputTickCount = Time.frameCount;
		m_isMovingForward = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Forward");
		m_isMovingBackward = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Backward");
		m_isMovingLeft = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Left");
		m_isMovingRight = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Right");
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Run"))
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
			if (m_isRunning)
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
				m_isRunning = false;
			}
			else if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Forward"))
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
				m_isRunning = true;
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Forward"))
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
			m_isRunning = false;
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Fire2"))
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
			if (m_playerController.c1aeae0a71b089f0b72d6f76062f51163())
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
				m_isAiming = true;
				m_isAutoFiring = false;
				goto IL_028c;
			}
		}
		m_isAiming = false;
		goto IL_028c;
		IL_0919:
		if (m_isReloading)
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
			m_isAiming = false;
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Skill"))
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
			if (m_playerController.ce3904876c92a696689165a6348ded9f6())
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
				m_isRunning = false;
				m_isUsingSkill = true;
				goto IL_0981;
			}
		}
		m_isUsingSkill = false;
		goto IL_0981;
		IL_0981:
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Interaction"))
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
			if (m_playerController.c69e93962e1ca78e26e0c6dfcd5b44426())
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
				c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_availableInteraction;
				m_isInteracting = true;
				goto IL_0a2b;
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c335a1480fba59f7a546ea6803a9374b9("Interaction"))
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
			if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf5958ca7bf2c10a23368dbc19f24a619())
			{
				goto IL_0a2b;
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
		c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
		m_isInteracting = false;
		goto IL_0a2b;
		IL_0a2b:
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Throw"))
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
			if (m_playerController.c9ebaaf97541199e490a4e6249772a282())
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
				m_isThrowing = true;
				goto IL_0a73;
			}
		}
		m_isThrowing = false;
		goto IL_0a73;
		IL_0a73:
		c4cd47251b66a298d77bc1a15013200f3();
		return;
		IL_0564:
		bool flag = false;
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("ChangeToPreviousWeapon"))
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
			m_nextWeaponIndex = m_previousWeaponIndex;
			flag = true;
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("ChangeWeapon1"))
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
			m_nextWeaponIndex = 0;
			flag = true;
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("ChangeWeapon2"))
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
			m_nextWeaponIndex = 1;
			flag = true;
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("ChangeWeapon3"))
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
			m_nextWeaponIndex = 2;
			flag = true;
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("ChangeWeapon4"))
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
			m_nextWeaponIndex = 3;
			flag = true;
		}
		if (!m_isSwitchingWeapon)
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
			if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8bb22a671c1c2a7c9a01ddc52a812d1d("SwitchWeapon") != 0f)
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
				EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = m_entity.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
				if (equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_nextWeaponIndex = equipmentInventoryEntityPlayer.c5c09844fd0f91323d4862a0049207950();
					flag = true;
				}
			}
		}
		byte b = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c91233b4b8268e8e24a4daa8c053e41ec();
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
			if (b != m_nextWeaponIndex)
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
				if (m_playerController.c611613a4cdf13c7acc73007bf65a3d2c(m_nextWeaponIndex))
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
					m_previousWeaponIndex = b;
					m_isSwitchingWeapon = true;
					m_isFiring = false;
					m_isAutoFiring = false;
					m_isReloading = false;
					m_isAiming = false;
					goto IL_0726;
				}
			}
		}
		m_isSwitchingWeapon = false;
		goto IL_0726;
		IL_03d5:
		EntityWeapon entityWeapon;
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Fire1"))
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
			if (m_playerController.cae80661bfeb2c6b447dae85baad4777d())
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
				if (m_playerController.c219a72dae1bf057dec472ae4c07937d6())
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
					if (m_playerController.c964ae19cf2139567e0ea1ed244cde093())
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
						m_isReloading = true;
					}
					m_isFiring = false;
					m_isAutoFiring = false;
				}
				else
				{
					if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entityWeapon.c7f7043e0de2367bd0181a33839512fe5())
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
							m_isFiring = false;
							if (entityWeapon.c2ad87a1cfefcac8e88894aa679b33ca1())
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
								m_isAutoFiring = true;
							}
							goto IL_0564;
						}
					}
					m_isFiring = true;
					m_isAutoFiring = false;
				}
				goto IL_0564;
			}
		}
		m_isFiring = false;
		if (m_playerController.cae80661bfeb2c6b447dae85baad4777d())
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
			if (m_playerController.c219a72dae1bf057dec472ae4c07937d6())
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
				if (m_playerController.c964ae19cf2139567e0ea1ed244cde093())
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
					if (!m_isAutoReload)
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
						m_isAutoReload = true;
						m_isReloading = true;
					}
				}
			}
		}
		if (!m_playerController.c219a72dae1bf057dec472ae4c07937d6())
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
			if (m_isAutoReload)
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
				m_isAutoReload = false;
			}
		}
		goto IL_0564;
		IL_0331:
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Reload"))
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
			if (m_playerController.c964ae19cf2139567e0ea1ed244cde093())
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
				m_isReloading = true;
				m_isFiring = false;
				m_isAutoFiring = false;
				goto IL_0564;
			}
		}
		m_isReloading = false;
		entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (entityWeapon.c0e97a4ad5a71613ca514fc6d82ba84bb())
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
				m_isAutoFiring = true;
				goto IL_03d5;
			}
		}
		m_isAutoFiring = false;
		goto IL_03d5;
		IL_028c:
		if (m_isRunning)
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
			if (m_isAiming)
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
				if (m_conflictFlag == KeyConflictFlag.None)
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
					if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Run"))
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
						m_conflictFlag = KeyConflictFlag.SprintWin;
					}
					else
					{
						m_conflictFlag = KeyConflictFlag.AimWin;
					}
				}
				if (m_conflictFlag == KeyConflictFlag.SprintWin)
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
					m_isAiming = false;
					m_isRunning = true;
				}
				else
				{
					m_isAiming = true;
					m_isRunning = false;
				}
				goto IL_0331;
			}
		}
		m_conflictFlag = KeyConflictFlag.None;
		goto IL_0331;
		IL_0726:
		if (holdToCrouch)
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
			if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Crouch"))
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
				if (m_playerController.c35c68db077c9e358c1d58e59d105d1ca())
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
					m_isCrouching = true;
				}
			}
			else if (m_playerController.cf2c2e13913fe2591bb62635eab3e3271())
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
				m_isCrouching = false;
			}
		}
		else if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Crouch"))
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
			if (m_isCrouching)
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
				if (m_playerController.cf2c2e13913fe2591bb62635eab3e3271())
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
					m_isCrouching = false;
				}
			}
			else if (m_playerController.c35c68db077c9e358c1d58e59d105d1ca())
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
				m_isCrouching = true;
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Jump"))
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
			if (m_playerController.c93a1503d0dae992d88a73cc17682ad31())
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
				if (m_isCrouching)
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
					if (m_playerController.cf2c2e13913fe2591bb62635eab3e3271())
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
						m_isJumping = false;
						m_isCrouching = false;
					}
				}
				else
				{
					m_isJumping = true;
				}
				goto IL_0894;
			}
		}
		m_isJumping = false;
		goto IL_0894;
		IL_0894:
		if (m_isFiring)
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
			m_isRunning = false;
		}
		if (m_isRunning)
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
			if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Run"))
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
				if (m_playerController.cf2c2e13913fe2591bb62635eab3e3271())
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
					m_isCrouching = false;
				}
				goto IL_0919;
			}
		}
		if (m_isCrouching)
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
			m_isRunning = false;
		}
		goto IL_0919;
	}

	private void c4cd47251b66a298d77bc1a15013200f3()
	{
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("MeleeAttack"))
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
			if (m_playerController.cab804f2f3e0598357bf19fd25b1d3faf())
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
				if (!m_isInteracting)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_isMeleeing = true;
							m_isAiming = false;
							m_isAutoReload = false;
							return;
						}
					}
				}
			}
		}
		m_isMeleeing = false;
	}

	public void cccac5da4d41afa803b9bd5624fd7e697()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		entityWeapon.c590c8dccc628cb573151dc19bc6b7328(ref m_recoilSettingsYaw);
		m_recoilOffsetYaw = Mathf.Clamp(m_recoilOffsetYaw, m_recoilSettingsYaw.m_offsetMin, m_recoilSettingsYaw.m_offsetMax);
		m_recoilOffsetYaw += m_recoilSettingsYaw.m_randomOffsetMin + (m_recoilSettingsYaw.m_randomOffsetMax - m_recoilSettingsYaw.m_randomOffsetMin) * Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomIndex++);
		entityWeapon.cf40305bb67d9e02d7dee3f86902b1649(ref m_recoilSettingsPitch);
		float num = m_recoilSettingsPitch.m_randomOffsetMin + (m_recoilSettingsPitch.m_randomOffsetMax - m_recoilSettingsPitch.m_randomOffsetMin) * Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomIndex++);
		float num2 = Mathf.Clamp(m_recoilOffsetPitch / m_recoilSettingsPitch.m_randomOffsetMax, FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(entityWeapon.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchMulMin) as FloatAttributeValue), FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(entityWeapon.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.RecoilPitchMulMax) as FloatAttributeValue));
		num *= num2;
		m_recoilOffsetPitch = Mathf.Clamp(m_recoilOffsetPitch, m_recoilSettingsPitch.m_offsetMin, m_recoilSettingsPitch.m_offsetMax);
		m_recoilOffsetPitch += num;
		entityWeapon.c268776d14847f8c011e4a364ffb53fba(ref m_recoilSettingsKickBack);
		m_recoilOffsetKickBack = Mathf.Clamp(m_recoilOffsetKickBack, m_recoilSettingsKickBack.m_offsetMin, m_recoilSettingsKickBack.m_offsetMax);
		m_recoilOffsetKickBack += m_recoilSettingsKickBack.m_randomOffsetMin + (m_recoilSettingsKickBack.m_randomOffsetMax - m_recoilSettingsKickBack.m_randomOffsetMin) * Utils.StaticRandom.c588e7dbcd383d8230b2d83d7b44af23b(m_randomIndex++);
		if (c4d927c91307ef767ba359c476291c950())
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
			float num3 = m_entity.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.WeaponRecoil);
			m_recoilOffsetYaw *= num3;
			m_recoilOffsetPitch *= num3;
			m_recoilOffsetKickBack *= num3;
		}
		if (entityWeapon.c7792c484b60d7c05b9ef0053fa855896() > 0f)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					m_nextFireTime = entityWeapon.m_nextFireTime;
					return;
				}
			}
		}
		m_nextFireTime = Time.time;
	}

	private void c1e9a5ae192d8d43354ea7b0dbf40f5ec(EntityWeapon.RecoilSettings c4be63b1981317018fd795c1d76792341, ref float c52921fe9488ee3d539be727c81094423)
	{
		if (c52921fe9488ee3d539be727c81094423 > 0f)
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
					if (m_nextFireTime > Time.fixedTime)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								c52921fe9488ee3d539be727c81094423 -= Time.fixedDeltaTime * c4be63b1981317018fd795c1d76792341.m_reducingRateActive;
								return;
							}
						}
					}
					c52921fe9488ee3d539be727c81094423 -= Time.fixedDeltaTime * c4be63b1981317018fd795c1d76792341.m_reducingRateOnIdle;
					return;
				}
			}
		}
		c52921fe9488ee3d539be727c81094423 = 0f;
	}

	private void c2ee64fdf581bc5be0af7aa2bfdfd8fd0(EntityWeapon.RecoilSettings c4be63b1981317018fd795c1d76792341, ref float c52921fe9488ee3d539be727c81094423)
	{
		if (c52921fe9488ee3d539be727c81094423 > 0f)
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
					if (m_nextFireTime > Time.fixedTime)
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
						c52921fe9488ee3d539be727c81094423 -= Time.fixedDeltaTime * c4be63b1981317018fd795c1d76792341.m_reducingRateActive;
					}
					else
					{
						c52921fe9488ee3d539be727c81094423 -= Time.fixedDeltaTime * c4be63b1981317018fd795c1d76792341.m_reducingRateOnIdle;
					}
					if (c52921fe9488ee3d539be727c81094423 <= 0f)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								c52921fe9488ee3d539be727c81094423 = 0f;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(c52921fe9488ee3d539be727c81094423 < 0f))
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
			if (m_nextFireTime > Time.fixedTime)
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
				c52921fe9488ee3d539be727c81094423 += Time.fixedDeltaTime * c4be63b1981317018fd795c1d76792341.m_reducingRateActive;
			}
			else
			{
				c52921fe9488ee3d539be727c81094423 += Time.fixedDeltaTime * c4be63b1981317018fd795c1d76792341.m_reducingRateOnIdle;
			}
			if (!(c52921fe9488ee3d539be727c81094423 >= 0f))
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
				c52921fe9488ee3d539be727c81094423 = 0f;
				return;
			}
		}
	}

	protected void c1e9a5ae192d8d43354ea7b0dbf40f5ec()
	{
		c2ee64fdf581bc5be0af7aa2bfdfd8fd0(m_recoilSettingsYaw, ref m_recoilOffsetYaw);
		c1e9a5ae192d8d43354ea7b0dbf40f5ec(m_recoilSettingsPitch, ref m_recoilOffsetPitch);
		c1e9a5ae192d8d43354ea7b0dbf40f5ec(m_recoilSettingsKickBack, ref m_recoilOffsetKickBack);
	}

	private void cd63e3c39678cdcd3950e87f4487fbd0a(float c2002bb238c228cf502166e05c0d89311)
	{
		if (m_posToFollowByCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c667f1f40e20b32d6e9cba43430e8d9be();
		}
		else
		{
			c7eecf1dc90d9eb5654da9ab1bbab50ea(c2002bb238c228cf502166e05c0d89311);
		}
		ca058546bfcb3d82b026a8becf9e1a502();
	}

	protected virtual void FixedUpdate()
	{
		c1e9a5ae192d8d43354ea7b0dbf40f5ec();
		cb0236037ddc5cb3f09aa9c02cb399cf2();
		cd63e3c39678cdcd3950e87f4487fbd0a(Time.fixedDeltaTime);
	}

	private void ca058546bfcb3d82b026a8becf9e1a502()
	{
		EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!m_isAiming)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			entityWeapon.m_wander_manager.Update();
			m_yaw += entityWeapon.m_wander_manager.ccb06a75f06c324eada17773dc99efb6b();
			m_yaw = c6fc49b73f745c2e4837b1bbaf188a366(m_yaw);
			m_pitch += entityWeapon.m_wander_manager.c33b81ab194703a85ac0990aebde19532();
			m_pitch = Mathf.Clamp(m_pitch, 0f - m_firstPersonSettings.m_cameraAngleMaxPitch, 0f - m_firstPersonSettings.m_cameraAngleMinPitch);
			return;
		}
	}

	private void c667f1f40e20b32d6e9cba43430e8d9be()
	{
		if (m_AccmulatedRotationTime > m_lastUpdateDeltaTime)
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
		float c61c8f2ed680a81e6a732b5b = 0f;
		float caffcc2863a479dfc06ba5e = 0f;
		cd44f6bdcdc858eaca35d29d36650f176(ref c61c8f2ed680a81e6a732b5b, ref caffcc2863a479dfc06ba5e);
		float num = 0f;
		float num2 = 0f;
		if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf5958ca7bf2c10a23368dbc19f24a619())
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
			num = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8bb22a671c1c2a7c9a01ddc52a812d1d("Mouse X");
			num *= Time.fixedDeltaTime / m_lastUpdateDeltaTime;
			num2 = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8bb22a671c1c2a7c9a01ddc52a812d1d("Mouse Y");
			num2 *= Time.fixedDeltaTime / m_lastUpdateDeltaTime;
		}
		m_angularVelocityYaw = num * c61c8f2ed680a81e6a732b5b;
		m_angularVelocityPitch = num2 * caffcc2863a479dfc06ba5e;
		if (m_inverseMouse)
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
			m_angularVelocityPitch *= -1f;
		}
		m_angularVelocityYaw = m_entity.ccaf53be8b86b7016efd6970ff8c92ad3.c468fbfea492ec867a1235b96939944ea(m_angularVelocityYaw);
		m_AccmulatedRotationTime += Time.fixedDeltaTime;
		m_yaw += m_angularVelocityYaw;
		m_yaw = c6fc49b73f745c2e4837b1bbaf188a366(m_yaw);
		m_pitch -= m_angularVelocityPitch;
		m_pitch = Mathf.Clamp(m_pitch, 0f - m_firstPersonSettings.m_cameraAngleMaxPitch, 0f - m_firstPersonSettings.m_cameraAngleMinPitch);
	}

	private float c6fc49b73f745c2e4837b1bbaf188a366(float cdeaa898a2de80d01f4d89a02fcb24a09)
	{
		float num = cdeaa898a2de80d01f4d89a02fcb24a09 % 360f;
		if (num < 0f)
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
			num += 360f;
		}
		return num;
	}

	private void c1d083aaf39b2c8e15949997f050780ce()
	{
		m_AccmulatedRotationTime = 0f;
	}

	private void cd44f6bdcdc858eaca35d29d36650f176(ref float c61c8f2ed680a81e6a732b5b181224697, ref float caffcc2863a479dfc06ba5e0962123717)
	{
		if (m_isAiming)
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
			EntityWeapon entityWeapon = m_entity.c3941dac8608f650ceb15dc36294a741c();
			if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						entityWeapon.c6701dc281cbcd330b4dd9b8d790bab90(ref c61c8f2ed680a81e6a732b5b181224697, ref caffcc2863a479dfc06ba5e0962123717);
						return;
					}
				}
			}
		}
		c61c8f2ed680a81e6a732b5b181224697 = m_firstPersonSettings.m_cameraAngularSpeedYaw;
		caffcc2863a479dfc06ba5e0962123717 = m_firstPersonSettings.m_cameraAngularSpeedPitch;
	}

	public void c3389544f22fed31da6c1ef5fb1f1ede8(float c5ceff30f6d428c3c4ce2e9c8e691e31a)
	{
		m_firstPersonSettings.m_cameraAngularSpeedYaw = c5ceff30f6d428c3c4ce2e9c8e691e31a;
		m_firstPersonSettings.m_cameraAngularSpeedPitch = c5ceff30f6d428c3c4ce2e9c8e691e31a;
	}

	public float cd44f6bdcdc858eaca35d29d36650f176()
	{
		return m_firstPersonSettings.m_cameraAngularSpeedYaw;
	}

	public void c1303fb339fb3afd9e5931160fcca18cc(Transform c5934603828f9e9928c0d117240d0ff65)
	{
		m_posToFollowByCamera = c5934603828f9e9928c0d117240d0ff65;
		m_lastTargetPos = m_posToFollowByCamera.position;
		m_lastMinePos = m_playerController.ce2053aa14178b14997db504c8a6e907e().position;
	}

	public void c23b559d4547aa3ece9286f3fadfd44b9()
	{
		m_posToFollowByCamera = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void c7eecf1dc90d9eb5654da9ab1bbab50ea(float c2002bb238c228cf502166e05c0d89311)
	{
		m_velocityOfCameraTarget = (m_posToFollowByCamera.position - m_lastTargetPos) / c2002bb238c228cf502166e05c0d89311;
		m_lastTargetPos = m_posToFollowByCamera.position;
		m_velocityOfMine = (m_playerController.ce2053aa14178b14997db504c8a6e907e().position - m_lastMinePos) / c2002bb238c228cf502166e05c0d89311;
		m_lastMinePos = m_playerController.ce2053aa14178b14997db504c8a6e907e().position;
		Vector3 lookRotation = m_posToFollowByCamera.position + m_velocityOfCameraTarget * c2002bb238c228cf502166e05c0d89311 - (m_playerController.ce2053aa14178b14997db504c8a6e907e().position + m_velocityOfMine * c2002bb238c228cf502166e05c0d89311);
		Quaternion identity = Quaternion.identity;
		identity.SetLookRotation(lookRotation);
		m_yaw = identity.eulerAngles.y;
		m_pitch = identity.eulerAngles.x;
	}

	public void cb230cde4e133468f684068c91db18b7e(bool c8ed534095c0669d0efc1594393bf0d5b)
	{
		m_isCrouching = c8ed534095c0669d0efc1594393bf0d5b;
	}

	public Vector3 cd9761354b8ba9519cb1ef92160cf8b59()
	{
		return m_motor.c02ba69b872ce3005f0d20ea25e9b15cf().velocity;
	}

	public BHVFirstPersonSettings c83296771aacb04d01c8b957f0a990ece()
	{
		return m_firstPersonSettings;
	}

	public void c3e1675ba5245fab3594c507dca5bd645(bool c032f33e38e78222047846ac4faa8e52c)
	{
		m_inverseMouse = c032f33e38e78222047846ac4faa8e52c;
	}
}
