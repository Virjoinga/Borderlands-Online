using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using A;
using Core;
using XsdSettings;

internal class LobbyService : OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>, ILobbyService
{
	private enum State
	{
		Closed = 0,
		Creating = 1,
		Created = 2,
		Joining = 3,
		Joined = 4,
		Opening = 5,
		Opened = 6,
		Leaving = 7,
		Left = 8
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct CachedEvent
	{
		public Dictionary<byte, object> Parameters { get; set; }

		public EventCallback Callback { get; set; }

		public int RoomId { get; set; }
	}

	private OnCreateLobby mOnCreateLobby;

	private OnOpenLobby mOnOpenLobby;

	private OnInviteToLobby mOnInviteToLobby;

	private OnAcceptLobbyInvitation mOnAcceptLobbyInvitation;

	private OnRejectLobbyInvitation mOnRejectLobbyInvitation;

	private OnKickPlayerFromLobby mOnKickPlayerFromLobby;

	private OnLeaveLobby mOnLeaveLobby;

	private OnStartLobbyGame mOnStartPvPGame;

	private OnCloseLobby mOnCloseLobby;

	private OnSetPlayerTeamID mOnSetPlayerTeamID;

	private OnGetLobby mOnGetLobby;

	private List<OnPlayerJoinLobby> mOnPlayerJoinLobby;

	private List<OnPlayerLeaveLobby> mOnPlayerLeaveLobby;

	private List<OnLobbyCreated> mOnLobbyCreated;

	private List<OnLobbyGameStart> mOnLobbyGameStart;

	private List<OnLobbyClose> mOnLobbyClose;

	private List<OnLobbyOwnerChange> mOnLobbyOwnerChange;

	private List<OnGroupJoinLobby> mOnGroupJoinLobby;

	private List<OnGroupLeaveLobby> mOnGroupLeaveLobby;

	private List<OnNewLobby> mOnNewLobby;

	private List<OnLobbyInvitationRecieved> mOnLobbyInvitationReceived;

	private List<CachedEvent> mCachedEvents;

	private State mState;

	[CompilerGenerated]
	private static Action<OnLobbyGameStart> _003C_003Ef__am_0024cache17;

	[CompilerGenerated]
	private static Action<OnLobbyClose> _003C_003Ef__am_0024cache18;

