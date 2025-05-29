using System.Xml.Serialization;

namespace XsdSettings
{
	public class Playlist
	{
		public int m_id { get; set; }

		public string m_name { get; set; }

		public string m_gameMode { get; set; }

		public int m_maxPlayerCount { get; set; }

		public int m_minPlayerCountToStart { get; set; }

		[XmlArrayItem("m_scene", IsNullable = false)]
		public string[] m_sceneToPlay { get; set; }

		public string m_bossName { get; set; }

		public int m_normal_LevelMin { get; set; }

		public int m_normal_LevelMax { get; set; }

		public int m_hard_LevelMin { get; set; }

		public int m_hard_LevelMax { get; set; }

		public int m_hell_LevelMin { get; set; }

		public int m_hell_LevelMax { get; set; }

		public int m_normal_Exp { get; set; }

		public int m_hard_Exp { get; set; }

		public int m_hell_Exp { get; set; }

		public Playlist()
		{
			m_maxPlayerCount = 4;
			m_minPlayerCountToStart = 1;
			m_bossName = string.Empty;
			m_normal_LevelMin = 1;
			m_normal_LevelMax = 10;
			m_hard_LevelMin = 10;
			m_hard_LevelMax = 20;
			m_hell_LevelMin = 20;
			m_hell_LevelMax = 25;
			m_normal_Exp = 0;
			m_hard_Exp = 0;
			m_hell_Exp = 0;
		}
	}
}
