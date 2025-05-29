public class ZoneTrigger : LevelTrigger
{
	public enum TriggerCondition
	{
		Enter = 0,
		Leave = 1,
		Occupied = 2
	}

	public TriggerCondition m_triggerCondition;

	private int m_playerInTriggerCount;
}
