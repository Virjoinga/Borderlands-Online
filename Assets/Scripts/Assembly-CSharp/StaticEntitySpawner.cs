using A;
using UnityEngine;

public class StaticEntitySpawner : MonoBehaviour, IEntityManagerListener, InstantiateManager.InstanciationClient
{
	private bool m_binded;

	public bool m_bDestoryableObj;

	private void Start()
	{
		c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
		if (m_bDestoryableObj)
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
			Transform transform = base.transform;
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				MeshRenderer componentInChildren = GetComponentInChildren<MeshRenderer>();
				if ((bool)componentInChildren)
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
					componentInChildren.enabled = false;
				}
				MeshCollider componentInChildren2 = GetComponentInChildren<MeshCollider>();
				if (!componentInChildren2)
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
					componentInChildren2.enabled = false;
					return;
				}
			}
		}
	}

	private void OnDestroy()
	{
		if (!(c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(this);
			return;
		}
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	public void OnEntitySpawn(Entity entity)
	{
		if (m_binded)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(Vector3.Distance(entity.transform.position, base.gameObject.transform.position) < 0.1f))
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
				if (!m_bDestoryableObj)
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
					Transform transform = base.transform;
					int childCount = transform.childCount;
					for (int i = 0; i < childCount; i++)
					{
						GameObject gameObject = transform.GetChild(i).gameObject;
						if (gameObject.tag == "TemplatePathFinding")
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
							Object.Destroy(gameObject);
						}
						else
						{
							gameObject.SetActive(true);
						}
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					MeshRenderer componentInChildren = GetComponentInChildren<MeshRenderer>();
					if ((bool)componentInChildren)
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
						componentInChildren.enabled = true;
					}
					MeshCollider componentInChildren2 = GetComponentInChildren<MeshCollider>();
					if ((bool)componentInChildren2)
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
						componentInChildren2.enabled = true;
					}
				}
				base.gameObject.transform.parent = entity.transform;
				m_binded = true;
				return;
			}
		}
	}
}
