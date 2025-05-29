using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using A;
using BHV;
using BHV_Anim;
using UnityEngine;

public class AIServiceSetting
{
	private static readonly AIServiceSetting s_instance = new AIServiceSetting();

	public Dictionary<uint, Dictionary<Type, BHVTaskSettings>> m_settingList = new Dictionary<uint, Dictionary<Type, BHVTaskSettings>>();

	public List<string> m_npcTaskSettingLoadedList = new List<string>();

	public Dictionary<uint, BHVAnimationManagerSetup> m_npcAnimationMgrSetupList = new Dictionary<uint, BHVAnimationManagerSetup>();

	private Dictionary<BHVTaskType, BHVTask> m_taskLUT = new Dictionary<BHVTaskType, BHVTask>();

	private Dictionary<string, ce972fd150f340044b329bd2758a9cacc> m_animStateList = new Dictionary<string, ce972fd150f340044b329bd2758a9cacc>();

	public XmlSerializer m_taskSerializer = new XmlSerializer(Type.GetTypeFromHandle(c0df1bd2508f45684adda5bf4c1dca6f0.cc1720d05c75832f704b87474932341c3()));

	public XmlSerializer m_animationSerializer = new XmlSerializer(Type.GetTypeFromHandle(c36e3e023af707323655c1243da28d687.cc1720d05c75832f704b87474932341c3()));

	public static AIServiceSetting c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private AIServiceSetting()
	{
	}

