using System.Xml.Serialization;

namespace BHV_Skill
{
	[XmlInclude(typeof(BHVSkillSettingsBerserk))]
	[XmlInclude(typeof(BHVSkillSettingsTurret))]
	[XmlInclude(typeof(BHVSkillSettingsFireBird))]
	[XmlInclude(typeof(BHVSkillSettingsHunter))]
	public class BHVSkillSettings
	{
	}
}
