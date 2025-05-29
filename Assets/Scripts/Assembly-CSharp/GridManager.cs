using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class GridManager : c06ca0e618478c23eba3419653a19760f<GridManager>
{
	public readonly List<Grid> m_grids = new List<Grid>();

	private Dictionary<byte, List<int>> m_AddingGrids = new Dictionary<byte, List<int>>();

	private Dictionary<byte, List<int>> m_RemovingGrids = new Dictionary<byte, List<int>>();

	public List<Entity> m_UnarrangedEntities = new List<Entity>();

	private bool m_isLevelReady;

	private byte m_gridIndex = 10;

	public SessionGrid m_sessionGrid { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		cf8a181520f1fe6f8d9ebe3906bd9d70e();
	}

	private void Start()
	{
	}

	private void cf8a181520f1fe6f8d9ebe3906bd9d70e()
	{
		m_sessionGrid = new SessionGrid(0);
		m_grids.Add(m_sessionGrid);
	}

	private void cd8db8ec39bb02dbc2e9e29ca7ad17317()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8762b0b9a035bab0b07fd588a158cd62().cdc780a4f7ed24542cc09a5fdd06846a6() is GameModeTown)
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
					return;
				}
			}
		}
		m_grids.Add(new InstanceGrid(m_gridIndex));
	}

	public void c526d28eda047d7e820ef2a3a9ecbed4f(Vector3 cef9712200bbe2c3873eec3ca2e18a595, Vector3 cb413b63b20e71ae5c504b03471480e2a)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = "RegisterLevelGrids:";
		array[1] = m_gridIndex;
		array[2] = " position:";
		array[3] = cef9712200bbe2c3873eec3ca2e18a595;
		array[4] = " size:";
		array[5] = cb413b63b20e71ae5c504b03471480e2a;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
		m_grids.Add(new Grid(m_gridIndex++, cef9712200bbe2c3873eec3ca2e18a595, cb413b63b20e71ae5c504b03471480e2a));
	}

	private void Update()
	{
		if (m_isLevelReady)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c9e979384eb3b7f05af1878c32be8512a();
					for (int i = 0; i < m_grids.Count; i++)
					{
						if (m_grids[i].isGeoGrid)
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
							m_grids[i].Update();
						}
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							cdea3a6cec74d602015b1ba13468c769f();
							return;
						}
					}
				}
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8266bc69cb6d3069bbd1b800662e5dbd())
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			cd8db8ec39bb02dbc2e9e29ca7ad17317();
			cd87d2a7c18f03a856f21cd9ef2ed7ce9();
			m_isLevelReady = true;
			return;
		}
	}

	private void cd87d2a7c18f03a856f21cd9ef2ed7ce9()
	{
		for (int i = 0; i < m_grids.Count; i++)
		{
			for (int j = i + 1; j < m_grids.Count; j++)
			{
				if (!m_grids[i].cf94ef1195a047a80546a2686375e537a(m_grids[j]))
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_grids[i].c10fe33275c225857272b1d8e59b25c3f(m_grids[j]);
				m_grids[j].c10fe33275c225857272b1d8e59b25c3f(m_grids[i]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00a1;
				}
				continue;
				end_IL_00a1:
				break;
			}
		}
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

	public void c070f89fa0787d8f729e321ccaf78a738(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (m_UnarrangedEntities.Contains(c5d720f6d007abb0c4a21d6a654e405bb))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_UnarrangedEntities.Add(c5d720f6d007abb0c4a21d6a654e405bb);
			return;
		}
	}

	public void c986e2c92f577697169e986d88211a625(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		EntityPlayer entityPlayer = c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer;
		if ((bool)entityPlayer)
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
			m_sessionGrid.c082c0a4f95d106b423ca9f6cea185076(entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().m_photonPlayer);
		}
		for (int i = 0; i < m_grids.Count; i++)
		{
			m_grids[i].c858d49c3aa8b8f3ea460cdf0aaa021bc(c5d720f6d007abb0c4a21d6a654e405bb);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			m_UnarrangedEntities.Remove(c5d720f6d007abb0c4a21d6a654e405bb);
			return;
		}
	}

	private void c9e979384eb3b7f05af1878c32be8512a()
	{
		for (int i = 0; i < m_UnarrangedEntities.Count; i++)
		{
			Entity entity = m_UnarrangedEntities[i];
			m_sessionGrid.c858d49c3aa8b8f3ea460cdf0aaa021bc(entity);
			EntityPlayer entityPlayer = entity as EntityPlayer;
			if ((bool)entityPlayer)
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
				m_sessionGrid.cf1657f157e2be9a3983c79565effc64b(entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().m_photonPlayer);
			}
			int num = 0;
			while (true)
			{
				if (num < m_grids.Count)
				{
					if (m_grids[num].isGeoGrid)
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
						if (m_grids[num].c7b0b058a2e7a511d7cd616b4c33a62ca(entity))
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
							m_grids[num].c9172684ab57085e2a77c2a3af69cb426(entity);
							m_UnarrangedEntities.Remove(entity);
							break;
						}
					}
					num++;
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
				break;
			}
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

	public void OnGridAddListener(Grid grid, PhotonPlayer player)
	{
		List<int> value = c0fcd81bbb74675098f106281392386f3.c7088de59e49f7108f520cf7e0bae167e;
		if (m_AddingGrids.TryGetValue(grid.m_id, out value))
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
					value.Add(player.c29a834d12d3895f5680e69a30e6cd9a3);
					return;
				}
			}
		}
		value = new List<int>();
		value.Add(player.c29a834d12d3895f5680e69a30e6cd9a3);
		m_AddingGrids.Add(grid.m_id, value);
	}

	public void OnGridRemoveListener(Grid grid, PhotonPlayer player)
	{
		List<int> value = c0fcd81bbb74675098f106281392386f3.c7088de59e49f7108f520cf7e0bae167e;
		if (m_RemovingGrids.TryGetValue(grid.m_id, out value))
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
					value.Add(player.c29a834d12d3895f5680e69a30e6cd9a3);
					return;
				}
			}
		}
		value = new List<int>();
		value.Add(player.c29a834d12d3895f5680e69a30e6cd9a3);
		m_RemovingGrids.Add(grid.m_id, value);
	}

	private void cdea3a6cec74d602015b1ba13468c769f()
	{
	}

	protected virtual void OnDrawGizmos()
	{
		using (List<Grid>.Enumerator enumerator = m_grids.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Grid current = enumerator.Current;
				current.OnDrawGizmos();
			}
			while (true)
			{
				switch (7)
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
	}
}
