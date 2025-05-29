using System;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniFriendView : FriendView
{
	private enum FRIEND_PANEL_STYLE
	{
		e_FriendList = 0,
		e_FriendInvitation = 1,
		e_FriendSearch = 2
	}

	private class FriendPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private int FRIEND_TOTAL = 14;

		private int INVITAION_TOTAL = 14;

		private int SEARCH_TOTAL = 13;

		private string FRIEND_SLOT_PREFIX_NAME = "elementFriend";

		private string FRIEND_INVITE_PREFIX_NAME = "itemInvitation";

		private string FRIEND_SEARCH_PREFIX_NAME = "itemFriend";

		private bool m_bOnlineChecked;

		protected c509f323e4f9c7c7350725dc5cf3f6ae6[] _friendButtons;

		protected c01cf7764f8785abbf3de0dd64f1bf020[] _friendInvitationButtons;

		protected c0fc44becb6054b8da2d11ec351304adc[] _friendSearchButtons;

		private MovieClip mc_FriendList;

		private MovieClip mc_InvitationList;

		private MovieClip mc_SearchList;

		private MovieClip mc_SearchTag;

		private MovieClip mc_Character;

		private c6425d3761c85e65e3530cc19d085d446 mc_FriendButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_InvitationButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_SearchButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_BlackListButton;

		private c6425d3761c85e65e3530cc19d085d446 mc_OnlineBox;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_searchFriendButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Close;

		private TextField tf_Name;

		private TextField tf_Level;

		private TextField tf_FriendNum;

		private TextField tf_FriendMaxNum;

		private ccf8bd4afc86b3c33d69f65b1612538ce mcNameInput;

		protected cf7ac05203029a27299d6893b2dbaee2e mc_ScrollBar;

		private int m_nMaxFriendCount = 30;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
					switch (1)
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
							switch (2)
							{
							case 0:
								break;
							default:
								c0159867dc6869bb2ec205ab748ad6afb();
								if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd0069281ff5290a7e6c484b6aed3933d)
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
									if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c1ec009745cf889298f5dbae973f0cbd7())
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
										mc_InvitationButton.c9c364a8fd1f013589fea518a3924e711 = true;
										mc_FriendList.visible = false;
										mc_InvitationList.visible = true;
									}
									else
									{
										mc_FriendButton.c9c364a8fd1f013589fea518a3924e711 = true;
										mc_FriendList.visible = true;
										mc_InvitationList.visible = false;
									}
								}
								else
								{
									mc_FriendButton.c9c364a8fd1f013589fea518a3924e711 = true;
									mc_FriendList.visible = true;
									mc_InvitationList.visible = false;
								}
								mc_SearchList.visible = false;
								mc_SearchTag.visible = false;
								mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
								mcNameInput.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
								c591c47219c2da4f480868724bfea2264();
								return;
							}
						}
					}
					mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
					mcNameInput.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = false;
					c09fd41a9b5ba9b6addeaef436867b943();
					return;
				}
			}
		}

		public FriendPanel()
		{
			_friendButtons = cec23fbee9ad60fb174ce902110930e14.c0a0cdf4a196914163f7334d9b0781a04(FRIEND_TOTAL);
			_friendInvitationButtons = cfc739b5f489c3fe6196f6754d2136e50.c0a0cdf4a196914163f7334d9b0781a04(INVITAION_TOTAL);
			_friendSearchButtons = c64e74521792bff5f43f6e430433dd958.c0a0cdf4a196914163f7334d9b0781a04(SEARCH_TOTAL);
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: FriendPanel onInit() 'mc_root' is null! InstancePanel won't work!!!");
						return;
					}
				}
			}
			mc_root.visible = false;
			mc_root.stopAll();
			MovieClip childByName = mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_friend_total");
			mc_FriendList = childByName.getChildByName<MovieClip>("mc_friends");
			mc_InvitationList = childByName.getChildByName<MovieClip>("mc_invetation");
			mc_SearchList = childByName.getChildByName<MovieClip>("mc_search");
			mc_SearchTag = childByName.getChildByName<MovieClip>("mc_searchTag");
			mc_Character = childByName.getChildByName<MovieClip>("mcIcon").getChildByName<MovieClip>("mcClassIcon");
			tf_Name = childByName.getChildByName<TextField>("tfPlayerName");
			tf_Level = childByName.getChildByName<TextField>("TitleName");
			tf_FriendNum = mc_FriendList.getChildByName<TextField>("tf_OnlineMember");
			tf_FriendMaxNum = mc_FriendList.getChildByName<TextField>("tf_AllMember");
			mc_Character.gotoAndStop(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a().ToString());
			tf_Name.text = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_name;
			tf_Level.text = "LV." + c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
			tf_FriendMaxNum.text = "/" + m_nMaxFriendCount;
			mc_FriendButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_InvitationButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_SearchButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_BlackListButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_Close = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_Close.c130648b59a0c8debea60aa153f844879(childByName.getChildByName<MovieClip>("mcBtnClose"));
			mc_Close.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
			mc_searchFriendButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_searchFriendButton.c130648b59a0c8debea60aa153f844879(mc_SearchList.getChildByName<MovieClip>("mc_searchBtn"));
			mc_searchFriendButton.addEventListener(MouseEvent.CLICK, c809456082aa8a4906776d2de67d4ba03);
			mcNameInput = new ccf8bd4afc86b3c33d69f65b1612538ce();
			mcNameInput.c130648b59a0c8debea60aa153f844879(mc_SearchList.getChildByName<MovieClip>("mcsloganInput"));
			mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
			mc_FriendButton.c130648b59a0c8debea60aa153f844879(childByName.getChildByName<MovieClip>("mc_friendlist"));
			mc_FriendButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c890432085331a0b200706f0b0820db1b);
			mc_FriendButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_FriendButton.cec024da8c099380cfe1334bfe4c8f30f = "Friend";
			mc_InvitationButton.c130648b59a0c8debea60aa153f844879(childByName.getChildByName<MovieClip>("mc_invitation"));
			mc_InvitationButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ccec8c369f0fcd3cdad159046c51b7944);
			mc_InvitationButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_InvitationButton.cec024da8c099380cfe1334bfe4c8f30f = "Friend";
			mc_SearchButton.c130648b59a0c8debea60aa153f844879(childByName.getChildByName<MovieClip>("mc_search_btn"));
			mc_SearchButton.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, cb70e34c92a9070a4a5b7a79ed61b9af5);
			mc_SearchButton.ce84b930a12a1d06512c79320b3f0d3f4 = false;
			mc_SearchButton.cec024da8c099380cfe1334bfe4c8f30f = "Friend";
			mc_BlackListButton.c130648b59a0c8debea60aa153f844879(childByName.getChildByName<MovieClip>("mc_black_btn"));
			mc_BlackListButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_ScrollBar = new cf7ac05203029a27299d6893b2dbaee2e();
			mc_ScrollBar.c130648b59a0c8debea60aa153f844879(childByName.getChildByName<MovieClip>("mcScrollingBar"));
			mc_ScrollBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
			mc_ScrollBar.cfcb3294d851a0336d3f3a8f2a943f2fb = (mc_ScrollBar.c9c58dff860effc1212c1afb5d14e147c = 0);
			mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			mc_FriendList.visible = true;
			mc_InvitationList.visible = false;
			mc_SearchList.visible = false;
			mc_SearchTag.visible = false;
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mc_root.visible = true;
			mc_root.gotoAndPlay("fade");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			mc_root.gotoAndPlay("fadeout");
			mc_root.addFrameScript("fadeoutend", c1a8a5357baa03eacf7b0a3123daf5911);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cadfb3e35b7330c65cea035fdd80e3962();
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeEventListener("fadeoutend", c1a8a5357baa03eacf7b0a3123daf5911);
			mc_root.visible = false;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(FRIEND_SLOT_PREFIX_NAME))
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
				int num = Convert.ToInt32(movieClip.name.Substring(FRIEND_SLOT_PREFIX_NAME.Length, movieClip.name.Length - FRIEND_SLOT_PREFIX_NAME.Length));
				if (num < _friendButtons.Length)
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
					if (num >= 0)
					{
						c509f323e4f9c7c7350725dc5cf3f6ae6 c509f323e4f9c7c7350725dc5cf3f6ae = new c509f323e4f9c7c7350725dc5cf3f6ae6();
						c509f323e4f9c7c7350725dc5cf3f6ae.c130648b59a0c8debea60aa153f844879(movieClip);
						_friendButtons[num] = c509f323e4f9c7c7350725dc5cf3f6ae;
						goto IL_00e8;
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
				}
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "friend itemSlot name wrong! Index:";
				array[1] = num;
				array[2] = " is bigger than sum: ";
				array[3] = _friendButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
				return true;
			}
			goto IL_00e8;
			IL_00e8:
			if (movieClip.name.StartsWith(FRIEND_INVITE_PREFIX_NAME))
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
				int num2 = Convert.ToInt32(movieClip.name.Substring(FRIEND_INVITE_PREFIX_NAME.Length, movieClip.name.Length - FRIEND_INVITE_PREFIX_NAME.Length));
				if (num2 < _friendInvitationButtons.Length)
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
					if (num2 >= 0)
					{
						c01cf7764f8785abbf3de0dd64f1bf020 c01cf7764f8785abbf3de0dd64f1bf = new c01cf7764f8785abbf3de0dd64f1bf020();
						c01cf7764f8785abbf3de0dd64f1bf.c130648b59a0c8debea60aa153f844879(movieClip);
						_friendInvitationButtons[num2] = c01cf7764f8785abbf3de0dd64f1bf;
						goto IL_01c7;
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
				}
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = "friend invitation itemSlot name wrong! Index:";
				array2[1] = num2;
				array2[2] = " is bigger than sum: ";
				array2[3] = _friendInvitationButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array2));
				return true;
			}
			goto IL_01c7;
			IL_01c7:
			if (movieClip.name.StartsWith(FRIEND_SEARCH_PREFIX_NAME))
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
				int num3 = Convert.ToInt32(movieClip.name.Substring(FRIEND_SEARCH_PREFIX_NAME.Length, movieClip.name.Length - FRIEND_SEARCH_PREFIX_NAME.Length));
				if (num3 < _friendSearchButtons.Length)
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
					if (num3 >= 0)
					{
						c0fc44becb6054b8da2d11ec351304adc c0fc44becb6054b8da2d11ec351304adc = new c0fc44becb6054b8da2d11ec351304adc();
						c0fc44becb6054b8da2d11ec351304adc.c130648b59a0c8debea60aa153f844879(movieClip);
						_friendSearchButtons[num3] = c0fc44becb6054b8da2d11ec351304adc;
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
				array3[0] = "friend search itemSlot name wrong! Index:";
				array3[1] = num3;
				array3[2] = " is bigger than sum: ";
				array3[3] = _friendSearchButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array3));
				return true;
			}
			goto IL_02ae;
			IL_02ae:
			if (movieClip.name == "mc_onlinecheck")
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
				mc_OnlineBox = new c6425d3761c85e65e3530cc19d085d446();
				mc_OnlineBox.c130648b59a0c8debea60aa153f844879(movieClip);
				mc_OnlineBox.ce84b930a12a1d06512c79320b3f0d3f4 = true;
				mc_OnlineBox.cec024da8c099380cfe1334bfe4c8f30f = "online";
				mc_OnlineBox.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c49a9bfb9ea581f9bdf563721bb73830f);
			}
			return true;
		}

		protected void c49a9bfb9ea581f9bdf563721bb73830f(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = cd729d94a5b443ac0f1b117450e5f4419.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
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
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				m_bOnlineChecked = true;
				mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(FRIEND_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c338f75ed0138aa7c193523682e0a180e() - FRIEND_TOTAL, 1);
				mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			}
			else
			{
				m_bOnlineChecked = false;
				mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(FRIEND_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c5f2cb1d77cbb3465c54be16450d45d1d() - FRIEND_TOTAL, 1);
				mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			}
			c591c47219c2da4f480868724bfea2264();
		}

		private void c890432085331a0b200706f0b0820db1b(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
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
				switch (3)
				{
				case 0:
					continue;
				}
				if (mc_FriendList.visible)
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
					mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(FRIEND_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c5f2cb1d77cbb3465c54be16450d45d1d() - FRIEND_TOTAL, 1);
					mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
					mc_FriendList.visible = true;
					mc_InvitationList.visible = false;
					mc_SearchList.visible = false;
					mc_SearchTag.visible = false;
					mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		private void ccec8c369f0fcd3cdad159046c51b7944(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
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
				switch (2)
				{
				case 0:
					continue;
				}
				if (mc_InvitationList.visible)
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
					mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(INVITAION_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c81b33504dcaf516d9419db3d8e269616() - INVITAION_TOTAL, 1);
					mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
					mc_FriendList.visible = false;
					mc_InvitationList.visible = true;
					mc_SearchList.visible = false;
					mc_SearchTag.visible = false;
					mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		private void cb70e34c92a9070a4a5b7a79ed61b9af5(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
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
				switch (3)
				{
				case 0:
					continue;
				}
				if (mc_SearchList.visible)
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
					mc_FriendList.visible = false;
					mc_InvitationList.visible = false;
					mc_SearchList.visible = true;
					mc_SearchTag.visible = false;
					mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = false;
					c591c47219c2da4f480868724bfea2264();
					return;
				}
			}
		}

		private void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<FriendView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		private void c809456082aa8a4906776d2de67d4ba03(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!(mcNameInput.c09721d98c247dde8efe59bc3cebbad00 != string.Empty))
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
				FriendManager.c71f6ce28731edfd43c976fbd57c57bea().cf532f18dc506947263a9adde977ea566(mcNameInput.c09721d98c247dde8efe59bc3cebbad00);
				return;
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
				switch (6)
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

		public void c591c47219c2da4f480868724bfea2264(bool c6f679be941e26295c3532fc30731ee30 = false)
		{
			if (mc_FriendList == null)
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
				if (mc_InvitationList == null)
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
					if (mc_SearchList == null)
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
					if (mc_FriendList.visible)
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
						tf_FriendNum.textFormat.color = Color.yellow;
						tf_FriendNum.text = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c5f2cb1d77cbb3465c54be16450d45d1d().ToString();
						int num;
						if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c5f2cb1d77cbb3465c54be16450d45d1d() > FRIEND_TOTAL)
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
							num = FRIEND_TOTAL;
						}
						else
						{
							num = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c5f2cb1d77cbb3465c54be16450d45d1d();
						}
						int num2 = num;
						if (m_bOnlineChecked)
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
							int num3;
							if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c338f75ed0138aa7c193523682e0a180e() > FRIEND_TOTAL)
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
								num3 = FRIEND_TOTAL;
							}
							else
							{
								num3 = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c338f75ed0138aa7c193523682e0a180e();
							}
							num2 = num3;
							mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(FRIEND_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c338f75ed0138aa7c193523682e0a180e() - FRIEND_TOTAL, 1);
						}
						else
						{
							mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(FRIEND_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c5f2cb1d77cbb3465c54be16450d45d1d() - FRIEND_TOTAL, 1);
						}
						for (int i = 0; i < num2; i++)
						{
							_friendButtons[i].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + i);
							_friendButtons[i].c150264a18c2cb408479d3f072cac8cc1 = true;
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
						for (int j = num2; j < FRIEND_TOTAL; j++)
						{
							if (_friendButtons[j] == null)
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
							_friendButtons[j].c150264a18c2cb408479d3f072cac8cc1 = false;
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
					if (mc_InvitationList.visible)
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
						mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(INVITAION_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c81b33504dcaf516d9419db3d8e269616() - INVITAION_TOTAL, 1);
						int num4;
						if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c81b33504dcaf516d9419db3d8e269616() > INVITAION_TOTAL)
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
							num4 = INVITAION_TOTAL;
						}
						else
						{
							num4 = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c81b33504dcaf516d9419db3d8e269616();
						}
						int num5 = num4;
						for (int k = 0; k < num5; k++)
						{
							_friendInvitationButtons[k].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + k);
							_friendInvitationButtons[k].c150264a18c2cb408479d3f072cac8cc1 = true;
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
						for (int l = num5; l < INVITAION_TOTAL; l++)
						{
							if (_friendInvitationButtons[l] == null)
							{
								continue;
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
							_friendInvitationButtons[l].c150264a18c2cb408479d3f072cac8cc1 = false;
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
					if (!mc_SearchList.visible)
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
						mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(FRIEND_TOTAL, 0, FriendManager.c71f6ce28731edfd43c976fbd57c57bea().ce7e52320196a6b9812b8a7f22ed7b89c() - FRIEND_TOTAL, 1);
						int num6;
						if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().ce7e52320196a6b9812b8a7f22ed7b89c() > SEARCH_TOTAL)
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
							num6 = SEARCH_TOTAL;
						}
						else
						{
							num6 = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().ce7e52320196a6b9812b8a7f22ed7b89c();
						}
						int num7 = num6;
						for (int m = 0; m < num7; m++)
						{
							_friendSearchButtons[m].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + m);
							_friendSearchButtons[m].c150264a18c2cb408479d3f072cac8cc1 = true;
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							for (int n = num7; n < SEARCH_TOTAL; n++)
							{
								if (_friendSearchButtons[n] == null)
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
								_friendSearchButtons[n].c150264a18c2cb408479d3f072cac8cc1 = false;
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
			}
		}
	}

	private FriendPanel _friendPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Friend_Group.swf", "RootPanel", cac896b87bcd10f72321dc7fe27e6cfb8);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_friendPanel);
		_friendPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Friend_Group.swf");
	}

	private void cac896b87bcd10f72321dc7fe27e6cfb8(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_friendPanel = new FriendPanel();
		_friendPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_friendPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_friendPanel);
		}
		_friendPanel.c150264a18c2cb408479d3f072cac8cc1 = _bVisible;
	}

	public override void c263a18e823d534fe933bf797fd17c221(bool c8be1fcd630e5fe96821376d111325750 = false)
	{
		if (_friendPanel == null)
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
			_friendPanel.c591c47219c2da4f480868724bfea2264(c8be1fcd630e5fe96821376d111325750);
			return;
		}
	}
}
