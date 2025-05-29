using System;
using System.Collections;
using A;
using Core;
using UnityEngine;
using XsdSettings;

[Serializable]
public class ShieldDNA : ICloneable
{
	public int m_id;

	public string m_name;

	public ItemRarity m_rarity;

	public ItemManufacturer m_shieldManufacturer;

	public int m_level;

	public int m_bodyIdx;

	public int m_batteryIdx;

	public int m_capacitorIdx;

	public int m_accessoryIdx;

	public int m_materialIdx;

	public GenerationSource m_generationSource;

	public ShieldAttribute m_attribute;

	public ShieldDNA(ShieldDNA c6e05265144de15ae76ef2beadf5b2390)
	{
		m_id = c6e05265144de15ae76ef2beadf5b2390.m_id;
		m_generationSource = c6e05265144de15ae76ef2beadf5b2390.m_generationSource;
		m_level = c6e05265144de15ae76ef2beadf5b2390.m_level;
		m_shieldManufacturer = c6e05265144de15ae76ef2beadf5b2390.m_shieldManufacturer;
		m_bodyIdx = c6e05265144de15ae76ef2beadf5b2390.m_bodyIdx;
		m_batteryIdx = c6e05265144de15ae76ef2beadf5b2390.m_batteryIdx;
		m_capacitorIdx = c6e05265144de15ae76ef2beadf5b2390.m_capacitorIdx;
		m_accessoryIdx = c6e05265144de15ae76ef2beadf5b2390.m_accessoryIdx;
		m_materialIdx = c6e05265144de15ae76ef2beadf5b2390.m_materialIdx;
		m_name = c6e05265144de15ae76ef2beadf5b2390.m_name;
		m_rarity = c6e05265144de15ae76ef2beadf5b2390.m_rarity;
	}

	public ShieldDNA()
	{
		m_id = 0;
		m_shieldManufacturer = ItemManufacturer.Vladof;
		m_generationSource = GenerationSource.Loot;
		m_level = 0;
		m_bodyIdx = 0;
		m_batteryIdx = 0;
		m_capacitorIdx = 0;
		m_accessoryIdx = 0;
		m_materialIdx = 0;
		m_name = string.Empty;
		m_rarity = ItemRarity.Common;
	}

	public object Clone()
	{
		return (ShieldDNA)MemberwiseClone();
	}

