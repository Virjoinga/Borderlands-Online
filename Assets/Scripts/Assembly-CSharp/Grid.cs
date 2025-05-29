using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class Grid
{
	private Bounds bounds;

	public readonly List<PhotonView> m_views = new List<PhotonView>();

	private List<Entity> m_entity = new List<Entity>();

	private List<Grid> m_nearby = new List<Grid>();

	public readonly List<int> m_newcomersID = new List<int>();

	public readonly List<int> m_settlersID = new List<int>();

	public readonly int m_maxUpdateViews = 100;

	public byte m_id { get; protected set; }

	public bool isGeoGrid { get; protected set; }

	public Grid(byte c35f98ccbfa8c6bf09319c620b21b5dc5, Vector3 c0aef4bbfe1352f0b771c7b7f4453b26e, Vector3 cb413b63b20e71ae5c504b03471480e2a, bool cdb1cc40f8ff480fc147a5fac1cb4cdf0 = true)
	{
		m_id = c35f98ccbfa8c6bf09319c620b21b5dc5;
		bounds.center = c0aef4bbfe1352f0b771c7b7f4453b26e;
		bounds.size = cb413b63b20e71ae5c504b03471480e2a;
		isGeoGrid = cdb1cc40f8ff480fc147a5fac1cb4cdf0;
	}

	public virtual void c10fe33275c225857272b1d8e59b25c3f(Grid ccc05a501bdfe710a82b7969e7a7550dd)
	{
		if (m_nearby.Contains(ccc05a501bdfe710a82b7969e7a7550dd))
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
			m_nearby.Add(ccc05a501bdfe710a82b7969e7a7550dd);
			return;
		}
	}

	public virtual void cb4341b3564e3d55dc9f38df4b813c5da(PhotonView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (m_views.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			m_views.Add(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public virtual void c27542a6dc8f97862ef53db1d4f3a6db8(PhotonView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		m_views.Remove(ca4187010cdd35921f11dd5df8ccc23e3);
	}

	public virtual void cf1657f157e2be9a3983c79565effc64b(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (m_newcomersID.Contains(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_settlersID.Contains(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3))
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
				m_newcomersID.Add(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3);
				c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnGridAddListener(this, ceb41162a7cd2a1d5c4a03830e02b4198);
				return;
			}
		}
	}

	public virtual void c082c0a4f95d106b423ca9f6cea185076(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (m_settlersID.Remove(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3))
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
					m_newcomersID.Remove(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3);
					c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnGridRemoveListener(this, ceb41162a7cd2a1d5c4a03830e02b4198);
					return;
				}
			}
		}
		if (!m_newcomersID.Remove(ceb41162a7cd2a1d5c4a03830e02b4198.c29a834d12d3895f5680e69a30e6cd9a3))
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
			c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnGridRemoveListener(this, ceb41162a7cd2a1d5c4a03830e02b4198);
			return;
		}
	}

	public virtual void c9172684ab57085e2a77c2a3af69cb426(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (m_entity.Contains(c5d720f6d007abb0c4a21d6a654e405bb))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "Add Entity";
			array[1] = c5d720f6d007abb0c4a21d6a654e405bb.name;
			array[2] = c5d720f6d007abb0c4a21d6a654e405bb.cc7403315505256d19a7b92aa614a8f10();
			array[3] = " to grid";
			array[4] = m_id;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
			m_entity.Add(c5d720f6d007abb0c4a21d6a654e405bb);
			m_views.AddRange(c5d720f6d007abb0c4a21d6a654e405bb.m_networkViews);
			if (!(c5d720f6d007abb0c4a21d6a654e405bb is EntityPlayer))
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
				EntityPlayer entityPlayer = c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer;
				cf1657f157e2be9a3983c79565effc64b(entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().m_photonPlayer);
				return;
			}
		}
	}

	public virtual void c858d49c3aa8b8f3ea460cdf0aaa021bc(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (m_entity.Contains(c5d720f6d007abb0c4a21d6a654e405bb))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_entity.Remove(c5d720f6d007abb0c4a21d6a654e405bb);
			if (c5d720f6d007abb0c4a21d6a654e405bb is EntityPlayer)
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
				EntityPlayer entityPlayer = c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer;
				c082c0a4f95d106b423ca9f6cea185076(entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().m_photonPlayer);
			}
		}
		for (int i = 0; i < c5d720f6d007abb0c4a21d6a654e405bb.m_networkViews.Count; i++)
		{
			m_views.Remove(c5d720f6d007abb0c4a21d6a654e405bb.m_networkViews[i]);
		}
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

	public virtual bool c7b0b058a2e7a511d7cd616b4c33a62ca(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		return bounds.Contains(c5d720f6d007abb0c4a21d6a654e405bb.transform.position);
	}

	public virtual bool cf94ef1195a047a80546a2686375e537a(Grid ccc05a501bdfe710a82b7969e7a7550dd)
	{
		return bounds.Intersects(ccc05a501bdfe710a82b7969e7a7550dd.bounds);
	}

	public virtual void Update()
	{
		int num = 0;
		while (num < m_entity.Count)
		{
			Entity entity = m_entity[num];
			bool flag = false;
			for (int i = 0; i < m_nearby.Count; i++)
			{
				if (!m_nearby[i].c7b0b058a2e7a511d7cd616b4c33a62ca(entity))
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
				m_nearby[i].c9172684ab57085e2a77c2a3af69cb426(entity);
				flag = true;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (!c7b0b058a2e7a511d7cd616b4c33a62ca(entity))
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
					if (!flag)
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
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
						array[0] = "can not allocate the entity ";
						array[1] = entity.name;
						array[2] = entity.cc7403315505256d19a7b92aa614a8f10();
						array[3] = "at grid ";
						array[4] = m_id;
						array[5] = " to another grid. pos:";
						array[6] = entity.transform.position;
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, string.Concat(array));
						c06ca0e618478c23eba3419653a19760f<GridManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_UnarrangedEntities.Add(entity);
					}
					c858d49c3aa8b8f3ea460cdf0aaa021bc(entity);
				}
				num++;
				break;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void OnNetworkingUpdated()
	{
		m_settlersID.AddRange(m_newcomersID);
		m_newcomersID.Clear();
	}

	public void OnDrawGizmos()
	{
		if (m_entity.Count >= 1)
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
			Gizmos.color = Color.green;
		}
		Gizmos.DrawWireCube(bounds.center, bounds.size);
		using (List<Grid>.Enumerator enumerator = m_nearby.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Grid current = enumerator.Current;
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(bounds.center, current.bounds.center);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_009e;
				}
				continue;
				end_IL_009e:
				break;
			}
		}
		Gizmos.color = Color.white;
	}
}
