using System.Collections;
using System.Collections.Generic;
using XsdSettings;

public class Lobby
{
	public int Id { get; set; }

	public int Owner { get; set; }

	public int c6bd4b9ef67e1accad2d94e7d188d4456
	{
		get
		{
			return Members.Count;
		}
		set
		{
		}
	}

	public int cb12cd48f345823447daecb3526050db7
	{
		get
		{
			return TotalSlots - Members.Count;
		}
		set
		{
		}
	}

	public int TotalSlots { get; set; }

	public bool IsGroupGame { get; set; }

	public string SessionId { get; set; }

	public GamemodeType GameMode { get; set; }

	public int Playlist { get; set; }

	public ELevelDifficulty Difficulty { get; set; }

	public List<Presence> Members { get; set; }

	public List<Group> Groups { get; set; }

	public bool HasGameStarted { get; set; }

	public Lobby(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		Id = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		Owner = (int)c28cf3d24e3067ef54895f824fad7fcef[1];
		TotalSlots = (int)c28cf3d24e3067ef54895f824fad7fcef[2];
		IsGroupGame = (bool)c28cf3d24e3067ef54895f824fad7fcef[3];
		SessionId = (string)c28cf3d24e3067ef54895f824fad7fcef[4];
		Members = new List<Presence>();
		Hashtable hashtable = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[5];
		for (int i = 0; i < hashtable.Count; i++)
		{
			Members.Add(new Presence((Hashtable)hashtable[i]));
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Groups = new List<Group>();
			Hashtable hashtable2 = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[6];
			for (int j = 0; j < hashtable2.Count; j++)
			{
				Groups.Add(new Group((Hashtable)hashtable2[j]));
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				GameMode = (GamemodeType)(int)c28cf3d24e3067ef54895f824fad7fcef[7];
				Playlist = (int)c28cf3d24e3067ef54895f824fad7fcef[8];
				Difficulty = (ELevelDifficulty)(int)c28cf3d24e3067ef54895f824fad7fcef[9];
				return;
			}
		}
	}

	public void c824d853466705b61a4e964c504c0da81(Presence caadc19f3b6ef506913862a46cd09ddf6)
	{
		if (cb12cd48f345823447daecb3526050db7 <= 0)
		{
			while (true)
			{
				switch (2)
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
		using (List<Presence>.Enumerator enumerator = Members.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Presence current = enumerator.Current;
				if (current.mCharacterId != caadc19f3b6ef506913862a46cd09ddf6.mCharacterId)
				{
					continue;
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
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0060;
				}
				continue;
				end_IL_0060:
				break;
			}
		}
		Members.Add(caadc19f3b6ef506913862a46cd09ddf6);
	}

	public bool c7e6306ae6375d9ab6d595d202da0b160(int c5dfde30d8784694fb9999709d290e6c4)
	{
		using (List<Presence>.Enumerator enumerator = Members.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Presence current = enumerator.Current;
				if (current.mCharacterId != c5dfde30d8784694fb9999709d290e6c4)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Members.Remove(current);
					return true;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0058;
				}
				continue;
				end_IL_0058:
				break;
			}
		}
		return false;
	}

	public void cd6d4f28cd75887780056ff798f57e54a(int c201251370bf8deb7ba71da4ae484a494)
	{
		Owner = c201251370bf8deb7ba71da4ae484a494;
	}

	public bool cfe994d4c778825e611c35c42ae65de3c(int c5dfde30d8784694fb9999709d290e6c4)
	{
		return Members.Find((Presence c5ebdc65d5cb420faf7ba524809963aa9) => c5ebdc65d5cb420faf7ba524809963aa9.mCharacterId == c5dfde30d8784694fb9999709d290e6c4) != null;
	}
}
