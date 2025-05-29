using System.Xml.Serialization;

namespace XsdSettings
{
	public class WeaponMeltManager
	{
		private WeaponMeltConfig[] m_WeaponMeltConfigsField;

		[XmlArrayItem("m_WeaponMeltConfig", IsNullable = false)]
		public WeaponMeltConfig[] m_WeaponMeltConfigs { get; set; }
	}
}
