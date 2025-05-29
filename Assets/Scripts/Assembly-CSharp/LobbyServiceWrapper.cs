using System.Collections.Generic;
using XsdSettings;

public class LobbyServiceWrapper : ServiceWrapper<ILobbyServiceWrapper, LobbyServiceWrapper>
{
	private List<ILobbyServiceNotificationListerner> m_listerner = new List<ILobbyServiceNotificationListerner>();

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(ILobbyServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(ILobbyServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new LobbyServiceWrapperOnline();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public void ca1a46125e5889b9b6092367966900859(OnInviteToLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().ca1a46125e5889b9b6092367966900859(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c56f2ef09c2c7b78d464a6d3be6b30e33(OnAcceptLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c56f2ef09c2c7b78d464a6d3be6b30e33(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void cb29008727fccd108206478ea0a634586(OnRejectLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cb29008727fccd108206478ea0a634586(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c90e08ff45bd89b1b852ef7a4959d640b(OnKickPlayerFromLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c90e08ff45bd89b1b852ef7a4959d640b(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void ce30914cedf948c8ebefe3783fb6c7f87(OnLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().ce30914cedf948c8ebefe3783fb6c7f87(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf3b52513e8cba99304793361dc501a83(OnStartLobbyGame c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cf3b52513e8cba99304793361dc501a83(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c400ced1c9947fde74182ee4f25a9570e(OnGetLobby c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c400ced1c9947fde74182ee4f25a9570e(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c7a337098f70dabdd1dc7f3a6a249dc79(OnCloseLobby c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c7a337098f70dabdd1dc7f3a6a249dc79(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c5e5cc544f50051d78abdccc1aec483a8(OnOpenLobby c2db84530ef366a6deb001d449d4aa151, GamemodeType c7c285f21497bec76d425ba4a0a524b46, int c62856dd6dd9686293af23b8532ee3525, ELevelDifficulty c46b57735a769802f4565a74b7185cc1f)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c5e5cc544f50051d78abdccc1aec483a8(c2db84530ef366a6deb001d449d4aa151, c7c285f21497bec76d425ba4a0a524b46, c62856dd6dd9686293af23b8532ee3525, c46b57735a769802f4565a74b7185cc1f);
	}

	public void cf919217c11722f259176c952c8aba513(OnCreateLobby c2db84530ef366a6deb001d449d4aa151, bool c6e6204a589f73f6bec566251719b4847)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cf919217c11722f259176c952c8aba513(c2db84530ef366a6deb001d449d4aa151, c6e6204a589f73f6bec566251719b4847);
	}

	public void c5df4cb8523b76dbc1c7b8d4f040e074a(Presence cff1dc2897ac6340245df41811ed528e6)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPlayerJoinLobby(cff1dc2897ac6340245df41811ed528e6);
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
			return;
		}
	}

	public void cc057af74a47c74d8690b13138820e1d7(int c5dfde30d8784694fb9999709d290e6c4)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPlayerLeaveLobby(c5dfde30d8784694fb9999709d290e6c4);
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
			return;
		}
	}

	public void c25521b20ad3e5d175f88a988c6459882(Lobby c3202f32ecb834b115326e72e13e35ff0)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnLobbyCreated(c3202f32ecb834b115326e72e13e35ff0);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public void c0e8f139c4f68e49fc180807c88dd33ab()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnLobbyGameStart();
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
			return;
		}
	}

	public void c7c96d5054056252e6165f5a6b6f95521()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnLobbyClose();
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
			return;
		}
	}

	public void c751d380f8b1c0d2b0e8527aa405623b3(int ce13cee3d1e1d70d06f08b27a696e09e8)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnLobbyOwnerChange(ce13cee3d1e1d70d06f08b27a696e09e8);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public void ca0eb402e9f376a67dd322343a98db8c8(int c979ec2891bdf45f616bb8a2b2b7051d5, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnLobbyInvitationRecieved(c979ec2891bdf45f616bb8a2b2b7051d5, c93f916e26c7f7aec4117058ff8a6c39d);
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
			return;
		}
	}

	public void cdccf85d97d2f0766a772d1d1c0745e76(int c9d58ef65dac2c7419ce2207ee64cd716)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupJoinLobby(c9d58ef65dac2c7419ce2207ee64cd716);
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
			return;
		}
	}

	public void ce439ec92ceab5080ef4f11bbdb306a27(int c9d58ef65dac2c7419ce2207ee64cd716)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupLeaveLobby(c9d58ef65dac2c7419ce2207ee64cd716);
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
			return;
		}
	}

	public void c7f53a1d367b0082775167e157684e411(Lobby cabcbc76b1bd3f15487ab1fe989815a74)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnNewLobby(cabcbc76b1bd3f15487ab1fe989815a74);
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
			return;
		}
	}
}
