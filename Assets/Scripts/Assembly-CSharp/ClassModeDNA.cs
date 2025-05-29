using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using XsdSettings;

public class ClassModeDNA : ICloneable
{
	public int m_id;

	public ClassModeType m_cmType;

	public ItemRarity m_rarity;

	public GenerationSource m_generationSource;

	public string m_name;

	public int m_level;

	public int m_adapterIdx;

	public int m_bodyIdx;

	public int m_chassisIdx;

	public int m_drumIdx;

	public int m_materialIdx;

	public ClassModeAttribute m_attribute;

	public int m_material;

	public ClassModeDNA()
	{
		m_id = 0;
		m_cmType = ClassModeType.SoldierDemoMan;
		m_adapterIdx = 0;
		m_bodyIdx = 0;
		m_chassisIdx = 0;
		m_drumIdx = 0;
		m_materialIdx = 0;
		m_level = 0;
	}

	public ClassModeDNA(ClassModeDNA c498ff81f8ab3e0654c2a1ef994384fb9)
	{
		m_id = c498ff81f8ab3e0654c2a1ef994384fb9.m_id;
		m_cmType = c498ff81f8ab3e0654c2a1ef994384fb9.m_cmType;
		m_adapterIdx = c498ff81f8ab3e0654c2a1ef994384fb9.m_adapterIdx;
		m_bodyIdx = c498ff81f8ab3e0654c2a1ef994384fb9.m_bodyIdx;
		m_chassisIdx = c498ff81f8ab3e0654c2a1ef994384fb9.m_chassisIdx;
		m_drumIdx = c498ff81f8ab3e0654c2a1ef994384fb9.m_drumIdx;
		m_materialIdx = c498ff81f8ab3e0654c2a1ef994384fb9.m_materialIdx;
		m_level = c498ff81f8ab3e0654c2a1ef994384fb9.m_level;
	}

	public object Clone()
	{
		return (ClassModeDNA)MemberwiseClone();
	}

