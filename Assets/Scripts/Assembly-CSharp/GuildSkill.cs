using System;
using System.Collections;

public class GuildSkill
{
	public int Id { get; set; }

	public int Grade { get; set; }

	public GuildSkill(Hashtable cd22aa6735988e8e65acbd503f3870e3e)
	{
		Id = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[0]);
		Grade = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[1]);
	}
}
