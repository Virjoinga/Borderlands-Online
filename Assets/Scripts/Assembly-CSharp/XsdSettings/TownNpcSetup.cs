using System.Xml.Serialization;

namespace XsdSettings
{
	public class TownNpcSetup
	{
		private TownNpc[] m_npcsField;

		[XmlArrayItem("m_npc", IsNullable = false)]
		public TownNpc[] m_npcs { get; set; }
	}
}
