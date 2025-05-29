using A;
using UnityEngine;

public class LevelObjectSync : MonoBehaviour
{
	public enum LevelObjectSyncState
	{
		Deactivated = 0,
		Activated = 1
	}

	private LevelObjectSyncState m_state;

	public LevelObjectSyncState m_initialState;

	public GameObject[] m_enableOnActivate = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(0);

	public GameObject[] m_disableOnActivate = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(0);

	public AnimationClip[] m_playOnActivate = cb017d9ec8302a508b2db26b89ec82e85.c0a0cdf4a196914163f7334d9b0781a04(0);

	public GameObject[] m_enableOnDeactivate = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(0);

	public GameObject[] m_disableOnDeactivate = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(0);

	public Animation[] m_playOnDeactivate = c96c04b1eaa0048ac3ba10cac3c967584.c0a0cdf4a196914163f7334d9b0781a04(0);

	private int m_levelObjectID;

	protected Animation m_animation;

	protected virtual void Awake()
	{
	}

	private void OnLevelWasLoaded()
	{
		if (!LevelObjectSyncManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			m_levelObjectID = LevelObjectSyncManager.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
			LevelObjectSyncManager.c5ee19dc8d4cccf5ae2de225410458b86.c8d59b839636d6ca6992727c0544bd4c8(m_levelObjectID, ref m_initialState);
			return;
		}
	}

	protected virtual void Start()
	{
		m_animation = GetComponent<Animation>();
		ccdbe4e8fac6da17241ea3a84ac4a449c(m_initialState, true);
	}

	public int c3db99fdbe4f5f530c7ee2cafae9d3eca()
	{
		return m_levelObjectID;
	}

	private void ccdbe4e8fac6da17241ea3a84ac4a449c(LevelObjectSyncState c17fcd0ed1024ad7689991a96ed60deb1, bool c98b923a4deef95378fc5ca923a2791c8)
	{
		if (!c98b923a4deef95378fc5ca923a2791c8)
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
			if (c17fcd0ed1024ad7689991a96ed60deb1 == m_state)
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
				break;
			}
		}
		m_state = c17fcd0ed1024ad7689991a96ed60deb1;
		LevelObjectSyncState state = m_state;
		if (state != 0)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (state != LevelObjectSyncState.Activated)
					{
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
					OnActivate();
					return;
				}
			}
		}
		OnDeactivate();
	}

	public virtual void ccdbe4e8fac6da17241ea3a84ac4a449c(LevelObjectSyncState c17fcd0ed1024ad7689991a96ed60deb1)
	{
		ccdbe4e8fac6da17241ea3a84ac4a449c(c17fcd0ed1024ad7689991a96ed60deb1, false);
	}

	public virtual void OnActivate()
	{
		for (int i = 0; i < m_enableOnActivate.Length; i++)
		{
			if (!(m_enableOnActivate[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_enableOnActivate[i].SetActive(true);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_disableOnActivate.Length; j++)
			{
				if (!(m_disableOnActivate[j] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_disableOnActivate[j].SetActive(false);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				for (int k = 0; k < m_playOnActivate.Length; k++)
				{
					if (!(m_playOnActivate[k] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					m_animation.Play(m_playOnActivate[k].name);
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
		}
	}

	public virtual void OnDeactivate()
	{
		for (int i = 0; i < m_enableOnDeactivate.Length; i++)
		{
			if (!m_enableOnDeactivate[i])
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
			m_enableOnDeactivate[i].SetActive(true);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < m_disableOnDeactivate.Length; j++)
			{
				if (!m_disableOnDeactivate[j])
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
				m_disableOnDeactivate[j].SetActive(false);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				for (int k = 0; k < m_playOnDeactivate.Length; k++)
				{
					if (!(m_playOnDeactivate[k] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					m_animation.Play(m_playOnDeactivate[k].name);
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
	}

	public LevelObjectSyncState c285c6dfb3039cfe6087d40143faf7488()
	{
		return m_state;
	}
}
