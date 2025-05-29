using System.Xml.Serialization;

namespace XsdSettings
{
	public class EchoMessagesSetup
	{
		private EchoMessage[] m_messagesField;

		[XmlArrayItem("m_message", IsNullable = false)]
		public EchoMessage[] m_messages { get; set; }
	}
}
