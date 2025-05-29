using System;
using System.Xml;
using UnityEngine;

public class AudioRTPCDefinition : NamedUniqueAudioObject
{
	public float m_defaultValue;

	public float m_minValue;

	public float m_maxValue;

	public AudioObjectFolder<AudioRTPCDefinition> m_parentFolder;

	private static readonly string MIN_VALUE_ATTR = "minValue";

	private static readonly string MAX_VALUE_ATTR = "maxValue";

	private static readonly string DEF_VALUE_ATTR = "defaultValue";

	public bool c3267fc9b8de3654f962de090855e92dc(float c3a93568e0f033263d093913b18d1f42c)
	{
		int result;
		if (m_minValue <= c3a93568e0f033263d093913b18d1f42c)
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
			result = ((c3a93568e0f033263d093913b18d1f42c <= m_maxValue) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public float c5c3cf815f5e698dc5a9b5e0ffd1d1fb7(float c3a93568e0f033263d093913b18d1f42c)
	{
		return Mathf.Clamp(m_minValue, m_maxValue, c3a93568e0f033263d093913b18d1f42c);
	}

	public float cd2b4a7bb19779290a5d990bfbfe2f27f(float c3a93568e0f033263d093913b18d1f42c)
	{
		return Mathf.InverseLerp(m_minValue, m_maxValue, c3a93568e0f033263d093913b18d1f42c);
	}

	public float c92ff55df7c4467fcf2c7682bb8168445(float cf74d9ae77fb742261a506769b3a230e8)
	{
		return Mathf.Lerp(m_minValue, m_maxValue, cf74d9ae77fb742261a506769b3a230e8);
	}

	public override void cc09306479ed0f9f54a5e4e8dd8d72b99(XmlNode cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		base.cc09306479ed0f9f54a5e4e8dd8d72b99(cab83bba925e6355b7d0df9fe7c31c6e1);
		m_minValue = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[MIN_VALUE_ATTR].Value);
		m_maxValue = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[MAX_VALUE_ATTR].Value);
		if (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[DEF_VALUE_ATTR] != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_defaultValue = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[DEF_VALUE_ATTR].Value);
					return;
				}
			}
		}
		m_defaultValue = m_minValue;
	}

	public override void c9742307d0830ac7381f2acd66ed5a6e2(XmlElement cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		base.c9742307d0830ac7381f2acd66ed5a6e2(cab83bba925e6355b7d0df9fe7c31c6e1);
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute(DEF_VALUE_ATTR, m_defaultValue.ToString());
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute(MIN_VALUE_ATTR, m_minValue.ToString());
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute(MAX_VALUE_ATTR, m_maxValue.ToString());
	}
}
