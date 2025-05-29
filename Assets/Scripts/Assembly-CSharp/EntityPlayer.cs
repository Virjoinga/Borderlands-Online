using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using BHV;
using Core;
using UnityEngine;
using XsdSettings;

public class EntityPlayer : Entity, MeleeAttacker, IDamageListener, InstantiateManager.InstanciationClient
{
	public class TriggerAtFirstTime
	{
		private bool m_active = true;

		private bool m_lasttick_condition;

		public bool Update(bool _new)
		{
			if (m_active)
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
				if (!m_lasttick_condition)
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
					if (_new)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								m_active = false;
								return true;
							}
						}
					}
				}
			}
			m_lasttick_condition = _new;
			return false;
		}
	}

	public enum KillType
	{
		Suicide = 0,
		IKillEnemy = 1,
		EnemyKillMe = 2,
		Others = 3
	}

	[Serializable]
	public class CharacterSetting
	{
		public float m_standHeight;

		public float m_crouchHeight;

		public float m_titleOffsetX;

		public float m_titleOffsetY;

		public float m_titleOffsetZ;

		public float m_titleOffsetX_Town;

		public float m_titleOffsetY_Town;

		public float m_titleOffsetZ_Town;
	}

	protected Session m_session;

	protected int m_playerId;

	protected PlayerInfoSync m_playerInfo;

	protected EquipmentInventoryEntityPlayer m_equipment;

	protected CollisionManager m_collisionManager;

	protected BadAssFPSCamera m_badassFpsCamera;

	protected InstanceInput m_instanceInput;

	protected PlayerController m_playerController;

	protected PlayerBehavior m_playerBehavior;

	protected CharacterController m_characterController;

	protected bool m_bTitleAdded;

	protected Entity m_lastKiller;

	protected static int m_WeapnSlotNums = 4;

	private PlayerFirstPersonInventoryManager m_playerFirstPersonInventoryManager;

	private Dictionary<Entity, int> sightTestCache;

	protected bool m_isInBattle;

	public EntityWeapon m_equipedWeapon;

	public EntityWeapon m_backWeapon;

	public EntityWeapon m_thighWeapon;

	public TextAsset m_AssemblyConfig;

	public Material m_fpHandMaterial;

	public int m_awesomeLevel = 1;

	protected PlayerInfoSync.OnPlayerStateChanged_Handler m_handler_statechanged;

	protected VFXManager m_vfxMgr;

	protected PlayerSkillManage m_skillManager;

	private bool m_bAimFOVChanging;

	protected SkillTreeStatus m_skillTreeStatus;

	protected PlayerEffectManager m_effectMgr;

	private PlayerGuildEffectManage m_guildEffectMgr;

	protected TriggerAtFirstTime m_weaponReady = new TriggerAtFirstTime();

	protected TriggerAtFirstTime m_shieldReady = new TriggerAtFirstTime();

	private int m_count_dot;

	private Transform m_HandModel;

	public bool m_pending_melee;

	private GameObject m_titleObj;

	private Transform m_3rdPersonRenderTransform;

	public TextAsset m_config_character;

	[SerializeField]
	private CharacterSetting m_character_setting;

	private float m_victimDamageModifier_skill = 1f;

	private float m_elementalDamageModifier_skill = 1f;

	private float m_slowdown_marked_move = 0.5f;

	public VFXManager cb1bc1ed3579c8c5bda5a8a3dbd112ea9
	{
		get
		{
			return m_vfxMgr;
		}
	}

	public PlayerSkillManage ccaf53be8b86b7016efd6970ff8c92ad3
	{
		get
		{
			return m_skillManager;
		}
	}

	public SkillTreeStatus c02f3d4a4e7d1edee179f9bf7e16aeb82
	{
		get
		{
			return m_skillTreeStatus;
		}
	}

	public PlayerEffectManager c8461c34c06edbd90bf4b90de8c15863f
	{
		get
		{
			return m_effectMgr;
		}
	}

	public CharacterSetting cf1bd1736812e2b58e29ab4a7df48f8fc
	{
		get
		{
			return m_character_setting;
		}
	}

	protected override void Awake()
	{
		m_playerId = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[0];
		base.Awake();
		m_session = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86;
		sightTestCache = new Dictionary<Entity, int>();
	}

	protected override void OnDestroy()
	{
		if (m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<DeathCamManager>.c5ee19dc8d4cccf5ae2de225410458b86.c204f539b7fcf04cfc94507be74843444(this);
		}
		base.OnDestroy();
	}

	public override AnimationManager cb8119a2676bfbd4df00a9ed683eed91a()
	{
		if (base.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		return GetComponent<PlayerThirdPersonAnimationManagerFSM>();
	}

	public override void Start()
	{
		m_equipment = GetComponent<EquipmentInventoryEntityPlayer>();
		m_collisionManager = GetComponent<CollisionManager>();
		m_instanceInput = GetComponent<InstanceInput>();
		m_playerController = GetComponent<PlayerController>();
		m_playerBehavior = (PlayerBehavior)GetComponent(Type.GetTypeFromHandle(c0f5d17a33d8cd277a8ef3e79eecf4a03.cc1720d05c75832f704b87474932341c3()));
		m_vfxMgr = GetComponentInChildren<VFXManager>();
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			playerInfoSync.c7cd2e714b90259c7cbaa0bd226fe8435(this);
			if (playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a > PlayerInfoSync.PlayerState.None)
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
				ce8aaeb9ca9b756e07c42f70ffc88ec2a();
			}
			else
			{
				m_handler_statechanged = ce8aaeb9ca9b756e07c42f70ffc88ec2a;
				playerInfoSync.c556b16ab244cfd0d587e50a0ea733af2 += m_handler_statechanged;
			}
		}
		base.name = base.name + "(" + playerInfoSync.m_name + ")";
		m_name = playerInfoSync.m_name;
		DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c5c5b57d23b5b73637a6ed6524fed2be5(this);
		base.Start();
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new Throw());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new SwitchWeapon());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EquipWeapon());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new UnequipWeapon());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EquipShield());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EquipClassMode());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new DropItem());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new SwapItems());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new SwapWeapons());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new Melee());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EntityInteraction());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new LevelTriggerInteraction());
		m_relatedPlayer = this;
		m_isInBattle = false;
		m_skillManager = GetComponent<PlayerSkillManage>();
		m_skillManager.ccc9d3a38966dc10fedb531ea17d24611();
		m_skillTreeStatus = GetComponent<SkillTreeStatus>();
		m_skillTreeStatus.ccc9d3a38966dc10fedb531ea17d24611();
		m_effectMgr = new PlayerEffectManager(this);
		StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(m_playerInfo);
		if (statSheet != null)
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
			statSheet.Reset(m_name);
		}
		c63442ae8c521ed9ec39ab8fef9481e2b();
		cbd67dd78c28bf48a51f4a5e980200357();
	}

	public void cae97f9a3934a859d516ff4ad03981cbc()
	{
		MapObjectMark component = base.gameObject.GetComponent<MapObjectMark>();
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
			UnityEngine.Object.Destroy(component);
		}
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		PlayerInfoSync playerInfoSync2 = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(playerInfoSync2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
					if (playerInfoSync.m_teamID == playerInfoSync2.m_teamID)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
							{
								MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
								mapObjectMark.iCharacterID = playerInfoSync.m_characterId;
								mapObjectMark.bAlwaysOnMap = true;
								mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.TeamMate;
								mapObjectMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
								return;
							}
							}
						}
					}
					if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
						MapObjectMark mapObjectMark2 = base.gameObject.AddComponent<MapObjectMark>();
						mapObjectMark2.bAlwaysOnMap = true;
						mapObjectMark2.ObjType = UIMapDataManager.MiniMapObjectType.EnemyPlayer;
						mapObjectMark2.iCharacterID = playerInfoSync.m_characterId;
						mapObjectMark2.cd26ab2539c05dcb4fe11c30d0792cfaf();
						return;
					}
				}
			}
		}
	}

	protected void cbd67dd78c28bf48a51f4a5e980200357()
	{
		m_guildEffectMgr = new PlayerGuildEffectManage(this);
	}

	public override void Update()
	{
		base.Update();
		EntityShield entityShield = c136b0f223897fdf01d18a9a5e3745433();
		if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			entityShield.cc0fea17131d6be72a517285b19e19d22();
		}
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			c35291fe21279a580b6f01ff258c2734f();
		}
		ce5c45bcaaf22de571068ea2c2117a705();
		ca6f045d8bd27d34cbbd13683d64fadfe();
		if (m_weaponReady.Update(c3941dac8608f650ceb15dc36294a741c() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c1632dd8ecf9bf6333f194667a67f8b01();
		}
		if (!m_shieldReady.Update(c136b0f223897fdf01d18a9a5e3745433() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c1632dd8ecf9bf6333f194667a67f8b01();
			return;
		}
	}

	public float c82b441c4ab4c45d35a689807a8f0c6f8(EffectType c4f09c39924e70788c7b055c1d1490578, AffectType c2b72f83d79e58e8996514b22aa4e82e3)
	{
		float result = c02f3d4a4e7d1edee179f9bf7e16aeb82.c60c4bc9a822c2cf24a43a6bfce027b54(c2b72f83d79e58e8996514b22aa4e82e3);
		ItemDNA itemDNA = ce151fa795d7c589adcf6f778be230913();
		if (itemDNA != null)
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
			ClassModeDNA classModeDNA = itemDNA.c253c28f3a59bc5e5a528dfbb463a8a45();
			if (classModeDNA != null)
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
				result = classModeDNA.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(c4f09c39924e70788c7b055c1d1490578, c2b72f83d79e58e8996514b22aa4e82e3);
			}
		}
		return result;
	}

	public float c3a15a166aa68b5653f6e42643cca86b8(EffectType c4f09c39924e70788c7b055c1d1490578, AffectType c2b72f83d79e58e8996514b22aa4e82e3)
	{
		float num = c02f3d4a4e7d1edee179f9bf7e16aeb82.c60c4bc9a822c2cf24a43a6bfce027b54(c2b72f83d79e58e8996514b22aa4e82e3);
		ItemDNA itemDNA = c70fcd351cb41ea802b178c30efa25138();
		if (itemDNA != null)
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
			SkillAttributeConfig skillAttributeConfig = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.c82e31e42e80eaa911946671ffebf023e(itemDNA.ca79da172938fdc8c067fb64242b6174a(), c4f09c39924e70788c7b055c1d1490578);
			if (skillAttributeConfig != null)
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
				if (skillAttributeConfig.m_affectType == c2b72f83d79e58e8996514b22aa4e82e3)
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
					num = skillAttributeConfig.m_attrValue;
					if (c2b72f83d79e58e8996514b22aa4e82e3 == AffectType.Scale)
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
						num += 1f;
					}
				}
				else
				{
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("{0} operation error, correct: {1}, current: {2}", c4f09c39924e70788c7b055c1d1490578, c2b72f83d79e58e8996514b22aa4e82e3, skillAttributeConfig.m_affectType));
				}
			}
		}
		return num;
	}

	public float ce16b18b2cda29a0e71fd54cf507bd7f6(EffectType c4f09c39924e70788c7b055c1d1490578, AffectType c2b72f83d79e58e8996514b22aa4e82e3)
	{
		return m_guildEffectMgr.c6bbb90ce98ca4f07581063bdf0dadfb5(c4f09c39924e70788c7b055c1d1490578, c2b72f83d79e58e8996514b22aa4e82e3);
	}

	private Entity cf2420acfc416a55af01cfe3de5db7b1f()
	{
		Ray cdb5cb253ef1339831696a37475f7233f = new Ray(c8cc25ca9fd18f583f33395178ef47f1d(), c56fad5727ffebf48f3df62074cd1bbe6());
		Collider c5c049386ad279173b227358fda3eaaf = cba31495600bcc560b910fdfa4123ae28.c7088de59e49f7108f520cf7e0bae167e;
		float c85645ac328a4c6e6c17d3da3be1e11f = float.MaxValue;
		return TargetingService.cdb2b353157196638ba0e612861776113(cdb5cb253ef1339831696a37475f7233f, this, out c5c049386ad279173b227358fda3eaaf, ref c85645ac328a4c6e6c17d3da3be1e11f, ColliderType.WeakPoint, true);
	}

	private void c2ae81a98e2dfcda8a7e5686c2900b458()
	{
	}

	public void LateUpdate()
	{
		if (!(m_badassFpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_badassFpsCamera.c68ecea1276d3ae144d8c54668d6bfcd9(-1);
			return;
		}
	}

	public override void cccac5da4d41afa803b9bd5624fd7e697()
	{
		if (m_playerBehavior == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					base.cccac5da4d41afa803b9bd5624fd7e697();
					return;
				}
			}
		}
		m_playerBehavior.cccac5da4d41afa803b9bd5624fd7e697();
	}

	public int ca15c8f7004fafacb3955a523d9a1cec9()
	{
		if ((bool)m_playerInfo)
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
					return m_playerInfo.m_characterId;
				}
			}
		}
		return -1;
	}

	public override string ca6bcee369aa6d4cdf126ebaeef6f6c73()
	{
		return m_name;
	}

	public void cbe6462ca5e54bdba2f8ce0af7023cd3a()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
			if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (entity.ceb10167333758220ffb9bc66317ad763() == ceb10167333758220ffb9bc66317ad763())
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
				c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09().c56e7023c9b616eca4ee05b6fe564f13d(cfead42af4aa2d194749ea438d6310568(), new Vector3(0f, 0.3f, 0f), ca6bcee369aa6d4cdf126ebaeef6f6c73(), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DUMMY);
			}
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09().c56e7023c9b616eca4ee05b6fe564f13d(cfead42af4aa2d194749ea438d6310568(), new Vector3(0f, 0.3f, 0f), ca6bcee369aa6d4cdf126ebaeef6f6c73(), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE);
		}
		m_bTitleAdded = true;
	}

	protected void c35291fe21279a580b6f01ff258c2734f()
	{
		if (!(cfead42af4aa2d194749ea438d6310568() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
					if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity == this)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								if (m_bTitleAdded)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
										{
											NpcTitleMgr npcTitleMgr = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09();
											if (npcTitleMgr != null)
											{
												while (true)
												{
													switch (2)
													{
													case 0:
														break;
													default:
														npcTitleMgr.c998544bee641bc3a66b600fbd8bc9fe2(cfead42af4aa2d194749ea438d6310568());
														m_bTitleAdded = false;
														return;
													}
												}
											}
											return;
										}
										}
									}
								}
								return;
							}
						}
					}
				}
				if (m_bTitleAdded)
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
					cbe6462ca5e54bdba2f8ce0af7023cd3a();
					return;
				}
			}
		}
	}

	protected void ce8aaeb9ca9b756e07c42f70ffc88ec2a()
	{
		if (m_playerInfo.c2d17ea39faa888e633ce06615ddf5c6a <= PlayerInfoSync.PlayerState.None)
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
			GetComponent<PlayerAssembly>().c3cd93b8cbfde89ff0736ee1900e85d93(m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194(), m_playerInfo.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a());
			if (m_handler_statechanged == null)
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
				m_playerInfo.c556b16ab244cfd0d587e50a0ea733af2 -= m_handler_statechanged;
				return;
			}
		}
	}

	public IEnumerator c422d603e64552d7acc420ac5ab4616d4()
	{
		yield return StartCoroutine(c1dbda475e2f6005bc6e1968e8163d5b5());
	}

	protected virtual IEnumerator c3950e6e8b4cd51dc750217b1aa707759(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		EntityWeapon weapon2 = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		while (true)
		{
			weapon2 = m_equipment.c4e0dae6a16a8a80ddb5214a896b9df58(c19a39247ea86ffe5f0de9d429ca0ca95);
			yield return 0;
			if (!m_equipment.c84d244047fda2195337385d49dfc973c(c19a39247ea86ffe5f0de9d429ca0ca95))
			{
				break;
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
				if (weapon2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					break;
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
				goto end_IL_0030;
			}
			continue;
			end_IL_0030:
			break;
		}
		if (!(weapon2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			yield break;
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
		while (!weapon2.m_isReady)
		{
			yield return 0;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			c42841eb15edb296c94c38f237f57d3dd(weapon2);
			weapon2.c67c35955d666a0c6fe54cd6e348b1675();
			yield break;
		}
	}

	protected virtual IEnumerator c1dbda475e2f6005bc6e1968e8163d5b5()
	{
		for (byte i = 0; i < m_equipment.cebe82f93c2f4e4f15daeb43e5bf5521b; i++)
		{
			yield return StartCoroutine(c3950e6e8b4cd51dc750217b1aa707759(i));
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
			if ((bool)m_equipment.cdda217ef6662acf86a5584ba19758192())
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
				m_equipment.cdda217ef6662acf86a5584ba19758192().c1c5a947f5f8c009fe6fac45c9e29ad1d(this);
				m_equipedWeapon = m_equipment.cdda217ef6662acf86a5584ba19758192();
			}
			c6619cf9e11b07d0d83539685b47e823d();
			yield break;
		}
	}

	public EntityWeapon cbbb614d0d9109acaa212a9df5e71e116()
	{
		if (m_equipment != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			for (byte b = 0; b < m_equipment.cebe82f93c2f4e4f15daeb43e5bf5521b; b++)
			{
				EntityWeapon entityWeapon = m_equipment.c4e0dae6a16a8a80ddb5214a896b9df58(b);
				if (m_equipment.c91233b4b8268e8e24a4daa8c053e41ec() != b)
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
					if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d() != null)
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
							if (!entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().c02f707b729db89f6ea8df2f0b980cd1e())
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return entityWeapon;
									}
								}
							}
						}
					}
				}
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
		return null;
	}

	public EntityWeapon c184e9c28cddb14ec4108e680534cc445()
	{
		if (m_equipment != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			for (byte b = 0; b < m_equipment.cebe82f93c2f4e4f15daeb43e5bf5521b; b++)
			{
				EntityWeapon entityWeapon = m_equipment.c4e0dae6a16a8a80ddb5214a896b9df58(b);
				if (m_equipment.c91233b4b8268e8e24a4daa8c053e41ec() != b)
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
					if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d() != null)
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
							if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().c02f707b729db89f6ea8df2f0b980cd1e())
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										return entityWeapon;
									}
								}
							}
						}
					}
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
		}
		return null;
	}

	public EntityWeapon c1cd8bfe2bd594219e3cd115ca7594a51()
	{
		if (m_equipment != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_equipment.cdda217ef6662acf86a5584ba19758192();
				}
			}
		}
		return null;
	}

	public void c6619cf9e11b07d0d83539685b47e823d()
	{
		if (caac907d451029d68503484a63934c93f())
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
			m_backWeapon = cbbb614d0d9109acaa212a9df5e71e116();
			if (m_backWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_backWeapon.cd2662e9afb6b96dba3deeda201efd9a2(this);
			}
			m_thighWeapon = c184e9c28cddb14ec4108e680534cc445();
			if (!(m_thighWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_thighWeapon.cd2662e9afb6b96dba3deeda201efd9a2(this);
				return;
			}
		}
	}

	public void cf5bceac14e5e0bb1b47fcf5f7b12dd31(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		StartCoroutine(c3950e6e8b4cd51dc750217b1aa707759(c19a39247ea86ffe5f0de9d429ca0ca95));
	}

	protected virtual IEnumerator cb44f868f4b7a8ce03439794e80a8db52()
	{
		EntityShield shield2 = cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			shield2 = m_equipment.cb4633378bdf6d47c409332e395d58c7a();
			yield return 0;
		}
		while (shield2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			while (!shield2.c39df47367fa21412aabfef05d9972f8c())
			{
				yield return 0;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				shield2.c1c5a947f5f8c009fe6fac45c9e29ad1d(this);
				yield break;
			}
		}
	}

	private IEnumerator ce763bd1866687d6bcc8efb401b464efc(int cb35e80fa0e4fbac71712471aac425e89)
	{
		BadAssNetworkView networkView2 = c758bff8e6f547440d0cfe42214b0c3e3.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			networkView2 = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(cb35e80fa0e4fbac71712471aac425e89);
			yield return 0;
		}
		while (networkView2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			EntityWeapon wp = networkView2.GetComponent<EntityWeapon>();
			while (!wp.c39df47367fa21412aabfef05d9972f8c())
			{
				if (c3941dac8608f650ceb15dc36294a741c() != wp)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							yield break;
						}
					}
				}
				yield return 0;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			while (wp.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				if (c3941dac8608f650ceb15dc36294a741c() != wp)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							yield break;
						}
					}
				}
				yield return 0;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				cb8119a2676bfbd4df00a9ed683eed91a().OnSwitchWeapon(wp);
				yield break;
			}
		}
	}

	private IEnumerator cadaf43857cdf51d3f5af530e0cffab4c(int cb0a4de1e5856a3b4ef3295ed4e9cd6a1, int c99c69f35c4aaf1b17be8d69a28fb430f, bool ca3a08caad0b7acce4572b16956fc251f)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Start");
		EntityWeapon weaponToPick = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		EntityWeapon weaponToDrop = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		BadAssNetworkView networkView = c758bff8e6f547440d0cfe42214b0c3e3.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			networkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(cb0a4de1e5856a3b4ef3295ed4e9cd6a1);
			yield return 0;
		}
		while (networkView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			weaponToPick = networkView.GetComponent<EntityWeapon>();
			if (c99c69f35c4aaf1b17be8d69a28fb430f != 0)
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
				networkView = c758bff8e6f547440d0cfe42214b0c3e3.c7088de59e49f7108f520cf7e0bae167e;
				do
				{
					networkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(c99c69f35c4aaf1b17be8d69a28fb430f);
					yield return 0;
				}
				while (networkView == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				weaponToDrop = networkView.GetComponent<EntityWeapon>();
			}
			weaponToPick.cd93c0dd53b810158c02385f682094c2c();
			while (!weaponToPick.c39df47367fa21412aabfef05d9972f8c())
			{
				yield return 0;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Model instantiated");
				if (weaponToDrop != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					weaponToDrop.c494579b31bf3f1d0d5ce9a541799ca8c(this);
					if (ca3a08caad0b7acce4572b16956fc251f)
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
						string text = weaponToDrop.cc7403315505256d19a7b92aa614a8f10().ToString();
						object obj;
						if (weaponToDrop.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							obj = weaponToDrop.m_owner.cc7403315505256d19a7b92aa614a8f10().ToString();
						}
						else
						{
							obj = "None";
						}
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Drop weaponToReplace - " + text + " - Owner = " + (string)obj);
						weaponToDrop.cd9058248734c831f0b6bdfd9e340e588(weaponToDrop.gameObject.transform.position, weaponToDrop.gameObject.transform.rotation, base.transform.forward);
					}
				}
				c42841eb15edb296c94c38f237f57d3dd(weaponToPick);
				string text2 = weaponToPick.cc7403315505256d19a7b92aa614a8f10().ToString();
				object obj2;
				if (weaponToPick.m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					obj2 = weaponToPick.m_owner.cc7403315505256d19a7b92aa614a8f10().ToString();
				}
				else
				{
					obj2 = "None";
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Equip weaponToPickup - " + text2 + " - Owner = " + (string)obj2);
				BaseEventTriggerCtl trigger = GetComponent<BaseEventTriggerCtl>();
				if (trigger != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					trigger.TriggerEventByName("Itm_Pickup_Gun");
				}
				AnimationManager animMng = cb8119a2676bfbd4df00a9ed683eed91a();
				if (!animMng)
				{
					yield break;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					animMng.OnPickUpWeapon(weaponToPick);
					yield break;
				}
			}
		}
	}

	public void caf2f2c49a1b541303cab309672e28eee()
	{
		if (ccaf53be8b86b7016efd6970ff8c92ad3.cf5261b7a90515bca15928ed9a04778d0())
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
					GetComponent<PlayerThirdPersonAnimationManagerFSM>().OnMeleeSkill();
					return;
				}
			}
		}
		cb8119a2676bfbd4df00a9ed683eed91a().OnMelee();
		HunterManage hunterManage = ccaf53be8b86b7016efd6970ff8c92ad3 as HunterManage;
		if (!hunterManage)
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
			if (!hunterManage.c41b7b1203f98ea7135c9a65278b49c7f())
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
				hunterManage.cdf62d155034dbd0911fda9d270fcaa2b();
				return;
			}
		}
	}

	private void c468779e3eacd99a6f6da120ed159515a()
	{
		if (m_count_dot <= 0)
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
			m_count_dot--;
			return;
		}
	}

	public override bool c34e2df09efc33ff67ad7080de3d7f694()
	{
		return m_count_dot < DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c1f787f99a147b5c013b65bed97203d9d();
	}

	public void OnDamaged(DamageContext context)
	{
		bool isTriggeringDamageOverTime;
		bool flag;
		float num;
		if (context.m_victim == this)
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
			try
			{
				AnimationManager animationManager = cb8119a2676bfbd4df00a9ed683eed91a();
				if (animationManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						animationManager.OnDamaged(context.m_damageInfo);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array[0] = "EntityPlayer.OnDamage - Exception[";
				array[1] = ex;
				array[2] = "] on Entity[";
				array[3] = m_name;
				array[4] = "] RemoteDamage[";
				array[5] = context.m_isRemote;
				array[6] = "]";
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, string.Concat(array));
				return;
			}
			isTriggeringDamageOverTime = context.m_damageInfo.m_isTriggeringDamageOverTime;
			flag = cc39e32515a88188b6980005dff0dc081(context);
			num = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c99eed77fc7972e1cedd74ab862117b4e(context.m_damageInfo.m_elementalType, context.m_victim, context.m_killer);
			if (!isTriggeringDamageOverTime)
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
				if (!flag)
				{
					goto IL_0127;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			m_count_dot++;
			Invoke("DOTFinish", num);
			goto IL_0127;
		}
		goto IL_030f;
		IL_030f:
		ccaf53be8b86b7016efd6970ff8c92ad3.OnDamaged(context);
		return;
		IL_0127:
		if (c523669fbdbca543697a711391a979f8f(context))
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
			BadAssFPSCamera badAssFPSCamera = cc6a7269e9ea93e537de47dc752b09a86();
			if (cb1bc1ed3579c8c5bda5a8a3dbd112ea9 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (badAssFPSCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageShieldBroken);
					BaseEventTriggerCtl component = GetComponent<BaseEventTriggerCtl>();
					if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						component.TriggerEventByName("Chr_Shr_Shield_Power_Down");
					}
				}
			}
		}
		if (m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194())
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
			if (isTriggeringDamageOverTime)
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
				switch (context.m_damageInfo.m_elementalType)
				{
				case AttackInfo.ElementalType.Fire:
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageFire, num);
					break;
				case AttackInfo.ElementalType.Shock:
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageElectricity, num);
					break;
				case AttackInfo.ElementalType.Corrosive:
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageVenom, num);
					break;
				}
			}
			else if (flag)
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
				num = 1f;
				switch (context.m_subType)
				{
				case AttackSubType.DamageOverTimeFire:
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageFire, num);
					break;
				case AttackSubType.DamageOverTimeShock:
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageElectricity, num);
					break;
				case AttackSubType.DamageOverTimeCorrosive:
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c988e4ac6fdd1506753a02a8d529aa7be().c02b20c991314989826a70c235439571f(this, ENPCParticleType.E_DamageVenom, num);
					break;
				}
			}
		}
		goto IL_030f;
	}

	public bool c523669fbdbca543697a711391a979f8f(DamageContext c1c778df64f82822fbb8d95c39308b441)
	{
		int result;
		if (c1c778df64f82822fbb8d95c39308b441.m_victim == this)
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
			if (ce7804365a7377021025c46a16aa79db4() > 0)
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
				result = ((c1c778df64f82822fbb8d95c39308b441.m_damageInfo.m_shieldDamagePoints > ce7804365a7377021025c46a16aa79db4()) ? 1 : 0);
				goto IL_0052;
			}
		}
		result = 0;
		goto IL_0052;
		IL_0052:
		return (byte)result != 0;
	}

	private bool cc39e32515a88188b6980005dff0dc081(DamageContext c1c778df64f82822fbb8d95c39308b441)
	{
		int result;
		if (c1c778df64f82822fbb8d95c39308b441.m_subType != AttackSubType.DamageOverTimeFire)
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
			if (c1c778df64f82822fbb8d95c39308b441.m_subType != AttackSubType.DamageOverTimeShock)
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
				result = ((c1c778df64f82822fbb8d95c39308b441.m_subType == AttackSubType.DamageOverTimeCorrosive) ? 1 : 0);
				goto IL_0041;
			}
		}
		result = 1;
		goto IL_0041;
		IL_0041:
		return (byte)result != 0;
	}

	private KillType c709aae86530f905309ce6226ad5879b7(KillContext c2970555c0fc69d9442a248a8e3fc971c)
	{
		KillType killType = KillType.Others;
		if (c2970555c0fc69d9442a248a8e3fc971c.m_killer == this)
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
					if (c2970555c0fc69d9442a248a8e3fc971c.m_victim == this)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return KillType.Suicide;
							}
						}
					}
					return KillType.IKillEnemy;
				}
			}
		}
		if (c2970555c0fc69d9442a248a8e3fc971c.m_victim == this)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return KillType.EnemyKillMe;
				}
			}
		}
		return KillType.Others;
	}

	public void OnEntityKill(KillContext context)
	{
		switch (c709aae86530f905309ce6226ad5879b7(context))
		{
		case KillType.Suicide:
			m_lastKiller = context.m_killer;
			break;
		case KillType.EnemyKillMe:
			m_lastKiller = context.m_killer;
			break;
		case KillType.IKillEnemy:
			c1bdf1a24384171335555e759cf37580c();
			cc5bc6f25e26210301af0fbcd8fb1840c();
			break;
		}
	}

	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	public override EntityType c6420f67f9249b1d533531d9f351a36e0()
	{
		return EntityType.Player;
	}

	public static string[] c95e69186ffac00a7b6e6ea9e892c59b7()
	{
		return cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);
	}

	public override int ceb10167333758220ffb9bc66317ad763()
	{
		return cd95354b53e674ec7dc9594e66e4d316f().m_teamID;
	}

	public override EntityWeapon c3941dac8608f650ceb15dc36294a741c()
	{
		return m_equipedWeapon;
	}

	public override EntityShield c136b0f223897fdf01d18a9a5e3745433()
	{
		return c5ca38fad98337fc5c7255384b2cd1a86().cb4633378bdf6d47c409332e395d58c7a();
	}

	public EntityClassMode c77717f6875cf8dbd332d3f112b2aa888()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return equipmentInventoryEntityPlayer.c082f20f357e6d0dc7ac2d2e1a6edc8d1();
				}
			}
		}
		return null;
	}

	public ItemDNA ce28a223f404aa592c5a5374f3601de28()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return equipmentInventoryEntityPlayer.c66e5209456d049749c2f674f493b9d33();
				}
			}
		}
		return null;
	}

	public ItemDNA ce151fa795d7c589adcf6f778be230913()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return equipmentInventoryEntityPlayer.c187f6ec8d6b0a87c0b17a98906a6b50b();
				}
			}
		}
		return null;
	}

	public ItemDNA c70fcd351cb41ea802b178c30efa25138()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return equipmentInventoryEntityPlayer.c318f39e20985f3629512f08ea6e8ab64();
				}
			}
		}
		return null;
	}

	public override EquipmentInventoryEntity c5ca38fad98337fc5c7255384b2cd1a86()
	{
		return m_equipment;
	}

	public override CollisionManager c63f8f07320313ddc4213cb59ee025962()
	{
		return m_collisionManager;
	}

	public InstanceInput cbe65aaa5561a0ba002aca1f0c8498077()
	{
		return m_instanceInput;
	}

	public override int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		return c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(playerInfoSync.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), playerInfoSync.m_exp);
	}

	public void c66cb355a7c605747a1511357ef03c679(BadAssFPSCamera c91fcf132a3585bad3597263bc8937405)
	{
		m_badassFpsCamera = c91fcf132a3585bad3597263bc8937405;
	}

	public BadAssFPSCamera cc6a7269e9ea93e537de47dc752b09a86()
	{
		return m_badassFpsCamera;
	}

	public Vector3 c4fba392e405428b3fd4874067a8b82ac()
	{
		return m_badassFpsCamera.c5c60ca8f56ba52fb6c16328e1d5eff52();
	}

	public PlayerBehavior c17ec2ef7b478c8c7fcfb60360ea3f7a7()
	{
		return m_playerBehavior;
	}

	public override PlayerInfoSync cd95354b53e674ec7dc9594e66e4d316f()
	{
		if (m_playerInfo == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerInfo = m_session.cb062638207d3746ee631744a4709b38f(m_playerId);
		}
		return m_playerInfo;
	}

	public override bool caac907d451029d68503484a63934c93f()
	{
		return m_playerId == NetworkManager.cf6124bd5254101846a57acc03f545846();
	}

	public void c42841eb15edb296c94c38f237f57d3dd(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_equipedWeapon.c67c35955d666a0c6fe54cd6e348b1675();
		}
		c39409683a32e09391d094314ffeae2b5.c959567c3d0deab4dacbe2081900e09fd(this);
		m_equipedWeapon = c39409683a32e09391d094314ffeae2b5;
		c39409683a32e09391d094314ffeae2b5.c1c5a947f5f8c009fe6fac45c9e29ad1d(this);
		c7c26d0231ca6afec48218d109bffb68d(true);
	}

	public void c554459b1136a15a5b4817abd6efd4e80(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (caac907d451029d68503484a63934c93f())
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
			if (m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_equipedWeapon.c67c35955d666a0c6fe54cd6e348b1675();
			}
		}
		else
		{
			c56d6550ab92858846935051403bd86eb(c39409683a32e09391d094314ffeae2b5);
		}
		m_equipedWeapon = c39409683a32e09391d094314ffeae2b5;
		c39409683a32e09391d094314ffeae2b5.c1c5a947f5f8c009fe6fac45c9e29ad1d(this);
		c7c26d0231ca6afec48218d109bffb68d(true);
	}

	public void c56d6550ab92858846935051403bd86eb(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (c39409683a32e09391d094314ffeae2b5 == m_thighWeapon)
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
			m_thighWeapon = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (c39409683a32e09391d094314ffeae2b5 == m_backWeapon)
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
			m_backWeapon = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (!(m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_equipedWeapon.cd2662e9afb6b96dba3deeda201efd9a2(this);
			if (m_equipedWeapon.c83e548e5608cd7f222098a6966b16545() == WeaponType.RepeaterPistol)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (m_thighWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_thighWeapon.c67c35955d666a0c6fe54cd6e348b1675();
						}
						m_thighWeapon = m_equipedWeapon;
						return;
					}
				}
			}
			if (m_backWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_backWeapon.c67c35955d666a0c6fe54cd6e348b1675();
			}
			m_backWeapon = m_equipedWeapon;
			return;
		}
	}

	public virtual void cabac189d699c8d8d56d0e1a68cd1440b(EntityWeapon c5855a8e103463e7269cfc5037b8f30a6, byte c793014f9fd028450a4a9908376309f26)
	{
	}

	public void ce57aad6b596ff079026ec9d3af723d7f(EntityWeapon c5855a8e103463e7269cfc5037b8f30a6, byte c793014f9fd028450a4a9908376309f26, bool c3ac0b298d42329ee7efce55d32960c5e)
	{
	}

	[RPC]
	public void RPC_RequestPickUpWeapon(int weaponToPickId, int weaponToDropId, bool throwIt)
	{
		StartCoroutine(cadaf43857cdf51d3f5af530e0cffab4c(weaponToPickId, weaponToDropId, throwIt));
	}

	public int c1facd4b8473c97b11386825128ea5617(int c8482fe9e64f8661c0062a79f0b76a1b6)
	{
		return (int)((float)c8482fe9e64f8661c0062a79f0b76a1b6 * c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ClipSize));
	}

	public IEnumerator cccb56495987b6a4ebab7b225fb1af261(int c032dde06ae3bc1aea3470ca6703a228b)
	{
		BadAssNetworkView view2 = c758bff8e6f547440d0cfe42214b0c3e3.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			view2 = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(c032dde06ae3bc1aea3470ca6703a228b);
			yield return 0;
		}
		while (view2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			EntityObject item = cd106b90ad49dbab480b1d65a61bd2d9e.c7088de59e49f7108f520cf7e0bae167e;
			if (view2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				item = view2.GetComponent<EntityObject>();
			}
			while (!item.c39df47367fa21412aabfef05d9972f8c())
			{
				yield return 0;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				item.cd9058248734c831f0b6bdfd9e340e588(base.transform.position, base.transform.rotation, base.transform.forward);
				yield break;
			}
		}
	}

	public void c2f18a3b5ccc9813ca1b7e1fcfcffdc75(bool c931294945eb91e7c5c56f2a38ca1fcd9)
	{
		if (m_HandModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cdc80718389782f689e37bd44dbe7ee66();
		}
		m_HandModel.GetComponent<SkinnedMeshRenderer>().enabled = !c931294945eb91e7c5c56f2a38ca1fcd9;
		if (m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			SkinnedMeshRenderer[] componentsInChildren = m_equipedWeapon.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.enabled = !c931294945eb91e7c5c56f2a38ca1fcd9;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.mIsHideFpMesh = c931294945eb91e7c5c56f2a38ca1fcd9;
	}

	public Transform cdc80718389782f689e37bd44dbe7ee66()
	{
		if (m_HandModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			string text = string.Empty;
			switch (cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a())
			{
			case AvatarType.SIREN:
				text = "HipsAdjuster/CHR_Siren_Hand_L1_01";
				break;
			case AvatarType.SOLDIER:
				text = "HipsAdjuster/CHR_Soldier_Hand_L1_01";
				break;
			case AvatarType.BERSERKER:
				text = "HipsAdjuster/CHR_Berserker_Hand_L1_01";
				break;
			case AvatarType.HUNTER:
				text = "HipsAdjuster/CHR_Hunter_Hand_L1_01";
				break;
			}
			m_HandModel = ccd8e6ea278245d0f158036267242e60f().transform.Find(text);
		}
		return m_HandModel;
	}

	public Transform cd7e713117e8662fdc8bf0797b3134656(Transform c072d62d4edaec97afba470332ae2bbe8, string cf6815e425026ca075e85851e7fd4a872)
	{
		if (c072d62d4edaec97afba470332ae2bbe8.name.Equals(cf6815e425026ca075e85851e7fd4a872))
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
					return c072d62d4edaec97afba470332ae2bbe8;
				}
			}
		}
		IEnumerator enumerator = c072d62d4edaec97afba470332ae2bbe8.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform c072d62d4edaec97afba470332ae2bbe9 = (Transform)enumerator.Current;
				Transform transform = cd7e713117e8662fdc8bf0797b3134656(c072d62d4edaec97afba470332ae2bbe9, cf6815e425026ca075e85851e7fd4a872);
				if (!(transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					return transform;
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					goto end_IL_0072;
				}
				continue;
				end_IL_0072:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_008a;
					}
					continue;
					end_IL_008a:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	private void ce5c45bcaaf22de571068ea2c2117a705()
	{
	}

	private void ca6f045d8bd27d34cbbd13683d64fadfe()
	{
		EquipmentInventoryEntity.PropertyFlags propertyFlags = c5ca38fad98337fc5c7255384b2cd1a86().c8636e472c72127553c97e9fcab49f723();
		if ((propertyFlags & EquipmentInventoryEntity.PropertyFlags.InBattle) != 0)
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
					if (!m_isInBattle)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								c732ab96c02a4821e33e2e0645bbb76fe(true);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!m_isInBattle)
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
			c732ab96c02a4821e33e2e0645bbb76fe(false);
			return;
		}
	}

	private void c732ab96c02a4821e33e2e0645bbb76fe(bool cb29bb6633c1f9f41cccb1c2b14238c86)
	{
		m_isInBattle = cb29bb6633c1f9f41cccb1c2b14238c86;
		if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
			if (!(null != cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.ce693c931d729e0b4883c89920d35043a))
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
				if (m_isInBattle)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.ce693c931d729e0b4883c89920d35043a.cf84421bb197aecb61b01c3aacc5fdb11(TensityState.Battle);
							return;
						}
					}
				}
				cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.ce693c931d729e0b4883c89920d35043a.cf84421bb197aecb61b01c3aacc5fdb11(TensityState.Normal);
				return;
			}
		}
	}

	public override bool ce003fe849cc45b85ca4570109817c796()
	{
		BHVTaskManager bHVTaskManager = c9b6d1d87bef7b03dad787ff0031551ee();
		if ((bool)bHVTaskManager)
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
			BHVTask bHVTask = bHVTaskManager.c2d51f6bc5c05cfbf476c30230c67b09e();
			if (bHVTask != null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return bHVTask.m_Type == BHVTaskType.PlayerDead;
					}
				}
			}
		}
		return true;
	}

	public AvatarType cb21345185f43f30c1edeaf8faafb0f2c()
	{
		if (cd95354b53e674ec7dc9594e66e4d316f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
					}
				}
			}
		}
		return AvatarType.TOTAL;
	}

	public int c5b34e15b87470e6c66e050be40b46b99(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		return c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4459dc4cce1d07c3d1484ae8659420f3(cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), cd6bb591c33b2ee3ab93e98aa43a6da63);
	}

	public float ca61d6db905e9724fdacd777186a9df71()
	{
		float result = 1f;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
			float num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(c7513e66c4e0fc55e6fea9dd9cb8b9943());
			float num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5216004c85993c1fca7ac1d94a5ab8d1();
			result = num2 / num;
		}
		return result;
	}

	public float c2114cce42ff5c0bbee157895c53837f0()
	{
		float num = 1f;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					float num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(c7513e66c4e0fc55e6fea9dd9cb8b9943());
					float num3 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5216004c85993c1fca7ac1d94a5ab8d1();
					return num3 / num2;
				}
				}
			}
		}
		return c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(c7513e66c4e0fc55e6fea9dd9cb8b9943());
	}

	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		Debug.cd311b36270223e532813522a1f24cc90(cad7880776eb7b2ddfb106102d4c51bbf(), c56fad5727ffebf48f3df62074cd1bbe6() * 1000f);
		if (!(m_badassFpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Debug.cd311b36270223e532813522a1f24cc90(m_badassFpsCamera.transform.position, c56fad5727ffebf48f3df62074cd1bbe6() * 500f, Color.green);
			RaycastHit hitInfo;
			if (!Physics.Raycast(cad7880776eb7b2ddfb106102d4c51bbf(), c56fad5727ffebf48f3df62074cd1bbe6(), out hitInfo, 400f))
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
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(hitInfo.point, 0.05f);
				Debug.cd311b36270223e532813522a1f24cc90(hitInfo.point, hitInfo.normal, Color.red * 0.5f);
				return;
			}
		}
	}

	public void OnPlayerRespawn()
	{
		if (m_playerController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerController.c942f30413f4166213a90c3567ae1489b();
		}
		if (m_equipment == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		for (byte b = 0; b < m_equipment.cebe82f93c2f4e4f15daeb43e5bf5521b; b++)
		{
			EntityWeapon entityWeapon = m_equipment.c4e0dae6a16a8a80ddb5214a896b9df58(b);
			if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				entityWeapon.OnPlayerRespawn();
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			cae97f9a3934a859d516ff4ad03981cbc();
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
			return;
		}
	}

	public override Vector3 c56fad5727ffebf48f3df62074cd1bbe6()
	{
		if (m_playerController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_playerController.c8760391d0bea1fb1158ddfc6b9f642a4();
				}
			}
		}
		return base.c56fad5727ffebf48f3df62074cd1bbe6();
	}

	public Vector3 cf7550547722452e5b776c97da0849b86()
	{
		if (m_playerController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_playerController.c194dc32812949364e4b91bc6d94a4f68();
				}
			}
		}
		return Vector3.zero;
	}

	public override Vector3 cad7880776eb7b2ddfb106102d4c51bbf()
	{
		if (m_playerController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_playerController.c3be03b1daae1e93e9a0633a6c86aa45b();
				}
			}
		}
		return base.cad7880776eb7b2ddfb106102d4c51bbf();
	}

	public Entity c9cfe6f2006905d8acedda81275138d34()
	{
		return m_lastKiller;
	}

	public void c0411698b20c1e5ea7a3daa619b2a2b43()
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Throw", false);
	}

	public virtual void c1fc97d9000793496ac114d06521f85a0(byte c793014f9fd028450a4a9908376309f26)
	{
		EntityWeapon entityWeapon = c3941dac8608f650ceb15dc36294a741c();
		if ((bool)entityWeapon)
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
			c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(cd95354b53e674ec7dc9594e66e4d316f()).c1a6327c9e7b6688a621c96ccac024ec4(entityWeapon.c83e548e5608cd7f222098a6966b16545());
		}
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("SwitchWeapon", true, c793014f9fd028450a4a9908376309f26);
	}

	public virtual void cabac189d699c8d8d56d0e1a68cd1440b(byte c71953cab9dff52e14146804e2928df92, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("EquipWeapon", true, (c19a39247ea86ffe5f0de9d429ca0ca95 << 8) | c71953cab9dff52e14146804e2928df92);
	}

	public virtual void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("UnequipWeapon", true, c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public virtual void c61f40925cf99c31aa9ac5df098110ada(byte c71953cab9dff52e14146804e2928df92)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("EquipShield", true, c71953cab9dff52e14146804e2928df92);
	}

	public virtual void c2bf177eafbfeb7beaa0bfd04facb2029(byte c71953cab9dff52e14146804e2928df92)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("EquipClassMode", true, c71953cab9dff52e14146804e2928df92);
	}

	public virtual void cccb56495987b6a4ebab7b225fb1af261(byte c71953cab9dff52e14146804e2928df92)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("DropItem", true, c71953cab9dff52e14146804e2928df92);
	}

	public virtual void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("SwapItems", true, (c42a8a9b0dd4206315a44f945fbf7331f << 8) | c5242449e40eab9ce5011e2bacd82070c);
	}

	public virtual void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("SwapWeapons", true, (c42a8a9b0dd4206315a44f945fbf7331f << 8) | c5242449e40eab9ce5011e2bacd82070c);
	}

	public void cca50d90a16c827944406599b9940ea35()
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Melee");
		m_pending_melee = true;
	}

	public void ca2deb9a5d1216bb1f968806841f1236f()
	{
		m_skillManager.ca2deb9a5d1216bb1f968806841f1236f();
	}

	public void ce2d31574942eb4096a689fa7573ca86e()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					InteractionClient c38a5a12997c9bd05a4616a5ae16e2f = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
					InteractionClient cd09bb1399261bd246ac4a49e9e4219a = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
					float c3b8493e0eaa99ba0eb14a1a14105961f = 0f;
					if (InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c54f7becd6f38edcaefd7d35cc9d49e83(this, ref c38a5a12997c9bd05a4616a5ae16e2f, ref cd09bb1399261bd246ac4a49e9e4219a, ref c3b8493e0eaa99ba0eb14a1a14105961f))
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								if (!(c38a5a12997c9bd05a4616a5ae16e2f is EntityWeapon))
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
											c38a5a12997c9bd05a4616a5ae16e2f.c4f2632dc55b69776a2b25638b97dedb6(this);
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction == null)
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
			if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction is Pickable)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
					{
						Pickable pickable = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction as Pickable;
						EntityObject entity = pickable.m_entity;
						ItemDNA itemDNA = entity.c4622c7a1660020e5029da03e27491b37();
						if (itemDNA != null)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									if (InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c6f2d419a4cc4b7bbd6ab53caca787949(this, itemDNA))
									{
										while (true)
										{
											switch (3)
											{
											case 0:
												break;
											default:
												m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("EntityInteraction", false, entity.cc7403315505256d19a7b92aa614a8f10());
												return;
											}
										}
									}
									return;
								}
							}
						}
						return;
					}
					}
				}
			}
			if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction is LevelTrigger)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						LevelTrigger levelTrigger = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_currentInteraction as LevelTrigger;
						m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("LevelTriggerInteraction", true, levelTrigger.c3db99fdbe4f5f530c7ee2cafae9d3eca());
						return;
					}
					}
				}
			}
			InteractionClient c38a5a12997c9bd05a4616a5ae16e2f2 = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
			InteractionClient cd09bb1399261bd246ac4a49e9e4219a2 = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
			float c3b8493e0eaa99ba0eb14a1a14105961f2 = 0f;
			if (!InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c54f7becd6f38edcaefd7d35cc9d49e83(this, ref c38a5a12997c9bd05a4616a5ae16e2f2, ref cd09bb1399261bd246ac4a49e9e4219a2, ref c3b8493e0eaa99ba0eb14a1a14105961f2))
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
				if (!(c38a5a12997c9bd05a4616a5ae16e2f2 is TeleportToTownTrigger))
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
					c38a5a12997c9bd05a4616a5ae16e2f2.c4f2632dc55b69776a2b25638b97dedb6(this);
					return;
				}
			}
		}
	}

	public void c098a9e3bea516a2ee4b9e6170de0b3e6(float cca5b0973d99ebc86cc45dfab1e61691f)
	{
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component.OnBerserkCharge(cca5b0973d99ebc86cc45dfab1e61691f);
	}

	public void c531fa1904aba5c91f9ea2d5bfd5e19e2(float cca5b0973d99ebc86cc45dfab1e61691f)
	{
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component.OnBerserkDash(cca5b0973d99ebc86cc45dfab1e61691f);
	}

	public void cf513ff9980e016604182063a6fba6ce5(float cca5b0973d99ebc86cc45dfab1e61691f)
	{
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component.OnBerserkPunch(cca5b0973d99ebc86cc45dfab1e61691f);
	}

	public void c65a04969a82d5af643e40146d4397416(float cca5b0973d99ebc86cc45dfab1e61691f)
	{
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component.OnFireBird(cca5b0973d99ebc86cc45dfab1e61691f);
	}

	public void cdae2d559d2cfebf7e06a8b2042b62a34(float cca5b0973d99ebc86cc45dfab1e61691f)
	{
		PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component.OnCallback(cca5b0973d99ebc86cc45dfab1e61691f);
	}

	public void c8e7de6296a25baa9101b2c51d861bbd4(float ce5153005e58459c18774d81099f8d6d6)
	{
		BroadcastMessage("OnThrowGrenade", SendMessageOptions.DontRequireReceiver);
	}

	public void cd3114b21dfb2b49cb9c14ab9e75026a9()
	{
		Throw @throw = m_ability.c663d11c8834305590100229866ab1cbc("Throw") as Throw;
		if (@throw == null)
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
			@throw.cba75526d58d328a7e2a0f72ff6bb6d36();
			return;
		}
	}

	public void cc6aeb18b193c810dc60d4bc287856afd(bool c40f108113e728ab673107a7ea66b4b64)
	{
		PlayerThirdPersonAnimationManagerFSM playerThirdPersonAnimationManagerFSM = cb8119a2676bfbd4df00a9ed683eed91a() as PlayerThirdPersonAnimationManagerFSM;
		if (!(playerThirdPersonAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (c40f108113e728ab673107a7ea66b4b64)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						playerThirdPersonAnimationManagerFSM.c45db0588e69aeb4ffd5cd6c61e636182(0f);
						return;
					}
				}
			}
			playerThirdPersonAnimationManagerFSM.c45db0588e69aeb4ffd5cd6c61e636182(1f);
			return;
		}
	}

	public bool c611613a4cdf13c7acc73007bf65a3d2c(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (m_playerController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return m_playerController.c611613a4cdf13c7acc73007bf65a3d2c(c19a39247ea86ffe5f0de9d429ca0ca95);
				}
			}
		}
		return false;
	}

	public virtual void ce7f18d227f2281ec702017e97b1553a7(byte c793014f9fd028450a4a9908376309f26)
	{
		m_equipment.cb71c24b68b65fe176d7936520d63a102(c793014f9fd028450a4a9908376309f26);
		StartCoroutine(ce763bd1866687d6bcc8efb401b464efc(m_equipment.cdda217ef6662acf86a5584ba19758192().cc7403315505256d19a7b92aa614a8f10()));
	}

	public void c844f5821f637596bbd1ae6eeddee90c9(byte cd27037dd3bf1006e6e39ebf89cbd7b03, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		m_equipment.cabac189d699c8d8d56d0e1a68cd1440b(cd27037dd3bf1006e6e39ebf89cbd7b03, c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public void caca8909bc1b1c48be9b9e5b497950bbc(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		m_equipment.c89361444df98c6f8354125e8bdb18882(c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public void c6cb662b5f4cf63b261aebc6f8f4f85a4(byte c71953cab9dff52e14146804e2928df92)
	{
		m_equipment.c61f40925cf99c31aa9ac5df098110ada(c71953cab9dff52e14146804e2928df92);
	}

	public void cc138972f2def727f3f514e72eb92827e(byte c71953cab9dff52e14146804e2928df92)
	{
		m_equipment.c2bf177eafbfeb7beaa0bfd04facb2029(c71953cab9dff52e14146804e2928df92);
	}

	public void c8cc28bd59a2da591a27cc3e0a7981a44(byte c71953cab9dff52e14146804e2928df92)
	{
		m_equipment.cccb56495987b6a4ebab7b225fb1af261(c71953cab9dff52e14146804e2928df92);
	}

	public override Vector3 c8cc25ca9fd18f583f33395178ef47f1d()
	{
		Skeleton skeleton = ccd8e6ea278245d0f158036267242e60f();
		if ((bool)skeleton)
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
			Transform transform = skeleton.cb2362c81dda995fcf817a341a4eb3ffb();
			if ((bool)transform)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						Vector3 position = transform.position;
						position.y -= 0.2f;
						return position;
					}
					}
				}
			}
		}
		return c4cf00ced2bc60ae908904eb73692869f();
	}

	public void c758f3560939f4f4f4649685139ccadc4(Quaternion c4ea6de03c1203f2470a6677821ad93f0, float c929d6dc26794b71ada3b76f22282c0f2)
	{
		m_playerController.c758f3560939f4f4f4649685139ccadc4(c4ea6de03c1203f2470a6677821ad93f0, c929d6dc26794b71ada3b76f22282c0f2);
	}

	public void c95b58ea1846fc7087c97f6018072d7de(Quaternion c4ea6de03c1203f2470a6677821ad93f0)
	{
		if (!(m_playerBehavior != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_playerBehavior.cef9a15f55812dc1fbddb2da6f1d2e6f3(c4ea6de03c1203f2470a6677821ad93f0.eulerAngles.y);
			m_playerBehavior.c222a9c0d0fa89d627bd2ccdc0d9092fc(c4ea6de03c1203f2470a6677821ad93f0.eulerAngles.x);
			return;
		}
	}

	public void c0cf22ec412ee180adea404711b6e7305(Transform c5934603828f9e9928c0d117240d0ff65)
	{
		if (!(m_playerBehavior != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_playerBehavior.c1303fb339fb3afd9e5931160fcca18cc(c5934603828f9e9928c0d117240d0ff65);
			return;
		}
	}

	public void c22cf8c28043e3d3f1b2bac01481e1ffd()
	{
		if (!(m_playerBehavior != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_playerBehavior.c23b559d4547aa3ece9286f3fadfd44b9();
			return;
		}
	}

	private Vector3 cce49f768696a567cae70e8564f85326a()
	{
		return cad7880776eb7b2ddfb106102d4c51bbf() + m_playerBehavior.cd9761354b8ba9519cb1ef92160cf8b59() * Time.fixedDeltaTime * 15f;
	}

	private Vector3 cda5a9d252c502702822081a2dd74d6e2()
	{
		if (Vector3.Angle(cf7550547722452e5b776c97da0849b86() * 15f, Vector3.zero) < 20f)
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
					return c56fad5727ffebf48f3df62074cd1bbe6() + cf7550547722452e5b776c97da0849b86() * 15f;
				}
			}
		}
		return c56fad5727ffebf48f3df62074cd1bbe6();
	}

	public bool c022608575b376ccc02c9ef85c756fa90(Entity c82fcbab5e578dc3a31c1f662916bd87e)
	{
		Skeleton skeleton = c82fcbab5e578dc3a31c1f662916bd87e.ccd8e6ea278245d0f158036267242e60f();
		if ((bool)skeleton)
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
			Transform transform = skeleton.cb2362c81dda995fcf817a341a4eb3ffb();
			if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (Vector3.Dot(transform.position - cce49f768696a567cae70e8564f85326a(), cda5a9d252c502702822081a2dd74d6e2()) > 0f)
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
					Bounds bounds = c82fcbab5e578dc3a31c1f662916bd87e.cfd528711df451502ef1ce8ea692f8afc();
					Vector3[] array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(8);
					array[0] = bounds.center + new Vector3(0f - bounds.extents.x, bounds.extents.y, 0f - bounds.extents.z) * 0.9f;
					array[1] = bounds.center + new Vector3(bounds.extents.x, 0f - bounds.extents.y, 0f - bounds.extents.z) * 0.9f;
					array[2] = bounds.center + new Vector3(bounds.extents.x, bounds.extents.y, 0f - bounds.extents.z) * 0.9f;
					array[3] = bounds.center + new Vector3(0f - bounds.extents.x, 0f - bounds.extents.y, 0f - bounds.extents.z) * 0.9f;
					array[4] = bounds.center + new Vector3(0f - bounds.extents.x, bounds.extents.y, bounds.extents.z) * 0.9f;
					array[5] = bounds.center + new Vector3(bounds.extents.x, 0f - bounds.extents.y, bounds.extents.z) * 0.9f;
					array[6] = bounds.center + new Vector3(bounds.extents.x, bounds.extents.y, bounds.extents.z) * 0.9f;
					array[7] = bounds.center + new Vector3(0f - bounds.extents.x, 0f - bounds.extents.y, bounds.extents.z) * 0.9f;
					float num = 0f;
					Vector3 vector = Vector3.zero;
					Ray cdb5cb253ef1339831696a37475f7233f = new Ray(cce49f768696a567cae70e8564f85326a(), c82fcbab5e578dc3a31c1f662916bd87e.transform.position + bounds.center - cce49f768696a567cae70e8564f85326a());
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = c82fcbab5e578dc3a31c1f662916bd87e.transform.position + c82fcbab5e578dc3a31c1f662916bd87e.transform.TransformDirection(array[i]);
						float num2 = Utils.cae03c409152de312b7950c98c6058048(cdb5cb253ef1339831696a37475f7233f, array[i]);
						if (!(num2 > num))
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
						num = num2;
						vector = array[i];
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
					Vector3 vector2 = 2f * (c82fcbab5e578dc3a31c1f662916bd87e.transform.position + bounds.center) - vector;
					Vector3 vector3 = new Vector3(vector.x, vector.y - 2f * (vector.y - (c82fcbab5e578dc3a31c1f662916bd87e.transform.position + bounds.center).y), vector.z);
					Vector3 vector4 = new Vector3(vector2.x, vector2.y - 2f * (vector2.y - (c82fcbab5e578dc3a31c1f662916bd87e.transform.position + bounds.center).y), vector2.z);
					array[0] = vector;
					array[1] = vector2;
					array[2] = vector3;
					array[3] = vector4;
					array[4] = transform.position;
					array[5] = c82fcbab5e578dc3a31c1f662916bd87e.transform.position;
					Collider c5c049386ad279173b227358fda3eaaf = cba31495600bcc560b910fdfa4123ae28.c7088de59e49f7108f520cf7e0bae167e;
					int num3 = 6;
					if (sightTestCache.ContainsKey(c82fcbab5e578dc3a31c1f662916bd87e))
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
						num3 = sightTestCache[c82fcbab5e578dc3a31c1f662916bd87e];
						float c85645ac328a4c6e6c17d3da3be1e11f = 300f;
						cdb5cb253ef1339831696a37475f7233f.direction = array[num3] - cce49f768696a567cae70e8564f85326a();
						Debug.cd311b36270223e532813522a1f24cc90(cdb5cb253ef1339831696a37475f7233f.origin, cdb5cb253ef1339831696a37475f7233f.direction * 1000f, Color.black);
						if (num3 < 4)
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
							if (TargetingService.cfc7875e612739018821cc55abbe376ab(cdb5cb253ef1339831696a37475f7233f, this, c82fcbab5e578dc3a31c1f662916bd87e, out c5c049386ad279173b227358fda3eaaf, ref c85645ac328a4c6e6c17d3da3be1e11f, ColliderType.MovementBounding))
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return true;
									}
								}
							}
						}
						else if (TargetingService.cfc7875e612739018821cc55abbe376ab(cdb5cb253ef1339831696a37475f7233f, this, c82fcbab5e578dc3a31c1f662916bd87e, out c5c049386ad279173b227358fda3eaaf, ref c85645ac328a4c6e6c17d3da3be1e11f))
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
					for (int j = 0; j < 6; j++)
					{
						if (j == num3)
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
							continue;
						}
						float c85645ac328a4c6e6c17d3da3be1e11f2 = 300f;
						cdb5cb253ef1339831696a37475f7233f.direction = array[j] - cce49f768696a567cae70e8564f85326a();
						Debug.cd311b36270223e532813522a1f24cc90(cdb5cb253ef1339831696a37475f7233f.origin, cdb5cb253ef1339831696a37475f7233f.direction * 1000f, Color.black);
						if (j < 4)
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
							if (!TargetingService.cfc7875e612739018821cc55abbe376ab(cdb5cb253ef1339831696a37475f7233f, this, c82fcbab5e578dc3a31c1f662916bd87e, out c5c049386ad279173b227358fda3eaaf, ref c85645ac328a4c6e6c17d3da3be1e11f2, ColliderType.MovementBounding))
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
								sightTestCache[c82fcbab5e578dc3a31c1f662916bd87e] = j;
								return true;
							}
						}
						if (!TargetingService.cfc7875e612739018821cc55abbe376ab(cdb5cb253ef1339831696a37475f7233f, this, c82fcbab5e578dc3a31c1f662916bd87e, out c5c049386ad279173b227358fda3eaaf, ref c85645ac328a4c6e6c17d3da3be1e11f2))
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
							sightTestCache[c82fcbab5e578dc3a31c1f662916bd87e] = j;
							return true;
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
				}
				else if (Vector3.Distance(c82fcbab5e578dc3a31c1f662916bd87e.transform.position, base.transform.position) < 5f)
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
		}
		return false;
	}

	public bool c565e9b2ca75f4f14ddd946c716adf4c3(Entity c82fcbab5e578dc3a31c1f662916bd87e)
	{
		Skeleton skeleton = c82fcbab5e578dc3a31c1f662916bd87e.ccd8e6ea278245d0f158036267242e60f();
		if ((bool)skeleton)
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
			Transform transform = skeleton.cb2362c81dda995fcf817a341a4eb3ffb();
			if ((bool)transform)
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
				if (Vector3.Angle(cda5a9d252c502702822081a2dd74d6e2(), transform.position - cce49f768696a567cae70e8564f85326a()) < 20f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
			else if (Vector3.Angle(cda5a9d252c502702822081a2dd74d6e2(), base.transform.position - cce49f768696a567cae70e8564f85326a()) < 20f)
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
		return false;
	}

	public bool c126f9363ce5c4ad9fc89f2e68a306b44(Entity c82fcbab5e578dc3a31c1f662916bd87e)
	{
		Skeleton skeleton = c82fcbab5e578dc3a31c1f662916bd87e.ccd8e6ea278245d0f158036267242e60f();
		if ((bool)skeleton)
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
			Transform transform = skeleton.cb2362c81dda995fcf817a341a4eb3ffb();
			if ((bool)transform)
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
				if (Vector3.Angle(cda5a9d252c502702822081a2dd74d6e2(), transform.position - cce49f768696a567cae70e8564f85326a()) < 40f)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						return true;
					}
				}
				if (Vector3.Angle(cda5a9d252c502702822081a2dd74d6e2(), base.transform.position - cce49f768696a567cae70e8564f85326a()) < 40f)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
			else if (Vector3.Angle(cda5a9d252c502702822081a2dd74d6e2(), base.transform.position - cce49f768696a567cae70e8564f85326a()) < 40f)
			{
				while (true)
				{
					switch (5)
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

	public bool ca12cadbe7ee37d267b161a94064131c1()
	{
		return m_bAimFOVChanging;
	}

	public void cce8a06f9d2b6de4283a2b9ecd4e2b29e(bool c93f525ed928b54f8eb035ee537387461)
	{
		m_bAimFOVChanging = c93f525ed928b54f8eb035ee537387461;
	}

	public override bool c147acea867a351adb3024b05cfd5b676()
	{
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return base.c147acea867a351adb3024b05cfd5b676();
				}
			}
		}
		return playerInfoSync.m_isInvulnerable;
	}

	public override void c8adb21292420ed2d7200db3d23532054(bool c1a11d8e9e2f1e1078bc1ec4cc3e55259)
	{
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					base.c8adb21292420ed2d7200db3d23532054(c1a11d8e9e2f1e1078bc1ec4cc3e55259);
					return;
				}
			}
		}
		playerInfoSync.m_isInvulnerable = c1a11d8e9e2f1e1078bc1ec4cc3e55259;
	}

	public void c99666144e8ebdd383dd49eeead74a99b()
	{
		m_playerBehavior.cb230cde4e133468f684068c91db18b7e(false);
	}

	private void c1bdf1a24384171335555e759cf37580c()
	{
		float num = c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.FixedTimeRegenHealthSpeed);
		if (num <= 0f)
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
					return;
				}
			}
		}
		float num2 = c02f3d4a4e7d1edee179f9bf7e16aeb82.c275ce281d2ced47562dce554e5197b73(ESkillType.Bloodlust);
		if (num2 <= 0f)
		{
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
		ccaf53be8b86b7016efd6970ff8c92ad3.c4272679fcbdb32603c8619b840e38e80.c444e6956d2e3aa629944329c6fa446be(num, num2);
	}

	private void cc5bc6f25e26210301af0fbcd8fb1840c()
	{
		BerserkManage berserkManage = ccaf53be8b86b7016efd6970ff8c92ad3 as BerserkManage;
		if (!(berserkManage != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			berserkManage.c5b66bbc9fbd5c36731d817ab86894762();
			return;
		}
	}

	public void ca85441e335aa8deaaaf1078789d9a19b(GameObject c92be84c2929e14255cef0634f9677b3f)
	{
		m_titleObj = c92be84c2929e14255cef0634f9677b3f;
		Vector3 vector;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			vector = new Vector3(cf1bd1736812e2b58e29ab4a7df48f8fc.m_titleOffsetX_Town, cf1bd1736812e2b58e29ab4a7df48f8fc.m_titleOffsetY_Town, cf1bd1736812e2b58e29ab4a7df48f8fc.m_titleOffsetZ_Town);
		}
		else
		{
			vector = new Vector3(cf1bd1736812e2b58e29ab4a7df48f8fc.m_titleOffsetX, cf1bd1736812e2b58e29ab4a7df48f8fc.m_titleOffsetY, cf1bd1736812e2b58e29ab4a7df48f8fc.m_titleOffsetZ);
		}
		Vector3 localPosition = vector;
		m_titleObj.transform.localPosition = localPosition;
	}

	public GameObject cfead42af4aa2d194749ea438d6310568()
	{
		return m_titleObj;
	}

	public void c002774b2c8a7098f9730129583e3722b(Transform c6709ec9bf67bc64248af981a28f45a7d)
	{
		m_3rdPersonRenderTransform = c6709ec9bf67bc64248af981a28f45a7d;
	}

	public void c6a81925b944ea7d0f6008bd83da0380d(bool c3c6828becf8413d62854040807b3e230)
	{
		if (m_3rdPersonRenderTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			SkinnedMeshRenderer[] componentsInChildren = m_3rdPersonRenderTransform.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				if (!(skinnedMeshRenderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
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
				skinnedMeshRenderer.enabled = !c3c6828becf8413d62854040807b3e230;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		if (!(m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_equipedWeapon.c8427a60c8a870df8389ec09a90588877(c3c6828becf8413d62854040807b3e230);
			return;
		}
	}

	public void cb768055bae24957dda6e466dfabe8b02(BuildingKitRender c08e7e52da87900283104d9f3edfb4156)
	{
		PlayerFirstPersonInventoryManager[] componentsInChildren = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponentsInChildren<PlayerFirstPersonInventoryManager>(true);
		GameObject gameObject;
		if (componentsInChildren != null)
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
			if (componentsInChildren.Length > 0)
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
				gameObject = componentsInChildren[0].gameObject;
				goto IL_0158;
			}
		}
		gameObject = c08e7e52da87900283104d9f3edfb4156.c3309affdc4b59cba5f457bbaec5f0762();
		Component component = gameObject.GetComponent<MecanimEventEmitter>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(component);
		}
		component = gameObject.GetComponent<AudioEventTriggerCtl>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(component);
		}
		component = gameObject.GetComponent<AudioParameterValues>();
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
			UnityEngine.Object.Destroy(component);
		}
		m_playerFirstPersonInventoryManager = gameObject.AddComponent<PlayerFirstPersonInventoryManager>();
		m_playerFirstPersonInventoryManager.c08335188fc1aef17bd106701ce1f7091 = gameObject.AddComponent<Skeleton>();
		string text = gameObject.name.Replace("(Clone)", string.Empty) + "_InventoryView";
		gameObject.name = text;
		PlayerAnimationIkController playerAnimationIkController = gameObject.AddComponent<PlayerAnimationIkController>();
		playerAnimationIkController.m_enableLeftHandIK = true;
		playerAnimationIkController.m_enableAimIK = false;
		playerAnimationIkController.m_enableLookIK = false;
		gameObject.transform.position = new Vector3(-1000f, -1000f, -1000f);
		goto IL_0158;
		IL_0158:
		PlayerThirdPersonAnimationManagerFSM component2 = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		component2.c29a63c4e0ac26e5b18e60c8167b5f543(gameObject);
	}

	public PlayerFirstPersonInventoryManager c59c4cd4b0f739ff1266013913fd2588a()
	{
		return m_playerFirstPersonInventoryManager;
	}

	protected void c63442ae8c521ed9ec39ab8fef9481e2b()
	{
		cb6163bf2d124cf5e051d1b26bc3056df();
	}

	private void cb6163bf2d124cf5e051d1b26bc3056df()
	{
		MemoryStream memoryStream = new MemoryStream(m_config_character.bytes);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(CharacterSetting));
			m_character_setting = xmlSerializer.Deserialize(memoryStream) as CharacterSetting;
		}
		finally
		{
			if (memoryStream != null)
			{
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
					((IDisposable)memoryStream).Dispose();
					break;
				}
			}
		}
	}

	public override float ce78805f904c50c7f149c6307c9b9fd5b(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		ccaf53be8b86b7016efd6970ff8c92ad3.c36677ec303a1d28a6920e312ed95c716(cf7ee7f254a35f9c53a393957e2758a0a, c3ced719b4780c1919017d69e82521ab3);
		return m_victimDamageModifier_skill;
	}

	public void c04d623108b1bd03e6013396a14c892c0(float c46ee00a9eee7def6bd5a897a5dce71e8)
	{
		m_victimDamageModifier_skill = c46ee00a9eee7def6bd5a897a5dce71e8;
	}

	public float c2386b82d4bb271e437af2a55537b8ff7()
	{
		return m_elementalDamageModifier_skill;
	}

	public void c6cd54baef34e474872c4ce12a7130afe(float c46ee00a9eee7def6bd5a897a5dce71e8)
	{
		m_elementalDamageModifier_skill = c46ee00a9eee7def6bd5a897a5dce71e8;
	}

	public override void ce7325a1f0410a6d170ae58fce0f0ae7f(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		if (c3521c9096ab7c30ece57e61bdb8622f2 == null)
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
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.PlayerSkill, new BHVTaskPlayerSkill());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Default, new BHVTaskDefault());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.PlayerDead, new BHVTaskPlayerDead());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.PlayerSpawn, new BHVTaskPlayerSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.PlayerTransfer, new BHVTaskPlayerTransfer());
	}

	[RPC]
	private void RPC_RequestAllLifeAndShield(Hashtable data, PhotonMessageInfo info)
	{
		int num = 0;
		int num2 = (int)data[num++];
		for (int i = 0; i < num2; i++)
		{
			int c35f98ccbfa8c6bf09319c620b21b5dc = (int)data[num++];
			Hashtable c591d56a94543e3559945c497f37126c = (Hashtable)data[num++];
			Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c35f98ccbfa8c6bf09319c620b21b5dc);
			if (!entity)
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
			EquipmentInventoryEntity equipmentInventoryEntity = entity.c5ca38fad98337fc5c7255384b2cd1a86();
			equipmentInventoryEntity.caece940d1c226511b3cca16fa8aa6a38(c591d56a94543e3559945c497f37126c);
		}
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

	public override float c150748569f6883ea4267194e6e3271e7(EntityWeapon c63e77db49ee63186e474d32152b9912c, int cfba4197b705c13c9466d9b0559d75d4b)
	{
		if (c63e77db49ee63186e474d32152b9912c == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return 0f;
				}
			}
		}
		float num = 0f;
		if (c63e77db49ee63186e474d32152b9912c.m_owner != this)
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
			num = c63e77db49ee63186e474d32152b9912c.m_owner.c150748569f6883ea4267194e6e3271e7(c63e77db49ee63186e474d32152b9912c, cfba4197b705c13c9466d9b0559d75d4b);
		}
		else
		{
			num = base.c150748569f6883ea4267194e6e3271e7(c63e77db49ee63186e474d32152b9912c, cfba4197b705c13c9466d9b0559d75d4b);
			if (ccaf53be8b86b7016efd6970ff8c92ad3 is FirebirdManage)
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
				float num2 = c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ElementDamage);
				num *= num2;
			}
			Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(cfba4197b705c13c9466d9b0559d75d4b);
			if (entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (entity is EntityPlayer)
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
					if ((entity as EntityPlayer).ccaf53be8b86b7016efd6970ff8c92ad3 is FirebirdManage)
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
						float num3 = (entity as EntityPlayer).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ResistElemental);
						num *= num3;
					}
				}
			}
		}
		return num * ca61d6db905e9724fdacd777186a9df71();
	}

	public void c2752f2e288d1e93ed4cdbb91832ec547(Entity c5d720f6d007abb0c4a21d6a654e405bb, float c84e0f1577246d40abcee6787ad5fb01d = 1f)
	{
		if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c84e0f1577246d40abcee6787ad5fb01d <= 0f)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_playerController.c2752f2e288d1e93ed4cdbb91832ec547((base.transform.position - c5d720f6d007abb0c4a21d6a654e405bb.transform.position).normalized * c84e0f1577246d40abcee6787ad5fb01d);
			return;
		}
	}

	public void c5c2aca029c3e1bc2bb64865a174ee334(bool cbfa69f8aec4c97d21e304a033a27250b)
	{
	}

	public void c8b0e994a248a912b115148e865a26464()
	{
		float cc38eba0587ccfea8f79928554ac7e78f = 7f;
		if (m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194())
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
					if ((bool)c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
							{
								FpEffectMgr fpEffectMgr = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c20e43347435e746a8d6d3d2c3d99c2f6();
								if (fpEffectMgr != null)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											fpEffectMgr.cd9568bf035fae5f39fd87a96cba69fa2(cc38eba0587ccfea8f79928554ac7e78f, CharacterFxMgr.FX_TYPE.FX_REVIVE);
											return;
										}
									}
								}
								return;
							}
							}
						}
					}
					return;
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			CharacterFxMgr characterFxMgr = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7();
			if (characterFxMgr == null)
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
				characterFxMgr.cd9568bf035fae5f39fd87a96cba69fa2(this, cc38eba0587ccfea8f79928554ac7e78f, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				if ((bool)m_equipedWeapon)
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
					characterFxMgr.cd9568bf035fae5f39fd87a96cba69fa2(m_equipedWeapon, cc38eba0587ccfea8f79928554ac7e78f, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				}
				if ((bool)m_backWeapon)
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
					characterFxMgr.cd9568bf035fae5f39fd87a96cba69fa2(m_backWeapon, cc38eba0587ccfea8f79928554ac7e78f, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				}
				if (!m_thighWeapon)
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
					characterFxMgr.cd9568bf035fae5f39fd87a96cba69fa2(m_thighWeapon, cc38eba0587ccfea8f79928554ac7e78f, CharacterFxMgr.FX_TYPE.FX_REVIVE);
					return;
				}
			}
		}
	}

	public override void cbb91e2330ed12a1942ead68e69e691a3(float c7877e67acd1ae62d246b5fb5e889a066)
	{
		if (c7877e67acd1ae62d246b5fb5e889a066 >= 1f)
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
					m_playerController.c942f30413f4166213a90c3567ae1489b();
					return;
				}
			}
		}
		m_playerController.c15206bb0d3ef42ea679c4698dced3dd1(c7877e67acd1ae62d246b5fb5e889a066);
	}

	public override void c49c490bcb316f43984756f2360518e6c(bool c8678fc7ce74e7101a14c28cf81451c7e)
	{
		float num;
		if (c8678fc7ce74e7101a14c28cf81451c7e)
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
			num = m_slowdown_marked_move;
		}
		else
		{
			num = 1f / m_slowdown_marked_move;
		}
		float c41372251925d6a785ff80b08d32bcc2c = num;
		m_playerController.c63ee313b87b770d38877f71939e90417(c41372251925d6a785ff80b08d32bcc2c);
	}

	public float c0e945b845e43ce710fc04a076a690a4e()
	{
		float result = 1f;
		if (ccaf53be8b86b7016efd6970ff8c92ad3 is HunterManage)
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
			result = c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.MarkingSlowRate);
		}
		return result;
	}

	public void cc2f0113176b624e561c0a894437dd8a7()
	{
		StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		if (sessionStats == null)
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
			if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
			if (statSheet == null)
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
			statSheet.c1babe499d121710272f7c72c1e923d1c(playerInfoSync.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a());
			return;
		}
	}

	public void c7c26d0231ca6afec48218d109bffb68d(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		Transform transform = cdc80718389782f689e37bd44dbe7ee66();
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		SkinnedMeshRenderer componentInChildren = transform.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		componentInChildren.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
	}

	public static AttackSubType c1bfdbbec3309b974f6b968fbb351a0ee(AttackSubType c4ebb4b9f676d846bc755ec671cea929b)
	{
		AttackSubType result = c4ebb4b9f676d846bc755ec671cea929b;
		switch (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c4ebb4b9f676d846bc755ec671cea929b))
		{
		case AttackInfo.AttackType.Projectile:
			result = AttackSubType.ProjectileHunter;
			break;
		case AttackInfo.AttackType.Area:
			result = AttackSubType.AreaHunter;
			break;
		case AttackInfo.AttackType.Melee:
			result = AttackSubType.MeleeHunter;
			break;
		}
		return result;
	}

	public bool c574429d11bce939e5a13413cb192e895(Entity cf90129559e8b043c8851fe07557ea812, Vector3 c4f1383b49aeaf204a4e2ef0b2495439b, float c4e056a08341b1f8b5cc7d8827a42b83a)
	{
		if (cf90129559e8b043c8851fe07557ea812 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		if (cf90129559e8b043c8851fe07557ea812.c5ca38fad98337fc5c7255384b2cd1a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (cf90129559e8b043c8851fe07557ea812.c5ca38fad98337fc5c7255384b2cd1a86().ca2ff7a501878363cb1d5f0472e306620() <= 0)
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
		if (c52b0e4c302961935453bec436d84dc68(cf90129559e8b043c8851fe07557ea812))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		float num = Vector3.Distance(c4f1383b49aeaf204a4e2ef0b2495439b, cf90129559e8b043c8851fe07557ea812.transform.position);
		if (num > c4e056a08341b1f8b5cc7d8827a42b83a)
		{
			while (true)
			{
				switch (6)
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

	private bool c52b0e4c302961935453bec436d84dc68(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		if (this == c6e853f452cc819532893b63942b8ed3d)
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
					return true;
				}
			}
		}
		if (c6e853f452cc819532893b63942b8ed3d.ceb10167333758220ffb9bc66317ad763() == ceb10167333758220ffb9bc66317ad763())
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
			if (!cad418535912a1c3cb6ea0ce1e4cbd114())
			{
				while (true)
				{
					switch (5)
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

	public void OnSwitchWeaponDone()
	{
		ccaf53be8b86b7016efd6970ff8c92ad3.OnSwitchWeaponDone();
		EntityWeapon entityWeapon = c3941dac8608f650ceb15dc36294a741c();
		if (!entityWeapon)
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
			c1632dd8ecf9bf6333f194667a67f8b01();
			return;
		}
	}

	public void c1632dd8ecf9bf6333f194667a67f8b01()
	{
	}

	public virtual void c7f7764f5af0ac27b16e2d01b492e5258()
	{
		c1632dd8ecf9bf6333f194667a67f8b01();
	}

	public int c5e6c0e1345df3750fb99585be90b80c3(int c3829226c5ae6148b47389b84cd9404d7)
	{
		int num = c3829226c5ae6148b47389b84cd9404d7;
		float num2 = c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BulletDamageScale);
		float c740b3e55709408e0e5b39ade51a3a5e = c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.BulletDamagePostAdd);
		num = (int)((float)c3829226c5ae6148b47389b84cd9404d7 * num2) + PlayerSkillManage.c2dd18403fa78b17c55fa02287de38e78(c7513e66c4e0fc55e6fea9dd9cb8b9943(), c740b3e55709408e0e5b39ade51a3a5e);
		return c7cb1ac7f406fd6311968208ac9386b8b(num);
	}

	public int c7cb1ac7f406fd6311968208ac9386b8b(int c33f742e04718943de21771ec0860174d)
	{
		int result = c33f742e04718943de21771ec0860174d;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
			float num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0ebc9ff966482c92935f5b954e66a18b(c7513e66c4e0fc55e6fea9dd9cb8b9943());
			float num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5216004c85993c1fca7ac1d94a5ab8d1();
			float num3 = num2 / num;
			result = (int)((float)c33f742e04718943de21771ec0860174d * num3);
		}
		return result;
	}

	public int c9f4dd15e13b73ad690e986546c3286bc(int c2b01b9cb1d7aeff79a4a823499bdbb5f)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
					return (int)c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5216004c85993c1fca7ac1d94a5ab8d1();
				}
			}
		}
		return c2b01b9cb1d7aeff79a4a823499bdbb5f;
	}

	public void cdf1673221e3a3e5e9bb9d0d07224afc6(bool c594dd8ca7c622d4540270690b0e000d3)
	{
		MovementSync component = GetComponent<MovementSync>();
		if (!component)
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
			component.c284c367e9c4fb46c610a5744293d502e(c594dd8ca7c622d4540270690b0e000d3);
			return;
		}
	}

	public float c31f5ac6f3babc0f76033c98d84c1824e()
	{
		MovementSync component = GetComponent<MovementSync>();
		if ((bool)component)
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
					return component.m_LastCorrectDis;
				}
			}
		}
		return 0f;
	}
}
