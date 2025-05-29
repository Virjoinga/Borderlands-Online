using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

[RequireComponent(typeof(EntityObject))]
public class Pickable : MonoBehaviour, InteractionClient
{
	public class LightPillarManager
	{
		protected const string LP_RES_PREFIX_NAME = "PTL_Light_Pillar_";

		protected const string Resource_AssetBundle_Name = "light_pillar.assetbundle";

		protected const string Client_Resource_AssetBundle_Name = "light_pillar_cl.assetbundle";

		private static LightPillarManager s_instance;

		protected Dictionary<string, Object> _mapResources;

		protected static Dictionary<ItemRarity, string> _mapItemColor;

		public static LightPillarManager ccf24681862bae286c19d5c9b16296be5
		{
			get
			{
				if (s_instance == null)
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
					s_instance = new LightPillarManager();
				}
				return s_instance;
			}
		}

		protected LightPillarManager()
		{
			_mapItemColor = new Dictionary<ItemRarity, string>();
			_mapItemColor.Add(ItemRarity.Common, "White");
			_mapItemColor.Add(ItemRarity.Uncommon, "Green");
			_mapItemColor.Add(ItemRarity.Rare, "Blue");
			_mapItemColor.Add(ItemRarity.VeryRare, "Purple");
			_mapItemColor.Add(ItemRarity.Epic, "Pink");
			_mapItemColor.Add(ItemRarity.MetaEpic, "Orange");
			_mapResources = new Dictionary<string, Object>();
		}

		public void c43fd40a8b21ccbced26910ee5cae6c87()
		{
			_mapResources.Clear();
		}

		public static string cfe28e3d50ddb29d6b1140e6eed1263bf(EntityObject c964c502d159dbf5de81022d9a17777c6)
		{
			string empty = string.Empty;
			switch (c964c502d159dbf5de81022d9a17777c6.c4622c7a1660020e5029da03e27491b37().m_type)
			{
			case ItemType.HealthPack:
				return "Red";
			case ItemType.Ammo:
			case ItemType.Material:
			case ItemType.AmmoPack:
				return "White";
			case ItemType.ClassMode:
				return _mapItemColor[(c964c502d159dbf5de81022d9a17777c6 as EntityClassMode).c729ce3b5f48e0eac3a7ead97b1d02f8d().m_rarity];
			case ItemType.Shield:
				return _mapItemColor[(c964c502d159dbf5de81022d9a17777c6 as EntityShield).c729ce3b5f48e0eac3a7ead97b1d02f8d().m_rarity];
			case ItemType.Weapon:
			{
				ItemRarity rarity = (ItemRarity)(c964c502d159dbf5de81022d9a17777c6 as EntityWeapon).c729ce3b5f48e0eac3a7ead97b1d02f8d().m_rarity;
				return _mapItemColor[rarity];
			}
			default:
				return "Yellow";
			}
		}

