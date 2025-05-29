using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniGuildSearchView : GuildSearchView
{
	private class GuildSearchPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private MovieClip mc_Total;

		private c6425d3761c85e65e3530cc19d085d446 mc_SearchPanelButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_MessagePanelButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CloseButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_SearchButton;

		private MovieClip mc_GuildList;

		private MovieClip mc_GuildMessageList;

		private string GUILD_SLOT_PREFIX_NAME = "itemguild";

		private string GUILD_MSG_SLOT_PREFIX_NAME = "itemMessage";

		private int GUILD_TOTAL = 14;

		private int GUILD_MESSAGE_TOTAL = 16;

		protected c5f20d8133b251cada9ed97eadee6ed58[] _guildButtons;

		protected c9c62cee2f3d16c454655494828af5dc6[] _guildMessageButtons;

		private c6425d3761c85e65e3530cc19d085d446 mc_QuestCheck;

		private c6425d3761c85e65e3530cc19d085d446 mc_PvECheck;

		private c6425d3761c85e65e3530cc19d085d446 mc_PvPCheck;

		private c6425d3761c85e65e3530cc19d085d446 mc_SocialCheck;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_LeftButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_RightButton;

		private TextField tf_GuildRemain;

		private int m_Flag;

		private int m_nOffset = 14;

		private int m_nSearchStep = 1;

		private GuildPreference m_LastPreference = GuildPreference.All;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return mc_root.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mc_root == null)
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
					GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cf10dc670a45bb0104e6966f4a2b2d3e9();
					if (value)
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
						m_Flag = 0;
						m_LastPreference = GuildPreference.All;
						mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						mc_QuestCheck.c9c364a8fd1f013589fea518a3924e711 = true;
						mc_PvECheck.c9c364a8fd1f013589fea518a3924e711 = true;
						mc_PvPCheck.c9c364a8fd1f013589fea518a3924e711 = true;
						mc_SocialCheck.c9c364a8fd1f013589fea518a3924e711 = true;
						mc_SearchButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
						c0159867dc6869bb2ec205ab748ad6afb();
						mc_SearchPanelButton.c9c364a8fd1f013589fea518a3924e711 = true;
						mc_GuildList.visible = true;
						mc_GuildMessageList.visible = false;
					}
					else
					{
						c09fd41a9b5ba9b6addeaef436867b943();
					}
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		public GuildSearchPanel()
		{
			_guildButtons = c62d89bf472bcfcf201fc570d295f3b7f.c0a0cdf4a196914163f7334d9b0781a04(GUILD_TOTAL);
			_guildMessageButtons = c83b9026f94117d8baf7c1954126c5fe4.c0a0cdf4a196914163f7334d9b0781a04(GUILD_MESSAGE_TOTAL);
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: GuildSearchPanel onInit() 'mc_root' is null! GuildSearchPanel won't work!!!");
						return;
					}
				}
			}
			mc_root.visible = false;
			mc_root.stopAll();
			mc_Total = mc_root.getChildByName<MovieClip>("mc_root");
			mc_GuildList = mc_Total.getChildByName<MovieClip>("mc_search");
			mc_GuildMessageList = mc_Total.getChildByName<MovieClip>("mc_record");
			mc_SearchPanelButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_SearchPanelButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_search_btn"));
			mc_SearchPanelButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, caea0cd498b4d31ea9cc88930b168ecbb);
			mc_SearchPanelButton.cec024da8c099380cfe1334bfe4c8f30f = "GuildPanel";
			mc_SearchPanelButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_MessagePanelButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_MessagePanelButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_invitation"));
			mc_MessagePanelButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c5dec5c7b3535b8e389694c4561a6485d);
			mc_MessagePanelButton.cec024da8c099380cfe1334bfe4c8f30f = "GuildPanel";
			mc_MessagePanelButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_CloseButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CloseButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mcBtnClose"));
			mc_CloseButton.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
			mc_SearchButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_SearchButton.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mc_searchBtn"));
			mc_SearchButton.addEventListener(MouseEvent.CLICK, c11c68ed6005142f1a88e12a7edccbd74);
			mc_GuildList.visible = true;
			mc_GuildMessageList.visible = false;
			mc_QuestCheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_QuestCheck.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mcQuestCheck"));
			mc_QuestCheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_QuestCheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_QuestCheck.cec024da8c099380cfe1334bfe4c8f30f = "quest";
			mc_QuestCheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_PvECheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_PvECheck.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mcPvECheck"));
			mc_PvECheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_PvECheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_PvECheck.cec024da8c099380cfe1334bfe4c8f30f = "pve";
			mc_PvECheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_PvPCheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_PvPCheck.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mcPvPCheck"));
			mc_PvPCheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_PvPCheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_PvPCheck.cec024da8c099380cfe1334bfe4c8f30f = "pvp";
			mc_PvPCheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_SocialCheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_SocialCheck.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mcSocialCheck"));
			mc_SocialCheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_SocialCheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_SocialCheck.cec024da8c099380cfe1334bfe4c8f30f = "social";
			mc_SocialCheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_LeftButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_LeftButton.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mc_Left"));
			mc_LeftButton.addEventListener(MouseEvent.CLICK, c32f6a067cde60a62886219ee3c9e4725);
			mc_RightButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_RightButton.c130648b59a0c8debea60aa153f844879(mc_GuildList.getChildByName<MovieClip>("mc_Right"));
			mc_RightButton.addEventListener(MouseEvent.CLICK, cfdae5ecc2e0c4437e4a2bf2e976362d3);
			tf_GuildRemain = mc_GuildMessageList.getChildByName<TextField>("tf_guildRemain");
			tf_GuildRemain.text = string.Empty;
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(GUILD_SLOT_PREFIX_NAME))
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
				int num = Convert.ToInt32(movieClip.name.Substring(GUILD_SLOT_PREFIX_NAME.Length, movieClip.name.Length - GUILD_SLOT_PREFIX_NAME.Length));
				if (num < _guildButtons.Length)
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
					if (num >= 0)
					{
						c5f20d8133b251cada9ed97eadee6ed58 c5f20d8133b251cada9ed97eadee6ed = new c5f20d8133b251cada9ed97eadee6ed58();
						c5f20d8133b251cada9ed97eadee6ed.c130648b59a0c8debea60aa153f844879(movieClip);
						_guildButtons[num] = c5f20d8133b251cada9ed97eadee6ed;
						goto IL_00e8;
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
				}
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "Guild itemSlot name wrong! Index:";
				array[1] = num;
				array[2] = " is bigger than sum: ";
				array[3] = _guildButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
				return true;
			}
			goto IL_00e8;
			IL_00e8:
			if (movieClip.name.StartsWith(GUILD_MSG_SLOT_PREFIX_NAME))
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
				int num2 = Convert.ToInt32(movieClip.name.Substring(GUILD_MSG_SLOT_PREFIX_NAME.Length, movieClip.name.Length - GUILD_MSG_SLOT_PREFIX_NAME.Length));
				if (num2 < _guildMessageButtons.Length)
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
					if (num2 >= 0)
					{
						c9c62cee2f3d16c454655494828af5dc6 c9c62cee2f3d16c454655494828af5dc = new c9c62cee2f3d16c454655494828af5dc6();
						c9c62cee2f3d16c454655494828af5dc.c130648b59a0c8debea60aa153f844879(movieClip);
						_guildMessageButtons[num2] = c9c62cee2f3d16c454655494828af5dc;
						goto IL_01c7;
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
				}
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = "Guild message itemSlot name wrong! Index:";
				array2[1] = num2;
				array2[2] = " is bigger than sum: ";
				array2[3] = _guildMessageButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array2));
				return true;
			}
			goto IL_01c7;
			IL_01c7:
			return false;
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mc_root.visible = true;
			mc_root.gotoAndPlay("DetailAppear");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			mc_root.gotoAndPlay("KeyFrame_2");
			mc_root.addFrameScript("KeyFrame_3", c1a8a5357baa03eacf7b0a3123daf5911);
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeEventListener("KeyFrame_3", c1a8a5357baa03eacf7b0a3123daf5911);
			mc_root.visible = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}

		private void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		private void c11c68ed6005142f1a88e12a7edccbd74(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			GuildPreference guildPreference = c6a5ddf484d828b6ffe7e3c26f1eae05e();
			m_Flag = 0;
			mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			m_LastPreference = guildPreference;
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6f90e917c845ddd5202db36d56473e6(guildPreference, m_nOffset);
		}

		private void c32f6a067cde60a62886219ee3c9e4725(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			m_Flag = -1;
			mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			if (m_nSearchStep > 1)
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
						GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6f90e917c845ddd5202db36d56473e6(m_LastPreference, (m_nSearchStep - 1) * m_nOffset);
						return;
					}
				}
			}
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6f90e917c845ddd5202db36d56473e6(m_LastPreference, m_nOffset);
		}

		private void cfdae5ecc2e0c4437e4a2bf2e976362d3(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			m_Flag = 1;
			mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6f90e917c845ddd5202db36d56473e6(m_LastPreference, (m_nSearchStep + 1) * m_nOffset);
		}

		private void caea0cd498b4d31ea9cc88930b168ecbb(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (mc_GuildList.visible)
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
					mc_GuildList.visible = true;
					mc_GuildMessageList.visible = false;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		private void c5dec5c7b3535b8e389694c4561a6485d(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
						return;
					}
				}
			}
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (mc_GuildMessageList.visible)
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
					mc_GuildList.visible = false;
					mc_GuildMessageList.visible = true;
					tf_GuildRemain.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_REMAINING")) + GuildManager.c71f6ce28731edfd43c976fbd57c57bea().ce4966e5102b8689f56a50d45f9ab777c();
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		private void ca6933d4065e842546d6e2f70775dd1d8(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			if (c6a5ddf484d828b6ffe7e3c26f1eae05e() == GuildPreference.None)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						mc_SearchButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						return;
					}
				}
			}
			mc_SearchButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
		}

		private GuildPreference c6a5ddf484d828b6ffe7e3c26f1eae05e()
		{
			GuildPreference guildPreference = GuildPreference.None;
			if (mc_QuestCheck != null)
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
				if (mc_PvECheck != null)
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
					if (mc_PvPCheck != null)
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
						if (mc_SocialCheck != null)
						{
							if (mc_QuestCheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.Quest;
							}
							if (mc_PvECheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.PvE;
							}
							if (mc_PvPCheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.PvP;
							}
							if (mc_SocialCheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.Social;
							}
							return guildPreference;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
					}
				}
			}
			return GuildPreference.All;
		}

		public void cb4e02cff1512be57edd191db2eec2b0a(int c41d8f7311845ab726afcb5975a0b304b)
		{
			if (m_Flag == 0)
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
				if (c41d8f7311845ab726afcb5975a0b304b == m_nOffset)
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
					mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				}
				m_nSearchStep = 1;
			}
			if (m_Flag == -1)
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
				if (c41d8f7311845ab726afcb5975a0b304b >= m_nOffset)
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
					mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					m_nSearchStep--;
					if (m_nSearchStep <= 1)
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
						m_nSearchStep = 1;
					}
					else
					{
						mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					}
				}
				else if (c41d8f7311845ab726afcb5975a0b304b != 0)
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
					m_nSearchStep--;
					if (m_nSearchStep <= 1)
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
						m_nSearchStep = 1;
					}
					else
					{
						mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
					}
				}
				else
				{
					m_nSearchStep = 1;
				}
			}
			if (m_Flag != 1)
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
				if (c41d8f7311845ab726afcb5975a0b304b >= m_nOffset)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_nSearchStep++;
							mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
							mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
							return;
						}
					}
				}
				if (c41d8f7311845ab726afcb5975a0b304b != 0)
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
					m_nSearchStep++;
				}
				else if (m_nSearchStep == 1)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				mc_LeftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				mc_RightButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				return;
			}
		}

		public int ce96b33ee40abc99c97f8a8ea66a99632()
		{
			return m_Flag;
		}

		public void c591c47219c2da4f480868724bfea2264(GuildSearchPart c716466036ca83f8907f5a0c81b0e432d = GuildSearchPart.e_None)
		{
			if (mc_GuildList == null)
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
				if (mc_GuildMessageList == null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (mc_GuildList.visible)
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
					int num = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c392389f80491f6afb198ca0180c79236();
					if (num > GUILD_TOTAL)
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
						num = GUILD_TOTAL;
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Guild search result is " + GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c392389f80491f6afb198ca0180c79236() + " more than " + GUILD_TOTAL);
					}
					for (int i = 0; i < num; i++)
					{
						_guildButtons[i].c263a18e823d534fe933bf797fd17c221(i);
						_guildButtons[i].c150264a18c2cb408479d3f072cac8cc1 = true;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					for (int j = num; j < GUILD_TOTAL; j++)
					{
						_guildButtons[j].c150264a18c2cb408479d3f072cac8cc1 = false;
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
				}
				if (!mc_GuildMessageList.visible)
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
					int num2 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c0f68d664365a72d62b5d68a988978557();
					for (int k = 0; k < num2; k++)
					{
						_guildMessageButtons[k].c263a18e823d534fe933bf797fd17c221(k);
						_guildMessageButtons[k].c150264a18c2cb408479d3f072cac8cc1 = true;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						for (int l = num2; l < GUILD_MESSAGE_TOTAL; l++)
						{
							_guildMessageButtons[l].c150264a18c2cb408479d3f072cac8cc1 = false;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return;
							}
						}
					}
				}
			}
		}
	}

	public class GuildTips : ca28a90236225d84ff4176d76e8446d33
	{
		protected GuildSkillData _skill;

		public static ItemTipsPanel _itemPanel;

		public GuildTips(GuildSkillData c02f15d17d3be88f612695c422dc620bd)
		{
			_skill = c02f15d17d3be88f612695c422dc620bd;
		}

		public override DisplayObject c710592d0cc98297d2151ac3095b4f412()
		{
			if (_skill == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
			}
			c8958be2e7cc65a2356b1cd729028de49();
			return _itemPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
		}

		protected void c8958be2e7cc65a2356b1cd729028de49()
		{
			if (_skill == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			string text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_SKILLID_" + _skill.m_id));
			if (_skill.m_type == "scale")
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
				float value = _skill.m_value;
				text = text + " + " + (int)((value - 1f) * 100f) + "%";
			}
			if (_skill.m_type == "postAdd")
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
				text = text + " + " + (int)_skill.m_value;
			}
			ItemTipsData itemTipsData = new ItemTipsData();
			itemTipsData.level = _skill.m_unlockLevel;
			ItemElement itemElement = new ItemElement();
			itemElement.eType = ETipsItemType.TEXT;
			itemElement.value = text;
			itemTipsData.attributeList.Add(itemElement);
			_itemPanel.c4415aa0606651420b103929644cf44bd(itemTipsData);
		}
	}

	public class GuildSkillIconSlot : ceaa621c569baf012ce466a5c368364e3
	{
		public enum GuildSkillSlotStatus
		{
			eNone = 0,
			eLock = 1,
			eUnlock = 2,
			eUpgrade = 3,
			eComplete = 4
		}

		protected MovieClip _rootMC;

		protected GuildSkillSlotStatus _slotStatus;

		protected GuildSkillData _skill;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnMouseCover;

		protected ItemTipsPanel m_Tips;

		public void c73e2661815f684ef5dd4807355ef628c(GuildSkillData c591d56a94543e3559945c497f37126c4)
		{
			_skill = c591d56a94543e3559945c497f37126c4;
			_rootMC.visible = true;
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcSkillTreeIcon");
			uniGuildSearchView uniGuildSearchView2 = (uniGuildSearchView)c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>();
			if (childByName != null)
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
				if (uniGuildSearchView2 != null)
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
					if (_skill != null)
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
						uniGuildSearchView2.c6a21327f8a1406da47c07d9ef9662d87(childByName, "Movie_Skill" + _rootMC.name.Substring(_rootMC.name.Length - 1, 1));
					}
				}
			}
			c46f083a1c6dc7b33c99f7a6787447fc3();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_rootMC.removeAllEventListeners(MouseEvent.CLICK);
			_rootMC.addEventListener(MouseEvent.CLICK, cbfe1a41acbaa3e09dabd1e800be3ad56);
			if (_btnMouseCover == null)
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
				_btnMouseCover = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			}
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcMouseCover");
			if (childByName == null)
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
				_btnMouseCover.c130648b59a0c8debea60aa153f844879(childByName);
				return;
			}
		}

		protected void cbfe1a41acbaa3e09dabd1e800be3ad56(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_slotStatus != GuildSkillSlotStatus.eUnlock)
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
				GuildManager.c71f6ce28731edfd43c976fbd57c57bea().ce626290c115689a580e2ebc12dd2526d(_skill.m_id);
				return;
			}
		}

		public void c46f083a1c6dc7b33c99f7a6787447fc3()
		{
			if (_skill == null)
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
						return;
					}
				}
			}
			if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c497b35769b9508f621afc5281220456a(_skill.m_id))
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
				if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c354e921f1ff059ad29b4691d49cd75b2(_skill.m_id))
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
					_rootMC.gotoAndStop("complete");
					_slotStatus = GuildSkillSlotStatus.eComplete;
				}
				else
				{
					_rootMC.gotoAndStop("unlock");
					_slotStatus = GuildSkillSlotStatus.eUnlock;
				}
			}
			else
			{
				_rootMC.gotoAndStop("lock");
				_slotStatus = GuildSkillSlotStatus.eLock;
			}
			_btnMouseCover.cbf402c82d0fffee7c8f37c98e456b8f8 = _slotStatus != GuildSkillSlotStatus.eLock;
		}
	}

	private class GuildManagePanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private MovieClip mc_Total;

		private c6425d3761c85e65e3530cc19d085d446 mc_MemberPanelButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_NewsPanelButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_ApplicationPanelButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_ActivityButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_SkillButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_OnlineBox;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CloseButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_ModifyButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_ResetButton;

		private MovieClip mc_GuildMemberList;

		private MovieClip mc_GuildNewsList;

		private MovieClip mc_GuildApplicationList;

		private MovieClip mc_GuildSkillList;

		private TextField tf_GuildName;

		private TextField tf_GuildLevel;

		private ccf8bd4afc86b3c33d69f65b1612538ce tf_GuildDeca;

		private TextField tf_GuildExp;

		private TextField tf_OnlineNum;

		private TextField tf_TotalNum;

		private TextField tf_SkillTips;

		private BadAssMovieClip mc_ExpBar;

		private float m_fExpWidth;

		protected cf7ac05203029a27299d6893b2dbaee2e mc_ScrollBar;

		private string GUILD_APPLICATION_PREFIX_NAME = "itemInvitation";

		private string GUILD_MEMBER_PREFIX_NAME = "elementMember";

		private string GUILD_NEWS_PREFIX_NAME = "itemNews";

		private string GUILD_SKILL_PREFIX_NAME = "mc_GuildIcon";

		private int GUILD_APPLICATION_TOTAL = 14;

		private int GUILD_MEMBER_TOTAL = 14;

		private int GUILD_NEWS_TOTAL = 14;

		private bool m_bOnlineChecked;

		protected c9542c14c996389480d707aa1968409d5[] _guildMemberButtons;

		protected cda9460eda4d73fd67f5caa5bdcdf303b[] _guildApplicationButtons;

		protected cf9493c5c15451e808a5e74c32781383a[] _guildNewsButtons;

		protected List<GuildSkillIconSlot> m_GuildSkillIconList;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return mc_root.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mc_root == null)
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
					if (value)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								c5bbf123eb3f3dea302b3e8154511ead6();
								cc5441980ac3f22768080730945fcb58e();
								mc_root.visible = true;
								mc_MemberPanelButton.c9c364a8fd1f013589fea518a3924e711 = true;
								mc_GuildMemberList.visible = true;
								mc_GuildNewsList.visible = false;
								mc_GuildApplicationList.visible = false;
								mc_GuildSkillList.visible = false;
								return;
							}
						}
					}
					tf_GuildDeca.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
					mc_root.visible = false;
					if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c47904336715d40ce61e78b89d35f292c();
						return;
					}
				}
			}
		}

		public GuildManagePanel()
		{
			_guildMemberButtons = c285f672762888ad6bbb711cd15e27000.c0a0cdf4a196914163f7334d9b0781a04(GUILD_MEMBER_TOTAL);
			_guildApplicationButtons = c67a7761e0ef6d6cb3aeabc6ba918bb58.c0a0cdf4a196914163f7334d9b0781a04(GUILD_APPLICATION_TOTAL);
			_guildNewsButtons = cc073ae67209498eb9a9c7b3f994f6acf.c0a0cdf4a196914163f7334d9b0781a04(GUILD_NEWS_TOTAL);
			m_GuildSkillIconList = new List<GuildSkillIconSlot>();
			m_GuildSkillIconList.Clear();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: GuildSearchPanel onInit() 'mc_root' is null! GuildManagePanel won't work!!!");
						return;
					}
				}
			}
			mc_root.visible = false;
			mc_Total = mc_root.getChildByName<MovieClip>("mc_total");
			mc_ExpBar = mc_Total.getChildByName<MovieClip>("mc_GuildLevel").getChildByName<BadAssMovieClip>("mc_bar");
			m_fExpWidth = mc_ExpBar.width;
			tf_GuildName = mc_Total.getChildByName<TextField>("mcGuildName");
			tf_GuildLevel = mc_Total.getChildByName<MovieClip>("mc_GuildLevel").getChildByName<TextField>("tf_level");
			tf_GuildExp = mc_Total.getChildByName<MovieClip>("mc_GuildLevel").getChildByName<TextField>("tf_Exp");
			tf_GuildDeca = new ccf8bd4afc86b3c33d69f65b1612538ce();
			tf_GuildDeca.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("TitleName").getChildByName<MovieClip>("mcsloganInput"));
			tf_GuildDeca.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			tf_GuildDeca.c275618f45ace7b211e4da85cecbb43d4 = 15;
			mc_GuildMemberList = mc_Total.getChildByName<MovieClip>("mc_MemberList");
			mc_GuildNewsList = mc_Total.getChildByName<MovieClip>("mc_NewsList");
			mc_GuildApplicationList = mc_Total.getChildByName<MovieClip>("mc_ApplicationList");
			mc_GuildSkillList = mc_Total.getChildByName<MovieClip>("mc_SkillList");
			tf_OnlineNum = mc_GuildMemberList.getChildByName<TextField>("tf_OnlineMember");
			tf_TotalNum = mc_GuildMemberList.getChildByName<TextField>("tf_AllMember");
			mc_MemberPanelButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_MemberPanelButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_member"));
			mc_MemberPanelButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c90b116ba039d51a7af2fd3d1deeb4833);
			mc_MemberPanelButton.cec024da8c099380cfe1334bfe4c8f30f = "GuildManagePanel";
			mc_MemberPanelButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_NewsPanelButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_NewsPanelButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_news"));
			mc_NewsPanelButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c3960e1969e6424f645da348a759dfdd0);
			mc_NewsPanelButton.cec024da8c099380cfe1334bfe4c8f30f = "GuildManagePanel";
			mc_NewsPanelButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_ApplicationPanelButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_ApplicationPanelButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_application"));
			mc_ApplicationPanelButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ce945ab51d1c8b45fa994a029aa8572e0);
			mc_ApplicationPanelButton.cec024da8c099380cfe1334bfe4c8f30f = "GuildManagePanel";
			mc_ApplicationPanelButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_ActivityButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_ActivityButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_activity"));
			mc_ActivityButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_SkillButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_SkillButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_skill"));
			mc_SkillButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c501f37cd056e04e72c712a17fc43f5e3);
			mc_SkillButton.cec024da8c099380cfe1334bfe4c8f30f = "GuildManagePanel";
			mc_SkillButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_CloseButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CloseButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mcBtnClose"));
			mc_CloseButton.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
			mc_ModifyButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_ModifyButton.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_Modify"));
			mc_ModifyButton.addEventListener(MouseEvent.CLICK, c43089d209950e0cb45ad46b03419f88a);
			mc_ModifyButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_ResetButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_ResetButton.c130648b59a0c8debea60aa153f844879(mc_GuildSkillList.getChildByName<MovieClip>("mc_reset"));
			mc_ResetButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_ResetButton.c150264a18c2cb408479d3f072cac8cc1 = false;
			tf_SkillTips = mc_GuildSkillList.getChildByName<TextField>("tf_Tips");
			tf_SkillTips.text = string.Empty;
			mc_GuildNewsList.visible = false;
			mc_GuildMemberList.visible = false;
			mc_GuildApplicationList.visible = false;
			mc_GuildSkillList.visible = false;
			mc_OnlineBox = new c6425d3761c85e65e3530cc19d085d446();
			mc_OnlineBox.c130648b59a0c8debea60aa153f844879(mc_GuildMemberList.getChildByName<MovieClip>("mc_onlinecheck"));
			mc_OnlineBox.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_OnlineBox.cec024da8c099380cfe1334bfe4c8f30f = "online";
			mc_OnlineBox.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c49a9bfb9ea581f9bdf563721bb73830f);
			mc_ScrollBar = new cf7ac05203029a27299d6893b2dbaee2e();
			mc_ScrollBar.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mcScrollingBar"));
			mc_ScrollBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
			mc_ScrollBar.cfcb3294d851a0336d3f3a8f2a943f2fb = (mc_ScrollBar.c9c58dff860effc1212c1afb5d14e147c = 0);
			mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(GUILD_MEMBER_TOTAL, 0, GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8362b5a3b1526fd771678993faa4c0bf() - GUILD_MEMBER_TOTAL, 1);
			mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(GUILD_MEMBER_PREFIX_NAME))
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
				int num = Convert.ToInt32(movieClip.name.Substring(GUILD_MEMBER_PREFIX_NAME.Length, movieClip.name.Length - GUILD_MEMBER_PREFIX_NAME.Length));
				if (num < _guildMemberButtons.Length)
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
					if (num >= 0)
					{
						c9542c14c996389480d707aa1968409d5 c9542c14c996389480d707aa1968409d = new c9542c14c996389480d707aa1968409d5();
						c9542c14c996389480d707aa1968409d.c130648b59a0c8debea60aa153f844879(movieClip);
						_guildMemberButtons[num] = c9542c14c996389480d707aa1968409d;
						goto IL_00e8;
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
				}
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "Guild Member itemSlot name wrong! Index:";
				array[1] = num;
				array[2] = " is bigger than sum: ";
				array[3] = _guildMemberButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
				return true;
			}
			goto IL_00e8;
			IL_00e8:
			if (movieClip.name.StartsWith(GUILD_APPLICATION_PREFIX_NAME))
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
				int num2 = Convert.ToInt32(movieClip.name.Substring(GUILD_APPLICATION_PREFIX_NAME.Length, movieClip.name.Length - GUILD_APPLICATION_PREFIX_NAME.Length));
				if (num2 < _guildApplicationButtons.Length)
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
					if (num2 >= 0)
					{
						cda9460eda4d73fd67f5caa5bdcdf303b cda9460eda4d73fd67f5caa5bdcdf303b = new cda9460eda4d73fd67f5caa5bdcdf303b();
						cda9460eda4d73fd67f5caa5bdcdf303b.c130648b59a0c8debea60aa153f844879(movieClip);
						_guildApplicationButtons[num2] = cda9460eda4d73fd67f5caa5bdcdf303b;
						goto IL_01c7;
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
				}
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = "Guild application itemSlot name wrong! Index:";
				array2[1] = num2;
				array2[2] = " is bigger than sum: ";
				array2[3] = _guildApplicationButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array2));
				return true;
			}
			goto IL_01c7;
			IL_01c7:
			if (movieClip.name.StartsWith(GUILD_NEWS_PREFIX_NAME))
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
				int num3 = Convert.ToInt32(movieClip.name.Substring(GUILD_NEWS_PREFIX_NAME.Length, movieClip.name.Length - GUILD_NEWS_PREFIX_NAME.Length));
				if (num3 < _guildNewsButtons.Length)
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
					if (num3 >= 0)
					{
						cf9493c5c15451e808a5e74c32781383a cf9493c5c15451e808a5e74c32781383a = new cf9493c5c15451e808a5e74c32781383a();
						cf9493c5c15451e808a5e74c32781383a.c130648b59a0c8debea60aa153f844879(movieClip);
						_guildNewsButtons[num3] = cf9493c5c15451e808a5e74c32781383a;
						goto IL_02ae;
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
				object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array3[0] = "Guild news itemSlot name wrong! Index:";
				array3[1] = num3;
				array3[2] = " is bigger than sum: ";
				array3[3] = _guildNewsButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array3));
				return true;
			}
			goto IL_02ae;
			IL_02ae:
			if (movieClip.name.StartsWith(GUILD_SKILL_PREFIX_NAME))
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
				int c5612a459a84ffdb41c885401433cd62d = Convert.ToInt32(movieClip.name.Substring(GUILD_SKILL_PREFIX_NAME.Length, movieClip.name.Length - GUILD_SKILL_PREFIX_NAME.Length));
				GuildSkillIconSlot guildSkillIconSlot = new GuildSkillIconSlot();
				guildSkillIconSlot.c130648b59a0c8debea60aa153f844879(movieClip);
				guildSkillIconSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = new GuildTips(c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.cc5dce38711e2bbea16a914035b5feac4(c5612a459a84ffdb41c885401433cd62d));
				m_GuildSkillIconList.Add(guildSkillIconSlot);
				guildSkillIconSlot.c73e2661815f684ef5dd4807355ef628c(c06ca0e618478c23eba3419653a19760f<GuildProgressionSetting>.c5ee19dc8d4cccf5ae2de225410458b86.cc5dce38711e2bbea16a914035b5feac4(c5612a459a84ffdb41c885401433cd62d));
			}
			return false;
		}

		private void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildSearchView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		private void c43089d209950e0cb45ad46b03419f88a(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c811064378d00bd87d4c577faf379e610(tf_GuildDeca.c09721d98c247dde8efe59bc3cebbad00);
			tf_GuildDeca.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
		}

		protected void c90b116ba039d51a7af2fd3d1deeb4833(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (mc_GuildMemberList.visible)
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
					mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
					mc_GuildMemberList.visible = true;
					mc_GuildApplicationList.visible = false;
					mc_GuildNewsList.visible = false;
					mc_GuildSkillList.visible = false;
					c5bbf123eb3f3dea302b3e8154511ead6();
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (!mc_root.visible)
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
				c591c47219c2da4f480868724bfea2264();
				return;
			}
		}

		private void c5bbf123eb3f3dea302b3e8154511ead6()
		{
			tf_GuildName.text = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cdfc3c128a8ef3481d219619ff7c528ef();
			tf_GuildLevel.text = "LV." + GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c846bf4a4017139a7dce7c6d98220157c();
			tf_GuildDeca.c09721d98c247dde8efe59bc3cebbad00 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c65298fc86b05864e137848a671fdf996();
			int num = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c7482cb3fb4cd3ed0c583554787567bf5();
			int num2 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c3259223a7c3b756dc4e83b75fbe50b09();
			int num3 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c2324f607a3388f1d247741a5c264a1bd();
			tf_GuildExp.text = string.Empty;
			if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c718d841fbf38cce02a34f1e1bb2242d8() != 0)
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
				tf_SkillTips.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_Skill_Active"));
			}
			else
			{
				tf_SkillTips.text = string.Empty;
			}
			if (num2 != 0)
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
				float num4 = (float)Math.Abs(num3 - num) / (float)(num2 - num) * m_fExpWidth;
				if (num4 > m_fExpWidth)
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
					mc_ExpBar.c93e718634f0a0a9662e4e62dc1b5d8a5 = m_fExpWidth;
				}
				else
				{
					mc_ExpBar.c93e718634f0a0a9662e4e62dc1b5d8a5 = num4;
				}
			}
			else
			{
				mc_ExpBar.c93e718634f0a0a9662e4e62dc1b5d8a5 = m_fExpWidth;
			}
			if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c17ba091c28b756583dc29d3eec870622())
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
				tf_GuildDeca.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
				tf_GuildDeca.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				mc_ModifyButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			}
			else
			{
				tf_GuildDeca.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
				tf_GuildDeca.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				mc_ModifyButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			}
			tf_OnlineNum.textFormat.color = Color.yellow;
			if (m_bOnlineChecked)
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
				tf_OnlineNum.text = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8ceb61cd1200718c24169268b6f6633b().ToString();
			}
			else
			{
				tf_OnlineNum.text = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8362b5a3b1526fd771678993faa4c0bf().ToString();
			}
			tf_TotalNum.text = "/" + GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c71058e47b33ad98116def30435511982();
		}

		protected void c3960e1969e6424f645da348a759dfdd0(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
						return;
					}
				}
			}
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (mc_GuildNewsList.visible)
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
					mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(GUILD_NEWS_TOTAL, 0, GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cef77de19f0228e00b7b1845e7c887019() - GUILD_NEWS_TOTAL, 1);
					mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
					mc_GuildNewsList.visible = true;
					mc_GuildApplicationList.visible = false;
					mc_GuildMemberList.visible = false;
					mc_GuildSkillList.visible = false;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		protected void ce945ab51d1c8b45fa994a029aa8572e0(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
						return;
					}
				}
			}
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (mc_GuildApplicationList.visible)
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
					mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(GUILD_APPLICATION_TOTAL, 0, GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c24a619997c1daa6d6672175b34cb8b83() - GUILD_APPLICATION_TOTAL, 1);
					mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
					mc_GuildApplicationList.visible = true;
					mc_GuildMemberList.visible = false;
					mc_GuildNewsList.visible = false;
					mc_GuildSkillList.visible = false;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		protected void c501f37cd056e04e72c712a17fc43f5e3(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
						return;
					}
				}
			}
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (mc_GuildSkillList.visible)
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
					mc_GuildSkillList.visible = true;
					mc_GuildMemberList.visible = false;
					mc_GuildNewsList.visible = false;
					mc_GuildApplicationList.visible = false;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		protected void c49a9bfb9ea581f9bdf563721bb73830f(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = cd729d94a5b443ac0f1b117450e5f4419.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
						return;
					}
				}
			}
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_bOnlineChecked = true;
						GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c2322c5712f68c0fb21443e577a94e14b();
						return;
					}
				}
			}
			m_bOnlineChecked = false;
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c9be8dfdfec9eb72150c0a63a13ec1fc4();
		}

		protected void cc5441980ac3f22768080730945fcb58e()
		{
			for (int i = 0; i < _guildMemberButtons.Length; i++)
			{
				_guildMemberButtons[i].c150264a18c2cb408479d3f072cac8cc1 = false;
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
				for (int j = 0; j < _guildApplicationButtons.Length; j++)
				{
					_guildApplicationButtons[j].c150264a18c2cb408479d3f072cac8cc1 = false;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					for (int k = 0; k < _guildNewsButtons.Length; k++)
					{
						_guildNewsButtons[k].c150264a18c2cb408479d3f072cac8cc1 = false;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}

		public void c591c47219c2da4f480868724bfea2264(GuildSearchPart c716466036ca83f8907f5a0c81b0e432d = GuildSearchPart.e_None)
		{
			c5bbf123eb3f3dea302b3e8154511ead6();
			if (mc_GuildApplicationList == null)
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
				if (mc_GuildMemberList == null)
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
					if (mc_GuildNewsList == null)
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
						if (mc_GuildSkillList == null)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									return;
								}
							}
						}
						if (mc_GuildMemberList.visible)
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
							if (c716466036ca83f8907f5a0c81b0e432d != 0)
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
								if (c716466036ca83f8907f5a0c81b0e432d != GuildSearchPart.e_GuildMember)
								{
									while (true)
									{
										switch (4)
										{
										case 0:
											break;
										default:
											return;
										}
									}
								}
							}
							int num;
							if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8362b5a3b1526fd771678993faa4c0bf() > GUILD_MEMBER_TOTAL)
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
								num = GUILD_MEMBER_TOTAL;
							}
							else
							{
								num = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8362b5a3b1526fd771678993faa4c0bf();
							}
							int num2 = num;
							if (m_bOnlineChecked)
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
								int num3;
								if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8ceb61cd1200718c24169268b6f6633b() > GUILD_MEMBER_TOTAL)
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
									num3 = GUILD_MEMBER_TOTAL;
								}
								else
								{
									num3 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8ceb61cd1200718c24169268b6f6633b();
								}
								num2 = num3;
								mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(GUILD_MEMBER_TOTAL, 0, GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8ceb61cd1200718c24169268b6f6633b() - GUILD_MEMBER_TOTAL, 1);
							}
							else
							{
								mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(GUILD_MEMBER_TOTAL, 0, GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8362b5a3b1526fd771678993faa4c0bf() - GUILD_MEMBER_TOTAL, 1);
							}
							for (int i = 0; i < num2; i++)
							{
								_guildMemberButtons[i].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + i);
								_guildMemberButtons[i].c150264a18c2cb408479d3f072cac8cc1 = true;
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
							for (int j = num2; j < GUILD_MEMBER_TOTAL; j++)
							{
								_guildMemberButtons[j].c150264a18c2cb408479d3f072cac8cc1 = false;
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
						}
						if (mc_GuildApplicationList.visible)
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
							if (c716466036ca83f8907f5a0c81b0e432d != 0)
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
								if (c716466036ca83f8907f5a0c81b0e432d != GuildSearchPart.e_GuildApplication)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											return;
										}
									}
								}
							}
							int num4;
							if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c24a619997c1daa6d6672175b34cb8b83() > GUILD_APPLICATION_TOTAL)
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
								num4 = GUILD_APPLICATION_TOTAL;
							}
							else
							{
								num4 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c24a619997c1daa6d6672175b34cb8b83();
							}
							int num5 = num4;
							for (int k = 0; k < num5; k++)
							{
								_guildApplicationButtons[k].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + k);
								_guildApplicationButtons[k].c150264a18c2cb408479d3f072cac8cc1 = true;
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
							for (int l = num5; l < GUILD_APPLICATION_TOTAL; l++)
							{
								_guildApplicationButtons[l].c150264a18c2cb408479d3f072cac8cc1 = false;
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
						}
						if (mc_GuildNewsList.visible)
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
							if (c716466036ca83f8907f5a0c81b0e432d != 0)
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
								if (c716466036ca83f8907f5a0c81b0e432d != GuildSearchPart.e_GuildNews)
								{
									while (true)
									{
										switch (4)
										{
										case 0:
											break;
										default:
											return;
										}
									}
								}
							}
							int num6;
							if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cef77de19f0228e00b7b1845e7c887019() > GUILD_NEWS_TOTAL)
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
								num6 = GUILD_NEWS_TOTAL;
							}
							else
							{
								num6 = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cef77de19f0228e00b7b1845e7c887019();
							}
							int num7 = num6;
							for (int m = 0; m < num7; m++)
							{
								_guildNewsButtons[m].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + m);
								_guildNewsButtons[m].c150264a18c2cb408479d3f072cac8cc1 = true;
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
							for (int n = num7; n < GUILD_NEWS_TOTAL; n++)
							{
								_guildNewsButtons[n].c150264a18c2cb408479d3f072cac8cc1 = false;
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
						}
						if (!mc_GuildSkillList.visible)
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
							if (c716466036ca83f8907f5a0c81b0e432d != 0)
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
								if (c716466036ca83f8907f5a0c81b0e432d != GuildSearchPart.e_GuildSkill)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											return;
										}
									}
								}
							}
							for (int num8 = 0; num8 < m_GuildSkillIconList.Count; num8++)
							{
								m_GuildSkillIconList[num8].c46f083a1c6dc7b33c99f7a6787447fc3();
							}
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									return;
								}
							}
						}
					}
				}
			}
		}
	}

	private GuildSearchPanel _guildSearchPanel;

	private GuildManagePanel _guildManagePanel;

	protected Dictionary<string, MovieClip> _GuildSkillIcon = new Dictionary<string, MovieClip>();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_GuildSkillIcon.Clear();
		for (int i = 0; i < 8; i++)
		{
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Skill_Buff_icon.swf", "Movie_Skill" + i, c910207b182ba6deb649b233dac255af0);
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Guild_flow.swf", "Panel_Guild", ca342d55e5227ec08b3eba6a5853554ba);
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Tips.swf", "Panel_Tips_Card", c1e3ae4c519247c15204aa617ee0a223f);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_GuildSkillIcon.Clear();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildSearchPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildManagePanel);
		_guildSearchPanel = null;
		_guildManagePanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Skill_Buff_icon.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Guild_flow.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Tips.swf");
	}

	private void ca342d55e5227ec08b3eba6a5853554ba(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_guildSearchPanel = new GuildSearchPanel();
		_guildSearchPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	private void c7017eda9d0b9f004bd270de2f36a8c2e(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_guildManagePanel = new GuildManagePanel();
		_guildManagePanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	private void c1e3ae4c519247c15204aa617ee0a223f(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		GuildTips._itemPanel = new ItemTipsPanel();
		GuildTips._itemPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
	}

	private void c910207b182ba6deb649b233dac255af0(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		if (cbe9ca8ddb3cdc2312e6ff8411b2db2c8 == null)
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
					return;
				}
			}
		}
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.name = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getSymbolName();
		if (!_GuildSkillIcon.ContainsKey(cbe9ca8ddb3cdc2312e6ff8411b2db2c8.name))
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
			_GuildSkillIcon.Add(cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getSymbolName(), cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		}
		if (_GuildSkillIcon.Count != 8)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Guild_flow.swf", "Panel_Guild_owner", c7017eda9d0b9f004bd270de2f36a8c2e);
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (!c9e82bede03ea180ba65a597350997ad2)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (!c8be1fcd630e5fe96821376d111325750)
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
						base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
						if (_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1)
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
							_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
							(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildSearchPanel);
						}
						if (_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1)
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
							_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
							(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildManagePanel);
						}
					}
					if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cb7a25096669180e2e90e9c1acb5e62c2())
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
								if (c8be1fcd630e5fe96821376d111325750)
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
									(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_guildSearchPanel);
								}
								else
								{
									(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildSearchPanel);
								}
								_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
								if (c8be1fcd630e5fe96821376d111325750)
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c508b282423394afe3d81a9f7faa2967b();
											return;
										}
									}
								}
								return;
							}
						}
					}
					if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd19cb80dca29b5c813acffe07d4eb050())
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								{
									if (c8be1fcd630e5fe96821376d111325750)
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
										(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_guildManagePanel);
									}
									else
									{
										(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildManagePanel);
									}
									if (c8be1fcd630e5fe96821376d111325750)
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
										GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c1c30180f8cf8e8933128caa5e48f49ae();
										GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cc94fcaeab5d835c80bf5ec715de08e9a();
										if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c17ba091c28b756583dc29d3eec870622())
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
											if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6451c6b5252840b2be641871236928f())
											{
												goto IL_0224;
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
										}
										GuildManager.c71f6ce28731edfd43c976fbd57c57bea().ceeacb24fb9f8879f890a919879452431();
									}
									goto IL_0224;
								}
								IL_0224:
								base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
								_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
								return;
							}
						}
					}
					return;
				}
			}
		}
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
			if (_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			if (!_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}
	}

	public override void c263a18e823d534fe933bf797fd17c221(GuildSearchPart c716466036ca83f8907f5a0c81b0e432d = GuildSearchPart.e_None)
	{
		if (_guildSearchPanel != null)
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
			if (_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_guildSearchPanel.c591c47219c2da4f480868724bfea2264(c716466036ca83f8907f5a0c81b0e432d);
			}
		}
		if (_guildManagePanel == null)
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
			if (!_guildManagePanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_guildManagePanel.c591c47219c2da4f480868724bfea2264(c716466036ca83f8907f5a0c81b0e432d);
				return;
			}
		}
	}

	public override void cb4e02cff1512be57edd191db2eec2b0a(int c41d8f7311845ab726afcb5975a0b304b)
	{
		if (_guildSearchPanel == null)
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
			if (!_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_guildSearchPanel.cb4e02cff1512be57edd191db2eec2b0a(c41d8f7311845ab726afcb5975a0b304b);
				return;
			}
		}
	}

	public override int ce96b33ee40abc99c97f8a8ea66a99632()
	{
		if (_guildSearchPanel != null)
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
			if (_guildSearchPanel.c150264a18c2cb408479d3f072cac8cc1)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return _guildSearchPanel.ce96b33ee40abc99c97f8a8ea66a99632();
					}
				}
			}
		}
		return base.ce96b33ee40abc99c97f8a8ea66a99632();
	}

	public void c6a21327f8a1406da47c07d9ef9662d87(MovieClip c38166bc7092867b1eae7a76b075dbdbd, string cc1e419f52102dfd441b21e702e5c1c88)
	{
		if (c38166bc7092867b1eae7a76b075dbdbd == null)
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
			if (cc1e419f52102dfd441b21e702e5c1c88.Length == 0)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			c38166bc7092867b1eae7a76b075dbdbd.gotoAndStop("EndFrame");
			MovieClip childByName = c38166bc7092867b1eae7a76b075dbdbd.getChildByName<MovieClip>("mcIconImg");
			childByName.visible = false;
			MovieClip childByName2 = c38166bc7092867b1eae7a76b075dbdbd.getChildByName<MovieClip>(cc1e419f52102dfd441b21e702e5c1c88);
			if (childByName2 != null)
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
				MovieClip value = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
				_GuildSkillIcon.TryGetValue(cc1e419f52102dfd441b21e702e5c1c88, out value);
				if (value == null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				MovieClip movieClip = value.newInstance();
				movieClip.x = 0f;
				movieClip.y = 0f;
				movieClip.name = value.name;
				c38166bc7092867b1eae7a76b075dbdbd.addChildAt(movieClip, c38166bc7092867b1eae7a76b075dbdbd.getChildIndex(childByName));
				return;
			}
		}
	}
}
