public interface IFriendServiceNotificationListerner
{
	void OnFriendRequestReceived(FriendRequest friendRequest);

	void OnNewFriend(Presence friendInfo);

	void OnUnfriended(int friendCharacterId);
}
