using A;
using Core;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniGuildOptionView : GuildOptionView
{
	private class GuildOptionPanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Join;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_Reject;

		private TextField tf_Content;

		private Utils.Timer m_Timer = new Utils.Timer();

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mc_root != null)
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
								continue;
							}
							break;
						}
						c0159867dc6869bb2ec205ab748ad6afb();
					}
					else
					{
						c09fd41a9b5ba9b6addeaef436867b943();
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
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: GuildOptionPanel onInit() 'mc_root' is null! GuildOptionPanel won't work!!!");
						return;
					}
				}
			}
			mc_root.stopAll();
			mc_root.addEventListener(CEvent.ENTER_FRAME, c04cc4c530372db0a04d942ee08561daa);
			mc_Join = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_Join.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_Join"));
			mc_Join.addEventListener(MouseEvent.CLICK, c99c0a142add800e869b0a89e3c72a5bb);
			mc_Reject = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_Reject.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_Reject"));
			mc_Reject.addEventListener(MouseEvent.CLICK, ca33994444ab1c48d7a328fa41683bcc1);
			tf_Content = mc_root.getChildByName<MovieClip>("mc_total").getChildByName<TextField>("mc_content");
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			m_Timer.cdada4c3678c9c23c38aaf0754a94a620();
			m_Timer.Start(180f);
			tf_Content.text = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().m_Invitation.guildMasterName + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_OWNER_INVITATION"));
			c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
			c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
			mc_root.gotoAndPlay("fadein");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().m_bCanShowMessage = true;
			mc_root.gotoAndPlay("fadeout");
		}

		private void c99c0a142add800e869b0a89e3c72a5bb(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			m_Timer.cdada4c3678c9c23c38aaf0754a94a620();
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd41b0678b505218e3df266adeecfb371(true);
		}

		private void ca33994444ab1c48d7a328fa41683bcc1(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			m_Timer.cdada4c3678c9c23c38aaf0754a94a620();
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd41b0678b505218e3df266adeecfb371(false);
		}

		private void c04cc4c530372db0a04d942ee08561daa(CEvent cd239cc2e7f6cebe6aadec02a32deab0e)
		{
			if (!m_Timer.cb261500372fa488b369e9159a002977a())
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
				if (!m_Timer.cf928603d375f06225f9eb5213fb17bd4())
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildOptionView>().c150264a18c2cb408479d3f072cac8cc1 = false;
					return;
				}
			}
		}
	}

	private GuildOptionPanel _guildOptionPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Guild_flow.swf", "Mc_tips", ca342d55e5227ec08b3eba6a5853554ba);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildOptionPanel);
		_guildOptionPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Guild_flow.swf");
	}

	private void ca342d55e5227ec08b3eba6a5853554ba(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_guildOptionPanel = new GuildOptionPanel();
		_guildOptionPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_guildOptionPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c7d5a91af372c5abe00435cdf71f886ad(_guildOptionPanel);
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c27542a6dc8f97862ef53db1d4f3a6db8(_guildOptionPanel);
		}
		_guildOptionPanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
	}
}
