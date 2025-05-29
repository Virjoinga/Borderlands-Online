using System;
using System.Collections.Generic;
using A;
using Photon;
using UnityEngine;
using XsdSettings;

public class QuestManager : Photon.MonoBehaviour, IDamageListener
{
	private class TaskProgress
	{
		public int m_characterId;

		public int m_questId;

		private int m_count;

		public bool m_isDirty;

		public bool m_isDone;

		public bool m_isSuccess;

		public QuestTask m_task;

		public QuestProgression m_progression;

		private bool m_bNeedSave;

		public int c9a57a1c6eac92cceec2de50aa04e4757
		{
			get
			{
				return m_count;
			}
			set
			{
				m_isDirty = value != m_count;
				int bNeedSave;
				if (!m_bNeedSave)
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
					bNeedSave = (m_isDirty ? 1 : 0);
				}
				else
				{
					bNeedSave = 1;
				}
				m_bNeedSave = (byte)bNeedSave != 0;
				m_count = value;
				m_progression.m_progress.mTaskProgress = m_count;
				m_isDone = m_count >= m_task.mTarget;
				if (!m_isDone)
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
					m_progression.cb6417467d06a91ed7a158790d8e877cc(m_task);
					return;
				}
			}
		}

		public bool ce99ab0eb074c21bc73f34a954b3107a5
		{
			get
			{
				return m_bNeedSave;
			}
		}
	}

	private class QuestProgression
	{
		public int m_characterId;

		public QuestProgress m_progress;

		public bool m_isDirty;

		public void c436d39aab7fcf511f0d05bfa21382243(QuestState c17fcd0ed1024ad7689991a96ed60deb1)
		{
			m_progress.mStatus = c17fcd0ed1024ad7689991a96ed60deb1;
			m_isDirty = true;
		}

		public void cb6417467d06a91ed7a158790d8e877cc(QuestTask cc0d456eb3f56f5d32d23620a7b525dcd)
		{
			if (m_progress.mCurrentTask != cc0d456eb3f56f5d32d23620a7b525dcd.mTaskId)
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
				Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(m_progress.mQuestId);
				if (cc0d456eb3f56f5d32d23620a7b525dcd.mTimeLimit != 0)
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
					if (!((double)cc0d456eb3f56f5d32d23620a7b525dcd.mTimeLimit >= c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c94ce42c8036c46b4b3e8327e21fffce0()))
					{
						c436d39aab7fcf511f0d05bfa21382243(QuestState.Failed);
						return;
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
				if (cc0d456eb3f56f5d32d23620a7b525dcd.mTaskId + 1 < quest.mTasks.Length)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							m_progress.mCurrentTask = cc0d456eb3f56f5d32d23620a7b525dcd.mTaskId + 1;
							m_progress.mTaskProgress = 0;
							return;
						}
					}
				}
				c436d39aab7fcf511f0d05bfa21382243(QuestState.Completed);
				return;
			}
		}
	}

	private static QuestManager s_instance;

	private List<TaskProgress> m_taskList = new List<TaskProgress>();

	private List<QuestProgression> m_questProgressionList = new List<QuestProgression>();

	public static QuestManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private void Awake()
	{
		s_instance = this;
	}

	protected void Start()
	{
		ce3999f448884c350b5510fc0d77e1e46(OnlineService.s_characterId, c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4bd163e6f603f6c0724372fd12f5f4cb());
	}

	private void OnDestroy()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cb5a871cb8bfa4f5acb9376850828d8bc();
	}

	protected void cae619de0d1899f7dd3f7bd982e66c933(int cf3ee56112c62330da43ddb0ed509ddf4)
	{
		Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c1b96f9e0e0373eb0c95ff2adb3efa970(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
		if (quest == null)
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
			QuestProgress questProgress = new QuestProgress();
			questProgress.mQuestId = quest.mId;
			questProgress.mStatus = QuestState.InProgress;
			questProgress.mCurrentTask = 999;
			for (int i = 0; i < quest.mTasks.Length; i++)
			{
				questProgress.mCurrentTask = Mathf.Min(questProgress.mCurrentTask, quest.mTasks[i].mTaskId);
				questProgress.mTaskProgress = 0;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				ccab7bbccad46c1d920e196e0de4167f9(cf3ee56112c62330da43ddb0ed509ddf4, quest, questProgress);
				return;
			}
		}
	}

	private void ccab7bbccad46c1d920e196e0de4167f9(int c5dfde30d8784694fb9999709d290e6c4, Quest c52b76aca0e4d0efec5a09cb55e9a0d1e, QuestProgress c3de77e741b3486260cf38174f79d4821)
	{
		if (c3de77e741b3486260cf38174f79d4821.mStatus != QuestState.InProgress)
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
		if (c52b76aca0e4d0efec5a09cb55e9a0d1e.mRequiredDifficulty != (int)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cfee2582eaf7bd61748c6f890c1e9365d())
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
			if (c52b76aca0e4d0efec5a09cb55e9a0d1e.mRequiredDifficulty != -1)
			{
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
		QuestProgression questProgression = new QuestProgression();
		questProgression.m_characterId = c5dfde30d8784694fb9999709d290e6c4;
		questProgression.m_progress = c3de77e741b3486260cf38174f79d4821;
		questProgression.c436d39aab7fcf511f0d05bfa21382243(c3de77e741b3486260cf38174f79d4821.mStatus);
		m_questProgressionList.Add(questProgression);
		for (int i = 0; i < c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks.Length; i++)
		{
			TaskProgress taskProgress = new TaskProgress();
			taskProgress.m_questId = c52b76aca0e4d0efec5a09cb55e9a0d1e.mId;
			taskProgress.m_characterId = c5dfde30d8784694fb9999709d290e6c4;
			taskProgress.m_progression = questProgression;
			taskProgress.m_task = new QuestTask
			{
				mAttackId = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mAttackId,
				mTarget = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mTarget,
				mTargetId = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mTargetId,
				mTaskId = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mTaskId,
				mTimeLimit = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mTimeLimit,
				mType = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mType,
				mItemType = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mItemType,
				mItemID = c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mItemID
			};
			if (c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mTaskId < c3de77e741b3486260cf38174f79d4821.mCurrentTask)
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
				taskProgress.c9a57a1c6eac92cceec2de50aa04e4757 = taskProgress.m_task.mTarget;
				taskProgress.m_isDone = true;
				taskProgress.m_isSuccess = true;
			}
			else if (c52b76aca0e4d0efec5a09cb55e9a0d1e.mTasks[i].mTaskId == c3de77e741b3486260cf38174f79d4821.mCurrentTask)
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
				taskProgress.c9a57a1c6eac92cceec2de50aa04e4757 = c3de77e741b3486260cf38174f79d4821.mTaskProgress;
			}
			taskProgress.m_isDirty = true;
			m_taskList.Add(taskProgress);
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

	public void ce3999f448884c350b5510fc0d77e1e46(int c5dfde30d8784694fb9999709d290e6c4, Dictionary<int, QuestProgress> cd563a3564d781de51750031f869a03aa)
	{
		if (cd563a3564d781de51750031f869a03aa == null)
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
		using (Dictionary<int, QuestProgress>.ValueCollection.Enumerator enumerator = cd563a3564d781de51750031f869a03aa.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QuestProgress current = enumerator.Current;
				int mQuestId = current.mQuestId;
				Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(mQuestId);
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
				if (!quest.mBoundInstanceList.c1a84901a0a9ec83a0000feb026941d27(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId))
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
					if (quest.mIsBoundInstance)
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
				}
				ccab7bbccad46c1d920e196e0de4167f9(c5dfde30d8784694fb9999709d290e6c4, quest, current);
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

	public void OnDamaged(DamageContext context)
	{
	}

	public void OnEntityKill(KillContext context)
	{
	}

	[RPC]
	private void RPC_H2C_UpdateTaskProgress(int questId, int taskId, int count, PhotonMessageInfo info)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c2a9e3aa730ddf2252b9c1473d8440379(questId, taskId, count);
			return;
		}
	}

	[RPC]
	private void RPC_H2C_UpdateQuestProgress(int questId, int state, PhotonMessageInfo info)
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c73138c5c7728a64e85530e587040e6db(questId, state);
			return;
		}
	}

	private void c2a9e3aa730ddf2252b9c1473d8440379(int c731f8f565b2035819f3412520ff285b3, int c43e3d8b3e47e153da82a98666f9b6412, int c9b15165c908ac1f9e9396c57137d3a67)
	{
		Dictionary<int, QuestProgress> dictionary = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4bd163e6f603f6c0724372fd12f5f4cb();
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			if (num3 < m_taskList.Count)
			{
				if (m_taskList[num3].m_questId == c731f8f565b2035819f3412520ff285b3)
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
					if (m_taskList[num3].m_task.mTaskId == c43e3d8b3e47e153da82a98666f9b6412)
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
						num = m_taskList[num3].m_progression.m_progress.mCurrentTask;
						m_taskList[num3].c9a57a1c6eac92cceec2de50aa04e4757 = c9b15165c908ac1f9e9396c57137d3a67;
						num2 = m_taskList[num3].m_progression.m_progress.mCurrentTask;
						flag = num != num2;
						dictionary[c731f8f565b2035819f3412520ff285b3] = m_taskList[num3].m_progression.m_progress;
						break;
					}
				}
				num3++;
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
			break;
		}
		if (flag)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnNewTask(OnlineService.s_characterId, c731f8f565b2035819f3412520ff285b3, num2);
		}
		if (dictionary.Count <= 0)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnQuestProgress(OnlineService.s_characterId, dictionary);
			return;
		}
	}

	private void c73138c5c7728a64e85530e587040e6db(int c731f8f565b2035819f3412520ff285b3, int c17fcd0ed1024ad7689991a96ed60deb1)
	{
		Dictionary<int, QuestProgress> dictionary = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4bd163e6f603f6c0724372fd12f5f4cb();
		bool flag = false;
		for (int i = 0; i < m_questProgressionList.Count; i++)
		{
			if (m_questProgressionList[i].m_progress.mQuestId != c731f8f565b2035819f3412520ff285b3)
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
			flag = true;
			m_questProgressionList[i].c436d39aab7fcf511f0d05bfa21382243((QuestState)c17fcd0ed1024ad7689991a96ed60deb1);
			if (dictionary.ContainsKey(m_questProgressionList[i].m_progress.mQuestId))
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
				dictionary[m_questProgressionList[i].m_progress.mQuestId].mStatus = (QuestState)c17fcd0ed1024ad7689991a96ed60deb1;
			}
			else
			{
				dictionary.Add(m_questProgressionList[i].m_progress.mQuestId, m_questProgressionList[i].m_progress);
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (!flag)
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
				Quest quest = c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0c8ccd79e03879ffc929ddac44fbc31c(c731f8f565b2035819f3412520ff285b3);
				QuestProgress questProgress = new QuestProgress();
				questProgress.mQuestId = c731f8f565b2035819f3412520ff285b3;
				questProgress.mStatus = QuestState.InProgress;
				questProgress.mCurrentTask = 999;
				for (int j = 0; j < quest.mTasks.Length; j++)
				{
					questProgress.mCurrentTask = Mathf.Min(questProgress.mCurrentTask, quest.mTasks[j].mTaskId);
					questProgress.mTaskProgress = 0;
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
				ccab7bbccad46c1d920e196e0de4167f9(OnlineService.s_characterId, quest, questProgress);
				dictionary[c731f8f565b2035819f3412520ff285b3] = questProgress;
			}
			if (dictionary.Count <= 0)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnQuestProgress(OnlineService.s_characterId, dictionary);
				return;
			}
		}
	}

	private static EntityNpc.EntitySubType c515423f18bff381dfcb9fa84ffa60d70(QuestEnemyType c1b74c5915e39170a5aa6ad96d0992a17)
	{
		return (EntityNpc.EntitySubType)(int)Enum.Parse(typeof(EntityNpc.EntitySubType), "CHR_" + c1b74c5915e39170a5aa6ad96d0992a17);
	}

	private static EntityNpc.EntityNpcFamilly ced7748ce3072cb44b842468581156023(QuestEnemyType c1b74c5915e39170a5aa6ad96d0992a17)
	{
		return (EntityNpc.EntityNpcFamilly)(int)Enum.Parse(typeof(EntityNpc.EntityNpcFamilly), c1b74c5915e39170a5aa6ad96d0992a17.ToString().Substring(3));
	}

	private static QuestAttackType c6ed53bb8e910c6c53c2d3186d1a105c4(AttackInfo.ElementalType c01adf83bf2e5024ab7c2cf2d958cfdd6, AttackSubType cc2a751229c536c25ab3fae62bfd9d1e5)
	{
		switch (c01adf83bf2e5024ab7c2cf2d958cfdd6)
		{
		case AttackInfo.ElementalType.Fire:
			return QuestAttackType.Fire;
		case AttackInfo.ElementalType.Shock:
			return QuestAttackType.Shock;
		case AttackInfo.ElementalType.Corrosive:
			return QuestAttackType.Corrosive;
		case AttackInfo.ElementalType.Explosive:
			return QuestAttackType.Explosive;
		default:
			switch (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cc2a751229c536c25ab3fae62bfd9d1e5))
			{
			case AttackInfo.AttackType.Melee:
				return QuestAttackType.Melee;
			case AttackInfo.AttackType.Projectile:
				return QuestAttackType.Any;
			case AttackInfo.AttackType.Area:
				return QuestAttackType.Any;
			case AttackInfo.AttackType.DamageOverTime:
				switch (AttackInfo.cd949fd4db8e262c24b57d93db37f93bf(cc2a751229c536c25ab3fae62bfd9d1e5))
				{
				case AttackInfo.ElementalType.Fire:
					return QuestAttackType.Fire;
				case AttackInfo.ElementalType.Shock:
					return QuestAttackType.Shock;
				case AttackInfo.ElementalType.Corrosive:
					return QuestAttackType.Corrosive;
				case AttackInfo.ElementalType.Explosive:
					return QuestAttackType.Explosive;
				}
				break;
			}
			return QuestAttackType.Any;
		}
	}
}
