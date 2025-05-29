using System;
using System.Collections;

public class GuildNews
{
	public int PosterAccountId { get; set; }

	public int PosterCharacterId { get; set; }

	public GuildNewsReason Reason { get; set; }

	public int Objective { get; set; }

	public string PosterName { get; set; }

	public GuildNews(Hashtable cd22aa6735988e8e65acbd503f3870e3e)
	{
		PosterAccountId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[0]);
		PosterCharacterId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[1]);
		Reason = (GuildNewsReason)Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[2]);
		if (cd22aa6735988e8e65acbd503f3870e3e[3] != null)
		{
			while (true)
			{
				switch (1)
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
			Objective = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[3]);
		}
		if (cd22aa6735988e8e65acbd503f3870e3e[4] == null)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			PosterName = Convert.ToString(cd22aa6735988e8e65acbd503f3870e3e[4]);
			return;
		}
	}
}