	public static ClassModeDNA cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		try
		{
			if (c591d56a94543e3559945c497f37126c4 == null)
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
						throw new Exception("data is NULL.");
					}
				}
			}
			ClassModeDNA classModeDNA = new ClassModeDNA();
			classModeDNA.m_level = (int)c591d56a94543e3559945c497f37126c4[1];
			classModeDNA.m_rarity = (ItemRarity)(int)c591d56a94543e3559945c497f37126c4[2];
			classModeDNA.m_generationSource = (GenerationSource)(int)c591d56a94543e3559945c497f37126c4[3];
			classModeDNA.m_id = (int)c591d56a94543e3559945c497f37126c4[4];
			classModeDNA.m_name = (string)c591d56a94543e3559945c497f37126c4[6];
			classModeDNA.m_cmType = (ClassModeType)(int)c591d56a94543e3559945c497f37126c4[7];
			classModeDNA.m_adapterIdx = (int)c591d56a94543e3559945c497f37126c4[8];
			classModeDNA.m_bodyIdx = (int)c591d56a94543e3559945c497f37126c4[9];
			classModeDNA.m_chassisIdx = (int)c591d56a94543e3559945c497f37126c4[10];
			classModeDNA.m_drumIdx = (int)c591d56a94543e3559945c497f37126c4[11];
			classModeDNA.m_materialIdx = (int)c591d56a94543e3559945c497f37126c4[12];
			classModeDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
			return classModeDNA;
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("Invalid ClassMode Data: {0}", ex.Message));
			return c6fa4f42bf72c2dd1857080a6c791c70f.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	public override int GetHashCode()
	{
		return m_cmType.ToString().GetHashCode();
	}

	public int ceb3d45f1f9ac07949342e57a7f731855(ClassModeSubPart cc39da5797bff62b57e27c70549bba81e)
	{
		switch (cc39da5797bff62b57e27c70549bba81e)
		{
		case ClassModeSubPart.Adapter:
			return m_adapterIdx;
		case ClassModeSubPart.Body:
			return m_bodyIdx;
		case ClassModeSubPart.Chassis:
			return m_chassisIdx;
		case ClassModeSubPart.Drum:
			return m_drumIdx;
		case ClassModeSubPart.Material:
			return m_materialIdx;
		default:
			return 0;
		}
	}

	public List<SkillAttributeConfig> cd0c0b3e28f87164a771cf50ebb30e5de()
	{
		List<SkillAttributeConfig> list = new List<SkillAttributeConfig>();
		using (List<SkillAttributeConfig>.Enumerator enumerator = m_attribute.m_classModeAttributes.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				SkillAttributeConfig current = enumerator.Current;
				if (!current.m_bModified)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				list.Add(current);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				return list;
			}
		}
	}

	public AvatarType c95c0ac986e3767a549cf71c2cf28b34f(ClassModeType cb60928ef9d0be0bfc6010c7fcf5f6ab7)
	{
		switch (cb60928ef9d0be0bfc6010c7fcf5f6ab7)
		{
		case ClassModeType.SoldierDemoMan:
		case ClassModeType.SoldierMachinist:
			return AvatarType.SOLDIER;
		case ClassModeType.SirenEnchanter:
		case ClassModeType.SirenSorcerer:
			return AvatarType.SIREN;
		case ClassModeType.BerserkerGuardian:
		case ClassModeType.BerserkerButcher:
			return AvatarType.BERSERKER;
		case ClassModeType.HunterAgent:
		case ClassModeType.HunterMarksman:
			return AvatarType.HUNTER;
		default:
			return AvatarType.TOTAL;
		}
	}

	public void ce6ec0bf2246c7c29dcd48277bcd2f743()
	{
		if (m_attribute == null)
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
			m_attribute = new ClassModeAttribute();
		}
		for (int i = 0; i < 5; i++)
		{
			SubPartClassMode subPartClassMode = SubPartClassModeStore.c67b9adbc0ab8308ac014cfe440647a7e.cdbf696aded5fd1b462c05fbd81522f65(m_cmType, (ClassModeSubPart)i, ceb3d45f1f9ac07949342e57a7f731855((ClassModeSubPart)i));
			if (subPartClassMode == null)
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
			if (subPartClassMode.m_subpartType == ClassModeSubPart.Material)
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
				m_material = (int)subPartClassMode.m_attributeValue;
			}
			else
			{
				if (subPartClassMode.m_attributeValue.ce5aad699df330ff708587e4fabea8cbb(0f, 0.001f))
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
				c2e294d60e500ff103a0593789c8ef6cb(subPartClassMode.m_affectType, subPartClassMode.m_classModeAttribute, subPartClassMode.m_attributeValue);
			}
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

	public void c2e294d60e500ff103a0593789c8ef6cb(AffectType c7d663c1e25c9ad53f0f4a926e3924759, EffectType cdc8afd29b145cd41766452ed8ad942b9, float c51651f7837a92bc8e64d74c13e2bb1eb)
	{
		m_attribute.m_classModeAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_bModified = true;
		switch (c7d663c1e25c9ad53f0f4a926e3924759)
		{
		case AffectType.PrevAdd:
		case AffectType.PostAdd:
			m_attribute.m_classModeAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_attrValue += c51651f7837a92bc8e64d74c13e2bb1eb;
			m_attribute.m_classModeAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_affectType = c7d663c1e25c9ad53f0f4a926e3924759;
			break;
		case AffectType.Scale:
			m_attribute.m_classModeAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_attrValue = 1f + c51651f7837a92bc8e64d74c13e2bb1eb;
			m_attribute.m_classModeAttributes[(int)cdc8afd29b145cd41766452ed8ad942b9].m_affectType = c7d663c1e25c9ad53f0f4a926e3924759;
			break;
		}
	}

	public string c5f6245b591c90000d8430fc1ca8cc4de()
	{
		if (m_name != null)
		{
			while (true)
			{
				switch (1)
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

	public void c56600998da7fa76c3dc3e09e3a16bbbc()
	{
	}
}
