namespace pumpkin.events
{
	public class KeyboardEvent : CEvent
	{
		public static string KEY_DOWN = "KEY_DOWN";

		public static string KEY_UP = "KEY_UP";

		public bool altKey;

		public string charString;

		public uint charCode;

		public bool commandKey;

		public bool controlKey;

		public bool ctrlKey;

		public uint keyCode;

		public bool shiftKey;

		public KeyboardEvent(string type, bool bubbles, bool cancelable)
			: base(type, bubbles, cancelable)
		{
		}
	}
}
