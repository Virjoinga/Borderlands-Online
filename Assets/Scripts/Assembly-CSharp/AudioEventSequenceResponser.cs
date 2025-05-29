using Core;
using UnityEngine;

[AddComponentMenu("Audio/Audio Sequence")]
public class AudioEventSequenceResponser : AudioEventResponsers
{
	public AudioEventResponser[] m_orderedResponsers;

	public bool m_isLoop;

	public bool m_isRandom;

	private bool m_needUpdate;

	private bool m_isPlaying;

	public override void Awake()
	{
		base.Awake();
		m_responsers.Clear();
		if (m_orderedResponsers.Length < 1)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "*****OrderedResponsers missing!");
					return;
				}
			}
		}
		for (int i = 0; i < m_orderedResponsers.Length; i++)
		{
			m_responsers.Add(m_orderedResponsers[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			m_currentResponser = m_responsers[0];
			return;
		}
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7()
	{
		m_currentResponser.c0a75d7afd2f7f1e47a5aadaab61303c7();
		m_needUpdate = true;
		m_isPlaying = true;
	}

	public override void c0a75d7afd2f7f1e47a5aadaab61303c7(float cb17344c6ba6038b9297f344b2472c2f5)
	{
		m_currentResponser.c0a75d7afd2f7f1e47a5aadaab61303c7(cb17344c6ba6038b9297f344b2472c2f5);
		m_needUpdate = true;
		m_isPlaying = true;
	}

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		if (m_isRandom)
		{
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
			m_currentIndex = Random.Range(0, m_responsers.Count);
		}
		else
		{
			m_currentIndex = 0;
		}
		m_currentResponser = m_responsers[m_currentIndex];
	}

	public override bool cb9efc4af2006b47000b468b9df139a30()
	{
		return m_isPlaying;
	}

	public override void cdada4c3678c9c23c38aaf0754a94a620()
	{
		base.cdada4c3678c9c23c38aaf0754a94a620();
		m_needUpdate = false;
		m_isPlaying = false;
	}

	private new void Update()
	{
		if (!m_needUpdate)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		if (m_currentResponser.cb9efc4af2006b47000b468b9df139a30())
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
			m_currentResponser.cdada4c3678c9c23c38aaf0754a94a620();
			if (m_isRandom)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				int num;
				for (num = Random.Range(0, m_responsers.Count); num == m_currentIndex; num = Random.Range(0, m_responsers.Count))
				{
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
				m_currentIndex = num;
			}
			else
			{
				m_currentIndex++;
			}
			if (m_currentIndex >= m_responsers.Count)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (m_isLoop)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									m_currentIndex = 0;
									m_currentResponser = m_responsers[m_currentIndex];
									m_currentResponser.c0a75d7afd2f7f1e47a5aadaab61303c7();
									return;
								}
							}
						}
						m_isPlaying = false;
						m_needUpdate = false;
						return;
					}
				}
			}
			m_currentResponser = m_responsers[m_currentIndex];
			m_currentResponser.c0a75d7afd2f7f1e47a5aadaab61303c7();
			return;
		}
	}
}
