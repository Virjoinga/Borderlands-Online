using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniCharInfoView : CharInfoView
{
	protected class CharacterPanel : c196099a1254db61d3be10d70e14e7422
	{
		public Item_SWAP_Delegate swapFunc;

		public Index_Delegate activeFunc;

		public Index_Delegate shieldFunc;

		public Index_Delegate classModeFunc;

		protected MovieClip mcRootMovie;

		protected c87da635fd7858aaa8f8053a95f123b32 mcShieldSlot;

		protected c87da635fd7858aaa8f8053a95f123b32 mcClassModeSlot;

		protected c87da635fd7858aaa8f8053a95f123b32[] _arrItemSlots;

		protected c6425d3761c85e65e3530cc19d085d446[] _arrCheckBoxes;

		protected MovieClip mcInfoPanel;

		protected TextField mcPlayerName;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcDetailBtn;

		protected c7beefc397f483dc0b72dcd3e6bdcf929 mc3DAvatar;

		protected MovieClip mcAvatar;

		protected bool _bInfoPanelVisible;

		public int SLOT_NUM = 4;

		private string ITEM_SLOT_PREFIX_NAME = "mcItemSlot";

		private string ITEM_CHECKBOX_PREFIX_NAME = "mcCheck";

		private string INFO_FRAME_PREFIX_NAME = "Info_";

		private PlayerProperties _playerInfo;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcXButton;

		protected c6425d3761c85e65e3530cc19d085d446 mcEquipRadio0;

		protected c6425d3761c85e65e3530cc19d085d446 mcEquipRadio1;

		protected MovieClip mcTabPanel0;

		protected MovieClip mcTabPanel1;

		private StringBuilder m_stringbuilder = new StringBuilder(32, 32);

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024mapA;

		public bool bGreenWord { get; set; }

		public int iActivedIndex { get; set; }

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
						switch (3)
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

		public CharacterPanel()
		{
			_arrItemSlots = cd37cd7953f9ca8b68e2410db7162caa8.c0a0cdf4a196914163f7334d9b0781a04(SLOT_NUM);
			_arrCheckBoxes = c67757306f9d6b6a8778a67ebe6597c57.c0a0cdf4a196914163f7334d9b0781a04(SLOT_NUM);
		}

		public void c5939103e64f288dfce17db2fb4594432(ItemDNA cc3903659f6abf884e4709091f9206475, Texture2D cd6102468cd57214a9f3e10633998391b)
		{
			if (cc3903659f6abf884e4709091f9206475 != null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						UIItemSlotData uIItemSlotData = new UIItemSlotData(cc3903659f6abf884e4709091f9206475, "charShield", 0);
						mcShieldSlot.c591d56a94543e3559945c497f37126c4 = uIItemSlotData;
						ShieldDNA shieldDNA = cc3903659f6abf884e4709091f9206475.c8e074b9d0135ff808166cc324407f74c();
						if (shieldDNA != null)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
								{
									c7beefc397f483dc0b72dcd3e6bdcf929 c76cc6288aad6ff8d562a2365e727c68c = mcShieldSlot.c76cc6288aad6ff8d562a2365e727c68c;
									c76cc6288aad6ff8d562a2365e727c68c.c2f5e208842730f75c8d5498004244d2a = 0.95f;
									c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cd6102468cd57214a9f3e10633998391b);
									mcShieldSlot.c1d4a927ba62b28412f982cec1c20bc7a = true;
									mcShieldSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(cc3903659f6abf884e4709091f9206475);
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
			mcShieldSlot.c591d56a94543e3559945c497f37126c4 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			mcShieldSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
		}

		public void c3073f21f22259bbb1160a60060b0bbee(ItemDNA c176822fdbbb024478da34c927718d68e, Texture2D cd6102468cd57214a9f3e10633998391b)
		{
			if (c176822fdbbb024478da34c927718d68e != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						UIItemSlotData uIItemSlotData = new UIItemSlotData(c176822fdbbb024478da34c927718d68e, "charClassMode", 0);
						mcClassModeSlot.c591d56a94543e3559945c497f37126c4 = uIItemSlotData;
						ClassModeDNA classModeDNA = c176822fdbbb024478da34c927718d68e.c253c28f3a59bc5e5a528dfbb463a8a45();
						if (classModeDNA != null)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
								{
									c7beefc397f483dc0b72dcd3e6bdcf929 c76cc6288aad6ff8d562a2365e727c68c = mcClassModeSlot.c76cc6288aad6ff8d562a2365e727c68c;
									c76cc6288aad6ff8d562a2365e727c68c.c2f5e208842730f75c8d5498004244d2a = 0.95f;
									c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cd6102468cd57214a9f3e10633998391b);
									mcClassModeSlot.c1d4a927ba62b28412f982cec1c20bc7a = true;
									mcClassModeSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(c176822fdbbb024478da34c927718d68e);
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
			mcClassModeSlot.c591d56a94543e3559945c497f37126c4 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			mcClassModeSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
		}

		public void ce173ad44b3260fda2aad425f9352f093(int c9526cedaae8a6f13c52592df57f78e6e, ItemDNA cb4be6dae1755138c26d22542471266a1, Texture2D cd6102468cd57214a9f3e10633998391b)
		{
			if (c9526cedaae8a6f13c52592df57f78e6e >= _arrItemSlots.Length)
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
				if (cb4be6dae1755138c26d22542471266a1 != null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							_arrCheckBoxes[c9526cedaae8a6f13c52592df57f78e6e].cbf402c82d0fffee7c8f37c98e456b8f8 = true;
							UIItemSlotData uIItemSlotData = new UIItemSlotData(cb4be6dae1755138c26d22542471266a1, "character", c9526cedaae8a6f13c52592df57f78e6e);
							_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c591d56a94543e3559945c497f37126c4 = uIItemSlotData;
							WeaponDNA weaponDNA = cb4be6dae1755138c26d22542471266a1.ca79da172938fdc8c067fb64242b6174a();
							if (weaponDNA != null)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										c7beefc397f483dc0b72dcd3e6bdcf929 c76cc6288aad6ff8d562a2365e727c68c = _arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c76cc6288aad6ff8d562a2365e727c68c;
										if (c76cc6288aad6ff8d562a2365e727c68c != null)
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
											c76cc6288aad6ff8d562a2365e727c68c.c2f5e208842730f75c8d5498004244d2a = 0.95f;
											c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cd6102468cd57214a9f3e10633998391b);
										}
										_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c1d4a927ba62b28412f982cec1c20bc7a = true;
										_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(cb4be6dae1755138c26d22542471266a1);
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
				if (_arrCheckBoxes[c9526cedaae8a6f13c52592df57f78e6e].c9c364a8fd1f013589fea518a3924e711)
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
					_arrCheckBoxes[c9526cedaae8a6f13c52592df57f78e6e].c9c364a8fd1f013589fea518a3924e711 = false;
				}
				_arrCheckBoxes[c9526cedaae8a6f13c52592df57f78e6e].cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].c591d56a94543e3559945c497f37126c4 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
				_arrItemSlots[c9526cedaae8a6f13c52592df57f78e6e].cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}

		public void ca5c8706e8e1a3983aa563c97b7b0ba17(int c9526cedaae8a6f13c52592df57f78e6e)
		{
			if (c9526cedaae8a6f13c52592df57f78e6e < 0)
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
				if (c9526cedaae8a6f13c52592df57f78e6e >= _arrCheckBoxes.Length)
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
				if (!_arrCheckBoxes[c9526cedaae8a6f13c52592df57f78e6e].c9c364a8fd1f013589fea518a3924e711)
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
					_arrCheckBoxes[c9526cedaae8a6f13c52592df57f78e6e].c9c364a8fd1f013589fea518a3924e711 = true;
				}
				iActivedIndex = c9526cedaae8a6f13c52592df57f78e6e;
				return;
			}
		}

		public void c4e5885239aaa9f9a523565e9d69d931d()
		{
			if (mc3DAvatar == null)
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
				Rect cadc118b5c81bb89bf38380c9747869ba = UniUIManager.UniSWFToolClass.ca32a2d214165802d3f1493d30c8bf414(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c0c17e73f50a88deade51a968597893c7());
				mc3DAvatar.c533af2b08173b7c2e3e5405efc254ee3(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9bf29a49cfe42cc19891e9333401d847(), cadc118b5c81bb89bf38380c9747869ba);
				return;
			}
		}

		public void c47393768ad382bdbf970d931566c6efe(PlayerProperties c25f5f36a54095a8f73d85c7f7b5af196)
		{
			_playerInfo = c25f5f36a54095a8f73d85c7f7b5af196;
			if (_playerInfo == null)
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
				if (mcPlayerName != null)
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
					mcPlayerName.text = _playerInfo.m_name;
				}
				cacf24eecb26befe8b4a58dcc98617d24();
				return;
			}
		}

		public void c6521ba8359487330208b7a29c28ea898(float cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (mcInfoPanel == null)
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
				UnityTextField childByName = mcInfoPanel.getChildByName<UnityTextField>("tfDamage");
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
					childByName.text = cefda2fdc3ce4e04f38bab77fc7998241.ToString("f2");
					return;
				}
			}
		}

		public void c5939103e64f288dfce17db2fb4594432(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (mcInfoPanel == null)
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
				UnityTextField childByName = mcInfoPanel.getChildByName<UnityTextField>("tfShield");
				if (childByName == null)
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
					if (bGreenWord)
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
						childByName.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
					}
					childByName.text = cefda2fdc3ce4e04f38bab77fc7998241.ToString();
					return;
				}
			}
		}

		private static string c04c953cb5003b6f9b255116d2e691e1a(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
		{
			switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
			{
			case AmmoType.AssaultRifle:
				return "mcAmmoAssaultRifle";
			case AmmoType.Grenade:
				return "mcAmmoGrenade";
			case AmmoType.Pistol:
				return "mcAmmoPistol";
			case AmmoType.ShotGun:
				return "mcAmmoShotGun";
			case AmmoType.SMG:
				return "mcAmmoSMG";
			case AmmoType.SniperRifle:
				return "mcAmmoSniperRifle";
			default:
				return string.Empty;
			}
		}

		private static string c7cdc11fc19e27bf08c22d89326c89799(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
		{
			switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
			{
			case AmmoType.AssaultRifle:
				return "mcAmmoAssaultRifle_max";
			case AmmoType.Grenade:
				return "mcAmmoGrenade_max";
			case AmmoType.Pistol:
				return "mcAmmoPistol_max";
			case AmmoType.ShotGun:
				return "mcAmmoShotGun_max";
			case AmmoType.SMG:
				return "mcAmmoSMG_max";
			case AmmoType.SniperRifle:
				return "mcAmmoSniperRifle_max";
			default:
				return string.Empty;
			}
		}

		public void cadd349c2753bedc4aac3aac852b41457(Dictionary<int, Vector2> c0bba4a6c36e3f05f02579c37d3767121)
		{
			if (mcInfoPanel == null)
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
			MovieClip movieClip = mcInfoPanel;
			if (movieClip == null)
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
				Dictionary<int, Vector2>.Enumerator enumerator = c0bba4a6c36e3f05f02579c37d3767121.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TextField childByName = movieClip.getChildByName<TextField>(c04c953cb5003b6f9b255116d2e691e1a((AmmoType)enumerator.Current.Key));
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
						m_stringbuilder.Length = 0;
						m_stringbuilder.Append(enumerator.Current.Value.x);
						childByName.text = m_stringbuilder.ToString();
					}
					childByName = movieClip.getChildByName<TextField>(c7cdc11fc19e27bf08c22d89326c89799((AmmoType)enumerator.Current.Key));
					if (childByName == null)
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
					m_stringbuilder.Length = 0;
					m_stringbuilder.Append(enumerator.Current.Value.y);
					childByName.text = m_stringbuilder.ToString();
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

		public void ce85c7c6c50bdf157a44e25f726d89b5c(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcRootMovie = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (mcRootMovie == null)
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
				if (mcInfoPanel == null)
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
					mcInfoPanel = mcRootMovie.getChildByName<MovieClip>("mcRoot");
				}
				cacf24eecb26befe8b4a58dcc98617d24();
				mcPlayerName = mcRootMovie.getChildByName<MovieClip>("mcRoot").getChildByName<TextField>("mcPlayerName");
				if (_playerInfo == null)
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
					mcPlayerName.text = _playerInfo.m_name;
					return;
				}
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			int num = UniUIManager.UniSWFToolClass.c001baac049112f025f0375d4fb44e2b0(movieClip.name, ITEM_SLOT_PREFIX_NAME);
			if (num >= 0)
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
				if (num < _arrItemSlots.Length)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = new c87da635fd7858aaa8f8053a95f123b32();
							c87da635fd7858aaa8f8053a95f123b.c130648b59a0c8debea60aa153f844879(movieClip);
							c87da635fd7858aaa8f8053a95f123b.addEventListener(MouseEvent.CLICK, ceaa483d1c7de4ff85b2bd14fa57fd849);
							c87da635fd7858aaa8f8053a95f123b.addEventListener("slash", cd31beb006c9b6f0df33cc5b8d7c495e5);
							c87da635fd7858aaa8f8053a95f123b.addEventListener("drop", c7f918a1d1b2f8e24904c4775619d988e);
							c87da635fd7858aaa8f8053a95f123b.c789178c13643f19818274be2b952ee75(c770b86d9d8fae414c9e83ca227015e44);
							c87da635fd7858aaa8f8053a95f123b.cd55b0729145dbbb40133dc949a6ab274 = num;
							_arrItemSlots[num] = c87da635fd7858aaa8f8053a95f123b;
							return true;
						}
						}
					}
				}
			}
			num = UniUIManager.UniSWFToolClass.c001baac049112f025f0375d4fb44e2b0(movieClip.name, ITEM_CHECKBOX_PREFIX_NAME);
			if (num >= 0)
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
				if (num < _arrCheckBoxes.Length)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							c6425d3761c85e65e3530cc19d085d446 c6425d3761c85e65e3530cc19d085d = new c6425d3761c85e65e3530cc19d085d446();
							c6425d3761c85e65e3530cc19d085d.c130648b59a0c8debea60aa153f844879(movieClip);
							c6425d3761c85e65e3530cc19d085d.addEventListener(MouseEvent.CLICK, c54f6f290fb1fe45c8717b5cf2c033bf6);
							c6425d3761c85e65e3530cc19d085d.ce84b930a12a1d06512c79320b3f0d3f4 = false;
							c6425d3761c85e65e3530cc19d085d.cec024da8c099380cfe1334bfe4c8f30f = "characterInfo";
							c6425d3761c85e65e3530cc19d085d.c591d56a94543e3559945c497f37126c4 = num;
							_arrCheckBoxes[num] = c6425d3761c85e65e3530cc19d085d;
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
				if (_003C_003Ef__switch_0024mapA == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(10);
					dictionary.Add("mcXButton", 0);
					dictionary.Add("mcAvatar", 1);
					dictionary.Add("mcInfoPanel", 2);
					dictionary.Add("mcDetailBtn", 3);
					dictionary.Add("mcEquipRadio0", 4);
					dictionary.Add("mcEquipRadio1", 5);
					dictionary.Add("mcTabPanel0", 6);
					dictionary.Add("mcTabPanel1", 7);
					dictionary.Add("mcShieldSlot", 8);
					dictionary.Add("mcClassModeSlot", 9);
					_003C_003Ef__switch_0024mapA = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024mapA.TryGetValue(name, out value))
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
						mcXButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcXButton.c130648b59a0c8debea60aa153f844879(movieClip);
						mcXButton.addEventListener(MouseEvent.CLICK, c33d802bc86e36d426896b838a8f61e31);
						result = true;
						break;
					case 1:
						mcAvatar = movieClip;
						movieClip.stopAll();
						mc3DAvatar = new c7beefc397f483dc0b72dcd3e6bdcf929();
						mc3DAvatar.c130648b59a0c8debea60aa153f844879(movieClip);
						mcAvatar.addEventListener(MouseEvent.MOUSE_DOWN, c6053f699c02ebbd364cedf0195d1d672);
						mcAvatar.addEventListener(MouseEvent.MOUSE_UP, c6053f699c02ebbd364cedf0195d1d672);
						mcAvatar.addEventListener(MouseEvent.MOUSE_LEAVE, c6053f699c02ebbd364cedf0195d1d672);
						result = true;
						break;
					case 2:
						mcInfoPanel = movieClip;
						mcInfoPanel.stop();
						cacf24eecb26befe8b4a58dcc98617d24();
						break;
					case 3:
						mcDetailBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcDetailBtn.c130648b59a0c8debea60aa153f844879(movieClip);
						mcDetailBtn.addEventListener(MouseEvent.CLICK, cc8ce881316b21df5c1384f68de4d0999);
						result = true;
						break;
					case 4:
						mcEquipRadio0 = new c6425d3761c85e65e3530cc19d085d446();
						mcEquipRadio0.c130648b59a0c8debea60aa153f844879(movieClip);
						mcEquipRadio0.c9c364a8fd1f013589fea518a3924e711 = true;
						mcEquipRadio0.ce84b930a12a1d06512c79320b3f0d3f4 = false;
						mcEquipRadio0.cec024da8c099380cfe1334bfe4c8f30f = "charInfoEquip";
						mcEquipRadio0.c6279c42b47398c5e401c1cff54ce61c2.addEventListener(CEvent.CHANGED, cabfab31f7e7c18640d4fdfea8e1ed329);
						result = true;
						break;
					case 5:
						mcEquipRadio1 = new c6425d3761c85e65e3530cc19d085d446();
						mcEquipRadio1.c130648b59a0c8debea60aa153f844879(movieClip);
						mcEquipRadio1.ce84b930a12a1d06512c79320b3f0d3f4 = false;
						mcEquipRadio1.cec024da8c099380cfe1334bfe4c8f30f = "charInfoEquip";
						result = true;
						break;
					case 6:
						mcTabPanel0 = movieClip;
						mcTabPanel0.visible = true;
						result = false;
						break;
					case 7:
						mcTabPanel1 = movieClip;
						mcTabPanel1.visible = false;
						result = false;
						break;
					case 8:
						mcShieldSlot = new c87da635fd7858aaa8f8053a95f123b32();
						mcShieldSlot.c130648b59a0c8debea60aa153f844879(movieClip);
						mcShieldSlot.addEventListener(MouseEvent.CLICK, c47040553e9ab939e6c43582327c5e90d);
						mcShieldSlot.addEventListener("slash", c869722b0db442ef7c022f2fcd4f1f9b4);
						mcShieldSlot.addEventListener("drop", c1350fad7367128232b8889deab2ff446);
						mcShieldSlot.c789178c13643f19818274be2b952ee75(c48bf6437291a9293ebdaedc327c20610);
						break;
					case 9:
						mcClassModeSlot = new c87da635fd7858aaa8f8053a95f123b32();
						mcClassModeSlot.c130648b59a0c8debea60aa153f844879(movieClip);
						mcClassModeSlot.addEventListener(MouseEvent.CLICK, c47040553e9ab939e6c43582327c5e90d);
						mcClassModeSlot.addEventListener("slash", c869722b0db442ef7c022f2fcd4f1f9b4);
						mcClassModeSlot.addEventListener("drop", c9f1a638b391b21e3649e0d642631f7f5);
						mcClassModeSlot.c789178c13643f19818274be2b952ee75(ce2c8311eb62179d7b76da473d311d5ca);
						break;
					}
				}
			}
			return result;
		}

		private bool c770b86d9d8fae414c9e83ca227015e44(object c591d56a94543e3559945c497f37126c4)
		{
			try
			{
				if (c591d56a94543e3559945c497f37126c4 == null)
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
							return false;
						}
					}
				}
				UIItemSlotData uIItemSlotData = (UIItemSlotData)c591d56a94543e3559945c497f37126c4;
				if (uIItemSlotData.item == null)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				return uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon);
			}
			catch (InvalidCastException)
			{
				return false;
			}
		}

		private bool c48bf6437291a9293ebdaedc327c20610(object c591d56a94543e3559945c497f37126c4)
		{
			try
			{
				if (c591d56a94543e3559945c497f37126c4 == null)
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
							return false;
						}
					}
				}
				UIItemSlotData uIItemSlotData = (UIItemSlotData)c591d56a94543e3559945c497f37126c4;
				if (uIItemSlotData.item == null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				return uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield);
			}
			catch (InvalidCastException)
			{
				return false;
			}
		}

		private bool ce2c8311eb62179d7b76da473d311d5ca(object c591d56a94543e3559945c497f37126c4)
		{
			try
			{
				if (c591d56a94543e3559945c497f37126c4 == null)
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
							return false;
						}
					}
				}
				UIItemSlotData uIItemSlotData = (UIItemSlotData)c591d56a94543e3559945c497f37126c4;
				if (uIItemSlotData.item == null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				return uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode);
			}
			catch (InvalidCastException)
			{
				return false;
			}
		}

		private void c6053f699c02ebbd364cedf0195d1d672(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new CEvent("Model_" + c3d202dee321219a80026dc3081fb3c86.type));
		}

		private void cacf24eecb26befe8b4a58dcc98617d24()
		{
			if (mcInfoPanel == null)
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
				if (_playerInfo == null)
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
					MovieClip movieClip = mcInfoPanel;
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
						MovieClip childByName = movieClip.getChildByName<MovieClip>("mcIcon");
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
							childByName = childByName.getChildByName<MovieClip>("mcClassIcon");
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
								childByName.gotoAndStop(_playerInfo.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a().ToString());
							}
						}
						UnityTextField childByName2 = movieClip.getChildByName<UnityTextField>("tfHP");
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
							if (bGreenWord)
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
								childByName2.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
							}
							if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
								EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
								if ((bool)entityPlayer)
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
									EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.c5ca38fad98337fc5c7255384b2cd1a86();
									if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
										childByName2.text = equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620().ToString();
									}
								}
							}
						}
						childByName2 = movieClip.getChildByName<UnityTextField>("tfLevel");
						if (childByName2 != null)
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
							if (bGreenWord)
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
								childByName2.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
							}
							childByName2.text = _playerInfo.m_level.ToString();
						}
						childByName2 = movieClip.getChildByName<UnityTextField>("tfLucky");
						childByName2 = movieClip.getChildByName<UnityTextField>("tfCritical");
						childByName2.text = "100%";
						childByName2 = movieClip.getChildByName<UnityTextField>("tfWorldRank");
						childByName2 = movieClip.getChildByName<UnityTextField>("tfReputation");
						return;
					}
				}
			}
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
				switch (5)
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
					target = new UIItemSlotData(null, "character", (int)(cdd9021d4f44808fce2ab49c52f0db6f.target as c87da635fd7858aaa8f8053a95f123b32).cd55b0729145dbbb40133dc949a6ab274);
				}
				if (swapFunc == null)
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
					swapFunc(target, from);
					return;
				}
			}
		}

		protected void cd31beb006c9b6f0df33cc5b8d7c495e5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = c3d202dee321219a80026dc3081fb3c86.target as c87da635fd7858aaa8f8053a95f123b32;
			if (iActivedIndex == (int)c87da635fd7858aaa8f8053a95f123b.cd55b0729145dbbb40133dc949a6ab274)
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
				c87da635fd7858aaa8f8053a95f123b.c35556323454cba71bb12e199cf43bf96();
				return;
			}
		}

		protected void ceaa483d1c7de4ff85b2bd14fa57fd849(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c649b5d45cf350f685c56c4bd02800198 c649b5d45cf350f685c56c4bd = c3d202dee321219a80026dc3081fb3c86 as c649b5d45cf350f685c56c4bd02800198;
			c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = c649b5d45cf350f685c56c4bd.target as c87da635fd7858aaa8f8053a95f123b32;
			if (Input.GetKey(KeyCode.LeftShift))
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
						dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("showWeaponModel", ((UIItemSlotData)c87da635fd7858aaa8f8053a95f123b.c591d56a94543e3559945c497f37126c4).item.ca79da172938fdc8c067fb64242b6174a()));
						return;
					}
				}
			}
			if (iActivedIndex == (int)c87da635fd7858aaa8f8053a95f123b.cd55b0729145dbbb40133dc949a6ab274)
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
				c87da635fd7858aaa8f8053a95f123b.c35556323454cba71bb12e199cf43bf96();
				return;
			}
		}

		protected void c47040553e9ab939e6c43582327c5e90d(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
		}

		protected void c869722b0db442ef7c022f2fcd4f1f9b4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
		}

		protected void c1350fad7367128232b8889deab2ff446(CEvent c3d202dee321219a80026dc3081fb3c86)
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
				UIItemSlotData uIItemSlotData = (UIItemSlotData)((cdaa8be71633914d75e27ba7c238d88d3)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4).c591d56a94543e3559945c497f37126c4;
				if (shieldFunc == null)
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
					if (!uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield))
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
						shieldFunc(uIItemSlotData.index);
						return;
					}
				}
			}
		}

		protected void c9f1a638b391b21e3649e0d642631f7f5(CEvent c3d202dee321219a80026dc3081fb3c86)
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
				UIItemSlotData uIItemSlotData = (UIItemSlotData)((cdaa8be71633914d75e27ba7c238d88d3)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4).c591d56a94543e3559945c497f37126c4;
				if (classModeFunc == null)
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
					if (!uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
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
						classModeFunc(uIItemSlotData.index);
						return;
					}
				}
			}
		}

		protected void cabfab31f7e7c18640d4fdfea8e1ed329(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			if (mcTabPanel0 == null)
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
				if (mcTabPanel1 == null)
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
					mcTabPanel0.visible = mcEquipRadio0.c9c364a8fd1f013589fea518a3924e711;
					mcTabPanel1.visible = mcEquipRadio1.c9c364a8fd1f013589fea518a3924e711;
					return;
				}
			}
		}

		protected void c54f6f290fb1fe45c8717b5cf2c033bf6(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = cd729d94a5b443ac0f1b117450e5f4419.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
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
				switch (4)
				{
				case 0:
					continue;
				}
				if (activeFunc == null)
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
					activeFunc((int)c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4);
					return;
				}
			}
		}

		protected void c33d802bc86e36d426896b838a8f61e31(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}

		protected void cc8ce881316b21df5c1384f68de4d0999(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cfce1db26c738386631c2292fb284aedb(!_bInfoPanelVisible);
		}

		protected void cfce1db26c738386631c2292fb284aedb(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			if (mcRootMovie.isPlaying)
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
			if (_bInfoPanelVisible == c74232243aff1dcbf2e8fc243633bb51a)
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
			_bInfoPanelVisible = c74232243aff1dcbf2e8fc243633bb51a;
			if (_bInfoPanelVisible)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						mcRootMovie.gotoAndPlay(INFO_FRAME_PREFIX_NAME + "FadeIn");
						return;
					}
				}
			}
			mcRootMovie.gotoAndPlay(INFO_FRAME_PREFIX_NAME + "FadeOut");
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mcRootMovie.visible = true;
			_bInfoPanelVisible = false;
			mcRootMovie.gotoAndPlay("Open");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			string empty = string.Empty;
			string text;
			if (_bInfoPanelVisible)
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
				text = INFO_FRAME_PREFIX_NAME;
			}
			else
			{
				text = string.Empty;
			}
			empty = text + "Close";
			mcRootMovie.gotoAndPlay(empty);
			mcRootMovie.addFrameScript(INFO_FRAME_PREFIX_NAME + "End", c1a8a5357baa03eacf7b0a3123daf5911);
			mcRootMovie.addFrameScript("End", c1a8a5357baa03eacf7b0a3123daf5911);
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcRootMovie.removeEventListener(INFO_FRAME_PREFIX_NAME + "End", c1a8a5357baa03eacf7b0a3123daf5911);
			mcRootMovie.removeEventListener("End", c1a8a5357baa03eacf7b0a3123daf5911);
			mcRootMovie.visible = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}
	}

	public delegate void Item_SWAP_Delegate(UIItemSlotData target, UIItemSlotData from);

	public delegate void Index_Delegate(int index);

	protected CharacterPanel m_charPanel;

	public override bool bPVPDisp
	{
		get
		{
			return base.bPVPDisp;
		}
		set
		{
			base.bPVPDisp = value;
			if (m_charPanel == null)
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
				m_charPanel.bGreenWord = value;
				return;
			}
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (m_charPanel.c27b8b8f2b26d9420fc1ac46dcae468c9)
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
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		c5942a289bb847abf2556f0b87b099420(_bVisible);
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(m_charPanel);
			c84f8fe2787c4ed57941b65ae934afecb();
			ca3635a4b4a9f3ba6302a0d67a0e4bdd1();
			cd71e2126c8425bde7ada191d04ee332b();
			ca247e8f91ccc6b7709c863cbf715e1ee();
			c005e92d6b4fdb43cc882206a3f0c3ffb();
			c27bd9cdd263e29de38d1f6ea82554bbe();
			cd4ae322c1148400237b6aaa1cba32b5a();
			ca247e8f91ccc6b7709c863cbf715e1ee();
		}
		m_charPanel.c150264a18c2cb408479d3f072cac8cc1 = _bVisible;
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c968ae3f7ba22e4826b18039ba36f33ce(this, new Vector2(0f, 0f));
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Inventory.swf", "Panel_Character", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_charPanel = new CharacterPanel();
		m_charPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = _bVisible;
		m_charPanel.bGreenWord = bPVPDisp;
		CharacterPanel charPanel = m_charPanel;
		charPanel.swapFunc = (Item_SWAP_Delegate)Delegate.Combine(charPanel.swapFunc, new Item_SWAP_Delegate(c9419d86b8c8857553e71d329d76530d5));
		CharacterPanel charPanel2 = m_charPanel;
		charPanel2.activeFunc = (Index_Delegate)Delegate.Combine(charPanel2.activeFunc, new Index_Delegate(base.c62e2102e53dae59b098c9594c8583845));
		CharacterPanel charPanel3 = m_charPanel;
		charPanel3.shieldFunc = (Index_Delegate)Delegate.Combine(charPanel3.shieldFunc, new Index_Delegate(base.c7cd1f59ace6ee251759251efbe7bb224));
		CharacterPanel charPanel4 = m_charPanel;
		charPanel4.classModeFunc = (Index_Delegate)Delegate.Combine(charPanel4.classModeFunc, new Index_Delegate(base.c66b709849d82c29e7dc0c64463b37c17));
		m_charPanel.addEventListener("showWeaponModel", c82879ab8fa4fd4a11b2ae590587ffe92);
		m_charPanel.addEventListener("Model_" + MouseEvent.MOUSE_DOWN, c484292ca6780116e28c388fa692ca69c);
		m_charPanel.addEventListener("Model_" + MouseEvent.MOUSE_UP, ccc15e86e7c00e2446466584e0bbbb239);
		m_charPanel.addEventListener("Model_" + MouseEvent.MOUSE_LEAVE, ccc15e86e7c00e2446466584e0bbbb239);
		DisplayObject childByName = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName("mcInventoryPosition");
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c968ae3f7ba22e4826b18039ba36f33ce(this, ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c46e387bea9111b07d3d0e2e52548626c(childByName, Vector2.zero));
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		if (m_charPanel != null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_charPanel);
			CharacterPanel charPanel = m_charPanel;
			charPanel.swapFunc = (Item_SWAP_Delegate)Delegate.Remove(charPanel.swapFunc, new Item_SWAP_Delegate(c9419d86b8c8857553e71d329d76530d5));
			CharacterPanel charPanel2 = m_charPanel;
			charPanel2.activeFunc = (Index_Delegate)Delegate.Remove(charPanel2.activeFunc, new Index_Delegate(base.c62e2102e53dae59b098c9594c8583845));
			CharacterPanel charPanel3 = m_charPanel;
			charPanel3.shieldFunc = (Index_Delegate)Delegate.Remove(charPanel3.shieldFunc, new Index_Delegate(base.c7cd1f59ace6ee251759251efbe7bb224));
		}
		m_charPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Inventory.swf");
	}

	protected override void c84f8fe2787c4ed57941b65ae934afecb()
	{
		if (m_charPanel == null)
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
		for (int i = 0; i < _iWeaponSlotSum; i++)
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
			if (i < _arrWeapons.Length)
			{
				Texture2D cd6102468cd57214a9f3e10633998391b = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
				if (_arrWeapons[i] != null)
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
					cd6102468cd57214a9f3e10633998391b = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(_arrWeapons[i]);
				}
				m_charPanel.ce173ad44b3260fda2aad425f9352f093(i, _arrWeapons[i], cd6102468cd57214a9f3e10633998391b);
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
			break;
		}
		m_charPanel.ca5c8706e8e1a3983aa563c97b7b0ba17(_iActivedIndex);
	}

	protected override void ca3635a4b4a9f3ba6302a0d67a0e4bdd1()
	{
		if (m_charPanel == null)
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
		if (_playerInfo == null)
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
			m_charPanel.c47393768ad382bdbf970d931566c6efe(_playerInfo);
			return;
		}
	}

	protected override void c27bd9cdd263e29de38d1f6ea82554bbe()
	{
		if (m_charPanel == null)
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
		m_charPanel.c4e5885239aaa9f9a523565e9d69d931d();
	}

	protected override void cd71e2126c8425bde7ada191d04ee332b()
	{
		if (m_charPanel == null)
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
		m_charPanel.cadd349c2753bedc4aac3aac852b41457(_ammoInfoList);
	}

	protected override void cd4ae322c1148400237b6aaa1cba32b5a()
	{
		if (m_charPanel == null)
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
		if (!c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c39df47367fa21412aabfef05d9972f8c())
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
			m_charPanel.c6521ba8359487330208b7a29c28ea898(c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ce34672c48c333964ff0b398bfef60e97());
			return;
		}
	}

	protected override void ca247e8f91ccc6b7709c863cbf715e1ee()
	{
		if (m_charPanel == null)
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
		Texture2D cd6102468cd57214a9f3e10633998391b = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
		if (_shieldDNA != null)
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
			cd6102468cd57214a9f3e10633998391b = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(_shieldDNA);
		}
		m_charPanel.c5939103e64f288dfce17db2fb4594432(_shieldDNA, cd6102468cd57214a9f3e10633998391b);
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
				EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
				if (!entityPlayer)
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
					EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.c5ca38fad98337fc5c7255384b2cd1a86();
					if (!(equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						m_charPanel.c5939103e64f288dfce17db2fb4594432(equipmentInventoryEntity.ca937003ba4cbf4130cad1fcc9da2873e());
						return;
					}
				}
			}
		}
	}

	protected override void c005e92d6b4fdb43cc882206a3f0c3ffb()
	{
		if (m_charPanel == null)
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
		Texture2D cd6102468cd57214a9f3e10633998391b = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
		if (_classModeDNA != null)
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
			cd6102468cd57214a9f3e10633998391b = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(_classModeDNA);
		}
		m_charPanel.c3073f21f22259bbb1160a60060b0bbee(_classModeDNA, cd6102468cd57214a9f3e10633998391b);
	}

	protected void c9419d86b8c8857553e71d329d76530d5(UIItemSlotData c82fcbab5e578dc3a31c1f662916bd87e, UIItemSlotData cae5fea398599f41bfafc9b6bb6f4559b)
	{
		if (cae5fea398599f41bfafc9b6bb6f4559b.identifier == "inventory")
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
					if (cae5fea398599f41bfafc9b6bb6f4559b.item.m_type == ItemType.Weapon)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								c8e05ed0c132b36a56b8484bb4dabb30e(cae5fea398599f41bfafc9b6bb6f4559b.index, c82fcbab5e578dc3a31c1f662916bd87e.index);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(cae5fea398599f41bfafc9b6bb6f4559b.identifier == "character"))
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
			cc7927fb2f699a2f6495cf21a5cf02606(cae5fea398599f41bfafc9b6bb6f4559b.index, c82fcbab5e578dc3a31c1f662916bd87e.index);
			return;
		}
	}

	protected override void ca71ff9e891e72ba05d0d35e6c20d3292()
	{
		for (int i = 0; i < _arrWeapons.Length; i++)
		{
			ItemDNA itemDNA = _arrWeapons[i];
			if (itemDNA == null)
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
			c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA);
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

	protected void c82879ab8fa4fd4a11b2ae590587ffe92(CEvent c3d202dee321219a80026dc3081fb3c86)
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
			WeaponDNA c39409683a32e09391d094314ffeae2b = (WeaponDNA)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponPreviewView>().c6187275e7336eafc3a9acc48a6644c55(c39409683a32e09391d094314ffeae2b);
			return;
		}
	}

	protected void c484292ca6780116e28c388fa692ca69c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (!(_modelController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_modelController.c0611c0503cb7e55eec97e2f0b356bbcd(new Vector3(-0.5f, 0f, 0f));
			return;
		}
	}

	protected void ccc15e86e7c00e2446466584e0bbbb239(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (!(_modelController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_modelController.c0611c0503cb7e55eec97e2f0b356bbcd(Vector3.zero);
			return;
		}
	}
}
