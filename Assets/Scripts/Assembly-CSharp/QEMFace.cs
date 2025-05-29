using A;
using UnityEngine;

public class QEMFace
{
	private bool m_dirty = true;

	public int m_index = -1;

	private QEMMatrix m_qem = new QEMMatrix();

	public QEMWedge[] m_wedges = cdcbc296938a35851f7ca72abfc075b20.c0a0cdf4a196914163f7334d9b0781a04(3);

	public QEMEdge[] m_edges = c082a45c3c5983ef1fd54af5c7be032ef.c0a0cdf4a196914163f7334d9b0781a04(3);

	public bool cf6dcc26ca88bb58eafc05cb9cc7cfa44
	{
		get
		{
			int result;
			if (!c44767225a54497a5723cf5f4fce5ce90())
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
				if (m_wedges[0].cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
					if (m_wedges[1].cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
						result = (m_wedges[2].cf6dcc26ca88bb58eafc05cb9cc7cfa44 ? 1 : 0);
						goto IL_0065;
					}
				}
			}
			result = 0;
			goto IL_0065;
			IL_0065:
			return (byte)result != 0;
		}
	}

	public Vector3 cc9bb89b7fc71502fe2bd38e5d49adcb7(bool cc5fa6fc46eed5c96391361badf1a2ab8)
	{
		Vector3 result = Vector3.Cross(m_wedges[2].c4cf00ced2bc60ae908904eb73692869f() - m_wedges[0].c4cf00ced2bc60ae908904eb73692869f(), m_wedges[1].c4cf00ced2bc60ae908904eb73692869f() - m_wedges[0].c4cf00ced2bc60ae908904eb73692869f());
		if (cc5fa6fc46eed5c96391361badf1a2ab8)
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
			result.Normalize();
		}
		return result;
	}

	public void c6247b97516f0f47835aa21a8285ce7e5(QEMFace ceacb19a4ed73f90d25df5977139fddb1)
	{
		ceacb19a4ed73f90d25df5977139fddb1.m_dirty = m_dirty;
		ceacb19a4ed73f90d25df5977139fddb1.m_index = m_index;
		ceacb19a4ed73f90d25df5977139fddb1.m_qem = m_qem;
		for (int i = 0; i < 3; i++)
		{
			ceacb19a4ed73f90d25df5977139fddb1.m_wedges[i] = m_wedges[i];
			ceacb19a4ed73f90d25df5977139fddb1.m_edges[i] = m_edges[i];
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

	public bool c1a84901a0a9ec83a0000feb026941d27(QEMVertex cf312a174496712827bd0ffaff85b09ea)
	{
		for (int i = 0; i < 3; i++)
		{
			if (m_wedges[i].m_vertex != cf312a174496712827bd0ffaff85b09ea)
			{
				continue;
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
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool c1a84901a0a9ec83a0000feb026941d27(QEMWedge cc63a40108f7294f19e932d331ffc0f14)
	{
		for (int i = 0; i < 3; i++)
		{
			if (m_wedges[i] != cc63a40108f7294f19e932d331ffc0f14)
			{
				continue;
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
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public void c32cf55f13000f40e78c6c1f181906bd7(QEMVertex cfff08344d577dfd995985a589b33ca8d, QEMWedge cfa63594be247513e241b09e266fa90d3)
	{
		for (int i = 0; i < 3; i++)
		{
			if (m_wedges[i].m_vertex != cfff08344d577dfd995985a589b33ca8d)
			{
				continue;
			}
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
			m_wedges[i] = cfa63594be247513e241b09e266fa90d3;
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

	public void c32cf55f13000f40e78c6c1f181906bd7(QEMWedge cfff08344d577dfd995985a589b33ca8d, QEMWedge cfa63594be247513e241b09e266fa90d3)
	{
		for (int i = 0; i < 3; i++)
		{
			if (m_wedges[i] != cfff08344d577dfd995985a589b33ca8d)
			{
				continue;
			}
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
			m_wedges[i] = cfa63594be247513e241b09e266fa90d3;
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

	public void c9b1d0dbe283462b532b8dfa340a18e2f()
	{
		m_dirty = true;
		for (int i = 0; i < m_wedges.Length; i++)
		{
			m_wedges[i].m_vertex.c9b1d0dbe283462b532b8dfa340a18e2f(false);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int j = 0; j < m_edges.Length; j++)
			{
				m_edges[j].c77e47406ba7bd585d4dafae8447630e1();
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void cd22527053972c81bf74cfa59e3e03f63(QEMWedge c717a3ea9ed38fe2cf3fda474da17add7, QEMWedge c289bc02b6c274e03a8038ed85afe221b, QEMWedge cc2007a85e7b289ff7842834adc1804e6, Vector3 cf5d861c74bc5f76089eaa0e6f21526c0, int cb8e962c8bc667a610ba2ab548fa78ab6, float cea8bc0ff9f39b928110f79da66ab6ab7)
	{
		m_qem.c8c08e5af03dde832c7190b0eccb38a93(c717a3ea9ed38fe2cf3fda474da17add7.c4cf00ced2bc60ae908904eb73692869f(), c289bc02b6c274e03a8038ed85afe221b.c4cf00ced2bc60ae908904eb73692869f(), cc2007a85e7b289ff7842834adc1804e6.c4cf00ced2bc60ae908904eb73692869f(), cf5d861c74bc5f76089eaa0e6f21526c0, c717a3ea9ed38fe2cf3fda474da17add7.m_attributes[cb8e962c8bc667a610ba2ab548fa78ab6] * cea8bc0ff9f39b928110f79da66ab6ab7, c289bc02b6c274e03a8038ed85afe221b.m_attributes[cb8e962c8bc667a610ba2ab548fa78ab6] * cea8bc0ff9f39b928110f79da66ab6ab7, cc2007a85e7b289ff7842834adc1804e6.m_attributes[cb8e962c8bc667a610ba2ab548fa78ab6] * cea8bc0ff9f39b928110f79da66ab6ab7, cb8e962c8bc667a610ba2ab548fa78ab6);
	}

	public void c6118ba7d2e2d850c4a5785dc60710d40()
	{
		QEMWedge qEMWedge = m_wedges[0];
		QEMWedge qEMWedge2 = m_wedges[1];
		QEMWedge qEMWedge3 = m_wedges[2];
		if (qEMWedge.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
			if (qEMWedge2.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
				if (qEMWedge3.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
						{
							Vector3 vector = cc9bb89b7fc71502fe2bd38e5d49adcb7(true);
							m_qem.c8c08e5af03dde832c7190b0eccb38a93(vector, 0f - Vector3.Dot(qEMWedge.c4cf00ced2bc60ae908904eb73692869f(), vector));
							int num = 0;
							QEMInput s_input = QEMCenter.s_input;
							if (s_input.m_uv != null)
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
								cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_uvWeight);
								cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_uvWeight);
							}
							if (s_input.m_uv2 != null)
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
								cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_uv2Weight);
								cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_uv2Weight);
							}
							if (s_input.m_normal != null)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_normalWeight);
										cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_normalWeight);
										cd22527053972c81bf74cfa59e3e03f63(qEMWedge, qEMWedge2, qEMWedge3, vector, num++, s_input.m_normalWeight);
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
			}
		}
		m_qem.c92eb2231f43bdb532bac8326ea4b2f1b();
	}

	public QEMMatrix c21369586b2ed957a19da994dff5f452e()
	{
		if (m_dirty)
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
			c6118ba7d2e2d850c4a5785dc60710d40();
			m_dirty = false;
		}
		return m_qem;
	}

	public bool c44767225a54497a5723cf5f4fce5ce90()
	{
		int result;
		if (m_wedges[0].m_vertex != m_wedges[1].m_vertex)
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
			if (m_wedges[0].m_vertex != m_wedges[2].m_vertex)
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
				result = ((m_wedges[1].m_vertex == m_wedges[2].m_vertex) ? 1 : 0);
				goto IL_0074;
			}
		}
		result = 1;
		goto IL_0074;
		IL_0074:
		return (byte)result != 0;
	}

	public QEMEdge cbd23cd3d26a452dc0588a63ce92f5076(QEMWedge c4a200d87ae4fe6027824130751792533, QEMWedge cbdb3252d8461e55dfd1543b8f79efa39)
	{
		QEMEdge result = c705340d8da95af6e1ea9c1a42c7a24d2.c7088de59e49f7108f520cf7e0bae167e;
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				if (m_edges[num] != null)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_edges[num].cdbb96bb21cbf3f95e90d131174daad95(c4a200d87ae4fe6027824130751792533, cbdb3252d8461e55dfd1543b8f79efa39))
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
						result = m_edges[num];
						break;
					}
				}
				num++;
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			break;
		}
		return result;
	}

	public QEMEdge cdf9593eb00108088dda44700eb03cd16(QEMWedge c4a200d87ae4fe6027824130751792533, QEMWedge cbdb3252d8461e55dfd1543b8f79efa39)
	{
		QEMEdge qEMEdge = c705340d8da95af6e1ea9c1a42c7a24d2.c7088de59e49f7108f520cf7e0bae167e;
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				if (m_wedges[num] == c4a200d87ae4fe6027824130751792533)
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
					qEMEdge = c4a200d87ae4fe6027824130751792533.cbd23cd3d26a452dc0588a63ce92f5076(cbdb3252d8461e55dfd1543b8f79efa39);
				}
				else if (m_wedges[num] == cbdb3252d8461e55dfd1543b8f79efa39)
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
					qEMEdge = cbdb3252d8461e55dfd1543b8f79efa39.cbd23cd3d26a452dc0588a63ce92f5076(c4a200d87ae4fe6027824130751792533);
				}
				if (qEMEdge != null)
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
					break;
				}
				num++;
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
			break;
		}
		return qEMEdge;
	}
}
