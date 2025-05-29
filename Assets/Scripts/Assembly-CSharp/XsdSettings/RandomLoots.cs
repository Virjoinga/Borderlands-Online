using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	public class RandomLoots
	{
		private Loot[] m_lootListField;

		[DefaultValue(5)]
		public int m_lootMax { get; set; }

		[XmlArrayItem("m_loot", IsNullable = false)]
		public Loot[] m_lootList { get; set; }

		public RandomLoots()
		{
			m_lootMax = 5;
		}
	}
}
