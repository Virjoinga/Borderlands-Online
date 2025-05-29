using System;
using A;
using Core;
using UnityEngine;

[Serializable]
public class AudioMixer
{
	public float m_scale = 1f;

	private AudioMixer m_parent;

	private AudioFadeType m_fadeType;

	private float m_defaultScale;

	private float m_fadeStartScale;

	private float m_targetScale;

	private float m_fadeStep;

	private float m_fadeStartPoint;

	private int m_maxNumVoices = -1;

	private int m_currentNumVoices;

	private bool m_mute;

	private static AudioMixer s_solo;

	public bool cfaa6343ef54871e0ca9e49a53a231aab()
	{
		return m_mute;
	}

	public void c662f42be491b01caed775b44185fd057(bool c07a1e1c9a1ad53a0cbf8dd721cc6931b)
	{
		m_mute = c07a1e1c9a1ad53a0cbf8dd721cc6931b;
	}

	public static AudioMixer cc6e94ad409ce979fc5bc7ed82ce3f0aa()
	{
		return s_solo;
	}

	public static void c388ae01a9e89c6f02690861988494a77(AudioMixer cea799cdbf778b55019b8e10bc6b8736d)
	{
		s_solo = cea799cdbf778b55019b8e10bc6b8736d;
	}

	public AudioFadeType c350ea3caf2fea949768363379f212ce4()
	{
		return m_fadeType;
	}

	public void c0bd8cf08184012e45f262f69c8c2860e()
	{
		m_fadeType = AudioFadeType.None;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_defaultScale = m_scale;
	}

