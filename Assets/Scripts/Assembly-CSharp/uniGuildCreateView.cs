using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class uniGuildCreateView : GuildCreateView
{
	private class GuildCreatePanel : c196099a1254db61d3be10d70e14e7422
	{
		public MovieClip mc_root;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CreateBtn;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CancelBtn;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b mc_CloseBtn;

		private ccf8bd4afc86b3c33d69f65b1612538ce tf_GuildName;

		private ccf8bd4afc86b3c33d69f65b1612538ce tf_GuildClaim;

		private c6425d3761c85e65e3530cc19d085d446 mc_QuestCheck;

		private c6425d3761c85e65e3530cc19d085d446 mc_PvECheck;

		private c6425d3761c85e65e3530cc19d085d446 mc_PvPCheck;

		private c6425d3761c85e65e3530cc19d085d446 mc_SocialCheck;

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
					switch (1)
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
								c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c7bb86b60f299c950179b9bd1c30a2a68);
								tf_GuildName.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
								tf_GuildClaim.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
								tf_GuildName.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
								tf_GuildClaim.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
								mc_QuestCheck.c9c364a8fd1f013589fea518a3924e711 = true;
								mc_PvECheck.c9c364a8fd1f013589fea518a3924e711 = true;
								mc_PvPCheck.c9c364a8fd1f013589fea518a3924e711 = true;
								mc_SocialCheck.c9c364a8fd1f013589fea518a3924e711 = true;
								mc_CreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
								c0159867dc6869bb2ec205ab748ad6afb();
								return;
							}
						}
					}
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c7bb86b60f299c950179b9bd1c30a2a68);
					c09fd41a9b5ba9b6addeaef436867b943();
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
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: GuildSearchPanel onInit() 'mc_root' is null! GuildSearchPanel won't work!!!");
						return;
					}
				}
			}
			mc_root.visible = false;
			mc_CreateBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CreateBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_create"));
			mc_CreateBtn.addEventListener(MouseEvent.CLICK, c1e19c248a4039f02423c0037f5384cb6);
			mc_CancelBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CancelBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_cancel"));
			mc_CancelBtn.addEventListener(MouseEvent.CLICK, c7c2ebf9a4704bd5defd809a6b06e889a);
			mc_CloseBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			mc_CloseBtn.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcBtnClose"));
			mc_CloseBtn.addEventListener(MouseEvent.CLICK, c21e36f8cd23459c6af056b4a8a451e4c);
			tf_GuildName = new ccf8bd4afc86b3c33d69f65b1612538ce();
			tf_GuildName.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcNameInput"));
			tf_GuildName.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			tf_GuildName.c275618f45ace7b211e4da85cecbb43d4 = 8;
			tf_GuildClaim = new ccf8bd4afc86b3c33d69f65b1612538ce();
			tf_GuildClaim.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcsloganInput"));
			tf_GuildClaim.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			tf_GuildClaim.c275618f45ace7b211e4da85cecbb43d4 = 15;
			tf_GuildName.ca8330954d9c83f7823077e64b06ff45a = true;
			tf_GuildClaim.ca8330954d9c83f7823077e64b06ff45a = true;
			tf_GuildName.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
			tf_GuildClaim.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
			tf_GuildName.addEventListener(CEvent.CHANGED, cdc88cb39a6d4b5dd548147756af51857);
			tf_GuildClaim.addEventListener(CEvent.CHANGED, cdc88cb39a6d4b5dd548147756af51857);
			mc_QuestCheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_QuestCheck.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcQuestCheck"));
			mc_QuestCheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_QuestCheck.cec024da8c099380cfe1334bfe4c8f30f = "quest";
			mc_QuestCheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_QuestCheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_PvECheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_PvECheck.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcPvECheck"));
			mc_PvECheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_PvECheck.cec024da8c099380cfe1334bfe4c8f30f = "pve";
			mc_PvECheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_PvECheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_PvPCheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_PvPCheck.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcPvPCheck"));
			mc_PvPCheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_PvPCheck.cec024da8c099380cfe1334bfe4c8f30f = "pvp";
			mc_PvPCheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_PvPCheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
			mc_SocialCheck = new c6425d3761c85e65e3530cc19d085d446();
			mc_SocialCheck.c130648b59a0c8debea60aa153f844879(mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcSocialCheck"));
			mc_SocialCheck.ce84b930a12a1d06512c79320b3f0d3f4 = true;
			mc_SocialCheck.cec024da8c099380cfe1334bfe4c8f30f = "social";
			mc_SocialCheck.c9c364a8fd1f013589fea518a3924e711 = true;
			mc_SocialCheck.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ca6933d4065e842546d6e2f70775dd1d8);
		}

		protected void c0159867dc6869bb2ec205ab748ad6afb()
		{
			mc_root.visible = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = false;
			mc_root.gotoAndPlay("DetailAppear");
		}

		protected void c09fd41a9b5ba9b6addeaef436867b943()
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
			tf_GuildName.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
			tf_GuildClaim.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
			mc_root.gotoAndPlay("KeyFrame_2");
			mc_root.addFrameScript("KeyFrame_3", c1a8a5357baa03eacf7b0a3123daf5911);
		}

		protected void c1a8a5357baa03eacf7b0a3123daf5911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mc_root.removeEventListener("KeyFrame_3", c1a8a5357baa03eacf7b0a3123daf5911);
			mc_root.visible = false;
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(this);
		}

		protected void cdc88cb39a6d4b5dd548147756af51857(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cf3730a6af4c66fb02e09b608751d7036();
		}

		private void cf3730a6af4c66fb02e09b608751d7036()
		{
			if (c6a5ddf484d828b6ffe7e3c26f1eae05e() == GuildPreference.None)
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
						mc_CreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						return;
					}
				}
			}
			if (tf_GuildName.c09721d98c247dde8efe59bc3cebbad00.Length > 0)
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
				if (tf_GuildClaim.c09721d98c247dde8efe59bc3cebbad00.Length > 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							if (!mc_CreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										mc_CreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
										return;
									}
								}
							}
							return;
						}
					}
				}
			}
			if (!mc_CreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8)
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
				mc_CreateBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				return;
			}
		}

		private void c21e36f8cd23459c6af056b4a8a451e4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildCreateView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		private void c1e19c248a4039f02423c0037f5384cb6(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!(tf_GuildName.c09721d98c247dde8efe59bc3cebbad00 != string.Empty))
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
				GuildPreference c6895cb3f6c7f5284072399c244b895cd = c6a5ddf484d828b6ffe7e3c26f1eae05e();
				GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cc4de3bcc457c8dac1f7fc8883cf00603(tf_GuildName.c09721d98c247dde8efe59bc3cebbad00, tf_GuildClaim.c09721d98c247dde8efe59bc3cebbad00, c6895cb3f6c7f5284072399c244b895cd);
				c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_guild");
				return;
			}
		}

		private void c7c2ebf9a4704bd5defd809a6b06e889a(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<GuildCreateView>().cc130a2d46a451dc54b61a8f0d60794ae();
		}

		private void ca6933d4065e842546d6e2f70775dd1d8(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c145c47696cdb7404f93dd0c2b26cfd51.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
			cf3730a6af4c66fb02e09b608751d7036();
		}

		private GuildPreference c6a5ddf484d828b6ffe7e3c26f1eae05e()
		{
			GuildPreference guildPreference = GuildPreference.None;
			if (mc_QuestCheck != null)
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
				if (mc_PvECheck != null)
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
					if (mc_PvPCheck != null)
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
						if (mc_SocialCheck != null)
						{
							if (mc_QuestCheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.Quest;
							}
							if (mc_PvECheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.PvE;
							}
							if (mc_PvPCheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.PvP;
							}
							if (mc_SocialCheck.c9c364a8fd1f013589fea518a3924e711)
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
								guildPreference |= GuildPreference.Social;
							}
							return guildPreference;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
					}
				}
			}
			return GuildPreference.All;
		}

		protected void c7bb86b60f299c950179b9bd1c30a2a68()
		{
			if (!Input.GetKeyDown(KeyCode.Tab))
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
				if (tf_GuildName.c49c2231d3c9f8a197e7c1f14492aa721())
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							tf_GuildName.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
							tf_GuildClaim.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
							return;
						}
					}
				}
				tf_GuildClaim.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
				tf_GuildName.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
				return;
			}
		}
	}

	private GuildCreatePanel _guildCreatePanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Guild_flow.swf", "Panel_DetailRoot", cb89edd5f0d60f2515f3550abb231df5e);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_guildCreatePanel);
		_guildCreatePanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Guild_flow.swf");
	}

	private void cb89edd5f0d60f2515f3550abb231df5e(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_guildCreatePanel = new GuildCreatePanel();
		_guildCreatePanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_guildCreatePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_guildCreatePanel);
		}
		_guildCreatePanel.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
	}
}
