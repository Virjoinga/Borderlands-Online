using System;
using System.Collections.Generic;
using A;
using XsdSettings;

public class QuestUIDataManager : IQuestServiceNotificationListerner
{
	public delegate void DeleOnQuestStatusUpdated(int questId, QuestState questState);

	public delegate void DeleOnGetPlayerQuestProgress(Dictionary<int, QuestProgress> questProgress);

	public delegate void DeleOnRewardClaimed(int questId, QuestReward[] rewards);

	protected static QuestUIDataManager _mgrRef;

	protected DeleOnQuestStatusUpdated _deleOnQuestStatusUpdated;

	protected DeleOnGetPlayerQuestProgress _deleOnGetPlayerQuestProgress;

	protected DeleOnRewardClaimed _deleOnRewardClaimed;

	protected WeaponGeneratorService _weaponServiceRef;

	protected Dictionary<int, List<int>> _npcGiverQuests = new Dictionary<int, List<int>>();

	protected Dictionary<int, List<int>> _npcClaimerQuests = new Dictionary<int, List<int>>();

	protected Dictionary<int, QuestProgress> _playerQuestProgress = new Dictionary<int, QuestProgress>();

	protected Dictionary<int, NpcTitleMgr.NPC_ICON_TYPE> _npcTitleState = new Dictionary<int, NpcTitleMgr.NPC_ICON_TYPE>();

	protected Queue<string> _pendingEchoIDQueue = new Queue<string>();

	private QuestUIDataManager()
	{
	}

