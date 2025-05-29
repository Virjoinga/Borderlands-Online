using A;
using UnityEngine;

public class BanditApollyonAnimationManagerFSM : NPCAnimationManagerFSM
{
	private const int UPPERBODY_LAYER = 1;

	public float m_lastShotSoundTime;

	public GameObject m_hammerObj;

	public bool m_bHammerHit;

	public Transform m_hammerVFXTransform;

	public Transform m_backHammerTransform;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = true;
		m_canUseFacingLogic = true;
		m_bHammerHit = false;
		if (m_animEventHandlerList != null)
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
			m_animEventHandlerList.Add("StartShoot", OnStartShoot);
		}
		m_animEventHandlerList.Add("MeleeHit", OnHammerAttackHit);
		m_animEventHandlerList.Add("TakeOutHammer", OnTakeOutHammer);
		m_animEventHandlerList.Add("PutBackHammer", OnPutBackHammer);
		c86383d232e04244997871b4bab010576();
	}

	public void c86383d232e04244997871b4bab010576()
	{
		m_hammerObj = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/WPN_Hammer_Apollyon"));
		if (m_hammerObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Transform[] componentsInChildren = m_hammerObj.transform.GetComponentsInChildren<Transform>();
			int num = componentsInChildren.Length;
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					Transform transform = componentsInChildren[num2];
					if (transform.gameObject.name == "PTL_Smash_Point")
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
						m_hammerVFXTransform = transform;
						break;
					}
					num2++;
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
				break;
			}
		}
		cc8e5aacfed551c3e66941834d2baff23(true);
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
					return 4;
				}
			}
		}
		return 0;
	}

	public void OnStartShoot()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityWeapon weapon = m_entity.cdcf5e0592c05a681a8470f66674efd0b().m_weapon;
		if (!(weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			weapon.c6f2004a1cbc439c9b630d1dd5c028bf3();
			return;
		}
	}

	public void cc8e5aacfed551c3e66941834d2baff23(bool cf2132047cb8681ca9c24088ec2982644)
	{
		EntityNpc component = GetComponent<EntityNpc>();
		if (component.m_rightHandWeaponSlot == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!(m_hammerObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (cf2132047cb8681ca9c24088ec2982644)
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
				m_hammerObj.transform.parent = m_backHammerTransform;
			}
			else
			{
				m_hammerObj.transform.parent = component.m_leftHandWeaponSlot;
			}
			m_hammerObj.transform.localPosition = Vector3.zero;
			m_hammerObj.transform.localRotation = Quaternion.identity;
			m_hammerObj.SetActive(true);
			return;
		}
	}

	public void OnTakeOutHammer()
	{
		cc8e5aacfed551c3e66941834d2baff23(false);
	}

	public void OnPutBackHammer()
	{
		cc8e5aacfed551c3e66941834d2baff23(true);
	}

	public void OnHammerAttackHit()
	{
		m_bHammerHit = true;
	}
}
