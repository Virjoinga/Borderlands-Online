using System;

public class EventCode
{
	public const byte GuildMemberQuit = 240;

	public const byte GuildMemberJoined = 239;

	public const byte GuildMasterChanged = 238;

	public const byte GuildManagerDischarged = 237;

	public const byte GuildManagerAssigned = 236;

	public const byte GuildSkillSelected = 235;

	public const byte FreeGuildSkillSlotGiven = 234;

	public const byte GuildExpelled = 233;

	public const byte GuildJoined = 232;

	public const byte GuildInvitation = 231;

	public const byte GameList = 230;

	public const byte GameListUpdate = 229;

	public const byte QueueState = 228;

	public const byte Match = 227;

	public const byte AppStats = 226;

	public const byte AzureNodeInfo = 210;

	public const byte Join = byte.MaxValue;

	public const byte Leave = 254;

	public const byte PropertiesChanged = 253;

	[Obsolete("Use PropertiesChanged now.")]
	public const byte SetProperties = 253;

	public const byte NewMessage = 223;

	public const byte InventoryUpdated = 222;

	public const byte InventoryAction = 221;

	public const byte InstanceCompleted = 219;

	public const byte InstanceUnlocked = 205;

	public const byte CurrenciesUpdated = 218;

	public const byte QuestStatusUpdated = 220;

	public const byte QuestTaskCompleted = 217;

	public const byte QuestRewardClaimed = 215;

	public const byte SkillPointEarned = 216;

	public const byte KickedFromGroup = 215;

	public const byte NewGroupLeader = 214;

	public const byte NewGroupMember = 213;

	public const byte GroupInviteRejected = 212;

	public const byte GroupMemberLeft = 211;

	public const byte GroupGameStarted = 210;

	public const byte GroupDisbanded = 209;

	public const byte GroupMatchmakingStarted = 165;

	public const byte NewFriend = 208;

	public const byte Unfriended = 207;

	public const byte ExperienceUpdated = 206;

	public const byte CharacterInfoUpdated = 204;

	public const byte Chat = 199;

	public const byte SendChatOk = 198;

	public const byte GameOwnerChanged = 197;

	public const byte KickedFromGame = 196;

	public const byte PresenceUpdated = 195;

	public const byte PlayerJoinedLobby = 194;

	public const byte PlayerLeftLobby = 193;

	public const byte LobbyCreated = 166;

	public const byte LobbyGameStarted = 192;

	public const byte LobbyClosed = 191;

	public const byte LobbyOwnerChanged = 190;

	public const byte GroupJoinedLobby = 189;

	public const byte GroupLeaveLobby = 188;

	public const byte LobbyOpened = 164;

	public const byte QuestClearDailyQuest = 170;

	public const byte QuestTaskUpdated = 169;

	public const byte WarehouseUpdated = 168;

	public const byte NewMail = 167;

	public const byte MailList = 161;

	public const byte KickPlayer = 163;

	public const byte NotifyAntiAddiction = 162;

	public const byte Announcements = 160;

	public const byte NotifyAntiAddictionLevel = 159;

	public const byte GPKDynCode = 158;

	public const byte GPKAuthData = 157;
}
