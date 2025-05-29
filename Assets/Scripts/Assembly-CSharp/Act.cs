using A;
using UnityEngine;
using XsdSettings;

public class Act : MonoBehaviour
{
	public string m_modeType = "GamemodePvE";

	public int m_level_Min = 1;

	public int m_level_Max = 1;

	protected bool m_bLevelSetuped;

	protected Playlist m_level;

	private void Start()
	{
		MatchmakingService matchmakingService;
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			matchmakingService = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<MatchmakingService>();
		}
		else
		{
			matchmakingService = c43a69fb78684cb9b28f36b8546ad4d92.c7088de59e49f7108f520cf7e0bae167e;
		}
		MatchmakingService matchmakingService2 = matchmakingService;
		if (matchmakingService2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			ELevelDifficulty difficulty = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_difficulty;
			m_level = matchmakingService2.c8e693f5f3ec2e82bd093c9a5d56bdf43();
			switch (difficulty)
			{
			case ELevelDifficulty.Hard:
				m_level_Min = m_level.m_hard_LevelMin;
				m_level_Max = m_level.m_hard_LevelMax;
				break;
			case ELevelDifficulty.Hell:
				m_level_Min = m_level.m_hell_LevelMin;
				m_level_Max = m_level.m_hell_LevelMax;
				break;
			default:
				m_level_Min = m_level.m_normal_LevelMin;
				m_level_Max = m_level.m_normal_LevelMax;
				break;
			}
		}
		if (m_level_Min < 1)
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
			m_level_Min = 1;
		}
		if (m_level_Max >= m_level_Min)
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
			m_level_Max = m_level_Min;
			return;
		}
	}

	private void Update()
	{
	}
}
