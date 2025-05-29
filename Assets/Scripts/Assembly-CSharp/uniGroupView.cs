using System;
using A;
using Core;
using pumpkin.display;
using pumpkin.events;

public class uniGroupView : GroupView
{
	private class GroupPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private int MESSAGE_TOTAL = 18;

		private string ITEM_SLOT_PREFIX_NAME = "groupItem";

		protected cb870df68606561cd5d8d0566ef0cdfea[] _arrButtons;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Close;

		protected cf7ac05203029a27299d6893b2dbaee2e mc_ScrollBar;

		protected MovieClip mc_GroupPanel;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
							return mc_root.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (mc_root == null)
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
					if (value)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								c591c47219c2da4f480868724bfea2264();
								c0159867dc6869bb2ec205ab748ad6afb();
								return;
							}
						}
					}
					c09fd41a9b5ba9b6addeaef436867b943();
					return;
				}
			}
		}

		public GroupPanel()
		{
			_arrButtons = c73e1524dabb5720987a8ac5e291ed750.c0a0cdf4a196914163f7334d9b0781a04(MESSAGE_TOTAL);
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: GroupPanel onInit() 'mc_root' is null! InstancePanel won't work!!!");
						return;
					}
				}
			}
			mc_root.visible = false;
			mc_Close = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_Close.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("group_root").getChildByName<MovieClip>("groupTotal").getChildByName<MovieClip>("mcBtnClose"));
			mc_Close.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
			mc_ScrollBar = new cf7ac05203029a27299d6893b2dbaee2e();
			mc_ScrollBar.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("group_root").getChildByName<MovieClip>("groupTotal").getChildByName<MovieClip>("mcScrollingBar"));
			mc_ScrollBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
			mc_ScrollBar.cfcb3294d851a0336d3f3a8f2a943f2fb = (mc_ScrollBar.c9c58dff860effc1212c1afb5d14e147c = 0);
			mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(MESSAGE_TOTAL, 0, GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c06288d57de4bf58c453289eef8b13572() - MESSAGE_TOTAL, 1);
			mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			mc_GroupPanel = mc_root.getChildByName<MovieClip>("group_root").getChildByName<MovieClip>("groupTotal").getChildByName<MovieClip>("mc_group");
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mc_root.visible = true;
			mc_root.gotoAndPlay("fade");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = false;
			mc_root.gotoAndPlay("fadeout");
			mc_root.addFrameScript("fadeoutend", c1a8a5357baa03eacf7b0a3123daf5911);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c2c8c844535004da8c81e3bc95e8f5750();
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeEventListener("fadeoutend", c1a8a5357baa03eacf7b0a3123daf5911);
			mc_root.visible = false;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(ITEM_SLOT_PREFIX_NAME))
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
				int num = Convert.ToInt32(movieClip.name.Substring(ITEM_SLOT_PREFIX_NAME.Length, movieClip.name.Length - ITEM_SLOT_PREFIX_NAME.Length));
				if (num < _arrButtons.Length)
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
					if (num >= 0)
					{
						cb870df68606561cd5d8d0566ef0cdfea cb870df68606561cd5d8d0566ef0cdfea = new cb870df68606561cd5d8d0566ef0cdfea();
						cb870df68606561cd5d8d0566ef0cdfea.c130648b59a0c8debea60aa153f844879(movieClip);
						_arrButtons[num] = cb870df68606561cd5d8d0566ef0cdfea;
						goto IL_00e8;
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
				array[0] = "Group itemSlot name wrong! Index:";
				array[1] = num;
				array[2] = " is bigger than sum: ";
				array[3] = _arrButtons.Length;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
				return true;
			}
			goto IL_00e8;
			IL_00e8:
			return true;
		}

		public void c591c47219c2da4f480868724bfea2264(bool c6f679be941e26295c3532fc30731ee30 = false)
		{
			mc_ScrollBar.c5a7d812d0a8e674b21eb0ed8824a2f59(MESSAGE_TOTAL, 0, GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c06288d57de4bf58c453289eef8b13572() - MESSAGE_TOTAL, 1);
			int num;
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c06288d57de4bf58c453289eef8b13572() > MESSAGE_TOTAL)
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
				num = MESSAGE_TOTAL;
			}
			else
			{
				num = GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c06288d57de4bf58c453289eef8b13572();
			}
			int num2 = num;
			for (int i = 0; i < num2; i++)
			{
				_arrButtons[i].c263a18e823d534fe933bf797fd17c221(mc_ScrollBar.cef9712200bbe2c3873eec3ca2e18a595 + i);
				_arrButtons[i].c150264a18c2cb408479d3f072cac8cc1 = true;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				for (int j = num2; j < MESSAGE_TOTAL; j++)
				{
					if (_arrButtons[j] == null)
					{
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
					_arrButtons[j].c150264a18c2cb408479d3f072cac8cc1 = false;
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

		private void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GroupView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (!mc_root.visible)
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
				c591c47219c2da4f480868724bfea2264();
				return;
			}
		}
	}

	private GroupPanel _groupPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Friend_Group.swf", "GroupRootPanel", cdd00bad0221631470edcf745132ae4ba);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_groupPanel);
		_groupPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Friend_Group.swf");
	}

	private void cdd00bad0221631470edcf745132ae4ba(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_groupPanel = new GroupPanel();
		_groupPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_groupPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_groupPanel);
		}
		_groupPanel.c150264a18c2cb408479d3f072cac8cc1 = _bVisible;
	}

	public override void c263a18e823d534fe933bf797fd17c221()
	{
		if (_groupPanel == null)
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
		_groupPanel.c591c47219c2da4f480868724bfea2264();
	}
}
