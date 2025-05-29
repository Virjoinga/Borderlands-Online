using System;
using System.Reflection;
using A;

internal class AutoTestTable
{
	public string[] m_testCases;

	public string[] m_loadLevel;

	public string[] m_empty;

	public string[] m_oneInvulnerablePlayerStanding;

	public string[] m_twoInvulnerablePlayersStanding;

	public string[] m_threeInvulnerablePlayersStanding;

	public string[] m_fourInvulnerablePlayersStanding;

	public string[] m_testAI;

	public string[] m_npcMovetoDestination;

	public string[] m_archangleEnergyBlast;

	public string[] m_archangelEnergyMissile;

	public string[] m_theInsaneTeleportPlayer;

	public string[] m_npcBasicSpawn;

	public string[] m_npcAdvanceSpawn;

	public string[] m_npcCombatSpawn;

	public string[] m_rakkFlyMeleeAttack;

	public string[] m_hurtZone;

	public string[] m_npcHeal;

	public string[] m_killDestroyableObject;

	public string[] m_tentacleMeleeAttack;

	public string[] m_npcRangeAttackPlayer;

	public string[] m_npcSniperAttackPlayer;

	public string[] m_npcFallBackFireAttackPlayer;

	public string[] m_badassBanditThrowGrenade;

	public string[] m_badassPsychoThrowAxe;

	public string[] m_npcSuicideAttack;

	public string[] m_npcReloadWeapon;

	public string[] m_npcSpitAttack;

	public string[] m_npcMeleeAttackPlayer;

	public string[] m_npcIceMeteorAttack;

	public string[] m_npcAttackPlayerInCover;

	public string[] m_npcShootExplosiveBarrel;

	public string[] m_npcOnDamage;

	public string[] m_playerTeleport;

	public string[] m_npcChooseCover;

	public string[] m_npcChargeAttack;

	public string[] m_npcChooseAttackTarget;

	public string[] m_playerShootingTest;

	public string[] m_playerShootingTestWithPlayerNotMoving;

	public string[] m_playerShootingTestPvP;

	public string[] m_memoryTest;

	public string[] m_memoryLeakTest;

	public string[] m_fpsTest;

	public string[] m_stressTest;

	public string[] m_stressTest3x5;

	public string[] m_stressTest3x6;

	public string[] m_stressTest3x7;

	public string[] m_stressTest3x9;

	public string[] m_stressTest3x10;

	public string[] m_stressTest3x11;

	public string[] m_stressTest3x13;

	public string[] m_stressTest3x14;

	public string[] m_stressTest3x15;

	public string[] m_skillSiren;

	public string[] m_skillBerserker;

	public string[] m_skillSoldier;

	public string[] m_skillHunter;

	public string[] m_itemWeapon;

	public string[] m_itemShield;

	public string[] m_itemClassMode;

