using System.Runtime.CompilerServices;

namespace BHV
{
	public class BHVRechargeSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private float ce87e5c556ac25f0c8330e54b94bf84b3;

		public float m_rechargeSpeed
		{
			[CompilerGenerated]
			get
			{
				return ce87e5c556ac25f0c8330e54b94bf84b3;
			}
			[CompilerGenerated]
			set
			{
				ce87e5c556ac25f0c8330e54b94bf84b3 = value;
			}
		}

		public BHVRechargeSettings()
		{
			m_rechargeSpeed = 1f;
		}
	}
}
