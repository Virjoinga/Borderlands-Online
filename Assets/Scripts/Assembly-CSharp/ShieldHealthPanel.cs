using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;

public class ShieldHealthPanel : c196099a1254db61d3be10d70e14e7422
{
	protected MovieClip mcSelf;

	protected MovieClip mcHealthIcon;

	protected MovieClip mcHealthBar;

	protected MovieClip mcShieldBar;

	protected MovieClip mcCharacter;

	protected MovieClip mc_Captain;

	protected Dictionary<AvatarType, string> _dicFrameKeyTypeMap;

	protected string[] TYPR_FRAME_MAP;

	public bool bGreenWord { get; set; }

	public virtual bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			if (mcSelf != null)
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
				switch (7)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				mcSelf.visible = value;
				if (!value)
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
					GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c490e1cdbd91f441f8899c3b557cbc807();
					return;
				}
			}
		}
	}

	public ShieldHealthPanel()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = "none";
		array[1] = "full";
		array[2] = "open";
		array[3] = "smash";
		array[4] = "picked up";
		array[5] = "reload";
		TYPR_FRAME_MAP = array;
		base._002Ector();
		_dicFrameKeyTypeMap = new Dictionary<AvatarType, string>
		{
			{
				AvatarType.SIREN,
				"SIREN"
			},
			{
				AvatarType.SOLDIER,
				"SOLDIER"
			},
			{
				AvatarType.BERSERKER,
				"BERSERKER"
			},
			{
				AvatarType.HUNTER,
				"HUNTER"
			},
			{
				AvatarType.TOTAL,
				"SOLDIER"
			}
		};
	}

	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
		mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
		if (mcSelf == null)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
					return;
				}
			}
		}
		mcSelf.stop();
		mcHealthIcon = mcSelf.getChildByName<MovieClip>("health_icon");
		mcHealthBar = mcSelf.getChildByName<MovieClip>("health");
		mcShieldBar = mcSelf.getChildByName<MovieClip>("shield");
		if (mcHealthIcon != null)
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
			mcHealthIcon.stop();
		}
		if (mcHealthBar != null)
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
			mcHealthBar.addFrameScript(mcHealthBar.totalFrames, c532ff2c5d8bccc4d6c2fb3564bd051a6);
			MovieClip childByName = mcHealthBar.getChildByName<MovieClip>("flash");
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
		if (mcShieldBar != null)
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
			mcShieldBar.addFrameScript(mcShieldBar.totalFrames, c88c9e16a2f101aaed1818fbbdfd0b82a);
			MovieClip childByName2 = mcShieldBar.getChildByName<MovieClip>("flash");
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
				childByName2.stop();
			}
		}
		mc_Captain = mcSelf.getChildByName<MovieClip>("character");
	}

	public void cab478a9dbd639cc459c21d4e2b0bd54c(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		if (mcHealthBar == null)
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
			mcHealthBar.gotoAndStop(101);
		}
		else
		{
			int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
			mcHealthBar.gotoAndStop(101 - num);
		}
		UnityTextField childByName = mcHealthBar.getChildByName<UnityTextField>("health_disp");
		if (childByName == null)
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
			childByName.text = ca78de5e2084d6b058e6ebdc8e85d7fae.ToString();
			if (!bGreenWord)
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
				childByName.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
				return;
			}
		}
	}

	public void cb8ad26e2e2615a2600329d5cd8a5b93b(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		if (mcShieldBar == null)
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
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			mcShieldBar.gotoAndStop(101);
		}
		else
		{
			int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
			mcShieldBar.gotoAndStop(101 - num);
		}
		UnityTextField childByName = mcShieldBar.getChildByName<UnityTextField>("shield_disp");
		if (childByName == null)
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
			childByName.text = ca78de5e2084d6b058e6ebdc8e85d7fae.ToString();
			if (!bGreenWord)
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
				childByName.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
				return;
			}
		}
	}

	public void c8a7bf734d0261ddea2b853ec9c8c88ec(AvatarType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (mcCharacter == null)
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
			mcCharacter.gotoAndStop(_dicFrameKeyTypeMap[c2b4f43f34e21572af6ab4414f04cee36]);
			return;
		}
	}

	public void c490e1cdbd91f441f8899c3b557cbc807(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		if (mc_Captain == null)
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
			if (mc_Captain.visible == c74232243aff1dcbf2e8fc243633bb51a)
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
				mc_Captain.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}
	}

	private void c532ff2c5d8bccc4d6c2fb3564bd051a6(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = mcHealthBar.getChildByName<MovieClip>("flash");
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
			childByName.gotoAndPlay("go");
			return;
		}
	}

	private void c88c9e16a2f101aaed1818fbbdfd0b82a(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = mcShieldBar.getChildByName<MovieClip>("flash");
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
			childByName.gotoAndPlay("go");
			return;
		}
	}
}
