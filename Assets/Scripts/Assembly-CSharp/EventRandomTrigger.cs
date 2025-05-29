using UnityEngine;

public class EventRandomTrigger
{
	public string m_eventName = "event name";

	public float m_rangeMin;

	public float m_rangeMax = 1f;

	private bool m_definedInThisEntity = true;

	private float m_nextTime;

	public void Start()
	{
		cc796d3d4960907acb95f50522becc392();
	}

	public bool c1311fffa224c7d908ff7e3b9a50dfda6()
	{
		bool flag = Time.time >= m_nextTime;
		if (flag)
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
			cc796d3d4960907acb95f50522becc392();
		}
		return flag;
	}

	private void cc796d3d4960907acb95f50522becc392()
	{
		m_nextTime = Time.time + Random.Range(m_rangeMin, m_rangeMax);
	}

	public void c833355f28871126c97086f4d9e61227e(bool c0c4bf0f54e5e72115e9cded4dbe02512)
	{
		m_definedInThisEntity = c0c4bf0f54e5e72115e9cded4dbe02512;
	}

	public bool c4e63cdf7582b2c7b45768fe92e5993ed()
	{
		return m_definedInThisEntity;
	}
}
