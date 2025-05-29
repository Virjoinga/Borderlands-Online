using System.Xml.Serialization;

namespace XsdSettings
{
	public class StarLevelUpgradeSetup
	{
		private RarityDefaultValue[] m_rarityDefaultValueListField;

		private StarLevelUpgrade[] m_starLevelUpgradeField;

		[XmlArrayItem("m_rarityDefault", IsNullable = false)]
		public RarityDefaultValue[] m_rarityDefaultValueList { get; set; }

		[XmlArrayItem("m_starLevelUpgrade", IsNullable = false)]
		public StarLevelUpgrade[] m_starLevelUpgrade { get; set; }

		public int c15e38327c5b5eed2c917ce1e8b78d24a(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370, int cd41ab51966c5ff00c67973a4755d4730, WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5)
		{
			int num = 0;
			for (int i = 0; i < m_rarityDefaultValueList.Length; i++)
			{
				if (m_rarityDefaultValueList[i].m_weaponRarity != c335b432937e6c5b61e3fce114d6b6ca5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				num = m_rarityDefaultValueList[i].m_adjustValue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < m_starLevelUpgrade.Length; j++)
				{
					if (m_starLevelUpgrade[j].m_weaponType != c27b7430edc94b8f5b543605119ec4a72)
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
					for (int k = 0; k < m_starLevelUpgrade[j].m_starLevelConfigList.Length; k++)
					{
						if (m_starLevelUpgrade[j].m_starLevelConfigList[k].m_starLevel != cb28988bdc2f2c56c6f1f1f5f12f2f370)
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
							return m_starLevelUpgrade[j].m_starLevelConfigList[k].m_basicStarExp + cd41ab51966c5ff00c67973a4755d4730 * (cb28988bdc2f2c56c6f1f1f5f12f2f370 + 1) * num;
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
					switch (4)
					{
					case 0:
						continue;
					}
					return 0;
				}
			}
		}

		public ItemConsume cd1b950d28832dc51f746809d8f189d68(WeaponType c27b7430edc94b8f5b543605119ec4a72, int cb28988bdc2f2c56c6f1f1f5f12f2f370)
		{
			for (int i = 0; i < m_starLevelUpgrade.Length; i++)
			{
				if (m_starLevelUpgrade[i].m_weaponType != c27b7430edc94b8f5b543605119ec4a72)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				for (int j = 0; j < m_starLevelUpgrade[i].m_starLevelConfigList.Length; j++)
				{
					if (m_starLevelUpgrade[i].m_starLevelConfigList[j].m_starLevel != cb28988bdc2f2c56c6f1f1f5f12f2f370)
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
						return m_starLevelUpgrade[i].m_starLevelConfigList[j].m_itemConsume;
					}
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
				return null;
			}
		}
	}
}
