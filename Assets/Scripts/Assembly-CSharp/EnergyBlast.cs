using A;
using UnityEngine;

public class EnergyBlast : MonoBehaviour
{
	public BHVTaskManager m_taskManager;

	public float m_delayTimer = 1f;

	private bool m_bStarted;

	private void Start()
	{
		m_bStarted = false;
	}

	private void Update()
	{
		if (m_bStarted)
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
			m_delayTimer -= Time.deltaTime;
			if (!(m_delayTimer < 0f))
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
				ParticleSystem component = GetComponent<ParticleSystem>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					component.Play();
				}
				Object.Destroy(base.gameObject, 5f);
				m_bStarted = true;
				return;
			}
		}
	}
}
