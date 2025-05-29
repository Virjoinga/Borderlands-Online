using System.Collections.Generic;
using A;
using XsdSettings;

public class QuestTrackView : BaseView
{
	public enum eTrackingCategory
	{
		eNone = 0,
		eObjective = 1,
		eQuest = 2
	}

	public enum eSlotStatus
	{
		eNormal = 0,
		eNew = 1,
		eRemoving = 2,
		eObsoleted = 3
	}

	public class TrackingDataContainer
	{
		public string StrID = string.Empty;

		public eTrackingCategory TaskCategory;

		public eSlotStatus DataStatus;

		public QuestProgress CurQuestProgress;

		public QuestProgress NewQuestProgress;

		public Quest QuestData;

		public string strTitleText = string.Empty;

		public string strDesText = string.Empty;

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			TaskCategory = eTrackingCategory.eNone;
			DataStatus = eSlotStatus.eNormal;
			StrID = string.Empty;
			CurQuestProgress = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
			NewQuestProgress = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
			QuestData = c6a1e9d9cfb0b8c14256796aa2b02d787.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	protected Dictionary<string, TrackingDataContainer> _onTrackingDataDic = new Dictionary<string, TrackingDataContainer>();

	protected List<TrackingDataContainer> _onTrackingDataList = new List<TrackingDataContainer>();

	protected HashSet<int> _onHandleQuests = new HashSet<int>();

	protected int _refIDCounter;

	protected bool _bQuestDataInited;

	protected readonly int REFERENCEID_UPPERBOUND = 1000;

	protected readonly string PREFIX_OBJECTIVE = "Objective_";

	protected readonly string PREFIX_QUEST = "Quest_";

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
		_refIDCounter = 0;
		_onHandleQuests = new HashSet<int>();
		_onTrackingDataDic = new Dictionary<string, TrackingDataContainer>();
		_onTrackingDataList = new List<TrackingDataContainer>();
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd35ec9bc0560c63369b10ad39d5c179b(c33ac4c0f51cd32dd024d0a97c2350cdf);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_onHandleQuests.Clear();
		_onTrackingDataDic.Clear();
		_onTrackingDataList.Clear();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
		_bQuestDataInited = false;
	}

	protected void c33ac4c0f51cd32dd024d0a97c2350cdf(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		c6359b9093af57e0af788b2e1738a3e2d(c83eacefb66a7a7e1c47477d728c2025f);
	}

