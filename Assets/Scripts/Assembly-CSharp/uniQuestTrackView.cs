using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniQuestTrackView : QuestTrackView
{
	public enum eTrackerAnimaType
	{
		eNone = 0,
		eNewQuest = 1,
		eTaskProgressUpdate = 2,
		eTaskComplete = 3,
		eQuestComplete = 4,
		eTaskFail = 5,
		eQuestFail = 6,
		eRemove = 7
	}

	protected class TrackerSlot
	{
		public string StrDataID = string.Empty;

		public string StrTitleText = string.Empty;

		public string StrDescriptionText = string.Empty;

		public bool bActive;

		public eTrackerAnimaType Anima;

		public Color TextColor = Color.white;

		public QuestState SlotState = QuestState.Available;

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			TextColor = Color.white;
			StrDataID = string.Empty;
			StrTitleText = string.Empty;
			StrDescriptionText = string.Empty;
			Anima = eTrackerAnimaType.eNone;
			bActive = false;
		}

		public void c3bcdfb01e004dde353674be0b3bd8dfa(QuestProgress c223beccc0070e76121a77e228e9383a3, Quest c6b405c9a3499384620ad758f86fdc2ae)
		{
			if (c223beccc0070e76121a77e228e9383a3 == null)
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
				if (c6b405c9a3499384620ad758f86fdc2ae == null)
				{
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
				SlotState = c223beccc0070e76121a77e228e9383a3.mStatus;
				TextColor = Color.white;
				if (c223beccc0070e76121a77e228e9383a3.mStatus == QuestState.InProgress)
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
					TextColor = Color.white;
				}
				else if (c223beccc0070e76121a77e228e9383a3.mStatus == QuestState.Completed)
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
					TextColor = Color.green;
				}
				StrTitleText = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c6b405c9a3499384620ad758f86fdc2ae.mTitle));
				int num = c223beccc0070e76121a77e228e9383a3.mCurrentTask;
				if (num >= c6b405c9a3499384620ad758f86fdc2ae.mTasks.Length)
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
					num = c6b405c9a3499384620ad758f86fdc2ae.mTasks.Length - 1;
				}
				QuestTask questTask = c6b405c9a3499384620ad758f86fdc2ae.mTasks[num];
				string text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(questTask.mDescription)) + " ";
				if (questTask.mType != QuestTaskType.Kills)
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
					if (questTask.mType != QuestTaskType.Damage)
					{
						if (questTask.mType == QuestTaskType.BringTo)
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
							if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
								int num2 = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(questTask.mMaterialType);
								if (num2 > questTask.mMaterialCount)
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
									num2 = questTask.mMaterialCount;
								}
								object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
								array[0] = text;
								array[1] = num2;
								array[2] = "/";
								array[3] = questTask.mMaterialCount;
								text = string.Concat(array);
							}
						}
						goto IL_021b;
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
				int num3 = c223beccc0070e76121a77e228e9383a3.mTaskProgress;
				if (num3 > questTask.mTarget)
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
					num3 = questTask.mTarget;
				}
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = text;
				array2[1] = num3;
				array2[2] = "/";
				array2[3] = questTask.mTarget;
				text = string.Concat(array2);
				goto IL_021b;
				IL_021b:
				StrDescriptionText = text;
				return;
			}
		}
	}

	protected class TrackSlotPanel : c196099a1254db61d3be10d70e14e7422
	{
		public delegate void OnAnimationEnd(TrackerSlot slotData);

		protected MovieClip _rootMC;

		protected MovieClip _statusMC;

		protected UnityTextField _textQuestName;

		protected TrackerSlot _slotData;

		protected bool _bOnAnima;

		protected OnAnimationEnd _onAnimationEnd;

		public OnAnimationEnd cc42356e4bdacf3ef36e1ca153154f7a9
		{
			set
			{
				_onAnimationEnd = value;
			}
		}

		public bool cbc8cbbfc971af96942d20584de336efc
		{
			get
			{
				return _bOnAnima;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_textQuestName = _rootMC.getChildByName<TextField>("textQuestName") as UnityTextField;
			_statusMC = _rootMC.getChildByName<MovieClip>("mcQuestStatus");
			if (_statusMC == null)
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
				_statusMC.addFrameScript("ComKey1", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("ComKey2", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("Complete", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TurnKey1", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TurnKey2", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TurnKey3", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TurnKey4", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TurnKey5", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TaskComKey1", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TaskComKey2", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TaskComKey3", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("TaskComKey4", c89f2899a2a57053b2b31f8cbf68de2c5);
				_statusMC.addFrameScript("RevealAniEnd", c729f0f3da43fe351d2a333618a48a6db);
				_statusMC.addFrameScript("CompleteAniEnd", c729f0f3da43fe351d2a333618a48a6db);
				_statusMC.addFrameScript("RemoveAniEnd", c729f0f3da43fe351d2a333618a48a6db);
				_statusMC.addFrameScript("IncrementAniEnd", c729f0f3da43fe351d2a333618a48a6db);
				_statusMC.addFrameScript("TurnAniEnd", c729f0f3da43fe351d2a333618a48a6db);
				_statusMC.addFrameScript("TaskComAniEnd", c729f0f3da43fe351d2a333618a48a6db);
				return;
			}
		}

		protected void c89f2899a2a57053b2b31f8cbf68de2c5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cee3f7e1f2fe80146187019ef16248436();
		}

		protected void c729f0f3da43fe351d2a333618a48a6db(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_statusMC.gotoAndStop("Off");
			_bOnAnima = false;
			if (_onAnimationEnd == null)
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
				_onAnimationEnd(_slotData);
				return;
			}
		}

		public void c263a18e823d534fe933bf797fd17c221(TrackerSlot cb43153030054778ce517cdde955a6283)
		{
			if (_bOnAnima)
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
						return;
					}
				}
			}
			_rootMC.visible = cb43153030054778ce517cdde955a6283.bActive;
			_slotData = cb43153030054778ce517cdde955a6283;
			if (_slotData.Anima != 0)
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
				c9c8c2e259fa10b28eef998125e51490f(_slotData.Anima);
				_bOnAnima = true;
			}
			cee3f7e1f2fe80146187019ef16248436();
		}

		public void c9c8c2e259fa10b28eef998125e51490f(eTrackerAnimaType cf78729f221e1c24a90714a3334dc5350)
		{
			switch (cf78729f221e1c24a90714a3334dc5350)
			{
			case eTrackerAnimaType.eQuestComplete:
				_statusMC.gotoAndPlay("Complete");
				break;
			case eTrackerAnimaType.eQuestFail:
				_statusMC.gotoAndPlay("Failure");
				break;
			case eTrackerAnimaType.eTaskComplete:
				_statusMC.gotoAndPlay("TaskComplete");
				break;
			case eTrackerAnimaType.eNewQuest:
				_statusMC.gotoAndPlay("Reveal");
				break;
			case eTrackerAnimaType.eTaskProgressUpdate:
				_statusMC.gotoAndPlay("Increment");
				break;
			case eTrackerAnimaType.eRemove:
				_statusMC.gotoAndPlay("Remove");
				break;
			case eTrackerAnimaType.eTaskFail:
				break;
			}
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			_rootMC.visible = c74232243aff1dcbf2e8fc243633bb51a;
		}

		public void cee3f7e1f2fe80146187019ef16248436()
		{
			if (_slotData == null)
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
			if (_textQuestName != null)
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
				_textQuestName.text = _slotData.StrTitleText;
				_textQuestName.c34fce3bccfffc6feb3579939c6d9a057 = _slotData.TextColor;
			}
			MovieClip childByName = _statusMC.getChildByName<MovieClip>("mcInnerQuestStatus");
			if (childByName == null)
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
				UnityTextField childByName2 = childByName.getChildByName<UnityTextField>("textQuestTask");
				if (childByName2 != null)
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
					childByName2.text = _slotData.StrDescriptionText;
					childByName2.c34fce3bccfffc6feb3579939c6d9a057 = _slotData.TextColor;
				}
				childByName.gotoAndStop(_slotData.SlotState.ToString());
				return;
			}
		}
	}

	protected c196099a1254db61d3be10d70e14e7422 _root;

	protected MovieClip _rootMC;

	protected string _strItemPrefix = "mcQuest_";

	protected static int MAX_TRACKING_NUM = 6;

	protected TrackSlotPanel[] _trackSlotPanelAry = new TrackSlotPanel[MAX_TRACKING_NUM];

	protected TrackerSlot[] _trackSlotAry = new TrackerSlot[MAX_TRACKING_NUM];

	protected int _aniRefCnt;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		for (int i = 0; i < MAX_TRACKING_NUM; i++)
		{
			_trackSlotAry[i] = new TrackerSlot();
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
			_bActive = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("HUD.swf", "Panel_QuestTrack", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
			return;
		}
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_root = new c196099a1254db61d3be10d70e14e7422();
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = true;
		_rootMC = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
		_root.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_root);
		for (int i = 1; i <= MAX_TRACKING_NUM; i++)
		{
			_trackSlotPanelAry[i - 1] = new TrackSlotPanel();
			string name = _strItemPrefix + i;
			MovieClip childByName = _rootMC.getChildByName<MovieClip>(name);
			if (childByName == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_trackSlotPanelAry[i - 1].c130648b59a0c8debea60aa153f844879(childByName);
			_trackSlotPanelAry[i - 1].cc42356e4bdacf3ef36e1ca153154f7a9 = c8d1da64668b522f517bd6cfbaf6e725a;
			childByName.visible = false;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			_bActive = true;
			QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c7805303703b83f4ce9498430b0a1527b();
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		if (_root != null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
		}
		_bActive = false;
		_root = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("HUD.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_rootMC == null)
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
			_rootMC.visible = c8be1fcd630e5fe96821376d111325750;
			return;
		}
	}

	protected eTrackerAnimaType cd5e6abd2d37f5322af0fe8070d83e71c(QuestProgress c6740850ac292085f9547090242738616, QuestProgress c202d5c92bc45eb0a05a59cf9de214962)
	{
		eTrackerAnimaType result = eTrackerAnimaType.eNone;
		if (c6740850ac292085f9547090242738616 == null)
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
			result = eTrackerAnimaType.eNewQuest;
		}
		else if (c6740850ac292085f9547090242738616.mQuestId != c202d5c92bc45eb0a05a59cf9de214962.mQuestId)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Wrong Quest ID to compare");
		}
		else
		{
			if (c6740850ac292085f9547090242738616.mStatus == QuestState.InProgress)
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
				if (c202d5c92bc45eb0a05a59cf9de214962.mStatus == QuestState.Completed)
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
					result = eTrackerAnimaType.eQuestComplete;
					goto IL_0158;
				}
			}
			if (c6740850ac292085f9547090242738616.mStatus == QuestState.InProgress)
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
				if (c202d5c92bc45eb0a05a59cf9de214962.mStatus == QuestState.Failed)
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
					result = eTrackerAnimaType.eQuestFail;
					goto IL_0158;
				}
			}
			if (c6740850ac292085f9547090242738616.mStatus == QuestState.InProgress)
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
				if (c202d5c92bc45eb0a05a59cf9de214962.mStatus == QuestState.RewardClaimed)
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
					result = eTrackerAnimaType.eRemove;
					goto IL_0158;
				}
			}
			if (c6740850ac292085f9547090242738616.mStatus == QuestState.Completed)
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
				if (c202d5c92bc45eb0a05a59cf9de214962.mStatus == QuestState.RewardClaimed)
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
					result = eTrackerAnimaType.eRemove;
					goto IL_0158;
				}
			}
			if (c6740850ac292085f9547090242738616.mStatus == QuestState.RewardClaimed)
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
				if (c202d5c92bc45eb0a05a59cf9de214962.mStatus == QuestState.RewardClaimed)
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
					result = eTrackerAnimaType.eRemove;
					goto IL_0158;
				}
			}
			if (c6740850ac292085f9547090242738616.mCurrentTask != c202d5c92bc45eb0a05a59cf9de214962.mCurrentTask)
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
				result = eTrackerAnimaType.eTaskComplete;
			}
			else if (c6740850ac292085f9547090242738616.mTaskProgress != c202d5c92bc45eb0a05a59cf9de214962.mTaskProgress)
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
				result = eTrackerAnimaType.eTaskProgressUpdate;
			}
		}
		goto IL_0158;
		IL_0158:
		return result;
	}

	protected void c8d1da64668b522f517bd6cfbaf6e725a(TrackerSlot cb43153030054778ce517cdde955a6283)
	{
		TrackingDataContainer value = null;
		if (_onTrackingDataDic.TryGetValue(cb43153030054778ce517cdde955a6283.StrDataID, out value))
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
			if (cb43153030054778ce517cdde955a6283.Anima == eTrackerAnimaType.eRemove)
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
				value.DataStatus = eSlotStatus.eObsoleted;
			}
			else
			{
				if (value.TaskCategory == eTrackingCategory.eQuest)
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
					value.CurQuestProgress = c3fc6acb046f3e57268177b0ec163678b(value.NewQuestProgress);
				}
				if (value.DataStatus == eSlotStatus.eNew)
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
					value.DataStatus = eSlotStatus.eNormal;
				}
			}
		}
		cee3f7e1f2fe80146187019ef16248436();
	}

	protected override void cee3f7e1f2fe80146187019ef16248436()
	{
		base.cee3f7e1f2fe80146187019ef16248436();
		if (!_bActive)
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
		TrackSlotPanel[] trackSlotPanelAry = _trackSlotPanelAry;
		foreach (TrackSlotPanel trackSlotPanel in trackSlotPanelAry)
		{
			if (!trackSlotPanel.cbc8cbbfc971af96942d20584de336efc)
			{
				continue;
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
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			int j;
			for (j = 0; j < MAX_TRACKING_NUM; j++)
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
				TrackingDataContainer trackingDataContainer;
				TrackerSlot trackerSlot;
				QuestProgress curQuestProgress;
				if (j < _onTrackingDataList.Count)
				{
					trackingDataContainer = _onTrackingDataList[j];
					trackerSlot = _trackSlotAry[j];
					if (trackerSlot == null)
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
					if (trackingDataContainer == null)
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
						continue;
					}
					trackerSlot.StrDataID = trackingDataContainer.StrID;
					trackerSlot.bActive = true;
					if (trackingDataContainer.TaskCategory == eTrackingCategory.eQuest)
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
						trackerSlot.Anima = cd5e6abd2d37f5322af0fe8070d83e71c(trackingDataContainer.CurQuestProgress, trackingDataContainer.NewQuestProgress);
						curQuestProgress = trackingDataContainer.CurQuestProgress;
						if (trackerSlot.Anima == eTrackerAnimaType.eNewQuest)
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
							curQuestProgress = trackingDataContainer.NewQuestProgress;
						}
						else
						{
							curQuestProgress = trackingDataContainer.CurQuestProgress;
							if (trackerSlot.Anima != eTrackerAnimaType.eQuestComplete)
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
								if (trackerSlot.Anima != eTrackerAnimaType.eTaskComplete)
								{
									goto IL_0147;
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
							curQuestProgress.mStatus = QuestState.Completed;
						}
						goto IL_0147;
					}
					if (trackingDataContainer.TaskCategory != eTrackingCategory.eObjective)
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
					trackerSlot.StrTitleText = trackingDataContainer.strTitleText;
					trackerSlot.TextColor = Color.white;
					trackerSlot.StrDescriptionText = trackingDataContainer.strDesText;
					eSlotStatus dataStatus = trackingDataContainer.DataStatus;
					if (dataStatus != eSlotStatus.eNew)
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
						if (dataStatus != eSlotStatus.eRemoving)
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
							trackerSlot.Anima = eTrackerAnimaType.eNone;
							trackerSlot.SlotState = QuestState.InProgress;
						}
						else
						{
							trackerSlot.Anima = eTrackerAnimaType.eRemove;
							trackerSlot.SlotState = QuestState.Completed;
							trackerSlot.TextColor = Color.green;
						}
					}
					else
					{
						trackerSlot.Anima = eTrackerAnimaType.eNewQuest;
						trackerSlot.SlotState = QuestState.InProgress;
					}
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
				break;
				IL_0147:
				Quest questData = trackingDataContainer.QuestData;
				trackerSlot.c3bcdfb01e004dde353674be0b3bd8dfa(curQuestProgress, questData);
			}
			for (; j < MAX_TRACKING_NUM; j++)
			{
				_trackSlotAry[j].cac7688b05e921e2be3f92479ba44b4a8();
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				for (j = 0; j < MAX_TRACKING_NUM; j++)
				{
					_trackSlotPanelAry[j].c263a18e823d534fe933bf797fd17c221(_trackSlotAry[j]);
				}
				while (true)
				{
					switch (7)
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
