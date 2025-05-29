namespace pumpkin.events
{
	public class LogEvent : CEvent
	{
		public static string LOGEVENT = "LOGEVENT";

		public int level;

		public string logStr;

		public LogEvent(int level, string logStr)
			: base(LOGEVENT)
		{
			this.level = level;
			this.logStr = logStr;
		}
	}
}
