using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	public class BHVFireStyleSettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private float c7e76027af4b3bada32e83a03df651c1b;

		[CompilerGenerated]
		private float cf0f1e691e644a4f56a4031113a8c48ea;

		[CompilerGenerated]
		private float cd51129835de61396c5e1d3d466f3f5de;

		[CompilerGenerated]
		private float cf5e251ce28494859a28ef5ff5f2f49ad;

		[CompilerGenerated]
		private float c43a7ef116297cb14ef0cfccfb6a23cf9;

		[CompilerGenerated]
		private float c4c722db893656e8c3efa0745cc3375b4;

		[CompilerGenerated]
		private bool cdf44782f1e99628803eb1ab143282059;

		[DefaultValue(typeof(float), "0.01")]
		public float m_burstSingle_FireTimeMin
		{
			[CompilerGenerated]
			get
			{
				return c7e76027af4b3bada32e83a03df651c1b;
			}
			[CompilerGenerated]
			set
			{
				c7e76027af4b3bada32e83a03df651c1b = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_burstSingle_FireTimeMax
		{
			[CompilerGenerated]
			get
			{
				return cf0f1e691e644a4f56a4031113a8c48ea;
			}
			[CompilerGenerated]
			set
			{
				cf0f1e691e644a4f56a4031113a8c48ea = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_IdleTimeMin
		{
			[CompilerGenerated]
			get
			{
				return cd51129835de61396c5e1d3d466f3f5de;
			}
			[CompilerGenerated]
			set
			{
				cd51129835de61396c5e1d3d466f3f5de = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_IdleTimeMax
		{
			[CompilerGenerated]
			get
			{
				return cf5e251ce28494859a28ef5ff5f2f49ad;
			}
			[CompilerGenerated]
			set
			{
				cf5e251ce28494859a28ef5ff5f2f49ad = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_FireTimeMin
		{
			[CompilerGenerated]
			get
			{
				return c43a7ef116297cb14ef0cfccfb6a23cf9;
			}
			[CompilerGenerated]
			set
			{
				c43a7ef116297cb14ef0cfccfb6a23cf9 = value;
			}
		}

		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_FireTimeMax
		{
			[CompilerGenerated]
			get
			{
				return c4c722db893656e8c3efa0745cc3375b4;
			}
			[CompilerGenerated]
			set
			{
				c4c722db893656e8c3efa0745cc3375b4 = value;
			}
		}

		[DefaultValue(false)]
		public bool m_canFallBackAfterFire
		{
			[CompilerGenerated]
			get
			{
				return cdf44782f1e99628803eb1ab143282059;
			}
			[CompilerGenerated]
			set
			{
				cdf44782f1e99628803eb1ab143282059 = value;
			}
		}

		public BHVFireStyleSettings()
		{
			m_burstSingle_FireTimeMin = 0.01f;
			m_burstSingle_FireTimeMax = 0.01f;
			m_burstChained_IdleTimeMin = 0.01f;
			m_burstChained_IdleTimeMax = 0.01f;
			m_burstChained_FireTimeMin = 0.01f;
			m_burstChained_FireTimeMax = 0.01f;
			m_canFallBackAfterFire = false;
		}
	}
}
