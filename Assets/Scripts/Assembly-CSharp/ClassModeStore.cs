public class ClassModeStore
{
	public ClassModeAttribute m_classModeAttr = new ClassModeAttribute();

	private static ClassModeStore s_classModeStore;

	public static ClassModeStore c5746c01b9c551e1a09e615700c47269f
	{
		get
		{
			if (s_classModeStore == null)
			{
				while (true)
				{
					switch (2)
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
				s_classModeStore = new ClassModeStore();
			}
			return s_classModeStore;
		}
		protected set
		{
			s_classModeStore = value;
		}
	}
}
