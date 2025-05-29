using System.Xml.Serialization;
using UnityEngine;

namespace XsdSettings
{
	public class ExtraAttrSlotSetup
	{
		private ExtraAttrSlot[] m_extraAttrSlotListField;

		[XmlArrayItem("m_extraAttrSlot", IsNullable = false)]
		public ExtraAttrSlot[] m_extraAttrSlotList { get; set; }

		public int ca5ac08b3168426e78e2b436f7817c886(ItemRarity c0e27bf192c0de78c6cb54282d29f08d8)
		{
			int num = 0;
			for (int i = 0; i < m_extraAttrSlotList.Length; i++)
			{
				if (m_extraAttrSlotList[i].m_rarity != c0e27bf192c0de78c6cb54282d29f08d8)
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
				num += m_extraAttrSlotList[i].m_probability;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				int num2 = Random.Range(0, num);
				int num3 = 0;
				for (int j = 0; j < m_extraAttrSlotList.Length; j++)
				{
					if (m_extraAttrSlotList[j].m_rarity != c0e27bf192c0de78c6cb54282d29f08d8)
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
					if (num2 < num3 + m_extraAttrSlotList[j].m_probability)
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
						if (num2 >= num3)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									return m_extraAttrSlotList[j].m_slotNum;
								}
							}
						}
					}
					num3 += m_extraAttrSlotList[j].m_probability;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return 0;
				}
			}
		}
	}
}
