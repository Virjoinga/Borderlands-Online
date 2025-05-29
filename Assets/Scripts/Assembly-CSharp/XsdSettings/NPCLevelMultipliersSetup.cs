using System.Xml.Serialization;

namespace XsdSettings
{
	public class NPCLevelMultipliersSetup
	{
		private NPCLevelMultipliers[] m_NPCLevelMultipliersListField;

		[XmlArrayItem("m_NPCLevelMultipliers", IsNullable = false)]
		public NPCLevelMultipliers[] m_NPCLevelMultipliersList { get; set; }
	}
}
