using System.Xml.Serialization;

namespace XsdSettings
{
	public class CharacterStoreSetup
	{
		private CharacterSetup[] m_characterSetupsField;

		[XmlArrayItem("m_characterSetup", IsNullable = false)]
		public CharacterSetup[] m_characterSetups { get; set; }
	}
}
