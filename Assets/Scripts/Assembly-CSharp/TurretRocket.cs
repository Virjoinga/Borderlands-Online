using A;
using UnityEngine;

public class TurretRocket : MonoBehaviour
{
	[HideInInspector]
	public float m_fSpeed = 15f;

	[HideInInspector]
	public float m_fLifeTime = 5f;

	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	[HideInInspector]
	public Entity m_targetEntity;

	private float m_hightOffest = 1f;

	private bool m_bDestoryed;

	private void Start()
	{
		m_bDestoryed = false;
		if (m_targetEntity as EntityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_hightOffest = (m_targetEntity as EntityNpc).m_entityHeight * 0.7f;
					return;
				}
			}
		}
		if (!(m_targetEntity as EntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_hightOffest = 1.5f;
			return;
		}
	}

	private void Update()
	{
		if (m_bDestoryed)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		m_fLifeTime -= Time.deltaTime;
		bool flag = false;
		if (m_targetEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 vector = m_targetEntity.c4cf00ced2bc60ae908904eb73692869f();
			vector.y += m_hightOffest;
			Vector3 normalized = (vector - base.transform.position).normalized;
			base.transform.forward = Vector3.Lerp(base.transform.forward, normalized, 0.2f);
			base.transform.position += base.transform.forward * m_fSpeed * Time.deltaTime;
			flag = (base.transform.position - vector).sqrMagnitude <= m_fSpeed * Time.deltaTime * m_fSpeed * Time.deltaTime;
		}
		else
		{
			base.transform.position += base.transform.forward * m_fSpeed * Time.deltaTime;
		}
		if (!c80f1d4cab6a920a50bea1fd3354cca21())
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
			if (!flag)
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
				break;
			}
		}
		GetComponent<VFXManager>().c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_TurretRocket);
		GetComponent<VFXManager>().cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_KnoxxMissileBurst, 1f);
		m_bDestoryed = true;
		Object.Destroy(base.gameObject, 1f);
		Renderer componentInChildren = base.gameObject.GetComponentInChildren<Renderer>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			componentInChildren.enabled = false;
			return;
		}
	}

	private bool c80f1d4cab6a920a50bea1fd3354cca21()
	{
		if (!(m_fLifeTime < 0f))
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
			if (!(m_BHVTaskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_BHVTaskManager.m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					return false;
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
		}
		return true;
	}
}
