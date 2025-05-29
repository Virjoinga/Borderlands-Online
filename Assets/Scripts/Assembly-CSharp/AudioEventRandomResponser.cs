using A;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Audio/Audio Random")]
public class AudioEventRandomResponser : AudioEventResponsers
{
	private RandomGenerator m_generator;

	public override void caf18a168df80e6ec094fac2d4a6b3c2c(RandomGenerator c4e92c721e96d4bb1b50291f9c471cee2)
	{
		base.caf18a168df80e6ec094fac2d4a6b3c2c(c4e92c721e96d4bb1b50291f9c471cee2);
		m_generator = c4e92c721e96d4bb1b50291f9c471cee2;
	}

	private void c08d25ee746179815eeba0c1663c29791()
	{
		m_currentIndex = m_generator(base.name, m_responsers.Count);
		if (m_currentIndex == -1)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_currentResponser = c77a81794feffca75455e9cbf19cb9e49.c7088de59e49f7108f520cf7e0bae167e;
					return;
				}
			}
		}
		m_currentResponser = m_responsers[m_currentIndex];
	}

	public override void ccc9d3a38966dc10fedb531ea17d24611()
	{
		base.ccc9d3a38966dc10fedb531ea17d24611();
		c08d25ee746179815eeba0c1663c29791();
	}
}
