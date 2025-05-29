using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	public class EchoMessage
	{
		private DisplayTarget[] m_displayTargetsField;

		public string m_id { get; set; }

		[XmlArrayItem("m_target", IsNullable = false)]
		public DisplayTarget[] m_displayTargets { get; set; }

		public string m_localizedText { get; set; }

		[DefaultValue("")]
		public string m_npcIcon { get; set; }

		public EchoMessage()
		{
			m_id = string.Empty;
			m_localizedText = "localized text";
			m_npcIcon = string.Empty;
		}
	}
}
