using A;
using Core;
using UnityEngine;

public class DeathCamManager : c1ee7921b0c3cce194fb7cae41b5a9d82<DeathCamManager>
{
	private Camera m_deathCam;

	private bool cd6872b2693f28d959cadada925a078d0(Vector3 c330987c4414f384d6c951ab9f68460d8, Entity c22049b7d048f5ceaad7bdef828bdb85c, Entity cf7ee7f254a35f9c53a393957e2758a0a)
	{
		bool flag = false;
		RaycastHit hitInfo;
		if (!Physics.Raycast(c22049b7d048f5ceaad7bdef828bdb85c.c8cc25ca9fd18f583f33395178ef47f1d(), c330987c4414f384d6c951ab9f68460d8 - c22049b7d048f5ceaad7bdef828bdb85c.c8cc25ca9fd18f583f33395178ef47f1d(), out hitInfo, Vector3.Distance(c330987c4414f384d6c951ab9f68460d8, c22049b7d048f5ceaad7bdef828bdb85c.c8cc25ca9fd18f583f33395178ef47f1d()), TargetingService.c766b2ad3bfeb136864b1696e7dda3d4c))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			flag = true;
		}
		if (flag)
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
			if (!Physics.Raycast(cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d(), c330987c4414f384d6c951ab9f68460d8 - cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d(), out hitInfo, Vector3.Distance(c330987c4414f384d6c951ab9f68460d8, cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d()), TargetingService.c766b2ad3bfeb136864b1696e7dda3d4c))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				flag = true;
			}
		}
		return flag;
	}

	public void cc3249dca17182b3b5eacef5b5ac6620f(Entity c22049b7d048f5ceaad7bdef828bdb85c, EntityPlayer cf7ee7f254a35f9c53a393957e2758a0a)
	{
		if (m_deathCam != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (cf7ee7f254a35f9c53a393957e2758a0a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		bool flag = false;
		if ((bool)c22049b7d048f5ceaad7bdef828bdb85c)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					cf7ee7f254a35f9c53a393957e2758a0a.cc6a7269e9ea93e537de47dc752b09a86().camera.enabled = false;
					cf7ee7f254a35f9c53a393957e2758a0a.c6a81925b944ea7d0f6008bd83da0380d(false);
					cf7ee7f254a35f9c53a393957e2758a0a.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(true);
					Vector3 position = cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d() + Vector3.up * 2f;
					Vector3 vector = cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d() - c22049b7d048f5ceaad7bdef828bdb85c.c8cc25ca9fd18f583f33395178ef47f1d();
					if (c22049b7d048f5ceaad7bdef828bdb85c != cf7ee7f254a35f9c53a393957e2758a0a)
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
						Vector3 vector2 = vector;
						vector2.Normalize();
						Vector3 vector3 = cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d() + Vector3.Normalize(vector2) * 2f;
						Vector3 vector4 = cf7ee7f254a35f9c53a393957e2758a0a.c8cc25ca9fd18f583f33395178ef47f1d();
						if (!flag)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
							Vector3 vector5 = Vector3.Cross(vector2, Vector3.up);
							vector4 = vector3 + vector5 * 2f;
							flag = cd6872b2693f28d959cadada925a078d0(vector4, c22049b7d048f5ceaad7bdef828bdb85c, cf7ee7f254a35f9c53a393957e2758a0a);
						}
						if (!flag)
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
							Vector3 vector6 = -Vector3.Cross(vector2, Vector3.up);
							vector4 = vector3 + vector6 * 2f;
							flag = cd6872b2693f28d959cadada925a078d0(vector4, c22049b7d048f5ceaad7bdef828bdb85c, cf7ee7f254a35f9c53a393957e2758a0a);
						}
						if (!flag)
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
							vector4 = vector3 + Vector3.up * 2f;
							flag = cd6872b2693f28d959cadada925a078d0(vector4, c22049b7d048f5ceaad7bdef828bdb85c, cf7ee7f254a35f9c53a393957e2758a0a);
						}
						if (!flag)
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
							vector4 = vector3 + Vector3.down * 2f;
							flag = cd6872b2693f28d959cadada925a078d0(vector4, c22049b7d048f5ceaad7bdef828bdb85c, cf7ee7f254a35f9c53a393957e2758a0a);
						}
						if (flag)
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
							position = vector4;
						}
					}
					GameObject gameObject = Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Player_Mecanim/DeathCam"), position, cf7ee7f254a35f9c53a393957e2758a0a.c06a97336d66561bdcc24dede6e251a09().rotation) as GameObject;
					m_deathCam = gameObject.camera;
					if (flag)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								m_deathCam.transform.LookAt(c22049b7d048f5ceaad7bdef828bdb85c.c8cc25ca9fd18f583f33395178ef47f1d() + vector / 2f);
								return;
							}
						}
					}
					m_deathCam.transform.LookAt(c22049b7d048f5ceaad7bdef828bdb85c.c8cc25ca9fd18f583f33395178ef47f1d());
					return;
				}
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "BHVTaskPlayerDead.SpawnDeathCam - killer is null");
	}

	public void c204f539b7fcf04cfc94507be74843444(EntityPlayer cf7ee7f254a35f9c53a393957e2758a0a)
	{
		if (m_deathCam == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
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
		if (cf7ee7f254a35f9c53a393957e2758a0a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		cf7ee7f254a35f9c53a393957e2758a0a.c6a81925b944ea7d0f6008bd83da0380d(true);
		cf7ee7f254a35f9c53a393957e2758a0a.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
		cf7ee7f254a35f9c53a393957e2758a0a.cc6a7269e9ea93e537de47dc752b09a86().camera.enabled = true;
		if (m_deathCam == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		Object.Destroy(m_deathCam.gameObject);
	}
}
