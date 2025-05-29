using System.Collections.Generic;
using A;
using UnityEngine;

public class SpiderantWebTrap : MonoBehaviour
{
	public float m_lifeTime = 10f;

	public float m_speedSlowRatio = 0.5f;

	public float m_flyingSpeed = 20f;

	public float m_scaleRatio = 5f;

	[HideInInspector]
	public InteractiveCloth m_webCloth;

	[HideInInspector]
	public Vector3 m_vLandPos;

	private bool m_bLanded;

	private bool m_bExpanded;

	private AIServiceCurve.Curve m_curve;

	protected List<EntityPlayer> m_entityList = new List<EntityPlayer>();

	private Vector3 m_vForce;

	private float m_expandTimer;

	private void Start()
	{
		m_bExpanded = false;
		m_webCloth = GetComponent<InteractiveCloth>();
	}

	private void Update()
	{
		m_lifeTime -= Time.deltaTime;
		if (m_lifeTime < 0f)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int count = m_entityList.Count;
					for (int i = 0; i < count; i++)
					{
						if (m_entityList[i] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							PlayerController component = m_entityList[i].GetComponent<PlayerController>();
							if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							}
							else
							{
								m_entityList[i].GetComponent<PlayerController>().c63ee313b87b770d38877f71939e90417(1f / m_speedSlowRatio);
							}
						}
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_entityList.Clear();
							Object.Destroy(base.gameObject);
							return;
						}
					}
				}
				}
			}
		}
		int num = m_webCloth.vertices.Length / 2;
		Vector3 vector = m_webCloth.vertices[num];
		if (!m_bExpanded)
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
			if (m_bLanded)
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
				m_expandTimer += Time.deltaTime;
				if (m_expandTimer > 2f)
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
					m_bExpanded = true;
					m_webCloth.useGravity = false;
					m_webCloth.enabled = false;
				}
			}
		}
		if (!m_bLanded)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					Vector3 vector2 = vector - m_vLandPos;
					vector2.y = 0f;
					if (vector2.sqrMagnitude < 25f)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								m_vForce.x = 0f;
								m_vForce.y = -20f;
								m_vForce.z = 0f;
								m_webCloth.externalAcceleration = m_vForce;
								m_bLanded = true;
								m_expandTimer = 0f;
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		int count2 = c9c8de68aa0982db2bbd496692c37e.Count;
		for (int j = 0; j < count2; j++)
		{
			EntityPlayer entityPlayer = c9c8de68aa0982db2bbd496692c37e[j].c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 vector3 = entityPlayer.transform.position - vector;
			vector3.y = 0f;
			int num2;
			if (vector3.sqrMagnitude < 25f)
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
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			bool flag = (byte)num2 != 0;
			bool flag2 = m_entityList.Contains(entityPlayer);
			PlayerController component2 = entityPlayer.GetComponent<PlayerController>();
			if (component2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				continue;
			}
			float num3 = component2.cde3473b2f8e41fee852784334ce69c8d();
			if (flag)
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
				if (flag2)
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
					if (!(num3 > 0.9f))
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
				}
				component2.c63ee313b87b770d38877f71939e90417(m_speedSlowRatio);
				m_entityList.Add(entityPlayer);
			}
			else
			{
				if (!flag2)
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
				component2.c63ee313b87b770d38877f71939e90417(1f / m_speedSlowRatio);
				m_entityList.Remove(entityPlayer);
			}
		}
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

	public void cb50b0b6514bc0563cb63a6886d320d2e(Vector3 cc031f65fbdd5bc6829990bc870497769)
	{
		m_vLandPos = cc031f65fbdd5bc6829990bc870497769;
		m_vForce = cc031f65fbdd5bc6829990bc870497769 - base.transform.position;
		m_vForce *= 2.5f;
		m_vForce.y = -10f;
		m_webCloth = GetComponent<InteractiveCloth>();
		m_webCloth.externalAcceleration = m_vForce;
	}
}
