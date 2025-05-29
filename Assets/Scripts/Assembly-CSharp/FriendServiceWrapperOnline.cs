using A;

public class FriendServiceWrapperOnline : IFriendServiceWrapper, IServiceWrapper
{
	private bool m_isInitializing;

	private bool m_initialized;

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_isInitializing)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_initialized)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				m_isInitializing = true;
				OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c025eff487db757fc22da3c49cc34e893(c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnFriendRequestReceived);
				OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c6ae275220cc90665328bca5a59b5d8b0(c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnNewFriend);
				OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb4778873060b94492e5ad8c7fab7867c(c1ee7921b0c3cce194fb7cae41b5a9d82<FriendServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnUnfriended);
				OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c0c080bd9e3394d77ec5a804d2a9f4106(OnGetMyFriendsList);
				FriendManager.c71f6ce28731edfd43c976fbd57c57bea();
				return;
			}
		}
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}

	private void OnGetMyFriendsList(int[] characterIds)
	{
		m_initialized = true;
	}

	public void c0c080bd9e3394d77ec5a804d2a9f4106(OnGetMyFriendsList c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c0c080bd9e3394d77ec5a804d2a9f4106(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cbbcfd0bf92e11cfa6ba6b913e85d9791(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cbbcfd0bf92e11cfa6ba6b913e85d9791(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c7f0dffe793ab211fb14de2aedcb03e7d(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7f0dffe793ab211fb14de2aedcb03e7d(c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void cc247771682223024f44ff9d22a219678(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc247771682223024f44ff9d22a219678(c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void cb1931c1ebff26aa30fe00faff1603cea(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb1931c1ebff26aa30fe00faff1603cea(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cc0c48b374f42e26b6e9ed360a1b3b117(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc0c48b374f42e26b6e9ed360a1b3b117(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cdb408b579eae20e64d078d773e5e11cc(int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cdb408b579eae20e64d078d773e5e11cc(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cf7722224c7d1307313afc3ac9d6c3f0f(OnIsUserAFriend c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c150511d61b60f422cbcb6a664fa3ae1c(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c4d847bdb1d904be0060f06149e5262fa(OnIsUserIgnored c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c69b5b785e4b3483f67b9de74c2ef7b07(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cb70aa5c7f0a7f74df164587279faa393(OnGetFriendsCharacterInfo c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb70aa5c7f0a7f74df164587279faa393(c2db84530ef366a6deb001d449d4aa151);
	}

	public void ccceb0f72a209e610a05e32f2bbb3eacb(OnGetMyPendingFriendRequests c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ccceb0f72a209e610a05e32f2bbb3eacb(c2db84530ef366a6deb001d449d4aa151);
	}
}
