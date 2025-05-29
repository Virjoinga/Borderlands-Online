using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsFury : BHVPropertySettings
	{
		[CompilerGenerated]
		private int c7c31c817202bf133bde5ae69c31698b8;

		[DefaultValue(200)]
		public int m_startFuryHealthPoint
		{
			[CompilerGenerated]
			get
			{
				return c7c31c817202bf133bde5ae69c31698b8;
			}
			[CompilerGenerated]
			set
			{
				c7c31c817202bf133bde5ae69c31698b8 = value;
			}
		}

		public BHVFSMSettingsFury()
		{
			m_startFuryHealthPoint = 200;
		}
	}
}
