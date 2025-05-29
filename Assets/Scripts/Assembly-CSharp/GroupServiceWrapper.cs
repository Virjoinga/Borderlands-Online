using System.Collections.Generic;

public class GroupServiceWrapper : ServiceWrapper<IGroupServiceWrapper, GroupServiceWrapper>
{
	private List<IGroupServiceNotificationListerner> m_listerner = new List<IGroupServiceNotificationListerner>();

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(IGroupServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(IGroupServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new GroupServiceWrapperOnline();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public void c84e7d656f39a60ef71f428c59209c060(OnGotMyGroupInfo c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c84e7d656f39a60ef71f428c59209c060(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c89fcb77276a7956cd51b61c3a4437b0f(OnSendGroupInvitation c2db84530ef366a6deb001d449d4aa151, int ca8606b1ba21cbc6f2fc0045fe691e617)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c89fcb77276a7956cd51b61c3a4437b0f(c2db84530ef366a6deb001d449d4aa151, ca8606b1ba21cbc6f2fc0045fe691e617);
	}

	public void cdabc733e8aacf96718d8617e58274f40(OnGroupInviteAccepted c2db84530ef366a6deb001d449d4aa151, int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cdabc733e8aacf96718d8617e58274f40(c2db84530ef366a6deb001d449d4aa151, c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c574e1ae38231526cf898f00f985e88b2(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c574e1ae38231526cf898f00f985e88b2(c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void c347662a41df388198423d3559d957132(OnKickPlayerFromGroup c2db84530ef366a6deb001d449d4aa151, int c1f6894ec2553584a258c0f0df766fc1f)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c347662a41df388198423d3559d957132(c2db84530ef366a6deb001d449d4aa151, c1f6894ec2553584a258c0f0df766fc1f);
	}

	public void c635f796eee513fdcf0733537d7f44398(OnLeaveGroup c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c635f796eee513fdcf0733537d7f44398(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c134957d891c1a5e48a3b0e225297e7cb()
	{
		c9374c9e18d64e753feff5ba5622a02ad().c134957d891c1a5e48a3b0e225297e7cb();
	}

	public void cde4925fdec123105628516489c324acf(OnGotMyGroupInfo c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cde4925fdec123105628516489c324acf(c2db84530ef366a6deb001d449d4aa151);
	}

	public void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnReceivedGroupInvitation(senderCharacterId, groupId, messageId);
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

	public void OnKickedFromGroup()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnKickedFromGroup();
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

	public void OnNewGroupLeader(int characterId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnNewGroupLeader(characterId);
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

	public void OnNewGroupMember(Presence characterinfo)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnNewGroupMember(characterinfo);
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

	public void OnGroupInviteRejected(int characterId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupInviteRejected(characterId);
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

	public void OnGroupMemberLeft(int characterId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupMemberLeft(characterId);
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

	public void OnGroupDisbanded()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupDisbanded();
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

	public void OnGroupMatchmakingStarted()
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnGroupMatchmakingStarted();
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
}