	protected virtual void c6359b9093af57e0af788b2e1738a3e2d(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		if (c83eacefb66a7a7e1c47477d728c2025f == null)
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
			if (!_bActive)
			{
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
			List<QuestProgress> list = c32dfbd70a1eea390a152e8f3bd4574d9(c83eacefb66a7a7e1c47477d728c2025f);
			if (!_bQuestDataInited)
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
				using (List<QuestProgress>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						QuestProgress current = enumerator.Current;
						_onHandleQuests.Add(current.mQuestId);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_0079;
						}
						continue;
						end_IL_0079:
						break;
					}
				}
				_bQuestDataInited = true;
			}
			using (List<QuestProgress>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					QuestProgress current2 = enumerator2.Current;
					string text = PREFIX_QUEST + current2.mQuestId;
					TrackingDataContainer value = null;
					if (_onTrackingDataDic.TryGetValue(text, out value))
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
						value.NewQuestProgress = current2;
						continue;
					}
					value = new TrackingDataContainer();
					value.StrID = text;
					value.TaskCategory = eTrackingCategory.eQuest;
					value.NewQuestProgress = current2;
					value.QuestData = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(current2.mQuestId);
					if (!_onHandleQuests.Contains(current2.mQuestId))
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
						_onHandleQuests.Add(current2.mQuestId);
						value.CurQuestProgress = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
					}
					else
					{
						value.CurQuestProgress = c3fc6acb046f3e57268177b0ec163678b(current2);
					}
					_onTrackingDataDic.Add(text, value);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_01a1;
					}
					continue;
					end_IL_01a1:
					break;
				}
			}
			cee3f7e1f2fe80146187019ef16248436();
			return;
		}
	}

	protected List<QuestProgress> c32dfbd70a1eea390a152e8f3bd4574d9(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		List<QuestProgress> list = new List<QuestProgress>();
		List<QuestProgress> value = cda9cc41fcf72c67af65abe224e1e7b45.c7088de59e49f7108f520cf7e0bae167e;
		Dictionary<QuestCategory, List<QuestProgress>> dictionary = new Dictionary<QuestCategory, List<QuestProgress>>();
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = c83eacefb66a7a7e1c47477d728c2025f.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				if (current.mStatus != QuestState.InProgress)
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
					if (current.mStatus != QuestState.Completed)
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
						if (current.mStatus != QuestState.Failed)
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
					}
				}
				Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(current.mQuestId);
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
				if (!dictionary.TryGetValue(quest.mCategory, out value))
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
					value = new List<QuestProgress>();
					dictionary.Add(quest.mCategory, value);
				}
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
					value.Add(current);
				}
				else
				{
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
					if (quest.mIsBoundInstance)
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
						if (!quest.mBoundInstanceList.c1a84901a0a9ec83a0000feb026941d27(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId))
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
					value.Add(current);
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_0158;
				}
				continue;
				end_IL_0158:
				break;
			}
		}
		using (Dictionary<QuestCategory, List<QuestProgress>>.ValueCollection.Enumerator enumerator2 = dictionary.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				List<QuestProgress> current2 = enumerator2.Current;
				current2.Sort(c2955a45d255d313e3429b9edc285de26);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_01ad;
				}
				continue;
				end_IL_01ad:
				break;
			}
		}
		QuestCategory[] array = c65718790a6f2380e7078aef1732c84a0.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = QuestCategory.Objective;
		array[2] = QuestCategory.Sidequest;
		array[3] = QuestCategory.Daily;
		array[4] = QuestCategory.Guidance;
		QuestCategory[] array2 = array;
		QuestCategory[] array3 = array2;
		foreach (QuestCategory key in array3)
		{
			if (!dictionary.TryGetValue(key, out value))
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
			list.AddRange(value);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return list;
		}
	}

	protected QuestProgress c3fc6acb046f3e57268177b0ec163678b(QuestProgress c223beccc0070e76121a77e228e9383a3)
	{
		QuestProgress questProgress = c7242d49d8b0586a36d8e21589657a414.c7088de59e49f7108f520cf7e0bae167e;
		if (c223beccc0070e76121a77e228e9383a3 != null)
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
			questProgress = new QuestProgress();
			questProgress.mCurrentTask = c223beccc0070e76121a77e228e9383a3.mCurrentTask;
			questProgress.mQuestId = c223beccc0070e76121a77e228e9383a3.mQuestId;
			questProgress.mStatus = c223beccc0070e76121a77e228e9383a3.mStatus;
			questProgress.mTaskProgress = c223beccc0070e76121a77e228e9383a3.mTaskProgress;
		}
		return questProgress;
	}

	protected int c2955a45d255d313e3429b9edc285de26(QuestProgress c052f035c94e7972ca4987129ac0e035a, QuestProgress cf335e740e52d098174ee35f171b08823)
	{
		return c052f035c94e7972ca4987129ac0e035a.mQuestId - cf335e740e52d098174ee35f171b08823.mQuestId;
	}

	public string c33096811c690978da9d02f180ff1e6d4(string c00e92bc9490ae65692b4be6c3238a6f2, string c4a44279e91dcc807ac582b1438c113eb)
	{
		string text = PREFIX_OBJECTIVE + _refIDCounter;
		_refIDCounter++;
		while (_onTrackingDataDic.ContainsKey(text))
		{
			_refIDCounter++;
			_refIDCounter %= REFERENCEID_UPPERBOUND;
			text = PREFIX_OBJECTIVE + _refIDCounter;
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
			TrackingDataContainer trackingDataContainer = new TrackingDataContainer();
			trackingDataContainer.TaskCategory = eTrackingCategory.eObjective;
			trackingDataContainer.StrID = text;
			trackingDataContainer.strTitleText = c00e92bc9490ae65692b4be6c3238a6f2;
			trackingDataContainer.strDesText = c4a44279e91dcc807ac582b1438c113eb;
			trackingDataContainer.DataStatus = eSlotStatus.eNew;
			_onTrackingDataDic.Add(text, trackingDataContainer);
			cee3f7e1f2fe80146187019ef16248436();
			return text;
		}
	}

	public void c34032e04fc02a186a3d3770f9d5425bd(string c63de2eeba7a7020bdb8f0e9d43918973)
	{
		TrackingDataContainer value = null;
		if (_onTrackingDataDic.TryGetValue(c63de2eeba7a7020bdb8f0e9d43918973, out value))
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
			value.DataStatus = eSlotStatus.eRemoving;
		}
		cee3f7e1f2fe80146187019ef16248436();
	}

	protected virtual void cee3f7e1f2fe80146187019ef16248436()
	{
		List<string> list = new List<string>();
		using (Dictionary<string, TrackingDataContainer>.Enumerator enumerator = _onTrackingDataDic.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, TrackingDataContainer> current = enumerator.Current;
				if (current.Value.DataStatus != eSlotStatus.eObsoleted)
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
				list.Add(current.Key);
			}
			while (true)
			{
				switch (6)
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
		using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				string current2 = enumerator2.Current;
				_onTrackingDataDic.Remove(current2);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00a6;
				}
				continue;
				end_IL_00a6:
				break;
			}
		}
		_onTrackingDataList = new List<TrackingDataContainer>(_onTrackingDataDic.Values);
		_onTrackingDataList.Sort(c14a692325919f0c46d457af69d5d7bc8);
	}

	protected int c14a692325919f0c46d457af69d5d7bc8(TrackingDataContainer cb23757880698a65db256be0a48f561b3, TrackingDataContainer cc1fa3171fa0e7211805389773c23a296)
	{
		int result = 0;
		if (cb23757880698a65db256be0a48f561b3.TaskCategory != cc1fa3171fa0e7211805389773c23a296.TaskCategory)
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
			result = cb23757880698a65db256be0a48f561b3.TaskCategory - cc1fa3171fa0e7211805389773c23a296.TaskCategory;
		}
		else
		{
			eTrackingCategory taskCategory = cb23757880698a65db256be0a48f561b3.TaskCategory;
			if (taskCategory != eTrackingCategory.eQuest)
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
			else if (cb23757880698a65db256be0a48f561b3.QuestData != null)
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
				if (cc1fa3171fa0e7211805389773c23a296.QuestData != null)
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
					result = cb23757880698a65db256be0a48f561b3.QuestData.mId - cc1fa3171fa0e7211805389773c23a296.QuestData.mId;
				}
			}
		}
		return result;
	}
}
