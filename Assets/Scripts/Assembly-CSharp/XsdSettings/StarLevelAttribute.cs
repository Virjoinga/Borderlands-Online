using System.Xml.Serialization;

namespace XsdSettings
{
	public class StarLevelAttribute
	{
		private WeaponType m_weaponTypeField;

		private levelAttribute[] m_levelAttributeListField;

		public WeaponType m_weaponType { get; set; }

		[XmlArrayItem("m_levelAttribute", IsNullable = false)]
		public levelAttribute[] m_levelAttributeList { get; set; }
	}
}
