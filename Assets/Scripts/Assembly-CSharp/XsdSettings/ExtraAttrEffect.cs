using System.Xml.Serialization;

namespace XsdSettings
{
	public class ExtraAttrEffect
	{
		private ItemRarity m_rarityField;

		private EffectType m_effectField;

		private AffectType m_affectTypeField;

		public ItemRarity m_rarity { get; set; }

		public EffectType m_effect { get; set; }

		public byte m_index { get; set; }

		public AffectType m_affectType { get; set; }

		public float m_attributeValue { get; set; }

		public int m_probability { get; set; }

		public string m_partName { get; set; }

		public int m_namePriority { get; set; }

		[XmlIgnore]
		public bool m_namePrioritySpecified { get; set; }
	}
}
