using System.Collections;

namespace pumpkin.events
{
	public class EventManager
	{
		private ArrayList eventDisptachers = new ArrayList();

		public void registerEventDispatcher(EventDispatcher e)
		{
			eventDisptachers.Add(e);
		}

		public void unregisterEventDispatcher(EventDispatcher e)
		{
			eventDisptachers.Remove(e);
		}
	}
}
