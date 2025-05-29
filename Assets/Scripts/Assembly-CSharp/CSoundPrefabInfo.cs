using System.Collections.Generic;
using A;

public class CSoundPrefabInfo
{
	public string m_sAudioPrefabName;

	public float m_fInterval;

	public float m_fDelay;

	public float m_fDistanceToTrigger;

	public float m_fFadeTime;

	public AudioEventAction m_eAction;

	public AudioEventResponser m_audioResponser;

	public float m_lastTriggerTime;

	public bool m_isClassSpecific;

	public bool m_isLocalPlayerOnly;

	public List<BaseEventResponser> m_activeList;

	public List<BaseEventResponser> m_freeList;

	public CSoundPrefabInfo()
	{
		m_sAudioPrefabName = string.Empty;
		m_fInterval = 0f;
		m_fDelay = 0f;
		m_fDistanceToTrigger = 500f;
		m_fFadeTime = 0f;
		m_lastTriggerTime = 0f;
		m_eAction = AudioEventAction.Play;
		m_audioResponser = cbe137deea149a1ba3f526c4acf30a625.c7088de59e49f7108f520cf7e0bae167e;
		m_activeList = new List<BaseEventResponser>();
		m_freeList = new List<BaseEventResponser>();
	}

	public int cd4e12d8d6f3fb9d92eb9f9d4eb3dd826()
	{
		for (int i = 0; i < m_activeList.Count; i++)
		{
			if (m_activeList[i].cb9efc4af2006b47000b468b9df139a30())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_freeList.Add(m_activeList[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			AudioResourceManager c9f6a0386ce93c761939b8a4def1e = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435;
			for (int j = 0; j < m_freeList.Count; j++)
			{
				BaseEventResponser baseEventResponser = m_freeList[j];
				c9f6a0386ce93c761939b8a4def1e.c0ff8eff4666ce864dea315d6be106481(baseEventResponser.gameObject);
				m_activeList.Remove(baseEventResponser);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				m_freeList.Clear();
				return m_activeList.Count;
			}
		}
	}
}
