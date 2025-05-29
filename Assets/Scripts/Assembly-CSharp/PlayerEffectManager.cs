using XsdSettings;

public class PlayerEffectManager
{
	private EntityPlayer m_owner;

	public PlayerEffectManager(EntityPlayer cf811c0d5de19d7fe22be8d61350b722d)
	{
		m_owner = cf811c0d5de19d7fe22be8d61350b722d;
	}

	public float c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType c4f09c39924e70788c7b055c1d1490578)
	{
		AffectType affectType = m_owner.c02f3d4a4e7d1edee179f9bf7e16aeb82.c6dc389961c519ce61badd4f5a6569fb3(c4f09c39924e70788c7b055c1d1490578);
		float num = m_owner.c02f3d4a4e7d1edee179f9bf7e16aeb82.ce4b7562d91f6077f573c5f5fa3d3e6dc(c4f09c39924e70788c7b055c1d1490578);
		float num2 = m_owner.c82b441c4ab4c45d35a689807a8f0c6f8(c4f09c39924e70788c7b055c1d1490578, affectType);
		float num3 = m_owner.c3a15a166aa68b5653f6e42643cca86b8(c4f09c39924e70788c7b055c1d1490578, affectType);
		float num4 = m_owner.ce16b18b2cda29a0e71fd54cf507bd7f6(c4f09c39924e70788c7b055c1d1490578, affectType);
		float num5 = num;
		if (affectType == AffectType.Scale)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					num5 *= num2;
					num5 *= num3;
					return num5 * num4;
				}
			}
		}
		num5 += num2;
		num5 += num3;
		return num5 + num4;
	}

	public static void c6a8566138d6dfc8766a96d964aca4d2d(EffectType c4f09c39924e70788c7b055c1d1490578, string c2b72f83d79e58e8996514b22aa4e82e3, float c4c2ec96a282f0d5bec78d25d7351942b)
	{
	}
}
