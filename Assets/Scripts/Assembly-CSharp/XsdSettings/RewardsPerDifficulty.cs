using System.Xml.Serialization;

namespace XsdSettings
{
	public class RewardsPerDifficulty
	{
		private RewardPerGrade[] m_rewardsField;

		public ELevelDifficulty m_difficulty { get; set; }

		[XmlArrayItem("m_reward", IsNullable = false)]
		public RewardPerGrade[] m_rewards { get; set; }

		public RewardsPerDifficulty()
		{
			m_difficulty = ELevelDifficulty.Normal;
		}
	}
}
