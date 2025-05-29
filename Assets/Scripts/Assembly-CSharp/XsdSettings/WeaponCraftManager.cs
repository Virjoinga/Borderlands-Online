using System.Xml.Serialization;

namespace XsdSettings
{
	public class WeaponCraftManager
	{
		private WeaponCraftConfig[] m_WeaponCraftConfigsField;

		[XmlArrayItem("m_WeaponCraftConfig", IsNullable = false)]
		public WeaponCraftConfig[] m_WeaponCraftConfigs { get; set; }
	}
}
