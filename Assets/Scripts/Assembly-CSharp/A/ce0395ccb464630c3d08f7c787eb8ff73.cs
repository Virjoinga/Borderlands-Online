using System.Collections.Generic;
using Core;
using pumpkin.display;

namespace A
{
	public class ce0395ccb464630c3d08f7c787eb8ff73
	{
		private DisplayObjectContainer cff782fca2be8c2b6ccc73e13c4667fda;

		private Dictionary<string, DisplayObjectContainer> c7bbb8206da2f089f04b8ab1bbf92d645;

		public ce0395ccb464630c3d08f7c787eb8ff73(DisplayObjectContainer c3cb1f1345dbfd94c51709a9b2e9a9704)
		{
			if (c3cb1f1345dbfd94c51709a9b2e9a9704 == null)
			{
				return;
			}
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
				c7bbb8206da2f089f04b8ab1bbf92d645 = new Dictionary<string, DisplayObjectContainer>();
				cff782fca2be8c2b6ccc73e13c4667fda = c3cb1f1345dbfd94c51709a9b2e9a9704;
				return;
			}
		}

		private ce0395ccb464630c3d08f7c787eb8ff73()
		{
		}

		public void ca20d02cf332b34551703e6ea1a479822()
		{
			cff782fca2be8c2b6ccc73e13c4667fda.removeAllChildren();
			c7bbb8206da2f089f04b8ab1bbf92d645.Clear();
		}

		public int cbc53582735b798af68be1963fbb04755(string c5fe690777bf5dec9374fa61ab6703175)
		{
			if (c7bbb8206da2f089f04b8ab1bbf92d645.ContainsKey(c5fe690777bf5dec9374fa61ab6703175))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return cff782fca2be8c2b6ccc73e13c4667fda.getChildIndex(c7bbb8206da2f089f04b8ab1bbf92d645[c5fe690777bf5dec9374fa61ab6703175]);
					}
				}
			}
			DisplayObjectContainer displayObjectContainer = new DisplayObjectContainer();
			displayObjectContainer.name = c5fe690777bf5dec9374fa61ab6703175;
			int count = c7bbb8206da2f089f04b8ab1bbf92d645.Count;
			cff782fca2be8c2b6ccc73e13c4667fda.addChildAt(displayObjectContainer, count);
			c7bbb8206da2f089f04b8ab1bbf92d645.Add(c5fe690777bf5dec9374fa61ab6703175, displayObjectContainer);
			return count;
		}

		public bool c1a18960a16cc8dc828c90c3843668810(DisplayObject c7c66aa9117293e26b403f87b05221fde, string c8ef427bb0ef8319952faf8140a23810a)
		{
			if (!c7bbb8206da2f089f04b8ab1bbf92d645.ContainsKey(c8ef427bb0ef8319952faf8140a23810a))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "You should create layer first: " + c8ef427bb0ef8319952faf8140a23810a);
						return false;
					}
				}
			}
			c7bbb8206da2f089f04b8ab1bbf92d645[c8ef427bb0ef8319952faf8140a23810a].addChild(c7c66aa9117293e26b403f87b05221fde);
			return true;
		}

		public bool c3ed76b6dadc5911369ecc3ec2f721b0f(DisplayObject c7c66aa9117293e26b403f87b05221fde, string cb4dc8a66214c09e6dc87bb9c8bb0f26c)
		{
			if (!c7bbb8206da2f089f04b8ab1bbf92d645.ContainsKey(cb4dc8a66214c09e6dc87bb9c8bb0f26c))
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
						return false;
					}
				}
			}
			if (!c7bbb8206da2f089f04b8ab1bbf92d645[cb4dc8a66214c09e6dc87bb9c8bb0f26c].contains(c7c66aa9117293e26b403f87b05221fde))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
			c7bbb8206da2f089f04b8ab1bbf92d645[cb4dc8a66214c09e6dc87bb9c8bb0f26c].removeChild(c7c66aa9117293e26b403f87b05221fde);
			return true;
		}

		public void c858d49c3aa8b8f3ea460cdf0aaa021bc(DisplayObject c7c66aa9117293e26b403f87b05221fde)
		{
			using (Dictionary<string, DisplayObjectContainer>.Enumerator enumerator = c7bbb8206da2f089f04b8ab1bbf92d645.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, DisplayObjectContainer> current = enumerator.Current;
					if (!current.Value.contains(c7c66aa9117293e26b403f87b05221fde))
					{
						continue;
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
						current.Value.removeChild(c7c66aa9117293e26b403f87b05221fde);
						return;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}

		public void cc371531e3f2794060d2ac285ffce8c04(bool c74232243aff1dcbf2e8fc243633bb51a, string cb4dc8a66214c09e6dc87bb9c8bb0f26c)
		{
			if (!c7bbb8206da2f089f04b8ab1bbf92d645.ContainsKey(cb4dc8a66214c09e6dc87bb9c8bb0f26c))
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
						return;
					}
				}
			}
			c7bbb8206da2f089f04b8ab1bbf92d645[cb4dc8a66214c09e6dc87bb9c8bb0f26c].visible = c74232243aff1dcbf2e8fc243633bb51a;
		}
	}
}
