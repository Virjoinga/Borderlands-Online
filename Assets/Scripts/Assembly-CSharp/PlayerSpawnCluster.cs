using A;
using Core;
using UnityEngine;

[RequireComponent(typeof(SpawnSlotContainer))]
public class PlayerSpawnCluster : Scene, InstantiateManager.InstanciationClient
{
	public bool m_autoRespawn = true;

	public float m_respawnTime = 3f;

	public bool m_isTeamSpawner;

	public int m_teamId = 1;

	public PlayerSpawnCluster m_playerSpawnCluserToReplace;

	public void c6d2e35d303ac2387ebdf2ed19b73b154(EntityPlayer c71c1e199679004120441047fd5bec329)
	{
	}

	protected override void c881f5c9f672eba2e02441e1387a821ba()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "PlayerSpawnCluster.Begin [" + base.gameObject.name + "]");
		if (m_playerSpawnCluserToReplace != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerSpawnCluserToReplace.cdada4c3678c9c23c38aaf0754a94a620(true);
			c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerSpawnClusterManager>.c5ee19dc8d4cccf5ae2de225410458b86.c332dbd4a0e97e38433bdf9bd7cc61386(m_playerSpawnCluserToReplace);
		}
		if (m_isTeamSpawner)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerSpawnClusterManager>.c5ee19dc8d4cccf5ae2de225410458b86.caf279e3f951497c2e8d52b799dbd5151(m_teamId, this);
		}
		else
		{
			c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerSpawnClusterManager>.c5ee19dc8d4cccf5ae2de225410458b86.caf279e3f951497c2e8d52b799dbd5151(this);
		}
		base.c881f5c9f672eba2e02441e1387a821ba();
	}

	protected override bool c6b55d8e5c9702fae8ea5ac979f1a8713()
	{
		return false;
	}

	protected override void ca9b3a2d1fbbeafb416b7e606f618cdf5()
	{
		base.ca9b3a2d1fbbeafb416b7e606f618cdf5();
	}

	protected override void cb537a7cebe404b48035eab26b9fd89b8()
	{
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}
}
