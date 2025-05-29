using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;

namespace BHV_Skill
{
	public class BHVSkillSetup
	{
		private Dictionary<Type, BHVSkillSettings> cdc9012cd21aba43c660d610ebd1b159e;

		private BHVSkillSettings[] c305aaef8d56d5b1f02fda09469963853;

		[CompilerGenerated]
		private BHVSkillSettings[] c060f3f139026189a4d6cac9b07b0f03e;

		[XmlArrayItem("m_skillSettings", IsNullable = false)]
		public BHVSkillSettings[] m_settings
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

		public void ccc9d3a38966dc10fedb531ea17d24611()
		{
			if (m_settings.Length <= 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			cdc9012cd21aba43c660d610ebd1b159e = new Dictionary<Type, BHVSkillSettings>(m_settings.Length);
			for (int i = 0; i < m_settings.Length; i++)
			{
				cdc9012cd21aba43c660d610ebd1b159e.Add(m_settings[i].GetType(), m_settings[i]);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		public c272566d4edbf24bb8c4df6114a524ac9 cd3d8b35d2647005675ba92178c253805<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : BHVSkillSettings
		{
			BHVSkillSettings value = cc17b98e4ab5fa6ebc33e94ffa03a0564.c7088de59e49f7108f520cf7e0bae167e;
			cdc9012cd21aba43c660d610ebd1b159e.TryGetValue(typeof(c272566d4edbf24bb8c4df6114a524ac9), out value);
			return (c272566d4edbf24bb8c4df6114a524ac9)value;
		}
	}
}
