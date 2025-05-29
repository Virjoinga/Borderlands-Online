namespace XsdSettings
{
	public class ExtraAttrLevelEffect
	{
		private EffectType m_effectTypeField;

		private ItemRarity m_rarityField;

		public int m_minLevel { get; set; }

		public int m_maxLevel { get; set; }

		public EffectType m_effectType { get; set; }

		public int m_probability { get; set; }

		public ItemRarity m_rarity { get; set; }
	}
}
