using UnityEngine;
using pumpkin.display;
using pumpkin.events;

namespace A
{
	public class c340ad4e1f1707c51248b1d3b50723a7e : EventDispatcher
	{
		private const string c79ef71b0452b27642e476435a6988884 = "DragManagerLayer";

		private static c340ad4e1f1707c51248b1d3b50723a7e cd55c99b38807cf15a2969975dd02178c;

		public bool c30baced45c2a7e71e9d09ac697bca37c;

		public int c1d62bccc6699f89fce837c9d839a3727;

		public int c3dd3e7575a554a9f9c61e3b29c480ca0;

		public object c23b4e0b18658b25fecb7b4ea24320303;

		public object cd54795bb5ce40bec40f7a0e1f36b10f2;

		private bool c9fdc3ee07043e1a89af8ac4e9e51fb1d;

		private object cc1e82e2b19483af134612fb0c24142e3;

		private MovieClip c640836cc925d59650a72d53cc3825d87;

		private DisplayObjectContainer c44a986207614903a79feeeb2b88da94c;

		private MovieClip ce09b2994f37b277a1b60943ccbc53ca1;

		public static c340ad4e1f1707c51248b1d3b50723a7e ccf24681862bae286c19d5c9b16296be5
		{
			get
			{
				if (cd55c99b38807cf15a2969975dd02178c == null)
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
					cd55c99b38807cf15a2969975dd02178c = new c340ad4e1f1707c51248b1d3b50723a7e();
				}
				return cd55c99b38807cf15a2969975dd02178c;
			}
		}

		public bool c93fcfbc31b4dd1606b1af2101ee270d0
		{
			get
			{
				return c9fdc3ee07043e1a89af8ac4e9e51fb1d;
			}
		}

		public object c591d56a94543e3559945c497f37126c4
		{
			get
			{
				return cc1e82e2b19483af134612fb0c24142e3;
			}
		}

		public MovieClip c82fcbab5e578dc3a31c1f662916bd87e
		{
			get
			{
				return c640836cc925d59650a72d53cc3825d87;
			}
		}

		private c340ad4e1f1707c51248b1d3b50723a7e()
		{
			c44a986207614903a79feeeb2b88da94c = ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c;
		}

