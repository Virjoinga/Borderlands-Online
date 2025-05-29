using UnityEngine;

namespace pumpkin.events
{
	public class MouseEvent : CEvent
	{
		public static string CLICK = "click";

		public static string MOUSE_DOWN = "mouseDown";

		public static string MOUSE_UP = "mouseUp";

		public static string MOUSE_MOVE = "mouseMove";

		public static string MOUSE_ENTER = "mouseEnter";

		public static string MOUSE_LEAVE = "mouseLeave";

		public float stageX;

		public float stageY;

		public int buttonId;

		public int touchId;

		public Touch touch;

		public Vector3 worldPos;

		public MouseEvent(string type)
			: base(type)
		{
		}

		public MouseEvent(string type, bool bubbles, bool cancelable)
			: base(type, bubbles, cancelable)
		{
		}
	}
}
