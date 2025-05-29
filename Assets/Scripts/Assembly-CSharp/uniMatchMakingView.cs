using A;
using Core;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniMatchMakingView : MatchMakingView
{
	private class MatchMakingPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Button;

		private TextField _MessageField;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf != null)
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
							switch (7)
							{
							case 0:
								break;
							default:
								c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c4717862155dcb63da4094ee983c75b38 = false;
								c23ffb495db7c9da62404f1cc24a67351();
								return;
							}
						}
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c4717862155dcb63da4094ee983c75b38 = true;
					cce6adadf40a70610ce3ae5dd40479620();
					return;
				}
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
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: MatchMakingPanel onInit() 'mcSelf' is null! MatchMakingPanel won't work!!!");
						return;
					}
				}
			}
			mc_Button = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_Button.c130648b59a0c8debea60aa153f844879(mcSelf.getChildByName<MovieClip>("mcNPCtalkframe").getChildByName<MovieClip>("mc_button"));
			_MessageField = mcSelf.getChildByName<MovieClip>("mcNPCtalkframe").getChildByName<TextField>("textDescription");
			_MessageField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Matchmaking_searhing_remind"));
			mcSelf.stop();
			mc_Button.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
		}

		public void c23ffb495db7c9da62404f1cc24a67351()
		{
			mc_Button.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			mcSelf.gotoAndPlay("fadein");
		}

		private void cce6adadf40a70610ce3ae5dd40479620()
		{
			mcSelf.gotoAndPlay("fadeout");
			mcSelf.addFrameScript("fadeoutEnd", ca45aa4038153928bb3c25fc71e6c45e1);
		}

		public void ca495c34d792d9b5bb233b4388b3dcb1d()
		{
			mc_Button.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
		}

		private void ce6e90523914e3b1e1fe3bd32ac290b03(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c10594d4e276bc6df144aea45627e66b5();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		}

		private void ca45aa4038153928bb3c25fc71e6c45e1(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcSelf.removeFrameScript("fadeoutEnd", ca45aa4038153928bb3c25fc71e6c45e1);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c9d057c2188e7d2872aa3ec71517e92ae = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
					break;
				}
			}
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c01f60631f6d4cee6631245560d19fc36("OnGoToInstance");
		}
	}

	private MatchMakingPanel _matchmakingPanel;

	public override bool cd0069281ff5290a7e6c484b6aed3933d
	{
		get
		{
			int result;
			if (_bActive)
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
				result = ((_matchmakingPanel != null) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("match_making.swf", "NPCAnima", c656a26e240260b9ad00a59baee99aa9b);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		cd709174be42fda430a2bdb7ad8549098(false);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_matchmakingPanel);
		_matchmakingPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("match_making.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c4717862155dcb63da4094ee983c75b38 = true;
	}

	private void c656a26e240260b9ad00a59baee99aa9b(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_matchmakingPanel = new MatchMakingPanel();
		_matchmakingPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_matchmakingPanel);
		}
		if (_matchmakingPanel == null)
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
			if (c9e82bede03ea180ba65a597350997ad2)
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
				if (c8be1fcd630e5fe96821376d111325750)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PauseMenuView>().c67b28f11a75cd869d2f715f541128e09 = false;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c4717862155dcb63da4094ee983c75b38 = false;
					if (m_gameMode == GamemodeType.GamemodePvE)
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
						TownBehaviour.ce2930ac4ecd72437eb897cc5b7ac411e();
					}
					else
					{
						TownBehaviour.cd2ae7f946a784d332495e83e7f45c518();
					}
				}
				else
				{
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PauseMenuView>().c67b28f11a75cd869d2f715f541128e09 = true;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().c4717862155dcb63da4094ee983c75b38 = true;
					if (m_gameMode == GamemodeType.GamemodePvE)
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
						TownBehaviour.c875cfe6662f961b477c2e72453edfbe4();
					}
					else
					{
						TownBehaviour.c1c09bbfad47ca3cf727182be087e9527();
					}
				}
				_matchmakingPanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
				return;
			}
		}
	}

	public override void c23ffb495db7c9da62404f1cc24a67351()
	{
		base.c23ffb495db7c9da62404f1cc24a67351();
		if (_matchmakingPanel == null)
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
			_matchmakingPanel.c23ffb495db7c9da62404f1cc24a67351();
			return;
		}
	}

	public override void ca495c34d792d9b5bb233b4388b3dcb1d()
	{
		if (_matchmakingPanel == null)
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
			_matchmakingPanel.ca495c34d792d9b5bb233b4388b3dcb1d();
			TownBehaviour.c1c09bbfad47ca3cf727182be087e9527();
			return;
		}
	}
}
