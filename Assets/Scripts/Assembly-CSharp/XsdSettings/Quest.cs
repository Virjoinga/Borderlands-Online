using System.Xml.Serialization;

namespace XsdSettings
{
	public class Quest
	{
		private QuestReward[] mRewardsField;

		private QuestTask[] mTasksField;

		public int mId { get; set; }

		[XmlArrayItem("m_int", IsNullable = false)]
		public int[] mGiverIdList { get; set; }

		[XmlArrayItem("m_int", IsNullable = false)]
		public int[] mReclaimerIdList { get; set; }

		public bool mIsBoundInstance { get; set; }

		[XmlArrayItem("m_int", IsNullable = false)]
		public int[] mBoundInstanceList { get; set; }

		public QuestCategory mCategory { get; set; }

		public string mTitle { get; set; }

		public string mDescription { get; set; }

		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mAvailableDialog { get; set; }

		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mInProgressDialog { get; set; }

		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mCompletedDialog { get; set; }

		public int mRequiredDifficulty { get; set; }

		public sbyte mRequiredLevel { get; set; }

		public sbyte mHighestLevel { get; set; }

		public sbyte mUnlockLevel { get; set; }

		[XmlArrayItem("mReward", IsNullable = false)]
		public QuestReward[] mRewards { get; set; }

		[XmlArrayItem("mTask", IsNullable = false)]
		public QuestTask[] mTasks { get; set; }

		public Quest()
		{
			mId = 0;
			mIsBoundInstance = true;
			mCategory = QuestCategory.Story;
			mRequiredDifficulty = -1;
			mRequiredLevel = 1;
			mHighestLevel = 0;
			mUnlockLevel = 0;
		}
	}
}
