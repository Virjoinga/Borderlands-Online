using System.Collections.Generic;
using A;

public class PlayerManager : c06ca0e618478c23eba3419653a19760f<PlayerManager>
{
	private Dictionary<int, PlayerProperties> m_players = new Dictionary<int, PlayerProperties>();

	private int m_localPlayerId;

	public void cd48a53289a0d0d4ec50069243545b823(PlayerProperties ceb41162a7cd2a1d5c4a03830e02b4198, bool c9f86d965ca220e54c03c3844c19b202f)
	{
		if (c9f86d965ca220e54c03c3844c19b202f)
		{
			while (true)
			{
				switch (4)
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
			m_localPlayerId = ceb41162a7cd2a1d5c4a03830e02b4198.m_id;
		}
		m_players.Remove(ceb41162a7cd2a1d5c4a03830e02b4198.m_id);
		m_players.Add(ceb41162a7cd2a1d5c4a03830e02b4198.m_id, ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	public PlayerProperties cd95354b53e674ec7dc9594e66e4d316f(int c8a7f3986726d4793d7b3f3bbcc750943)
	{
		PlayerProperties value = cfae41224a817cbf5e9ab6bf016351ae8.c7088de59e49f7108f520cf7e0bae167e;
		m_players.TryGetValue(c8a7f3986726d4793d7b3f3bbcc750943, out value);
		return value;
	}

	public PlayerProperties ccc826da979542be7370386df94069f47()
	{
		return cd95354b53e674ec7dc9594e66e4d316f(m_localPlayerId);
	}
}
