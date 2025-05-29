using System;
using System.Collections.Generic;
using A;
using BHV;
using Core;
using Photon;
using UnityEngine;
using XsdSettings;

[RequireComponent(typeof(BadAssNetworkView))]
public class Entity : Photon.MonoBehaviour
{
	public enum EntityType
	{
		None = 0,
		Player = 1,
		Npc = 2,
		Object = 3,
		Projectile = 4,
		Others = 5
	}

	public List<PhotonView> m_networkViews = new List<PhotonView>();

	public List<Grid> m_grids = new List<Grid>();

	public float m_entityHeight = 1.8f;

	public string m_name = "Invalid_Entity_Name";

	public TextAsset m_xmlConfig;

	public TextAsset m_postInitXmlConfig;

	protected EntityManager m_entityMng;

	public EntityAbility m_ability;

	public EntityPlayer m_relatedPlayer;

	public Skeleton m_skeleton;

	public Entity m_killer;

	[HideInInspector]
	public bool m_bCanReceiveShootDamage = true;

	[HideInInspector]
	public bool m_bCanReceiveMeleeDamage = true;

	[HideInInspector]
	public bool m_bCanReceiveAreaDamage = true;

	protected Vector3 m_snapOnGroundPosition = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

	public virtual int cc7403315505256d19a7b92aa614a8f10()
	{
		return base.photonView.ce57f12a4f7e693a5fe0c4049dc56fa7c;
	}

	public void caec8e67d1485c25903bc0ecc1eec6e3d(Vector3 c330987c4414f384d6c951ab9f68460d8)
	{
		m_snapOnGroundPosition = c330987c4414f384d6c951ab9f68460d8;
	}

	public virtual AttackInfo.ElementalType c338e1019b68c1ba415414bd8d6cd4cae()
	{
		return AttackInfo.ElementalType.None;
	}

	public virtual float c3ec9446bbe93280e8fe22462a5e22880(AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d)
	{
		return 0f;
	}

