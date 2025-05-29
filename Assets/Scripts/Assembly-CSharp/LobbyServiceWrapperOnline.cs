using A;
using XsdSettings;

public class LobbyServiceWrapperOnline : ILobbyServiceWrapper, IServiceWrapper
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
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c49e6a046e282568081061bce76751216(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdccf85d97d2f0766a772d1d1c0745e76);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c09adc6e0d66196a91d10a204adb4660c(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce439ec92ceab5080ef4f11bbdb306a27);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca7fda1e916bc5dc8a532dbb050f61829(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7c96d5054056252e6165f5a6b6f95521);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c65c2d6a8fba3f4edbace2efb75320ca0(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c25521b20ad3e5d175f88a988c6459882);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb56367b61a1d9d852e94baa33360edfa(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0e8f139c4f68e49fc180807c88dd33ab);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c8a889a9c4828e990e77121594dbad509(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c751d380f8b1c0d2b0e8527aa405623b3);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c91b3622e4ee80042eaa2142a7f639e56(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5df4cb8523b76dbc1c7b8d4f040e074a);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c2316a0f8fb386cbc58a94d362e891b2e(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc057af74a47c74d8690b13138820e1d7);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf81eb90b44d659d7f1968edf0e9fbe49(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca0eb402e9f376a67dd322343a98db8c8);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c8207c4bd711f8db99cf8daf6a2a1b6ce(c1ee7921b0c3cce194fb7cae41b5a9d82<LobbyServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7f53a1d367b0082775167e157684e411);
				LobbyManager.c71f6ce28731edfd43c976fbd57c57bea();
				m_initialized = true;
				return;
			}
		}
	}

	private void OnGetMyLobby(Lobby room)
	{
		m_initialized = true;
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}

	public void ca1a46125e5889b9b6092367966900859(OnInviteToLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca1a46125e5889b9b6092367966900859(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c56f2ef09c2c7b78d464a6d3be6b30e33(OnAcceptLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c56f2ef09c2c7b78d464a6d3be6b30e33(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void cb29008727fccd108206478ea0a634586(OnRejectLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb29008727fccd108206478ea0a634586(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c90e08ff45bd89b1b852ef7a4959d640b(OnKickPlayerFromLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c90e08ff45bd89b1b852ef7a4959d640b(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void ce30914cedf948c8ebefe3783fb6c7f87(OnLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce30914cedf948c8ebefe3783fb6c7f87(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf3b52513e8cba99304793361dc501a83(OnStartLobbyGame c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf3b52513e8cba99304793361dc501a83(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c400ced1c9947fde74182ee4f25a9570e(OnGetLobby c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c400ced1c9947fde74182ee4f25a9570e(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c7a337098f70dabdd1dc7f3a6a249dc79(OnCloseLobby c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7a337098f70dabdd1dc7f3a6a249dc79(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf919217c11722f259176c952c8aba513(OnCreateLobby c2db84530ef366a6deb001d449d4aa151, bool c6e6204a589f73f6bec566251719b4847)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf919217c11722f259176c952c8aba513(c2db84530ef366a6deb001d449d4aa151, c6e6204a589f73f6bec566251719b4847);
	}

	public void c5e5cc544f50051d78abdccc1aec483a8(OnOpenLobby c2db84530ef366a6deb001d449d4aa151, GamemodeType c7c285f21497bec76d425ba4a0a524b46, int c62856dd6dd9686293af23b8532ee3525, ELevelDifficulty c46b57735a769802f4565a74b7185cc1f)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5e5cc544f50051d78abdccc1aec483a8(c2db84530ef366a6deb001d449d4aa151, c7c285f21497bec76d425ba4a0a524b46, c62856dd6dd9686293af23b8532ee3525, c46b57735a769802f4565a74b7185cc1f);
	}
}
