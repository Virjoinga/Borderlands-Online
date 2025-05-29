using System.Xml.Serialization;

namespace XsdSettings
{
	public class ShieldRaritySetup
	{
		private ShieldRarityConfig[] m_shieldRaritiesField;

		[XmlArrayItem("m_shieldRarity", IsNullable = false)]
		public ShieldRarityConfig[] m_shieldRarities { get; set; }
	}
}
