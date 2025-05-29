using System;
using System.Collections;
using System.Collections.Generic;

public class Guild
{
	public List<Presence> mMemberList = new List<Presence>();

	public int Id { get; set; }

	public string Name { get; set; }

	public string Banner { get; set; }

	public int Level { get; set; }

	public int Experience { get; set; }

	public int MemberCount { get; set; }

	public GuildPreference Preference { get; set; }

	public bool HasVacancy { get; set; }

	public int MaxMemberCount { get; set; }

	public int MasterAccountId { get; set; }

	public int MasterCharacterId { get; set; }

	public int FreeSkillCount { get; set; }

	public List<Presence> ced4f209cd82cf504446bed630a19d684
	{
		get
		{
			return mMemberList;
		}
	}

	public Guild(Hashtable cd22aa6735988e8e65acbd503f3870e3e)
	{
		Id = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[0]);
		Name = Convert.ToString(cd22aa6735988e8e65acbd503f3870e3e[1]);
		Banner = Convert.ToString(cd22aa6735988e8e65acbd503f3870e3e[2]);
		Level = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[3]);
		Experience = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[4]);
		MemberCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[5]);
		bool flag = Convert.ToBoolean(cd22aa6735988e8e65acbd503f3870e3e[6]);
		bool flag2 = Convert.ToBoolean(cd22aa6735988e8e65acbd503f3870e3e[7]);
		bool flag3 = Convert.ToBoolean(cd22aa6735988e8e65acbd503f3870e3e[8]);
		bool flag4 = Convert.ToBoolean(cd22aa6735988e8e65acbd503f3870e3e[9]);
		Preference |= GuildPreference.None;
		if (flag)
		{
			while (true)
			{
				switch (7)
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
			Preference |= GuildPreference.Social;
		}
		if (flag2)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			Preference |= GuildPreference.Quest;
		}
		if (flag3)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			Preference |= GuildPreference.PvP;
		}
		if (flag4)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			Preference |= GuildPreference.PvE;
		}
		FreeSkillCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[10]);
		HasVacancy = Convert.ToBoolean(cd22aa6735988e8e65acbd503f3870e3e[11]);
		MaxMemberCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[12]);
		MasterAccountId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[13]);
		MasterCharacterId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[14]);
		if (cd22aa6735988e8e65acbd503f3870e3e[15] == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			Hashtable[] array = (Hashtable[])cd22aa6735988e8e65acbd503f3870e3e[15];
			Hashtable[] array2 = array;
			foreach (Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c in array2)
			{
				mMemberList.Add(new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c));
			}
			while (true)
			{
				switch (7)
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
