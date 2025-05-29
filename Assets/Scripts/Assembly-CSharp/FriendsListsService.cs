using System;
using System.Collections;
using System.Collections.Generic;
using A;
using XsdSettings;

internal class FriendsListsService : OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>, IFriendsListsService
{
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	private List<OnNewFriend> mOnNewFriend = new List<OnNewFriend>();

	private List<OnUnfriended> mOnUnfriended = new List<OnUnfriended>();

	private List<OnFriendRequestReceived> mOnFriendRequestReceived = new List<OnFriendRequestReceived>();

	private OnGetMyFriendsList mOnGetMyFriendsList;

	private OnIsUserAFriend mOnIsUserAFriend;

	private OnIsUserIgnored mOnIsUserIgnored;

	private OnGetFriendsCharacterInfo mOnGetFriendsCharacterInfo;

	private OnGetMyPendingFriendRequests mOnGetMyPendingFriendRequests;

	public FriendsListsService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(207, OnRetrieveFriendsList);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(206, OnIsUserAFriend);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(201, OnIsUserIgnored);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(144, OnGotFriendsCharacterInfo);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(208, OnNewFriendEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(207, OnUnfriendedEvent);
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c87d2b468801f2ac5185e4eea8e8cf7a3("friend_request", OnFriendRequestReceived);
	}

