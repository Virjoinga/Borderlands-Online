using System.Collections.Generic;

public class AudioObjectFolder<T> : NamedUniqueAudioObject where T : NamedUniqueAudioObject
{
	private List<T> m_objectList = new List<T>();

	public List<T> cbd727a994978fbc688a671f62ad6415b
	{
		get
		{
			return m_objectList;
		}
		set
		{
			m_objectList = new List<T>(value);
		}
	}

	public void cb5c99fd46b7ccbb8badbe459550dcf36(T c9499262b6f91e1fc7e0aeb8b8a9f7e27)
	{
		if (m_objectList.Contains(c9499262b6f91e1fc7e0aeb8b8a9f7e27))
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
			m_objectList.Add(c9499262b6f91e1fc7e0aeb8b8a9f7e27);
			return;
		}
	}

	public void c84553af78dd0534986227b72279ffcd9(T c9499262b6f91e1fc7e0aeb8b8a9f7e27)
	{
		if (!m_objectList.Contains(c9499262b6f91e1fc7e0aeb8b8a9f7e27))
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
			m_objectList.Remove(c9499262b6f91e1fc7e0aeb8b8a9f7e27);
			return;
		}
	}
}
