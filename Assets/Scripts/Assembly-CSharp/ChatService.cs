using System.Collections.Generic;
using A;
using Core;

internal class ChatService : OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>, IChatService
{
	private OnChat mOnChat;

	private List<OnNewChat> mOnNewChat = new List<OnNewChat>();

	private List<OnChatOK> mOnChatOK = new List<OnChatOK>();

	public ChatService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(139, OnChated);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(199, OnNewchated);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(198, OnSendChatOk);
		PhotonNetwork.networkingPeer.c71111ea3c8afdb98963505d86a8495b6(139, OnGameChated);
		PhotonNetwork.networkingPeer.c89f9569b4330d0286992724cb1480f55(199, OnGameNewchated);
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
	}

	public void ce7ecb13108674f84f720553066d29db7(OnChat c2db84530ef366a6deb001d449d4aa151, byte c60cae76d65f1a4f1b2b01da404f738b0, int c1cc10478b0fb75a49477a8f3df0d162c, string c76759d33b9cb2580a3b145e1ba084675, string ca04b8fe5d43144ba3361431c00741486, byte[] c869de72ad8783f7d8dd3eff78f110bae)
	{
		if (c60cae76d65f1a4f1b2b01da404f738b0 != 8)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c60cae76d65f1a4f1b2b01da404f738b0 != 5)
			{
				mOnChat = c2db84530ef366a6deb001d449d4aa151;
				OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
				array[0] = c60cae76d65f1a4f1b2b01da404f738b0;
				array[1] = c1cc10478b0fb75a49477a8f3df0d162c;
				array[2] = c76759d33b9cb2580a3b145e1ba084675;
				array[3] = ca04b8fe5d43144ba3361431c00741486;
				array[4] = c869de72ad8783f7d8dd3eff78f110bae;
				onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(139, array);
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		mOnChat = c2db84530ef366a6deb001d449d4aa151;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "chatType: " + c60cae76d65f1a4f1b2b01da404f738b0);
		PhotonNetwork.networkingPeer.OpCustom(139, new Dictionary<byte, object>
		{
			{ 0, c60cae76d65f1a4f1b2b01da404f738b0 },
			{ 1, c1cc10478b0fb75a49477a8f3df0d162c },
			{ 2, c76759d33b9cb2580a3b145e1ba084675 },
			{ 3, ca04b8fe5d43144ba3361431c00741486 },
			{ 4, c869de72ad8783f7d8dd3eff78f110bae }
		}, true);
	}

	private void OnChated(short operationResponse, Dictionary<byte, object> parameters)
	{
		short num = (short)parameters[0];
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "OnChated: ";
		array[1] = operationResponse;
		array[2] = " Result ";
		array[3] = num;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat(array));
		if (mOnChat == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mOnChat(operationResponse);
			mOnChat = cb7d6bb3aca5870507be5aa4083d1d2e8.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnGameChated(short operationResponse, Dictionary<byte, object> parameters)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "OnChated: " + operationResponse);
		if (mOnChat == null)
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
			mOnChat(operationResponse);
			mOnChat = cb7d6bb3aca5870507be5aa4083d1d2e8.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnNewchated(Dictionary<byte, object> parameters)
	{
		byte chattype = (byte)parameters[0];
		int charID = (int)parameters[1];
		string charNickname = (string)parameters[2];
		string content = (string)parameters[3];
		byte[] attachedobject = (byte[])parameters[4];
		mOnNewChat.ForEach(delegate(OnNewChat c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(chattype, charID, charNickname, content, attachedobject);
		});
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = "OnNewchated  chattype: ";
		array[1] = (int)chattype;
		array[2] = " CharID: ";
		array[3] = charID;
		array[4] = " nickname : ";
		array[5] = charNickname;
		array[6] = " content: ";
		array[7] = content;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat(array));
	}

	private void OnGameNewchated(Dictionary<byte, object> parameters)
	{
		byte chattype = (byte)parameters[0];
		int charID = (int)parameters[1];
		string charNickname = (string)parameters[2];
		string content = (string)parameters[3];
		byte[] attachedobject = (byte[])parameters[4];
		mOnNewChat.ForEach(delegate(OnNewChat c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(chattype, charID, charNickname, content, attachedobject);
		});
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = "OnNewchated  chattype: ";
		array[1] = (int)chattype;
		array[2] = " CharID: ";
		array[3] = charID;
		array[4] = " nickname : ";
		array[5] = charNickname;
		array[6] = " content: ";
		array[7] = content;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat(array));
	}

	private void OnSendChatOk(Dictionary<byte, object> parameters)
	{
		byte chattype = (byte)parameters[0];
		int charID = (int)parameters[1];
		string charNickname = (string)parameters[2];
		string content = (string)parameters[3];
		byte[] attachedobject = (byte[])parameters[4];
		mOnChatOK.ForEach(delegate(OnChatOK c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(chattype, charID, charNickname, content, attachedobject);
		});
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = "OnSendChatOk  chattype: ";
		array[1] = (int)chattype;
		array[2] = " CharID: ";
		array[3] = charID;
		array[4] = " nickname : ";
		array[5] = charNickname;
		array[6] = " content: ";
		array[7] = content;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat(array));
	}

	public void c99ae00bed7f8b90460dead1f6df257e8(OnNewChat c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewChat.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cc8d3253f8397c4475d7f6d887b02c64e(OnNewChat c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewChat.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c26284ca2d02d3aa0631d68ff992ed262(OnChatOK c2db84530ef366a6deb001d449d4aa151)
	{
		mOnChatOK.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf536a49fbacf1808b502e8e454bda345(OnChatOK c2db84530ef366a6deb001d449d4aa151)
	{
		mOnChatOK.Remove(c2db84530ef366a6deb001d449d4aa151);
	}
}
