using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;

public class uniHUDAimTargetView : HUDAimTargetView
{
	public enum CROSS_HAIR_COLOR
	{
		WHITE = 0,
		RED = 1,
		YELLOW = 2,
		GREEN = 3
	}

	private class BossHudPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected TextField tfBossName;

		protected TextField tfBossLevel;

		protected MovieClip mcCursor;

		protected MovieClip mcBlueBar;

		protected MovieClip mcYellowBar;

		protected MovieClip mcRedBar;

		protected MovieClip[] mcProgressBars;

		protected MovieClip mcCurrentBar;

		private bool m_bBossInfoSet;

		private bool m_bBossKilled;

		private bool m_bEnableHP = true;

		private bool m_bPhaseChanged;

		private int m_nPhase = 1;

		private EntityNpc m_BossEntity;

		protected bool _bVisible;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf != null)
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
							return mcSelf.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mcSelf == null)
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
					mcSelf.visible = value;
					return;
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: BossHudPanel onInit() 'mcSelf' is null! BossHudPanel won't work!!!");
						return;
					}
				}
			}
			mcSelf.stop();
			tfBossName = mcSelf.getChildByName<TextField>("nameLabel");
			tfBossLevel = mcSelf.getChildByName<TextField>("level");
			mcCursor = mcSelf.getChildByName<MovieClip>("mc_cusor");
			mcCursor.stop();
			mcBlueBar = mcSelf.getChildByName<MovieClip>("mc_bluebar");
			mcBlueBar.stop();
			mcYellowBar = mcSelf.getChildByName<MovieClip>("mc_yellowbar");
			mcYellowBar.stop();
			mcRedBar = mcSelf.getChildByName<MovieClip>("mc_redbar");
			mcRedBar.stop();
			MovieClip[] array = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = mcCursor;
			array[1] = mcBlueBar;
			array[2] = mcYellowBar;
			array[3] = mcRedBar;
			mcProgressBars = array;
			mcCurrentBar = mcBlueBar;
			cb4f3308a027b872c9958bc80d30da06c();
		}

		private void cb4f3308a027b872c9958bc80d30da06c()
		{
			for (int i = 0; i < mcProgressBars.Length; i++)
			{
				MaskManager maskManager = MaskManager.c71f6ce28731edfd43c976fbd57c57bea();
				MovieClip childByName = mcProgressBars[i].getChildByName<MovieClip>("mcProgressMask");
				MovieClip[] array = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = mcProgressBars[i].getChildByName<MovieClip>("mcProgressBar");
				maskManager.c691ab6ea2ee6d471d8daa38c709e55f3(childByName, array);
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

		private void c97c2bcb1b01aec9b01c9262ed63c0857()
		{
			MaskManager.c71f6ce28731edfd43c976fbd57c57bea().Update(mcCursor.getChildByName<MovieClip>("mcProgressMask"));
			MaskManager.c71f6ce28731edfd43c976fbd57c57bea().Update(mcCurrentBar.getChildByName<MovieClip>("mcProgressMask"));
		}

		private void cd7bfb3173c68926ed73264babdcc0544()
		{
			for (int i = 0; i < mcProgressBars.Length; i++)
			{
				MaskManager.c71f6ce28731edfd43c976fbd57c57bea().c6a66de0dc4243b4bccc9ecf8069b15d9(mcProgressBars[i].getChildByName<MovieClip>("mcProgressMask"));
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

		public void cd2e48af5036f9af603d95eb723ef7beb(EntityNpc c5d720f6d007abb0c4a21d6a654e405bb)
		{
			if (!string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_autoTestCase))
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
			if (m_BossEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!(c5d720f6d007abb0c4a21d6a654e405bb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_BossEntity = c5d720f6d007abb0c4a21d6a654e405bb;
				mcSelf.addEventListener(CEvent.ENTER_FRAME, Update);
				return;
			}
		}

		public void cc65a6852af6fc5b9fc0cb6a7fa951de2(int cd6bb591c33b2ee3ab93e98aa43a6da63, string cd99af21e22e356018b8f72d4a7e4872a)
		{
			if (tfBossName != null)
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
				tfBossName.text = cd99af21e22e356018b8f72d4a7e4872a;
			}
			if (tfBossLevel == null)
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
				if (cd6bb591c33b2ee3ab93e98aa43a6da63 != 0)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							tfBossLevel.text = "LV:" + cd6bb591c33b2ee3ab93e98aa43a6da63;
							return;
						}
					}
				}
				tfBossLevel.text = string.Empty;
				return;
			}
		}

		public void cab478a9dbd639cc459c21d4e2b0bd54c(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6, int c0bb32bee3cf6dd96e41e00dc5a4ae21a, int ce9468aa2dd2bd99d09db5f068744c509, int cb0f8292d8f444f9ae8f374bdd92e60f5)
		{
			if (mcCurrentBar == null)
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
			if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						if (m_nPhase == 3)
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
							if (mcCurrentBar == mcRedBar)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										if (!m_bBossKilled)
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
													m_bBossKilled = true;
													mcCurrentBar.gotoAndStop(100);
													mcCursor.gotoAndStop(100);
													m_bEnableHP = false;
													mcCursor.visible = false;
													mcCurrentBar.gotoAndPlay(101);
													mcSelf.addEventListener(CEvent.ENTER_FRAME, c49090463c064defd652037c9109b6fd7);
													return;
												}
											}
										}
										return;
									}
								}
							}
						}
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "UIWarning: BossHudPanel::SetHealthBar Boss's life point is 0, its phase is ";
						array[1] = c0bb32bee3cf6dd96e41e00dc5a4ae21a;
						array[2] = " and its MaxLifePoint is ";
						array[3] = ce565b32ce48270d8a80781c7ab11cae6;
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
						return;
					}
					}
				}
			}
			if (m_nPhase != c0bb32bee3cf6dd96e41e00dc5a4ae21a)
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
				m_bPhaseChanged = true;
				m_nPhase = c0bb32bee3cf6dd96e41e00dc5a4ae21a;
			}
			else
			{
				m_bPhaseChanged = false;
			}
			ca78de5e2084d6b058e6ebdc8e85d7fae = Mathf.FloorToInt(ca78de5e2084d6b058e6ebdc8e85d7fae - ce565b32ce48270d8a80781c7ab11cae6 * ce9468aa2dd2bd99d09db5f068744c509 / 100);
			ce565b32ce48270d8a80781c7ab11cae6 = Mathf.FloorToInt(ce565b32ce48270d8a80781c7ab11cae6 * Math.Abs(cb0f8292d8f444f9ae8f374bdd92e60f5 - ce9468aa2dd2bd99d09db5f068744c509) / 100);
			if (m_bPhaseChanged)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (m_bEnableHP)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									mcCurrentBar.gotoAndStop(100);
									mcCursor.gotoAndStop(100);
									m_bEnableHP = false;
									mcCursor.visible = false;
									mcCurrentBar.gotoAndPlay(101);
									mcSelf.addEventListener(CEvent.ENTER_FRAME, c49090463c064defd652037c9109b6fd7);
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (!m_bEnableHP)
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
				int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
				mcCurrentBar.gotoAndStop(101 - num);
				if (!mcCursor.visible)
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
					mcCursor.visible = true;
				}
				mcCursor.gotoAndStop(101 - num);
				return;
			}
		}

		private void c49090463c064defd652037c9109b6fd7(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (mcCurrentBar.isPlaying)
			{
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
			if (m_nPhase == 1)
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
				mcBlueBar.visible = true;
				mcBlueBar.gotoAndStop(1);
				mcYellowBar.gotoAndStop(1);
				mcYellowBar.visible = true;
				mcCurrentBar = mcBlueBar;
			}
			else if (m_nPhase == 2)
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
				mcBlueBar.visible = false;
				mcYellowBar.gotoAndStop(1);
				mcRedBar.gotoAndStop(1);
				mcRedBar.visible = true;
				mcYellowBar.visible = true;
				mcCurrentBar = mcYellowBar;
			}
			else
			{
				if (m_nPhase == 3)
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
					if (mcCurrentBar == mcYellowBar)
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
						mcYellowBar.visible = false;
						mcRedBar.gotoAndStop(1);
						mcRedBar.visible = true;
						mcCurrentBar = mcRedBar;
						goto IL_0185;
					}
				}
				if (m_nPhase == 3)
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
					if (mcCurrentBar == mcRedBar)
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
						c150264a18c2cb408479d3f072cac8cc1 = false;
						c649543487911247490016f844cdd8ca4();
					}
				}
			}
			goto IL_0185;
			IL_0185:
			m_bEnableHP = true;
			mcSelf.removeEventListener(CEvent.ENTER_FRAME, c49090463c064defd652037c9109b6fd7);
		}

		private void Update(CEvent evt)
		{
			c97c2bcb1b01aec9b01c9262ed63c0857();
			if (m_BossEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						EquipmentInventoryEntityNpcBoss equipmentInventoryEntityNpcBoss = m_BossEntity.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityNpcBoss;
						if (equipmentInventoryEntityNpcBoss != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									if (!m_bBossInfoSet)
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
										if (equipmentInventoryEntityNpcBoss.c7513e66c4e0fc55e6fea9dd9cb8b9943() != 0)
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
											if (!c150264a18c2cb408479d3f072cac8cc1)
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
												c150264a18c2cb408479d3f072cac8cc1 = true;
											}
											cc65a6852af6fc5b9fc0cb6a7fa951de2(equipmentInventoryEntityNpcBoss.c7513e66c4e0fc55e6fea9dd9cb8b9943(), m_BossEntity.ca6bcee369aa6d4cdf126ebaeef6f6c73());
											m_bBossInfoSet = true;
										}
										else
										{
											cc65a6852af6fc5b9fc0cb6a7fa951de2(equipmentInventoryEntityNpcBoss.c7513e66c4e0fc55e6fea9dd9cb8b9943(), m_BossEntity.ca6bcee369aa6d4cdf126ebaeef6f6c73());
										}
									}
									cab478a9dbd639cc459c21d4e2b0bd54c(equipmentInventoryEntityNpcBoss.ca2ff7a501878363cb1d5f0472e306620(), equipmentInventoryEntityNpcBoss.ccfad1bf47b003333c5ddd084f14d33e7(), equipmentInventoryEntityNpcBoss.cd183a5dbb084bdf2992464c044efe530(), equipmentInventoryEntityNpcBoss.c6681f45fcaa97031091f74fc718c5127(), equipmentInventoryEntityNpcBoss.c69c1bed154b761bdb32ed7f4099fd87f());
									return;
								}
							}
						}
						return;
					}
					}
				}
			}
			if (c150264a18c2cb408479d3f072cac8cc1)
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
				c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			mcSelf.removeEventListener(CEvent.ENTER_FRAME, Update);
		}

		public void c649543487911247490016f844cdd8ca4()
		{
			mcBlueBar.visible = true;
			mcRedBar.visible = true;
			mcYellowBar.visible = true;
			mcCursor.visible = true;
			m_bBossInfoSet = false;
			m_bBossKilled = false;
			m_bEnableHP = true;
			m_bPhaseChanged = false;
			m_nPhase = 1;
			mcCurrentBar = mcBlueBar;
			m_BossEntity = c5a038c0475899deb7d599d42df1a5858.c7088de59e49f7108f520cf7e0bae167e;
			mcCursor.gotoAndStop(1);
			mcBlueBar.gotoAndStop(1);
			mcYellowBar.gotoAndStop(1);
			mcRedBar.gotoAndStop(1);
		}
	}

	private class CoatingPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected bool _bVisible;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return _bVisible;
			}
			set
			{
				if (_bVisible == value)
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
				_bVisible = value;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcRoot");
			if (mcSelf == null)
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
				mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			}
			if (mcSelf == null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: CoatingPanel onConfiUI() 'mcSelf' is null! CoatingPanel won't work!!!");
						return;
					}
				}
			}
			mcSelf.stop();
		}

		public void c6623ef8b23a16416be968b58cad3128e(string c2b4f43f34e21572af6ab4414f04cee36)
		{
			mcSelf.gotoAndStop(c2b4f43f34e21572af6ab4414f04cee36);
		}
	}

	private class MaskPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected bool _bVisible;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return _bVisible;
			}
			set
			{
				if (_bVisible == value)
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
				_bVisible = value;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcRoot");
			if (mcSelf == null)
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
				mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			}
			if (mcSelf == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: MaskPanel onConfiUI() 'mcSelf' is null! MaskPanel won't work!!!");
						return;
					}
				}
			}
			mcSelf.stop();
		}

		public void c6623ef8b23a16416be968b58cad3128e(string c2b4f43f34e21572af6ab4414f04cee36)
		{
			mcSelf.gotoAndStop(c2b4f43f34e21572af6ab4414f04cee36);
		}
	}

	private class AIInfoPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected MovieClip mcShieldBar;

		protected MovieClip mcHealthBar;

		protected MovieClip mcHealthColorBar;

		protected TextField tfName;

		protected TextField tfLevel;

		protected TextField tfPlayer;

		protected bool _bVisible;

		protected bool _bMaskSetted;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return _bVisible;
			}
			set
			{
				if (_bVisible == value)
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
				_bVisible = value;
				cb10a54b48a5c53522c1c854a67da038f();
			}
		}

		private void cb10a54b48a5c53522c1c854a67da038f()
		{
			if (ca37fcdce7d4937b60735f4033eb55695 == null)
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
				if (mcSelf == null)
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
				if (_bVisible)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							mcSelf.removeAllEventListeners(CEvent.ENTER_FRAME);
							ca37fcdce7d4937b60735f4033eb55695.visible = true;
							return;
						}
					}
				}
				mcSelf.addEventListener(CEvent.ENTER_FRAME, c49090463c064defd652037c9109b6fd7);
				return;
			}
		}

		private void c49090463c064defd652037c9109b6fd7(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (mcShieldBar.isPlaying)
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
				if (mcHealthBar.isPlaying)
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
				mcSelf.removeAllEventListeners(CEvent.ENTER_FRAME);
				ca37fcdce7d4937b60735f4033eb55695.visible = false;
				return;
			}
		}

		public virtual void c7dcafa368362314dcd96f62f010b3dd8(Entity c6ae1558443885d1fd1bac185e323104d)
		{
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcRoot");
			if (mcSelf == null)
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
				mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			}
			if (mcSelf == null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: AIInfoPanel onConfiUI() 'mcSelf' is null! AIInfoPanel won't work!!!");
						return;
					}
				}
			}
			mcSelf.stop();
			mcShieldBar = mcSelf.getChildByName<MovieClip>("mcShield");
			mcShieldBar.stop();
			mcHealthBar = mcSelf.getChildByName<MovieClip>("mcHealth");
			mcHealthBar.stop();
			mcHealthColorBar = mcHealthBar.getChildByName<MovieClip>("mc_hpbar");
			mcHealthColorBar.stop();
			MaskManager maskManager = MaskManager.c71f6ce28731edfd43c976fbd57c57bea();
			MovieClip childByName = mcShieldBar.getChildByName<MovieClip>("mcProgressMask");
			MovieClip[] array = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = mcShieldBar.getChildByName<MovieClip>("mcProgressBar");
			maskManager.c691ab6ea2ee6d471d8daa38c709e55f3(childByName, array);
			MaskManager maskManager2 = MaskManager.c71f6ce28731edfd43c976fbd57c57bea();
			MovieClip childByName2 = mcHealthBar.getChildByName<MovieClip>("mcProgressMask");
			MovieClip[] array2 = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = mcHealthColorBar;
			maskManager2.c691ab6ea2ee6d471d8daa38c709e55f3(childByName2, array2);
			tfName = mcSelf.getChildByName<TextField>("nameLabel");
			tfLevel = mcSelf.getChildByName<TextField>("level");
			tfPlayer = mcSelf.getChildByName<TextField>("playername");
			_bMaskSetted = false;
		}

		public void c8123b0a5b1c5404d55df72e727311132(string c1fe468c3333face2b1ac9d1c55d68f42)
		{
			if (!_bMaskSetted)
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
				Rectangle bounds = mcHealthBar.getBounds(mcHealthColorBar);
				mcHealthBar.clipRect = bounds.rect;
				_bMaskSetted = true;
			}
			mcHealthColorBar.gotoAndStop(c1fe468c3333face2b1ac9d1c55d68f42);
		}

		public void cab478a9dbd639cc459c21d4e2b0bd54c(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
		{
			if (mcHealthBar == null)
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
			if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
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
				if (mcHealthBar.getCurrentFrame() <= 100)
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
					mcHealthBar.gotoAndPlay(101);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
				mcHealthBar.gotoAndStop(101 - num);
			}
			MaskManager.c71f6ce28731edfd43c976fbd57c57bea().Update(mcHealthBar.getChildByName<MovieClip>("mcProgressMask"));
		}

		public void cb8ad26e2e2615a2600329d5cd8a5b93b(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6, bool c9385a8b4aa29165e7f6c6d3bfcf4c20b = true)
		{
			if (mcShieldBar == null)
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
			if (!c9385a8b4aa29165e7f6c6d3bfcf4c20b)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						mcShieldBar.visible = false;
						return;
					}
				}
			}
			mcShieldBar.visible = true;
			if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
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
				if (ce565b32ce48270d8a80781c7ab11cae6 == 0)
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
					mcShieldBar.gotoAndStop(mcShieldBar.totalFrames);
				}
				else if (mcShieldBar.getCurrentFrame() <= 100)
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
					mcShieldBar.gotoAndPlay(110);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
				mcShieldBar.gotoAndStop(101 - num);
			}
			MaskManager.c71f6ce28731edfd43c976fbd57c57bea().Update(mcShieldBar.getChildByName<MovieClip>("mcProgressMask"));
		}

		public void ce60a543a0ad48212151c9336288092c1(int cd6bb591c33b2ee3ab93e98aa43a6da63, string cd99af21e22e356018b8f72d4a7e4872a, string ceb41162a7cd2a1d5c4a03830e02b4198 = "")
		{
			if (tfName != null)
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
				tfName.text = cd99af21e22e356018b8f72d4a7e4872a;
			}
			if (tfLevel != null)
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
				int num = cd6bb591c33b2ee3ab93e98aa43a6da63;
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
					(tfLevel as UnityTextField).c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
					num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6de0f39084fc3425d6b29d876ff17854();
				}
				if (cd6bb591c33b2ee3ab93e98aa43a6da63 == 0)
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
					tfLevel.text = string.Empty;
				}
				else
				{
					tfLevel.text = "Lv" + num;
				}
			}
			if (tfPlayer == null)
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
				tfPlayer.text = ceb41162a7cd2a1d5c4a03830e02b4198;
				return;
			}
		}
	}

	private class BadassAIInfoPanel : AIInfoPanel
	{
		protected TextField tfSkill;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			tfSkill = mcSelf.getChildByName<TextField>("skillLabel");
		}

		public override void c7dcafa368362314dcd96f62f010b3dd8(Entity c6ae1558443885d1fd1bac185e323104d)
		{
			string text = string.Empty;
			List<PassiveSkillType> list = c6ae1558443885d1fd1bac185e323104d.c11d8925a1c6e53e1ad9411746fd14f72();
			for (int i = 0; i < list.Count; i++)
			{
				text += LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(list[i].ToString()));
				text += " ";
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
				UnityTextField unityTextField = (UnityTextField)tfSkill;
				unityTextField.c34fce3bccfffc6feb3579939c6d9a057 = Color.yellow;
				tfSkill.text = text;
				return;
			}
		}
	}

	public class CrossHairPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected MovieClip mcCrossHair;

		protected Dictionary<CROSS_HAIR_COLOR, string> _ColorFrameMap;

		protected CROSS_HAIR_COLOR _color;

		public float _rightRotation = 90f;

		private AttackInfo.ElementalType elementType = AttackInfo.ElementalType.Max;

		public bool _bScopeMode;

		private float SCOPE_MIN_MARGIN = 20f;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf != null)
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
							return mcSelf.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mcSelf == null)
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
					mcSelf.visible = value;
					return;
				}
			}
		}

		public CrossHairPanel()
		{
			_ColorFrameMap = new Dictionary<CROSS_HAIR_COLOR, string>();
			_ColorFrameMap.Add(CROSS_HAIR_COLOR.WHITE, "white");
			_ColorFrameMap.Add(CROSS_HAIR_COLOR.RED, "red");
			_ColorFrameMap.Add(CROSS_HAIR_COLOR.GREEN, "green");
			_ColorFrameMap.Add(CROSS_HAIR_COLOR.YELLOW, "yellow");
		}

		public virtual void c03bdfe343bec46ff09b53cc0e1af2772(string cd99af21e22e356018b8f72d4a7e4872a, CROSS_HAIR_COLOR c2022f114954310f1130ded90da1fb8b7, bool cd7aa5b04df11f2bf644abbd5d2841766 = false)
		{
			_bScopeMode = cd7aa5b04df11f2bf644abbd5d2841766;
			_color = c2022f114954310f1130ded90da1fb8b7;
			if (mcSelf == null)
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
				mcSelf.gotoAndStop(cd99af21e22e356018b8f72d4a7e4872a);
				mcSelf.addEventListener(CEvent.ENTER_FRAME, c3460e53f63705e49d9fa898affdf06f1);
				return;
			}
		}

		public void c8e36274b37533d0e18e8717eb68d598e(AttackInfo.ElementalType c2b4f43f34e21572af6ab4414f04cee36)
		{
			elementType = c2b4f43f34e21572af6ab4414f04cee36;
		}

		public virtual void ce9f69ed78b52af94d7d66afb3ba803e7(int cd4ae0ac4cbfb1d9dc6c08d98a62730b4)
		{
			if (mcCrossHair == null)
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
				if (mcSelf == null)
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
				float num = 0f;
				float num2 = 120f;
				float num3 = 0f;
				for (int i = 0; i < 3; i++)
				{
					MovieClip childByName = mcCrossHair.getChildByName<MovieClip>("piece" + i);
					if (childByName == null)
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
					childByName.x = Mathf.Sin(num / 180f * (float)Math.PI) * (SCOPE_MIN_MARGIN + (float)cd4ae0ac4cbfb1d9dc6c08d98a62730b4);
					childByName.y = (0f - Mathf.Cos(num / 180f * (float)Math.PI)) * (SCOPE_MIN_MARGIN + (float)cd4ae0ac4cbfb1d9dc6c08d98a62730b4);
					childByName.rotation = num3;
					num += num2;
					num3 += num2 + (float)(180 * (i + 1));
				}
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
		}

		public virtual void cb741f27373d4820430822ecabcd4f56b(int cd4ae0ac4cbfb1d9dc6c08d98a62730b4)
		{
			if (mcCrossHair == null)
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
				if (mcSelf == null)
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
				MovieClip childByName = mcCrossHair.getChildByName<MovieClip>("down");
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
					Matrix matrix = childByName.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = 0f;
					matrix.ty = cd4ae0ac4cbfb1d9dc6c08d98a62730b4;
					childByName.setMatrix(matrix);
					childByName.invalidateMatrix(true);
					childByName.rotation = -180f;
				}
				childByName = mcCrossHair.getChildByName<MovieClip>("up");
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
					Matrix matrix = childByName.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = 0f;
					matrix.ty = -cd4ae0ac4cbfb1d9dc6c08d98a62730b4;
					childByName.setMatrix(matrix);
					childByName.invalidateMatrix(true);
				}
				childByName = mcCrossHair.getChildByName<MovieClip>("left");
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
					Matrix matrix = childByName.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = -cd4ae0ac4cbfb1d9dc6c08d98a62730b4;
					matrix.ty = 0f;
					childByName.setMatrix(matrix);
					childByName.invalidateMatrix(true);
					childByName.rotation = 0f - _rightRotation;
				}
				childByName = mcCrossHair.getChildByName<MovieClip>("right");
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
					Matrix matrix = childByName.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = cd4ae0ac4cbfb1d9dc6c08d98a62730b4;
					matrix.ty = 0f;
					childByName.setMatrix(matrix);
					childByName.invalidateMatrix(true);
					childByName.rotation = _rightRotation;
					return;
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: CrossHairPanel Cross Hair MovieClip missing!!");
						return;
					}
				}
			}
			mcSelf.gotoAndStop("Spot");
			mcCrossHair = mcSelf.getChildByName("crossHair") as MovieClip;
		}

		private void c3460e53f63705e49d9fa898affdf06f1(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcSelf.removeEventListener(CEvent.ENTER_FRAME, c3460e53f63705e49d9fa898affdf06f1);
			mcCrossHair = mcSelf.getChildByName<MovieClip>("crossHair");
			if (mcCrossHair != null)
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
				mcCrossHair.gotoAndStop(_ColorFrameMap[_color]);
			}
			MovieClip childByName = mcSelf.getChildByName<MovieClip>("mc_elements");
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
				if (elementType != 0)
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
					if (elementType != AttackInfo.ElementalType.Max)
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
						if (elementType != AttackInfo.ElementalType.Explosive)
						{
							childByName.visible = true;
							childByName.gotoAndStop(elementType.ToString());
							return;
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
					}
				}
				childByName.visible = false;
				return;
			}
		}
	}

	private class EntityIconPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		protected DisplayObject mcForbid;

		protected MovieClip mcIcon;

		protected string _frame = string.Empty;

		protected string _strColor = string.Empty;

		protected bool _bForbid;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: EntityIconPanel MovieClip missing!!");
						return;
					}
				}
			}
			mcSelf.stop();
			mcRoot = mcSelf.getChildByName<MovieClip>("mcRoot");
			if (mcRoot == null)
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
				mcForbid = mcRoot.getChildByName("mcForbid") as MovieClip;
				return;
			}
		}

		private void cb858f4c907c42c1ea4be312cf85f7f91(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcRoot = mcSelf.getChildByName<MovieClip>("mcRoot");
			if (mcRoot == null)
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
				mcForbid = mcRoot.getChildByName("mcForbid") as MovieClip;
				if (mcForbid != null)
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
					mcForbid.visible = _bForbid;
				}
				mcRoot.addEventListener(CEvent.ENTER_FRAME, c2d8a1c6b34dac985193a5052b6d340fc);
				mcRoot.gotoAndStop(_frame);
				return;
			}
		}

		private void c2d8a1c6b34dac985193a5052b6d340fc(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcRoot.removeEventListener(CEvent.ENTER_FRAME, c2d8a1c6b34dac985193a5052b6d340fc);
			mcIcon = mcRoot.getChildByName("mcIcon") as MovieClip;
			if (mcIcon == null)
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
				mcIcon.gotoAndStop(_strColor);
				return;
			}
		}

		public void c61ff4a3a8c566e6321b3844189b6dfa8(string c70bca89991046fd211df3bb4c520d25f, bool c0ed1ae01e6d9fafe2906352a3dde6927, string c1fe468c3333face2b1ac9d1c55d68f42, string ccefb70d1c6517764559a52080e56d522 = "")
		{
			_frame = c70bca89991046fd211df3bb4c520d25f + ccefb70d1c6517764559a52080e56d522;
			_bForbid = c0ed1ae01e6d9fafe2906352a3dde6927;
			_strColor = c1fe468c3333face2b1ac9d1c55d68f42;
			mcRoot.gotoAndStop(_frame);
			mcSelf.addEventListener(CEvent.ENTER_FRAME, cb858f4c907c42c1ea4be312cf85f7f91);
			mcSelf.gotoAndPlay("IN");
		}

		public void c1b6dfffa2aeed0a61dd7747f6dd7eed7()
		{
			_frame = string.Empty;
			mcSelf.gotoAndStop("IN");
			mcSelf.removeAllEventListeners(CEvent.ENTER_FRAME);
		}
	}

	public class CardInfoMaker
	{
		protected MovieClip mcRoot;

		protected ItemDNA _showItem;

		protected ItemDNA _compareItem;

		protected virtual string c878d4164b90c3984e81f987922e217f5
		{
			get
			{
				return "none";
			}
		}

		public CardInfoMaker(ItemDNA cc88f070ce05a551e7c7982eb44e87ff3, ItemDNA cd7c0d36f2c73807ca9525013ef524075)
		{
			_showItem = cc88f070ce05a551e7c7982eb44e87ff3;
			_compareItem = cd7c0d36f2c73807ca9525013ef524075;
		}

		public virtual void cdb78bdb88116209c2e4d40eb159be6bd(MovieClip c91e2a905b28bfd2691cc9d1d958726ac)
		{
			mcRoot = c91e2a905b28bfd2691cc9d1d958726ac;
			if (mcRoot == null)
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
				if (mcRoot.currentLabel != c878d4164b90c3984e81f987922e217f5)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							mcRoot.gotoAndStop(c878d4164b90c3984e81f987922e217f5);
							mcRoot.addFrameScript(c878d4164b90c3984e81f987922e217f5, c77de347f5cc9efb7b4cb59c10d1fcbd9);
							return;
						}
					}
				}
				c39062807a45556a41c3a92303c3ea6b5();
				return;
			}
		}

		protected virtual void c39062807a45556a41c3a92303c3ea6b5()
		{
		}

		private void c77de347f5cc9efb7b4cb59c10d1fcbd9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcRoot.removeFrameScript(c878d4164b90c3984e81f987922e217f5, c77de347f5cc9efb7b4cb59c10d1fcbd9);
			c39062807a45556a41c3a92303c3ea6b5();
		}

		protected void caa5a58169efb0112cfd73130a3c987c0(UnityTextField c083d53c11a1797a6c79e396ef7fddf46, UnityTextField c00bef710db05fa49c5f91001344a8e81, string ce6a949c29a8d738b2d3b073d044ec56e)
		{
			if (c083d53c11a1797a6c79e396ef7fddf46 == null)
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
				if (c00bef710db05fa49c5f91001344a8e81 == null)
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
				bool visible;
				if (ce6a949c29a8d738b2d3b073d044ec56e == string.Empty)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							visible = (c00bef710db05fa49c5f91001344a8e81.visible = false);
							c083d53c11a1797a6c79e396ef7fddf46.visible = visible;
							return;
						}
					}
				}
				visible = (c00bef710db05fa49c5f91001344a8e81.visible = true);
				c083d53c11a1797a6c79e396ef7fddf46.visible = visible;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '$';
				string[] array2 = ce6a949c29a8d738b2d3b073d044ec56e.Split(array);
				if (array2[0] == "Red")
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							c083d53c11a1797a6c79e396ef7fddf46.visible = false;
							c00bef710db05fa49c5f91001344a8e81.c34fce3bccfffc6feb3579939c6d9a057 = UniUIManager.UniSWFToolClass.c086651c22e0343f3b0c0e7248aafc15f(array2[0]);
							c00bef710db05fa49c5f91001344a8e81.text = array2[1];
							return;
						}
					}
				}
				Color c34fce3bccfffc6feb3579939c6d9a = (c00bef710db05fa49c5f91001344a8e81.c34fce3bccfffc6feb3579939c6d9a057 = UniUIManager.UniSWFToolClass.c086651c22e0343f3b0c0e7248aafc15f(array2[0]));
				c083d53c11a1797a6c79e396ef7fddf46.c34fce3bccfffc6feb3579939c6d9a057 = c34fce3bccfffc6feb3579939c6d9a;
				c083d53c11a1797a6c79e396ef7fddf46.text = array2[1];
				c00bef710db05fa49c5f91001344a8e81.text = array2[2];
				return;
			}
		}
	}

	public class ItemCard3DPanel : ItemCardPanel
	{
		private float _fXOffset;

		private float _fYOffset;

		private float _fScale;

		public override void c58de56793cb96a279858c7b68a326d17(ItemDNA ca57e1c076c01141c5ce58c7341db7833, ItemDNA cd7c0d36f2c73807ca9525013ef524075)
		{
			base.c58de56793cb96a279858c7b68a326d17(ca57e1c076c01141c5ce58c7341db7833, cd7c0d36f2c73807ca9525013ef524075);
			ca37fcdce7d4937b60735f4033eb55695.visible = true;
		}

		public override void cd351226c5175db6eab2a3dd9ec9ff57c(MovieClip c59a247e42dc696f4409f74cfa6b6515b)
		{
			base.cd351226c5175db6eab2a3dd9ec9ff57c(c59a247e42dc696f4409f74cfa6b6515b);
			_fXOffset = c59a247e42dc696f4409f74cfa6b6515b.width / 2f;
			_fYOffset = c59a247e42dc696f4409f74cfa6b6515b.height / 3f;
		}

		public void c1b6dfffa2aeed0a61dd7747f6dd7eed7()
		{
			_showItem = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
			_compareItem = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
			ca37fcdce7d4937b60735f4033eb55695.visible = false;
		}

		public void c034936ede6b65db0da600e58eb5611d2(int c5ebdc65d5cb420faf7ba524809963aa9, int c9d16e16b57deb9bb1da907451ba1f25b)
		{
			if (ca37fcdce7d4937b60735f4033eb55695 == null)
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
				ca37fcdce7d4937b60735f4033eb55695.x = (float)c5ebdc65d5cb420faf7ba524809963aa9 - _fXOffset * _fScale;
				ca37fcdce7d4937b60735f4033eb55695.y = (float)c9d16e16b57deb9bb1da907451ba1f25b - _fYOffset * _fScale;
				return;
			}
		}

		public void ce0e89df2a24bb933ecdd599d103b2972(float c52653cd226edee69dc40caf0157e2a97)
		{
			float num = c52653cd226edee69dc40caf0157e2a97;
			ca37fcdce7d4937b60735f4033eb55695.scaleY = num;
			num = num;
			ca37fcdce7d4937b60735f4033eb55695.scaleX = num;
			_fScale = num;
		}
	}

	private class ExpDownPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected const string WORD_XP = "xp";

		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		protected MovieClip mcExp;

		protected MovieClip mcExpCover;

		protected TextField tfValue;

		protected TextField tfValueCover;

		protected bool _bVisible;

		protected int _iExp;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: ExpDownPanel MovieClip missing!!");
						return;
					}
				}
			}
			mcSelf.visible = false;
			mcSelf.stop();
			mcRoot = mcSelf.getChildByName<MovieClip>("mcRoot");
			if (mcRoot == null)
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
				mcRoot.stop();
				mcExp = mcRoot.getChildByName("mcExp") as MovieClip;
				if (mcExp != null)
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
					tfValue = mcExp.getChildByName<TextField>("textField");
				}
				mcExpCover = mcRoot.getChildByName("mcExpCover") as MovieClip;
				if (mcExpCover != null)
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
					tfValueCover = mcExpCover.getChildByName<TextField>("textField");
				}
				mcRoot.addFrameScript("end", cac82e8c496f294f2b6dc0f455295de86);
				return;
			}
		}

		public virtual void c0c96ef86c800567bc44df5110bcc5c48(int cbaddf7257702172b936cbef73bc586ff)
		{
			_iExp = cbaddf7257702172b936cbef73bc586ff;
			mcExp = mcRoot.getChildByName("mcExp") as MovieClip;
			if (mcExp != null)
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
				tfValue = mcExp.getChildByName<TextField>("textField");
				if (tfValue != null)
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
					tfValue.text = cbaddf7257702172b936cbef73bc586ff + "xp";
				}
			}
			mcExpCover = mcRoot.getChildByName("mcExpCover") as MovieClip;
			if (mcExpCover != null)
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
				tfValueCover = mcExpCover.getChildByName<TextField>("textField");
				if (tfValueCover != null)
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
					tfValueCover.text = cbaddf7257702172b936cbef73bc586ff + "xp";
				}
			}
			mcRoot.gotoAndPlay("start");
			mcRoot.addEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
			mcSelf.visible = true;
		}

		private void c77de347f5cc9efb7b4cb59c10d1fcbd9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcExp = mcRoot.getChildByName("mcExp") as MovieClip;
			if (mcExp != null)
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
				tfValue = mcExp.getChildByName<TextField>("textField");
				if (tfValue != null)
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
					tfValue.text = _iExp + "xp";
				}
			}
			mcExpCover = mcRoot.getChildByName("mcExpCover") as MovieClip;
			if (mcExpCover == null)
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
				tfValueCover = mcExpCover.getChildByName<TextField>("textField");
				if (tfValueCover == null)
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
					tfValueCover.text = _iExp + "xp";
					return;
				}
			}
		}

		private void cac82e8c496f294f2b6dc0f455295de86(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcSelf.visible = false;
			mcRoot.removeEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _rootPanel;

	private ETipsPanel _eTipsPanel;

	private CrossHairPanel _crossHairPanel;

	private MaskPanel _maskPanel;

	private CoatingPanel _coatingPanel;

	private AIInfoPanel _aiPanel;

	private EntityIconPanel _iconPanel;

	private ItemCard3DPanel _itemPanel;

	private ExpDownPanel _expPanel;

	private BossHudPanel _bossPanel;

	private BadassAIInfoPanel _badassAIPanel;

	private float MAGIC_VALUE = 16.744186f;

	private Dictionary<WeaponType, string> WEAPON_FRAME_MAP;

	private MovieClipBehaviour _mcbIcon;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map15;

	public uniHUDAimTargetView()
	{
		WEAPON_FRAME_MAP = new Dictionary<WeaponType, string>();
		WEAPON_FRAME_MAP.Add(WeaponType.ShotGun, "shotgun_");
		WEAPON_FRAME_MAP.Add(WeaponType.SMG, "SMG_");
		WEAPON_FRAME_MAP.Add(WeaponType.SniperRifle, "Sniper_");
		WEAPON_FRAME_MAP.Add(WeaponType.RepeaterPistol, "Pistol_");
		WEAPON_FRAME_MAP.Add(WeaponType.CombatRifle, "SMG_");
		WEAPON_FRAME_MAP.Add(WeaponType.TOTAL, "Spot");
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Tips.swf", "Panel_Tips_Card", ccc880559f3152cad09b3f27f7d43cbf7);
		BadAssMovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c = new BadAssMovieClip("SightBead.swf", "ScreenPanel");
		BadAssMovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c2 = new BadAssMovieClip("SightBead.swf", "Panel_BossHud");
		c0735a4018274337fb4ff5a4d1f1f2e1d(cbe9ca8ddb3cdc2312e6ff8411b2db2c);
		c9cbcfe9b145b1e68ce64d5ed2e26eb68(cbe9ca8ddb3cdc2312e6ff8411b2db2c2);
		cf737b86795a7a0392facdf826a0abf09();
	}

	private void ccc880559f3152cad09b3f27f7d43cbf7(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		float c5ebdc65d5cb420faf7ba524809963aa = 0f;
		float c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		MovieClip movieClip = new MovieClip();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c24a0f2b5695dcd950edb79b1830693f9(out c5ebdc65d5cb420faf7ba524809963aa, out c9d16e16b57deb9bb1da907451ba1f25b);
		movieClip.x = c5ebdc65d5cb420faf7ba524809963aa;
		movieClip.y = c9d16e16b57deb9bb1da907451ba1f25b;
		movieClip.visible = false;
		_itemPanel = new ItemCard3DPanel();
		_itemPanel.c130648b59a0c8debea60aa153f844879(movieClip);
		_itemPanel.cd351226c5175db6eab2a3dd9ec9ff57c(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c561fe037bc737c4c5c91e0ed62eb07b7(_itemPanel);
	}

	private void c0735a4018274337fb4ff5a4d1f1f2e1d(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		float c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		float c5ebdc65d5cb420faf7ba524809963aa;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c24a0f2b5695dcd950edb79b1830693f9(out c5ebdc65d5cb420faf7ba524809963aa, out c9d16e16b57deb9bb1da907451ba1f25b);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.x = c5ebdc65d5cb420faf7ba524809963aa;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.y = c9d16e16b57deb9bb1da907451ba1f25b;
		_rootPanel = new c196099a1254db61d3be10d70e14e7422();
		_rootPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_rootPanel);
	}

	private void c9cbcfe9b145b1e68ce64d5ed2e26eb68(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		float c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		float c5ebdc65d5cb420faf7ba524809963aa;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c24a0f2b5695dcd950edb79b1830693f9(out c5ebdc65d5cb420faf7ba524809963aa, out c9d16e16b57deb9bb1da907451ba1f25b);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.x = c5ebdc65d5cb420faf7ba524809963aa;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.y = c9d16e16b57deb9bb1da907451ba1f25b;
		_bossPanel = new BossHudPanel();
		_bossPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_bossPanel);
		_bossPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_itemPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_bossPanel);
		cfda78d63001fa69d57b84b09673ea0e8();
		_itemPanel = null;
		_eTipsPanel = c63393689f1717210774504a294433ab8.c7088de59e49f7108f520cf7e0bae167e;
		_crossHairPanel = null;
		_maskPanel = null;
		_rootPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		_bossPanel = null;
		_badassAIPanel = null;
		_coatingPanel = null;
		MaskManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Tips.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("SightBead.swf");
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (_003C_003Ef__switch_0024map15 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(7);
				dictionary.Add("mcETips", 0);
				dictionary.Add("mcCrossHair", 1);
				dictionary.Add("mcMask", 2);
				dictionary.Add("mcCoating", 3);
				dictionary.Add("mcAIInfo", 4);
				dictionary.Add("mcExpDown", 5);
				dictionary.Add("panelBadass", 6);
				_003C_003Ef__switch_0024map15 = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024map15.TryGetValue(name, out value))
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
					_eTipsPanel = new ETipsPanel();
					_eTipsPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 1:
					_crossHairPanel = new CrossHairPanel();
					_crossHairPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 2:
					movieClip.visible = false;
					movieClip.stop();
					_maskPanel = new MaskPanel();
					_maskPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 3:
					movieClip.visible = false;
					movieClip.stop();
					_coatingPanel = new CoatingPanel();
					_coatingPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 4:
					movieClip.visible = false;
					movieClip.stop();
					_aiPanel = new AIInfoPanel();
					_aiPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 5:
					movieClip.visible = false;
					movieClip.stop();
					_expPanel = new ExpDownPanel();
					_expPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 6:
					movieClip.visible = false;
					movieClip.stop();
					_badassAIPanel = new BadassAIInfoPanel();
					_badassAIPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public override void c565fc8fc4a259a71ab4632066f71f0ea(E_USE_TYPE c2b4f43f34e21572af6ab4414f04cee36)
	{
		base.c565fc8fc4a259a71ab4632066f71f0ea(c2b4f43f34e21572af6ab4414f04cee36);
		if (_eTipsPanel == null)
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
		if (c2b4f43f34e21572af6ab4414f04cee36 == E_USE_TYPE.E_NONE)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					_eTipsPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
					return;
				}
			}
		}
		_eTipsPanel.c607978cd1d85e01c73ba93a33624bc38((int)_curType);
		_eTipsPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
	}

	public override void c5c6d9b37e66c45c8c7187665713ece00(E_SCOPE_TYPE cf7c8dfabbc57dfde03eb82fbfba3b0f6 = E_SCOPE_TYPE.E_NORMAL)
	{
		bool flag = _eAimMode != cf7c8dfabbc57dfde03eb82fbfba3b0f6;
		base.c5c6d9b37e66c45c8c7187665713ece00(cf7c8dfabbc57dfde03eb82fbfba3b0f6);
		if (!flag)
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
			ca0bcc5c54701ac796ed2e6b174818448();
			return;
		}
	}

	public override void c33d552efca40d63443e0a504daea3912(float c52921fe9488ee3d539be727c81094423, float c08627fb03567104b28523ad64354582e = float.MaxValue)
	{
		_fCrossHairAccurate = c52921fe9488ee3d539be727c81094423;
		_fScopeCrossHairAccurate = c08627fb03567104b28523ad64354582e;
		if (_crossHairPanel == null)
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
			Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
			if (c91fcf132a3585bad3597263bc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				MAGIC_VALUE = 720f / c91fcf132a3585bad3597263bc.fieldOfView;
			}
			int cd4ae0ac4cbfb1d9dc6c08d98a62730b = Mathf.CeilToInt(_fCrossHairAccurate * MAGIC_VALUE);
			int cd4ae0ac4cbfb1d9dc6c08d98a62730b2 = Mathf.CeilToInt(_fScopeCrossHairAccurate * MAGIC_VALUE);
			_crossHairPanel.cb741f27373d4820430822ecabcd4f56b(cd4ae0ac4cbfb1d9dc6c08d98a62730b);
			_crossHairPanel.ce9f69ed78b52af94d7d66afb3ba803e7(cd4ae0ac4cbfb1d9dc6c08d98a62730b2);
			return;
		}
	}

	public override void cd2e48af5036f9af603d95eb723ef7beb(EntityNpc c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (_bossPanel == null)
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
			_bossPanel.cd2e48af5036f9af603d95eb723ef7beb(c5d720f6d007abb0c4a21d6a654e405bb);
			return;
		}
	}

	public override void c49129feb5dd2a9881cc3a462a98d59b7()
	{
		if (_bossPanel == null)
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
			if (_bossPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_bossPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
				return;
			}
		}
	}

	public override void cfa5c65236b46d49f65e56ec12a03c489()
	{
		if (_bossPanel == null)
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
			if (!_bossPanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_bossPanel.c649543487911247490016f844cdd8ca4();
				_bossPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}
	}

	public override void cf5386f91e44d079b4719a30812cbf941(int cd6bb591c33b2ee3ab93e98aa43a6da63, string cd99af21e22e356018b8f72d4a7e4872a)
	{
		if (_bossPanel == null)
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
			_bossPanel.cc65a6852af6fc5b9fc0cb6a7fa951de2(cd6bb591c33b2ee3ab93e98aa43a6da63, cd99af21e22e356018b8f72d4a7e4872a);
			return;
		}
	}

	public override void cf8c79459ba37498d40bc2aad6dc9c03a(int ca9418d63b770eac102bfc9f4297a1066, int ca4ca4714d7c458ac40f3dadb7f670c6e, int c0bb32bee3cf6dd96e41e00dc5a4ae21a, int ce9468aa2dd2bd99d09db5f068744c509)
	{
	}

	public override void cd20042520dda2fb118d7aa058174cd2f(Entity c1b673d88dc2361383429c174b464e388, bool cd2cb6285cd9f694f5fec76ed066610af = false)
	{
		bool flag = _aimedEntity != c1b673d88dc2361383429c174b464e388;
		if (_bAimed)
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
			if (_aimedEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				flag = true;
			}
		}
		base.cd20042520dda2fb118d7aa058174cd2f(c1b673d88dc2361383429c174b464e388, cd2cb6285cd9f694f5fec76ed066610af);
		if (c1b673d88dc2361383429c174b464e388 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityDestoryableObj entityDestoryableObj = c1b673d88dc2361383429c174b464e388 as EntityDestoryableObj;
			if (entityDestoryableObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (entityDestoryableObj.m_bHideUI)
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
			bool flag2 = false;
			bool flag3 = false;
			if (c1b673d88dc2361383429c174b464e388.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Npc)
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
				EntityNpc entityNpc = c1b673d88dc2361383429c174b464e388 as EntityNpc;
				if (entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					flag2 = entityNpc.c90ea3a207cd50bba4ba7c81b9ff2bcb5();
					flag3 = entityNpc.m_npcFamilly == EntityNpc.EntityNpcFamilly.Tutor;
				}
			}
			if (!flag2)
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
				AIInfoPanel aIInfoPanel = null;
				if (_aimedEntity is EntityNpc)
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
					EntityNpc entityNpc2 = _aimedEntity as EntityNpc;
					if (entityNpc2.cb3c049644818b9981f10871585889e97())
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
						aIInfoPanel = _badassAIPanel;
					}
					else
					{
						aIInfoPanel = _aiPanel;
					}
				}
				else
				{
					aIInfoPanel = _aiPanel;
				}
				if (aIInfoPanel != null)
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
					if (!aIInfoPanel.c150264a18c2cb408479d3f072cac8cc1)
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
						aIInfoPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
					}
					string ceb41162a7cd2a1d5c4a03830e02b = string.Empty;
					if (_aimedEntity is EntityPlayer)
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
						EntityPlayer entityPlayer = _aimedEntity as EntityPlayer;
						if (entityPlayer.ceb10167333758220ffb9bc66317ad763() == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_teamID)
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
							aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("GREEN");
						}
						else
						{
							aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("RED");
						}
					}
					else if (flag3)
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
						aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("GREEN");
					}
					else if (_aimedEntity is EntityNpcSoldierTurret)
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
						EntityNpcSoldierTurret entityNpcSoldierTurret = _aimedEntity as EntityNpcSoldierTurret;
						ceb41162a7cd2a1d5c4a03830e02b = entityNpcSoldierTurret.c5a054719a5eca237f11fd9762d98ca82();
						if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(entityNpcSoldierTurret.m_relatedPlayer.ca15c8f7004fafacb3955a523d9a1cec9()))
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
							aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("GREEN");
						}
						else
						{
							PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
							if (playerInfoSync.m_characterId == entityNpcSoldierTurret.m_relatedPlayer.ca15c8f7004fafacb3955a523d9a1cec9())
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
								aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("GREEN");
							}
							else
							{
								aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("RED");
							}
						}
					}
					else
					{
						WeakPoint c38b98045365f4b50a4fbe3f1d89af = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
						_aimedEntity.c659e11237d268aac8b68c419cf6b053a(out c38b98045365f4b50a4fbe3f1d89af);
						if (c38b98045365f4b50a4fbe3f1d89af.m_matterType == WeakPoint.MatterType.Armor)
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
							aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("YELLOW");
						}
						else
						{
							aIInfoPanel.c8123b0a5b1c5404d55df72e727311132("RED");
						}
					}
					aIInfoPanel.cab478a9dbd639cc459c21d4e2b0bd54c(_aimedEntity.ca2ff7a501878363cb1d5f0472e306620(), _aimedEntity.ccfad1bf47b003333c5ddd084f14d33e7());
					aIInfoPanel.cb8ad26e2e2615a2600329d5cd8a5b93b(_aimedEntity.ce7804365a7377021025c46a16aa79db4(), _aimedEntity.ca937003ba4cbf4130cad1fcc9da2873e());
					aIInfoPanel.ce60a543a0ad48212151c9336288092c1(_aimedEntity.c7513e66c4e0fc55e6fea9dd9cb8b9943(), _aimedEntity.ca6bcee369aa6d4cdf126ebaeef6f6c73(), ceb41162a7cd2a1d5c4a03830e02b);
					aIInfoPanel.c7dcafa368362314dcd96f62f010b3dd8(_aimedEntity);
				}
			}
			else
			{
				WeakPoint component = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedCollider.gameObject.GetComponent<WeakPoint>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (component.cf3d09e30f1d1bc489a1c3a97d696dbe2())
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
						if (component.m_matterType == WeakPoint.MatterType.Armor)
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
							_aiPanel.c8123b0a5b1c5404d55df72e727311132("YELLOW");
						}
						else
						{
							_aiPanel.c8123b0a5b1c5404d55df72e727311132("RED");
						}
						EquipmentInventoryEntityNpcBoss equipmentInventoryEntityNpcBoss = _aimedEntity.c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityNpcBoss;
						if (equipmentInventoryEntityNpcBoss != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (_aiPanel != null)
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
								if (!_aiPanel.c150264a18c2cb408479d3f072cac8cc1)
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
									_aiPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
								}
								_aiPanel.cab478a9dbd639cc459c21d4e2b0bd54c(equipmentInventoryEntityNpcBoss.c0e018ed0ee4ac2592fafd36d256cd617(component), equipmentInventoryEntityNpcBoss.ccfad1bf47b003333c5ddd084f14d33e7(component));
								_aiPanel.cb8ad26e2e2615a2600329d5cd8a5b93b(0, 100, false);
								_aiPanel.ce60a543a0ad48212151c9336288092c1(0, LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(component.m_partInfo.ToString())), string.Empty);
							}
						}
					}
				}
			}
		}
		else
		{
			if (_badassAIPanel != null)
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
				_badassAIPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
			}
			if (_aiPanel != null)
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
				_aiPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
			}
		}
		if (!flag)
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
			ca0bcc5c54701ac796ed2e6b174818448();
			return;
		}
	}

	public override void cda9735eb2b55d94b17b1b29402d92fb0(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		bool flag = _weaponType != c27b7430edc94b8f5b543605119ec4a72;
		base.cda9735eb2b55d94b17b1b29402d92fb0(c27b7430edc94b8f5b543605119ec4a72);
		if (!flag)
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
			ca0bcc5c54701ac796ed2e6b174818448();
			return;
		}
	}

	private void ca0bcc5c54701ac796ed2e6b174818448()
	{
		CROSS_HAIR_COLOR c2022f114954310f1130ded90da1fb8b = CROSS_HAIR_COLOR.WHITE;
		if (_aimedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!_isInSameTeam)
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
				c2022f114954310f1130ded90da1fb8b = CROSS_HAIR_COLOR.RED;
			}
		}
		if (_crossHairPanel == null)
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
			if (!WEAPON_FRAME_MAP.ContainsKey(_weaponType))
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
				DisplayObjectContainer c89ef242f4744e0f1c4ffea4da8b79bc = _coatingPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
				bool flag = _eAimMode != E_SCOPE_TYPE.E_NONE;
				_crossHairPanel.c150264a18c2cb408479d3f072cac8cc1 = flag;
				flag = flag;
				_maskPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = flag;
				c89ef242f4744e0f1c4ffea4da8b79bc.visible = flag;
				if (_eAimMode == E_SCOPE_TYPE.E_SNIPER)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							if (_weaponType == WeaponType.ShotGun)
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
								_crossHairPanel._rightRotation = 0f;
							}
							else
							{
								_crossHairPanel._rightRotation = 90f;
							}
							_crossHairPanel.c8e36274b37533d0e18e8717eb68d598e(_elementalType);
							_crossHairPanel.c03bdfe343bec46ff09b53cc0e1af2772(WEAPON_FRAME_MAP[_weaponType] + "scope_04", c2022f114954310f1130ded90da1fb8b, true);
							_maskPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
							_maskPanel.c6623ef8b23a16416be968b58cad3128e(_maskType.ToString());
							_coatingPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
							_coatingPanel.c6623ef8b23a16416be968b58cad3128e(_weaponType.ToString() + "_coating");
							return;
						}
					}
				}
				if (_eAimMode == E_SCOPE_TYPE.E_NORMAL)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							_crossHairPanel._rightRotation = 90f;
							_crossHairPanel.c03bdfe343bec46ff09b53cc0e1af2772(WEAPON_FRAME_MAP[_weaponType] + "regular", c2022f114954310f1130ded90da1fb8b);
							_maskPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
							_coatingPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
							return;
						}
					}
				}
				_crossHairPanel._rightRotation = 90f;
				_crossHairPanel.c03bdfe343bec46ff09b53cc0e1af2772(WEAPON_FRAME_MAP[WeaponType.TOTAL], c2022f114954310f1130ded90da1fb8b);
				_maskPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				_coatingPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				return;
			}
		}
	}

	protected override void c19f79f487937dbc8d71c8b454a0457aa()
	{
		if (_iconPanel != null)
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
			_iconPanel.c1b6dfffa2aeed0a61dd7747f6dd7eed7();
			_iconObject.SetActive(false);
		}
		if (_itemPanel == null)
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
			_itemPanel.c1b6dfffa2aeed0a61dd7747f6dd7eed7();
			return;
		}
	}

	protected override void c29226db8d29cd80b3b478968bad1c6ad()
	{
		base.c29226db8d29cd80b3b478968bad1c6ad();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_World_Use_Over");
		_itemPanel.c58de56793cb96a279858c7b68a326d17(_interactingItem.c4622c7a1660020e5029da03e27491b37(), _compareItem);
	}

	protected override void c9c30bd737ebcd34f4739e25847bb02b6(Vector3 cef9712200bbe2c3873eec3ca2e18a595, bool c0ed1ae01e6d9fafe2906352a3dde6927)
	{
		base.c9c30bd737ebcd34f4739e25847bb02b6(cef9712200bbe2c3873eec3ca2e18a595, c0ed1ae01e6d9fafe2906352a3dde6927);
		if (!(_iconObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_iconObject.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
			_iconObject.SetActive(true);
			_mcbIcon.billboardCamera = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
			string ccefb70d1c6517764559a52080e56d = string.Empty;
			switch (_interactingItem.c4622c7a1660020e5029da03e27491b37().m_type)
			{
			case ItemType.Weapon:
				ccefb70d1c6517764559a52080e56d = "_" + (_interactingItem as EntityWeapon).c83e548e5608cd7f222098a6966b16545();
				break;
			case ItemType.Ammo:
				ccefb70d1c6517764559a52080e56d = "_" + _interactingItem.c4622c7a1660020e5029da03e27491b37().m_ammoType;
				break;
			}
			string c1fe468c3333face2b1ac9d1c55d68f = Pickable.LightPillarManager.cfe28e3d50ddb29d6b1140e6eed1263bf(_interactingItem);
			_iconPanel.c61ff4a3a8c566e6321b3844189b6dfa8(_interactingItem.c4622c7a1660020e5029da03e27491b37().m_type.ToString(), c0ed1ae01e6d9fafe2906352a3dde6927, c1fe468c3333face2b1ac9d1c55d68f, ccefb70d1c6517764559a52080e56d);
			return;
		}
	}

	protected override void cdf9d64b8309c15ad1f048bdea5fb5520(Vector2 cef9712200bbe2c3873eec3ca2e18a595, float c52653cd226edee69dc40caf0157e2a97)
	{
		if (_itemPanel == null)
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
			_itemPanel.c034936ede6b65db0da600e58eb5611d2(Mathf.CeilToInt(cef9712200bbe2c3873eec3ca2e18a595.x / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12), Mathf.CeilToInt(cef9712200bbe2c3873eec3ca2e18a595.y / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12));
			_itemPanel.ce0e89df2a24bb933ecdd599d103b2972(c52653cd226edee69dc40caf0157e2a97);
			return;
		}
	}

	protected override void c94b5204c5fd60d429ba70c491ef9c7eb(int c4a37d36a3ef1e82fa8b2e1badb7fbfb5)
	{
		if (_expPanel == null)
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
			_expPanel.c0c96ef86c800567bc44df5110bcc5c48(c4a37d36a3ef1e82fa8b2e1badb7fbfb5);
			return;
		}
	}

	private void cf737b86795a7a0392facdf826a0abf09()
	{
		if (_iconObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_iconObject = UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("UI_uniSWF/EntityIcon")) as GameObject;
			_iconObject.name = "iconObject";
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c114035b255a7c79daf00b8613364145c(_iconObject);
		}
		_mcbIcon = _iconObject.GetComponent<MovieClipBehaviour>();
		if (_mcbIcon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_mcbIcon.billboard = true;
			_iconPanel = new EntityIconPanel();
			_iconPanel.c130648b59a0c8debea60aa153f844879(_mcbIcon.movieClip);
		}
		_iconObject.SetActive(false);
	}

	private void cfda78d63001fa69d57b84b09673ea0e8()
	{
		if (!(_iconObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			return;
		}
	}

	public override bool OnScreenResized()
	{
		float c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		float c5ebdc65d5cb420faf7ba524809963aa;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c24a0f2b5695dcd950edb79b1830693f9(out c5ebdc65d5cb420faf7ba524809963aa, out c9d16e16b57deb9bb1da907451ba1f25b);
		_rootPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = c5ebdc65d5cb420faf7ba524809963aa;
		_rootPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.y = c9d16e16b57deb9bb1da907451ba1f25b;
		return true;
	}
}
