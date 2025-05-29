using A;
using UnityEngine;

public class ObjectParticleManager : MonoBehaviour
{
	public bool m_clearAllParticleAtEnd;

	public ParticleInfo[] m_particlePlayList;

	public Transform m_defaultTransform;

	public Transform m_alternativeTransform;

	private VFXManager m_VFXManager;

	private float m_startTime;

	private void Start()
	{
		m_VFXManager = GetComponent<VFXManager>();
		m_startTime = Time.time;
		if (!(m_defaultTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_alternativeTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_defaultTransform.gameObject.SetActive(true);
				m_alternativeTransform.gameObject.SetActive(false);
				return;
			}
		}
	}

	private void Update()
	{
		for (int i = 0; i < m_particlePlayList.Length; i++)
		{
			if (m_particlePlayList[i].m_alreadyPlayed)
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
			if (!(Time.time - m_startTime > m_particlePlayList[i].m_delay))
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
			c7a63d99b415fdb2c7adba18081949333(m_particlePlayList[i].m_particleToPlay, m_particlePlayList[i].m_duration);
			m_particlePlayList[i].m_alreadyPlayed = true;
			if (!m_particlePlayList[i].m_hideDefaultTransformWhenPlay)
			{
				continue;
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
			if (!(m_defaultTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_defaultTransform.gameObject.SetActive(false);
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

	public void c1ccf778419424f0f595c0d069d66e4e1(ENPCParticleType c53787a82f53a62af33fe4c70a84a16bb)
	{
		for (int i = 0; i < m_particlePlayList.Length; i++)
		{
			if (m_particlePlayList[i].m_particleToPlay != c53787a82f53a62af33fe4c70a84a16bb)
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
			m_particlePlayList[i].m_alreadyPlayed = false;
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

	public void c7a63d99b415fdb2c7adba18081949333(ENPCParticleType c53787a82f53a62af33fe4c70a84a16bb, float cdc9f6ace07173b95607c1a4b98439397)
	{
		m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(c53787a82f53a62af33fe4c70a84a16bb, cdc9f6ace07173b95607c1a4b98439397);
	}

	public void cdb22a9a349507be00401b4d9fc80d1bb()
	{
		m_VFXManager.cb6ddb86ff592b855d40e4b6baac609bf();
	}

	public void cec482001ad991ef85e52e298f1fc3cdc()
	{
		if (!(m_defaultTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_alternativeTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_defaultTransform.gameObject.SetActive(false);
				m_alternativeTransform.gameObject.SetActive(true);
				return;
			}
		}
	}

	private void OnDestroy()
	{
		if (!m_clearAllParticleAtEnd)
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
			cdb22a9a349507be00401b4d9fc80d1bb();
			return;
		}
	}
}
