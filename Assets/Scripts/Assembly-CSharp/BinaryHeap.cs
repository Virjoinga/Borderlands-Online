public class BinaryHeap
{
	private QEMEdge[] m_array;

	private int m_heapSize;

	public BinaryHeap(QEMEdge[] c5d8c0dff2a72efb6534752a08ea45a14)
	{
		m_array = c5d8c0dff2a72efb6534752a08ea45a14;
		m_heapSize = m_array.Length;
		c62885ad4148b45b498df98d6c41e5891();
	}

	public QEMEdge c82d4c15e04d528819eaff709d021d290()
	{
		return c7605b6a8df360621e4eb06fe0b47814b(0);
	}

	public QEMEdge c7605b6a8df360621e4eb06fe0b47814b(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c5612a459a84ffdb41c885401433cd62d < m_heapSize)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						c4c219e06931010719120d0a6b9bc859e(c5612a459a84ffdb41c885401433cd62d, --m_heapSize);
						c7e4505ee001438e40aa253c75194b708(c5612a459a84ffdb41c885401433cd62d);
						return m_array[m_heapSize];
					}
				}
			}
		}
		return null;
	}

	public int c7ed33d6df7751b2f5930fd83c9989c36()
	{
		return m_heapSize;
	}

	public void c2f16e4b881ca4098c16d65a494a22542(int c5612a459a84ffdb41c885401433cd62d)
	{
		c6e12ddab9dc4d8d2565cdf59ad68455d(c5612a459a84ffdb41c885401433cd62d);
		c7e4505ee001438e40aa253c75194b708(c5612a459a84ffdb41c885401433cd62d);
	}

	public QEMEdge c588e7dbcd383d8230b2d83d7b44af23b(int c872943035f78644fd01b267deff00547)
	{
		if (c872943035f78644fd01b267deff00547 >= 0)
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
			if (c872943035f78644fd01b267deff00547 < m_heapSize)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return m_array[c872943035f78644fd01b267deff00547];
					}
				}
			}
		}
		return null;
	}

	private void c62885ad4148b45b498df98d6c41e5891()
	{
		for (int num = m_heapSize / 2 - 1; num >= 0; num--)
		{
			c7e4505ee001438e40aa253c75194b708(num);
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
			for (int i = 0; i < m_heapSize; i++)
			{
				m_array[i].m_index = i;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void c4c219e06931010719120d0a6b9bc859e(int cb6f02e44368ea9c6d908935668ddf449, int cdec7efe40b9cb86019555d0e14182695)
	{
		if (cb6f02e44368ea9c6d908935668ddf449 == cdec7efe40b9cb86019555d0e14182695)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			QEMEdge qEMEdge = m_array[cb6f02e44368ea9c6d908935668ddf449];
			m_array[cb6f02e44368ea9c6d908935668ddf449] = m_array[cdec7efe40b9cb86019555d0e14182695];
			m_array[cdec7efe40b9cb86019555d0e14182695] = qEMEdge;
			m_array[cb6f02e44368ea9c6d908935668ddf449].m_index = cb6f02e44368ea9c6d908935668ddf449;
			m_array[cdec7efe40b9cb86019555d0e14182695].m_index = cdec7efe40b9cb86019555d0e14182695;
			return;
		}
	}

	public void c7e4505ee001438e40aa253c75194b708(int c5612a459a84ffdb41c885401433cd62d)
	{
		int num = c5612a459a84ffdb41c885401433cd62d;
		int num2 = ca6355962092bbecef1276624e9ad50c3(num);
		while (num >= 0)
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
			if (num >= m_heapSize)
			{
				break;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (num2 >= 0)
			{
				int num3 = num2 + 1;
				if (num3 < m_heapSize)
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
					if (m_array[num3].cadb490a5154195ab279210bc338e9d5a() < m_array[num2].cadb490a5154195ab279210bc338e9d5a())
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
						num2 = num3;
					}
				}
				if (m_array[num2].cadb490a5154195ab279210bc338e9d5a() < m_array[num].cadb490a5154195ab279210bc338e9d5a())
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
					c4c219e06931010719120d0a6b9bc859e(num, num2);
					num = num2;
					num2 = ca6355962092bbecef1276624e9ad50c3(num);
				}
				else
				{
					num = (num2 = -1);
				}
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void c6e12ddab9dc4d8d2565cdf59ad68455d(int c5612a459a84ffdb41c885401433cd62d)
	{
		int num = c5612a459a84ffdb41c885401433cd62d;
		int num2 = c250783c219e5191f706df9ed222f6b38(num);
		while (num >= 0)
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
			if (num >= m_heapSize)
			{
				break;
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
			if (num2 >= 0)
			{
				if (m_array[num].cadb490a5154195ab279210bc338e9d5a() < m_array[num2].cadb490a5154195ab279210bc338e9d5a())
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c4c219e06931010719120d0a6b9bc859e(num, num2);
					num = num2;
					num2 = c250783c219e5191f706df9ed222f6b38(num);
				}
				else
				{
					num = (num2 = -1);
				}
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private int c250783c219e5191f706df9ed222f6b38(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_heapSize)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return (c5612a459a84ffdb41c885401433cd62d - 1) / 2;
					}
				}
			}
		}
		return -1;
	}

	private int ca6355962092bbecef1276624e9ad50c3(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d >= 0)
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
			c5612a459a84ffdb41c885401433cd62d = 2 * c5612a459a84ffdb41c885401433cd62d + 1;
			if (c5612a459a84ffdb41c885401433cd62d < m_heapSize)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return c5612a459a84ffdb41c885401433cd62d;
					}
				}
			}
		}
		return -1;
	}
}
