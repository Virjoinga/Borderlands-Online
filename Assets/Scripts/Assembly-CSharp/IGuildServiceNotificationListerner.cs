public interface IGuildServiceNotificationListerner
{
	void OnReceivedGuildInvitation(int guildId, string guildMasterNick, string guildName);

	void OnReceivedGuildJoined(int guildId, string guildName);

	void OnReceivedGuildExpelled(int guildId, string guildName);

	void OnReceivedFreeGuildSkillSlotGiven(int guildId, int remainFreeSkillCount);

	void OnReceivedGuildSkillSelected(int guildId, int skillId, int remainFreeSkillCount);

	void OnReceivedGuildManagerAssigned(int guildId);

	void OnReceivedGuildManagerDischarged(int guildId);

	void OnReceivedGuildMasterChanged(int guildId);
}
