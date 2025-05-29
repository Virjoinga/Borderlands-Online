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

public class uniPauseMenuView : PauseMenuView
{
	protected class EscMenuPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected delegate void onClickBtn();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnBackToGame = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnOptions = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnQuitInstance = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnRespawn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnExitGame = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnReplayTutorial = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map23;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map23 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(6);
					dictionary.Add("btnBackToGame", 0);
					dictionary.Add("btnOptions", 1);
					dictionary.Add("btnQuitInstance", 2);
					dictionary.Add("btnRespawn", 3);
					dictionary.Add("btnExit", 4);
					dictionary.Add("btnReplayTutorial", 5);
					_003C_003Ef__switch_0024map23 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map23.TryGetValue(name, out value))
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
						_btnBackToGame.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnBackToGame.removeAllEventListeners(MouseEvent.CLICK);
						_btnBackToGame.addEventListener(MouseEvent.CLICK, c6d01a5982183f0c0365348c102cbc7cf);
						result = true;
						break;
					case 1:
						_btnOptions.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnOptions.removeAllEventListeners(MouseEvent.CLICK);
						_btnOptions.addEventListener(MouseEvent.CLICK, c80c1be8ff023ddf24aaf28b067ae41a4);
						result = true;
						break;
					case 2:
						_btnQuitInstance.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnQuitInstance.removeAllEventListeners(MouseEvent.CLICK);
						_btnQuitInstance.addEventListener(MouseEvent.CLICK, c63174c0a9f3b938e5621af466e464500);
						result = true;
						break;
					case 3:
						_btnRespawn.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnRespawn.removeAllEventListeners(MouseEvent.CLICK);
						_btnRespawn.addEventListener(MouseEvent.CLICK, c3833e9078298ed25e690fa5cb2faba35);
						result = true;
						break;
					case 4:
						_btnExitGame.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnExitGame.removeAllEventListeners(MouseEvent.CLICK);
						_btnExitGame.addEventListener(MouseEvent.CLICK, ce57b553191a96c2db68b10803829a37c);
						result = true;
						break;
					case 5:
						_btnReplayTutorial.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnReplayTutorial.removeAllEventListeners(MouseEvent.CLICK);
						_btnReplayTutorial.addEventListener(MouseEvent.CLICK, cacb9d2fa64b03d960f07b5b8df0eac3a);
						result = true;
						break;
					}
				}
			}
			return result;
		}

		protected void c80c1be8ff023ddf24aaf28b067ae41a4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 e = new cdd9021d4f44808fce2ab49c52f0db6f7(EscMenuFunction.GameOptions.ToString(), null);
			dispatchEvent(e);
		}

		protected void c63174c0a9f3b938e5621af466e464500(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 e = new cdd9021d4f44808fce2ab49c52f0db6f7(EscMenuFunction.QuitInstance.ToString(), null);
			dispatchEvent(e);
		}

		protected void c6d01a5982183f0c0365348c102cbc7cf(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 e = new cdd9021d4f44808fce2ab49c52f0db6f7(EscMenuFunction.BackToGame.ToString(), null);
			dispatchEvent(e);
		}

		protected void c3833e9078298ed25e690fa5cb2faba35(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 e = new cdd9021d4f44808fce2ab49c52f0db6f7(EscMenuFunction.Respawn.ToString(), null);
			dispatchEvent(e);
		}

		protected void ce57b553191a96c2db68b10803829a37c(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 e = new cdd9021d4f44808fce2ab49c52f0db6f7(EscMenuFunction.ExitGame.ToString(), null);
			dispatchEvent(e);
		}

		protected void cacb9d2fa64b03d960f07b5b8df0eac3a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 e = new cdd9021d4f44808fce2ab49c52f0db6f7(EscMenuFunction.ReplayTutorial.ToString(), null);
			dispatchEvent(e);
		}

		public void c9805ba91d6c6ad00e40cba71c6079d3f(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			_btnRespawn.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
		}

		public void cffcbeac9a39b2cea767263041a6b5c38(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			_btnQuitInstance.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
		}

		public void c8cf8eceb6cfc97d28820bb77800dbe1f(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			_btnReplayTutorial.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
		}
	}

	protected class OptionsMenuPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected class SettingCatogoryTab : c6425d3761c85e65e3530cc19d085d446
		{
			protected int _iIndex = -1;

			protected SettingCategory _category;

			public int c79163fa3657843afb073bdf6e707c9fc
			{
				get
				{
					return _iIndex;
				}
			}

			public SettingCategory c23cee373240060d3f7436af859b589c1
			{
				get
				{
					return _category;
				}
			}

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				int num = base.c89ef242f4744e0f1c4ffea4da8b79bc1.name.IndexOf('_');
				int num2 = base.c89ef242f4744e0f1c4ffea4da8b79bc1.name.LastIndexOf('_');
				if (num2 != -1)
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
					if (num != -1)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								_iIndex = Convert.ToInt32(base.c89ef242f4744e0f1c4ffea4da8b79bc1.name.Substring(num2 + 1));
								_category = (SettingCategory)(int)Enum.Parse(Type.GetTypeFromHandle(ce9dd45ec611a2b8f620ca39ba40139af.cc1720d05c75832f704b87474932341c3()), base.c89ef242f4744e0f1c4ffea4da8b79bc1.name.Substring(num + 1, num2 - num - 1));
								return;
							}
						}
					}
				}
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Wrong MovieClip Name " + base.c89ef242f4744e0f1c4ffea4da8b79bc1.name);
			}
		}

		protected class SettingMenuList : c196099a1254db61d3be10d70e14e7422
		{
			protected const int ITEM_SLOT_COUNT = 14;

			protected const string ITEM_NAME_PREFIX = "mcItem_";

			protected cf7ac05203029a27299d6893b2dbaee2e _scBar = new cf7ac05203029a27299d6893b2dbaee2e();

			protected SettingMenuItemContainer[] _itemList = new SettingMenuItemContainer[14];

			protected List<GameSettingMgr.SettingItemData> _dataList = new List<GameSettingMgr.SettingItemData>();

			protected string _strGroupLabel;

			public string c72c0fd272db1789b79a29eaaaef7e9f8
			{
				set
				{
					_strGroupLabel = value;
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
					int num = movieClip.name.IndexOf('_');
					if (num != -1)
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
						string value = movieClip.name.Substring(num + 1);
						int num2 = Convert.ToInt32(value);
						if (num2 >= 0)
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
							if (num2 < 14)
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
								if (_itemList[num2] == null)
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
									string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
									array[0] = EVT_MOUSE_ENTER_SETTINGITEM;
									array[1] = EVT_MOUSE_LEAVE_SETTINGITEM;
									array[2] = EVT_SETTINGITEM_DATA_CHANGED;
									array[3] = EVT_CLICK_SETTINGITEM;
									array[4] = EVT_CLICK_LEFT_KEY;
									array[5] = EVT_CLICK_RIGHT_KEY;
									string[] array2 = array;
									_itemList[num2] = new SettingMenuItemContainer();
									string[] array3 = array2;
									foreach (string type in array3)
									{
										_itemList[num2].removeAllEventListeners(type);
										_itemList[num2].addEventListener(type, c1217d5959a1637e514cbe150c61da19b);
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
									_itemList[num2].c72c0fd272db1789b79a29eaaaef7e9f8 = _strGroupLabel;
								}
								_itemList[num2].c130648b59a0c8debea60aa153f844879(movieClip);
							}
						}
					}
				}
				else if (movieClip.name == "mcScrollingBar")
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
					_scBar.c130648b59a0c8debea60aa153f844879(movieClip);
					_scBar.removeAllEventListeners("Scrolling");
					_scBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
					_scBar.c9c58dff860effc1212c1afb5d14e147c = (_scBar.cfcb3294d851a0336d3f3a8f2a943f2fb = 0);
					movieClip.visible = false;
					result = true;
				}
				return result;
			}

			public void cb468fa4c423bca714403647cc3f95552(List<GameSettingMgr.SettingItemData> c6d32ec7b3f796a0f3bcc82efcede83f5 = null)
			{
				if (c6d32ec7b3f796a0f3bcc82efcede83f5 != null)
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
					_dataList = c6d32ec7b3f796a0f3bcc82efcede83f5;
				}
				if (!(base.c89ef242f4744e0f1c4ffea4da8b79bc1 is MovieClip))
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
				_scBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
				_scBar.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _dataList.Count > 14;
				_scBar.c5a7d812d0a8e674b21eb0ed8824a2f59(14, 0, _dataList.Count - 14, 1);
				c9c040a2d0edf8852c382f5612a6dfe82(_scBar.cef9712200bbe2c3873eec3ca2e18a595);
			}

			protected void c1217d5959a1637e514cbe150c61da19b(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(c3d202dee321219a80026dc3081fb3c86);
			}

			protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				c9c040a2d0edf8852c382f5612a6dfe82(_scBar.cef9712200bbe2c3873eec3ca2e18a595);
			}

			protected void c9c040a2d0edf8852c382f5612a6dfe82(int c5128793ce5a806c0b7ba35948f75f131)
			{
				if (c5128793ce5a806c0b7ba35948f75f131 < 0)
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
					if (c5128793ce5a806c0b7ba35948f75f131 > _dataList.Count)
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
					int i = 0;
					if (_dataList != null)
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
						while (c5128793ce5a806c0b7ba35948f75f131 < _dataList.Count)
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
							if (i < _itemList.Length)
							{
								if (_itemList[i] != null)
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
									_itemList[i].cb468fa4c423bca714403647cc3f95552(_dataList[c5128793ce5a806c0b7ba35948f75f131]);
									_itemList[i].c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
								}
								c5128793ce5a806c0b7ba35948f75f131++;
								i++;
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
							break;
						}
					}
					for (; i < 14; i++)
					{
						if (_itemList[i] == null)
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
						_itemList[i].c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
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

		protected class SettingMenuItemContainer : c196099a1254db61d3be10d70e14e7422
		{
			protected SettingMenuItem_Button _item_Button = new SettingMenuItem_Button();

			protected SettingMenuItem_Range _item_Range = new SettingMenuItem_Range();

			protected SettingMenuItem_KeyBinding _item_KeyBinding = new SettingMenuItem_KeyBinding();

			protected SettingMenuItem_Options _item_Options = new SettingMenuItem_Options();

			protected string _strGroupLabel;

			protected GameSettingMgr.SettingItemData _settingData;

			[CompilerGenerated]
			private static Dictionary<string, int> _003C_003Ef__switch_0024map25;

			public string c72c0fd272db1789b79a29eaaaef7e9f8
			{
				set
				{
					_strGroupLabel = value;
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
					if (_003C_003Ef__switch_0024map25 == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
						dictionary.Add("mcSettingItem_Range", 0);
						dictionary.Add("mcSettingItem_KeyBinding", 1);
						dictionary.Add("mcSettingItem_Options", 2);
						dictionary.Add("mcSettingItem_Button", 3);
						_003C_003Ef__switch_0024map25 = dictionary;
					}
					int value;
					if (_003C_003Ef__switch_0024map25.TryGetValue(name, out value))
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
							_item_Range.cec024da8c099380cfe1334bfe4c8f30f = _strGroupLabel;
							_item_Range.c130648b59a0c8debea60aa153f844879(movieClip);
							_item_Range.addEventListener(MouseEvent.CLICK, c6a70fd9feff88d029afec071ee28a14b);
							c2d527e587ae401a2fc96e95f86e8e888(_item_Range, EVT_SETTINGITEM_DATA_CHANGED);
							movieClip.visible = false;
							result = true;
							break;
						case 1:
							_item_KeyBinding.cec024da8c099380cfe1334bfe4c8f30f = _strGroupLabel;
							_item_KeyBinding.c130648b59a0c8debea60aa153f844879(movieClip);
							_item_KeyBinding.addEventListener(MouseEvent.CLICK, c6a70fd9feff88d029afec071ee28a14b);
							c2d527e587ae401a2fc96e95f86e8e888(_item_KeyBinding, EVT_SETTINGITEM_DATA_CHANGED);
							c2d527e587ae401a2fc96e95f86e8e888(_item_KeyBinding, EVT_CLICK_LEFT_KEY);
							c2d527e587ae401a2fc96e95f86e8e888(_item_KeyBinding, EVT_CLICK_RIGHT_KEY);
							movieClip.visible = false;
							result = true;
							break;
						case 2:
							_item_Options.cec024da8c099380cfe1334bfe4c8f30f = _strGroupLabel;
							_item_Options.c130648b59a0c8debea60aa153f844879(movieClip);
							_item_Options.addEventListener(MouseEvent.CLICK, c6a70fd9feff88d029afec071ee28a14b);
							c2d527e587ae401a2fc96e95f86e8e888(_item_Options, EVT_SETTINGITEM_DATA_CHANGED);
							movieClip.visible = false;
							result = true;
							break;
						case 3:
							_item_Button.cec024da8c099380cfe1334bfe4c8f30f = _strGroupLabel;
							_item_Button.c130648b59a0c8debea60aa153f844879(movieClip);
							_item_Button.addEventListener(MouseEvent.CLICK, c6a70fd9feff88d029afec071ee28a14b);
							c2d527e587ae401a2fc96e95f86e8e888(_item_Button, EVT_SETTINGITEM_DATA_CHANGED);
							movieClip.visible = false;
							result = true;
							break;
						}
					}
				}
				return result;
			}

			protected void c2d527e587ae401a2fc96e95f86e8e888(SettingMenuItemBase c82fcbab5e578dc3a31c1f662916bd87e, string c29b3652d6d7a572d9842dd2ee37c89ce)
			{
				if (c82fcbab5e578dc3a31c1f662916bd87e == null)
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
					if (c29b3652d6d7a572d9842dd2ee37c89ce == null)
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
						c82fcbab5e578dc3a31c1f662916bd87e.removeAllEventListeners(c29b3652d6d7a572d9842dd2ee37c89ce);
						c82fcbab5e578dc3a31c1f662916bd87e.addEventListener(c29b3652d6d7a572d9842dd2ee37c89ce, cf059464fe8dfeec58646ec5adae4cac5);
						return;
					}
				}
			}

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
				if (movieClip == null)
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
					movieClip.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
					movieClip.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
					movieClip.addEventListener(MouseEvent.MOUSE_ENTER, c20cbcc77183d1c3b18b45c40186f86b4);
					movieClip.addEventListener(MouseEvent.MOUSE_LEAVE, c128fdd223f1220da81516f2e9503bfb1);
					return;
				}
			}

			protected void c20cbcc77183d1c3b18b45c40186f86b4(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_MOUSE_ENTER_SETTINGITEM, _settingData));
			}

			protected void c128fdd223f1220da81516f2e9503bfb1(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_MOUSE_LEAVE_SETTINGITEM, _settingData));
			}

			protected void c6a70fd9feff88d029afec071ee28a14b(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_CLICK_SETTINGITEM, _settingData));
			}

			protected void cf059464fe8dfeec58646ec5adae4cac5(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(c3d202dee321219a80026dc3081fb3c86);
			}

			public void cb468fa4c423bca714403647cc3f95552(GameSettingMgr.SettingItemData c9dd1426bdf4c924cfabbe067735870a6)
			{
				_settingData = c9dd1426bdf4c924cfabbe067735870a6;
				_item_Range.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				_item_KeyBinding.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				_item_Options.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				_item_Button.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				SettingMenuItemBase settingMenuItemBase = null;
				if (c9dd1426bdf4c924cfabbe067735870a6.type == GameSettingMgr.SettingItemDataType.ConfigItem)
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
					if (c9dd1426bdf4c924cfabbe067735870a6.config != null)
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
						switch (c9dd1426bdf4c924cfabbe067735870a6.config.mDisplayType)
						{
						case SettingDisplayType.Range:
							settingMenuItemBase = _item_Range;
							break;
						case SettingDisplayType.Options:
						case SettingDisplayType.Toggle:
							settingMenuItemBase = _item_Options;
							break;
						case SettingDisplayType.Button:
							settingMenuItemBase = _item_Button;
							break;
						}
					}
				}
				else if (c9dd1426bdf4c924cfabbe067735870a6.type == GameSettingMgr.SettingItemDataType.KeyBinding)
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
					settingMenuItemBase = _item_KeyBinding;
				}
				if (settingMenuItemBase == null)
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
					settingMenuItemBase.cb468fa4c423bca714403647cc3f95552(c9dd1426bdf4c924cfabbe067735870a6);
					settingMenuItemBase.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
					settingMenuItemBase.cbf402c82d0fffee7c8f37c98e456b8f8 = c9dd1426bdf4c924cfabbe067735870a6.bEnable;
					return;
				}
			}
		}

		protected class SettingMenuItemBase : c6425d3761c85e65e3530cc19d085d446
		{
			protected GameSettingMgr.SettingItemData _settingData;

			protected bool _bInChildMC;

			public GameSettingMgr.SettingItemData c1bcb9a90574add00dc70c49786b845c2
			{
				get
				{
					return _settingData;
				}
			}

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
				if (movieClip == null)
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
					movieClip.addFrameScript("up", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("over", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("down", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("disabled", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("selected_up", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("selected_over", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("selected_down", c2d4b6616c5d13a240f0d050133a6a00b);
					movieClip.addFrameScript("selected_disabled", c2d4b6616c5d13a240f0d050133a6a00b);
					return;
				}
			}

			protected override void c16dd84132166e8847948a375ec27d1d9()
			{
				c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = false;
				c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_ENTER, c2aeb7361dd785a11d5c819ec01d705ea, false);
				c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_LEAVE, c2fe93430aa746dfd9da07963f5288f61, false);
				c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_DOWN, c03a16c41904647d1b94578bb05681454, false);
				c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.CLICK, c5070be7f946bbda0b6d1be08b4a33d89, false);
			}

			protected void c2aeb7361dd785a11d5c819ec01d705ea(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				if (!_bInChildMC)
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
					c0d0edd197df0dbfa38010e2ce6112850(c3d202dee321219a80026dc3081fb3c86);
				}
				c9c364a8fd1f013589fea518a3924e711 = true;
			}

			protected void c2fe93430aa746dfd9da07963f5288f61(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				if (_bInChildMC)
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
					cabaa8cbfd9da30988bae3a6c5a4b14d2(c3d202dee321219a80026dc3081fb3c86);
					return;
				}
			}

			protected void c03a16c41904647d1b94578bb05681454(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				if (_bInChildMC)
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
					cca1346a71f7b492d4c1bbe3a95e31557(c3d202dee321219a80026dc3081fb3c86);
					return;
				}
			}

			protected void c5070be7f946bbda0b6d1be08b4a33d89(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				if (_bInChildMC)
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
					ca2c8ad477a1a8ef2c6efd2087707b4b0(c3d202dee321219a80026dc3081fb3c86);
					return;
				}
			}

			protected virtual void cd52c66586f554b2c345f7d3b39de5fb3(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				_bInChildMC = true;
			}

			protected virtual void cda39947280cd4eec9e5bd91ad8d03bb1(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				_bInChildMC = false;
			}

			public virtual void cb468fa4c423bca714403647cc3f95552(GameSettingMgr.SettingItemData c9dd1426bdf4c924cfabbe067735870a6)
			{
				_settingData = c9dd1426bdf4c924cfabbe067735870a6;
				TextField childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textTitle");
				if (childByName != null)
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
					if (_settingData != null)
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
						string c0ecc54688f26e096af3299c445becd1a = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
						GameSettingMgr.SettingItemDataType type = _settingData.type;
						if (type != 0)
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
							if (type != GameSettingMgr.SettingItemDataType.KeyBinding)
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
							else
							{
								c0ecc54688f26e096af3299c445becd1a = "Control_" + _settingData.controlAction;
							}
						}
						else if (_settingData.config != null)
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
							c0ecc54688f26e096af3299c445becd1a = _settingData.config.mTitle;
						}
						childByName.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c0ecc54688f26e096af3299c445becd1a));
					}
				}
				MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
				if (movieClip == null)
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
					movieClip.mouseChildrenEnabled = true;
					return;
				}
			}

			protected void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				cb468fa4c423bca714403647cc3f95552(_settingData);
			}
		}

		protected class SettingMenuItem_Button : SettingMenuItemBase
		{
		}

		protected class SettingMenuItem_Range : SettingMenuItemBase
		{
			protected SettingMenuRangeBar _rangeBar = new SettingMenuRangeBar();

			protected float _fCurValue;

			[CompilerGenerated]
			private static Dictionary<string, int> _003C_003Ef__switch_0024map26;

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
					if (_003C_003Ef__switch_0024map26 == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
						dictionary.Add("mcBar", 0);
						_003C_003Ef__switch_0024map26 = dictionary;
					}
					int value;
					if (_003C_003Ef__switch_0024map26.TryGetValue(name, out value))
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
						if (value != 0)
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
						else
						{
							_rangeBar.c130648b59a0c8debea60aa153f844879(movieClip);
							_rangeBar.removeAllEventListeners(CEvent.CHANGED);
							_rangeBar.addEventListener(CEvent.CHANGED, cadfd603af9436e4752d0cfa88ca9659c);
							movieClip.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
							movieClip.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
							movieClip.addEventListener(MouseEvent.MOUSE_ENTER, cd52c66586f554b2c345f7d3b39de5fb3);
							movieClip.addEventListener(MouseEvent.MOUSE_LEAVE, cda39947280cd4eec9e5bd91ad8d03bb1);
						}
					}
				}
				return result;
			}

			public override void cb468fa4c423bca714403647cc3f95552(GameSettingMgr.SettingItemData c9dd1426bdf4c924cfabbe067735870a6)
			{
				base.cb468fa4c423bca714403647cc3f95552(c9dd1426bdf4c924cfabbe067735870a6);
				if (c9dd1426bdf4c924cfabbe067735870a6 == null)
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
					if (c9dd1426bdf4c924cfabbe067735870a6.config == null)
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
						if (c9dd1426bdf4c924cfabbe067735870a6.config.mRange == null)
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
							_rangeBar.c72f7dcd66a96c475e4492de8dab658d2(c9dd1426bdf4c924cfabbe067735870a6.config.mRange.LeftValue, c9dd1426bdf4c924cfabbe067735870a6.config.mRange.RightValue);
							if (_settingData.bDirty)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										_rangeBar.ce67fe08303bcabbca2138202c6624710(c9dd1426bdf4c924cfabbe067735870a6.newValue.fValue);
										return;
									}
								}
							}
							_rangeBar.ce67fe08303bcabbca2138202c6624710(c9dd1426bdf4c924cfabbe067735870a6.curValue.fValue);
							return;
						}
					}
				}
			}

			protected void cadfd603af9436e4752d0cfa88ca9659c(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
				if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
					if (cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 == null)
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
						_fCurValue = Convert.ToSingle(cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4);
						if (_fCurValue == _settingData.curValue.fValue)
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
							_settingData.bDirty = true;
							_settingData.newValue.fValue = _fCurValue;
							dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_SETTINGITEM_DATA_CHANGED, _settingData));
							return;
						}
					}
				}
			}
		}

		protected class SettingMenuRangeBar : c196099a1254db61d3be10d70e14e7422
		{
			protected ca5de54f2df53a95dc6f907c5b61cdb4a _sliderBar = new ca5de54f2df53a95dc6f907c5b61cdb4a();

			protected TextField _textValue;

			protected float _fLength = 100f;

			protected float _fCurValue = 100f;

			[CompilerGenerated]
			private static Dictionary<string, int> _003C_003Ef__switch_0024map27;

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
					if (_003C_003Ef__switch_0024map27 == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
						dictionary.Add("mcSlider", 0);
						_003C_003Ef__switch_0024map27 = dictionary;
					}
					int value;
					if (_003C_003Ef__switch_0024map27.TryGetValue(name, out value))
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
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						else
						{
							_sliderBar.c130648b59a0c8debea60aa153f844879(movieClip);
							_sliderBar.removeAllEventListeners(CEvent.CHANGED);
							_sliderBar.addEventListener(CEvent.CHANGED, cf5df28256d90bbb4e60c35d282c9488d);
							result = true;
						}
					}
				}
				return result;
			}

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				_textValue = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textValue");
			}

			protected void cf5df28256d90bbb4e60c35d282c9488d(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
				if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
					if (cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 == null)
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
						float num = Convert.ToSingle(cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4);
						ce67fe08303bcabbca2138202c6624710(num);
						if (_textValue != null)
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
							int num2 = Mathf.CeilToInt(num);
							_textValue.text = num2.ToString();
						}
						dispatchEvent(c3d202dee321219a80026dc3081fb3c86);
						return;
					}
				}
			}

			public void ce67fe08303bcabbca2138202c6624710(float c8f6f53ee3b51a3ea94ddedc3968eef91)
			{
				if (_sliderBar.cefda2fdc3ce4e04f38bab77fc7998241 == c8f6f53ee3b51a3ea94ddedc3968eef91)
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
					_sliderBar.cefda2fdc3ce4e04f38bab77fc7998241 = c8f6f53ee3b51a3ea94ddedc3968eef91;
					return;
				}
			}

			public void c72f7dcd66a96c475e4492de8dab658d2(float c5bb3d54bd48d0ad6ee995015db35b9e0, float c9d30661eae3efb9dafa75e077acc4944)
			{
				_sliderBar.cd3aa3714e9e1b18f79d970881e51b4d9 = c5bb3d54bd48d0ad6ee995015db35b9e0;
				_sliderBar.cc0fcc850026a18cac77e032f088df9c2 = c9d30661eae3efb9dafa75e077acc4944;
				_fLength = c9d30661eae3efb9dafa75e077acc4944 - c5bb3d54bd48d0ad6ee995015db35b9e0;
			}
		}

		protected class SettingMenuItem_KeyBinding : SettingMenuItemBase
		{
			protected TextField _textLeftKey;

			protected TextField _textRightKey;

			protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnLeftKey = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

			protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnRightKey = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

			[CompilerGenerated]
			private static Dictionary<string, int> _003C_003Ef__switch_0024map28;

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
					if (_003C_003Ef__switch_0024map28 == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(2);
						dictionary.Add("mcLeftKey", 0);
						dictionary.Add("mcRightKey", 1);
						_003C_003Ef__switch_0024map28 = dictionary;
					}
					int value;
					if (_003C_003Ef__switch_0024map28.TryGetValue(name, out value))
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
						if (value != 0)
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
							if (value != 1)
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
							}
							else
							{
								_textRightKey = movieClip.getChildByName<TextField>("textValue");
								_btnRightKey.c130648b59a0c8debea60aa153f844879(movieClip);
								_btnRightKey.removeAllEventListeners(MouseEvent.CLICK);
								_btnRightKey.addEventListener(MouseEvent.CLICK, c15d9cfb85528e6eb17a33613aee6dd9a);
							}
						}
						else
						{
							_textLeftKey = movieClip.getChildByName<TextField>("textValue");
							_btnLeftKey.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnLeftKey.removeAllEventListeners(MouseEvent.CLICK);
							_btnLeftKey.addEventListener(MouseEvent.CLICK, c0445395be6b2ca6d85f99f6327597c04);
						}
					}
				}
				return result;
			}

			protected void c0445395be6b2ca6d85f99f6327597c04(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_CLICK_LEFT_KEY, _settingData));
			}

			protected void c15d9cfb85528e6eb17a33613aee6dd9a(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_CLICK_RIGHT_KEY, _settingData));
			}

			public override void cb468fa4c423bca714403647cc3f95552(GameSettingMgr.SettingItemData c9dd1426bdf4c924cfabbe067735870a6)
			{
				base.cb468fa4c423bca714403647cc3f95552(c9dd1426bdf4c924cfabbe067735870a6);
				if (c9dd1426bdf4c924cfabbe067735870a6 == null)
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
					InputManager.InputKeyBinding keyBinding = c9dd1426bdf4c924cfabbe067735870a6.curValue.keyBinding;
					if (c9dd1426bdf4c924cfabbe067735870a6.bDirty)
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
						keyBinding = c9dd1426bdf4c924cfabbe067735870a6.newValue.keyBinding;
					}
					if (_textLeftKey != null)
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
						string text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Key_" + keyBinding.primaryKey));
						_textLeftKey.text = text;
					}
					if (_textRightKey == null)
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
						string text2 = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Key_" + keyBinding.seconderyKey));
						_textRightKey.text = text2;
						return;
					}
				}
			}
		}

		protected class SettingMenuItem_Options : SettingMenuItemBase
		{
			protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnLeft = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

			protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnRight = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

			protected List<string> _strValueList = new List<string>();

			protected int _iOnShowIdx;

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				_btnLeft.removeAllEventListeners(MouseEvent.CLICK);
				_btnLeft.addEventListener(MouseEvent.CLICK, c026450dc7ac99a6d6ed2f7c612305829);
				_btnRight.removeAllEventListeners(MouseEvent.CLICK);
				_btnRight.addEventListener(MouseEvent.CLICK, ccc7b1384172ae71229e949a66465ba39);
				_iOnShowIdx = 0;
			}

			public override void cb468fa4c423bca714403647cc3f95552(GameSettingMgr.SettingItemData c9dd1426bdf4c924cfabbe067735870a6)
			{
				base.cb468fa4c423bca714403647cc3f95552(c9dd1426bdf4c924cfabbe067735870a6);
				MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("btnLeft");
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					_btnLeft.removeAllEventListeners(MouseEvent.CLICK);
					_btnLeft = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					_btnLeft.c130648b59a0c8debea60aa153f844879(childByName);
					_btnLeft.addEventListener(MouseEvent.CLICK, c026450dc7ac99a6d6ed2f7c612305829);
					childByName.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
					childByName.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
					childByName.addEventListener(MouseEvent.MOUSE_ENTER, cd52c66586f554b2c345f7d3b39de5fb3);
					childByName.addEventListener(MouseEvent.MOUSE_LEAVE, cda39947280cd4eec9e5bd91ad8d03bb1);
				}
				MovieClip childByName2 = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("btnRight");
				if (childByName2 != null)
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
					_btnRight.removeAllEventListeners(MouseEvent.CLICK);
					_btnRight = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					_btnRight.c130648b59a0c8debea60aa153f844879(childByName2);
					_btnRight.addEventListener(MouseEvent.CLICK, ccc7b1384172ae71229e949a66465ba39);
					childByName2.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
					childByName2.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
					childByName2.addEventListener(MouseEvent.MOUSE_ENTER, cd52c66586f554b2c345f7d3b39de5fb3);
					childByName2.addEventListener(MouseEvent.MOUSE_LEAVE, cda39947280cd4eec9e5bd91ad8d03bb1);
				}
				_strValueList.Clear();
				if (c9dd1426bdf4c924cfabbe067735870a6 == null)
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
					if (c9dd1426bdf4c924cfabbe067735870a6.config == null)
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
						if (c9dd1426bdf4c924cfabbe067735870a6.config.mDisplayType == SettingDisplayType.Toggle)
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
							_strValueList.Add("Off");
							_strValueList.Add("On");
						}
						else
						{
							switch (c9dd1426bdf4c924cfabbe067735870a6.config.mFunctionType)
							{
							case SettingFunctionType.OverallQuality:
							{
								XsdSettings.QualityLevel[] mQualitys = c9dd1426bdf4c924cfabbe067735870a6.config.mQualitys;
								foreach (XsdSettings.QualityLevel qualityLevel in mQualitys)
								{
									_strValueList.Add(qualityLevel.ToString());
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
							case SettingFunctionType.ScreenResolution:
							{
								IntPair[] mResolutions = c9dd1426bdf4c924cfabbe067735870a6.config.mResolutions;
								foreach (IntPair intPair in mResolutions)
								{
									string item = intPair.LeftValue + " * " + intPair.RightValue;
									_strValueList.Add(item);
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
								break;
							}
							}
						}
						if (c9dd1426bdf4c924cfabbe067735870a6 != null)
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
							if (c9dd1426bdf4c924cfabbe067735870a6.config != null)
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
								if (c9dd1426bdf4c924cfabbe067735870a6.config.mDisplayType == SettingDisplayType.Options)
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
									if (c9dd1426bdf4c924cfabbe067735870a6.bDirty)
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
										_iOnShowIdx = c9dd1426bdf4c924cfabbe067735870a6.newValue.iIndex;
									}
									else
									{
										_iOnShowIdx = c9dd1426bdf4c924cfabbe067735870a6.curValue.iIndex;
									}
								}
								else if (c9dd1426bdf4c924cfabbe067735870a6.config.mDisplayType == SettingDisplayType.Toggle)
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
									if (c9dd1426bdf4c924cfabbe067735870a6.bDirty)
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
										int iOnShowIdx;
										if (c9dd1426bdf4c924cfabbe067735870a6.newValue.bOn)
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
											iOnShowIdx = 1;
										}
										else
										{
											iOnShowIdx = 0;
										}
										_iOnShowIdx = iOnShowIdx;
									}
									else
									{
										int iOnShowIdx2;
										if (c9dd1426bdf4c924cfabbe067735870a6.curValue.bOn)
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
											iOnShowIdx2 = 1;
										}
										else
										{
											iOnShowIdx2 = 0;
										}
										_iOnShowIdx = iOnShowIdx2;
									}
								}
							}
						}
						cee3f7e1f2fe80146187019ef16248436();
						return;
					}
				}
			}

			protected void c026450dc7ac99a6d6ed2f7c612305829(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				_iOnShowIdx--;
				cee3f7e1f2fe80146187019ef16248436();
				c9e5c82162f5b8a36e2f70533805fefc8();
			}

			protected void ccc7b1384172ae71229e949a66465ba39(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				_iOnShowIdx++;
				cee3f7e1f2fe80146187019ef16248436();
				c9e5c82162f5b8a36e2f70533805fefc8();
			}

			protected void c9e5c82162f5b8a36e2f70533805fefc8()
			{
				if (_settingData.config != null)
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
					if (_settingData.config.mDisplayType == SettingDisplayType.Options)
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
						_settingData.newValue.iIndex = _iOnShowIdx;
					}
					else if (_settingData.config.mDisplayType == SettingDisplayType.Toggle)
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
						_settingData.newValue.bOn = _iOnShowIdx == 1;
					}
				}
				_settingData.bDirty = true;
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7(EVT_SETTINGITEM_DATA_CHANGED, _settingData));
			}

			protected void cee3f7e1f2fe80146187019ef16248436()
			{
				_iOnShowIdx = (_iOnShowIdx + _strValueList.Count) % _strValueList.Count;
				TextField childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textValue");
				if (childByName == null)
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
					string text = string.Empty;
					if (_strValueList.Count != 0)
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
						if (_iOnShowIdx < _strValueList.Count)
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
							text = _strValueList[_iOnShowIdx];
						}
					}
					childByName.text = text;
					return;
				}
			}
		}

		protected const string TAB_GROUP_NAME = "GameSettingFuntionTab";

		protected const string ITEMLIST_LEFT_GROUP_LABEL = "TabLeftGroupLabel";

		protected const string ITEMLIST_RIGHT_GROUP_LABEL = "TabRightGroupLabel";

		protected MovieClip _mcRoot;

		protected MovieClip _mcLeftMenuList;

		protected MovieClip _mcRightMenuList;

		protected MovieClip _mcPresetScheme;

		protected MovieClip _mcDescription;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnBack = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnSave = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnReset = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected SettingMenuList _leftMenuListPanel = new SettingMenuList();

		protected SettingMenuList _rightMenuListPanel = new SettingMenuList();

		protected SettingCategory _curCategory;

		protected Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> _settingConfigData = new Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>>();

		protected Dictionary<string, SettingCatogoryTab> _tabDic = new Dictionary<string, SettingCatogoryTab>();

		protected GameSettingMgr.SettingItemData _leftPanelOnFocusItem;

		protected bool _bRightPanelOnShow;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map24;

		public SettingCategory caad4c74aba4cce980a68d899b92ebac9
		{
			get
			{
				return _curCategory;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("Tab_"))
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
				SettingCatogoryTab value = null;
				if (!_tabDic.TryGetValue(movieClip.name, out value))
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
					value = new SettingCatogoryTab();
					value.ce84b930a12a1d06512c79320b3f0d3f4 = false;
					_tabDic.Add(movieClip.name, value);
				}
				value.c130648b59a0c8debea60aa153f844879(movieClip);
				TextField childByName = movieClip.getChildByName<TextField>("textField");
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
					value.cf798cedf450c3ad2a08ce2d2fd00d464 = childByName.text;
				}
				result = true;
			}
			else
			{
				string name = movieClip.name;
				if (name != null)
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
					if (_003C_003Ef__switch_0024map24 == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(7);
						dictionary.Add("btnBack", 0);
						dictionary.Add("btnReset", 1);
						dictionary.Add("btnSave", 2);
						dictionary.Add("mcLeftDetail", 3);
						dictionary.Add("mcRightDetail", 4);
						dictionary.Add("mcPresetScheme", 5);
						dictionary.Add("mcDescription", 6);
						_003C_003Ef__switch_0024map24 = dictionary;
					}
					int value2;
					if (_003C_003Ef__switch_0024map24.TryGetValue(name, out value2))
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
						switch (value2)
						{
						case 0:
							_btnBack.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnBack.removeAllEventListeners(MouseEvent.CLICK);
							_btnBack.addEventListener(MouseEvent.CLICK, cc6b0c71961a2de8e173a8220ec273570);
							result = true;
							break;
						case 1:
							_btnReset.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnReset.removeAllEventListeners(MouseEvent.CLICK);
							_btnReset.addEventListener(MouseEvent.CLICK, cf6563846a162845bc34a8cb660536911);
							result = true;
							break;
						case 2:
							_btnSave.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnSave.removeAllEventListeners(MouseEvent.CLICK);
							_btnSave.addEventListener(MouseEvent.CLICK, c59ff1cc3531a4703dc14872bf2035913);
							result = true;
							break;
						case 3:
						{
							_mcLeftMenuList = movieClip;
							MovieClip childByName3 = _mcLeftMenuList.getChildByName<MovieClip>("mcItemList");
							if (childByName3 != null)
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
								_leftMenuListPanel.c72c0fd272db1789b79a29eaaaef7e9f8 = "TabLeftGroupLabel";
								_leftMenuListPanel.c130648b59a0c8debea60aa153f844879(childByName3);
								_leftMenuListPanel.removeAllEventListeners(EVT_MOUSE_ENTER_SETTINGITEM);
								_leftMenuListPanel.addEventListener(EVT_MOUSE_ENTER_SETTINGITEM, c666f6da9d72a65e9c4799a5d7ebe8260);
								_leftMenuListPanel.removeAllEventListeners(EVT_MOUSE_LEAVE_SETTINGITEM);
								_leftMenuListPanel.addEventListener(EVT_MOUSE_LEAVE_SETTINGITEM, c6453e18885cec01fbc7cae6f5f00f1fa);
								_leftMenuListPanel.removeAllEventListeners(EVT_SETTINGITEM_DATA_CHANGED);
								_leftMenuListPanel.addEventListener(EVT_SETTINGITEM_DATA_CHANGED, cf059464fe8dfeec58646ec5adae4cac5);
								_leftMenuListPanel.removeAllEventListeners(EVT_CLICK_SETTINGITEM);
								_leftMenuListPanel.addEventListener(EVT_CLICK_SETTINGITEM, cd1cb11432b1bb33dd0a70fac1e575ab4);
							}
							result = true;
							break;
						}
						case 4:
							_rightMenuListPanel.c72c0fd272db1789b79a29eaaaef7e9f8 = "TabRightGroupLabel";
							_rightMenuListPanel.removeAllEventListeners(EVT_CLICK_LEFT_KEY);
							_rightMenuListPanel.removeAllEventListeners(EVT_CLICK_RIGHT_KEY);
							_rightMenuListPanel.addEventListener(EVT_CLICK_LEFT_KEY, cf059464fe8dfeec58646ec5adae4cac5);
							_rightMenuListPanel.addEventListener(EVT_CLICK_RIGHT_KEY, cf059464fe8dfeec58646ec5adae4cac5);
							_mcRightMenuList = movieClip;
							_mcRightMenuList.visible = false;
							_mcRightMenuList.addFrameScript("normal", c0080dabe46fac5d82962219c1e912403);
							_mcRightMenuList.addFrameScript("fadein", c0080dabe46fac5d82962219c1e912403);
							_mcRightMenuList.addFrameScript("fadeout", c0080dabe46fac5d82962219c1e912403);
							_mcRightMenuList.addFrameScript("fadeoutend", c000768d862a5236e9c5322024f45d024);
							result = true;
							break;
						case 5:
							_mcPresetScheme = movieClip;
							_mcPresetScheme.visible = false;
							result = true;
							break;
						case 6:
						{
							_mcDescription = movieClip;
							TextField childByName2 = _mcDescription.getChildByName<TextField>("textDescription");
							if (childByName2 != null)
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
								childByName2.text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
							}
							result = true;
							break;
						}
						}
					}
				}
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_mcRoot = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			List<SettingCatogoryTab> list = new List<SettingCatogoryTab>(_tabDic.Values);
			list.Sort(c0ed8616eb49f60d029ccdfdecc5b4713);
			using (List<SettingCatogoryTab>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SettingCatogoryTab current = enumerator.Current;
					current.cec024da8c099380cfe1334bfe4c8f30f = "GameSettingFuntionTab";
					current.ce84b930a12a1d06512c79320b3f0d3f4 = false;
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
					break;
				}
			}
			cab925e8b02dc39594f255a86a0d7c5e1 cab925e8b02dc39594f255a86a0d7c5e = cab925e8b02dc39594f255a86a0d7c5e1.cd4833052cc4daf5b269e37eb1d8262d9("GameSettingFuntionTab");
			if (cab925e8b02dc39594f255a86a0d7c5e != null)
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
				cab925e8b02dc39594f255a86a0d7c5e.addEventListener(CEvent.CHANGED, cb5b07d55759e104a9ecf651cff64071b);
			}
			list[0].c9c364a8fd1f013589fea518a3924e711 = true;
			c9c040a2d0edf8852c382f5612a6dfe82();
		}

		public void cb468fa4c423bca714403647cc3f95552(Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> ce58650d17122b4af3213e43b927cbc89)
		{
			_settingConfigData = ce58650d17122b4af3213e43b927cbc89;
			c9c040a2d0edf8852c382f5612a6dfe82();
		}

		protected int c0ed8616eb49f60d029ccdfdecc5b4713(SettingCatogoryTab c1c653eed9959cd1d51b7f91a50650615, SettingCatogoryTab cd9c09a49d33111fdda012945e71df943)
		{
			return c1c653eed9959cd1d51b7f91a50650615.c79163fa3657843afb073bdf6e707c9fc - cd9c09a49d33111fdda012945e71df943.c79163fa3657843afb073bdf6e707c9fc;
		}

		protected void cd1cb11432b1bb33dd0a70fac1e575ab4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
			if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
				if (_leftPanelOnFocusItem != null)
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
					if (_leftPanelOnFocusItem.config != null)
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
						if (_leftPanelOnFocusItem.config.mFunctionType == SettingFunctionType.CustomKeyBinding)
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
							_mcRightMenuList.gotoAndPlay("fadeout");
						}
					}
				}
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData != null)
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
					if (settingItemData.config != null)
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
						if (settingItemData.config.mFunctionType == SettingFunctionType.CustomKeyBinding)
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
							if (_mcRightMenuList != null)
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
						}
					}
				}
				_leftPanelOnFocusItem = settingItemData;
				dispatchEvent(cdd9021d4f44808fce2ab49c52f0db6f);
				return;
			}
		}

		protected void c666f6da9d72a65e9c4799a5d7ebe8260(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
			if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData == null)
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
					if (settingItemData.config == null)
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
						if (_mcDescription != null)
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
							TextField childByName = _mcDescription.getChildByName<TextField>("textDescription");
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
								childByName.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(settingItemData.config.mDescription));
							}
						}
						if (settingItemData.config.mFunctionType != SettingFunctionType.CustomKeyBinding)
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
							if (_bRightPanelOnShow)
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
								_mcRightMenuList.visible = true;
								_mcRightMenuList.gotoAndPlay("fadein");
								_rightMenuListPanel.cb468fa4c423bca714403647cc3f95552(settingItemData.children);
								_bRightPanelOnShow = true;
								return;
							}
						}
					}
				}
			}
		}

		protected void c6453e18885cec01fbc7cae6f5f00f1fa(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
			if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData == null)
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
					if (settingItemData.config == null)
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
						if (_mcDescription != null)
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
							TextField childByName = _mcDescription.getChildByName<TextField>("textDescription");
							if (childByName != null)
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
								childByName.text = string.Empty;
							}
						}
						if (settingItemData.config.mFunctionType == SettingFunctionType.CustomKeyBinding)
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
							if (!_bRightPanelOnShow)
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
								_mcRightMenuList.gotoAndPlay("fadeout");
								_bRightPanelOnShow = false;
								return;
							}
						}
					}
				}
			}
		}

		protected void c0080dabe46fac5d82962219c1e912403(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = _mcRightMenuList.getChildByName<MovieClip>("mcItemList");
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
				_rightMenuListPanel.c130648b59a0c8debea60aa153f844879(childByName);
				_rightMenuListPanel.cb468fa4c423bca714403647cc3f95552(c70fb1e9764824c0e5eea76bc553d5e06.c7088de59e49f7108f520cf7e0bae167e);
				return;
			}
		}

		protected void c000768d862a5236e9c5322024f45d024(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_mcRightMenuList.visible = false;
		}

		protected void cc6b0c71961a2de8e173a8220ec273570(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new CEvent(EVT_CLICK_BACK));
		}

		protected void c59ff1cc3531a4703dc14872bf2035913(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new CEvent(EVT_CLICK_SAVE));
		}

		protected void cf6563846a162845bc34a8cb660536911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new CEvent(EVT_CLICK_RESET));
		}

		protected void cb5b07d55759e104a9ecf651cff64071b(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			SettingCatogoryTab settingCatogoryTab = cab925e8b02dc39594f255a86a0d7c5e1.cd4833052cc4daf5b269e37eb1d8262d9("GameSettingFuntionTab").cbe2d3a52e3b467c552460216e94ddc82 as SettingCatogoryTab;
			if (settingCatogoryTab != null)
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
				_curCategory = settingCatogoryTab.c23cee373240060d3f7436af859b589c1;
				if (settingCatogoryTab.c23cee373240060d3f7436af859b589c1 != SettingCategory.Control)
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
					if (_mcRightMenuList != null)
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
						_mcRightMenuList.visible = false;
					}
					if (_mcPresetScheme != null)
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
						_mcPresetScheme.visible = false;
					}
				}
			}
			c9c040a2d0edf8852c382f5612a6dfe82();
		}

		protected void c9c040a2d0edf8852c382f5612a6dfe82()
		{
			List<GameSettingMgr.SettingItemData> value = c70fb1e9764824c0e5eea76bc553d5e06.c7088de59e49f7108f520cf7e0bae167e;
			_settingConfigData.TryGetValue(_curCategory, out value);
			if (_leftMenuListPanel != null)
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
				_leftMenuListPanel.cb468fa4c423bca714403647cc3f95552(value);
				cab925e8b02dc39594f255a86a0d7c5e1 cab925e8b02dc39594f255a86a0d7c5e = cab925e8b02dc39594f255a86a0d7c5e1.cd4833052cc4daf5b269e37eb1d8262d9("TabLeftGroupLabel");
				if (cab925e8b02dc39594f255a86a0d7c5e != null)
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
					cab925e8b02dc39594f255a86a0d7c5e.cebce50b7b5316e383f9350f76837e934(0);
				}
			}
			if (_rightMenuListPanel == null)
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
				_rightMenuListPanel.cb468fa4c423bca714403647cc3f95552(c70fb1e9764824c0e5eea76bc553d5e06.c7088de59e49f7108f520cf7e0bae167e);
				return;
			}
		}

		protected void cf059464fe8dfeec58646ec5adae4cac5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(c3d202dee321219a80026dc3081fb3c86);
		}
	}

	protected c196099a1254db61d3be10d70e14e7422 _panelRoot;

	protected EscMenuPanel _escMenu;

	protected OptionsMenuPanel _optionsMenu;

	protected MovieClip _mcRoot;

	protected MovieClip _mcOptionMenuAnima;

	protected MovieClip _mcEscMenuRoot;

	protected static string EVT_CLICK_BACK = "EvtClickBack";

	protected static string EVT_CLICK_RESET = "EvtClickReset";

	protected static string EVT_CLICK_SAVE = "EvtClickSave";

	protected static string EVT_CLICK_RIGHT_KEY = "EvtClickRightKey";

	protected static string EVT_CLICK_LEFT_KEY = "EvtClickLeftKey";

	protected static string EVT_CLICK_SETTINGITEM = "EvtClickSettingItem";

	protected static string EVT_MOUSE_ENTER_SETTINGITEM = "EvtMouseEnterSettingItem";

	protected static string EVT_MOUSE_LEAVE_SETTINGITEM = "EvtMouseLeaveSettingItem";

	protected static string EVT_SETTINGITEM_DATA_CHANGED = "EvtSettingItemDataChanged";

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Setting.swf", "Panel_Root", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panelRoot);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Setting.swf");
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_panelRoot = new c196099a1254db61d3be10d70e14e7422();
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
		_mcRoot = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
		_panelRoot.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_mcEscMenuRoot = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName<MovieClip>("mcEscMenu");
		_escMenu = new EscMenuPanel();
		if (_mcEscMenuRoot != null)
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
			_mcEscMenuRoot.visible = false;
			_escMenu.c130648b59a0c8debea60aa153f844879(_mcEscMenuRoot);
			EscMenuFunction[] array = (EscMenuFunction[])Enum.GetValues(typeof(EscMenuFunction));
			EscMenuFunction[] array2 = array;
			foreach (EscMenuFunction escMenuFunction in array2)
			{
				_escMenu.removeAllEventListeners(escMenuFunction.ToString());
				_escMenu.addEventListener(escMenuFunction.ToString(), c073fca9a173effae81c6e2de8a0630ee);
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
		_escMenu.c9805ba91d6c6ad00e40cba71c6079d3f(_bRespawnEnable);
		_escMenu.cffcbeac9a39b2cea767263041a6b5c38(_bLeaveInstanceEnable);
		_escMenu.c8cf8eceb6cfc97d28820bb77800dbe1f(_bReplayTutorialEnable);
		_mcOptionMenuAnima = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName<MovieClip>("mcOptionsMenuAnima");
		_optionsMenu = new OptionsMenuPanel();
		if (_mcOptionMenuAnima != null)
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
			MovieClip childByName = _mcOptionMenuAnima.getChildByName<MovieClip>("mcOptionsMenu");
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
				_optionsMenu.c130648b59a0c8debea60aa153f844879(childByName);
				_optionsMenu.cb468fa4c423bca714403647cc3f95552(_dicSettingsByCategory);
			}
			_mcOptionMenuAnima.visible = false;
			_mcOptionMenuAnima.addFrameScript("fadein", c47a0aeee49fa7d8dda2aa2ca5542b0a7);
			_mcOptionMenuAnima.addFrameScript("normal", c47a0aeee49fa7d8dda2aa2ca5542b0a7);
			_mcOptionMenuAnima.addFrameScript("fadeout", c47a0aeee49fa7d8dda2aa2ca5542b0a7);
			_mcOptionMenuAnima.addFrameScript("fadeOutEnd", c815e9161ba44fe2ece1a5f726e001c75);
		}
		_bActive = true;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_mcRoot == null)
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
			if (c8be1fcd630e5fe96821376d111325750)
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
				(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_panelRoot);
			}
			else
			{
				(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panelRoot);
			}
			_mcRoot.visible = c8be1fcd630e5fe96821376d111325750;
			if (c8be1fcd630e5fe96821376d111325750)
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
				ce269ba343b870fb2522da1974bf87490(EscMenuState.Root);
				return;
			}
		}
	}

	protected override void ce269ba343b870fb2522da1974bf87490(EscMenuState c7d77be03dd09783b7cf45209bd57d03e)
	{
		base.ce269ba343b870fb2522da1974bf87490(c7d77be03dd09783b7cf45209bd57d03e);
		if (_curState == EscMenuState.Root)
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
			if (_mcEscMenuRoot != null)
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
				_mcEscMenuRoot.visible = false;
			}
		}
		else if (_curState == EscMenuState.Options)
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
			if (_mcOptionMenuAnima != null)
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
				_mcOptionMenuAnima.gotoAndPlay("fadeout");
			}
		}
		if (c7d77be03dd09783b7cf45209bd57d03e == EscMenuState.Root)
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
			if (_mcEscMenuRoot != null)
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
				_mcEscMenuRoot.visible = true;
			}
		}
		else if (c7d77be03dd09783b7cf45209bd57d03e == EscMenuState.Options)
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
			if (_mcOptionMenuAnima != null)
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
				_mcOptionMenuAnima.visible = true;
				_mcOptionMenuAnima.gotoAndPlay("fadein");
			}
		}
		_curState = c7d77be03dd09783b7cf45209bd57d03e;
		_optionsMenu.cb468fa4c423bca714403647cc3f95552(_dicSettingsByCategory);
	}

	protected void c815e9161ba44fe2ece1a5f726e001c75(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_mcOptionMenuAnima.visible = false;
	}

	protected void c47a0aeee49fa7d8dda2aa2ca5542b0a7(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = _mcOptionMenuAnima.getChildByName<MovieClip>("mcOptionsMenu");
		if (childByName == null)
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
			_optionsMenu.c130648b59a0c8debea60aa153f844879(_mcOptionMenuAnima);
			_optionsMenu.removeAllEventListeners(EVT_CLICK_BACK);
			_optionsMenu.addEventListener(EVT_CLICK_BACK, cc6b0c71961a2de8e173a8220ec273570);
			_optionsMenu.removeAllEventListeners(EVT_CLICK_RESET);
			_optionsMenu.addEventListener(EVT_CLICK_RESET, cf6563846a162845bc34a8cb660536911);
			_optionsMenu.removeAllEventListeners(EVT_CLICK_SAVE);
			_optionsMenu.addEventListener(EVT_CLICK_SAVE, c59ff1cc3531a4703dc14872bf2035913);
			_optionsMenu.removeAllEventListeners(EVT_SETTINGITEM_DATA_CHANGED);
			_optionsMenu.addEventListener(EVT_SETTINGITEM_DATA_CHANGED, c2eef9da4dd1676868fd57c3157486bc2);
			_optionsMenu.removeAllEventListeners(EVT_CLICK_LEFT_KEY);
			_optionsMenu.addEventListener(EVT_CLICK_LEFT_KEY, c0445395be6b2ca6d85f99f6327597c04);
			_optionsMenu.removeAllEventListeners(EVT_CLICK_RIGHT_KEY);
			_optionsMenu.addEventListener(EVT_CLICK_RIGHT_KEY, c15d9cfb85528e6eb17a33613aee6dd9a);
			_optionsMenu.removeAllEventListeners(EVT_CLICK_SETTINGITEM);
			_optionsMenu.addEventListener(EVT_CLICK_SETTINGITEM, c4f984cf46b89604c8242f480fe138186);
			return;
		}
	}

	protected void cc6b0c71961a2de8e173a8220ec273570(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c645e159b14c940d3fb6c0970dff95827())
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
					c4c9df40759d8b2c274ca175c00b254b9();
					return;
				}
			}
		}
		ce269ba343b870fb2522da1974bf87490(EscMenuState.Root);
	}

	protected void cf6563846a162845bc34a8cb660536911(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cc979c27f27a50500a198b3df3dc3de5b(_optionsMenu.caad4c74aba4cce980a68d899b92ebac9);
		_optionsMenu.cb468fa4c423bca714403647cc3f95552(_dicSettingsByCategory);
	}

	protected void c59ff1cc3531a4703dc14872bf2035913(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		caa333e802fda46f16bea83331fc54e91();
		_optionsMenu.cb468fa4c423bca714403647cc3f95552(_dicSettingsByCategory);
	}

	protected void c0445395be6b2ca6d85f99f6327597c04(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			if (cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 == null)
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
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData == null)
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
					_bIsPrimaryKey = true;
					_onProcessingData = settingItemData;
					cd029737dbbe5a57b54eb2fed49d5ce2c();
					return;
				}
			}
		}
	}

	protected void c15d9cfb85528e6eb17a33613aee6dd9a(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			if (cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 == null)
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
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData == null)
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
					_bIsPrimaryKey = false;
					_onProcessingData = settingItemData;
					cd029737dbbe5a57b54eb2fed49d5ce2c();
					return;
				}
			}
		}
	}

	protected void c4f984cf46b89604c8242f480fe138186(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			if (cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 == null)
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
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData == null)
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
					c6a70fd9feff88d029afec071ee28a14b(settingItemData);
					return;
				}
			}
		}
	}

	protected void c2eef9da4dd1676868fd57c3157486bc2(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			if (cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 == null)
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
				GameSettingMgr.SettingItemData settingItemData = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as GameSettingMgr.SettingItemData;
				if (settingItemData == null)
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
					if (settingItemData.type != 0)
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
						if (settingItemData.config == null)
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
							if (settingItemData.config.mFunctionType != SettingFunctionType.FullScreen)
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
								c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9c468c80f530b448d1ac8906148c9a2();
								ce269ba343b870fb2522da1974bf87490(EscMenuState.Options);
								return;
							}
						}
					}
				}
			}
		}
	}

	protected void c073fca9a173effae81c6e2de8a0630ee(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		switch ((EscMenuFunction)(int)Enum.Parse(typeof(EscMenuFunction), c3d202dee321219a80026dc3081fb3c86.type))
		{
		case EscMenuFunction.BackToGame:
			c76647445a81350a21a12e1ec5fbb0052();
			break;
		case EscMenuFunction.ExitGame:
			cea93a0f84d44233bf81f22d9265be856();
			break;
		case EscMenuFunction.GameOptions:
			ce269ba343b870fb2522da1974bf87490(EscMenuState.Options);
			break;
		case EscMenuFunction.QuitInstance:
			ca64bc613abd7b2015fc221b5af350e0d();
			break;
		case EscMenuFunction.Respawn:
			cc0f6d906592b43fa741d36fb2c491011();
			break;
		case EscMenuFunction.ReplayTutorial:
			cccec04cc6c3f4e3451c437d02a02d30c();
			break;
		}
	}
}
