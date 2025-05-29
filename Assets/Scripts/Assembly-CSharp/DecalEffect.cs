using A;
using UnityEngine;

[AddComponentMenu("Effects/TKC/Decal Effect")]
public class DecalEffect : EffectBase
{
	public Material m_material;

	public Vector3 m_decalSize = new Vector3(1f, 1f, 1f);

	public Texture2D[] m_texture;

	public int m_poolSize = 1;

	public void Awake()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
		{
			while (true)
			{
				switch (3)
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
		m_pool = new EffectPool(m_poolSize);
	}

	public override void PlayEffect(EffectTrigger trigger)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		if (trigger.m_location != EffectLocationType.Raycast)
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
			c187fd54873b5d132de736f4e9c0c8c09(trigger.m_raycastHit.collider.gameObject, trigger.m_raycastHit.point, -trigger.m_raycastHit.normal);
			return;
		}
	}

	public void c187fd54873b5d132de736f4e9c0c8c09(GameObject ce7df41518c0940974d277780511764ec, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Vector3 ce0b1068786abedfc61051e3371371ea6)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
		GameObject gameObject = new GameObject(m_myName);
		gameObject.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
		gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, ce0b1068786abedfc61051e3371371ea6);
		gameObject.transform.localScale = m_decalSize;
		cc49e644e4794a97f26962520c4027935(gameObject, ce7df41518c0940974d277780511764ec);
	}

	public void cc49e644e4794a97f26962520c4027935(GameObject c408cdede67f4d498c4c3508017efbbc1, GameObject ce7df41518c0940974d277780511764ec)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
		{
			while (true)
			{
				switch (5)
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
		EffectPoolController effectPoolController = c408cdede67f4d498c4c3508017efbbc1.AddComponent<EffectPoolController>();
		effectPoolController.c57e4d4cd41f3be21d7e24a71aa08c6ba(m_pool);
		Decal.dCount++;
		Decal decal = c408cdede67f4d498c4c3508017efbbc1.AddComponent<Decal>();
		decal.affectedObject = ce7df41518c0940974d277780511764ec;
		decal.decalMode = DecalMode.MESH_FILTER;
		decal.pushDistance = 0.02f;
		Material material = m_material;
		if (m_texture != null)
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
			if (m_texture.Length > 0)
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
				int num = Random.Range(0, m_texture.Length);
				material.mainTexture = m_texture[num];
			}
		}
		decal.decalMaterial = material;
		decal.ce281869c43f18fb7a3f5381b24b58075();
		decal.transform.parent = ce7df41518c0940974d277780511764ec.transform;
	}
}