		public MovieClip c7ad56e119144cb12a7a6b382776abd2d(MovieClip ce09b2994f37b277a1b60943ccbc53ca1, object cfe0a1153f61dcdf419049830449301da, object c591d56a94543e3559945c497f37126c4, object cd54795bb5ce40bec40f7a0e1f36b10f2, DisplayObject cf14fc6a1402b43acfd46ee09dc465918, bool c4da9a63bd7967d982787d7f43606f5d6)
		{
			if (ce09b2994f37b277a1b60943ccbc53ca1 == null)
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
						return null;
					}
				}
			}
			c30baced45c2a7e71e9d09ac697bca37c = true;
			MovieClip movieClip = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
			if (cfe0a1153f61dcdf419049830449301da is MovieClip)
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
				MovieClip movieClip2 = cfe0a1153f61dcdf419049830449301da as MovieClip;
				movieClip = movieClip2.newInstance();
				movieClip.mouseEnabled = false;
				if (movieClip2.isPlaying)
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
					movieClip.gotoAndPlay(movieClip2.currentFrame);
				}
				else
				{
					movieClip.gotoAndStop(movieClip2.currentFrame);
				}
			}
			else if (cfe0a1153f61dcdf419049830449301da is c7beefc397f483dc0b72dcd3e6bdcf929)
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
				pumpkin.display.Sprite displayObject = new pumpkin.display.Sprite();
				(cfe0a1153f61dcdf419049830449301da as c7beefc397f483dc0b72dcd3e6bdcf929).cebb7bc7852c7c7427532f3bd680c245e(displayObject);
				movieClip = new MovieClip();
				movieClip.stopAll();
				movieClip.addChild(displayObject);
				movieClip.mouseEnabled = false;
			}
			else if (cfe0a1153f61dcdf419049830449301da == null)
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
				movieClip = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
			}
			c640836cc925d59650a72d53cc3825d87 = movieClip;
			ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(c640836cc925d59650a72d53cc3825d87, "DragManagerLayer");
			int num;
			if (c4da9a63bd7967d982787d7f43606f5d6)
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
				num = -Mathf.FloorToInt(cf14fc6a1402b43acfd46ee09dc465918.width / 2f);
			}
			else
			{
				num = 0;
			}
			c1d62bccc6699f89fce837c9d839a3727 = num;
			int num2;
			if (c4da9a63bd7967d982787d7f43606f5d6)
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
				num2 = -Mathf.FloorToInt(cf14fc6a1402b43acfd46ee09dc465918.height / 2f);
			}
			else
			{
				num2 = 0;
			}
			c3dd3e7575a554a9f9c61e3b29c480ca0 = num2;
			if (cf14fc6a1402b43acfd46ee09dc465918 != null)
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
				if (cf14fc6a1402b43acfd46ee09dc465918 != movieClip)
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
					if (movieClip != null)
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
						Vector2 vector = new Vector2(ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c.mouseX, ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c.mouseY);
						movieClip.x = vector.x + (float)c1d62bccc6699f89fce837c9d839a3727;
						movieClip.y = vector.y + (float)c3dd3e7575a554a9f9c61e3b29c480ca0;
					}
				}
			}
			c80768e67d0c8f957006a3589092c4cc2(c591d56a94543e3559945c497f37126c4, cd54795bb5ce40bec40f7a0e1f36b10f2);
			if (ce09b2994f37b277a1b60943ccbc53ca1 != null)
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
				this.ce09b2994f37b277a1b60943ccbc53ca1 = ce09b2994f37b277a1b60943ccbc53ca1;
				this.ce09b2994f37b277a1b60943ccbc53ca1.visible = ce09b2994f37b277a1b60943ccbc53ca1.visible;
			}
			c6ae7f7e977a53956ec405b6f612a3c3d();
			c44a986207614903a79feeeb2b88da94c.addEventListener(MouseEvent.MOUSE_MOVE, cb55d296d3226488642b6492ba833c859);
			c44a986207614903a79feeeb2b88da94c.addEventListener(MouseEvent.MOUSE_DOWN, c6fe8f961da8397bdba81dfc34c3547d2);
			return c640836cc925d59650a72d53cc3825d87;
		}

		public void ccb55a3d34170d32918df66b9fee4f77c()
		{
			ced8acacc699e809f1609d0c32765422e(false);
		}

		public void c80768e67d0c8f957006a3589092c4cc2(object c591d56a94543e3559945c497f37126c4, object cd54795bb5ce40bec40f7a0e1f36b10f2)
		{
			c9fdc3ee07043e1a89af8ac4e9e51fb1d = true;
			cc1e82e2b19483af134612fb0c24142e3 = c591d56a94543e3559945c497f37126c4;
			this.cd54795bb5ce40bec40f7a0e1f36b10f2 = cd54795bb5ce40bec40f7a0e1f36b10f2;
			c23b4e0b18658b25fecb7b4ea24320303 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("dragBegin", c591d56a94543e3559945c497f37126c4));
		}

		public void c4fdd007303fd7b5c133404b463447e39()
		{
			ced8acacc699e809f1609d0c32765422e(true);
		}

		public void c04cc4c530372db0a04d942ee08561daa()
		{
			if (!c93fcfbc31b4dd1606b1af2101ee270d0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				cf7ddb9649a026017b203800830b8d4a5();
				return;
			}
		}

		private void cb55d296d3226488642b6492ba833c859(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cf7ddb9649a026017b203800830b8d4a5();
		}

		private void cf7ddb9649a026017b203800830b8d4a5()
		{
			if (c640836cc925d59650a72d53cc3825d87 == null)
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
				c640836cc925d59650a72d53cc3825d87.x = c640836cc925d59650a72d53cc3825d87.parent.mouseX + (float)c1d62bccc6699f89fce837c9d839a3727;
				c640836cc925d59650a72d53cc3825d87.y = c640836cc925d59650a72d53cc3825d87.parent.mouseY + (float)c3dd3e7575a554a9f9c61e3b29c480ca0;
				return;
			}
		}

		private void ced8acacc699e809f1609d0c32765422e(bool c45f4ff3e52769613f7fe87136374eecf)
		{
			if (!c9fdc3ee07043e1a89af8ac4e9e51fb1d)
			{
				while (true)
				{
					switch (5)
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
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("dragEnd", new cdaa8be71633914d75e27ba7c238d88d3(c45f4ff3e52769613f7fe87136374eecf, cc1e82e2b19483af134612fb0c24142e3, c23b4e0b18658b25fecb7b4ea24320303, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e)));
			cecdbba337eca9563c514de5a01cd4bf6();
		}

		private void cecdbba337eca9563c514de5a01cd4bf6()
		{
			c23b4e0b18658b25fecb7b4ea24320303 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			if (c30baced45c2a7e71e9d09ac697bca37c)
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
				if (c640836cc925d59650a72d53cc3825d87 != null)
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
					c640836cc925d59650a72d53cc3825d87.parent.removeChild(c640836cc925d59650a72d53cc3825d87);
				}
			}
			c640836cc925d59650a72d53cc3825d87 = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
			cc1e82e2b19483af134612fb0c24142e3 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			c44a986207614903a79feeeb2b88da94c.removeEventListener(MouseEvent.MOUSE_MOVE, cb55d296d3226488642b6492ba833c859);
			c44a986207614903a79feeeb2b88da94c.removeEventListener(MouseEvent.MOUSE_DOWN, c6fe8f961da8397bdba81dfc34c3547d2);
			c44a986207614903a79feeeb2b88da94c.removeEventListener(MouseEvent.MOUSE_UP, cd6b59f719154bf344fe0991398ae19ed);
			c1d62bccc6699f89fce837c9d839a3727 = (c3dd3e7575a554a9f9c61e3b29c480ca0 = 0);
			c9fdc3ee07043e1a89af8ac4e9e51fb1d = false;
		}

		private void c6fe8f961da8397bdba81dfc34c3547d2(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c6ae7f7e977a53956ec405b6f612a3c3d();
		}

		public void c6ae7f7e977a53956ec405b6f612a3c3d()
		{
			if (c23b4e0b18658b25fecb7b4ea24320303 == null)
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
						c44a986207614903a79feeeb2b88da94c.removeEventListener(MouseEvent.MOUSE_UP, cd6b59f719154bf344fe0991398ae19ed);
						return;
					}
				}
			}
			c44a986207614903a79feeeb2b88da94c.addEventListener(MouseEvent.MOUSE_UP, cd6b59f719154bf344fe0991398ae19ed);
		}

		private void cd6b59f719154bf344fe0991398ae19ed(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			ccb55a3d34170d32918df66b9fee4f77c();
		}

		public void cd93285db16841148ed53a5bbeb35cf20()
		{
			c44a986207614903a79feeeb2b88da94c = ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c;
			ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("DragManagerLayer");
		}
	}
}
