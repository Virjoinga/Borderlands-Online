using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;

public class PvPRoomManager : IPvPRoomServiceNotificationListerner
{
	public int m_nRoomOwnerId = -1;

	public bool m_bInRoom;

	protected static PvPRoomManager _PvPRoomInstance;

	public Dictionary<int, Presence> m_RoomInfoMap;

	private PvPRoomManager()
	{
		m_RoomInfoMap = new Dictionary<int, Presence>();
		m_RoomInfoMap.Clear();
	}

	public static PvPRoomManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_PvPRoomInstance == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_PvPRoomInstance = new PvPRoomManager();
			c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_PvPRoomInstance);
		}
		return _PvPRoomInstance;
	}

	public bool c829214fb27d5055667975031067dc825()
	{
		return m_bInRoom;
	}

	public bool cb7f148598f59ea065be4d6fa7fe1ac66()
	{
		return OnlineService.s_characterId == m_nRoomOwnerId;
	}

	public bool cd5c06fa7fd7b3e5c7621d2107419ec81()
	{
		if (m_bInRoom)
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
					return false;
				}
			}
		}
		if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return false;
	}

	private void c56e87f978b4e8a2e87ad9f1c998f958c()
	{
		m_bInRoom = false;
		m_nRoomOwnerId = -1;
		m_RoomInfoMap.Clear();
	}

	public void OnPlayerJoinPvPRoom(Presence newPlayer)
	{
		if (newPlayer == null)
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
			if (m_RoomInfoMap.ContainsKey(newPlayer.mCharacterId))
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
				m_RoomInfoMap.Add(newPlayer.mCharacterId, newPlayer);
				return;
			}
		}
	}

	public void OnPlayerLeavePvPRoom(int characterId)
	{
		if (!m_RoomInfoMap.ContainsKey(characterId))
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
			m_RoomInfoMap.Remove(characterId);
			return;
		}
	}

	public void OnPvPGameStart()
	{
	}

	public void OnPvPRoomClose()
	{
		c56e87f978b4e8a2e87ad9f1c998f958c();
	}

	public void OnPvPRoomOwnerChange(int newOwnerCharacterId)
	{
		m_nRoomOwnerId = newOwnerCharacterId;
	}

	public void OnGroupJoinPvPRoom(int newGroup)
	{
	}

	public void OnGroupLeavePvPRoom(int newGroup)
	{
	}

	public void OnPvPInvitationRecieved(int sender, int messageId)
	{
	}

	private void OnFindPvPRoom(Lobby room)
	{
		c56e87f978b4e8a2e87ad9f1c998f958c();
		if (room == null)
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
			m_bInRoom = true;
			m_nRoomOwnerId = room.Owner;
			room.Members.ForEach(delegate(Presence c5ebdc65d5cb420faf7ba524809963aa9)
			{
				m_RoomInfoMap.Add(c5ebdc65d5cb420faf7ba524809963aa9.mCharacterId, c5ebdc65d5cb420faf7ba524809963aa9);
			});
			return;
		}
	}

	public void c5fb2cfb40182a00f03bd404574c40d13()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5fb2cfb40182a00f03bd404574c40d13(OnFindPvPRoom);
	}

	public void caa4a47453ea971fd2067d44f36a0ed43(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.caa4a47453ea971fd2067d44f36a0ed43(OnInviteToPvPRoom, c5dfde30d8784694fb9999709d290e6c4);
	}

	private void OnInviteToPvPRoom(bool success)
	{
	}

	public void c1cfffd13655715201bd438cb413c4f67(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c1cfffd13655715201bd438cb413c4f67(OnFindPvPRoom, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c1bdf2c860a2d1cd68483a47561b6fc89(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdf2c860a2d1cd68483a47561b6fc89(OnRejectPvPRoomInvitation, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	private void OnRejectPvPRoomInvitation(bool success)
	{
	}

	public void c8842e55f3627037c4826450ddc239fa0(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c8842e55f3627037c4826450ddc239fa0(OnKickPlayerFromPvPRoom, c5dfde30d8784694fb9999709d290e6c4);
	}

	private void OnKickPlayerFromPvPRoom(bool success, int characterId)
	{
	}

	public void c5e280689a1b4c9471dd5fdfb9a5fab31()
	{
		c1ee7921b0c3cce194fb7cae41b5a9d82<PvPRoomServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5e280689a1b4c9471dd5fdfb9a5fab31(OnLeavePvPRoom);
	}

	private void OnLeavePvPRoom(bool success)
	{
		if (!success)
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
			c56e87f978b4e8a2e87ad9f1c998f958c();
			return;
		}
	}

	[CompilerGenerated]
	private void c1acbef3304a1fa881f24bafdd76f6fa2(Presence c5ebdc65d5cb420faf7ba524809963aa9)
	{
		m_RoomInfoMap.Add(c5ebdc65d5cb420faf7ba524809963aa9.mCharacterId, c5ebdc65d5cb420faf7ba524809963aa9);
	}
}
