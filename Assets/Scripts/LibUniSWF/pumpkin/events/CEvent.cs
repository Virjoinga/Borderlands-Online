namespace pumpkin.events
{
	public class CEvent
	{
		public static string ENTER_FRAME = "ENTER_FRAME";

		public static string RESIZE = "RESIZE";

		public static string COMPLETE = "COMPLETE";

		public static string CHANGED = "CHANGED";

		public static string ADDED_TO_STAGE = "ADDED_TO_STAGE";

		public static string REMOVED_FROM_STAGE = "REMOVED_FROM_STAGE";

		public object currentTarget;

		public object target;

		public bool used = false;

		public int eventPhase = 0;

		private bool m_Bubbles = false;

		private bool m_Cancelable = false;

		private bool m_Cancelled = false;

		private bool m_CancelledImmediate = false;

		private string m_Type;

		public string type
		{
			get
			{
				return m_Type;
			}
		}

		public bool bubbles
		{
			get
			{
				return m_Bubbles;
			}
		}

		public bool cancelable
		{
			get
			{
				return m_Cancelable;
			}
		}

		public CEvent(CEvent e)
		{
			m_Type = e.type;
			currentTarget = e.currentTarget;
			target = e.target;
		}

		public CEvent(string type)
		{
			m_Type = type;
			m_Bubbles = false;
			m_Cancelable = false;
		}

		public CEvent(string type, bool bubbles, bool cancelable)
		{
			m_Type = type;
			m_Bubbles = bubbles;
			m_Cancelable = cancelable;
		}

		public T toEvent<T>() where T : CEvent
		{
			return this as T;
		}

		public T toTarget<T>() where T : class
		{
			return target as T;
		}

		public bool isCancelled()
		{
			return m_Cancelled;
		}

		public bool isImmediateCancelled()
		{
			return m_CancelledImmediate;
		}

		public void cancel()
		{
			m_Cancelled = true;
		}

		public void cancelImmediate()
		{
			m_CancelledImmediate = true;
		}
	}
}
