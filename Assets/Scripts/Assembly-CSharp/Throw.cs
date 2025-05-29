using A;
using UnityEngine;

public class Throw : Action, InstantiateManager.InstanciationClient
{
	private int m_strength;

	protected override void c413183a79233cd0411af23b0f0c942f4()
	{
		if (!(m_entity is EntityPlayer))
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
			EntityPlayer entityPlayer = m_entity as EntityPlayer;
			if (!entityPlayer)
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
				entityPlayer.c8e7de6296a25baa9101b2c51d861bbd4(base.m_actionDelay);
				return;
			}
		}
	}

	public void cba75526d58d328a7e2a0f72ff6bb6d36()
	{
	}

	protected override void c5c08725571cbae704deb427cb93c8e9b()
	{
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		EntityObject component = instance.GetComponent<EntityObject>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			component.c71e2faacad39f5de99408bee4edd5367(m_entity);
		}
		instance.rigidbody.AddForce(m_entity.c56fad5727ffebf48f3df62074cd1bbe6() * m_strength);
	}
}
