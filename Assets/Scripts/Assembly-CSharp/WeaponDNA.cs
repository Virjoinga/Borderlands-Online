using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using A;
using Core;
using UnityEngine;
using XsdSettings;

[Serializable]
public class WeaponDNA : ICloneable
{
	public string m_name;

	public WeaponType m_type;

	public WeaponRarity m_rarity;

	public int m_level;

	public int[] m_subPartsCode = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(9);

	public GenerationSource m_generationSource;

	public WeaponAttribute m_attribute;

	public int m_extraEffectCount;

	public int[] m_extraEffect = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(ItemDNA.m_extraEffectNums);

	public int[] m_extraEffectIndex = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(ItemDNA.m_extraEffectNums);

	public int m_starLevel;

	public int m_starExperience;

	public int m_id { get; set; }

	public WeaponDNA(WeaponDNA c53b5c96930d3532e5eda8804220ea788)
	{
		m_id = c53b5c96930d3532e5eda8804220ea788.m_id;
		m_name = c53b5c96930d3532e5eda8804220ea788.m_name;
		m_type = c53b5c96930d3532e5eda8804220ea788.m_type;
		m_level = c53b5c96930d3532e5eda8804220ea788.m_level;
		m_rarity = c53b5c96930d3532e5eda8804220ea788.m_rarity;
		m_subPartsCode = c53b5c96930d3532e5eda8804220ea788.m_subPartsCode;
		m_generationSource = c53b5c96930d3532e5eda8804220ea788.m_generationSource;
		m_attribute = new WeaponAttribute(c53b5c96930d3532e5eda8804220ea788.m_attribute);
	}

