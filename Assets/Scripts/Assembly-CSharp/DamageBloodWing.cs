using System.Collections.Generic;
using A;
using BHV_Skill;
using UnityEngine;
using XsdSettings;

public class DamageBloodWing : MonoBehaviour
{
	private MoveBloodWing m_moveComp;

	private List<Entity> m_InRangeEnemyList = new List<Entity>();

	private BHVSkillSettingsFireBird m_settings;

	private EntityPlayer m_playerOwner;

	private bool m_bTouchedEnemy;

	private void Awake()
	{
		m_moveComp = GetComponent<MoveBloodWing>();
	}

	private void Update()
	{
		if (m_playerOwner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_playerOwner = m_moveComp.c44e36d96da2cfca88d9eef88ae429482();
			m_settings = m_playerOwner.ccaf53be8b86b7016efd6970ff8c92ad3.cd3d8b35d2647005675ba92178c253805<BHVSkillSettingsFireBird>();
		}
		if (m_playerOwner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_moveComp.cd183a5dbb084bdf2992464c044efe530() != 0)
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
			c8b052d7bc5ae4b3417e291a42c47e461();
			return;
		}
	}

	private void c8b052d7bc5ae4b3417e291a42c47e461()
	{
		if (m_bTouchedEnemy)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c0048a9dbe2a809ef8c02c22d26c568ef(c5540c5bbc6a5af01e6c038a9a1b820d7());
			if (m_InRangeEnemyList.Count <= 0)
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
				m_bTouchedEnemy = true;
				FirebirdManage.c3e45855b170d32c9cab624e8abd48e4f("[Touch Enemy]");
				Entity c640836cc925d59650a72d53cc3825d = m_InRangeEnemyList[0];
				m_moveComp.c116d84b25e343a44c548e2955559606a(c640836cc925d59650a72d53cc3825d);
				return;
			}
		}
	}

	public List<Entity> c0048a9dbe2a809ef8c02c22d26c568ef(float c4e056a08341b1f8b5cc7d8827a42b83a)
	{
		m_InRangeEnemyList.Clear();
		using (List<Entity>.Enumerator enumerator = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cb8a72c40c1b6db1b4a333f6af978a477().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Entity current = enumerator.Current;
				if (!c574429d11bce939e5a13413cb192e895(current, base.transform.position, c4e056a08341b1f8b5cc7d8827a42b83a))
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
				m_InRangeEnemyList.Add(current);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_0072;
				}
				continue;
				end_IL_0072:
				break;
			}
		}
		return m_InRangeEnemyList;
	}

	public bool c574429d11bce939e5a13413cb192e895(Entity cf90129559e8b043c8851fe07557ea812, Vector3 c4f1383b49aeaf204a4e2ef0b2495439b, float c4e056a08341b1f8b5cc7d8827a42b83a)
	{
		if (cf90129559e8b043c8851fe07557ea812 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		if (cf90129559e8b043c8851fe07557ea812.c5ca38fad98337fc5c7255384b2cd1a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (cf90129559e8b043c8851fe07557ea812.c5ca38fad98337fc5c7255384b2cd1a86().ca2ff7a501878363cb1d5f0472e306620() <= 0)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (c52b0e4c302961935453bec436d84dc68(cf90129559e8b043c8851fe07557ea812))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		float num = Vector3.Distance(c4f1383b49aeaf204a4e2ef0b2495439b, cf90129559e8b043c8851fe07557ea812.transform.position);
		if (num > c4e056a08341b1f8b5cc7d8827a42b83a)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}

	private bool c52b0e4c302961935453bec436d84dc68(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		if (!(m_playerOwner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_playerOwner == c6e853f452cc819532893b63942b8ed3d))
			{
				if (c6e853f452cc819532893b63942b8ed3d.ceb10167333758220ffb9bc66317ad763() == m_playerOwner.ceb10167333758220ffb9bc66317ad763())
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
					if (!m_playerOwner.cad418535912a1c3cb6ea0ce1e4cbd114())
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
				}
				return false;
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
		return true;
	}

	public float cff42711c7cc8149eb74d120d5818e6ac()
	{
		return m_settings.m_explosionRadius * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FirebirdExplosionDamage);
	}

	private int c65b4432bdd564c962c37009590429601()
	{
		float num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(m_playerOwner.c7513e66c4e0fc55e6fea9dd9cb8b9943());
		float num2 = m_settings.m_explosionDamage * num * m_playerOwner.ca61d6db905e9724fdacd777186a9df71();
		float num3 = num2 * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FirebirdExplosionDamage);
		return (int)num3;
	}

	public float c5540c5bbc6a5af01e6c038a9a1b820d7()
	{
		if (m_settings == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 0f;
				}
			}
		}
		float num = m_settings.m_fireRadius * m_playerOwner.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FirebirdRadius);
		return (int)num;
	}
}
