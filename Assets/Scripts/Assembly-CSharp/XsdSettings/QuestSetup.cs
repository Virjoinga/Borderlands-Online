using System.Xml.Serialization;

namespace XsdSettings
{
	public class QuestSetup
	{
		private Quest[] mQuestsField;

		[XmlArrayItem("mQuest", IsNullable = false)]
		public Quest[] mQuests { get; set; }
	}
}
