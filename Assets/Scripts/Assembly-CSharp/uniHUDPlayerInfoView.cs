using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDPlayerInfoView : HUDPlayerInfoView
{
	private class AmmoPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected MovieClip mcBulletIcon;

		protected MovieClip mcBulletBar;

		protected TextField tfBulletText;

		protected TextField tfMaxBulletText;

		protected MovieClip mcGrenadeIcon;

		protected MovieClip mcGrenadeBar;

		protected TextField tfGrenadeText;

		protected TextField tfMaxGrenadeText;

		protected Dictionary<WeaponType, string> WEAPONTYPE_FRAME_MAP;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf != null)
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

		public AmmoPanel()
		{
			WEAPONTYPE_FRAME_MAP = new Dictionary<WeaponType, string>();
			WEAPONTYPE_FRAME_MAP.Add(WeaponType.SniperRifle, "sniper");
			WEAPONTYPE_FRAME_MAP.Add(WeaponType.ShotGun, "shotgun");
			WEAPONTYPE_FRAME_MAP.Add(WeaponType.SMG, "smg");
			WEAPONTYPE_FRAME_MAP.Add(WeaponType.RepeaterPistol, "repeater");
			WEAPONTYPE_FRAME_MAP.Add(WeaponType.CombatRifle, "smg");
			WEAPONTYPE_FRAME_MAP.Add(WeaponType.TOTAL, "none");
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
						return;
					}
				}
			}
			mcSelf.stop();
			mcBulletIcon = mcSelf.getChildByName<MovieClip>("bullet_icon");
			mcBulletBar = mcSelf.getChildByName<MovieClip>("bullets");
			tfBulletText = mcSelf.getChildByName<TextField>("bullet_c");
			tfMaxBulletText = mcSelf.getChildByName<TextField>("bullet_m");
			mcGrenadeIcon = mcSelf.getChildByName<MovieClip>("grenade_icon");
			mcGrenadeBar = mcSelf.getChildByName<MovieClip>("grenades");
			tfGrenadeText = mcSelf.getChildByName<TextField>("grenade_c");
			tfMaxGrenadeText = mcSelf.getChildByName<TextField>("grenade_m");
			if (mcBulletIcon != null)
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
				mcBulletIcon.stop();
			}
			if (mcBulletBar != null)
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
				mcBulletBar.stop();
				mcBulletBar.addFrameScript(mcBulletBar.totalFrames, c8342ddb0584302f3d5860ce1a673a815);
				MovieClip childByName = mcBulletBar.getChildByName<MovieClip>("flash");
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
					childByName.stop();
				}
			}
			if (tfBulletText != null)
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
				tfBulletText.text = string.Empty;
			}
			if (tfMaxBulletText != null)
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
				tfMaxBulletText.text = string.Empty;
			}
			if (mcGrenadeIcon != null)
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
				mcGrenadeIcon.stop();
			}
			if (mcGrenadeBar != null)
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
				mcGrenadeBar.stop();
			}
			if (tfGrenadeText != null)
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
				tfGrenadeText.text = string.Empty;
			}
			if (tfMaxGrenadeText == null)
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
				tfMaxGrenadeText.text = string.Empty;
				return;
			}
		}

		public void c2337dfb3a86d4a9321040610b3b17aa4(int ca78de5e2084d6b058e6ebdc8e85d7fae, int cd6c1d47c8a2cec3796fb541deb86e312, int c6c65a33e62768daae81c67db16e9f118)
		{
			if (mcBulletBar != null)
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
				if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
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
					mcBulletBar.gotoAndStop(100);
				}
				else
				{
					int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)cd6c1d47c8a2cec3796fb541deb86e312);
					mcBulletBar.gotoAndStop(101 - num);
				}
			}
			if (tfBulletText != null)
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
				tfBulletText.text = ca78de5e2084d6b058e6ebdc8e85d7fae.ToString();
			}
			if (tfMaxBulletText == null)
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
				tfMaxBulletText.text = c6c65a33e62768daae81c67db16e9f118.ToString();
				return;
			}
		}

		public void cad9e68ac3a70b4fac949454d0c960180(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
		{
			if (mcGrenadeBar != null)
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
				if (ca78de5e2084d6b058e6ebdc8e85d7fae == 0)
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
					mcGrenadeBar.gotoAndStop(100);
				}
				else
				{
					int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
					mcGrenadeBar.gotoAndStop(101 - num);
				}
			}
			if (tfGrenadeText != null)
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
				tfGrenadeText.text = ca78de5e2084d6b058e6ebdc8e85d7fae.ToString();
			}
			if (tfMaxGrenadeText == null)
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
				tfMaxGrenadeText.text = ce565b32ce48270d8a80781c7ab11cae6.ToString();
				return;
			}
		}

		public void c4347bc1a2bcf9e25f40ac189817a6764(WeaponType c2b4f43f34e21572af6ab4414f04cee36)
		{
			if (mcBulletIcon == null)
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
				mcBulletIcon.gotoAndStop(WEAPONTYPE_FRAME_MAP[c2b4f43f34e21572af6ab4414f04cee36]);
				return;
			}
		}

		private void c8342ddb0584302f3d5860ce1a673a815(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = mcBulletBar.getChildByName<MovieClip>("flash");
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				childByName.gotoAndPlay("go");
				return;
			}
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _rootPanel;

	private c196099a1254db61d3be10d70e14e7422 _rootCharPanel;

	private ShieldHealthPanel mcPlayerInfo;

	private AmmoPanel mcAmmoInfo;

	private ExpLevelPanel mcLevelInfo;

	private SmallWeaponCardPanel mcWeaponCard;

	private WeaponSlotPanel mcWeaponSlotPanel;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map6;

	public override bool bPVPDisp
	{
		get
		{
			return base.bPVPDisp;
		}
		set
		{
			base.bPVPDisp = value;
			if (mcPlayerInfo != null)
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
				mcPlayerInfo.bGreenWord = value;
			}
			if (mcLevelInfo == null)
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
				mcLevelInfo.bGreenWord = value;
				return;
			}
		}
	}

	public override void OnTestGUI()
	{
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("PlayerInfoBar.swf", "ScreenPanel", caad4f53a6c2abc4051c508b619a8a96e);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("HUD.swf", "ScreenPanel", c0735a4018274337fb4ff5a4d1f1f2e1d);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("HUD.swf", "Panel_WeaponSlot", cd8ecd1280a22dbbea9d7cbc62d02fc73);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Weapon_card.swf", "Panel_SimpleWeaponCard", cc139671fc499493f575387327ccbc7f3);
	}

	private void c0735a4018274337fb4ff5a4d1f1f2e1d(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_rootPanel = new c196099a1254db61d3be10d70e14e7422();
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.x = 0f;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.y = 0f;
		_rootPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_rootPanel);
	}

	private void caad4f53a6c2abc4051c508b619a8a96e(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_rootCharPanel = new c196099a1254db61d3be10d70e14e7422();
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.x = 0f;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.y = 0f;
		_rootCharPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_rootCharPanel);
	}

	private void cc139671fc499493f575387327ccbc7f3(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		mcWeaponCard = new SmallWeaponCardPanel();
		mcWeaponCard.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(mcWeaponCard);
	}

	private void cd8ecd1280a22dbbea9d7cbc62d02fc73(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		mcWeaponSlotPanel = new WeaponSlotPanel();
		mcWeaponSlotPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(mcWeaponSlotPanel);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootCharPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(mcWeaponCard);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(mcWeaponSlotPanel);
		mcPlayerInfo = c741762d7b2517e6899444b018d2cc6d5.c7088de59e49f7108f520cf7e0bae167e;
		mcAmmoInfo = null;
		_rootPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		_rootCharPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("PlayerInfoBar.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("HUD.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Weapon_card.swf");
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
			if (_003C_003Ef__switch_0024map6 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(3);
				dictionary.Add("mcPlayerInfo", 0);
				dictionary.Add("mcAmmo", 1);
				dictionary.Add("mcExp", 2);
				_003C_003Ef__switch_0024map6 = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024map6.TryGetValue(name, out value))
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
				switch (value)
				{
				case 0:
					mcPlayerInfo = new ShieldHealthPanel();
					mcPlayerInfo.c130648b59a0c8debea60aa153f844879(movieClip);
					if (mcPlayerInfo != null)
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
						mcPlayerInfo.bGreenWord = bPVPDisp;
						mcPlayerInfo.cb8ad26e2e2615a2600329d5cd8a5b93b(_iCurShield, _iMaxShield);
						mcPlayerInfo.cab478a9dbd639cc459c21d4e2b0bd54c(_iCurHealth, _iMaxHealth);
						mcPlayerInfo.c8a7bf734d0261ddea2b853ec9c8c88ec(_playerClass);
					}
					result = true;
					break;
				case 1:
				{
					mcAmmoInfo = new AmmoPanel();
					MovieClip childByName = movieClip.getChildByName<MovieClip>("mcFilterBaker");
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
						mcAmmoInfo.c130648b59a0c8debea60aa153f844879(childByName);
						if (mcAmmoInfo != null)
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
							mcAmmoInfo.c2337dfb3a86d4a9321040610b3b17aa4(_iCurBullets, _iClipBullets, _iMaxBullets);
							mcAmmoInfo.c4347bc1a2bcf9e25f40ac189817a6764(_curWeaponType);
							mcAmmoInfo.cad9e68ac3a70b4fac949454d0c960180(_iCurGrenades, _iMaxGrenades);
						}
					}
					result = true;
					break;
				}
				case 2:
					mcLevelInfo = new ExpLevelPanel();
					mcLevelInfo.c130648b59a0c8debea60aa153f844879(movieClip);
					if (mcLevelInfo != null)
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
						mcLevelInfo.bGreenWord = bPVPDisp;
						mcLevelInfo.cb973dc8f0b1d812e85e2c505b0659581(_iCurExp, _iMaxExp);
					}
					result = true;
					break;
				}
			}
		}
		return result;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_rootPanel != null)
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
			_rootPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c150264a18c2cb408479d3f072cac8cc1;
		}
		if (_rootCharPanel == null)
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
			_rootCharPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c150264a18c2cb408479d3f072cac8cc1;
			return;
		}
	}

	public override void c5939103e64f288dfce17db2fb4594432(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		int num;
		if (_iCurShield == ca78de5e2084d6b058e6ebdc8e85d7fae)
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
			num = ((_iMaxShield != ce565b32ce48270d8a80781c7ab11cae6) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool flag = (byte)num != 0;
		base.c5939103e64f288dfce17db2fb4594432(ca78de5e2084d6b058e6ebdc8e85d7fae, ce565b32ce48270d8a80781c7ab11cae6);
		if (!flag)
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
			if (mcPlayerInfo == null)
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
				mcPlayerInfo.cb8ad26e2e2615a2600329d5cd8a5b93b(_iCurShield, _iMaxShield);
				return;
			}
		}
	}

	public override void c24573231c964a8e1b6c359bcdc11ac2e(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		int num;
		if (_iCurHealth == ca78de5e2084d6b058e6ebdc8e85d7fae)
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
			num = ((_iMaxHealth != ce565b32ce48270d8a80781c7ab11cae6) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool flag = (byte)num != 0;
		base.c24573231c964a8e1b6c359bcdc11ac2e(ca78de5e2084d6b058e6ebdc8e85d7fae, ce565b32ce48270d8a80781c7ab11cae6);
		if (!flag)
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
			if (mcPlayerInfo == null)
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
				mcPlayerInfo.cab478a9dbd639cc459c21d4e2b0bd54c(_iCurHealth, _iMaxHealth);
				return;
			}
		}
	}

	public override void cf2a380a4692cc5676e8aa35a6ac96305(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		int num;
		if (_iCurExp == ca78de5e2084d6b058e6ebdc8e85d7fae)
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
			num = ((_iMaxExp != ce565b32ce48270d8a80781c7ab11cae6) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool flag = (byte)num != 0;
		base.cf2a380a4692cc5676e8aa35a6ac96305(ca78de5e2084d6b058e6ebdc8e85d7fae, ce565b32ce48270d8a80781c7ab11cae6);
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
			if (mcLevelInfo == null)
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
				mcLevelInfo.cb973dc8f0b1d812e85e2c505b0659581(_iCurExp, _iMaxExp);
				return;
			}
		}
	}

	public override void c20894ccb970fa2a20c47d5540f4bf0fe(int ca78de5e2084d6b058e6ebdc8e85d7fae, int cd6c1d47c8a2cec3796fb541deb86e312, int c6c65a33e62768daae81c67db16e9f118, WeaponType ccc3129646b2d42ec7517a480b9cf8c9b)
	{
		int num;
		if (_iCurBullets == ca78de5e2084d6b058e6ebdc8e85d7fae)
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
			if (_iMaxBullets == c6c65a33e62768daae81c67db16e9f118)
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
				num = ((_iClipBullets != cd6c1d47c8a2cec3796fb541deb86e312) ? 1 : 0);
				goto IL_003e;
			}
		}
		num = 1;
		goto IL_003e;
		IL_003e:
		bool flag = (byte)num != 0;
		bool flag2 = _curWeaponType != ccc3129646b2d42ec7517a480b9cf8c9b;
		base.c20894ccb970fa2a20c47d5540f4bf0fe(ca78de5e2084d6b058e6ebdc8e85d7fae, cd6c1d47c8a2cec3796fb541deb86e312, c6c65a33e62768daae81c67db16e9f118, ccc3129646b2d42ec7517a480b9cf8c9b);
		if (mcAmmoInfo == null)
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
			if (flag)
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
				mcAmmoInfo.c2337dfb3a86d4a9321040610b3b17aa4(_iCurBullets, _iClipBullets, _iMaxBullets);
			}
			if (!flag2)
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
				mcAmmoInfo.c4347bc1a2bcf9e25f40ac189817a6764(_curWeaponType);
				return;
			}
		}
	}

	public override void ce97bd49017579e3133b38884c053821f(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		int num;
		if (_iCurGrenades == ca78de5e2084d6b058e6ebdc8e85d7fae)
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
			num = ((_iMaxGrenades != ce565b32ce48270d8a80781c7ab11cae6) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool flag = (byte)num != 0;
		base.ce97bd49017579e3133b38884c053821f(ca78de5e2084d6b058e6ebdc8e85d7fae, ce565b32ce48270d8a80781c7ab11cae6);
		if (!flag)
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
			if (mcAmmoInfo == null)
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
				mcAmmoInfo.cad9e68ac3a70b4fac949454d0c960180(_iCurGrenades, _iMaxGrenades);
				return;
			}
		}
	}

	public override void cacb0973399bda5328a4e13f27d851fdb(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		base.cacb0973399bda5328a4e13f27d851fdb(cd6bb591c33b2ee3ab93e98aa43a6da63);
		if (_bActive)
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
			if (mcLevelInfo != null)
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
				mcLevelInfo.cacb0973399bda5328a4e13f27d851fdb(_iLevel);
			}
		}
		c703c5fded04cda53a7b6b36f5ca11a10.c5ee19dc8d4cccf5ae2de225410458b86.ceb41162a7cd2a1d5c4a03830e02b4198.c462fe1a64a37daab5e61f688d9a61e7f("Chr_Shr_LevelUp");
	}

	public override void c457db9cda354860a735321a344aa0ecf(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		base.c457db9cda354860a735321a344aa0ecf(cd99af21e22e356018b8f72d4a7e4872a);
		if (!_bActive)
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
			if (mcLevelInfo == null)
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
				mcLevelInfo.c0be25dad7f3b503064fc98b654b8c830(_iLevel, _strName);
				return;
			}
		}
	}

	public override void c722314920476b2c350e95cac25fa5871(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		base.c722314920476b2c350e95cac25fa5871(cd6bb591c33b2ee3ab93e98aa43a6da63);
		if (!_bActive)
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
			if (mcLevelInfo == null)
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
				mcLevelInfo.c0be25dad7f3b503064fc98b654b8c830(_iLevel, _strName);
				return;
			}
		}
	}

	public override void ce3841e95e779dd0c94cd831fe7d0b869(AvatarType cb5482a2a46b0f936c871f58108c762d2)
	{
		bool flag = _playerClass != cb5482a2a46b0f936c871f58108c762d2;
		base.ce3841e95e779dd0c94cd831fe7d0b869(cb5482a2a46b0f936c871f58108c762d2);
		if (!flag)
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
			if (mcPlayerInfo == null)
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
				mcPlayerInfo.c8a7bf734d0261ddea2b853ec9c8c88ec(cb5482a2a46b0f936c871f58108c762d2);
				return;
			}
		}
	}

	public override void c490e1cdbd91f441f8899c3b557cbc807(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		base.c490e1cdbd91f441f8899c3b557cbc807(c74232243aff1dcbf2e8fc243633bb51a);
		if (mcPlayerInfo == null)
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
			mcPlayerInfo.c490e1cdbd91f441f8899c3b557cbc807(c74232243aff1dcbf2e8fc243633bb51a);
			return;
		}
	}

	public override void c660501325b92420b182c10632cb9aa92(WeaponDNA c7ad992a76feafc31f8ad6e56516da24f, WeaponDNA cfe74b263a7818f4cb67012603360ce86)
	{
		base.c660501325b92420b182c10632cb9aa92(c7ad992a76feafc31f8ad6e56516da24f, cfe74b263a7818f4cb67012603360ce86);
		if (!_bActive)
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
			if (mcWeaponCard == null)
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
				mcWeaponCard.c58de56793cb96a279858c7b68a326d17(c7ad992a76feafc31f8ad6e56516da24f, cfe74b263a7818f4cb67012603360ce86);
				return;
			}
		}
	}

	public override void ca330dd5237a52ac8e99b440a78802ff6(bool c9385a8b4aa29165e7f6c6d3bfcf4c20b)
	{
		base.ca330dd5237a52ac8e99b440a78802ff6(c9385a8b4aa29165e7f6c6d3bfcf4c20b);
		if (!_bActive)
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
			if (mcWeaponSlotPanel == null)
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
				WeaponSlotPanel weaponSlotPanel = mcWeaponSlotPanel;
				int num;
				if (!c9385a8b4aa29165e7f6c6d3bfcf4c20b)
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
					num = (base.bAlwaysShowWeaponSlot ? 1 : 0);
				}
				else
				{
					num = 1;
				}
				weaponSlotPanel.c150264a18c2cb408479d3f072cac8cc1 = (byte)num != 0;
				mcWeaponSlotPanel.Update(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c7f019a4e8415dcf5133dea4fc25c9671, c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c8cf14f8e08f9993b9b0bbb7ad63e2a54);
				return;
			}
		}
	}
}
