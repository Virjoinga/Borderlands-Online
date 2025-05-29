using System.Xml.Serialization;

namespace XsdSettings
{
	[XmlInclude(typeof(ScoringSetupPVE))]
	[XmlInclude(typeof(ScoringBase))]
	[XmlInclude(typeof(ScoringSetupPVP))]
	public class ScoringType
	{
	}
}