		public void cb78d29c2fb21572285a48670ca83732a(object cd22aa6735988e8e65acbd503f3870e3e = null)
		{
			_mapResources.Clear();
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				c763a00fcfa49caf0c5d1e758447b652d("light_pillar_cl.assetbundle");
			}
			c763a00fcfa49caf0c5d1e758447b652d("light_pillar.assetbundle");
		}

		private void c763a00fcfa49caf0c5d1e758447b652d(string ccc3a743cfeeaa8212871445f2d92eb9a)
		{
			BaseAssetBundle baseAssetBundle = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(ccc3a743cfeeaa8212871445f2d92eb9a);
			if (baseAssetBundle == null)
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
			Object[] array = baseAssetBundle.c6a2c96c95dbb6d94ab759d22726b0440();
			if (array == null)
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
			foreach (Object @object in array)
			{
				if (!(@object is GameObject))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				_mapResources.Add(@object.name, @object);
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

		protected Object ca66de0fe5dae478298c737d8fcbccdd5(string c5fe690777bf5dec9374fa61ab6703175)
		{
			if (!_mapResources.ContainsKey(c5fe690777bf5dec9374fa61ab6703175))
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Light pillor resource doesn't exist! Name: " + c5fe690777bf5dec9374fa61ab6703175);
						return null;
					}
				}
			}
			return _mapResources[c5fe690777bf5dec9374fa61ab6703175];
		}

		public void c715fb3e5eda3bf2a01175e980333331f(EntityObject c5d720f6d007abb0c4a21d6a654e405bb)
		{
			if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Transform transform = c5d720f6d007abb0c4a21d6a654e405bb.gameObject.transform.FindChild("LightPillor");
			if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			transform.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
			CollisionManager collisionManager = c5d720f6d007abb0c4a21d6a654e405bb.c63f8f07320313ddc4213cb59ee025962();
			if ((bool)collisionManager)
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
				collisionManager.c30658ab50c1dcbe63044c9cd8fe8cb2b(transform.GetComponent<Collider>());
			}
			Object.DestroyObject(transform.gameObject);
		}

		public void c4f821103c3b3b97f69365622b1e163fd(EntityObject c5d720f6d007abb0c4a21d6a654e405bb)
		{
			if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			Transform transform = c5d720f6d007abb0c4a21d6a654e405bb.gameObject.transform.FindChild("LightPillor");
			if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				gameObject = transform.gameObject;
			}
			else
			{
				string text = cfe28e3d50ddb29d6b1140e6eed1263bf(c5d720f6d007abb0c4a21d6a654e405bb);
				string text2 = "PTL_Light_Pillar_" + text;
				Object @object = ca66de0fe5dae478298c737d8fcbccdd5(text2);
				if ((bool)@object)
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
					gameObject = Object.Instantiate(@object) as GameObject;
				}
				else
				{
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "Could Not load Light Pillar: " + text2);
				}
			}
			if (!gameObject)
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
				gameObject.layer = LayerMask.NameToLayer("diegeticUI");
				gameObject.name = "LightPillor";
				gameObject.transform.parent = c5d720f6d007abb0c4a21d6a654e405bb.gameObject.transform;
				gameObject.transform.transform.localPosition = Vector3.zero;
				gameObject.transform.transform.localRotation = Quaternion.identity;
				gameObject.transform.transform.localScale = Vector3.one;
				gameObject.AddComponent<FixRotator>();
				CollisionManager collisionManager = c5d720f6d007abb0c4a21d6a654e405bb.c63f8f07320313ddc4213cb59ee025962();
				if (!collisionManager)
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
					collisionManager.cf19d18e7c73d5aff0a6786700d4e529d(gameObject.GetComponent<Collider>());
					return;
				}
			}
		}
	}

	public bool m_autoPickup;

	private bool m_isReady;

	private bool m_isPickable;

	private Vector3 m_velocity = Vector3.zero;

	private int m_attachId = -1;

	private int m_numWeaponSpawned;

	private int m_numItemSpawned;

	private ItemDNA m_dna;

	private float m_destructionTimer;

	private float m_lightPillarTimer;

	private float m_pickableTimer;

	public bool m_spinningToOwner { get; private set; }

	public EntityObject m_entity { get; private set; }

	private void Awake()
	{
		m_isReady = false;
		m_isPickable = false;
	}

	private void Start()
	{
		m_entity = GetComponent<EntityObject>();
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "m_entity should not be null in Pickable");
		}
		if ((bool)InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
		}
		m_entity.tag = "Item";
		object[] array = m_entity.c9fc033d895059e2080450369e258d5f0();
		if (array != null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					m_dna = array[0] as ItemDNA;
					m_velocity = (Vector3)array[1];
					m_attachId = (int)array[3];
					m_numWeaponSpawned = (int)array[4];
					m_numItemSpawned = (int)array[5];
					return;
				}
			}
		}
		EntityWeapon entityWeapon = m_entity as EntityWeapon;
		if (!entityWeapon)
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
			m_dna = ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d());
			return;
		}
	}

	private void Update()
	{
		if (!m_isReady)
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
			if (m_entity.c39df47367fa21412aabfef05d9972f8c())
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
				m_isReady = true;
				OnReady();
			}
		}
		else if (m_spinningToOwner)
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
			cf3c994915c0c9ca0a3a9ec58b7ab2452();
		}
		if (m_pickableTimer > 0f)
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
			m_pickableTimer -= Time.deltaTime;
			if (m_pickableTimer <= 0f)
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
				ca655cfdab2170cc13536eb8f17bc4ca4(true);
			}
		}
		if (!(m_lightPillarTimer > 0f))
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
			m_lightPillarTimer -= Time.deltaTime;
			if (!(m_lightPillarTimer <= 0f))
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
				c4f821103c3b3b97f69365622b1e163fd();
				return;
			}
		}
	}

	private void OnReady()
	{
		if (!(m_entity.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (m_attachId == -1)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_entity.cd9058248734c831f0b6bdfd9e340e588(m_entity.transform.position, m_entity.transform.rotation, m_velocity);
						return;
					}
				}
			}
			cb21d2cf69f9d5dc7fdbdfe1281893ddd();
			if (m_lightPillarTimer == 0f)
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
				c4f821103c3b3b97f69365622b1e163fd();
			}
			if (m_pickableTimer != 0f)
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
				ca655cfdab2170cc13536eb8f17bc4ca4(true);
				return;
			}
		}
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

	private void OnCollisionEnter(Collision collision)
	{
		if (m_isPickable)
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
			if (!(m_pickableTimer <= 0f))
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
				ca655cfdab2170cc13536eb8f17bc4ca4(true);
				return;
			}
		}
	}

	public void OnOwnerChanged()
	{
	}

	public ItemDNA c286cbdde6d61958bfcaff0cd6a8b2963()
	{
		return m_dna;
	}

	private void ca655cfdab2170cc13536eb8f17bc4ca4(bool c800ce33d0d3838aa7debc94b5128679f)
	{
		if (c800ce33d0d3838aa7debc94b5128679f == m_isPickable)
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
			m_isPickable = c800ce33d0d3838aa7debc94b5128679f;
			return;
		}
	}

	private void c4f821103c3b3b97f69365622b1e163fd()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
				LightPillarManager.ccf24681862bae286c19d5c9b16296be5.c4f821103c3b3b97f69365622b1e163fd(m_entity);
				return;
			}
		}
	}

	private void c94e4354405022af9d7cc69908e452f71()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
				LightPillarManager.ccf24681862bae286c19d5c9b16296be5.c715fb3e5eda3bf2a01175e980333331f(m_entity);
				return;
			}
		}
	}

	public void cb21d2cf69f9d5dc7fdbdfe1281893ddd()
	{
		LevelObjectSync levelObjectSync = LevelObjectSyncManager.c5ee19dc8d4cccf5ae2de225410458b86.c5126cda7cf5cdf4e8083679781e5b0ce(m_attachId);
		if (!(levelObjectSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			LootingTable component = levelObjectSync.GetComponent<LootingTable>();
			if (!component)
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
				GameObject gameObject = component.cf0a77cf8ccad134ddd84c16ff1bad050(c286cbdde6d61958bfcaff0cd6a8b2963().m_type, m_numWeaponSpawned, m_numItemSpawned);
				if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					base.transform.parent = gameObject.transform;
					base.transform.localPosition = Vector3.zero;
					base.transform.localRotation = Quaternion.identity;
					LootingSlot component2 = gameObject.GetComponent<LootingSlot>();
					m_lightPillarTimer = component2.m_lootLightPillarDelay;
					m_pickableTimer = component2.m_lootPickableDelay;
					return;
				}
			}
		}
	}

	public void OnDrop()
	{
		c4f821103c3b3b97f69365622b1e163fd();
	}

	public void OnPick()
	{
		c94e4354405022af9d7cc69908e452f71();
	}

	public bool c3fa5657ea791d3c8779428f0361d91e3()
	{
		int result;
		if (m_isPickable)
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
			if (m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_entity.c39df47367fa21412aabfef05d9972f8c())
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
					if (m_entity.gameObject.activeSelf)
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
						result = ((m_entity.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
						goto IL_0099;
					}
				}
			}
		}
		result = 0;
		goto IL_0099;
		IL_0099:
		return (byte)result != 0;
	}

	public Vector3 c4cf00ced2bc60ae908904eb73692869f()
	{
		return m_entity.gameObject.transform.position;
	}

	public bool c0c9ccf9f6d8cef1e33079d8eaf757b12(Ray cdb5cb253ef1339831696a37475f7233f, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		CollisionManager collisionManager = m_entity.c63f8f07320313ddc4213cb59ee025962();
		if (collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			RaycastHit c3ced719b4780c1919017d69e82521ab;
			if (collisionManager.cd7c958f1e0eea8f346b44512bf8f1ea4(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f0))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "No interaction possible with " + base.name + " as it has no CollisionManager component!");
		}
		return false;
	}

	public virtual bool cafe5e3051445e4e581a42f13d84472ee()
	{
		return true;
	}

	public virtual E_USE_TYPE c2aae0ed9fb0e39619e71e33a2e3fc48b()
	{
		if (m_autoPickup)
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
					return E_USE_TYPE.E_NONE;
				}
			}
		}
		return E_USE_TYPE.E_PICKUP;
	}

	public virtual bool cab69fd15e36704ccac7469787a1570a0(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		return c3fa5657ea791d3c8779428f0361d91e3();
	}

	public virtual void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
	{
	}

	public void c22785b57afeece46810fee1b68ee29a4(EntityPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		m_spinningToOwner = true;
		m_entity.c71e2faacad39f5de99408bee4edd5367(ceb41162a7cd2a1d5c4a03830e02b4198);
		m_entity.c7625f669cf7d310f5ae9a4aa2646e757(false);
		m_entity.transform.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
		c94e4354405022af9d7cc69908e452f71();
	}

	public void cf3c994915c0c9ca0a3a9ec58b7ab2452()
	{
		Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
		if ((m_entity.m_owner as EntityPlayer).c3941dac8608f650ceb15dc36294a741c() != m_entity)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_entity.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
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
					if (m_entity.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
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
					if (m_entity.m_owner.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
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
					ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
					c36964cf41281414170f34ee68bef6c = m_entity.m_owner.transform.position;
					c36964cf41281414170f34ee68bef6c.y += c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_lootSpinningHeightOffset;
					c36964cf41281414170f34ee68bef6c -= m_entity.transform.position;
					float num = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_lootSpinningMoveSpeed * Time.deltaTime;
					m_entity.transform.position += c36964cf41281414170f34ee68bef6c.normalized * num;
					m_entity.transform.Rotate(Vector3.up, c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_lootSpinningRotateSpeed * Time.deltaTime, Space.World);
					if (num >= c36964cf41281414170f34ee68bef6c.magnitude)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								OnSpinningToOwnerFinished();
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		m_spinningToOwner = false;
	}

	public void OnSpinningToOwnerFinished()
	{
		BaseEventTriggerCtl component = m_entity.m_owner.GetComponent<BaseEventTriggerCtl>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			switch (m_entity.m_subType)
			{
			case EntityObject.EntitySubType.AmmoPack:
				component.TriggerEventByName("Itm_Pickup_Ammo");
				break;
			case EntityObject.EntitySubType.MoneyPack:
				component.TriggerEventByName("Itm_Pickup_Cash");
				break;
			case EntityObject.EntitySubType.HealthPack:
				component.TriggerEventByName("Itm_Pickup_Hp");
				break;
			case EntityObject.EntitySubType.Material:
			{
				ItemDNA itemDNA2 = c286cbdde6d61958bfcaff0cd6a8b2963();
				component.TriggerEventByName("Itm_Pickup_" + itemDNA2.m_materialType.ToString().Substring(3));
				break;
			}
			case EntityObject.EntitySubType.Shield:
				component.TriggerEventByName("Itm_Pickup_Ammo");
				break;
			case EntityObject.EntitySubType.None:
			{
				ItemDNA itemDNA = c286cbdde6d61958bfcaff0cd6a8b2963();
				if (itemDNA != null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.System, "invalid Entity's \"Sub Type\": " + itemDNA.m_materialType);
				}
				else
				{
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.System, "invalid Entity's \"Sub Type\"");
				}
				break;
			}
			}
		}
		m_spinningToOwner = false;
	}
}
