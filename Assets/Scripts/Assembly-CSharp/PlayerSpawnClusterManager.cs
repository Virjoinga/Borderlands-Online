using System.Collections.Generic;
using A;

internal class PlayerSpawnClusterManager : c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerSpawnClusterManager>
{
	private Dictionary<int, PlayerSpawnCluster> m_cluster = new Dictionary<int, PlayerSpawnCluster>();

	private List<PlayerSpawnCluster> m_activeClusters = new List<PlayerSpawnCluster>();

	public void Reset()
	{
		m_cluster.Clear();
		m_activeClusters.Clear();
	}

	public PlayerSpawnCluster c31e1d9d13ad633423d3ea225742663a4(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (ceb41162a7cd2a1d5c4a03830e02b4198 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}
		}
		PlayerSpawnCluster value;
		if (m_cluster.TryGetValue(ceb41162a7cd2a1d5c4a03830e02b4198.m_teamID, out value))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return value;
				}
			}
		}
		for (int i = 0; i < m_activeClusters.Count; i++)
		{
			if (!m_activeClusters[i].c6d925511a08a1bfb02c7f48ba4d49c7a(ceb41162a7cd2a1d5c4a03830e02b4198))
			{
				continue;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return m_activeClusters[i];
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public void caf279e3f951497c2e8d52b799dbd5151(int c804e1fb3ce017e25e147307416292d7a, PlayerSpawnCluster c2acd1a8feebf87b83e5d6d609dc53067)
	{
		m_cluster.Add(c804e1fb3ce017e25e147307416292d7a, c2acd1a8feebf87b83e5d6d609dc53067);
	}

	public void caf279e3f951497c2e8d52b799dbd5151(PlayerSpawnCluster c2acd1a8feebf87b83e5d6d609dc53067)
	{
		m_activeClusters.Add(c2acd1a8feebf87b83e5d6d609dc53067);
	}

	public void c332dbd4a0e97e38433bdf9bd7cc61386(PlayerSpawnCluster c2acd1a8feebf87b83e5d6d609dc53067)
	{
		m_activeClusters.Remove(c2acd1a8feebf87b83e5d6d609dc53067);
	}
}
