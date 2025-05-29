using System;
using System.Collections.Generic;
using A;
using UnityEngine;

public class EntityManager : c06ca0e618478c23eba3419653a19760f<EntityManager>
{
	private List<IEntityManagerListener> m_listerner = new List<IEntityManagerListener>();

	public GameObject m_entityDirectory;

	private List<Entity>[] m_entitiesPerType;

	public void c28e7fb4a7d03eef0acca90b1bd76a2c9(IEntityManagerListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void c704834a4a19f1f8555b44d9c021845ab(IEntityManagerListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_listerner.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	protected override void Awake()
	{
		base.Awake();
		m_entitiesPerType = c6d8d398c41aebc35f1a465ea24d5c819.c0a0cdf4a196914163f7334d9b0781a04(Enum.GetNames(typeof(Entity.EntityType)).Length);
		for (int i = 0; i < m_entitiesPerType.Length; i++)
		{
			m_entitiesPerType[i] = new List<Entity>();
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_entityDirectory = new GameObject("Entities");
			m_entityDirectory.transform.parent = base.transform;
			return;
		}
	}

	public void c986e2c92f577697169e986d88211a625(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (!(c5d720f6d007abb0c4a21d6a654e405bb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(c5d720f6d007abb0c4a21d6a654e405bb.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				UnityEngine.Object.Destroy(c5d720f6d007abb0c4a21d6a654e405bb.gameObject);
				return;
			}
		}
	}

	private void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		for (int i = 0; i < m_entitiesPerType[0].Count; i++)
		{
			c986e2c92f577697169e986d88211a625(m_entitiesPerType[0][i]);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int j = 0; j < m_entitiesPerType.Length; j++)
			{
				m_entitiesPerType[j].Clear();
			}
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
	}

	public void c57e4d4cd41f3be21d7e24a71aa08c6ba(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		m_entitiesPerType[0].Add(c5d720f6d007abb0c4a21d6a654e405bb);
		m_entitiesPerType[(int)c5d720f6d007abb0c4a21d6a654e405bb.c6420f67f9249b1d533531d9f351a36e0()].Add(c5d720f6d007abb0c4a21d6a654e405bb);
		for (int i = 0; i < m_listerner.Count; i++)
		{
			m_listerner[i].OnEntitySpawn(c5d720f6d007abb0c4a21d6a654e405bb);
		}
		while (true)
		{
			switch (3)
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

	public void cf5212e6903ec0c0b27816142c32a2d13(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		m_entitiesPerType[0].Remove(c5d720f6d007abb0c4a21d6a654e405bb);
		m_entitiesPerType[(int)c5d720f6d007abb0c4a21d6a654e405bb.c6420f67f9249b1d533531d9f351a36e0()].Remove(c5d720f6d007abb0c4a21d6a654e405bb);
	}

	public void c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType c2b4f43f34e21572af6ab4414f04cee36, out List<Entity> c0c2a548e7e20a141e7763c365a4d6642)
	{
		c0c2a548e7e20a141e7763c365a4d6642 = m_entitiesPerType[(int)c2b4f43f34e21572af6ab4414f04cee36];
	}

	public void c87ecafd3dda798dbf216aaf5316d45f6(out List<Entity> c0c2a548e7e20a141e7763c365a4d6642)
	{
		c0c2a548e7e20a141e7763c365a4d6642 = m_entitiesPerType[0];
	}

	public void c16724d551ad0986ab23e0697bcedb358(Entity.EntityType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (c2b4f43f34e21572af6ab4414f04cee36 == Entity.EntityType.None)
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
					cb6ddb86ff592b855d40e4b6baac609bf();
					return;
				}
			}
		}
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < m_entitiesPerType[(int)c2b4f43f34e21572af6ab4414f04cee36].Count; i++)
		{
			if (c2b4f43f34e21572af6ab4414f04cee36 == Entity.EntityType.Object)
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
				EntityObject entityObject = (EntityObject)m_entitiesPerType[(int)c2b4f43f34e21572af6ab4414f04cee36][i];
				if (entityObject.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (entityObject.m_owner.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Player)
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
						continue;
					}
				}
			}
			list.Add(m_entitiesPerType[(int)c2b4f43f34e21572af6ab4414f04cee36][i]);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < list.Count; j++)
			{
				c986e2c92f577697169e986d88211a625(list[j]);
				cf5212e6903ec0c0b27816142c32a2d13(list[j]);
			}
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
	}

	public int c6d037f57d903e6bcdcc24348eeefb88c(Entity.EntityType c2b4f43f34e21572af6ab4414f04cee36 = Entity.EntityType.None)
	{
		return m_entitiesPerType[(int)c2b4f43f34e21572af6ab4414f04cee36].Count;
	}

	public int[] c1866b244449989bc7ddc2674dfdef3ab()
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(m_entitiesPerType.Length);
		for (int i = 0; i < m_entitiesPerType.Length; i++)
		{
			array[i] = m_entitiesPerType[i].Count;
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
			return array;
		}
	}
}
