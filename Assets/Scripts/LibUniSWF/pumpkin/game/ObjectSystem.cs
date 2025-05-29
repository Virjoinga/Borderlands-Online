using pumpkin.events;

namespace pumpkin.game
{
	public class ObjectSystem : EventDispatcher
	{
		private static ObjectSystem g_instance = null;

		public static ObjectSystem instance
		{
			get
			{
				if (g_instance == null)
				{
					g_instance = new ObjectSystem();
				}
				return g_instance;
			}
			set
			{
				g_instance = value;
			}
		}

		public ObjectSystem()
		{
			g_instance = this;
		}
	}
}
