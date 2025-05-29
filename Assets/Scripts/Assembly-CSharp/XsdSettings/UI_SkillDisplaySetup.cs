using System.Collections.Generic;
using System.Xml.Serialization;
using Core;

namespace XsdSettings
{
	public class UI_SkillDisplaySetup
	{
		private Dictionary<EffectType, DisplayType> m_skillDisplayLUT = new Dictionary<EffectType, DisplayType>();

		private SkillDisplayType[] m_skillDisplaySetupListField;

		[XmlArrayItem("m_skillDisplay", IsNullable = false)]
		public SkillDisplayType[] m_skillDisplaySetupList { get; set; }

		public void c205e144c1d26465e00fad0b88805fb6e()
		{
			m_skillDisplayLUT.Clear();
			for (int i = 0; i < m_skillDisplaySetupList.Length; i++)
			{
				DisplayType value = DisplayType.Total;
				if (m_skillDisplayLUT.TryGetValue(m_skillDisplaySetupList[i].m_effectType, out value))
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Skill " + m_skillDisplaySetupList[i].m_effectType.ToString() + " UI display shouldn't have two setups. Pls give this to yihan");
				}
				else
				{
					m_skillDisplayLUT.Add(m_skillDisplaySetupList[i].m_effectType, m_skillDisplaySetupList[i].m_displayType);
				}
			}
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

		public DisplayType cadef9a192fc5bdbc6abde1b1df3c3e98(EffectType c470c62d408de8861af01a7e0dbd93430)
		{
			DisplayType value = DisplayType.Percentage;
			m_skillDisplayLUT.TryGetValue(c470c62d408de8861af01a7e0dbd93430, out value);
			return value;
		}
	}
}
