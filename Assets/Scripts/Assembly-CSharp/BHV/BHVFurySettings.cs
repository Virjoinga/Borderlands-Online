using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	public class BHVFurySettings : BHVTaskSettings
	{
		[CompilerGenerated]
		private float c679d74e7be3e249d59eb5a83c20cde94;

		[DefaultValue(typeof(float), "1")]
		public float m_damageModifier
		{
			[CompilerGenerated]
			get
			{
				return c679d74e7be3e249d59eb5a83c20cde94;
			}
			[CompilerGenerated]
			set
			{
				c679d74e7be3e249d59eb5a83c20cde94 = value;
			}
		}

		public BHVFurySettings()
		{
			m_damageModifier = 1f;
		}
	}
}
