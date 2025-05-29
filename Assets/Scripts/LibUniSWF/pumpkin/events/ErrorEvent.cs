namespace pumpkin.events
{
	public class ErrorEvent : CEvent
	{
		public static string ERROR = "ERROR";

		public string error;

		public ErrorEvent(string name)
			: base(name)
		{
		}
	}
}
