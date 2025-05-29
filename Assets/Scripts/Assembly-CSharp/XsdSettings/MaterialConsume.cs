using System.Xml.Serialization;

namespace XsdSettings
{
	public class MaterialConsume
	{
		private WeaponType m_weaponTypeField;

		private ConsumedMaterial[] m_consumedMaterialListField;

		public WeaponType m_weaponType { get; set; }

		[XmlArrayItem("m_consumedMaterial", IsNullable = false)]
		public ConsumedMaterial[] m_consumedMaterialList { get; set; }
	}
}
