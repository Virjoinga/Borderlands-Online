using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV
{
	public class BHVTaskManagerSetup
	{
		[XmlIgnore]
		public Dictionary<Type, BHVTaskSettings> cdc9012cd21aba43c660d610ebd1b159e = new Dictionary<Type, BHVTaskSettings>();

		private BHVTaskSettings[] c305aaef8d56d5b1f02fda09469963853;

		[CompilerGenerated]
		private BHVTaskSettings[] c060f3f139026189a4d6cac9b07b0f03e;

		[CompilerGenerated]
		private string c275d28fc5f03603a4d3de12fcaf053db;

		[XmlArrayItem("m_taskSettings", IsNullable = false)]
		public BHVTaskSettings[] m_settings
		{
			[CompilerGenerated]
			get
			{
				return c060f3f139026189a4d6cac9b07b0f03e;
			}
			[CompilerGenerated]
			set
			{
				c060f3f139026189a4d6cac9b07b0f03e = value;
			}
		}

		public string m_entityType
		{
			[CompilerGenerated]
			get
			{
				return c275d28fc5f03603a4d3de12fcaf053db;
			}
			[CompilerGenerated]
			set
			{
				c275d28fc5f03603a4d3de12fcaf053db = value;
			}
		}

		public void c088702f4b6cd07e179f719732c55051f()
		{
			if (m_settings == null)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (m_settings.Length <= 0)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				for (int i = 0; i < m_settings.Length; i++)
				{
					cdc9012cd21aba43c660d610ebd1b159e.Add(m_settings[i].GetType(), m_settings[i]);
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
