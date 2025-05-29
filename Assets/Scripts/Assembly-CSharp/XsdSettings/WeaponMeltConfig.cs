using System.Xml.Serialization;

namespace XsdSettings
{
	public class WeaponMeltConfig
	{
		private WeaponRarity m_WeaponRarityField;

		private WeaponType m_WeaponTypeField;

		private AcquiredMaterial[] m_AcquiredMaterialsField;

		public int m_MinWeaponLevel { get; set; }

		public int m_MaxWeaponLevel { get; set; }

		public WeaponRarity m_WeaponRarity { get; set; }

		public WeaponType m_WeaponType { get; set; }

		[XmlArrayItem("m_AcquiredMaterial", IsNullable = false)]
		public AcquiredMaterial[] m_AcquiredMaterials { get; set; }
	}
}
