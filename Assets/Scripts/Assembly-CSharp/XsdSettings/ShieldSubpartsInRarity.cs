using System.Xml.Serialization;

namespace XsdSettings
{
	public class ShieldSubpartsInRarity
	{
		private ShieldSubPart m_shieldSubpartField;

		private ShieldSubpartChoice[] m_subpartChoicesField;

		public ShieldSubPart m_shieldSubpart { get; set; }

		[XmlArrayItem("m_subpartChoice", IsNullable = false)]
		public ShieldSubpartChoice[] m_subpartChoices { get; set; }
	}
}
