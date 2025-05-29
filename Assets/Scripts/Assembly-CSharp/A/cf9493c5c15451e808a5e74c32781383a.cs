using pumpkin.display;
using pumpkin.text;

namespace A
{
	public class cf9493c5c15451e808a5e74c32781383a : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected TextField cdb3099582734b815203ac6bc6ed77e24;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			cdb3099582734b815203ac6bc6ed77e24 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfname");
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			GuildNews guildNews = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c70379a017e027584de6c517a58028c52(c62a53388af21c9e5e206591a30eb9f80);
			if (guildNews == null)
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
				string text = string.Empty;
				if (guildNews.Reason == GuildNewsReason.GuildLevelUp)
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
					text += guildNews.Objective;
				}
				cdb3099582734b815203ac6bc6ed77e24.text = guildNews.PosterName + " " + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_" + guildNews.Reason)) + text;
				return;
			}
		}
	}
}
