using System;
using System.Collections.Generic;
using System.Text;
using A;
using Core;
using UnityEngine;

public class ChatView : BaseView
{
	protected struct ChatInfoDesc
	{
		public ChatParameter m_iType;

		public string m_strUserName;

		public int m_ID;

		public string m_strContent;

		public string m_strChatText;
	}

	protected const int Max_WorldMsg_Num = 2048;

	protected const float TIME_HIDE = 60f;

	private string chatInputString = string.Empty;

	private int selectChannel;

	private bool _bChannelSel;

	public string[] selStrings;

	protected bool _bInputing;

	protected Dictionary<ChatParameter, string> m_mapChannelName;

	protected Dictionary<ChatParameter, string> m_mapChannelColor = new Dictionary<ChatParameter, string>
	{
		{
			ChatParameter.BroadCast,
			"#FFFFFF"
		},
		{
			ChatParameter.Friend,
			"#FFFFFF"
		},
		{
			ChatParameter.Group,
			"#00B0F0"
		},
		{
			ChatParameter.Guild,
			"#00FF00"
		},
		{
			ChatParameter.None,
			"#FFFFFF"
		},
		{
			ChatParameter.Private,
			"#FF2391"
		},
		{
			ChatParameter.System,
			"#A5F64E"
		},
		{
			ChatParameter.Team,
			"#00B0F0"
		},
		{
			ChatParameter.Town,
			"#A5F64E"
		}
	};

	protected Dictionary<ChatParameter, bool> m_mapChannelFilter;

	protected int Page_Msg_Number = 7;

	protected int _iStartIndex;

	protected List<ChatInfoDesc> m_arWorldMsg = new List<ChatInfoDesc>();

	protected List<ChatInfoDesc> m_arFilteredMsg = new List<ChatInfoDesc>();

	protected List<ChatParameter> m_arAvailableChannel = new List<ChatParameter>();

	protected ChatStringMaker msgMaker = new ChatStringMaker();

	protected int _iCaret;

	protected ChatParameter _curChannel = ChatParameter.BroadCast;

	protected string _whisperTartgetName = string.Empty;

	protected float _fPastTime = -1f;

