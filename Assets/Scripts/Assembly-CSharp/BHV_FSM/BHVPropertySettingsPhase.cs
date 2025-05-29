using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_FSM
{
	[XmlInclude(typeof(BHVFSMSettingsSpiderantTalos))]
	[XmlInclude(typeof(BHVFSMSettingsApollyon))]
	[XmlInclude(typeof(BHVFSMSettingsCrimsonMechaKnoxx))]
	[XmlInclude(typeof(BHVFSMSettingsTheInsane))]
	[XmlInclude(typeof(BHVFSMSettingsSpiderantWidowmaker))]
	[XmlInclude(typeof(BHVFSMSettingsArchAngel))]
	public class BHVPropertySettingsPhase : BHVPropertySettings
	{
		[CompilerGenerated]
		private int c7ce37193a9e8cf74f74330b34cc20334;

		public int m_phaseId
		{
			[CompilerGenerated]
			get
			{
				return c7ce37193a9e8cf74f74330b34cc20334;
			}
			[CompilerGenerated]
			set
			{
				c7ce37193a9e8cf74f74330b34cc20334 = value;
			}
		}
	}
}
