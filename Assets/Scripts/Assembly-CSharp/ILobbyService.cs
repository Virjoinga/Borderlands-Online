using XsdSettings;

internal interface ILobbyService
{
	void cf919217c11722f259176c952c8aba513(OnCreateLobby c2db84530ef366a6deb001d449d4aa151, bool c6e6204a589f73f6bec566251719b4847);

	void c5e5cc544f50051d78abdccc1aec483a8(OnOpenLobby c2db84530ef366a6deb001d449d4aa151, GamemodeType c7c285f21497bec76d425ba4a0a524b46, int c62856dd6dd9686293af23b8532ee3525, ELevelDifficulty c46b57735a769802f4565a74b7185cc1f);

	void ca1a46125e5889b9b6092367966900859(OnInviteToLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4);

	void c56f2ef09c2c7b78d464a6d3be6b30e33(OnAcceptLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d);

	void cb29008727fccd108206478ea0a634586(OnRejectLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d);

	void c90e08ff45bd89b1b852ef7a4959d640b(OnKickPlayerFromLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4);

	void ce30914cedf948c8ebefe3783fb6c7f87(OnLeaveLobby c2db84530ef366a6deb001d449d4aa151);

	void cf3b52513e8cba99304793361dc501a83(OnStartLobbyGame c2db84530ef366a6deb001d449d4aa151);

	void c400ced1c9947fde74182ee4f25a9570e(OnGetLobby c2db84530ef366a6deb001d449d4aa151);

	void c7a337098f70dabdd1dc7f3a6a249dc79(OnCloseLobby c2db84530ef366a6deb001d449d4aa151);

	void c91b3622e4ee80042eaa2142a7f639e56(OnPlayerJoinLobby c2db84530ef366a6deb001d449d4aa151);

	void ce344b11a9d5fa10629adbc4930ebe482(OnPlayerJoinLobby c2db84530ef366a6deb001d449d4aa151);

	void c2316a0f8fb386cbc58a94d362e891b2e(OnPlayerLeaveLobby c2db84530ef366a6deb001d449d4aa151);

	void c6720d557f823dbb5bd96023ca32c6cf5(OnPlayerLeaveLobby c2db84530ef366a6deb001d449d4aa151);

	void c65c2d6a8fba3f4edbace2efb75320ca0(OnLobbyCreated c2db84530ef366a6deb001d449d4aa151);

	void c059cfcfa6c6800f5eecd0a6742ad4606(OnLobbyCreated c2db84530ef366a6deb001d449d4aa151);

	void cb56367b61a1d9d852e94baa33360edfa(OnLobbyGameStart c2db84530ef366a6deb001d449d4aa151);

	void c2a676874872d31dd2524cce6a535ae6e(OnLobbyGameStart c2db84530ef366a6deb001d449d4aa151);

	void ca7fda1e916bc5dc8a532dbb050f61829(OnLobbyClose c2db84530ef366a6deb001d449d4aa151);

	void c126495a8b634410cc144c3020eb31419(OnLobbyClose c2db84530ef366a6deb001d449d4aa151);

	void c8a889a9c4828e990e77121594dbad509(OnLobbyOwnerChange c2db84530ef366a6deb001d449d4aa151);

	void cd6c9d4aae264adafc9bf1eb27c60d3a8(OnLobbyOwnerChange c2db84530ef366a6deb001d449d4aa151);

	void cf81eb90b44d659d7f1968edf0e9fbe49(OnLobbyInvitationRecieved c2db84530ef366a6deb001d449d4aa151);

	void cbff6fddd09e2e701bceb3160d8ff63a1(OnLobbyInvitationRecieved c2db84530ef366a6deb001d449d4aa151);

	void c49e6a046e282568081061bce76751216(OnGroupJoinLobby c2db84530ef366a6deb001d449d4aa151);

	void c9f1c948894da42060e98acb5a29bebab(OnGroupJoinLobby c2db84530ef366a6deb001d449d4aa151);

	void c09adc6e0d66196a91d10a204adb4660c(OnGroupLeaveLobby c2db84530ef366a6deb001d449d4aa151);

	void c03d085ec0beb8c53feb590a552d9808e(OnGroupLeaveLobby c2db84530ef366a6deb001d449d4aa151);

	void c8207c4bd711f8db99cf8daf6a2a1b6ce(OnNewLobby c2db84530ef366a6deb001d449d4aa151);

	void c1c16ff56aeced5d679185f23becc9aad(OnNewLobby c2db84530ef366a6deb001d449d4aa151);
}
