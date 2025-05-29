using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

[Serializable]
public class SubPartsInRarity
{
	[SerializeField]
	public WeaponSubPart m_weaponSubPart;

	[SerializeField]
	public List<SubpartChoice> m_subParts = new List<SubpartChoice>();

	public SubPartsInRarity()
	{
	}

	public SubPartsInRarity(SubPartsInRarity c5eb5bb2a5bc236b25b9814b957699568)
	{
		m_subParts.Clear();
		for (int i = 0; i < c5eb5bb2a5bc236b25b9814b957699568.m_subParts.Count; i++)
		{
			m_subParts.Add(c5eb5bb2a5bc236b25b9814b957699568.m_subParts[i]);
		}
		while (true)
		{
			switch (2)
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

	public SubPartsInRarity(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc, WeaponSubPart c62097b7b3122a87da1f985b35754535c)
	{
		m_weaponSubPart = c62097b7b3122a87da1f985b35754535c;
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
			m_subParts.Clear();
			return;
		}
	}
}
