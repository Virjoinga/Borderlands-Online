using System.Collections.Generic;
using Core;

public class AttributeScaleSortComparer : IComparer<AttributeScale>
{
	public int Compare(AttributeScale attr1, AttributeScale attr2)
	{
		if (attr1.m_scale > attr2.m_scale)
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
					return 1;
				}
			}
		}
		if (attr1.m_scale < attr2.m_scale)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return -1;
				}
			}
		}
		int num = WeaponStore.weaponStore.AttributePriority.Length;
		int num2 = WeaponStore.weaponStore.AttributePriority.Length;
		for (int i = 0; i < WeaponStore.weaponStore.AttributePriority.Length; i++)
		{
			if (attr1.m_attribute == WeaponStore.weaponStore.AttributePriority[i])
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
				num = i;
			}
			else
			{
				if (attr2.m_attribute != WeaponStore.weaponStore.AttributePriority[i])
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
				num2 = i;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (num < num2)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return 1;
					}
				}
			}
			if (num > num2)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return -1;
					}
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "AttributeScale have same m_attribute and scale, this is not right");
			return 0;
		}
	}
}
