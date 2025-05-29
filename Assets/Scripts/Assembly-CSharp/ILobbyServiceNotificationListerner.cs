public interface ILobbyServiceNotificationListerner
{
	void OnNewLobby(Lobby newLobby);

	void OnPlayerJoinLobby(Presence newPlayer);

	void OnPlayerLeaveLobby(int characterId);

	void OnLobbyCreated(Lobby room);

	void OnLobbyGameStart();

	void OnLobbyClose();

	void OnLobbyOwnerChange(int newOwnerCharacterId);

	void OnGroupJoinLobby(int newGroup);

	void OnGroupLeaveLobby(int newGroup);

	void OnLobbyInvitationRecieved(int sender, int messageId);
}
