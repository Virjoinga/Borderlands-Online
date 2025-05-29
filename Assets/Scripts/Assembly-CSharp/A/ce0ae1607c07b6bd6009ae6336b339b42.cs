using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class ce0ae1607c07b6bd6009ae6336b339b42 : c9f62278a5e2341872ad7373d9bb65f26
	{
		private int c914362963b5669274c6582a534308c62 = -1;

		protected MovieClip c4e4c496f46f70e0221399000a65266d9;

		protected MovieClip c6bc59c1d0a8c70ee6b39aca5d7791ddc;

		protected TextField ce6ba2c1d352d37d3309feea279593241;

		protected TextField ce1920b9e00f9e50c1bc7657ed14878cd;

		protected TextField ca2b2b6aa6c1023dab7d27ac79396193f;

		protected TextField ca65fbc8873a704a25420b48862b0d2f5;

		protected TextField c210e580cd8c55e4eeba39dde09195935;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b cce1fabe7d424237606b41675015388a4;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b cb42694326f6450a627a055c541721d47;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			c4e4c496f46f70e0221399000a65266d9 = movieClip.getChildByName<MovieClip>("roomowner");
			c6bc59c1d0a8c70ee6b39aca5d7791ddc = movieClip.getChildByName<MovieClip>("mc_self");
			ce6ba2c1d352d37d3309feea279593241 = movieClip.getChildByName<TextField>("tfname");
			ce1920b9e00f9e50c1bc7657ed14878cd = movieClip.getChildByName<TextField>("tflevel");
			ca2b2b6aa6c1023dab7d27ac79396193f = movieClip.getChildByName<TextField>("tfhonor");
			ca65fbc8873a704a25420b48862b0d2f5 = movieClip.getChildByName<TextField>("tfkilldeath");
			c210e580cd8c55e4eeba39dde09195935 = movieClip.getChildByName<TextField>("tfwindeath");
			cce1fabe7d424237606b41675015388a4 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			cce1fabe7d424237606b41675015388a4.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("mc_kick"));
			cce1fabe7d424237606b41675015388a4.addEventListener(MouseEvent.CLICK, c90080d1879587ccabd3d3bd05f11eb7e);
			cb42694326f6450a627a055c541721d47 = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			cb42694326f6450a627a055c541721d47.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("mc_info"));
			cb42694326f6450a627a055c541721d47.addEventListener(MouseEvent.CLICK, c1045053998022dd6ec2c03cc04d5d144);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(CEvent.ENTER_FRAME, c12b196ef16d3d89b666906481f435d35);
		}

		private void ceb63301b9832f896a08a3dd276ad3ea6()
		{
			if (c4e4c496f46f70e0221399000a65266d9.visible != LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94(c914362963b5669274c6582a534308c62))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c4e4c496f46f70e0221399000a65266d9.visible = LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94(c914362963b5669274c6582a534308c62);
			}
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (c6bc59c1d0a8c70ee6b39aca5d7791ddc.visible != (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId == c914362963b5669274c6582a534308c62))
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									c6bc59c1d0a8c70ee6b39aca5d7791ddc.visible = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId == c914362963b5669274c6582a534308c62;
									return;
								}
							}
						}
						return;
					}
				}
			}
			c6bc59c1d0a8c70ee6b39aca5d7791ddc.visible = false;
		}

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
			ceb63301b9832f896a08a3dd276ad3ea6();
		}

		protected void c12b196ef16d3d89b666906481f435d35(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			ceb63301b9832f896a08a3dd276ad3ea6();
		}

		protected void c90080d1879587ccabd3d3bd05f11eb7e(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
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
				if (c914362963b5669274c6582a534308c62 != c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c90e08ff45bd89b1b852ef7a4959d640b(c914362963b5669274c6582a534308c62);
							return;
						}
					}
				}
				LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().ce30914cedf948c8ebefe3783fb6c7f87();
				return;
			}
		}

		protected void c1045053998022dd6ec2c03cc04d5d144(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PvPFlowView>().c5391a4d4b379929bb2d2d16aded03f79();
			LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c8f46bdc59faaa4c24f98ee46924af401(c914362963b5669274c6582a534308c62);
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Presence presence = LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cd36269e0c4619dc5307d8034050d3c8d(c62a53388af21c9e5e206591a30eb9f80);
			c4e4c496f46f70e0221399000a65266d9.visible = false;
			c6bc59c1d0a8c70ee6b39aca5d7791ddc.visible = false;
			if (presence == null)
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
				c914362963b5669274c6582a534308c62 = presence.mCharacterId;
				ce6ba2c1d352d37d3309feea279593241.text = presence.mCharacterName;
				ce1920b9e00f9e50c1bc7657ed14878cd.text = "LV." + presence.mCharacterLevel;
				ca2b2b6aa6c1023dab7d27ac79396193f.text = presence.mHonorPoint.ToString();
				ca65fbc8873a704a25420b48862b0d2f5.text = presence.mKillCount + "/" + presence.mDeathCount;
				c210e580cd8c55e4eeba39dde09195935.text = presence.mWinCount + "/" + presence.mLossCount;
				if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94(c914362963b5669274c6582a534308c62))
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
					c4e4c496f46f70e0221399000a65266d9.visible = true;
				}
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (presence.mCharacterId == c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_characterId)
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
						c6bc59c1d0a8c70ee6b39aca5d7791ddc.visible = true;
						cce1fabe7d424237606b41675015388a4.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
					}
				}
				else
				{
					cce1fabe7d424237606b41675015388a4.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
				}
				if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
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
					cce1fabe7d424237606b41675015388a4.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
					return;
				}
			}
		}
	}
}
