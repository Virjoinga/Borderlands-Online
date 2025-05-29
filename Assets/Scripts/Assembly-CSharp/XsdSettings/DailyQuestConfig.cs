using System.Xml.Serialization;

namespace XsdSettings
{
	public class DailyQuestConfig
	{
		private LevelDailyQuest[] mLevelDailyQuestListField;

		public int mMaxAcceptDailyQuestCount { get; set; }

		[XmlArrayItem("mLevelDailyQuest", IsNullable = false)]
		public LevelDailyQuest[] mLevelDailyQuestList { get; set; }

		public DailyQuestConfig()
		{
			mMaxAcceptDailyQuestCount = 5;
		}
	}
}
