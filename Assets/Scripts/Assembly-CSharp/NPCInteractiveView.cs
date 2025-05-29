using System.Collections.Generic;
using A;
using XsdSettings;

public class NPCInteractiveView : BaseView
{
	public class FunctionListItemData
	{
		public QuestUIData questData;

		public NPC_UIFlowController.NPC_UIFlowState functionType;

		public bool bAlwaysInBoard;
	}

	protected XsdSettings.TownNpc _NPCInfo;

	protected List<QuestUIData> _onShowQuestData;

	protected List<FunctionListItemData> _functionDataList = new List<FunctionListItemData>();

	public static int MAX_FUNCTION_ITEM_COUNT = 6;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_onShowQuestData = new List<QuestUIData>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd35ec9bc0560c63369b10ad39d5c179b(c33ac4c0f51cd32dd024d0a97c2350cdf);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (_bVisible)
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
					NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
	}

	public virtual void cf15a2a34d3ddcc09914934a114ef53e0(XsdSettings.TownNpc cd127046b3a39f56884ba24c3480a96d3)
	{
		_NPCInfo = cd127046b3a39f56884ba24c3480a96d3;
		c712f9c0b3e4a2ea0d836c8558b45a625();
		ceb879c61288940491aaed074feee1d20();
	}

	public void c1355bc0152e0d2e697663842a602d128()
	{
		c712f9c0b3e4a2ea0d836c8558b45a625();
		ceb879c61288940491aaed074feee1d20();
	}

	protected int c8f990c2115fa582b418381e534d17dea(QuestUIData c7b08d4a355fe61c985a43a1bf77bac64, QuestUIData c371e172059105afe6b38fdbfef39c0c2)
	{
		return c7b08d4a355fe61c985a43a1bf77bac64._quest.mId - c371e172059105afe6b38fdbfef39c0c2._quest.mId;
	}

	protected void c33ac4c0f51cd32dd024d0a97c2350cdf(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		c712f9c0b3e4a2ea0d836c8558b45a625();
		ceb879c61288940491aaed074feee1d20();
	}

	protected void c712f9c0b3e4a2ea0d836c8558b45a625()
	{
		_onShowQuestData.Clear();
		if (_NPCInfo != null)
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
			List<int> list = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c76d93063702ae290eec41bbb845f9011(_NPCInfo.m_id);
			if (list != null)
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
				using (List<int>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int current = enumerator.Current;
						QuestUIData questUIData = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cbc6752b59485c3ca287072485ad0180b(current);
						if (questUIData._questProgress == null)
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
						if (questUIData._questProgress.mStatus != QuestState.Available)
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
						_onShowQuestData.Add(questUIData);
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_00bb;
						}
						continue;
						end_IL_00bb:
						break;
					}
				}
			}
			List<int> list2 = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cec44ef982b992f6b2fb51d06ccf6705b(_NPCInfo.m_id);
			if (list2 != null)
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
				using (List<int>.Enumerator enumerator2 = list2.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						int current2 = enumerator2.Current;
						QuestUIData questUIData2 = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cbc6752b59485c3ca287072485ad0180b(current2);
						if (questUIData2._questProgress == null)
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
						if (questUIData2._questProgress.mStatus != QuestState.InProgress)
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
							if (questUIData2._questProgress.mStatus != QuestState.Completed)
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
						c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
						if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943() < questUIData2._quest.mRequiredLevel)
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
						_onShowQuestData.Add(questUIData2);
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							goto end_IL_01c7;
						}
						continue;
						end_IL_01c7:
						break;
					}
				}
			}
		}
		_onShowQuestData.Sort(c8f990c2115fa582b418381e534d17dea);
	}

	protected virtual void ceb879c61288940491aaed074feee1d20()
	{
		_functionDataList.Clear();
		if (_NPCInfo != null)
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
			if (_NPCInfo.m_occupations != null)
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
				int num = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
				NpcOccupation[] occupations = _NPCInfo.m_occupations;
				foreach (NpcOccupation npcOccupation in occupations)
				{
					FunctionListItemData functionListItemData = new FunctionListItemData();
					functionListItemData.bAlwaysInBoard = true;
					switch (npcOccupation)
					{
					case NpcOccupation.Crafting:
						if (num < LevelingManager.CRAFTING_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Crafting;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.Melting:
						if (num < LevelingManager.MELTING_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Melting;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.Guild:
						if (num < LevelingManager.CREATEGUILD_UNLOCK_LEVEL)
						{
							break;
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
						if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c50c0301c45aeaef550d68b8337bd23b2())
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
							functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.CreateGuild;
							_functionDataList.Add(functionListItemData);
						}
						if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c17ba091c28b756583dc29d3eec870622())
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
							FunctionListItemData functionListItemData2 = new FunctionListItemData();
							functionListItemData2.bAlwaysInBoard = true;
							functionListItemData2.functionType = NPC_UIFlowController.NPC_UIFlowState.DismissGuild;
							_functionDataList.Add(functionListItemData2);
						}
						else
						{
							if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd19cb80dca29b5c813acffe07d4eb050())
							{
								break;
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
							FunctionListItemData functionListItemData3 = new FunctionListItemData();
							functionListItemData3.bAlwaysInBoard = true;
							functionListItemData3.functionType = NPC_UIFlowController.NPC_UIFlowState.QuitGuild;
							_functionDataList.Add(functionListItemData3);
						}
						break;
					case NpcOccupation.Mail:
						if (num < LevelingManager.MAIL_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Mail;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.WeaponShop:
						if (num < LevelingManager.SELLING_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.WeaponShop;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.CoinShieldShop:
						if (num < LevelingManager.SELLING_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.CoinShieldShop;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.ClassModeShop:
						if (num < LevelingManager.CLASSMODESHOP_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.ClassModeShop;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.Warehouse:
						if (num < LevelingManager.WAREHOUSE_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Warehouse;
						_functionDataList.Add(functionListItemData);
						break;
					case NpcOccupation.WeaponUpgrade:
						if (num < LevelingManager.UPGRADE_UNLOCK_LEVEL)
						{
							break;
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
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.WeaponUpgrade;
						_functionDataList.Add(functionListItemData);
						break;
					}
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
			}
		}
		for (int j = 0; j < _onShowQuestData.Count; j++)
		{
			FunctionListItemData functionListItemData4 = new FunctionListItemData();
			functionListItemData4.questData = _onShowQuestData[j];
			functionListItemData4.functionType = NPC_UIFlowController.NPC_UIFlowState.Quest;
			_functionDataList.Add(functionListItemData4);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			FunctionListItemData functionListItemData5 = new FunctionListItemData();
			functionListItemData5.functionType = NPC_UIFlowController.NPC_UIFlowState.None;
			functionListItemData5.bAlwaysInBoard = true;
			_functionDataList.Add(functionListItemData5);
			return;
		}
	}

	public virtual void cbbb55bdde473e2f1c0bc8f9214dd7dff(FunctionListItemData cb4be6dae1755138c26d22542471266a1)
	{
		if (cb4be6dae1755138c26d22542471266a1.functionType == NPC_UIFlowController.NPC_UIFlowState.Quest)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cca0442ccb623885a072dc61860e6655c().CurQuestData = cb4be6dae1755138c26d22542471266a1.questData;
					QuestProgress questProgress = cb4be6dae1755138c26d22542471266a1.questData._questProgress;
					if (questProgress != null)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								if (questProgress.mStatus == QuestState.Available)
								{
									while (true)
									{
										switch (4)
										{
										case 0:
											break;
										default:
											NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.NpcDialog);
											return;
										}
									}
								}
								if (questProgress.mStatus == QuestState.InProgress)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.Quest);
											return;
										}
									}
								}
								if (questProgress.mStatus == QuestState.Completed)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
											NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.NpcDialog);
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		if (cb4be6dae1755138c26d22542471266a1.functionType == NPC_UIFlowController.NPC_UIFlowState.DismissGuild)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c375b2f5564171f0063c8aa9c5f2f9c91();
					ceb879c61288940491aaed074feee1d20();
					return;
				}
			}
		}
		if (cb4be6dae1755138c26d22542471266a1.functionType == NPC_UIFlowController.NPC_UIFlowState.QuitGuild)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd19cb80dca29b5c813acffe07d4eb050())
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
						GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd7f2c3b464455db93ee7e906dea031be();
					}
					NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
					ceb879c61288940491aaed074feee1d20();
					return;
				}
			}
		}
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(cb4be6dae1755138c26d22542471266a1.functionType);
	}
}
