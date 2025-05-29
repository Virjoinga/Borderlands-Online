using A;
using Core;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniNPCDialogView : NPCDialogView
{
	public class NPCDialog : c196099a1254db61d3be10d70e14e7422
	{
		protected string _strDialogID;

		private MovieClip _rootMC;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_rootMC.addFrameScript("fadeout", c2471d58f4b2eb70e68abd7931c298d02);
			_rootMC.addFrameScript("nromal", c2471d58f4b2eb70e68abd7931c298d02);
			_rootMC.addFrameScript("greetingwords_IN", c2471d58f4b2eb70e68abd7931c298d02);
			_rootMC.addFrameScript("fadeoutEnd", c90b8f3c7c55511377f8b8d0554b881be);
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			_rootMC.visible = c74232243aff1dcbf2e8fc243633bb51a;
		}

		public void c40b5bc409cf38b17f8cc13dd745279ee(string c8d2c653bb3978be90fc0f2484421c09c)
		{
			_strDialogID = c8d2c653bb3978be90fc0f2484421c09c;
			cee3f7e1f2fe80146187019ef16248436();
		}

		public void c31a4a0ec5bc196f8ba7f1a8ac1fa3d86()
		{
			_rootMC.visible = true;
			if (_rootMC == null)
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
				_rootMC.gotoAndPlay("fadein");
				return;
			}
		}

		public void cffc413d6d646123b674daaa86a50e03f()
		{
			if (_rootMC == null)
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
				_rootMC.gotoAndPlay("fadeout");
				return;
			}
		}

		protected void c90b8f3c7c55511377f8b8d0554b881be(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_rootMC.visible = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}

		protected void cee3f7e1f2fe80146187019ef16248436()
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mcNPCDialog");
			if (childByName == null)
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
			string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
			if (_strDialogID != null)
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
				text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(_strDialogID));
			}
			TextField childByName2 = childByName.getChildByName<TextField>("textDescription");
			if (childByName2 == null)
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
				childByName2.multiline = true;
				childByName2.text = text;
				return;
			}
		}

		protected void c2471d58f4b2eb70e68abd7931c298d02(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cee3f7e1f2fe80146187019ef16248436();
		}
	}

	protected NPCDialog _dialog;

	protected c196099a1254db61d3be10d70e14e7422 _root;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Quest.swf", "Movie_DialogRoot", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_root = new c196099a1254db61d3be10d70e14e7422();
		_root.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		MovieClip childByName = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName<MovieClip>("mcRoot");
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
			_dialog = new NPCDialog();
			_dialog.c130648b59a0c8debea60aa153f844879(childByName);
			_dialog.c43cbb41bf755dfa61de619fc6e86ab31(false);
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
		_root = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Quest.swf");
	}

	protected override void c2fa8a6ee40c4f7f52aa7c2003b19c513()
	{
		base.c2fa8a6ee40c4f7f52aa7c2003b19c513();
		if (_dialog == null)
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
			if (_iOnShowStrIndex >= 0)
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
				if (_iOnShowStrIndex < _strDialogList.Count)
				{
					_dialog.c40b5bc409cf38b17f8cc13dd745279ee(_strDialogList[_iOnShowStrIndex]);
					return;
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
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Dialog text out of index ");
			return;
		}
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
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_root);
					_dialog.c31a4a0ec5bc196f8ba7f1a8ac1fa3d86();
					return;
				}
			}
		}
		_dialog.cffc413d6d646123b674daaa86a50e03f();
	}
}