	public ChatView()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = "System";
		array[1] = "BroadCast";
		array[2] = "Guild";
		array[3] = "Group";
		array[4] = "Team";
		array[5] = "Friend";
		array[6] = "Private";
		array[7] = "Town";
		selStrings = array;
		base._002Ector();
		m_mapChannelFilter = new Dictionary<ChatParameter, bool>();
		m_mapChannelName = new Dictionary<ChatParameter, string>();
		ChatParameter[] array2 = (ChatParameter[])Enum.GetValues(Type.GetTypeFromHandle(ce4808b36fbf866acf502c9056d072641.cc1720d05c75832f704b87474932341c3()));
		ChatParameter[] array3 = array2;
		foreach (ChatParameter chatParameter in array3)
		{
			m_mapChannelFilter.Add(chatParameter, true);
			m_mapChannelName.Add(chatParameter, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("ChatChannel_" + chatParameter)));
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

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		if (!_bInputing)
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
			if (!c150264a18c2cb408479d3f072cac8cc1)
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
				Event current = Event.current;
				if (current != null)
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
					if (current.isKey)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Detected key code: " + current.keyCode);
					}
				}
				string text = string.Empty;
				using (List<ChatInfoDesc>.Enumerator enumerator = m_arWorldMsg.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						text = text + enumerator.Current.m_strChatText + "\n";
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_00bd;
						}
						continue;
						end_IL_00bd:
						break;
					}
				}
				GUI.TextArea(new Rect(0f, Screen.height - 300, 300f, 160f), text);
				chatInputString = msgMaker.cacb712132910f653280e21b175dc564d();
				GUI.TextField(new Rect(50f, Screen.height - 100, 200f, 30f), chatInputString);
				if (GUI.Button(new Rect(260f, Screen.height - 100, 40f, 30f), "Send"))
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
					c275eddcb46d8b583bc15e0c52e1742d9();
				}
				selectChannel = GUI.SelectionGrid(new Rect(0f, Screen.height - 140, 300f, 30f), selectChannel, selStrings, selStrings.Length);
				if (GUI.Button(new Rect(0f, Screen.height - 100, 50f, 30f), selStrings[selectChannel]))
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
					_bChannelSel = true;
				}
				if (!_bChannelSel)
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
					GUI.Box(new Rect(0f, Screen.height - 70, 300f, 30f), string.Empty);
					int selected = -1;
					selected = GUI.SelectionGrid(new Rect(0f, Screen.height - 70, 400f, 30f), selected, selStrings, selStrings.Length);
					if (selected == -1)
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
						_bChannelSel = false;
						_curChannel = (ChatParameter)(selected + 1);
						return;
					}
				}
			}
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c3ee3ae9c8e9d7863fc24390827b6193f(this, "UIChatInput");
		c1ee7921b0c3cce194fb7cae41b5a9d82<ChatServiceWarpper>.c5ee19dc8d4cccf5ae2de225410458b86.c99ae00bed7f8b90460dead1f6df257e8(OnNetRecieveMsg);
		c1ee7921b0c3cce194fb7cae41b5a9d82<ChatServiceWarpper>.c5ee19dc8d4cccf5ae2de225410458b86.c26284ca2d02d3aa0631d68ff992ed262(OnNetRecievePrivateMsg);
		c150264a18c2cb408479d3f072cac8cc1 = true;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		ca8767fb514ddefa2b1a62df5b7b11eef();
		c150264a18c2cb408479d3f072cac8cc1 = false;
		c1ee7921b0c3cce194fb7cae41b5a9d82<ChatServiceWarpper>.c5ee19dc8d4cccf5ae2de225410458b86.cc8d3253f8397c4475d7f6d887b02c64e(OnNetRecieveMsg);
		c1ee7921b0c3cce194fb7cae41b5a9d82<ChatServiceWarpper>.c5ee19dc8d4cccf5ae2de225410458b86.cf536a49fbacf1808b502e8e454bda345(OnNetRecievePrivateMsg);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cee8cde4410c30a1ff6fab848a28cf88f(this, string.Empty);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (!_bInputing)
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
			if (_bVisible)
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
				ca8767fb514ddefa2b1a62df5b7b11eef();
				return;
			}
		}
	}

	public override bool OnShortCutCMD(string command)
	{
		if (cd0069281ff5290a7e6c484b6aed3933d)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (_bVisible)
			{
				if (!_bInputing)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							cc3b5f55e9264cc4d0f9461a25307874f();
							return true;
						}
					}
				}
				return false;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return false;
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (_bInputing)
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
					ca8767fb514ddefa2b1a62df5b7b11eef();
					return true;
				}
			}
		}
		return false;
	}

	public void c9c8e5a517b23a2b1acabe838f9baf845(object c2a9069f1b3d678bedae4d394c196f412)
	{
		cba8e8b1d8d6b9d28e478a64bad8ba328(ChatParameter.Private, (string)c2a9069f1b3d678bedae4d394c196f412);
		cc3b5f55e9264cc4d0f9461a25307874f();
	}

	public void cba8e8b1d8d6b9d28e478a64bad8ba328(ChatParameter ce3d0ae6e01f448f003f48ae05efb1578, string cc3750c889eab4922744ef9336fcb3722 = "")
	{
		StringBuilder stringBuilder = new StringBuilder();
		_curChannel = ce3d0ae6e01f448f003f48ae05efb1578;
		stringBuilder.Append("[").Append(m_mapChannelName[_curChannel]).Append("]");
		if (_curChannel == ChatParameter.Private)
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
			_whisperTartgetName = cc3750c889eab4922744ef9336fcb3722;
			stringBuilder.Append("[").Append(_whisperTartgetName).Append("]");
		}
		msgMaker.c75d58403d1e8b87c008cb98f50c8978b(stringBuilder.ToString());
		c3b80b8ee1b29b56c47b88ec0936c4142();
	}

	public virtual void cc3b5f55e9264cc4d0f9461a25307874f()
	{
		Input.imeCompositionMode = IMECompositionMode.On;
		Input.compensateSensors = true;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = false;
		msgMaker.cac7688b05e921e2be3f92479ba44b4a8();
		c3b80b8ee1b29b56c47b88ec0936c4142();
		c8786116c3ac8c450b7005e3dc50328a7();
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c1b97ddc2948f5f2e08c0dcd77acaddcd, true);
		_bInputing = true;
		cb34e7e8b8d8ae36f950f231011c2ab5e();
	}

	public virtual void ca8767fb514ddefa2b1a62df5b7b11eef()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c1b97ddc2948f5f2e08c0dcd77acaddcd);
		Input.imeCompositionMode = IMECompositionMode.Off;
		Input.compensateSensors = false;
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
		msgMaker.cac7688b05e921e2be3f92479ba44b4a8();
		c3b80b8ee1b29b56c47b88ec0936c4142();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
		_bInputing = false;
		c63564fabd37c68447164a1c452ad80d1();
	}

	protected void c63564fabd37c68447164a1c452ad80d1()
	{
		if (_fPastTime < 0f)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c95c5989df2b6f69277d0abe0e1741bdf);
		}
		_fPastTime = 0f;
	}

	protected void cb34e7e8b8d8ae36f950f231011c2ab5e()
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c95c5989df2b6f69277d0abe0e1741bdf);
		_fPastTime = -1f;
	}

	protected void c95c5989df2b6f69277d0abe0e1741bdf()
	{
		_fPastTime += Time.deltaTime;
		if (!(_fPastTime > 60f))
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
			cb34e7e8b8d8ae36f950f231011c2ab5e();
			c7d76cbe7f1cefed1f414370da3e418b5();
			return;
		}
	}

	public void OnNetRecieveMsg(byte chatType, int senderID, string senderNickname, string content, byte[] attachedobject)
	{
		cdf1b518a606ae8fae32a93c7d3abd6b2((ChatParameter)chatType, senderNickname, content, senderID, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409());
	}

	public void OnNetRecievePrivateMsg(byte chatType, int recieverID, string recieverNickname, string content, byte[] attachedobject)
	{
		cdf1b518a606ae8fae32a93c7d3abd6b2((ChatParameter)chatType, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409(), content, recieverID, recieverNickname);
	}

	public void cdf1b518a606ae8fae32a93c7d3abd6b2(ChatParameter c60cae76d65f1a4f1b2b01da404f738b0, string c701820ade327991c09c4c036b8dd1b57, string cac6acc699e99fa6f8302aa6d30b3c3a9, int ceb1333ab49cbd7040724abe30790518c, string c1f7a5cbc1069c99767146e1d6cc7aa09 = "")
	{
		ChatInfoDesc item = cd640fe2cf3b6ec2c4b518a477a7693c6(c60cae76d65f1a4f1b2b01da404f738b0, c701820ade327991c09c4c036b8dd1b57, cac6acc699e99fa6f8302aa6d30b3c3a9, ceb1333ab49cbd7040724abe30790518c, c60cae76d65f1a4f1b2b01da404f738b0 == ChatParameter.Private, c1f7a5cbc1069c99767146e1d6cc7aa09);
		m_arWorldMsg.Add(item);
		if (m_arWorldMsg.Count > 2048)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_arWorldMsg.RemoveRange(0, m_arWorldMsg.Count - 2048);
		}
		if (!m_mapChannelFilter[c60cae76d65f1a4f1b2b01da404f738b0])
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
			int num = Math.Max(m_arFilteredMsg.Count - 1, 0);
			m_arFilteredMsg.Add(item);
			if (_iStartIndex == num)
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
				_iStartIndex = Math.Max(m_arFilteredMsg.Count - 1, 0);
			}
			c8786116c3ac8c450b7005e3dc50328a7();
			c4649e2e5bddc2221506fb8dd60ed93a1();
			if (_bInputing)
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
				c63564fabd37c68447164a1c452ad80d1();
				return;
			}
		}
	}

	protected ChatInfoDesc[] cd00e1903b32505c3da3dc5878f07e7ce()
	{
		int num = _iStartIndex + 1;
		if (num > Page_Msg_Number)
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
			num = Page_Msg_Number;
		}
		return m_arFilteredMsg.GetRange(_iStartIndex + 1 - num, num).ToArray();
	}

	protected void c1f66b207e09a1af64457df9d1c70dee6(int c72943404493c5c9abc349e4b65bfe91b)
	{
	}

	public void c85d6545b87129c60c9164fb2179eb5c2(ChatParameter[] cbbf6a50cf64ad859e4e83fe948579fd0)
	{
		m_arAvailableChannel.Clear();
		m_arAvailableChannel.AddRange(cbbf6a50cf64ad859e4e83fe948579fd0);
	}

	public void c6055d259a42afc6a9407f1ffaaac3386(ChatParameter[] cbbf6a50cf64ad859e4e83fe948579fd0)
	{
		ChatParameter[] array = (ChatParameter[])Enum.GetValues(Type.GetTypeFromHandle(ce4808b36fbf866acf502c9056d072641.cc1720d05c75832f704b87474932341c3()));
		ChatParameter[] array2 = array;
		foreach (ChatParameter key in array2)
		{
			m_mapChannelFilter[key] = false;
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
			foreach (ChatParameter key2 in cbbf6a50cf64ad859e4e83fe948579fd0)
			{
				m_mapChannelFilter[key2] = true;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_arFilteredMsg.Clear();
				using (List<ChatInfoDesc>.Enumerator enumerator = m_arWorldMsg.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ChatInfoDesc current = enumerator.Current;
						if (!m_mapChannelFilter[current.m_iType])
						{
							continue;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						m_arFilteredMsg.Add(current);
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_00e3;
						}
						continue;
						end_IL_00e3:
						break;
					}
				}
				_iStartIndex = m_arFilteredMsg.Count - 1;
				c4649e2e5bddc2221506fb8dd60ed93a1();
				return;
			}
		}
	}

	protected void c32d147ad9fda59ba8e19605067b8ac74(Vector2 cef9712200bbe2c3873eec3ca2e18a595)
	{
		List<MenuItemDef> list = new List<MenuItemDef>();
		using (List<ChatParameter>.Enumerator enumerator = m_arAvailableChannel.GetEnumerator())
		{
			MenuItemDef item = default(MenuItemDef);
			while (enumerator.MoveNext())
			{
				ChatParameter current = enumerator.Current;
				if (current == ChatParameter.System)
				{
					continue;
				}
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
				if (current == ChatParameter.Private)
				{
					continue;
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
				item.itemTitle = m_mapChannelName[current];
				item.itemData = current;
				item.itemFunc = c24c185c21291c318e36e45d03dd83d37;
				if (current == ChatParameter.Group)
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
					if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
						item.itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
					}
				}
				else if (current == ChatParameter.Guild)
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
					if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd19cb80dca29b5c813acffe07d4eb050())
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
						item.itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
					}
				}
				list.Add(item);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0102;
				}
				continue;
				end_IL_0102:
				break;
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(list.ToArray(), cef9712200bbe2c3873eec3ca2e18a595);
	}

	protected void c24c185c21291c318e36e45d03dd83d37(object cb54d348399fa4dd469e1db15f7b72412)
	{
		cba8e8b1d8d6b9d28e478a64bad8ba328((ChatParameter)(byte)cb54d348399fa4dd469e1db15f7b72412, string.Empty);
	}

	protected virtual void c4649e2e5bddc2221506fb8dd60ed93a1()
	{
	}

	protected virtual void c3b80b8ee1b29b56c47b88ec0936c4142()
	{
	}

	protected virtual void c7d76cbe7f1cefed1f414370da3e418b5()
	{
	}

	protected virtual void c8786116c3ac8c450b7005e3dc50328a7()
	{
	}

	protected void c275eddcb46d8b583bc15e0c52e1742d9()
	{
		string text = msgMaker.cc4110c4a5820d26a32d025fd117df81a().Trim();
		if (text != string.Empty)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			byte[] c869de72ad8783f7d8dd3eff78f110bae = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(1);
			ChatServiceWarpper c5ee19dc8d4cccf5ae2de225410458b = c1ee7921b0c3cce194fb7cae41b5a9d82<ChatServiceWarpper>.c5ee19dc8d4cccf5ae2de225410458b86;
			OnChat c2db84530ef366a6deb001d449d4aa = c1f66b207e09a1af64457df9d1c70dee6;
			ChatParameter curChannel = _curChannel;
			string c76759d33b9cb2580a3b145e1ba;
			if (_curChannel == ChatParameter.Private)
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
				c76759d33b9cb2580a3b145e1ba = _whisperTartgetName;
			}
			else
			{
				c76759d33b9cb2580a3b145e1ba = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
			}
			c5ee19dc8d4cccf5ae2de225410458b.cb8dcf26100ed296de16c03054668e4a3(c2db84530ef366a6deb001d449d4aa, (byte)curChannel, 0, c76759d33b9cb2580a3b145e1ba, msgMaker.cc4110c4a5820d26a32d025fd117df81a(), c869de72ad8783f7d8dd3eff78f110bae);
		}
		ca8767fb514ddefa2b1a62df5b7b11eef();
	}

	protected ChatInfoDesc cd640fe2cf3b6ec2c4b518a477a7693c6(ChatParameter c60cae76d65f1a4f1b2b01da404f738b0, string c701820ade327991c09c4c036b8dd1b57, string cac6acc699e99fa6f8302aa6d30b3c3a9, int c717dab0494f3f0f159b8bd8bc7c8b729, bool c268c9c084873272dd5d019cfb153f523, string c1f7a5cbc1069c99767146e1d6cc7aa09 = "")
	{
		string empty = string.Empty;
		ChatInfoDesc result = default(ChatInfoDesc);
		result.m_iType = c60cae76d65f1a4f1b2b01da404f738b0;
		result.m_strUserName = c701820ade327991c09c4c036b8dd1b57;
		result.m_strContent = cac6acc699e99fa6f8302aa6d30b3c3a9;
		result.m_ID = c717dab0494f3f0f159b8bd8bc7c8b729;
		if (c268c9c084873272dd5d019cfb153f523)
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
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "[";
			array[1] = result.m_strUserName;
			array[2] = "] to [";
			array[3] = c1f7a5cbc1069c99767146e1d6cc7aa09;
			array[4] = "]:";
			empty = string.Concat(array);
		}
		else
		{
			string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array2[0] = "[";
			array2[1] = m_mapChannelName[c60cae76d65f1a4f1b2b01da404f738b0];
			array2[2] = "][";
			array2[3] = result.m_strUserName;
			array2[4] = "]:";
			empty = string.Concat(array2);
		}
		empty += result.m_strContent;
		string[] array3 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
		array3[0] = "<color='";
		array3[1] = m_mapChannelColor[result.m_iType];
		array3[2] = "'>";
		array3[3] = empty;
		array3[4] = "</color>";
		empty = string.Concat(array3);
		result.m_strChatText = empty;
		return result;
	}

	protected void c1b97ddc2948f5f2e08c0dcd77acaddcd()
	{
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Return))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c275eddcb46d8b583bc15e0c52e1742d9();
		}
		else if (Input.inputString.Length > 0)
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
			if (Input.inputString == "\b")
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
				msgMaker.c2f60e15b853088b328c7029c944d4176(_iCaret - 1);
				_iCaret = msgMaker.c63717d634de6b4a849edf089c8403f89(_iCaret - 1);
				flag = true;
			}
			else if (Input.inputString == "\n")
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
			}
			else if (Input.inputString == "\r")
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
			}
			else
			{
				msgMaker.c9d07e0a52df67b746698e11beb235411(_iCaret, Input.inputString);
				_iCaret = msgMaker.c63717d634de6b4a849edf089c8403f89(_iCaret + Input.inputString.Length);
				flag = true;
			}
		}
		if (!flag)
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
			c3b80b8ee1b29b56c47b88ec0936c4142();
			return;
		}
	}
}
