using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	public class TownNpc
	{
		private NpcOccupation[] m_occupationsField;

		public int m_id { get; set; }

		public string m_nameId { get; set; }

		public string m_greetingsId { get; set; }

		[XmlArrayItem("m_occupation", IsNullable = false)]
		public NpcOccupation[] m_occupations { get; set; }

		[DefaultValue(-1)]
		public int m_WeaponShopID { get; set; }

		[DefaultValue(-1)]
		public int m_CoinShieldShopID { get; set; }

		[DefaultValue(-1)]
		public int m_ClassModeShopID { get; set; }

		public TownNpc()
		{
			m_WeaponShopID = -1;
			m_CoinShieldShopID = -1;
			m_ClassModeShopID = -1;
		}
	}
}