	public virtual int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		return 0;
	}

	public virtual string ca6bcee369aa6d4cdf126ebaeef6f6c73()
	{
		return LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_name));
	}

	public virtual float c51d604728b9ec2e83a3f2783582757e9()
	{
		return 1f;
	}

	public virtual List<PassiveSkillType> c11d8925a1c6e53e1ad9411746fd14f72()
	{
		return null;
	}

	public virtual object[] c9fc033d895059e2080450369e258d5f0()
	{
		return base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45;
	}

	public virtual EntityType c6420f67f9249b1d533531d9f351a36e0()
	{
		throw new NotImplementedException();
	}

	public virtual int ceb10167333758220ffb9bc66317ad763()
	{
		throw new NotImplementedException();
	}

	public virtual AIInventory cdcf5e0592c05a681a8470f66674efd0b()
	{
		throw new NotImplementedException();
	}

	public virtual NavMeshAgent cb7fad43afb51f83d8698379136b46e95()
	{
		return null;
	}

	public virtual AnimationManager cb8119a2676bfbd4df00a9ed683eed91a()
	{
		return null;
	}

	public virtual ENPCParticleType cfa1f39f0f16c281e2062553416590dbb(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		return c6e9c05551eaa310c6fcb665b20682b9c;
	}

	public virtual BHVTaskManager c9b6d1d87bef7b03dad787ff0031551ee()
	{
		return GetComponent<BHVTaskManager>();
	}

	public virtual VFXManager ccdbbc6879c7efc53e81b9c2fbaceead9()
	{
		return GetComponentInChildren<VFXManager>();
	}

	public virtual EntityWeapon c3941dac8608f650ceb15dc36294a741c()
	{
		throw new NotImplementedException();
	}

	public virtual Skeleton ccd8e6ea278245d0f158036267242e60f()
	{
		return m_skeleton;
	}

	public virtual EntityShield c136b0f223897fdf01d18a9a5e3745433()
	{
		return null;
	}

	public virtual EquipmentInventoryEntity c5ca38fad98337fc5c7255384b2cd1a86()
	{
		return null;
	}

	public virtual bool c64c62b7b247792a393fc6789fd736232()
	{
		return false;
	}

	public virtual CollisionManager c63f8f07320313ddc4213cb59ee025962()
	{
		return null;
	}

	public virtual BHVBrain c27d3e998b3d9d3614473d27bb0d3f9d2()
	{
		return GetComponent<BHVBrain>();
	}

	public virtual Vector3 c8cc25ca9fd18f583f33395178ef47f1d()
	{
		return c4cf00ced2bc60ae908904eb73692869f() + Vector3.up * m_entityHeight * 0.5f;
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return base.gameObject.transform.position;
	}

	public Transform c06a97336d66561bdcc24dede6e251a09()
	{
		return base.gameObject.transform;
	}

	public virtual void cccac5da4d41afa803b9bd5624fd7e697()
	{
	}

	protected virtual void Awake()
	{
		m_entityMng = c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86;
		m_entityMng.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
		base.gameObject.transform.parent = m_entityMng.m_entityDirectory.transform;
		if (m_xmlConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
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
			PrefabManager.c467e74afab95ccaf4c794df74516df56(base.gameObject, m_xmlConfig);
		}
		m_ability = base.gameObject.AddComponent<EntityAbility>();
		BadAssNetworkView[] components = GetComponents<BadAssNetworkView>();
		for (int i = 0; i < components.Length; i++)
		{
			if (!components[i].c201e69461401637f68794a86ca99b782())
			{
				continue;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			m_networkViews.Add(components[i]);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	protected virtual void OnDestroy()
	{
		if ((bool)m_ability)
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
			m_ability.cac7688b05e921e2be3f92479ba44b4a8();
		}
		if (!m_entityMng)
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
			m_entityMng.cf5212e6903ec0c0b27816142c32a2d13(this);
			return;
		}
	}

	public virtual PlayerInfoSync cd95354b53e674ec7dc9594e66e4d316f()
	{
		return null;
	}

	public virtual bool caac907d451029d68503484a63934c93f()
	{
		return false;
	}

	public bool cc9092b59c901ab832a40b51c2cfa71b7()
	{
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return true;
				}
			}
		}
		if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}

	protected void cdea459d34b5e2c81e7b54f656d605342()
	{
		if (m_postInitXmlConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			PrefabManager.c467e74afab95ccaf4c794df74516df56(base.gameObject, m_postInitXmlConfig);
		}
		if (m_xmlConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PrefabManager.c3911f9551fc7e67d65f7b9825f756fd9(base.gameObject);
		}
		m_skeleton = GetComponentInChildren<Skeleton>();
	}

	public virtual void Start()
	{
		cdea459d34b5e2c81e7b54f656d605342();
	}

	public virtual void Update()
	{
	}

	public virtual Vector3 c56fad5727ffebf48f3df62074cd1bbe6()
	{
		return base.transform.forward;
	}

	public virtual Vector3 cad7880776eb7b2ddfb106102d4c51bbf()
	{
		return base.transform.position;
	}

	public virtual float c9e78731a722173182d97fcb193f372d4(AttackInfo.AttackType c9853bc8fde5be0efddd14f9f85b4181d)
	{
		return 1f;
	}

	public virtual float cbc82bd86727dfe88813561a2b0a3ffa9(AttackInfo.AttackType c9853bc8fde5be0efddd14f9f85b4181d)
	{
		return 1f;
	}

	public virtual float cb3223f9a305a17e1eab189d88cb7010d()
	{
		return 1f;
	}

	public virtual float c6fe8d13591d462327306a32e7824f43e()
	{
		return 1f;
	}

	public virtual float ce78805f904c50c7f149c6307c9b9fd5b(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		return 1f;
	}

	public virtual float cee5214b76cdbc7e2e4c21a77b1a28161()
	{
		return 1f;
	}

	public virtual float c1212fda798b1e74e4258b247bc16f722()
	{
		return 1f;
	}

	public virtual float c3e09247dd3e9371b0945bda51e18553f(AttackInfo.AttackType c9853bc8fde5be0efddd14f9f85b4181d, bool c630d50d5dec38605bd844e4adb5c00ba, Entity c42167b7db020f2e5cd252c40ece23f3b)
	{
		return 1f;
	}

	public virtual void cf0a63fdc9831dd55ae40ac6a5f5eb7e0(int c19e024b5bcbd347892bec27154c527de)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		if (!(equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			equipmentInventoryEntity.cf0a63fdc9831dd55ae40ac6a5f5eb7e0(c19e024b5bcbd347892bec27154c527de);
			return;
		}
	}

	public virtual void c9af7b3e5f6626ceef1a0036138121839(int c19e024b5bcbd347892bec27154c527de)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		if (!(equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			equipmentInventoryEntity.c9af7b3e5f6626ceef1a0036138121839(c19e024b5bcbd347892bec27154c527de);
			return;
		}
	}

	public virtual void c34fa9ca078c2cc90fb0cae8284ed10d7(int c19e024b5bcbd347892bec27154c527de)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		if (!(equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			equipmentInventoryEntity.c34fa9ca078c2cc90fb0cae8284ed10d7(c19e024b5bcbd347892bec27154c527de);
			return;
		}
	}

	public virtual int ca2ff7a501878363cb1d5f0472e306620()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		int result;
		if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620();
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public virtual int ccfad1bf47b003333c5ddd084f14d33e7()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		int result;
		if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			result = equipmentInventoryEntity.ccfad1bf47b003333c5ddd084f14d33e7();
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public virtual void c98ef918d9887e870c11adec28ce761bb(int c4481b75aaaa86787270602aae36a94d4)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		if (equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
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
		equipmentInventoryEntity.c405b3c9891c62259c5917e975ecd6145(c4481b75aaaa86787270602aae36a94d4);
	}

	public virtual void c1fb54a5108ae0e4b4c5b6344e051ea15(int c4481b75aaaa86787270602aae36a94d4)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		if (equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
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
		equipmentInventoryEntity.c405b3c9891c62259c5917e975ecd6145(c4481b75aaaa86787270602aae36a94d4);
	}

	public virtual int ce7804365a7377021025c46a16aa79db4()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		int result;
		if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = equipmentInventoryEntity.ce7804365a7377021025c46a16aa79db4();
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public virtual int ca937003ba4cbf4130cad1fcc9da2873e()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = c5ca38fad98337fc5c7255384b2cd1a86();
		int result;
		if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = equipmentInventoryEntity.ca937003ba4cbf4130cad1fcc9da2873e();
		}
		else
		{
			result = 0;
		}
		return result;
	}

	[AudioParameterFunction]
	public string GetAudioMaterialBelow()
	{
		string result = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		RaycastHit hitInfo;
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 0.7f, 0.4f), Vector3.down, out hitInfo))
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
			string text = hitInfo.transform.tag;
			if (AudioSwitchValues.ccda565901954c74049a57d592e42373c(text))
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
				result = text;
			}
		}
		return result;
	}

	public virtual int cfa29f666f7b32a7317160b9de6838449()
	{
		throw new NotImplementedException();
	}

	public virtual bool cad418535912a1c3cb6ea0ce1e4cbd114()
	{
		return false;
	}

	public virtual void c3bf54d312726877e5f77b6d475aef510()
	{
		base.transform.position = c4c38fdc58f120e1209ca439fa8ee5818();
	}

	public virtual Vector3 c4c38fdc58f120e1209ca439fa8ee5818()
	{
		if (Mathf.Approximately(base.transform.position.x, m_snapOnGroundPosition.x))
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
			if (Mathf.Approximately(base.transform.position.z, m_snapOnGroundPosition.z))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return m_snapOnGroundPosition;
					}
				}
			}
		}
		float entityHeight = m_entityHeight;
		Vector3 vector = base.transform.position + Vector3.up * entityHeight;
		RaycastHit hitInfo;
		if (Physics.Raycast(vector, Vector3.down, out hitInfo, 10f, TargetingService.c766b2ad3bfeb136864b1696e7dda3d4c))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					vector.y = hitInfo.point.y;
					m_snapOnGroundPosition = vector;
					return vector;
				}
			}
		}
		return base.transform.position;
	}

	public void c90772582c2a384501f1dec50d90e2afe(int c71343215f125dcae7cc50af15a301fcd)
	{
		Vector3 position = base.transform.position;
		Vector3 origin = base.transform.position + Vector3.up * m_entityHeight * 0.5f;
		RaycastHit[] array = Physics.SphereCastAll(origin, 0.1f, Vector3.down, 10f, c71343215f125dcae7cc50af15a301fcd);
		float num = float.MaxValue;
		float y = float.MaxValue;
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].distance < num))
			{
				continue;
			}
			while (true)
			{
				switch (7)
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
			y = array[i].point.y;
			num = array[i].distance;
			flag = true;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (flag)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				position.y = y;
			}
			base.transform.position = position;
			return;
		}
	}

	public Bounds cfd528711df451502ef1ce8ea692f8afc()
	{
		if (c63f8f07320313ddc4213cb59ee025962() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return c63f8f07320313ddc4213cb59ee025962().c1d6860eee695e1e68dc547c4685b588e();
				}
			}
		}
		return new Bounds(Vector3.zero, Vector3.zero);
	}

	protected virtual void OnDrawGizmos()
	{
	}

	public virtual bool c147acea867a351adb3024b05cfd5b676()
	{
		return false;
	}

	public virtual void c8adb21292420ed2d7200db3d23532054(bool c1a11d8e9e2f1e1078bc1ec4cc3e55259)
	{
	}

	public virtual bool ce003fe849cc45b85ca4570109817c796()
	{
		return false;
	}

	public virtual float c150748569f6883ea4267194e6e3271e7(EntityWeapon c63e77db49ee63186e474d32152b9912c, int cfba4197b705c13c9466d9b0559d75d4b)
	{
		float result = 0f;
		if (c63e77db49ee63186e474d32152b9912c != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
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
			result = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(c63e77db49ee63186e474d32152b9912c.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponElementalDamage) as FloatAttributeValue);
		}
		return result;
	}

	public int c659e11237d268aac8b68c419cf6b053a()
	{
		WeakPoint c38b98045365f4b50a4fbe3f1d89af = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
		return c659e11237d268aac8b68c419cf6b053a(out c38b98045365f4b50a4fbe3f1d89af);
	}

	public int c659e11237d268aac8b68c419cf6b053a(out WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		WeakPoint[] array = c63f8f07320313ddc4213cb59ee025962().cf0d37a28cb0655ede4d95f3b263f7558();
		WeakPoint c7088de59e49f7108f520cf7e0bae167e = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
		for (int i = 0; i < array.Length; i++)
		{
			c7088de59e49f7108f520cf7e0bae167e = array[i];
			if (!c7088de59e49f7108f520cf7e0bae167e.m_isDefaultWeakPoint)
			{
				continue;
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
				c38b98045365f4b50a4fbe3f1d89af089 = c7088de59e49f7108f520cf7e0bae167e;
				return i;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "No Default WeakPoint was found on Entity: " + base.gameObject.name + ". Weakpoint [0] will be used!!");
			c38b98045365f4b50a4fbe3f1d89af089 = array[0];
			return 0;
		}
	}

	public virtual void ce7325a1f0410a6d170ae58fce0f0ae7f(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
	}

	public virtual string caee41037b4b1f78e0109e763f22a7a0c()
	{
		return null;
	}

	public virtual void cbb91e2330ed12a1942ead68e69e691a3(float c7877e67acd1ae62d246b5fb5e889a066)
	{
	}

	public virtual void c49c490bcb316f43984756f2360518e6c(bool c8678fc7ce74e7101a14c28cf81451c7e)
	{
	}

	public virtual bool c34e2df09efc33ff67ad7080de3d7f694()
	{
		return true;
	}

	public virtual void ce3d2463f4bde14fb9d124a4dce341d89(float ca4323e9c37df6a1f0dfaad4990247fd5)
	{
	}
}
