using System.Xml.Serialization;

namespace XsdSettings
{
	public class ShopSetup
	{
		private Shop[] m_shopsField;

		public float m_soldRatio { get; set; }

		[XmlArrayItem("m_shop", IsNullable = false)]
		public Shop[] m_shops { get; set; }

		public ShopSetup()
		{
			m_soldRatio = 0.5f;
		}
	}
}
