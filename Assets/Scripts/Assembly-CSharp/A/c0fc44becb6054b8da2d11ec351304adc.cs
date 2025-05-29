using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c0fc44becb6054b8da2d11ec351304adc : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected MovieClip ceb4571ca7f02fb40a98cbbf8b1f58d4b;

		protected TextField c5d96dddf6df5aa49b15d2398df5f9437;

		protected TextField ca84ebe7f578948a6eec4a5e2a15ace07;

		protected TextField c5cb93dc2252bdcc84f647582c5085f75;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b cf25ef84246e4fadefec44ad7b5af2705;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b c47b7e7a3442c5865120ab095cac1a87a;

		protected Presence c57b01bb713a45dd68b36b4f255e08dff;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mc_FriendItem");
			ceb4571ca7f02fb40a98cbbf8b1f58d4b = childByName.getChildByName<MovieClip>("mc_Icon");
			c5d96dddf6df5aa49b15d2398df5f9437 = childByName.getChildByName<TextField>("tflv");
			ca84ebe7f578948a6eec4a5e2a15ace07 = childByName.getChildByName<TextField>("tfname");
			c5cb93dc2252bdcc84f647582c5085f75 = childByName.getChildByName<TextField>("tfposition");
			cf25ef84246e4fadefec44ad7b5af2705 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			c47b7e7a3442c5865120ab095cac1a87a = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			cf25ef84246e4fadefec44ad7b5af2705.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("mc_accept"));
			c47b7e7a3442c5865120ab095cac1a87a.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("mc_reject"));
			cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
			c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
			cf25ef84246e4fadefec44ad7b5af2705.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			c47b7e7a3442c5865120ab095cac1a87a.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(CEvent.ENTER_FRAME, c12b196ef16d3d89b666906481f435d35);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
		}

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
			cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
			c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
		}

		protected void c12b196ef16d3d89b666906481f435d35(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cf25ef84246e4fadefec44ad7b5af2705.c150264a18c2cb408479d3f072cac8cc1 = false;
			c47b7e7a3442c5865120ab095cac1a87a.c150264a18c2cb408479d3f072cac8cc1 = false;
		}

		protected void ce6e90523914e3b1e1fe3bd32ac290b03(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (c93b9f9e7db3254d97a5118f2dcffe924 == -1)
			{
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
					return;
				}
			}
			if (c93b9f9e7db3254d97a5118f2dcffe924 == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(c93b9f9e7db3254d97a5118f2dcffe924))
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
				if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c52b0e4c302961935453bec436d84dc68(c93b9f9e7db3254d97a5118f2dcffe924))
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
			MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(2);
			array[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Invitation"));
			array[0].itemData = c93b9f9e7db3254d97a5118f2dcffe924;
			if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
			{
				goto IL_011b;
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
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
				if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(c93b9f9e7db3254d97a5118f2dcffe924))
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
					goto IL_011b;
				}
			}
			array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			goto IL_0195;
			IL_011b:
			if (c57b01bb713a45dd68b36b4f255e08dff != null)
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
				if (c57b01bb713a45dd68b36b4f255e08dff.mIsOnline)
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
					array[0].itemFunc = c3a3df7377c1cc08c19b43be7807f2e2a;
				}
				else
				{
					array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				}
			}
			else
			{
				array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
			goto IL_0195;
			IL_0280:
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(array);
			return;
			IL_0195:
			array[1].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Friend_Invitation"));
			array[1].itemData = c93b9f9e7db3254d97a5118f2dcffe924;
			if (!FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c52b0e4c302961935453bec436d84dc68(c93b9f9e7db3254d97a5118f2dcffe924))
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
				if (c57b01bb713a45dd68b36b4f255e08dff != null)
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
					if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c20292dc0112b596d061ae25400743cc5())
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
						if (c57b01bb713a45dd68b36b4f255e08dff.mIsOnline)
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
							array[1].itemFunc = cc28711790460afe9d821b1acd541fb46;
							goto IL_0280;
						}
					}
					array[1].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				}
				else
				{
					array[1].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				}
			}
			else
			{
				array[1].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			}
			goto IL_0280;
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			c57b01bb713a45dd68b36b4f255e08dff = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().cf263428aa6e41bad2d6cbafd66bfc3f5(c62a53388af21c9e5e206591a30eb9f80);
			if (c57b01bb713a45dd68b36b4f255e08dff == null)
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
				c93b9f9e7db3254d97a5118f2dcffe924 = c57b01bb713a45dd68b36b4f255e08dff.mCharacterId;
				if (c57b01bb713a45dd68b36b4f255e08dff.mIsOnline)
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
					ca84ebe7f578948a6eec4a5e2a15ace07.textFormat.color = Color.white;
					c5d96dddf6df5aa49b15d2398df5f9437.textFormat.color = Color.yellow;
					c5cb93dc2252bdcc84f647582c5085f75.textFormat.color = Color.white;
					c5cb93dc2252bdcc84f647582c5085f75.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Instance_" + c57b01bb713a45dd68b36b4f255e08dff.mCurrentTown));
				}
				else
				{
					ca84ebe7f578948a6eec4a5e2a15ace07.textFormat.color = Color.gray;
					c5d96dddf6df5aa49b15d2398df5f9437.textFormat.color = Color.gray;
					c5cb93dc2252bdcc84f647582c5085f75.textFormat.color = Color.gray;
					c5cb93dc2252bdcc84f647582c5085f75.text = Utility.c3702d7d2ce9dcf64b29c2fab82d733d5(c57b01bb713a45dd68b36b4f255e08dff.mLastOnline);
				}
				c5d96dddf6df5aa49b15d2398df5f9437.text = "Lv." + c57b01bb713a45dd68b36b4f255e08dff.mCharacterLevel;
				ca84ebe7f578948a6eec4a5e2a15ace07.text = c57b01bb713a45dd68b36b4f255e08dff.mCharacterName;
				AvatarType mAvatarType = c57b01bb713a45dd68b36b4f255e08dff.mAvatarType;
				ceb4571ca7f02fb40a98cbbf8b1f58d4b.gotoAndStop(mAvatarType.ToString());
				return;
			}
		}

		protected void c3a3df7377c1cc08c19b43be7807f2e2a(object c591d56a94543e3559945c497f37126c4)
		{
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c0d1b2121def725b11ad7317d4212131a((int)c591d56a94543e3559945c497f37126c4);
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c89fcb77276a7956cd51b61c3a4437b0f(c591d56a94543e3559945c497f37126c4);
		}

		protected void cc28711790460afe9d821b1acd541fb46(object c591d56a94543e3559945c497f37126c4)
		{
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c0d1b2121def725b11ad7317d4212131a((int)c591d56a94543e3559945c497f37126c4);
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().cbbcfd0bf92e11cfa6ba6b913e85d9791(c591d56a94543e3559945c497f37126c4);
		}
	}
}
