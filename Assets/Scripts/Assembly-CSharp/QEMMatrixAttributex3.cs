using A;
using UnityEngine;

public class QEMMatrixAttributex3
{
	public QEMVectorAttribute[] m_b = c2169ab288623d61ac6fb90e0517de808.c0a0cdf4a196914163f7334d9b0781a04(3);

	public QEMMatrixAttributex3()
	{
		for (int i = 0; i < 3; i++)
		{
			m_b[i] = new QEMVectorAttribute();
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
			return;
		}
	}

	public void c09d84353c41f841631b72e2ed955fefc(int c57579c4e2d3244ef6ef7a961ca982231, Vector3 cf312a174496712827bd0ffaff85b09ea)
	{
		for (int i = 0; i < 3; i++)
		{
			m_b[i].set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c57579c4e2d3244ef6ef7a961ca982231, cf312a174496712827bd0ffaff85b09ea[i]);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public void c9172684ab57085e2a77c2a3af69cb426(QEMMatrixAttributex3 ce00d51a1fe36853f765e24d398dc3da9)
	{
		for (int i = 0; i < 3; i++)
		{
			m_b[i].c9172684ab57085e2a77c2a3af69cb426(ce00d51a1fe36853f765e24d398dc3da9.m_b[i]);
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
			return;
		}
	}

	public static void c9172684ab57085e2a77c2a3af69cb426(QEMMatrixAttributex3 cb6f02e44368ea9c6d908935668ddf449, QEMMatrixAttributex3 cdec7efe40b9cb86019555d0e14182695, ref QEMMatrixAttributex3 cdbee49fe29de456df5bf99adb8c01e72)
	{
		for (int i = 0; i < 3; i++)
		{
			QEMVectorAttribute.c9172684ab57085e2a77c2a3af69cb426(cb6f02e44368ea9c6d908935668ddf449.m_b[i], cdec7efe40b9cb86019555d0e14182695.m_b[i], ref cdbee49fe29de456df5bf99adb8c01e72.m_b[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(float cc6aae3613e8118db3849f77569032076)
	{
		for (int i = 0; i < 3; i++)
		{
			m_b[i].ccb0d23031f36ef9d9e72c797d8c717e4(cc6aae3613e8118db3849f77569032076);
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
			return;
		}
	}

	public Vector3 ccb0d23031f36ef9d9e72c797d8c717e4(QEMVectorAttribute cf312a174496712827bd0ffaff85b09ea)
	{
		Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		for (int i = 0; i < 3; i++)
		{
			c36964cf41281414170f34ee68bef6c[i] = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[i], cf312a174496712827bd0ffaff85b09ea);
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
			return c36964cf41281414170f34ee68bef6c;
		}
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(Vector3 cf312a174496712827bd0ffaff85b09ea, ref QEMVectorAttribute cdbee49fe29de456df5bf99adb8c01e72)
	{
		int num = m_b[0].cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num; i++)
		{
			cdbee49fe29de456df5bf99adb8c01e72.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i, cf312a174496712827bd0ffaff85b09ea.x * m_b[0].get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i) + cf312a174496712827bd0ffaff85b09ea.y * m_b[1].get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i) + cf312a174496712827bd0ffaff85b09ea.z * m_b[2].get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i));
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
			return;
		}
	}

	public QEMMatrix3x3 c2010e78adaf6cb4cd6b8c76338725122()
	{
		QEMMatrix3x3 c36964cf41281414170f34ee68bef6c = default(QEMMatrix3x3);
		cb803e93453833476395330a736e338d4.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.m_00 = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[0], m_b[0]);
		c36964cf41281414170f34ee68bef6c.m_01 = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[0], m_b[1]);
		c36964cf41281414170f34ee68bef6c.m_02 = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[0], m_b[2]);
		c36964cf41281414170f34ee68bef6c.m_11 = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[1], m_b[1]);
		c36964cf41281414170f34ee68bef6c.m_12 = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[1], m_b[2]);
		c36964cf41281414170f34ee68bef6c.m_22 = QEMVectorAttribute.c73d241e02d022b2c3a9788b4039df0ef(m_b[2], m_b[2]);
		return c36964cf41281414170f34ee68bef6c;
	}

	public void c92eb2231f43bdb532bac8326ea4b2f1b()
	{
		for (int i = 0; i < 3; i++)
		{
			m_b[i].c92eb2231f43bdb532bac8326ea4b2f1b();
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}
}
