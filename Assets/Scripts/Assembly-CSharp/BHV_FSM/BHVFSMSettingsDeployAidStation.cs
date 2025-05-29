using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsDeployAidStation : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c7a5f344a6ab2147e3a2f3be13b0ecbb2;

		[CompilerGenerated]
		private int cd2262a2451da38dc85612604247c1385;

		[CompilerGenerated]
		private float c494bc4fde5de5e6dbe2a6b7db9a6dbd4;

		[CompilerGenerated]
		private float ccef6e95b6a56d5efe4e5582db52a1278;

		public float m_deployChance
		{
			[CompilerGenerated]
			get
			{
				return c7a5f344a6ab2147e3a2f3be13b0ecbb2;
			}
			[CompilerGenerated]
			set
			{
				c7a5f344a6ab2147e3a2f3be13b0ecbb2 = value;
			}
		}

		public int m_healthPoints
		{
			[CompilerGenerated]
			get
			{
				return cd2262a2451da38dc85612604247c1385;
			}
			[CompilerGenerated]
			set
			{
				cd2262a2451da38dc85612604247c1385 = value;
			}
		}

		public float m_healRange
		{
			[CompilerGenerated]
			get
			{
				return c494bc4fde5de5e6dbe2a6b7db9a6dbd4;
			}
			[CompilerGenerated]
			set
			{
				c494bc4fde5de5e6dbe2a6b7db9a6dbd4 = value;
			}
		}

		public float m_healRate
		{
			[CompilerGenerated]
			get
			{
				return ccef6e95b6a56d5efe4e5582db52a1278;
			}
			[CompilerGenerated]
			set
			{
				ccef6e95b6a56d5efe4e5582db52a1278 = value;
			}
		}

		public BHVFSMSettingsDeployAidStation()
		{
			m_deployChance = 0.5f;
			m_healthPoints = 100;
			m_healRange = 10f;
			m_healRate = 10f;
		}
	}
}
