using Core;
using UnityEngine;
using pumpkin.display;

namespace A
{
	public class ca34081ace93927b1656a62bbab14a6f3
	{
		public const float c2834a73e29d61198208a0fe6999c13d2 = 1280f;

		public const float c633c7abec464fa1092c4d569e1c4ee7e = 720f;

		private static ca34081ace93927b1656a62bbab14a6f3 cd55c99b38807cf15a2969975dd02178c;

		protected Stage c913c155671285d58b92f58bfa6f90fed;

		protected float c886f190606e50482593ad1814500f28e = 1f;

		public float c733505907f25eda0c5e1552782bb49e6 = 1280f;

		public float c4d3a4955dfb0902145e8a6f501bc9f7a = 720f;

		protected ce0395ccb464630c3d08f7c787eb8ff73 cdae7e73de775b50bd0f5b0b12d27d854;

		public static ca34081ace93927b1656a62bbab14a6f3 ccf24681862bae286c19d5c9b16296be5
		{
			get
			{
				if (cd55c99b38807cf15a2969975dd02178c == null)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					cd55c99b38807cf15a2969975dd02178c = new ca34081ace93927b1656a62bbab14a6f3();
				}
				return cd55c99b38807cf15a2969975dd02178c;
			}
		}

		public Stage c1e172bfb5184630068d909f8fe1e728c
		{
			get
			{
				return c913c155671285d58b92f58bfa6f90fed;
			}
			set
			{
				c913c155671285d58b92f58bfa6f90fed = value;
				if (c913c155671285d58b92f58bfa6f90fed != null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							if (cdae7e73de775b50bd0f5b0b12d27d854 == null)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										cdae7e73de775b50bd0f5b0b12d27d854 = new ce0395ccb464630c3d08f7c787eb8ff73(c913c155671285d58b92f58bfa6f90fed);
										return;
									}
								}
							}
							return;
						}
					}
				}
				cdae7e73de775b50bd0f5b0b12d27d854 = c8cd4a57ff14339cb81720fb04f7aedd2.c7088de59e49f7108f520cf7e0bae167e;
			}
		}

		public float c38416c96b869af0e164ff13994b8aa12
		{
			get
			{
				return c886f190606e50482593ad1814500f28e;
			}
		}

		public float cbc610632d62314b5dee9dfab820ccf7d
		{
			get
			{
				return c733505907f25eda0c5e1552782bb49e6;
			}
		}

		public float c5b74b332e25262d06ef731df64d69ccc
		{
			get
			{
				return c4d3a4955dfb0902145e8a6f501bc9f7a;
			}
		}

		private ca34081ace93927b1656a62bbab14a6f3()
		{
		}

		public void OnScreenResize(float fSceenW, float fScreenH)
		{
			float num = fSceenW / 1280f;
			float num2 = fScreenH / 720f;
			c886f190606e50482593ad1814500f28e = Mathf.Min(num, num2);
			c733505907f25eda0c5e1552782bb49e6 = 1280f * num / c886f190606e50482593ad1814500f28e;
			c4d3a4955dfb0902145e8a6f501bc9f7a = 720f * num2 / c886f190606e50482593ad1814500f28e;
		}

		private void c6f3a8aae78cd9ecf56b81b2bf2388b0f(DisplayObject cd443e11d58410853a275d8d2a34f3efc, Vector2 ced197c6e46ee7f24766c906dede9228a, ref Vector2 c6755cfc1b50ffa48b9850fd69cb05c78)
		{
			if (cd443e11d58410853a275d8d2a34f3efc == null)
			{
				while (true)
				{
					switch (4)
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
			c6755cfc1b50ffa48b9850fd69cb05c78.x = ced197c6e46ee7f24766c906dede9228a.x - cd443e11d58410853a275d8d2a34f3efc.x;
			c6755cfc1b50ffa48b9850fd69cb05c78.y = ced197c6e46ee7f24766c906dede9228a.y - cd443e11d58410853a275d8d2a34f3efc.y;
			c6f3a8aae78cd9ecf56b81b2bf2388b0f(cd443e11d58410853a275d8d2a34f3efc.parent, c6755cfc1b50ffa48b9850fd69cb05c78, ref c6755cfc1b50ffa48b9850fd69cb05c78);
		}

		private void c11cc650980661a16ca098e39d897687c(DisplayObject cd443e11d58410853a275d8d2a34f3efc, Vector2 ced197c6e46ee7f24766c906dede9228a, ref Vector2 c6755cfc1b50ffa48b9850fd69cb05c78)
		{
			if (cd443e11d58410853a275d8d2a34f3efc == null)
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
						return;
					}
				}
			}
			c6755cfc1b50ffa48b9850fd69cb05c78.x = ced197c6e46ee7f24766c906dede9228a.x + cd443e11d58410853a275d8d2a34f3efc.x;
			c6755cfc1b50ffa48b9850fd69cb05c78.y = ced197c6e46ee7f24766c906dede9228a.y + cd443e11d58410853a275d8d2a34f3efc.y;
			c11cc650980661a16ca098e39d897687c(cd443e11d58410853a275d8d2a34f3efc.parent, c6755cfc1b50ffa48b9850fd69cb05c78, ref c6755cfc1b50ffa48b9850fd69cb05c78);
		}

		public Vector2 c88ec770b25554e17182648d69403ceb1(DisplayObject cd443e11d58410853a275d8d2a34f3efc, Vector2 ced197c6e46ee7f24766c906dede9228a)
		{
			Vector2 c6755cfc1b50ffa48b9850fd69cb05c = Vector2.zero;
			c6f3a8aae78cd9ecf56b81b2bf2388b0f(cd443e11d58410853a275d8d2a34f3efc, ced197c6e46ee7f24766c906dede9228a, ref c6755cfc1b50ffa48b9850fd69cb05c);
			return c6755cfc1b50ffa48b9850fd69cb05c;
		}

		public Vector2 c46e387bea9111b07d3d0e2e52548626c(DisplayObject cd443e11d58410853a275d8d2a34f3efc, Vector2 ced197c6e46ee7f24766c906dede9228a)
		{
			Vector2 c6755cfc1b50ffa48b9850fd69cb05c = Vector2.zero;
			c11cc650980661a16ca098e39d897687c(cd443e11d58410853a275d8d2a34f3efc, ced197c6e46ee7f24766c906dede9228a, ref c6755cfc1b50ffa48b9850fd69cb05c);
			return c6755cfc1b50ffa48b9850fd69cb05c;
		}

		public bool c1a18960a16cc8dc828c90c3843668810(DisplayObject c7c66aa9117293e26b403f87b05221fde, string cb4dc8a66214c09e6dc87bb9c8bb0f26c)
		{
			if (c1e172bfb5184630068d909f8fe1e728c != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (cdae7e73de775b50bd0f5b0b12d27d854 != null)
				{
					cdae7e73de775b50bd0f5b0b12d27d854.c1a18960a16cc8dc828c90c3843668810(c7c66aa9117293e26b403f87b05221fde, cb4dc8a66214c09e6dc87bb9c8bb0f26c);
					return false;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "FlashGlobal stage is ";
			array[1] = c913c155671285d58b92f58bfa6f90fed;
			array[2] = " or _layerManager is ";
			array[3] = cdae7e73de775b50bd0f5b0b12d27d854;
			array[4] = "!!";
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
			return false;
		}

		public int cbc53582735b798af68be1963fbb04755(string c5fe690777bf5dec9374fa61ab6703175)
		{
			if (cdae7e73de775b50bd0f5b0b12d27d854 != null)
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
						return cdae7e73de775b50bd0f5b0b12d27d854.cbc53582735b798af68be1963fbb04755(c5fe690777bf5dec9374fa61ab6703175);
					}
				}
			}
			return -1;
		}

		public void c3ed76b6dadc5911369ecc3ec2f721b0f(DisplayObject c7c66aa9117293e26b403f87b05221fde, string cb4dc8a66214c09e6dc87bb9c8bb0f26c)
		{
			if (cdae7e73de775b50bd0f5b0b12d27d854 == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				cdae7e73de775b50bd0f5b0b12d27d854.c3ed76b6dadc5911369ecc3ec2f721b0f(c7c66aa9117293e26b403f87b05221fde, cb4dc8a66214c09e6dc87bb9c8bb0f26c);
				return;
			}
		}

		public void c858d49c3aa8b8f3ea460cdf0aaa021bc(DisplayObject c7c66aa9117293e26b403f87b05221fde)
		{
			if (cdae7e73de775b50bd0f5b0b12d27d854 == null)
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
				cdae7e73de775b50bd0f5b0b12d27d854.c858d49c3aa8b8f3ea460cdf0aaa021bc(c7c66aa9117293e26b403f87b05221fde);
				return;
			}
		}

		public void cc371531e3f2794060d2ac285ffce8c04(bool c74232243aff1dcbf2e8fc243633bb51a, string cb4dc8a66214c09e6dc87bb9c8bb0f26c)
		{
			if (cdae7e73de775b50bd0f5b0b12d27d854 == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				cdae7e73de775b50bd0f5b0b12d27d854.cc371531e3f2794060d2ac285ffce8c04(c74232243aff1dcbf2e8fc243633bb51a, cb4dc8a66214c09e6dc87bb9c8bb0f26c);
				return;
			}
		}
	}
}
