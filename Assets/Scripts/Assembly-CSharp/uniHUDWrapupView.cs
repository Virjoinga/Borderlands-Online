using System;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDWrapupView : HUDWrapupView
{
	private class WrapupPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		public MovieClip mc_Total;

		private TextField m_textLevelName;

		private TextField m_textDetail;

		private TextField m_textKilled;

		private TextField m_textTime;

		private TextField m_textExp;

		private TextField m_textGuildExp;

		private TextField m_textDifficulty;

		private TextField m_textHurt;

		private TextField m_textCountDown;

		private MovieClip m_Grade;

		private TextField m_MoneyClip;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Button;

		public bool m_LuckBoxShow;

		public bool m_bShowSlot1;

		public bool m_bShowSlot2;

		private int mKilled;

		private float mDetail;

		private int mHurt;

		private string mLevelName = string.Empty;

		private string mDifficulty = "Normal";

		private float mTime;

		private string mGrade = "S";

		private string m_strTime = string.Empty;

		private int m_xpBonus;

		private int m_Money;

		private int m_GuildExp;

		private bool m_bShowGrade;

		private float m_CountDownTime = 65f;

		private float m_CountDownInterval = 5f;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
					switch (5)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mc_root.visible = value;
					return;
				}
			}
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: WrapupPanel onInit() 'mc_root' is null! WrapupPanel won't work!!!");
						return;
					}
				}
			}
			mc_Total = mc_root.getChildByName<MovieClip>("mc_total");
			m_textLevelName = mc_Total.getChildByName<TextField>("textName");
			m_textTime = mc_Total.getChildByName<MovieClip>("mc_time").getChildByName<MovieClip>("mc_timeLayer").getChildByName<TextField>("textTime");
			m_textHurt = mc_Total.getChildByName<TextField>("textHurt");
			m_textKilled = mc_Total.getChildByName<TextField>("textKilled");
			m_textDetail = mc_Total.getChildByName<TextField>("textDetail");
			m_textDifficulty = mc_Total.getChildByName<TextField>("textDifficulty");
			m_Grade = mc_Total.getChildByName<MovieClip>("mc_grade");
			m_textGuildExp = mc_Total.getChildByName<MovieClip>("mc_GuildExp").getChildByName<TextField>("textExp");
			m_textExp = mc_Total.getChildByName<MovieClip>("mc_Exp").getChildByName<TextField>("textExp");
			m_textCountDown = mc_Total.getChildByName<MovieClip>("mc_countdown").getChildByName<TextField>("textCountDown");
			m_textCountDown.text = string.Empty;
			m_MoneyClip = mc_Total.getChildByName<MovieClip>("mc_Money").getChildByName<TextField>("textExp");
			if (m_Grade == null)
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
				m_Grade.visible = false;
				return;
			}
		}

		protected void c4cb9d159ab22ab85b94d483809a7e9e2()
		{
			if (LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c1b6f1885552cdca583b20160d9e865b8() != 0)
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
				m_bShowSlot1 = true;
				ItemDNA itemDNA = LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c0b887ca3b7074404bde04f358415edb8(0);
				if (itemDNA != null)
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
					MovieClip childByName = mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("mc_loading");
					childByName.visible = false;
					if (itemDNA.m_type == ItemType.Material)
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
						MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(itemDNA.m_materialType);
						MovieClip movieClip2 = movieClip.newInstance();
						movieClip2.name = "icon";
						MovieClip childByName2 = mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons");
						childByName2.stopAll();
						childByName2.addChild(movieClip2);
					}
					else if (itemDNA.m_type == ItemType.Money)
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
						MovieClip movieClip3 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c28ee12a3e8557af117e75c0f0133c2f3();
						MovieClip movieClip4 = movieClip3.newInstance();
						movieClip4.name = "icon";
						MovieClip childByName3 = mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons");
						childByName3.stopAll();
						childByName3.addChild(movieClip4);
					}
					else
					{
						Texture2D cf83e762e4368c5dedaab3e73ad69452e = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA);
						c7beefc397f483dc0b72dcd3e6bdcf929 c7beefc397f483dc0b72dcd3e6bdcf = new c7beefc397f483dc0b72dcd3e6bdcf929();
						c7beefc397f483dc0b72dcd3e6bdcf.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons"));
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
				switch (5)
				{
				case 0:
					continue;
				}
				m_bShowSlot2 = true;
				ItemDNA itemDNA2 = LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c0b887ca3b7074404bde04f358415edb8(0, true);
				if (itemDNA2 == null)
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
					MovieClip childByName4 = mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("mc_loading");
					childByName4.visible = false;
					if (itemDNA2.m_type == ItemType.Material)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
							{
								MovieClip movieClip5 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(itemDNA2.m_materialType);
								MovieClip movieClip6 = movieClip5.newInstance();
								movieClip6.name = "icon";
								MovieClip childByName5 = mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
								childByName5.stopAll();
								childByName5.addChild(movieClip6);
								return;
							}
							}
						}
					}
					if (itemDNA2.m_type == ItemType.Money)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
							{
								MovieClip movieClip7 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c28ee12a3e8557af117e75c0f0133c2f3();
								MovieClip movieClip8 = movieClip7.newInstance();
								movieClip8.name = "icon";
								MovieClip childByName6 = mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
								childByName6.stopAll();
								childByName6.addChild(movieClip8);
								return;
							}
							}
						}
					}
					Texture2D cf83e762e4368c5dedaab3e73ad69452e2 = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA2);
					c7beefc397f483dc0b72dcd3e6bdcf929 c7beefc397f483dc0b72dcd3e6bdcf2 = new c7beefc397f483dc0b72dcd3e6bdcf929();
					c7beefc397f483dc0b72dcd3e6bdcf2.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons"));
					c7beefc397f483dc0b72dcd3e6bdcf2.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e2);
					return;
				}
			}
		}

		public void c18a62da240926bd18528ca36e6e83ac3()
		{
			if (mc_Button == null)
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
				c4cb9d159ab22ab85b94d483809a7e9e2();
				mc_Button.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				mc_Button.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
				return;
			}
		}

		public void cc98e52440b77159144d14a0afe75cbf8()
		{
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			mc_root.addFrameScript("fadeoutover", c613ddb5a531424c3f57a12057307b842);
			mc_root.gotoAndPlay("fadeout");
		}

		private void ce6e90523914e3b1e1fe3bd32ac290b03(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_Total.removeEventListener(CEvent.ENTER_FRAME, c263a18e823d534fe933bf797fd17c221);
			cc98e52440b77159144d14a0afe75cbf8();
		}

		private void c613ddb5a531424c3f57a12057307b842(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeFrameScript("fadeoutover", c613ddb5a531424c3f57a12057307b842);
			GameFlowManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86;
			if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c5ee19dc8d4cccf5ae2de225410458b.c1570506bf0b326e191d0406037cb4fef();
				c5ee19dc8d4cccf5ae2de225410458b.cec9cdae23444bbac5cad953e7fc1f8e9();
			}
			c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
		}

		public void c23ffb495db7c9da62404f1cc24a67351(string cabd15f81c79912cd94358a0debf95ca1, int cc50bf6fc73cf69dfd4a0c45f5888704a, float ca03e3b53a7666a4136667b3496d42b84, int cf1e32dcdba991c84b8c62c92155def42, string c049d32faad45883066af42b0ed8dc2ee, string cffd1d8a20753da6682803b993c24d807, float cad9f703d862495149cd6bddd080f050b, int cf13fd632f93aa296c99679582ff35a65, string c9a5cd33b431c756e63f71873dfa45dab, int ccf7aaade8a1b6682ab9291c1d70ef219, int cd9b823270575c6300a8d2830704bec09 = 0)
		{
			if (m_Grade != null)
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
				m_Grade.visible = false;
			}
			m_bShowGrade = false;
			mKilled = cc50bf6fc73cf69dfd4a0c45f5888704a;
			mDetail = ca03e3b53a7666a4136667b3496d42b84;
			mHurt = cf1e32dcdba991c84b8c62c92155def42;
			mLevelName = c049d32faad45883066af42b0ed8dc2ee;
			mDifficulty = cffd1d8a20753da6682803b993c24d807;
			mTime = cad9f703d862495149cd6bddd080f050b;
			m_xpBonus = cf13fd632f93aa296c99679582ff35a65;
			m_Money = cd9b823270575c6300a8d2830704bec09;
			m_GuildExp = ccf7aaade8a1b6682ab9291c1d70ef219;
			mGrade = c9a5cd33b431c756e63f71873dfa45dab;
			c8e37185d5a280a96664e00745990f381();
			mc_root.gotoAndPlay("fadein");
			mc_root.addFrameScript("normal", c9405f941973a879d940129a018602cdd);
		}

		private void c8e37185d5a280a96664e00745990f381()
		{
			int num = (int)mTime;
			int num2 = num / 60;
			int num3 = num - num2 * 60;
			string text = "00";
			string text2 = "00";
			text = num2.ToString();
			if (num3 != 0)
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
				if (num3 < 10)
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
					text2 = "0" + num3;
				}
				else
				{
					text2 = num3.ToString();
				}
			}
			m_strTime = text + "'" + text2 + "''";
		}

		private void c9405f941973a879d940129a018602cdd(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.stop();
			mc_root.removeFrameScript("normal", c9405f941973a879d940129a018602cdd);
			mc_Total = mc_root.getChildByName<MovieClip>("mc_total");
			mc_Total.gotoAndPlay("show detail");
			mc_Total.addEventListener(CEvent.ENTER_FRAME, c263a18e823d534fe933bf797fd17c221);
			if (!c150264a18c2cb408479d3f072cac8cc1)
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
				m_CountDownTime = 65f;
				mc_Total.addEventListener(CEvent.ENTER_FRAME, cbb62c7bf65054acdcba4d40fc55ff7f8);
				mc_Total.addFrameScript("off", cbb41a784075d03489c016df272718526);
				mc_Total.addFrameScript("EXP_showoff", c8c284693215f2bb107c0ccda876bc28a);
				mc_Total.addFrameScript("get grade", c7ed7ee690795577d2d7a0a9192ae6705);
				return;
			}
		}

		private void c8c284693215f2bb107c0ccda876bc28a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wrapup_Pop_up");
			mc_Total.removeFrameScript("EXP_showoff", c8c284693215f2bb107c0ccda876bc28a);
		}

		private void c7ed7ee690795577d2d7a0a9192ae6705(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wrapup_Result");
			mc_Total.removeFrameScript("get grade", c7ed7ee690795577d2d7a0a9192ae6705);
			m_bShowGrade = true;
		}

		private void cbb41a784075d03489c016df272718526(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (m_LuckBoxShow)
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
				ca84ec93d89e9282fc0c56081cb9f860c();
				return;
			}
		}

		private void ca84ec93d89e9282fc0c56081cb9f860c()
		{
			m_LuckBoxShow = true;
			mc_Total.removeFrameScript("off", cbb41a784075d03489c016df272718526);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + " onStop:Set LuckyBox True!!");
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1 = true;
			GameFlowManager c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86;
			if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c5ee19dc8d4cccf5ae2de225410458b.c1bdd1e7aa891de56d871ae24289f5f8b();
			}
			mc_Button = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_Button.c130648b59a0c8debea60aa153f844879(mc_Total.getChildByName<MovieClip>("mc_back"));
		}

		private void cbb62c7bf65054acdcba4d40fc55ff7f8(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			m_textCountDown = mc_Total.getChildByName<MovieClip>("mc_countdown").getChildByName<TextField>("textCountDown");
			m_CountDownTime -= Time.deltaTime;
			int num = (int)(m_CountDownTime - m_CountDownInterval);
			if (num <= 55)
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
				if (!m_LuckBoxShow)
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
					ca84ec93d89e9282fc0c56081cb9f860c();
				}
			}
			if (m_CountDownTime <= 0f)
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
				m_CountDownTime = 0f;
			}
			if (num <= 0)
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
				num = 0;
			}
			m_textCountDown.text = num + "''";
			if (num == 0)
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
				if (!LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().m_bLuckyBoxOpened)
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
					LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c9ea1e516f59bdd69e72560dbbcf36e29();
				}
			}
			if (m_CountDownTime != 0f)
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
				mc_Total.removeEventListener(CEvent.ENTER_FRAME, cbb62c7bf65054acdcba4d40fc55ff7f8);
				cc98e52440b77159144d14a0afe75cbf8();
				return;
			}
		}

		private void c263a18e823d534fe933bf797fd17c221(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			try
			{
				m_textLevelName = mc_Total.getChildByName<TextField>("textName");
				m_textKilled = mc_Total.getChildByName<TextField>("textKilled");
				m_textDetail = mc_Total.getChildByName<TextField>("textDetail");
				m_textTime = mc_Total.getChildByName<MovieClip>("mc_time").getChildByName<MovieClip>("mc_timeLayer").getChildByName<TextField>("textTime");
				m_textHurt = mc_Total.getChildByName<TextField>("textHurt");
				m_textDifficulty = mc_Total.getChildByName<TextField>("textDifficulty");
				m_Grade = mc_Total.getChildByName<MovieClip>("mc_grade");
				m_textGuildExp = mc_Total.getChildByName<MovieClip>("mc_GuildExp").getChildByName<TextField>("textExp");
				m_textExp = mc_Total.getChildByName<MovieClip>("mc_Exp").getChildByName<TextField>("textExp");
				m_MoneyClip = mc_Total.getChildByName<MovieClip>("mc_Money").getChildByName<TextField>("textExp");
				MovieClip childByName = mc_Total.getChildByName<MovieClip>("mc_slot1");
				MovieClip childByName2 = mc_Total.getChildByName<MovieClip>("mc_slot2");
				if (childByName != null)
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
					if (m_bShowSlot1)
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
						childByName.visible = true;
					}
					else
					{
						childByName.visible = false;
					}
				}
				if (childByName2 != null)
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
					if (m_bShowSlot2)
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
						childByName2.visible = true;
					}
					else
					{
						childByName2.visible = false;
					}
				}
				if (!c150264a18c2cb408479d3f072cac8cc1)
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
					if (m_Grade != null)
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
						m_Grade.stopAll();
						m_Grade.gotoAndStop(mGrade);
						m_Grade.visible = m_bShowGrade;
					}
					if (m_textLevelName != null)
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
						if (m_textLevelName.text != mLevelName)
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
							m_textLevelName.text = mLevelName;
						}
					}
					if (m_textKilled != null)
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
						if (m_textKilled.text != mKilled.ToString())
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
							m_textKilled.text = mKilled.ToString();
						}
					}
					if (m_textDetail != null)
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
						if (m_textDetail.text != mDetail + "%")
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
							m_textDetail.text = mDetail + "%";
						}
					}
					if (m_textHurt != null)
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
						if (m_textHurt.text != mHurt.ToString())
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
							m_textHurt.text = mHurt.ToString();
						}
					}
					if (m_textDifficulty != null)
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
						if (m_textDifficulty.text != mDifficulty)
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
							m_textDifficulty.text = mDifficulty;
						}
					}
					if (m_textLevelName != null)
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
						if (m_textLevelName.text != mLevelName)
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
							m_textLevelName.text = mLevelName;
						}
					}
					if (m_textTime != null)
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
						if (m_textTime.text != m_strTime)
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
							m_textTime.text = m_strTime;
						}
					}
					if (m_textExp != null)
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
						UnityTextField unityTextField = (UnityTextField)m_textExp;
						unityTextField.c34fce3bccfffc6feb3579939c6d9a057 = Color.magenta;
						if (m_textExp.text != "XP " + m_xpBonus)
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
							m_textExp.text = "XP " + m_xpBonus;
						}
					}
					if (m_MoneyClip != null)
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
						if (m_MoneyClip.text != m_Money.ToString())
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
							m_MoneyClip.text = m_Money.ToString();
						}
					}
					if (m_textGuildExp == null)
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
						if (!(m_textGuildExp.text != m_GuildExp.ToString()))
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
							m_textGuildExp.text = m_GuildExp.ToString();
							return;
						}
					}
				}
			}
			catch (Exception ex)
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, ex.ToString());
			}
		}

		private void c5dd9fece3937732c9f279a9924ab722b()
		{
		}
	}

	private WrapupPanel _wrapupPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Wrap_Up.swf", "Whole", c985b05bf08ad1e9c7a114c53b82de07c);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_wrapupPanel);
		_wrapupPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Wrap_Up.swf");
	}

	private void c985b05bf08ad1e9c7a114c53b82de07c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_wrapupPanel = new WrapupPanel();
		_wrapupPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_wrapupPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + "Add Wrap Up!!!" + DateTime.Today.ToString());
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c120a0ab44e69ef682f36041c0b116750(_wrapupPanel);
		_wrapupPanel.c23ffb495db7c9da62404f1cc24a67351(string.Empty, 0, 0f, 0, string.Empty, string.Empty, 3f, 0, string.Empty, 0);
	}

	public override void c6c0790cec120a0223fe798ec4a63029a()
	{
		base.c6c0790cec120a0223fe798ec4a63029a();
		if (_wrapupPanel == null)
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
			if (_wrapupPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
				_wrapupPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
				_wrapupPanel.c23ffb495db7c9da62404f1cc24a67351(m_Name, m_Killed, m_Detail, m_Hurt, m_LevelName, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_Difficulty.ToString())), m_Time, m_ExpGained, m_instanceGrade.ToString(), m_GuildExp, m_Money);
				return;
			}
		}
	}

	public override void c515f796a94abd08a45b1f67775e1da8d()
	{
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
		_wrapupPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
		_wrapupPanel.c23ffb495db7c9da62404f1cc24a67351(string.Empty, 0, 0f, 0, string.Empty, string.Empty, 3f, 0, string.Empty, 0);
	}

	public void c18a62da240926bd18528ca36e6e83ac3()
	{
		if (_wrapupPanel == null)
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
			_wrapupPanel.c18a62da240926bd18528ca36e6e83ac3();
			return;
		}
	}
}
