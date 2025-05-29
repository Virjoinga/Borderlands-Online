using System.Collections.Generic;
using A;
using UnityEngine;

public class SupplySpawner : MonoBehaviour, ILootListener
{
	public float m_cooldownDelay = 15f;

	public Material m_openMaterial;

	public Material m_closeMaterial;

	private List<Entity> m_entitySpawned = new List<Entity>();

	private void Update()
	{
		if (Time.frameCount % 10 == 0)
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
			m_entitySpawned.Clear();
			List<Entity> c0c2a548e7e20a141e7763c365a4d;
			c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Object, out c0c2a548e7e20a141e7763c365a4d);
			for (int i = 0; i < c0c2a548e7e20a141e7763c365a4d.Count; i++)
			{
				float num = Vector3.Distance(c0c2a548e7e20a141e7763c365a4d[i].transform.position, base.transform.position);
				if (!(num < 0.2f))
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
				m_entitySpawned.Add(c0c2a548e7e20a141e7763c365a4d[i]);
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
		}
		MeshRenderer componentInChildren = GetComponentInChildren<MeshRenderer>();
		if (!componentInChildren)
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
			if (m_entitySpawned.Count > 0)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						componentInChildren.material = m_openMaterial;
						return;
					}
				}
			}
			componentInChildren.material = m_closeMaterial;
			return;
		}
	}

	public void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
		m_entitySpawned.Remove(item);
	}
}
