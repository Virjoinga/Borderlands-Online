using pumpkin.display;
using pumpkin.events;

namespace A
{
	public class c9f78f655c4c54b13154033525ab8adab : c8e81fbb352f6a532c1fd4a46305e91f9
	{
		private class cc8cce5d504fefc15577469bece43a6c2 : c196099a1254db61d3be10d70e14e7422
		{
			protected MovieClip c13ea7254c15348a03e7ecc980894c2be;

			private MovieClip c10acfdefcdd3bd3a64c9225600b92c58;

			private MovieClip cd932c3eff52322972cd13fc75a71a329;

			private MovieClip c39968dd6d0aa91bdfbc1cd3e86be55f1;

			private int c10d260deb7c1cba43d6ab48f23a5b648 = 1;

			private bool cb2ee34d990c1778b589578f3691f2b9e = true;

			public virtual bool c150264a18c2cb408479d3f072cac8cc1
			{
				get
				{
					if (c13ea7254c15348a03e7ecc980894c2be != null)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								if (1 == 0)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								return c13ea7254c15348a03e7ecc980894c2be.visible;
							}
						}
					}
					return false;
				}
				set
				{
					if (c13ea7254c15348a03e7ecc980894c2be == null)
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
						c13ea7254c15348a03e7ecc980894c2be.visible = value;
						return;
					}
				}
			}

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				c13ea7254c15348a03e7ecc980894c2be = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
				c10acfdefcdd3bd3a64c9225600b92c58 = c13ea7254c15348a03e7ecc980894c2be.getChildByName<MovieClip>("MateInfo1");
				cd932c3eff52322972cd13fc75a71a329 = c13ea7254c15348a03e7ecc980894c2be.getChildByName<MovieClip>("MateInfo2");
				c39968dd6d0aa91bdfbc1cd3e86be55f1 = c13ea7254c15348a03e7ecc980894c2be.getChildByName<MovieClip>("MateInfo3");
				c10acfdefcdd3bd3a64c9225600b92c58.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
				cd932c3eff52322972cd13fc75a71a329.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
				c39968dd6d0aa91bdfbc1cd3e86be55f1.addEventListener(MouseEvent.CLICK, ce6e90523914e3b1e1fe3bd32ac290b03);
				c10acfdefcdd3bd3a64c9225600b92c58.addEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
				cd932c3eff52322972cd13fc75a71a329.addEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
				c39968dd6d0aa91bdfbc1cd3e86be55f1.addEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
			}

			protected void c77de347f5cc9efb7b4cb59c10d1fcbd9(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				MovieClip movieClip = c3d202dee321219a80026dc3081fb3c86.currentTarget as MovieClip;
				if (movieClip == null)
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
					if (movieClip.getChildByName<MovieClip>("All") == null)
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
						if (movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus") == null)
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
							if (movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon") == null)
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
								c10d260deb7c1cba43d6ab48f23a5b648 %= 100;
								movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon")
									.alpha = 0.5f;
								movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health")
									.alpha = 0.5f;
								movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield")
									.alpha = 0.5f;
								movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon")
									.gotoAndStop(3);
								movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health")
									.gotoAndStop(c10d260deb7c1cba43d6ab48f23a5b648);
								movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield")
									.gotoAndStop(c10d260deb7c1cba43d6ab48f23a5b648);
								c10d260deb7c1cba43d6ab48f23a5b648++;
								return;
							}
						}
					}
				}
			}

			protected void ce6e90523914e3b1e1fe3bd32ac290b03(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				MovieClip movieClip = c3d202dee321219a80026dc3081fb3c86.currentTarget as MovieClip;
				if (movieClip == null)
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
					if (cb2ee34d990c1778b589578f3691f2b9e)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								movieClip.gotoAndPlay("IN");
								cb2ee34d990c1778b589578f3691f2b9e = false;
								return;
							}
						}
					}
					movieClip.gotoAndPlay("out");
					cb2ee34d990c1778b589578f3691f2b9e = true;
					return;
				}
			}
		}

		private cc8cce5d504fefc15577469bece43a6c2 c22b8f01656b50028849b8287b410da34;

		public c9f78f655c4c54b13154033525ab8adab(UniUIManager c532b9e27685f696d32331c089aec2fc2)
			: base(c532b9e27685f696d32331c089aec2fc2)
		{
			MovieClip c998c56e5cab278873f1a5722e79733da = c451ed1a0b8413e882bc56f9ab434e6ae.c8fa44ac86695940c4538ed5d6a372410("Team_mate_portrait.swf", "TeamMateInfo");
			c22b8f01656b50028849b8287b410da34 = new cc8cce5d504fefc15577469bece43a6c2();
			c22b8f01656b50028849b8287b410da34.c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
			c451ed1a0b8413e882bc56f9ab434e6ae.cb4341b3564e3d55dc9f38df4b813c5da(c22b8f01656b50028849b8287b410da34);
		}

		public override void cac7688b05e921e2be3f92479ba44b4a8()
		{
			base.cac7688b05e921e2be3f92479ba44b4a8();
			if (c22b8f01656b50028849b8287b410da34 == null)
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
				c451ed1a0b8413e882bc56f9ab434e6ae.c27542a6dc8f97862ef53db1d4f3a6db8(c22b8f01656b50028849b8287b410da34);
				c22b8f01656b50028849b8287b410da34 = null;
				return;
			}
		}
	}
}
