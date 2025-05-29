using A;
using Core;
using pumpkin.display;
using pumpkin.events;

public class ETipsPanel : c196099a1254db61d3be10d70e14e7422
{
	protected MovieClip mcSelf;

	protected MovieClip mcOnlyChild;

	protected string[] TYPE_FRAME_MAP;

	public virtual bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			return mcOnlyChild.visible;
		}
		set
		{
			mcOnlyChild.visible = value;
		}
	}

	public ETipsPanel()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = "none";
		array[1] = "full";
		array[2] = "open";
		array[3] = "smash";
		array[4] = "picked up";
		array[5] = "reload";
		array[6] = "talk";
		array[7] = "outOfAmmo";
		TYPE_FRAME_MAP = array;
		base._002Ector();
	}

	public virtual void c607978cd1d85e01c73ba93a33624bc38(int c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (c2b4f43f34e21572af6ab4414f04cee36 < 0)
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
			if (c2b4f43f34e21572af6ab4414f04cee36 > TYPE_FRAME_MAP.Length)
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
			mcOnlyChild.gotoAndStop(TYPE_FRAME_MAP[c2b4f43f34e21572af6ab4414f04cee36]);
			return;
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
		}
		mcOnlyChild = mcSelf.getChildByName<MovieClip>("mcETips");
		if (mcOnlyChild == null)
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
			mcOnlyChild.stop();
			return;
		}
	}

	protected virtual void c7d86d78cfbb03b6fe2c5df6ee8693d77(CEvent cd729d94a5b443ac0f1b117450e5f4419)
	{
	}
}
