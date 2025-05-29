using System.Collections.Generic;

public class FriendServiceWrapper : ServiceWrapper<IFriendServiceWrapper, FriendServiceWrapper>
{
	protected List<IFriendServiceNotificationListerner> m_listerner = new List<IFriendServiceNotificationListerner>();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new FriendServiceWrapperOnline();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public void c0c080bd9e3394d77ec5a804d2a9f4106(OnGetMyFriendsList c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c0c080bd9e3394d77ec5a804d2a9f4106(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cbbcfd0bf92e11cfa6ba6b913e85d9791(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cbbcfd0bf92e11cfa6ba6b913e85d9791(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c7f0dffe793ab211fb14de2aedcb03e7d(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c7f0dffe793ab211fb14de2aedcb03e7d(c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void cc247771682223024f44ff9d22a219678(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cc247771682223024f44ff9d22a219678(c93f916e26c7f7aec4117058ff8a6c39d);
	}

	public void cb1931c1ebff26aa30fe00faff1603cea(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cb1931c1ebff26aa30fe00faff1603cea(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cc0c48b374f42e26b6e9ed360a1b3b117(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cc0c48b374f42e26b6e9ed360a1b3b117(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cdb408b579eae20e64d078d773e5e11cc(int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cdb408b579eae20e64d078d773e5e11cc(c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cf7722224c7d1307313afc3ac9d6c3f0f(OnIsUserAFriend c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cf7722224c7d1307313afc3ac9d6c3f0f(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void c4d847bdb1d904be0060f06149e5262fa(OnIsUserIgnored c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c4d847bdb1d904be0060f06149e5262fa(c2db84530ef366a6deb001d449d4aa151, c5dfde30d8784694fb9999709d290e6c4);
	}

	public void cb70aa5c7f0a7f74df164587279faa393(OnGetFriendsCharacterInfo c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().cb70aa5c7f0a7f74df164587279faa393(c2db84530ef366a6deb001d449d4aa151);
	}

	public void ccceb0f72a209e610a05e32f2bbb3eacb(OnGetMyPendingFriendRequests c2db84530ef366a6deb001d449d4aa151)
	{
		c9374c9e18d64e753feff5ba5622a02ad().ccceb0f72a209e610a05e32f2bbb3eacb(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(IFriendServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(IFriendServiceNotificationListerner c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void OnFriendRequestReceived(FriendRequest friendRequest)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnFriendRequestReceived(friendRequest);
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

	public void OnNewFriend(Presence friendInfo)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnNewFriend(friendInfo);
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

	public void OnUnfriended(int friendCharacterId)
	{
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnUnfriended(friendCharacterId);
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
}
