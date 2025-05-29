public class LevelTrigger : LevelObjectSync
{
	public bool m_useOnce;

	protected bool m_used;

	public override void ccdbe4e8fac6da17241ea3a84ac4a449c(LevelObjectSyncState c17fcd0ed1024ad7689991a96ed60deb1)
	{
		if (!m_useOnce)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_used)
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				LevelObjectSyncState levelObjectSyncState = c285c6dfb3039cfe6087d40143faf7488();
				base.ccdbe4e8fac6da17241ea3a84ac4a449c(c17fcd0ed1024ad7689991a96ed60deb1);
				LevelObjectSyncState levelObjectSyncState2 = c285c6dfb3039cfe6087d40143faf7488();
				m_used |= levelObjectSyncState != levelObjectSyncState2;
				return;
			}
		}
	}
}
