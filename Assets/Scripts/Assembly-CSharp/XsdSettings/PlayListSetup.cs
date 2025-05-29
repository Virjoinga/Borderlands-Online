using System.Xml.Serialization;

namespace XsdSettings
{
	public class PlayListSetup
	{
		private Playlist[] m_playlistsField;

		[XmlArrayItem("m_playlist", IsNullable = false)]
		public Playlist[] m_playlists { get; set; }
	}
}
