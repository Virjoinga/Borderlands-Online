using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace A
{
	[DefaultMember("Item")]
	public class c0f3c1d262ce52808e3809fe84e7b77f8
	{
		public Dictionary<string, ce972fd150f340044b329bd2758a9cacc> cf72e8322082a011ac716a52a275711ac = new Dictionary<string, ce972fd150f340044b329bd2758a9cacc>();

		[CompilerGenerated]
		private ce972fd150f340044b329bd2758a9cacc c86cde5e78896a2b5cbef3b21c255f6ed;

		[CompilerGenerated]
		private ce972fd150f340044b329bd2758a9cacc c24a40669781755dd1d474bce25a30031;

		public ce972fd150f340044b329bd2758a9cacc m_curState
		{
			[CompilerGenerated]
			get
			{
				return c86cde5e78896a2b5cbef3b21c255f6ed;
			}
			[CompilerGenerated]
			private set
			{
				c86cde5e78896a2b5cbef3b21c255f6ed = value;
			}
		}

		public ce972fd150f340044b329bd2758a9cacc m_preState
		{
			[CompilerGenerated]
			get
			{
				return c24a40669781755dd1d474bce25a30031;
			}
			[CompilerGenerated]
			private set
			{
				c24a40669781755dd1d474bce25a30031 = value;
			}
		}

		public ce972fd150f340044b329bd2758a9cacc cbbf1d0dd5bd18c03ef13e60bff03ebc0
		{
			get
			{
				if (!cf72e8322082a011ac716a52a275711ac.ContainsKey(cf9e4ee4aad0dfef345efeacc8e9c1232))
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
							return null;
						}
					}
				}
				return cf72e8322082a011ac716a52a275711ac[cf9e4ee4aad0dfef345efeacc8e9c1232];
			}
			set
			{
				cf72e8322082a011ac716a52a275711ac[cf9e4ee4aad0dfef345efeacc8e9c1232] = value;
			}
		}

		public void c64dc51f788493a1a9e7999e9e2317ddf(string cf9e4ee4aad0dfef345efeacc8e9c1232)
		{
			cf72e8322082a011ac716a52a275711ac.Add(cf9e4ee4aad0dfef345efeacc8e9c1232, new ce972fd150f340044b329bd2758a9cacc(this, cf9e4ee4aad0dfef345efeacc8e9c1232));
		}

		public void c3d651aa95fd9820e9e2c328cc63e13e9(string c340cda5237492158a3158af7966d79b1)
		{
			ce972fd150f340044b329bd2758a9cacc value = cde2bf372eeaf659ec9aa9ec29a6d1191.c7088de59e49f7108f520cf7e0bae167e;
			if (!cf72e8322082a011ac716a52a275711ac.TryGetValue(c340cda5237492158a3158af7966d79b1, out value))
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
						return;
					}
				}
			}
			if (value == null)
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
			value.cdecc1d7a8728981e97b2a31b6b14af4e = this;
			if (m_curState != null)
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
				m_curState.caeee91e34d54e1e41ab1b380f7d8c9a4();
			}
			m_preState = m_curState;
			m_curState = value;
			m_curState.cdd79e3fb9f04672a139ad58f6b3176f7();
		}

		public void c3d651aa95fd9820e9e2c328cc63e13e9(ce972fd150f340044b329bd2758a9cacc c7d77be03dd09783b7cf45209bd57d03e)
		{
			if (c7d77be03dd09783b7cf45209bd57d03e == null)
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
						return;
					}
				}
			}
			c7d77be03dd09783b7cf45209bd57d03e.cdecc1d7a8728981e97b2a31b6b14af4e = this;
			if (m_curState != null)
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
				m_curState.caeee91e34d54e1e41ab1b380f7d8c9a4();
			}
			m_preState = m_curState;
			m_curState = c7d77be03dd09783b7cf45209bd57d03e;
			m_curState.cdd79e3fb9f04672a139ad58f6b3176f7();
		}

		public bool ccbc3718dd3d0e1356fa98d45c46d48ea(string ce7431eb8cf0921edde84fddbb6379357)
		{
			ce972fd150f340044b329bd2758a9cacc value = cde2bf372eeaf659ec9aa9ec29a6d1191.c7088de59e49f7108f520cf7e0bae167e;
			if (!cf72e8322082a011ac716a52a275711ac.TryGetValue(ce7431eb8cf0921edde84fddbb6379357, out value))
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
						return false;
					}
				}
			}
			return m_curState == value;
		}

		public bool ccbc3718dd3d0e1356fa98d45c46d48ea(ce972fd150f340044b329bd2758a9cacc c12da452506697be78f3c915040b65dd8)
		{
			return m_curState == c12da452506697be78f3c915040b65dd8;
		}

		public virtual void Update()
		{
			if (m_curState == null)
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
						return;
					}
				}
			}
			m_curState.c07b7ce37423e253b784029efb12b608f();
		}
	}
}
