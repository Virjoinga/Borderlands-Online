using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using XsdSettings;

internal class QuestService : OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>, IQuestService
{
	private class QuestRequirementInfo
	{
		public const int Type = 0;

		public const int Value = 1;

		public const int TargetId = 2;

		public const int AttackId = 3;

		public const int Progress = 4;

		public const int TaskId = 5;

		public const int Id = 6;

		public const int TimeLimit = 7;
	}

	public delegate void QuestProgressCallback(int characterId, Dictionary<int, QuestProgress> progress);

	private Dictionary<int, Dictionary<int, QuestProgress>> mCachedPlayerQuests = new Dictionary<int, Dictionary<int, QuestProgress>>();

	private List<QuestAcceptedCallback> mQuestAcceptedCallbacks = new List<QuestAcceptedCallback>();

	private List<QuestStatusCallback> mQuestStatusCallbacks = new List<QuestStatusCallback>();

	private List<QuestTaskUpdatedCallback> mQuestTaskUpdatedCallbacks = new List<QuestTaskUpdatedCallback>();

	private List<QuestRewardClaimedCallback> mQuestRewardsClaimedCallbacks = new List<QuestRewardClaimedCallback>();

	private List<ClearPlayerDailyQuestCallback> mClearDailyQuestCallbacks = new List<ClearPlayerDailyQuestCallback>();

	private List<GetPlayerDailyQuestsContentCallback> mPlayerDailyQuestsContentCallbacks = new List<GetPlayerDailyQuestsContentCallback>();

	private GetPlayerQuestsCallback mGetPlayerQuestsCallback;

	private TalkToNPCCallback mTalkToNPCCallback;

	private BringToNPCCallback mBringToNPCCallback;

	[CompilerGenerated]
	private static Action<ClearPlayerDailyQuestCallback> _003C_003Ef__am_0024cacheA;

