using A;
using Core;
using pumpkin.display;
using pumpkin.events;

public class uniPvPCancelView : PvPCancelView
{
	private class PvPCancelPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CancelBtn;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
					switch (7)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
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
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: PvPCancelPanel onInit() 'mc_root' is null! PvPCancelPanel won't work!!!");
						return;
					}
				}
			}
			mc_CancelBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CancelBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_cancel"));
			mc_CancelBtn.addEventListener(MouseEvent.CLICK, c160c4effdbc25f551e67296293735016);
		}

		private void c160c4effdbc25f551e67296293735016(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae)
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
				MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c10594d4e276bc6df144aea45627e66b5();
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c9d057c2188e7d2872aa3ec71517e92ae = false;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPCancelView>().c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}
	}

	private PvPCancelPanel _PvPCancelPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("2014_PvP_Flow.swf", "CancelMatchMaking", c5ca16fbb57dc88673defc1ebd54f4adf);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_PvPCancelPanel);
		_PvPCancelPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("2014_PvP_Flow.swf");
	}

	private void c5ca16fbb57dc88673defc1ebd54f4adf(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_PvPCancelPanel = new PvPCancelPanel();
		_PvPCancelPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_PvPCancelPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_PvPCancelPanel);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		_PvPCancelPanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
	}
}
