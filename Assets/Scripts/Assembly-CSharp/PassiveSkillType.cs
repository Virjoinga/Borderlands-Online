using System.Xml.Serialization;

public enum PassiveSkillType
{
	None = 0,
	[XmlEnum(Name = "HPMultiplier")]
	HPMultiplier = 1,
	[XmlEnum(Name = "RangeDamageMultiplier")]
	RangeDamageMultiplier = 2,
	[XmlEnum(Name = "MeleeDamageMultiplier")]
	MeleeDamageMultiplier = 3,
	[XmlEnum(Name = "SpeedMultiplier")]
	SpeedMultiplier = 4,
	[XmlEnum(Name = "BerserkAura")]
	BerserkAura = 5
}
