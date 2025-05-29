using System.Collections;
using XsdSettings;

public class Character
{
	public int Id { get; set; }

	public int AccountId { get; set; }

	public string Name { get; set; }

	public int Experience { get; set; }

	public int Level { get; set; }

	public AvatarType AvatarType { get; set; }

	public string AvatarParts { get; set; }

	public string AvatarMaterials { get; set; }

	public uint AvatarId { get; set; }

	public int TimePlayed { get; set; }

	public Inventory Inventory { get; set; }

	public CurrencyInfo Currency { get; set; }

	public QuestInfo QuestList { get; set; }

	public InstanceInfo Instances { get; set; }

	public SkillTree Skills { get; set; }

	public Character(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
	}

	public void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		Id = (int)c591d56a94543e3559945c497f37126c4[0];
		AccountId = (int)c591d56a94543e3559945c497f37126c4[1];
		Name = (string)c591d56a94543e3559945c497f37126c4[2];
		Experience = (int)c591d56a94543e3559945c497f37126c4[3];
		Level = (int)c591d56a94543e3559945c497f37126c4[4];
		AvatarType = (AvatarType)(int)c591d56a94543e3559945c497f37126c4[5];
		AvatarParts = (string)c591d56a94543e3559945c497f37126c4[6];
		AvatarMaterials = (string)c591d56a94543e3559945c497f37126c4[7];
		AvatarId = (uint)(int)c591d56a94543e3559945c497f37126c4[8];
		Inventory = new Inventory((Hashtable)c591d56a94543e3559945c497f37126c4[9]);
		Currency = new CurrencyInfo((Hashtable)c591d56a94543e3559945c497f37126c4[10]);
		QuestList = new QuestInfo((Hashtable)c591d56a94543e3559945c497f37126c4[11]);
		Instances = new InstanceInfo((Hashtable)c591d56a94543e3559945c497f37126c4[12]);
		Skills = new SkillTree((Hashtable)c591d56a94543e3559945c497f37126c4[13]);
		TimePlayed = (int)c591d56a94543e3559945c497f37126c4[14];
	}
}
