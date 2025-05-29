using System;
using System.Text;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class ExpLevelPanel : c196099a1254db61d3be10d70e14e7422
{
	protected MovieClip mcSelf;

	protected MovieClip mcXPBar;

	protected MovieClip mcLevelUp;

	protected MovieClip mcLevelInfo;

	protected MovieClip mcLevelInfoLevel;

	protected int _iLevel;

	public virtual bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			if (mcSelf != null)
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
				switch (4)
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

	public bool bGreenWord { get; set; }

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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
					return;
				}
			}
		}
		mcSelf.stop();
		mcXPBar = mcSelf.getChildByName<MovieClip>("xpbar");
		mcLevelUp = mcSelf.getChildByName<MovieClip>("mcLevelUp");
		if (mcLevelUp != null)
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
			mcLevelUp.visible = false;
			mcLevelUp.stop();
			mcLevelUp.addFrameScript("end", c86b0ddea07c804c980f2bb3f6412263c);
		}
		if (mcXPBar == null)
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
			mcLevelInfo = mcXPBar.getChildByName<MovieClip>("levelInfo");
			mcLevelInfo.gotoAndStop("normal");
			mcLevelInfo.addFrameScript("end", c23db6a5a99a934078fea12198840a1e3);
			mcLevelInfoLevel = mcLevelInfo.getChildByName<MovieClip>("level");
			UnityTextField childByName = mcLevelInfoLevel.getChildByName<UnityTextField>("level");
			childByName.text = ccc4ecce2c9b3785a1919fd1febc2181e(_iLevel);
			if (!bGreenWord)
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
				childByName.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
				return;
			}
		}
	}

	protected void c86b0ddea07c804c980f2bb3f6412263c(CEvent cd729d94a5b443ac0f1b117450e5f4419)
	{
		mcLevelUp.visible = false;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mcLevelInfo.addEventListener(CEvent.ENTER_FRAME, cea77a9df422c45a19f1e559fea8c31c4);
			mcLevelInfo.gotoAndPlay("levelup");
			return;
		}
	}

	protected void c23db6a5a99a934078fea12198840a1e3(CEvent cd729d94a5b443ac0f1b117450e5f4419)
	{
		mcLevelInfo.removeAllEventListeners(CEvent.ENTER_FRAME);
		mcLevelInfo.gotoAndStop("normal");
		mcLevelInfoLevel = mcLevelInfo.getChildByName<MovieClip>("level");
		UnityTextField childByName = mcLevelInfoLevel.getChildByName<UnityTextField>("level");
		childByName.text = ccc4ecce2c9b3785a1919fd1febc2181e(_iLevel);
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			childByName.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
			return;
		}
	}

	private void cea77a9df422c45a19f1e559fea8c31c4(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (mcLevelInfo == null)
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
		MovieClip childByName = mcLevelInfo.getChildByName<MovieClip>("level");
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
			TextField childByName2 = childByName.getChildByName<TextField>("level");
			if (childByName2 != null)
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
				childByName2.text = ccc4ecce2c9b3785a1919fd1febc2181e(_iLevel);
			}
		}
		mcLevelInfoLevel = childByName;
		childByName = mcLevelInfo.getChildByName<MovieClip>("levelEffect");
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
			TextField childByName2 = childByName.getChildByName<TextField>("level");
			if (childByName2 == null)
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
				childByName2.text = ccc4ecce2c9b3785a1919fd1febc2181e(_iLevel);
				return;
			}
		}
	}

	public void cb973dc8f0b1d812e85e2c505b0659581(int ca78de5e2084d6b058e6ebdc8e85d7fae, int ce565b32ce48270d8a80781c7ab11cae6)
	{
		if (mcXPBar == null)
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
			int num = (int)Math.Ceiling(100.0 * (double)ca78de5e2084d6b058e6ebdc8e85d7fae / (double)ce565b32ce48270d8a80781c7ab11cae6);
			mcXPBar.gotoAndStop(num);
			return;
		}
	}

	public void c0be25dad7f3b503064fc98b654b8c830(int c2b01b9cb1d7aeff79a4a823499bdbb5f, string cd99af21e22e356018b8f72d4a7e4872a)
	{
		if (mcLevelInfo == null)
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
		mcLevelInfoLevel = mcLevelInfo.getChildByName<MovieClip>("level");
		if (mcLevelInfoLevel == null)
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
		UnityTextField childByName = mcLevelInfoLevel.getChildByName<UnityTextField>("level");
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
			if (!mcLevelUp.isPlaying)
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
				childByName.text = ccc4ecce2c9b3785a1919fd1febc2181e(c2b01b9cb1d7aeff79a4a823499bdbb5f);
				if (bGreenWord)
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
					childByName.c34fce3bccfffc6feb3579939c6d9a057 = Color.green;
				}
			}
		}
		childByName = mcXPBar.getChildByName<UnityTextField>("playername");
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
			childByName.text = cd99af21e22e356018b8f72d4a7e4872a;
			return;
		}
	}

	private string ccc4ecce2c9b3785a1919fd1febc2181e(int c2b01b9cb1d7aeff79a4a823499bdbb5f)
	{
		StringBuilder stringBuilder = new StringBuilder("Lv.");
		if (c2b01b9cb1d7aeff79a4a823499bdbb5f < 10)
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
			stringBuilder.Append("  ");
		}
		stringBuilder.Append(c2b01b9cb1d7aeff79a4a823499bdbb5f);
		return stringBuilder.ToString();
	}

	public void cacb0973399bda5328a4e13f27d851fdb(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		_iLevel = cd6bb591c33b2ee3ab93e98aa43a6da63;
		if (mcLevelUp != null)
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
			mcLevelUp.visible = true;
			mcLevelUp.gotoAndPlay("start");
		}
		if (mcXPBar == null)
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
			mcXPBar.gotoAndPlay("shine");
			return;
		}
	}
}
