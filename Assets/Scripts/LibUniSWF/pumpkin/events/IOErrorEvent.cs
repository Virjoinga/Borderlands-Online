namespace pumpkin.events
{
	public class IOErrorEvent : ErrorEvent
	{
		public static string IO_ERROR = "IO_ERROR";

		public int statusCode;

		public IOErrorEvent(string name)
			: base(name)
		{
		}
	}
}
