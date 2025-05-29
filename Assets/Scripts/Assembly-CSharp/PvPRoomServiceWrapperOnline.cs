using A;

public class PvPRoomServiceWrapperOnline : IPvPRoomServiceWrapper, IServiceWrapper
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
			switch (7)
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
				switch (2)
				{
				case 0:
					continue;
				}
				m_isInitializing = true;
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c400ced1c9947fde74182ee4f25a9570e(OnGetMyPvPRoom);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c91b3622e4ee80042eaa2142a7f639e56(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnPlayerJoinPvPRoom);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c2316a0f8fb386cbc58a94d362e891b2e(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnPlayerLeavePvPRoom);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb56367b61a1d9d852e94baa33360edfa(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnPvPGameStart);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca7fda1e916bc5dc8a532dbb050f61829(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnPvPRoomClose);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c8a889a9c4828e990e77121594dbad509(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnPvPRoomOwnerChange);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf81eb90b44d659d7f1968edf0e9fbe49(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnPvPInvitationRecieved);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c49e6a046e282568081061bce76751216(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGroupJoinPvPRoom);
				OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c09adc6e0d66196a91d10a204adb4660c(c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.OnGroupLeavePvPRoom);
				return;
			}
		}
	}

	private void OnGetMyPvPRoom(Lobby room)
	{
		m_initialized = true;
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}

	public void caa4a47453ea971fd2067d44f36a0ed43(OnInviteToLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca1a46125e5889b9b6092367966900859(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c1cfffd13655715201bd438cb413c4f67(OnAcceptLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c56f2ef09c2c7b78d464a6d3be6b30e33(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c1bdf2c860a2d1cd68483a47561b6fc89(OnRejectLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb29008727fccd108206478ea0a634586(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c8842e55f3627037c4826450ddc239fa0(OnKickPlayerFromLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c90e08ff45bd89b1b852ef7a4959d640b(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c5e280689a1b4c9471dd5fdfb9a5fab31(OnLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ce30914cedf948c8ebefe3783fb6c7f87(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c9753076c0b0c7eec9eac887d781300ff(OnStartLobbyGame c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cf3b52513e8cba99304793361dc501a83(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c5fb2cfb40182a00f03bd404574c40d13(OnGetLobby c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c400ced1c9947fde74182ee4f25a9570e(c2db84530ef366a6deb001d449d4aa151);
	}
}
