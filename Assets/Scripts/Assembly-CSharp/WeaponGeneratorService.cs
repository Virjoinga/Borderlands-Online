using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class WeaponGeneratorService : MonoBehaviour
{
	public WeaponDNA[] m_weapons;

	public WeaponDNA[] m_NPCWeapons;

	private Dictionary<int, List<float>> m_weaponQualityRule;

	private void Start()
	{
		c7298f373f7f68ee130a1a17b936c7e24("WeaponEditor/Bin/Preset_Weapons", ref m_weapons);
		c7298f373f7f68ee130a1a17b936c7e24("WeaponEditor/Bin/Preset_WeaponsForNPC", ref m_NPCWeapons);
	}

	private void cb828d498f5b7c4d28b46ebe88342884a(string c0b16dce2fd09e49dd6976cae6aa57677, ref WeaponDNA[] c784abee8f516637e721e5d792915bcb3)
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c0b16dce2fd09e49dd6976cae6aa57677) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Weapon");
		c784abee8f516637e721e5d792915bcb3 = ce76974377b1b0ebb92a9280be375eb48.c0a0cdf4a196914163f7334d9b0781a04(elementsByTagName.Count);
		int num = 0;
		IEnumerator enumerator = elementsByTagName.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				WeaponType weaponType = (WeaponType)(int)Enum.Parse(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["type"].Value);
				WeaponDNA weaponDNA = new WeaponDNA();
				weaponDNA.m_name = xmlNode.Attributes["name"].Value;
				weaponDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
				weaponDNA.m_type = weaponType;
				weaponDNA.m_rarity = (WeaponRarity)(int)Enum.Parse(Type.GetTypeFromHandle(c7035278b710159f614630f761d2ec0d0.cc1720d05c75832f704b87474932341c3()), xmlNode.Attributes["raritytype"].Value);
				weaponDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(9);
				IEnumerator enumerator2 = Enum.GetValues(Type.GetTypeFromHandle(cbd6d334b1b2c7df454eca020d8c24cc2.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						WeaponSubPart weaponSubPart = (WeaponSubPart)(int)enumerator2.Current;
						if (weaponSubPart == WeaponSubPart.MAX)
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
						}
						else
						{
							SubPartWpn subPartWpn = new SubPartWpn(weaponType, weaponSubPart);
							subPartWpn.m_Index = Convert.ToInt32(xmlNode.Attributes[Enum.GetName(Type.GetTypeFromHandle(cbd6d334b1b2c7df454eca020d8c24cc2.cc1720d05c75832f704b87474932341c3()), weaponSubPart)].Value);
							array[(int)weaponSubPart] = subPartWpn.GetHashCode();
						}
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_021f;
						}
						continue;
						end_IL_021f:
						break;
					}
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable == null)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								goto end_IL_0238;
							}
							continue;
							end_IL_0238:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
				weaponDNA.m_subPartsCode = array;
				weaponDNA.m_generationSource = GenerationSource.Loot;
				weaponDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
				c784abee8f516637e721e5d792915bcb3[num++] = weaponDNA;
			}
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
		finally
		{
			IDisposable disposable2 = enumerator as IDisposable;
			if (disposable2 == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0294;
					}
					continue;
					end_IL_0294:
					break;
				}
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void c7298f373f7f68ee130a1a17b936c7e24(string ca1837576150199b26256e52934a58197, ref WeaponDNA[] c784abee8f516637e721e5d792915bcb3)
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(ca1837576150199b26256e52934a58197) as TextAsset;
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		try
		{
			c784abee8f516637e721e5d792915bcb3 = ce76974377b1b0ebb92a9280be375eb48.c0a0cdf4a196914163f7334d9b0781a04(binaryReader.ReadInt32());
			int num = 0;
			while (num < c784abee8f516637e721e5d792915bcb3.Length)
			{
				WeaponDNA weaponDNA = new WeaponDNA();
				weaponDNA.m_name = binaryReader.ReadString();
				weaponDNA.m_id = binaryReader.ReadInt32();
				weaponDNA.m_type = (WeaponType)binaryReader.ReadByte();
				weaponDNA.m_rarity = (WeaponRarity)binaryReader.ReadByte();
				weaponDNA.m_level = binaryReader.ReadInt32();
				weaponDNA.m_extraEffectCount = binaryReader.ReadInt32();
				for (int i = 0; i < ItemDNA.m_extraEffectNums; i++)
				{
					weaponDNA.m_extraEffect[i] = binaryReader.ReadInt32();
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
					for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
					{
						weaponDNA.m_extraEffectIndex[j] = binaryReader.ReadInt32();
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						int num2 = 9;
						int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num2);
						for (int k = 0; k < num2; k++)
						{
							array[k] = binaryReader.ReadInt32();
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_0132;
							}
							continue;
							end_IL_0132:
							break;
						}
						weaponDNA.m_subPartsCode = array;
						weaponDNA.m_generationSource = GenerationSource.Loot;
						weaponDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
						c784abee8f516637e721e5d792915bcb3[num] = weaponDNA;
						num++;
						break;
					}
					break;
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				memoryStream.Dispose();
				binaryReader.Close();
				return;
			}
		}
		finally
		{
			if (binaryReader != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					((IDisposable)binaryReader).Dispose();
					break;
				}
			}
		}
	}

	private void cc559cce930b07303ff56fbc0c6520453(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cc731ea1f325fce42b04c12a130d6c769, int c5eb2db1ebfc86132792c0312d4a6a878, int c3f899cc5ff0012e976818480e03f142f)
	{
		if (c27b7430edc94b8f5b543605119ec4a72 != WeaponType.SniperRifle)
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
			if (c5eb2db1ebfc86132792c0312d4a6a878 != 1)
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
				if (c5eb2db1ebfc86132792c0312d4a6a878 != 3)
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
					if (c5eb2db1ebfc86132792c0312d4a6a878 != 4)
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
						break;
					}
				}
			}
			if (c3f899cc5ff0012e976818480e03f142f == 2)
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
				if (c3f899cc5ff0012e976818480e03f142f != 5)
				{
					return;
				}
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
		}
	}

	private IEnumerator cb6cf2909448881e6ef22adf2b5e0e17b(WeaponType c2b4f43f34e21572af6ab4414f04cee36, int cd6bb591c33b2ee3ab93e98aa43a6da63, int c125eba1ef2c4172dbdd570378589dcab)
	{
		yield return new WaitForSeconds(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_serviceProcessingTime);
		List<WeaponDNA> weaponOfType = new List<WeaponDNA>();
		WeaponDNA[] weapons = m_weapons;
		foreach (WeaponDNA weapon in weapons)
		{
			if (weapon.c83e548e5608cd7f222098a6966b16545() != c2b4f43f34e21572af6ab4414f04cee36)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			weaponOfType.Add(weapon);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			List<WeaponDNA> generatedWeapon = new List<WeaponDNA>();
			for (int i = 0; i < c125eba1ef2c4172dbdd570378589dcab; i++)
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
				if (i < weaponOfType.Count)
				{
					generatedWeapon.Add(weaponOfType[i]);
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
				break;
			}
			SendMessage("OnRequestRandomWeaponGeneration", generatedWeapon, SendMessageOptions.DontRequireReceiver);
			yield break;
		}
	}

	public WeaponDNA c99cb07293f626db9e57760c01c295c00()
	{
		WeaponType c27b7430edc94b8f5b543605119ec4a = (WeaponType)UnityEngine.Random.Range(0, 3);
		WeaponRarity c335b432937e6c5b61e3fce114d6b6ca = (WeaponRarity)UnityEngine.Random.Range(0, 6);
		return c99cb07293f626db9e57760c01c295c00(c27b7430edc94b8f5b543605119ec4a, c335b432937e6c5b61e3fce114d6b6ca);
	}

	public WeaponDNA c99cb07293f626db9e57760c01c295c00(WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5)
	{
		WeaponType c27b7430edc94b8f5b543605119ec4a = (WeaponType)UnityEngine.Random.Range(0, 5);
		return c99cb07293f626db9e57760c01c295c00(c27b7430edc94b8f5b543605119ec4a, c335b432937e6c5b61e3fce114d6b6ca5);
	}

	public WeaponDNA c99cb07293f626db9e57760c01c295c00(WeaponType c27b7430edc94b8f5b543605119ec4a72, WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5 = WeaponRarity.Common)
	{
		if (c27b7430edc94b8f5b543605119ec4a72 == WeaponType.TOTAL)
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
			c27b7430edc94b8f5b543605119ec4a72 = (WeaponType)UnityEngine.Random.Range(0, 5);
		}
		if (c335b432937e6c5b61e3fce114d6b6ca5 == WeaponRarity.TOTAL)
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
			c335b432937e6c5b61e3fce114d6b6ca5 = (WeaponRarity)UnityEngine.Random.Range(0, 6);
		}
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(Enum.GetValues(Type.GetTypeFromHandle(cbd6d334b1b2c7df454eca020d8c24cc2.cc1720d05c75832f704b87474932341c3())).Length - 1);
		for (int i = 0; i < 9; i++)
		{
			if (i == 9)
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
				continue;
			}
			if (SubPartStore.c2468dbf91d056d864da750fa5576bbef.c1da8bf1abc50177e367792c08bfd23f6(c27b7430edc94b8f5b543605119ec4a72, (WeaponSubPart)i))
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
				SubPartWpn subPartWpn = new SubPartWpn(c27b7430edc94b8f5b543605119ec4a72, (WeaponSubPart)i);
				subPartWpn.m_Index = -1;
				array[i] = subPartWpn.GetHashCode();
				continue;
			}
			int c5612a459a84ffdb41c885401433cd62d = RarityStore.rarityStore.c3bce211af4ebaab88eaecbd89de457cd(c27b7430edc94b8f5b543605119ec4a72, c335b432937e6c5b61e3fce114d6b6ca5, (WeaponSubPart)i);
			SubPartWpn subPartWpn2 = SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(c27b7430edc94b8f5b543605119ec4a72, (WeaponSubPart)i, c5612a459a84ffdb41c885401433cd62d);
			if (subPartWpn2 == null)
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
			array[i] = subPartWpn2.GetHashCode();
			object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array2[0] = "get:";
			array2[1] = Enum.GetName(Type.GetTypeFromHandle(cbd6d334b1b2c7df454eca020d8c24cc2.cc1720d05c75832f704b87474932341c3()), subPartWpn2.m_partType);
			array2[2] = "-";
			array2[3] = subPartWpn2.m_Index;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array2));
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			WeaponDNA weaponDNA = new WeaponDNA();
			weaponDNA.m_type = c27b7430edc94b8f5b543605119ec4a72;
			weaponDNA.m_subPartsCode = array;
			weaponDNA.m_generationSource = GenerationSource.Loot;
			weaponDNA.m_name = string.Format("{0}", weaponDNA.m_type);
			weaponDNA.m_rarity = c335b432937e6c5b61e3fce114d6b6ca5;
			weaponDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
			weaponDNA.m_extraEffectCount = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_slotSetups.ca5ac08b3168426e78e2b436f7817c886(weaponDNA.c5681693ba1dda13f5ded7392b68c1e19());
			weaponDNA.m_extraEffect = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_levelEffectSetups.cb5ca053b99d0243a3db761c01bcca458(weaponDNA.c5681693ba1dda13f5ded7392b68c1e19(), weaponDNA.m_level, weaponDNA.m_extraEffectCount, cd854b73d143561ed3c0d11e05425f473.c7088de59e49f7108f520cf7e0bae167e);
			weaponDNA.m_extraEffectIndex = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.c7f598feb0b9cb42385696406189e52a3(weaponDNA.c5681693ba1dda13f5ded7392b68c1e19(), weaponDNA.m_extraEffect);
			weaponDNA.c769c0065a21eb531d8917d0dd358768f();
			return weaponDNA;
		}
	}

	public WeaponDNA c849f0e46afe2d4898e815bd8a455fe6b()
	{
		return m_weapons[UnityEngine.Random.Range(0, c03759d0ca237ff2a482801ecc0963848())];
	}

	public WeaponDNA c9f647d10e49d4574bbd3bc57fb0a3e31()
	{
		return m_weapons[UnityEngine.Random.Range(0, m_weapons.Length)];
	}

	public WeaponDNA c4e0dae6a16a8a80ddb5214a896b9df58(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_weapons.Length; i++)
		{
			if (m_weapons[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				return m_weapons[i];
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

	public WeaponDNA cd3728c6f41593e1da7359f2dce39ce0f(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		for (int i = 0; i < m_weapons.Length; i++)
		{
			if (!m_weapons[i].m_name.Equals(cd99af21e22e356018b8f72d4a7e4872a))
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
				return m_weapons[i];
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public WeaponDNA ca42e633aafcfd5583b6c0f668ed4533a(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_NPCWeapons.Length; i++)
		{
			if (m_NPCWeapons[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_NPCWeapons[i];
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Invalid Weapon ID");
			return null;
		}
	}

	public int c03759d0ca237ff2a482801ecc0963848()
	{
		return 15;
	}

	private int c55d600dd53bb6818f69cb88910ef0a68(int cb9aa9404220b2b81c6745ac8d6bdabc6 = 0, int c61b929632cc30a86392a6d89b8696662 = 0, int cc91b88c0d703701bf50ef9e3ab825ed3 = 0)
	{
		int num = cb9aa9404220b2b81c6745ac8d6bdabc6 + c61b929632cc30a86392a6d89b8696662 + cc91b88c0d703701bf50ef9e3ab825ed3;
		int num2 = num - num % 10;
		int max = num2 + 11;
		int num3 = UnityEngine.Random.Range(num2, max);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "*****WeaponLevelGenerator: " + num3);
		return num3;
	}

	private void c023abb85115936df05ebdbbdc731d1a9()
	{
		m_weaponQualityRule = new Dictionary<int, List<float>>();
		List<float> list = new List<float>();
		list.Add(0.25f);
		list.Add(0.18f);
		m_weaponQualityRule.Add(0, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.25f);
		list.Add(0.18f);
		list.Add(0.08f);
		list.Add(0.002f);
		m_weaponQualityRule.Add(1, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.25f);
		list.Add(0.18f);
		list.Add(0.1f);
		list.Add(0.002f);
		list.Add(0.002f);
		m_weaponQualityRule.Add(2, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.38f);
		list.Add(0.22f);
		list.Add(0.08f);
		list.Add(0.02f);
		list.Add(0.008f);
		list.Add(0.002f);
		m_weaponQualityRule.Add(3, list);
		list = new List<float>();
		list.Add(0.25f);
		list.Add(0.38f);
		list.Add(0.22f);
		list.Add(0.08f);
		list.Add(0.02f);
		list.Add(0.008f);
		list.Add(0.005f);
		list.Add(0.002f);
		m_weaponQualityRule.Add(4, list);
		m_weaponQualityRule.Add(5, list);
		m_weaponQualityRule.Add(6, list);
	}

	private WeaponQuality c3a1b061529a82e6412887255263df11a(int cd41ab51966c5ff00c67973a4755d4730 = 0)
	{
		int key = (cd41ab51966c5ff00c67973a4755d4730 - 1) / 10;
		List<float> list = m_weaponQualityRule[key];
		if (m_weaponQualityRule == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "*****Invalid listIndex");
					return WeaponQuality.Max;
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, list[i].ToString());
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			int count = list.Count;
			float num = UnityEngine.Random.Range(0f, 1f);
			int num2 = 0;
			float num3 = 0f;
			while (true)
			{
				if (num2 < count)
				{
					num3 += list[num2];
					if (num3 > num)
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
					num2++;
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
				break;
			}
			WeaponQuality weaponQuality = (WeaponQuality)num2;
			if (num2 == count)
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
				weaponQuality = WeaponQuality.Max;
			}
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = "*****WeaponQualityGenerator: ";
			array[1] = weaponQuality;
			array[2] = "  result: ";
			array[3] = num;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
			return weaponQuality;
		}
	}

	private WeaponType c22a9c6a70920312bae8350d34bbb4d9e()
	{
		WeaponType weaponType = (WeaponType)UnityEngine.Random.Range(0, 5);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "*****WeaponTypeGenerator: " + weaponType);
		return weaponType;
	}

	private void c24170ed681131c7cdf11a25848a95e60(string c26bc9278762c84e1e76177f085674c7e, string ce7ca4eeecb6eaefe7c767fd6ec84011c, ref int ccb47f27de7c4d7fd16b48c6a8c441e7b, ref int c6ff2ed69a5fd1486727d53e14096ea6d, ref int cea3f6d8d95596ae038af3c0d8dd4d16a, ref int c0937e84ef86fe0957a1f03f61ae64579, ref int c2e77b14eef6cc0571283261da74fa189, ref int c93ce1f441a4bace32ace56ecb83c5d38, ref string cdfad4ba0a55425109c91f87781d91a4f)
	{
		ccb47f27de7c4d7fd16b48c6a8c441e7b = UnityEngine.Random.Range(0, 5);
		c6ff2ed69a5fd1486727d53e14096ea6d = UnityEngine.Random.Range(0, 5);
		cea3f6d8d95596ae038af3c0d8dd4d16a = UnityEngine.Random.Range(0, 5);
		c0937e84ef86fe0957a1f03f61ae64579 = UnityEngine.Random.Range(0, 5);
		c2e77b14eef6cc0571283261da74fa189 = UnityEngine.Random.Range(0, 5);
		c93ce1f441a4bace32ace56ecb83c5d38 = UnityEngine.Random.Range(0, 5);
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(14);
		array[0] = "*****ModelPartGenerator--body:";
		array[1] = ccb47f27de7c4d7fd16b48c6a8c441e7b;
		array[2] = " barrel:";
		array[3] = c6ff2ed69a5fd1486727d53e14096ea6d;
		array[4] = " sight:";
		array[5] = cea3f6d8d95596ae038af3c0d8dd4d16a;
		array[6] = " mag:";
		array[7] = c0937e84ef86fe0957a1f03f61ae64579;
		array[8] = " stock:";
		array[9] = c2e77b14eef6cc0571283261da74fa189;
		array[10] = " acc:";
		array[11] = c93ce1f441a4bace32ace56ecb83c5d38;
		array[12] = " material:";
		array[13] = cdfad4ba0a55425109c91f87781d91a4f;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
	}
}
