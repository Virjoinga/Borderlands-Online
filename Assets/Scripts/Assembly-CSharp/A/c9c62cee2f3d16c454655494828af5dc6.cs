using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c9c62cee2f3d16c454655494828af5dc6 : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected c82f7c0afbcfc8c5382a8c6daa9365b7b c140a38239fc945b906ef561a1b63d3be;

		protected MovieClip c942465e3e8b775db0e8e0b98f5e70064;

		protected TextField c41972088b8db60635664bcd4e01ae403;

		protected TextField cb0e6cba35779731cb4ea1e2a295b68ab;

		protected TextField c91db8da265961406c20520752f4ee09a;

		private int c2ee80563c488ac6b4ee0477b0aca496f = -1;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			c140a38239fc945b906ef561a1b63d3be = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			c140a38239fc945b906ef561a1b63d3be.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("mc_CancelBtn"));
			c140a38239fc945b906ef561a1b63d3be.addEventListener(MouseEvent.CLICK, c160c4effdbc25f551e67296293735016);
			c942465e3e8b775db0e8e0b98f5e70064 = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<MovieClip>("mc_Icon");
			c41972088b8db60635664bcd4e01ae403 = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<TextField>("tflv");
			cb0e6cba35779731cb4ea1e2a295b68ab = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<TextField>("tfname");
			c91db8da265961406c20520752f4ee09a = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<TextField>("status");
		}

		protected void c160c4effdbc25f551e67296293735016(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (c2ee80563c488ac6b4ee0477b0aca496f == -1)
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
				GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c474237584e28f7acc3d8d13d9e2a60c8(c2ee80563c488ac6b4ee0477b0aca496f);
				return;
			}
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Guild guild = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c2262ea095e753c6e870bd09796d69f55(c62a53388af21c9e5e206591a30eb9f80);
			if (guild != null)
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
						c2ee80563c488ac6b4ee0477b0aca496f = guild.Id;
						c41972088b8db60635664bcd4e01ae403.text = "Lv." + guild.Level;
						cb0e6cba35779731cb4ea1e2a295b68ab.text = guild.Name;
						return;
					}
				}
			}
			c2ee80563c488ac6b4ee0477b0aca496f = -1;
		}
	}
}
