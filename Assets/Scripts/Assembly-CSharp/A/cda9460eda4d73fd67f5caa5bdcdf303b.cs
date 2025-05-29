using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class cda9460eda4d73fd67f5caa5bdcdf303b : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected MovieClip c65e7cfbfd415abd692f92e0870c49352;

		protected MovieClip c0ada53eafbc9ed42853b9fbd14b5eaee;

		protected TextField cc75db01329241d2d1d7bb4abca77cf11;

		protected TextField c5c467fc2b7d4549eefe4a190ecf4851c;

		protected TextField c7b7e44956341a44d57084d84a89b883c;

		protected TextField ca0ce025a4743a4f416ca0f3bffb343cf;

		protected TextField c280a2ad0600ed1fc97e7b01b5dde9135;

		protected TextField c08779df41a7c3d9aa20a07d0bdf21bc2;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b cf25ef84246e4fadefec44ad7b5af2705;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b c47b7e7a3442c5865120ab095cac1a87a;

		private GuildManager.ApplicationStatus cca2a038beeadb1cee89ef4be54520de2;

		private int c914362963b5669274c6582a534308c62 = -1;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			c65e7cfbfd415abd692f92e0870c49352 = movieClip.getChildByName<MovieClip>("groupNormal");
			c0ada53eafbc9ed42853b9fbd14b5eaee = movieClip.getChildByName<MovieClip>("groupDecided");
			cc75db01329241d2d1d7bb4abca77cf11 = c65e7cfbfd415abd692f92e0870c49352.getChildByName<TextField>("tflv");
			c5c467fc2b7d4549eefe4a190ecf4851c = c65e7cfbfd415abd692f92e0870c49352.getChildByName<TextField>("tfname");
			c7b7e44956341a44d57084d84a89b883c = c65e7cfbfd415abd692f92e0870c49352.getChildByName<TextField>("tfposition");
			cc75db01329241d2d1d7bb4abca77cf11.text = string.Empty;
			c5c467fc2b7d4549eefe4a190ecf4851c.text = string.Empty;
			c7b7e44956341a44d57084d84a89b883c.text = string.Empty;
			ca0ce025a4743a4f416ca0f3bffb343cf = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<TextField>("tflv");
			c280a2ad0600ed1fc97e7b01b5dde9135 = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<TextField>("tfname");
			c08779df41a7c3d9aa20a07d0bdf21bc2 = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<TextField>("tfinfo");
			ca0ce025a4743a4f416ca0f3bffb343cf.text = string.Empty;
			c280a2ad0600ed1fc97e7b01b5dde9135.text = string.Empty;
			c08779df41a7c3d9aa20a07d0bdf21bc2.text = string.Empty;
			cf25ef84246e4fadefec44ad7b5af2705 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			cf25ef84246e4fadefec44ad7b5af2705.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("bt_accept"));
			cf25ef84246e4fadefec44ad7b5af2705.addEventListener(MouseEvent.CLICK, c4408f73213286076e988bde4256b616a);
			c47b7e7a3442c5865120ab095cac1a87a = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			c47b7e7a3442c5865120ab095cac1a87a.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("bt_reject"));
			c47b7e7a3442c5865120ab095cac1a87a.addEventListener(MouseEvent.CLICK, cd29709dfe837ebdff6f86e385cfcb7a6);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(CEvent.ENTER_FRAME, c12b196ef16d3d89b666906481f435d35);
		}

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
			c39fc9de70a274455503ae86287e8d293();
		}

		protected void c12b196ef16d3d89b666906481f435d35(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c39fc9de70a274455503ae86287e8d293();
		}

		protected override void c39fc9de70a274455503ae86287e8d293()
		{
			if (cca2a038beeadb1cee89ef4be54520de2 == GuildManager.ApplicationStatus.e_WaitingForDecide)
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
						c65e7cfbfd415abd692f92e0870c49352.visible = true;
						c0ada53eafbc9ed42853b9fbd14b5eaee.visible = false;
						cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = true;
						c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = true;
						return;
					}
				}
			}
			c65e7cfbfd415abd692f92e0870c49352.visible = false;
			c0ada53eafbc9ed42853b9fbd14b5eaee.visible = true;
			cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
			c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
		}

		private void c4408f73213286076e988bde4256b616a(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c5754d5650a3df3b3f78db32c9e4a0591(c914362963b5669274c6582a534308c62, true);
		}

		private void cd29709dfe837ebdff6f86e385cfcb7a6(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c5754d5650a3df3b3f78db32c9e4a0591(c914362963b5669274c6582a534308c62, false);
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Presence presence = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c02470b148853eea1ca9740b81d13751f(c62a53388af21c9e5e206591a30eb9f80);
			GuildManager.ApplicationStatus applicationStatus = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c0c36f47b5eb99cef21538d13b28fbcdc(c62a53388af21c9e5e206591a30eb9f80);
			if (presence != null)
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
						cca2a038beeadb1cee89ef4be54520de2 = applicationStatus;
						c914362963b5669274c6582a534308c62 = presence.mCharacterId;
						if (applicationStatus == GuildManager.ApplicationStatus.e_WaitingForDecide)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									c65e7cfbfd415abd692f92e0870c49352.visible = true;
									c0ada53eafbc9ed42853b9fbd14b5eaee.visible = false;
									cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = true;
									c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = true;
									cc75db01329241d2d1d7bb4abca77cf11.textFormat.color = Color.yellow;
									cc75db01329241d2d1d7bb4abca77cf11.text = "LV." + presence.mCharacterLevel;
									c5c467fc2b7d4549eefe4a190ecf4851c.text = presence.mCharacterName;
									c7b7e44956341a44d57084d84a89b883c.text = string.Empty;
									ca0ce025a4743a4f416ca0f3bffb343cf.text = string.Empty;
									c280a2ad0600ed1fc97e7b01b5dde9135.text = string.Empty;
									c08779df41a7c3d9aa20a07d0bdf21bc2.text = string.Empty;
									return;
								}
							}
						}
						c65e7cfbfd415abd692f92e0870c49352.visible = false;
						c0ada53eafbc9ed42853b9fbd14b5eaee.visible = true;
						cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
						c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
						ca0ce025a4743a4f416ca0f3bffb343cf.textFormat.color = Color.yellow;
						ca0ce025a4743a4f416ca0f3bffb343cf.text = "LV." + presence.mCharacterLevel;
						c280a2ad0600ed1fc97e7b01b5dde9135.text = presence.mCharacterName;
						cc75db01329241d2d1d7bb4abca77cf11.text = string.Empty;
						c5c467fc2b7d4549eefe4a190ecf4851c.text = string.Empty;
						c7b7e44956341a44d57084d84a89b883c.text = string.Empty;
						if (applicationStatus == GuildManager.ApplicationStatus.e_Accepted)
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
							c08779df41a7c3d9aa20a07d0bdf21bc2.text = "Accepted";
						}
						if (applicationStatus == GuildManager.ApplicationStatus.e_Rejected)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									c08779df41a7c3d9aa20a07d0bdf21bc2.text = "Rejected";
									return;
								}
							}
						}
						return;
					}
				}
			}
			c914362963b5669274c6582a534308c62 = -1;
			cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
			c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
			cc75db01329241d2d1d7bb4abca77cf11.text = string.Empty;
			c5c467fc2b7d4549eefe4a190ecf4851c.text = string.Empty;
			c7b7e44956341a44d57084d84a89b883c.text = string.Empty;
			ca0ce025a4743a4f416ca0f3bffb343cf.text = string.Empty;
			c280a2ad0600ed1fc97e7b01b5dde9135.text = string.Empty;
			c08779df41a7c3d9aa20a07d0bdf21bc2.text = string.Empty;
			cca2a038beeadb1cee89ef4be54520de2 = GuildManager.ApplicationStatus.e_Rejected;
		}
	}
}
