public interface INetworkManagerListener
{
	void OnJoinedRoom();

	void OnPhotonJoinRoomFailed();

	void OnPhotonRandomJoinFailed();

	void OnDisconnectedFromPhoton();

	void OnLeftRoom();
}