	public QuestService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(185, OnGetPlayerQuests);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(181, OnClaimQuestRewards);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(183, OnGetPlayerQuests);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(184, OnAcceptQuest);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(150, OnTalkToNPC);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(145, OnBringToNPC);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(141, OnGetDailyQuestContents);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(220, OnQuestStatusUpdated);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(217, OnQuestTaskCompleted);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(170, OnQuestClearDailyQuest);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(169, OnQuestTaskUpdated);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(215, OnQuestRewardClaimed);
	}

	public Dictionary<int, QuestProgress> c4bd163e6f603f6c0724372fd12f5f4cb(int c5dfde30d8784694fb9999709d290e6c4, GetPlayerQuestsCallback c2db84530ef366a6deb001d449d4aa151 = null)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
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
			mGetPlayerQuestsCallback = c2db84530ef366a6deb001d449d4aa151;
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(185, array);
		if (mCachedPlayerQuests.ContainsKey(c5dfde30d8784694fb9999709d290e6c4))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return mCachedPlayerQuests[c5dfde30d8784694fb9999709d290e6c4];
				}
			}
		}
		return null;
	}

	public void OnGetPlayerQuests(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			int num = (int)parameters[0];
			Hashtable hashtable = (Hashtable)parameters[1];
			mCachedPlayerQuests[num] = new Dictionary<int, QuestProgress>();
			IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Hashtable hashtable2 = (Hashtable)((DictionaryEntry)enumerator.Current).Value;
					if (hashtable2[1] == null)
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
					int num2 = (int)hashtable2[0];
					int mStatus = (int)hashtable2[1];
					int mCurrentTask = (int)hashtable2[2];
					int mTaskProgress = (int)hashtable2[3];
					mCachedPlayerQuests[num][num2] = new QuestProgress
					{
						mQuestId = num2,
						mStatus = (QuestState)mStatus,
						mCurrentTask = mCurrentTask,
						mTaskProgress = mTaskProgress
					};
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0139;
					}
					continue;
					end_IL_0139:
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
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_0151;
						}
						continue;
						end_IL_0151:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			if (mGetPlayerQuestsCallback == null)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				mGetPlayerQuestsCallback(num, mCachedPlayerQuests[num]);
				mGetPlayerQuestsCallback = c72e0d8ff1d99028d74501f96fa5e4c0b.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}
	}

	public void cf7f98b1de39f26f9a9d63b5d8ac5a26b(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c731f8f565b2035819f3412520ff285b3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(184, array);
	}

	public void OnAcceptQuest(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int num = (int)parameters[0];
					int num2 = (int)parameters[1];
					if ((bool)parameters[2])
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
						if (mCachedPlayerQuests.ContainsKey(num))
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
							if (mCachedPlayerQuests[num].ContainsKey(num2))
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
						}
					}
					else
					{
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "On accept quest fail, accountId : ";
						array[1] = num;
						array[2] = "  questId ";
						array[3] = num2;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array));
					}
					using (List<QuestAcceptedCallback>.Enumerator enumerator = mQuestAcceptedCallbacks.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							QuestAcceptedCallback current = enumerator.Current;
							current(num, num2);
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
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "On accept quest request fail, operationResponse : " + operationResponse);
	}

	public void cddb1928d6bb517752689884a3e06f40b(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c731f8f565b2035819f3412520ff285b3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(215, array);
	}

	public void c3f047aa9d6b8fd920083294a0346ccc1(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3, int c43e3d8b3e47e153da82a98666f9b6412, int ccb48c4078e19a9f7fc9ba8e31a1288d6)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c731f8f565b2035819f3412520ff285b3;
		array[2] = c43e3d8b3e47e153da82a98666f9b6412;
		array[3] = ccb48c4078e19a9f7fc9ba8e31a1288d6;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(183, array);
	}

	private void OnQuestStatusUpdated(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int questId = (int)parameters[1];
		QuestState questStatus = (QuestState)(int)parameters[2];
		if (mCachedPlayerQuests.ContainsKey(accountId))
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
			if (mCachedPlayerQuests[accountId].ContainsKey(questId))
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
				mCachedPlayerQuests[accountId][questId].mStatus = questStatus;
			}
		}
		mQuestStatusCallbacks.ForEach(delegate(QuestStatusCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(accountId, questId, questStatus);
		});
	}

	private void OnQuestRewardClaimed(Dictionary<byte, object> parameters)
	{
	}

	private void OnQuestTaskCompleted(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int questId = (int)parameters[1];
		if (mCachedPlayerQuests.ContainsKey(accountId))
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
			if (mCachedPlayerQuests[accountId].ContainsKey(questId))
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
				mCachedPlayerQuests[accountId][questId].mCurrentTask++;
				mCachedPlayerQuests[accountId][questId].mTaskProgress = 0;
			}
		}
		mQuestStatusCallbacks.ForEach(delegate(QuestStatusCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(accountId, questId, QuestState.InProgress);
		});
	}

	private void OnQuestTaskUpdated(Dictionary<byte, object> parameters)
	{
		int accountId = (int)parameters[0];
		int questId = (int)parameters[1];
		int progress = (int)parameters[2];
		if (mCachedPlayerQuests.ContainsKey(accountId))
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
			if (mCachedPlayerQuests[accountId].ContainsKey(questId))
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
				mCachedPlayerQuests[accountId][questId].mTaskProgress = progress;
			}
		}
		mQuestTaskUpdatedCallbacks.ForEach(delegate(QuestTaskUpdatedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(accountId, questId, progress);
		});
	}

	public void c509488e7555f17435dc7dacc1709e509(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c731f8f565b2035819f3412520ff285b3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(142, array);
	}

	public void c5fdc976a8c3f9e6e8516525fd2a5396f(int c5dfde30d8784694fb9999709d290e6c4, int c731f8f565b2035819f3412520ff285b3)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = c731f8f565b2035819f3412520ff285b3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(181, array);
	}

	public void c4c0bdfafe8e95354b5fbeb52e4c32d3d(QuestAcceptedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestAcceptedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cbe020d7b7dd96a242148f08477c57582(QuestAcceptedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestAcceptedCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c44c96f389ef3a2876896b4e3f64f453c(QuestStatusCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestStatusCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c8e1b83ac972d3a3db99bd02e093b9ce6(QuestStatusCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestStatusCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c530831a7ae824f7a624d7d8e23a5a064(QuestRewardClaimedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestRewardsClaimedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c6afb3d035c93bd9d70ad1a106444d70e(QuestRewardClaimedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestRewardsClaimedCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnClaimQuestRewards(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
		{
			return;
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
			if (!(bool)parameters[0])
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
				int characterId = (int)parameters[1];
				int questId = (int)parameters[2];
				Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(questId);
				if (parameters.ContainsKey(3))
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
					OnGetPlayerQuests(operationResponse, new Dictionary<byte, object>
					{
						{ 0, characterId },
						{
							1,
							parameters[3]
						}
					});
				}
				if (mCachedPlayerQuests.ContainsKey(characterId))
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
					if (mCachedPlayerQuests[characterId].ContainsKey(questId))
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
						mCachedPlayerQuests[characterId][questId].mStatus = QuestState.RewardClaimed;
					}
				}
				mQuestRewardsClaimedCallbacks.ForEach(delegate(QuestRewardClaimedCallback c2db84530ef366a6deb001d449d4aa151)
				{
					c2db84530ef366a6deb001d449d4aa151(characterId, questId, quest.mRewards);
				});
				PhotonNetwork.networkingPeer.c3f632fdd31c8a3f2463924fbc1ced8b4(215, new Hashtable
				{
					{ 0, characterId },
					{ 1, questId }
				}, true, 0);
				return;
			}
		}
	}

	public void cb534083a07db3bd6b74a38a62625f875(TalkToNPCCallback c2db84530ef366a6deb001d449d4aa151, int c731f8f565b2035819f3412520ff285b3, int c43e3d8b3e47e153da82a98666f9b6412)
	{
		mTalkToNPCCallback = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c731f8f565b2035819f3412520ff285b3;
		array[1] = c43e3d8b3e47e153da82a98666f9b6412;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(150, array);
	}

	private void OnTalkToNPC(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mTalkToNPCCallback == null)
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
			if (operationResponse == 0)
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
				int key = (int)parameters[0];
				Hashtable hashtable = (Hashtable)parameters[1];
				mCachedPlayerQuests[key] = new Dictionary<int, QuestProgress>();
				IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Hashtable hashtable2 = (Hashtable)((DictionaryEntry)enumerator.Current).Value;
						if (hashtable2[1] == null)
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
						int num = (int)hashtable2[0];
						int mStatus = (int)hashtable2[1];
						int mCurrentTask = (int)hashtable2[2];
						int mTaskProgress = (int)hashtable2[3];
						mCachedPlayerQuests[key][num] = new QuestProgress
						{
							mQuestId = num,
							mStatus = (QuestState)mStatus,
							mCurrentTask = mCurrentTask,
							mTaskProgress = mTaskProgress
						};
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_014e;
						}
						continue;
						end_IL_014e:
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
							switch (5)
							{
							case 0:
								break;
							default:
								goto end_IL_0166;
							}
							continue;
							end_IL_0166:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
				mTalkToNPCCallback(true, mCachedPlayerQuests[key]);
			}
			else
			{
				mTalkToNPCCallback(false, cba13dcc199c4905ac0a8b942ce266625.c7088de59e49f7108f520cf7e0bae167e);
			}
			mTalkToNPCCallback = c51de75badcaeed32128802e83e041469.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c069e3e12ab95ff8518fd20364724de3f(BringToNPCCallback c2db84530ef366a6deb001d449d4aa151, int c731f8f565b2035819f3412520ff285b3, int c43e3d8b3e47e153da82a98666f9b6412)
	{
		mBringToNPCCallback = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c731f8f565b2035819f3412520ff285b3;
		array[1] = c43e3d8b3e47e153da82a98666f9b6412;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(145, array);
	}

	private void OnBringToNPC(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mBringToNPCCallback == null)
		{
			return;
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
			if (operationResponse == 0)
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
				int key = (int)parameters[0];
				Hashtable hashtable = (Hashtable)parameters[1];
				mCachedPlayerQuests[key] = new Dictionary<int, QuestProgress>();
				IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Hashtable hashtable2 = (Hashtable)((DictionaryEntry)enumerator.Current).Value;
						if (hashtable2[1] == null)
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
						int num = (int)hashtable2[0];
						int mStatus = (int)hashtable2[1];
						int mCurrentTask = (int)hashtable2[2];
						int mTaskProgress = (int)hashtable2[3];
						mCachedPlayerQuests[key][num] = new QuestProgress
						{
							mQuestId = num,
							mStatus = (QuestState)mStatus,
							mCurrentTask = mCurrentTask,
							mTaskProgress = mTaskProgress
						};
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_014e;
						}
						continue;
						end_IL_014e:
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
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_0166;
							}
							continue;
							end_IL_0166:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
				mBringToNPCCallback(true, mCachedPlayerQuests[key]);
			}
			else
			{
				mBringToNPCCallback(false, cba13dcc199c4905ac0a8b942ce266625.c7088de59e49f7108f520cf7e0bae167e);
			}
			mBringToNPCCallback = c9376eb30f00ab624a2053400512b75ef.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnQuestClearDailyQuest(Dictionary<byte, object> parameters)
	{
		List<ClearPlayerDailyQuestCallback> list = mClearDailyQuestCallbacks;
		if (_003C_003Ef__am_0024cacheA == null)
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
			_003C_003Ef__am_0024cacheA = delegate(ClearPlayerDailyQuestCallback c2db84530ef366a6deb001d449d4aa151)
			{
				c2db84530ef366a6deb001d449d4aa151();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cacheA);
	}

	public void c43f812e5db31871c2108e9f7fc8a0a73()
	{
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(141, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetDailyQuestContents(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
		{
			return;
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
			Hashtable hashtable = (Hashtable)parameters[0];
			Dictionary<int, DailyQuestInfo> dailyquestinfo = new Dictionary<int, DailyQuestInfo>();
			IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Hashtable hashtable2 = (Hashtable)((DictionaryEntry)enumerator.Current).Value;
					if (hashtable2[0] == null)
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
					int key = (int)hashtable2[0];
					int mQuestId = (int)hashtable2[1];
					dailyquestinfo[key] = new DailyQuestInfo
					{
						mQuestId = mQuestId
					};
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00d7;
					}
					continue;
					end_IL_00d7:
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
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_00ef;
						}
						continue;
						end_IL_00ef:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
			mPlayerDailyQuestsContentCallbacks.ForEach(delegate(GetPlayerDailyQuestsContentCallback c2db84530ef366a6deb001d449d4aa151)
			{
				c2db84530ef366a6deb001d449d4aa151(dailyquestinfo);
			});
			return;
		}
	}

	public void ca52c9e2259d0b538edee5722aa748096(ClearPlayerDailyQuestCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mClearDailyQuestCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0c336d0d64368b160010636a617db4c9(ClearPlayerDailyQuestCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mClearDailyQuestCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cb78578f9da078d41ec650239fe560809(GetPlayerDailyQuestsContentCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mPlayerDailyQuestsContentCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c91b792cd17eeffdb90b3a76f4b83c112(GetPlayerDailyQuestsContentCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mPlayerDailyQuestsContentCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cea4bda9fd29c6859ef594d46facfb65f(QuestTaskUpdatedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestTaskUpdatedCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0a7803c9d2d935629e59a92899fcdde9(QuestTaskUpdatedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mQuestTaskUpdatedCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	[CompilerGenerated]
	private static void c12de56398bbde7f5ddc04174219ca523(ClearPlayerDailyQuestCallback c2db84530ef366a6deb001d449d4aa151)
	{
		c2db84530ef366a6deb001d449d4aa151();
	}
}