	private bool c4b5a55c44e7780f52c3fdf7566e2afb4
	{
		get
		{
			int result;
			if (mState != State.Creating)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (mState != State.Opening)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (mState != State.Joining)
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
						result = ((mState == State.Leaving) ? 1 : 0);
						goto IL_004e;
					}
				}
			}
			result = 1;
			goto IL_004e;
			IL_004e:
			return (byte)result != 0;
		}
	}

	public LobbyService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(87, OnCreateLobbyResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(96, OnOpenLobbyResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(132, OnInviteToLobbyResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(131, OnAcceptLobbyInvitationResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(130, OnRejectLobbyInvitationResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(129, OnKickPlayerFromLobbyResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(228, OnLeaveLobbyResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(126, OnGetLobbyResponse);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(125, OnCloseLobbyResponse);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(194, OnPlayerJoinLobbyEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(193, OnPlayerLeftLobbyEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(166, OnLobbyCreatedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(164, OnNewLobbyEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(192, OnLobbyGameStartEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(191, OnLobbyCloseEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(190, OnLobbyOwnerChangeEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(189, OnGroupJoinedLobbyEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(188, OnGroupLeaveLobbyEvent);
		PhotonNetwork.networkingPeer.c71111ea3c8afdb98963505d86a8495b6(124, OnAcceptLobbyGameInvitation);
		PhotonNetwork.networkingPeer.c71111ea3c8afdb98963505d86a8495b6(122, OnSetPlayerTeamIDResponse);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(192, OnPvPGameCreatedEvent);
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c87d2b468801f2ac5185e4eea8e8cf7a3("lobby_invite", OnLobbyInvitationReceived);
		mOnPlayerJoinLobby = new List<OnPlayerJoinLobby>();
		mOnPlayerLeaveLobby = new List<OnPlayerLeaveLobby>();
		mOnLobbyCreated = new List<OnLobbyCreated>();
		mOnLobbyGameStart = new List<OnLobbyGameStart>();
		mOnLobbyClose = new List<OnLobbyClose>();
		mOnLobbyOwnerChange = new List<OnLobbyOwnerChange>();
		mOnGroupJoinLobby = new List<OnGroupJoinLobby>();
		mOnGroupLeaveLobby = new List<OnGroupLeaveLobby>();
		mOnLobbyInvitationReceived = new List<OnLobbyInvitationRecieved>();
		mOnNewLobby = new List<OnNewLobby>();
		mCachedEvents = new List<CachedEvent>();
		mState = State.Closed;
	}

	public void cf919217c11722f259176c952c8aba513(OnCreateLobby c2db84530ef366a6deb001d449d4aa151, bool c6e6204a589f73f6bec566251719b4847)
	{
		mState = State.Creating;
		mOnCreateLobby = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c6e6204a589f73f6bec566251719b4847;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(87, array);
	}

	private void OnCreateLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			while (true)
			{
				switch (6)
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
			mState = State.Created;
			Lobby lobby = new Lobby((Hashtable)parameters[0]);
			if (mOnCreateLobby != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnCreateLobby(lobby);
			}
			c7955f4447a19137adaf2840420f966cb(lobby.Id);
		}
		else
		{
			mState = State.Closed;
			if (mOnCreateLobby != null)
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
				mOnCreateLobby(c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e);
			}
		}
		mOnCreateLobby = cb1abeb6df8dbb28d5c866e2f50662618.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void c5e5cc544f50051d78abdccc1aec483a8(OnOpenLobby c2db84530ef366a6deb001d449d4aa151, GamemodeType c7c285f21497bec76d425ba4a0a524b46, int c62856dd6dd9686293af23b8532ee3525, ELevelDifficulty c46b57735a769802f4565a74b7185cc1f)
	{
		mState = State.Opening;
		mOnOpenLobby = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = (int)c7c285f21497bec76d425ba4a0a524b46;
		array[1] = c62856dd6dd9686293af23b8532ee3525;
		array[2] = (int)c46b57735a769802f4565a74b7185cc1f;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(96, array);
	}

	private void OnOpenLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			while (true)
			{
				switch (6)
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
			mState = State.Opened;
			Lobby lobby = new Lobby((Hashtable)parameters[0]);
			if (mOnOpenLobby != null)
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
				mOnOpenLobby(lobby);
			}
			c7955f4447a19137adaf2840420f966cb(lobby.Id);
		}
		else
		{
			mState = State.Closed;
			if (mOnOpenLobby != null)
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
				mOnOpenLobby(c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e);
			}
		}
		mOnOpenLobby = cbcd7ae2517336311b405fca763dd067b.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void ca1a46125e5889b9b6092367966900859(OnInviteToLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		mOnInviteToLobby = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(132, array);
	}

	private void OnInviteToLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnInviteToLobby == null)
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
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnInviteToLobby(true);
			}
			else
			{
				mOnInviteToLobby(false);
			}
			mOnInviteToLobby = c15cad49827514036445e2f00b0eef2cb.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c56f2ef09c2c7b78d464a6d3be6b30e33(OnAcceptLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		mState = State.Joining;
		mOnAcceptLobbyInvitation = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(131, array);
	}

	private void OnAcceptLobbyInvitationResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mState = State.Joined;
			Lobby lobby = new Lobby((Hashtable)parameters[0]);
			if (mOnAcceptLobbyInvitation != null)
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
				mOnAcceptLobbyInvitation(lobby);
			}
			c7955f4447a19137adaf2840420f966cb(lobby.Id);
		}
		else
		{
			mState = State.Closed;
			if (mOnAcceptLobbyInvitation != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnAcceptLobbyInvitation(c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e);
			}
		}
		mOnAcceptLobbyInvitation = ce566282c685685f647b48b503d76cc92.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void cb29008727fccd108206478ea0a634586(OnRejectLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		mOnRejectLobbyInvitation = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(130, array);
	}

	private void OnRejectLobbyInvitationResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnRejectLobbyInvitation == null)
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
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnRejectLobbyInvitation(true);
			}
			else
			{
				mOnRejectLobbyInvitation(false);
			}
			mOnRejectLobbyInvitation = cf44c98bc3b5950f00acb34057ece62b6.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c90e08ff45bd89b1b852ef7a4959d640b(OnKickPlayerFromLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		mOnKickPlayerFromLobby = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(129, array);
	}

	private void OnKickPlayerFromLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnKickPlayerFromLobby == null)
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
				int characterId = (int)parameters[0];
				mOnKickPlayerFromLobby(true, characterId);
			}
			else
			{
				mOnKickPlayerFromLobby(false, -1);
			}
			mOnKickPlayerFromLobby = c40f2555baffd2bce34413c36fcee7b18.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void ce30914cedf948c8ebefe3783fb6c7f87(OnLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mState = State.Leaving;
		mOnLeaveLobby = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(228, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnLeaveLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mState = State.Left;
			if (mOnLeaveLobby != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnLeaveLobby(true);
			}
			c7955f4447a19137adaf2840420f966cb(0);
		}
		else
		{
			mState = State.Closed;
			if (mOnLeaveLobby != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnLeaveLobby(false);
			}
		}
		mOnLeaveLobby = cff9676360ed41a0de61ed9502828af3a.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void cf3b52513e8cba99304793361dc501a83(OnStartLobbyGame c2db84530ef366a6deb001d449d4aa151)
	{
	}

	public void c91b3622e4ee80042eaa2142a7f639e56(OnPlayerJoinLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnPlayerJoinLobby.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void ce344b11a9d5fa10629adbc4930ebe482(OnPlayerJoinLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnPlayerJoinLobby.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnPlayerJoinLobbyEvent(Dictionary<byte, object> parameters)
	{
		if (c4b5a55c44e7780f52c3fdf7566e2afb4)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mCachedEvents.Add(new CachedEvent
					{
						Parameters = parameters,
						Callback = OnPlayerJoinLobbyEvent,
						RoomId = (int)parameters[1]
					});
					return;
				}
			}
		}
		Presence character = new Presence((Hashtable)parameters[0]);
		mOnPlayerJoinLobby.ForEach(delegate(OnPlayerJoinLobby c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(character);
		});
	}

	public void c2316a0f8fb386cbc58a94d362e891b2e(OnPlayerLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnPlayerLeaveLobby.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c6720d557f823dbb5bd96023ca32c6cf5(OnPlayerLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnPlayerLeaveLobby.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnPlayerLeftLobbyEvent(Dictionary<byte, object> parameters)
	{
		int player = (int)parameters[0];
		mOnPlayerLeaveLobby.ForEach(delegate(OnPlayerLeaveLobby c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(player);
		});
	}

	public void c65c2d6a8fba3f4edbace2efb75320ca0(OnLobbyCreated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyCreated.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c059cfcfa6c6800f5eecd0a6742ad4606(OnLobbyCreated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyCreated.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnLobbyCreatedEvent(Dictionary<byte, object> parameters)
	{
		Lobby room = new Lobby((Hashtable)parameters[0]);
		mOnLobbyCreated.ForEach(delegate(OnLobbyCreated c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(room);
		});
	}

	public void cb56367b61a1d9d852e94baa33360edfa(OnLobbyGameStart c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyGameStart.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c2a676874872d31dd2524cce6a535ae6e(OnLobbyGameStart c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyGameStart.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnLobbyGameStartEvent(Dictionary<byte, object> parameters)
	{
		if (c4b5a55c44e7780f52c3fdf7566e2afb4)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mCachedEvents.Add(new CachedEvent
					{
						Parameters = parameters,
						Callback = OnLobbyGameStartEvent,
						RoomId = (int)parameters[0]
					});
					return;
				}
			}
		}
		PhotonNetwork.networkingPeer.c50190e0c5838cf36bc56ebceb28dcdaa(124, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
		List<OnLobbyGameStart> list = mOnLobbyGameStart;
		if (_003C_003Ef__am_0024cache17 == null)
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
			_003C_003Ef__am_0024cache17 = delegate(OnLobbyGameStart c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cache17);
	}

	public void ca7fda1e916bc5dc8a532dbb050f61829(OnLobbyClose c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyClose.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c126495a8b634410cc144c3020eb31419(OnLobbyClose c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyClose.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnLobbyCloseEvent(Dictionary<byte, object> parameters)
	{
		mState = State.Closed;
		List<OnLobbyClose> list = mOnLobbyClose;
		if (_003C_003Ef__am_0024cache18 == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_003C_003Ef__am_0024cache18 = delegate(OnLobbyClose c5ebdc65d5cb420faf7ba524809963aa9)
			{
				c5ebdc65d5cb420faf7ba524809963aa9();
			};
		}
		list.ForEach(_003C_003Ef__am_0024cache18);
	}

	public void c8a889a9c4828e990e77121594dbad509(OnLobbyOwnerChange c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyOwnerChange.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cd6c9d4aae264adafc9bf1eb27c60d3a8(OnLobbyOwnerChange c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyOwnerChange.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnLobbyOwnerChangeEvent(Dictionary<byte, object> parameters)
	{
		int newOwner = (int)parameters[0];
		mOnLobbyOwnerChange.ForEach(delegate(OnLobbyOwnerChange c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(newOwner);
		});
	}

	public void cf81eb90b44d659d7f1968edf0e9fbe49(OnLobbyInvitationRecieved c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyInvitationReceived.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cbff6fddd09e2e701bceb3160d8ff63a1(OnLobbyInvitationRecieved c2db84530ef366a6deb001d449d4aa151)
	{
		mOnLobbyInvitationReceived.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnLobbyInvitationReceived(Message message)
	{
		mOnLobbyInvitationReceived.ForEach(delegate(OnLobbyInvitationRecieved c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(message.mSender, message.mId);
		});
	}

	public void c49e6a046e282568081061bce76751216(OnGroupJoinLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupJoinLobby.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c9f1c948894da42060e98acb5a29bebab(OnGroupJoinLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupJoinLobby.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGroupJoinedLobbyEvent(Dictionary<byte, object> parameters)
	{
		if (c4b5a55c44e7780f52c3fdf7566e2afb4)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mCachedEvents.Add(new CachedEvent
					{
						Parameters = parameters,
						Callback = OnGroupJoinedLobbyEvent,
						RoomId = (int)parameters[1]
					});
					return;
				}
			}
		}
		int newGroup = (int)parameters[0];
		mOnGroupJoinLobby.ForEach(delegate(OnGroupJoinLobby c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(newGroup);
		});
	}

	public void c09adc6e0d66196a91d10a204adb4660c(OnGroupLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupLeaveLobby.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c03d085ec0beb8c53feb590a552d9808e(OnGroupLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGroupLeaveLobby.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGroupLeaveLobbyEvent(Dictionary<byte, object> parameters)
	{
		if (c4b5a55c44e7780f52c3fdf7566e2afb4)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mCachedEvents.Add(new CachedEvent
					{
						Parameters = parameters,
						Callback = OnGroupLeaveLobbyEvent,
						RoomId = (int)parameters[1]
					});
					return;
				}
			}
		}
		int newGroup = (int)parameters[0];
		mOnGroupLeaveLobby.ForEach(delegate(OnGroupLeaveLobby c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(newGroup);
		});
	}

	public void c8207c4bd711f8db99cf8daf6a2a1b6ce(OnNewLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewLobby.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c1c16ff56aeced5d679185f23becc9aad(OnNewLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewLobby.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnNewLobbyEvent(Dictionary<byte, object> parameters)
	{
		Lobby newLobby = new Lobby((Hashtable)parameters[0]);
		mOnNewLobby.ForEach(delegate(OnNewLobby c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(newLobby);
		});
	}

	public void c400ced1c9947fde74182ee4f25a9570e(OnGetLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGetLobby = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(126, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void c120791be4a021bb56a2bc83624034be6(OnGetLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		mOnGetLobby = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(126, array);
	}

	private void OnGetLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetLobby == null)
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
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				Lobby room = new Lobby((Hashtable)parameters[0]);
				mOnGetLobby(room);
			}
			else
			{
				mOnGetLobby(c879d606e15475cf9d576cc62b721ca45.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnGetLobby = cebeeb46ffc7e89bc7ce18818c8f29ac7.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c7a337098f70dabdd1dc7f3a6a249dc79(OnCloseLobby c2db84530ef366a6deb001d449d4aa151)
	{
		mOnCloseLobby = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(125, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cddd7844f3231d1cc9b60ffd632c2a57b(OnCloseLobby c2db84530ef366a6deb001d449d4aa151, int cc87f1be0acb768df8ad592ae73d95e06)
	{
		mOnCloseLobby = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cc87f1be0acb768df8ad592ae73d95e06;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(125, array);
	}

	private void OnCloseLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		mState = State.Closed;
		if (mOnCloseLobby == null)
		{
			return;
		}
		while (true)
		{
			switch (6)
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
				mOnCloseLobby(true);
			}
			else
			{
				mOnCloseLobby(false);
			}
			mOnCloseLobby = c0b351ad5182be735ff98b8e9da3f159d.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c6da1b3336894d9537eb2465db79254e8(OnSetPlayerTeamID c2db84530ef366a6deb001d449d4aa151, int c1cc10478b0fb75a49477a8f3df0d162c, int c6518f874296c762c9541b6588700caff)
	{
		mOnSetPlayerTeamID = c2db84530ef366a6deb001d449d4aa151;
		NetworkingPeer networkingPeer = PhotonNetwork.networkingPeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c1cc10478b0fb75a49477a8f3df0d162c;
		array[1] = c6518f874296c762c9541b6588700caff;
		networkingPeer.c50190e0c5838cf36bc56ebceb28dcdaa(122, array);
	}

	private void OnSetPlayerTeamIDResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSetPlayerTeamID == null)
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
				mOnSetPlayerTeamID(true);
			}
			else
			{
				mOnSetPlayerTeamID(false);
			}
			mOnSetPlayerTeamID = c284883b2f75002b448eebde395b4d573.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnPvPGameCreatedEvent(Dictionary<byte, object> parameters)
	{
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(123, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnAcceptLobbyGameInvitation(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse != 0)
		{
			return;
		}
		while (true)
		{
			switch (6)
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
				switch (5)
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
					switch (2)
					{
					case 0:
						continue;
					}
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().cd0069281ff5290a7e6c484b6aed3933d)
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
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = (int)parameters[1];
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "LobbyService.OnAcceptPvPGameInvitation - " + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", (string)parameters[0]);
					return;
				}
			}
		}
	}

	private void c7955f4447a19137adaf2840420f966cb(int cc87f1be0acb768df8ad592ae73d95e06)
	{
		using (List<CachedEvent>.Enumerator enumerator = mCachedEvents.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CachedEvent current = enumerator.Current;
				if (current.RoomId != cc87f1be0acb768df8ad592ae73d95e06)
				{
					continue;
				}
				while (true)
				{
					switch (2)
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
				current.Callback(current.Parameters);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_005b;
				}
				continue;
				end_IL_005b:
				break;
			}
		}
		mCachedEvents.Clear();
	}

	private void OnSetPlayerTeamID(bool success)
	{
	}

	[CompilerGenerated]
	private static void c0d850d273246f9ff91f914eedf1cc0bb(OnLobbyGameStart c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9();
	}

	[CompilerGenerated]
	private static void c2c92843d27dc95fda5b75c2c54df71bd(OnLobbyClose c5ebdc65d5cb420faf7ba524809963aa9)
	{
		c5ebdc65d5cb420faf7ba524809963aa9();
	}
}
