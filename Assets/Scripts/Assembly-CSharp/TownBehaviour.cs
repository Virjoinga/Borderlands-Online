using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class TownBehaviour : StepBehaviour
{
	private Camera _gameCamera;

	public static bool m_bCheckWorldMap = false;

	private static Utils.Timer m_MatchMakingTime = new Utils.Timer();

	private static Utils.Timer m_PvEMatchMakingTime = new Utils.Timer();

	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(true);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c2dc5e286b7faa1029d7be508be9ce924(false);
		LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().c7c03e6f29c8281984fdd564fed20468c();
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c076bcbb538ab7a02f13183c99cc8c79e();
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().ccc9d3a38966dc10fedb531ea17d24611();
		UIMapDisplayManager.c71f6ce28731edfd43c976fbd57c57bea().ccc9d3a38966dc10fedb531ea17d24611();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<WareHouseView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<QuestTrackView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<CharInfoView>().bPVPDisp = false;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<HUDTeamMatePortraitView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<NPCDialogView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<NPCInteractiveView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<QuestDetailView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<SkillTreeView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<QuestListView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<EchoMessageView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<WeaponMeltView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<InstanceSelectView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>()._enterLevelFunc = ccaddab9d4477b0348c03e66ec878a152.c7088de59e49f7108f520cf7e0bae167e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<TownHUDView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<InstanceView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<CurrencyUpdateView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<PopupMenuView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<PlayerListView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<GroupView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<FriendView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<HUDWarningView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<WeaponPreviewView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<WeaponCraftView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<InventoryView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<WorldMapSelectView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<MiniMapView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<MatchMakingView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<LargeMapView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<MailView>();
		ChatView chatView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<ChatView>();
		ChatParameter[] array = c00dae1e31bd474cae9f1d0b21051ce58.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = ChatParameter.Town;
		array[1] = ChatParameter.Group;
		array[2] = ChatParameter.Guild;
		array[3] = ChatParameter.Private;
		array[4] = ChatParameter.System;
		chatView.c85d6545b87129c60c9164fb2179eb5c2(array);
		chatView.cba8e8b1d8d6b9d28e478a64bad8ba328(ChatParameter.Town, string.Empty);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<PauseMenuView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<GuildCreateView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<GuildSearchView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<GuildOptionView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<PvPFlowView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<PvPTipsView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<ShopView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ce22458c51b34b4a5bbda40331bde92e6<WeaponUpgradeView>();
		ItemTips.c932bfccc5c973fdc58a3c282d4ccc1a5();
		c94d14a5ae8009939f4f8d62faa8ffc79();
		LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().m_bCanShowLobbyECHO = true;
	}

	public override void ca9a7e4f5830bea46045e5de793b42658(FrontEndStepManager.StepState c4563c3e865ced83101267c98f318b921)
	{
		_gameCamera = c4ffee394d9d7cb3cc1237fb7e347bc29.c7088de59e49f7108f520cf7e0bae167e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405 = c4ffee394d9d7cb3cc1237fb7e347bc29.c7088de59e49f7108f520cf7e0bae167e;
		ItemTips.c9dec9a28db62894ffe6dd475eda41961();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<ChatView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<WeaponMeltView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<PopupMenuView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<PlayerListView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<WareHouseView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<QuestTrackView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<CharInfoView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<HUDTeamMatePortraitView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<NPCDialogView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<NPCInteractiveView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<QuestDetailView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<EchoMessageView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<SkillTreeView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<InstanceSelectView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<CurrencyUpdateView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<TownHUDView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<QuestListView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<InstanceView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<GroupView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<FriendView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<HUDWarningView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<WeaponPreviewView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<WeaponCraftView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<InventoryView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<WorldMapSelectView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<ShopView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<MiniMapView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<LargeMapView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<MatchMakingView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<GuildCreateView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<GuildSearchView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<GuildOptionView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<PvPFlowView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<PvPTipsView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<MailView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<WeaponUpgradeView>();
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		UIMapDisplayManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cdda1108806b8a31337c338a488b30f1e();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c6f01b5fa13c603e61975e008f5f3dce8<PauseMenuView>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(true);
	}

	public override void OnLevelLoadingFinish()
	{
		GameObject gameObject = new GameObject("WeaponCraftObject");
		ParticleManager c451f04a91206cc21efd84192906fe8e = gameObject.AddComponent<ParticleManager>();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponCraftView>().c451f04a91206cc21efd84192906fe8e3 = c451f04a91206cc21efd84192906fe8e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WeaponMeltView>().c451f04a91206cc21efd84192906fe8e3 = c451f04a91206cc21efd84192906fe8e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c114035b255a7c79daf00b8613364145c(gameObject);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().c223fa13462383b866a17f6b609b07fc3(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = true;
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c453f2a4444139b3731bbf5855f7433e3();
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().ccc9d3a38966dc10fedb531ea17d24611();
		c6bbbc6750896f2c37ef14a8b28e175d9();
	}

	private void Update()
	{
		c9ae486cc9480abf1922133af6d925ac7();
		cb283f9e85571bed7be141508762c12de();
		Session c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86;
		if (c5ee19dc8d4cccf5ae2de225410458b == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTeamMatePortraitView>() != null)
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
			Presence[] array = GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c5b73c8ec4cf5992b0576375f00ee04d9();
			if (array.Length == 0)
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
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTeamMatePortraitView>().cbfadbedd34e283c5ad417e3ad4508cbf();
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDTeamMatePortraitView>().cd2d87578e397fe6a8d3d350c2a512f51(array[i], i, array.Length);
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
		}
		if (_gameCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			GameObject gameObject = GameObject.Find("FpsCamera(Clone)");
			if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				_gameCamera = gameObject.GetComponent<Camera>();
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405 = _gameCamera;
			}
		}
		E_USE_TYPE c2b4f43f34e21572af6ab4414f04cee = E_USE_TYPE.E_NONE;
		if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c69e93962e1ca78e26e0c6dfcd5b44426())
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
				c2b4f43f34e21572af6ab4414f04cee = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_availableInteraction.c2aae0ed9fb0e39619e71e33a2e3fc48b();
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<TownHUDView>().c565fc8fc4a259a71ab4632066f71f0ea(c2b4f43f34e21572af6ab4414f04cee);
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().Update();
		UIMapDisplayManager.c71f6ce28731edfd43c976fbd57c57bea().Update();
		c0823d0fe20486e5f04efefe34bb94d12();
	}

	private int c3d1bb3692c0855c4147e6387b76d54a6(PlayerInfoSync c4dc7d02cb18f1b4fe4a2caa3b76f2b5c, PlayerInfoSync c9256c859427b0c4bd43645ff0466f5e2)
	{
		if (c9256c859427b0c4bd43645ff0466f5e2.m_characterId == GroupManager.c71f6ce28731edfd43c976fbd57c57bea().m_nLeaderId)
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
					return 1;
				}
			}
		}
		return -1;
	}

	private void c94d14a5ae8009939f4f8d62faa8ffc79()
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		XsdSettings.TownNpc[] npcs = c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_npcsSetup.m_npcs;
		foreach (XsdSettings.TownNpc townNpc in npcs)
		{
			NpcOccupation[] occupations = townNpc.m_occupations;
			foreach (NpcOccupation npcOccupation in occupations)
			{
				int item = -1;
				switch (npcOccupation)
				{
				case NpcOccupation.ClassModeShop:
					item = townNpc.m_ClassModeShopID;
					break;
				case NpcOccupation.WeaponShop:
					item = townNpc.m_WeaponShopID;
					break;
				case NpcOccupation.CoinShieldShop:
					item = townNpc.m_CoinShieldShopID;
					break;
				}
				hashSet.Add(item);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_00bf;
				}
				continue;
				end_IL_00bf:
				break;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			using (HashSet<int>.Enumerator enumerator = hashSet.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					if (current == -1)
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
					c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cee370ce68b9715d7b8caecb310431e99(current, true);
				}
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
		}
	}

	private void c6bbbc6750896f2c37ef14a8b28e175d9()
	{
		bool flag = false;
		using (List<MailInfo>.Enumerator enumerator = c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cfd9d57231f4e8e67b5a6a492bc70a1a0().GetEnumerator())
		{
			while (true)
			{
				if (enumerator.MoveNext())
				{
					MailInfo current = enumerator.Current;
					if (current.Mailtype != 0)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (current.Mailstate != 0)
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
					if (current.Item == null)
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
					if (current.Item.mItem == null)
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
						flag = true;
						break;
					}
					break;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_0089;
					}
					continue;
					end_IL_0089:
					break;
				}
				break;
			}
		}
		if (!flag)
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
			c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5("81013");
			return;
		}
	}

	private void OnLevelUp(PlayerInfoSync player)
	{
		if (player.c16d1154aec91a0f8f4a52d77fc081194())
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
			c94d14a5ae8009939f4f8d62faa8ffc79();
		}
		AvatarType c951097a6ef3eb670bc38dce2cd336b7a = player.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
		NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().cacb0973399bda5328a4e13f27d851fdb(c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, player.m_exp));
	}

	private void c0823d0fe20486e5f04efefe34bb94d12()
	{
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_name = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409();
		playerProperties.m_exp = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c623008f5bbe4bf72af447d08f62aa043();
		playerProperties.m_avatarDna = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c093d70e3287743ce2bc905d2c4b341f3();
		playerProperties.m_level = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceSelectView>().c0be25dad7f3b503064fc98b654b8c830(playerProperties);
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>() != null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c0be25dad7f3b503064fc98b654b8c830(playerProperties);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c8de516016f86a6aaeb78036625c2510a();
		}
		GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c490e1cdbd91f441f8899c3b557cbc807();
	}

	public static void cd2ae7f946a784d332495e83e7f45c518()
	{
		m_MatchMakingTime.cdada4c3678c9c23c38aaf0754a94a620();
		m_MatchMakingTime.Start(20f);
	}

	public static void c1c09bbfad47ca3cf727182be087e9527()
	{
		m_MatchMakingTime.cdada4c3678c9c23c38aaf0754a94a620();
	}

	private void c9ae486cc9480abf1922133af6d925ac7()
	{
		if (!m_MatchMakingTime.cb261500372fa488b369e9159a002977a())
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
			Lobby cf5b9332c9bfbdc7648aaad2509591a7d = LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cf5b9332c9bfbdc7648aaad2509591a7d;
			if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (m_MatchMakingTime.cf928603d375f06225f9eb5213fb17bd4())
						{
							while (true)
							{
								bool flag;
								switch (7)
								{
								case 0:
									break;
								default:
									{
										flag = false;
										LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().m_bCanShowLobbyECHO = true;
										if (cf5b9332c9bfbdc7648aaad2509591a7d.GameMode == GamemodeType.GamemodeTeamDeathmatch)
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
											if (cf5b9332c9bfbdc7648aaad2509591a7d.IsGroupGame)
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
												if (cf5b9332c9bfbdc7648aaad2509591a7d.Groups.Count > 1)
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
													flag = true;
												}
											}
										}
										if (cf5b9332c9bfbdc7648aaad2509591a7d.GameMode == GamemodeType.GamemodeTeamDeathmatch)
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
											if (cf5b9332c9bfbdc7648aaad2509591a7d.IsGroupGame)
											{
												goto IL_0108;
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
										if (cf5b9332c9bfbdc7648aaad2509591a7d.Members.Count > 1)
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
											flag = true;
										}
										goto IL_0108;
									}
									IL_0108:
									if (flag)
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
										if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
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
											c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.ceba244211ce5e4e3f8e412a840ec284b("OnGoToInstance", cf5b9332c9bfbdc7648aaad2509591a7d.Playlist, cf5b9332c9bfbdc7648aaad2509591a7d.GameMode);
										}
									}
									else
									{
										LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c7a337098f70dabdd1dc7f3a6a249dc79();
									}
									c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
									return;
								}
							}
						}
						if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c487629df5d3f6240821140b3e6ca8783())
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
									c1c09bbfad47ca3cf727182be087e9527();
									LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().m_bCanShowLobbyECHO = true;
									if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c03e08ddbd7a06ade357b3ce0364b3f94())
									{
										while (true)
										{
											switch (2)
											{
											case 0:
												break;
											default:
												c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.ceba244211ce5e4e3f8e412a840ec284b("OnGoToInstance", cf5b9332c9bfbdc7648aaad2509591a7d.Playlist, cf5b9332c9bfbdc7648aaad2509591a7d.GameMode);
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
			if (!m_MatchMakingTime.cf928603d375f06225f9eb5213fb17bd4())
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
				LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().m_bCanShowLobbyECHO = true;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
				return;
			}
		}
	}

	public static void ce2930ac4ecd72437eb897cc5b7ac411e()
	{
		m_PvEMatchMakingTime.cdada4c3678c9c23c38aaf0754a94a620();
		m_PvEMatchMakingTime.Start(20f);
	}

	public static void c875cfe6662f961b477c2e72453edfbe4()
	{
		m_PvEMatchMakingTime.cdada4c3678c9c23c38aaf0754a94a620();
	}

	private void cb283f9e85571bed7be141508762c12de()
	{
		if (!m_PvEMatchMakingTime.cb261500372fa488b369e9159a002977a())
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
			Lobby c02871361bbce7d8a240cb3023dd5d12c = LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().c02871361bbce7d8a240cb3023dd5d12c;
			if (m_PvEMatchMakingTime.cf928603d375f06225f9eb5213fb17bd4())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cd32d91087eba68a8898d7f9466c7c721())
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
							c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.ceba244211ce5e4e3f8e412a840ec284b("OnGoToInstance", c02871361bbce7d8a240cb3023dd5d12c.Playlist, c02871361bbce7d8a240cb3023dd5d12c.GameMode);
						}
						else
						{
							DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "~~~~~~~Time Over!!" + c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + "not PvE room Owner");
						}
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
						return;
					}
				}
			}
			if (!LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().ccf43e054fa157ad0e22e94fc2035fd4f())
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
				if (LobbyManager.c71f6ce28731edfd43c976fbd57c57bea().cd32d91087eba68a8898d7f9466c7c721())
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
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.ceba244211ce5e4e3f8e412a840ec284b("OnGoToInstance", c02871361bbce7d8a240cb3023dd5d12c.Playlist, c02871361bbce7d8a240cb3023dd5d12c.GameMode);
				}
				else
				{
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "~~~~~~~PvE room Full!!" + c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409() + "not PvE room Owner");
				}
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<MatchMakingView>().c150264a18c2cb408479d3f072cac8cc1 = false;
				c875cfe6662f961b477c2e72453edfbe4();
				return;
			}
		}
	}
}
