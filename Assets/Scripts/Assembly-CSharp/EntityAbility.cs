using System.Collections.Generic;
using UnityEngine;

public class EntityAbility : MonoBehaviour
{
	private Dictionary<int, Action> m_Actions = new Dictionary<int, Action>();

	private Dictionary<string, Action> m_ActionNames = new Dictionary<string, Action>();

	private Entity m_entity;

	private void Awake()
	{
		m_entity = GetComponent<Entity>();
	}

	public void ce385d5e67ccaf21ebf4f026a4744475e(Action c861de212c63da4e42109937e3cac1a44)
	{
		m_Actions.Add(c861de212c63da4e42109937e3cac1a44.cedd6df992c20da839c6da89aebf78bea(), c861de212c63da4e42109937e3cac1a44);
		m_ActionNames.Add(c861de212c63da4e42109937e3cac1a44.GetType().Name, c861de212c63da4e42109937e3cac1a44);
		c861de212c63da4e42109937e3cac1a44.Start(m_entity);
	}

	public void c5f5fd9016b4470a3114ff92c3b6f4565(Action c861de212c63da4e42109937e3cac1a44)
	{
		m_Actions.Remove(c861de212c63da4e42109937e3cac1a44.cedd6df992c20da839c6da89aebf78bea());
		m_ActionNames.Remove(c861de212c63da4e42109937e3cac1a44.GetType().Name);
		c861de212c63da4e42109937e3cac1a44.c365a77c63c91e13de4ca19c9a953aa5e(m_entity);
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		using (Dictionary<int, Action>.ValueCollection.Enumerator enumerator = m_Actions.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Action current = enumerator.Current;
				current.c365a77c63c91e13de4ca19c9a953aa5e(m_entity);
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
				break;
			}
		}
		m_Actions.Clear();
		m_ActionNames.Clear();
	}

	public Action c663d11c8834305590100229866ab1cbc(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		if (m_Actions.ContainsKey(c35f98ccbfa8c6bf09319c620b21b5dc5))
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
					return m_Actions[c35f98ccbfa8c6bf09319c620b21b5dc5];
				}
			}
		}
		return null;
	}

	public Action c663d11c8834305590100229866ab1cbc(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		return m_ActionNames[cd99af21e22e356018b8f72d4a7e4872a];
	}

	public void ca1ca367e3e7bc5e3d1d18071c855c82f(string cd99af21e22e356018b8f72d4a7e4872a, bool cfc2b13fa6a0b27e2980698f92f04d34c = true, int cd22aa6735988e8e65acbd503f3870e3e = 0)
	{
		if (cfc2b13fa6a0b27e2980698f92f04d34c)
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
					m_ActionNames[cd99af21e22e356018b8f72d4a7e4872a].c99ba9c13b5a9e792c3b892f32759fc1c(cd22aa6735988e8e65acbd503f3870e3e);
					return;
				}
			}
		}
		m_ActionNames[cd99af21e22e356018b8f72d4a7e4872a].cd91d39f37531b5cbfdda0b9a40a28e12(cd22aa6735988e8e65acbd503f3870e3e);
	}
}
