using System.Collections.Generic;
using System.Xml.Serialization;
using A;
using UnityEngine;

namespace XsdSettings
{
	public class ExtraAttrLevelEffectSetup
	{
		private ExtraAttrLevelEffect[] m_extraAttrLevelEffectListField;

		[XmlArrayItem("m_extraAttrLevelEffect", IsNullable = false)]
		public ExtraAttrLevelEffect[] m_extraAttrLevelEffectList { get; set; }

		public int[] cb5ca053b99d0243a3db761c01bcca458(ItemRarity c0e27bf192c0de78c6cb54282d29f08d8, int cd6bb591c33b2ee3ab93e98aa43a6da63, int cf0a89fb854702aa2ad81f6b398540931, List<EffectType> c0ed5b89d0ab6e7467f7dc02136938fd0 = null)
		{
			List<ExtraAttrLevelEffect> list = new List<ExtraAttrLevelEffect>();
			for (int i = 0; i < m_extraAttrLevelEffectList.Length; i++)
			{
				if (m_extraAttrLevelEffectList[i].m_rarity != c0e27bf192c0de78c6cb54282d29f08d8)
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
				if (cd6bb591c33b2ee3ab93e98aa43a6da63 < m_extraAttrLevelEffectList[i].m_minLevel)
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
				if (cd6bb591c33b2ee3ab93e98aa43a6da63 > m_extraAttrLevelEffectList[i].m_maxLevel)
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
				bool flag = false;
				if (c0ed5b89d0ab6e7467f7dc02136938fd0 != null)
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
					for (int j = 0; j < c0ed5b89d0ab6e7467f7dc02136938fd0.Count; j++)
					{
						if (c0ed5b89d0ab6e7467f7dc02136938fd0[j] != m_extraAttrLevelEffectList[i].m_effectType)
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
						flag = true;
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
				}
				if (flag)
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
				list.Add(m_extraAttrLevelEffectList[i]);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				List<int> list2 = new List<int>();
				while (cf0a89fb854702aa2ad81f6b398540931 > 0)
				{
					int num = 0;
					for (int k = 0; k < list.Count; k++)
					{
						num += list[k].m_probability;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						int num2 = Random.Range(0, num);
						int num3 = 0;
						int num4 = 0;
						while (true)
						{
							if (num4 < list.Count)
							{
								if (num2 < num3 + list[num4].m_probability)
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
									if (num2 >= num3)
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
										list2.Add((int)list[num4].m_effectType);
										list.RemoveAt(num4);
										break;
									}
								}
								num3 += list[num4].m_probability;
								num4++;
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
						cf0a89fb854702aa2ad81f6b398540931--;
						break;
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(ItemDNA.m_extraEffectNums);
					for (int l = 0; l < array.Length; l++)
					{
						array[l] = 0;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						for (int m = 0; m < list2.Count; m++)
						{
							array[m] = list2[m];
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							return array;
						}
					}
				}
			}
		}

		public List<EffectType> c30cd75126640615344dee0f37f795baa(ulong c75de53d9f069393deb89711c791e0784)
		{
			List<EffectType> list = new List<EffectType>();
			for (int i = 0; i < 8; i++)
			{
				list.Add((EffectType)(c75de53d9f069393deb89711c791e0784 & 0xFF));
				c75de53d9f069393deb89711c791e0784 >>= 8;
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
				return list;
			}
		}
	}
}