	public AutoTestTable()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array[1] = "  Test1|Test2";
		array[2] = "Quit";
		m_testCases = array;
		string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
		array2[0] = "LoadLevel";
		m_loadLevel = array2;
		m_empty = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);
		string[] array3 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array3[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array3[1] = "  InvulnerablePlayerStandStillForOneMinute";
		array3[2] = "Quit";
		m_oneInvulnerablePlayerStanding = array3;
		string[] array4 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array4[0] = "LoadAutoTestLevel1_WaitForTwoPlayers";
		array4[1] = "  InvulnerablePlayerStandStillForOneMinute";
		array4[2] = "Quit";
		m_twoInvulnerablePlayersStanding = array4;
		string[] array5 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array5[0] = "LoadAutoTestLevel1_WaitForThreePlayers";
		array5[1] = "  InvulnerablePlayerStandStillForOneMinute";
		array5[2] = "Quit";
		m_threeInvulnerablePlayersStanding = array5;
		string[] array6 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array6[0] = "LoadAutoTestLevel1_WaitForFourPlayers";
		array6[1] = "  InvulnerablePlayerStandStillForOneMinute";
		array6[2] = "Quit";
		m_fourInvulnerablePlayersStanding = array6;
		string[] array7 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array7[0] = "LoadAutoTestLevel1_WaitForFourPlayers";
		array7[1] = "  NpcMoveToDestination|NpcRangeAttackPlayer|NpcShootExplosiveBarrel|NpcChooseAttackTarget|NpcOnDamage|PlayerTeleport|NpcMeleeAttackPlayer|NpcChooseCover|NpcAttackPlayerInCover|NpcSuicideAttack |BadassBanditThrowGrenade|NpcBasicSpawn|NpcAdvanceSpawn|BadassPsychoThrowAxe|NpcReloadWeapon|NpcChargeAttack|NpcSpitAttack|NpcCombatSpawn|NpcIceMeteorAttack|NpcHeal|NpcSniperAttackPlayer|RakkFlyMeleeAttack|HurtZone|NpcFallBackFireAttackPlayer|KillDestroyableObject|TentacleMeleeAttack|ArchangleEnergyBlast|ArchangelEnergyMissile|TheInsaneTeleportPlayer";
		array7[2] = "Quit";
		m_testAI = array7;
		string[] array8 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array8[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array8[1] = "  NpcMoveToDestination";
		array8[2] = "Quit";
		m_npcMovetoDestination = array8;
		string[] array9 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array9[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array9[1] = "  ArchangleEnergyBlast";
		array9[2] = "Quit";
		m_archangleEnergyBlast = array9;
		string[] array10 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array10[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array10[1] = "  ArchangelEnergyMissile";
		array10[2] = "Quit";
		m_archangelEnergyMissile = array10;
		string[] array11 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array11[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array11[1] = "  TheInsaneTeleportPlayer";
		array11[2] = "Quit";
		m_theInsaneTeleportPlayer = array11;
		string[] array12 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array12[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array12[1] = "  NpcBasicSpawn";
		array12[2] = "Quit";
		m_npcBasicSpawn = array12;
		string[] array13 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array13[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array13[1] = "  NpcAdvanceSpawn";
		array13[2] = "Quit";
		m_npcAdvanceSpawn = array13;
		string[] array14 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array14[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array14[1] = "  NpcCombatSpawn";
		array14[2] = "Quit";
		m_npcCombatSpawn = array14;
		string[] array15 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array15[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array15[1] = "  RakkFlyMeleeAttack";
		array15[2] = "Quit";
		m_rakkFlyMeleeAttack = array15;
		string[] array16 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array16[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array16[1] = "  HurtZone";
		array16[2] = "Quit";
		m_hurtZone = array16;
		string[] array17 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array17[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array17[1] = "  NpcHeal";
		array17[2] = "Quit";
		m_npcHeal = array17;
		string[] array18 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array18[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array18[1] = "  KillDestroyableObject";
		array18[2] = "Quit";
		m_killDestroyableObject = array18;
		string[] array19 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array19[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array19[1] = "  TentacleMeleeAttack";
		array19[2] = "Quit";
		m_tentacleMeleeAttack = array19;
		string[] array20 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array20[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array20[1] = "  NpcRangeAttackPlayer";
		array20[2] = "Quit";
		m_npcRangeAttackPlayer = array20;
		string[] array21 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array21[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array21[1] = "  NpcSniperAttackPlayer";
		array21[2] = "Quit";
		m_npcSniperAttackPlayer = array21;
		string[] array22 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array22[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array22[1] = "  NpcFallBackFireAttackPlayer";
		array22[2] = "Quit";
		m_npcFallBackFireAttackPlayer = array22;
		string[] array23 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array23[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array23[1] = "  BadassBanditThrowGrenade";
		array23[2] = "Quit";
		m_badassBanditThrowGrenade = array23;
		string[] array24 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array24[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array24[1] = "  BadassPsychoThrowAxe";
		array24[2] = "Quit";
		m_badassPsychoThrowAxe = array24;
		string[] array25 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array25[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array25[1] = "  NpcSuicideAttack";
		array25[2] = "Quit";
		m_npcSuicideAttack = array25;
		string[] array26 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array26[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array26[1] = "  NpcReloadWeapon";
		array26[2] = "Quit";
		m_npcReloadWeapon = array26;
		string[] array27 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array27[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array27[1] = "  NpcSpitAttack";
		array27[2] = "Quit";
		m_npcSpitAttack = array27;
		string[] array28 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array28[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array28[1] = "  NpcMeleeAttackPlayer";
		array28[2] = "Quit";
		m_npcMeleeAttackPlayer = array28;
		string[] array29 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array29[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array29[1] = "  NpcIceMeteorAttack";
		array29[2] = "Quit";
		m_npcIceMeteorAttack = array29;
		string[] array30 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array30[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array30[1] = "  NpcAttackPlayerInCover";
		array30[2] = "Quit";
		m_npcAttackPlayerInCover = array30;
		string[] array31 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array31[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array31[1] = "  NpcShootExplosiveBarrel";
		array31[2] = "Quit";
		m_npcShootExplosiveBarrel = array31;
		string[] array32 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array32[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array32[1] = "  NpcOnDamage";
		array32[2] = "Quit";
		m_npcOnDamage = array32;
		string[] array33 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array33[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array33[1] = "  PlayerTeleport";
		array33[2] = "Quit";
		m_playerTeleport = array33;
		string[] array34 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array34[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array34[1] = "  NpcChooseCover";
		array34[2] = "Quit";
		m_npcChooseCover = array34;
		string[] array35 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array35[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array35[1] = "  NpcChargeAttack";
		array35[2] = "Quit";
		m_npcChargeAttack = array35;
		string[] array36 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array36[0] = "LoadAutoTestLevel1_WaitForTwoPlayers";
		array36[1] = "  NpcChooseAttackTarget";
		array36[2] = "Quit";
		m_npcChooseAttackTarget = array36;
		string[] array37 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array37[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)";
		array37[1] = "  PlayerShootingTest";
		array37[2] = "Quit";
		m_playerShootingTest = array37;
		string[] array38 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array38[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)";
		array38[1] = "  PlayerShootingTestWithPlayerNotMoving";
		array38[2] = "Quit";
		m_playerShootingTestWithPlayerNotMoving = array38;
		string[] array39 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array39[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,2)";
		array39[1] = "  PlayerShootingTestPvP";
		array39[2] = "Quit";
		m_playerShootingTestPvP = array39;
		string[] array40 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array40[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array40[1] = "  Memory";
		array40[2] = "Quit";
		m_memoryTest = array40;
		string[] array41 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array41[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array41[1] = "  MemLeak";
		array41[2] = "Quit";
		m_memoryLeakTest = array41;
		string[] array42 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array42[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array42[1] = "  Fps";
		array42[2] = "Quit";
		m_fpsTest = array42;
		string[] array43 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array43[0] = "Stress";
		array43[1] = "Quit";
		m_stressTest = array43;
		string[] array44 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array44[0] = "Stress3x5";
		array44[1] = "Quit";
		m_stressTest3x5 = array44;
		string[] array45 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array45[0] = "Stress3x6";
		array45[1] = "Quit";
		m_stressTest3x6 = array45;
		string[] array46 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array46[0] = "Stress3x7";
		array46[1] = "Quit";
		m_stressTest3x7 = array46;
		string[] array47 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array47[0] = "Stress3x9";
		array47[1] = "Quit";
		m_stressTest3x9 = array47;
		string[] array48 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array48[0] = "Stress3x10";
		array48[1] = "Quit";
		m_stressTest3x10 = array48;
		string[] array49 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array49[0] = "Stress3x11";
		array49[1] = "Quit";
		m_stressTest3x11 = array49;
		string[] array50 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array50[0] = "Stress3x13";
		array50[1] = "Quit";
		m_stressTest3x13 = array50;
		string[] array51 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array51[0] = "Stress3x14";
		array51[1] = "Quit";
		m_stressTest3x14 = array51;
		string[] array52 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
		array52[0] = "Stress3x15";
		array52[1] = "Quit";
		m_stressTest3x15 = array52;
		string[] array53 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array53[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)";
		array53[1] = "  SkillSirenTest";
		array53[2] = "Quit";
		m_skillSiren = array53;
		string[] array54 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array54[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(BERSERKER,1)";
		array54[1] = "  SkillBerserkerTest";
		array54[2] = "Quit";
		m_skillBerserker = array54;
		string[] array55 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array55[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(SOLDIER,1)";
		array55[1] = "  SkillSoldierTest";
		array55[2] = "Quit";
		m_skillSoldier = array55;
		string[] array56 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array56[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(HUNTER,1)";
		array56[1] = "  SkillHunterTest";
		array56[2] = "Quit";
		m_skillHunter = array56;
		string[] array57 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array57[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array57[1] = "  ItemWeaponTest";
		array57[2] = "Quit";
		m_itemWeapon = array57;
		string[] array58 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array58[0] = "LoadAutoTestLevel1_WaitForOnePlayer";
		array58[1] = "  ItemShieldTest";
		array58[2] = "Quit";
		m_itemShield = array58;
		string[] array59 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array59[0] = "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)";
		array59[1] = "  ItemClassModeTest";
		array59[2] = "Quit";
		m_itemClassMode = array59;
		base._002Ector();
	}

	public string[] c55ff23a26d586b890d4ccb766e85a594(string c95187d82e2a3f6e2434c21ee8b774d77)
	{
		string[] result = m_empty;
		Type type = GetType();
		FieldInfo field = type.GetField("m_" + c95187d82e2a3f6e2434c21ee8b774d77);
		if (field != null)
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
			result = (string[])field.GetValue(this);
		}
		return result;
	}
}
