using A;
using UnityEngine;

public class DynamicSkinCollider : MonoBehaviour
{
	public MeshCollider m_collider;

	public SkinnedMeshRenderer m_renderer;

	private Mesh[] m_mesh = ca6a8ca843a4497dfa8dad06768105ff8.c0a0cdf4a196914163f7334d9b0781a04(2);

	private int m_meshIndex;

	private float m_time;

	private float m_interval = 0.25f;

	private bool m_enabled = true;

	private Mesh c6252bb552067c83d6487df9ea2e453a2()
	{
		m_meshIndex = (m_meshIndex + 1) % m_mesh.Length;
		if (m_mesh[m_meshIndex] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_mesh[m_meshIndex] = new Mesh();
		}
		return m_mesh[m_meshIndex];
	}

	private Mesh c926dcbbbcdd1276a720e5d4d05cd63f0()
	{
		return m_mesh[m_meshIndex];
	}

	public MeshCollider c56e531df0f0f544b68332074d3a9ba47()
	{
		MeshCollider c7088de59e49f7108f520cf7e0bae167e = ce00b6fa562b1e14f8b65fbf361e05458.c7088de59e49f7108f520cf7e0bae167e;
		if (m_enabled)
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
			if ((bool)m_renderer)
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
				if (Time.time - m_time > m_interval)
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
					CPUSkinning.c2ec7b02fdcee1e679e8188ed9a48329b(m_renderer, c6252bb552067c83d6487df9ea2e453a2());
					m_time = Time.time;
				}
				m_collider.sharedMesh = c926dcbbbcdd1276a720e5d4d05cd63f0();
				c7088de59e49f7108f520cf7e0bae167e = m_collider;
			}
		}
		return c7088de59e49f7108f520cf7e0bae167e;
	}

	private void OnSpawnCompleted()
	{
		m_collider = base.gameObject.GetComponentInChildren<MeshCollider>();
		m_renderer = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
	}
}
