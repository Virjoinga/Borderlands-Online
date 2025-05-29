public class ShieldStore
{
	public ShieldAttribute m_shieldAttr = new ShieldAttribute();

	private static ShieldStore s_shieldStore;

	public static ShieldStore cf40d1e3d55cebc701245d293c7b71157
	{
		get
		{
			if (s_shieldStore == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				s_shieldStore = new ShieldStore();
			}
			return s_shieldStore;
		}
		protected set
		{
			s_shieldStore = value;
		}
	}
}
