using System;
using System.Collections;
using System.Collections.Generic;
using A;
using XsdSettings;

public class ClassModeAttribute
{
	public List<SkillAttributeConfig> m_classModeAttributes = new List<SkillAttributeConfig>();

	public ClassModeAttribute()
	{
		m_classModeAttributes.Clear();
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c494d7a9577f7e64983f9c532ef82600b.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				EffectType cdc8afd29b145cd41766452ed8ad942b = (EffectType)(int)enumerator.Current;
				m_classModeAttributes.Add(new SkillAttributeConfig(cdc8afd29b145cd41766452ed8ad942b));
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0083;
					}
					continue;
					end_IL_0083:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public float c4e0f63f4b4d409c5e3992c71520e30a0(EffectType c14a3281d507e19a44765abe71968063a, AffectType c7d663c1e25c9ad53f0f4a926e3924759)
	{
		if (!m_classModeAttributes[(int)c14a3281d507e19a44765abe71968063a].m_bModified)
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
					if (c7d663c1e25c9ad53f0f4a926e3924759 == AffectType.Scale)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return 1f;
							}
						}
					}
					return 0f;
				}
			}
		}
		return m_classModeAttributes[(int)c14a3281d507e19a44765abe71968063a].m_attrValue;
	}
}
