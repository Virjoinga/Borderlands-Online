namespace pumpkin.events
{
	public class DragEvent : CEvent
	{
		public static string QUERY = "dragQuery";

		public static string DROP = "dragDrop";

		public object draggedItem = null;

		public object draggedSource = null;

		public object acceptedTarget = null;

		public DragEvent(string type)
			: base(type)
		{
		}

		public DragEvent(string type, bool bubbles, bool cancelable)
			: base(type, bubbles, cancelable)
		{
		}
	}
}
