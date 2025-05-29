using UnityEngine;

public class EntityNpcSpiderantTalos : EntityNpc
{
	public Transform m_armorLeft;

	public Transform m_armorRight;

	public Transform m_armorBack;

	[HideInInspector]
	public bool m_bAllArmorDestoryed;

	public Transform m_iceEarthquakeShard;

	public Transform m_icePick;

	public override void Start()
	{
		base.Start();
		m_bAllArmorDestoryed = false;
	}

	public override void Update()
	{
		base.Update();
		if (m_bAllArmorDestoryed)
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
			return;
		}
	}

	public override ENPCParticleType cfa1f39f0f16c281e2062553416590dbb(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		if (c38b98045365f4b50a4fbe3f1d89af089.cf3d09e30f1d1bc489a1c3a97d696dbe2())
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return ENPCParticleType.E_DamageOnArmor;
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() != WeakPoint.StrengthType.Strong)
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
			if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() != WeakPoint.StrengthType.VeryStrong)
			{
				return c6e9c05551eaa310c6fcb665b20682b9c;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return ENPCParticleType.E_DamageOnArmor;
	}
}
