using System.Collections.Generic;
using A;
using Core;

internal class GameInvitationService : OnAccessSingleton<IGameInvitationService, GameInvitationService, GameInvitationServiceOffline>, IGameInvitationService
{
	private List<GameInvitationCallback> mGameInvitationCallbacks;

	private bool mWaitingOnIsFriendsGameJoinable;

	private bool mIsFriendsGameJoinable;

	public GameInvitationService()
	{
		mGameInvitationCallbacks = new List<GameInvitationCallback>();
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c87d2b468801f2ac5185e4eea8e8cf7a3("game_invitation", OnGameInvitationReceived);
		PhotonNetwork.networkingPeer.c71111ea3c8afdb98963505d86a8495b6(137, OnAcceptGameInvitationResponse);
	}

	public void c2a9851d45be22427de9c341ccb994d68(GameInvitationCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mGameInvitationCallbacks.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c35da19b9c3eb358ffdb49dfa0fa3c926(GameInvitationCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mGameInvitationCallbacks.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c78d0394257e5901444ba6c7d309c11d3(string cfbe80bfe797338ac909b03da7a69ef08)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cfbe80bfe797338ac909b03da7a69ef08;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(200, array);
	}

	private void OnGameInvitationReceived(Message message)
	{
		mGameInvitationCallbacks.ForEach(delegate(GameInvitationCallback c2db84530ef366a6deb001d449d4aa151)
		{
			GameInvitation c36964cf41281414170f34ee68bef6c = default(GameInvitation);
			c52da9dc2159c80b647b392518145f75b.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			c36964cf41281414170f34ee68bef6c.mId = message.mId;
			c36964cf41281414170f34ee68bef6c.mSender = message.mSender;
			c2db84530ef366a6deb001d449d4aa151(c36964cf41281414170f34ee68bef6c);
		});
	}

	public void c2b234219005ba028476114a8117fa41d(GameInvitation cfd6fb9b14530f8f94c3ee197484b21bf)
	{
		NetworkingPeer networkingPeer = PhotonNetwork.networkingPeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cfd6fb9b14530f8f94c3ee197484b21bf.mId;
		networkingPeer.c50190e0c5838cf36bc56ebceb28dcdaa(137, array);
	}

	private void OnAcceptGameInvitationResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (parameters == null)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (!parameters.ContainsKey(0))
				{
					return;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = (int)parameters[1];
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "GameInvitationService.OnAcceptGameInvitationResponse - playlistId: " + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", (string)parameters[0]);
					return;
				}
			}
		}
	}

	public void c1e91466ab2875ac28da3216b1f3fa528(GameInvitation cfd6fb9b14530f8f94c3ee197484b21bf)
	{
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce4f66b66479413697c4095985f07fe73(cfd6fb9b14530f8f94c3ee197484b21bf.mId);
	}

	public bool cc610ba1e701bfb9ff932ff345cc69a0b(string cfbe80bfe797338ac909b03da7a69ef08)
	{
		mWaitingOnIsFriendsGameJoinable = true;
		mIsFriendsGameJoinable = false;
		PhotonNetwork.networkingPeer.c64252907630eb3dbcc25305b98437731(cfbe80bfe797338ac909b03da7a69ef08);
		while (mWaitingOnIsFriendsGameJoinable)
		{
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return mIsFriendsGameJoinable;
		}
	}

	public void OnIsFriendsGameJoinable(bool result)
	{
		mIsFriendsGameJoinable = result;
		mWaitingOnIsFriendsGameJoinable = false;
	}

	public void c3ef3d5906e65ad5ff8288af98d5d4722(string cfbe80bfe797338ac909b03da7a69ef08)
	{
		PhotonNetwork.networkingPeer.c2935569ee141e8f27fd790d08feaa41b(cfbe80bfe797338ac909b03da7a69ef08);
	}
}
