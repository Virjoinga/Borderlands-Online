using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c5f20d8133b251cada9ed97eadee6ed58 : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected c82f7c0afbcfc8c5382a8c6daa9365b7b c2169eeb2d63e59162be248f6456b6b6d;

		protected MovieClip c942465e3e8b775db0e8e0b98f5e70064;

		protected TextField c41972088b8db60635664bcd4e01ae403;

		protected TextField cb0e6cba35779731cb4ea1e2a295b68ab;

		protected TextField c91db8da265961406c20520752f4ee09a;

		protected TextField c8a7eb1f2dc27e0982d2d680a5975bcea;

		private int c1f40e65c808640b0248b28a60153d815 = -1;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			c2169eeb2d63e59162be248f6456b6b6d = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			c2169eeb2d63e59162be248f6456b6b6d.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("mc_JoinBtn"));
			c2169eeb2d63e59162be248f6456b6b6d.addEventListener(MouseEvent.CLICK, c855693edbd8e0be5de720c982f479ebc);
			c942465e3e8b775db0e8e0b98f5e70064 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<MovieClip>("mc_Icon");
			c41972088b8db60635664bcd4e01ae403 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("tflv");
			cb0e6cba35779731cb4ea1e2a295b68ab = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("tfname");
			c91db8da265961406c20520752f4ee09a = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("status");
			c8a7eb1f2dc27e0982d2d680a5975bcea = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("headcount");
		}

		protected void c855693edbd8e0be5de720c982f479ebc(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (c1f40e65c808640b0248b28a60153d815 == -1)
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
				GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c1347808c45481ed9d11a556bed90f456(c1f40e65c808640b0248b28a60153d815);
				return;
			}
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Guild guild = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c06a3c1c3a086f54cdad2babac747cf54(c62a53388af21c9e5e206591a30eb9f80);
			if (guild != null)
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
						c1f40e65c808640b0248b28a60153d815 = guild.Id;
						c41972088b8db60635664bcd4e01ae403.text = "Lv." + guild.Level;
						cb0e6cba35779731cb4ea1e2a295b68ab.text = guild.Name;
						c91db8da265961406c20520752f4ee09a.text = string.Empty;
						c8a7eb1f2dc27e0982d2d680a5975bcea.text = guild.MemberCount + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GuildMembers"));
						if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cfd711de3351af645b2d20a2bea350915(c1f40e65c808640b0248b28a60153d815))
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									c2169eeb2d63e59162be248f6456b6b6d.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
									c2169eeb2d63e59162be248f6456b6b6d.c150264a18c2cb408479d3f072cac8cc1 = true;
									return;
								}
							}
						}
						if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c8f6b66556de9658f8929503bb43e0b1f(c1f40e65c808640b0248b28a60153d815))
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
							c91db8da265961406c20520752f4ee09a.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_APPLIED"));
						}
						else
						{
							c91db8da265961406c20520752f4ee09a.text = string.Empty;
						}
						c2169eeb2d63e59162be248f6456b6b6d.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						c2169eeb2d63e59162be248f6456b6b6d.c150264a18c2cb408479d3f072cac8cc1 = true;
						return;
					}
				}
			}
			c1f40e65c808640b0248b28a60153d815 = -1;
			c41972088b8db60635664bcd4e01ae403.text = string.Empty;
			cb0e6cba35779731cb4ea1e2a295b68ab.text = string.Empty;
			c91db8da265961406c20520752f4ee09a.text = string.Empty;
		}
	}
}
