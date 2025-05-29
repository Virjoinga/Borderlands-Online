namespace XsdSettings
{
	public class LootingLevelRange
	{
		private RandomLoots m_randomLootsField;

		private LootGroups m_lootGroupsField;

		public int m_levelMin { get; set; }

		public int m_levelMax { get; set; }

		public RandomLoots m_randomLoots { get; set; }

		public LootGroups m_lootGroups { get; set; }

		public LootingLevelRange()
		{
			m_levelMin = 1;
			m_levelMax = 10;
		}
	}
}
