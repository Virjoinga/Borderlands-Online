using System.Xml.Serialization;

namespace XsdSettings
{
	public class StarExpUpgradeSetup
	{
		private MaterialConsume[] m_materialConsumeListField;

		public int m_rewardValue { get; set; }

		[XmlArrayItem("m_materialConsume", IsNullable = false)]
		public MaterialConsume[] m_materialConsumeList { get; set; }

		public ConsumedMaterial[] c427b782717fb7214fcc0f2cf5778100a(WeaponType c27b7430edc94b8f5b543605119ec4a72)
		{
			for (int i = 0; i < m_materialConsumeList.Length; i++)
			{
				if (m_materialConsumeList[i].m_weaponType != c27b7430edc94b8f5b543605119ec4a72)
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
					return m_materialConsumeList[i].m_consumedMaterialList;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return null;
			}
		}
	}
}
