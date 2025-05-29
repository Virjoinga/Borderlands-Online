using System.Xml.Serialization;

namespace XsdSettings
{
	public class levelAttribute
	{
		private SingleWeaponAttribute[] m_weaponAttributeListField;

		public int m_starLevel { get; set; }

		[XmlArrayItem("m_weaponAttribute", IsNullable = false)]
		public SingleWeaponAttribute[] m_weaponAttributeList { get; set; }
	}
}