	public void c364ecb1e3f2cafa6e8793178cfbd2327(float c2796c66c13e4346cf101d7928a271951, float cb17344c6ba6038b9297f344b2472c2f5 = 0f, bool c41a65acdc6feabec040241b1170d6b34 = true)
	{
		if (c41a65acdc6feabec040241b1170d6b34)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_scale = 0f;
		}
		m_fadeStartScale = m_scale;
		m_targetScale = m_defaultScale;
		m_fadeStep = c2796c66c13e4346cf101d7928a271951;
		m_fadeStartPoint = Time.time + cb17344c6ba6038b9297f344b2472c2f5;
		m_fadeType = AudioFadeType.FadeIn;
	}

	public void cadd9bee93ecf3ad1c30c38c48b9a22ef(float c2796c66c13e4346cf101d7928a271951)
	{
		m_fadeStartScale = m_scale;
		m_targetScale = 0f;
		m_fadeStep = c2796c66c13e4346cf101d7928a271951;
		m_fadeStartPoint = Time.time;
		m_fadeType = AudioFadeType.FadeOut;
	}

	public bool cc56123259c44174bf6c32d225c07c313()
	{
		bool flag = false;
		float num = Time.time - m_fadeStartPoint;
		if (num > 0f)
		{
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
			m_scale = m_fadeStartScale + (m_targetScale - m_fadeStartScale) * num / m_fadeStep;
			if (m_fadeType == AudioFadeType.FadeIn)
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
				if (m_scale > m_targetScale)
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
					m_scale = m_targetScale;
					flag = true;
				}
			}
			else if (m_fadeType == AudioFadeType.FadeOut)
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
				if ((double)m_scale < 0.001)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					m_scale = m_defaultScale;
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
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
			c0bd8cf08184012e45f262f69c8c2860e();
		}
		return flag;
	}

	public void c3cbb887eeba52f2125aa47b794ceeb5e(AudioMixer c0b8b4f11377b8a222dc728ff2c622559)
	{
		m_parent = c0b8b4f11377b8a222dc728ff2c622559;
	}

	public bool c5be961c712e4fb2c55fd726e27a850e2(AudioMixer cea799cdbf778b55019b8e10bc6b8736d)
	{
		if (cea799cdbf778b55019b8e10bc6b8736d == this)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return true;
				}
			}
		}
		if (m_parent == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return m_parent.c5be961c712e4fb2c55fd726e27a850e2(cea799cdbf778b55019b8e10bc6b8736d);
	}

	public void c26262bae53d5c2c52bddfedd7d419779(float c8fa619f2f864a86646215fa3f0aa7319)
	{
		if (!(c8fa619f2f864a86646215fa3f0aa7319 < 0f))
		{
			while (true)
			{
				switch (1)
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
			if (!(1f < c8fa619f2f864a86646215fa3f0aa7319))
			{
				goto IL_0045;
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
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "AudioMixer.SetLocalScale: out-of-bounds volume: " + c8fa619f2f864a86646215fa3f0aa7319);
		goto IL_0045;
		IL_0045:
		m_scale = Mathf.Clamp01(c8fa619f2f864a86646215fa3f0aa7319);
		m_targetScale = m_scale;
	}

	public float cc0a42a0f0722f4d51045b776d01ec4fc()
	{
		if (s_solo != null)
		{
			while (true)
			{
				switch (1)
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
			if (!c5be961c712e4fb2c55fd726e27a850e2(s_solo))
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
				if (!s_solo.c5be961c712e4fb2c55fd726e27a850e2(this))
				{
					goto IL_0066;
				}
			}
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
		if (m_mute)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			goto IL_0066;
		}
		float result = m_scale;
		goto IL_0073;
		IL_0073:
		return result;
		IL_0066:
		result = 0f;
		goto IL_0073;
	}

	public float c609ccaaff98c19a49a8607c90d848bc9()
	{
		float num = cc0a42a0f0722f4d51045b776d01ec4fc();
		if (m_parent != null)
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
			if (num > 0f)
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
				num *= m_parent.c609ccaaff98c19a49a8607c90d848bc9();
			}
		}
		return num;
	}

	public void c3c97153ecd62d38c6885ab2ee963730c()
	{
		m_currentNumVoices = 0;
	}

	public int c08972c6c4207997157ac7a208df2eea1()
	{
		return m_currentNumVoices;
	}

	public int c2f90d8ac0668f5966e81a74935ffdeda()
	{
		return m_maxNumVoices;
	}

	public bool c657bf856d2ad05da762f87a1b533f478()
	{
		return m_maxNumVoices > 0;
	}

	public void cfbed0abcdee56ed3111d1d2756add2d7(int cbbb5ca695722f5de21f47d424e2302c9)
	{
		m_maxNumVoices = cbbb5ca695722f5de21f47d424e2302c9;
	}

	private bool c2617af35e9ea338344917b86c02bf3a8()
	{
		int result;
		if (c657bf856d2ad05da762f87a1b533f478())
		{
			while (true)
			{
				switch (1)
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
			result = ((m_currentNumVoices < m_maxNumVoices) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public bool c9195b8abe338cb95c3049fa8932947a9()
	{
		int result;
		if (c2617af35e9ea338344917b86c02bf3a8())
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
			if (m_parent != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				result = (m_parent.c9195b8abe338cb95c3049fa8932947a9() ? 1 : 0);
			}
			else
			{
				result = 1;
			}
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void caf3e02be9e4a934ca58b0bb0fd29af4d()
	{
		if (!c2617af35e9ea338344917b86c02bf3a8())
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = "IncrementVoiceCount: already at or above maximum voice count: ";
			array[1] = m_currentNumVoices;
			array[2] = " >= ";
			array[3] = m_maxNumVoices;
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, string.Concat(array));
		}
		m_currentNumVoices++;
		if (m_parent == null)
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
			m_parent.caf3e02be9e4a934ca58b0bb0fd29af4d();
			return;
		}
	}

	public void c4e38b0ce5ca1d64e0131311fc493ee08()
	{
		m_currentNumVoices--;
		if (m_parent == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_parent.c4e38b0ce5ca1d64e0131311fc493ee08();
			return;
		}
	}
}
