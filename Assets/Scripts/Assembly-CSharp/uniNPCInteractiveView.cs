using System;
using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniNPCInteractiveView : NPCInteractiveView
{
	public class NPCFunctionList : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip _rootMC;

		protected cf7ac05203029a27299d6893b2dbaee2e _scBar = new cf7ac05203029a27299d6893b2dbaee2e();

		protected UnityTextField _textNpcName;

		protected UnityTextField _textGreeting;

		protected string _strListNamePrefix = "mcNPCItem_";

		protected List<FunctionListItemData> _allItemInfoList = new List<FunctionListItemData>();

		protected NPCFunctionListButton[] _functionItemList = new NPCFunctionListButton[NPCInteractiveView.MAX_FUNCTION_ITEM_COUNT];

		protected deleOnClickButton _deleOnClickButton;

		protected int _iOnShowItemCnt;

		protected int _iMaxScrollableItemCnt;

		public deleOnClickButton ce6a1efd8cfc56612b84fe8a69afa5a98
		{
			set
			{
				_deleOnClickButton = value;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains(_strListNamePrefix))
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
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				int num = Convert.ToInt32(array2[1]);
				if (_functionItemList[num - 1] == null)
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
					_functionItemList[num - 1] = new NPCFunctionListButton();
					_functionItemList[num - 1].ce6a1efd8cfc56612b84fe8a69afa5a98 = _deleOnClickButton;
				}
				_functionItemList[num - 1].c130648b59a0c8debea60aa153f844879(movieClip);
				result = true;
			}
			else if (movieClip.name == "mcScrollingBar")
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
				_scBar.c130648b59a0c8debea60aa153f844879(movieClip);
				_scBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
				_scBar.cfcb3294d851a0336d3f3a8f2a943f2fb = (_scBar.c9c58dff860effc1212c1afb5d14e147c = 0);
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_textNpcName = (UnityTextField)_rootMC.getChildByName<TextField>("textNpcName");
			_textGreeting = (UnityTextField)_rootMC.getChildByName<TextField>("textGreeting");
		}

		protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			ceb879c61288940491aaed074feee1d20();
		}

		public void cf15a2a34d3ddcc09914934a114ef53e0(string c69bbcff276f878596b0229ec36370bd6, string c15125949bf0d22d7bbc91e7094d0ff51)
		{
			if (_textNpcName != null)
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
				_textNpcName.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c69bbcff276f878596b0229ec36370bd6));
			}
			if (_textGreeting == null)
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
				_textGreeting.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c15125949bf0d22d7bbc91e7094d0ff51));
				return;
			}
		}

		public void c30354725d9512975d57fd5b6d6e3d930(List<FunctionListItemData> cc53ad5ff0efd61d4fbc172779b049c06)
		{
			_allItemInfoList = cc53ad5ff0efd61d4fbc172779b049c06;
			if (_scBar != null)
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
				_scBar.c150264a18c2cb408479d3f072cac8cc1 = _allItemInfoList.Count > 6;
				_scBar.c5a7d812d0a8e674b21eb0ed8824a2f59(_functionItemList.Length, 0, cc53ad5ff0efd61d4fbc172779b049c06.Count - _functionItemList.Length, 1);
				_scBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			}
			int iOnShowItemCnt;
			if (_functionItemList.Length > cc53ad5ff0efd61d4fbc172779b049c06.Count)
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
				iOnShowItemCnt = cc53ad5ff0efd61d4fbc172779b049c06.Count;
			}
			else
			{
				iOnShowItemCnt = _functionItemList.Length;
			}
			_iOnShowItemCnt = iOnShowItemCnt;
			int num = 0;
			using (List<FunctionListItemData>.Enumerator enumerator = _allItemInfoList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FunctionListItemData current = enumerator.Current;
					if (!current.bAlwaysInBoard)
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
					num++;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_00e0;
					}
					continue;
					end_IL_00e0:
					break;
				}
			}
			_iMaxScrollableItemCnt = _functionItemList.Length - num;
			ceb879c61288940491aaed074feee1d20();
		}

		protected void ceb879c61288940491aaed074feee1d20()
		{
			List<FunctionListItemData> list = new List<FunctionListItemData>();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < _allItemInfoList.Count; i++)
			{
				FunctionListItemData functionListItemData = _allItemInfoList[i];
				if (functionListItemData == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (functionListItemData.bAlwaysInBoard)
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
					list.Add(functionListItemData);
				}
				else if (num < _scBar.cef9712200bbe2c3873eec3ca2e18a595)
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
					num++;
				}
				else
				{
					if (num2 >= _iMaxScrollableItemCnt)
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
					list.Add(functionListItemData);
					num2++;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				int j;
				for (j = 0; j < list.Count; j++)
				{
					FunctionListItemData functionListItemData2 = list[j];
					NPCFunctionListButton nPCFunctionListButton = _functionItemList[j];
					if (functionListItemData2 == null)
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
					if (nPCFunctionListButton == null)
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
					nPCFunctionListButton.cdce6c95b6510115e804fad74215d4975(functionListItemData2);
					nPCFunctionListButton.c43cbb41bf755dfa61de619fc6e86ab31(true);
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
				for (; j < _functionItemList.Length; j++)
				{
					NPCFunctionListButton nPCFunctionListButton2 = _functionItemList[j];
					if (nPCFunctionListButton2 == null)
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
					nPCFunctionListButton2.c43cbb41bf755dfa61de619fc6e86ab31(false);
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

	public class NPCFunctionListButton : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip _rootMC;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _rootBtn;

		protected NPCFunctionListSlot _relateItem;

		protected FunctionListItemData _relateFunctionInfo;

		protected deleOnClickButton _deleOnClickButton;

		public deleOnClickButton ce6a1efd8cfc56612b84fe8a69afa5a98
		{
			set
			{
				_deleOnClickButton = value;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_relateItem = new NPCFunctionListSlot();
			_relateItem.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcListItem"));
			_rootBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			_rootBtn.c130648b59a0c8debea60aa153f844879(_rootMC);
			_rootBtn.addEventListener(MouseEvent.CLICK, cbbb55bdde473e2f1c0bc8f9214dd7dff);
			cee3f7e1f2fe80146187019ef16248436();
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			if (base.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
				base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}

		protected void cbbb55bdde473e2f1c0bc8f9214dd7dff(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_deleOnClickButton == null)
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
				_deleOnClickButton(_relateFunctionInfo);
				return;
			}
		}

		public void cdce6c95b6510115e804fad74215d4975(FunctionListItemData c6e9a2c994c3398aadf8464b69b2fe412)
		{
			_relateFunctionInfo = c6e9a2c994c3398aadf8464b69b2fe412;
			cee3f7e1f2fe80146187019ef16248436();
		}

		protected void cee3f7e1f2fe80146187019ef16248436()
		{
			if (_relateFunctionInfo == null)
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
						_rootMC.visible = false;
						return;
					}
				}
			}
			_relateItem.ce008cdd349394595bf6ed3502a887365(_relateFunctionInfo);
		}
	}

	public class NPCFunctionListSlot : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip _rootMC;

		protected NPCFunctionListItem _Item;

		protected FunctionListItemData _data;

		protected string _strListItemName = string.Empty;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_rootMC.visible = false;
			_Item = new NPCFunctionListItem();
			_rootMC.addEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
		}

		public void ce008cdd349394595bf6ed3502a887365(FunctionListItemData c7721e9a4be5d57f072a5828495add783)
		{
			_data = c7721e9a4be5d57f072a5828495add783;
			if (c7721e9a4be5d57f072a5828495add783 == null)
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
						_rootMC.visible = false;
						return;
					}
				}
			}
			_strListItemName = "mcListItem_";
			string text = "Common";
			switch (c7721e9a4be5d57f072a5828495add783.functionType)
			{
			case NPC_UIFlowController.NPC_UIFlowState.None:
				text = "Close";
				break;
			case NPC_UIFlowController.NPC_UIFlowState.Quest:
				text = "Quest";
				break;
			}
			_strListItemName += text;
			_rootMC.gotoAndStop(text);
		}

		protected void c77de347f5cc9efb7b4cb59c10d1fcbd9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = _rootMC.getChildByName<MovieClip>(_strListItemName);
			if (childByName == null)
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
				_Item.c130648b59a0c8debea60aa153f844879(childByName);
				if (_data == null)
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
					_Item.ce008cdd349394595bf6ed3502a887365(_data);
					return;
				}
			}
		}
	}

	public class NPCFunctionListItem : c196099a1254db61d3be10d70e14e7422
	{
		protected const string KEY_PREFIX = "NPC_";

		public void ce008cdd349394595bf6ed3502a887365(FunctionListItemData c569c9c5e9312bd22e7caf8a0c3ce3fc9)
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType == NPC_UIFlowController.NPC_UIFlowState.Quest)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						UnityTextField childByName = movieClip.getChildByName<UnityTextField>("ItemText");
						if (childByName != null)
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
							Color c34fce3bccfffc6feb3579939c6d9a = Color.white;
							QuestProgress questProgress = c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._questProgress;
							if (questProgress != null)
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
									if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._quest != null)
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
										if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._quest.mCategory == QuestCategory.Daily)
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
											c34fce3bccfffc6feb3579939c6d9a = new Color(0f, 0.514f, 1f);
										}
										else if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._quest.mCategory == QuestCategory.Special)
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
											c34fce3bccfffc6feb3579939c6d9a = new Color(0.227f, 0.694f, 1f);
										}
										else
										{
											c34fce3bccfffc6feb3579939c6d9a = Color.yellow;
										}
									}
								}
								else if (questProgress.mStatus == QuestState.InProgress)
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
									c34fce3bccfffc6feb3579939c6d9a = Color.white;
								}
								else if (questProgress.mStatus == QuestState.Completed)
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
									c34fce3bccfffc6feb3579939c6d9a = Color.green;
								}
							}
							childByName.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._quest.mTitle));
							childByName.c34fce3bccfffc6feb3579939c6d9a057 = c34fce3bccfffc6feb3579939c6d9a;
						}
						MovieClip childByName2 = movieClip.getChildByName<MovieClip>("mcQuestTypeIcon");
						if (childByName2 != null)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
								{
									childByName2.gotoAndStop(c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._quest.mCategory.ToString());
									string name = "mcIconColor_" + c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._quest.mCategory;
									MovieClip childByName3 = childByName2.getChildByName<MovieClip>(name);
									if (childByName3 != null)
									{
										while (true)
										{
											switch (5)
											{
											case 0:
												break;
											default:
												childByName3.gotoAndStop(c569c9c5e9312bd22e7caf8a0c3ce3fc9.questData._questProgress.mStatus.ToString());
												return;
											}
										}
									}
									return;
								}
								}
							}
						}
						return;
					}
					}
				}
			}
			if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.Melting)
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
				if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.WeaponShop)
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
					if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.ClassModeShop)
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
						if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.CoinShieldShop)
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
							if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.Crafting)
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
								if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.CreateGuild)
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
									if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.DismissGuild)
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
										if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.Mail)
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
											if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.Warehouse)
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
												if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.WeaponUpgrade)
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
													if (c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType != NPC_UIFlowController.NPC_UIFlowState.QuitGuild)
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
														break;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			UnityTextField childByName4 = movieClip.getChildByName<MovieClip>("mcTitleContainer").getChildByName<UnityTextField>("textTitle");
			if (childByName4 == null)
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
				childByName4.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("NPC_" + c569c9c5e9312bd22e7caf8a0c3ce3fc9.functionType));
				return;
			}
		}
	}

	public delegate void deleOnClickButton(FunctionListItemData itemData);

	protected NPCFunctionList _root;

	protected c196099a1254db61d3be10d70e14e7422 _animaContainer;

	protected MovieClip _animaContainerMC;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Quest.swf", "NPCFunctionList", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
		_animaContainer = new c196099a1254db61d3be10d70e14e7422();
		_animaContainer.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_animaContainerMC = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
		_animaContainerMC.visible = false;
		_animaContainerMC.addFrameScript("fadein", c2471d58f4b2eb70e68abd7931c298d02);
		_animaContainerMC.addFrameScript("normal", c2471d58f4b2eb70e68abd7931c298d02);
		_animaContainerMC.addFrameScript("fadeout", c2471d58f4b2eb70e68abd7931c298d02);
		_animaContainerMC.addFrameScript("KeyFrame_1", c2471d58f4b2eb70e68abd7931c298d02);
		_animaContainerMC.addFrameScript("AniEnd", c729f0f3da43fe351d2a333618a48a6db);
		_root = new NPCFunctionList();
		_root.ce6a1efd8cfc56612b84fe8a69afa5a98 = cbbb55bdde473e2f1c0bc8f9214dd7dff;
		MovieClip childByName = _animaContainerMC.getChildByName<MovieClip>("mcFunctionList");
		if (childByName != null)
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
			_root.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		}
		_bActive = true;
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c7805303703b83f4ce9498430b0a1527b();
	}

	protected void c729f0f3da43fe351d2a333618a48a6db(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_animaContainerMC.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_animaContainer);
	}

	protected void c2471d58f4b2eb70e68abd7931c298d02(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c97d099cec851d2f0e43a5c7679b91d70();
	}

	protected void c97d099cec851d2f0e43a5c7679b91d70()
	{
		MovieClip childByName = _animaContainerMC.getChildByName<MovieClip>("mcFunctionList");
		if (childByName != null)
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
			_root.c130648b59a0c8debea60aa153f844879(childByName);
		}
		if (_functionDataList == null)
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
			_root.c30354725d9512975d57fd5b6d6e3d930(_functionDataList);
			if (_NPCInfo == null)
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
				_root.cf15a2a34d3ddcc09914934a114ef53e0(_NPCInfo.m_nameId, _NPCInfo.m_greetingsId);
				return;
			}
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		if (_animaContainer != null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_animaContainer);
		}
		_animaContainer = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Quest.swf");
		_root = null;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_bVisible)
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
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_animaContainer);
					_animaContainerMC.visible = true;
					_animaContainerMC.gotoAndPlay("fadein");
					c97d099cec851d2f0e43a5c7679b91d70();
					ceb879c61288940491aaed074feee1d20();
					return;
				}
			}
		}
		_animaContainerMC.gotoAndPlay("fadeout");
	}

	public override void cf15a2a34d3ddcc09914934a114ef53e0(XsdSettings.TownNpc cd127046b3a39f56884ba24c3480a96d3)
	{
		base.cf15a2a34d3ddcc09914934a114ef53e0(cd127046b3a39f56884ba24c3480a96d3);
		if (_root == null)
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
			_root.cf15a2a34d3ddcc09914934a114ef53e0(_NPCInfo.m_nameId, _NPCInfo.m_greetingsId);
			return;
		}
	}

	protected override void ceb879c61288940491aaed074feee1d20()
	{
		base.ceb879c61288940491aaed074feee1d20();
		if (!_bActive)
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
					return;
				}
			}
		}
		if (_root == null)
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
			_root.c30354725d9512975d57fd5b6d6e3d930(_functionDataList);
			return;
		}
	}
}
