public class OperationCode
{
	public const byte Authenticate = 230;

	public const byte JoinLobby = 229;

	public const byte LeaveLobby = 228;

	public const byte CreateGame = 227;

	public const byte JoinGame = 226;

	public const byte JoinRandomGame = 225;

	public const byte Leave = 254;

	public const byte RaiseEvent = 253;

	public const byte SetProperties = 252;

	public const byte GetProperties = 251;

	public const byte ChangeGroups = 248;

	public const byte QueryRooms = 221;

	public const byte CancelJoin = 167;

	public const byte CloseGame = 138;

	public const byte KickPlayerFromGame = 136;

	public const byte Login = 222;

	public const byte GetCharacterInfo = 220;

	public const byte RequestCreateCharacter = 219;

	public const byte UpdateCharacterName = 218;

	public const byte UpdateCharacterModel = 217;

	public const byte UpdateCharacterExp = 216;

	public const byte SelectCharacter_OLD = 214;

	public const byte UpdateCharacterInfo = 213;

	public const byte RequestItemDNA = 212;

	public const byte SendMessage = 211;

	public const byte RetrieveMessages = 210;

	public const byte MarkAsRead = 209;

	public const byte DeleteMessage = 208;

	public const byte RetrieveFriendsList = 207;

	public const byte IsUserAFriend = 206;

	public const byte SendFriendRequest = 164;

	public const byte AcceptFriendRequest = 205;

	public const byte RejectFriendRequest = 165;

	public const byte Unfriend = 204;

	public const byte Ignore = 203;

	public const byte Unignore = 202;

	public const byte IsUserIgnored = 201;

	public const byte GetAllFriendsCharacterInfo = 144;

	public const byte SendGameInvitation = 200;

	public const byte AcceptGameInvitation = 137;

	public const byte AcceptGroupGameInvitation = 199;

	public const byte JoinSessionInProgress = 198;

	public const byte IsFriendsGameJoinable = 197;

	public const byte GetInventory = 196;

	public const byte SwapInventorySlots = 195;

	public const byte AddItemsToInventory = 194;

	public const byte DropItemFromInventory = 193;

	public const byte UpdateInventory = 177;

	public const byte Split = 90;

	public const byte Combine = 89;

	public const byte Tidy = 88;

	public const byte EquipWeapon = 192;

	public const byte UnequipWeapon = 191;

	public const byte SetActiveWeapon = 190;

	public const byte EquipNewWeapon = 189;

	public const byte UpdateAmmoCounts = 188;

	public const byte SwapWeapons = 166;

	public const byte GetMyCurrencies = 156;

	public const byte GetCurrencies = 187;

	public const byte UpdateCurrencies = 186;

	public const byte GetPlayerQuests = 185;

	public const byte AcceptQuest = 184;

	public const byte UpdateQuestRequirement = 183;

	public const byte ClaimQuestRewards = 181;

	public const byte RejectQuest = 215;

	public const byte TalkToNPC = 150;

	public const byte BringToNPC = 145;

	public const byte CompleteQuest = 142;

	public const byte GetDailyQuestContents = 141;

	public const byte GetUnlockedInstances = 180;

	public const byte CompleteInstance = 179;

	public const byte UnlockInstance = 178;

	public const byte GetMySkillPoints = 173;

	public const byte GetInvestedSkillPoints = 171;

	public const byte InvestSkillPoint = 170;

	public const byte InvestMultipleSkillPoints = 169;

	public const byte ResetSkillPoints = 168;

	public const byte SendGroupInvitation = 163;

	public const byte AcceptGroupInvitation = 162;

	public const byte RejectGroupInvitation = 161;

	public const byte KickPlayerFromGroup = 160;

	public const byte LeaveGroup = 159;

	public const byte GetMyGroupInfo = 158;

	public const byte SendGameInvitationsToGroup = 157;

	public const byte RejoinGroup = 151;

	public const byte SmeltWeapon = 154;

	public const byte CraftWeapon = 153;

	public const byte GetMyCraftedWeapons = 143;

	public const byte RequestSubmitMatchResult = 149;

	public const byte RequestMatchRecord = 148;

	public const byte GetPeerPresence = 147;

	public const byte GetAllFriendsPresence = 146;

	public const byte SetCurrentTown = 155;

	public const byte SearchForCharacter = 152;

	public const byte Chat = 139;

	public const byte EquipShield = 135;

	public const byte UnequipShield = 134;

	public const byte CreateLobby = 87;

	public const byte OpenLobby = 96;

	public const byte FindLobby = 133;

	public const byte InviteToLobby = 132;

	public const byte AcceptLobbyInvitation = 131;

	public const byte RejectLobbyInvitation = 130;

	public const byte KickPlayerFromLobby = 129;

	public const byte StartLobbyGame = 127;

	public const byte GetLobby = 126;

	public const byte CloseLobby = 125;

	public const byte AcceptLobbyGameInvitation = 124;

	public const byte SendPvPGameInvitations = 123;

	public const byte SetTeamID = 122;

	public const byte GetShop = 121;

	public const byte BuyItem = 120;

	public const byte SellItem = 119;

	public const byte GetMyGuildApplications = 77;

	public const byte CancelMyGuildApplication = 76;

	public const byte GetMyGuildNews = 78;

	public const byte ChangeGuildBanner = 100;

	public const byte GetMyGuildInfo = 101;

	public const byte GetMyGuildId = 102;

	public const byte GetGuildInfo = 103;

	public const byte CreateGuild = 104;

	public const byte DismissGuild = 105;

	public const byte NotifyGuildDismissal = 106;

	public const byte ChangeGuildMaster = 107;

	public const byte SearchGuild = 108;

	public const byte ApplyToGuild = 109;

	public const byte GetGuildApplications = 110;

	public const byte ProcessGuildApplications = 111;

	public const byte QuitGuild = 112;

	public const byte ExpellFromGuild = 113;

	public const byte InviteToGuild = 114;

	public const byte GetMyGuildInvitations = 115;

	public const byte ProcessGuildInvitations = 116;

	public const byte GetGuildNews = 117;

	public const byte UpdateGuildNews = 118;

	public const byte AssignGuildManager = 73;

	public const byte DischargeGuildManager = 72;

	public const byte SubmitPvEFactorsForGuildExpCalc = 67;

	public const byte GetGuildSkillList = 66;

	public const byte GetMyGuildSkillList = 65;

	public const byte ActivateGuildSkill = 64;

	public const byte GetGuildManagerList = 63;

	public const byte GetWarehouse = 99;

	public const byte SwapWarehouseSlot = 98;

	public const byte SwapInventoryWarehouseSlot = 97;

	public const byte GetMail = 95;

	public const byte SendMail = 94;

	public const byte UpdateMailState = 93;

	public const byte GetMailItems = 92;

	public const byte DeleteMail = 91;

	public const byte EquipClassMod = 86;

	public const byte GetAntiLevel = 85;

	public const byte GetCharacterList = 84;

	public const byte SelectCharacter = 83;

	public const byte CreateCharacter = 82;

	public const byte GetCharacter = 81;

	public const byte GetMyCharacter = 80;

	public const byte UpdateCharacterExperience = 79;

	public const byte GetPersonalSettings = 75;

	public const byte SetPersonalSettings = 74;

	public const byte OpenLuckyBox = 71;

	public const byte AwardLuckyBox = 70;

	public const byte UpgradeStarExperience = 69;

	public const byte UpgradeStarLevel = 68;

	public const byte GPKAuthReply = 62;

	public const byte RecordClientDebugInfo = 61;
}
