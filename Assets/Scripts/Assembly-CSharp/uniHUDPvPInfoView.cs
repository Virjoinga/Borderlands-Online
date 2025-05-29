using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDPvPInfoView : HUDPvPInfoView
{
	protected class KillingStampIcon : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_StampIcon;

		public MovieClip mc_RedStamp;

		public MovieClip mc_BlueStamp;

		public MovieClip mc_GreenStamp;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_StampIcon != null)
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
							return mc_StampIcon.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mc_StampIcon == null)
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
					mc_RedStamp.visible = value;
					mc_BlueStamp.visible = value;
					mc_GreenStamp.visible = value;
					return;
				}
			}
		}

		public void ce13d3cdd9d187c1d08b123cb2ee56943(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
		{
			if (cbe9ca8ddb3cdc2312e6ff8411b2db2c8 == null)
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
				c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
				mc_StampIcon = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
				mc_RedStamp = mc_StampIcon.getChildByName<MovieClip>("mc_red");
				mc_BlueStamp = mc_StampIcon.getChildByName<MovieClip>("mc_blue");
				mc_GreenStamp = mc_StampIcon.getChildByName<MovieClip>("mc_green");
				return;
			}
		}

		public void cca2f3c1074cb80ece7240c6723611e03(ScoringActionType c3dd63cbbc9b91e00848374d9fbadeb4a)
		{
			switch (c3dd63cbbc9b91e00848374d9fbadeb4a)
			{
			case ScoringActionType.BasicSuicide:
				mc_RedStamp.visible = false;
				mc_GreenStamp.visible = false;
				mc_BlueStamp.visible = true;
				break;
			case ScoringActionType.BasicAssist:
				mc_RedStamp.visible = false;
				mc_BlueStamp.visible = false;
				mc_GreenStamp.visible = true;
				break;
			case ScoringActionType.BonusHeadShot:
			case ScoringActionType.BonusCritical:
			case ScoringActionType.BonusMelee:
			case ScoringActionType.BonusLastKill:
			case ScoringActionType.BonusRevenge:
			case ScoringActionType.BonusTurretKill:
			case ScoringActionType.BonusFirebirdKill:
			case ScoringActionType.BonusPunchKill:
			case ScoringActionType.BonusMarkedKill:
			case ScoringActionType.BonusGrenadesKill:
				mc_RedStamp.gotoAndStop(c3dd63cbbc9b91e00848374d9fbadeb4a.ToString());
				mc_RedStamp.visible = true;
				mc_BlueStamp.visible = false;
				mc_GreenStamp.visible = false;
				break;
			case ScoringActionType.BonusKillStreak:
			case ScoringActionType.BonusDominating:
			case ScoringActionType.BonusOneShotTwoKills:
			case ScoringActionType.BonusFirstBlood:
			case ScoringActionType.BonusTeamWin:
				break;
			}
		}
	}

	protected class PVPHudScreen : c196099a1254db61d3be10d70e14e7422
	{
		public enum HudState
		{
			Raw = 0,
			Init = 1,
			Start = 2,
			Game = 3,
			Tab = 4,
			End = 5,
			WrapUp = 6
		}

		private const int NUM_OF_ROWS = 8;

		private const float TIME = 5f;

		private const float START_COUNT_DOWN = 30f;

		public KillInfoItemContainer m_KillInfoItemContainer;

		protected int m_iLastFrameKillInfoCount;

		protected bool m_bOnKillInfoFadeOutAnima;

		private MovieClip m_targetInfo;

		private MovieClip m_wrapupPanel;

		private MovieClip m_wrapupContainer;

		private MovieClip m_tabPanel;

		private MovieClip m_resultInfoPanel;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b m_backToLobbyButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b m_matchMakingButton;

		private UIMapDisplayManager.UIMapRoot m_mapRoot;

		private MovieClip m_resultContainer;

		private HudState m_state = HudState.Init;

		private float m_startTime;

		private float m_triggerTime;

		public uniHUDPvPInfoView m_rootView;

		public bool isInited;

		private float m_CountDownTime = 65f;

		private float m_CountDownInterval = 5f;

		private int STAMP_TOTAL = 15;

		private int m_StampCount;

		private int m_nCurretnStamp;

		protected KillingStampIcon[] m_StampIcons;

		private TextField tf_CountDown;

		private MovieClip mc_Rank;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map16;

		public HudState cdd8b1f9a423aaaa710988ac604ba4868
		{
			get
			{
				return m_state;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			if (ca37fcdce7d4937b60735f4033eb55695 == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: HUDPVPInfo onInit() '_relatedMovieClip' is null! InstancePanel won't work!!!");
						return;
					}
				}
			}
			ce528330af391600e74c8c4eaf0c5bc3a();
			isInited = true;
		}

		protected override bool OnWidgetInitialized(ref MovieClip mc, Type widgetType)
		{
			bool result = false;
			string name = mc.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map16 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(5);
					dictionary.Add("mcTargetInfo", 0);
					dictionary.Add("mcKillingInfoContainer", 1);
					dictionary.Add("mcResultInfo", 2);
					dictionary.Add("mcWrapup", 3);
					dictionary.Add("mcTab", 4);
					_003C_003Ef__switch_0024map16 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map16.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
					{
						m_targetInfo = new MovieClip();
						m_targetInfo = mc;
						m_targetInfo.visible = false;
						m_targetInfo.addFrameScript("animEnd", c23be6eda07a842c2d568569131375cc6);
						m_targetInfo.gotoAndStop(1);
						TextField childByName2 = m_targetInfo.getChildByName<MovieClip>("mc_root").getChildByName<TextField>("tf_Mode");
						TextField childByName3 = m_targetInfo.getChildByName<MovieClip>("mc_root").getChildByName<TextField>("tf_Rule");
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
							childByName2.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_TeamDeathMatch"));
							childByName3.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVPRule_TeamDeathMatch"));
						}
						else
						{
							childByName2.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_DeathMatch"));
							childByName3.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVPRule_DeathMatch"));
						}
						result = true;
						break;
					}
					case 1:
						m_KillInfoItemContainer = new KillInfoItemContainer();
						m_KillInfoItemContainer.c130648b59a0c8debea60aa153f844879(mc);
						result = true;
						break;
					case 2:
						m_resultInfoPanel = new MovieClip();
						m_resultInfoPanel = mc;
						m_resultInfoPanel.stopAll();
						m_resultInfoPanel.visible = false;
						m_resultContainer = m_resultInfoPanel.getChildByName<MovieClip>("mcContainer");
						result = true;
						break;
					case 3:
					{
						m_wrapupPanel = new MovieClip();
						m_wrapupPanel = mc;
						m_wrapupPanel.visible = false;
						m_wrapupContainer = new MovieClip();
						m_wrapupContainer = mc.getChildByName<MovieClip>("mcContent");
						m_backToLobbyButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						m_backToLobbyButton.c130648b59a0c8debea60aa153f844879(m_wrapupContainer.getChildByName<MovieClip>("mcToLobbyButton"));
						m_backToLobbyButton.addEventListener(MouseEvent.CLICK, cf3f4e24a1208169c2b49ebbb6ced457e);
						m_backToLobbyButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						m_matchMakingButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						m_matchMakingButton.c130648b59a0c8debea60aa153f844879(m_wrapupContainer.getChildByName<MovieClip>("mcStartingButton"));
						m_matchMakingButton.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						c069ea14a3197ae8a805282023a2220d7();
						MovieClip childByName4 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot1");
						childByName4.visible = false;
						MovieClip childByName5 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2");
						childByName5.visible = false;
						result = true;
						break;
					}
					case 4:
					{
						m_tabPanel = new MovieClip();
						m_tabPanel = mc;
						m_tabPanel.visible = false;
						MovieClip childByName = mc.getChildByName<MovieClip>("mcMiniMap");
						if (childByName != null)
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
							m_mapRoot = new UIMapDisplayManager.UIMapRoot();
							m_mapRoot.c4ff0d4ba3eeaed831ca975de7848acce = UIMapDisplayManager.MapCategoryTag.PVPMap;
							m_mapRoot.c729bd42662457ecf184ce15af0942cbe = true;
							m_mapRoot.cd61d9f244ef37bfca642c090f0dd57af = true;
							m_mapRoot.c130648b59a0c8debea60aa153f844879(childByName);
							UIMapDisplayManager.c71f6ce28731edfd43c976fbd57c57bea().c79b68441494b2679b55be7197f656be8(m_mapRoot);
						}
						result = true;
						break;
					}
					}
				}
			}
			return result;
		}

		public void ce421ed184b36b13e7072feb7da58f0ae()
		{
			if (m_backToLobbyButton != null)
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
				m_backToLobbyButton.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			}
			c4cb9d159ab22ab85b94d483809a7e9e2();
		}

		protected void c4cb9d159ab22ab85b94d483809a7e9e2()
		{
			if (LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c1b6f1885552cdca583b20160d9e865b8() != 0)
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
				MovieClip childByName = m_wrapupContainer.getChildByName<MovieClip>("mc_slot1");
				childByName.visible = true;
				ItemDNA itemDNA = LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c0b887ca3b7074404bde04f358415edb8(0);
				if (itemDNA != null)
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
					MovieClip childByName2 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("mc_loading");
					childByName2.visible = false;
					if (itemDNA.m_type == ItemType.Material)
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
						MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(itemDNA.m_materialType);
						MovieClip movieClip2 = movieClip.newInstance();
						movieClip2.name = "icon";
						MovieClip childByName3 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons");
						childByName3.stopAll();
						childByName3.addChild(movieClip2);
					}
					else if (itemDNA.m_type == ItemType.Money)
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
						MovieClip movieClip3 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c28ee12a3e8557af117e75c0f0133c2f3();
						MovieClip movieClip4 = movieClip3.newInstance();
						movieClip4.name = "icon";
						MovieClip childByName4 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
						childByName4.stopAll();
						childByName4.addChild(movieClip4);
					}
					else
					{
						Texture2D cf83e762e4368c5dedaab3e73ad69452e = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA);
						c7beefc397f483dc0b72dcd3e6bdcf929 c7beefc397f483dc0b72dcd3e6bdcf = new c7beefc397f483dc0b72dcd3e6bdcf929();
						c7beefc397f483dc0b72dcd3e6bdcf.c130648b59a0c8debea60aa153f844879(m_wrapupContainer.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons"));
						c7beefc397f483dc0b72dcd3e6bdcf.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e);
					}
				}
			}
			if (LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c1b6f1885552cdca583b20160d9e865b8(true) == 0)
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
				MovieClip childByName5 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2");
				childByName5.visible = true;
				ItemDNA itemDNA2 = LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c0b887ca3b7074404bde04f358415edb8(0, true);
				if (itemDNA2 == null)
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
					MovieClip childByName6 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("mc_loading");
					childByName6.visible = false;
					if (itemDNA2.m_type == ItemType.Material)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
							{
								MovieClip movieClip5 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(itemDNA2.m_materialType);
								MovieClip movieClip6 = movieClip5.newInstance();
								movieClip6.name = "icon";
								MovieClip childByName7 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
								childByName7.stopAll();
								childByName7.addChild(movieClip6);
								return;
							}
							}
						}
					}
					if (itemDNA2.m_type == ItemType.Money)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
							{
								MovieClip movieClip7 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c28ee12a3e8557af117e75c0f0133c2f3();
								MovieClip movieClip8 = movieClip7.newInstance();
								movieClip8.name = "icon";
								MovieClip childByName8 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
								childByName8.stopAll();
								childByName8.addChild(movieClip8);
								return;
							}
							}
						}
					}
					Texture2D cf83e762e4368c5dedaab3e73ad69452e2 = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA2);
					c7beefc397f483dc0b72dcd3e6bdcf929 c7beefc397f483dc0b72dcd3e6bdcf2 = new c7beefc397f483dc0b72dcd3e6bdcf929();
					c7beefc397f483dc0b72dcd3e6bdcf2.c130648b59a0c8debea60aa153f844879(m_wrapupContainer.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons"));
					c7beefc397f483dc0b72dcd3e6bdcf2.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e2);
					return;
				}
			}
		}

		protected void c069ea14a3197ae8a805282023a2220d7()
		{
			m_StampIcons = new KillingStampIcon[STAMP_TOTAL];
			for (int i = 0; i < STAMP_TOTAL; i++)
			{
				MovieClip childByName = m_wrapupContainer.getChildByName<MovieClip>("stamp" + i);
				if (childByName == null)
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				KillingStampIcon killingStampIcon = new KillingStampIcon();
				killingStampIcon.ce13d3cdd9d187c1d08b123cb2ee56943(childByName);
				m_StampIcons[i] = killingStampIcon;
			}
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

		protected void cf66b3f5ad0d81464dac4aec75d8bef94()
		{
			for (int i = 0; i < m_StampIcons.Length; i++)
			{
				m_StampIcons[i].c150264a18c2cb408479d3f072cac8cc1 = false;
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

		protected void cc98e52440b77159144d14a0afe75cbf8()
		{
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(true);
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
		}

		private void cf3f4e24a1208169c2b49ebbb6ced457e(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			cc98e52440b77159144d14a0afe75cbf8();
		}

		private void c9be719d8344f1558dad30d28ba9a9521(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae)
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
				cefe421697a3bbbea5cbd44ad193a066d();
				return;
			}
		}

		public void c17989b93d3d0102e811acd54b349c39f()
		{
			m_state = HudState.End;
			ce528330af391600e74c8c4eaf0c5bc3a();
		}

		private void cd15e3e31bae933869c71fbd3cd76923a(float cad9f703d862495149cd6bddd080f050b = 5f)
		{
			if (ca37fcdce7d4937b60735f4033eb55695.hasEventListener(CEvent.ENTER_FRAME))
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
				ca37fcdce7d4937b60735f4033eb55695.removeEventListener(CEvent.ENTER_FRAME, c09950cc86f866e71a4dc5e005e5e2eb3);
			}
			m_startTime = Time.time;
			m_triggerTime = cad9f703d862495149cd6bddd080f050b;
			ca37fcdce7d4937b60735f4033eb55695.addEventListener(CEvent.ENTER_FRAME, c09950cc86f866e71a4dc5e005e5e2eb3);
		}

		private void c09950cc86f866e71a4dc5e005e5e2eb3(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			if (!(Time.time - m_startTime > m_triggerTime))
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
				ca37fcdce7d4937b60735f4033eb55695.removeEventListener(CEvent.ENTER_FRAME, c09950cc86f866e71a4dc5e005e5e2eb3);
				switch (m_state)
				{
				case HudState.Start:
					m_state = HudState.Game;
					ce528330af391600e74c8c4eaf0c5bc3a();
					break;
				case HudState.End:
					m_state = HudState.WrapUp;
					ce528330af391600e74c8c4eaf0c5bc3a();
					break;
				case HudState.WrapUp:
					break;
				case HudState.Game:
				case HudState.Tab:
					break;
				}
				return;
			}
		}

		private void c23be6eda07a842c2d568569131375cc6(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			m_state = HudState.Game;
			ce528330af391600e74c8c4eaf0c5bc3a();
		}

		private void ca9be004ddcc7c41622a9b057affce5f6(MovieClip c3b25312b3b4868d181e116bb93592519, StatisticsManager.SessionStats cead7d16e6dad2d06a4663d3bd82846bb)
		{
			if (cead7d16e6dad2d06a4663d3bd82846bb == null)
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
						return;
					}
				}
			}
			int num = -1;
			StatisticsManager.StatSheet[] array = cead7d16e6dad2d06a4663d3bd82846bb.m_statsSheets.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].m_isTeam)
				{
					continue;
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
				if (!(array[i].m_name == c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409()))
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
				num = array[i].m_teamId;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "Before sort:" + m_state);
				for (int j = 0; j < array.Length; j++)
				{
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
					array2[0] = "Is team:";
					array2[1] = array[j].m_isTeam;
					array2[2] = " Name:";
					array2[3] = array[j].m_name;
					array2[4] = " level:";
					array2[5] = array[j].m_level;
					array2[6] = " team:";
					array2[7] = array[j].m_teamId;
					array2[8] = " score:";
					array2[9] = array[j].m_score;
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array2));
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					Array.Sort(array, delegate(StatisticsManager.StatSheet c2993f6f258fe4579223a84a5bae0ed06, StatisticsManager.StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa)
					{
						if (c2993f6f258fe4579223a84a5bae0ed06.m_isTeam)
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
							if (c568f0fb646e0f9df3ef10d50dec7cdaa.m_isTeam)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										return 0;
									}
								}
							}
						}
						if (c2993f6f258fe4579223a84a5bae0ed06.m_isTeam)
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
							if (!c568f0fb646e0f9df3ef10d50dec7cdaa.m_isTeam)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return 1;
									}
								}
							}
						}
						if (!c2993f6f258fe4579223a84a5bae0ed06.m_isTeam)
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
							if (c568f0fb646e0f9df3ef10d50dec7cdaa.m_isTeam)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return -1;
									}
								}
							}
						}
						if (!c2993f6f258fe4579223a84a5bae0ed06.m_isTeam)
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
							if (!c568f0fb646e0f9df3ef10d50dec7cdaa.m_isTeam)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
													if (c2993f6f258fe4579223a84a5bae0ed06.m_teamId == c568f0fb646e0f9df3ef10d50dec7cdaa.m_teamId)
													{
														while (true)
														{
															switch (7)
															{
															case 0:
																break;
															default:
																return cead7d16e6dad2d06a4663d3bd82846bb.c7eb206db14d8da3c4f26d5579f983539(c2993f6f258fe4579223a84a5bae0ed06, c568f0fb646e0f9df3ef10d50dec7cdaa);
															}
														}
													}
													return c568f0fb646e0f9df3ef10d50dec7cdaa.m_teamId - c2993f6f258fe4579223a84a5bae0ed06.m_teamId;
												}
											}
										}
										return cead7d16e6dad2d06a4663d3bd82846bb.c7eb206db14d8da3c4f26d5579f983539(c2993f6f258fe4579223a84a5bae0ed06, c568f0fb646e0f9df3ef10d50dec7cdaa);
									}
								}
							}
						}
						return 0;
					});
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "After sort:");
					for (int k = 0; k < array.Length; k++)
					{
						object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
						array3[0] = "Is team:";
						array3[1] = array[k].m_isTeam;
						array3[2] = " Name:";
						array3[3] = array[k].m_name;
						array3[4] = " level:";
						array3[5] = array[k].m_level;
						array3[6] = " team:";
						array3[7] = array[k].m_teamId;
						array3[8] = " score:";
						array3[9] = array[k].m_score;
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array3));
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						int num2 = 0;
						for (int l = 0; l < 8; l++)
						{
							string name = "mcRow" + (num2 + 1);
							MovieClip childByName = c3b25312b3b4868d181e116bb93592519.getChildByName<MovieClip>(name);
							childByName.visible = false;
							if (l > num2)
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
								name = "mcRow" + (l + 1);
								MovieClip childByName2 = c3b25312b3b4868d181e116bb93592519.getChildByName<MovieClip>(name);
								childByName2.visible = false;
							}
							StatisticsManager.StatSheet statSheet;
							if (childByName != null)
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
								if (l < array.Length)
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
									if (array[l].m_isTeam)
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
									statSheet = array[l];
									int c804e1fb3ce017e25e147307416292d7a = 0;
									if (m_state == HudState.Tab)
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
										c804e1fb3ce017e25e147307416292d7a = statSheet.m_teamId;
									}
									if (m_state == HudState.WrapUp)
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
										if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
											if (HUDPvPInfoView.m_PlayerTeamMap.ContainsKey(statSheet.m_id))
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
												c804e1fb3ce017e25e147307416292d7a = HUDPvPInfoView.m_PlayerTeamMap[statSheet.m_id];
											}
										}
									}
									bool cb2ae62750bf0d4bac82b0f72a1ad = statSheet.m_name == c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
									c7949f87f6e53652dcc26dae3ef5b2443(childByName.getChildByName<MovieClip>("mcLevelnfo"), statSheet.m_level.ToString(), c804e1fb3ce017e25e147307416292d7a, cb2ae62750bf0d4bac82b0f72a1ad);
									c7949f87f6e53652dcc26dae3ef5b2443(childByName.getChildByName<MovieClip>("mcNameInfo"), statSheet.m_name, c804e1fb3ce017e25e147307416292d7a, cb2ae62750bf0d4bac82b0f72a1ad);
									c7949f87f6e53652dcc26dae3ef5b2443(childByName.getChildByName<MovieClip>("mcDeathInfo"), statSheet.m_killCount + "/" + statSheet.m_deathcount, c804e1fb3ce017e25e147307416292d7a, cb2ae62750bf0d4bac82b0f72a1ad);
									c7949f87f6e53652dcc26dae3ef5b2443(childByName.getChildByName<MovieClip>("mcScoreInfo"), statSheet.m_score.ToString(), c804e1fb3ce017e25e147307416292d7a, cb2ae62750bf0d4bac82b0f72a1ad);
									if (m_state == HudState.Tab)
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
										if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28296aaabdb7ddfba47ef5559c1df883(statSheet.m_id) == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
											if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28296aaabdb7ddfba47ef5559c1df883(statSheet.m_id).c66b232dbebded7c7e9a89c1e8bd84689() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
												if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28296aaabdb7ddfba47ef5559c1df883(statSheet.m_id).c66b232dbebded7c7e9a89c1e8bd84689().c5ca38fad98337fc5c7255384b2cd1a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
												{
													if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28296aaabdb7ddfba47ef5559c1df883(statSheet.m_id).c66b232dbebded7c7e9a89c1e8bd84689().c5ca38fad98337fc5c7255384b2cd1a86()
														.ca2ff7a501878363cb1d5f0472e306620() == 0)
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
														childByName.getChildByName<MovieClip>("mcStatusInfo").gotoAndStop("died");
													}
													else
													{
														childByName.getChildByName<MovieClip>("mcStatusInfo").gotoAndStop("live");
													}
													goto IL_05cb;
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
										}
										childByName.getChildByName<MovieClip>("mcStatusInfo").gotoAndStop("live");
									}
									else if (m_state == HudState.WrapUp)
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
										c7949f87f6e53652dcc26dae3ef5b2443(childByName.getChildByName<MovieClip>("mcStatusInfo"), string.Empty, c804e1fb3ce017e25e147307416292d7a);
										c7949f87f6e53652dcc26dae3ef5b2443(childByName.getChildByName<MovieClip>("mcMoney"), string.Empty, c804e1fb3ce017e25e147307416292d7a);
									}
									goto IL_05cb;
								}
							}
							goto IL_066c;
							IL_05cb:
							if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
								if (statSheet.m_teamId == num)
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
									childByName.gotoAndStop("friend");
								}
								else
								{
									childByName.gotoAndStop("enemy");
								}
							}
							else if (statSheet.m_name == c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409())
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
								childByName.gotoAndStop("friend");
							}
							else
							{
								childByName.gotoAndStop("enemy");
							}
							childByName.visible = true;
							num2++;
							goto IL_066c;
							IL_066c:
							childByName = c3b25312b3b4868d181e116bb93592519.getChildByName<MovieClip>("mcMapName");
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
								c7949f87f6e53652dcc26dae3ef5b2443(childByName, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Instance_" + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId)));
							}
							childByName = c3b25312b3b4868d181e116bb93592519.getChildByName<MovieClip>("mcMatchMode");
							if (childByName == null)
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
							string text = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460();
							if (text == "GameModePvP")
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
								c7949f87f6e53652dcc26dae3ef5b2443(childByName, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_DeathMatch")));
								continue;
							}
							if (!(text == "GamemodeTeamDeathmatch"))
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
							c7949f87f6e53652dcc26dae3ef5b2443(childByName, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("PVP_TeamDeathMatch")));
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							if (m_state != HudState.WrapUp)
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
								MovieClip childByName3 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot1");
								MovieClip childByName4 = m_wrapupContainer.getChildByName<MovieClip>("mc_slot2");
								childByName3.visible = false;
								childByName4.visible = false;
								tf_CountDown = m_wrapupContainer.getChildByName<TextField>("tf_CountDown");
								m_CountDownTime = 65f;
								m_nCurretnStamp = 0;
								m_StampCount = KillingStampManager.c71f6ce28731edfd43c976fbd57c57bea().ccbac5ab0a2855b0adc4324fe26e033a9();
								m_wrapupPanel.addEventListener(CEvent.ENTER_FRAME, cbb62c7bf65054acdcba4d40fc55ff7f8);
								StatisticsManager.StatSheet statSheet2 = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c876ebada48854e6e8e29d50bc5352240().c9e69f6afb2b50d93703124af45d4282c();
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_killall"), statSheet2.m_killCount.ToString());
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_death"), statSheet2.m_deathcount.ToString());
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_myscore"), statSheet2.m_score.ToString());
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_headshot"), statSheet2.m_headshotKillCount.ToString());
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("earnG_Smoney"), statSheet2.m_extraMoney.ToString());
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("earnEXP"), statSheet2.m_extraExp.ToString());
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_stampcount"), m_StampCount.ToString());
								string c11850078118ec3368b07cfa9c60449bf = "0";
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_kills"), c11850078118ec3368b07cfa9c60449bf);
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_domination"), c11850078118ec3368b07cfa9c60449bf);
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_killedbyme"), string.Empty);
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("mc_stampbonus"), c11850078118ec3368b07cfa9c60449bf);
								if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd19cb80dca29b5c813acffe07d4eb050())
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("earnG_EXP"), statSheet2.m_guildExp.ToString());
											return;
										}
									}
								}
								c7949f87f6e53652dcc26dae3ef5b2443(m_wrapupContainer.getChildByName<MovieClip>("earnG_EXP"), c11850078118ec3368b07cfa9c60449bf);
								return;
							}
						}
					}
				}
			}
		}

		protected void c1f78bdc9db0570007de6a982b6fa646f()
		{
			if (m_StampCount == 0)
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
						if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									if (!LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().m_bLuckyBoxOpened)
									{
										while (true)
										{
											switch (5)
											{
											case 0:
												break;
											default:
												c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1 = true;
												return;
											}
										}
									}
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (m_nCurretnStamp > m_StampCount * 10)
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
			if (m_nCurretnStamp / 10 < m_StampCount)
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
				if (m_nCurretnStamp % 10 == 0)
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
					m_StampIcons[m_nCurretnStamp / 10].cca2f3c1074cb80ece7240c6723611e03(KillingStampManager.c71f6ce28731edfd43c976fbd57c57bea().c97d7a5a735063b7fad4db0bbb901032c(m_nCurretnStamp / 10));
				}
			}
			m_nCurretnStamp++;
			if (m_nCurretnStamp <= m_StampCount * 10)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1 = true;
				return;
			}
		}

		protected void cbb62c7bf65054acdcba4d40fc55ff7f8(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c1f78bdc9db0570007de6a982b6fa646f();
			m_CountDownTime -= Time.deltaTime;
			int num = (int)(m_CountDownTime - m_CountDownInterval);
			if (m_CountDownTime <= 0f)
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
				m_CountDownTime = 0f;
			}
			if (num <= 0)
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
				num = 0;
			}
			tf_CountDown.text = num + "''";
			if (num == 0)
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
				if (!LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().m_bLuckyBoxOpened)
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
					LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c9ea1e516f59bdd69e72560dbbcf36e29();
				}
			}
			if (m_CountDownTime != 0f)
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
				m_wrapupPanel.removeEventListener(CEvent.ENTER_FRAME, cbb62c7bf65054acdcba4d40fc55ff7f8);
				cc98e52440b77159144d14a0afe75cbf8();
				return;
			}
		}

		public void ce528330af391600e74c8c4eaf0c5bc3a()
		{
			switch (m_state)
			{
			case HudState.Init:
				m_targetInfo.visible = false;
				m_resultInfoPanel.visible = false;
				m_tabPanel.visible = false;
				m_wrapupPanel.visible = false;
				m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(false);
				m_state = HudState.Start;
				ce528330af391600e74c8c4eaf0c5bc3a();
				break;
			case HudState.Start:
				if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c9d057c2188e7d2872aa3ec71517e92ae)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c9d057c2188e7d2872aa3ec71517e92ae = false;
				}
				m_targetInfo.visible = true;
				m_targetInfo.play();
				m_resultInfoPanel.visible = false;
				m_tabPanel.visible = false;
				m_wrapupPanel.visible = false;
				m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(false);
				m_rootView.cae4d5f3ea26ef08f162561464693dd61();
				cd15e3e31bae933869c71fbd3cd76923a();
				break;
			case HudState.Tab:
				m_targetInfo.visible = false;
				m_resultInfoPanel.visible = false;
				m_tabPanel.visible = true;
				m_wrapupPanel.visible = false;
				m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(false);
				break;
			case HudState.WrapUp:
				m_targetInfo.visible = false;
				m_resultInfoPanel.visible = false;
				m_tabPanel.visible = false;
				m_wrapupPanel.visible = true;
				m_wrapupPanel.gotoAndPlay("fadein");
				m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(false);
				cf66b3f5ad0d81464dac4aec75d8bef94();
				ca9be004ddcc7c41622a9b057affce5f6(m_wrapupContainer, c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c876ebada48854e6e8e29d50bc5352240());
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
				m_rootView.c2a041f325b4a47cb1fdb49089b371132(false);
				cd15e3e31bae933869c71fbd3cd76923a(30f);
				break;
			case HudState.End:
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PauseMenuView>().c67b28f11a75cd869d2f715f541128e09 = false;
				m_rootView.cae4d5f3ea26ef08f162561464693dd61(false);
				m_targetInfo.visible = false;
				m_resultInfoPanel.gotoAndPlay("fadein");
				c9e04464a8b4438824a11acf84cff9685();
				m_resultInfoPanel.visible = true;
				m_tabPanel.visible = false;
				m_wrapupPanel.visible = false;
				m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(false);
				cd15e3e31bae933869c71fbd3cd76923a();
				break;
			case HudState.Game:
				m_targetInfo.visible = false;
				m_resultInfoPanel.visible = false;
				m_tabPanel.visible = false;
				m_wrapupPanel.visible = false;
				m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(true);
				break;
			}
		}

		private string cd0e71e038768512a0b596a81179ee04a(int ceba5147339e9020797f9e9f57e356033, int c8064faf8956065648bc653b476a39ee6)
		{
			float num = ceba5147339e9020797f9e9f57e356033;
			float num2 = c8064faf8956065648bc653b476a39ee6;
			string result = "D";
			if ((double)num2 >= (double)num * 0.5)
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
				result = "C";
			}
			if ((double)num2 >= (double)num * 0.7)
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
				result = "B";
			}
			if ((double)num2 >= (double)num * 0.9)
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
				result = "A";
			}
			if (num2 >= num)
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
				result = "S";
			}
			return result;
		}

		private void c9e04464a8b4438824a11acf84cff9685()
		{
			MovieClip movieClip = new MovieClip();
			movieClip = m_resultContainer.getChildByName<MovieClip>("mcWin");
			movieClip.visible = false;
			MovieClip movieClip2 = new MovieClip();
			movieClip2 = m_resultContainer.getChildByName<MovieClip>("mcLose");
			movieClip2.visible = false;
			PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c9e69f6afb2b50d93703124af45d4282c();
			string to = cd0e71e038768512a0b596a81179ee04a(c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().c415f9dee531e543fc447806c04e5e5f9(), statSheet.m_score);
			mc_Rank = m_wrapupContainer.getChildByName<MovieClip>("mc_rankPanel").getChildByName<MovieClip>("mc_grade");
			mc_Rank.gotoAndStop(to);
			movieClip.visible = c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.ce01a42bf0027493da7880d4eae90961c(ceb41162a7cd2a1d5c4a03830e02b);
			movieClip2.visible = !movieClip.visible;
		}

		private void c7949f87f6e53652dcc26dae3ef5b2443(MovieClip c6df0ceb3aa767576f3f5b0e23de52511, string c11850078118ec3368b07cfa9c60449bf, int c804e1fb3ce017e25e147307416292d7a = 0, bool cb2ae62750bf0d4bac82b0f72a1ad4199 = false, bool cb4040e85ef24e4c9dea5dfc714598840 = true)
		{
			TextField childByName = c6df0ceb3aa767576f3f5b0e23de52511.getChildByName<TextField>("textField");
			if (!cb2ae62750bf0d4bac82b0f72a1ad4199)
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
				if (childByName.textFormat.color != Color.white)
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
					childByName.textFormat.color = Color.white;
				}
			}
			else if (childByName.textFormat.color != Color.yellow)
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
				childByName.textFormat.color = Color.yellow;
			}
			if (childByName.text != c11850078118ec3368b07cfa9c60449bf)
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
				childByName.text = c11850078118ec3368b07cfa9c60449bf;
			}
			if (childByName.visible == cb4040e85ef24e4c9dea5dfc714598840)
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
				childByName.visible = cb4040e85ef24e4c9dea5dfc714598840;
				return;
			}
		}

		public void c4114581ec685cd727c0a3b62484fc1d2(bool c3bb2e6cf658dd2652153ec1d3daa0563)
		{
			if (m_state != HudState.Game)
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
				if (m_state != HudState.Tab)
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
			int state;
			if (c3bb2e6cf658dd2652153ec1d3daa0563)
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
				state = 4;
			}
			else
			{
				state = 3;
			}
			m_state = (HudState)state;
			if (c3bb2e6cf658dd2652153ec1d3daa0563)
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
				ca9be004ddcc7c41622a9b057affce5f6(m_tabPanel, c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25());
				m_rootView.c2a041f325b4a47cb1fdb49089b371132(false);
			}
			else
			{
				m_rootView.c2a041f325b4a47cb1fdb49089b371132(true);
			}
			ce528330af391600e74c8c4eaf0c5bc3a();
		}

		private void cefe421697a3bbbea5cbd44ad193a066d()
		{
			if (ca37fcdce7d4937b60735f4033eb55695.hasEventListener(CEvent.ENTER_FRAME))
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
				ca37fcdce7d4937b60735f4033eb55695.removeEventListener(CEvent.ENTER_FRAME, c09950cc86f866e71a4dc5e005e5e2eb3);
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDVictoryCondition>().cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(true);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<HUDPvPInfoView>();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<HUDVictoryCondition>();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.cc244d573983559acb0dfb881b1e2f5bf();
		}
	}

	public class KillInfoItemContainer : c196099a1254db61d3be10d70e14e7422
	{
		private const int MAX_KILL_INFO = 7;

		protected KillInfoItem[] m_ItemArray = new KillInfoItem[HUDPvPInfoView.m_sMaxKillInfoCount];

		protected MovieClip[] m_ItemMCArray = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(HUDPvPInfoView.m_sMaxKillInfoCount);

		private MovieClip m_container;

		private MovieClip m_content;

		public bool isLocked;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map17;

		public bool c13ab21170a26d0ff28a15fb5bef26015
		{
			get
			{
				return m_container.visible;
			}
			set
			{
				if (isLocked)
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
					m_container.visible = value;
					return;
				}
			}
		}

		public KillInfoItemContainer()
		{
			for (int i = 0; i < m_ItemArray.Length; i++)
			{
				m_ItemArray[i] = new KillInfoItem();
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

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
		}

		public void c9c8c2e259fa10b28eef998125e51490f(string c682d58dff199c276f30506a89567cf66)
		{
			if (!m_container.visible)
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
				m_container.gotoAndPlay(c682d58dff199c276f30506a89567cf66);
				return;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map17 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(2);
					dictionary.Add("mcRootContainer", 0);
					dictionary.Add("mcContent", 1);
					_003C_003Ef__switch_0024map17 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map17.TryGetValue(name, out value))
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
					if (value != 0)
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
						if (value != 1)
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
						}
						else
						{
							m_content = movieClip;
							for (int i = 0; i < 7; i++)
							{
								string name2 = "mcItem_" + i;
								MovieClip childByName = m_content.getChildByName<MovieClip>(name2);
								m_ItemMCArray[i] = childByName;
								m_ItemArray[i].c130648b59a0c8debea60aa153f844879(childByName);
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
					}
					else
					{
						m_container = movieClip;
						m_container.visible = false;
						m_container.gotoAndStop("normal");
					}
				}
			}
			return result;
		}

		private void c649543487911247490016f844cdd8ca4()
		{
			for (int i = 0; i < m_ItemMCArray.Length; i++)
			{
				m_ItemMCArray[i].visible = false;
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

		public void c4a2ab3125dd2fc5825ddbfdba1f3483c(Queue<KillInfo> c400e9b6bf7938a2edc3bcd74ddc58dfb)
		{
			KillInfo[] array = c400e9b6bf7938a2edc3bcd74ddc58dfb.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				m_ItemArray[i].c150264a18c2cb408479d3f072cac8cc1 = true;
				m_ItemArray[i].ce4bf9718485f72643b662cd66d5c4e8e(array[i]);
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
				for (int j = array.Length; j < HUDPvPInfoView.m_sMaxKillInfoCount; j++)
				{
					m_ItemArray[j].c150264a18c2cb408479d3f072cac8cc1 = false;
				}
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
	}

	public class KillInfoItem : c196099a1254db61d3be10d70e14e7422
	{
		private MovieClip m_KillTypeIcon;

		private MovieClip m_KillerName;

		private MovieClip m_VictimName;

		private MovieClip m_ElementIcon;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (ca37fcdce7d4937b60735f4033eb55695 != null)
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
							return ca37fcdce7d4937b60735f4033eb55695.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (ca37fcdce7d4937b60735f4033eb55695 == null)
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
					ca37fcdce7d4937b60735f4033eb55695.visible = value;
					return;
				}
			}
		}

		private bool cb35a96c9b2c1038836b500868f657903(string cd99af21e22e356018b8f72d4a7e4872a)
		{
			int num = 0;
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			int num2 = 0;
			while (true)
			{
				if (num2 < c9c8de68aa0982db2bbd496692c37e.Count)
				{
					if (!c9c8de68aa0982db2bbd496692c37e[num2].c16d1154aec91a0f8f4a52d77fc081194())
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
						if (c9c8de68aa0982db2bbd496692c37e[num2].m_name == cd99af21e22e356018b8f72d4a7e4872a)
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
							num = c9c8de68aa0982db2bbd496692c37e[num2].m_teamID;
							break;
						}
					}
					num2++;
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
				break;
			}
			if (num == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_teamID)
			{
				while (true)
				{
					switch (2)
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

		private bool c95cd2eaf57f155c93fb4b927b52ca60e(string cd99af21e22e356018b8f72d4a7e4872a)
		{
			return c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_name == cd99af21e22e356018b8f72d4a7e4872a;
		}

		private void c12b196ef16d3d89b666906481f435d35(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			if (ca37fcdce7d4937b60735f4033eb55695.visible)
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
				ca37fcdce7d4937b60735f4033eb55695.visible = true;
				return;
			}
		}

		public void ce4bf9718485f72643b662cd66d5c4e8e(KillInfo cd5f6cf04a95e3b27f4b87dcddde008a2)
		{
			m_VictimName = (ca37fcdce7d4937b60735f4033eb55695 as MovieClip).getChildByName<MovieClip>("mcVictimName");
			m_KillerName = (ca37fcdce7d4937b60735f4033eb55695 as MovieClip).getChildByName<MovieClip>("mcKillerName");
			m_KillTypeIcon = (ca37fcdce7d4937b60735f4033eb55695 as MovieClip).getChildByName<MovieClip>("KillType");
			m_ElementIcon = (ca37fcdce7d4937b60735f4033eb55695 as MovieClip).getChildByName<MovieClip>("element");
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c0fa185c7b0349f8cb220d2aefb47d990())
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
				if (c95cd2eaf57f155c93fb4b927b52ca60e(cd5f6cf04a95e3b27f4b87dcddde008a2.strKiller))
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
					m_KillerName.gotoAndStop("self");
				}
				else if (cb35a96c9b2c1038836b500868f657903(cd5f6cf04a95e3b27f4b87dcddde008a2.strKiller))
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
					m_KillerName.gotoAndStop("teammate");
				}
				else
				{
					m_KillerName.gotoAndStop("emeny");
				}
				if (c95cd2eaf57f155c93fb4b927b52ca60e(cd5f6cf04a95e3b27f4b87dcddde008a2.strVictim))
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
					m_VictimName.gotoAndStop("self");
				}
				else if (cb35a96c9b2c1038836b500868f657903(cd5f6cf04a95e3b27f4b87dcddde008a2.strVictim))
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
					m_VictimName.gotoAndStop("teammate");
				}
				else
				{
					m_VictimName.gotoAndStop("emeny");
				}
			}
			else
			{
				if (c95cd2eaf57f155c93fb4b927b52ca60e(cd5f6cf04a95e3b27f4b87dcddde008a2.strKiller))
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
					m_KillerName.gotoAndStop("self");
				}
				else
				{
					m_KillerName.gotoAndStop("emeny");
				}
				if (c95cd2eaf57f155c93fb4b927b52ca60e(cd5f6cf04a95e3b27f4b87dcddde008a2.strVictim))
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
					m_VictimName.gotoAndStop("self");
				}
				else
				{
					m_VictimName.gotoAndStop("emeny");
				}
			}
			TextField childByName = m_VictimName.getChildByName<TextField>("textField");
			if (childByName.text != cd5f6cf04a95e3b27f4b87dcddde008a2.strVictim)
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
				childByName.text = cd5f6cf04a95e3b27f4b87dcddde008a2.strVictim;
			}
			childByName = m_KillerName.getChildByName<TextField>("textField");
			if (childByName.text != cd5f6cf04a95e3b27f4b87dcddde008a2.strKiller)
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
				childByName.text = cd5f6cf04a95e3b27f4b87dcddde008a2.strKiller;
			}
			m_ElementIcon.visible = false;
			if (cd5f6cf04a95e3b27f4b87dcddde008a2.scoringActionList.Contains(ScoringActionType.BonusCritical))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						m_KillTypeIcon.gotoAndStop(ScoringActionType.BonusCritical.ToString());
						return;
					}
				}
			}
			if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd5f6cf04a95e3b27f4b87dcddde008a2.attackSubType) == AttackInfo.AttackType.Melee)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						m_KillTypeIcon.gotoAndStop(AttackInfo.AttackType.Melee.ToString());
						return;
					}
				}
			}
			if (cd5f6cf04a95e3b27f4b87dcddde008a2.attackSubType != AttackSubType.DamageOverTimeFire)
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
				if (cd5f6cf04a95e3b27f4b87dcddde008a2.attackSubType != AttackSubType.DamageOverTimeShock)
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
					if (cd5f6cf04a95e3b27f4b87dcddde008a2.attackSubType != AttackSubType.DamageOverTimeCorrosive)
					{
						m_KillTypeIcon.gotoAndStop(cd5f6cf04a95e3b27f4b87dcddde008a2.attackSubType.ToString());
						return;
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
			}
			m_KillTypeIcon.gotoAndStop(1);
			m_ElementIcon.visible = true;
			m_ElementIcon.gotoAndStop(cd5f6cf04a95e3b27f4b87dcddde008a2.attackSubType.ToString());
		}
	}

	public class ScoringInfoContainer : c196099a1254db61d3be10d70e14e7422
	{
		protected Vector2[] m_OriginalPosArray = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(HUDPvPInfoView.m_sMaxScoreInfoCount);

		protected Queue<ScoringInfoItem> m_backupQueue = new Queue<ScoringInfoItem>();

		protected Queue<ScoringInfoItem> m_onusingQueue = new Queue<ScoringInfoItem>();

		protected bool m_bNeedUpdatePos;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map18;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			ScoringInfoItem scoringInfoItem = null;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map18 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(3);
					dictionary.Add("mcRoot_1", 0);
					dictionary.Add("mcRoot_2", 1);
					dictionary.Add("mcRoot_3", 2);
					_003C_003Ef__switch_0024map18 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map18.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						movieClip.gotoAndStop("normal");
						movieClip.addFrameScript("AnimationEnd", c729f0f3da43fe351d2a333618a48a6db);
						m_OriginalPosArray[0] = new Vector2(movieClip.x, movieClip.y);
						scoringInfoItem = new ScoringInfoItem();
						scoringInfoItem.c130648b59a0c8debea60aa153f844879(movieClip);
						m_backupQueue.Enqueue(scoringInfoItem);
						result = true;
						break;
					case 1:
						movieClip.gotoAndStop("normal");
						movieClip.addFrameScript("AnimationEnd", c729f0f3da43fe351d2a333618a48a6db);
						m_OriginalPosArray[1] = new Vector2(movieClip.x, movieClip.y);
						scoringInfoItem = new ScoringInfoItem();
						scoringInfoItem.c130648b59a0c8debea60aa153f844879(movieClip);
						m_backupQueue.Enqueue(scoringInfoItem);
						result = true;
						break;
					case 2:
						movieClip.gotoAndStop("normal");
						movieClip.addFrameScript("AnimationEnd", c729f0f3da43fe351d2a333618a48a6db);
						m_OriginalPosArray[2] = new Vector2(movieClip.x, movieClip.y);
						scoringInfoItem = new ScoringInfoItem();
						scoringInfoItem.c130648b59a0c8debea60aa153f844879(movieClip);
						m_backupQueue.Enqueue(scoringInfoItem);
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public void c729f0f3da43fe351d2a333618a48a6db(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			ScoringInfoItem scoringInfoItem = m_onusingQueue.Dequeue();
			scoringInfoItem.c43cbb41bf755dfa61de619fc6e86ab31(false);
			m_backupQueue.Enqueue(scoringInfoItem);
		}

		public void Update(float _deltaTime)
		{
			Queue<ScoringInfoItem> queue = new Queue<ScoringInfoItem>(m_onusingQueue);
			m_onusingQueue.Clear();
			int num = 0;
			int count = queue.Count;
			while (queue.Count > 0)
			{
				num++;
				ScoringInfoItem scoringInfoItem = queue.Dequeue();
				scoringInfoItem.Update(_deltaTime);
				if (m_bNeedUpdatePos)
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
					scoringInfoItem.c034936ede6b65db0da600e58eb5611d2(m_OriginalPosArray[count - num]);
				}
				m_onusingQueue.Enqueue(scoringInfoItem);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_bNeedUpdatePos = false;
				return;
			}
		}

		public void c89c2adfebe75568a32261eaf914c0141(ScoreInfo c5e8d81d6fb845de5618a3df6d55feb15)
		{
			m_bNeedUpdatePos = true;
			ScoringInfoItem scoringInfoItem = null;
			if (m_onusingQueue.Count == HUDPvPInfoView.m_sMaxScoreInfoCount)
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
				scoringInfoItem = m_onusingQueue.Dequeue();
			}
			else
			{
				scoringInfoItem = m_backupQueue.Dequeue();
			}
			scoringInfoItem.c263a18e823d534fe933bf797fd17c221();
			scoringInfoItem.cea301dec01e9619bc040acd970102315(c5e8d81d6fb845de5618a3df6d55feb15);
			m_onusingQueue.Enqueue(scoringInfoItem);
		}
	}

	public class ScoringInfoItem : c196099a1254db61d3be10d70e14e7422
	{
		protected float m_fTimeLeft;

		protected string m_strScoreType;

		protected string m_strScoreNumber;

		protected bool m_bOnFadeoutAnimation;

		protected bool m_bVisible;

		public void cea301dec01e9619bc040acd970102315(ScoreInfo c48689f6463b42384c631399a9d9e7648)
		{
			m_fTimeLeft = c48689f6463b42384c631399a9d9e7648.fTimeLeft;
			if (c48689f6463b42384c631399a9d9e7648.iScore >= 0)
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
				m_strScoreNumber = "+" + c48689f6463b42384c631399a9d9e7648.iScore;
			}
			else
			{
				m_strScoreNumber = c48689f6463b42384c631399a9d9e7648.iScore.ToString();
			}
			m_strScoreType = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c48689f6463b42384c631399a9d9e7648.ScoringType.ToString()));
		}

		public void Update(float _fDeltaTime)
		{
			if (m_bOnFadeoutAnimation)
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
				m_fTimeLeft -= _fDeltaTime;
				if (m_fTimeLeft < 0f)
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
					(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndPlay("fadeout");
					m_bOnFadeoutAnimation = true;
				}
				MovieClip childByName = (ca37fcdce7d4937b60735f4033eb55695 as MovieClip).getChildByName<MovieClip>("mcPVPkillscore");
				if (childByName == null)
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
					TextField childByName2 = childByName.getChildByName<TextField>("text_ScoringType");
					if (childByName2.text != m_strScoreType)
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
						childByName2.text = m_strScoreType;
					}
					childByName2 = childByName.getChildByName<TextField>("text_ScoreNumber");
					if (!(childByName2.text != m_strScoreNumber))
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
						childByName2.text = m_strScoreNumber;
						return;
					}
				}
			}
		}

		public void c034936ede6b65db0da600e58eb5611d2(Vector2 c12f4e1de3ebb7672752cd96ee2f6c5b4)
		{
			(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).x = c12f4e1de3ebb7672752cd96ee2f6c5b4.x;
			(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).y = c12f4e1de3ebb7672752cd96ee2f6c5b4.y;
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c8b64aef39806bef0c330f87521f7b940)
		{
			if (m_bVisible == c8b64aef39806bef0c330f87521f7b940)
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
				(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).visible = c8b64aef39806bef0c330f87521f7b940;
				m_bVisible = c8b64aef39806bef0c330f87521f7b940;
				return;
			}
		}

		public void c263a18e823d534fe933bf797fd17c221()
		{
			c43cbb41bf755dfa61de619fc6e86ab31(true);
			m_bOnFadeoutAnimation = false;
			(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndPlay("fadein");
		}
	}

	protected ScoringInfoContainer m_ScoringItemContainer;

	private PVPHudScreen m_pvpHudScreen;

	protected int m_iLastFrameKillInfoCount;

	protected bool m_bOnKillInfoFadeOutAnima;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("2014_PVP_HUD.swf", "Panel_PVPHud", c0735a4018274337fb4ff5a4d1f1f2e1d);
		BadAssMovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c = new BadAssMovieClip("SightBead.swf", "Panel_pvp_score");
		c9a2bed3d96e862459253a2fe52afe7fb(cbe9ca8ddb3cdc2312e6ff8411b2db2c);
	}

	private void c0735a4018274337fb4ff5a4d1f1f2e1d(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_pvpHudScreen = new PVPHudScreen();
		m_pvpHudScreen.m_rootView = this;
		m_pvpHudScreen.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_pvpHudScreen);
	}

	private void c9a2bed3d96e862459253a2fe52afe7fb(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		float c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		float c5ebdc65d5cb420faf7ba524809963aa;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c24a0f2b5695dcd950edb79b1830693f9(out c5ebdc65d5cb420faf7ba524809963aa, out c9d16e16b57deb9bb1da907451ba1f25b);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.x = c5ebdc65d5cb420faf7ba524809963aa;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.y = c9d16e16b57deb9bb1da907451ba1f25b;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = true;
		m_ScoringItemContainer = new ScoringInfoContainer();
		m_ScoringItemContainer.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_ScoringItemContainer);
	}

	protected override void c7ba3429fee00eecd5933751342411be8(float c4bb7d253cf6d616d835d0c2bfca8a211)
	{
		if (m_pvpHudScreen == null)
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
			if (m_pvpHudScreen.m_KillInfoItemContainer == null)
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
				if (m_pvpHudScreen.m_KillInfoItemContainer.isLocked)
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
				base.c7ba3429fee00eecd5933751342411be8(c4bb7d253cf6d616d835d0c2bfca8a211);
				if (m_killInfoVisible)
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
					if (!m_pvpHudScreen.m_KillInfoItemContainer.c13ab21170a26d0ff28a15fb5bef26015)
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
						m_pvpHudScreen.m_KillInfoItemContainer.c9c8c2e259fa10b28eef998125e51490f("fadein");
						m_pvpHudScreen.m_KillInfoItemContainer.c13ab21170a26d0ff28a15fb5bef26015 = true;
					}
				}
				else if (m_pvpHudScreen.m_KillInfoItemContainer.c13ab21170a26d0ff28a15fb5bef26015)
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
					m_pvpHudScreen.m_KillInfoItemContainer.c13ab21170a26d0ff28a15fb5bef26015 = false;
					m_killingInfoQueue.Clear();
				}
				if (!m_bKillInfoNeedUpdate)
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
					m_pvpHudScreen.m_KillInfoItemContainer.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
					m_pvpHudScreen.m_KillInfoItemContainer.c4a2ab3125dd2fc5825ddbfdba1f3483c(m_killingInfoQueue);
					m_bKillInfoNeedUpdate = false;
					return;
				}
			}
		}
	}

	public void ce421ed184b36b13e7072feb7da58f0ae()
	{
		if (m_pvpHudScreen == null)
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
			m_pvpHudScreen.ce421ed184b36b13e7072feb7da58f0ae();
			return;
		}
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (m_pvpHudScreen != null)
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
			if (m_pvpHudScreen.cdd8b1f9a423aaaa710988ac604ba4868 == PVPHudScreen.HudState.WrapUp)
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
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	protected override void c7bb86b60f299c950179b9bd1c30a2a68()
	{
		base.c7bb86b60f299c950179b9bd1c30a2a68();
		if (m_pvpHudScreen == null)
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
					return;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("ShowScore"))
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
			m_pvpHudScreen.c4114581ec685cd727c0a3b62484fc1d2(true);
		}
		if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c335a1480fba59f7a546ea6803a9374b9("ShowScore"))
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
			m_pvpHudScreen.c4114581ec685cd727c0a3b62484fc1d2(false);
			return;
		}
	}

	protected override void c04ef5b99f419a4d197b8aee089d17013(float c4bb7d253cf6d616d835d0c2bfca8a211)
	{
		base.c04ef5b99f419a4d197b8aee089d17013(c4bb7d253cf6d616d835d0c2bfca8a211);
		while (m_scoreInfoQueue.Count > 0)
		{
			ScoreInfo c5e8d81d6fb845de5618a3df6d55feb = m_scoreInfoQueue.Dequeue();
			m_ScoringItemContainer.c89c2adfebe75568a32261eaf914c0141(c5e8d81d6fb845de5618a3df6d55feb);
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
			m_ScoringItemContainer.Update(c4bb7d253cf6d616d835d0c2bfca8a211);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		if (m_pvpHudScreen == null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_pvpHudScreen);
			m_pvpHudScreen.isInited = false;
			m_pvpHudScreen = null;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("2014_PVP_HUD.swf");
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("SightBead.swf");
			return;
		}
	}

	public override void c4effbb7e0f68e0d6297d5bb56a935bfb()
	{
		base.c4effbb7e0f68e0d6297d5bb56a935bfb();
		m_pvpHudScreen.c17989b93d3d0102e811acd54b349c39f();
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (m_pvpHudScreen == null)
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
			if (!m_pvpHudScreen.isInited)
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
				if (m_pvpHudScreen.c89ef242f4744e0f1c4ffea4da8b79bc1.visible == _bVisible)
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
				(m_pvpHudScreen.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip).visible = _bVisible;
				if (!_bVisible)
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
					m_pvpHudScreen.ce528330af391600e74c8c4eaf0c5bc3a();
					return;
				}
			}
		}
	}
}
