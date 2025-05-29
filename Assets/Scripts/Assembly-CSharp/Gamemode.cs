using System;
using System.Collections.Generic;
using System.Reflection;
using A;
using UnityEngine;

public class Gamemode : MonoBehaviour, InstantiateManager.InstanciationClient
{
	private string m_gamemodeName;

	private static List<Type> m_modeTypes = new List<Type>();

	public static Gamemode c50497ba3c78c744833a10292bd54eb31(string c6e4d3b7126d80cac5b6a261274de0ab0)
	{
		Gamemode c7088de59e49f7108f520cf7e0bae167e = c5e0b278c2b46ac4337be15131a11de51.c7088de59e49f7108f520cf7e0bae167e;
		return SessionInfo.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.AddComponent(c6e4d3b7126d80cac5b6a261274de0ab0) as Gamemode;
	}

	public static string[] cb80aa82f979988a3479991cd1c455c91()
	{
		m_modeTypes.Clear();
		Type[] types = Assembly.GetAssembly(Type.GetTypeFromHandle(ca066b7c50fab68bd8179699d9efb14d0.cc1720d05c75832f704b87474932341c3())).GetTypes();
		Type[] array = types;
		foreach (Type type in array)
		{
			if (!type.IsSubclassOf(Type.GetTypeFromHandle(ca066b7c50fab68bd8179699d9efb14d0.cc1720d05c75832f704b87474932341c3())))
			{
				continue;
			}
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
			m_modeTypes.Add(type);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			Type[] array2 = m_modeTypes.ToArray();
			string[] array3 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(array2.Length);
			for (int j = 0; j < array3.Length; j++)
			{
				array3[j] = array2[j].ToString();
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return array3;
			}
		}
	}

	public virtual bool c28b45877056e09d3c4d6fa790a1517aa()
	{
		return false;
	}

	public virtual bool c6c049b52b0154322f2bf768d2f85b9f3()
	{
		return false;
	}

	public virtual bool ce69137ed12ec78fa8fb598a02878cea1()
	{
		return false;
	}

	public virtual bool c3ddc3cfd52ca04af057ad84e50440970()
	{
		return false;
	}

	public virtual bool c405fdb1d2e2cac07a4ab80bc077a819f()
	{
		return false;
	}

	public string c1492faa4c1a9b76581845cee4d47d460()
	{
		return m_gamemodeName;
	}

	public virtual void Awake()
	{
	}

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_gamemodeName = GetType().ToString();
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		for (int i = 0; i < c9c8de68aa0982db2bbd496692c37e.Count; i++)
		{
			c9c8de68aa0982db2bbd496692c37e[i].m_teamID = c481002aa5818572745c4be69cc2222f6(c9c8de68aa0982db2bbd496692c37e[i]);
			c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdb7db6721dec105d58123fc2c43fa883(c9c8de68aa0982db2bbd496692c37e[i]);
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
			ccc9d3a38966dc10fedb531ea17d24611();
			return;
		}
	}

	public void c5c15220c3e633306fef152f245ce53fa()
	{
		c48e3f163c544e2d9f608a2a55fd1b83a();
	}

	protected virtual void ccc9d3a38966dc10fedb531ea17d24611()
	{
	}

	protected virtual void c48e3f163c544e2d9f608a2a55fd1b83a()
	{
	}

	public virtual void c881f5c9f672eba2e02441e1387a821ba()
	{
	}

	public virtual void ca9b3a2d1fbbeafb416b7e606f618cdf5()
	{
		c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c16724d551ad0986ab23e0697bcedb358(Entity.EntityType.Npc);
	}

	public virtual int c481002aa5818572745c4be69cc2222f6(PlayerInfoSync cb0f1fb849add37bc33dde348d4d2f716)
	{
		return 0;
	}

	public void cbf88786968d4e3f9e913b96b364959ac(PlayerInfoSync c25f5f36a54095a8f73d85c7f7b5af196)
	{
	}

	public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		Entity component = instance.GetComponent<Entity>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (component.c6420f67f9249b1d533531d9f351a36e0() != Entity.EntityType.Player)
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
				instance.GetComponent<MovementSync>().c88b49dc0432dffa0f75de3d5ec1c1946(request.m_position + new Vector3(0f, 0.2f, 0f), request.m_rotation);
				return;
			}
		}
	}

	public virtual void OnSpawn(Entity playerEntity)
	{
	}
}
