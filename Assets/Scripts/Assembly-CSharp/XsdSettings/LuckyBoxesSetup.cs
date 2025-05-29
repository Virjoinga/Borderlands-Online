using System.Xml.Serialization;

namespace XsdSettings
{
	public class LuckyBoxesSetup
	{
		private BoxRank[] m_boxRanksField;

		private LuckyBoxSettings[] m_luckyBoxesField;

		[XmlArrayItem("m_box", IsNullable = false)]
		public BoxRank[] m_boxRanks { get; set; }

		[XmlArrayItem("m_luckyBox", IsNullable = false)]
		public LuckyBoxSettings[] m_luckyBoxes { get; set; }
	}
}
