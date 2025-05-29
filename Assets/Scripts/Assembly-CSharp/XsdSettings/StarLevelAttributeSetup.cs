using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	public class StarLevelAttributeSetup
	{
		private StarLevelAttribute[] m_starLevelAttributeListField;

		[XmlArrayItem("m_starLevelAttribute", IsNullable = false)]
		public StarLevelAttribute[] m_starLevelAttributeList { get; set; }

		public List<SingleWeaponAttribute> c72d3a70da22effa82ba411b3671a0a3a(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370)
		{
			List<SingleWeaponAttribute> list = new List<SingleWeaponAttribute>();
			for (int i = 0; i < m_starLevelAttributeList.Length; i++)
			{
				if (m_starLevelAttributeList[i].m_weaponType != c27b7430edc94b8f5b543605119ec4a72)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				for (int j = 0; j < m_starLevelAttributeList[i].m_levelAttributeList.Length; j++)
				{
					if (m_starLevelAttributeList[i].m_levelAttributeList[j].m_starLevel >= cb28988bdc2f2c56c6f1f1f5f12f2f370)
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
					for (int k = 0; k < m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList.Length; k++)
					{
						list.Add(m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList[k]);
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
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return list;
			}
		}

		public List<SingleWeaponAttribute> c3c4c965dd8b39195a54e450ba7e26923(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370)
		{
			List<SingleWeaponAttribute> list = new List<SingleWeaponAttribute>();
			for (int i = 0; i < m_starLevelAttributeList.Length; i++)
			{
				if (m_starLevelAttributeList[i].m_weaponType != c27b7430edc94b8f5b543605119ec4a72)
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
				for (int j = 0; j < m_starLevelAttributeList[i].m_levelAttributeList.Length; j++)
				{
					if (m_starLevelAttributeList[i].m_levelAttributeList[j].m_starLevel != cb28988bdc2f2c56c6f1f1f5f12f2f370)
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
					for (int k = 0; k < m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList.Length; k++)
					{
						list.Add(m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList[k]);
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
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return list;
			}
		}
	}
}
