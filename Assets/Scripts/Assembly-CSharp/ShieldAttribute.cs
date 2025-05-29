using System;
using System.Collections;
using System.Collections.Generic;
using A;
using XsdSettings;

public class ShieldAttribute
{
	public List<ShieldAttributeConfig> m_shieldAttributes = new List<ShieldAttributeConfig>();

	public ShieldAttribute()
	{
		m_shieldAttributes.Clear();
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c76fe0a0ec8116347e7235530f2fffad7.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ShieldAttributeType cdc8afd29b145cd41766452ed8ad942b = (ShieldAttributeType)(int)enumerator.Current;
				m_shieldAttributes.Add(new ShieldAttributeConfig(cdc8afd29b145cd41766452ed8ad942b));
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
					switch (1)
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

	public float c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType c14a3281d507e19a44765abe71968063a)
	{
		return m_shieldAttributes[(int)c14a3281d507e19a44765abe71968063a].m_attrValue;
	}
}
