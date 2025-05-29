using System.Xml.Serialization;

namespace XsdSettings
{
	public class LuckyBoxSettings
	{
		private RewardsPerDifficulty[] m_perDificultyListField;

		[XmlArrayItem("m_id", IsNullable = false)]
		public int[] m_playlists { get; set; }

		[XmlArrayItem("m_rewardPerDifficulty", IsNullable = false)]
		public RewardsPerDifficulty[] m_perDificultyList { get; set; }
	}
}
