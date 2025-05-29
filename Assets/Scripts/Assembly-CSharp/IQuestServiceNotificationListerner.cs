using System.Collections.Generic;
using XsdSettings;

public interface IQuestServiceNotificationListerner
{
	void OnQuestUpdate(int characterId, int questId, QuestState questState);

	void OnQuestAccepted(int characterId, int questId);

	void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards);

	void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> quests);

	void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID);
}
