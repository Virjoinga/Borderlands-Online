using A;
using UnityEngine;

public class KnoxxMissile : EntityProjectile, IDestructibleObj
{
	public int m_HP = 10;

	public float m_lifeTime = 5f;

	public float m_flyingSpeed = 15f;

	public float m_traceTargetSpeed = 2f;

	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	[HideInInspector]
	public int m_index;

	private Entity m_targetEntity;

	private bool m_bDestory;

	private Vector3 m_vDirToTarget;

	private Vector3 m_initDir = Vector3.up;

	private float m_curTime;

	private int m_maxHP;

	protected override void Awake()
	{
		GetComponent<BadAssNetworkView>().photonView.ce57f12a4f7e693a5fe0c4049dc56fa7c = 0;
	}

	public void c7c5fd2bd1c5c6f266b23bc3369b810b5(Entity c82fcbab5e578dc3a31c1f662916bd87e)
	{
		m_targetEntity = c82fcbab5e578dc3a31c1f662916bd87e;
	}

	public override void Start()
	{
		base.Start();
		m_bDestory = false;
		m_curTime = 0f;
		m_maxHP = m_HP;
		m_index = AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.c963ef5d4b51a9309fa9483d743ab9b33(this);
		base.transform.forward = Quaternion.Euler(0f, 0f, (float)(m_index % 3) * 30f - 30f) * m_initDir;
	}

	public override int ca2ff7a501878363cb1d5f0472e306620()
	{
		return m_HP;
	}

	public override int ccfad1bf47b003333c5ddd084f14d33e7()
	{
		return m_maxHP;
	}

	public override void Update()
	{
		if (m_bDestory)
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
					return;
				}
			}
		}
		m_curTime += Time.deltaTime;
		if (m_curTime > m_lifeTime)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					c918693d78025ee181080696108945498();
					return;
				}
			}
		}
		if (c1a9000273965ab9fb7e03d24cf53856d())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c918693d78025ee181080696108945498();
					return;
				}
			}
		}
		if (m_curTime > 0.3f)
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
			if (m_targetEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_vDirToTarget = (m_targetEntity.c4cf00ced2bc60ae908904eb73692869f() + Vector3.up * 1.4f - base.transform.position).normalized;
				base.transform.forward = Vector3.Lerp(base.transform.forward, m_vDirToTarget, m_traceTargetSpeed * Time.deltaTime);
			}
		}
		base.transform.position += base.transform.forward * m_flyingSpeed * Time.deltaTime;
	}

	private bool c1a9000273965ab9fb7e03d24cf53856d()
	{
		if (base.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		int layerMask = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
		float value = m_flyingSpeed * Time.deltaTime;
		value = Mathf.Clamp(value, 0.3f, 1.5f);
		RaycastHit hitInfo;
		if (Physics.Raycast(base.transform.position, base.transform.forward, out hitInfo, value, layerMask))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return false;
	}

	private void cfdec4f00d647020f25b997166aa68a5d()
	{
	}

	public override void c918693d78025ee181080696108945498()
	{
		m_bDestory = true;
		if (base.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			VFXManager component = GetComponent<VFXManager>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_KnoxxMissileBurst, 1f);
			}
		}
		if (base.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				GetComponent<MeshRenderer>().enabled = false;
			}
		}
		AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.c9fed2b73e654eeb03ea3ad8521c9ae89(m_index);
		Object.Destroy(base.gameObject, 1f);
		base.c918693d78025ee181080696108945498();
	}

	public override bool c7617b17bcc7d64fcc6e7da325dfd8a2f(AttackInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		Vector3 normalized = (base.transform.position - c00bb86ffbeb6764fbe60d7b64859db7f.m_origin).normalized;
		if (Vector3.Dot(normalized, c00bb86ffbeb6764fbe60d7b64859db7f.m_direction) < 0.8f)
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
					return false;
				}
			}
		}
		RaycastHit hitInfo;
		if (Physics.Raycast(c00bb86ffbeb6764fbe60d7b64859db7f.m_origin, c00bb86ffbeb6764fbe60d7b64859db7f.m_direction, out hitInfo, 100f, 1 << LayerMask.NameToLayer("DestructibleObj")))
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
			if (hitInfo.collider.gameObject == base.gameObject)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_HP -= c00bb86ffbeb6764fbe60d7b64859db7f.m_damagePoint;
						if (m_HP < 0)
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
							cfdec4f00d647020f25b997166aa68a5d();
						}
						return true;
					}
				}
			}
		}
		return false;
	}
}
