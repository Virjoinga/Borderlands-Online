using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c9542c14c996389480d707aa1968409d5 : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected MovieClip cba3f5bc185873baea3c3b288b6699a06;

		protected TextField c5d96dddf6df5aa49b15d2398df5f9437;

		protected TextField ca84ebe7f578948a6eec4a5e2a15ace07;

		protected TextField c5cb93dc2252bdcc84f647582c5085f75;

		protected TextField c77b753c665c5843bd29073922afdf9db;

		private int c914362963b5669274c6582a534308c62 = -1;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			cba3f5bc185873baea3c3b288b6699a06 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<MovieClip>("mc_Icon");
			c5d96dddf6df5aa49b15d2398df5f9437 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tflv");
			ca84ebe7f578948a6eec4a5e2a15ace07 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfname");
			c5cb93dc2252bdcc84f647582c5085f75 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfposition");
			c77b753c665c5843bd29073922afdf9db = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfjdtitle");
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.CLICK, c5afe4ba358736ecbfb7bb98c419a19c6);
		}

		protected void c5afe4ba358736ecbfb7bb98c419a19c6(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c055fde1cbb50b2caadff9b9898ec0f9a(c914362963b5669274c6582a534308c62);
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Presence presence = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cfcb510191c7a829452983b49c9afb8e5(c62a53388af21c9e5e206591a30eb9f80);
			if (presence != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c914362963b5669274c6582a534308c62 = presence.mCharacterId;
						AvatarType mAvatarType = presence.mAvatarType;
						cba3f5bc185873baea3c3b288b6699a06.gotoAndStop(mAvatarType.ToString());
						c5d96dddf6df5aa49b15d2398df5f9437.text = "Lv." + presence.mCharacterLevel;
						ca84ebe7f578948a6eec4a5e2a15ace07.text = presence.mCharacterName;
						c77b753c665c5843bd29073922afdf9db.textFormat.color = Color.green;
						if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c17ba091c28b756583dc29d3eec870622(presence.mCharacterId))
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
							c77b753c665c5843bd29073922afdf9db.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_OWNER"));
						}
						else if (GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6451c6b5252840b2be641871236928f(presence.mCharacterId))
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
							c77b753c665c5843bd29073922afdf9db.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_MANAGER"));
						}
						else
						{
							c77b753c665c5843bd29073922afdf9db.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_MEMBER"));
						}
						if (presence.mIsOnline)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									c5cb93dc2252bdcc84f647582c5085f75.textFormat.color = Color.white;
									c5cb93dc2252bdcc84f647582c5085f75.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Instance_" + presence.mCurrentTown));
									return;
								}
							}
						}
						c5cb93dc2252bdcc84f647582c5085f75.textFormat.color = Color.gray;
						c5cb93dc2252bdcc84f647582c5085f75.text = Utility.c3702d7d2ce9dcf64b29c2fab82d733d5(presence.mLastOnline);
						return;
					}
					}
				}
			}
			c914362963b5669274c6582a534308c62 = -1;
			c5d96dddf6df5aa49b15d2398df5f9437.text = string.Empty;
			ca84ebe7f578948a6eec4a5e2a15ace07.text = string.Empty;
			c5cb93dc2252bdcc84f647582c5085f75.text = string.Empty;
			c77b753c665c5843bd29073922afdf9db.text = string.Empty;
		}
	}
}
