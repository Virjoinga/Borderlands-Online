using System.Collections.Generic;

public interface ISkillTreeServiceNotificationListerner
{
	void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints);

	void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints);

	void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful);

	void OnResetSkillPt(int characterId, bool wasSuccessful);

	void OnSkillPtEarned(int characterId, int numEarned);
}