	public static QuestUIDataManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_mgrRef == null)
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
			_mgrRef = new QuestUIDataManager();
		}
		return _mgrRef;
	}

	public QuestUIData cbc6752b59485c3ca287072485ad0180b(int c8d9247e6ec97defd6456db7da9372514)
	{
		QuestUIData questUIData = new QuestUIData();
		QuestProgress value = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
		if (!_playerQuestProgress.TryGetValue(c8d9247e6ec97defd6456db7da9372514, out value))
		{
			while (true)
			{
				switch (5)
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
		questUIData._questProgress = value;
		Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(c8d9247e6ec97defd6456db7da9372514);
		if (quest == null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		questUIData._quest = quest;
		return questUIData;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		_weaponServiceRef = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>();
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7d08ed02a7697465eaaf348e5256df6d(cc4456da97d6151dc87ed8defc9f8c6cc);
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cd2beda30e19af44fd0d1bdf7f55c9f4d(cee01756f649533da47876b62a671807f);
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(this);
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0e99b4914f8c6b80f6233d720bf3d53f(cc4456da97d6151dc87ed8defc9f8c6cc);
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().c7f1091fa96379f982bfcae30e3cca0ff(cee01756f649533da47876b62a671807f);
		_mgrRef = ce9c0a468c0cff8c54a09d662782744fe.c7088de59e49f7108f520cf7e0bae167e;
		_deleOnQuestStatusUpdated = null;
		_deleOnGetPlayerQuestProgress = null;
		_deleOnRewardClaimed = null;
	}

	public void c7805303703b83f4ce9498430b0a1527b()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4bd163e6f603f6c0724372fd12f5f4cb();
	}

	public void cf7f98b1de39f26f9a9d63b5d8ac5a26b(int c8d9247e6ec97defd6456db7da9372514)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cf7f98b1de39f26f9a9d63b5d8ac5a26b(c8d9247e6ec97defd6456db7da9372514);
	}

	public void c5fdc976a8c3f9e6e8516525fd2a5396f(int c8d9247e6ec97defd6456db7da9372514)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5fdc976a8c3f9e6e8516525fd2a5396f(c8d9247e6ec97defd6456db7da9372514);
	}

	public void c8f521a1ec27bde9acc96bf16dc9821ff(DeleOnQuestStatusUpdated c8985f47f4f91c32134aa4602ac2debef)
	{
		_deleOnQuestStatusUpdated = (DeleOnQuestStatusUpdated)Delegate.Combine(_deleOnQuestStatusUpdated, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void cd35ec9bc0560c63369b10ad39d5c179b(DeleOnGetPlayerQuestProgress c8985f47f4f91c32134aa4602ac2debef)
	{
		_deleOnGetPlayerQuestProgress = (DeleOnGetPlayerQuestProgress)Delegate.Combine(_deleOnGetPlayerQuestProgress, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void c7c83d311f62c1a786291ae4fe56d1bd3(DeleOnGetPlayerQuestProgress c8985f47f4f91c32134aa4602ac2debef)
	{
		_deleOnGetPlayerQuestProgress = (DeleOnGetPlayerQuestProgress)Delegate.Remove(_deleOnGetPlayerQuestProgress, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void c50686cce5baffaa301e3f55f448c9ac8(DeleOnRewardClaimed c8985f47f4f91c32134aa4602ac2debef)
	{
		_deleOnRewardClaimed = (DeleOnRewardClaimed)Delegate.Combine(_deleOnRewardClaimed, c8985f47f4f91c32134aa4602ac2debef);
	}

	public void cc4456da97d6151dc87ed8defc9f8c6cc(InventoryServiceWrapper.InventoryUpdateType c8caa3fd8318cafc7e124efd1475a86a1)
	{
		if (c8caa3fd8318cafc7e124efd1475a86a1 != InventoryServiceWrapper.InventoryUpdateType.ItemUpdate)
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
			c7805303703b83f4ce9498430b0a1527b();
			return;
		}
	}

	public void OnQuestUpdate(int accountId, int questId, QuestState questState)
	{
		Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(questId);
		if (questState == QuestState.InProgress)
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
			if (quest != null)
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
				OnNewTask(accountId, questId, 0);
			}
		}
		c7805303703b83f4ce9498430b0a1527b();
		if (_deleOnQuestStatusUpdated == null)
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
			_deleOnQuestStatusUpdated(questId, questState);
			return;
		}
	}

	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
		Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(iQuestID);
		if (quest == null)
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
			if (quest.mTasks.Length <= iNewTaskID)
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
				if (quest.mTasks[iNewTaskID].mTaskEchoIDList == null)
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
					string[] mTaskEchoIDList = quest.mTasks[iNewTaskID].mTaskEchoIDList;
					foreach (string c54ae8359265df3301c1ea017ed36e in mTaskEchoIDList)
					{
						c8b482b5d1fbfb7f9753fba4e47dfe1d6(c54ae8359265df3301c1ea017ed36e);
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
		}
	}

	public void OnQuestProgress(int accountId, Dictionary<int, QuestProgress> questProgress)
	{
		if (questProgress == null)
		{
			while (true)
			{
				switch (6)
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
		_playerQuestProgress = questProgress;
		_npcClaimerQuests.Clear();
		_npcGiverQuests.Clear();
		_npcTitleState.Clear();
		using (Dictionary<int, QuestProgress>.Enumerator enumerator = _playerQuestProgress.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, QuestProgress> current = enumerator.Current;
				Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(current.Value.mQuestId);
				if (quest == null)
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
				int[] mGiverIdList = quest.mGiverIdList;
				foreach (int num in mGiverIdList)
				{
					List<int> value = c0fcd81bbb74675098f106281392386f3.c7088de59e49f7108f520cf7e0bae167e;
					if (!_npcGiverQuests.TryGetValue(num, out value))
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
						value = new List<int>();
						_npcGiverQuests.Add(num, value);
					}
					value.Add(quest.mId);
					c931d23d9a7de1287bf70bceabccdbd21(num, quest, current.Value);
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
				int[] mReclaimerIdList = quest.mReclaimerIdList;
				foreach (int num2 in mReclaimerIdList)
				{
					List<int> value2 = c0fcd81bbb74675098f106281392386f3.c7088de59e49f7108f520cf7e0bae167e;
					if (!_npcClaimerQuests.TryGetValue(num2, out value2))
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
						value2 = new List<int>();
						_npcClaimerQuests.Add(num2, value2);
					}
					value2.Add(quest.mId);
					c931d23d9a7de1287bf70bceabccdbd21(num2, quest, current.Value);
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
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_01a5;
				}
				continue;
				end_IL_01a5:
				break;
			}
		}
		if (_deleOnGetPlayerQuestProgress == null)
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
			_deleOnGetPlayerQuestProgress(questProgress);
			return;
		}
	}

	protected void c931d23d9a7de1287bf70bceabccdbd21(int cd65cbd799175f1375d6ecf8d91f04e56, Quest cd367ff7d36f9463c80fb2752fa976953, QuestProgress cd563a3564d781de51750031f869a03aa)
	{
		NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		NpcTitleMgr.NPC_ICON_TYPE c9f42d54a38407d4fc21972bb1dba8a = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		NpcTitleMgr.NPC_ICON_TYPE cba9ce10895c838df75d001bb79ec33ac = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		if (cd367ff7d36f9463c80fb2752fa976953.mReclaimerIdList.c1a84901a0a9ec83a0000feb026941d27(cd65cbd799175f1375d6ecf8d91f04e56))
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
			if (cd563a3564d781de51750031f869a03aa.mStatus == QuestState.InProgress)
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
				cba9ce10895c838df75d001bb79ec33ac = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS;
			}
			else if (cd563a3564d781de51750031f869a03aa.mStatus == QuestState.Completed)
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
				if (cd367ff7d36f9463c80fb2752fa976953.mCategory == QuestCategory.Daily)
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
					cba9ce10895c838df75d001bb79ec33ac = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE;
				}
				else if (cd367ff7d36f9463c80fb2752fa976953.mCategory == QuestCategory.Special)
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
					cba9ce10895c838df75d001bb79ec33ac = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE;
				}
				else
				{
					cba9ce10895c838df75d001bb79ec33ac = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE;
				}
			}
		}
		if (cd367ff7d36f9463c80fb2752fa976953.mGiverIdList.c1a84901a0a9ec83a0000feb026941d27(cd65cbd799175f1375d6ecf8d91f04e56))
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
			if (cd563a3564d781de51750031f869a03aa.mStatus == QuestState.Available)
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
				if (cd367ff7d36f9463c80fb2752fa976953.mCategory == QuestCategory.Daily)
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
					c9f42d54a38407d4fc21972bb1dba8a = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW;
				}
				else if (cd367ff7d36f9463c80fb2752fa976953.mCategory == QuestCategory.Special)
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
					c9f42d54a38407d4fc21972bb1dba8a = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW;
				}
				else
				{
					c9f42d54a38407d4fc21972bb1dba8a = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW;
				}
			}
		}
		nPC_ICON_TYPE = c5fdc8b15eeab047a4bab41eb8031cd31(c9f42d54a38407d4fc21972bb1dba8a, cba9ce10895c838df75d001bb79ec33ac);
		NpcTitleMgr.NPC_ICON_TYPE value = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		if (!_npcTitleState.TryGetValue(cd65cbd799175f1375d6ecf8d91f04e56, out value))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					_npcTitleState.Add(cd65cbd799175f1375d6ecf8d91f04e56, nPC_ICON_TYPE);
					return;
				}
			}
		}
		_npcTitleState[cd65cbd799175f1375d6ecf8d91f04e56] = c5fdc8b15eeab047a4bab41eb8031cd31(nPC_ICON_TYPE, value);
	}

	protected NpcTitleMgr.NPC_ICON_TYPE c5fdc8b15eeab047a4bab41eb8031cd31(NpcTitleMgr.NPC_ICON_TYPE c9f42d54a38407d4fc21972bb1dba8a49, NpcTitleMgr.NPC_ICON_TYPE cba9ce10895c838df75d001bb79ec33ac)
	{
		NpcTitleMgr.NPC_ICON_TYPE result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
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
			if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW)
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
					if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW)
					{
						if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE)
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
							if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE)
							{
								if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW)
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
									if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW)
									{
										if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS)
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
											if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS)
											{
												if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW)
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
													if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW)
													{
														if (c9f42d54a38407d4fc21972bb1dba8a49 != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
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
															if (cba9ce10895c838df75d001bb79ec33ac != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
															{
																goto IL_00f2;
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
														result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE;
														goto IL_00f2;
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
												}
												result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW;
												goto IL_00f2;
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
										}
										result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS;
										goto IL_00f2;
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
								result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW;
								goto IL_00f2;
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
						}
						result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE;
						goto IL_00f2;
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
				result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW;
				goto IL_00f2;
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
		}
		result = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE;
		goto IL_00f2;
		IL_00f2:
		return result;
	}

	public NpcTitleMgr.NPC_ICON_TYPE cb2eb54c3368a58ea14ecbe8882783c55(int cd65cbd799175f1375d6ecf8d91f04e56)
	{
		NpcTitleMgr.NPC_ICON_TYPE value = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		_npcTitleState.TryGetValue(cd65cbd799175f1375d6ecf8d91f04e56, out value);
		return value;
	}

	public void OnQuestRewardClaimed(int accountId, int questId, QuestReward[] rewards)
	{
		c7805303703b83f4ce9498430b0a1527b();
		if (_deleOnRewardClaimed == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_deleOnRewardClaimed(questId, rewards);
			return;
		}
	}

	public void OnQuestAccepted(int accountId, int questId)
	{
	}

	public List<int> c76d93063702ae290eec41bbb845f9011(int cd65cbd799175f1375d6ecf8d91f04e56)
	{
		List<int> value = c0fcd81bbb74675098f106281392386f3.c7088de59e49f7108f520cf7e0bae167e;
		_npcGiverQuests.TryGetValue(cd65cbd799175f1375d6ecf8d91f04e56, out value);
		return value;
	}

	public List<int> cec44ef982b992f6b2fb51d06ccf6705b(int cd65cbd799175f1375d6ecf8d91f04e56)
	{
		List<int> value = c0fcd81bbb74675098f106281392386f3.c7088de59e49f7108f520cf7e0bae167e;
		_npcClaimerQuests.TryGetValue(cd65cbd799175f1375d6ecf8d91f04e56, out value);
		return value;
	}

	public NpcTitleMgr.NPC_ICON_TYPE ca481ed3c1b498d8142b62adaf2d68067(int ca754d97f0e77a3bd2a4bf8d3de0eb9f5, int c7486913f1565c2422cca435709ed0d68 = -1)
	{
		NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		if (_playerQuestProgress != null)
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
			using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = _playerQuestProgress.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					QuestProgress current = enumerator.Current;
					if (current.mStatus != QuestState.InProgress)
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
					Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
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
					if (!quest.mIsBoundInstance)
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
					if (!quest.mBoundInstanceList.c1a84901a0a9ec83a0000feb026941d27(ca754d97f0e77a3bd2a4bf8d3de0eb9f5))
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
					if (quest.mRequiredDifficulty != c7486913f1565c2422cca435709ed0d68)
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
						if (quest.mRequiredDifficulty != -1)
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
						if (c7486913f1565c2422cca435709ed0d68 != 0)
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
					if (quest.mCategory != QuestCategory.Daily)
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
						nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE;
					}
					else
					{
						if (nPC_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
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
						nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0120;
					}
					continue;
					end_IL_0120:
					break;
				}
			}
		}
		return nPC_ICON_TYPE;
	}

	protected void c8b482b5d1fbfb7f9753fba4e47dfe1d6(string c54ae8359265df3301c1ea017ed36e898)
	{
		if (NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cd885bd4479d20f52c6f209bf46f58b98)
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
					_pendingEchoIDQueue.Enqueue(c54ae8359265df3301c1ea017ed36e898);
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(c54ae8359265df3301c1ea017ed36e898);
	}

	protected void cee01756f649533da47876b62a671807f(bool c9385a8b4aa29165e7f6c6d3bfcf4c20b)
	{
		if (c9385a8b4aa29165e7f6c6d3bfcf4c20b)
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
			while (_pendingEchoIDQueue.Count > 0)
			{
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(_pendingEchoIDQueue.Dequeue());
			}
			while (true)
			{
				switch (2)
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
