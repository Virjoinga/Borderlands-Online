using System.Collections;

public class QuestProgress
{
	public int mQuestId;

	public QuestState mStatus;

	public int mCurrentTask;

	public int mTaskProgress;

	public QuestProgress()
	{
	}

	public QuestProgress(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
	}

	public void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		mQuestId = (int)c591d56a94543e3559945c497f37126c4[0];
		mStatus = (QuestState)(int)c591d56a94543e3559945c497f37126c4[1];
		mCurrentTask = (int)c591d56a94543e3559945c497f37126c4[2];
		mTaskProgress = (int)c591d56a94543e3559945c497f37126c4[3];
	}
}
