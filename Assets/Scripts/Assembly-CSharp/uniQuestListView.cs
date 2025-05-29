using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniQuestListView : QuestListView
{
	public class QuestListPanel : c196099a1254db61d3be10d70e14e7422
	{
		public class QuestKeyCompare : IComparer<int>
		{
			public int Compare(int iKeyA, int iKeyB)
			{
				return iKeyA - iKeyB;
			}
		}

		public delegate void EnterQuestItem(int i);

		public delegate void onCloseList();

		protected QuestSlot[] _questItemArray = new QuestSlot[15];

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnClose;

		protected cf7ac05203029a27299d6893b2dbaee2e _scrollBar;

		protected int _iQuestItemMCNum = 12;

		protected int _iOnShowQuestNum;

		protected List<QuestSlotInfo> _questSlotInfoList = new List<QuestSlotInfo>();

		public static int _iFinishedQuestsIndex = -1;

		protected Dictionary<QuestState, Color> _dicQuestTextColor = new Dictionary<QuestState, Color>();

		protected Color _textColorInsTitle = Color.white;

		protected EnterQuestItem _deleOnEnterQuestItem;

		protected onCloseList _deleOnClose;

		public EnterQuestItem ca6361e8b0d97d0c0c3d300154e999ec7
		{
			set
			{
				_deleOnEnterQuestItem = value;
			}
		}

		public onCloseList cf1bf054536e1151c5e84b246633009dd
		{
			set
			{
				_deleOnClose = value;
			}
		}

		protected void cdac62da57178ef3ba733f252c4118b7d(int c872943035f78644fd01b267deff00547)
		{
			if (_deleOnEnterQuestItem == null)
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
				_deleOnEnterQuestItem(c872943035f78644fd01b267deff00547);
				return;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("mcItem_"))
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
				_questItemArray[num - 1] = new QuestSlot();
				_questItemArray[num - 1].ca6361e8b0d97d0c0c3d300154e999ec7 = cdac62da57178ef3ba733f252c4118b7d;
				_questItemArray[num - 1].c130648b59a0c8debea60aa153f844879(movieClip);
				_questItemArray[num - 1].c43cbb41bf755dfa61de619fc6e86ab31(false);
				result = true;
			}
			else if (movieClip.name == "mcBtnClose")
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
				_btnClose = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
				_btnClose.c130648b59a0c8debea60aa153f844879(movieClip);
				_btnClose.addEventListener(MouseEvent.CLICK, c83f5d510d483adac7af2c6c9fdf95b71);
				result = true;
			}
			else if (movieClip.name == "mcScrollingBar")
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
				_scrollBar = new cf7ac05203029a27299d6893b2dbaee2e();
				_scrollBar.c130648b59a0c8debea60aa153f844879(movieClip);
				_scrollBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
				_scrollBar.cfcb3294d851a0336d3f3a8f2a943f2fb = (_scrollBar.c9c58dff860effc1212c1afb5d14e147c = 0);
				result = true;
			}
			return result;
		}

		protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			int num = _scrollBar.cef9712200bbe2c3873eec3ca2e18a595 + 1;
			int num2;
			if (_questSlotInfoList.Count > _iQuestItemMCNum)
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
				num2 = _iQuestItemMCNum;
			}
			else
			{
				num2 = _questSlotInfoList.Count;
			}
			int num3 = num2;
			c957877f7fba3af8dd1f69f3e85a05beb(num, num + num3 - 1);
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_dicQuestTextColor.Add(QuestState.Available, Color.yellow);
			_dicQuestTextColor.Add(QuestState.Completed, Color.green);
			_dicQuestTextColor.Add(QuestState.InProgress, Color.white);
			_dicQuestTextColor.Add(QuestState.RewardClaimed, Color.grey);
		}

		public void c40b5bc409cf38b17f8cc13dd745279ee(List<int> c825be12ebe577dcbab2706611b826e65)
		{
			SortedDictionary<int, List<QuestUIData>> sortedDictionary = new SortedDictionary<int, List<QuestUIData>>(new QuestKeyCompare());
			using (List<int>.Enumerator enumerator = c825be12ebe577dcbab2706611b826e65.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					QuestUIData questUIData = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cbc6752b59485c3ca287072485ad0180b(current);
					if (questUIData == null)
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
					}
					else
					{
						if (questUIData._questProgress == null)
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
						int num = 0;
						QuestState mStatus = questUIData._questProgress.mStatus;
						if (mStatus == QuestState.RewardClaimed)
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
							num = _iFinishedQuestsIndex;
						}
						else
						{
							num = questUIData._quest.mBoundInstanceList[0];
						}
						if (!sortedDictionary.ContainsKey(num))
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
							sortedDictionary.Add(num, new List<QuestUIData>());
						}
						sortedDictionary[num].Add(questUIData);
					}
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00da;
					}
					continue;
					end_IL_00da:
					break;
				}
			}
			int iOnShowQuestNum;
			if (c825be12ebe577dcbab2706611b826e65.Count > _iQuestItemMCNum)
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
				iOnShowQuestNum = c825be12ebe577dcbab2706611b826e65.Count;
			}
			else
			{
				iOnShowQuestNum = _iOnShowQuestNum;
			}
			_iOnShowQuestNum = iOnShowQuestNum;
			_questSlotInfoList.Clear();
			using (SortedDictionary<int, List<QuestUIData>>.KeyCollection.Enumerator enumerator2 = sortedDictionary.Keys.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					int current2 = enumerator2.Current;
					if (current2 == _iFinishedQuestsIndex)
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
						continue;
					}
					QuestSlotInfo questSlotInfo = new QuestSlotInfo();
					questSlotInfo.bIsTitleItem = true;
					questSlotInfo.strTitleString = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(current2).m_name;
					_questSlotInfoList.Add(questSlotInfo);
					using (List<QuestUIData>.Enumerator enumerator3 = sortedDictionary[current2].GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							QuestUIData current3 = enumerator3.Current;
							QuestSlotInfo questSlotInfo2 = new QuestSlotInfo();
							questSlotInfo2.questData = current3;
							_questSlotInfoList.Add(questSlotInfo2);
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_01e8;
							}
							continue;
							end_IL_01e8:
							break;
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
						goto end_IL_020f;
					}
					continue;
					end_IL_020f:
					break;
				}
			}
			if (sortedDictionary.ContainsKey(_iFinishedQuestsIndex))
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
				QuestSlotInfo questSlotInfo3 = new QuestSlotInfo();
				questSlotInfo3.bIsTitleItem = true;
				questSlotInfo3.strTitleString = "Completed_Quest";
				_questSlotInfoList.Add(questSlotInfo3);
				using (List<QuestUIData>.Enumerator enumerator4 = sortedDictionary[_iFinishedQuestsIndex].GetEnumerator())
				{
					while (enumerator4.MoveNext())
					{
						QuestUIData current4 = enumerator4.Current;
						QuestSlotInfo questSlotInfo4 = new QuestSlotInfo();
						questSlotInfo4.questData = current4;
						_questSlotInfoList.Add(questSlotInfo4);
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_02b7;
						}
						continue;
						end_IL_02b7:
						break;
					}
				}
			}
			int num2 = 0;
			using (List<QuestSlotInfo>.Enumerator enumerator5 = _questSlotInfoList.GetEnumerator())
			{
				while (enumerator5.MoveNext())
				{
					QuestSlotInfo current5 = enumerator5.Current;
					if (!current5.bIsTitleItem)
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
						current5.textColor = _dicQuestTextColor[current5.questData._questProgress.mStatus];
						num2++;
						current5.bIsDarkSlot = num2 % 2 == 0;
					}
					else
					{
						current5.textColor = _textColorInsTitle;
						num2 = 0;
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_035a;
					}
					continue;
					end_IL_035a:
					break;
				}
			}
			using (List<QuestSlotInfo>.Enumerator enumerator6 = _questSlotInfoList.GetEnumerator())
			{
				while (true)
				{
					if (enumerator6.MoveNext())
					{
						QuestSlotInfo current6 = enumerator6.Current;
						if (current6.bIsTitleItem)
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
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestListView>().c70b2c6b0dfcbcde99ba4dbf6a6b911f7(current6.questData._quest.mId);
							break;
						}
						break;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_03dc;
						}
						continue;
						end_IL_03dc:
						break;
					}
					break;
				}
			}
			int num3;
			if (_questSlotInfoList.Count > _iQuestItemMCNum)
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
				num3 = _iQuestItemMCNum;
			}
			else
			{
				num3 = _questSlotInfoList.Count;
			}
			int c22bbd1ab99b6b61e166c3b64ba9dc = num3;
			c957877f7fba3af8dd1f69f3e85a05beb(1, c22bbd1ab99b6b61e166c3b64ba9dc);
			if (_scrollBar == null)
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
				int iQuestItemMCNum = _iQuestItemMCNum;
				_scrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(iQuestItemMCNum, 0, _questSlotInfoList.Count - iQuestItemMCNum, 1);
				_scrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
				return;
			}
		}

		public void c957877f7fba3af8dd1f69f3e85a05beb(int c815b908e3c8975c339fa92ab1aa041fd, int c22bbd1ab99b6b61e166c3b64ba9dc884)
		{
			if (c815b908e3c8975c339fa92ab1aa041fd >= 1)
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
				if (c22bbd1ab99b6b61e166c3b64ba9dc884 <= _questSlotInfoList.Count)
				{
					goto IL_003c;
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, " Quest List item out of index");
			goto IL_003c;
			IL_003c:
			int num = c22bbd1ab99b6b61e166c3b64ba9dc884 - c815b908e3c8975c339fa92ab1aa041fd + 1;
			for (int i = 0; i < num; i++)
			{
				QuestSlotInfo c536aee83fe233c78b617d48af497e1d = _questSlotInfoList[i + c815b908e3c8975c339fa92ab1aa041fd - 1];
				_questItemArray[i].c43cbb41bf755dfa61de619fc6e86ab31(true);
				_questItemArray[i].c939bc4ed7b3fcdf72d01feff164d15ed(c536aee83fe233c78b617d48af497e1d);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				for (int j = num; j < _iQuestItemMCNum; j++)
				{
					_questItemArray[j].c43cbb41bf755dfa61de619fc6e86ab31(false);
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

		protected void c83f5d510d483adac7af2c6c9fdf95b71(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_deleOnClose == null)
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
				_deleOnClose();
				return;
			}
		}
	}

	public class QuestSlotInfo
	{
		public QuestUIData questData;

		public bool bIsTitleItem;

		public string strTitleString;

		public bool bIsDarkSlot;

		public Color textColor = Color.white;
	}

	public class QuestSlot : c82f7c0afbcfc8c5382a8c6daa9365b7b
	{
		public delegate void onEnterQuestItem(int i);

		protected MovieClip _mcRoot;

		protected MovieClip _mcQuestNameMC;

		protected MovieClip _mcSlotBG;

		protected bool _bMouseOn;

		protected QuestSlotInfo _slotInfo;

		protected string _strTextString;

		protected onEnterQuestItem _deleOnEnterQuestItem;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map29;

		public onEnterQuestItem ca6361e8b0d97d0c0c3d300154e999ec7
		{
			set
			{
				_deleOnEnterQuestItem = value;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map29 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(2);
					dictionary.Add("mcQuestName", 0);
					dictionary.Add("mcSlotBG", 1);
					_003C_003Ef__switch_0024map29 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map29.TryGetValue(name, out value))
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
					if (value != 0)
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
						if (value != 1)
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
						}
						else
						{
							_mcSlotBG = movieClip;
							result = true;
						}
					}
					else
					{
						_mcQuestNameMC = movieClip;
						result = true;
					}
				}
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			_mcRoot = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_mcRoot.addEventListener(MouseEvent.MOUSE_ENTER, c666f6da9d72a65e9c4799a5d7ebe8260);
			_mcRoot.addEventListener(MouseEvent.MOUSE_LEAVE, c6453e18885cec01fbc7cae6f5f00f1fa);
		}

		protected void c2471d58f4b2eb70e68abd7931c298d02(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_slotInfo == null)
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
				c939bc4ed7b3fcdf72d01feff164d15ed(_slotInfo);
				return;
			}
		}

		protected void c666f6da9d72a65e9c4799a5d7ebe8260(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_slotInfo == null)
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
				c939bc4ed7b3fcdf72d01feff164d15ed(_slotInfo);
				if (_slotInfo.bIsTitleItem)
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
					if (_deleOnEnterQuestItem == null)
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
						_deleOnEnterQuestItem(_slotInfo.questData._quest.mId);
						return;
					}
				}
			}
		}

		protected void c6453e18885cec01fbc7cae6f5f00f1fa(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_mcRoot.gotoAndStop("up");
			if (_slotInfo == null)
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
				c939bc4ed7b3fcdf72d01feff164d15ed(_slotInfo);
				return;
			}
		}

		public void c939bc4ed7b3fcdf72d01feff164d15ed(QuestSlotInfo c536aee83fe233c78b617d48af497e1d5)
		{
			UnityTextField unityTextField = (UnityTextField)_mcQuestNameMC.getChildByName<TextField>("infotitle");
			MovieClip childByName = _mcRoot.getChildByName<MovieClip>("mcTypeIcon");
			unityTextField.c34fce3bccfffc6feb3579939c6d9a057 = c536aee83fe233c78b617d48af497e1d5.textColor;
			_slotInfo = c536aee83fe233c78b617d48af497e1d5;
			if (c536aee83fe233c78b617d48af497e1d5.bIsTitleItem)
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
						_strTextString = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c536aee83fe233c78b617d48af497e1d5.strTitleString));
						childByName.visible = false;
						unityTextField.text = _strTextString;
						_mcSlotBG.gotoAndStop("TitleBG");
						return;
					}
				}
			}
			Quest quest = c536aee83fe233c78b617d48af497e1d5.questData._quest;
			QuestProgress questProgress = c536aee83fe233c78b617d48af497e1d5.questData._questProgress;
			_strTextString = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(quest.mTitle));
			childByName.visible = true;
			if (c536aee83fe233c78b617d48af497e1d5.bIsDarkSlot)
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
				_mcSlotBG.gotoAndStop("DarkBG");
			}
			else
			{
				_mcSlotBG.gotoAndStop("lightBG");
			}
			if (unityTextField != null)
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
				unityTextField.text = _strTextString;
			}
			childByName.gotoAndStop(quest.mCategory.ToString());
			MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcIconColor");
			if (childByName2 == null)
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
				childByName2.gotoAndStop(questProgress.mStatus.ToString());
				return;
			}
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			_mcRoot.visible = c74232243aff1dcbf2e8fc243633bb51a;
		}
	}

	protected c196099a1254db61d3be10d70e14e7422 _root;

	protected MovieClip _rootMC;

	protected QuestListPanel _questList;

	protected uniQuestDetailView.QuestDetail _questDetail;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Quest.swf", "whole", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
		_root = new c196099a1254db61d3be10d70e14e7422();
		_root.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_rootMC = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.addFrameScript("pannelopen", c2471d58f4b2eb70e68abd7931c298d02);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.addFrameScript("firstmove", c2471d58f4b2eb70e68abd7931c298d02);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.addFrameScript("DetailAppear", c2471d58f4b2eb70e68abd7931c298d02);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.addFrameScript("KeyFrame_1", c2471d58f4b2eb70e68abd7931c298d02);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.addFrameScript("KeyFrame_2", c2471d58f4b2eb70e68abd7931c298d02);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.addFrameScript("infofadeout", c2471d58f4b2eb70e68abd7931c298d02);
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c7805303703b83f4ce9498430b0a1527b();
		_bActive = true;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		if (_root != null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
		}
		_root = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Quest.swf");
	}

	protected void c2471d58f4b2eb70e68abd7931c298d02(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcQuestList");
		if (childByName != null)
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
			_questList = new QuestListPanel();
			_questList.ca6361e8b0d97d0c0c3d300154e999ec7 = c70b2c6b0dfcbcde99ba4dbf6a6b911f7;
			_questList.cf1bf054536e1151c5e84b246633009dd = c83f5d510d483adac7af2c6c9fdf95b71;
			_questList.c130648b59a0c8debea60aa153f844879(childByName);
			_questList.c40b5bc409cf38b17f8cc13dd745279ee(_onShowQuestIDList);
		}
		MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("mcQuestDetail");
		if (childByName2 == null)
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
			_questDetail = new uniQuestDetailView.QuestDetail();
			_questDetail.c130648b59a0c8debea60aa153f844879(childByName2);
			_questDetail.c0c96bf89d6652c6c16b48f708fe5c87a = false;
			c70b2c6b0dfcbcde99ba4dbf6a6b911f7(_iOnShowQuestID);
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		_rootMC.visible = c8be1fcd630e5fe96821376d111325750;
		if (c8be1fcd630e5fe96821376d111325750)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().cb4341b3564e3d55dc9f38df4b813c5da(_root);
					_rootMC.gotoAndStop("pannelopen");
					if (_onShowQuestIDList.Count > 0)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								_rootMC.addEventListener(MouseEvent.MOUSE_ENTER, cae0585a7ae5232356d4dab1128e663cf);
								return;
							}
						}
					}
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c27542a6dc8f97862ef53db1d4f3a6db8(_root);
	}

	protected void cae0585a7ae5232356d4dab1128e663cf(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_rootMC.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
		_rootMC.gotoAndPlay("firstmove");
	}

	public void OnQuestBtnClicked()
	{
		c150264a18c2cb408479d3f072cac8cc1 = !_bVisible;
	}

	public override void cf00a3d5f06264dc7364f393405057c72(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		base.cf00a3d5f06264dc7364f393405057c72(c83eacefb66a7a7e1c47477d728c2025f);
		if (_root == null)
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
		if (_questList == null)
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
			_questList.c40b5bc409cf38b17f8cc13dd745279ee(_onShowQuestIDList);
			return;
		}
	}

	public override void c70b2c6b0dfcbcde99ba4dbf6a6b911f7(int c8d9247e6ec97defd6456db7da9372514)
	{
		base.c70b2c6b0dfcbcde99ba4dbf6a6b911f7(c8d9247e6ec97defd6456db7da9372514);
		if (_iOnShowQuestID == -1)
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
			QuestUIData questUIData = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cbc6752b59485c3ca287072485ad0180b(c8d9247e6ec97defd6456db7da9372514);
			if (questUIData == null)
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
				if (_questDetail == null)
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
					_questDetail.c12c1611d592facfca7f3d95d2ce78e8a(questUIData);
					return;
				}
			}
		}
	}
}
