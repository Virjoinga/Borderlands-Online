using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class QuestServiceWrapper : ServiceWrapper<IQuestServiceWrapper, QuestServiceWrapper>
{
	protected bool m_bInited;

	protected Dictionary<int, QuestProgress> m_playerQuestsProgess = new Dictionary<int, QuestProgress>();

	protected Dictionary<int, Quest> m_playerQuestsInfo = new Dictionary<int, Quest>();

	protected Dictionary<int, Quest> m_playerDailyQuests = new Dictionary<int, Quest>();

	protected Dictionary<int, DailyQuestInfo> m_dailyQuestInfos = new Dictionary<int, DailyQuestInfo>();

	private List<IQuestServiceNotificationListerner> m_listerner = new List<IQuestServiceNotificationListerner>();

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(IQuestServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(IQuestServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
		if (m_playerQuestsProgess == null)
		{
			while (true)
			{
				switch (3)
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
		if (questState == QuestState.Available)
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
			QuestProgress questProgress = new QuestProgress();
			questProgress.mCurrentTask = 0;
			questProgress.mQuestId = questId;
			questProgress.mStatus = questState;
			questProgress.mTaskProgress = 0;
			if (!m_playerQuestsProgess.ContainsKey(questId))
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
				m_playerQuestsProgess.Add(questId, questProgress);
				OnQuestProgress(OnlineService.s_characterId, m_playerQuestsProgess);
			}
			Quest quest = c0c8ccd79e03879ffc929ddac44fbc31c(questId);
			if (quest != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (quest.mCategory == QuestCategory.Guidance)
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
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
							cf7f98b1de39f26f9a9d63b5d8ac5a26b(questId);
						}
					}
				}
			}
		}
		else
		{
			QuestProgress value = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
			if (m_playerQuestsProgess.TryGetValue(questId, out value))
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
				if (value != null)
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
					value.mStatus = questState;
				}
			}
		}
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnQuestUpdate(characterId, questId, questState);
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

	public void OnQuestAccepted(int characterId, int questId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnQuestAccepted(characterId, questId);
		}
		while (true)
		{
			switch (4)
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

	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnNewTask(iCharacterID, iQuestID, iNewTaskID);
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
			return;
		}
	}

	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnQuestRewardClaimed(characterId, questId, rewards);
		}
		while (true)
		{
			switch (4)
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

	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> quests)
	{
		m_playerQuestsProgess = quests;
		int num = 0;
		using (Dictionary<int, DailyQuestInfo>.Enumerator enumerator = m_dailyQuestInfos.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, DailyQuestInfo> current = enumerator.Current;
				QuestProgress value = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
				if (!m_playerQuestsProgess.TryGetValue(current.Key, out value))
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
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (value.mStatus != QuestState.Completed)
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
					if (value.mStatus != QuestState.InProgress)
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
						if (value.mStatus != QuestState.RewardClaimed)
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
					}
				}
				num++;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_00a4;
				}
				continue;
				end_IL_00a4:
				break;
			}
		}
		if (num < 5)
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
			using (Dictionary<int, DailyQuestInfo>.Enumerator enumerator2 = m_dailyQuestInfos.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<int, DailyQuestInfo> current2 = enumerator2.Current;
					QuestProgress value2 = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
					if (!m_playerQuestsProgess.TryGetValue(current2.Key, out value2))
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
						value2 = new QuestProgress();
						value2.mQuestId = current2.Key;
						value2.mStatus = QuestState.Available;
						m_playerQuestsProgess.Add(current2.Key, value2);
					}
					else
					{
						if (value2.mStatus != 0)
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
						value2.mStatus = QuestState.Available;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0177;
					}
					continue;
					end_IL_0177:
					break;
				}
			}
		}
		List<int> list = new List<int>(m_playerQuestsProgess.Keys);
		using (List<int>.Enumerator enumerator3 = list.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				int current3 = enumerator3.Current;
				Quest value3 = c6a1e9d9cfb0b8c14256796aa2b02d787.c7088de59e49f7108f520cf7e0bae167e;
				if (!m_playerQuestsInfo.TryGetValue(current3, out value3))
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
					break;
				}
				QuestProgress questProgress = m_playerQuestsProgess[current3];
				if (num >= 5)
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
					if (value3.mCategory == QuestCategory.Daily)
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
						if (questProgress.mStatus == QuestState.Available)
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
							m_playerQuestsProgess.Remove(current3);
							continue;
						}
					}
				}
				int num2 = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
				if (value3.mRequiredLevel <= num2)
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
					if (value3.mHighestLevel <= 0)
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
					if (num2 <= value3.mHighestLevel)
					{
						continue;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				if (questProgress.mStatus != QuestState.Available)
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
					break;
				}
				m_playerQuestsProgess[current3].mStatus = QuestState.Unavailable;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_02d2;
				}
				continue;
				end_IL_02d2:
				break;
			}
		}
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnQuestProgress(characterId, m_playerQuestsProgess);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	protected override IQuestServiceWrapper c9374c9e18d64e753feff5ba5622a02ad()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689())
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return m_wrapperSession;
							}
						}
					}
				}
			}
		}
		return m_wrapperOnline;
	}

	public override void Reset()
	{
		m_bInited = false;
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_bInited)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_wrapperOnline = new QuestServiceWrapperOnline();
			m_wrapperSession = new QuestServiceWrapperSession();
			m_playerQuestsInfo = new Dictionary<int, Quest>();
			m_playerDailyQuests = new Dictionary<int, Quest>();
			c8407bc65fd35d9c4095fd638fa06cc8e("Settings/Quests", ref m_playerQuestsInfo);
			c8407bc65fd35d9c4095fd638fa06cc8e("Settings/DailyQuests", ref m_playerDailyQuests);
			c8407bc65fd35d9c4095fd638fa06cc8e("Settings/GuidanceQuests", ref m_playerQuestsInfo);
			base.cd93285db16841148ed53a5bbeb35cf20();
			m_bInited = true;
			return;
		}
	}

	public void c453f2a4444139b3731bbf5855f7433e3()
	{
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = m_playerQuestsProgess.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				if (current.mStatus != QuestState.Available)
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
					continue;
				}
				Quest quest = c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
				if (quest == null)
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (quest.mCategory != QuestCategory.Guidance)
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
				cf7f98b1de39f26f9a9d63b5d8ac5a26b(quest.mId);
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

	protected void c8407bc65fd35d9c4095fd638fa06cc8e(string c411fadd666352d1038a71c7c17b370c0, ref Dictionary<int, Quest> cfeb8370582646b8696da2d4f86e1197f)
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c411fadd666352d1038a71c7c17b370c0);
		QuestSetup questSetup = c1f65d049a1f4086b495eeca4f3680d73.c7088de59e49f7108f520cf7e0bae167e;
		StringReader stringReader = new StringReader(textAsset.text);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c0315d7015ef012213a2970a394fa1bf5.cc1720d05c75832f704b87474932341c3()));
			questSetup = xmlSerializer.Deserialize(stringReader) as QuestSetup;
		}
		finally
		{
			if (stringReader != null)
			{
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
					((IDisposable)stringReader).Dispose();
					break;
				}
			}
		}
		if (questSetup != null)
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
			if (questSetup.mQuests != null)
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
				Quest[] mQuests = questSetup.mQuests;
				foreach (Quest quest in mQuests)
				{
					if (!cfeb8370582646b8696da2d4f86e1197f.ContainsKey(quest.mId))
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
						cfeb8370582646b8696da2d4f86e1197f.Add(quest.mId, quest);
					}
					else
					{
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Get duplicate quest ID of " + quest.mId);
					}
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
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	public void c5fdc976a8c3f9e6e8516525fd2a5396f(int c731f8f565b2035819f3412520ff285b3)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c5fdc976a8c3f9e6e8516525fd2a5396f(c731f8f565b2035819f3412520ff285b3);
	}

	public void cf7f98b1de39f26f9a9d63b5d8ac5a26b(int c731f8f565b2035819f3412520ff285b3)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cf7f98b1de39f26f9a9d63b5d8ac5a26b(c731f8f565b2035819f3412520ff285b3);
	}

	public void c43f812e5db31871c2108e9f7fc8a0a73()
	{
		c9374c9e18d64e753feff5ba5622a02ad().c43f812e5db31871c2108e9f7fc8a0a73();
	}

	public Dictionary<int, QuestProgress> c4bd163e6f603f6c0724372fd12f5f4cb(bool c0d0ebdcc82ebf812848478a4baa4ca59 = true)
	{
		if (c0d0ebdcc82ebf812848478a4baa4ca59)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			OnQuestProgress(OnlineService.s_characterId, m_playerQuestsProgess);
		}
		return m_playerQuestsProgess;
	}

	public QuestProgress c2bf7446e2592f33112710a7566975ad7(int c731f8f565b2035819f3412520ff285b3)
	{
		QuestProgress value = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
		if (m_playerQuestsProgess.TryGetValue(c731f8f565b2035819f3412520ff285b3, out value))
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
					return value;
				}
			}
		}
		return null;
	}

	public void OnGetPlayerDailyQuestsContent(Dictionary<int, DailyQuestInfo> dailyQuestInfos)
	{
		m_dailyQuestInfos = dailyQuestInfos;
		using (Dictionary<int, DailyQuestInfo>.Enumerator enumerator = m_dailyQuestInfos.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, DailyQuestInfo> current = enumerator.Current;
				Quest value = c6a1e9d9cfb0b8c14256796aa2b02d787.c7088de59e49f7108f520cf7e0bae167e;
				if (m_playerDailyQuests.TryGetValue(current.Value.mQuestId, out value))
				{
					while (true)
					{
						switch (7)
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
					if (m_playerQuestsInfo.ContainsKey(current.Key))
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
					value.mId = current.Key;
					m_playerQuestsInfo.Add(current.Key, value);
				}
				else
				{
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array[0] = "Can not find daily quest ! Server Daily Quest ID : ";
					array[1] = current.Key;
					array[2] = " quest ID ";
					array[3] = current.Value.mQuestId;
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat(array));
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_00fe;
				}
				continue;
				end_IL_00fe:
				break;
			}
		}
		OnQuestProgress(OnlineService.s_characterId, m_playerQuestsProgess);
	}

	public void OnClearPlayerDailyQuest()
	{
		using (Dictionary<int, DailyQuestInfo>.KeyCollection.Enumerator enumerator = m_dailyQuestInfos.Keys.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				if (!m_playerQuestsProgess.ContainsKey(current))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_playerQuestsProgess.Remove(current);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_005e;
				}
				continue;
				end_IL_005e:
				break;
			}
		}
		m_dailyQuestInfos.Clear();
		OnQuestProgress(OnlineService.s_characterId, m_playerQuestsProgess);
		c43f812e5db31871c2108e9f7fc8a0a73();
	}

	public void c509488e7555f17435dc7dacc1709e509(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
	}

	private void cddb1928d6bb517752689884a3e06f40b(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cddb1928d6bb517752689884a3e06f40b(c5dfde30d8784694fb9999709d290e6c4, c731f8f565b2035819f3412520ff285b3);
	}

	public void cb534083a07db3bd6b74a38a62625f875(int cff9257dfd67c5d87350b6d9d70f655e2)
	{
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = m_playerQuestsProgess.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				if (current.mStatus != QuestState.InProgress)
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
					continue;
				}
				Quest quest = c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
				if (quest == null)
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
					continue;
				}
				QuestTask questTask = quest.mTasks[current.mCurrentTask];
				if (questTask == null)
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
				}
				else if (questTask.mType != QuestTaskType.TalkTo)
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
				}
				else
				{
					if (questTask.mTarget != cff9257dfd67c5d87350b6d9d70f655e2)
					{
						continue;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						c9374c9e18d64e753feff5ba5622a02ad().cb534083a07db3bd6b74a38a62625f875(OnTalkToNPC, current.mQuestId, questTask.mTaskId);
						return;
					}
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void OnTalkToNPC(bool success, Dictionary<int, QuestProgress> questProgress)
	{
		if (!success)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			OnQuestProgress(OnlineService.s_characterId, questProgress);
			return;
		}
	}

	public void c069e3e12ab95ff8518fd20364724de3f(int cff9257dfd67c5d87350b6d9d70f655e2)
	{
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = m_playerQuestsProgess.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				if (current.mStatus != QuestState.InProgress)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					continue;
				}
				Quest quest = c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
				if (quest == null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					continue;
				}
				QuestTask questTask = quest.mTasks[current.mCurrentTask];
				if (questTask == null)
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
				}
				else if (questTask.mType != QuestTaskType.BringTo)
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
				}
				else
				{
					if (questTask.mTarget != cff9257dfd67c5d87350b6d9d70f655e2)
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
					if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(questTask.mMaterialType) < questTask.mMaterialCount)
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
						c9374c9e18d64e753feff5ba5622a02ad().c069e3e12ab95ff8518fd20364724de3f(OnBringToNPC, current.mQuestId, questTask.mTaskId);
						return;
					}
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void OnBringToNPC(bool success, Dictionary<int, QuestProgress> questProgress)
	{
		if (!success)
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			OnQuestProgress(OnlineService.s_characterId, questProgress);
			return;
		}
	}

	public void c9d878a0c8ef401a60f254a868331d1bd()
	{
		c0c2fff5d2d07b2508ad22cc121948302(QuestTaskType.UseSkill);
	}

	public void cb2129d5ac409250d4c0820338b1540f1()
	{
		c0c2fff5d2d07b2508ad22cc121948302(QuestTaskType.SkillPoint);
	}

	public void cbd003204f631ee0c3edf8bfdbedafd12()
	{
		c0c2fff5d2d07b2508ad22cc121948302(QuestTaskType.ShowItem);
	}

	protected void c0c2fff5d2d07b2508ad22cc121948302(QuestTaskType c82da4aba736860aef1c9db1e5d8d1a58)
	{
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = m_playerQuestsProgess.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				if (current.mStatus != QuestState.InProgress)
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
					continue;
				}
				Quest quest = c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
				if (quest == null)
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
					continue;
				}
				QuestTask questTask = quest.mTasks[current.mCurrentTask];
				if (questTask == null)
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
				}
				else if (questTask.mType != c82da4aba736860aef1c9db1e5d8d1a58)
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
				}
				else
				{
					c9374c9e18d64e753feff5ba5622a02ad().c509488e7555f17435dc7dacc1709e509(OnlineService.s_characterId, current.mQuestId);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public Dictionary<int, Quest> cc1076a9627a18bd4b67cb59f4bee480a()
	{
		return m_playerQuestsInfo;
	}

	public Quest c0c8ccd79e03879ffc929ddac44fbc31c(int c731f8f565b2035819f3412520ff285b3)
	{
		Quest value = c6a1e9d9cfb0b8c14256796aa2b02d787.c7088de59e49f7108f520cf7e0bae167e;
		m_playerQuestsInfo.TryGetValue(c731f8f565b2035819f3412520ff285b3, out value);
		return value;
	}

	public Quest c1b96f9e0e0373eb0c95ff2adb3efa970(int ca754d97f0e77a3bd2a4bf8d3de0eb9f5)
	{
		Quest result = c6a1e9d9cfb0b8c14256796aa2b02d787.c7088de59e49f7108f520cf7e0bae167e;
		using (Dictionary<int, Quest>.ValueCollection.Enumerator enumerator = m_playerQuestsInfo.Values.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					Quest current = enumerator.Current;
					if (current.mCategory != QuestCategory.Objective)
					{
						continue;
					}
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
					if (!current.mBoundInstanceList.c1a84901a0a9ec83a0000feb026941d27(ca754d97f0e77a3bd2a4bf8d3de0eb9f5))
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
						result = current;
						break;
					}
					break;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0070;
					}
					continue;
					end_IL_0070:
					break;
				}
				break;
			}
		}
		return result;
	}

	public void cb5a871cb8bfa4f5acb9376850828d8bc()
	{
		List<int> list = new List<int>();
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = m_playerQuestsProgess.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				Quest quest = c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
				if (quest == null)
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
				if (quest.mCategory != QuestCategory.Objective)
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				list.Add(quest.mId);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_007a;
				}
				continue;
				end_IL_007a:
				break;
			}
		}
		using (List<int>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				int current2 = enumerator2.Current;
				m_playerQuestsProgess.Remove(current2);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}
}
