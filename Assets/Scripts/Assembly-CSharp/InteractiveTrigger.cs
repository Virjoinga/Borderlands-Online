using A;
using UnityEngine;

public class InteractiveTrigger : LevelTrigger, InteractionClient
{
	protected CollisionManager m_collisionManager;

	public string m_enableNavmeshLayerOnActivate;

	protected override void Awake()
	{
		base.Awake();
		if ((bool)InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
		}
		m_collisionManager = base.gameObject.AddComponent<CollisionManager>();
	}

	private void OnDestroy()
	{
		if (!InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(this);
			return;
		}
	}

	protected override void Start()
	{
		base.Start();
		m_collisionManager.cf19d18e7c73d5aff0a6786700d4e529d(GetComponent<Collider>());
	}

	public override void OnActivate()
	{
		base.OnActivate();
		if (string.IsNullOrEmpty(m_enableNavmeshLayerOnActivate))
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
			return;
		}
	}

	public bool c0c9ccf9f6d8cef1e33079d8eaf757b12(Ray cdb5cb253ef1339831696a37475f7233f, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		CollisionManager collisionManager = m_collisionManager;
		if (collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			RaycastHit c3ced719b4780c1919017d69e82521ab;
			if (collisionManager.cd7c958f1e0eea8f346b44512bf8f1ea4(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f0))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual bool cafe5e3051445e4e581a42f13d84472ee()
	{
		return false;
	}

	public bool cab69fd15e36704ccac7469787a1570a0(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (m_useOnce)
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
			if (m_used)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
		}
		return true;
	}

	public virtual void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
	{
		int c17fcd0ed1024ad7689991a96ed60deb;
		if (c285c6dfb3039cfe6087d40143faf7488() == LevelObjectSyncState.Activated)
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
			c17fcd0ed1024ad7689991a96ed60deb = 0;
		}
		else
		{
			c17fcd0ed1024ad7689991a96ed60deb = 1;
		}
		ccdbe4e8fac6da17241ea3a84ac4a449c((LevelObjectSyncState)c17fcd0ed1024ad7689991a96ed60deb);
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return base.transform.position;
	}

	public E_USE_TYPE c2aae0ed9fb0e39619e71e33a2e3fc48b()
	{
		return E_USE_TYPE.E_OPEN;
	}
}
