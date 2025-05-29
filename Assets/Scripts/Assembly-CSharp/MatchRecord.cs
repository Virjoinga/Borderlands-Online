using System;
using System.Collections;
using System.Collections.Generic;
using XsdSettings;

public class MatchRecord
{
	public Dictionary<GamemodeType, Hashtable> mMatchTypeFactors = new Dictionary<GamemodeType, Hashtable>();

	public Dictionary<int, Hashtable> mLevelTypeFactors = new Dictionary<int, Hashtable>();

	public Dictionary<AvatarType, Hashtable> mSkillTypeFactors = new Dictionary<AvatarType, Hashtable>();

	public Dictionary<WeaponType, Hashtable> mWeaponTypeFactors = new Dictionary<WeaponType, Hashtable>();

	public int TotalMatchCount { get; set; }

	public int TotalHonorPoint { get; set; }

	public int TotalWinCount { get; set; }

	public int TotalLossCount { get; set; }

	public int TotalKillCount { get; set; }

	public int TotalDeathCount { get; set; }

	public int TotalMeleeKill { get; set; }

	public int TotalGrenadeKill { get; set; }

	public int CharacterId { get; set; }

	public Dictionary<GamemodeType, Hashtable> ca3b488f8d471f2e3bc41d41928124733
	{
		get
		{
			return mMatchTypeFactors;
		}
	}

	public Dictionary<int, Hashtable> c4540e04bfca2834653c461e2e62e4d82
	{
		get
		{
			return mLevelTypeFactors;
		}
	}

	public Dictionary<AvatarType, Hashtable> c989d90e2a5cbd5cc8ca1b2087674c555
	{
		get
		{
			return mSkillTypeFactors;
		}
	}

	public Dictionary<WeaponType, Hashtable> c7c630e06fdb599b61123976f89943dc8
	{
		get
		{
			return mWeaponTypeFactors;
		}
	}

	public MatchRecord(Hashtable cd22aa6735988e8e65acbd503f3870e3e)
	{
		CharacterId = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[0]);
		TotalMatchCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[1]);
		TotalHonorPoint = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[2]);
		TotalWinCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[3]);
		TotalLossCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[4]);
		TotalKillCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[5]);
		TotalDeathCount = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[6]);
		TotalMeleeKill = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[7]);
		TotalGrenadeKill = Convert.ToInt32(cd22aa6735988e8e65acbd503f3870e3e[8]);
		if (cd22aa6735988e8e65acbd503f3870e3e[9] != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Hashtable[] c07f595c609c623527efa412832349378 = (Hashtable[])cd22aa6735988e8e65acbd503f3870e3e[9];
			c57daab99c1cc943df219e9a6a6f3ef17(c07f595c609c623527efa412832349378, ref mMatchTypeFactors);
		}
		if (cd22aa6735988e8e65acbd503f3870e3e[10] != null)
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
			Hashtable[] c07f595c609c623527efa4128323493782 = (Hashtable[])cd22aa6735988e8e65acbd503f3870e3e[10];
			c57daab99c1cc943df219e9a6a6f3ef17(c07f595c609c623527efa4128323493782, ref mLevelTypeFactors);
		}
		if (cd22aa6735988e8e65acbd503f3870e3e[11] != null)
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
			Hashtable[] c07f595c609c623527efa4128323493783 = (Hashtable[])cd22aa6735988e8e65acbd503f3870e3e[11];
			c57daab99c1cc943df219e9a6a6f3ef17(c07f595c609c623527efa4128323493783, ref mSkillTypeFactors);
		}
		if (cd22aa6735988e8e65acbd503f3870e3e[12] == null)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			Hashtable[] c07f595c609c623527efa4128323493784 = (Hashtable[])cd22aa6735988e8e65acbd503f3870e3e[12];
			c57daab99c1cc943df219e9a6a6f3ef17(c07f595c609c623527efa4128323493784, ref mWeaponTypeFactors);
			return;
		}
	}

	private void c57daab99c1cc943df219e9a6a6f3ef17<ccc78c2b16a6afce11cda5e6ea733871c>(Hashtable[] c07f595c609c623527efa412832349378, ref Dictionary<ccc78c2b16a6afce11cda5e6ea733871c, Hashtable> cb13b75628098b24bf04dc02c57488fa9)
	{
		foreach (Hashtable hashtable in c07f595c609c623527efa412832349378)
		{
			Hashtable hashtable2 = new Hashtable();
			ccc78c2b16a6afce11cda5e6ea733871c key = (ccc78c2b16a6afce11cda5e6ea733871c)hashtable[0];
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if ((int)current == 0)
					{
						continue;
					}
					while (true)
					{
						switch (2)
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
					int num = Convert.ToInt32(current) - 1;
					hashtable2[num] = Convert.ToInt32(hashtable[current]);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_009d;
					}
					continue;
					end_IL_009d:
					break;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_00b6;
						}
						continue;
						end_IL_00b6:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			cb13b75628098b24bf04dc02c57488fa9.Add(key, hashtable2);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
