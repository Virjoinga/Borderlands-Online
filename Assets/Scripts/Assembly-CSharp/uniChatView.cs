using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class uniChatView : ChatView
{
	public class ChatPanel : c196099a1254db61d3be10d70e14e7422
	{
		public const int CHANNEL_BUTTON_NUMBER = 6;

		protected MovieClip mcContent;

		protected MovieClip mcContentRoot;

		protected cf7ac05203029a27299d6893b2dbaee2e mcScrollingBar;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcLastBtn;

		protected UnityTextField tfContent;

		protected UnityTextField tfInputer;

		protected MovieClip mcInputer;

		protected MovieClip mcInputRoot;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcSendBtn;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcChannelBtn;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcSettingBtn;

		protected c6425d3761c85e65e3530cc19d085d446[] _arrChanelBtn = c67757306f9d6b6a8778a67ebe6597c57.c0a0cdf4a196914163f7334d9b0781a04(6);

		public string[] _arrChannelNames;

		protected bool _contentVisible;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024mapC;

		public bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible;
			}
			set
			{
				if (value)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							c0159867dc6869bb2ec205ab748ad6afb();
							return;
						}
					}
				}
				c09fd41a9b5ba9b6addeaef436867b943();
			}
		}

		public bool c27b8b8f2b26d9420fc1ac46dcae468c9
		{
			get
			{
				return mcInputer.isPlaying;
			}
		}

		public int c0d6ba2588dcead7778a2143c0f8c0f8f
		{
			get
			{
				if (mcScrollingBar != null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return mcScrollingBar.cef9712200bbe2c3873eec3ca2e18a595;
						}
					}
				}
				return 0;
			}
			set
			{
				if (mcScrollingBar == null)
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
					mcScrollingBar.cef9712200bbe2c3873eec3ca2e18a595 = value;
					return;
				}
			}
		}

		public void cb4fdf404ad4c5901b7f844eddd42baf6()
		{
			if (mcContent == null)
			{
				return;
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
				if (_contentVisible)
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
					mcContent.visible = true;
					mcContent.gotoAndPlay("fadein");
					_contentVisible = true;
					return;
				}
			}
		}

		public void c9242063b905b70b12fe762c4b0caaffe()
		{
			if (mcContent == null)
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
				if (!_contentVisible)
				{
					return;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					mcContent.gotoAndPlay("fadeout");
					_contentVisible = false;
					return;
				}
			}
		}

		public void cd37123e5a08bfe5db060a104d2820695()
		{
			if (mcInputer == null)
			{
				return;
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
				mcInputer.visible = true;
				mcInputer.gotoAndPlay("fadein");
				return;
			}
		}

		public void ccbe35b1f3e84e2410eb5c72c51f39ffc()
		{
			if (mcInputer == null)
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
				mcInputer.gotoAndPlay("fadeout");
				return;
			}
		}

		public void c83fd9531fb9d6f390537577c00f19b22(string c094a4a1a0156e95bfac75eed5f525426, int c0b680ff36836999984a8ab6039b533bd = 0)
		{
			if (tfInputer == null)
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
				tfInputer.text = c094a4a1a0156e95bfac75eed5f525426;
				return;
			}
		}

		public void cf382d7cc348c9e607dbab0a1fc0974b3(string c094a4a1a0156e95bfac75eed5f525426)
		{
			if (tfContent == null)
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
				tfContent.text = c094a4a1a0156e95bfac75eed5f525426;
				return;
			}
		}

		public Vector2 ce87dd9e2e97ba5f7d9d6b177fa360deb()
		{
			return ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c46e387bea9111b07d3d0e2e52548626c(mcChannelBtn.c89ef242f4744e0f1c4ffea4da8b79bc1, new Vector2(mcChannelBtn.c89ef242f4744e0f1c4ffea4da8b79bc1.x, mcChannelBtn.c89ef242f4744e0f1c4ffea4da8b79bc1.y));
		}

		public void c9c876240e83ef8739ae888652ffe8f22(int cf512520c53a47d360d189f1963c2a5b2, int c1a0139d78d4b74044f06b4e676dcc511, int c8cc109d7daf35ef5b180de3c5ac6de20, int cef9712200bbe2c3873eec3ca2e18a595)
		{
			if (mcScrollingBar == null)
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
				mcScrollingBar.c5a7d812d0a8e674b21eb0ed8824a2f59(cf512520c53a47d360d189f1963c2a5b2, c1a0139d78d4b74044f06b4e676dcc511, c8cc109d7daf35ef5b180de3c5ac6de20, 1);
				mcScrollingBar.cef9712200bbe2c3873eec3ca2e18a595 = cef9712200bbe2c3873eec3ca2e18a595;
				return;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcContent.visible = _contentVisible;
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024mapC == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(15);
					dictionary.Add("mcChanelBtn0", 0);
					dictionary.Add("mcChanelBtn1", 0);
					dictionary.Add("mcChanelBtn2", 0);
					dictionary.Add("mcChanelBtn3", 0);
					dictionary.Add("mcChanelBtn4", 0);
					dictionary.Add("mcChanelBtn5", 0);
					dictionary.Add("mcInputer", 1);
					dictionary.Add("mcInputRoot", 2);
					dictionary.Add("mcContent", 3);
					dictionary.Add("mcContentRoot", 4);
					dictionary.Add("mcChannelBtn", 5);
					dictionary.Add("mcSendBtn", 6);
					dictionary.Add("mcLastBtn", 7);
					dictionary.Add("mcScrollingBar", 8);
					dictionary.Add("mcSettingBtn", 9);
					_003C_003Ef__switch_0024mapC = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024mapC.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
					{
						int num = Convert.ToInt32(movieClip.name.Substring(movieClip.name.Length - 1, 1));
						_arrChanelBtn[num] = new c6425d3761c85e65e3530cc19d085d446();
						_arrChanelBtn[num].c130648b59a0c8debea60aa153f844879(movieClip);
						_arrChanelBtn[num].ce84b930a12a1d06512c79320b3f0d3f4 = false;
						_arrChanelBtn[num].cec024da8c099380cfe1334bfe4c8f30f = "chatChannel";
						_arrChanelBtn[num].c591d56a94543e3559945c497f37126c4 = num;
						_arrChanelBtn[num].c9c364a8fd1f013589fea518a3924e711 = num == 0;
						_arrChanelBtn[num].c150264a18c2cb408479d3f072cac8cc1 = num < 6;
						_arrChanelBtn[num].addEventListener(MouseEvent.CLICK, c8258b6a3f3565886ee6a2cf0c434b272);
						if (_arrChannelNames != null)
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
							_arrChanelBtn[num].cf798cedf450c3ad2a08ce2d2fd00d464 = _arrChannelNames[num];
						}
						result = true;
						break;
					}
					case 1:
						mcInputer = movieClip;
						mcInputer.addFrameScript("end", c1a8a5357baa03eacf7b0a3123daf5911);
						mcInputer.gotoAndStop("end");
						mcInputer.visible = false;
						result = false;
						break;
					case 2:
						mcInputRoot = movieClip;
						tfInputer = mcInputRoot.getChildByName<UnityTextField>("tfInputer");
						if (tfInputer != null)
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
							tfInputer.text = string.Empty;
						}
						result = false;
						break;
					case 3:
						mcContent = movieClip;
						mcContent.visible = false;
						mcContent.addFrameScript("end", c1a8a5357baa03eacf7b0a3123daf5911);
						mcContent.gotoAndStop("end");
						result = false;
						break;
					case 4:
						mcContentRoot = movieClip;
						tfContent = mcContentRoot.getChildByName<UnityTextField>("tfContent");
						if (tfContent != null)
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
							tfContent.text = string.Empty;
						}
						result = false;
						break;
					case 5:
						mcChannelBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcChannelBtn.c130648b59a0c8debea60aa153f844879(movieClip);
						mcChannelBtn.c591d56a94543e3559945c497f37126c4 = "SendChannel";
						mcChannelBtn.addEventListener(MouseEvent.CLICK, cf5c4f462989b77416f4433e1c6b301d2);
						result = true;
						break;
					case 6:
						mcSendBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcSendBtn.c130648b59a0c8debea60aa153f844879(movieClip);
						mcSendBtn.c591d56a94543e3559945c497f37126c4 = "Send";
						mcSendBtn.addEventListener(MouseEvent.CLICK, cf5c4f462989b77416f4433e1c6b301d2);
						result = true;
						break;
					case 7:
						mcLastBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcLastBtn.c130648b59a0c8debea60aa153f844879(movieClip);
						mcLastBtn.c591d56a94543e3559945c497f37126c4 = "GotoLast";
						mcLastBtn.addEventListener(MouseEvent.CLICK, cf5c4f462989b77416f4433e1c6b301d2);
						result = true;
						break;
					case 8:
						mcScrollingBar = new cf7ac05203029a27299d6893b2dbaee2e();
						mcScrollingBar.c130648b59a0c8debea60aa153f844879(movieClip);
						mcScrollingBar.addEventListener("Scrolling", c572d9b4e8efb42e6d51f963c7d7b81e9);
						result = true;
						break;
					case 9:
						mcSettingBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcSettingBtn.c130648b59a0c8debea60aa153f844879(movieClip);
						mcSettingBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						result = true;
						break;
					}
				}
			}
			return result;
		}

		protected void c572d9b4e8efb42e6d51f963c7d7b81e9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(c3d202dee321219a80026dc3081fb3c86);
		}

		protected void c8258b6a3f3565886ee6a2cf0c434b272(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c3d202dee321219a80026dc3081fb3c86.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
				if (c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4 == null)
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
					dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("Channel" + c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4.ToString(), c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4));
					return;
				}
			}
		}

		protected void cf5c4f462989b77416f4433e1c6b301d2(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c3d202dee321219a80026dc3081fb3c86.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
				if (c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4 == null)
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
					dispatchEvent(new CEvent(c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4.ToString()));
					return;
				}
			}
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			(c3d202dee321219a80026dc3081fb3c86.currentTarget as MovieClip).visible = false;
		}
	}

	protected ChatPanel m_ChatPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("ChatSystem.swf", "Panel_ChatAll", cdade65fca9368f860759e1ba47026648);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		if (m_ChatPanel != null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_ChatPanel);
		}
		m_ChatPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("ChatSystem.swf");
	}

	public override void cc3b5f55e9264cc4d0f9461a25307874f()
	{
		if (m_ChatPanel == null)
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
			if (m_ChatPanel.c27b8b8f2b26d9420fc1ac46dcae468c9)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			base.cc3b5f55e9264cc4d0f9461a25307874f();
			m_ChatPanel.cd37123e5a08bfe5db060a104d2820695();
			return;
		}
	}

	public override void ca8767fb514ddefa2b1a62df5b7b11eef()
	{
		base.ca8767fb514ddefa2b1a62df5b7b11eef();
		if (m_ChatPanel == null)
		{
			return;
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
			m_ChatPanel.c83fd9531fb9d6f390537577c00f19b22(string.Empty);
			m_ChatPanel.ccbe35b1f3e84e2410eb5c72c51f39ffc();
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (m_ChatPanel == null)
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
			m_ChatPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _bVisible;
			return;
		}
	}

	private void cdade65fca9368f860759e1ba47026648(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_ChatPanel = new ChatPanel();
		m_ChatPanel._arrChannelNames = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
		m_ChatPanel._arrChannelNames[0] = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("ChatChannel_All"));
		m_ChatPanel.addEventListener("Channel0", c0c63cdc5307131292ab252ca7067426f);
		int num = 1;
		using (List<ChatParameter>.Enumerator enumerator = m_arAvailableChannel.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ChatParameter current = enumerator.Current;
				if (num >= 6)
				{
					continue;
				}
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
				m_ChatPanel._arrChannelNames[num] = m_mapChannelName[current];
				m_ChatPanel.addEventListener("Channel" + num, c707e00c3bc2cad9871a3213367d426d5);
				num++;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00e7;
				}
				continue;
				end_IL_00e7:
				break;
			}
		}
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.stopAll();
		m_ChatPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c7d5a91af372c5abe00435cdf71f886ad(m_ChatPanel);
		c3e69d2a402b0b50cfb9ca0e2f0a8b337();
		m_ChatPanel.addEventListener("Send", cd67df37d3c0b5dea6d90f8459ba197a0);
		m_ChatPanel.addEventListener("SendChannel", c61edf39506fa72d9f4153284f350becb);
		m_ChatPanel.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
		m_ChatPanel.addEventListener("GotoLast", c6ccac3db79443133339177dc70f533e2);
	}

	protected void c0c63cdc5307131292ab252ca7067426f(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		ChatParameter[] cbbf6a50cf64ad859e4e83fe948579fd = m_arAvailableChannel.ToArray();
		c6055d259a42afc6a9407f1ffaaac3386(cbbf6a50cf64ad859e4e83fe948579fd);
	}

	protected void c707e00c3bc2cad9871a3213367d426d5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
		{
			return;
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
			int num = (int)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
			ChatParameter[] array = c00dae1e31bd474cae9f1d0b21051ce58.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = m_arAvailableChannel[num - 1];
			ChatParameter[] cbbf6a50cf64ad859e4e83fe948579fd = array;
			c6055d259a42afc6a9407f1ffaaac3386(cbbf6a50cf64ad859e4e83fe948579fd);
			return;
		}
	}

	protected void cd67df37d3c0b5dea6d90f8459ba197a0(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c275eddcb46d8b583bc15e0c52e1742d9();
	}

	protected void c61edf39506fa72d9f4153284f350becb(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c32d147ad9fda59ba8e19605067b8ac74(m_ChatPanel.ce87dd9e2e97ba5f7d9d6b177fa360deb());
	}

	protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_iStartIndex = m_ChatPanel.c0d6ba2588dcead7778a2143c0f8c0f8f;
		c81c5d6b14c8e013e2370c0ca02db4d35();
	}

	protected void c6ccac3db79443133339177dc70f533e2(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		m_ChatPanel.c0d6ba2588dcead7778a2143c0f8c0f8f = m_arFilteredMsg.Count - 1;
	}

	protected override void c4649e2e5bddc2221506fb8dd60ed93a1()
	{
		c3e69d2a402b0b50cfb9ca0e2f0a8b337();
	}

	protected void c81c5d6b14c8e013e2370c0ca02db4d35()
	{
		if (m_ChatPanel == null)
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
			string text = string.Empty;
			ChatInfoDesc[] array = cd00e1903b32505c3da3dc5878f07e7ce();
			ChatInfoDesc[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				ChatInfoDesc chatInfoDesc = array2[i];
				text = text + chatInfoDesc.m_strChatText + "\n";
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				m_ChatPanel.cf382d7cc348c9e607dbab0a1fc0974b3(text);
				return;
			}
		}
	}

	protected void c3e69d2a402b0b50cfb9ca0e2f0a8b337()
	{
		if (m_ChatPanel == null)
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
			m_ChatPanel.c9c876240e83ef8739ae888652ffe8f22(Page_Msg_Number, Math.Min(Page_Msg_Number - 1, m_arFilteredMsg.Count - 1), m_arFilteredMsg.Count - 1, _iStartIndex);
			return;
		}
	}

	protected override void c3b80b8ee1b29b56c47b88ec0936c4142()
	{
		if (m_ChatPanel == null)
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
			m_ChatPanel.c83fd9531fb9d6f390537577c00f19b22(msgMaker.cacb712132910f653280e21b175dc564d());
			return;
		}
	}

	protected override void c7d76cbe7f1cefed1f414370da3e418b5()
	{
		if (m_ChatPanel == null)
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
			m_ChatPanel.c9242063b905b70b12fe762c4b0caaffe();
			return;
		}
	}

	protected override void c8786116c3ac8c450b7005e3dc50328a7()
	{
		if (m_ChatPanel == null)
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
			m_ChatPanel.cb4fdf404ad4c5901b7f844eddd42baf6();
			return;
		}
	}
}
