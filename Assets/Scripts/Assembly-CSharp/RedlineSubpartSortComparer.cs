using System.Collections.Generic;
using Core;
using XsdSettings;

public class RedlineSubpartSortComparer : IComparer<WeaponSubPart>
{
	public int Compare(WeaponSubPart part1, WeaponSubPart part2)
	{
		int num = WeaponStore.weaponStore.SubpartPriority.Length;
		int num2 = WeaponStore.weaponStore.SubpartPriority.Length;
		for (int i = 0; i < WeaponStore.weaponStore.SubpartPriority.Length; i++)
		{
			if (part1 == WeaponStore.weaponStore.SubpartPriority[i])
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				num = i;
			}
			else
			{
				if (part2 != WeaponStore.weaponStore.SubpartPriority[i])
				{
					continue;
				}
				while (true)
				{
					switch (5)
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
					switch (6)
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
					switch (5)
					{
					case 0:
						break;
					default:
						return -1;
					}
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Same weaponSubPart type in list? this is not right");
			return 0;
		}
	}
}
