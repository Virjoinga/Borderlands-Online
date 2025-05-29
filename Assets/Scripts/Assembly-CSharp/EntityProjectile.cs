using A;

public class EntityProjectile : Entity, IDestructibleObj
{
	private CollisionManager m_collisionManager;

	public override EntityType c6420f67f9249b1d533531d9f351a36e0()
	{
		return EntityType.Projectile;
	}

	public override bool c64c62b7b247792a393fc6789fd736232()
	{
		return true;
	}

	public override int ceb10167333758220ffb9bc66317ad763()
	{
		return 253;
	}

	public override CollisionManager c63f8f07320313ddc4213cb59ee025962()
	{
		return m_collisionManager;
	}

	public override void Start()
	{
		base.Start();
		if ((bool)DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
		{
			while (true)
			{
				switch (1)
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cf3d2cb82d21abb0d2de84f85c25fdb49(GetComponent<Entity>());
		}
		m_collisionManager = GetComponent<CollisionManager>();
		if (!(m_collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			m_collisionManager.cd93285db16841148ed53a5bbeb35cf20(false);
			return;
		}
	}

	public virtual bool c7617b17bcc7d64fcc6e7da325dfd8a2f(AttackInfo c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		return false;
	}

	public virtual void c918693d78025ee181080696108945498()
	{
		if (!DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
		{
			return;
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd5e20c96aa545559531f1792ec0f8b61(GetComponent<Entity>());
			return;
		}
	}

	public virtual void c24573231c964a8e1b6c359bcdc11ac2e(int c0e0b6548ee9ac8354c15e369d7f01c5f)
	{
	}
}
