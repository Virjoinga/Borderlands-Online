using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

internal class QEMCenter
{
	public const bool CHECKERROR = true;

	public static QEMInput s_input;

	private BinaryHeap m_edgeHeap;

	private QEMFace[] m_allFaces;

	private QEMVertex[] m_allVertices;

	private QEMFace m_tempFace;

	private QEMVertex m_tempVertex;

	private int m_targetFaceNumber;

	private int m_activeFaceNumber;

	public QEMCenter(QEMInput ce00d51a1fe36853f765e24d398dc3da9)
	{
		cbba4da89e249920884b1bd7aa03874c3(ce00d51a1fe36853f765e24d398dc3da9);
		ce57f3058e06bb976ce3c8dd24e50d988();
	}

	private void cbba4da89e249920884b1bd7aa03874c3(QEMInput ce00d51a1fe36853f765e24d398dc3da9)
	{
		s_input = ce00d51a1fe36853f765e24d398dc3da9;
		int num = 3;
		if (ce00d51a1fe36853f765e24d398dc3da9.m_uv != null)
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
			num += 2;
		}
		if (ce00d51a1fe36853f765e24d398dc3da9.m_uv2 != null)
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
			num += 2;
		}
		if (ce00d51a1fe36853f765e24d398dc3da9.m_normal != null)
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
			num += 3;
		}
		QEMMatrix.ccc9d3a38966dc10fedb531ea17d24611(num);
		m_tempFace = new QEMFace();
		m_tempVertex = new QEMVertex();
	}

	public void ce335f34f1427f544af38c891245c831b(QEMFace c08620e3a064e9157076164058c01bf56, List<QEMEdge> c33797d11aa05ac4eee525c7a1aef377a)
	{
		int[,] array = new int[3, 2]
		{
			{ 0, 1 },
			{ 0, 2 },
			{ 1, 2 }
		};
		for (int i = 0; i < 3; i++)
		{
			QEMWedge qEMWedge = c08620e3a064e9157076164058c01bf56.m_wedges[array[i, 0]];
			QEMWedge qEMWedge2 = c08620e3a064e9157076164058c01bf56.m_wedges[array[i, 1]];
			if (c08620e3a064e9157076164058c01bf56.m_edges[i] != null)
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
			QEMEdge qEMEdge = c08620e3a064e9157076164058c01bf56.cdf9593eb00108088dda44700eb03cd16(qEMWedge, qEMWedge2);
			if (qEMEdge == null)
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
				qEMEdge = new QEMEdge();
				qEMEdge.m_wedges[0] = qEMWedge;
				qEMEdge.m_wedges[1] = qEMWedge2;
				qEMEdge.m_ref = 1;
				c33797d11aa05ac4eee525c7a1aef377a.Add(qEMEdge);
			}
			else
			{
				qEMEdge.m_ref++;
			}
			c08620e3a064e9157076164058c01bf56.m_edges[i] = qEMEdge;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void ce335f34f1427f544af38c891245c831b(QEMFace c08620e3a064e9157076164058c01bf56)
	{
		int[,] array = new int[3, 2]
		{
			{ 0, 1 },
			{ 0, 2 },
			{ 1, 2 }
		};
		for (int i = 0; i < 3; i++)
		{
			QEMWedge qEMWedge = c08620e3a064e9157076164058c01bf56.m_wedges[array[i, 0]];
			QEMWedge qEMWedge2 = c08620e3a064e9157076164058c01bf56.m_wedges[array[i, 1]];
			if (c08620e3a064e9157076164058c01bf56.m_edges[i].cdbb96bb21cbf3f95e90d131174daad95(qEMWedge, qEMWedge2))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			QEMEdge qEMEdge = c08620e3a064e9157076164058c01bf56.cdf9593eb00108088dda44700eb03cd16(qEMWedge, qEMWedge2);
			if (qEMEdge == null)
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
				qEMEdge = c08620e3a064e9157076164058c01bf56.m_edges[i];
				qEMEdge.m_wedges[0] = qEMWedge;
				qEMEdge.m_wedges[1] = qEMWedge2;
			}
			else
			{
				m_edgeHeap.c7605b6a8df360621e4eb06fe0b47814b(c08620e3a064e9157076164058c01bf56.m_edges[i].m_index);
				c08620e3a064e9157076164058c01bf56.m_edges[i] = qEMEdge;
				qEMEdge.m_ref++;
			}
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

	public void cd49e6e5161ef5ccbaf69509993040901(string c709b291ceac9f97f0c78f269054fa014)
	{
		if (!string.IsNullOrEmpty(c709b291ceac9f97f0c78f269054fa014))
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, c709b291ceac9f97f0c78f269054fa014);
		}
		for (int i = 0; i < m_allFaces.Length; i++)
		{
			QEMFace qEMFace = m_allFaces[i];
			if (qEMFace.m_index != i)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 0");
			}
			if (!qEMFace.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
			{
				continue;
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
			if (qEMFace.c44767225a54497a5723cf5f4fce5ce90())
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 1");
			}
			QEMWedge c4a200d87ae4fe6027824130751792533 = qEMFace.m_wedges[0];
			QEMWedge qEMWedge = qEMFace.m_wedges[1];
			QEMWedge cbdb3252d8461e55dfd1543b8f79efa = qEMFace.m_wedges[2];
			QEMEdge qEMEdge = qEMFace.m_edges[0];
			QEMEdge qEMEdge2 = qEMFace.m_edges[1];
			QEMEdge qEMEdge3 = qEMFace.m_edges[2];
			for (int j = 0; j < 3; j++)
			{
				QEMWedge qEMWedge2 = qEMFace.m_wedges[j];
				if (qEMWedge2.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 2");
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
			if (!qEMEdge.cdbb96bb21cbf3f95e90d131174daad95(c4a200d87ae4fe6027824130751792533, qEMWedge))
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 3");
			}
			if (!qEMEdge2.cdbb96bb21cbf3f95e90d131174daad95(c4a200d87ae4fe6027824130751792533, cbdb3252d8461e55dfd1543b8f79efa))
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 4");
			}
			if (!qEMEdge3.cdbb96bb21cbf3f95e90d131174daad95(qEMWedge, cbdb3252d8461e55dfd1543b8f79efa))
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 5");
			}
			for (int k = 0; k < 3; k++)
			{
				QEMWedge qEMWedge3 = qEMFace.m_wedges[k];
				using (LinkedList<QEMFace>.Enumerator enumerator = qEMWedge3.m_faces.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						QEMFace current = enumerator.Current;
						if (!current.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
							DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 6");
						}
						if (current.c1a84901a0a9ec83a0000feb026941d27(qEMWedge3))
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Face Error 7");
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_01ec;
						}
						continue;
						end_IL_01ec:
						break;
					}
				}
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
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			int num = 0;
			while (num < m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36())
			{
				QEMEdge qEMEdge4 = m_edgeHeap.c588e7dbcd383d8230b2d83d7b44af23b(num);
				for (int l = num + 1; l < m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36(); l++)
				{
					QEMEdge qEMEdge5 = m_edgeHeap.c588e7dbcd383d8230b2d83d7b44af23b(l);
					if (!qEMEdge5.cdbb96bb21cbf3f95e90d131174daad95(qEMEdge4))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Edge Error 0");
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					if (!qEMEdge4.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Edge Error 1");
					}
					if (qEMEdge4.m_index >= m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36())
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Edge Error 2");
					}
					if (qEMEdge4.m_ref <= 0)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Edge Error 2");
					}
					num++;
					break;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				for (int m = 0; m < m_allVertices.Length; m++)
				{
					QEMVertex qEMVertex = m_allVertices[m];
					if (qEMVertex == null)
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!qEMVertex.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
					using (LinkedList<QEMWedge>.Enumerator enumerator2 = qEMVertex.m_wedges.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							QEMWedge current2 = enumerator2.Current;
							if (current2.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
							DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "Vert Error 0");
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_03bd;
							}
							continue;
							end_IL_03bd:
							break;
						}
					}
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
	}

	public void ce57f3058e06bb976ce3c8dd24e50d988()
	{
		Vector3[] vertex = s_input.m_vertex;
		int[] triangle = s_input.m_triangle;
		Vector2[] uv = s_input.m_uv;
		Vector2[] uv2 = s_input.m_uv2;
		Vector3[] normal = s_input.m_normal;
		m_allVertices = c36f52f4aa36808206b5ea5aab6bb2b0e.c0a0cdf4a196914163f7334d9b0781a04(vertex.Length);
		m_allFaces = c6190266b7d2d57e3d9dfed0c990102ce.c0a0cdf4a196914163f7334d9b0781a04(triangle.Length / 3);
		m_activeFaceNumber = m_allFaces.Length;
		m_targetFaceNumber = (int)((float)m_activeFaceNumber * s_input.m_percentage);
		for (int i = 0; i < m_allVertices.Length; i++)
		{
			QEMVertex qEMVertex = (m_allVertices[i] = new QEMVertex());
			qEMVertex.m_pos = vertex[i];
			QEMWedge qEMWedge = new QEMWedge();
			if (QEMMatrix.s_n > 3)
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
				qEMWedge.m_attributes = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(QEMMatrix.s_n - 3);
				int num = 0;
				if (uv != null)
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
					qEMWedge.m_attributes[num++] = uv[i].x;
					qEMWedge.m_attributes[num++] = uv[i].y;
				}
				if (uv2 != null)
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
					qEMWedge.m_attributes[num++] = uv2[i].x;
					qEMWedge.m_attributes[num++] = uv2[i].y;
				}
				if (normal != null)
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
					qEMWedge.m_attributes[num++] = normal[i].x;
					qEMWedge.m_attributes[num++] = normal[i].y;
					qEMWedge.m_attributes[num++] = normal[i].z;
				}
			}
			qEMVertex.c4c3d24f73b9ed5a97ecddeaad9e4c6c3(qEMWedge);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_allFaces.Length; j++)
			{
				int num2 = triangle[3 * j];
				int num3 = triangle[3 * j + 1];
				int num4 = triangle[3 * j + 2];
				if (num2 == num3)
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
				if (num2 == num4)
				{
					continue;
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
				if (num3 == num4)
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
				QEMFace qEMFace = (m_allFaces[j] = new QEMFace());
				qEMFace.m_index = j;
				for (int k = 0; k < 3; k++)
				{
					int num5 = triangle[3 * j + k];
					qEMFace.m_wedges[k] = m_allVertices[num5].m_wedges.First.Value;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				float num6 = s_input.s_vertexCombineThreshold * s_input.s_vertexCombineThreshold;
				for (int l = 0; l < m_allVertices.Length; l++)
				{
					QEMVertex qEMVertex2 = m_allVertices[l];
					if (qEMVertex2 == null)
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
						break;
					}
					for (int m = l + 1; m < m_allVertices.Length; m++)
					{
						QEMVertex qEMVertex3 = m_allVertices[m];
						if (qEMVertex3 == null)
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
							break;
						}
						if (!((qEMVertex2.m_pos - qEMVertex3.m_pos).sqrMagnitude < num6))
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
						using (LinkedList<QEMWedge>.Enumerator enumerator = qEMVertex3.m_wedges.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								QEMWedge current = enumerator.Current;
								qEMVertex2.c4c3d24f73b9ed5a97ecddeaad9e4c6c3(current);
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									goto end_IL_03a9;
								}
								continue;
								end_IL_03a9:
								break;
							}
						}
						qEMVertex3.m_wedges.Clear();
						m_allVertices[m] = null;
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
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					List<QEMEdge> list = new List<QEMEdge>(m_allFaces.Length * 3);
					for (int n = 0; n < m_allFaces.Length; n++)
					{
						QEMFace qEMFace2 = m_allFaces[n];
						if (qEMFace2 == null)
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
						for (int num7 = 0; num7 < 3; num7++)
						{
							qEMFace2.m_wedges[num7].m_faces.AddFirst(qEMFace2);
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
						ce335f34f1427f544af38c891245c831b(qEMFace2, list);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						using (List<QEMEdge>.Enumerator enumerator2 = list.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								QEMEdge current2 = enumerator2.Current;
								current2.c38ca93c671d5871fef52bbdb82094c03();
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									goto end_IL_04c8;
								}
								continue;
								end_IL_04c8:
								break;
							}
						}
						m_edgeHeap = new BinaryHeap(list.ToArray());
						return;
					}
				}
			}
		}
	}

	public void c624e1595d9343108a5af5816211ee871(Mesh c56b619f725ce213e27e56f775bbcb3a8)
	{
		List<Vector3> list = new List<Vector3>();
		List<Vector2> list2 = c794c2821067af0defda4b2189623f800.c7088de59e49f7108f520cf7e0bae167e;
		if (s_input.m_uv != null)
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
			list2 = new List<Vector2>();
		}
		List<Vector2> list3 = c794c2821067af0defda4b2189623f800.c7088de59e49f7108f520cf7e0bae167e;
		if (s_input.m_uv2 != null)
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
			list3 = new List<Vector2>();
		}
		List<Vector3> list4 = c8b136fa6b18ac3f2bd0db74fc6db220e.c7088de59e49f7108f520cf7e0bae167e;
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
			list4 = new List<Vector3>();
		}
		List<int> list5 = new List<int>(m_allFaces.Length * 3);
		int[,] array = new int[m_allFaces.Length, 3];
		for (int i = 0; i < m_allFaces.Length; i++)
		{
			array[i, 0] = (array[i, 1] = (array[i, 2] = -1));
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_allFaces.Length; j++)
			{
				QEMFace qEMFace = m_allFaces[j];
				if (qEMFace == null)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!qEMFace.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
				for (int k = 0; k < 3; k++)
				{
					if (array[j, k] >= 0)
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
					int count = list.Count;
					QEMWedge qEMWedge = qEMFace.m_wedges[k];
					list.Add(qEMWedge.c4cf00ced2bc60ae908904eb73692869f());
					int num = 0;
					if (list2 != null)
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
						list2.Add(new Vector2(qEMWedge.m_attributes[num], qEMWedge.m_attributes[num + 1]));
						num += 2;
					}
					if (list3 != null)
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
						list3.Add(new Vector2(qEMWedge.m_attributes[num], qEMWedge.m_attributes[num + 1]));
						num += 2;
					}
					if (list4 != null)
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
						list4.Add(new Vector3(qEMWedge.m_attributes[num], qEMWedge.m_attributes[num + 1], qEMWedge.m_attributes[num + 2]));
						num += 3;
					}
					array[j, k] = count;
					using (LinkedList<QEMFace>.Enumerator enumerator = qEMWedge.m_faces.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							QEMFace current = enumerator.Current;
							if (!current.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
							for (int l = 0; l < 3; l++)
							{
								if (current.m_wedges[l] != qEMWedge)
								{
									continue;
								}
								while (true)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									break;
								}
								array[current.m_index, l] = count;
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
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								goto end_IL_029f;
							}
							continue;
							end_IL_029f:
							break;
						}
					}
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
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				for (int m = 0; m < m_allFaces.Length; m++)
				{
					bool flag = true;
					int num2 = 0;
					while (true)
					{
						if (num2 < 3)
						{
							if (array[m, num2] < 0)
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
								flag = false;
								break;
							}
							num2++;
							continue;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						break;
					}
					if (!flag)
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					for (int n = 0; n < 3; n++)
					{
						list5.Add(array[m, n]);
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					c56b619f725ce213e27e56f775bbcb3a8.vertices = list.ToArray();
					c56b619f725ce213e27e56f775bbcb3a8.triangles = list5.ToArray();
					if (list2 != null)
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
						c56b619f725ce213e27e56f775bbcb3a8.uv = list2.ToArray();
					}
					if (list3 != null)
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
						c56b619f725ce213e27e56f775bbcb3a8.uv2 = list3.ToArray();
					}
					if (list4 == null)
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
						c56b619f725ce213e27e56f775bbcb3a8.normals = list4.ToArray();
						return;
					}
				}
			}
		}
	}

	public void c5d4e5f2506c6b95a571431abe9acb13e(int c9b15165c908ac1f9e9396c57137d3a67)
	{
		for (int i = 0; i < c9b15165c908ac1f9e9396c57137d3a67; i++)
		{
			while (true)
			{
				QEMEdge qEMEdge = m_edgeHeap.c588e7dbcd383d8230b2d83d7b44af23b(0);
				if (qEMEdge != null)
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
					if (qEMEdge.cadb490a5154195ab279210bc338e9d5a() != float.MaxValue)
					{
						if (c5d4e5f2506c6b95a571431abe9acb13e(qEMEdge))
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
							c13ff105f8cdfbc0be4d8c336cb364697(qEMEdge);
							if (qEMEdge.m_index >= m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36())
							{
								break;
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
							DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "edge not popped");
							break;
						}
						m_edgeHeap.c7e4505ee001438e40aa253c75194b708(0);
						if (m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36() > 0)
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
							break;
						}
						break;
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
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "No Edge To Collapse");
				return;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			cd49e6e5161ef5ccbaf69509993040901(string.Empty);
			return;
		}
	}

	public void c5d4e5f2506c6b95a571431abe9acb13e()
	{
		while (m_activeFaceNumber > m_targetFaceNumber)
		{
			QEMEdge qEMEdge = m_edgeHeap.c588e7dbcd383d8230b2d83d7b44af23b(0);
			if (qEMEdge != null)
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
				if (qEMEdge.cadb490a5154195ab279210bc338e9d5a() != float.MaxValue)
				{
					if (c5d4e5f2506c6b95a571431abe9acb13e(qEMEdge))
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
						c13ff105f8cdfbc0be4d8c336cb364697(qEMEdge);
						if (qEMEdge.m_index >= m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36())
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "edge not popped");
					}
					else
					{
						m_edgeHeap.c7e4505ee001438e40aa253c75194b708(0);
					}
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
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "No Edge To Collapse");
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			cd49e6e5161ef5ccbaf69509993040901(string.Empty);
			return;
		}
	}

	private void c13ff105f8cdfbc0be4d8c336cb364697(QEMEdge cf60f20a065ff24cf6f150a0def92ef0f)
	{
		QEMWedge qEMWedge = cf60f20a065ff24cf6f150a0def92ef0f.m_wedges[0];
		using (LinkedList<QEMWedge>.Enumerator enumerator = qEMWedge.m_vertex.m_wedges.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QEMWedge current = enumerator.Current;
				LinkedListNode<QEMFace> linkedListNode = current.m_faces.First;
				while (linkedListNode != null)
				{
					LinkedListNode<QEMFace> next = linkedListNode.Next;
					QEMFace value = linkedListNode.Value;
					if (!value.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
						current.m_faces.Remove(linkedListNode);
						for (int i = 0; i < 3; i++)
						{
							QEMWedge qEMWedge2 = value.m_wedges[i];
							if (qEMWedge2 == current)
							{
								continue;
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
							qEMWedge2.m_faces.Remove(value);
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
						ceb5bff23bb15ac3ef1fd11b24037bcd4(value);
						m_activeFaceNumber--;
					}
					linkedListNode = next;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_00fc;
				}
				continue;
				end_IL_00fc:
				break;
			}
		}
		using (LinkedList<QEMWedge>.Enumerator enumerator2 = qEMWedge.m_vertex.m_wedges.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				QEMWedge current2 = enumerator2.Current;
				using (LinkedList<QEMFace>.Enumerator enumerator3 = current2.m_faces.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						QEMFace current3 = enumerator3.Current;
						for (int j = 0; j < 3; j++)
						{
							QEMEdge qEMEdge = current3.m_edges[j];
							if (!qEMEdge.cbd5838c1972c6cb63c8b35385a8b61bb())
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
							if (qEMEdge.m_index >= m_edgeHeap.c7ed33d6df7751b2f5930fd83c9989c36())
							{
								continue;
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
							if (qEMEdge.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
								m_edgeHeap.c2f16e4b881ca4098c16d65a494a22542(qEMEdge.m_index);
							}
							else
							{
								m_edgeHeap.c7605b6a8df360621e4eb06fe0b47814b(qEMEdge.m_index);
								DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "m_edgeHeap.Pop(edge.m_index);");
							}
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_0210;
						}
						continue;
						end_IL_0210:
						break;
					}
				}
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

	public void ceb5bff23bb15ac3ef1fd11b24037bcd4(QEMFace c08620e3a064e9157076164058c01bf56)
	{
		for (int i = 0; i < 3; i++)
		{
			c08620e3a064e9157076164058c01bf56.m_edges[i].m_ref--;
			if (c08620e3a064e9157076164058c01bf56.m_edges[i].m_ref > 0)
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c08620e3a064e9157076164058c01bf56.m_edges[i].m_ref < 0)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "face.m_edges[i].m_ref < 0");
			}
			m_edgeHeap.c7605b6a8df360621e4eb06fe0b47814b(c08620e3a064e9157076164058c01bf56.m_edges[i].m_index);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private bool c5f61e28605a985ce54b6fcce777f0fea(QEMEdge c6160453ebc961fb52208ff202a88b446)
	{
		QEMWedge qEMWedge = c6160453ebc961fb52208ff202a88b446.m_wedges[0];
		QEMWedge qEMWedge2 = c6160453ebc961fb52208ff202a88b446.m_wedges[1];
		QEMVertex vertex = qEMWedge.m_vertex;
		QEMVertex vertex2 = qEMWedge2.m_vertex;
		m_tempVertex.m_pos = c6160453ebc961fb52208ff202a88b446.c0db42106bdaa19a2109fd3e327423f16().c4cf00ced2bc60ae908904eb73692869f();
		if (m_tempVertex.m_wedges.Count == 0)
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
			QEMWedge c86c4e778d832501632b63ddc = new QEMWedge();
			m_tempVertex.c4c3d24f73b9ed5a97ecddeaad9e4c6c3(c86c4e778d832501632b63ddc);
		}
		QEMWedge value = m_tempVertex.m_wedges.First.Value;
		using (LinkedList<QEMWedge>.Enumerator enumerator = vertex.m_wedges.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				QEMWedge current = enumerator.Current;
				LinkedListNode<QEMFace> linkedListNode = current.m_faces.First;
				while (linkedListNode != null)
				{
					LinkedListNode<QEMFace> next = linkedListNode.Next;
					QEMFace value2 = linkedListNode.Value;
					if (value2.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
						value2.c6247b97516f0f47835aa21a8285ce7e5(m_tempFace);
						m_tempFace.c32cf55f13000f40e78c6c1f181906bd7(vertex, value);
						m_tempFace.c32cf55f13000f40e78c6c1f181906bd7(vertex2, value);
						if (!m_tempFace.c44767225a54497a5723cf5f4fce5ce90())
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
							Vector3 lhs = value2.cc9bb89b7fc71502fe2bd38e5d49adcb7(false);
							Vector3 rhs = m_tempFace.cc9bb89b7fc71502fe2bd38e5d49adcb7(false);
							if (Vector3.Dot(lhs, rhs) < 0f)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										return false;
									}
								}
							}
						}
					}
					else
					{
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "v1 invalid face");
						current.m_faces.Remove(linkedListNode);
						for (int i = 0; i < 3; i++)
						{
							if (!value2.m_edges[i].cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
								break;
							}
							m_edgeHeap.c7605b6a8df360621e4eb06fe0b47814b(value2.m_edges[i].m_index);
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
					}
					linkedListNode = next;
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
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_0206;
				}
				continue;
				end_IL_0206:
				break;
			}
		}
		using (LinkedList<QEMWedge>.Enumerator enumerator2 = vertex2.m_wedges.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				QEMWedge current2 = enumerator2.Current;
				LinkedListNode<QEMFace> linkedListNode2 = current2.m_faces.First;
				while (linkedListNode2 != null)
				{
					LinkedListNode<QEMFace> next2 = linkedListNode2.Next;
					QEMFace value3 = linkedListNode2.Value;
					if (value3.cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
						value3.c6247b97516f0f47835aa21a8285ce7e5(m_tempFace);
						m_tempFace.c32cf55f13000f40e78c6c1f181906bd7(vertex, value);
						m_tempFace.c32cf55f13000f40e78c6c1f181906bd7(vertex2, value);
						if (!m_tempFace.c44767225a54497a5723cf5f4fce5ce90())
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
							Vector3 lhs2 = value3.cc9bb89b7fc71502fe2bd38e5d49adcb7(false);
							Vector3 rhs2 = m_tempFace.cc9bb89b7fc71502fe2bd38e5d49adcb7(false);
							if (Vector3.Dot(lhs2, rhs2) < 0f)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										return false;
									}
								}
							}
						}
					}
					else
					{
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "v2 invalid face");
						current2.m_faces.Remove(linkedListNode2);
						for (int j = 0; j < 3; j++)
						{
							if (!value3.m_edges[j].cf6dcc26ca88bb58eafc05cb9cc7cfa44)
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
							m_edgeHeap.c7605b6a8df360621e4eb06fe0b47814b(value3.m_edges[j].m_index);
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
					}
					linkedListNode2 = next2;
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
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_0395;
				}
				continue;
				end_IL_0395:
				break;
			}
		}
		return true;
	}

	public bool c5d4e5f2506c6b95a571431abe9acb13e(QEMEdge c6160453ebc961fb52208ff202a88b446)
	{
		c6160453ebc961fb52208ff202a88b446.m_error = float.MaxValue;
		if (c5f61e28605a985ce54b6fcce777f0fea(c6160453ebc961fb52208ff202a88b446))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					QEMWedge qEMWedge = c6160453ebc961fb52208ff202a88b446.m_wedges[0];
					QEMWedge qEMWedge2 = c6160453ebc961fb52208ff202a88b446.m_wedges[1];
					QEMVertex vertex = qEMWedge.m_vertex;
					QEMVertex vertex2 = qEMWedge2.m_vertex;
					QEMVectorN qEMVectorN = c6160453ebc961fb52208ff202a88b446.c0db42106bdaa19a2109fd3e327423f16();
					vertex.m_pos = qEMVectorN.c4cf00ced2bc60ae908904eb73692869f();
					int num = 0;
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
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_uvWeight;
						num++;
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_uvWeight;
						num++;
					}
					if (s_input.m_uv2 != null)
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
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_uv2Weight;
						num++;
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_uv2Weight;
						num++;
					}
					if (s_input.m_normal != null)
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
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_normalWeight;
						num++;
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_normalWeight;
						num++;
						qEMWedge.m_attributes[num] = qEMVectorN.cbc6c23e986f6b4b045e27d64d700163c(num) / s_input.m_normalWeight;
						num++;
					}
					using (LinkedList<QEMFace>.Enumerator enumerator = qEMWedge2.m_faces.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							QEMFace current = enumerator.Current;
							current.c32cf55f13000f40e78c6c1f181906bd7(qEMWedge2, qEMWedge);
							if (!current.c44767225a54497a5723cf5f4fce5ce90())
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
								qEMWedge.m_faces.AddFirst(current);
							}
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								goto end_IL_0202;
							}
							continue;
							end_IL_0202:
							break;
						}
					}
					qEMWedge.m_boundaryQEM.c9172684ab57085e2a77c2a3af69cb426(qEMWedge2.m_boundaryQEM);
					LinkedListNode<QEMWedge> linkedListNode = vertex2.m_wedges.First;
					while (linkedListNode != null)
					{
						QEMWedge value = linkedListNode.Value;
						LinkedListNode<QEMWedge> next = linkedListNode.Next;
						if (value != qEMWedge2)
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
							vertex.c4c3d24f73b9ed5a97ecddeaad9e4c6c3(value);
						}
						linkedListNode = next;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
						{
							using (LinkedList<QEMFace>.Enumerator enumerator2 = qEMWedge2.m_faces.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									QEMFace current2 = enumerator2.Current;
									ce335f34f1427f544af38c891245c831b(current2);
								}
								while (true)
								{
									switch (1)
									{
									case 0:
										break;
									default:
										goto end_IL_02ab;
									}
									continue;
									end_IL_02ab:
									break;
								}
							}
							vertex2.cf6dcc26ca88bb58eafc05cb9cc7cfa44 = false;
							qEMWedge2.cf6dcc26ca88bb58eafc05cb9cc7cfa44 = false;
							vertex.c9b1d0dbe283462b532b8dfa340a18e2f(true);
							return true;
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
