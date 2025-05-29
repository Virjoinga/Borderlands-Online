using System;
using System.Collections;

public class Invitation
{
	public int GuildId { get; set; }

	public string GuildName { get; set; }

	public string GuildMasterNick { get; set; }

	public int GuildInviterCharacterId { get; set; }

	public Invitation(Hashtable cd22aa6735988e8e65acbd503f3870e3e)
	{
		GuildId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[0]);
		GuildMasterNick = Convert.ToString(cd22aa6735988e8e65acbd503f3870e3e[1]);
		GuildName = Convert.ToString(cd22aa6735988e8e65acbd503f3870e3e[2]);
		GuildInviterCharacterId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[3]);
	}
}
