using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class QEMWedge
{
	public LinkedList<QEMFace> m_faces = new LinkedList<QEMFace>();

	public QEMVertex m_vertex;

	public QEMMatrix m_boundaryQEM = new QEMMatrix();

	public float[] m_attributes;

	public bool cf6dcc26ca88bb58eafc05cb9cc7cfa44
	{
		get
		{
			return m_vertex != cc789528c0b2099d2e31b9088d304e1a9.c7088de59e49f7108f520cf7e0bae167e;
		}
		set
		{
			if (value)
			{
				while (true)
				{
					switch (4)
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
			m_vertex = cc789528c0b2099d2e31b9088d304e1a9.c7088de59e49f7108f520cf7e0bae167e;
		}
	}

	public QEMWedge()
	{
		m_boundaryQEM.c92eb2231f43bdb532bac8326ea4b2f1b();
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return m_vertex.m_pos;
	}

	public QEMEdge cbd23cd3d26a452dc0588a63ce92f5076(QEMWedge cf312a174496712827bd0ffaff85b09ea)
	{
		QEMEdge qEMEdge = c705340d8da95af6e1ea9c1a42c7a24d2.c7088de59e49f7108f520cf7e0bae167e;
		using (LinkedList<QEMFace>.Enumerator enumerator = m_faces.GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					QEMFace current = enumerator.Current;
					qEMEdge = current.cbd23cd3d26a452dc0588a63ce92f5076(this, cf312a174496712827bd0ffaff85b09ea);
					if (qEMEdge == null)
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						break;
					}
					break;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_004e;
					}
					continue;
					end_IL_004e:
					break;
				}
				break;
			}
		}
		return qEMEdge;
	}

	public void c21369586b2ed957a19da994dff5f452e(ref QEMMatrix cdbee49fe29de456df5bf99adb8c01e72)
	{
		QEMMatrix.c9172684ab57085e2a77c2a3af69cb426(m_vertex.c21369586b2ed957a19da994dff5f452e(), m_boundaryQEM, ref cdbee49fe29de456df5bf99adb8c01e72);
	}
}
