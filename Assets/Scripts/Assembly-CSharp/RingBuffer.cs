using A;
using Core;

public class RingBuffer
{
	private object[] m_buffer;

	private int m_tail;

	private int m_head;

	private int m_cap;

	private bool m_discard;

	private bool m_full;

	private bool m_empty;

	public RingBuffer(int c1ca49f07c6ba2c53626bb5eb77a503d3, bool c2d50baf865dc7d6f66c9e75fc501c5e1)
	{
		m_head = (m_tail = 0);
		m_cap = c1ca49f07c6ba2c53626bb5eb77a503d3;
		m_discard = c2d50baf865dc7d6f66c9e75fc501c5e1;
		m_buffer = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(m_cap);
		m_empty = true;
	}

	public bool cd6aca5b3793f791cfc489609e675c90b(object c5d720f6d007abb0c4a21d6a654e405bb)
	{
		m_empty = false;
		if (!m_full)
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
			m_buffer[m_tail] = c5d720f6d007abb0c4a21d6a654e405bb;
			m_tail = c5e48466767cb75d348fd9f951ab4e538(m_tail);
			if (m_tail == m_head)
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
				m_full = true;
			}
		}
		else
		{
			if (!m_discard)
			{
				return false;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			m_buffer[m_tail] = c5d720f6d007abb0c4a21d6a654e405bb;
			m_tail = c5e48466767cb75d348fd9f951ab4e538(m_tail);
			m_head = c5e48466767cb75d348fd9f951ab4e538(m_head);
		}
		return true;
	}

	public object cef0e77f01549f5bca5df565d45cc1a90()
	{
		return m_buffer[cab8772f51d077bf414fefc074354f334(m_tail)];
	}

	public object c8a833251dc49a102f7b1cb1c222bc04e()
	{
		return m_buffer[c7c0ad6267b5c2ea4d75fbdb3c0a0bad2(m_tail, 2)];
	}

	public object c588e7dbcd383d8230b2d83d7b44af23b(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d < ca0dc0c335bcd7a0d16510da3a64d1c4f())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c5612a459a84ffdb41c885401433cd62d >= 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_buffer[ce296b0616503494937a12a04533ac348(m_head, c5612a459a84ffdb41c885401433cd62d)];
					}
				}
			}
		}
		if (c5612a459a84ffdb41c885401433cd62d > ca0dc0c335bcd7a0d16510da3a64d1c4f())
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.System, "try to access beyond buffer");
		}
		return null;
	}

	public object c7605b6a8df360621e4eb06fe0b47814b()
	{
		m_full = false;
		if (!m_empty)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int head = m_head;
					m_head = c5e48466767cb75d348fd9f951ab4e538(m_head);
					if (m_head == m_tail)
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
						m_empty = true;
					}
					return m_buffer[head];
				}
				}
			}
		}
		return null;
	}

	private int c5e48466767cb75d348fd9f951ab4e538(int c5612a459a84ffdb41c885401433cd62d)
	{
		return (c5612a459a84ffdb41c885401433cd62d + 1) % m_cap;
	}

	private int cab8772f51d077bf414fefc074354f334(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d == 0)
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
					return m_cap - 1;
				}
			}
		}
		return (c5612a459a84ffdb41c885401433cd62d - 1) % m_cap;
	}

	private int ce296b0616503494937a12a04533ac348(int c5612a459a84ffdb41c885401433cd62d, int cc2f02279e22264d3ef0c3d613fbd8dd6)
	{
		return (c5612a459a84ffdb41c885401433cd62d + cc2f02279e22264d3ef0c3d613fbd8dd6) % m_cap;
	}

	private int c7c0ad6267b5c2ea4d75fbdb3c0a0bad2(int c5612a459a84ffdb41c885401433cd62d, int cc2f02279e22264d3ef0c3d613fbd8dd6)
	{
		return (c5612a459a84ffdb41c885401433cd62d + m_cap - cc2f02279e22264d3ef0c3d613fbd8dd6) % m_cap;
	}

	public int ca0dc0c335bcd7a0d16510da3a64d1c4f()
	{
		if (m_full)
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
					return m_cap;
				}
			}
		}
		if (m_empty)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		int result;
		if (m_tail - m_head >= 0)
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
			result = m_tail - m_head;
		}
		else
		{
			result = m_tail - m_head + m_cap;
		}
		return result;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_tail = m_head;
	}

	public int cbb9f1aee8a8e86f5765f179e98139a1e()
	{
		return m_cap;
	}
}
