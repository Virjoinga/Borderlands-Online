using System.Text;
using A;
using UnityEngine;

public class BanditPsychoAnimationManagerFSM : NPCAnimationManagerFSM
{
	private const int UPPERBODY_LAYER = 1;

	public GameObject m_weaponNPC;

	public void c7e468ebc1b89422a70281492a69034b0()
	{
		if (m_weaponHolder == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		StringBuilder stringBuilder = new StringBuilder("Entities/Object/Weapon/");
		if (m_setup.m_settings.m_weaponHolderName == "Bip01 R Hand_AXE")
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
			stringBuilder.Append(m_setup.m_settings.m_weaponPrefabName);
		}
		else if (m_setup.m_settings.m_weaponHolderName == "Bip01 L Hand_GRENADE")
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
			stringBuilder.Append("WPN_Grenade_Dummy");
		}
		m_weaponNPC = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(stringBuilder.ToString()));
		if (!(m_weaponNPC != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			PsychoThrowAxe component = m_weaponNPC.GetComponent<PsychoThrowAxe>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Object.Destroy(component);
			}
			m_weaponNPC.transform.parent = m_weaponHolder;
			m_weaponNPC.transform.localPosition = Vector3.zero;
			m_weaponNPC.transform.localRotation = Quaternion.identity;
			m_weaponNPC.SetActive(true);
			return;
		}
	}

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = true;
		m_canUseFacingLogic = false;
		m_deathLayer = 2;
		c7e468ebc1b89422a70281492a69034b0();
		if ((m_entity as EntityNpc).cacbe09dd8d5d8eaa8df1a1884004dfe2() == EntityNpc.EntityNpcRank.Badass)
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
			m_animEventHandlerList.Add("ThrowWeapon", base.OnThrowWeapon);
			m_animEventHandlerList.Add("SpawnWeapon", OnSpawnWeapon);
		}
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
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
					return 1;
				}
			}
		}
		return 0;
	}

	public void OnSpawnWeapon()
	{
		AnimationThrowWeaponState animationThrowWeaponState = c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.ThrowWeapon)) as AnimationThrowWeaponState;
		if (animationThrowWeaponState == null)
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
			animationThrowWeaponState.m_spawnNewWeapon = true;
			return;
		}
	}
}
