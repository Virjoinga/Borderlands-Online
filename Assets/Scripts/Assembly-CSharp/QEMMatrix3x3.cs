using System.Reflection;
using A;
using Core;
using UnityEngine;

[DefaultMember("Item")]
public struct QEMMatrix3x3
{
	public float m_00;

	public float m_01;

	public float m_02;

	public float m_11;

	public float m_12;

	public float m_22;

	public float cbbf1d0dd5bd18c03ef13e60bff03ebc0
	{
		get
		{
			if (c5612a459a84ffdb41c885401433cd62d == 0)
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
						return m_00;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 1)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return m_01;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 2)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return m_11;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 3)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return m_02;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 4)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return m_12;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 5)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return m_22;
					}
				}
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "errorrrr");
			return 0f;
		}
		set
		{
			if (c5612a459a84ffdb41c885401433cd62d == 0)
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
						m_00 = value;
						return;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 1)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_01 = value;
						return;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 2)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_11 = value;
						return;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 3)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						m_02 = value;
						return;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 4)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						m_12 = value;
						return;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d == 5)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_22 = value;
						return;
					}
				}
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "errorrrr");
		}
	}

	public QEMMatrix3x3 ccb0d23031f36ef9d9e72c797d8c717e4(float cc6aae3613e8118db3849f77569032076)
	{
		m_00 *= cc6aae3613e8118db3849f77569032076;
		m_01 *= cc6aae3613e8118db3849f77569032076;
		m_02 *= cc6aae3613e8118db3849f77569032076;
		m_11 *= cc6aae3613e8118db3849f77569032076;
		m_12 *= cc6aae3613e8118db3849f77569032076;
		m_22 *= cc6aae3613e8118db3849f77569032076;
		return this;
	}

	public QEMMatrix3x3 ccb0d23031f36ef9d9e72c797d8c717e4(QEMMatrix3x3 cf312a174496712827bd0ffaff85b09ea)
	{
		QEMMatrix3x3 c36964cf41281414170f34ee68bef6c = default(QEMMatrix3x3);
		cb803e93453833476395330a736e338d4.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.m_00 = m_00 * cf312a174496712827bd0ffaff85b09ea.m_00 + m_01 * cf312a174496712827bd0ffaff85b09ea.m_01 + m_02 * cf312a174496712827bd0ffaff85b09ea.m_02;
		c36964cf41281414170f34ee68bef6c.m_01 = m_00 * cf312a174496712827bd0ffaff85b09ea.m_01 + m_01 * cf312a174496712827bd0ffaff85b09ea.m_11 + m_02 * cf312a174496712827bd0ffaff85b09ea.m_12;
		c36964cf41281414170f34ee68bef6c.m_02 = m_00 * cf312a174496712827bd0ffaff85b09ea.m_02 + m_01 * cf312a174496712827bd0ffaff85b09ea.m_12 + m_02 * cf312a174496712827bd0ffaff85b09ea.m_22;
		c36964cf41281414170f34ee68bef6c.m_11 = m_01 * cf312a174496712827bd0ffaff85b09ea.m_01 + m_11 * cf312a174496712827bd0ffaff85b09ea.m_11 + m_12 * cf312a174496712827bd0ffaff85b09ea.m_12;
		c36964cf41281414170f34ee68bef6c.m_12 = m_01 * cf312a174496712827bd0ffaff85b09ea.m_02 + m_11 * cf312a174496712827bd0ffaff85b09ea.m_12 + m_12 * cf312a174496712827bd0ffaff85b09ea.m_22;
		c36964cf41281414170f34ee68bef6c.m_22 = m_02 * cf312a174496712827bd0ffaff85b09ea.m_02 + m_12 * cf312a174496712827bd0ffaff85b09ea.m_12 + m_22 * cf312a174496712827bd0ffaff85b09ea.m_22;
		return c36964cf41281414170f34ee68bef6c;
	}

	public Vector3 ccb0d23031f36ef9d9e72c797d8c717e4(Vector3 cf312a174496712827bd0ffaff85b09ea)
	{
		float x = cf312a174496712827bd0ffaff85b09ea.x;
		float y = cf312a174496712827bd0ffaff85b09ea.y;
		float z = cf312a174496712827bd0ffaff85b09ea.z;
		return new Vector3(x * m_00 + y * m_01 + z * m_02, x * m_01 + y * m_11 + z * m_12, x * m_02 + y * m_12 + z * m_22);
	}

	public static QEMMatrix3x3 c9172684ab57085e2a77c2a3af69cb426(QEMMatrix3x3 cb6f02e44368ea9c6d908935668ddf449, QEMMatrix3x3 cdec7efe40b9cb86019555d0e14182695)
	{
		QEMMatrix3x3 c36964cf41281414170f34ee68bef6c = default(QEMMatrix3x3);
		cb803e93453833476395330a736e338d4.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.m_00 = cb6f02e44368ea9c6d908935668ddf449.m_00 + cdec7efe40b9cb86019555d0e14182695.m_00;
		c36964cf41281414170f34ee68bef6c.m_01 = cb6f02e44368ea9c6d908935668ddf449.m_01 + cdec7efe40b9cb86019555d0e14182695.m_01;
		c36964cf41281414170f34ee68bef6c.m_02 = cb6f02e44368ea9c6d908935668ddf449.m_02 + cdec7efe40b9cb86019555d0e14182695.m_02;
		c36964cf41281414170f34ee68bef6c.m_11 = cb6f02e44368ea9c6d908935668ddf449.m_11 + cdec7efe40b9cb86019555d0e14182695.m_11;
		c36964cf41281414170f34ee68bef6c.m_12 = cb6f02e44368ea9c6d908935668ddf449.m_12 + cdec7efe40b9cb86019555d0e14182695.m_12;
		c36964cf41281414170f34ee68bef6c.m_22 = cb6f02e44368ea9c6d908935668ddf449.m_22 + cdec7efe40b9cb86019555d0e14182695.m_22;
		return c36964cf41281414170f34ee68bef6c;
	}

	public void c9172684ab57085e2a77c2a3af69cb426(QEMMatrix3x3 c7014fabb0683970386771ab37eb4778d)
	{
		m_00 += c7014fabb0683970386771ab37eb4778d.m_00;
		m_01 += c7014fabb0683970386771ab37eb4778d.m_01;
		m_02 += c7014fabb0683970386771ab37eb4778d.m_02;
		m_11 += c7014fabb0683970386771ab37eb4778d.m_11;
		m_12 += c7014fabb0683970386771ab37eb4778d.m_12;
		m_22 += c7014fabb0683970386771ab37eb4778d.m_22;
	}

	public void c92eb2231f43bdb532bac8326ea4b2f1b()
	{
		m_00 = 0f;
		m_01 = 0f;
		m_02 = 0f;
		m_11 = 0f;
		m_12 = 0f;
		m_22 = 0f;
	}

	public float c0dcfe41f57932a16dbc85c83daf47296()
	{
		return m_00 * (m_11 * m_22 - m_12 * m_12) + m_01 * (m_12 * m_02 - m_22 * m_01) + m_02 * (m_01 * m_12 - m_11 * m_02);
	}

	public QEMMatrix3x3 c4463fa705520e7ae2098551bae26ad78()
	{
		QEMMatrix3x3 c36964cf41281414170f34ee68bef6c = default(QEMMatrix3x3);
		cb803e93453833476395330a736e338d4.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		float num = c0dcfe41f57932a16dbc85c83daf47296();
		c36964cf41281414170f34ee68bef6c.m_00 = (m_11 * m_22 - m_12 * m_12) / num;
		c36964cf41281414170f34ee68bef6c.m_01 = (m_02 * m_12 - m_01 * m_22) / num;
		c36964cf41281414170f34ee68bef6c.m_02 = (m_01 * m_12 - m_02 * m_11) / num;
		c36964cf41281414170f34ee68bef6c.m_11 = (m_00 * m_22 - m_02 * m_02) / num;
		c36964cf41281414170f34ee68bef6c.m_12 = (m_02 * m_01 - m_00 * m_12) / num;
		c36964cf41281414170f34ee68bef6c.m_22 = (m_00 * m_11 - m_01 * m_01) / num;
		return c36964cf41281414170f34ee68bef6c;
	}

	public bool c57f3600422b6dbcd76697dd500a03eed()
	{
		float num = m_00 - 1f;
		float num2 = m_11 - 1f;
		float num3 = m_22 - 1f;
		if (num * num < 1E-05f)
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
			if (num2 * num2 < 1E-05f)
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
				if (num3 * num3 < 1E-05f)
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
					if (m_01 * m_01 < 1E-05f)
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
						if (m_02 * m_02 < 1E-05f)
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
							if (m_12 * m_12 < 1E-05f)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										break;
									default:
										return true;
									}
								}
							}
						}
					}
				}
			}
		}
		return false;
	}
}
