using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

[Serializable]
public class WeaponRarityAttr
{
	[SerializeField]
	public WeaponType m_weaponType;

	[SerializeField]
	public List<WeaponRarityType> m_weaponRarityType = new List<WeaponRarityType>();

	public WeaponRarityAttr()
	{
	}

	public WeaponRarityAttr(WeaponRarityAttr c5eb5bb2a5bc236b25b9814b957699568)
	{
		m_weaponType = c5eb5bb2a5bc236b25b9814b957699568.m_weaponType;
		m_weaponRarityType.Clear();
		for (int i = 0; i < c5eb5bb2a5bc236b25b9814b957699568.m_weaponRarityType.Count; i++)
		{
			m_weaponRarityType.Add(new WeaponRarityType(c5eb5bb2a5bc236b25b9814b957699568.m_weaponRarityType[i]));
		}
		while (true)
		{
			switch (1)
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

	public WeaponRarityAttr(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc, WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
		m_weaponType = c2b4f43f34e21572af6ab4414f04cee36;
		if (!ccb88cc9ce41c4f9df0c68fa9f9360ffc)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_weaponRarityType.Clear();
			for (int i = 0; i < 6; i++)
			{
				m_weaponRarityType.Add(new WeaponRarityType(true, (WeaponRarity)i));
			}
			while (true)
			{
				switch (3)
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
		List<WeaponRarityType> list = new List<WeaponRarityType>();
		for (int i = 0; i < 6; i++)
		{
			WeaponRarity weaponRarity = (WeaponRarity)i;
			int num = m_weaponRarityType.FindIndex((WeaponRarityType c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.m_weaponRarity == weaponRarity);
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
				list.Add(m_weaponRarityType[num]);
			}
			else
			{
				list.Add(new WeaponRarityType(true, weaponRarity));
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			m_weaponRarityType = list;
			for (int j = 0; j < m_weaponRarityType.Count; j++)
			{
				m_weaponRarityType[j].c7a3a9c22cd95b108e71a40ce2ee85008();
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
	}
}
