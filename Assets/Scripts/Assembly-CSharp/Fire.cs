using A;

public class Fire : Action
{
	protected override void c413183a79233cd0411af23b0f0c942f4()
	{
		if (!(m_entity is EntityWeapon))
		{
			return;
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
			EntityWeapon entityWeapon = (EntityWeapon)m_entity;
			entityWeapon.cd65b54c26e0c82a0470c549d2b13f4aa(LastActionMessage);
			if (!(entityWeapon.m_owner is EntityPlayer))
			{
				return;
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

	protected override void cc69f8e9734cb68d6d47cf096f99df02b()
	{
		if (!(m_entity is EntityWeapon))
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
			EntityWeapon entityWeapon = (EntityWeapon)m_entity;
			entityWeapon.cb6eff0c11ae578b14e6b2e2feca5fd1a(LastActionMessage, base.m_actionDelay);
			if (!(entityWeapon.m_owner is EntityPlayer))
			{
				return;
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

	protected override void c5c08725571cbae704deb427cb93c8e9b()
	{
		EntityWeapon entityWeapon = m_entity as EntityWeapon;
		if (entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		entityWeapon.c63121b3f50cf93ab203732688f5e98d1(base.m_actionDelay);
	}
}
