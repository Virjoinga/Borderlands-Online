using UnityEngine;

public class EffectPoolController : MonoBehaviour
{
	[HideInInspector]
	public bool m_destroyedByPool;

	[HideInInspector]
	public EffectPool m_pool;

	private void OnDestroy()
	{
		if (m_destroyedByPool)
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
			if (m_pool == null)
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
				m_pool.c858d49c3aa8b8f3ea460cdf0aaa021bc(base.gameObject);
				return;
			}
		}
	}

	private void YouAreDestroyedByPool()
	{
		m_destroyedByPool = true;
	}

	public void c57e4d4cd41f3be21d7e24a71aa08c6ba(EffectPool c860b65fd75579a8a47b05d64677f373b)
	{
		m_pool = c860b65fd75579a8a47b05d64677f373b;
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
			m_pool.c9172684ab57085e2a77c2a3af69cb426(base.gameObject);
			return;
		}
	}
}
