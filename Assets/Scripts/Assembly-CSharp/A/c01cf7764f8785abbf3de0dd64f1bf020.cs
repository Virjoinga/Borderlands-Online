using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c01cf7764f8785abbf3de0dd64f1bf020 : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected MovieClip c65e7cfbfd415abd692f92e0870c49352;

		protected MovieClip c0ada53eafbc9ed42853b9fbd14b5eaee;

		protected MovieClip c029b121c24c5be9b10e59bcb9fccd983;

		protected MovieClip cab8907a76c736cb687705dd983f067f3;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b cf25ef84246e4fadefec44ad7b5af2705;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b c47b7e7a3442c5865120ab095cac1a87a;

		protected TextField c5c467fc2b7d4549eefe4a190ecf4851c;

		protected TextField c280a2ad0600ed1fc97e7b01b5dde9135;

		protected TextField cc75db01329241d2d1d7bb4abca77cf11;

		protected TextField ca0ce025a4743a4f416ca0f3bffb343cf;

		protected TextField cfacada943602304f57c27f8805d8874e;

		protected TextField c29ac24d0dfbf9258ca8c8da7869f10b3;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			c65e7cfbfd415abd692f92e0870c49352 = movieClip.getChildByName<MovieClip>("groupNormal");
			c0ada53eafbc9ed42853b9fbd14b5eaee = movieClip.getChildByName<MovieClip>("groupDecided");
			c029b121c24c5be9b10e59bcb9fccd983 = c65e7cfbfd415abd692f92e0870c49352.getChildByName<MovieClip>("mc_Icon");
			cab8907a76c736cb687705dd983f067f3 = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<MovieClip>("mc_Icon");
			c5c467fc2b7d4549eefe4a190ecf4851c = c65e7cfbfd415abd692f92e0870c49352.getChildByName<TextField>("tfname");
			c280a2ad0600ed1fc97e7b01b5dde9135 = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<TextField>("tfname");
			cc75db01329241d2d1d7bb4abca77cf11 = c65e7cfbfd415abd692f92e0870c49352.getChildByName<TextField>("tflv");
			ca0ce025a4743a4f416ca0f3bffb343cf = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<TextField>("tflv");
			cfacada943602304f57c27f8805d8874e = c0ada53eafbc9ed42853b9fbd14b5eaee.getChildByName<TextField>("tfinfo");
			c29ac24d0dfbf9258ca8c8da7869f10b3 = c65e7cfbfd415abd692f92e0870c49352.getChildByName<TextField>("tfposition");
			MovieClip childByName = movieClip.getChildByName<MovieClip>("bt_accept");
			MovieClip childByName2 = movieClip.getChildByName<MovieClip>("bt_reject");
			cf25ef84246e4fadefec44ad7b5af2705 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			c47b7e7a3442c5865120ab095cac1a87a = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			cf25ef84246e4fadefec44ad7b5af2705.c130648b59a0c8debea60aa153f844879(childByName);
			c47b7e7a3442c5865120ab095cac1a87a.c130648b59a0c8debea60aa153f844879(childByName2);
			c65e7cfbfd415abd692f92e0870c49352.visible = false;
			cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
			c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
			c29ac24d0dfbf9258ca8c8da7869f10b3.textFormat.color = Color.green;
			c29ac24d0dfbf9258ca8c8da7869f10b3.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Friend_Invitation"));
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(CEvent.ENTER_FRAME, c12b196ef16d3d89b666906481f435d35);
			cf25ef84246e4fadefec44ad7b5af2705.addEventListener(MouseEvent.CLICK, cd1158e9ac8a91c680730426e724c5b83);
			c47b7e7a3442c5865120ab095cac1a87a.addEventListener(MouseEvent.CLICK, c057d6e1ceab016fc023618c40b64ee9d);
		}

		protected void c12b196ef16d3d89b666906481f435d35(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c39fc9de70a274455503ae86287e8d293();
		}

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
			c39fc9de70a274455503ae86287e8d293();
		}

		protected override void c39fc9de70a274455503ae86287e8d293()
		{
			if (c93b9f9e7db3254d97a5118f2dcffe924 == -1)
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
			if (!FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c80e280b3a474879292d226409aeb70ba(c93b9f9e7db3254d97a5118f2dcffe924))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			c0ada53eafbc9ed42853b9fbd14b5eaee.visible = false;
			c65e7cfbfd415abd692f92e0870c49352.visible = true;
			c4fe78a23d4d3fbe28703a67062c46bd3();
		}

		protected void c4fe78a23d4d3fbe28703a67062c46bd3()
		{
			if (!(base.c17fcd0ed1024ad7689991a96ed60deb1 == "over"))
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
				if (!(base.c17fcd0ed1024ad7689991a96ed60deb1 == "down"))
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
					if (!(base.c17fcd0ed1024ad7689991a96ed60deb1 == "release"))
					{
						cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
						c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
						return;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
			if (!cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1)
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
				if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c20292dc0112b596d061ae25400743cc5())
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
					cf25ef84246e4fadefec44ad7b5af2705.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
				}
				else
				{
					cf25ef84246e4fadefec44ad7b5af2705.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				}
				cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = true;
			}
			if (c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1)
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
				c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = true;
				return;
			}
		}

		protected void cd1158e9ac8a91c680730426e724c5b83(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c7f0dffe793ab211fb14de2aedcb03e7d(c93b9f9e7db3254d97a5118f2dcffe924);
		}

		protected void c057d6e1ceab016fc023618c40b64ee9d(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().cc247771682223024f44ff9d22a219678(c93b9f9e7db3254d97a5118f2dcffe924);
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			PlayerProperties playerProperties = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c8b56aabd1119d63ae70495f90ba03b68(c62a53388af21c9e5e206591a30eb9f80);
			if (playerProperties == null)
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
				c93b9f9e7db3254d97a5118f2dcffe924 = playerProperties.m_id;
				c5c467fc2b7d4549eefe4a190ecf4851c.text = playerProperties.m_name;
				c280a2ad0600ed1fc97e7b01b5dde9135.text = playerProperties.m_name;
				cc75db01329241d2d1d7bb4abca77cf11.text = "Lv:" + playerProperties.m_level;
				ca0ce025a4743a4f416ca0f3bffb343cf.text = "Lv:" + playerProperties.m_level;
				c029b121c24c5be9b10e59bcb9fccd983.gotoAndStop(playerProperties.m_avatarDna.m_type.ToString());
				cab8907a76c736cb687705dd983f067f3.gotoAndStop(playerProperties.m_avatarDna.m_type.ToString());
				return;
			}
		}
	}
}
