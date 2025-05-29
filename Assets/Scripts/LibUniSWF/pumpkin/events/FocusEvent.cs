namespace pumpkin.events
{
	public class FocusEvent : CEvent
	{
		public static string FOCUS_OUT = "FOCUS_OUT";

		public static string FOCUS_IN = "FOCUS_IN";

		public FocusEvent(string type, bool bubbles, bool cancelable)
			: base(type, bubbles, cancelable)
		{
		}
	}
}
