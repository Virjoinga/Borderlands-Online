using System.Collections.Generic;
using Core;
using UnityEngine;

public class QEMVertex
{
	public LinkedList<QEMWedge> m_wedges = new LinkedList<QEMWedge>();

	public Vector3 m_pos;

	private QEMMatrix m_qem = new QEMMatrix();

	public bool m_dirty = true;

	public bool cf6dcc26ca88bb58eafc05cb9cc7cfa44
	{
		get
		{
			return m_pos.x != float.MaxValue;
		}
		set
		{
			if (value)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "set valid to true ??");
						return;
					}
				}
			}
			m_pos.x = float.MaxValue;
		}
	}

	public void c4c3d24f73b9ed5a97ecddeaad9e4c6c3(QEMWedge c86c4e778d832501632b63ddc74852926)
	{
		m_wedges.AddFirst(c86c4e778d832501632b63ddc74852926);
		c86c4e778d832501632b63ddc74852926.m_vertex = this;
	}

	public bool c1a84901a0a9ec83a0000feb026941d27(QEMFace c08620e3a064e9157076164058c01bf56)
	{
		using (LinkedList<QEMWedge>.Enumerator enumerator = m_wedges.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QEMWedge current = enumerator.Current;
				if (!current.m_faces.Contains(c08620e3a064e9157076164058c01bf56))
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
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_004c;
				}
				continue;
				end_IL_004c:
				break;
			}
		}
		return false;
	}

	public void c6118ba7d2e2d850c4a5785dc60710d40()
	{
		m_qem.c92eb2231f43bdb532bac8326ea4b2f1b();
		using (LinkedList<QEMWedge>.Enumerator enumerator = m_wedges.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QEMWedge current = enumerator.Current;
				using (LinkedList<QEMFace>.Enumerator enumerator2 = current.m_faces.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						QEMFace current2 = enumerator2.Current;
						if (!current2.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
						m_qem.c9172684ab57085e2a77c2a3af69cb426(current2.c21369586b2ed957a19da994dff5f452e());
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_007d;
						}
						continue;
						end_IL_007d:
						break;
					}
				}
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

	public QEMMatrix c21369586b2ed957a19da994dff5f452e()
	{
		if (m_dirty)
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
			m_dirty = false;
		}
		return m_qem;
	}

	public void c9b1d0dbe283462b532b8dfa340a18e2f(bool ca2ad00165f7b4d6ebf0d2cb7ea0dce9c)
	{
		m_dirty = true;
		if (!ca2ad00165f7b4d6ebf0d2cb7ea0dce9c)
		{
			return;
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
			using (LinkedList<QEMWedge>.Enumerator enumerator = m_wedges.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					QEMWedge current = enumerator.Current;
					using (LinkedList<QEMFace>.Enumerator enumerator2 = current.m_faces.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							QEMFace current2 = enumerator2.Current;
							current2.c9b1d0dbe283462b532b8dfa340a18e2f();
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								goto end_IL_0065;
							}
							continue;
							end_IL_0065:
							break;
						}
					}
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
	}
}
