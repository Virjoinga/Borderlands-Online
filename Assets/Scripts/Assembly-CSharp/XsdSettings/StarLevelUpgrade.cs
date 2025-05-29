using System.Xml.Serialization;

namespace XsdSettings
{
	public class StarLevelUpgrade
	{
		private WeaponType m_weaponTypeField;

		private StarLevelConfig[] m_starLevelConfigListField;

		public WeaponType m_weaponType { get; set; }

		[XmlArrayItem("m_starLevelConfig", IsNullable = false)]
		public StarLevelConfig[] m_starLevelConfigList { get; set; }
	}
}
