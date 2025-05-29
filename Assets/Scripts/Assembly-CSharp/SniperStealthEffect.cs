using A;
using UnityEngine;

public class SniperStealthEffect : MonoBehaviour
{
	public Material[] m_sniperStealthMaterials;

	[HideInInspector]
	public Material[] m_sniperMaterials;

	public void cad9a3be7846b818e8bd3827fe93ef1bc(bool c38daa1ecfc4be57f0bab6f15b4488ecc, SkinnedMeshRenderer c91cbe02810173de3a981383253864426)
	{
		if (c91cbe02810173de3a981383253864426 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (m_sniperStealthMaterials != null)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								c91cbe02810173de3a981383253864426.materials = m_sniperStealthMaterials;
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (m_sniperMaterials == null)
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
			c91cbe02810173de3a981383253864426.materials = m_sniperMaterials;
			return;
		}
	}
}
