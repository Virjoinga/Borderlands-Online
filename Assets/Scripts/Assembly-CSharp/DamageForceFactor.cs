using XsdSettings;

public static class DamageForceFactor
{
	public const float m_explosionForce = 100f;

	public const float m_grenadeForce = 80f;

	public const float m_shotgunForce = 60f;

	public const float m_sniperForce = 40f;

	public const float m_rifleForce = 20f;

	public const float m_defaultForce = 1f;

	public static float c7018363381b768b9669018477728bc48(AttackInfo c095f59bf32567f9716f72d707585375b, float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		if (c095f59bf32567f9716f72d707585375b == null)
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
					return 1f;
				}
			}
		}
		if (c095f59bf32567f9716f72d707585375b.m_subType == AttackSubType.AreaExplosion)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return 100f;
				}
			}
		}
		if (c095f59bf32567f9716f72d707585375b.m_subType == AttackSubType.AreaGrenade)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return 80f;
				}
			}
		}
		if (c095f59bf32567f9716f72d707585375b.m_subType == AttackSubType.ProjectileShotgun)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (c85645ac328a4c6e6c17d3da3be1e11f0 < 15f)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return 60f;
					}
				}
			}
		}
		else if (c095f59bf32567f9716f72d707585375b.m_subType == AttackSubType.ProjectileSniper)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			if (c85645ac328a4c6e6c17d3da3be1e11f0 < 15f)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return 40f;
					}
				}
			}
		}
		return 1f;
	}
}