	public void c0c080bd9e3394d77ec5a804d2a9f4106(OnGetMyFriendsList c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetMyFriendsList = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(207, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnRetrieveFriendsList(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetMyFriendsList == null)
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
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(parameters.Count);
				int num = 0;
				using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						array[num++] = (int)((Hashtable)current)[0];
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_0086;
						}
						continue;
						end_IL_0086:
						break;
					}
				}
				mOnGetMyFriendsList(array);
			}
			else
			{
				mOnGetMyFriendsList(cdaeaf95d71df33e056aef814d5b686ff.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnGetMyFriendsList = c8fd93b7c0c46146a5e7c44d32d22c69e.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cbbcfd0bf92e11cfa6ba6b913e85d9791(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(164, array);
	}

	public void c7f0dffe793ab211fb14de2aedcb03e7d(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(205, array);
	}

	public void cc247771682223024f44ff9d22a219678(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(165, array);
	}

	public void cb1931c1ebff26aa30fe00faff1603cea(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(204, array);
	}

	public void cc0c48b374f42e26b6e9ed360a1b3b117(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(203, array);
	}

	public void cdb408b579eae20e64d078d773e5e11cc(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(202, array);
	}

	public void c150511d61b60f422cbcb6a664fa3ae1c(OnIsUserAFriend c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		mOnIsUserAFriend = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = OnlineService.s_characterId;
		array[1] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(206, array);
	}

	private void OnIsUserAFriend(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnIsUserAFriend == null)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				int characterId = (int)parameters[0];
				int characterId2 = (int)parameters[1];
				bool result = (bool)parameters[2];
				mOnIsUserAFriend(characterId, characterId2, result);
			}
			else
			{
				mOnIsUserAFriend(-1, -1, false);
			}
			mOnIsUserAFriend = c03114f96974eca2c6ea06519293913fc.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c69b5b785e4b3483f67b9de74c2ef7b07(OnIsUserIgnored c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		mOnIsUserIgnored = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = OnlineService.s_characterId;
		array[1] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(201, array);
	}

	private void OnIsUserIgnored(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnIsUserIgnored == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				int characterId = (int)parameters[0];
				int characterId2 = (int)parameters[1];
				bool result = (bool)parameters[2];
				mOnIsUserIgnored(characterId, characterId2, result);
			}
			else
			{
				mOnIsUserIgnored(-1, -1, false);
			}
			mOnIsUserIgnored = c471c34cfe733166417747e744852e5b7.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c025eff487db757fc22da3c49cc34e893(OnFriendRequestReceived c2db84530ef366a6deb001d449d4aa151)
	{
		mOnFriendRequestReceived.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cad3a5edcde90bc5cec0acccb80a54d96(OnFriendRequestReceived c2db84530ef366a6deb001d449d4aa151)
	{
		mOnFriendRequestReceived.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnFriendRequestReceived(Message message)
	{
		mOnFriendRequestReceived.ForEach(delegate(OnFriendRequestReceived c2db84530ef366a6deb001d449d4aa151)
		{
			FriendRequest c36964cf41281414170f34ee68bef6c = default(FriendRequest);
			c292c0459faf9cda5cb9d2f1cdc796e68.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			c36964cf41281414170f34ee68bef6c.mMessageId = message.mId;
			c36964cf41281414170f34ee68bef6c.mSender = message.mSender;
			c2db84530ef366a6deb001d449d4aa151(c36964cf41281414170f34ee68bef6c);
		});
	}

	public void c80434356593b573ea7da041eb3b4177f(OnIsUserAFriend c2db84530ef366a6deb001d449d4aa151, int cf173d33763475cd4e4c68bfe91ae6c16, int c5ae1a08e575c642d25ab9d1a6bbae667)
	{
		mOnIsUserAFriend = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = cf173d33763475cd4e4c68bfe91ae6c16;
		array[1] = c5ae1a08e575c642d25ab9d1a6bbae667;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(206, array);
	}

	public void c29b2efeea1dc998485e42e9f47181575(OnIsUserIgnored c2db84530ef366a6deb001d449d4aa151, int cf173d33763475cd4e4c68bfe91ae6c16, int c5ae1a08e575c642d25ab9d1a6bbae667)
	{
		mOnIsUserIgnored = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = cf173d33763475cd4e4c68bfe91ae6c16;
		array[1] = c5ae1a08e575c642d25ab9d1a6bbae667;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(201, array);
	}

	public void cb70aa5c7f0a7f74df164587279faa393(OnGetFriendsCharacterInfo c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetFriendsCharacterInfo = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(144, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGotFriendsCharacterInfo(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetFriendsCharacterInfo == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				List<PlayerProperties> list = new List<PlayerProperties>();
				Hashtable hashtable = (Hashtable)parameters[0];
				IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Dictionary<byte, object> dictionary = (Dictionary<byte, object>)((DictionaryEntry)enumerator.Current).Value;
						PlayerProperties playerProperties = new PlayerProperties();
						playerProperties.m_id = (int)dictionary[0];
						playerProperties.m_name = (string)dictionary[1];
						playerProperties.m_level = (int)dictionary[2];
						playerProperties.m_avatarDna = new AvatarDNA();
						PlayerProperties playerProperties2 = playerProperties;
						playerProperties2.m_avatarDna.c300c4ff719a5623d8161bef607d268f1((AvatarType)(int)dictionary[3]);
						list.Add(playerProperties2);
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_00f8;
						}
						continue;
						end_IL_00f8:
						break;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable == null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_0110;
							}
							continue;
							end_IL_0110:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
				mOnGetFriendsCharacterInfo(list);
			}
			else
			{
				mOnGetFriendsCharacterInfo(c968c05a0a77cadbac62f57fe3bcedd3b.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnGetFriendsCharacterInfo = c97063c1a6f7542ee4ccfe594f18dd145.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void ccceb0f72a209e610a05e32f2bbb3eacb(OnGetMyPendingFriendRequests c2db84530ef366a6deb001d449d4aa151)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mOnGetMyPendingFriendRequests = c2db84530ef366a6deb001d449d4aa151;
		}
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cde08d917e68f9dec60dac2ce9359317f(OnRetrieveMessagesResponse, "friend_request", false);
	}

	private void OnRetrieveMessagesResponse(Message[] messages)
	{
		if (mOnGetMyPendingFriendRequests == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			FriendRequest[] array = c2bfbca743ee651a738857b8aac1c2ce5.c0a0cdf4a196914163f7334d9b0781a04(messages.Length);
			for (int i = 0; i < messages.Length; i++)
			{
				array[i].mMessageId = messages[i].mId;
				array[i].mSender = messages[i].mSender;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				mOnGetMyPendingFriendRequests(array);
				mOnGetMyPendingFriendRequests = ce437cae79a87f3311a639c7188b44c4a.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}
	}

	public void c6ae275220cc90665328bca5a59b5d8b0(OnNewFriend c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewFriend.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c42641b2a02bd4742bc9d01ba9377007a(OnNewFriend c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewFriend.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnNewFriendEvent(Dictionary<byte, object> parameters)
	{
		Presence presence = new Presence((Hashtable)parameters[0]);
		mOnNewFriend.ForEach(delegate(OnNewFriend c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(presence);
		});
	}

	public void cb4778873060b94492e5ad8c7fab7867c(OnUnfriended c2db84530ef366a6deb001d449d4aa151)
	{
		mOnUnfriended.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cba9bfe604ad47f8081cf9e72319ed62a(OnUnfriended c2db84530ef366a6deb001d449d4aa151)
	{
		mOnUnfriended.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnUnfriendedEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnUnfriended.ForEach(delegate(OnUnfriended c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(characterId);
		});
	}
}
