using System.Collections.Generic;
using A;
using UnityEngine;

internal class PrefabPool
{
	private GameObject m_go;

	private GameObject m_template;

	private List<GameObject> m_pool = new List<GameObject>();

	public string cd99af21e22e356018b8f72d4a7e4872a
	{
		get
		{
			object result;
			if (null != m_template)
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
				result = m_template.name;
			}
			else
			{
				result = null;
			}
			return (string)result;
		}
	}

	public PrefabPool(GameObject c67a1d98c1674ef249d2771121eef0ec8, GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		m_template = c67a1d98c1674ef249d2771121eef0ec8;
		m_go = new GameObject();
		Object.DontDestroyOnLoad(m_go);
		m_go.hideFlags = HideFlags.DontSave;
		m_go.name = c67a1d98c1674ef249d2771121eef0ec8.name;
		if (!(null != c0b8b4f11377b8a222dc728ff2c622559))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Utils.cee1496692d8e43aa68171d8c01774b76(m_go, c0b8b4f11377b8a222dc728ff2c622559);
			return;
		}
	}

	public string ce3e478508e5e484d064256062bedc4a4()
	{
		return "PrefabPool[ " + cd99af21e22e356018b8f72d4a7e4872a + " ]";
	}

	private GameObject cdefc42856b33a785a329a94fec6bdafa()
	{
		GameObject result = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (m_pool.Count > 0)
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
			int num = m_pool.Count - 1;
			int num2 = num;
			while (num2 >= 0)
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
				if (null == m_pool[num2])
				{
					num2--;
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
				break;
			}
			if (num2 == -1)
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
				m_pool.Clear();
			}
			else
			{
				result = m_pool[num2];
				m_pool.RemoveRange(num2, m_pool.Count - num2);
			}
		}
		return result;
	}

	public GameObject c3bbc599e9b8f85f2f044dfd09efdfc1a(GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		GameObject gameObject = cdefc42856b33a785a329a94fec6bdafa();
		if (null == gameObject)
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
			gameObject = c5c65f2f579dcd2462a0d62f3b7ba6ad8();
		}
		if (null != c0b8b4f11377b8a222dc728ff2c622559)
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
			Utils.cee1496692d8e43aa68171d8c01774b76(gameObject, c0b8b4f11377b8a222dc728ff2c622559);
		}
		return gameObject;
	}

	public void c6f00f93ae7322a2e474ac89d787bab88(GameObject ccf24681862bae286c19d5c9b16296be5)
	{
		Utils.cee1496692d8e43aa68171d8c01774b76(ccf24681862bae286c19d5c9b16296be5, m_go);
		m_pool.Add(ccf24681862bae286c19d5c9b16296be5);
	}

	public void Reset()
	{
		m_pool.Clear();
		Object.Destroy(m_go);
	}

	private GameObject c5c65f2f579dcd2462a0d62f3b7ba6ad8()
	{
		GameObject gameObject = (GameObject)Object.Instantiate(m_template);
		gameObject.hideFlags = HideFlags.DontSave;
		Object.DontDestroyOnLoad(gameObject);
		gameObject.name = m_template.name;
		return gameObject;
	}
}
