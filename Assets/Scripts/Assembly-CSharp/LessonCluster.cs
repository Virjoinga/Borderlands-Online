using A;
using UnityEngine;

public class LessonCluster : Scene
{
	private ClusterAction_TutorialLesson m_tutorialLesson;

	private ClusterAction_ResetTutorTask m_resetTutorTask;

	private bool m_forceComplete;

	public ClusterAction[] m_npcTasks = c111275d4ad878a6fe2a6c4e067bb8986.c0a0cdf4a196914163f7334d9b0781a04(0);

	[HideInInspector]
	public bool m_showNpcTasks;

	[HideInInspector]
	public bool m_CompleteAfterNpcTasksDone = true;

	[HideInInspector]
	public bool m_closePreviousLessonCluster = true;

	[HideInInspector]
	public LessonCluster m_previousLessonCluster;

	protected override bool c6b55d8e5c9702fae8ea5ac979f1a8713()
	{
		return false;
	}

	public ClusterAction_TutorialLesson cbccfec798ca1f865b007e9b94200c707()
	{
		if (m_tutorialLesson != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_tutorialLesson;
				}
			}
		}
		if (m_completionActions != null)
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
			for (int i = 0; i < m_completionActions.Length; i++)
			{
				m_tutorialLesson = m_completionActions[i] as ClusterAction_TutorialLesson;
				if (!(m_tutorialLesson != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					return m_tutorialLesson;
				}
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
		return null;
	}

	public ClusterAction_ResetTutorTask c0033acff92702a89553bf2cc640a932f()
	{
		if (m_resetTutorTask != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_resetTutorTask;
				}
			}
		}
		if (m_completionActions != null)
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
			for (int i = 0; i < m_completionActions.Length; i++)
			{
				m_resetTutorTask = m_completionActions[i] as ClusterAction_ResetTutorTask;
				if (!(m_resetTutorTask != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					return m_resetTutorTask;
				}
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
		return null;
	}
}
