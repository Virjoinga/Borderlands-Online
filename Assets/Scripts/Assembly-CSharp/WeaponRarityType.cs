using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

[Serializable]
public class WeaponRarityType
{
	[SerializeField]
	public WeaponRarity m_weaponRarity;

	[SerializeField]
	public List<SubPartsInRarity> m_subPartTypes = new List<SubPartsInRarity>();

	public WeaponRarityType()
	{
	}

	public WeaponRarityType(WeaponRarityType c5eb5bb2a5bc236b25b9814b957699568)
	{
		m_subPartTypes.Clear();
		for (int i = 0; i < c5eb5bb2a5bc236b25b9814b957699568.m_subPartTypes.Count; i++)
		{
			m_subPartTypes.Add(new SubPartsInRarity(c5eb5bb2a5bc236b25b9814b957699568.m_subPartTypes[i]));
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

	public WeaponRarityType(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc, WeaponRarity c335b432937e6c5b61e3fce114d6b6ca5)
	{
		m_weaponRarity = c335b432937e6c5b61e3fce114d6b6ca5;
		if (!ccb88cc9ce41c4f9df0c68fa9f9360ffc)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_subPartTypes.Clear();
			for (int i = 0; i < 9; i++)
			{
				m_subPartTypes.Add(new SubPartsInRarity(true, (WeaponSubPart)i));
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void c7a3a9c22cd95b108e71a40ce2ee85008()
	{
		List<SubPartsInRarity> list = new List<SubPartsInRarity>();
		for (int i = 0; i < 9; i++)
		{
			WeaponSubPart weaponSubPart = (WeaponSubPart)i;
			int num = m_subPartTypes.FindIndex((SubPartsInRarity c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.m_weaponSubPart == weaponSubPart);
			if (num >= 0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				list.Add(m_subPartTypes[num]);
			}
			else
			{
				list.Add(new SubPartsInRarity(true, weaponSubPart));
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			m_subPartTypes = list;
			return;
		}
	}
}
