using A;
using XsdSettings;

public class SoldierTurretAIInventory : AIInventory
{
	public override void Start()
	{
		c0ccc5f7b2ebc263f9c20e5854f1e8af0();
		base.Start();
	}

	public void c0ccc5f7b2ebc263f9c20e5854f1e8af0()
	{
		EntityNpc component = base.gameObject.GetComponent<EntityNpc>();
		if (!(component.m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			float num = component.m_relatedPlayer.c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ElementDamage);
			int[] weaponID = m_weaponID;
			int num2;
			if (num > 1f)
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
				num2 = 6;
			}
			else
			{
				num2 = 5;
			}
			weaponID[0] = num2;
			return;
		}
	}
}
