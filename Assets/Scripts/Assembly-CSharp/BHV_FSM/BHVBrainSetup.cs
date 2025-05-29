using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_FSM
{
	public class BHVBrainSetup
	{
		private BHVPropertySettings[] c708d8888d52afaa142a1a00133f2c3bb;

		private BHVPropertySettingsPhase[] c135858bf1271ea1be0692d9fa58e4ecb;

		[CompilerGenerated]
		private string c486cd7c0914f127032fe5b2cb1bd7424;

		[CompilerGenerated]
		private BHVPropertySettings[] c75f07c53bdb3ebc045f579d7fb8fdd8f;

		[CompilerGenerated]
		private BHVPropertySettingsPhase[] cf694418850b2e9eb90ebbeadb7bddd24;

		public string m_fsmType
		{
			[CompilerGenerated]
			get
			{
				return c486cd7c0914f127032fe5b2cb1bd7424;
			}
			[CompilerGenerated]
			set
			{
				c486cd7c0914f127032fe5b2cb1bd7424 = value;
			}
		}

		[XmlArrayItem("m_BHVPropertySettings", IsNullable = false)]
		public BHVPropertySettings[] m_BHVPropertySettingsList
		{
			[CompilerGenerated]
			get
			{
				return c75f07c53bdb3ebc045f579d7fb8fdd8f;
			}
			[CompilerGenerated]
			set
			{
				c75f07c53bdb3ebc045f579d7fb8fdd8f = value;
			}
		}

		[XmlArrayItem("m_BHVPropertySettingsPhase", IsNullable = false)]
		public BHVPropertySettingsPhase[] m_BHVPropertySettingsPhaseList
		{
			[CompilerGenerated]
			get
			{
				return cf694418850b2e9eb90ebbeadb7bddd24;
			}
			[CompilerGenerated]
			set
			{
				cf694418850b2e9eb90ebbeadb7bddd24 = value;
			}
		}
	}
}
