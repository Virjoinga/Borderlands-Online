using System.Collections.Generic;
using System.Xml.Serialization;
using A;
using UnityEngine;

namespace XsdSettings
{
	public class ExtraAttrEffectSetup
	{
		private ExtraAttrEffect[] m_extraAttrEffectListField;

		[XmlArrayItem("m_extraAttrEffect", IsNullable = false)]
		public ExtraAttrEffect[] m_extraAttrEffectList { get; set; }

		private int c9e47845f32adbdcafdffbd4bb34140e3(ItemRarity c0e27bf192c0de78c6cb54282d29f08d8, EffectType c470c62d408de8861af01a7e0dbd93430)
		{
			int num = 0;
			for (int i = 0; i < m_extraAttrEffectList.Length; i++)
			{
				if (m_extraAttrEffectList[i].m_rarity != c0e27bf192c0de78c6cb54282d29f08d8)
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
				if (m_extraAttrEffectList[i].m_effect != c470c62d408de8861af01a7e0dbd93430)
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
				num += m_extraAttrEffectList[i].m_probability;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				int num2 = Random.Range(0, num);
				int num3 = 0;
				for (int j = 0; j < m_extraAttrEffectList.Length; j++)
				{
					if (m_extraAttrEffectList[j].m_rarity != c0e27bf192c0de78c6cb54282d29f08d8)
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
					if (m_extraAttrEffectList[j].m_effect != c470c62d408de8861af01a7e0dbd93430)
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
					if (num2 < num3 + m_extraAttrEffectList[j].m_probability)
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
						if (num2 >= num3)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									return m_extraAttrEffectList[j].m_index;
								}
							}
						}
					}
					num3 += m_extraAttrEffectList[j].m_probability;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return int.MaxValue;
				}
			}
		}

		public int[] c7f598feb0b9cb42385696406189e52a3(ItemRarity c0e27bf192c0de78c6cb54282d29f08d8, int[] c4d811a46efa931327efc2a3d093c1b63)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < c4d811a46efa931327efc2a3d093c1b63.Length; i++)
			{
				list.Add(c9e47845f32adbdcafdffbd4bb34140e3(c0e27bf192c0de78c6cb54282d29f08d8, (EffectType)c4d811a46efa931327efc2a3d093c1b63[i]));
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
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(ItemDNA.m_extraEffectNums);
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 0;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					for (int k = 0; k < list.Count; k++)
					{
						array[k] = list[k];
					}
					while (true)
					{
						switch (3)
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
}
