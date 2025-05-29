using A;
using Core;
using pumpkin.display;
using pumpkin.events;

public class uniPvPModeSelectView : PvPModeSelectView
{
	private class PvPModePanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		public MovieClip mc_base;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CommonBtn;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_OfficialBtn;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
					switch (5)
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
							switch (1)
							{
							case 0:
								break;
							default:
								c0159867dc6869bb2ec205ab748ad6afb();
								return;
							}
						}
					}
					mc_root.visible = value;
					return;
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: PvPModePanel onInit() 'mc_root' is null! PvPModePanel won't work!!!");
						return;
					}
				}
			}
			mc_base = mc_root.getChildByName<MovieClip>("mc_root");
			mc_CommonBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CommonBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_root").getChildByName<MovieClip>("mc_commonBtn"));
			mc_CommonBtn.addEventListener(MouseEvent.CLICK, ca6ca783effe6f712eae85d50ef12da45);
			mc_OfficialBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_OfficialBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_root").getChildByName<MovieClip>("mc_officialBtn"));
			mc_OfficialBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mc_root.visible = true;
			mc_base.gotoAndPlay("fadein");
		}

		private void ca6ca783effe6f712eae85d50ef12da45(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPModeSelectView>().c150264a18c2cb408479d3f072cac8cc1 = false;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPRoomListView>().c150264a18c2cb408479d3f072cac8cc1 = true;
		}
	}

	private PvPModePanel _PvPModePanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("2014_PvP_Flow.swf", "option", c4b697c98069cb6aff05a6189cae4a1bd);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_PvPModePanel);
		_PvPModePanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("2014_PvP_Flow.swf");
	}

	private void c4b697c98069cb6aff05a6189cae4a1bd(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_PvPModePanel = new PvPModePanel();
		_PvPModePanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_PvPModePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_PvPModePanel);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (!m_bCheckCondition)
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
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPRoomListView>().c150264a18c2cb408479d3f072cac8cc1)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPRoomListView>().c150264a18c2cb408479d3f072cac8cc1 = false;
				}
			}
			_PvPModePanel.c150264a18c2cb408479d3f072cac8cc1 = _bVisible;
			return;
		}
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (_PvPModePanel != null)
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
			if (_PvPModePanel.c150264a18c2cb408479d3f072cac8cc1)
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
				_PvPModePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}
}
