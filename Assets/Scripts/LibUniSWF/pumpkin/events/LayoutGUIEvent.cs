namespace pumpkin.events
{
	public class LayoutGUIEvent : CEvent
	{
		public static string LAYOUT_GUI = "LayoutGUI";

		public LayoutGUIEvent()
			: base(LAYOUT_GUI)
		{
		}
	}
}
