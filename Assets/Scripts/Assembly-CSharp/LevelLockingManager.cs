using System.Collections.Generic;
using System.Linq;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class LevelLockingManager : IQuestServiceNotificationListerner
{
	private Dictionary<int, int> mAccessableLevels = new Dictionary<int, int>();

	private Dictionary<int, int> mUnlockedLevels = new Dictionary<int, int>();

	private Dictionary<int, int> mGroupUnlockedLevels = new Dictionary<int, int>();

	private List<int> mProcessingQuests = new List<int>();

	private bool m_bFirstEnterFlag = true;

	private static LevelLockingManager mInstance;

	private bool m_unlockAll;

	public bool m_bQuestInited;

	private bool m_bWithNewlyUnlockedInstance;

	private LevelLockingManager()
	{
		OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c93da630efea1a10cb46ea9bd9ab69472(c93ac29792273db426951b1ebb8551cc3);
	}

	public void c74690d3a571b9427693142bd80c6fc01()
	{
		m_unlockAll = true;
	}

	public static LevelLockingManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (mInstance == null)
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
			mInstance = new LevelLockingManager();
		}
		return mInstance;
	}

	public bool c8d5186b7fb030f2b629c651fef672388()
	{
		return m_bFirstEnterFlag;
	}

	public bool c6080f1351b3cc5b24904b27bb1bb49ad(int cca82d1ca8bb3a0c9ca3e8697397df77e)
	{
		if (m_unlockAll)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return true;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return mUnlockedLevels.ContainsKey(cca82d1ca8bb3a0c9ca3e8697397df77e);
	}

	public bool cbdf72842c7a6a0a539f425affd93e61b()
	{
		c7c03e6f29c8281984fdd564fed20468c(false);
		GameObject gameObject = GameObject.Find("LD");
		LobbyBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<LobbyBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].c53110ece4e7b27b1427b8ee45884568e();
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return m_bWithNewlyUnlockedInstance;
		}
	}

	public void c27df1edd6c14308f219e43f18b18b7f2()
	{
		GameObject gameObject = GameObject.Find("LD");
		LobbyBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<LobbyBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].ca1b9dbcdbe8df928e93eeb9f3a881f3d();
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
			return;
		}
	}

	public void c4fd4491fcfa97e5d3d672639a889a1b1()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
	}

	protected void c93ac29792273db426951b1ebb8551cc3(int ca754d97f0e77a3bd2a4bf8d3de0eb9f5)
	{
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnUnlockNewInstance();
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
			if (!mGroupUnlockedLevels.ContainsKey(ca754d97f0e77a3bd2a4bf8d3de0eb9f5))
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
				mGroupUnlockedLevels.Add(ca754d97f0e77a3bd2a4bf8d3de0eb9f5, 0);
			}
		}
		if (!mUnlockedLevels.ContainsKey(ca754d97f0e77a3bd2a4bf8d3de0eb9f5))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			mUnlockedLevels.Add(ca754d97f0e77a3bd2a4bf8d3de0eb9f5, 0);
			m_bWithNewlyUnlockedInstance = true;
		}
		if (mAccessableLevels.ContainsKey(ca754d97f0e77a3bd2a4bf8d3de0eb9f5))
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			mAccessableLevels.Add(ca754d97f0e77a3bd2a4bf8d3de0eb9f5, 0);
			return;
		}
	}

	protected void cc4197129f7529f30385dbf6d52f7c20a(Dictionary<int, int> c9697fd3fb817426cd94a594832eafa55)
	{
		c7c03e6f29c8281984fdd564fed20468c(false);
	}

	public void OnQuestUpdate(int accountId, int questId, QuestState questState)
	{
		c7c03e6f29c8281984fdd564fed20468c(false);
	}

	public void OnQuestAccepted(int accountId, int questId)
	{
	}

	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	public void OnQuestRewardClaimed(int accountId, int questId, QuestReward[] rewards)
	{
		c7c03e6f29c8281984fdd564fed20468c(false);
	}

	public void OnQuestProgress(int accountId, Dictionary<int, QuestProgress> questProgress)
	{
		mProcessingQuests.Clear();
		Dictionary<int, Quest> dictionary = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc1076a9627a18bd4b67cb59f4bee480a();
		for (int i = 0; i < questProgress.Count; i++)
		{
			QuestProgress value = questProgress.ElementAt(i).Value;
			if (value.mStatus != QuestState.InProgress)
			{
				continue;
			}
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
			Quest value2 = c6a1e9d9cfb0b8c14256796aa2b02d787.c7088de59e49f7108f520cf7e0bae167e;
			dictionary.TryGetValue(value.mQuestId, out value2);
			if (value2 == null)
			{
				continue;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			int[] mBoundInstanceList = value2.mBoundInstanceList;
			foreach (int item in mBoundInstanceList)
			{
				if (mProcessingQuests.Contains(item))
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!value2.mIsBoundInstance)
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
				mProcessingQuests.Add(item);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
				c3fe05a58a92948d50c3f4ae173e922ca();
			}
			m_bQuestInited = true;
			return;
		}
	}

	public bool cb6bb5b1eab94d6a9e847453cd616d1a6(int ccc15ba28a96efe390f868ffde0345c5f)
	{
		return mProcessingQuests.Contains(ccc15ba28a96efe390f868ffde0345c5f);
	}

	public void c7c03e6f29c8281984fdd564fed20468c(bool c193698e1d7a9e94fa14de0e7004d1542 = true)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_bWithNewlyUnlockedInstance = false;
					return;
				}
			}
		}
		Dictionary<int, int> dictionary = OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c50c5e39d33643f03b4da08ee3c5dce44();
		if (m_bFirstEnterFlag)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					for (int i = 0; i < dictionary.Count; i++)
					{
						mAccessableLevels.Add(dictionary.ElementAt(i).Key, dictionary.ElementAt(i).Value);
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							m_bFirstEnterFlag = false;
							c4fd4491fcfa97e5d3d672639a889a1b1();
							return;
						}
					}
				}
				}
			}
		}
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
			c3fe05a58a92948d50c3f4ae173e922ca();
		}
		m_bWithNewlyUnlockedInstance = false;
		mUnlockedLevels.Clear();
		for (int j = 0; j < dictionary.Count; j++)
		{
			if (mAccessableLevels.ContainsKey(dictionary.ElementAt(j).Key))
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			mUnlockedLevels.Add(dictionary.ElementAt(j).Key, dictionary.ElementAt(j).Value);
			m_bWithNewlyUnlockedInstance = true;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			mAccessableLevels.Clear();
			for (int k = 0; k < dictionary.Count; k++)
			{
				mAccessableLevels.Add(dictionary.ElementAt(k).Key, dictionary.ElementAt(k).Value);
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

	public void c3fe05a58a92948d50c3f4ae173e922ca()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "UpdateGroupUnlockedInstances call GetMyUnlockedInstances");
		OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cfc7db85f7cf2e51258ea6bcd864d4d2a(cd19facc18081b2cfd2ce7ee297b13ebf);
	}

	private void cd19facc18081b2cfd2ce7ee297b13ebf(Dictionary<int, int> c9697fd3fb817426cd94a594832eafa55)
	{
		mGroupUnlockedLevels.Clear();
		mAccessableLevels.Clear();
		for (int i = 0; i < c9697fd3fb817426cd94a594832eafa55.Count; i++)
		{
			mGroupUnlockedLevels.Add(c9697fd3fb817426cd94a594832eafa55.ElementAt(i).Key, c9697fd3fb817426cd94a594832eafa55.ElementAt(i).Value);
			mAccessableLevels.Add(c9697fd3fb817426cd94a594832eafa55.ElementAt(i).Key, c9697fd3fb817426cd94a594832eafa55.ElementAt(i).Value);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public bool cfbf6ce5213eb84d4ac07084f783da2ed(int cca82d1ca8bb3a0c9ca3e8697397df77e)
	{
		if (m_unlockAll)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
			if (mGroupUnlockedLevels.ContainsKey(cca82d1ca8bb3a0c9ca3e8697397df77e))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		else if (mAccessableLevels.ContainsKey(cca82d1ca8bb3a0c9ca3e8697397df77e))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}

	public int c18d0e40d91f45fe30c88eb7febeda940(int cca82d1ca8bb3a0c9ca3e8697397df77e)
	{
		if (m_unlockAll)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 2;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return 2;
				}
			}
		}
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (mGroupUnlockedLevels.ContainsKey(cca82d1ca8bb3a0c9ca3e8697397df77e))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return mGroupUnlockedLevels[cca82d1ca8bb3a0c9ca3e8697397df77e];
					}
				}
			}
		}
		else if (mAccessableLevels.ContainsKey(cca82d1ca8bb3a0c9ca3e8697397df77e))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return mAccessableLevels[cca82d1ca8bb3a0c9ca3e8697397df77e];
				}
			}
		}
		return -1;
	}
}
