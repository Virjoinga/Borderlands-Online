using System.Collections;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class EquipmentInventoryEntityPlayer : EquipmentInventoryEntity, IPhotonEvaluate
{
	protected enum PouchType
	{
		LIFE = 0,
		SMGAMMO = 1,
		GRENADE = 2,
		SNIPERAMMO = 3,
		SHOTGUNAMMO = 4,
		PISTOLAMMO = 5,
		ASSAULTRIFLEAMMO = 6
	}

	protected static int s_weaponSlotCount = 4;

	protected static int s_materialQuantityPerSlot = 99;

	protected PropertyFlags m_flags;

	protected bool m_isAmmoDirty;

	protected bool m_isItemsDirty;

	protected InventorySlot m_shieldSlot = new InventorySlot();

	protected InventorySlot m_classModeSlot = new InventorySlot();

	protected InventorySlot[] m_weaponSlots;

	protected ItemDNA[] m_itemSlots;

	protected byte m_activeWeaponSlot;

	protected short m_lastShieldPointReceived;

	protected int m_itemSlotCount = 60;

	protected Inventory m_inventory;

	public int cebe82f93c2f4e4f15daeb43e5bf5521b
	{
		get
		{
			return s_weaponSlotCount;
		}
		private set
		{
			s_weaponSlotCount = value;
		}
	}

	public ItemDNA[] c8650edf44cd5a93f3ea208aaf977f953()
	{
		return m_itemSlots;
	}

	public override int ca2ff7a501878363cb1d5f0472e306620()
	{
		return m_pouchList[0].c4c4b463091d2b6acfdded4fa12b32f25();
	}

	public override int ccfad1bf47b003333c5ddd084f14d33e7()
	{
		return m_pouchList[0].c17a506784adea8f822bee98ad9dba710();
	}

	public override int cdee885326dc3732f50e8ea26f8cbfb73()
	{
		return m_pouchList[0].c3326a47fbaf3911cb03db331d9fcd9bf();
	}

	public override int c19b70ea6e4db0802bb7cae385cc85109(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		int num = 0;
		switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
		{
		case AmmoType.SMG:
			return m_pouchList[1].c4c4b463091d2b6acfdded4fa12b32f25();
		case AmmoType.SniperRifle:
			return m_pouchList[3].c4c4b463091d2b6acfdded4fa12b32f25();
		case AmmoType.ShotGun:
			return m_pouchList[4].c4c4b463091d2b6acfdded4fa12b32f25();
		case AmmoType.Pistol:
			return m_pouchList[5].c4c4b463091d2b6acfdded4fa12b32f25();
		case AmmoType.AssaultRifle:
			return m_pouchList[6].c4c4b463091d2b6acfdded4fa12b32f25();
		case AmmoType.Grenade:
			return cc0b9d3080e1a0c182204b250d657b977();
		default:
			return 0;
		}
	}

	public override int c5c30fc221fd2805f9535a08995b34b98(WeaponType c21171aa66b09d27be1f523137627333d)
	{
		int num = 0;
		switch (c21171aa66b09d27be1f523137627333d)
		{
		case WeaponType.SMG:
			return m_pouchList[1].c4c4b463091d2b6acfdded4fa12b32f25();
		case WeaponType.SniperRifle:
			return m_pouchList[3].c4c4b463091d2b6acfdded4fa12b32f25();
		case WeaponType.ShotGun:
			return m_pouchList[4].c4c4b463091d2b6acfdded4fa12b32f25();
		case WeaponType.RepeaterPistol:
			return m_pouchList[5].c4c4b463091d2b6acfdded4fa12b32f25();
		case WeaponType.CombatRifle:
			return m_pouchList[6].c4c4b463091d2b6acfdded4fa12b32f25();
		default:
			return 0;
		}
	}

	public override int c8a605fa1a9c2a71cfb141d9433f2f958(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		int num = 0;
		switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
		{
		case AmmoType.SMG:
			return m_pouchList[1].c17a506784adea8f822bee98ad9dba710();
		case AmmoType.SniperRifle:
			return m_pouchList[3].c17a506784adea8f822bee98ad9dba710();
		case AmmoType.ShotGun:
			return m_pouchList[4].c17a506784adea8f822bee98ad9dba710();
		case AmmoType.Pistol:
			return m_pouchList[5].c17a506784adea8f822bee98ad9dba710();
		case AmmoType.AssaultRifle:
			return m_pouchList[6].c17a506784adea8f822bee98ad9dba710();
		case AmmoType.Grenade:
			return c4864359b53f3eb339247aab4edeb1fe5();
		default:
			return 0;
		}
	}

	public override int c899909cfce72c3526b0e233b21dcf395(WeaponType c4377262dd7fb8935a8214f6610cfb066)
	{
		int num = 0;
		switch (c4377262dd7fb8935a8214f6610cfb066)
		{
		case WeaponType.SMG:
			return m_pouchList[1].c17a506784adea8f822bee98ad9dba710();
		case WeaponType.SniperRifle:
			return m_pouchList[3].c17a506784adea8f822bee98ad9dba710();
		case WeaponType.ShotGun:
			return m_pouchList[4].c17a506784adea8f822bee98ad9dba710();
		case WeaponType.RepeaterPistol:
			return m_pouchList[5].c17a506784adea8f822bee98ad9dba710();
		case WeaponType.CombatRifle:
			return m_pouchList[6].c17a506784adea8f822bee98ad9dba710();
		default:
			return 0;
		}
	}

	public override int c78d9aede4c30f70263e7312e02202ac1(WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
		int num = 0;
		switch (c2b4f43f34e21572af6ab4414f04cee36)
		{
		case WeaponType.SMG:
			return m_pouchList[1].c3326a47fbaf3911cb03db331d9fcd9bf();
		case WeaponType.SniperRifle:
			return m_pouchList[3].c3326a47fbaf3911cb03db331d9fcd9bf();
		case WeaponType.ShotGun:
			return m_pouchList[4].c3326a47fbaf3911cb03db331d9fcd9bf();
		case WeaponType.RepeaterPistol:
			return m_pouchList[5].c3326a47fbaf3911cb03db331d9fcd9bf();
		case WeaponType.CombatRifle:
			return m_pouchList[6].c3326a47fbaf3911cb03db331d9fcd9bf();
		default:
			return 0;
		}
	}

	public override int cc0b9d3080e1a0c182204b250d657b977()
	{
		return m_pouchList[2].c4c4b463091d2b6acfdded4fa12b32f25();
	}

	public override int c4864359b53f3eb339247aab4edeb1fe5()
	{
		return m_pouchList[2].c17a506784adea8f822bee98ad9dba710();
	}

	public override PropertyFlags c8636e472c72127553c97e9fcab49f723()
	{
		return m_flags;
	}

	public int ca77a0dd5dbf0daa686053361865cb06a()
	{
		return m_itemSlotCount;
	}

	public int caa75b946a7aa0d2b3a6d5c5b2b94f0a3()
	{
		int num = 0;
		for (int i = 0; i < m_itemSlots.Length; i++)
		{
			if (m_itemSlots[i] == null)
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num++;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return num;
		}
	}

	public override int ce7804365a7377021025c46a16aa79db4()
	{
		if (cb4633378bdf6d47c409332e395d58c7a() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25();
				}
			}
		}
		return 0;
	}

	public override int ca937003ba4cbf4130cad1fcc9da2873e()
	{
		if (cb4633378bdf6d47c409332e395d58c7a() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.c17a506784adea8f822bee98ad9dba710();
				}
			}
		}
		return 0;
	}

	public virtual ItemDNA c66e5209456d049749c2f674f493b9d33()
	{
		if (m_shieldSlot != null)
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
					return m_shieldSlot.c729ce3b5f48e0eac3a7ead97b1d02f8d();
				}
			}
		}
		return null;
	}

	public ItemDNA c187f6ec8d6b0a87c0b17a98906a6b50b()
	{
		if (m_classModeSlot != null)
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
					return m_classModeSlot.c729ce3b5f48e0eac3a7ead97b1d02f8d();
				}
			}
		}
		return null;
	}

	public ItemDNA c318f39e20985f3629512f08ea6e8ab64()
	{
		if (m_activeWeaponSlot < m_weaponSlots.Length)
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
			if (m_weaponSlots[m_activeWeaponSlot] != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return m_weaponSlots[m_activeWeaponSlot].c729ce3b5f48e0eac3a7ead97b1d02f8d();
					}
				}
			}
		}
		return null;
	}

	public void cd24bf490e2857ac6b6de17acf68794dd()
	{
		m_isAmmoDirty = true;
		m_isItemsDirty = true;
	}

	public override void c830fb918b7a26abced3d1b85d11d53a0(PropertyFlags c1241d2df0b8d540930a28f541f89b2c5)
	{
		m_flags = c1241d2df0b8d540930a28f541f89b2c5;
	}

	public override EntityShield cb4633378bdf6d47c409332e395d58c7a()
	{
		return m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityShield;
	}

	public override EntityWeapon cdda217ef6662acf86a5584ba19758192()
	{
		return m_weaponSlots[m_activeWeaponSlot].c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
	}

	public override EntityWeapon c4e0dae6a16a8a80ddb5214a896b9df58(byte ccdfba09818795b7154978e955acab94a)
	{
		return m_weaponSlots[ccdfba09818795b7154978e955acab94a].c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
	}

	public bool c84d244047fda2195337385d49dfc973c(byte ccdfba09818795b7154978e955acab94a)
	{
		return m_weaponSlots[ccdfba09818795b7154978e955acab94a].cc6aaf385211ddff355edfb4576dcd1d1();
	}

	public EntityClassMode c082f20f357e6d0dc7ac2d2e1a6edc8d1()
	{
		return m_classModeSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityClassMode;
	}

	public void c723059b5a3c55c81c99bcd595332cb52(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c4ed717bfa8e3dbe7b0f04513d76a651e;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_ShowInventoryFull", m_entity.cd95354b53e674ec7dc9594e66e4d316f().ccbf0424f81fe9104b29857c1137a5d96(), array);
	}

	public void c37bebbe7208b73fe3f43364ddc597284()
	{
		for (int i = 0; i < 6; i++)
		{
			if (i == 2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(c06ca0e618478c23eba3419653a19760f<LootingManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c21ad47204b5c92fdbb3d4d6a2babb082(c19b70ea6e4db0802bb7cae385cc85109((AmmoType)i) + c06ca0e618478c23eba3419653a19760f<LootingManager>.c5ee19dc8d4cccf5ae2de225410458b86.cae816a5b35dd33a6b1dfb5d0f344978e(ItemType.Ammo, (AmmoType)i), (AmmoType)i);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_UseAmmoPack", m_entity.cd95354b53e674ec7dc9594e66e4d316f().ccbf0424f81fe9104b29857c1137a5d96(), c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
			return;
		}
	}

	[RPC]
	public void RPC_ShowInventoryFull(ItemDNA itemDNA)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(itemDNA);
	}

	[RPC]
	public void RPC_UseAmmoPack()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "RPC_UseAmmoPack");
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CurrencyUpdateView>().c4c93611d50d24eb4ab3a3549d4422105();
	}

	public override void c21ad47204b5c92fdbb3d4d6a2babb082(int cfd8fa226b0f9739fe464bf6cf939f561, AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		int num = c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
		switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
		{
		case AmmoType.SMG:
			m_pouchList[1].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
			break;
		case AmmoType.SniperRifle:
			m_pouchList[3].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
			break;
		case AmmoType.ShotGun:
			m_pouchList[4].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
			break;
		case AmmoType.Pistol:
			m_pouchList[5].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
			break;
		case AmmoType.AssaultRifle:
			m_pouchList[6].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c19b70ea6e4db0802bb7cae385cc85109(c1e73ae4c18ab95639cb0c7604f21dc2b);
			break;
		case AmmoType.Grenade:
			ce997541d3ac9e95ddee7d477001213a0(cfd8fa226b0f9739fe464bf6cf939f561);
			break;
		default:
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "Wrong ammo type setup!!!Please log a bug");
			break;
		}
	}

	public override void ce653df38cbca26f91f2e8654ccc7b048(int cfd8fa226b0f9739fe464bf6cf939f561, WeaponType c21171aa66b09d27be1f523137627333d)
	{
		int num = c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
		switch (c21171aa66b09d27be1f523137627333d)
		{
		case WeaponType.SMG:
			m_pouchList[1].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
			break;
		case WeaponType.SniperRifle:
			m_pouchList[3].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
			break;
		case WeaponType.ShotGun:
			m_pouchList[4].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
			break;
		case WeaponType.RepeaterPistol:
			m_pouchList[5].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
			break;
		case WeaponType.CombatRifle:
			m_pouchList[6].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c5c30fc221fd2805f9535a08995b34b98(c21171aa66b09d27be1f523137627333d);
			break;
		default:
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "Wrong ammo type setup!!!Please log a bug");
			break;
		}
	}

	public override void c2d2d33b57e3f95d0673fb35826ea2dc8(int cfd8fa226b0f9739fe464bf6cf939f561, WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
		int num = c899909cfce72c3526b0e233b21dcf395(c2b4f43f34e21572af6ab4414f04cee36);
		switch (c2b4f43f34e21572af6ab4414f04cee36)
		{
		case WeaponType.SMG:
			m_pouchList[1].c82133ff2bb787510ed8585dd3d834b59(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c899909cfce72c3526b0e233b21dcf395(c2b4f43f34e21572af6ab4414f04cee36);
			break;
		case WeaponType.SniperRifle:
			m_pouchList[3].c82133ff2bb787510ed8585dd3d834b59(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c899909cfce72c3526b0e233b21dcf395(c2b4f43f34e21572af6ab4414f04cee36);
			break;
		case WeaponType.ShotGun:
			m_pouchList[4].c82133ff2bb787510ed8585dd3d834b59(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c899909cfce72c3526b0e233b21dcf395(c2b4f43f34e21572af6ab4414f04cee36);
			break;
		case WeaponType.RepeaterPistol:
			m_pouchList[5].c82133ff2bb787510ed8585dd3d834b59(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c899909cfce72c3526b0e233b21dcf395(c2b4f43f34e21572af6ab4414f04cee36);
			break;
		case WeaponType.CombatRifle:
			m_pouchList[6].c82133ff2bb787510ed8585dd3d834b59(cfd8fa226b0f9739fe464bf6cf939f561);
			m_isAmmoDirty |= num != c899909cfce72c3526b0e233b21dcf395(c2b4f43f34e21572af6ab4414f04cee36);
			break;
		default:
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "Wrong ammo type setup!!!Please log a bug");
			break;
		}
	}

	public override void ce997541d3ac9e95ddee7d477001213a0(int cfd8fa226b0f9739fe464bf6cf939f561)
	{
		int num = cc0b9d3080e1a0c182204b250d657b977();
		m_pouchList[2].ca0f7f52805a9c67a892c5b479a17c3aa(cfd8fa226b0f9739fe464bf6cf939f561);
		m_isAmmoDirty |= num != cc0b9d3080e1a0c182204b250d657b977();
	}

	public override int c43a75ebc3bb03dc214576d3b5b1a1301()
	{
		return m_pouchList[2].c3326a47fbaf3911cb03db331d9fcd9bf();
	}

	public override void ccd54745b619f8623af9ba6da7437e69b(int c8f5cba5f8c95383267d9edfe6df38c46)
	{
		int num = c4864359b53f3eb339247aab4edeb1fe5();
		if (c8f5cba5f8c95383267d9edfe6df38c46 < cc0b9d3080e1a0c182204b250d657b977())
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
			ce997541d3ac9e95ddee7d477001213a0(c8f5cba5f8c95383267d9edfe6df38c46);
		}
		m_pouchList[2].c82133ff2bb787510ed8585dd3d834b59(c8f5cba5f8c95383267d9edfe6df38c46);
		m_isAmmoDirty |= num != c4864359b53f3eb339247aab4edeb1fe5();
	}

	public override void c9af7b3e5f6626ceef1a0036138121839(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].c82133ff2bb787510ed8585dd3d834b59(c19e024b5bcbd347892bec27154c527de);
	}

	public override void cf0a63fdc9831dd55ae40ac6a5f5eb7e0(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
	}

	public override void c34fa9ca078c2cc90fb0cae8284ed10d7(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].cc934e25bb0ce6d2db75ef537501c8237(c19e024b5bcbd347892bec27154c527de);
	}

	public override void c521b7affa3889eae158dbd009bbe95cb(int c8bb9a8fe3e1b66a449326ff976fa842a)
	{
		EntityShield entityShield = cb4633378bdf6d47c409332e395d58c7a();
		if (entityShield == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		entityShield.m_shieldPoints.ca0f7f52805a9c67a892c5b479a17c3aa(c8bb9a8fe3e1b66a449326ff976fa842a);
	}

	public override void c405b3c9891c62259c5917e975ecd6145(int c7bbd39dd7ee73bf0c91ece5753f491d3)
	{
		EntityShield entityShield = cb4633378bdf6d47c409332e395d58c7a();
		if (entityShield == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		entityShield.m_shieldPoints.c82133ff2bb787510ed8585dd3d834b59(c7bbd39dd7ee73bf0c91ece5753f491d3);
	}

	public ItemDNA c48db535623c3c5d4028ae3a36cb12dc6(int ccdfba09818795b7154978e955acab94a)
	{
		return m_itemSlots[ccdfba09818795b7154978e955acab94a];
	}

	private void Awake()
	{
		m_weaponSlots = c8155569e60f1f14c4c9c02e52b3b34cd.c0a0cdf4a196914163f7334d9b0781a04(s_weaponSlotCount);
		for (int i = 0; i < s_weaponSlotCount; i++)
		{
			m_weaponSlots[i] = new InventorySlot();
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
			m_itemSlots = cd7e95b9c3ab3ea52b4fc74831d35ced6.c0a0cdf4a196914163f7334d9b0781a04(m_itemSlotCount);
			m_pouchList.Clear();
			m_pouchList.Add(new Utils.PouchNetwork());
			m_pouchList.Add(new Utils.PouchNetwork());
			m_pouchList.Add(new Utils.PouchNetwork());
			m_pouchList.Add(new Utils.PouchNetwork());
			m_pouchList.Add(new Utils.PouchNetwork());
			m_pouchList.Add(new Utils.PouchNetwork());
			m_pouchList.Add(new Utils.PouchNetwork());
			return;
		}
	}

	public override void Start()
	{
		base.Start();
		m_entity = GetComponent<EntityPlayer>();
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c();
	}

	protected virtual void Update()
	{
		if (base.photonView.c6971afb2ced2e6c56d327fce1c3bca83)
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
			if (m_isAmmoDirty)
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
				c4263f5a1f23942355ba085c61330d116();
			}
		}
		if (!base.photonView.c6971afb2ced2e6c56d327fce1c3bca83)
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
			if (!m_isItemsDirty)
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
				c68a9ef82f51a0bbae05e8476bf2ab94f();
				return;
			}
		}
	}

	public virtual bool c3ac9dbf338103e5bc87b5c2d6acf117a(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		if (ca57e1c076c01141c5ce58c7341db7833 == null)
		{
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
				sbyte b = c6737b45737eb7c4d304d55fe1d7826fa();
				if (b < 0)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
				return false;
			}
		}
		if (ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Material))
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
			sbyte b2 = c0436fc1c55e077d6311da29276c013f4(ca57e1c076c01141c5ce58c7341db7833.m_materialType, ca57e1c076c01141c5ce58c7341db7833.m_value);
			if (b2 < 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		else
		{
			if (!ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
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
				if (!ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield))
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
					if (!ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
					{
						goto IL_00cc;
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
			sbyte b3 = c6737b45737eb7c4d304d55fe1d7826fa();
			if (b3 < 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		goto IL_00cc;
		IL_00cc:
		return false;
	}

	protected sbyte c0436fc1c55e077d6311da29276c013f4(MaterialType c2b4f43f34e21572af6ab4414f04cee36, int c71bf89d19a5e197aade34b29b90c8497)
	{
		for (sbyte b = 0; b < m_itemSlots.Length; b++)
		{
			if (m_itemSlots[b] != null)
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
				if (m_itemSlots[b].ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Material))
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
					if (m_itemSlots[b].m_materialType == c2b4f43f34e21572af6ab4414f04cee36)
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
						if (m_itemSlots[b].m_value + c71bf89d19a5e197aade34b29b90c8497 <= s_materialQuantityPerSlot)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
									return b;
								}
							}
						}
					}
				}
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return c6737b45737eb7c4d304d55fe1d7826fa();
		}
	}

	protected sbyte c6737b45737eb7c4d304d55fe1d7826fa()
	{
		for (sbyte b = 0; b < m_itemSlots.Length; b++)
		{
			if (m_itemSlots[b] == null)
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
						return b;
					}
				}
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return -1;
		}
	}

	public ItemDNA c20ad6bcf5b5ce2ad75ae35905409f5fa(byte ccdfba09818795b7154978e955acab94a)
	{
		return m_weaponSlots[ccdfba09818795b7154978e955acab94a].c729ce3b5f48e0eac3a7ead97b1d02f8d();
	}

	public virtual void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
			m_isItemsDirty = true;
			ItemDNA itemDNA = m_itemSlots[c42a8a9b0dd4206315a44f945fbf7331f];
			m_itemSlots[c42a8a9b0dd4206315a44f945fbf7331f] = m_itemSlots[c5242449e40eab9ce5011e2bacd82070c];
			m_itemSlots[c5242449e40eab9ce5011e2bacd82070c] = itemDNA;
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	public virtual void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_isItemsDirty = true;
			InventorySlot inventorySlot = m_weaponSlots[c42a8a9b0dd4206315a44f945fbf7331f];
			m_weaponSlots[c42a8a9b0dd4206315a44f945fbf7331f] = m_weaponSlots[c5242449e40eab9ce5011e2bacd82070c];
			m_weaponSlots[c5242449e40eab9ce5011e2bacd82070c] = inventorySlot;
			if (m_activeWeaponSlot == c42a8a9b0dd4206315a44f945fbf7331f)
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
				cb71c24b68b65fe176d7936520d63a102(c5242449e40eab9ce5011e2bacd82070c);
			}
			else if (m_activeWeaponSlot == c5242449e40eab9ce5011e2bacd82070c)
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
				cb71c24b68b65fe176d7936520d63a102(c42a8a9b0dd4206315a44f945fbf7331f);
			}
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	public virtual void cabac189d699c8d8d56d0e1a68cd1440b(byte c71953cab9dff52e14146804e2928df92, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
			EntityPlayer entityPlayer = m_entity as EntityPlayer;
			if (m_itemSlots[c71953cab9dff52e14146804e2928df92] == null)
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
				if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (!m_itemSlots[c71953cab9dff52e14146804e2928df92].ce30d65b28e5e27287812b940c39aacf7(entityPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943()))
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
					m_isItemsDirty = true;
					EntityWeapon entityWeapon = m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
					m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c7cd2e714b90259c7cbaa0bd226fe8435(0, m_itemSlots[c71953cab9dff52e14146804e2928df92]);
					if (m_itemSlots[c71953cab9dff52e14146804e2928df92] != null)
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
						if (m_itemSlots[c71953cab9dff52e14146804e2928df92].ca79da172938fdc8c067fb64242b6174a() != null)
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
							if (m_itemSlots[c71953cab9dff52e14146804e2928df92].ca79da172938fdc8c067fb64242b6174a().m_attribute != null)
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
								c21ad47204b5c92fdbb3d4d6a2babb082(c19b70ea6e4db0802bb7cae385cc85109(m_itemSlots[c71953cab9dff52e14146804e2928df92].m_ammoType) - (m_entity as EntityPlayer).c1facd4b8473c97b11386825128ea5617(IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_itemSlots[c71953cab9dff52e14146804e2928df92].ca79da172938fdc8c067fb64242b6174a().m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ClipSize) as IntAttributeValue)), m_itemSlots[c71953cab9dff52e14146804e2928df92].m_ammoType);
							}
						}
					}
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
						m_itemSlots[c71953cab9dff52e14146804e2928df92] = ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d());
						c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityWeapon);
					}
					else
					{
						m_itemSlots[c71953cab9dff52e14146804e2928df92] = null;
					}
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
					cb71c24b68b65fe176d7936520d63a102(c19a39247ea86ffe5f0de9d429ca0ca95);
					return;
				}
			}
		}
	}

	public virtual void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
			if (c91233b4b8268e8e24a4daa8c053e41ec() == c19a39247ea86ffe5f0de9d429ca0ca95)
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
			sbyte b = c6737b45737eb7c4d304d55fe1d7826fa();
			if (b == -1)
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
			m_isItemsDirty = true;
			EntityWeapon entityWeapon = m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
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
				m_itemSlots[b] = ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d());
				ce653df38cbca26f91f2e8654ccc7b048(c5c30fc221fd2805f9535a08995b34b98(entityWeapon.c83e548e5608cd7f222098a6966b16545()) + entityWeapon.m_ammoCount, entityWeapon.c83e548e5608cd7f222098a6966b16545());
				c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityWeapon);
			}
			m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].cac7688b05e921e2be3f92479ba44b4a8();
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	public virtual void c78742691326e1e69f66c386d907da903(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		EntityShield entityShield = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe93941b14e28baa59c497f98102ccd5(Vector3.zero, Quaternion.identity, true);
		entityShield.c68cd0a841e044876d964965d7ec944bd(c4ed717bfa8e3dbe7b0f04513d76a651e.c8e074b9d0135ff808166cc324407f74c(), m_entity);
		entityShield.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
	}

	public void ca5a254e6d90166c359b3c7fb49b8babe(Vector3 ca1d882dff681e89a9ecd742b34db6dcc)
	{
		EntityShield entityShield = m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityShield;
		if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityShield);
		}
		Vector3 position = m_entity.transform.position;
		position.y += 1f;
		Vector3 normalized = (ca1d882dff681e89a9ecd742b34db6dcc - m_entity.transform.position).normalized;
		c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.cbf43efce245fabdfb9d3009487ba8085(c66e5209456d049749c2f674f493b9d33(), position, m_entity.transform.rotation, normalized);
	}

	public virtual void c61f40925cf99c31aa9ac5df098110ada(byte c793014f9fd028450a4a9908376309f26)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			EntityPlayer entityPlayer = m_entity as EntityPlayer;
			if (m_itemSlots[c793014f9fd028450a4a9908376309f26] == null)
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
				if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (!m_itemSlots[c793014f9fd028450a4a9908376309f26].ce30d65b28e5e27287812b940c39aacf7(entityPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943()))
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
					if (m_itemSlots[c793014f9fd028450a4a9908376309f26] == null)
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
						if (!m_itemSlots[c793014f9fd028450a4a9908376309f26].ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield))
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
							EntityShield entityShield = m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityShield;
							m_isItemsDirty = true;
							if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								if (entityShield.c729ce3b5f48e0eac3a7ead97b1d02f8d() != null)
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
									m_itemSlots[c793014f9fd028450a4a9908376309f26] = ItemDNA.c8f331a9c3beba42f2ccd0923c0c67e0a(entityShield.c729ce3b5f48e0eac3a7ead97b1d02f8d());
								}
								c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityShield);
							}
							else
							{
								m_itemSlots[c793014f9fd028450a4a9908376309f26] = null;
							}
							c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
							return;
						}
					}
				}
			}
		}
	}

	[RPC]
	public void RPC_ApplyShieldSetup(int maxShieldPoints, float RegenerationCooldown, float regenerationRate, int shieldToEquipId, ItemDNA itemDNA)
	{
		StartCoroutine(cb542692f489c59d11d81a79a8e0b2a09(maxShieldPoints, RegenerationCooldown, regenerationRate, shieldToEquipId, itemDNA));
	}

	private IEnumerator cb542692f489c59d11d81a79a8e0b2a09(int cbebb73dc55d1604d5309b1a20581fac1, float c20ba8f893fa1c8a014aca2e8d23bb5e6, float c1ef2a93353c91ac719d48ba48765f178, int c5ad73cfd88c133c8bab67ddd5232c187, ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		EntityShield shieldToEquip2 = cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
		BadAssNetworkView networkView2 = c758bff8e6f547440d0cfe42214b0c3e3.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			networkView2 = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(c5ad73cfd88c133c8bab67ddd5232c187);
			yield return 0;
		}
		while (networkView2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			shieldToEquip2 = networkView2.GetComponent<EntityShield>();
			shieldToEquip2.m_maxShieldPoints = cbebb73dc55d1604d5309b1a20581fac1;
			shieldToEquip2.m_regenerationCooldown = c20ba8f893fa1c8a014aca2e8d23bb5e6;
			shieldToEquip2.m_regenerationRate = c1ef2a93353c91ac719d48ba48765f178;
			shieldToEquip2.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
			m_shieldSlot.c7cd2e714b90259c7cbaa0bd226fe8435(c5ad73cfd88c133c8bab67ddd5232c187, c4ed717bfa8e3dbe7b0f04513d76a651e);
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
			yield break;
		}
	}

	[RPC]
	public void RPC_ApplyClassModeSetup(int classModeToEquipId, ItemDNA itemDNA)
	{
		StartCoroutine(ca96268497b323d7b8188889075a39659(classModeToEquipId, itemDNA));
	}

	private IEnumerator ca96268497b323d7b8188889075a39659(int c7dd3e519477e7890101f6e3a19aa0924, ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		EntityClassMode classModeToEquip2 = c14f6092e7187fb942b7b3a67f869f237.c7088de59e49f7108f520cf7e0bae167e;
		BadAssNetworkView networkView2 = c758bff8e6f547440d0cfe42214b0c3e3.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			networkView2 = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(c7dd3e519477e7890101f6e3a19aa0924);
			yield return 0;
		}
		while (networkView2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			classModeToEquip2 = networkView2.GetComponent<EntityClassMode>();
			classModeToEquip2.c959567c3d0deab4dacbe2081900e09fd(m_entity);
			classModeToEquip2.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
			m_classModeSlot.c7cd2e714b90259c7cbaa0bd226fe8435(classModeToEquip2, c4ed717bfa8e3dbe7b0f04513d76a651e);
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
			yield break;
		}
	}

	public virtual void c474a2d0a31529b847725f85f5ab221a7(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		EntityClassMode entityClassMode = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad906dd3da954596cb70c5723a6afa82(c4ed717bfa8e3dbe7b0f04513d76a651e, Vector3.zero, Quaternion.identity, true);
		entityClassMode.c68cd0a841e044876d964965d7ec944bd(c4ed717bfa8e3dbe7b0f04513d76a651e.c253c28f3a59bc5e5a528dfbb463a8a45());
		entityClassMode.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
	}

	public virtual void c2bf177eafbfeb7beaa0bfd04facb2029(byte c793014f9fd028450a4a9908376309f26)
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
					return;
				}
			}
		}
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (m_itemSlots[c793014f9fd028450a4a9908376309f26] == null)
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
				if (!m_itemSlots[c793014f9fd028450a4a9908376309f26].ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
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
					ClassModeDNA classModeDNA = m_itemSlots[c793014f9fd028450a4a9908376309f26].c253c28f3a59bc5e5a528dfbb463a8a45();
					EntityPlayer entityPlayer = m_entity as EntityPlayer;
					if (classModeDNA == null)
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
						if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (classModeDNA.c95c0ac986e3767a549cf71c2cf28b34f(classModeDNA.m_cmType) != entityPlayer.cb21345185f43f30c1edeaf8faafb0f2c())
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
								if (!m_itemSlots[c793014f9fd028450a4a9908376309f26].ce30d65b28e5e27287812b940c39aacf7(entityPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943()))
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
								EntityClassMode entityClassMode = m_classModeSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityClassMode;
								m_isItemsDirty = true;
								if (entityClassMode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									if (entityClassMode.c729ce3b5f48e0eac3a7ead97b1d02f8d() != null)
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
										m_itemSlots[c793014f9fd028450a4a9908376309f26] = ItemDNA.c7a1e006dac3107ddc09019d735839e9a(entityClassMode.c729ce3b5f48e0eac3a7ead97b1d02f8d());
									}
									c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityClassMode);
								}
								else
								{
									m_itemSlots[c793014f9fd028450a4a9908376309f26] = null;
								}
								c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
								return;
							}
						}
					}
				}
			}
		}
	}

	public virtual void cccb56495987b6a4ebab7b225fb1af261(byte c793014f9fd028450a4a9908376309f26)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
			m_isItemsDirty = true;
			ItemDNA itemDNA = m_itemSlots[c793014f9fd028450a4a9908376309f26];
			if (itemDNA != null)
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
				m_itemSlots[c793014f9fd028450a4a9908376309f26] = null;
			}
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	public virtual void cb71c24b68b65fe176d7936520d63a102(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (c19a39247ea86ffe5f0de9d429ca0ca95 == m_activeWeaponSlot)
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
			m_activeWeaponSlot = c19a39247ea86ffe5f0de9d429ca0ca95;
			if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
			if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon);
					return;
				}
			}
		}
	}

	public virtual byte c91233b4b8268e8e24a4daa8c053e41ec()
	{
		return m_activeWeaponSlot;
	}

	public byte c5c09844fd0f91323d4862a0049207950()
	{
		byte b = m_activeWeaponSlot;
		int num = 0;
		while (true)
		{
			if (num < s_weaponSlotCount)
			{
				b++;
				if (b >= s_weaponSlotCount)
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
					b = 0;
				}
				if (c84d244047fda2195337385d49dfc973c(b))
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
					break;
				}
				num++;
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
			break;
		}
		return b;
	}

	public void OnPhotonEvaluate(PhotonPlayer player, ref PhotonPriority priority)
	{
		if (player == null)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (playerInfoSync.m_id != player.c29a834d12d3895f5680e69a30e6cd9a3)
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
			priority.priority = -2000;
			return;
		}
	}

	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		c06ade3733c4658b091be622d9d3b4034();
		InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.None;
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
			stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)m_flags);
			int num = 0;
			ItemDNA cebae66039aadeac8deb1211786332a = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
			if (m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num = m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689().cc7403315505256d19a7b92aa614a8f10();
				cebae66039aadeac8deb1211786332a = m_shieldSlot.c729ce3b5f48e0eac3a7ead97b1d02f8d();
			}
			stream.caf7283cc5cd9725a88a9cdfa630d92f8(num);
			stream.caf7283cc5cd9725a88a9cdfa630d92f8(cebae66039aadeac8deb1211786332a);
			for (int i = 0; i < s_weaponSlotCount; i++)
			{
				num = 0;
				cebae66039aadeac8deb1211786332a = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
				if ((bool)m_weaponSlots[i].c66b232dbebded7c7e9a89c1e8bd84689())
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
					num = m_weaponSlots[i].c66b232dbebded7c7e9a89c1e8bd84689().cc7403315505256d19a7b92aa614a8f10();
					cebae66039aadeac8deb1211786332a = m_weaponSlots[i].c729ce3b5f48e0eac3a7ead97b1d02f8d();
				}
				stream.caf7283cc5cd9725a88a9cdfa630d92f8(num);
				stream.caf7283cc5cd9725a88a9cdfa630d92f8(cebae66039aadeac8deb1211786332a);
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
			stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_activeWeaponSlot);
			goto IL_0315;
		}
		m_flags = (PropertyFlags)(byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		bool flag = false;
		int c35f98ccbfa8c6bf09319c620b21b5dc = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		bool flag2 = false;
		ItemDNA itemDNA = (ItemDNA)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		if (itemDNA != null)
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
			if (m_shieldSlot != null)
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
				flag2 = itemDNA.Equals(m_shieldSlot.c729ce3b5f48e0eac3a7ead97b1d02f8d());
				goto IL_01c9;
			}
		}
		int num2;
		if (itemDNA == null)
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
			num2 = ((m_shieldSlot.c729ce3b5f48e0eac3a7ead97b1d02f8d() == c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
		}
		else
		{
			num2 = 0;
		}
		flag2 = (byte)num2 != 0;
		goto IL_01c9;
		IL_01c9:
		flag = flag || !flag2;
		m_shieldSlot.c7cd2e714b90259c7cbaa0bd226fe8435(c35f98ccbfa8c6bf09319c620b21b5dc, itemDNA);
		int c35f98ccbfa8c6bf09319c620b21b5dc2;
		ItemDNA itemDNA2;
		bool flag3;
		for (int j = 0; j < s_weaponSlotCount; flag = flag || !flag3, m_weaponSlots[j].c7cd2e714b90259c7cbaa0bd226fe8435(c35f98ccbfa8c6bf09319c620b21b5dc2, itemDNA2), j++)
		{
			c35f98ccbfa8c6bf09319c620b21b5dc2 = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			flag3 = false;
			itemDNA2 = (ItemDNA)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			if (itemDNA2 != null)
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
				if (m_weaponSlots[j] != null)
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
					flag3 = itemDNA2.Equals(m_weaponSlots[j].c729ce3b5f48e0eac3a7ead97b1d02f8d());
					continue;
				}
			}
			int num3;
			if (itemDNA2 == null)
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
				num3 = ((m_weaponSlots[j].c729ce3b5f48e0eac3a7ead97b1d02f8d() == c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
			}
			else
			{
				num3 = 0;
			}
			flag3 = (byte)num3 != 0;
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
		byte b = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		bool flag4 = m_activeWeaponSlot != b;
		cb71c24b68b65fe176d7936520d63a102(b);
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
			if (flag4)
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
				inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.FullUpdate;
				goto IL_0315;
			}
		}
		if (flag)
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
			inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.ItemUpdate;
		}
		else if (flag4)
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
			inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon;
		}
		goto IL_0315;
		IL_0315:
		if (!(m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (m_entity.cc9092b59c901ab832a40b51c2cfa71b7())
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
				if (inventoryUpdateType == InventoryServiceWrapper.InventoryUpdateType.None)
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
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(inventoryUpdateType);
					return;
				}
			}
		}
	}

	public override void c06ade3733c4658b091be622d9d3b4034()
	{
		base.c06ade3733c4658b091be622d9d3b4034();
		if (!cb4633378bdf6d47c409332e395d58c7a())
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
			cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.c06ade3733c4658b091be622d9d3b4034();
			return;
		}
	}

	public override void cdfac57bd798072bd71a801c00909ad5c()
	{
		base.c06ade3733c4658b091be622d9d3b4034();
		if (!cb4633378bdf6d47c409332e395d58c7a())
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
			cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.cdfac57bd798072bd71a801c00909ad5c();
			return;
		}
	}

	private void c4263f5a1f23942355ba085c61330d116()
	{
		int num = 0;
		Hashtable hashtable = new Hashtable();
		hashtable[num++] = (short)m_pouchList[1].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = (short)m_pouchList[1].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = (short)m_pouchList[3].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = (short)m_pouchList[3].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = (byte)m_pouchList[2].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = (byte)m_pouchList[2].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = (short)m_pouchList[4].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = (short)m_pouchList[4].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = (short)m_pouchList[5].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = (short)m_pouchList[5].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = (short)m_pouchList[6].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = (short)m_pouchList[6].c4c4b463091d2b6acfdded4fa12b32f25();
		PhotonView obj = base.photonView;
		PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab = m_entity.cd95354b53e674ec7dc9594e66e4d316f().ccbf0424f81fe9104b29857c1137a5d96();
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = hashtable;
		obj.c19fd12ed98be2a9174d53644dc9757c8("RPC_OnReceiveAmmos", c8bb3a6115f009b6d03350a85a41ecab, array);
		m_isAmmoDirty = false;
	}

	private void c68a9ef82f51a0bbae05e8476bf2ab94f()
	{
		int num = 0;
		Hashtable hashtable = new Hashtable();
		hashtable[num++] = m_itemSlotCount;
		for (int i = 0; i < m_itemSlotCount; i++)
		{
			hashtable[num++] = m_itemSlots[i];
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
			PhotonView obj = base.photonView;
			PhotonPlayer c8bb3a6115f009b6d03350a85a41ecab = m_entity.cd95354b53e674ec7dc9594e66e4d316f().ccbf0424f81fe9104b29857c1137a5d96();
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = hashtable;
			obj.c19fd12ed98be2a9174d53644dc9757c8("RPC_OnReceiveItems", c8bb3a6115f009b6d03350a85a41ecab, array);
			m_isItemsDirty = false;
			return;
		}
	}

	[RPC]
	private void RPC_OnReceiveAmmos(Hashtable data)
	{
		int num = 0;
		m_pouchList[1].c82133ff2bb787510ed8585dd3d834b59((short)data[num++]);
		m_pouchList[1].ca0f7f52805a9c67a892c5b479a17c3aa((short)data[num++]);
		m_pouchList[3].c82133ff2bb787510ed8585dd3d834b59((short)data[num++]);
		m_pouchList[3].ca0f7f52805a9c67a892c5b479a17c3aa((short)data[num++]);
		m_pouchList[2].c82133ff2bb787510ed8585dd3d834b59((byte)data[num++]);
		m_pouchList[2].ca0f7f52805a9c67a892c5b479a17c3aa((byte)data[num++]);
		m_pouchList[4].c82133ff2bb787510ed8585dd3d834b59((short)data[num++]);
		m_pouchList[4].ca0f7f52805a9c67a892c5b479a17c3aa((short)data[num++]);
		m_pouchList[5].c82133ff2bb787510ed8585dd3d834b59((short)data[num++]);
		m_pouchList[5].ca0f7f52805a9c67a892c5b479a17c3aa((short)data[num++]);
		m_pouchList[6].c82133ff2bb787510ed8585dd3d834b59((short)data[num++]);
		m_pouchList[6].ca0f7f52805a9c67a892c5b479a17c3aa((short)data[num++]);
	}

	[RPC]
	private void RPC_OnReceiveItems(Hashtable data)
	{
		int num = 0;
		m_itemSlotCount = (int)data[num++];
		ItemDNA[] c7088de59e49f7108f520cf7e0bae167e = c40f95efd648b11a1e5ebceb36b60ccc7.c7088de59e49f7108f520cf7e0bae167e;
		if (m_itemSlotCount != m_itemSlots.Length)
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
			c7088de59e49f7108f520cf7e0bae167e = cd7e95b9c3ab3ea52b4fc74831d35ced6.c0a0cdf4a196914163f7334d9b0781a04(m_itemSlotCount);
		}
		else
		{
			c7088de59e49f7108f520cf7e0bae167e = m_itemSlots;
		}
		bool flag = false;
		bool flag2;
		ItemDNA itemDNA;
		for (int i = 0; i < m_itemSlotCount; flag = flag || !flag2, c7088de59e49f7108f520cf7e0bae167e[i] = itemDNA, i++)
		{
			flag2 = false;
			itemDNA = (ItemDNA)data[num++];
			if (i >= m_itemSlots.Length)
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
			if (itemDNA != null)
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
				if (m_itemSlots[i] != null)
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
					flag2 = itemDNA.Equals(m_itemSlots[i]);
					continue;
				}
			}
			int num2;
			if (itemDNA == null)
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
				num2 = ((m_itemSlots[i] == null) ? 1 : 0);
			}
			else
			{
				num2 = 0;
			}
			flag2 = (byte)num2 != 0;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			m_itemSlots = c7088de59e49f7108f520cf7e0bae167e;
			if (!m_entity)
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
				if (!flag)
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
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
					return;
				}
			}
		}
	}

	public virtual EntityShield cfe93941b14e28baa59c497f98102ccd5()
	{
		return cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
	}
}
