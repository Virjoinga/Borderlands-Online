public interface IPvPRoomServiceNotificationListerner
{
	void OnPlayerJoinPvPRoom(Presence newPlayer);

	void OnPlayerLeavePvPRoom(int characterId);

	void OnPvPGameStart();

	void OnPvPRoomClose();

	void OnPvPRoomOwnerChange(int newOwnerCharacterId);

	void OnGroupJoinPvPRoom(int newGroup);

	void OnGroupLeavePvPRoom(int newGroup);

	void OnPvPInvitationRecieved(int sender, int messageId);
}
