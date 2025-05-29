using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using pumpkin.display;
using pumpkin.events;

public class uniTownHUDView : TownHUDView
{
	private class TownCrossHairPanel : uniHUDAimTargetView.CrossHairPanel
	{
		public override void c03bdfe343bec46ff09b53cc0e1af2772(string cd99af21e22e356018b8f72d4a7e4872a, uniHUDAimTargetView.CROSS_HAIR_COLOR c2022f114954310f1130ded90da1fb8b7, bool cd7aa5b04df11f2bf644abbd5d2841766 = false)
		{
			_bScopeMode = cd7aa5b04df11f2bf644abbd5d2841766;
			_color = c2022f114954310f1130ded90da1fb8b7;
			if (mcSelf == null)
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
				mcSelf.gotoAndStop(cd99af21e22e356018b8f72d4a7e4872a);
				mcSelf.addEventListener(CEvent.ENTER_FRAME, c6f9518b766a0835e47b6c1cf108fce74);
				return;
			}
		}

		protected void c6f9518b766a0835e47b6c1cf108fce74(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcSelf.removeEventListener(CEvent.ENTER_FRAME, c6f9518b766a0835e47b6c1cf108fce74);
			mcCrossHair = mcSelf.getChildByName<MovieClip>("crossHair");
			if (mcCrossHair == null)
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
				mcCrossHair.addFrameScript("green", c11499c9a8f1a72592da363a4d1122eb8);
				mcCrossHair.gotoAndStop(_ColorFrameMap[_color]);
				return;
			}
		}

		protected void c11499c9a8f1a72592da363a4d1122eb8(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcCrossHair.removeFrameScript("green", c11499c9a8f1a72592da363a4d1122eb8);
			MovieClip childByName = mcCrossHair.getChildByName<MovieClip>("down");
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
				childByName.gotoAndPlay(1);
			}
			childByName = mcCrossHair.getChildByName<MovieClip>("up");
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
				childByName.gotoAndPlay(1);
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
				childByName.gotoAndPlay(1);
			}
			childByName = mcCrossHair.getChildByName<MovieClip>("right");
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
				childByName.gotoAndPlay(1);
				return;
			}
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _rootPanel;

	private ETipsPanel _eTipsPanel;

	private TownCrossHairPanel _crossHairPanel;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map2C;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("TownSightBead.swf", "TownScreen", c0735a4018274337fb4ff5a4d1f1f2e1d);
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

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		_eTipsPanel = c63393689f1717210774504a294433ab8.c7088de59e49f7108f520cf7e0bae167e;
		_crossHairPanel = null;
		_rootPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("TownSightBead.swf");
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024map2C == null)
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
				dictionary.Add("mcETips", 0);
				dictionary.Add("mcCrossHair", 1);
				_003C_003Ef__switch_0024map2C = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024map2C.TryGetValue(name, out value))
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
						switch (5)
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
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					else
					{
						_crossHairPanel = new TownCrossHairPanel();
						_crossHairPanel.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
					}
				}
				else
				{
					_eTipsPanel = new ETipsPanel();
					_eTipsPanel.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
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
		if (c2b4f43f34e21572af6ab4414f04cee36 == E_USE_TYPE.E_NONE)
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
			_eTipsPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		}
		else
		{
			_eTipsPanel.c607978cd1d85e01c73ba93a33624bc38((int)_curType);
			_eTipsPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
		}
		ca0bcc5c54701ac796ed2e6b174818448();
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (_rootPanel == null)
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
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		_rootPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _bVisible;
	}

	private void ca0bcc5c54701ac796ed2e6b174818448()
	{
		uniHUDAimTargetView.CROSS_HAIR_COLOR c2022f114954310f1130ded90da1fb8b;
		if (_curType != E_USE_TYPE.E_TALK)
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
			if (_curType != E_USE_TYPE.E_OPEN)
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
				if (_curType != E_USE_TYPE.E_PICKUP)
				{
					c2022f114954310f1130ded90da1fb8b = uniHUDAimTargetView.CROSS_HAIR_COLOR.WHITE;
					goto IL_0048;
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
		c2022f114954310f1130ded90da1fb8b = uniHUDAimTargetView.CROSS_HAIR_COLOR.GREEN;
		goto IL_0048;
		IL_0048:
		if (_crossHairPanel == null)
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
			_crossHairPanel.c03bdfe343bec46ff09b53cc0e1af2772("Town_Cross", c2022f114954310f1130ded90da1fb8b);
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
