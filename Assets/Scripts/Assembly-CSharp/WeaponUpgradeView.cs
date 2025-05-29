using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;

public class WeaponUpgradeView : BaseView
{
	protected int weaponIndex;

	protected GameObject weaponModel;

	protected GameObject weaponContainer;

	protected GameObject defaultParticle;

	protected GameObject successParticle;

	protected GameObject failureParticle;

	protected Dictionary<WeaponType, Transform> weaponPosition;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map7;

	public virtual void c23ffb495db7c9da62404f1cc24a67351()
	{
		if (!(weaponContainer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			cb0b49ac07e81cf1b9dfe2e83191d5ded();
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_bVisible)
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
					c23ffb495db7c9da62404f1cc24a67351();
					return;
				}
			}
		}
		defaultParticle.SetActive(false);
		successParticle.SetActive(false);
		failureParticle.SetActive(false);
		if (weaponModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Object.Destroy(weaponModel);
			weaponModel = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		}
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
	}

	protected virtual void ca0d81305a63da237ff4996557b68322d()
	{
		WeaponDNA weaponDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c48db535623c3c5d4028ae3a36cb12dc6(weaponIndex).ca79da172938fdc8c067fb64242b6174a();
		ConsumedMaterial[] array = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c427b782717fb7214fcc0f2cf5778100a(weaponDNA.c83e548e5608cd7f222098a6966b16545());
		bool flag = true;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(array[num].m_consumedMaterialType) < array[num].m_consumedMaterialNums)
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
					flag = false;
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
		if (flag)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c82735d95d0446f1d90255f3da8685aaa();
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Material")), OnDailogTaped, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
	}

	protected virtual void c003d770a5d51d5333b7aa55f762704c4()
	{
		WeaponDNA weaponDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c48db535623c3c5d4028ae3a36cb12dc6(weaponIndex).ca79da172938fdc8c067fb64242b6174a();
		ItemConsume itemConsume = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.cd1b950d28832dc51f746809d8f189d68(weaponDNA.c83e548e5608cd7f222098a6966b16545(), weaponDNA.m_starLevel);
		if (itemConsume == null)
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
		if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(itemConsume.m_materialType) < itemConsume.m_materialNums)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Material")), OnDailogTaped, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
					return;
				}
			}
		}
		if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c9f30498b55d5d8ebb2b670dc3a42584b() != null)
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
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c9f30498b55d5d8ebb2b670dc3a42584b().BondCurrency >= itemConsume.m_itemNums)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						c043be6790fadf5ce3bd57fadcbd544e7();
						return;
					}
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Currency")), OnDailogTaped, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
	}

	protected virtual void OnDailogTaped()
	{
	}

	protected virtual void c82735d95d0446f1d90255f3da8685aaa()
	{
		cb875222c821f3646dd22d722aafdbebc();
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c1ce781f2f9808d850e290cc8196d4f10(OnExperienceUpdate, weaponIndex);
	}

	protected virtual void c043be6790fadf5ce3bd57fadcbd544e7()
	{
		cb875222c821f3646dd22d722aafdbebc();
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c85f327d439d363ea060637d0fb984bef(OnLevelUpdate, weaponIndex);
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_upgrade");
	}

	public virtual void ca61d5a82dff4dca6763fa249b5241e54()
	{
	}

	public virtual void cb875222c821f3646dd22d722aafdbebc()
	{
	}

	protected virtual void ca7f40a3610b9512926911208d97b0caa()
	{
		successParticle.SetActive(true);
		successParticle.GetComponent<ParticleSystem>().Play();
	}

	protected virtual void ccd3eab4bbc52e554166ae214401869fe()
	{
		failureParticle.SetActive(true);
		failureParticle.GetComponent<ParticleSystem>().Play();
	}

	public virtual void OnLevelUpdate(bool success, ItemDNA newWeapon)
	{
		ca61d5a82dff4dca6763fa249b5241e54();
		if (success)
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
					c660501325b92420b182c10632cb9aa92(newWeapon, false, false);
					ca7f40a3610b9512926911208d97b0caa();
					return;
				}
			}
		}
		c660501325b92420b182c10632cb9aa92(newWeapon, false);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Failed")), OnDailogTaped, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
		ccd3eab4bbc52e554166ae214401869fe();
	}

	public virtual void OnExperienceUpdate(ItemDNA newWeapon)
	{
		ca61d5a82dff4dca6763fa249b5241e54();
		if (newWeapon != null)
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
					c660501325b92420b182c10632cb9aa92(newWeapon, false);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cea4468dc2438c0952d375da1a5a17607(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Failed")), OnDailogTaped, c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e);
	}

	public virtual void c660501325b92420b182c10632cb9aa92(ItemDNA c000a5a1f484781c00fa6008d1814e675, bool c1cfcfc2b2c10ed433757ae4513e115fe = true, bool c01de5f7fd10b55819a8738f39620dedf = true)
	{
		if (!c1cfcfc2b2c10ed433757ae4513e115fe)
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
		if (c000a5a1f484781c00fa6008d1814e675 == null)
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
		if (weaponModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Object.Destroy(weaponModel);
		}
		defaultParticle.SetActive(false);
		if (weaponContainer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cb0b49ac07e81cf1b9dfe2e83191d5ded();
		}
		c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc5bc70567710d6a69882bdd6416a1db9(c000a5a1f484781c00fa6008d1814e675.ca79da172938fdc8c067fb64242b6174a(), c55f17871c3376b87483caf11ac9597a8);
	}

	public void c55f17871c3376b87483caf11ac9597a8(ref GameObject cd1505a8bc35681ef0fed8cd958a8b539, WeaponDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		if (weaponContainer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cd1505a8bc35681ef0fed8cd958a8b539.transform.parent = weaponContainer.transform;
			cd1505a8bc35681ef0fed8cd958a8b539.transform.localRotation = weaponPosition[caedbc1db6c28d44eab6021e7d674eab3.m_type].localRotation;
			cd1505a8bc35681ef0fed8cd958a8b539.transform.localPosition = weaponPosition[caedbc1db6c28d44eab6021e7d674eab3.m_type].localPosition;
			cd1505a8bc35681ef0fed8cd958a8b539.transform.localScale = weaponPosition[caedbc1db6c28d44eab6021e7d674eab3.m_type].localScale;
			weaponModel = cd1505a8bc35681ef0fed8cd958a8b539;
		}
		defaultParticle.SetActive(true);
		defaultParticle.GetComponent<ParticleSystem>().Play();
	}

	private void cb0b49ac07e81cf1b9dfe2e83191d5ded()
	{
		weaponPosition = new Dictionary<WeaponType, Transform>();
		weaponContainer = GameObject.Find("PRO_WeaponUpgrade");
		if (!(weaponContainer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Transform[] componentsInChildren = weaponContainer.GetComponentsInChildren<Transform>(true);
			if (componentsInChildren == null)
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
				Transform[] array = componentsInChildren;
				foreach (Transform transform in array)
				{
					string name = transform.name;
					if (name == null)
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
					if (_003C_003Ef__switch_0024map7 == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(7);
						dictionary.Add("WPN_COR_ground", 0);
						dictionary.Add("WPN_SHN_ground", 1);
						dictionary.Add("WPN_SMG_ground", 2);
						dictionary.Add("WPN_SNR_ground", 3);
						dictionary.Add("PTL_Weapon_Upgrade_Default", 4);
						dictionary.Add("PTL_Weapon_Upgrade_Failure", 5);
						dictionary.Add("PTL_Weapon_Upgrade_Success", 6);
						_003C_003Ef__switch_0024map7 = dictionary;
					}
					int value;
					if (!_003C_003Ef__switch_0024map7.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						weaponPosition[WeaponType.CombatRifle] = transform;
						break;
					case 1:
						weaponPosition[WeaponType.ShotGun] = transform;
						weaponPosition[WeaponType.RepeaterPistol] = transform;
						break;
					case 2:
						weaponPosition[WeaponType.SMG] = transform;
						break;
					case 3:
						weaponPosition[WeaponType.SniperRifle] = transform;
						break;
					case 4:
						defaultParticle = transform.gameObject;
						break;
					case 5:
						failureParticle = transform.gameObject;
						break;
					case 6:
						successParticle = transform.gameObject;
						break;
					}
				}
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
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
	}
}
