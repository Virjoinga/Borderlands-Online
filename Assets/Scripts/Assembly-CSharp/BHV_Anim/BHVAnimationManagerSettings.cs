using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_Anim
{
	public class BHVAnimationManagerSettings
	{
		[CompilerGenerated]
		private string cd9d8bbfd0db89bd3aef3555c193b1328;

		[CompilerGenerated]
		private string c0b01ff5539d91a794f0ea55238353a6c;

		[CompilerGenerated]
		private bool c8dcc8bfcfe19078c4360272791c070bf;

		[CompilerGenerated]
		private string c57519445d3375af65cacaeb8f3ceeb03;

		[CompilerGenerated]
		private float c87a100c732b7b012c0ca527df305c2b4;

		[CompilerGenerated]
		private int c87b257c486dc0e859a7def1576692dc4;

		[CompilerGenerated]
		private int ca1d0c68df1f4d7cc06db6baece81cb37;

		[CompilerGenerated]
		private float c8052efc2de8c4106ab59fe8dadbdd3fe;

		[CompilerGenerated]
		private bool c46026ec981815a23746899a27efd8808;

		[DefaultValue("")]
		public string m_weaponHolderName
		{
			[CompilerGenerated]
			get
			{
				return cd9d8bbfd0db89bd3aef3555c193b1328;
			}
			[CompilerGenerated]
			set
			{
				cd9d8bbfd0db89bd3aef3555c193b1328 = value;
			}
		}

		[DefaultValue("")]
		public string m_weaponPrefabName
		{
			[CompilerGenerated]
			get
			{
				return c0b01ff5539d91a794f0ea55238353a6c;
			}
			[CompilerGenerated]
			set
			{
				c0b01ff5539d91a794f0ea55238353a6c = value;
			}
		}

		[DefaultValue(false)]
		public bool m_hasDeathAnimation
		{
			[CompilerGenerated]
			get
			{
				return c8dcc8bfcfe19078c4360272791c070bf;
			}
			[CompilerGenerated]
			set
			{
				c8dcc8bfcfe19078c4360272791c070bf = value;
			}
		}

		[DefaultValue("")]
		public string m_animationHostName
		{
			[CompilerGenerated]
			get
			{
				return c57519445d3375af65cacaeb8f3ceeb03;
			}
			[CompilerGenerated]
			set
			{
				c57519445d3375af65cacaeb8f3ceeb03 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_animationSpeedFactor
		{
			[CompilerGenerated]
			get
			{
				return c87a100c732b7b012c0ca527df305c2b4;
			}
			[CompilerGenerated]
			set
			{
				c87a100c732b7b012c0ca527df305c2b4 = value;
			}
		}

		[DefaultValue(0)]
		public int m_normalDeathAnimCount
		{
			[CompilerGenerated]
			get
			{
				return c87b257c486dc0e859a7def1576692dc4;
			}
			[CompilerGenerated]
			set
			{
				c87b257c486dc0e859a7def1576692dc4 = value;
			}
		}

		[DefaultValue(0)]
		public int m_headShotDeathAnimCount
		{
			[CompilerGenerated]
			get
			{
				return ca1d0c68df1f4d7cc06db6baece81cb37;
			}
			[CompilerGenerated]
			set
			{
				ca1d0c68df1f4d7cc06db6baece81cb37 = value;
			}
		}

		public float m_invisibleChance
		{
			[CompilerGenerated]
			get
			{
				return c8052efc2de8c4106ab59fe8dadbdd3fe;
			}
			[CompilerGenerated]
			set
			{
				c8052efc2de8c4106ab59fe8dadbdd3fe = value;
			}
		}

		[XmlIgnore]
		public bool m_invisibleChanceSpecified
		{
			[CompilerGenerated]
			get
			{
				return c46026ec981815a23746899a27efd8808;
			}
			[CompilerGenerated]
			set
			{
				c46026ec981815a23746899a27efd8808 = value;
			}
		}

		public BHVAnimationManagerSettings()
		{
			m_weaponHolderName = string.Empty;
			m_weaponPrefabName = string.Empty;
			m_hasDeathAnimation = false;
			m_animationHostName = string.Empty;
			m_animationSpeedFactor = 1f;
			m_normalDeathAnimCount = 0;
			m_headShotDeathAnimCount = 0;
		}
	}
}
