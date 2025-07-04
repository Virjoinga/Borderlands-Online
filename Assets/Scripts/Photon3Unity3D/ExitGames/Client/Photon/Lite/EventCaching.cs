namespace ExitGames.Client.Photon.Lite
{
	public enum EventCaching : byte
	{
		DoNotCache = 0,
		MergeCache = 1,
		ReplaceCache = 2,
		RemoveCache = 3,
		AddToRoomCache = 4,
		AddToRoomCacheGlobal = 5,
		RemoveFromRoomCache = 6,
		RemoveFromRoomCacheForActorsLeft = 7
	}
}
