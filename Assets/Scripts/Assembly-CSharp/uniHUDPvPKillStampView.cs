using System.Collections.Generic;
using A;
using Core;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDPvPKillStampView : HUDPvPKillStampView
{
	public class KillStampHistoryItem : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mc_ItemInfo;

		protected MovieClip mc_Total;

		protected MovieClip mc_RedStamp;

		protected MovieClip mc_BlueStamp;

		protected MovieClip mc_GreenStamp;

		protected TextField tf_Title;

		protected TextField tf_Content;

		private bool m_bPlayingFadeout;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_ItemInfo = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_ItemInfo == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: KillStampHistoryItem onInit() 'mc_ItemInfo' is null! KillStampHistoryItem won't work!!!");
						return;
					}
				}
			}
			mc_Total = mc_ItemInfo.getChildByName<MovieClip>("mc_total");
			mc_RedStamp = mc_Total.getChildByName<MovieClip>("mc_red");
			mc_BlueStamp = mc_Total.getChildByName<MovieClip>("mc_blue");
			mc_GreenStamp = mc_Total.getChildByName<MovieClip>("mc_green");
			mc_ItemInfo.gotoAndStop("fadeoutEnd");
			tf_Title = mc_Total.getChildByName<TextField>("tf_Title");
			tf_Content = mc_Total.getChildByName<TextField>("tf_Content");
		}

		public void cedf24d0882cf193b727925a6e497eec5(KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481, bool c09cca5eafd4fdb6dcb625d1475568049, bool c9f7c402f1ebc33034fcb504a965dc666, bool c214eb97a4f62e21be4c73db2476e2f9e)
		{
			if (!c214eb97a4f62e21be4c73db2476e2f9e)
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
						c741744f5bb21161ef9b9787a2e110c43();
						return;
					}
				}
			}
			mc_ItemInfo.visible = true;
			switch (c3dd63cbbc9b91e00848374d9fbadeb4a)
			{
			case KillStampType.Blue:
				mc_RedStamp.visible = false;
				mc_GreenStamp.visible = false;
				mc_BlueStamp.visible = true;
				break;
			case KillStampType.Green:
				mc_RedStamp.visible = false;
				mc_BlueStamp.visible = false;
				mc_GreenStamp.visible = true;
				break;
			case KillStampType.Red:
				mc_RedStamp.gotoAndStop(c912c4e044d875453592ee1f909d9f481.ToString());
				mc_RedStamp.visible = true;
				mc_BlueStamp.visible = false;
				mc_GreenStamp.visible = false;
				break;
			}
			tf_Title.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c912c4e044d875453592ee1f909d9f481.ToString() + "_Name"));
			tf_Content.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c912c4e044d875453592ee1f909d9f481.ToString() + "_Des"));
			if (c09cca5eafd4fdb6dcb625d1475568049)
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
				mc_ItemInfo.gotoAndPlay("In");
			}
			else if (!c9f7c402f1ebc33034fcb504a965dc666)
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
				mc_ItemInfo.gotoAndStop("normal");
			}
			else
			{
				c741744f5bb21161ef9b9787a2e110c43();
			}
			m_bPlayingFadeout = false;
		}

		public void Update(int index)
		{
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPKillStampView>().c3b3dabaf53de10c093171899c8cf1ebc(index))
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
				if (m_bPlayingFadeout)
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
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPKillStampView>().c545b62695c10a2d217ace6482461f480(index))
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
						m_bPlayingFadeout = true;
						mc_ItemInfo.addFrameScript("fadeoutEnd", c64731ac8bb5cc084887d0eaa39fdee64);
						mc_ItemInfo.gotoAndPlay("fadeout");
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPKillStampView>().ceb2a336a7402b963f4c512e2e1cb652f(index);
						return;
					}
				}
			}
		}

		protected void c64731ac8bb5cc084887d0eaa39fdee64(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_ItemInfo.removeFrameScript("fadeoutEnd", c64731ac8bb5cc084887d0eaa39fdee64);
			m_bPlayingFadeout = false;
		}

		public void c741744f5bb21161ef9b9787a2e110c43()
		{
			m_bPlayingFadeout = false;
			if (mc_ItemInfo != null)
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
						mc_ItemInfo.gotoAndStop("fadeoutEnd");
						return;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "NULL!!!!!!");
		}
	}

	protected class PvPKillStampHistoryPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		protected List<KillStampHistoryItem> m_HistoryItemList = new List<KillStampHistoryItem>();

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: PvPKillStampHistoryPanel onInit() 'mc_root' is null! PvPKillStampHistoryPanel won't work!!!");
						return;
					}
				}
			}
			m_HistoryItemList.Clear();
			KillStampHistoryItem killStampHistoryItem = new KillStampHistoryItem();
			killStampHistoryItem.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("line_1"));
			KillStampHistoryItem killStampHistoryItem2 = new KillStampHistoryItem();
			killStampHistoryItem2.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("line_2"));
			KillStampHistoryItem killStampHistoryItem3 = new KillStampHistoryItem();
			killStampHistoryItem3.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("line_3"));
			KillStampHistoryItem killStampHistoryItem4 = new KillStampHistoryItem();
			killStampHistoryItem4.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("line_4"));
			m_HistoryItemList.Add(killStampHistoryItem);
			m_HistoryItemList.Add(killStampHistoryItem2);
			m_HistoryItemList.Add(killStampHistoryItem3);
			m_HistoryItemList.Add(killStampHistoryItem4);
		}

		public void Update()
		{
			for (int i = 0; i < m_HistoryItemList.Count; i++)
			{
				m_HistoryItemList[i].Update(i);
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

		public void cedf24d0882cf193b727925a6e497eec5(int c5612a459a84ffdb41c885401433cd62d, KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481, bool c09cca5eafd4fdb6dcb625d1475568049, bool c9f7c402f1ebc33034fcb504a965dc666 = false, bool c214eb97a4f62e21be4c73db2476e2f9e = true)
		{
			if (m_HistoryItemList[c5612a459a84ffdb41c885401433cd62d] == null)
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
				m_HistoryItemList[c5612a459a84ffdb41c885401433cd62d].cedf24d0882cf193b727925a6e497eec5(c3dd63cbbc9b91e00848374d9fbadeb4a, c912c4e044d875453592ee1f909d9f481, c09cca5eafd4fdb6dcb625d1475568049, c9f7c402f1ebc33034fcb504a965dc666, c214eb97a4f62e21be4c73db2476e2f9e);
				return;
			}
		}
	}

	protected class PvPKillStampPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private MovieClip mc_CurrentStamp;

		private MovieClip mc_RedStamp;

		private MovieClip mc_GreenStamp;

		private MovieClip mc_BlueStamp;

		private MovieClip mc_RedContent;

		private bool m_bShowingKillStamp;

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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: PvPKillStampPanel onInit() 'mc_root' is null! PvPKillStampPanel won't work!!!");
						return;
					}
				}
			}
			mc_RedStamp = mc_root.getChildByName<MovieClip>("mc_redStamp");
			mc_GreenStamp = mc_root.getChildByName<MovieClip>("mc_greenStamp");
			mc_BlueStamp = mc_root.getChildByName<MovieClip>("mc_blueStamp");
			mc_RedContent = mc_RedStamp.getChildByName<MovieClip>("mc_RedContent");
			mc_RedStamp.gotoAndStop("end");
			mc_GreenStamp.stopAll();
			mc_BlueStamp.stopAll();
			mc_root.addEventListener(CEvent.ENTER_FRAME, c12b196ef16d3d89b666906481f435d35);
		}

		protected void c12b196ef16d3d89b666906481f435d35(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (m_bShowingKillStamp)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPKillStampView>().cbeb688edaa441785de1fc7ac739eb868();
				return;
			}
		}

		public void cdd0cd5262d80c1cc266da986bdbb86b0(KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481)
		{
			mc_RedStamp.removeFrameScript("end", c64db779f55903e33f60d927d3b9cdbb9);
			mc_GreenStamp.removeFrameScript("end", c64db779f55903e33f60d927d3b9cdbb9);
			mc_BlueStamp.removeFrameScript("end", c64db779f55903e33f60d927d3b9cdbb9);
			switch (c3dd63cbbc9b91e00848374d9fbadeb4a)
			{
			case KillStampType.Red:
				mc_CurrentStamp = mc_RedStamp;
				mc_GreenStamp.gotoAndStop(1);
				mc_BlueStamp.gotoAndStop(1);
				mc_RedContent.gotoAndStop(c912c4e044d875453592ee1f909d9f481.ToString());
				break;
			case KillStampType.Blue:
				mc_CurrentStamp = mc_BlueStamp;
				mc_RedStamp.gotoAndStop("end");
				mc_GreenStamp.gotoAndStop(1);
				break;
			case KillStampType.Green:
				mc_CurrentStamp = mc_GreenStamp;
				mc_RedStamp.gotoAndStop("end");
				mc_BlueStamp.gotoAndStop(1);
				break;
			default:
				mc_CurrentStamp = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
				break;
			}
			if (mc_CurrentStamp == null)
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
				m_bShowingKillStamp = true;
				mc_CurrentStamp.addFrameScript("end", c64db779f55903e33f60d927d3b9cdbb9);
				mc_CurrentStamp.gotoAndPlay(1);
				return;
			}
		}

		protected void c64db779f55903e33f60d927d3b9cdbb9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			m_bShowingKillStamp = false;
		}
	}

	private PvPKillStampPanel _KillStampPanel;

	private PvPKillStampHistoryPanel _KillStampHistoryPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PVP_stamp.swf", "Mc_history_line", caacf7a99f05706502e1564eace93324c);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PVP_stamp.swf", "Mc_bigstamp", cc7adb08f6a9cd305d0ec500225734694);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_KillStampPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_KillStampHistoryPanel);
		_KillStampPanel = null;
		_KillStampHistoryPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("PVP_stamp.swf");
	}

	private void cc7adb08f6a9cd305d0ec500225734694(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_KillStampPanel = new PvPKillStampPanel();
		_KillStampPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_KillStampPanel);
	}

	private void caacf7a99f05706502e1564eace93324c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_KillStampHistoryPanel = new PvPKillStampHistoryPanel();
		_KillStampHistoryPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_KillStampHistoryPanel);
	}

	public override void cdd0cd5262d80c1cc266da986bdbb86b0(KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481)
	{
		base.cdd0cd5262d80c1cc266da986bdbb86b0(c3dd63cbbc9b91e00848374d9fbadeb4a, c912c4e044d875453592ee1f909d9f481);
		if (_KillStampPanel == null)
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
			_KillStampPanel.cdd0cd5262d80c1cc266da986bdbb86b0(c3dd63cbbc9b91e00848374d9fbadeb4a, c912c4e044d875453592ee1f909d9f481);
			return;
		}
	}

	public override void Update(float fDeltaTime)
	{
		base.Update(fDeltaTime);
		if (_KillStampHistoryPanel == null)
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
			_KillStampHistoryPanel.Update();
			return;
		}
	}

	public override void cedf24d0882cf193b727925a6e497eec5(int c5612a459a84ffdb41c885401433cd62d, KillStampType c3dd63cbbc9b91e00848374d9fbadeb4a, ScoringActionType c912c4e044d875453592ee1f909d9f481, bool c09cca5eafd4fdb6dcb625d1475568049, bool c9f7c402f1ebc33034fcb504a965dc666 = false, bool c214eb97a4f62e21be4c73db2476e2f9e = true)
	{
		if (_KillStampHistoryPanel == null)
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
			_KillStampHistoryPanel.cedf24d0882cf193b727925a6e497eec5(c5612a459a84ffdb41c885401433cd62d, c3dd63cbbc9b91e00848374d9fbadeb4a, c912c4e044d875453592ee1f909d9f481, c09cca5eafd4fdb6dcb625d1475568049, c9f7c402f1ebc33034fcb504a965dc666, c214eb97a4f62e21be4c73db2476e2f9e);
			return;
		}
	}
}
