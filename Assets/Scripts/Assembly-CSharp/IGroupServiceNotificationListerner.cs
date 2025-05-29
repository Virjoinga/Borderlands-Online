public interface IGroupServiceNotificationListerner
{
	void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId);

	void OnKickedFromGroup();

	void OnNewGroupLeader(int characterId);

	void OnNewGroupMember(Presence characterinfo);

	void OnGroupInviteRejected(int characterId);

	void OnGroupMemberLeft(int characterId);

	void OnGroupDisbanded();

	void OnGroupMatchmakingStarted();
}
