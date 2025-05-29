using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class ItemGeneratorService : MonoBehaviour
{
	private const string m_itemPath = "Entities/Object/Item/";

	private GUIDGenerator m_gUIDGen;

	private Dictionary<ItemInstance, ItemDNA> m_localItemDic;

	private NPCShieldSetup[] m_NPCShields;

	private ShieldDNA[] m_PlayerShields;

	private ClassModeDNA[] m_playerClassMode;

	private void Awake()
	{
		m_gUIDGen = new GUIDGenerator();
		m_localItemDic = new Dictionary<ItemInstance, ItemDNA>();
		ca7dc01d1c39f53c467d1408d6913a44f("Preset_ShieldsForPlayer");
		c04b20cf8921c3c3276bd7f105bc3edf6("Preset_ClassMode");
	}

	public ShieldDNA c47470b98a24a224df3c46acf8f37a19d(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_PlayerShields.Length)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return m_PlayerShields[c5612a459a84ffdb41c885401433cd62d];
					}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid shield ID");
		return null;
	}

	public ShieldDNA cd07bbd862d5849fcdfb1b2299a9185eb(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_PlayerShields.Length; i++)
		{
			if (m_PlayerShields[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_PlayerShields[i];
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid shield ID");
			return null;
		}
	}

	public ShieldDNA c88da764016f721ac6872c0c972350696(ItemManufacturer cbbbeda4b55c267838c8f3ed954cdcea6)
	{
		for (int i = 0; i < m_PlayerShields.Length; i++)
		{
			if (m_PlayerShields[i].m_shieldManufacturer != cbbbeda4b55c267838c8f3ed954cdcea6)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_PlayerShields[i];
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid shield manufacturer");
			return null;
		}
	}

	public ClassModeDNA cb44448661d7529865ae34ac25fd5ad51(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_playerClassMode.Length)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return m_playerClassMode[c5612a459a84ffdb41c885401433cd62d];
					}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid class mode index");
		return null;
	}

	private void ca7dc01d1c39f53c467d1408d6913a44f(string c10e5f25a33521ae563c93d041c1860d7)
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c10e5f25a33521ae563c93d041c1860d7) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Shield");
		m_PlayerShields = caafa5ac76efdc5481b03a87c35a40b09.c0a0cdf4a196914163f7334d9b0781a04(elementsByTagName.Count);
		int num = 0;
		IEnumerator enumerator = elementsByTagName.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				ShieldDNA shieldDNA = new ShieldDNA();
				shieldDNA.m_name = xmlNode.Attributes["name"].Value;
				try
				{
					shieldDNA.m_shieldManufacturer = (ItemManufacturer)(int)Enum.Parse(Type.GetTypeFromHandle(c90c54b49c621bbe0466c0365ee1ff9c9.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["manufacturer"].Value);
				}
				catch (Exception ex)
				{
					shieldDNA.m_shieldManufacturer = ItemManufacturer.Vladof;
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Manufacturer name is not correct in presetshield for player xml. " + ex.Message);
				}
				shieldDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
				shieldDNA.m_rarity = (ItemRarity)(int)Enum.Parse(Type.GetTypeFromHandle(c5977d60e97e6ab15d61b19ea0582ed7c.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["rarity"].Value);
				shieldDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
				shieldDNA.m_bodyIdx = int.Parse(xmlNode.Attributes["Body"].Value);
				shieldDNA.m_batteryIdx = int.Parse(xmlNode.Attributes["Battery"].Value);
				shieldDNA.m_capacitorIdx = int.Parse(xmlNode.Attributes["Capacitor"].Value);
				shieldDNA.m_accessoryIdx = int.Parse(xmlNode.Attributes["Accessory"].Value);
				shieldDNA.m_materialIdx = int.Parse(xmlNode.Attributes["Material"].Value);
				shieldDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
				m_PlayerShields[num++] = shieldDNA;
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
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_029e;
					}
					continue;
					end_IL_029e:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	private void c04b20cf8921c3c3276bd7f105bc3edf6(string c8e93695b6b66d400171d6f4ec6a14ee0)
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8e93695b6b66d400171d6f4ec6a14ee0) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("ClassMode");
		m_playerClassMode = c1bd69ac962bcfefc805153a6cb4503c4.c0a0cdf4a196914163f7334d9b0781a04(elementsByTagName.Count);
		int num = 0;
		IEnumerator enumerator = elementsByTagName.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				ClassModeDNA classModeDNA = new ClassModeDNA();
				classModeDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
				classModeDNA.m_name = xmlNode.Attributes["name"].Value;
				classModeDNA.m_cmType = (ClassModeType)(int)Enum.Parse(Type.GetTypeFromHandle(c615f0479c79bc5e6220dda003b242953.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["CMType"].Value);
				classModeDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
				classModeDNA.m_rarity = (ItemRarity)(int)Enum.Parse(Type.GetTypeFromHandle(c5977d60e97e6ab15d61b19ea0582ed7c.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["rarity"].Value);
				classModeDNA.m_adapterIdx = Convert.ToInt32(xmlNode.Attributes["Adapter"].Value);
				classModeDNA.m_bodyIdx = Convert.ToInt32(xmlNode.Attributes["Body"].Value);
				classModeDNA.m_chassisIdx = Convert.ToInt32(xmlNode.Attributes["Chassis"].Value);
				classModeDNA.m_drumIdx = Convert.ToInt32(xmlNode.Attributes["Drum"].Value);
				classModeDNA.m_materialIdx = Convert.ToInt32(xmlNode.Attributes["Material"].Value);
				classModeDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
				m_playerClassMode[num] = classModeDNA;
				num++;
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
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0275;
					}
					continue;
					end_IL_0275:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public ItemDNA c99cb07293f626db9e57760c01c295c00(WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5 = WeaponRarity.Common)
	{
		WeaponType c27b7430edc94b8f5b543605119ec4a = (WeaponType)UnityEngine.Random.Range(0, 5);
		return ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(GetComponent<WeaponGeneratorService>().c99cb07293f626db9e57760c01c295c00(c27b7430edc94b8f5b543605119ec4a, c335b432937e6c5b61e3fce114d6b6ca5));
	}

	public ItemDNA cb91bcce0d95dc59b0d0daf8432eab50f(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		return ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(GetComponent<WeaponGeneratorService>().c4e0dae6a16a8a80ddb5214a896b9df58(c35f98ccbfa8c6bf09319c620b21b5dc5));
	}

	public ItemDNA c99cb07293f626db9e57760c01c295c00(WeaponType c27b7430edc94b8f5b543605119ec4a72 = WeaponType.TOTAL, WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5 = WeaponRarity.Common)
	{
		if (c27b7430edc94b8f5b543605119ec4a72 == WeaponType.TOTAL)
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
			c27b7430edc94b8f5b543605119ec4a72 = (WeaponType)UnityEngine.Random.Range(0, 5);
		}
		return ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(GetComponent<WeaponGeneratorService>().c99cb07293f626db9e57760c01c295c00(c27b7430edc94b8f5b543605119ec4a72, c335b432937e6c5b61e3fce114d6b6ca5));
	}

	public ItemDNA ce9de61ca808e356bda41671efa5177d6(int c71bf89d19a5e197aade34b29b90c8497)
	{
		if (c71bf89d19a5e197aade34b29b90c8497 == 0)
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
			c71bf89d19a5e197aade34b29b90c8497 = c06ca0e618478c23eba3419653a19760f<LootingManager>.c5ee19dc8d4cccf5ae2de225410458b86.cae816a5b35dd33a6b1dfb5d0f344978e(ItemType.HealthPack);
		}
		return ItemDNA.cc17851d48b488126d6f73578b5780377(c71bf89d19a5e197aade34b29b90c8497);
	}

	public ItemDNA caf71e7d2a15cfbdd927a966d4dbe3ce1(int c71bf89d19a5e197aade34b29b90c8497)
	{
		return ItemDNA.c2360cbbc495138755199b7da0e6f9841(c71bf89d19a5e197aade34b29b90c8497);
	}

	public ItemDNA ca16afa1c7cc5b281687b834e34aee093(int c71bf89d19a5e197aade34b29b90c8497 = 0)
	{
		return c19b70ea6e4db0802bb7cae385cc85109(cc75cebef35a562be1471b0cec5a4538a(), c71bf89d19a5e197aade34b29b90c8497);
	}

	public AmmoType cc75cebef35a562be1471b0cec5a4538a()
	{
		AmmoType ammoType = (AmmoType)UnityEngine.Random.Range(0, 5);
		if (ammoType >= AmmoType.Grenade)
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
			ammoType++;
		}
		return ammoType;
	}

	public ItemDNA c19b70ea6e4db0802bb7cae385cc85109(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b, int c71bf89d19a5e197aade34b29b90c8497 = 0)
	{
		if (c71bf89d19a5e197aade34b29b90c8497 == 0)
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
			c71bf89d19a5e197aade34b29b90c8497 = c06ca0e618478c23eba3419653a19760f<LootingManager>.c5ee19dc8d4cccf5ae2de225410458b86.cae816a5b35dd33a6b1dfb5d0f344978e(ItemType.Ammo, c1e73ae4c18ab95639cb0c7604f21dc2b);
		}
		return ItemDNA.cda992a74324f68bb483f862f7544f742(c71bf89d19a5e197aade34b29b90c8497, c1e73ae4c18ab95639cb0c7604f21dc2b);
	}

	public ItemDNA c15e7064f3f03a5bd01e03d226678015b(int c71bf89d19a5e197aade34b29b90c8497)
	{
		if (c71bf89d19a5e197aade34b29b90c8497 == 0)
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
			c71bf89d19a5e197aade34b29b90c8497 = c06ca0e618478c23eba3419653a19760f<LootingManager>.c5ee19dc8d4cccf5ae2de225410458b86.cae816a5b35dd33a6b1dfb5d0f344978e(ItemType.Money);
		}
		return ItemDNA.cf3cf5ff68c6b242036334f6d3f834e32(c71bf89d19a5e197aade34b29b90c8497);
	}

	public ItemDNA ce7f7d72170e103006bc40aa6b7b2e26d(ItemType c2b4f43f34e21572af6ab4414f04cee36, int c71bf89d19a5e197aade34b29b90c8497)
	{
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.Weapon)
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
					return c99cb07293f626db9e57760c01c295c00((WeaponRarity)UnityEngine.Random.Range(0, 6));
				}
			}
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.Ammo)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return ca16afa1c7cc5b281687b834e34aee093(c71bf89d19a5e197aade34b29b90c8497);
				}
			}
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.HealthPack)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return ce9de61ca808e356bda41671efa5177d6(c71bf89d19a5e197aade34b29b90c8497);
				}
			}
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.AmmoPack)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return caf71e7d2a15cfbdd927a966d4dbe3ce1(c71bf89d19a5e197aade34b29b90c8497);
				}
			}
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.Money)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return c15e7064f3f03a5bd01e03d226678015b(c71bf89d19a5e197aade34b29b90c8497);
				}
			}
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.Shield)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return cd5517723a7d1b3ef645dd9aac2b3a392();
				}
			}
		}
		if (c2b4f43f34e21572af6ab4414f04cee36 == ItemType.ClassMode)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return cf99ad34c4923497068777213145d63d0();
				}
			}
		}
		return null;
	}

	public ItemDNA c24cbedcfe8237e033f3212072cda88db(int c068a8459573fe13bf64a51143a16239d)
	{
		WeaponDNA weaponDNA = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>().c4e0dae6a16a8a80ddb5214a896b9df58(c068a8459573fe13bf64a51143a16239d);
		if (weaponDNA == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "weapon id " + c068a8459573fe13bf64a51143a16239d + " not found in the preset weapons.");
		}
		return ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(weaponDNA);
	}

	public ItemDNA cae1d9fbe64c79c2ca4f01fa40339b359(int c71bf89d19a5e197aade34b29b90c8497)
	{
		return c8f6134952ecb083984e6eff06b352a9b((MaterialType)UnityEngine.Random.Range(0, 13), c71bf89d19a5e197aade34b29b90c8497);
	}

	public ItemDNA c8f6134952ecb083984e6eff06b352a9b(MaterialType c424fafa6354141c1e81d53efca575d8d, int c71bf89d19a5e197aade34b29b90c8497)
	{
		if (c71bf89d19a5e197aade34b29b90c8497 == 0)
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
			c71bf89d19a5e197aade34b29b90c8497 = 1;
		}
		return ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4(c424fafa6354141c1e81d53efca575d8d, c71bf89d19a5e197aade34b29b90c8497);
	}

	public ItemDNA cf99ad34c4923497068777213145d63d0(ItemRarity cfa5cf06c08ed2297025c96328a9d47ae)
	{
		ClassModeDNA classModeDNA = new ClassModeDNA();
		ClassModeType classModeType = (ClassModeType)UnityEngine.Random.Range(0, 8);
		classModeDNA.m_adapterIdx = ClassModeRarityStore.c922af22d5da6d560167ffa19a38beecd.c3bce211af4ebaab88eaecbd89de457cd(classModeType, cfa5cf06c08ed2297025c96328a9d47ae, ClassModeSubPart.Adapter);
		classModeDNA.m_bodyIdx = ClassModeRarityStore.c922af22d5da6d560167ffa19a38beecd.c3bce211af4ebaab88eaecbd89de457cd(classModeType, cfa5cf06c08ed2297025c96328a9d47ae, ClassModeSubPart.Body);
		classModeDNA.m_chassisIdx = ClassModeRarityStore.c922af22d5da6d560167ffa19a38beecd.c3bce211af4ebaab88eaecbd89de457cd(classModeType, cfa5cf06c08ed2297025c96328a9d47ae, ClassModeSubPart.Chassis);
		classModeDNA.m_drumIdx = ClassModeRarityStore.c922af22d5da6d560167ffa19a38beecd.c3bce211af4ebaab88eaecbd89de457cd(classModeType, cfa5cf06c08ed2297025c96328a9d47ae, ClassModeSubPart.Drum);
		classModeDNA.m_materialIdx = ClassModeRarityStore.c922af22d5da6d560167ffa19a38beecd.c3bce211af4ebaab88eaecbd89de457cd(classModeType, cfa5cf06c08ed2297025c96328a9d47ae, ClassModeSubPart.Material);
		classModeDNA.m_cmType = classModeType;
		classModeDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
		classModeDNA.c56600998da7fa76c3dc3e09e3a16bbbc();
		return c082f20f357e6d0dc7ac2d2e1a6edc8d1(classModeDNA);
	}

	public ItemDNA cf99ad34c4923497068777213145d63d0()
	{
		ClassModeDNA cc5dc401c4272a2185ba4c4b9033482b = cb44448661d7529865ae34ac25fd5ad51(UnityEngine.Random.Range(0, m_playerClassMode.Length));
		return c082f20f357e6d0dc7ac2d2e1a6edc8d1(cc5dc401c4272a2185ba4c4b9033482b);
	}

	public ItemDNA c8be4fb00b4db963ae0ea814af0f6f03d(int c72d673c94b613f02146ba70c8d44cf5e)
	{
		for (int i = 0; i < m_playerClassMode.Length; i++)
		{
			if (m_playerClassMode[i].m_id != c72d673c94b613f02146ba70c8d44cf5e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return c082f20f357e6d0dc7ac2d2e1a6edc8d1(m_playerClassMode[i]);
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public ItemDNA c2e01cb7898e34aaec17b49fc6d18524c(int c73994e5a37b4fce8f3082ed44d22181f)
	{
		for (int i = 0; i < m_PlayerShields.Length; i++)
		{
			if (m_PlayerShields[i].m_id != c73994e5a37b4fce8f3082ed44d22181f)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return cb4633378bdf6d47c409332e395d58c7a(m_PlayerShields[i]);
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public ItemDNA c082f20f357e6d0dc7ac2d2e1a6edc8d1(ClassModeDNA cc5dc401c4272a2185ba4c4b9033482b7)
	{
		return ItemDNA.c7a1e006dac3107ddc09019d735839e9a(cc5dc401c4272a2185ba4c4b9033482b7);
	}

	public ItemDNA cd5517723a7d1b3ef645dd9aac2b3a392(ItemRarity c63bb945a0d03ca6003a2ef06d4b924b4)
	{
		return null;
	}

	public ItemDNA cd5517723a7d1b3ef645dd9aac2b3a392()
	{
		return null;
	}

	public ItemDNA cb4633378bdf6d47c409332e395d58c7a(ShieldDNA c6e05265144de15ae76ef2beadf5b2390)
	{
		return ItemDNA.c8f331a9c3beba42f2ccd0923c0c67e0a(c6e05265144de15ae76ef2beadf5b2390);
	}

	public ItemInstance cbe196809cf0b27c694ddf91a28a46280(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					ItemInstance itemInstance = new ItemInstance(m_gUIDGen.c6e2b9ff42c167dc996f3caa221267502());
					m_localItemDic.Add(itemInstance, c4ed717bfa8e3dbe7b0f04513d76a651e);
					return itemInstance;
				}
				}
			}
		}
		return null;
	}

	public static string c474b312bbfb73d3e8ab0cf777f80e68c(ItemDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		if (caedbc1db6c28d44eab6021e7d674eab3 != null)
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
					return c75919981e281c6d31567ac93867ca150(caedbc1db6c28d44eab6021e7d674eab3.m_type, caedbc1db6c28d44eab6021e7d674eab3.m_ammoType, caedbc1db6c28d44eab6021e7d674eab3.m_materialType, caedbc1db6c28d44eab6021e7d674eab3);
				}
			}
		}
		return string.Empty;
	}

	public static string c75919981e281c6d31567ac93867ca150(ItemType c6ca7698352db776b80b27b30e89ff904)
	{
		return c75919981e281c6d31567ac93867ca150(c6ca7698352db776b80b27b30e89ff904, AmmoType.TOTAL, MaterialType.TOTAL, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	public static string c75919981e281c6d31567ac93867ca150(ItemType c6ca7698352db776b80b27b30e89ff904, AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		return c75919981e281c6d31567ac93867ca150(c6ca7698352db776b80b27b30e89ff904, c1e73ae4c18ab95639cb0c7604f21dc2b, MaterialType.TOTAL, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	public static string c75919981e281c6d31567ac93867ca150(ItemType c6ca7698352db776b80b27b30e89ff904, MaterialType c424fafa6354141c1e81d53efca575d8d)
	{
		return c75919981e281c6d31567ac93867ca150(c6ca7698352db776b80b27b30e89ff904, AmmoType.TOTAL, c424fafa6354141c1e81d53efca575d8d, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	private static string c75919981e281c6d31567ac93867ca150(ItemType c6ca7698352db776b80b27b30e89ff904, AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b, MaterialType c424fafa6354141c1e81d53efca575d8d, ItemDNA caedbc1db6c28d44eab6021e7d674eab3 = null)
	{
		string result = string.Empty;
		switch (c6ca7698352db776b80b27b30e89ff904)
		{
		case ItemType.Weapon:
			result = "Entities/Object/Weapon/Weapon";
			break;
		case ItemType.Material:
			result = "Entities/Object/Item/PRO_" + c424fafa6354141c1e81d53efca575d8d.ToString() + "_P";
			break;
		case ItemType.ClassMode:
			if (caedbc1db6c28d44eab6021e7d674eab3 == null)
			{
				break;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (caedbc1db6c28d44eab6021e7d674eab3.m_classMode == null)
			{
				break;
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
			result = "Entities/Object/Item/ClassMode/PRO_CM_" + caedbc1db6c28d44eab6021e7d674eab3.m_classMode.m_cmType.ToString() + "_P";
			break;
		case ItemType.Shield:
			if (caedbc1db6c28d44eab6021e7d674eab3 != null)
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
				if (caedbc1db6c28d44eab6021e7d674eab3.m_shiled != null)
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
					if (caedbc1db6c28d44eab6021e7d674eab3.m_shiled.m_shieldManufacturer != ItemManufacturer.MAX)
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
						result = "Entities/Object/Item/PRO_Shield_" + caedbc1db6c28d44eab6021e7d674eab3.m_shiled.m_shieldManufacturer.ToString() + "_P";
						break;
					}
				}
			}
			result = "Entities/Object/Shield";
			break;
		case ItemType.HealthPack:
			result = "Entities/Object/Item/PRO_Pack_HP_P";
			break;
		case ItemType.AmmoPack:
			result = "Entities/Object/Item/PRO_Ammo_Pack_P";
			break;
		case ItemType.Ammo:
			switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
			{
			case AmmoType.SMG:
				result = "Entities/Object/Item/PRO_Ammo_SMG_P";
				break;
			case AmmoType.SniperRifle:
				result = "Entities/Object/Item/PRO_Ammo_Sniper_P";
				break;
			case AmmoType.Grenade:
				result = "Entities/Object/Item/PRO_Ammo_Grenade_P";
				break;
			case AmmoType.ShotGun:
				result = "Entities/Object/Item/PRO_Ammo_Shotgun_P";
				break;
			case AmmoType.Pistol:
				result = "Entities/Object/Item/PRO_Ammo_RepeaterPistol_P";
				break;
			case AmmoType.AssaultRifle:
				result = "Entities/Object/Item/PRO_Ammo_SMG_P";
				break;
			}
			break;
		case ItemType.Money:
			result = "Entities/Object/Item/PRO_Cash_P";
			break;
		}
		return result;
	}
}
