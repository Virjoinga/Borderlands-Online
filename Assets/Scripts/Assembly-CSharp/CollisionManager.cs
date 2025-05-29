using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
	private List<Collider> m_colliders = new List<Collider>();

	private WeakPoint[] m_weakPoints = ce458fa0852a920e6e66d10e2d915a248.c0a0cdf4a196914163f7334d9b0781a04(0);

	private Collider m_boundingBox;

	private BoxCollider m_movementBounding;

	private Bounds m_movementBounds;

	private bool m_inited;

	public void cd93285db16841148ed53a5bbeb35cf20(bool c947d4451a0d20360a3a0783ce65d26df)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			c90035e0f9a6f497713223da7479f40d8();
		}
		m_weakPoints = base.gameObject.GetComponentsInChildren<WeakPoint>();
		Transform transform = base.gameObject.transform.Find("BoundingBox");
		if ((bool)transform)
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
			m_boundingBox = (Collider)transform.GetComponent(Type.GetTypeFromHandle(c7f442acc61520b26a4125cf79ddeaf1d.cc1720d05c75832f704b87474932341c3()));
		}
		c2fd255ea5510abf5ead6b84fa91ea6d5(false);
		if (c947d4451a0d20360a3a0783ce65d26df)
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
			if (m_boundingBox != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_movementBounding == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_movementBounding = base.gameObject.AddComponent<BoxCollider>();
					if (m_movementBounding != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_movementBounding.isTrigger = base.enabled;
						m_movementBounding.size = m_boundingBox.bounds.size + new Vector3(2f, 0.5f, 2f);
						m_movementBounding.center = m_boundingBox.bounds.center - m_boundingBox.transform.position;
						m_movementBounds.center = m_movementBounding.center;
						m_movementBounds.size = m_movementBounding.size;
					}
				}
			}
		}
		Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			m_colliders.Add(componentsInChildren[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			m_inited = true;
			return;
		}
	}

	public bool c24ccda861b979b836eef59fa18fc8d8e()
	{
		return m_inited;
	}

	public bool cd7c958f1e0eea8f346b44512bf8f1ea4(Ray cdb5cb253ef1339831696a37475f7233f, out RaycastHit c3ced719b4780c1919017d69e82521ab3, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		bool result = false;
		RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
		cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c3ced719b4780c1919017d69e82521ab3 = c36964cf41281414170f34ee68bef6c;
		if (cdb5cb253ef1339831696a37475f7233f.direction != Vector3.zero)
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
			for (int i = 0; i < m_colliders.Count; i++)
			{
				cdb5cb253ef1339831696a37475f7233f.direction = cdb5cb253ef1339831696a37475f7233f.direction.normalized;
				Collider collider = m_colliders[i];
				if (collider == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				}
				else if (collider.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				}
				else
				{
					if (!collider.Raycast(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab3, c85645ac328a4c6e6c17d3da3be1e11f0))
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
					result = true;
					c85645ac328a4c6e6c17d3da3be1e11f0 = c3ced719b4780c1919017d69e82521ab3.distance;
				}
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
		return result;
	}

	public bool ce3a634dd33744eb63234d14e7a1e099f(Ray cdb5cb253ef1339831696a37475f7233f, out RaycastHit c3ced719b4780c1919017d69e82521ab3, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		bool result = false;
		RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
		cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c3ced719b4780c1919017d69e82521ab3 = c36964cf41281414170f34ee68bef6c;
		if (cdb5cb253ef1339831696a37475f7233f.direction != Vector3.zero)
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
			c2fd255ea5510abf5ead6b84fa91ea6d5(true);
			for (int i = 0; i < m_weakPoints.Length; i++)
			{
				WeakPoint weakPoint = m_weakPoints[i];
				if (weakPoint == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				if (weakPoint.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				Collider collider = weakPoint.cac6286fb02aed4914febe35bdf6b9e2e();
				if (collider == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				if (collider.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				cdb5cb253ef1339831696a37475f7233f.direction = cdb5cb253ef1339831696a37475f7233f.direction.normalized;
				RaycastHit hitInfo;
				if (!collider.Raycast(cdb5cb253ef1339831696a37475f7233f, out hitInfo, c85645ac328a4c6e6c17d3da3be1e11f0))
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
				c3ced719b4780c1919017d69e82521ab3 = hitInfo;
				result = true;
				c85645ac328a4c6e6c17d3da3be1e11f0 = c3ced719b4780c1919017d69e82521ab3.distance;
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
			c2fd255ea5510abf5ead6b84fa91ea6d5(false);
		}
		return result;
	}

	public bool c3b718f1007bb58e0bf2ca151b7d08786(Ray cdb5cb253ef1339831696a37475f7233f, out RaycastHit c3ced719b4780c1919017d69e82521ab3, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		bool result = false;
		RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
		cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c3ced719b4780c1919017d69e82521ab3 = c36964cf41281414170f34ee68bef6c;
		if (cdb5cb253ef1339831696a37475f7233f.direction != Vector3.zero)
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
			if (m_boundingBox != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				cdb5cb253ef1339831696a37475f7233f.direction = cdb5cb253ef1339831696a37475f7233f.direction.normalized;
				if (m_boundingBox.Raycast(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab3, c85645ac328a4c6e6c17d3da3be1e11f0))
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
					result = true;
					c85645ac328a4c6e6c17d3da3be1e11f0 = c3ced719b4780c1919017d69e82521ab3.distance;
				}
			}
		}
		return result;
	}

	public bool c9e8c231a5bbbe15568687fd781ca9b0f(Ray cdb5cb253ef1339831696a37475f7233f, out RaycastHit c3ced719b4780c1919017d69e82521ab3, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		bool result = false;
		RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
		cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c3ced719b4780c1919017d69e82521ab3 = c36964cf41281414170f34ee68bef6c;
		if (cdb5cb253ef1339831696a37475f7233f.direction != Vector3.zero)
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
			if (m_movementBounding != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				cdb5cb253ef1339831696a37475f7233f.direction = cdb5cb253ef1339831696a37475f7233f.direction.normalized;
				if (m_movementBounding.Raycast(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab3, c85645ac328a4c6e6c17d3da3be1e11f0))
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
					result = true;
					c85645ac328a4c6e6c17d3da3be1e11f0 = c3ced719b4780c1919017d69e82521ab3.distance;
				}
			}
		}
		return result;
	}

	public bool c5eaa1d6ded3939c278019b4ed3305826()
	{
		return m_colliders.Count > 0;
	}

	public void cf19d18e7c73d5aff0a6786700d4e529d(Collider ca0f58c983a310bcc674ccfdd77a6850c)
	{
		if (m_colliders.Exists((Collider c5abff3ecb5288a2407a0cf0d2083cc70) => c5abff3ecb5288a2407a0cf0d2083cc70 == ca0f58c983a310bcc674ccfdd77a6850c))
		{
			return;
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
			m_colliders.Add(ca0f58c983a310bcc674ccfdd77a6850c);
			return;
		}
	}

	public void c30658ab50c1dcbe63044c9cd8fe8cb2b(Collider ca0f58c983a310bcc674ccfdd77a6850c)
	{
		m_colliders.RemoveAll((Collider c5abff3ecb5288a2407a0cf0d2083cc70) => c5abff3ecb5288a2407a0cf0d2083cc70 == ca0f58c983a310bcc674ccfdd77a6850c);
	}

	public void c7625f669cf7d310f5ae9a4aa2646e757(bool cbf402c82d0fffee7c8f37c98e456b8f8)
	{
		for (int i = 0; i < m_colliders.Count; i++)
		{
			if (!(m_colliders[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_colliders[i].enabled = cbf402c82d0fffee7c8f37c98e456b8f8;
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

	public WeakPoint[] cf0d37a28cb0655ede4d95f3b263f7558()
	{
		return m_weakPoints;
	}

	public sbyte cb74e05c70b659a8c77daaa12fcbf3a74(WeakPoint c21dfbdbfc865e775d0fd21534f7fb298)
	{
		for (sbyte b = 0; b < m_weakPoints.Length; b++)
		{
			if (m_weakPoints[b] == c21dfbdbfc865e775d0fd21534f7fb298)
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
						return b;
					}
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
			return -1;
		}
	}

	public WeakPoint c92b2d96b80fc4e8dc19a3368e56dbacb(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (-1 < c5612a459a84ffdb41c885401433cd62d)
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
			if (c5612a459a84ffdb41c885401433cd62d < m_weakPoints.Length)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_weakPoints[c5612a459a84ffdb41c885401433cd62d];
					}
				}
			}
		}
		return null;
	}

	public Collider c1ce44495f53aa451cfab609bd34340d2()
	{
		if (m_boundingBox == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, base.gameObject.name + " dont have bounding box but access it");
		}
		return m_boundingBox;
	}

	public BoxCollider cad83439a05db8f3be64081b2969f28c8()
	{
		return m_movementBounding;
	}

	public Bounds c1d6860eee695e1e68dc547c4685b588e()
	{
		return m_movementBounds;
	}

	private void OnDrawGizmos()
	{
		WeakPoint[] weakPoints = m_weakPoints;
		foreach (WeakPoint weakPoint in weakPoints)
		{
			Gizmos.DrawSphere(weakPoint.transform.position, 0.05f);
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
			if (!m_boundingBox)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				Gizmos.color = Color.magenta;
				Gizmos.DrawWireCube(m_boundingBox.bounds.center, m_boundingBox.bounds.size);
				return;
			}
		}
	}

	public void c0921477f0f5481900f5ba2cf3bf4c322()
	{
		for (int i = 0; i < m_weakPoints.Length; i++)
		{
			m_weakPoints[i].gameObject.layer = LayerMask.NameToLayer("WeakPoint");
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

	public void c2fd255ea5510abf5ead6b84fa91ea6d5(bool c232363d391ddf136de98040c51b456ba)
	{
		for (int i = 0; i < m_weakPoints.Length; i++)
		{
			if (!(m_weakPoints[i].cac6286fb02aed4914febe35bdf6b9e2e() != m_boundingBox))
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
			m_weakPoints[i].cac6286fb02aed4914febe35bdf6b9e2e().enabled = c232363d391ddf136de98040c51b456ba;
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

	public void cd632e5715ef3decbdd36429dcbc891cf()
	{
		m_boundingBox.transform.localPosition = Vector3.zero;
		for (int i = 0; i < m_weakPoints.Length; i++)
		{
			if (!(m_weakPoints[i].cac6286fb02aed4914febe35bdf6b9e2e() != m_boundingBox))
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
			m_weakPoints[i].c23487ba5bae52418f400eca74da63212();
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

	private void c90035e0f9a6f497713223da7479f40d8()
	{
		CharacterJoint[] componentsInChildren = GetComponentsInChildren<CharacterJoint>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.DestroyImmediate(componentsInChildren[i]);
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
			Rigidbody[] componentsInChildren2 = GetComponentsInChildren<Rigidbody>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				if (componentsInChildren2[j].transform == base.transform)
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
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren2[j]);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				Collider[] componentsInChildren3 = GetComponentsInChildren<Collider>();
				for (int k = 0; k < componentsInChildren3.Length; k++)
				{
					if (componentsInChildren3[k].transform == base.transform)
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
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(componentsInChildren3[k]);
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					WeakPoint[] componentsInChildren4 = GetComponentsInChildren<WeakPoint>();
					for (int l = 0; l < componentsInChildren4.Length; l++)
					{
						if (componentsInChildren4[l].transform == base.transform)
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
						}
						else
						{
							UnityEngine.Object.DestroyImmediate(componentsInChildren4[l]);
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

	public void c240cef3c15ad5ab6ce89665d079c3bc2()
	{
		if (!(GetComponent<Rigidbody>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
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
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			return;
		}
	}
}
