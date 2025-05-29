using A;
using UnityEngine;

public class EnergyMissile : MonoBehaviour
{
	private BHVTaskManager m_taskManager;

	private float m_speed = 10f;

	private Vector3 m_vTargetPos;

	private Vector3 m_vFlyDir;

	private bool m_bFlyFinished;

	private float m_timer = 3f;

	private float m_destroydelay = 3f;

	private Entity m_targetEntity;

	private bool m_bVfxReady;

	private void Start()
	{
		m_bVfxReady = false;
	}

	private void Update()
	{
		if (m_taskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
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
		if (AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.m_bPlayCutScene)
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
			m_destroydelay = 0.01f;
			c918693d78025ee181080696108945498();
		}
		if (!m_bVfxReady)
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
			m_bVfxReady = GetComponent<VFXManager>().c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_archangelEnergyMissile, null, base.transform, Vector3.zero, Quaternion.identity);
		}
		if (m_timer > 0f)
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
			m_timer -= Time.deltaTime;
			if (m_timer > 0f)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						c320738a8fe680a474e1d80c4a8f4d795();
						return;
					}
				}
			}
		}
		if (m_bFlyFinished)
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
			float sqrMagnitude = (m_vTargetPos - base.transform.position).sqrMagnitude;
			if (sqrMagnitude < Time.deltaTime * m_speed * Time.deltaTime * m_speed)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						base.transform.position = m_vTargetPos;
						c918693d78025ee181080696108945498();
						return;
					}
				}
			}
			if (c1a9000273965ab9fb7e03d24cf53856d())
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						c918693d78025ee181080696108945498();
						return;
					}
				}
			}
			base.transform.position += m_vFlyDir * Time.deltaTime * m_speed;
			return;
		}
	}

	public void cd232ee5f717924fbbb159f559bf8ed59(BHVTaskManager c9f936100770508e8acd275ff7c1d6641, Entity c37d495435d366367865fe524ce762c0c, float c5ceff30f6d428c3c4ce2e9c8e691e31a)
	{
		m_speed = c5ceff30f6d428c3c4ce2e9c8e691e31a;
		m_targetEntity = c37d495435d366367865fe524ce762c0c;
		m_taskManager = c9f936100770508e8acd275ff7c1d6641;
		m_timer = 3f;
	}

	private void c320738a8fe680a474e1d80c4a8f4d795()
	{
		Vector3 vector = Random.insideUnitSphere * 1.5f;
		vector.y = 0f;
		if (m_targetEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_vTargetPos = m_targetEntity.c4cf00ced2bc60ae908904eb73692869f() + vector;
		}
		else
		{
			m_vTargetPos = base.transform.position + Vector3.down * 30f;
		}
		m_vFlyDir = (m_vTargetPos - base.transform.position).normalized;
	}

	private bool c1a9000273965ab9fb7e03d24cf53856d()
	{
		int layerMask = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
		float value = m_speed * Time.deltaTime;
		value = Mathf.Clamp(value, 0.3f, 1.5f);
		RaycastHit hitInfo;
		if (Physics.Raycast(base.transform.position, m_vFlyDir, out hitInfo, value, layerMask))
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
					return true;
				}
			}
		}
		return false;
	}

	private void c918693d78025ee181080696108945498()
	{
		m_bFlyFinished = true;
		VFXManager component = GetComponent<VFXManager>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_archangelEnergyMissile);
			component.c0c5ca8f54702477a0524e764704df02c(ENPCParticleType.E_ArchangelEnergyExplosive, null, base.transform.position, Quaternion.identity);
		}
		Object.Destroy(base.gameObject, m_destroydelay);
	}
}
