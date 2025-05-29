using System.Xml.Serialization;

namespace XsdSettings
{
	public class ControlSchemeSetup
	{
		private ControlScheme[] mControlSchemeListField;

		[XmlArrayItem("mControlScheme", IsNullable = false)]
		public ControlScheme[] mControlSchemeList { get; set; }
	}
}
