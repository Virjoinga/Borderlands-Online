using System.ComponentModel;

namespace XsdSettings
{
	public class QuestReward
	{
		public QuestRewardType mType { get; set; }

		[DefaultValue(0)]
		public int mRewardID { get; set; }

		[DefaultValue(MaterialType.MT_Titanium)]
		public MaterialType mMaterialType { get; set; }

		[DefaultValue(1)]
		public int mCount { get; set; }

		public QuestReward()
		{
			mType = QuestRewardType.Item;
			mRewardID = 0;
			mMaterialType = MaterialType.MT_Titanium;
			mCount = 1;
		}
	}
}
