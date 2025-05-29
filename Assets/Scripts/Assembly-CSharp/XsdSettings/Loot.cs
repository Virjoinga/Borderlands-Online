using System.ComponentModel;

namespace XsdSettings
{
	public class Loot
	{
		private ItemType m_lootTypeField;

		public bool c2f80f246c1eec4ba85242786c5be44d0
		{
			get
			{
				return WeaponType.TOTAL != m_weaponType;
			}
		}

		public bool c15aacc545e50a85a60a2e5823d3e74c9
		{
			get
			{
				return MaterialType.TOTAL != m_materialType;
			}
		}

		public bool cf00b9d93d68249c53b28d9aa72a31569
		{
			get
			{
				return AmmoType.TOTAL != m_ammoType;
			}
		}

		public bool c257ec2518777a53cf7d316179e4502b6
		{
			get
			{
				return ItemRarity.TOTAL != m_itemRarity;
			}
		}

		public bool c92933aaf6a3caedbea8ac222402cc1f8
		{
			get
			{
				return m_weaponID != 0;
			}
		}

		public ItemType m_lootType { get; set; }

		public int m_lootProbability { get; set; }

		[DefaultValue(0)]
		public int m_lootQuantity { get; set; }

		public int m_weaponID { get; set; }

		public WeaponType m_weaponType { get; set; }

		public WeaponRarity m_weaponRarity { get; set; }

		public MaterialType m_materialType { get; set; }

		public AmmoType m_ammoType { get; set; }

		public ItemRarity m_itemRarity { get; set; }

		public Loot()
		{
			m_lootProbability = 1;
			m_lootQuantity = 0;
			m_weaponID = 0;
			m_weaponType = WeaponType.TOTAL;
			m_weaponRarity = WeaponRarity.TOTAL;
			m_materialType = MaterialType.TOTAL;
			m_ammoType = AmmoType.TOTAL;
			m_itemRarity = ItemRarity.TOTAL;
		}
	}
}
