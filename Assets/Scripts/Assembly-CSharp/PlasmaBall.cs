using A;
using UnityEngine;

public class PlasmaBall : MonoBehaviour
{
	private enum EStateOfPlasmaBall
	{
		ECharge = 0,
		EFlying = 1,
		EBurst = 2
	}

	[HideInInspector]
	public bool m_bStartFlying;

	[HideInInspector]
	public Vector3 m_vFlyingDir;

	[HideInInspector]
	public Vector3 m_vTargetPos;

	[HideInInspector]
	public float m_flyingSpeed;

	[HideInInspector]
	public float m_damageDuration = 2f;

	[HideInInspector]
	public float m_damage = 10f;

	[HideInInspector]
	public float m_chargeTime = 1f;

	[HideInInspector]
	public float m_damageRadius = 2f;

	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	[HideInInspector]
	public GameObject m_attackObject;

	private SphereCollider m_collider;

	private PlasmaHurtZone m_hurtZone;

	private float m_chargeTimer;

	private float m_flyingTime = 10f;

	private EStateOfPlasmaBall m_state;

	private void Start()
	{
		m_state = EStateOfPlasmaBall.ECharge;
		GetComponent<VFXManager>().cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_PlasmaBallCharge, 1f);
		m_collider = GetComponent<SphereCollider>();
		m_collider.enabled = false;
		m_collider.radius = 0.001f;
		m_hurtZone = GetComponent<PlasmaHurtZone>();
		m_hurtZone.enabled = false;
		m_bStartFlying = false;
		m_chargeTimer = 0f;
	}

	private void Update()
	{
		if (base.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_BHVTaskManager.m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		VFXManager component = GetComponent<VFXManager>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		if (m_state == EStateOfPlasmaBall.ECharge)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					m_chargeTimer += Time.deltaTime;
					if (m_chargeTimer < m_chargeTime)
					{
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
					base.transform.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
					if (m_attackObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_vTargetPos = m_attackObject.transform.position + Vector3.up * 1.4f;
					}
					m_vFlyingDir = m_BHVTaskManager.m_entity.transform.forward;
					Vector3 normalized = (m_vTargetPos - base.transform.position).normalized;
					m_vFlyingDir.y = normalized.y;
					m_flyingTime = (base.transform.position - m_vTargetPos).magnitude / m_flyingSpeed;
					component.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_PlasmaBallFly, m_flyingTime);
					m_state = EStateOfPlasmaBall.EFlying;
					return;
				}
				}
			}
		}
		if (m_state == EStateOfPlasmaBall.EFlying)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					m_flyingTime -= Time.deltaTime;
					if (m_flyingTime > 0f)
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
						if (!c1a9000273965ab9fb7e03d24cf53856d())
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									base.transform.position += m_vFlyingDir * m_flyingSpeed * Time.deltaTime;
									return;
								}
							}
						}
					}
					component.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_PlasmaBallBurst, m_damageDuration);
					m_state = EStateOfPlasmaBall.EBurst;
					return;
				}
			}
		}
		m_damageDuration -= Time.deltaTime;
		if (!(m_damageDuration < 0f))
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
			Object.Destroy(base.gameObject);
			return;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
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
		if (m_state != EStateOfPlasmaBall.EFlying)
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
			m_flyingTime = 0f;
			return;
		}
	}

	private bool c1a9000273965ab9fb7e03d24cf53856d()
	{
		if (base.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
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
				switch (4)
				{
				case 0:
					break;
				default:
				{
					int result;
					if (hitInfo.transform.parent == m_BHVTaskManager.transform)
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
						result = 0;
					}
					else
					{
						result = 1;
					}
					return (byte)result != 0;
				}
				}
			}
		}
		return false;
	}
}