	public static ShieldDNA cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		try
		{
			if (c591d56a94543e3559945c497f37126c4 == null)
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
						throw new Exception("data is NULL.");
					}
				}
			}
			ShieldDNA shieldDNA = new ShieldDNA();
			shieldDNA.m_level = (int)c591d56a94543e3559945c497f37126c4[1];
			shieldDNA.m_rarity = (ItemRarity)(int)c591d56a94543e3559945c497f37126c4[2];
			shieldDNA.m_generationSource = (GenerationSource)(int)c591d56a94543e3559945c497f37126c4[3];
			shieldDNA.m_id = (int)c591d56a94543e3559945c497f37126c4[4];
			shieldDNA.m_name = (string)c591d56a94543e3559945c497f37126c4[6];
			shieldDNA.m_shieldManufacturer = (ItemManufacturer)(int)c591d56a94543e3559945c497f37126c4[8];
			shieldDNA.m_bodyIdx = (int)c591d56a94543e3559945c497f37126c4[9];
			shieldDNA.m_batteryIdx = (int)c591d56a94543e3559945c497f37126c4[10];
			shieldDNA.m_capacitorIdx = (int)c591d56a94543e3559945c497f37126c4[11];
			shieldDNA.m_accessoryIdx = (int)c591d56a94543e3559945c497f37126c4[12];
			shieldDNA.m_materialIdx = (int)c591d56a94543e3559945c497f37126c4[13];
			shieldDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
			return shieldDNA;
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("Invalid shield Data: {0}", ex.Message));
			return c26b1d577ac9c0da502ba2980efb9fbde.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	public override int GetHashCode()
	{
		return m_shieldManufacturer.ToString().GetHashCode();
	}

	public void ce6ec0bf2246c7c29dcd48277bcd2f743()
	{
		if (m_attribute == null)
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
			m_attribute = new ShieldAttribute();
		}
		for (int i = 0; i < 5; i++)
		{
			SubPartShield subPartShield = SubPartShieldStore.cae9c063cc4b210afb2878d8f360436c9.cdbf696aded5fd1b462c05fbd81522f65((ShieldSubPart)i, ceb3d45f1f9ac07949342e57a7f731855((ShieldSubPart)i));
			if (subPartShield == null)
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
			c2e294d60e500ff103a0593789c8ef6cb(subPartShield.m_affectType, subPartShield.m_shieldAttribute, subPartShield.m_attributeValue);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			m_shieldManufacturer = (ItemManufacturer)m_attribute.m_shieldAttributes[3].m_attrValue;
			return;
		}
	}

	public string c5f6245b591c90000d8430fc1ca8cc4de()
	{
		if (m_name != null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int num = m_name.IndexOf(" ");
					if (num > 0)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
							{
								string c0ecc54688f26e096af3299c445becd1a = m_name.Substring(0, num);
								string c0ecc54688f26e096af3299c445becd1a2 = m_name.Substring(num + 1);
								string text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c0ecc54688f26e096af3299c445becd1a));
								string text2 = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c0ecc54688f26e096af3299c445becd1a2));
								return text + " " + text2;
							}
							}
						}
					}
					return LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_name));
				}
				}
			}
		}
		return null;
	}

	public void c3216d4d86c0a7d7bf5c6f3d12cdd73f8()
	{
	}

	public int ceb3d45f1f9ac07949342e57a7f731855(ShieldSubPart cc39da5797bff62b57e27c70549bba81e)
	{
		switch (cc39da5797bff62b57e27c70549bba81e)
		{
		case ShieldSubPart.Accessory:
			return m_accessoryIdx;
		case ShieldSubPart.Battery:
			return m_batteryIdx;
		case ShieldSubPart.Body:
			return m_bodyIdx;
		case ShieldSubPart.Capacitor:
			return m_capacitorIdx;
		case ShieldSubPart.Material:
			return m_materialIdx;
		default:
			return 0;
		}
	}

	public void c2e294d60e500ff103a0593789c8ef6cb(AffectType c7d663c1e25c9ad53f0f4a926e3924759, ShieldAttributeType cdc8afd29b145cd41766452ed8ad942b9, float c51651f7837a92bc8e64d74c13e2bb1eb)
	{
		switch (c7d663c1e25c9ad53f0f4a926e3924759)
		{
		case AffectType.PrevAdd:
		case AffectType.PostAdd:
			m_attribute.m_shieldAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_attrValue += c51651f7837a92bc8e64d74c13e2bb1eb;
			break;
		case AffectType.Scale:
			m_attribute.m_shieldAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_attrValue *= c51651f7837a92bc8e64d74c13e2bb1eb;
			break;
		}
	}

	public float c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType cdc8afd29b145cd41766452ed8ad942b9)
	{
		if (cdc8afd29b145cd41766452ed8ad942b9 == ShieldAttributeType.Capacity)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					float num = m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(cdc8afd29b145cd41766452ed8ad942b9) / ShieldAttributeConfig.s_maxShieldPoint;
					LevelingManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86;
					int cd6bb591c33b2ee3ab93e98aa43a6da;
					if (m_level > 0)
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
						cd6bb591c33b2ee3ab93e98aa43a6da = m_level;
					}
					else
					{
						cd6bb591c33b2ee3ab93e98aa43a6da = 1;
					}
					int num2 = c5ee19dc8d4cccf5ae2de225410458b.c4459dc4cce1d07c3d1484ae8659420f3(AvatarType.SIREN, cd6bb591c33b2ee3ab93e98aa43a6da);
					return Mathf.FloorToInt(num * (float)num2);
				}
				}
			}
		}
		if (cdc8afd29b145cd41766452ed8ad942b9 == ShieldAttributeType.RechargeDelay)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(cdc8afd29b145cd41766452ed8ad942b9);
				}
			}
		}
		if (cdc8afd29b145cd41766452ed8ad942b9 == ShieldAttributeType.RechargeRate)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					float num3 = m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.Capacity) / ShieldAttributeConfig.s_maxShieldPoint;
					LevelingManager c5ee19dc8d4cccf5ae2de225410458b2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86;
					int cd6bb591c33b2ee3ab93e98aa43a6da2;
					if (m_level > 0)
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
						cd6bb591c33b2ee3ab93e98aa43a6da2 = m_level;
					}
					else
					{
						cd6bb591c33b2ee3ab93e98aa43a6da2 = 1;
					}
					int num4 = c5ee19dc8d4cccf5ae2de225410458b2.c4459dc4cce1d07c3d1484ae8659420f3(AvatarType.SIREN, cd6bb591c33b2ee3ab93e98aa43a6da2);
					return (float)num4 * num3 * m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(cdc8afd29b145cd41766452ed8ad942b9);
				}
				}
			}
		}
		return 0f;
	}
}
