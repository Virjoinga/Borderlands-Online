using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class cc25c1ee12c4b33340a4c33ba3a4275c9 : c9f62278a5e2341872ad7373d9bb65f26
	{
		private int c914362963b5669274c6582a534308c62 = -1;

		protected TextField ce6ba2c1d352d37d3309feea279593241;

		protected TextField ce1920b9e00f9e50c1bc7657ed14878cd;

		protected TextField ca2b2b6aa6c1023dab7d27ac79396193f;

		protected TextField ca65fbc8873a704a25420b48862b0d2f5;

		protected TextField c210e580cd8c55e4eeba39dde09195935;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b c32a42dd0b87b4ea3aa32365c5d0b7a9d;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			ce6ba2c1d352d37d3309feea279593241 = movieClip.getChildByName<TextField>("tfname");
			ce1920b9e00f9e50c1bc7657ed14878cd = movieClip.getChildByName<TextField>("tflevel");
			ca2b2b6aa6c1023dab7d27ac79396193f = movieClip.getChildByName<TextField>("tfhonor");
			ca65fbc8873a704a25420b48862b0d2f5 = movieClip.getChildByName<TextField>("tfkilldeath");
			c210e580cd8c55e4eeba39dde09195935 = movieClip.getChildByName<TextField>("tfwindeath");
			c32a42dd0b87b4ea3aa32365c5d0b7a9d = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			c32a42dd0b87b4ea3aa32365c5d0b7a9d.c130648b59a0c8debea60aa153f844879(movieClip.getChildByName<MovieClip>("btn_Invite"));
			c32a42dd0b87b4ea3aa32365c5d0b7a9d.addEventListener(MouseEvent.CLICK, cb90bb1ae45086c6e25c4f443a8b97f6b);
		}

		protected override void c9f8eeb310eab54c590c996dd8e63e346()
		{
			base.c9f8eeb310eab54c590c996dd8e63e346();
		}

		protected void cb90bb1ae45086c6e25c4f443a8b97f6b(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
		{
			LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c9ae14989b238c7ea986761bc0a3353e2(c914362963b5669274c6582a534308c62);
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Presence presence = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().ce9b5878739f3b5cba4562c672e5555e1(c62a53388af21c9e5e206591a30eb9f80);
			c914362963b5669274c6582a534308c62 = presence.mCharacterId;
			if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c32a42dd0b87b4ea3aa32365c5d0b7a9d.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			}
			else
			{
				c32a42dd0b87b4ea3aa32365c5d0b7a9d.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			}
			ce6ba2c1d352d37d3309feea279593241.text = presence.mCharacterName;
			ce1920b9e00f9e50c1bc7657ed14878cd.text = "LV." + presence.mCharacterLevel;
			ca2b2b6aa6c1023dab7d27ac79396193f.text = presence.mHonorPoint.ToString();
			int num;
			if (presence.mDeathCount == 0)
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
				num = 0;
			}
			else
			{
				num = presence.mKillCount / presence.mDeathCount;
			}
			ca65fbc8873a704a25420b48862b0d2f5.text = ((double)num).ToString("0.0000");
			int num2;
			if (presence.mLossCount == 0)
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
				num2 = 0;
			}
			else
			{
				num2 = presence.mWinCount / presence.mLossCount;
			}
			c210e580cd8c55e4eeba39dde09195935.text = ((double)num2).ToString("0.0000");
		}
	}
}
