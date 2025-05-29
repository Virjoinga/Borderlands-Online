using pumpkin.display;

namespace A
{
	public class c91aff805303ae5b9d8575bad699e1a6e : c8e81fbb352f6a532c1fd4a46305e91f9
	{
		private class c765c4f3c438e194a1e1c5bfa34a2b6dc : c196099a1254db61d3be10d70e14e7422
		{
			protected MovieClip c13ea7254c15348a03e7ecc980894c2be;

			private MovieClip c92608184a1d5af9305739edd89be1dac;

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				c13ea7254c15348a03e7ecc980894c2be = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
				c13ea7254c15348a03e7ecc980894c2be.gotoAndPlay("fadein");
				c92608184a1d5af9305739edd89be1dac = c13ea7254c15348a03e7ecc980894c2be.getChildByName<MovieClip>("mc_total");
				c92608184a1d5af9305739edd89be1dac.gotoAndPlay("show detail");
			}
		}

		private c765c4f3c438e194a1e1c5bfa34a2b6dc c5fb8650f62813b3602950462c7848231;

		public c91aff805303ae5b9d8575bad699e1a6e(UniUIManager c532b9e27685f696d32331c089aec2fc2)
			: base(c532b9e27685f696d32331c089aec2fc2)
		{
			MovieClip c998c56e5cab278873f1a5722e79733da = c451ed1a0b8413e882bc56f9ab434e6ae.c8fa44ac86695940c4538ed5d6a372410("Wrap Up.swf", "Whole");
			c5fb8650f62813b3602950462c7848231 = new c765c4f3c438e194a1e1c5bfa34a2b6dc();
			c5fb8650f62813b3602950462c7848231.c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
			c451ed1a0b8413e882bc56f9ab434e6ae.cb4341b3564e3d55dc9f38df4b813c5da(c5fb8650f62813b3602950462c7848231);
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			if (c5fb8650f62813b3602950462c7848231 == null)
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
				c451ed1a0b8413e882bc56f9ab434e6ae.c27542a6dc8f97862ef53db1d4f3a6db8(c5fb8650f62813b3602950462c7848231);
				c5fb8650f62813b3602950462c7848231 = null;
				return;
			}
		}
	}
}
