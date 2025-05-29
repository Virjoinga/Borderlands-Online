using System.Collections.Generic;
using A;
using UnityEngine;

public class EffectPool
{
	public int m_max;

	private List<GameObject> m_pool;

	public EffectPool(int c8cc109d7daf35ef5b180de3c5ac6de20)
	{
		m_max = c8cc109d7daf35ef5b180de3c5ac6de20;
		if (c8cc109d7daf35ef5b180de3c5ac6de20 <= 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_pool = new List<GameObject>(m_max);
			return;
		}
	}

	public void c9172684ab57085e2a77c2a3af69cb426(GameObject cf57af788088518e7ab778f819794c902)
	{
		if (m_pool == null)
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
			if (!(cf57af788088518e7ab778f819794c902 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				break;
			}
			while (m_pool.Count >= m_max)
			{
				GameObject gameObject = m_pool[0];
				gameObject.SendMessage("YouAreDestroyedByPool", SendMessageOptions.DontRequireReceiver);
				Object.Destroy(gameObject);
				m_pool.RemoveAt(0);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				m_pool.Add(cf57af788088518e7ab778f819794c902);
				return;
			}
		}
	}

	public void c858d49c3aa8b8f3ea460cdf0aaa021bc(GameObject cf57af788088518e7ab778f819794c902)
	{
		if (m_pool == null)
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
			m_pool.Remove(cf57af788088518e7ab778f819794c902);
			return;
		}
	}
}
