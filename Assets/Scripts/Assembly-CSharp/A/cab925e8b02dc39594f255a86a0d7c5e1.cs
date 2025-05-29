using System.Collections.Generic;
using pumpkin.events;

namespace A
{
	public class cab925e8b02dc39594f255a86a0d7c5e1 : EventDispatcher
	{
		public static Dictionary<string, cab925e8b02dc39594f255a86a0d7c5e1> cbe519c330bf0122d5fdb757b59e95216 = new Dictionary<string, cab925e8b02dc39594f255a86a0d7c5e1>();

		public string cd99af21e22e356018b8f72d4a7e4872a;

		public c82f7c0afbcfc8c5382a8c6daa9365b7b cbe2d3a52e3b467c552460216e94ddc82;

		protected List<c82f7c0afbcfc8c5382a8c6daa9365b7b> cfb1b70875043a3bbab17a383ac9b9fb9;

		public int c5220d4b10e7dadd4770a64c797f91fc9
		{
			get
			{
				return cfb1b70875043a3bbab17a383ac9b9fb9.Count;
			}
		}

		public object c591d56a94543e3559945c497f37126c4
		{
			get
			{
				object result;
				if (cbe2d3a52e3b467c552460216e94ddc82 == null)
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
					result = null;
				}
				else
				{
					result = cbe2d3a52e3b467c552460216e94ddc82.c591d56a94543e3559945c497f37126c4;
				}
				return result;
			}
		}

		public int c4faf30651c41fe92fdecb4457d3d6fa5
		{
			get
			{
				return cfb1b70875043a3bbab17a383ac9b9fb9.IndexOf(cbe2d3a52e3b467c552460216e94ddc82);
			}
		}

		public cab925e8b02dc39594f255a86a0d7c5e1(string c5fe690777bf5dec9374fa61ab6703175)
		{
			cd99af21e22e356018b8f72d4a7e4872a = c5fe690777bf5dec9374fa61ab6703175;
			cfb1b70875043a3bbab17a383ac9b9fb9 = new List<c82f7c0afbcfc8c5382a8c6daa9365b7b>();
		}

