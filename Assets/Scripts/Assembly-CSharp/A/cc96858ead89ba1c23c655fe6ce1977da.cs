using pumpkin.display;
using pumpkin.events;

namespace A
{
	public class cc96858ead89ba1c23c655fe6ce1977da : c8e81fbb352f6a532c1fd4a46305e91f9
	{
		private class c62d0f3aa08c4b304878902c4713bf63a : c196099a1254db61d3be10d70e14e7422
		{
			protected MovieClip c13ea7254c15348a03e7ecc980894c2be;

			private MovieClip c17b976c95647469d68efce198fd4690b;

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				c13ea7254c15348a03e7ecc980894c2be = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
				c17b976c95647469d68efce198fd4690b = c13ea7254c15348a03e7ecc980894c2be.getChildByName<MovieClip>("mcNPCtalkframe");
				c13ea7254c15348a03e7ecc980894c2be.gotoAndPlay("fadein");
				c17b976c95647469d68efce198fd4690b.gotoAndPlay("normal");
				c17b976c95647469d68efce198fd4690b.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
			}

			private void ce6e90523914e3b1e1fe3bd32ac290b03(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				c13ea7254c15348a03e7ecc980894c2be.gotoAndPlay("fadeout");
				c13ea7254c15348a03e7ecc980894c2be.addFrameScript("fadeoutEnd", ca45aa4038153928bb3c25fc71e6c45e1);
			}

			private void ca45aa4038153928bb3c25fc71e6c45e1(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				c13ea7254c15348a03e7ecc980894c2be.removeFrameScript("fadeoutEnd", ca45aa4038153928bb3c25fc71e6c45e1);
				c13ea7254c15348a03e7ecc980894c2be.gotoAndPlay("fadein");
			}
		}

		private c62d0f3aa08c4b304878902c4713bf63a c61076bb393637832baf123bec92c9bd8;

		public cc96858ead89ba1c23c655fe6ce1977da(UniUIManager c532b9e27685f696d32331c089aec2fc2)
			: base(c532b9e27685f696d32331c089aec2fc2)
		{
			MovieClip c998c56e5cab278873f1a5722e79733da = c451ed1a0b8413e882bc56f9ab434e6ae.c8fa44ac86695940c4538ed5d6a372410("match_making.swf", "NPCAnima");
			c61076bb393637832baf123bec92c9bd8 = new c62d0f3aa08c4b304878902c4713bf63a();
			c61076bb393637832baf123bec92c9bd8.c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
			c451ed1a0b8413e882bc56f9ab434e6ae.cb4341b3564e3d55dc9f38df4b813c5da(c61076bb393637832baf123bec92c9bd8);
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			if (c61076bb393637832baf123bec92c9bd8 == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c451ed1a0b8413e882bc56f9ab434e6ae.c27542a6dc8f97862ef53db1d4f3a6db8(c61076bb393637832baf123bec92c9bd8);
				c61076bb393637832baf123bec92c9bd8 = null;
				return;
			}
		}
	}
}