	public void c9ee8cfaa6e149322d3e55ae5ead97ebf()
	{
		TextAsset c7088de59e49f7108f520cf7e0bae167e = c83605b31ccc1890819799ea0ccf10caf.c7088de59e49f7108f520cf7e0bae167e;
		string c7088de59e49f7108f520cf7e0bae167e2 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		string c7088de59e49f7108f520cf7e0bae167e3 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		uint num = 0u;
		XmlNodeList xmlNodeList = LevelLoadingManager.MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectNodes("NPCSetting/NPC/@value");
		for (int i = 0; i < xmlNodeList.Count; i++)
		{
			c7088de59e49f7108f520cf7e0bae167e3 = xmlNodeList[i].Value.Replace("_L", string.Empty);
			c7088de59e49f7108f520cf7e0bae167e3 = c7088de59e49f7108f520cf7e0bae167e3.Replace("_M", string.Empty);
			num = 0u;
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "Entities/Npc/";
			array[1] = c7088de59e49f7108f520cf7e0bae167e3;
			array[2] = "/Config_";
			array[3] = c7088de59e49f7108f520cf7e0bae167e3;
			array[4] = "_TaskManager";
			c7088de59e49f7108f520cf7e0bae167e2 = string.Concat(array);
			c7088de59e49f7108f520cf7e0bae167e = Resources.Load<TextAsset>(c7088de59e49f7108f520cf7e0bae167e2);
			if (c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c8db800cfdf1a5889ecd7b1fd2e8e2078(c7088de59e49f7108f520cf7e0bae167e3, c7088de59e49f7108f520cf7e0bae167e.text, ref num);
			}
			if (num == 0)
			{
				continue;
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
			string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array2[0] = "Entities/Npc/";
			array2[1] = c7088de59e49f7108f520cf7e0bae167e3;
			array2[2] = "/Config_";
			array2[3] = c7088de59e49f7108f520cf7e0bae167e3;
			array2[4] = "_AnimationManager";
			c7088de59e49f7108f520cf7e0bae167e2 = string.Concat(array2);
			c7088de59e49f7108f520cf7e0bae167e = Resources.Load<TextAsset>(c7088de59e49f7108f520cf7e0bae167e2);
			if (!(c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
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
			c43526fac186d9cb69a8e57e1f0352993(num, c7088de59e49f7108f520cf7e0bae167e.text);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (m_taskLUT.Count == 0)
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
				m_taskLUT.Add(BHVTaskType.Idle, new BHVTaskIdle());
				m_taskLUT.Add(BHVTaskType.MoveTo, new BHVTaskMoveTo());
				m_taskLUT.Add(BHVTaskType.Die, new BHVTaskDie());
				m_taskLUT.Add(BHVTaskType.Dead, new BHVTaskDead());
				m_taskLUT.Add(BHVTaskType.DazeEffect, new BHVTaskDazeEffect());
				m_taskLUT.Add(BHVTaskType.LightHurt, new BHVTaskLightHurt());
				m_taskLUT.Add(BHVTaskType.Alert, new BHVTaskAlert());
				m_taskLUT.Add(BHVTaskType.TurnTo, new BHVTaskTurnTo());
				m_taskLUT.Add(BHVTaskType.Respawn, new BHVTaskRespawn());
				m_taskLUT.Add(BHVTaskType.MoveWithFacing, new BHVTaskMoveWithFacing());
				m_taskLUT.Add(BHVTaskType.Fire, new BHVTaskFire());
				m_taskLUT.Add(BHVTaskType.CoverIdle, new BHVTaskCoverIdle());
				m_taskLUT.Add(BHVTaskType.CoverFire, new BHVTaskCoverFire());
				m_taskLUT.Add(BHVTaskType.CoverFireIdle, new BHVTaskCoverFireIdle());
				m_taskLUT.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
				m_taskLUT.Add(BHVTaskType.Reload, new BHVTaskReload());
				m_taskLUT.Add(BHVTaskType.CoverReload, new BHVTaskCoverReload());
				m_taskLUT.Add(BHVTaskType.CoverPeakOut, new BHVTaskCoverPeakOut());
				m_taskLUT.Add(BHVTaskType.CoverPeakIn, new BHVTaskCoverPeakIn());
				m_taskLUT.Add(BHVTaskType.CoverLookAround, new BHVTaskCoverLookAround());
				m_taskLUT.Add(BHVTaskType.Hurt, new BHVTaskHurt());
				m_taskLUT.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
				m_taskLUT.Add(BHVTaskType.Roll, new BHVTaskRoll());
				m_taskLUT.Add(BHVTaskType.SideStep, new BHVTaskSideStep());
				m_taskLUT.Add(BHVTaskType.Warning, new BHVTaskWarning());
				m_taskLUT.Add(BHVTaskType.Suicide, new BHVTaskSuicide());
				m_taskLUT.Add(BHVTaskType.JumpAttack, new BHVTaskJumpAttack());
				m_taskLUT.Add(BHVTaskType.JumpAttackLand, new BHVTaskJumpAttackLand());
				m_taskLUT.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
				m_taskLUT.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
				m_taskLUT.Add(BHVTaskType.Warcry, new BHVTaskWarcry());
				m_taskLUT.Add(BHVTaskType.Spit, new BHVTaskSpit());
				m_taskLUT.Add(BHVTaskType.Spawn, new BHVTaskSpawn());
				m_taskLUT.Add(BHVTaskType.Stunned, new BHVTaskStunned());
			}
			if (m_animStateList.Count != 0)
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
				m_animStateList.Add("Idle", new AnimationIdleState());
				m_animStateList.Add("Die", new AnimationDieState());
				m_animStateList.Add("Dead", new AnimationDeadState());
				m_animStateList.Add("Alert", new AnimationAlertState());
				m_animStateList.Add("TurnTo", new AnimationTurnToState());
				m_animStateList.Add("Move", new AnimationMoveState());
				m_animStateList.Add("Hurt", new AnimationHurtState());
				m_animStateList.Add("JumpAttack", new AnimationJumpAttackState());
				m_animStateList.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
				m_animStateList.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
				m_animStateList.Add("CombatSpawn", new AnimationCombatSpawnState());
				m_animStateList.Add("MeleeAttack", new AnimationMeleeAttackState());
				m_animStateList.Add("Warcry", new AnimationWarcryState());
				m_animStateList.Add("Charge", new AnimationChargeState());
				m_animStateList.Add("ChargeHit", new AnimationChargeHitState());
				m_animStateList.Add("MoveWithFacing", new AnimationMoveWithFacingState());
				m_animStateList.Add("CoverIdleBeforeFire", new AnimationCoverIdleBeforeFireState());
				m_animStateList.Add("CoverIdle", new AnimationCoverIdleState());
				m_animStateList.Add("CoverLookAround", new AnimationCoverLookAroundState());
				m_animStateList.Add("CoverPeakIn", new AnimationCoverPeakInState());
				m_animStateList.Add("CoverPeakOut", new AnimationCoverPeakOutState());
				m_animStateList.Add("Roll", new AnimationRollState());
				m_animStateList.Add("Warning", new AnimationWarningState());
				m_animStateList.Add("Fire", new AnimationFireState());
				m_animStateList.Add("Reload", new AnimationReloadState());
				m_animStateList.Add("CoverFire", new AnimationCoverFireState());
				m_animStateList.Add("CoverReload", new AnimationCoverReloadState());
				m_animStateList.Add("Empty", new AnimationEmptyState());
				m_animStateList.Add("Stun", new AnimationStunState());
				m_animStateList.Add("Spawn", new AnimationSpawnState());
				return;
			}
		}
	}

	public bool c43526fac186d9cb69a8e57e1f0352993(uint c875cb4aedab4dbd285f491b3440727ec, string ce6be564ae39a9af3aff0a170d981d7b6)
	{
		if (c5ee19dc8d4cccf5ae2de225410458b86.m_npcAnimationMgrSetupList.ContainsKey(c875cb4aedab4dbd285f491b3440727ec))
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
					return true;
				}
			}
		}
		BHVAnimationManagerSetup value = c9699e0d21f3747b218c6cea7c1498488.c7088de59e49f7108f520cf7e0bae167e;
		StringReader textReader = new StringReader(ce6be564ae39a9af3aff0a170d981d7b6);
		if (m_animationSerializer != null)
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
			value = m_animationSerializer.Deserialize(textReader) as BHVAnimationManagerSetup;
		}
		c5ee19dc8d4cccf5ae2de225410458b86.m_npcAnimationMgrSetupList.Add(c875cb4aedab4dbd285f491b3440727ec, value);
		return true;
	}

	public bool c8db800cfdf1a5889ecd7b1fd2e8e2078(string cba1be6d72b8313db99be2b558066eafc, string ce6be564ae39a9af3aff0a170d981d7b6, ref uint c875cb4aedab4dbd285f491b3440727ec)
	{
		if (m_npcTaskSettingLoadedList.Contains(cba1be6d72b8313db99be2b558066eafc))
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
					return true;
				}
			}
		}
		BHVTaskManagerSetup bHVTaskManagerSetup = c1f7119e9beef47c3d1dee9e146ed6d76.c7088de59e49f7108f520cf7e0bae167e;
		StringReader textReader = new StringReader(ce6be564ae39a9af3aff0a170d981d7b6);
		if (m_taskSerializer != null)
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
			bHVTaskManagerSetup = m_taskSerializer.Deserialize(textReader) as BHVTaskManagerSetup;
		}
		Dictionary<Type, BHVTaskSettings> dictionary = new Dictionary<Type, BHVTaskSettings>();
		int num = bHVTaskManagerSetup.m_settings.Length;
		for (int i = 0; i < num; i++)
		{
			dictionary.Add(bHVTaskManagerSetup.m_settings[i].GetType(), bHVTaskManagerSetup.m_settings[i]);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			c875cb4aedab4dbd285f491b3440727ec = Utility.cf642a65627df2adf4e90330457651907(bHVTaskManagerSetup.m_entityType);
			m_settingList.Add(c875cb4aedab4dbd285f491b3440727ec, dictionary);
			m_npcTaskSettingLoadedList.Add(cba1be6d72b8313db99be2b558066eafc);
			return true;
		}
	}

	public void cf2f713d2eb507941299440866f1f376e(EntityNpc.EntitySubType c22a75c71fa78ee19ac7d9915d41a0c01, Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Idle, new BHVTaskIdle());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MoveTo, new BHVTaskMoveTo());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Die, new BHVTaskDie());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Dead, new BHVTaskDead());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.DazeEffect, new BHVTaskDazeEffect());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.LightHurt, new BHVTaskLightHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Alert, new BHVTaskAlert());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.TurnTo, new BHVTaskTurnTo());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Respawn, new BHVTaskRespawn());
		switch (c22a75c71fa78ee19ac7d9915d41a0c01)
		{
		case EntityNpc.EntitySubType.CHR_BanditKiller:
		case EntityNpc.EntitySubType.CHR_BanditRaider:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceInfantry:
			c645b4c76ca57965ba06a8532f268818c(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BanditScout:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceSniper:
			ca2ca83ba5da96861d1f5a2eac6249b1b(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BadassBanditKiller:
			c47ab651fdb5a6c1f1cf1e80ad9d513f4(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BanditPsycho:
		case EntityNpc.EntitySubType.CHR_BanditSuicidePsycho:
			c49160197b44c00f55af003b6f79020dc(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BadassBanditPsycho:
			cbd091e596aeeaca271af4cd8152f534c(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceDefender:
		case EntityNpc.EntitySubType.CHR_BadassCrimsonLanceDefender:
			c5e303a660380062606c21af9157ddce8(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_GuardianWraith:
			cd5634d968410f8d754970a06fd1d050c(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BadassGuardianWraith:
			c9a435c88e63611400b79a8791229d045(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_ArchAngel:
			cfaebfa638aef761adc429645bf328d64(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWorker:
		case EntityNpc.EntitySubType.CHR_BadassSpiderantWorker:
			ca12d572fbf4fb6b9d778cf30ad370be8(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SkagAdult:
		case EntityNpc.EntitySubType.CHR_SkagAlpha:
		case EntityNpc.EntitySubType.CHR_SkagPup:
		case EntityNpc.EntitySubType.CHR_BadassVkag:
			c8d6220b66747fc14cf192fd77c720874(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SkagSpitter:
			cb0bd35a91c049215d6db13ae4ba0ddbc(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SkagZilla:
			c7863db78dd8ec6bf15b35078ae96f875(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BanditApollyon:
			c8538c2857c1505271923089d2e7efdc7(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BanditBruiser:
			c479e1825a6fb6904b05a92a3cfafb0a8(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceMedic:
			ce46d4bf5739a065b7be1f23ba372abf2(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx:
			cb0da5e8143dadbd476cfbea79b05a061(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_MedicalStation:
			c2cc862a35800fcce2a7b0194f9469bad(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_MidgetShotgunner:
			c31db37502734df581a009c4b32965f47(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_Rakk:
			c47f1291ebba9399fa67e2a2893ee25f6(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SoldierTurretBasic:
			c81c9e636aa1884a8eb0f03c79f4a1ea5(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantTalos:
			c7bf75551e13c79435cc63fc4b7d74034(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWidowmaker:
			cd54c567414ffd780f8f6191a6f2fe7b1(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_ClapTrapTutor:
			c964bb349e51723bdb963ad1f03166991(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsane:
			cf7e5c267e465b2f0976a014da2b1b938(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacle:
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacleLarge:
			cb8a29475404261c4fda732b1b2c3f7d4(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_Crabworm:
			cd81dc238461e0744dab957761d6d1376(c3521c9096ab7c30ece57e61bdb8622f2);
			break;
		case EntityNpc.EntitySubType.CHR_BanditNineToes:
			break;
		}
	}

	public void cd81dc238461e0744dab957761d6d1376(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.DrillAttack, new BHVTaskDrillAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.UndergroundIdle, new BHVTaskUndergroundIdle());
	}

	public void c645b4c76ca57965ba06a8532f268818c(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MoveWithFacing, new BHVTaskMoveWithFacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverIdle, new BHVTaskCoverIdle());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverFire, new BHVTaskCoverFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverFireIdle, new BHVTaskCoverFireIdle());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverReload, new BHVTaskCoverReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverPeakOut, new BHVTaskCoverPeakOut());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverPeakIn, new BHVTaskCoverPeakIn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverLookAround, new BHVTaskCoverLookAround());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Roll, new BHVTaskRoll());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.SideStep, new BHVTaskSideStep());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warning, new BHVTaskWarning());
	}

	public void ca2ca83ba5da96861d1f5a2eac6249b1b(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c645b4c76ca57965ba06a8532f268818c(c3521c9096ab7c30ece57e61bdb8622f2);
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AimingTarget, new BHVTaskAimingTarget());
	}

	public void c47ab651fdb5a6c1f1cf1e80ad9d513f4(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c645b4c76ca57965ba06a8532f268818c(c3521c9096ab7c30ece57e61bdb8622f2);
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ThrowAttack, new BHVTaskThrowAttack());
	}

	public void c49160197b44c00f55af003b6f79020dc(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Suicide, new BHVTaskSuicide());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
	}

	public void cbd091e596aeeaca271af4cd8152f534c(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c49160197b44c00f55af003b6f79020dc(c3521c9096ab7c30ece57e61bdb8622f2);
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ThrowAttack, new BHVTaskThrowAttack());
	}

	public void c5e303a660380062606c21af9157ddce8(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MoveWithFacing, new BHVTaskMoveWithFacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.SideStep, new BHVTaskSideStep());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warning, new BHVTaskWarning());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
	}

	public void cd5634d968410f8d754970a06fd1d050c(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.SlideMoveTo, new BHVTaskSlideMoveTo());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Roll, new BHVTaskRoll());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.SideStep, new BHVTaskSideStep());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ShowWeapon, new BHVTaskShowWeapon());
	}

	public void c9a435c88e63611400b79a8791229d045(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		cd5634d968410f8d754970a06fd1d050c(c3521c9096ab7c30ece57e61bdb8622f2);
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Teleport, new BHVTaskTeleport());
	}

	public void cfaebfa638aef761adc429645bf328d64(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CircleMove, new BHVTaskCircleMove());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Teleport, new BHVTaskTeleport());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.EnergyBlast, new BHVTaskEnergyBlast());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.EnergyMissile, new BHVTaskEnergyMissile());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.DeathStruggle, new BHVTaskDeathStruggle());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
	}

	public void ca12d572fbf4fb6b9d778cf30ad370be8(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttack, new BHVTaskJumpAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttackLand, new BHVTaskJumpAttackLand());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spawn, new BHVTaskSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Stunned, new BHVTaskStunned());
	}

	public void c8d6220b66747fc14cf192fd77c720874(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttack, new BHVTaskJumpAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttackLand, new BHVTaskJumpAttackLand());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warcry, new BHVTaskWarcry());
	}

	public void cb0bd35a91c049215d6db13ae4ba0ddbc(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spit, new BHVTaskSpit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warcry, new BHVTaskWarcry());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
	}

	public void c7863db78dd8ec6bf15b35078ae96f875(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warcry, new BHVTaskWarcry());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpOnTheSpotAttack, new BHVTaskJumpOnTheSpotAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
	}

	public void c8538c2857c1505271923089d2e7efdc7(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.HammerAttack, new BHVTaskHammerAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MoveWithFacing, new BHVTaskMoveWithFacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warning, new BHVTaskWarning());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.HammerJumpAttack, new BHVTaskHammerJumpAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.LavaStrike, new BHVTaskLavaStrike());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
	}

	public void c479e1825a6fb6904b05a92a3cfafb0a8(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MoveWithFacing, new BHVTaskMoveWithFacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warning, new BHVTaskWarning());
	}

	public void ce46d4bf5739a065b7be1f23ba372abf2(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.SideStep, new BHVTaskSideStep());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warning, new BHVTaskWarning());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.DeployAidStation, new BHVTaskDeployAidStation());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MoveWithFacing, new BHVTaskMoveWithFacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverIdle, new BHVTaskCoverIdle());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverFire, new BHVTaskCoverFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverFireIdle, new BHVTaskCoverFireIdle());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverReload, new BHVTaskCoverReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverPeakOut, new BHVTaskCoverPeakOut());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverPeakIn, new BHVTaskCoverPeakIn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.CoverLookAround, new BHVTaskCoverLookAround());
	}

	public void cb0da5e8143dadbd476cfbea79b05a061(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warning, new BHVTaskWarning());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttack, new BHVTaskJumpAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttackLand, new BHVTaskJumpAttackLand());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.TurnOnSpot, new BHVTaskTurnOnSpot());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spacing, new BHVTaskSpacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Critical, new BHVTaskCritical());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.RailgunAttack, new BHVTaskRailgunAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MortarAttack, new BHVTaskMortarAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JetAttack, new BHVTaskJetAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.DestoryMissile, new BHVTaskDestoryMissile());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.LaserSweep, new BHVTaskLaserSweep());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Recharge, new BHVTaskRecharge());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
	}

	public void c2cc862a35800fcce2a7b0194f9469bad(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spawn, new BHVTaskSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.MoveTo);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.DazeEffect);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.LightHurt);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.Alert);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.TurnTo);
	}

	public void c31db37502734df581a009c4b32965f47(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Fire, new BHVTaskFire());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Reload, new BHVTaskReload());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.AdvanceSpawn, new BHVTaskAdvanceSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.FireFullBody, new BHVTaskFireFullBody());
	}

	public void c47f1291ebba9399fa67e2a2893ee25f6(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.HoverPatrol, new BHVTaskHoverPatrol());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.FlyMeleeAttack, new BHVTaskFlyMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.FlyGather, new BHVTaskFlyGather());
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.MoveTo);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.Alert);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.TurnTo);
	}

	public void c81c9e636aa1884a8eb0f03c79f4a1ea5(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.RocketAttack, new BHVTaskRocketAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.FireFullBody, new BHVTaskFireFullBody());
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.MoveTo);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.DazeEffect);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.LightHurt);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.Alert);
		c3521c9096ab7c30ece57e61bdb8622f2.Remove(BHVTaskType.TurnTo);
	}

	public void c7bf75551e13c79435cc63fc4b7d74034(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spacing, new BHVTaskSpacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.IceEarthquakeAttack, new BHVTaskIceEarthquakeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.IceMeteorAttack, new BHVTaskIceMeteorAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.EarthPikeAttack, new BHVTaskEarthPikeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spawn, new BHVTaskSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warcry, new BHVTaskWarcry());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Stunned, new BHVTaskStunned());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.SummonExtraNPC, new BHVTaskSummonExtraNPC());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.DestoryMissile, new BHVTaskDestoryMissile());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
	}

	public void cd54c567414ffd780f8f6191a6f2fe7b1(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttack, new BHVTaskJumpAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.JumpAttackLand, new BHVTaskJumpAttackLand());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttack, new BHVTaskChargeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.ChargeAttackHit, new BHVTaskChargeAttackHit());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spacing, new BHVTaskSpacing());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.BurrowAttack, new BHVTaskBurrowAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Critical, new BHVTaskCritical());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spawn, new BHVTaskSpawn());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Warcry, new BHVTaskWarcry());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Stunned, new BHVTaskStunned());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.RadiusAttack, new BHVTaskRadiusAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.WebTrap, new BHVTaskWebTrap());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
	}

	public void c964bb349e51723bdb963ad1f03166991(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.TutorialLesson, new BHVTaskTutorialLesson());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.TutorialAction, new BHVTaskTutorialAction());
	}

	public void cf7e5c267e465b2f0976a014da2b1b938(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.EyeLaser, new BHVTaskEyeLaser());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.EyeLaserPlus, new BHVTaskEyeLaserPlus());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.PlayerTeleport, new BHVTaskPlayerTeleport());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Hurt, new BHVTaskHurt());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Disabled, new BHVTaskDisabled());
	}

	public void cb8a29475404261c4fda732b1b2c3f7d4(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.MeleeAttack, new BHVTaskMeleeAttack());
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Spawn, new BHVTaskSpawn());
	}

	public void c3e8b1cf5056bc530491730c7a01bb983(EntityNpc.EntitySubType c22a75c71fa78ee19ac7d9915d41a0c01, NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Idle", new AnimationIdleState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Die", new AnimationDieState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Dead", new AnimationDeadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Alert", new AnimationAlertState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("TurnTo", new AnimationTurnToState());
		switch (c22a75c71fa78ee19ac7d9915d41a0c01)
		{
		case EntityNpc.EntitySubType.CHR_SkagAdult:
		case EntityNpc.EntitySubType.CHR_SkagAlpha:
		case EntityNpc.EntitySubType.CHR_SkagPup:
		case EntityNpc.EntitySubType.CHR_BadassVkag:
			c0ff1ef97f8e3edd1b2a95d3f57ba4279(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BanditKiller:
		case EntityNpc.EntitySubType.CHR_BanditRaider:
		case EntityNpc.EntitySubType.CHR_BanditScout:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceInfantry:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceSniper:
			cdc8d187526113b1f11af000168616c58(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BadassBanditKiller:
			c679960917d218808493db5ab9573b582(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BanditBruiser:
			cce79b5144c980f18e20fe1e83d90189d(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceDefender:
		case EntityNpc.EntitySubType.CHR_BadassCrimsonLanceDefender:
			c79ca8355620118c9ce2733873f4537da(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceMedic:
			cb71ea57e0c465326f601d838f3fbc0e1(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BanditPsycho:
		case EntityNpc.EntitySubType.CHR_BanditSuicidePsycho:
			c5eaff2d5df7b93c1a81f59287ead767c(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BadassBanditPsycho:
			c5264c66789223f57a382c54d86e43203(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWorker:
		case EntityNpc.EntitySubType.CHR_BadassSpiderantWorker:
			c7bcc194eace947fb4eb89b89010e8098(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_GuardianWraith:
		case EntityNpc.EntitySubType.CHR_BadassGuardianWraith:
			cfe728e59ae0161887a666ec816b8a41b(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_ArchAngel:
			c11ed0e332fdb5ef37195169e7d5411e9(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_SkagSpitter:
			cbddd21fd452c32c73d86d9f90d365f75(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_SkagZilla:
			c99178517de1582bb0543eb32daec8ca6(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_MedicalStation:
			cd7d3dda3af9e5d82f76520df4e464f7c(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_MidgetShotgunner:
			cbf2b436ccdc8552c6d6a1da350c23c76(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_Rakk:
			cef343b24f197805df3d3f1323412a1c2(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_SoldierTurretBasic:
			c2fbf37d735c5462e358b7806ee1bdb44(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BanditApollyon:
			ce5749f7af29fb0a1fa011f95d7efd87a(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx:
			cffbc38387a4dd317deea42972bdbc1a6(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantTalos:
			cd4b69c837e951a0a6367ed16272960aa(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWidowmaker:
			c72d0c1bf6fe0c04206707cf39bf2c9dc(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_ClapTrapTutor:
			ce62fd18ec44bc99dbc959b49620cdd42(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsane:
			cb512d5b64c51b15f2bef78332a896c2c(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacle:
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacleLarge:
			cef2739114c38966b42b2ef6b893de1a3(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_Crabworm:
			c80971ce4f140a34dae243c90004759db(c2cf02d66b3019ca523c0e8a23d59a336);
			break;
		case EntityNpc.EntitySubType.CHR_BanditNineToes:
			break;
		}
	}

	public void c0ff1ef97f8e3edd1b2a95d3f57ba4279(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttack", new AnimationJumpAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warcry", new AnimationWarcryState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Charge", new AnimationChargeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ChargeHit", new AnimationChargeHitState());
	}

	public void cbddd21fd452c32c73d86d9f90d365f75(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warcry", new AnimationWarcryState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spit", new AnimationSpitState());
	}

	public void c99178517de1582bb0543eb32daec8ca6(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warcry", new AnimationWarcryState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpOnSpot", new AnimationJumpOnSpotState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Charge", new AnimationChargeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ChargeHit", new AnimationChargeHitState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
	}

	public void c7bcc194eace947fb4eb89b89010e8098(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Stun", new AnimationStunState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttack", new AnimationJumpAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spawn", new AnimationSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Charge", new AnimationChargeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ChargeHit", new AnimationChargeHitState());
	}

	public void c5eaff2d5df7b93c1a81f59287ead767c(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("SuicideBomb", new AnimationSuicideBombState());
	}

	public void c5264c66789223f57a382c54d86e43203(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c5eaff2d5df7b93c1a81f59287ead767c(c2cf02d66b3019ca523c0e8a23d59a336);
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ThrowWeapon", new AnimationThrowWeaponState());
	}

	public void c79ca8355620118c9ce2733873f4537da(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Roll", new AnimationRollState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warning", new AnimationWarningState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Fire", new AnimationFireState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Reload", new AnimationReloadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Empty", new AnimationEmptyState());
	}

	public void cdc8d187526113b1f11af000168616c58(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverIdleBeforeFire", new AnimationCoverIdleBeforeFireState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverIdle", new AnimationCoverIdleState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverLookAround", new AnimationCoverLookAroundState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverPeakIn", new AnimationCoverPeakInState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverPeakOut", new AnimationCoverPeakOutState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Roll", new AnimationRollState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warning", new AnimationWarningState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Fire", new AnimationFireState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Reload", new AnimationReloadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverFire", new AnimationCoverFireState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CoverReload", new AnimationCoverReloadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Empty", new AnimationEmptyState());
	}

	public void c679960917d218808493db5ab9573b582(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		cdc8d187526113b1f11af000168616c58(c2cf02d66b3019ca523c0e8a23d59a336);
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ThrowWeapon", new AnimationThrowWeaponState());
	}

	public void cb71ea57e0c465326f601d838f3fbc0e1(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		cdc8d187526113b1f11af000168616c58(c2cf02d66b3019ca523c0e8a23d59a336);
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("DeployAidStation", new AnimationDeployAidStationState());
	}

	public void cce79b5144c980f18e20fe1e83d90189d(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warning", new AnimationWarningState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Fire", new AnimationFireState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Reload", new AnimationReloadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Empty", new AnimationEmptyState());
	}

	public void cfe728e59ae0161887a666ec816b8a41b(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("SlideMove", new AnimationSlideMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ShowWeapon", new AnimationShowWeaponState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ThrowWeapon", new AnimationThrowWeaponState());
	}

	public void c11ed0e332fdb5ef37195169e7d5411e9(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CircleMove", new AnimationCircleMoveState());
	}

	public void cd7d3dda3af9e5d82f76520df4e464f7c(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spawn", new AnimationSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Remove("Alert");
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Remove("TurnTo");
	}

	public void cbf2b436ccdc8552c6d6a1da350c23c76(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("FireFullBody", new AnimationFireFullBodyState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Reload", new AnimationReloadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Empty", new AnimationEmptyState());
	}

	public void cef343b24f197805df3d3f1323412a1c2(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("HoverPatrol", new AnimationHoverPatrolState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("FlyGather", new AnimationFlyGatherState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("FlyMeleeAttack", new AnimationFlyMeleeAttackState());
	}

	public void c2fbf37d735c5462e358b7806ee1bdb44(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("FireFullBody", new AnimationFireFullBodyState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Remove("Alert");
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Remove("TurnTo");
	}

	public void ce5749f7af29fb0a1fa011f95d7efd87a(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warning", new AnimationWarningState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttack", new AnimationJumpAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("LavaStrike", new AnimationLavaStrikeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Fire", new AnimationFireState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Reload", new AnimationReloadState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Empty", new AnimationEmptyState());
	}

	public void cffbc38387a4dd317deea42972bdbc1a6(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warning", new AnimationWarningState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttack", new AnimationJumpAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Charge", new AnimationChargeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ChargeHit", new AnimationChargeHitState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spacing", new AnimationSpacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("RailgunAttack", new AnimationRailgunAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MortarAttack", new AnimationMortarAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("TurnOnSpot", new AnimationTurnOnSpotState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("LaserSweep", new AnimationLaserSweepState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Critical", new AnimationCriticalState());
	}

	public void cd4b69c837e951a0a6367ed16272960aa(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spawn", new AnimationSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Stun", new AnimationStunState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spacing", new AnimationSpacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("RadiusAttack", new AnimationRadiusAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("IceMeteorAttack", new AnimationIceMeteorAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Charge", new AnimationChargeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ChargeHit", new AnimationChargeHitState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("SummonExtraNPC", new AnimationSummonExtraNPCState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warcry", new AnimationWarcryState());
	}

	public void c72d0c1bf6fe0c04206707cf39bf2c9dc(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spawn", new AnimationSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("CombatSpawn", new AnimationCombatSpawnState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Stun", new AnimationStunState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spacing", new AnimationSpacingState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttack", new AnimationJumpAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("RadiusAttack", new AnimationRadiusAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Burrow", new AnimationBurrowState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Charge", new AnimationChargeState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("ChargeHit", new AnimationChargeHitState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Critical", new AnimationCriticalState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Warcry", new AnimationWarcryState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("WebTrap", new AnimationWebTrapState());
	}

	public void ce62fd18ec44bc99dbc959b49620cdd42(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("TutorialLesson", new AnimationTutorialLessonState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("TutorialAction", new AnimationTutorialActionState());
	}

	public void cb512d5b64c51b15f2bef78332a896c2c(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Hurt", new AnimationHurtState());
	}

	public void cef2739114c38966b42b2ef6b893de1a3(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spawn", new AnimationSpawnState());
	}

	public void c80971ce4f140a34dae243c90004759db(NPCAnimationManagerFSM c2cf02d66b3019ca523c0e8a23d59a336)
	{
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Move", new AnimationMoveState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("MeleeAttack", new AnimationMeleeAttackState());
		c2cf02d66b3019ca523c0e8a23d59a336.m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.Add("Spawn", new AnimationSpawnState());
	}
}
