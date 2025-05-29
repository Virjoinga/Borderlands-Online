using System.ComponentModel;

namespace XsdSettings
{
	public class GuidanceTip
	{
		public string m_id { get; set; }

		public string m_echoMsgId { get; set; }

		public TipTrigger m_trigger { get; set; }

		[DefaultValue(1)]
		public int m_value { get; set; }

		public GuidanceTip()
		{
			m_trigger = TipTrigger.LevelUp;
			m_value = 1;
		}
	}
}
