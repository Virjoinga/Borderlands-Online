using System.Xml.Serialization;

namespace XsdSettings
{
	public class SettingMenuSetup
	{
		private Category[] settingsField;

		[XmlArrayItem("mCategory", IsNullable = false)]
		public Category[] Settings { get; set; }
	}
}
