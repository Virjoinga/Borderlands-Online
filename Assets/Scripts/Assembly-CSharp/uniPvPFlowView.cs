using System;
using A;
using Core;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniPvPFlowView : PvPFlowView
{
	private class PvPFlowPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private int ROOM_MEMBER_TOTAL = 8;

		private string ROOM_MEMBER_PREFIX_NAME = "itemlist";

		protected ce0ae1607c07b6bd6009ae6336b339b42[] _roomMemberListButtons;

		private int FRIEND_TOTAL = 15;

		private string FRIEND_PREFIX_NAME = "playerlist";

		protected cc25c1ee12c4b33340a4c33ba3a4275c9[] _roomInvitationListButtons;

		private int PLAYER_RECORD_TOTAL = 16;

		private string PLAYER_RECORD_PREFIX_NAME = "playerinfo";

		protected c6ae57b6b0eaf6c226a8fff792fb808df[] _playerRecordListButtons;

		protected MovieClip mc_RoomPanel;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CloseBtn;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InviteBtn;

		protected TextField tf_RoomLevel;

		protected TextField tf_RoomOwnerName;

		protected TextField tf_RoomOwnerMatchCount;

		protected TextField tf_RoomOwnerHonor;

		protected TextField tf_RoomOwnerKillDeath;

		protected TextField tf_RoomOwnerWinLose;

		protected MovieClip mc_InstancePanel;

		protected MovieClip mc_Selected;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_TeamDeathBtn;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_DeathBtn;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CloseSelectBtn;

		private int m_nInstanceId = -1;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InstanceBtn1;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InstanceBtn2;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InstanceBtn3;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InstanceBtn4;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InstanceBtn5;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_InstanceBtn6;

		protected MovieClip mc_ListPanel;

		private c6425d3761c85e65e3530cc19d085d446 mc_NearbyFriendButton;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_BackBtn;

		protected MovieClip mc_InfoPanel;

		private c6425d3761c85e65e3530cc19d085d446 mc_RankButton;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_ReturnBtn;

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
				if (mc_root != null)
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
					mc_root.visible = value;
					if (value)
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
						mc_RoomPanel.visible = true;
						mc_InstancePanel.visible = true;
						mc_ListPanel.visible = false;
						mc_InfoPanel.visible = false;
						mc_Selected.visible = false;
						c591c47219c2da4f480868724bfea2264();
					}
				}
				if (!value)
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
					c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_pvp");
					return;
				}
			}
		}

		public PvPFlowPanel()
		{
			_roomMemberListButtons = c2dedb390a484f3bac4291495644c968d.c0a0cdf4a196914163f7334d9b0781a04(ROOM_MEMBER_TOTAL);
			_roomInvitationListButtons = c8d8e46cc5f5a9aadda5944fb62aa6c5c.c0a0cdf4a196914163f7334d9b0781a04(FRIEND_TOTAL);
			_playerRecordListButtons = c5b91f2064e4c4fc5978c99158b780b22.c0a0cdf4a196914163f7334d9b0781a04(PLAYER_RECORD_TOTAL);
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			mc_root.stopAll();
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: PvPFlowPanel onInit() 'mc_root' is null! PvPFlowPanel won't work!!!");
						return;
					}
				}
			}
			mc_RoomPanel = mc_root.getChildByName<MovieClip>("mc_Room");
			mc_CloseBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CloseBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mcClose"));
			mc_CloseBtn.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
			mc_InviteBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InviteBtn.c130648b59a0c8debea60aa153f844879(mc_RoomPanel.getChildByName<MovieClip>("mc_invite"));
			mc_InviteBtn.addEventListener(MouseEvent.CLICK, c729c1f528fd63f742b7ed54b2d87a6e9);
			tf_RoomLevel = mc_RoomPanel.getChildByName<TextField>("roomlevel");
			tf_RoomOwnerName = mc_RoomPanel.getChildByName<TextField>("ownername");
			tf_RoomOwnerMatchCount = mc_RoomPanel.getChildByName<TextField>("ownercount");
			tf_RoomOwnerHonor = mc_RoomPanel.getChildByName<TextField>("ownerhonor");
			tf_RoomOwnerKillDeath = mc_RoomPanel.getChildByName<TextField>("ownerkilldeath");
			tf_RoomOwnerWinLose = mc_RoomPanel.getChildByName<TextField>("ownerwinlose");
			mc_InstancePanel = mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_instance");
			mc_Selected = mc_InstancePanel.getChildByName<MovieClip>("mc_All");
			mc_TeamDeathBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_TeamDeathBtn.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_All").getChildByName<MovieClip>("mc_team"));
			mc_TeamDeathBtn.addEventListener(MouseEvent.CLICK, c59e6848a91481a404c9d77688dc57acf);
			mc_DeathBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_DeathBtn.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_All").getChildByName<MovieClip>("mc_solo"));
			mc_DeathBtn.addEventListener(MouseEvent.CLICK, c2ad3faebb0c8f5b27795460f6991f700);
			mc_CloseSelectBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CloseSelectBtn.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_All").getChildByName<MovieClip>("mcXButton"));
			mc_CloseSelectBtn.addEventListener(MouseEvent.CLICK, c93bde6c7c4aee5697582efa1e99449ba);
			mc_InstanceBtn1 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InstanceBtn1.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_instance1"));
			mc_InstanceBtn1.addEventListener(MouseEvent.CLICK, cab292bd2642c8246c318171e0d38b7f0);
			mc_InstancePanel.getChildByName<MovieClip>("mc_instance1").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Relic Alcaid");
			mc_InstanceBtn2 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InstanceBtn2.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_instance2"));
			mc_InstanceBtn2.addEventListener(MouseEvent.CLICK, c997adcc0c5c3e1e446104074859028a9);
			mc_InstancePanel.getChildByName<MovieClip>("mc_instance2").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Final Command");
			mc_InstanceBtn3 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InstanceBtn3.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_instance3"));
			mc_InstanceBtn3.addEventListener(MouseEvent.CLICK, c31b386dc3710b18d082ad1ea50b8e929);
			mc_InstancePanel.getChildByName<MovieClip>("mc_instance3").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Waterfall");
			mc_InstanceBtn4 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InstanceBtn4.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_instance4"));
			mc_InstanceBtn4.addEventListener(MouseEvent.CLICK, c9166a3c6aa5ddf68cf31db6bb43881da);
			mc_InstancePanel.getChildByName<MovieClip>("mc_instance4").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Valley of weeping");
			mc_InstanceBtn5 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InstanceBtn5.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_instance5"));
			mc_InstanceBtn5.addEventListener(MouseEvent.CLICK, c6c06b336616475a9763116899a3cf53b);
			mc_InstanceBtn5.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_InstancePanel.getChildByName<MovieClip>("mc_instance5").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("none");
			mc_InstanceBtn6 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_InstanceBtn6.c130648b59a0c8debea60aa153f844879(mc_InstancePanel.getChildByName<MovieClip>("mc_instance6"));
			mc_InstanceBtn6.addEventListener(MouseEvent.CLICK, c55c4d55e2f1e7b74dc238bf5b0780360);
			mc_InstanceBtn6.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_InstancePanel.getChildByName<MovieClip>("mc_instance6").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("none");
			mc_ListPanel = mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_List");
			mc_BackBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_BackBtn.c130648b59a0c8debea60aa153f844879(mc_ListPanel.getChildByName<MovieClip>("mc_back"));
			mc_BackBtn.addEventListener(MouseEvent.CLICK, cb7e20120b2dc039ccc2e9644991e43dd);
			mc_InfoPanel = mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_detail");
			mc_ReturnBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_ReturnBtn.c130648b59a0c8debea60aa153f844879(mc_InfoPanel.getChildByName<MovieClip>("mc_return"));
			mc_ReturnBtn.addEventListener(MouseEvent.CLICK, ca033a99a417cdf99b2aa61d2d8d558b7);
			mc_RankButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_RankButton.c130648b59a0c8debea60aa153f844879(mc_InfoPanel.getChildByName<MovieClip>("mc_rankPanel"));
			mc_RankButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mc_NearbyFriendButton = new c6425d3761c85e65e3530cc19d085d446();
			mc_NearbyFriendButton.c130648b59a0c8debea60aa153f844879(mc_ListPanel.getChildByName<MovieClip>("mc_nearbyPanel"));
			mc_NearbyFriendButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(ROOM_MEMBER_PREFIX_NAME))
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
				int num = Convert.ToInt32(movieClip.name.Substring(ROOM_MEMBER_PREFIX_NAME.Length, movieClip.name.Length - ROOM_MEMBER_PREFIX_NAME.Length));
				if (num < _roomMemberListButtons.Length)
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
					if (num >= 0)
					{
						ce0ae1607c07b6bd6009ae6336b339b42 ce0ae1607c07b6bd6009ae6336b339b = new ce0ae1607c07b6bd6009ae6336b339b42();
						ce0ae1607c07b6bd6009ae6336b339b.c130648b59a0c8debea60aa153f844879(movieClip);
						_roomMemberListButtons[num] = ce0ae1607c07b6bd6009ae6336b339b;
						goto IL_00e8;
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "Room Member itemSlot name wrong! Index:";
				array[1] = num;
				array[2] = " is bigger than sum: ";
				array[3] = _roomMemberListButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
				return true;
			}
			goto IL_00e8;
			IL_00e8:
			if (movieClip.name.StartsWith(FRIEND_PREFIX_NAME))
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
				int num2 = Convert.ToInt32(movieClip.name.Substring(FRIEND_PREFIX_NAME.Length, movieClip.name.Length - FRIEND_PREFIX_NAME.Length));
				if (num2 < _roomInvitationListButtons.Length)
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
					if (num2 >= 0)
					{
						cc25c1ee12c4b33340a4c33ba3a4275c9 cc25c1ee12c4b33340a4c33ba3a4275c = new cc25c1ee12c4b33340a4c33ba3a4275c9();
						cc25c1ee12c4b33340a4c33ba3a4275c.c130648b59a0c8debea60aa153f844879(movieClip);
						_roomInvitationListButtons[num2] = cc25c1ee12c4b33340a4c33ba3a4275c;
						goto IL_01c7;
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
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = "Room Friend List itemSlot name wrong! Index:";
				array2[1] = num2;
				array2[2] = " is bigger than sum: ";
				array2[3] = _roomInvitationListButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array2));
				return true;
			}
			goto IL_01c7;
			IL_01c7:
			if (movieClip.name.StartsWith(PLAYER_RECORD_PREFIX_NAME))
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
				int num3 = Convert.ToInt32(movieClip.name.Substring(PLAYER_RECORD_PREFIX_NAME.Length, movieClip.name.Length - PLAYER_RECORD_PREFIX_NAME.Length));
				if (num3 < _playerRecordListButtons.Length)
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
						c6ae57b6b0eaf6c226a8fff792fb808df c6ae57b6b0eaf6c226a8fff792fb808df = new c6ae57b6b0eaf6c226a8fff792fb808df();
						c6ae57b6b0eaf6c226a8fff792fb808df.c130648b59a0c8debea60aa153f844879(movieClip);
						_playerRecordListButtons[num3] = c6ae57b6b0eaf6c226a8fff792fb808df;
						goto IL_02ae;
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
				object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array3[0] = "Player Record List itemSlot name wrong! Index:";
				array3[1] = num3;
				array3[2] = " is bigger than sum: ";
				array3[3] = _playerRecordListButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array3));
				return true;
			}
			goto IL_02ae;
			IL_02ae:
			return false;
		}

		private void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		private void c729c1f528fd63f742b7ed54b2d87a6e9(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!mc_ListPanel.visible)
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
				mc_InstancePanel.visible = false;
				mc_Selected.visible = false;
				mc_InfoPanel.visible = false;
				mc_ListPanel.visible = true;
			}
			c591c47219c2da4f480868724bfea2264();
		}

		protected void c5a802ac1acd4f9d1f170a16edf8a453e()
		{
			Presence presence = LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c21e522aeeaf7bcca3d0ea44730a13b6d();
			if (presence == null)
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
				tf_RoomLevel.text = string.Empty;
				tf_RoomOwnerName.text = presence.mCharacterName;
				tf_RoomOwnerMatchCount.text = presence.mMatchCount.ToString();
				tf_RoomOwnerHonor.text = presence.mHonorPoint.ToString();
				tf_RoomOwnerKillDeath.text = presence.mKillCount + "/" + presence.mDeathCount;
				tf_RoomOwnerWinLose.text = presence.mWinCount + "/" + presence.mLossCount;
				return;
			}
		}

		private void c2ad3faebb0c8f5b27795460f6991f700(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (m_nInstanceId == -1)
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
				cefe421697a3bbbea5cbd44ad193a066d(m_nInstanceId, GamemodeType.GamemodeDeathmatch);
				return;
			}
		}

		private void c59e6848a91481a404c9d77688dc57acf(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (m_nInstanceId == -1)
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
				cefe421697a3bbbea5cbd44ad193a066d(m_nInstanceId, GamemodeType.GamemodeTeamDeathmatch);
				return;
			}
		}

		private void c93bde6c7c4aee5697582efa1e99449ba(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			m_nInstanceId = -1;
			mc_Selected.visible = false;
		}

		private void cb7e20120b2dc039ccc2e9644991e43dd(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!mc_ListPanel.visible)
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
				mc_ListPanel.visible = false;
				mc_Selected.visible = false;
				mc_InfoPanel.visible = false;
				mc_InstancePanel.visible = true;
				return;
			}
		}

		private void ca033a99a417cdf99b2aa61d2d8d558b7(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!mc_InfoPanel.visible)
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
				mc_InfoPanel.visible = false;
				mc_Selected.visible = false;
				mc_ListPanel.visible = false;
				mc_InstancePanel.visible = true;
				return;
			}
		}

		public void c591c47219c2da4f480868724bfea2264()
		{
			c5a802ac1acd4f9d1f170a16edf8a453e();
			if (mc_RoomPanel.visible)
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
				int num = LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().caa44e85b88b13372e89502b18c25780d();
				for (int i = 0; i < num; i++)
				{
					_roomMemberListButtons[i].c263a18e823d534fe933bf797fd17c221(i);
					_roomMemberListButtons[i].c150264a18c2cb408479d3f072cac8cc1 = true;
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
				for (int j = num; j < ROOM_MEMBER_TOTAL; j++)
				{
					_roomMemberListButtons[j].c150264a18c2cb408479d3f072cac8cc1 = false;
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
			if (!mc_ListPanel.visible)
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
				int num2 = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c338f75ed0138aa7c193523682e0a180e();
				for (int k = 0; k < num2; k++)
				{
					_roomInvitationListButtons[k].c263a18e823d534fe933bf797fd17c221(k);
					_roomInvitationListButtons[k].c150264a18c2cb408479d3f072cac8cc1 = true;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					for (int l = num2; l < FRIEND_TOTAL; l++)
					{
						_roomInvitationListButtons[l].c150264a18c2cb408479d3f072cac8cc1 = false;
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

		private void cefe421697a3bbbea5cbd44ad193a066d(int c717dab0494f3f0f159b8bd8bc7c8b729, GamemodeType c7c285f21497bec76d425ba4a0a524b46)
		{
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c487629df5d3f6240821140b3e6ca8783())
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
				LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c3f65cc88af0ef84cc42196bbe25136c4(c7c285f21497bec76d425ba4a0a524b46, c717dab0494f3f0f159b8bd8bc7c8b729);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().m_gameMode = c7c285f21497bec76d425ba4a0a524b46;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c9d057c2188e7d2872aa3ec71517e92ae = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		private void c4b82fe6e9de8d26638e77f24b3d74b2b(int cdb1e09e6b4d62165e7b6544e99a268f0)
		{
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
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
				m_nInstanceId = cdb1e09e6b4d62165e7b6544e99a268f0;
				mc_Selected.visible = true;
				if (cdb1e09e6b4d62165e7b6544e99a268f0 == 1001)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							mc_DeathBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
							mc_TeamDeathBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
							return;
						}
					}
				}
				mc_DeathBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				mc_TeamDeathBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				return;
			}
		}

		private void c750bc42952f6119b707d855fcff097b7()
		{
			mc_Selected.visible = false;
		}

		public void c5391a4d4b379929bb2d2d16aded03f79()
		{
			if (mc_InfoPanel.visible)
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
				for (int i = 0; i < _playerRecordListButtons.Length; i++)
				{
					_playerRecordListButtons[i].c150264a18c2cb408479d3f072cac8cc1 = false;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					mc_Selected.visible = false;
					mc_InstancePanel.visible = false;
					mc_ListPanel.visible = false;
					mc_InfoPanel.visible = true;
					return;
				}
			}
		}

		public void c84e874fe933f0054c408cf6d29002635(int c5dfde30d8784694fb9999709d290e6c4)
		{
			if (c5dfde30d8784694fb9999709d290e6c4 != LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().m_nTargetCharacterId)
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
			if (!mc_InfoPanel.visible)
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
			for (int i = 0; i < _playerRecordListButtons.Length - 1; i++)
			{
				_playerRecordListButtons[i].c150264a18c2cb408479d3f072cac8cc1 = true;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				_playerRecordListButtons[0].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Total")), string.Empty, true);
				_playerRecordListButtons[1].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_TotalMatches")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c6619468f0932e2230c557ba2cd7304ef(c5dfde30d8784694fb9999709d290e6c4).ToString());
				_playerRecordListButtons[2].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_HornorValue")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().ca04453b994172f72867b29f29524d679(c5dfde30d8784694fb9999709d290e6c4).ToString());
				_playerRecordListButtons[3].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Kill/Death")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c20779a4b227671104ddab39ea26f409c(c5dfde30d8784694fb9999709d290e6c4));
				_playerRecordListButtons[4].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Win/Lose")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c5247e943f91eab848d503f98588e1394(c5dfde30d8784694fb9999709d290e6c4));
				_playerRecordListButtons[5].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_DeathMatch")), string.Empty, true);
				_playerRecordListButtons[6].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_TotalMatch")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().ce574ea8e3af3f348b2d6bf384b7bcc47(c5dfde30d8784694fb9999709d290e6c4).ToString());
				_playerRecordListButtons[7].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_HornorValue")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c41b3d32fd607d52a1df96c223a79b063(c5dfde30d8784694fb9999709d290e6c4).ToString());
				_playerRecordListButtons[8].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Kill/Death")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cff276e47b032c5207a61a940cdae6a92(c5dfde30d8784694fb9999709d290e6c4));
				_playerRecordListButtons[9].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Win/Lose")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cb2292c0a3565071b2f7b68f23c300b30(c5dfde30d8784694fb9999709d290e6c4));
				_playerRecordListButtons[10].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_TeamMatch")), string.Empty, true);
				_playerRecordListButtons[11].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_TotalMatch")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c8dcde2232ad460a011b8ad821e5a9272(c5dfde30d8784694fb9999709d290e6c4).ToString());
				_playerRecordListButtons[12].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_HornorValue")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c087b8770187c88bb321cf20e82562b03(c5dfde30d8784694fb9999709d290e6c4).ToString());
				_playerRecordListButtons[13].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Kill/Death")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c9d9fa7b15e5679d955b99ae26e527c7c(c5dfde30d8784694fb9999709d290e6c4));
				_playerRecordListButtons[14].c2786f1425a63a64bd01b4ba445fb8ba9(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_Win/Lose")), LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cfd32b145462aafa7dd1957f8c1efd961(c5dfde30d8784694fb9999709d290e6c4));
				_playerRecordListButtons[15].c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}

		private void cab292bd2642c8246c318171e0d38b7f0(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Relic Alcaid");
			c4b82fe6e9de8d26638e77f24b3d74b2b(1001);
		}

		private void c997adcc0c5c3e1e446104074859028a9(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Final Command");
			c4b82fe6e9de8d26638e77f24b3d74b2b(1002);
		}

		private void c31b386dc3710b18d082ad1ea50b8e929(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Waterfall");
			c4b82fe6e9de8d26638e77f24b3d74b2b(1003);
		}

		private void c9166a3c6aa5ddf68cf31db6bb43881da(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Valley of weeping");
			c4b82fe6e9de8d26638e77f24b3d74b2b(1006);
		}

		private void c6c06b336616475a9763116899a3cf53b(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
		}

		private void c55c4d55e2f1e7b74dc238bf5b0780360(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
		}
	}

	private PvPFlowPanel _pvpFlowPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("pvp_match_making.swf", "movie_matchmaking", c6bc9199ec2eb0da633fb507af75748ef);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_pvpFlowPanel);
		_pvpFlowPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("pvp_match_making.swf");
	}

	private void c6bc9199ec2eb0da633fb507af75748ef(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_pvpFlowPanel = new PvPFlowPanel();
		_pvpFlowPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_pvpFlowPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (c8be1fcd630e5fe96821376d111325750)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c76154b5d193e30b53344242a665f1fe4())
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
				if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
					if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
				}
			}
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c76154b5d193e30b53344242a665f1fe4())
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
				if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
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
					if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943() < LevelingManager.PVP_UNLOCK_LEVEL)
					{
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_pvpFlowPanel);
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c76154b5d193e30b53344242a665f1fe4())
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
				LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cb155f2586fade9c6703c740916aacf6d();
			}
			else
			{
				LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c5bb97cae178d4b25c1e804580f327373();
			}
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c6882cd92015bfcab69976c46b09f2786())
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cd3edf4455690dc2bca805c557d5cfffd();
			}
		}
		else
		{
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_pvpFlowPanel);
		}
		_pvpFlowPanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
	}

	public override void c263a18e823d534fe933bf797fd17c221()
	{
		if (_pvpFlowPanel == null)
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
			_pvpFlowPanel.c591c47219c2da4f480868724bfea2264();
			return;
		}
	}

	public override void c84e874fe933f0054c408cf6d29002635(int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (!_pvpFlowPanel.c150264a18c2cb408479d3f072cac8cc1)
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
			_pvpFlowPanel.c84e874fe933f0054c408cf6d29002635(c5dfde30d8784694fb9999709d290e6c4);
			return;
		}
	}

	public override void c5391a4d4b379929bb2d2d16aded03f79()
	{
		if (!_pvpFlowPanel.c150264a18c2cb408479d3f072cac8cc1)
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
			_pvpFlowPanel.c5391a4d4b379929bb2d2d16aded03f79();
			return;
		}
	}
}
