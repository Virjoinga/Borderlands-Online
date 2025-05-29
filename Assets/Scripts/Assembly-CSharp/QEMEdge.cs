using System.Collections.Generic;
using A;
using UnityEngine;

public class QEMEdge
{
	public bool m_qemDirty = true;

	public int m_index = -1;

	public QEMWedge[] m_wedges = cdcbc296938a35851f7ca72abfc075b20.c0a0cdf4a196914163f7334d9b0781a04(2);

	public QEMVectorN m_collapsePosition = new QEMVectorN();

	public float m_error = float.MaxValue;

	public int m_ref;

	public bool cf6dcc26ca88bb58eafc05cb9cc7cfa44
	{
		get
		{
			int result;
			if (!c44767225a54497a5723cf5f4fce5ce90())
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
				if (m_wedges[0].cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
					result = (m_wedges[1].cf6dcc26ca88bb58eafc05cb9cc7cfa44 ? 1 : 0);
					goto IL_004a;
				}
			}
			result = 0;
			goto IL_004a;
			IL_004a:
			return (byte)result != 0;
		}
	}

	public QEMFace c8d80af39f8dee3ba211584bc3f457480()
	{
		QEMFace result = ceba7d2e26cb857dad38860e62cc6412d.c7088de59e49f7108f520cf7e0bae167e;
		int num = 0;
		using (LinkedList<QEMFace>.Enumerator enumerator = m_wedges[0].m_faces.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QEMFace current = enumerator.Current;
				if (current.cbd23cd3d26a452dc0588a63ce92f5076(m_wedges[0], m_wedges[1]) == null)
				{
					continue;
				}
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
				num++;
				result = current;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0067;
				}
				continue;
				end_IL_0067:
				break;
			}
		}
		if (num != 1)
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
			result = ceba7d2e26cb857dad38860e62cc6412d.c7088de59e49f7108f520cf7e0bae167e;
		}
		return result;
	}

	public bool c1a84901a0a9ec83a0000feb026941d27(QEMWedge cf312a174496712827bd0ffaff85b09ea)
	{
		int result;
		if (m_wedges[0] != cf312a174496712827bd0ffaff85b09ea)
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
			result = ((m_wedges[1] == cf312a174496712827bd0ffaff85b09ea) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool c44767225a54497a5723cf5f4fce5ce90()
	{
		return m_wedges[0].m_vertex == m_wedges[1].m_vertex;
	}

	public bool cdbb96bb21cbf3f95e90d131174daad95(QEMEdge c6160453ebc961fb52208ff202a88b446)
	{
		return cdbb96bb21cbf3f95e90d131174daad95(c6160453ebc961fb52208ff202a88b446.m_wedges[0], c6160453ebc961fb52208ff202a88b446.m_wedges[1]);
	}

	public bool cdbb96bb21cbf3f95e90d131174daad95(QEMWedge c4a200d87ae4fe6027824130751792533, QEMWedge cbdb3252d8461e55dfd1543b8f79efa39)
	{
		if (m_wedges[0] == c4a200d87ae4fe6027824130751792533)
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
			if (m_wedges[1] == cbdb3252d8461e55dfd1543b8f79efa39)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		if (m_wedges[1] == c4a200d87ae4fe6027824130751792533)
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
			if (m_wedges[0] == cbdb3252d8461e55dfd1543b8f79efa39)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool cbd5838c1972c6cb63c8b35385a8b61bb()
	{
		return m_qemDirty;
	}

	public void c77e47406ba7bd585d4dafae8447630e1()
	{
		m_qemDirty = true;
	}

	public void c6118ba7d2e2d850c4a5785dc60710d40()
	{
		if (cf6dcc26ca88bb58eafc05cb9cc7cfa44)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_wedges[0].c21369586b2ed957a19da994dff5f452e(ref QEMMatrix.s_tempQEMMatrix1);
					m_wedges[1].c21369586b2ed957a19da994dff5f452e(ref QEMMatrix.s_tempQEMMatrix2);
					QEMMatrix.c9172684ab57085e2a77c2a3af69cb426(QEMMatrix.s_tempQEMMatrix1, QEMMatrix.s_tempQEMMatrix2, ref QEMMatrix.s_tempQEMMatrix0);
					QEMMatrix s_tempQEMMatrix = QEMMatrix.s_tempQEMMatrix0;
					if (!s_tempQEMMatrix.c37752a4bccdb3f5868cae3dedd2038d0(ref m_collapsePosition))
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
						m_collapsePosition.c034936ede6b65db0da600e58eb5611d2((m_wedges[0].c4cf00ced2bc60ae908904eb73692869f() + m_wedges[1].c4cf00ced2bc60ae908904eb73692869f()) / 2f);
						for (int i = 0; i < QEMMatrix.s_n - 3; i++)
						{
							m_collapsePosition.cfa95d8e518a4c412db818ebd69b402c3(i, (m_wedges[0].m_attributes[i] + m_wedges[1].m_attributes[i]) / 2f);
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
					}
					bool flag = false;
					QEMInput s_input = QEMCenter.s_input;
					int num = 0;
					if (s_input.m_normal != null)
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
						int c5612a459a84ffdb41c885401433cd62d = num++;
						int c5612a459a84ffdb41c885401433cd62d2 = num++;
						int c5612a459a84ffdb41c885401433cd62d3 = num++;
						float cefda2fdc3ce4e04f38bab77fc = m_collapsePosition.cbc6c23e986f6b4b045e27d64d700163c(c5612a459a84ffdb41c885401433cd62d);
						float cefda2fdc3ce4e04f38bab77fc2 = m_collapsePosition.cbc6c23e986f6b4b045e27d64d700163c(c5612a459a84ffdb41c885401433cd62d2);
						float cefda2fdc3ce4e04f38bab77fc3 = m_collapsePosition.cbc6c23e986f6b4b045e27d64d700163c(c5612a459a84ffdb41c885401433cd62d3);
						m_collapsePosition.cfa95d8e518a4c412db818ebd69b402c3(c5612a459a84ffdb41c885401433cd62d, cefda2fdc3ce4e04f38bab77fc);
						m_collapsePosition.cfa95d8e518a4c412db818ebd69b402c3(c5612a459a84ffdb41c885401433cd62d2, cefda2fdc3ce4e04f38bab77fc2);
						m_collapsePosition.cfa95d8e518a4c412db818ebd69b402c3(c5612a459a84ffdb41c885401433cd62d3, cefda2fdc3ce4e04f38bab77fc3);
					}
					m_error = s_tempQEMMatrix.cadb490a5154195ab279210bc338e9d5a(m_collapsePosition);
					if (flag)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								m_error = float.MaxValue;
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		m_error = float.MaxValue;
	}

	public void c38ca93c671d5871fef52bbdb82094c03()
	{
		QEMMatrix s_tempQEMMatrix = QEMMatrix.s_tempQEMMatrix0;
		s_tempQEMMatrix.c92eb2231f43bdb532bac8326ea4b2f1b();
		QEMFace qEMFace = c8d80af39f8dee3ba211584bc3f457480();
		if (qEMFace == null)
		{
			return;
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
			Vector3 lhs = qEMFace.cc9bb89b7fc71502fe2bd38e5d49adcb7(false);
			QEMWedge qEMWedge = c48d60e9291bc8b78642749e4ce8ba9ca.c7088de59e49f7108f520cf7e0bae167e;
			QEMWedge qEMWedge2 = c48d60e9291bc8b78642749e4ce8ba9ca.c7088de59e49f7108f520cf7e0bae167e;
			for (int i = 0; i < 3; i++)
			{
				if (m_wedges[0] == qEMFace.m_wedges[i])
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
					qEMWedge = m_wedges[0];
					qEMWedge2 = m_wedges[1];
					continue;
				}
				if (m_wedges[1] != qEMFace.m_wedges[i])
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
					break;
				}
				qEMWedge = m_wedges[1];
				qEMWedge2 = m_wedges[0];
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				Vector3 vector = Vector3.Cross(lhs, qEMWedge2.c4cf00ced2bc60ae908904eb73692869f() - qEMWedge.c4cf00ced2bc60ae908904eb73692869f());
				vector.Normalize();
				float cf0ecbb9b13151932b8293691a84d1c = 0f - Vector3.Dot(m_wedges[0].c4cf00ced2bc60ae908904eb73692869f(), vector);
				QEMInput s_input = QEMCenter.s_input;
				for (int j = 0; j < 2; j++)
				{
					QEMWedge qEMWedge3 = m_wedges[j];
					s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(vector, cf0ecbb9b13151932b8293691a84d1c);
					int num = 0;
					if (s_input.m_uv != null)
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
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_uvWeight * qEMWedge3.m_attributes[num], num);
						num++;
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_uvWeight * qEMWedge3.m_attributes[num], num);
						num++;
					}
					if (s_input.m_uv2 != null)
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
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_uv2Weight * qEMWedge3.m_attributes[num], num);
						num++;
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_uv2Weight * qEMWedge3.m_attributes[num], num);
						num++;
					}
					if (s_input.m_normal != null)
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
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_normalWeight * qEMWedge3.m_attributes[num], num);
						num++;
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_normalWeight * qEMWedge3.m_attributes[num], num);
						num++;
						s_tempQEMMatrix.c8c08e5af03dde832c7190b0eccb38a93(s_input.m_normalWeight * qEMWedge3.m_attributes[num], num);
						num++;
					}
					s_tempQEMMatrix.ccb0d23031f36ef9d9e72c797d8c717e4(QEMCenter.s_input.s_boundaryPlaneWeight);
					qEMWedge3.m_boundaryQEM.c9172684ab57085e2a77c2a3af69cb426(s_tempQEMMatrix);
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
		}
	}

	public float cadb490a5154195ab279210bc338e9d5a()
	{
		if (m_qemDirty)
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
			c6118ba7d2e2d850c4a5785dc60710d40();
			m_qemDirty = false;
		}
		return m_error;
	}

	public QEMVectorN c0db42106bdaa19a2109fd3e327423f16()
	{
		if (m_qemDirty)
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
			c6118ba7d2e2d850c4a5785dc60710d40();
			m_qemDirty = false;
		}
		return m_collapsePosition;
	}
}