		public static cab925e8b02dc39594f255a86a0d7c5e1 cd4833052cc4daf5b269e37eb1d8262d9(string c5fe690777bf5dec9374fa61ab6703175)
		{
			cab925e8b02dc39594f255a86a0d7c5e1 c7088de59e49f7108f520cf7e0bae167e = cb0d1c1a94fde85b4e9d18fca0b119505.c7088de59e49f7108f520cf7e0bae167e;
			if (cbe519c330bf0122d5fdb757b59e95216.ContainsKey(c5fe690777bf5dec9374fa61ab6703175.ToLower()))
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
				c7088de59e49f7108f520cf7e0bae167e = cbe519c330bf0122d5fdb757b59e95216[c5fe690777bf5dec9374fa61ab6703175.ToLower()];
			}
			else
			{
				c7088de59e49f7108f520cf7e0bae167e = new cab925e8b02dc39594f255a86a0d7c5e1(c5fe690777bf5dec9374fa61ab6703175);
				cbe519c330bf0122d5fdb757b59e95216.Add(c5fe690777bf5dec9374fa61ab6703175.ToLower(), c7088de59e49f7108f520cf7e0bae167e);
			}
			return c7088de59e49f7108f520cf7e0bae167e;
		}

		public void c944ce396befee000aaf19ada19b929c3(c82f7c0afbcfc8c5382a8c6daa9365b7b cc5b2a83f0ff489309eb5bc89970fb973)
		{
			cae286eca4fc7200a84038485c394f478(cc5b2a83f0ff489309eb5bc89970fb973);
			cfb1b70875043a3bbab17a383ac9b9fb9.Add(cc5b2a83f0ff489309eb5bc89970fb973);
			if (cc5b2a83f0ff489309eb5bc89970fb973.c9c364a8fd1f013589fea518a3924e711)
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
				cdb38ab0e0853152b8697b4110b2dba59(cc5b2a83f0ff489309eb5bc89970fb973);
			}
			cc5b2a83f0ff489309eb5bc89970fb973.addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c94c8f66b7e538fcda39ef0fb7296baad, false);
			cc5b2a83f0ff489309eb5bc89970fb973.addEventListener(MouseEvent.CLICK, c150a5f7ef9e027d1fbcbf9d51dd4bb8c, false);
		}

		public void cae286eca4fc7200a84038485c394f478(c82f7c0afbcfc8c5382a8c6daa9365b7b cc5b2a83f0ff489309eb5bc89970fb973)
		{
			cfb1b70875043a3bbab17a383ac9b9fb9.Remove(cc5b2a83f0ff489309eb5bc89970fb973);
			cc5b2a83f0ff489309eb5bc89970fb973.removeEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, c94c8f66b7e538fcda39ef0fb7296baad, false);
			cc5b2a83f0ff489309eb5bc89970fb973.removeEventListener(MouseEvent.CLICK, c150a5f7ef9e027d1fbcbf9d51dd4bb8c, false);
		}

		public c82f7c0afbcfc8c5382a8c6daa9365b7b c14935a199e1f7bae2eaa71b86bf60331(int c5612a459a84ffdb41c885401433cd62d)
		{
			return cfb1b70875043a3bbab17a383ac9b9fb9[c5612a459a84ffdb41c885401433cd62d];
		}

		public bool cebce50b7b5316e383f9350f76837e934(int c5612a459a84ffdb41c885401433cd62d, bool c9c364a8fd1f013589fea518a3924e711 = true)
		{
			bool result = false;
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b2 = cfb1b70875043a3bbab17a383ac9b9fb9[c5612a459a84ffdb41c885401433cd62d];
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b2 != null)
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
				c82f7c0afbcfc8c5382a8c6daa9365b7b2.c9c364a8fd1f013589fea518a3924e711 = c9c364a8fd1f013589fea518a3924e711;
				result = true;
			}
			return result;
		}

		protected void cdb38ab0e0853152b8697b4110b2dba59(c82f7c0afbcfc8c5382a8c6daa9365b7b cc5b2a83f0ff489309eb5bc89970fb973, bool c9c364a8fd1f013589fea518a3924e711 = true)
		{
			if (c9c364a8fd1f013589fea518a3924e711)
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
				if (cc5b2a83f0ff489309eb5bc89970fb973 == cbe2d3a52e3b467c552460216e94ddc82)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
			int num;
			if (!c9c364a8fd1f013589fea518a3924e711)
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
				if (cc5b2a83f0ff489309eb5bc89970fb973 == cbe2d3a52e3b467c552460216e94ddc82)
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
					num = (cc5b2a83f0ff489309eb5bc89970fb973.ce84b930a12a1d06512c79320b3f0d3f4 ? 1 : 0);
					goto IL_0053;
				}
			}
			num = 0;
			goto IL_0053;
			IL_0053:
			bool flag = (byte)num != 0;
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b2 = cbe2d3a52e3b467c552460216e94ddc82;
			if (c9c364a8fd1f013589fea518a3924e711)
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
				cbe2d3a52e3b467c552460216e94ddc82 = cc5b2a83f0ff489309eb5bc89970fb973;
			}
			if (c9c364a8fd1f013589fea518a3924e711)
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
				if (c82f7c0afbcfc8c5382a8c6daa9365b7b2 != null)
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
					c82f7c0afbcfc8c5382a8c6daa9365b7b2.c9c364a8fd1f013589fea518a3924e711 = false;
				}
			}
			if (flag)
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
				cbe2d3a52e3b467c552460216e94ddc82 = c97069a74e409c00ffe9b90ba6b0c56c7.c7088de59e49f7108f520cf7e0bae167e;
			}
			else if (!c9c364a8fd1f013589fea518a3924e711)
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
			dispatchEvent(new CEvent(CEvent.CHANGED));
		}

		public bool ccfb4c9a7d41146c14621da195881ed41(c82f7c0afbcfc8c5382a8c6daa9365b7b cc5b2a83f0ff489309eb5bc89970fb973)
		{
			return cfb1b70875043a3bbab17a383ac9b9fb9.Contains(cc5b2a83f0ff489309eb5bc89970fb973);
		}

		protected void c94c8f66b7e538fcda39ef0fb7296baad(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b2 = cd729d94a5b443ac0f1b117450e5f4419.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b2.c9c364a8fd1f013589fea518a3924e711)
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
						cdb38ab0e0853152b8697b4110b2dba59(c82f7c0afbcfc8c5382a8c6daa9365b7b2);
						return;
					}
				}
			}
			cdb38ab0e0853152b8697b4110b2dba59(c82f7c0afbcfc8c5382a8c6daa9365b7b2, false);
		}

		protected void c150a5f7ef9e027d1fbcbf9d51dd4bb8c(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			dispatchEvent(cd729d94a5b443ac0f1b117450e5f4419);
		}

		protected void c333134bacfa8815e72937ecd4d08bdd9(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			cae286eca4fc7200a84038485c394f478(cd729d94a5b443ac0f1b117450e5f4419.target as c82f7c0afbcfc8c5382a8c6daa9365b7b);
		}
	}
}
