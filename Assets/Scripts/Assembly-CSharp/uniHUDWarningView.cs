using A;
using Core;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDWarningView : HUDWarningView
{
	private class WarningPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Confirm = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Back = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		private TextField m_txMessage;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mc_root = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mc_root == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: WarningPanel onInit() 'mc_root' is null! WarningPanel won't work!!!");
						return;
					}
				}
			}
			mc_root.addFrameScript("fadeout", c613ddb5a531424c3f57a12057307b842);
			mc_Confirm.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mcPrevBtn"));
			mc_Back.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mcBackBtn"));
			m_txMessage = mc_root.getChildByName<MovieClip>("mcPanel").getChildByName<TextField>("txMessage");
		}

		public void c12f73f3df0bf117f8c9e93ca894a7c06(string cad8d6e0a594ee2e7b3f487fb75cd3d59 = "", Delegate_EventProc c3ecf27f8d510a71f06e60a77ad171ed9 = null, Delegate_EventProc c87b9485b73761da34a9344ae11698587 = null)
		{
			if (m_txMessage != null)
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
				m_txMessage.text = cad8d6e0a594ee2e7b3f487fb75cd3d59;
			}
			if (c3ecf27f8d510a71f06e60a77ad171ed9 != null)
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
				mc_Confirm.c150264a18c2cb408479d3f072cac8cc1 = true;
				mc_Confirm.addEventListener(MouseEvent.CLICK, ca131ac030d74d9bdd378fddf7107a229);
			}
			else
			{
				mc_Confirm.c150264a18c2cb408479d3f072cac8cc1 = false;
				mc_Confirm.removeAllEventListeners(MouseEvent.CLICK);
			}
			if (c87b9485b73761da34a9344ae11698587 != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						mc_Back.c150264a18c2cb408479d3f072cac8cc1 = true;
						mc_Back.addEventListener(MouseEvent.CLICK, c7c2ebf9a4704bd5defd809a6b06e889a);
						return;
					}
				}
			}
			mc_Back.c150264a18c2cb408479d3f072cac8cc1 = false;
			mc_Back.removeAllEventListeners(MouseEvent.CLICK);
		}

		public void c23ffb495db7c9da62404f1cc24a67351()
		{
			mc_root.visible = true;
			mc_root.gotoAndPlay("fadein");
		}

		public void cce6adadf40a70610ce3ae5dd40479620()
		{
			mc_root.gotoAndPlay("fadeout");
		}

		private void ca131ac030d74d9bdd378fddf7107a229(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cfd58c94350618be817cfdb449a158aad(false);
		}

		private void c7c2ebf9a4704bd5defd809a6b06e889a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cfd58c94350618be817cfdb449a158aad();
		}

		private void c613ddb5a531424c3f57a12057307b842(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.visible = false;
		}

		public void c5200a497e5e56ce55ab88bb16853c3d8(string c7033d7f579ec542d7cca3c8e32d316d4, string c88366ab379be430cd8802fc113358ffa)
		{
			mc_Confirm.ca08748e235f2abf925ebb3dfb3b858e8.text = c7033d7f579ec542d7cca3c8e32d316d4;
			mc_Back.ca08748e235f2abf925ebb3dfb3b858e8.text = c88366ab379be430cd8802fc113358ffa;
		}
	}

	private class InfoPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private TextField _infoField;

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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: infoPanel onInit() 'mc_root' is null! WarningPanel won't work!!!");
						return;
					}
				}
			}
			_infoField = mc_root.getChildByName<TextField>("textTips");
		}

		public void cbc6cd817c01cd45403c946755cef2f6e(string c9bbc30d75f7bf3ca249130e81ff0fd6d)
		{
			if (_infoField == null)
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
				_infoField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c9bbc30d75f7bf3ca249130e81ff0fd6d));
				return;
			}
		}
	}

	private WarningPanel _warningPanel;

	private InfoPanel _infoPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Warning.swf", "Whole", c1ac16afcc9cae39f77e2ad2c1f389cd1);
		BadAssMovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c = new BadAssMovieClip("CommonLib.swf", "SystemInfo");
		c5f7136f590197664e570808b3efeb0a2(cbe9ca8ddb3cdc2312e6ff8411b2db2c);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_warningPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_infoPanel);
		_warningPanel = null;
		_infoPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Warning.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("CommonLib.swf");
	}

	public override void cea4468dc2438c0952d375da1a5a17607(string cad8d6e0a594ee2e7b3f487fb75cd3d59 = "", Delegate_EventProc c3ecf27f8d510a71f06e60a77ad171ed9 = null, Delegate_EventProc c87b9485b73761da34a9344ae11698587 = null)
	{
		if (_bVisible)
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
					return;
				}
			}
		}
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c120a0ab44e69ef682f36041c0b116750(_warningPanel);
		base.cea4468dc2438c0952d375da1a5a17607(cad8d6e0a594ee2e7b3f487fb75cd3d59, c3ecf27f8d510a71f06e60a77ad171ed9, c87b9485b73761da34a9344ae11698587);
		if (_warningPanel == null)
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
			ce14ab3b98c66fd882f4ebb627236ed4f();
			_warningPanel.c12f73f3df0bf117f8c9e93ca894a7c06(cad8d6e0a594ee2e7b3f487fb75cd3d59, c3ecf27f8d510a71f06e60a77ad171ed9, c87b9485b73761da34a9344ae11698587);
			_warningPanel.c23ffb495db7c9da62404f1cc24a67351();
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Warning_Pop");
			return;
		}
	}

	public override void cfd58c94350618be817cfdb449a158aad(bool c56e59f369525e00cfdef7ef793e66596 = true)
	{
		base.cfd58c94350618be817cfdb449a158aad(c56e59f369525e00cfdef7ef793e66596);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_warningPanel);
		if (_warningPanel == null)
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
			_warningPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
			return;
		}
	}

	public override void c5734fb1245ed054d8619adf30ecab3c8(string c9bbc30d75f7bf3ca249130e81ff0fd6d = "")
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_infoPanel);
		_infoPanel.cbc6cd817c01cd45403c946755cef2f6e(c9bbc30d75f7bf3ca249130e81ff0fd6d);
		_infoPanel.mc_root.visible = true;
	}

	public override void ce14ab3b98c66fd882f4ebb627236ed4f()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_infoPanel);
		_infoPanel.mc_root.visible = false;
	}

	private void c1ac16afcc9cae39f77e2ad2c1f389cd1(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_warningPanel = new WarningPanel();
		_warningPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
	}

	private void c5f7136f590197664e570808b3efeb0a2(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_infoPanel = new InfoPanel();
		_infoPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		ce14ab3b98c66fd882f4ebb627236ed4f();
	}

	public override void c5200a497e5e56ce55ab88bb16853c3d8(string c7033d7f579ec542d7cca3c8e32d316d4, string c88366ab379be430cd8802fc113358ffa)
	{
		if (_warningPanel == null)
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
			_warningPanel.c5200a497e5e56ce55ab88bb16853c3d8(c7033d7f579ec542d7cca3c8e32d316d4, c88366ab379be430cd8802fc113358ffa);
			return;
		}
	}
}
