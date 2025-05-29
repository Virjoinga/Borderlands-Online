using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	public class QuestTask
	{
		public int mTaskId { get; set; }

		public string mDescription { get; set; }

		public QuestTaskType mType { get; set; }

		public int mTarget { get; set; }

		public int mTimeLimit { get; set; }

		[DefaultValue(QuestEnemyType.AnyBandit)]
		public QuestEnemyType mTargetId { get; set; }

		[DefaultValue(QuestAttackType.Any)]
		public QuestAttackType mAttackId { get; set; }

		[DefaultValue(MaterialType.MT_Titanium)]
		public MaterialType mMaterialType { get; set; }

		[DefaultValue(1)]
		public int mMaterialCount { get; set; }

		[DefaultValue(ItemType.NA)]
		public ItemType mItemType { get; set; }

		[DefaultValue(0)]
		public int mItemID { get; set; }

		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mTaskEchoIDList { get; set; }

		public QuestTask()
		{
			mTaskId = 0;
			mType = QuestTaskType.Instance;
			mTarget = 0;
			mTimeLimit = 0;
			mTargetId = QuestEnemyType.AnyBandit;
			mAttackId = QuestAttackType.Any;
			mMaterialType = MaterialType.MT_Titanium;
			mMaterialCount = 1;
			mItemType = ItemType.NA;
			mItemID = 0;
		}
	}
}
