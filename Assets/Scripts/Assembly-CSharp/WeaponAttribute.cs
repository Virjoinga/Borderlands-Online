using System;
using System.Collections;
using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

[Serializable]
public class WeaponAttribute
{
	[SerializeField]
	public WeaponType m_weaponType;

	[SerializeField]
	public List<BOLAttribute> m_weaponAttribute = new List<BOLAttribute>();

	public WeaponAttribute()
	{
	}

	public WeaponAttribute(WeaponAttribute c5eb5bb2a5bc236b25b9814b957699568)
	{
		m_weaponType = c5eb5bb2a5bc236b25b9814b957699568.m_weaponType;
		m_weaponAttribute.Clear();
		using (List<BOLAttribute>.Enumerator enumerator = c5eb5bb2a5bc236b25b9814b957699568.m_weaponAttribute.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BOLAttribute current = enumerator.Current;
				m_weaponAttribute.Add(new BOLAttribute(current));
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
				return;
			}
		}
	}

	public WeaponAttribute(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc, WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
		m_weaponType = c2b4f43f34e21572af6ab4414f04cee36;
		if (!ccb88cc9ce41c4f9df0c68fa9f9360ffc)
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
			m_weaponAttribute.Clear();
			IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c25a6363a7a7e86d9c74685be52d97b15.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					AttributeType c2b4f43f34e21572af6ab4414f04cee37 = (AttributeType)(int)enumerator.Current;
					m_weaponAttribute.Add(AttributeStore.attributeStore.cb66e09406d31e61e068f9c0f2be88f8f(c2b4f43f34e21572af6ab4414f04cee37));
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_00a3;
						}
						continue;
						end_IL_00a3:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
	}

	public void c7a3a9c22cd95b108e71a40ce2ee85008()
	{
		List<BOLAttribute> list = new List<BOLAttribute>();
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c25a6363a7a7e86d9c74685be52d97b15.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			AttributeType attributeType;
			while (enumerator.MoveNext())
			{
				attributeType = (AttributeType)(int)enumerator.Current;
				int num = m_weaponAttribute.FindIndex((BOLAttribute c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.m_attributeType == attributeType);
				if (num >= 0)
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
					list.Add(m_weaponAttribute[num]);
				}
				else
				{
					list.Add(AttributeStore.attributeStore.cb66e09406d31e61e068f9c0f2be88f8f(attributeType));
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_00b3;
				}
				continue;
				end_IL_00b3:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_00cb;
					}
					continue;
					end_IL_00cb:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		using (List<BOLAttribute>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				BOLAttribute current = enumerator2.Current;
				current.c44f9e79fa85546625edd2986a4083fbf();
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_0105;
				}
				continue;
				end_IL_0105:
				break;
			}
		}
		m_weaponAttribute = list;
	}

	public AttributeValue c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType c14a3281d507e19a44765abe71968063a)
	{
		return m_weaponAttribute[(int)c14a3281d507e19a44765abe71968063a].m_attributeValue;
	}

	public float c2d32d874e045788b400f1b8bfd71f5f0()
	{
		if (m_weaponType == WeaponType.SniperRifle)
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
					return 100f - (m_weaponAttribute[8].m_attributeValue as FloatAttributeValue).m_value;
				}
			}
		}
		return 100f - (m_weaponAttribute[2].m_attributeValue as FloatAttributeValue).m_value;
	}
}
