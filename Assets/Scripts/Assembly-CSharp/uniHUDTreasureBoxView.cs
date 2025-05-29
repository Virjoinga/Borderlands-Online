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

public class uniHUDTreasureBoxView : HUDTreasureBoxView
{
	private class TreasureBox : ceaa621c569baf012ce466a5c368364e3
	{
		public MovieClip mc_Box;

		public MovieClip mc_Slot;

		public MovieClip mc_BoxStyle;

		public c7beefc397f483dc0b72dcd3e6bdcf929 m_imageLoader;

		public ItemDNA m_itemDNA;

		private bool m_bIsLocked;

		protected TextField m_tfNumber;

		private float m_fAlpha = 1f;

		public TreasureBox(bool cb1150c5c1545a576d5a45c577a903f6d)
		{
			m_bIsLocked = cb1150c5c1545a576d5a45c577a903f6d;
			m_imageLoader = new c7beefc397f483dc0b72dcd3e6bdcf929();
		}

		public void ce13d3cdd9d187c1d08b123cb2ee56943(MovieClip c9daf806ae588c86ccf90515cc653779e, MovieClip c404ae9657023b3a88381b52cd7d7e8d7)
		{
			if (c404ae9657023b3a88381b52cd7d7e8d7 != null)
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
				c130648b59a0c8debea60aa153f844879(c404ae9657023b3a88381b52cd7d7e8d7);
				mc_Slot = c404ae9657023b3a88381b52cd7d7e8d7;
				mc_Slot.visible = false;
				m_imageLoader.c130648b59a0c8debea60aa153f844879(mc_Slot.getChildByName<MovieClip>("icons"));
			}
			if (c9daf806ae588c86ccf90515cc653779e == null)
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
				mc_Box = c9daf806ae588c86ccf90515cc653779e;
				mc_BoxStyle = mc_Box.getChildByName<MovieClip>("mc_boxStyle");
				return;
			}
		}

		public void c4359882fe569b03ba6dba29001e11030()
		{
			mc_Box.addEventListener(MouseEvent.CLICK, cc3d77d94332a67a66abd57fcd87bef69);
			mc_Box.addEventListener(MouseEvent.MOUSE_ENTER, cadce22e7a666664f05dd9df730828905);
			mc_Box.addEventListener(MouseEvent.MOUSE_LEAVE, c1e8cc2494908a8ab5afd4e62348f4deb);
			m_tfNumber = mc_Slot.getChildByName<TextField>("textNumber");
			m_tfNumber.text = string.Empty;
		}

		protected void cc3d77d94332a67a66abd57fcd87bef69(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			int c62a53388af21c9e5e206591a30eb9f = int.Parse(mc_Box.name.Substring(mc_Box.name.Length - 1, 1));
			LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().cc153f529c9d81cda8397e0213df6f866(c62a53388af21c9e5e206591a30eb9f, m_bIsLocked);
		}

		protected void cadce22e7a666664f05dd9df730828905(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.HandOpen);
		}

		protected void c1e8cc2494908a8ab5afd4e62348f4deb(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.DefaultCursor);
		}

		public void c68730ec8aaf6846674689e4f4bfca072(string c9954ef00e56565ae66cf4f80961951d2)
		{
			if (mc_BoxStyle == null)
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
				if (!m_bIsLocked)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							mc_BoxStyle.gotoAndStop(c9954ef00e56565ae66cf4f80961951d2);
							return;
						}
					}
				}
				if (c9954ef00e56565ae66cf4f80961951d2 == "weapon_load_pic")
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							mc_BoxStyle.gotoAndStop(c9954ef00e56565ae66cf4f80961951d2);
							return;
						}
					}
				}
				mc_BoxStyle.gotoAndStop("diamond");
				return;
			}
		}

		public void c715d058075f0265bb392b1c6949f6e1c(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
		{
			if (c4ed717bfa8e3dbe7b0f04513d76a651e == null)
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
				m_itemDNA = c4ed717bfa8e3dbe7b0f04513d76a651e;
				mc_Box.addFrameScript("flashoutEnd", c0ccab659980fa5dcb134474e24e14b49);
				mc_Box.gotoAndPlay("flashout");
				mc_Box.removeEventListener(MouseEvent.CLICK, cc3d77d94332a67a66abd57fcd87bef69);
				mc_Box.removeEventListener(MouseEvent.MOUSE_ENTER, cadce22e7a666664f05dd9df730828905);
				mc_Box.removeEventListener(MouseEvent.MOUSE_LEAVE, c1e8cc2494908a8ab5afd4e62348f4deb);
				return;
			}
		}

		protected void c0ccab659980fa5dcb134474e24e14b49(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_Box.removeFrameScript("flashoutEnd", c0ccab659980fa5dcb134474e24e14b49);
			mc_Box.visible = false;
			mc_Slot.visible = true;
			if (m_itemDNA.m_type == ItemType.Material)
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
				MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(m_itemDNA.m_materialType);
				movieClip.alpha = m_fAlpha;
				MovieClip movieClip2 = movieClip.newInstance();
				movieClip2.name = "icon";
				movieClip2.alpha = m_fAlpha;
				MovieClip childByName = mc_Slot.getChildByName<MovieClip>("icons");
				childByName.stopAll();
				childByName.addChild(movieClip2);
			}
			else if (m_itemDNA.m_type == ItemType.Money)
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
				MovieClip movieClip3 = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c28ee12a3e8557af117e75c0f0133c2f3();
				movieClip3.alpha = m_fAlpha;
				MovieClip movieClip4 = movieClip3.newInstance();
				movieClip4.name = "icon";
				movieClip4.alpha = m_fAlpha;
				MovieClip childByName2 = mc_Slot.getChildByName<MovieClip>("icons");
				childByName2.stopAll();
				childByName2.addChild(movieClip4);
			}
			else
			{
				Texture2D cf83e762e4368c5dedaab3e73ad69452e = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(m_itemDNA);
				m_imageLoader.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e);
			}
			if (m_itemDNA.m_type != ItemType.Money)
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
				base.cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(m_itemDNA);
			}
			int num = int.Parse(mc_Box.name.Substring(mc_Box.name.Length - 1, 1));
			if (num == LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().cf9ca16030e575997356fc88266bdcca7(m_bIsLocked))
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						mc_Slot.addFrameScript("selected", cdd10e87905d62334594c51af122b922f);
						mc_Slot.gotoAndStop("selected");
						(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>() as uniHUDTreasureBoxView).c6f93125d9c0bdb53f27fd135d86166c2(m_bIsLocked);
						return;
					}
				}
			}
			mc_Slot.addFrameScript("unpicked", c7b7c7d4b44dd971fe54640ffa099d3d2);
			mc_Slot.gotoAndStop("unpicked");
		}

		private void c61f2f93187891e3dbe9f42a697871585()
		{
			m_tfNumber = mc_Slot.getChildByName<TextField>("textNumber");
			m_tfNumber.text = string.Empty;
		}

		protected void cdd10e87905d62334594c51af122b922f(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_Slot.removeFrameScript("selected", cdd10e87905d62334594c51af122b922f);
			c61f2f93187891e3dbe9f42a697871585();
		}

		protected void c7b7c7d4b44dd971fe54640ffa099d3d2(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_Slot.removeFrameScript("unpicked", c7b7c7d4b44dd971fe54640ffa099d3d2);
			c61f2f93187891e3dbe9f42a697871585();
		}

		protected void ce4d554737ceae040e96e796d73a6ff68(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_Box.removeFrameScript("weapon_load_pic", ce4d554737ceae040e96e796d73a6ff68);
			m_tfNumber.text = "x" + m_itemDNA.m_value;
			MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(m_itemDNA.m_materialType);
			movieClip.alpha = m_fAlpha;
			MovieClip movieClip2 = movieClip.newInstance();
			movieClip2.name = "icon";
			movieClip2.alpha = m_fAlpha;
			MovieClip childByName = mc_Box.getChildByName<MovieClip>("icons");
			childByName.stopAll();
			childByName.addChild(movieClip2);
		}
	}

	private class TreasureBoxPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CloseBtn;

		private MovieClip mc_Box1;

		private MovieClip mc_Box2;

		private MovieClip mc_Box3;

		private TextField tf_Keys;

		private List<TreasureBox> m_BoxList;

		protected c7beefc397f483dc0b72dcd3e6bdcf929 testLoader;

		protected GameObject testObj;

		protected GameObject cameraObj;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map1E;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
					switch (3)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
					if (value)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
							{
								for (int i = 0; i < m_BoxList.Count; i++)
								{
									m_BoxList[i].c4359882fe569b03ba6dba29001e11030();
								}
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										caa9354f1402aa27f2e8f3833ea3e802d();
										mc_root.visible = true;
										mc_root.gotoAndPlay("fadein");
										tf_Keys.text = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().cdfd935f4433ff75143d2f554dc03490c()
											.ToString();
										return;
									}
								}
							}
							}
						}
					}
					mc_root.gotoAndPlay("fadeout");
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: TreasureBoxPanel onInit() 'mc_root' is null! TreasureBoxPanel won't work!!!");
						return;
					}
				}
			}
			m_BoxList = new List<TreasureBox>();
			m_BoxList.Clear();
			mc_root.stopAll();
			mc_root.visible = false;
			mc_CloseBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CloseBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_closeButton"));
			mc_CloseBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			tf_Keys = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<TextField>("textAccount");
			mc_Box1 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box1");
			mc_Box2 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box2");
			mc_Box3 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box3");
			TreasureBox treasureBox = new TreasureBox(false);
			treasureBox.ce13d3cdd9d187c1d08b123cb2ee56943(mc_Box1, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot1"));
			TreasureBox treasureBox2 = new TreasureBox(false);
			treasureBox2.ce13d3cdd9d187c1d08b123cb2ee56943(mc_Box2, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot2"));
			TreasureBox treasureBox3 = new TreasureBox(false);
			treasureBox3.ce13d3cdd9d187c1d08b123cb2ee56943(mc_Box3, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot3"));
			MovieClip childByName = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box4");
			MovieClip childByName2 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box5");
			MovieClip childByName3 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box6");
			TreasureBox treasureBox4 = new TreasureBox(true);
			treasureBox4.ce13d3cdd9d187c1d08b123cb2ee56943(childByName, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot4"));
			TreasureBox treasureBox5 = new TreasureBox(true);
			treasureBox5.ce13d3cdd9d187c1d08b123cb2ee56943(childByName2, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot5"));
			TreasureBox treasureBox6 = new TreasureBox(true);
			treasureBox6.ce13d3cdd9d187c1d08b123cb2ee56943(childByName3, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot6"));
			m_BoxList.Add(treasureBox);
			m_BoxList.Add(treasureBox2);
			m_BoxList.Add(treasureBox3);
			m_BoxList.Add(treasureBox4);
			m_BoxList.Add(treasureBox5);
			m_BoxList.Add(treasureBox6);
			caa9354f1402aa27f2e8f3833ea3e802d();
		}

		private void caa9354f1402aa27f2e8f3833ea3e802d()
		{
			string c9954ef00e56565ae66cf4f80961951d = "iron";
			switch (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWrapupView>().m_instanceGrade)
			{
			case InstanceGrade.D:
				c9954ef00e56565ae66cf4f80961951d = "iron";
				break;
			case InstanceGrade.C:
				c9954ef00e56565ae66cf4f80961951d = "bronze";
				break;
			case InstanceGrade.B:
				c9954ef00e56565ae66cf4f80961951d = "silver";
				break;
			case InstanceGrade.A:
				c9954ef00e56565ae66cf4f80961951d = "gold";
				break;
			case InstanceGrade.S:
				c9954ef00e56565ae66cf4f80961951d = "platinum";
				break;
			}
			for (int i = 0; i < m_BoxList.Count; i++)
			{
				m_BoxList[i].c68730ec8aaf6846674689e4f4bfca072(c9954ef00e56565ae66cf4f80961951d);
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

		protected void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}

		public void c34d668560660d3e6282a1bcef2bc598b(Texture cd6102468cd57214a9f3e10633998391b)
		{
			testLoader.c533af2b08173b7c2e3e5405efc254ee3(cd6102468cd57214a9f3e10633998391b);
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map1E == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcAvatar", 0);
					_003C_003Ef__switch_0024map1E = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map1E.TryGetValue(name, out value))
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
					if (value != 0)
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
					}
					else
					{
						movieClip.stopAll();
						testLoader = new c7beefc397f483dc0b72dcd3e6bdcf929();
						testLoader.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
					}
				}
			}
			return result;
		}

		public void c6f93125d9c0bdb53f27fd135d86166c2(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
		{
			int num = LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().cf9ca16030e575997356fc88266bdcca7(cbd1884b6d3b625a8ec599b0ab246eb01);
			int num2 = 1;
			if (!cbd1884b6d3b625a8ec599b0ab246eb01)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						for (int i = 0; i < 3; i++)
						{
							if (i != num - 1)
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
								m_BoxList[i].c715d058075f0265bb392b1c6949f6e1c(LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().ca98df7948f1e617dffb496037571e81c(num2, cbd1884b6d3b625a8ec599b0ab246eb01));
								num2++;
							}
						}
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
					}
				}
			}
			for (int j = 3; j < 6; j++)
			{
				if (j == num - 1)
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
				m_BoxList[j].c715d058075f0265bb392b1c6949f6e1c(LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().ca98df7948f1e617dffb496037571e81c(num2, cbd1884b6d3b625a8ec599b0ab246eb01));
				num2++;
			}
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

		public void c01a658b50fbe8877dbf1c7e9881dd684(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
		{
			if (cbd1884b6d3b625a8ec599b0ab246eb01)
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
				tf_Keys.text = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTreasureBoxView>().cdfd935f4433ff75143d2f554dc03490c()
					.ToString();
			}
			int num = LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().cf9ca16030e575997356fc88266bdcca7(cbd1884b6d3b625a8ec599b0ab246eb01);
			if (num != 0)
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
				m_BoxList[num - 1].c715d058075f0265bb392b1c6949f6e1c(LuckyBoxManager.c71f6ce28731edfd43c976fbd57c57bea().c02bc6f816bafc46b05ad6ab3fda2f3b2(cbd1884b6d3b625a8ec599b0ab246eb01));
			}
			mc_CloseBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			mc_CloseBtn.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
		}
	}

	private TreasureBoxPanel _treasureBoxPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("K-box.swf", "K_box", c0859e788f37fa5ecec9741b38e833712);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_treasureBoxPanel);
		_treasureBoxPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("K-box.swf");
	}

	private void c0859e788f37fa5ecec9741b38e833712(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_treasureBoxPanel = new TreasureBoxPanel();
		_treasureBoxPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + "Add Lucky box to top!!!" + DateTime.Today.ToString());
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_treasureBoxPanel != null)
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
						(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c120a0ab44e69ef682f36041c0b116750(_treasureBoxPanel);
					}
					_treasureBoxPanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
					return;
				}
			}
		}
		if (!c8be1fcd630e5fe96821376d111325750)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + " Lucky box view is null!!!" + DateTime.Today.ToString());
			return;
		}
	}

	public override void c34d668560660d3e6282a1bcef2bc598b(Texture cd6102468cd57214a9f3e10633998391b)
	{
		base.c34d668560660d3e6282a1bcef2bc598b(cd6102468cd57214a9f3e10633998391b);
		if (_treasureBoxPanel == null)
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
			_treasureBoxPanel.c34d668560660d3e6282a1bcef2bc598b(cd6102468cd57214a9f3e10633998391b);
			return;
		}
	}

	public override void c01a658b50fbe8877dbf1c7e9881dd684(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		base.c01a658b50fbe8877dbf1c7e9881dd684(cbd1884b6d3b625a8ec599b0ab246eb01);
		if (_treasureBoxPanel == null)
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
			_treasureBoxPanel.c01a658b50fbe8877dbf1c7e9881dd684(cbd1884b6d3b625a8ec599b0ab246eb01);
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWrapupView>() as uniHUDWrapupView).c18a62da240926bd18528ca36e6e83ac3();
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDPvPInfoView>() as uniHUDPvPInfoView).ce421ed184b36b13e7072feb7da58f0ae();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.DefaultCursor);
			return;
		}
	}

	public void c6f93125d9c0bdb53f27fd135d86166c2(bool cbd1884b6d3b625a8ec599b0ab246eb01 = false)
	{
		if (_treasureBoxPanel == null)
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
			_treasureBoxPanel.c6f93125d9c0bdb53f27fd135d86166c2(cbd1884b6d3b625a8ec599b0ab246eb01);
			return;
		}
	}
}
