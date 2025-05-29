using System.Xml.Serialization;

namespace XsdSettings
{
	public class ControlScheme
	{
		private KeyBindingItem[] mKeyBindingListField;

		public string mID { get; set; }

		[XmlArrayItem("mKeyBindings", IsNullable = false)]
		public KeyBindingItem[] mKeyBindingList { get; set; }
	}
}
