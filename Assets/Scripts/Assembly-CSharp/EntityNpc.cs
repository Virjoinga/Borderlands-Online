using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using A;
using BHV;
using Core;
using UnityEngine;
using XsdSettings;

public class EntityNpc : Entity, AreaDamager, MeleeAttacker, SpitDamager, ChargeAttackDamager, KnockBackInterface
{
	public enum EntitySubType
	{
		None = 0,
		CHR_SkagAdult = 1,
		CHR_SkagAlpha = 2,
		CHR_SkagPup = 3,
		CHR_SkagSpitter = 4,
		CHR_SkagZilla = 5,
		CHR_BanditKiller = 6,
		CHR_BanditRaider = 7,
		CHR_BanditNineToes = 8,
		CHR_BanditBruiser = 9,
		CHR_BanditPsycho = 10,
		CHR_SpiderantWidowmaker = 11,
		CHR_BanditSuicidePsycho = 12,
		CHR_SpiderantWorker = 13,
		CHR_CrimsonLanceDefender = 14,
		CHR_GuardianWraith = 15,
		CHR_SpiderantTalos = 16,
		CHR_BadassVkag = 17,
		CHR_BadassBanditKiller = 18,
		CHR_BadassBanditPsycho = 19,
		CHR_CrimsonMechaKnoxx = 20,
		CHR_BadassSpiderantWorker = 21,
		CHR_BadassCrimsonLanceDefender = 22,
		CHR_BadassGuardianWraith = 23,
		CHR_Rakk = 24,
		CHR_MidgetShotgunner = 25,
		CHR_BanditScout = 26,
		CHR_SoldierTurretBasic = 27,
		CHR_CrimsonLanceMedic = 28,
		CHR_MedicalStation = 29,
		CHR_BanditApollyon = 30,
		CHR_CrimsonLanceInfantry = 31,
		CHR_CrimsonLanceSniper = 32,
		CHR_ArchAngel = 33,
		CHR_ClapTrapTutor = 34,
		CHR_TheInsane = 35,
		CHR_TheInsaneTentacle = 36,
		CHR_TheInsaneTentacleLarge = 37,
		CHR_Crabworm = 38
	}

	public enum EntityNpcFamilly
	{
		None = 0,
		Bandit = 1,
		Skag = 2,
		Spiderant = 3,
		Guardian = 4,
		Crimson = 5,
		Bird = 6,
		Turret = 7,
		Tutor = 8
	}

	public enum EntityNpcRank
	{
		Common = 0,
		Badass = 1,
		Boss = 2
	}

	protected const int m_juniorLevel = 12;

	protected const int m_midLevel = 12;

	protected const int m_seniorLevlel = 20;

	private EquipmentInventoryEntity m_equipment;

	private CollisionManager m_collisionManager;

	private int m_playerCountAtStartTime = 1;

	public string m_missionName = string.Empty;

	public EntitySubType m_subType;

	public EntityNpcFamilly m_npcFamilly;

	public int m_lowHPThreshold = 20;

	public bool m_alreadyLowHP;

	public EntityNpcRank m_npcRank;

	private float m_berserkAuraModifier = 1f;

	[HideInInspector]
	public GameObject m_attackTarget;

	[HideInInspector]
	public bool m_bHaveBeenAlerted;

	[HideInInspector]
	public int m_level = -1;

	[HideInInspector]
	public float m_accumulateHealPoint;

	public GameObject m_spawnObjPrefab;

	public GameObject[] m_spawnObjPrefabList;

	public Transform m_headTransform;

	public Transform m_rightHandWeaponSlot;

	public Transform m_leftHandWeaponSlot;

	public List<PassiveSkill> m_passiveSkill = new List<PassiveSkill>();

	private List<PassiveSkillSettings> m_passiveSkillSettings = new List<PassiveSkillSettings>();

	public int m_teamID = 255;

	private int m_lastHP;

	private int m_lastShield;

	private VFXManager m_vfxManager;

	private bool m_bHealEffect;

	private bool m_hasBerserkAura;

	private EntityStatusTracker m_statusTracker = new EntityStatusTracker();

	public StringBuilder m_appearName;

	public string m_localizedAppearName;

	private AIInventory m_aiInventory;

	private float m_speedRate_marked = 0.5f;

