using System.Reflection;
using A;

[DefaultMember("Item")]
public class QEMVectorAttribute
{
	private float[] m_vector;

	public float cbbf1d0dd5bd18c03ef13e60bff03ebc0
	{
		get
		{
			return m_vector[c5612a459a84ffdb41c885401433cd62d];
		}
		set
		{
			m_vector[c5612a459a84ffdb41c885401433cd62d] = value;
		}
	}

	public QEMVectorAttribute()
	{
		m_vector = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(QEMVectorN.s_n - 3);
	}

	public void c92eb2231f43bdb532bac8326ea4b2f1b()
	{
		int num = cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num; i++)
		{
			m_vector[i] = 0f;
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

	public int cbdd49dbc32b577a8bec157227d17b961()
	{
		return m_vector.Length;
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(float cc6aae3613e8118db3849f77569032076)
	{
		int num = cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num; i++)
		{
			m_vector[i] *= cc6aae3613e8118db3849f77569032076;
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

	public void c9172684ab57085e2a77c2a3af69cb426(QEMVectorAttribute ce00d51a1fe36853f765e24d398dc3da9)
	{
		int num = cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num; i++)
		{
			m_vector[i] += ce00d51a1fe36853f765e24d398dc3da9.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i);
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

	public static void c9172684ab57085e2a77c2a3af69cb426(QEMVectorAttribute cb6f02e44368ea9c6d908935668ddf449, QEMVectorAttribute cdec7efe40b9cb86019555d0e14182695, ref QEMVectorAttribute cdbee49fe29de456df5bf99adb8c01e72)
	{
		int num = cdbee49fe29de456df5bf99adb8c01e72.cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num; i++)
		{
			cdbee49fe29de456df5bf99adb8c01e72.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i, cb6f02e44368ea9c6d908935668ddf449.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i) + cdec7efe40b9cb86019555d0e14182695.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i));
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

	public static float c73d241e02d022b2c3a9788b4039df0ef(QEMVectorAttribute cb6f02e44368ea9c6d908935668ddf449, QEMVectorAttribute cdec7efe40b9cb86019555d0e14182695)
	{
		float num = 0f;
		int num2 = cb6f02e44368ea9c6d908935668ddf449.cbdd49dbc32b577a8bec157227d17b961();
		for (int i = 0; i < num2; i++)
		{
			num += cb6f02e44368ea9c6d908935668ddf449.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i) * cdec7efe40b9cb86019555d0e14182695.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(i);
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
			return num;
		}
	}
}