	public WeaponDNA()
	{
		m_type = WeaponType.SMG;
		m_name = string.Empty;
		m_level = 1;
		m_rarity = WeaponRarity.Common;
		for (int i = 0; i < m_subPartsCode.Length; i++)
		{
			m_subPartsCode[i] = SubPartWpn.cab05c97ab6dee558edc49d79f6a92ed1(m_type, (WeaponSubPart)i, 0);
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
			m_generationSource = GenerationSource.Loot;
			m_attribute = c71722c4194895927e64f2a4f0991fcca.c7088de59e49f7108f520cf7e0bae167e;
			m_extraEffectCount = 0;
			for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
			{
				m_extraEffect[j] = 0;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				for (int k = 0; k < ItemDNA.m_extraEffectNums; k++)
				{
					m_extraEffectIndex[k] = 0;
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
	}

	public object Clone()
	{
		WeaponDNA weaponDNA = (WeaponDNA)MemberwiseClone();
		m_subPartsCode.CopyTo(weaponDNA.m_subPartsCode, 0);
		return weaponDNA;
	}

	public string cf2ac33c63b307c2048f4971b0f8bf391()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(9);
		for (int i = 0; i < 9; i++)
		{
			array[i] = m_subPartsCode[i].ToString();
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
			return string.Join(",", array);
		}
	}

	public WeaponType c83e548e5608cd7f222098a6966b16545()
	{
		return m_type;
	}

	public ItemRarity c5681693ba1dda13f5ded7392b68c1e19()
	{
		return (ItemRarity)m_rarity;
	}

	public bool c02f707b729db89f6ea8df2f0b980cd1e()
	{
		int result;
		if (m_type == WeaponType.RepeaterPistol)
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
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public string c5f6245b591c90000d8430fc1ca8cc4de()
	{
		int num = m_name.IndexOf(" ");
		if (num <= 0)
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
					return LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_name));
				}
			}
		}
		string name = m_name;
		char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = ' ';
		string[] array2 = name.Split(array);
		string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		for (int i = 0; i < array2.Length; i++)
		{
			text += LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(array2[i]));
			if (i == array2.Length - 1)
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
			text += " ";
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return text;
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
			m_attribute = new WeaponAttribute(WeaponStore.weaponStore.m_weaponDic[(int)c83e548e5608cd7f222098a6966b16545()]);
		}
		FloatAttributeValue floatAttributeValue = m_attribute.m_weaponAttribute[101].m_attributeValue as FloatAttributeValue;
		if (floatAttributeValue != null)
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
			floatAttributeValue.m_value = c1a0a00d284fbcae1083e170eda771126(m_level, floatAttributeValue.m_value);
		}
		Dictionary<AttributeType, List<AttributeValue>> dictionary = new Dictionary<AttributeType, List<AttributeValue>>();
		for (int i = 0; i < m_subPartsCode.Length; i++)
		{
			SubPartWpn subPartWpn = SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(m_subPartsCode[i]);
			if (subPartWpn != null)
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
				if (subPartWpn.m_Attributes == null)
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
				for (int j = 0; j < subPartWpn.m_Attributes.Length; j++)
				{
					BOLAttribute bOLAttribute = m_attribute.m_weaponAttribute[(int)subPartWpn.m_Attributes[j].m_attributeType];
					if (bOLAttribute.m_attributeType != subPartWpn.m_Attributes[j].m_attributeType)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, bOLAttribute.m_attributeType.ToString() + "Attribute distortion!!!!" + subPartWpn.m_Attributes[j].m_attributeType);
					}
					List<AttributeValue> value = c9497fa9523905808aac42021cda9ed0a.c7088de59e49f7108f520cf7e0bae167e;
					if (!dictionary.TryGetValue(subPartWpn.m_Attributes[j].m_attributeType, out value))
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
						value = new List<AttributeValue>();
						value.Add(subPartWpn.m_Attributes[j].m_attributeValue);
						dictionary.Add(subPartWpn.m_Attributes[j].m_attributeType, value);
					}
					else
					{
						value.Add(subPartWpn.m_Attributes[j].m_attributeValue);
					}
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
			else
			{
				if (SubPartStore.c2468dbf91d056d864da750fa5576bbef.c1da8bf1abc50177e367792c08bfd23f6(c83e548e5608cd7f222098a6966b16545(), (WeaponSubPart)i))
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
				string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
				array[0] = "can't find sub part for ";
				array[1] = c83e548e5608cd7f222098a6966b16545().ToString();
				array[2] = "Rarity is ";
				array[3] = m_rarity.ToString();
				array[4] = " subpart is ";
				array[5] = ((WeaponSubPart)i).ToString();
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array));
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			using (Dictionary<AttributeType, List<AttributeValue>>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<AttributeType, List<AttributeValue>> current = enumerator.Current;
					List<AttributeValue> value2 = current.Value;
					AttributeValue attributeValue = m_attribute.m_weaponAttribute[(int)current.Key].m_attributeValue;
					int num = 0;
					while (true)
					{
						if (num < value2.Count)
						{
							if (attributeValue.m_type != value2[num].m_type)
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
								string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(8);
								array2[0] = "weapon type ";
								array2[1] = m_type.ToString();
								array2[2] = " ";
								array2[3] = attributeValue.m_type.ToString();
								array2[4] = "is not match ";
								array2[5] = value2[num].m_type.ToString();
								array2[6] = " attribute is ";
								array2[7] = current.Key.ToString();
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array2));
								break;
							}
							num++;
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
					attributeValue.c9c04395301e0ad43dd772719c88b33d9(value2);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_0411;
					}
					continue;
					end_IL_0411:
					break;
				}
			}
			FloatAttributeValue floatAttributeValue2 = m_attribute.m_weaponAttribute[100].m_attributeValue as FloatAttributeValue;
			FloatAttributeValue floatAttributeValue3 = m_attribute.m_weaponAttribute[120].m_attributeValue as FloatAttributeValue;
			FloatAttributeValue floatAttributeValue4 = m_attribute.m_weaponAttribute[63].m_attributeValue as FloatAttributeValue;
			if (floatAttributeValue2 != null)
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
				if (floatAttributeValue3 != null)
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
					if (floatAttributeValue4 != null)
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
						if (floatAttributeValue4.m_value > 0f)
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
							floatAttributeValue2.m_value = floatAttributeValue3.m_value / floatAttributeValue4.m_value;
							floatAttributeValue2.m_value = c1a0a00d284fbcae1083e170eda771126(m_level, floatAttributeValue2.m_value);
						}
					}
				}
			}
			IntAttributeValue intAttributeValue = m_attribute.m_weaponAttribute[102].m_attributeValue as IntAttributeValue;
			int num2 = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.m_weaponAttribute[104].m_attributeValue as IntAttributeValue);
			if (intAttributeValue.m_value == 0)
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
				if (num2 == 2)
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
					intAttributeValue.m_value = 1;
				}
			}
			c4bc569e58a832b25025fbeedca9da647();
			return;
		}
	}

	public void c4bc569e58a832b25025fbeedca9da647()
	{
		List<SingleWeaponAttribute> list = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.m_starLevelAttrSetup.c72d3a70da22effa82ba411b3671a0a3a(m_type, m_starLevel);
		for (int i = 0; i < list.Count; i++)
		{
			AttributeValue attributeValue = m_attribute.m_weaponAttribute[(int)list[i].m_attributeType].m_attributeValue;
			List<AttributeValue> list2 = new List<AttributeValue>();
			if (attributeValue.m_type == AttributeValueType.FloatAttributeValue)
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
				FloatAttributeValue floatAttributeValue = new FloatAttributeValue();
				floatAttributeValue.m_value = list[i].m_value;
				floatAttributeValue.m_affectType = list[i].m_affectType;
				list2.Add(floatAttributeValue);
			}
			else if (attributeValue.m_type == AttributeValueType.IntAttributeValue)
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
				IntAttributeValue intAttributeValue = new IntAttributeValue();
				intAttributeValue.m_value = Convert.ToInt32(list[i].m_value);
				intAttributeValue.m_affectType = list[i].m_affectType;
				list2.Add(intAttributeValue);
			}
			attributeValue.c9c04395301e0ad43dd772719c88b33d9(list2);
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

	public float c1a0a00d284fbcae1083e170eda771126(int ce00d51a1fe36853f765e24d398dc3da9, float c11317036f2a0fb8f1dd4486f0d2bf05b)
	{
		float num = 0f;
		int num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable.Length;
		int num3 = ce00d51a1fe36853f765e24d398dc3da9 - 1;
		float powerRating;
		if (num3 < c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable.Length)
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
			powerRating = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable[num3].m_powerRating;
		}
		else
		{
			powerRating = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_progressionSetup.m_experienceTable[num2 - 1].m_powerRating;
		}
		num = powerRating;
		return c11317036f2a0fb8f1dd4486f0d2bf05b * num;
	}

	public Dictionary<string, WeaponCardDisplayType> cefb40e06b60c8f7c43d5935ac57ba968()
	{
		Dictionary<string, WeaponCardDisplayType> dictionary = new Dictionary<string, WeaponCardDisplayType>();
		int num = 0;
		for (int i = 0; i < m_subPartsCode.Length; i++)
		{
			SubPartWpn subPartWpn = SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(m_subPartsCode[i]);
			if (subPartWpn == null)
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
			if (!(subPartWpn.m_redline != string.Empty))
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
			if (subPartWpn.m_redlinePriority <= num)
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
			num = subPartWpn.m_redlinePriority;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			List<WeaponSubPart> list = new List<WeaponSubPart>();
			for (int j = 0; j < m_subPartsCode.Length; j++)
			{
				SubPartWpn subPartWpn2 = SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(m_subPartsCode[j]);
				if (subPartWpn2 == null)
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
				if (!(subPartWpn2.m_redline != string.Empty))
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
				if (subPartWpn2.m_redlinePriority <= 0)
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
				if (subPartWpn2.m_redlinePriority != num)
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
				list.Add(subPartWpn2.m_partType);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (m_attribute != null)
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
					string text = caa0b57b36eb0c67bce7f01c0e28d9b4f();
					if (text != null)
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
						dictionary.Add(text, WeaponCardDisplayType.ManufacturerWord);
					}
					if (IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ScopeMaskType) as IntAttributeValue) != 0)
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
						float num2 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomEndFOV) as FloatAttributeValue) / FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FirstPersonMeshFOV) as FloatAttributeValue);
						if (num2 > 1f)
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
							string key = num2.ToString("#0.0") + "x" + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("ZoomEndFOV"));
							dictionary.Add(key, WeaponCardDisplayType.ZoomWord);
						}
					}
					WeaponCardDisplayType c88ae38c42ce938f2f1541c191ab6a1be = WeaponCardDisplayType.FireWord;
					string text2 = c17dd17035267bc9584a31ac1245c5862(ref c88ae38c42ce938f2f1541c191ab6a1be);
					if (text2 != null)
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
						dictionary.Add(text2, c88ae38c42ce938f2f1541c191ab6a1be);
					}
				}
				List<SkillAttributeConfig> list2 = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.c7495388aceb7889e8ef8e2d021bdb97f(this);
				for (int k = 0; k < list2.Count; k++)
				{
					StringBuilder stringBuilder = new StringBuilder();
					if (list2[k].m_attrValue >= 0f)
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
						stringBuilder.Append("+");
					}
					if (SkillDisplayStore.c44a2b51cbcd8bf73167ba6a2f008a34b.m_skillDisplaySetup.cadef9a192fc5bdbc6abde1b1df3c3e98(list2[k].m_attrType) == DisplayType.Percentage)
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
						stringBuilder.Append(list2[k].m_attrValue.ToString("#0%"));
					}
					else
					{
						stringBuilder.Append(ca8150a0af60f4014c522d26d35999e17(list2[k].m_attrValue, list2[k].m_attrType).ToString());
					}
					stringBuilder.Append(" ");
					stringBuilder.Append(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(list2[k].m_attrType.ToString())));
					dictionary.Add(stringBuilder.ToString(), WeaponCardDisplayType.ExtraSlotWord);
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					return dictionary;
				}
			}
		}
	}

	private float ca8150a0af60f4014c522d26d35999e17(float cd3fd8cff9444e8e69036b2b139290946, EffectType c470c62d408de8861af01a7e0dbd93430)
	{
		if (c470c62d408de8861af01a7e0dbd93430 != EffectType.WeaponMaxHPPostAdd)
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
			if (c470c62d408de8861af01a7e0dbd93430 != EffectType.WeaponMaxShieldPostAdd)
			{
				return cd3fd8cff9444e8e69036b2b139290946;
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
		int num = (int)(cd3fd8cff9444e8e69036b2b139290946 * c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(m_level));
		return num;
	}

	public string c17dd17035267bc9584a31ac1245c5862(ref WeaponCardDisplayType c88ae38c42ce938f2f1541c191ab6a1be)
	{
		AttackInfo.ElementalType elementalType = (AttackInfo.ElementalType)IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalType) as IntAttributeValue);
		string result = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		switch (elementalType)
		{
		case AttackInfo.ElementalType.Fire:
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_Elem_Fire"));
			c88ae38c42ce938f2f1541c191ab6a1be = WeaponCardDisplayType.FireWord;
			break;
		case AttackInfo.ElementalType.Shock:
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_Elem_Electric"));
			c88ae38c42ce938f2f1541c191ab6a1be = WeaponCardDisplayType.ShockWord;
			break;
		case AttackInfo.ElementalType.Corrosive:
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_Elem_Corrosive"));
			c88ae38c42ce938f2f1541c191ab6a1be = WeaponCardDisplayType.CorrosiveWord;
			break;
		}
		return result;
	}

	public string caa0b57b36eb0c67bce7f01c0e28d9b4f()
	{
		switch ((ItemManufacturer)IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ManufactureType) as IntAttributeValue))
		{
		case ItemManufacturer.Vladof:
		{
			float num2 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRateIncrease) as FloatAttributeValue);
			if (!(num2 > 0f))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_Manu_Vladof"));
			}
		}
		case ItemManufacturer.Dahl:
		{
			int num3 = IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomFiringBurst) as IntAttributeValue);
			if (num3 <= 0)
			{
				break;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_Manu_Dahl"));
			}
		}
		case ItemManufacturer.Maliwan:
		{
			float num = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalProcCoef) as FloatAttributeValue);
			if (!(num >= 0.33f))
			{
				break;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				return LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_Manu_Maliwan"));
			}
		}
		}
		return null;
	}

	public string cd961f8d46c2b42b7e3b61920946d9f38(string cd70a189a19dc9356db14fb1010c2365a)
	{
		List<string> list = new List<string>();
		int num = 0;
		string result = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		SubPartWpn subPartWpn = SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(m_subPartsCode[0]);
		if (subPartWpn != null)
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
			if (subPartWpn.c8bcc550da88694617c77beaecf52f7ae(subPartWpn.m_partType))
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
				if (subPartWpn.m_partName != null)
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
					if (subPartWpn.m_namePriority >= num)
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
						if (subPartWpn.m_partName != cd70a189a19dc9356db14fb1010c2365a)
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
							result = subPartWpn.m_partName;
							num = subPartWpn.m_namePriority;
							list.Add(subPartWpn.m_partName);
						}
					}
				}
			}
		}
		for (int i = 0; i < m_extraEffectCount; i++)
		{
			for (int j = 0; j < ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList.Length; j++)
			{
				if (ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_rarity != c5681693ba1dda13f5ded7392b68c1e19())
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
				if (ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_effect != (EffectType)m_extraEffect[i])
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
				if (ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_index != m_extraEffectIndex[i])
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
				if (!(ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_partName != cd70a189a19dc9356db14fb1010c2365a))
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
				if (ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_namePriority > num)
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
					result = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_partName;
					num = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_namePriority;
					list.Clear();
				}
				if (ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_namePriority != num)
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
				if (ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_partName == null)
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
				list.Add(ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.m_effectSetups.m_extraAttrEffectList[j].m_partName);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_02a5;
				}
				continue;
				end_IL_02a5:
				break;
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (list.Count > 1)
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
				result = list[UnityEngine.Random.Range(0, list.Count)];
			}
			return result;
		}
	}

	public void c769c0065a21eb531d8917d0dd358768f()
	{
	}

	public BuildingUnit c0a44d3f083e360cf0185a2dac74d7e5e()
	{
		BuildingPart[] array = c015251fb9f02fd840fd03897a90706e4.c0a0cdf4a196914163f7334d9b0781a04(m_subPartsCode.Length);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new BuildingPart(SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(m_subPartsCode[i]));
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
			return new BuildingUnit(array);
		}
	}

	public byte c7f910426b3f87db67b8af4c62170e282(WeaponSubPart c60344406ce11ae1fafe3cb61fcb66cf2)
	{
		byte c872943035f78644fd01b267deff = SubPartStore.c2468dbf91d056d864da750fa5576bbef.c38e616c203dfa717c3386be3bb720a43(m_type, c60344406ce11ae1fafe3cb61fcb66cf2);
		return c0a44d3f083e360cf0185a2dac74d7e5e().c693accb7f953ed2c388675c890c1e685(c872943035f78644fd01b267deff).mFBX;
	}

	public static WeaponDNA cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		try
		{
			if (c591d56a94543e3559945c497f37126c4 == null)
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
						throw new Exception("data is NULL.");
					}
				}
			}
			WeaponDNA weaponDNA = new WeaponDNA();
			weaponDNA.m_level = (int)c591d56a94543e3559945c497f37126c4[1];
			weaponDNA.m_rarity = (WeaponRarity)(int)c591d56a94543e3559945c497f37126c4[2];
			weaponDNA.m_generationSource = (GenerationSource)(int)c591d56a94543e3559945c497f37126c4[3];
			weaponDNA.m_id = (int)c591d56a94543e3559945c497f37126c4[4];
			weaponDNA.m_name = (string)c591d56a94543e3559945c497f37126c4[6];
			weaponDNA.m_type = (WeaponType)(int)c591d56a94543e3559945c497f37126c4[7];
			weaponDNA.m_starLevel = (int)c591d56a94543e3559945c497f37126c4[17];
			weaponDNA.m_starExperience = (int)c591d56a94543e3559945c497f37126c4[18];
			for (int i = 0; i < weaponDNA.m_subPartsCode.Length; i++)
			{
				weaponDNA.m_subPartsCode[i] = SubPartWpn.cab05c97ab6dee558edc49d79f6a92ed1(weaponDNA.m_type, (WeaponSubPart)i, (int)c591d56a94543e3559945c497f37126c4[i + 8]);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				weaponDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
				return weaponDNA;
			}
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("Invalid Weapon Data: {0}", ex.Message));
			return cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	public override string ToString()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
		array[0] = m_name;
		array[1] = c83e548e5608cd7f222098a6966b16545();
		array[2] = m_level;
		array[3] = m_subPartsCode[0];
		array[4] = m_subPartsCode[1];
		array[5] = m_subPartsCode[2];
		array[6] = m_subPartsCode[3];
		return string.Format("{0} - {1} - {2} - {3} - {4:X} - {5} - {6}", array);
	}

	public override bool Equals(object obj)
	{
		WeaponDNA weaponDNA = obj as WeaponDNA;
		if (weaponDNA != null)
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
			if (m_name == weaponDNA.m_name)
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
				if (m_type == weaponDNA.m_type)
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
					if (m_id == weaponDNA.m_id)
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
						if (m_level == weaponDNA.m_level)
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
							if (m_subPartsCode.Length == weaponDNA.m_subPartsCode.Length)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										for (int i = 0; i < m_subPartsCode.Length; i++)
										{
											if (m_subPartsCode[i] != weaponDNA.m_subPartsCode[i])
											{
												while (true)
												{
													switch (1)
													{
													case 0:
														break;
													default:
														return false;
													}
												}
											}
										}
										while (true)
										{
											switch (6)
											{
											case 0:
												break;
											default:
												return true;
											}
										}
									}
									}
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = m_name.GetHashCode() ^ m_type.GetHashCode() ^ m_id.GetHashCode() ^ m_level.GetHashCode();
		for (int i = 0; i < m_subPartsCode.Length; i++)
		{
			num ^= m_subPartsCode[i].GetHashCode();
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
			return num;
		}
	}
}
