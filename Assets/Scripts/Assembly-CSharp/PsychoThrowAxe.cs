using A;
using UnityEngine;

public class PsychoThrowAxe : MonoBehaviour
{
	[HideInInspector]
	public Vector3 m_vEndPos;

	[HideInInspector]
	public AIServiceCurve.Curve m_flyingCurve;

	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	[HideInInspector]
	public GameObject m_attackObject;

	[HideInInspector]
	public bool m_bFlying;

	public float m_fSpeed = 25f;

	public int m_damage = 30;

	private bool m_bFlyingEnd;

	private bool m_bHitted;

	private float m_lifeTime = 10f;

	private float m_flyingSoundTimer;

	private Vector3 m_vOffsetToTarget;

	public BaseEventTriggerCtl m_AudioCtl;

	private void Start()
	{
		m_AudioCtl = GetComponentInChildren<BaseEventTriggerCtl>();
		m_bFlyingEnd = false;
		m_bFlying = false;
		m_bHitted = false;
		m_lifeTime = 10f;
		m_flyingSoundTimer = 0f;
	}

	private void Update()
	{
		m_lifeTime -= Time.deltaTime;
		if (m_lifeTime < float.Epsilon)
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
			if (m_bFlying)
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
				Object.Destroy(base.gameObject);
			}
		}
		if (m_bHitted)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					base.transform.position = m_attackObject.transform.position + m_vOffsetToTarget;
					return;
				}
			}
		}
		if (m_flyingCurve == null)
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
			if (m_BHVTaskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_bFlyingEnd)
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
					if (m_attackObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					Vector3 newPosition;
					m_bFlyingEnd = m_flyingCurve.Update(Time.deltaTime, m_fSpeed, out newPosition);
					Vector3 position = base.transform.position;
					base.transform.position = newPosition;
					base.transform.RotateAround(base.transform.position, base.transform.right, 1080f * Time.deltaTime);
					if (m_AudioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_flyingSoundTimer += Time.deltaTime;
						if (m_flyingSoundTimer > 0.33f)
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
							m_flyingSoundTimer -= 0.33f;
							m_AudioCtl.TriggerEventByName("Psycho_Axe_Wsh_Rnd");
						}
					}
					if (!m_bHitted)
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
						Vector3 vector = m_attackObject.transform.position + Vector3.up * 1.4f;
						float sqrMagnitude = (base.transform.position - vector).sqrMagnitude;
						if (!(sqrMagnitude < m_fSpeed * m_fSpeed * Time.deltaTime * Time.deltaTime))
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
							if (!(sqrMagnitude < 0.64f))
							{
								goto IL_0315;
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
						m_bHitted = true;
						Vector3 normalized = (base.transform.position - position).normalized;
						float num = (vector - position).magnitude - 0.2f;
						base.transform.position = position + normalized * num;
						m_vOffsetToTarget = base.transform.position - m_attackObject.transform.position;
					}
					goto IL_0315;
					IL_0315:
					if (!m_bHitted)
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
						if (!m_bFlyingEnd)
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
							break;
						}
					}
					Object.Destroy(base.gameObject, 0.5f);
					return;
				}
			}
		}
	}
}
