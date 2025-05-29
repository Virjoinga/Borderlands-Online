using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniInventoryView : InventoryView
{
	public class InventoryPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected Item_SWAP_Delegate swapFunc;

		protected c87da635fd7858aaa8f8053a95f123b32[] _arrItemSlots;

		protected MovieClip mcRootMovie;

		public int SLOT_NUM = 14;

		protected int _iItemSum;

		private int SLOT_TOTAL = 42;

		private string ITEM_SLOT_PREFIX_NAME = "mcItemSlot";

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcXButton;

		protected cf7ac05203029a27299d6893b2dbaee2e mcSB;

		protected TextField specialCurrencyTF;

		protected TextField circulateCurrencyTF;

		protected TextField bondCurrencyTF;

		protected TextField keysTF;

		protected TextField expiringKeysTF;

		protected TextField expiringTimeTF;

		protected UnityTextField tfSummary;

		protected ExpiringCurrency expiringKey;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map20;

		public Vector2 cef9712200bbe2c3873eec3ca2e18a595
		{
			get
			{
				return new Vector2(mcRootMovie.x, mcRootMovie.y);
			}
			set
			{
				Vector2 vector = ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c88ec770b25554e17182648d69403ceb1(mcRootMovie.parent, value);
				mcRootMovie.x = vector.x;
				mcRootMovie.y = vector.y;
			}
		}

		public bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return mcRootMovie.visible;
			}
			set
			{
				if (value)
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
				return mcRootMovie.isPlaying;
			}
		}

		public int cf8d72a811da4c504c742af61c94ad3c0
		{
			get
			{
				if (mcSB != null)
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
							return mcSB.cef9712200bbe2c3873eec3ca2e18a595;
						}
					}
				}
				return 0;
			}
			set
			{
				if (mcSB == null)
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
					mcSB.cef9712200bbe2c3873eec3ca2e18a595 = value;
					return;
				}
			}
		}

		public InventoryPanel(int c22d8df2b2160120b869133da5a2533da)
		{
			SLOT_TOTAL = c22d8df2b2160120b869133da5a2533da;
			_arrItemSlots = cd37cd7953f9ca8b68e2410db7162caa8.c0a0cdf4a196914163f7334d9b0781a04(SLOT_NUM);
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcRootMovie = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			mcRootMovie.stopAll();
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcRoot");
			childByName.stopAll();
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				specialCurrencyTF = childByName.getChildByName<TextField>("specialCurrency");
				circulateCurrencyTF = childByName.getChildByName<TextField>("circulateCurrency");
				bondCurrencyTF = childByName.getChildByName<TextField>("bondCurrency");
				keysTF = childByName.getChildByName<TextField>("keysTF");
				expiringKeysTF = childByName.getChildByName<TextField>("expiringKeysTF");
				expiringTimeTF = childByName.getChildByName<TextField>("expiringTimeTF");
				tfSummary = childByName.getChildByName<UnityTextField>("tfSummary");
				return;
			}
		}

		public void c68ed7414b562b3f60addc6579051f185(int cdddf3ee050c73253a0eed1738c2fc872, int c8e0912d89bc1f75509dd09fc37fdec7b, int c7b176945cd320ea3c7e7a8e06224c2d0)
		{
			if (specialCurrencyTF != null)
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
				specialCurrencyTF.text = cdddf3ee050c73253a0eed1738c2fc872.ToString();
			}
			if (circulateCurrencyTF != null)
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
				circulateCurrencyTF.text = c8e0912d89bc1f75509dd09fc37fdec7b.ToString();
			}
			if (bondCurrencyTF == null)
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
				bondCurrencyTF.text = c7b176945cd320ea3c7e7a8e06224c2d0.ToString();
				return;
			}
		}

		public void cc8931b6c9acf5d4fc292cb080693b0d9(int c03432f889e423c52fc050a7b001c2520, ExpiringCurrency ca406b3913d8a8b0502eee7023f609cad)
		{
			if (keysTF != null)
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
				keysTF.text = c03432f889e423c52fc050a7b001c2520.ToString();
			}
			expiringKey = ca406b3913d8a8b0502eee7023f609cad;
			if (expiringKeysTF != null)
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
				if (expiringKey != null)
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
					expiringKeysTF.text = expiringKey.Count.ToString();
				}
			}
			c55fd35a5934f98c30bd70a02cbf25fea();
		}

		public void c55fd35a5934f98c30bd70a02cbf25fea()
		{
			if (expiringTimeTF == null)
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
			if (expiringKey != null)
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
				if (!(expiringKey.c556272486f855b6dc3e20f90745df2a7 < 0f))
				{
					expiringTimeTF.visible = true;
					TimeSpan timeSpan = TimeSpan.FromSeconds(expiringKey.c556272486f855b6dc3e20f90745df2a7);
					StringBuilder stringBuilder = new StringBuilder(timeSpan.Hours.ToString("00")).Append("'").Append(timeSpan.Minutes.ToString("00")).Append("'")
						.Append(timeSpan.Seconds.ToString("00"))
						.Append("\"");
					expiringTimeTF.text = stringBuilder.ToString();
					return;
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
			expiringTimeTF.visible = false;
		}

		public void ccb3c174a4b7b912ff30c796130e97fa2(int c971e5554515aa942515c80324d1526ac, int c0f58093e7980c8f7780bde4dfd2e7cf1)
		{
			_iItemSum = c971e5554515aa942515c80324d1526ac;
			if (tfSummary == null)
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
				UnityTextField unityTextField = tfSummary;
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = string.Empty;
				array[1] = _iItemSum;
				array[2] = "/";
				array[3] = c0f58093e7980c8f7780bde4dfd2e7cf1;
				unityTextField.text = string.Concat(array);
				return;
			}
		}

		public void ce173ad44b3260fda2aad425f9352f093(int c9526cedaae8a6f13c52592df57f78e6e, UIItemSlotData cb4be6dae1755138c26d22542471266a1, Texture2D cd6102468cd57214a9f3e10633998391b, int c668dae8f721ade771d420baa9fe638e2, MovieClip c6a27da07f961a8c779d4035d57ea0911 = null)
		{
			if (c9526cedaae8a6f13c52592df57f78e6e >= _arrItemSlots.Length)
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
				if (c9526cedaae8a6f13c52592df57f78e6e < 0)
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
				if (cb4be6dae1755138c26d22542471266a1.item != null)
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
					if (_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e] != null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
							{
								MovieClip childByName = _arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf60cea27899464ecfab889519bbd47e7.getChildByName<MovieClip>("icon");
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
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf60cea27899464ecfab889519bbd47e7.removeChild(childByName);
								}
								Texture2D cf83e762e4368c5dedaab3e73ad69452e = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
								if (c6a27da07f961a8c779d4035d57ea0911 != null)
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
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c1d4a927ba62b28412f982cec1c20bc7a = false;
									MovieClip movieClip = c6a27da07f961a8c779d4035d57ea0911.newInstance();
									movieClip.name = "icon";
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf60cea27899464ecfab889519bbd47e7.stopAll();
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf60cea27899464ecfab889519bbd47e7.addChild(movieClip);
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c7b36e61b4e327af6fc082f1b263c501a = c6a27da07f961a8c779d4035d57ea0911;
								}
								else
								{
									cf83e762e4368c5dedaab3e73ad69452e = cd6102468cd57214a9f3e10633998391b;
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c1d4a927ba62b28412f982cec1c20bc7a = true;
									_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c7b36e61b4e327af6fc082f1b263c501a = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
								}
								c7beefc397f483dc0b72dcd3e6bdcf929 c76cc6288aad6ff8d562a2365e727c68c = _arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c76cc6288aad6ff8d562a2365e727c68c;
								if (c76cc6288aad6ff8d562a2365e727c68c != null)
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
									c76cc6288aad6ff8d562a2365e727c68c.c2f5e208842730f75c8d5498004244d2a = 0.95f;
									c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e);
								}
								_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].quantity = c668dae8f721ade771d420baa9fe638e2;
								_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c591d56a94543e3559945c497f37126c4 = cb4be6dae1755138c26d22542471266a1;
								_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(cb4be6dae1755138c26d22542471266a1.item);
								return;
							}
							}
						}
					}
				}
				if (_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e] == null)
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
					_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].quantity = -1;
					_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c591d56a94543e3559945c497f37126c4 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
					_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
					return;
				}
			}
		}

		public void cc5a26ce86f3799f44553c2295c433164(Item_SWAP_Delegate cb24ea666f3f25bc975f1e84effd63cad)
		{
			swapFunc = (Item_SWAP_Delegate)Delegate.Combine(swapFunc, cb24ea666f3f25bc975f1e84effd63cad);
		}

		public void c04dbbd9ff849f6902091326db294909f(Item_SWAP_Delegate cb24ea666f3f25bc975f1e84effd63cad)
		{
			swapFunc = (Item_SWAP_Delegate)Delegate.Remove(swapFunc, cb24ea666f3f25bc975f1e84effd63cad);
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.Length > ITEM_SLOT_PREFIX_NAME.Length)
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
				string text = movieClip.name.Substring(0, ITEM_SLOT_PREFIX_NAME.Length);
				if (text == ITEM_SLOT_PREFIX_NAME)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							int num = Convert.ToInt32(movieClip.name.Substring(ITEM_SLOT_PREFIX_NAME.Length, movieClip.name.Length - ITEM_SLOT_PREFIX_NAME.Length));
							if (num < _arrItemSlots.Length)
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
								if (num >= 0)
								{
									c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = new c87da635fd7858aaa8f8053a95f123b32();
									c87da635fd7858aaa8f8053a95f123b.c130648b59a0c8debea60aa153f844879(movieClip);
									movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
									c87da635fd7858aaa8f8053a95f123b.addEventListener(MouseEvent.CLICK, ceaa483d1c7de4ff85b2bd14fa57fd849);
									c87da635fd7858aaa8f8053a95f123b.addEventListener(c649b5d45cf350f685c56c4bd02800198.c4c735ed0f7d81b376e20a84473c72a44, c2ff52100b8c4d1d3cdf165c285f1fafa);
									c87da635fd7858aaa8f8053a95f123b.addEventListener(c649b5d45cf350f685c56c4bd02800198.cfb118d69d579b2fbde25fa8127b213f3, c89be23d15c41af4eb1df0ed22c841e59);
									c87da635fd7858aaa8f8053a95f123b.addEventListener(MouseEvent.MOUSE_ENTER, c89be23d15c41af4eb1df0ed22c841e59);
									c87da635fd7858aaa8f8053a95f123b.addEventListener(MouseEvent.MOUSE_LEAVE, c89be23d15c41af4eb1df0ed22c841e59);
									c87da635fd7858aaa8f8053a95f123b.addEventListener("slash", cd31beb006c9b6f0df33cc5b8d7c495e5);
									c87da635fd7858aaa8f8053a95f123b.addEventListener("drop", c7f918a1d1b2f8e24904c4775619d988e);
									c87da635fd7858aaa8f8053a95f123b.cd55b0729145dbbb40133dc949a6ab274 = num;
									_arrItemSlots[num] = c87da635fd7858aaa8f8053a95f123b;
									return true;
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
							object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
							array[0] = "Inventory itemSlot name wrong! Index:";
							array[1] = num;
							array[2] = " is bigger than sum: ";
							array[3] = _arrItemSlots.Length;
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
							return true;
						}
						}
					}
				}
			}
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
				if (_003C_003Ef__switch_0024map20 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(2);
					dictionary.Add("mcXButton", 0);
					dictionary.Add("mcScrollingBar", 1);
					_003C_003Ef__switch_0024map20 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map20.TryGetValue(name, out value))
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
					if (value != 0)
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
						if (value != 1)
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
						}
						else
						{
							mcSB = new cf7ac05203029a27299d6893b2dbaee2e();
							mcSB.c130648b59a0c8debea60aa153f844879(movieClip);
							mcSB.addEventListener("Scrolling", c572d9b4e8efb42e6d51f963c7d7b81e9);
							mcSB.cfcb3294d851a0336d3f3a8f2a943f2fb = -4;
							int num2 = SLOT_NUM >> 1;
							mcSB.c5a7d812d0a8e674b21eb0ed8824a2f59(num2, 0, (SLOT_TOTAL >> 1) - num2, 1);
							mcSB.cef9712200bbe2c3873eec3ca2e18a595 = 0;
							(base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip).addEventListener(ccee399aceaafcace836a9d2621e66f35.cb995b44f9d3bf68faff261ab2cc8c5b7, mcSB.c740df24cdea1387e258957ce237e3fda, false);
							result = true;
						}
					}
					else
					{
						mcXButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcXButton.c130648b59a0c8debea60aa153f844879(movieClip);
						mcXButton.addEventListener(MouseEvent.CLICK, c33d802bc86e36d426896b838a8f61e31);
						result = true;
					}
				}
			}
			return result;
		}

		protected void c572d9b4e8efb42e6d51f963c7d7b81e9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(c3d202dee321219a80026dc3081fb3c86);
		}

		protected void c7f918a1d1b2f8e24904c4775619d988e(CEvent c3d202dee321219a80026dc3081fb3c86)
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
				cdaa8be71633914d75e27ba7c238d88d3 cdaa8be71633914d75e27ba7c238d88d = (cdaa8be71633914d75e27ba7c238d88d3)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
				UIItemSlotData from = (UIItemSlotData)cdaa8be71633914d75e27ba7c238d88d.c591d56a94543e3559945c497f37126c4;
				UIItemSlotData target;
				if (cdaa8be71633914d75e27ba7c238d88d.c94bfd4765313431c30399426a6fbe2e7 != null)
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
					target = (UIItemSlotData)cdaa8be71633914d75e27ba7c238d88d.c94bfd4765313431c30399426a6fbe2e7;
				}
				else
				{
					c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = cdd9021d4f44808fce2ab49c52f0db6f.target as c87da635fd7858aaa8f8053a95f123b32;
					if (c87da635fd7858aaa8f8053a95f123b == null)
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
					target = new UIItemSlotData(null, "inventory", (cf8d72a811da4c504c742af61c94ad3c0 << 1) + (int)c87da635fd7858aaa8f8053a95f123b.cd55b0729145dbbb40133dc949a6ab274);
				}
				swapFunc(target, from);
				return;
			}
		}

		protected void cd31beb006c9b6f0df33cc5b8d7c495e5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			(c3d202dee321219a80026dc3081fb3c86.target as c87da635fd7858aaa8f8053a95f123b32).c35556323454cba71bb12e199cf43bf96();
		}

		protected void c89be23d15c41af4eb1df0ed22c841e59(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = c3d202dee321219a80026dc3081fb3c86.target as c87da635fd7858aaa8f8053a95f123b32;
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("Item" + c3d202dee321219a80026dc3081fb3c86.type, c87da635fd7858aaa8f8053a95f123b.c591d56a94543e3559945c497f37126c4));
		}

		protected void ceaa483d1c7de4ff85b2bd14fa57fd849(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c649b5d45cf350f685c56c4bd02800198 c649b5d45cf350f685c56c4bd = c3d202dee321219a80026dc3081fb3c86 as c649b5d45cf350f685c56c4bd02800198;
			c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = c649b5d45cf350f685c56c4bd.target as c87da635fd7858aaa8f8053a95f123b32;
			if (Input.GetKey(KeyCode.LeftShift))
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
						dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("showWeaponModel", ((UIItemSlotData)c87da635fd7858aaa8f8053a95f123b.c591d56a94543e3559945c497f37126c4).item.ca79da172938fdc8c067fb64242b6174a()));
						return;
					}
				}
			}
			if (hasEventListener("Item" + c3d202dee321219a80026dc3081fb3c86.type))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("Item" + c3d202dee321219a80026dc3081fb3c86.type, c87da635fd7858aaa8f8053a95f123b.c591d56a94543e3559945c497f37126c4));
						return;
					}
				}
			}
			c87da635fd7858aaa8f8053a95f123b.c35556323454cba71bb12e199cf43bf96();
		}

		protected void c2ff52100b8c4d1d3cdf165c285f1fafa(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c649b5d45cf350f685c56c4bd02800198 c649b5d45cf350f685c56c4bd = c3d202dee321219a80026dc3081fb3c86 as c649b5d45cf350f685c56c4bd02800198;
			c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = c649b5d45cf350f685c56c4bd.target as c87da635fd7858aaa8f8053a95f123b32;
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("Item" + c3d202dee321219a80026dc3081fb3c86.type, c87da635fd7858aaa8f8053a95f123b.c591d56a94543e3559945c497f37126c4));
		}

		protected void c33d802bc86e36d426896b838a8f61e31(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new CEvent("XBtnClicked"));
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mcRootMovie.visible = true;
			mcRootMovie.removeEventListener("End", c1a8a5357baa03eacf7b0a3123daf5911);
			mcRootMovie.gotoAndPlay("Open");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			mcRootMovie.gotoAndPlay("Close");
			mcRootMovie.addFrameScript("End", c1a8a5357baa03eacf7b0a3123daf5911);
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcRootMovie.removeEventListener("End", c1a8a5357baa03eacf7b0a3123daf5911);
			mcRootMovie.visible = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}

		protected void cb7cb27e5a6e72ef079808069fc4ef217(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
		}
	}

	public delegate void Item_SWAP_Delegate(UIItemSlotData target, UIItemSlotData from);

	protected InventoryPanel m_InventoryPanel;

	protected Vector2 _visiblePos = Vector2.zero;

	protected Dictionary<string, MovieClip> _dicMaterialIcons;

	protected MovieClip _MoneyIcon;

	public InventoryPanel c796c173865ebd0e0606dad33b499db0b
	{
		get
		{
			return m_InventoryPanel;
		}
	}

	public uniInventoryView()
	{
		_dicMaterialIcons = new Dictionary<string, MovieClip>();
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Inventory.swf", "Panel_Inventory", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		WeaponTips.ca49e5e0015ea1ca43f1040447671e38a();
		c2cf48648eb8d914882441eeeca363a16();
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_InventoryPanel = new InventoryPanel(_iSlotSum);
		m_InventoryPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = _bVisible;
		m_InventoryPanel.cc5a26ce86f3799f44553c2295c433164(cc281ef8b521f65e4b9efa6528e76b799);
		m_InventoryPanel.addEventListener("XBtnClicked", c33d802bc86e36d426896b838a8f61e31);
		m_InventoryPanel.addEventListener("Scrolling", cc8939f6400eb93a4b3566459020bafe9);
		m_InventoryPanel.addEventListener("showWeaponModel", c82879ab8fa4fd4a11b2ae590587ffe92);
		m_InventoryPanel.addEventListener("Item" + c649b5d45cf350f685c56c4bd02800198.c4c735ed0f7d81b376e20a84473c72a44, cb2c3509405c0344543482efe0219e770);
		UniUIManager uniUIManager = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager;
		uniUIManager.cbc15476a9112020f8fa67ca3691284d5.addEventListener("drop", c2b169dce2970cbd4a6600e20ece3068c);
		uniUIManager.c239889f6079aa61647e3c4b8f3627d00(c16e257f6660a091cef11d48d66c42f68, true);
		_bActive = true;
	}

	public void c16e257f6660a091cef11d48d66c42f68()
	{
		if (m_InventoryPanel == null)
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
			m_InventoryPanel.c55fd35a5934f98c30bd70a02cbf25fea();
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		cbe1734fcf9317c165b1527ab5acf7253();
		if (m_InventoryPanel != null)
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
			m_InventoryPanel.c04dbbd9ff849f6902091326db294909f(cc281ef8b521f65e4b9efa6528e76b799);
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_InventoryPanel);
		}
		m_InventoryPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Inventory.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_bVisible)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_InventoryPanel);
			if (m_InventoryPanel != null)
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
				m_InventoryPanel.cef9712200bbe2c3873eec3ca2e18a595 = _visiblePos;
			}
			m_InventoryPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
			c59da8661588e408c0b48d7a9ddc11ab9();
			cf157ca65df0b4e8c64213bea4c8767f2();
		}
		else
		{
			m_InventoryPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		}
		if (_bVisible)
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
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c4fdd007303fd7b5c133404b463447e39();
			return;
		}
	}

	public override void cc70485d0f318bdcb115a41bc918cae44(Vector2 c330987c4414f384d6c951ab9f68460d8)
	{
		base.cc70485d0f318bdcb115a41bc918cae44(c330987c4414f384d6c951ab9f68460d8);
		_visiblePos = c330987c4414f384d6c951ab9f68460d8;
		if (m_InventoryPanel == null)
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
			if (!m_InventoryPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				m_InventoryPanel.cef9712200bbe2c3873eec3ca2e18a595 = c330987c4414f384d6c951ab9f68460d8;
				return;
			}
		}
	}

	protected override void cdb61fd817ac27166903b9ffc008ad1dd()
	{
		if (m_InventoryPanel == null)
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
		m_InventoryPanel.ccb3c174a4b7b912ff30c796130e97fa2(_iItemSum, _iSlotSum);
		int num = m_InventoryPanel.cf8d72a811da4c504c742af61c94ad3c0 << 1;
		int num2 = 0;
		while (num2 < m_InventoryPanel.SLOT_NUM)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (num2 + num < _arrItems.Count)
				{
					int num3 = num2 + num;
					UIItemSlotData cb4be6dae1755138c26d22542471266a = new UIItemSlotData(_arrItems[num3], "inventory", num3);
					MovieClip c6a27da07f961a8c779d4035d57ea = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
					Texture2D cd6102468cd57214a9f3e10633998391b = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
					int c668dae8f721ade771d420baa9fe638e = -1;
					if (_arrItems[num3] != null)
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
						if (_arrItems[num3].m_type == ItemType.Material)
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
							c6a27da07f961a8c779d4035d57ea = cf00e0520259191fd2faf4e52ef6f3ac0(_arrItems[num3].m_materialType);
							c668dae8f721ade771d420baa9fe638e = _arrItems[num3].m_value;
						}
						else
						{
							cd6102468cd57214a9f3e10633998391b = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(_arrItems[num3]);
						}
					}
					m_InventoryPanel.ce173ad44b3260fda2aad425f9352f093(num2, cb4be6dae1755138c26d22542471266a, cd6102468cd57214a9f3e10633998391b, c668dae8f721ade771d420baa9fe638e, c6a27da07f961a8c779d4035d57ea);
					num2++;
					break;
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
		}
	}

	protected override void c59da8661588e408c0b48d7a9ddc11ab9()
	{
		if (m_InventoryPanel == null)
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
			if (_currencyInfo == null)
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
			m_InventoryPanel.c68ed7414b562b3f60addc6579051f185(_currencyInfo.BondCurrency, _currencyInfo.SpecialCurrency, _currencyInfo.CirculateCurrency);
			return;
		}
	}

	protected override void cf157ca65df0b4e8c64213bea4c8767f2()
	{
		if (m_InventoryPanel == null)
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
			if (_currencyInfo == null)
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
			int c03432f889e423c52fc050a7b001c = 0;
			if (_currencyInfo.cbab1b45c1da05265f0459d3ebbe08b7c.ContainsKey(LuckyBoxRank.Diamond))
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
				c03432f889e423c52fc050a7b001c = _currencyInfo.cbab1b45c1da05265f0459d3ebbe08b7c[LuckyBoxRank.Diamond];
			}
			ExpiringCurrency ca406b3913d8a8b0502eee7023f609cad = c83f53ff2e2d1c3d9a08298c027ce5e7d.c7088de59e49f7108f520cf7e0bae167e;
			if (_currencyInfo.c6d1a6bc2728f2d802903c307c555a497.ContainsKey(LuckyBoxRank.Diamond))
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
				ca406b3913d8a8b0502eee7023f609cad = _currencyInfo.c6d1a6bc2728f2d802903c307c555a497[LuckyBoxRank.Diamond];
			}
			m_InventoryPanel.cc8931b6c9acf5d4fc292cb080693b0d9(c03432f889e423c52fc050a7b001c, ca406b3913d8a8b0502eee7023f609cad);
			return;
		}
	}

	protected override void ca71ff9e891e72ba05d0d35e6c20d3292()
	{
		for (int i = 0; i < _arrItems.Count; i++)
		{
			ItemDNA itemDNA = _arrItems[i];
			if (itemDNA == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA);
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

	protected void cbe1734fcf9317c165b1527ab5acf7253()
	{
		_dicMaterialIcons.Clear();
	}

	protected void c2cf48648eb8d914882441eeeca363a16()
	{
		_dicMaterialIcons.Clear();
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c566d164fd2de71df1df7b9f1ba7192df.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MaterialType materialType = (MaterialType)(int)enumerator.Current;
				if (materialType == MaterialType.TOTAL)
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
				}
				else
				{
					MovieClip value = new MovieClip("CommonLib.swf", materialType.ToString());
					_dicMaterialIcons.Add(materialType.ToString(), value);
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_008d;
				}
				continue;
				end_IL_008d:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_00a5;
					}
					continue;
					end_IL_00a5:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		MovieClip movieClip = new MovieClip("CommonLib.swf", "MT_Money");
		if (movieClip == null)
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
			_dicMaterialIcons.Add("Money", movieClip);
			return;
		}
	}

	public MovieClip cf00e0520259191fd2faf4e52ef6f3ac0(MaterialType c6036f8f74e508ecf2d60f73883ab00ca)
	{
		MovieClip movieClip = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
		string key = c6036f8f74e508ecf2d60f73883ab00ca.ToString();
		if (_dicMaterialIcons.ContainsKey(key))
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
			movieClip = _dicMaterialIcons[key];
			movieClip.stopAll();
		}
		return movieClip;
	}

	public MovieClip cc03556e4e2ae2f10297d48a0eaad4ff8()
	{
		MovieClip movieClip = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
		if (_dicMaterialIcons.ContainsKey("MT_Shield"))
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
			movieClip = _dicMaterialIcons["MT_Shield"];
			movieClip.stopAll();
		}
		return movieClip;
	}

	public MovieClip c28ee12a3e8557af117e75c0f0133c2f3()
	{
		MovieClip movieClip = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
		if (_dicMaterialIcons.ContainsKey("Money"))
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
			movieClip = _dicMaterialIcons["Money"];
			movieClip.stopAll();
		}
		return movieClip;
	}

	protected void cc281ef8b521f65e4b9efa6528e76b799(UIItemSlotData c82fcbab5e578dc3a31c1f662916bd87e, UIItemSlotData cae5fea398599f41bfafc9b6bb6f4559b)
	{
		if (cae5fea398599f41bfafc9b6bb6f4559b.identifier == "inventory")
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
					c1a8455a9ebc438c42697a10f94624a4a(cae5fea398599f41bfafc9b6bb6f4559b.index, c82fcbab5e578dc3a31c1f662916bd87e.index);
					return;
				}
			}
		}
		if (cae5fea398599f41bfafc9b6bb6f4559b.identifier == "character")
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c95c907131d60893ab10124305650f93f(cae5fea398599f41bfafc9b6bb6f4559b.index);
					return;
				}
			}
		}
		if (!(cae5fea398599f41bfafc9b6bb6f4559b.identifier == "warehouse"))
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
			c1313402f01ea427301c8dc00be412797(cae5fea398599f41bfafc9b6bb6f4559b.index, c82fcbab5e578dc3a31c1f662916bd87e.index);
			return;
		}
	}

	protected void c2b169dce2970cbd4a6600e20ece3068c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			UIItemSlotData uIItemSlotData = (UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
			if (!(uIItemSlotData.identifier == "inventory"))
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
				ced89d39fd82d07f930c30c633a3ad475(uIItemSlotData.index);
				return;
			}
		}
	}

	protected void c33d802bc86e36d426896b838a8f61e31(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected void cc8939f6400eb93a4b3566459020bafe9(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdb61fd817ac27166903b9ffc008ad1dd();
	}

	protected void c82879ab8fa4fd4a11b2ae590587ffe92(CEvent c3d202dee321219a80026dc3081fb3c86)
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
			WeaponDNA c39409683a32e09391d094314ffeae2b = (WeaponDNA)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponPreviewView>().c6187275e7336eafc3a9acc48a6644c55(c39409683a32e09391d094314ffeae2b);
			return;
		}
	}

	protected void cb2c3509405c0344543482efe0219e770(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		UIItemSlotData cb4be6dae1755138c26d22542471266a = (UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
		c196ad5f133a65d2658191c2ea2bb7a7a(cb4be6dae1755138c26d22542471266a);
	}
}
