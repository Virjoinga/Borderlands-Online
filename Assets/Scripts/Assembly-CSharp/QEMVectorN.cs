using System.Reflection;
using A;
using UnityEngine;

[DefaultMember("Item")]
public class QEMVectorN
{
	public static QEMVectorN s_tempVector;

	public static int s_n;

	public Vector3 m_b1;

	public QEMVectorAttribute m_b2;

	public float cbbf1d0dd5bd18c03ef13e60bff03ebc0
	{
		get
		{
			if (c5612a459a84ffdb41c885401433cd62d < 3)
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
						return m_b1[c5612a459a84ffdb41c885401433cd62d];
					}
				}
			}
			return m_b2.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d - 3);
		}
		set
		{
			if (c5612a459a84ffdb41c885401433cd62d < 3)
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
						m_b1[c5612a459a84ffdb41c885401433cd62d] = value;
						return;
					}
				}
			}
			m_b2.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d - 3, value);
		}
	}

	public QEMVectorN()
	{
		Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		m_b1 = c36964cf41281414170f34ee68bef6c;
		m_b2 = new QEMVectorAttribute();
	}

	public void c034936ede6b65db0da600e58eb5611d2(Vector3 cf312a174496712827bd0ffaff85b09ea)
	{
		m_b1 = cf312a174496712827bd0ffaff85b09ea;
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return m_b1;
	}

	public void cfa95d8e518a4c412db818ebd69b402c3(int c5612a459a84ffdb41c885401433cd62d, float cefda2fdc3ce4e04f38bab77fc7998241)
	{
		m_b2.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d, cefda2fdc3ce4e04f38bab77fc7998241);
	}

	public float cbc6c23e986f6b4b045e27d64d700163c(int c5612a459a84ffdb41c885401433cd62d)
	{
		return m_b2.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
	}

	public void c92eb2231f43bdb532bac8326ea4b2f1b()
	{
		m_b1 = Vector3.zero;
		m_b2.c92eb2231f43bdb532bac8326ea4b2f1b();
	}

	public int cbdd49dbc32b577a8bec157227d17b961()
	{
		return m_b2.cbdd49dbc32b577a8bec157227d17b961() + 3;
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(float cc6aae3613e8118db3849f77569032076)
	{
		m_b1 *= cc6aae3613e8118db3849f77569032076;
		m_b2.ccb0d23031f36ef9d9e72c797d8c717e4(cc6aae3613e8118db3849f77569032076);
	}

	public void c9172684ab57085e2a77c2a3af69cb426(QEMVectorN ce00d51a1fe36853f765e24d398dc3da9)
	{
		m_b1 += ce00d51a1fe36853f765e24d398dc3da9.m_b1;
		m_b2.c9172684ab57085e2a77c2a3af69cb426(ce00d51a1fe36853f765e24d398dc3da9.m_b2);
	}

	public static void c9172684ab57085e2a77c2a3af69cb426(QEMVectorN cb6f02e44368ea9c6d908935668ddf449, QEMVectorN cdec7efe40b9cb86019555d0e14182695, ref QEMVectorN cdbee49fe29de456df5bf99adb8c01e72)
	{
		cdbee49fe29de456df5bf99adb8c01e72.m_b1 = cb6f02e44368ea9c6d908935668ddf449.m_b1 + cdec7efe40b9cb86019555d0e14182695.m_b1;
		QEMVectorAttribute.c9172684ab57085e2a77c2a3af69cb426(cb6f02e44368ea9c6d908935668ddf449.m_b2, cdec7efe40b9cb86019555d0e14182695.m_b2, ref cdbee49fe29de456df5bf99adb8c01e72.m_b2);
	}

	public static float c73d241e02d022b2c3a9788b4039df0ef(QEMVectorN cb6f02e44368ea9c6d908935668ddf449, QEMVectorN cdec7efe40b9cb86019555d0e14182695)
	{
		float num = 0f;
		int num2 = cb6f02e44368ea9c6d908935668ddf449.cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num2; i++)
		{
			num += cb6f02e44368ea9c6d908935668ddf449.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i) * cdec7efe40b9cb86019555d0e14182695.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i);
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
			return num;
		}
	}
}
