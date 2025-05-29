using System;

public class ErrorCode
{
	public const int Ok = 0;

	public const int OperationNotAllowedInCurrentState = -3;

	public const int InvalidOperationCode = -2;

	public const int InternalServerError = -1;

	public const int InvalidAuthentication = 32767;

	public const int GameIdAlreadyExists = 32766;

	public const int GameFull = 32765;

	public const int GameClosed = 32764;

	[Obsolete("No longer used, cause random matchmaking is no longer a process.")]
	public const int AlreadyMatched = 32763;

	public const int ServerFull = 32762;

	public const int UserBlocked = 32761;

	public const int NoRandomMatchFound = 32760;

	public const int GameDoesNotExist = 32758;

	public const int MaxCcuReached = 32757;

	public const int InvalidRegion = 32756;

	public const int OperationTimedOut = 32754;

	public const int AppAuthenticationFailed = 32755;

	public const int CharacterServiceGetError = 32752;

	public const int CharacterServiceUpdateError = 32751;

	public const int ItemServiceGetError = 32750;

	public const int NoImplementation = 32749;

	public const int ChatTypeError = 32748;

	public const int ChatGroupError = 32747;

	public const int ChatNotFriendError = 32746;

	public const int ChatNotOnlineError = 32745;

	public const int OutOfLevelRange = 32744;

	public const int CharacterNotExist = 32743;

	public const int LoginAlreadyOnline = 32742;

	public const int MailNotExsit = 32741;

	public const int MailCharacterNotExist = 32740;

	public const int MailInBlock = 32739;

	public const int MailContentLimit = 32738;

	public const int MailInboxFull = 32737;

	public const int MailNotItem = 32736;

	public const int LoginBan = 32735;

	public const int NicknameContainDirtyword = 32734;

	public const int NicknameTooLong = 32733;

	public const int NicknameAlreadyExists = 32732;

	public const int AppVersionError = 32731;

	public const int ServerMaintenance = 32730;

	public const int InventoryFull = 32729;
}
