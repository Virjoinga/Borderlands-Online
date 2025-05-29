using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class VisibilityManager : c06ca0e618478c23eba3419653a19760f<VisibilityManager>
{
	public int MaxVisibileNumber = 30;

	public List<Renderer> m_meshRenders = new List<Renderer>();

	public Dictionary<Entity, List<Renderer>> m_invisibles = new Dictionary<Entity, List<Renderer>>();

	private void Start()
	{
	}

	private void Update()
	{
		List<Renderer> list = new List<Renderer>();
		using (List<Renderer>.Enumerator enumerator = m_meshRenders.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Renderer current = enumerator.Current;
				if (!(current == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				list.Add(current);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0054;
				}
				continue;
				end_IL_0054:
				break;
			}
		}
		using (List<Renderer>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				Renderer current2 = enumerator2.Current;
				if (!(current2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
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
				m_meshRenders.Remove(current2);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_00b5;
				}
				continue;
				end_IL_00b5:
				break;
			}
		}
		int num = 0;
		List<Entity> c0c2a548e7e20a141e7763c365a4d;
		c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Player, out c0c2a548e7e20a141e7763c365a4d);
		c2864d21026187ec4d5b8e7d3885f57f9(ref c0c2a548e7e20a141e7763c365a4d);
		cc44aca88515147efeb1f823dfa1a30c7(ref c0c2a548e7e20a141e7763c365a4d);
		for (int i = 0; i < c0c2a548e7e20a141e7763c365a4d.Count; i++)
		{
			if ((c0c2a548e7e20a141e7763c365a4d[i] as EntityPlayer).caac907d451029d68503484a63934c93f())
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
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631((c0c2a548e7e20a141e7763c365a4d[i] as EntityPlayer).ca15c8f7004fafacb3955a523d9a1cec9()))
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
				continue;
			}
			if (num < MaxVisibileNumber)
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
				if (!m_invisibles.ContainsKey(c0c2a548e7e20a141e7763c365a4d[i]))
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
					num++;
					continue;
				}
			}
			c28f66161c15a244f19769bdac25b2b7a(c0c2a548e7e20a141e7763c365a4d[i]);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (num >= MaxVisibileNumber)
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
				Entity[] array = cab690d6dad87479a5f95cd29e5fb3be9.c0a0cdf4a196914163f7334d9b0781a04(MaxVisibileNumber - num);
				m_invisibles.Keys.CopyTo(array, 0);
				for (int j = 0; j < array.Length; j++)
				{
					c43cbb41bf755dfa61de619fc6e86ab31(array[j]);
					num++;
					if (num < MaxVisibileNumber)
					{
						continue;
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
	}

	public void c57e4d4cd41f3be21d7e24a71aa08c6ba(Renderer c91cbe02810173de3a981383253864426)
	{
		if (!c91cbe02810173de3a981383253864426)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "VisibilityManager.register" + c91cbe02810173de3a981383253864426.name);
			m_meshRenders.Add(c91cbe02810173de3a981383253864426);
			return;
		}
	}

	public void cf5212e6903ec0c0b27816142c32a2d13(Renderer c91cbe02810173de3a981383253864426)
	{
		m_meshRenders.Remove(c91cbe02810173de3a981383253864426);
	}

	private void c28f66161c15a244f19769bdac25b2b7a(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		for (int i = 0; i < m_meshRenders.Count; i++)
		{
			if (m_meshRenders[i].transform.IsChildOf(c5d720f6d007abb0c4a21d6a654e405bb.transform))
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
				if (m_meshRenders[i].enabled)
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
					List<Renderer> value;
					if (m_invisibles.TryGetValue(c5d720f6d007abb0c4a21d6a654e405bb, out value))
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
						value.Add(m_meshRenders[i]);
					}
					else
					{
						value = new List<Renderer>();
						value.Add(m_meshRenders[i]);
						m_invisibles.Add(c5d720f6d007abb0c4a21d6a654e405bb, value);
					}
					m_meshRenders[i].enabled = false;
				}
			}
			(c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer).c63f8f07320313ddc4213cb59ee025962().c7625f669cf7d310f5ae9a4aa2646e757(false);
			(c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer).cdf1673221e3a3e5e9bb9d0d07224afc6(false);
		}
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

	private void c43cbb41bf755dfa61de619fc6e86ab31(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (!c5d720f6d007abb0c4a21d6a654e405bb)
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
			List<Renderer> value;
			if (!m_invisibles.TryGetValue(c5d720f6d007abb0c4a21d6a654e405bb, out value))
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
				for (int i = 0; i < value.Count; i++)
				{
					value[i].enabled = true;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					value.Clear();
					m_invisibles.Remove(c5d720f6d007abb0c4a21d6a654e405bb);
					(c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer).c63f8f07320313ddc4213cb59ee025962().c7625f669cf7d310f5ae9a4aa2646e757(true);
					(c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer).cdf1673221e3a3e5e9bb9d0d07224afc6(true);
					return;
				}
			}
		}
	}

	private void c2864d21026187ec4d5b8e7d3885f57f9(ref List<Entity> c1025255bcb853fd85f60830829aac526)
	{
		int num = 0;
		for (int i = 0; i < c1025255bcb853fd85f60830829aac526.Count; i++)
		{
			if (!FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c52b0e4c302961935453bec436d84dc68((c1025255bcb853fd85f60830829aac526[i] as EntityPlayer).ca15c8f7004fafacb3955a523d9a1cec9()))
			{
				continue;
			}
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
			Entity value = c1025255bcb853fd85f60830829aac526[num];
			c1025255bcb853fd85f60830829aac526[num] = c1025255bcb853fd85f60830829aac526[i];
			c1025255bcb853fd85f60830829aac526[i] = value;
			num++;
		}
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

	private void cc44aca88515147efeb1f823dfa1a30c7(ref List<Entity> c1025255bcb853fd85f60830829aac526)
	{
		int num = 0;
		for (int i = 0; i < c1025255bcb853fd85f60830829aac526.Count; i++)
		{
			if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c66bf8bbd3d688c43085d847b766f9e5b((c1025255bcb853fd85f60830829aac526[i] as EntityPlayer).ca15c8f7004fafacb3955a523d9a1cec9()))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Entity value = c1025255bcb853fd85f60830829aac526[num];
			c1025255bcb853fd85f60830829aac526[num] = c1025255bcb853fd85f60830829aac526[i];
			c1025255bcb853fd85f60830829aac526[i] = value;
			num++;
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
}