	public override int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		if (m_npcFamilly == EntityNpcFamilly.Tutor)
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
			m_level = 0;
		}
		else
		{
			m_level = m_equipment.c7513e66c4e0fc55e6fea9dd9cb8b9943();
		}
		ca9e31a41a3b3684196fd11113e6b1f48();
		return m_level;
	}

	public override bool c64c62b7b247792a393fc6789fd736232()
	{
		return true;
	}

	public override List<PassiveSkillType> c11d8925a1c6e53e1ad9411746fd14f72()
	{
		List<PassiveSkillType> list = new List<PassiveSkillType>();
		using (List<PassiveSkillSettings>.Enumerator enumerator = m_passiveSkillSettings.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PassiveSkillSettings current = enumerator.Current;
				list.Add(current.m_skillType);
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
				break;
			}
		}
		return list;
	}

	private void ca9e31a41a3b3684196fd11113e6b1f48()
	{
		if (m_appearName != null)
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
			m_appearName = new StringBuilder(m_name);
			if (m_level > 12)
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
				if (m_level <= 12)
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
					m_appearName.Append("_M");
					goto IL_0093;
				}
			}
			if (m_level > 12)
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
				m_appearName.Append("_L");
			}
			goto IL_0093;
			IL_0093:
			if ((m_equipment as EquipmentInventoryEntityNpc).m_bMissionNpc)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_localizedAppearName = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_missionName));
						return;
					}
				}
			}
			m_localizedAppearName = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_appearName.ToString()));
			return;
		}
	}

	public override string ca6bcee369aa6d4cdf126ebaeef6f6c73()
	{
		if (m_appearName == null)
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
			ca9e31a41a3b3684196fd11113e6b1f48();
		}
		return m_localizedAppearName;
	}

	public override float c51d604728b9ec2e83a3f2783582757e9()
	{
		float num = 1f;
		using (List<PassiveSkillSettings>.Enumerator enumerator = m_passiveSkillSettings.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PassiveSkillSettings current = enumerator.Current;
				if (current.m_skillType != PassiveSkillType.SpeedMultiplier)
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
				num *= current.m_multiplier;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return num;
			}
		}
	}

	public override EntityType c6420f67f9249b1d533531d9f351a36e0()
	{
		return EntityType.Npc;
	}

	public override bool cad418535912a1c3cb6ea0ce1e4cbd114()
	{
		if (m_subType == EntitySubType.CHR_BanditSuicidePsycho)
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
					return true;
				}
			}
		}
		return base.cad418535912a1c3cb6ea0ce1e4cbd114();
	}

	public static string[] c95e69186ffac00a7b6e6ea9e892c59b7()
	{
		return Enum.GetNames(typeof(EntitySubType));
	}

	public override int ceb10167333758220ffb9bc66317ad763()
	{
		return m_teamID;
	}

	public override AIInventory cdcf5e0592c05a681a8470f66674efd0b()
	{
		if (m_aiInventory == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_aiInventory = GetComponent<AIInventory>();
		}
		return m_aiInventory;
	}

	public override EntityWeapon c3941dac8608f650ceb15dc36294a741c()
	{
		AIInventory aIInventory = cdcf5e0592c05a681a8470f66674efd0b();
		if (aIInventory != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return aIInventory.m_weapon;
				}
			}
		}
		return null;
	}

	public override EntityShield c136b0f223897fdf01d18a9a5e3745433()
	{
		return c5ca38fad98337fc5c7255384b2cd1a86().cb4633378bdf6d47c409332e395d58c7a();
	}

	public override NavMeshAgent cb7fad43afb51f83d8698379136b46e95()
	{
		return GetComponent<NavMeshAgent>();
	}

	public override AnimationManager cb8119a2676bfbd4df00a9ed683eed91a()
	{
		return GetComponent<AnimationManagerFSM>();
	}

	public override EquipmentInventoryEntity c5ca38fad98337fc5c7255384b2cd1a86()
	{
		return m_equipment;
	}

	public override CollisionManager c63f8f07320313ddc4213cb59ee025962()
	{
		return m_collisionManager;
	}

	public override void Start()
	{
		m_equipment = GetComponent<EquipmentInventoryEntity>();
		m_collisionManager = GetComponent<CollisionManager>();
		base.Start();
		base.gameObject.SendMessage("OnSpawnCompleted", null, SendMessageOptions.DontRequireReceiver);
		c63f8f07320313ddc4213cb59ee025962().cd93285db16841148ed53a5bbeb35cf20(true);
		base.gameObject.layer = LayerMask.NameToLayer("Npc");
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new Melee());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new AreaDamage());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new SpitDamage());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new ChargeAttackDamage());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new KnockBack());
		if (m_entityMng != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			int num = m_entityMng.c6d037f57d903e6bcdcc24348eeefb88c(EntityType.Player);
			if (num > 0)
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
				m_playerCountAtStartTime = num;
			}
		}
		m_bHaveBeenAlerted = false;
		if (c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDAimTargetView>().cd2e48af5036f9af603d95eb723ef7beb(this);
		}
		m_vfxManager = GetComponentInChildren<VFXManager>();
		m_bHealEffect = false;
		m_lastShield = int.MaxValue;
		cbe69c00ee6a961f5e519fe230d87c736();
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.AI, "m_berserkAuraModifier " + m_berserkAuraModifier);
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestPassiveSkill", PhotonTargets.MasterClient, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cbe69c00ee6a961f5e519fe230d87c736()
	{
		if (m_subType == EntitySubType.CHR_SoldierTurretBasic)
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
			MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
			if (m_subType == EntitySubType.CHR_ClapTrapTutor)
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
				mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.NPC;
			}
			else
			{
				switch (m_npcRank)
				{
				case EntityNpcRank.Badass:
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.Badass;
					break;
				case EntityNpcRank.Common:
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.Enemy;
					break;
				case EntityNpcRank.Boss:
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.Boss;
					mapObjectMark.bAlwaysOnMap = true;
					break;
				}
			}
			mapObjectMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
			return;
		}
	}

	private void cc218ad58636009dc7d50dda395687abd(float c877048f03b7df9171f7903bb56ef8e24)
	{
	}

	[RPC]
	public void RPC_RequestPassiveSkill(PhotonMessageInfo info)
	{
	}

	[RPC]
	public void RPC_ApplyPassiveSkill(Hashtable passiveSkills)
	{
		m_passiveSkillSettings.Clear();
		for (int i = 0; i < passiveSkills.Count; i++)
		{
			PassiveSkillSettings passiveSkillSettings = new PassiveSkillSettings();
			Hashtable hashtable = passiveSkills[i] as Hashtable;
			passiveSkillSettings.m_multiplier = (float)hashtable[0];
			passiveSkillSettings.m_skillID = (int)hashtable[1];
			passiveSkillSettings.m_skillType = (PassiveSkillType)(byte)hashtable[2];
			m_passiveSkillSettings.Add(passiveSkillSettings);
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
			return;
		}
	}

	public void caf2f2c49a1b541303cab309672e28eee()
	{
	}

	public void c5253ca17ae006a22025093f8cafde97c()
	{
	}

	public void c278b0a14d216fb6b5a6e2cf8b8537984()
	{
	}

	public void ca2cff68dfdc43cd26e25f0f552101cf6()
	{
	}

	public override Vector3 c56fad5727ffebf48f3df62074cd1bbe6()
	{
		EntityWeapon entityWeapon = c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return entityWeapon.m_fireDirection;
				}
			}
		}
		return base.c56fad5727ffebf48f3df62074cd1bbe6();
	}

	public override Vector3 cad7880776eb7b2ddfb106102d4c51bbf()
	{
		EntityWeapon entityWeapon = c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return entityWeapon.m_fireOrigin;
				}
			}
		}
		return base.cad7880776eb7b2ddfb106102d4c51bbf();
	}

	private void c78041004f0f1867c8818572e9beb7016()
	{
	}

	public override void Update()
	{
		int num = ca2ff7a501878363cb1d5f0472e306620();
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
			if (num > 0)
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
				entityShield.cc0fea17131d6be72a517285b19e19d22();
				int num2 = ce7804365a7377021025c46a16aa79db4();
				int num3 = ca937003ba4cbf4130cad1fcc9da2873e();
				if (num2 > m_lastShield)
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
					if (num2 == num3)
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
						m_vfxManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_DamageShieldFull, base.transform.position);
					}
				}
				m_lastShield = num2;
			}
		}
		c78041004f0f1867c8818572e9beb7016();
		if (m_vfxManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_lastHP > 0)
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
				if (num > m_lastHP)
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
					Vector3 position = base.transform.position;
					position.y += m_entityHeight * 0.5f;
					m_vfxManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_NPC_Heal, position);
					m_bHealEffect = true;
					goto IL_0162;
				}
			}
			if (m_bHealEffect)
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
				m_bHealEffect = false;
				m_vfxManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_NPC_Heal);
			}
		}
		goto IL_0162;
		IL_0162:
		m_lastHP = num;
		EquipmentInventoryEntityNpc equipmentInventoryEntityNpc = m_equipment as EquipmentInventoryEntityNpc;
		if (!(equipmentInventoryEntityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (equipmentInventoryEntityNpc.cdf295658fa3a6f2070241c6edf06aef2)
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
				if (ca2ff7a501878363cb1d5f0472e306620() > 0)
				{
					if (!m_hasBerserkAura)
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
						if (m_vfxManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							Vector3 zero = Vector3.zero;
							zero.y = m_entityHeight - 1.8f;
							m_vfxManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_BerserkAura_Start, this, base.transform, zero, Quaternion.Euler(-90f, 0f, 0f), 2f);
							m_vfxManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_BerserkAura_Continue, this, base.transform, zero, Quaternion.Euler(-90f, 0f, 0f));
						}
					}
					m_hasBerserkAura = true;
					return;
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
			}
			if (m_hasBerserkAura)
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
				if (m_vfxManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_vfxManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_BerserkAura_Continue);
				}
			}
			m_hasBerserkAura = false;
			return;
		}
	}

	public override int cfa29f666f7b32a7317160b9de6838449()
	{
		return m_playerCountAtStartTime;
	}

	public bool c0d8ecc63ad8fe29b3f117731a4bc7949()
	{
		return m_bHaveBeenAlerted;
	}

	public override bool ce003fe849cc45b85ca4570109817c796()
	{
		BHVTaskManager bHVTaskManager = c9b6d1d87bef7b03dad787ff0031551ee();
		if (bHVTaskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		BHVTask bHVTask = bHVTaskManager.c2d51f6bc5c05cfbf476c30230c67b09e();
		if (bHVTask == null)
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
		int result;
		if (bHVTask.m_Type != BHVTaskType.Dead)
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
			result = ((bHVTask.m_Type == BHVTaskType.Die) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	[AudioParameterFunction]
	public string GetHurtState()
	{
		if (m_equipment == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return "Default";
				}
			}
		}
		if (m_equipment.ccfad1bf47b003333c5ddd084f14d33e7() == 0)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return "Default";
				}
			}
		}
		if (m_alreadyLowHP)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (100 * m_equipment.ca2ff7a501878363cb1d5f0472e306620() / m_equipment.ccfad1bf47b003333c5ddd084f14d33e7() > m_lowHPThreshold)
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
						m_alreadyLowHP = false;
					}
					return "Default";
				}
			}
		}
		if (100 * m_equipment.ca2ff7a501878363cb1d5f0472e306620() / m_equipment.ccfad1bf47b003333c5ddd084f14d33e7() < m_lowHPThreshold)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					m_alreadyLowHP = true;
					return "LowHP";
				}
			}
		}
		return "Default";
	}

	public override ENPCParticleType cfa1f39f0f16c281e2062553416590dbb(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		if (ce7804365a7377021025c46a16aa79db4() > 0)
		{
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
				c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_DamageShieldHit;
				return c6e9c05551eaa310c6fcb665b20682b9c;
			}
		}
		if (m_subType != EntitySubType.CHR_BadassCrimsonLanceDefender)
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
			if (m_subType != EntitySubType.CHR_CrimsonLanceDefender)
			{
				if (m_subType != EntitySubType.CHR_SpiderantWorker)
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
					if (m_subType != EntitySubType.CHR_BadassSpiderantWorker)
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
						if (m_subType != EntitySubType.CHR_SpiderantWidowmaker)
						{
							goto IL_00ff;
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
				}
				if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() != WeakPoint.StrengthType.Strong)
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
					if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() != WeakPoint.StrengthType.VeryStrong)
					{
						if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() != WeakPoint.StrengthType.Weak)
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
							if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() != 0)
							{
								goto IL_00ff;
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
						}
						return ENPCParticleType.E_DamagedBulletNone;
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
				return ENPCParticleType.E_DamageOnArmor;
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
		if (c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be() == WeakPoint.StrengthType.Indestructible)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return ENPCParticleType.E_DamageOnArmor;
				}
			}
		}
		goto IL_00ff;
		IL_00ff:
		return c6e9c05551eaa310c6fcb665b20682b9c;
	}

	public EntityNpcRank cacbe09dd8d5d8eaa8df1a1884004dfe2()
	{
		return m_npcRank;
	}

	public bool cb3c049644818b9981f10871585889e97()
	{
		return m_npcRank == EntityNpcRank.Badass;
	}

	public bool c90ea3a207cd50bba4ba7c81b9ff2bcb5()
	{
		return m_npcRank == EntityNpcRank.Boss;
	}

	public void c33277226bda920b3fbf5ed150f89ecd0(bool c8109f82e911a0735719244bed1c74928, int c19e024b5bcbd347892bec27154c527de)
	{
		if (c19e024b5bcbd347892bec27154c527de <= 0)
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
		DamageInfo c36964cf41281414170f34ee68bef6c = default(DamageInfo);
		c8347f10dea711681dd4ae9a2b7de6aeb.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.m_attackSubType = AttackSubType.Recover;
		c36964cf41281414170f34ee68bef6c.m_from = cc7403315505256d19a7b92aa614a8f10();
		c36964cf41281414170f34ee68bef6c.m_healthDamagePoints = c19e024b5bcbd347892bec27154c527de;
		EquipmentInventoryEntityNpc equipmentInventoryEntityNpc = c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityNpc;
		if (!(equipmentInventoryEntityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			equipmentInventoryEntityNpc.cb6ceb78f36080a0ffcced8be849ad7f3(c8109f82e911a0735719244bed1c74928);
			return;
		}
	}

	public override VFXManager ccdbbc6879c7efc53e81b9c2fbaceead9()
	{
		return m_vfxManager;
	}

	public override Vector3 c4c38fdc58f120e1209ca439fa8ee5818()
	{
		if (Mathf.Approximately(base.transform.position.x, m_snapOnGroundPosition.x))
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
			if (Mathf.Approximately(base.transform.position.z, m_snapOnGroundPosition.z))
			{
				while (true)
				{
					switch (4)
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
		float radius = 0.25f;
		Vector3 vector = base.transform.position + Vector3.up * entityHeight;
		RaycastHit hitInfo;
		if (Physics.SphereCast(vector, radius, Vector3.down, out hitInfo, 10f, 1 << LayerMask.NameToLayer("Walkable")))
		{
			while (true)
			{
				switch (3)
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

	public override string caee41037b4b1f78e0109e763f22a7a0c()
	{
		StringBuilder stringBuilder = new StringBuilder();
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = ca6bcee369aa6d4cdf126ebaeef6f6c73();
		array[1] = base.transform.position;
		array[2] = " HP";
		array[3] = ca2ff7a501878363cb1d5f0472e306620();
		stringBuilder.AppendLine(string.Concat(array));
		stringBuilder.Append(c9b6d1d87bef7b03dad787ff0031551ee().ToString());
		stringBuilder.Append(cb8119a2676bfbd4df00a9ed683eed91a().ToString());
		return stringBuilder.ToString();
	}

	protected override void Awake()
	{
		base.Awake();
		GetComponent<BHVTaskManager>().c6bb3d8c3bbcf29724a8c3bebc37fb458(m_subType);
		GetComponent<NPCAnimationManagerFSM>().c20e2314b46c8284e3ff42ed88515ca1e(m_subType);
	}

	public void c2752f2e288d1e93ed4cdbb91832ec547(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("KnockBack", true, c5d720f6d007abb0c4a21d6a654e405bb.cc7403315505256d19a7b92aa614a8f10());
	}

	public void ca9aa8e1a53a488affbcece4b7b8f7ee1(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		(c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer).c2752f2e288d1e93ed4cdbb91832ec547(this);
	}

	public override void cbb91e2330ed12a1942ead68e69e691a3(float c7877e67acd1ae62d246b5fb5e889a066)
	{
		AnimationManagerFSM component = GetComponent<AnimationManagerFSM>();
		if (c7877e67acd1ae62d246b5fb5e889a066 < 1f)
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
					component.c82680016189694aae7ffda7f93e20c78(c7877e67acd1ae62d246b5fb5e889a066);
					return;
				}
			}
		}
		component.c38e22188b18e8482a7c7b657c0db7eaf();
	}

	[RPC]
	private void RPC_DoSlowdown(float _rate, PhotonMessageInfo info)
	{
		AnimationManagerFSM component = GetComponent<AnimationManagerFSM>();
		if (_rate < 1f)
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
					component.c82680016189694aae7ffda7f93e20c78(_rate);
					return;
				}
			}
		}
		component.c38e22188b18e8482a7c7b657c0db7eaf();
	}

	public override void c49c490bcb316f43984756f2360518e6c(bool c8678fc7ce74e7101a14c28cf81451c7e)
	{
		AnimationManagerFSM component = GetComponent<AnimationManagerFSM>();
		if (c8678fc7ce74e7101a14c28cf81451c7e)
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
					component.c82680016189694aae7ffda7f93e20c78(m_speedRate_marked);
					return;
				}
			}
		}
		component.c38e22188b18e8482a7c7b657c0db7eaf();
	}
}
