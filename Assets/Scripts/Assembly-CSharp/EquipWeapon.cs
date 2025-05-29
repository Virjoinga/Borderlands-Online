public class EquipWeapon : Action
{
	protected override void c413183a79233cd0411af23b0f0c942f4()
	{
		EntityPlayer entityPlayer = m_entity as EntityPlayer;
		if (!(entityPlayer is EntityPlayer))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			entityPlayer.c844f5821f637596bbd1ae6eeddee90c9((byte)((uint)m_param & 0xFFu), (byte)((m_param & 0xFF00) >> 8));
			return;
		}
	}
}
