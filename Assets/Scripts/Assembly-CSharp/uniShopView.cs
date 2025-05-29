using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniShopView : ShopView
{
	protected class ShopPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected class ShopItemSlot : c87da635fd7858aaa8f8053a95f123b32
		{
			protected UnityTextField _textPrice;

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				_textPrice = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<UnityTextField>("textPrice");
				if (_textPrice == null)
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
					_textPrice.text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
					_textPrice.visible = false;
					return;
				}
			}

			public void c05827e484a7f6b48421dbc2aaacc28ab(ShopItemUIData cb4be6dae1755138c26d22542471266a1)
			{
				ca37fcdce7d4937b60735f4033eb55695.removeEventListener(CEvent.ENTER_FRAME, cf5d745df5fd4d19639167da3c0405618);
				MovieClip childByName = cf60cea27899464ecfab889519bbd47e7.getChildByName<MovieClip>("icon");
				if (childByName != null)
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
					cf60cea27899464ecfab889519bbd47e7.removeChild(childByName);
				}
				base.c591d56a94543e3559945c497f37126c4 = cb4be6dae1755138c26d22542471266a1;
				if (cb4be6dae1755138c26d22542471266a1 != null)
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
					if (cb4be6dae1755138c26d22542471266a1.RelateData != null)
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
						if (cb4be6dae1755138c26d22542471266a1.RelateData.Item != null)
						{
							if (_textPrice != null)
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
								_textPrice.text = "$ " + cb4be6dae1755138c26d22542471266a1.RelateData.Price;
								_textPrice.visible = true;
								UnityTextField textPrice = _textPrice;
								Color c34fce3bccfffc6feb3579939c6d9a;
								if (cb4be6dae1755138c26d22542471266a1.bAffordable)
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
									c34fce3bccfffc6feb3579939c6d9a = Color.green;
								}
								else
								{
									c34fce3bccfffc6feb3579939c6d9a = Color.red;
								}
								textPrice.c34fce3bccfffc6feb3579939c6d9a057 = c34fce3bccfffc6feb3579939c6d9a;
							}
							if (cb4be6dae1755138c26d22542471266a1.RelateData.Item.m_type == ItemType.Material)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
									{
										MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(cb4be6dae1755138c26d22542471266a1.RelateData.Item.m_materialType);
										if (movieClip != null)
										{
											while (true)
											{
												switch (1)
												{
												case 0:
													break;
												default:
												{
													base.c1d4a927ba62b28412f982cec1c20bc7a = false;
													MovieClip movieClip2 = movieClip.newInstance();
													movieClip2.name = "icon";
													base.cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
													cf60cea27899464ecfab889519bbd47e7.stopAll();
													cf60cea27899464ecfab889519bbd47e7.addChild(movieClip2);
													base.c7a6152d8035cf59072f2f7297bf180ad = false;
													c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
													return;
												}
												}
											}
										}
										return;
									}
									}
								}
							}
							base.c7a6152d8035cf59072f2f7297bf180ad = true;
							c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = false;
							Texture2D cf83e762e4368c5dedaab3e73ad69452e = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(cb4be6dae1755138c26d22542471266a1.RelateData.Item);
							c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e);
							ca37fcdce7d4937b60735f4033eb55695.addEventListener(CEvent.ENTER_FRAME, cf5d745df5fd4d19639167da3c0405618);
							base.cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(cb4be6dae1755138c26d22542471266a1.RelateData.Item);
							return;
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
				base.cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
				base.quantity = 0;
				c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = false;
				c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
				base.c7a6152d8035cf59072f2f7297bf180ad = false;
				if (_textPrice == null)
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
					_textPrice.text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
					_textPrice.visible = false;
					return;
				}
			}

			protected void cf5d745df5fd4d19639167da3c0405618(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				if (!c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c4eb4b65926bb326691460e35136288d0(((ShopItemUIData)base.c591d56a94543e3559945c497f37126c4).RelateData.Item))
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
					ca37fcdce7d4937b60735f4033eb55695.removeEventListener(CEvent.ENTER_FRAME, cf5d745df5fd4d19639167da3c0405618);
					base.c7a6152d8035cf59072f2f7297bf180ad = false;
					c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = true;
					return;
				}
			}
		}

		public delegate void DeleOnClickClose();

		public delegate void DeleOnClickShopItem(ShopItemUIData itemData);

		public delegate void DeleOnSwitchTab(ShopTabState newState);

		protected const int MAX_SLOT_COUNT = 14;

		protected const string SLOT_NAME_PREFIX = "mcItem_";

		protected const string TAB_NAME_PREFIX = "mcTab_";

		protected const string TAB_BTNGROUP_NAME = "ShopButtonGroupName";

		protected ShopTabState _curTab;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _XBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c6425d3761c85e65e3530cc19d085d446 _btnPurchase = new c6425d3761c85e65e3530cc19d085d446();

		protected c6425d3761c85e65e3530cc19d085d446 _btnSold = new c6425d3761c85e65e3530cc19d085d446();

		protected ShopItemSlot[] _itemSlotAry = new ShopItemSlot[14];

		protected cf7ac05203029a27299d6893b2dbaee2e _scBar = new cf7ac05203029a27299d6893b2dbaee2e();

		protected TextField _textRefreshTime;

		protected TextField _textDescription;

		protected List<ShopItemUIData> _onShowItemList = new List<ShopItemUIData>();

		protected DeleOnClickClose _deleOnClickClose;

		protected DeleOnClickShopItem _deleOnClickShopItem;

		protected DeleOnSwitchTab _deleOnSwitchTab;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map2A;

		public DeleOnClickClose ccfe8288a25263bb240beb84660537167
		{
			set
			{
				_deleOnClickClose = value;
			}
		}

		public DeleOnClickShopItem c10253512c37b5daa33d132e1d8221867
		{
			set
			{
				_deleOnClickShopItem = value;
			}
		}

		public DeleOnSwitchTab cfd3403b41ab96eeeb4620c8e275ae784
		{
			set
			{
				_deleOnSwitchTab = value;
			}
		}

		public void c02bb7f4232389fa6f63ec0ca36c10606(ShopTabState c7d77be03dd09783b7cf45209bd57d03e)
		{
			_curTab = c7d77be03dd09783b7cf45209bd57d03e;
			if (c7d77be03dd09783b7cf45209bd57d03e == ShopTabState.Shop)
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
						if (_btnPurchase != null)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									_btnPurchase.c9c364a8fd1f013589fea518a3924e711 = true;
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (c7d77be03dd09783b7cf45209bd57d03e != ShopTabState.SoldItems)
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
				if (_btnSold == null)
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
					_btnSold.c9c364a8fd1f013589fea518a3924e711 = true;
					return;
				}
			}
		}

		public void c927709aa8f87ff9b7fa5b03683bfbfdc(string c2a73e60de19e13648b3e6f51adc52b57)
		{
			if (_textRefreshTime == null)
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
				return;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("mcItem_"))
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
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				if (array2.Length > 1)
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
					int num = Convert.ToInt32(array2[1]) - 1;
					if (num < 14)
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
						if (_itemSlotAry[num] == null)
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
							_itemSlotAry[num] = new ShopItemSlot();
						}
						_itemSlotAry[num].c130648b59a0c8debea60aa153f844879(movieClip);
						_itemSlotAry[num].removeAllEventListeners(MouseEvent.CLICK);
						_itemSlotAry[num].addEventListener(MouseEvent.CLICK, c6a70fd9feff88d029afec071ee28a14b);
						result = true;
					}
				}
			}
			else
			{
				string name2 = movieClip.name;
				if (name2 != null)
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
					if (_003C_003Ef__switch_0024map2A == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(6);
						dictionary.Add("mcXButton", 0);
						dictionary.Add("mcTabPurchase", 1);
						dictionary.Add("mcTabSold", 2);
						dictionary.Add("mcScrollingBar", 3);
						dictionary.Add("mcItemSpecial", 4);
						dictionary.Add("mcBackButton", 5);
						_003C_003Ef__switch_0024map2A = dictionary;
					}
					int value;
					if (_003C_003Ef__switch_0024map2A.TryGetValue(name2, out value))
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
						switch (value)
						{
						case 0:
							_XBtn.c130648b59a0c8debea60aa153f844879(movieClip);
							_XBtn.removeAllEventListeners(MouseEvent.CLICK);
							_XBtn.addEventListener(MouseEvent.CLICK, c83f5d510d483adac7af2c6c9fdf95b71);
							result = true;
							break;
						case 1:
							_btnPurchase.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnPurchase.c9c364a8fd1f013589fea518a3924e711 = true;
							_btnPurchase.ce84b930a12a1d06512c79320b3f0d3f4 = false;
							_btnPurchase.cec024da8c099380cfe1334bfe4c8f30f = "ShopButtonGroupName";
							_btnPurchase.c6279c42b47398c5e401c1cff54ce61c2.addEventListener(CEvent.CHANGED, c61baf50b7bf8d9b933d01d693f41ee2d);
							_btnPurchase.c9c364a8fd1f013589fea518a3924e711 = true;
							result = true;
							break;
						case 2:
							_btnSold.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnSold.ce84b930a12a1d06512c79320b3f0d3f4 = false;
							_btnSold.cec024da8c099380cfe1334bfe4c8f30f = "ShopButtonGroupName";
							result = true;
							break;
						case 3:
							movieClip.visible = false;
							_scBar.c130648b59a0c8debea60aa153f844879(movieClip);
							_scBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
							_scBar.cfcb3294d851a0336d3f3a8f2a943f2fb = (_scBar.c9c58dff860effc1212c1afb5d14e147c = 0);
							result = true;
							break;
						case 4:
							movieClip.visible = false;
							result = true;
							break;
						case 5:
							movieClip.visible = false;
							result = true;
							break;
						}
					}
				}
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcTabPurchase");
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				_btnPurchase.c130648b59a0c8debea60aa153f844879(childByName);
			}
			_textRefreshTime = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textRefreshTime");
			if (_textRefreshTime != null)
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
				_textRefreshTime.visible = false;
			}
			_textDescription = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textDescription");
			if (_textDescription != null)
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
				_textDescription.text = string.Empty;
			}
			c2b2d805ee2e3f1fe03749d38403b112b(0);
		}

		protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			int cef9712200bbe2c3873eec3ca2e18a = _scBar.cef9712200bbe2c3873eec3ca2e18a595;
			c2b2d805ee2e3f1fe03749d38403b112b(cef9712200bbe2c3873eec3ca2e18a);
		}

		protected void c61baf50b7bf8d9b933d01d693f41ee2d(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_deleOnSwitchTab == null)
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
			if (_btnPurchase.c9c364a8fd1f013589fea518a3924e711)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						_curTab = ShopTabState.Shop;
						_deleOnSwitchTab(ShopTabState.Shop);
						return;
					}
				}
			}
			if (!_btnSold.c9c364a8fd1f013589fea518a3924e711)
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
				_curTab = ShopTabState.SoldItems;
				_deleOnSwitchTab(ShopTabState.SoldItems);
				return;
			}
		}

		protected void c6a70fd9feff88d029afec071ee28a14b(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			ShopItemSlot shopItemSlot = c3d202dee321219a80026dc3081fb3c86.target as ShopItemSlot;
			if (shopItemSlot == null)
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
				if (_deleOnClickShopItem == null)
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
					ShopItemUIData shopItemUIData = shopItemSlot.c591d56a94543e3559945c497f37126c4 as ShopItemUIData;
					if (shopItemUIData == null)
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
						_deleOnClickShopItem(shopItemUIData);
						return;
					}
				}
			}
		}

		public void cd863d77a7a88229d3a5ec5ec4dafd965(List<ShopItemUIData> c06da6e53dcfe4a4720bcb8bf4abf1866)
		{
			_onShowItemList = c06da6e53dcfe4a4720bcb8bf4abf1866;
			if (_scBar != null)
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
				if (_onShowItemList != null)
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
					cf7ac05203029a27299d6893b2dbaee2e scBar = _scBar;
					int c150264a18c2cb408479d3f072cac8cc;
					if (_curTab == ShopTabState.SoldItems)
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
						c150264a18c2cb408479d3f072cac8cc = ((_onShowItemList.Count > 14) ? 1 : 0);
					}
					else
					{
						c150264a18c2cb408479d3f072cac8cc = 0;
					}
					scBar.c150264a18c2cb408479d3f072cac8cc1 = (byte)c150264a18c2cb408479d3f072cac8cc != 0;
					int cf512520c53a47d360d189f1963c2a5b = 7;
					int c07d769aff526665b054ae3f98b6c334c = _onShowItemList.Count >> 1;
					_scBar.c5a7d812d0a8e674b21eb0ed8824a2f59(cf512520c53a47d360d189f1963c2a5b, 0, c07d769aff526665b054ae3f98b6c334c, 1);
					goto IL_0098;
				}
			}
			_scBar.c150264a18c2cb408479d3f072cac8cc1 = false;
			goto IL_0098;
			IL_0098:
			c2b2d805ee2e3f1fe03749d38403b112b(0);
		}

		protected void c2b2d805ee2e3f1fe03749d38403b112b(int c5814938c243573c6cc02b8596abe5101)
		{
			if (_onShowItemList == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						ShopItemSlot[] itemSlotAry = _itemSlotAry;
						foreach (ShopItemSlot shopItemSlot in itemSlotAry)
						{
							if (shopItemSlot != null)
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
								shopItemSlot.c05827e484a7f6b48421dbc2aaacc28ab(null);
							}
						}
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
					}
				}
			}
			int j = 0;
			for (int k = c5814938c243573c6cc02b8596abe5101 * 2; k < _onShowItemList.Count; k++)
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
				if (j < _itemSlotAry.Length)
				{
					if (_itemSlotAry[j] != null)
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
						if (_onShowItemList[k] != null)
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
							_itemSlotAry[j].c05827e484a7f6b48421dbc2aaacc28ab(_onShowItemList[k]);
						}
					}
					j++;
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
			for (; j < _itemSlotAry.Length; j++)
			{
				if (_itemSlotAry[j] == null)
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
				_itemSlotAry[j].c05827e484a7f6b48421dbc2aaacc28ab(null);
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

		protected void c83f5d510d483adac7af2c6c9fdf95b71(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_deleOnClickClose == null)
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
				_deleOnClickClose();
				return;
			}
		}
	}

	protected uniInventoryView.InventoryPanel _inventoryPanel;

	protected MovieClip _mcRoot;

	protected c196099a1254db61d3be10d70e14e7422 _panelRoot;

	protected ShopPanel _shopRoot;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c968ae3f7ba22e4826b18039ba36f33ce(this, new Vector2(0f, 0f));
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Shop.swf", "Panel_Shop", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		_inventoryPanel = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c796c173865ebd0e0606dad33b499db0b;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panelRoot);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Shop.swf");
		_inventoryPanel = null;
		_panelRoot = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		_shopRoot = null;
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_mcRoot = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
		_mcRoot.visible = false;
		_panelRoot = new c196099a1254db61d3be10d70e14e7422();
		_panelRoot.c130648b59a0c8debea60aa153f844879(_mcRoot);
		_shopRoot = new ShopPanel();
		_shopRoot.ccfe8288a25263bb240beb84660537167 = c83f5d510d483adac7af2c6c9fdf95b71;
		_shopRoot.c10253512c37b5daa33d132e1d8221867 = c167c6648e24d0e39d64ca92b49fa2fe8;
		_shopRoot.cfd3403b41ab96eeeb4620c8e275ae784 = cb5b07d55759e104a9ecf651cff64071b;
		_mcRoot.addFrameScript("Open", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRoot.addFrameScript("Normal", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRoot.addFrameScript("Close", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRoot.addFrameScript("End", ca45aa4038153928bb3c25fc71e6c45e1);
		MovieClip childByName = _mcRoot.getChildByName<MovieClip>("mcRoot");
		if (childByName != null)
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
			_shopRoot.c130648b59a0c8debea60aa153f844879(childByName);
		}
		MovieClip childByName2 = _mcRoot.getChildByName<MovieClip>("mcInventoryPosition");
		if (childByName2 != null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c968ae3f7ba22e4826b18039ba36f33ce(this, ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c46e387bea9111b07d3d0e2e52548626c(childByName2, Vector2.zero));
		}
		_bActive = true;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_inventoryPanel == null)
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
			_inventoryPanel = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c796c173865ebd0e0606dad33b499db0b;
		}
		if (_inventoryPanel != null)
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
			if (_bVisible)
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
				_inventoryPanel.addEventListener("Item" + MouseEvent.CLICK, c3f07aa998bf303194d0f7ebe96fc957c);
			}
			else
			{
				_inventoryPanel.removeEventListener("Item" + MouseEvent.CLICK, c3f07aa998bf303194d0f7ebe96fc957c);
			}
		}
		if (_mcRoot == null)
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
			if (c8be1fcd630e5fe96821376d111325750)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_panelRoot);
						_mcRoot.visible = true;
						_mcRoot.gotoAndPlay("Open");
						return;
					}
				}
			}
			_mcRoot.gotoAndPlay("Close");
			if (_shopRoot == null)
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
				_shopRoot.c02bb7f4232389fa6f63ec0ca36c10606(ShopTabState.Shop);
				return;
			}
		}
	}

	protected void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = _mcRoot.getChildByName<MovieClip>("mcRoot");
		if (childByName == null)
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
			_shopRoot.c130648b59a0c8debea60aa153f844879(childByName);
			return;
		}
	}

	protected void ca45aa4038153928bb3c25fc71e6c45e1(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_mcRoot.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panelRoot);
	}

	protected override void c363ffa9972525058a49f41a533885921()
	{
		base.c363ffa9972525058a49f41a533885921();
		if (_shopRoot == null)
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
			_shopRoot.cd863d77a7a88229d3a5ec5ec4dafd965(_onShowItemList);
			return;
		}
	}

	protected override void c04cc4c530372db0a04d942ee08561daa()
	{
		base.c04cc4c530372db0a04d942ee08561daa();
		string c2a73e60de19e13648b3e6f51adc52b = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		if (_bVisible)
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
			if (_curState == ShopTabState.Shop)
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
				c2a73e60de19e13648b3e6f51adc52b = _remainTime.Hours + ":" + _remainTime.Minutes;
			}
		}
		if (_shopRoot == null)
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
			_shopRoot.c927709aa8f87ff9b7fa5b03683bfbfdc(c2a73e60de19e13648b3e6f51adc52b);
			return;
		}
	}

	protected void c3f07aa998bf303194d0f7ebe96fc957c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		c2c3ac86434d1a4c7cff44aeb0e855931(((UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4).index);
	}

	protected override void c6c05b7fcf02ae4ca0a240a5e85fc0da2()
	{
		base.c6c05b7fcf02ae4ca0a240a5e85fc0da2();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Vending_Buy");
	}

	protected override void c9d043fcf67d0622298737fab331bacb1()
	{
		base.c9d043fcf67d0622298737fab331bacb1();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Vending_Sell");
	}

	protected override void cc1c2481d0270b1299a68075c97ce0d6a()
	{
		base.cc1c2481d0270b1299a68075c97ce0d6a();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Vending_Insufficient_Funds");
	}

	protected override void cc000a344cdad533d803612c38cc86b08()
	{
		base.cc000a344cdad533d803612c38cc86b08();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Vending_No_Money");
	}

	protected void c83f5d510d483adac7af2c6c9fdf95b71()
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected void c167c6648e24d0e39d64ca92b49fa2fe8(ShopItemUIData cb4be6dae1755138c26d22542471266a1)
	{
		if (_curState == ShopTabState.Shop)
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
					c0daf1eb16f82daaf7d68848a80e12ec8(cb4be6dae1755138c26d22542471266a1);
					return;
				}
			}
		}
		if (_curState != ShopTabState.SoldItems)
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
			c80a25b271ce3a17774934ece68f549eb(cb4be6dae1755138c26d22542471266a1);
			return;
		}
	}

	protected void cb5b07d55759e104a9ecf651cff64071b(ShopTabState c7d77be03dd09783b7cf45209bd57d03e)
	{
		ce949eff967c8bef62f7ca157b7e3d4af(c7d77be03dd09783b7cf45209bd57d03e);
	}
}
