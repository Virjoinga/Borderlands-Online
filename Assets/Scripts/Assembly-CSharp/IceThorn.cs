using A;
using UnityEngine;

public class IceThorn : EntityProjectile, IDestructibleObj
{
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	[HideInInspector]
	public float m_damageRadius;

	[HideInInspector]
	public int m_damage;

	[HideInInspector]
	public int m_index;

	public int m_HP = 10;

	public float m_fRaiseSpeed = 1.5f;

	public float m_warningTime = 1f;

	public float m_raiseHeight = 3f;

	public float m_lifeTime = 10f;

	[HideInInspector]
	public int m_maxHP;

	private float m_curTime;

	private float m_blockTime;

	private float m_totalRaiseHeight;

	private Vector3 m_vDeltaRaise;

	private bool m_bDestoryed;

	private bool m_bDestoryedByPlayer;

	protected override void Awake()
	{
		GetComponent<BadAssNetworkView>().photonView.ce57f12a4f7e693a5fe0c4049dc56fa7c = 0;
	}

	public override void Start()
	{
		base.Start();
		m_curTime = 0f;
		m_totalRaiseHeight = 0f;
		m_bDestoryed = false;
		m_bDestoryedByPlayer = false;
		m_blockTime = 0f;
		GetComponent<VFXManager>().c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_IceThorn, base.transform.position + Vector3.up * 4.5f, base.transform.rotation, true);
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_bDestoryed)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (m_BHVTaskManager.m_entity.ca2ff7a501878363cb1d5f0472e306620() <= 0)
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
			m_curTime += Time.deltaTime;
			if (m_curTime < m_warningTime)
			{
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
			if (m_totalRaiseHeight >= m_raiseHeight)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_blockTime += Time.deltaTime;
						if (m_blockTime < m_lifeTime)
						{
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
						c918693d78025ee181080696108945498();
						return;
					}
				}
			}
			float num = Time.deltaTime * m_fRaiseSpeed;
			if (num + m_totalRaiseHeight > m_raiseHeight)
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
				num = m_raiseHeight - m_totalRaiseHeight;
			}
			m_vDeltaRaise = base.transform.position;
			m_vDeltaRaise.y += num;
			base.transform.position = m_vDeltaRaise;
			m_totalRaiseHeight += num;
			return;
		}
	}

	public override void c918693d78025ee181080696108945498()
	{
		m_bDestoryed = true;
		GetComponent<VFXManager>().c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_IceBroken, base.transform.position + Vector3.up * 2f, base.transform.rotation, true);
		GetComponent<MeshRenderer>().enabled = false;
		if (!m_bDestoryedByPlayer)
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
		}
		AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.c9fed2b73e654eeb03ea3ad8521c9ae89(m_index);
		Object.Destroy(base.gameObject, 0.5f);
		base.c918693d78025ee181080696108945498();
	}

	private void cfdec4f00d647020f25b997166aa68a5d()
	{
	}

	public override bool c7617b17bcc7d64fcc6e7da325dfd8a2f(AttackInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		return false;
	}

	public override void c24573231c964a8e1b6c359bcdc11ac2e(int c0e0b6548ee9ac8354c15e369d7f01c5f)
	{
		int num = m_HP - c0e0b6548ee9ac8354c15e369d7f01c5f;
		if (num > 0)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWorldTipsView>().c84366760d1fa67e4323e190564d3e406(num, WeakPoint.StrengthType.Normal, base.gameObject.transform.position + Vector3.up * 2.5f, AttackInfo.ElementalType.None, false);
		}
		m_HP = c0e0b6548ee9ac8354c15e369d7f01c5f;
	}
}
