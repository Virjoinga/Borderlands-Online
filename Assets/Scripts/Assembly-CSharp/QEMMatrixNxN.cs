using A;

public class QEMMatrixNxN
{
	public QEMMatrix3x3 m_AC;

	public QEMMatrixAttributex3 m_AB;

	public float m_diagonal;

	public QEMMatrixNxN()
	{
		QEMMatrix3x3 c36964cf41281414170f34ee68bef6c = default(QEMMatrix3x3);
		cb803e93453833476395330a736e338d4.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		m_AC = c36964cf41281414170f34ee68bef6c;
		m_AB = new QEMMatrixAttributex3();
		m_diagonal = 0f;
	}

	public int cbdd49dbc32b577a8bec157227d17b961()
	{
		return QEMVectorN.s_n;
	}

	public float ce496f2302aa3f83a2edca09168844502(int cabae5c580e7cc65bdd747ea87e0b78d8, int c2d2e55ae6c4d319c42e74c3dcabc2ebe)
	{
		int num = cabae5c580e7cc65bdd747ea87e0b78d8;
		int num2 = c2d2e55ae6c4d319c42e74c3dcabc2ebe;
		if (num < num2)
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
			num = c2d2e55ae6c4d319c42e74c3dcabc2ebe;
			num2 = cabae5c580e7cc65bdd747ea87e0b78d8;
		}
		if (num < 3)
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
			if (num2 < 3)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return m_AC.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(num + num2 + num / 2);
					}
				}
			}
		}
		if (num >= 3)
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
			if (num2 >= 3)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (num == num2)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									return m_diagonal;
								}
							}
						}
						return 0f;
					}
				}
			}
		}
		return m_AB.m_b[num2].get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(num - 3);
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(float cc6aae3613e8118db3849f77569032076)
	{
		m_AC.ccb0d23031f36ef9d9e72c797d8c717e4(cc6aae3613e8118db3849f77569032076);
		m_AB.ccb0d23031f36ef9d9e72c797d8c717e4(cc6aae3613e8118db3849f77569032076);
		m_diagonal *= cc6aae3613e8118db3849f77569032076;
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(QEMVectorN cf312a174496712827bd0ffaff85b09ea, ref QEMVectorN c72943404493c5c9abc349e4b65bfe91b)
	{
		int num = cf312a174496712827bd0ffaff85b09ea.cbdd49dbc32b577a8bec157227d17b961();
		int num2 = 0;
		while (num2 < num)
		{
			c72943404493c5c9abc349e4b65bfe91b.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(num2, 0f);
			for (int i = 0; i < num; i++)
			{
				QEMVectorN qEMVectorN;
				QEMVectorN qEMVectorN2 = (qEMVectorN = c72943404493c5c9abc349e4b65bfe91b);
				int c5612a459a84ffdb41c885401433cd62d;
				int c5612a459a84ffdb41c885401433cd62d2 = (c5612a459a84ffdb41c885401433cd62d = num2);
				float num3 = qEMVectorN.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
				qEMVectorN2.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d2, num3 + cf312a174496712827bd0ffaff85b09ea.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i) * ce496f2302aa3f83a2edca09168844502(num2, i));
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
				num2++;
				break;
			}
		}
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

	public static void c9172684ab57085e2a77c2a3af69cb426(QEMMatrixNxN cb6f02e44368ea9c6d908935668ddf449, QEMMatrixNxN cdec7efe40b9cb86019555d0e14182695, ref QEMMatrixNxN c72943404493c5c9abc349e4b65bfe91b)
	{
		c72943404493c5c9abc349e4b65bfe91b.m_AC = QEMMatrix3x3.c9172684ab57085e2a77c2a3af69cb426(cb6f02e44368ea9c6d908935668ddf449.m_AC, cdec7efe40b9cb86019555d0e14182695.m_AC);
		QEMMatrixAttributex3.c9172684ab57085e2a77c2a3af69cb426(cb6f02e44368ea9c6d908935668ddf449.m_AB, cdec7efe40b9cb86019555d0e14182695.m_AB, ref c72943404493c5c9abc349e4b65bfe91b.m_AB);
		c72943404493c5c9abc349e4b65bfe91b.m_diagonal = cb6f02e44368ea9c6d908935668ddf449.m_diagonal + cdec7efe40b9cb86019555d0e14182695.m_diagonal;
	}

	public void c9172684ab57085e2a77c2a3af69cb426(QEMMatrixNxN c3969c4feb40f8516749043c6dffef098)
	{
		m_AC.c9172684ab57085e2a77c2a3af69cb426(c3969c4feb40f8516749043c6dffef098.m_AC);
		m_AB.c9172684ab57085e2a77c2a3af69cb426(c3969c4feb40f8516749043c6dffef098.m_AB);
		m_diagonal += c3969c4feb40f8516749043c6dffef098.m_diagonal;
	}

	public void c92eb2231f43bdb532bac8326ea4b2f1b()
	{
		m_AC.c92eb2231f43bdb532bac8326ea4b2f1b();
		m_AB.c92eb2231f43bdb532bac8326ea4b2f1b();
		m_diagonal = 0f;
	}
}
