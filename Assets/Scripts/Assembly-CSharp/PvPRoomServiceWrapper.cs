using System.Collections.Generic;

public class PvPRoomServiceWrapper : ServiceWrapper<IPvPRoomServiceWrapper, PvPRoomServiceWrapper>
{
	private List<IPvPRoomServiceNotificationListerner> m_listerner = new List<IPvPRoomServiceNotificationListerner>();

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(IPvPRoomServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(IPvPRoomServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new PvPRoomServiceWrapperOnline();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public void caa4a47453ea971fd2067d44f36a0ed43(OnInviteToLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().caa4a47453ea971fd2067d44f36a0ed43(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c1cfffd13655715201bd438cb413c4f67(OnAcceptLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c1cfffd13655715201bd438cb413c4f67(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c1bdf2c860a2d1cd68483a47561b6fc89(OnRejectLobbyInvitation c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c1bdf2c860a2d1cd68483a47561b6fc89(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c8842e55f3627037c4826450ddc239fa0(OnKickPlayerFromLobby c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c8842e55f3627037c4826450ddc239fa0(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c5e280689a1b4c9471dd5fdfb9a5fab31(OnLeaveLobby c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c5e280689a1b4c9471dd5fdfb9a5fab31(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c9753076c0b0c7eec9eac887d781300ff(OnStartLobbyGame c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c9753076c0b0c7eec9eac887d781300ff(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c5fb2cfb40182a00f03bd404574c40d13(OnGetLobby c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c5fb2cfb40182a00f03bd404574c40d13(c2db84530ef366a6deb001d449d4aa151);
	}

	public void OnPlayerJoinPvPRoom(Presence newPlayer)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPlayerJoinPvPRoom(newPlayer);
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

	public void OnPlayerLeavePvPRoom(int characterId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPlayerLeavePvPRoom(characterId);
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

	public void OnPvPGameStart()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPvPGameStart();
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
			return;
		}
	}

	public void OnPvPRoomClose()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPvPRoomClose();
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

	public void OnPvPRoomOwnerChange(int newOwnerCharacterId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPvPRoomOwnerChange(newOwnerCharacterId);
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

	public void OnGroupJoinPvPRoom(int newGroup)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupJoinPvPRoom(newGroup);
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
			return;
		}
	}

	public void OnGroupLeavePvPRoom(int newGroup)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupLeavePvPRoom(newGroup);
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
			return;
		}
	}

	public void OnPvPInvitationRecieved(int sender, int messageId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnPvPInvitationRecieved(sender, messageId);
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
