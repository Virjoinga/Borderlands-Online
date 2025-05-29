using A;

public class AntiAddiction
{
	public enum Level
	{
		NormalRewards = 0,
		HalfRewards = 1,
		NoRewards = 2
	}

	public static float ccb82e6b2e7ea42ec09135d0657ab0b7d(Level cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		if (cd6bb591c33b2ee3ab93e98aa43a6da63 != Level.HalfRewards)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (cd6bb591c33b2ee3ab93e98aa43a6da63 != Level.NoRewards)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return 1f;
							}
						}
					}
					return 0f;
				}
			}
		}
		return 0.5f;
	}

	public static Level c02a9ad8e6d82091fada7ba4dd60b5ead(int cdc9f6ace07173b95607c1a4b98439397)
	{
		if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 300f)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return Level.NoRewards;
				}
			}
		}
		if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 180f)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return Level.HalfRewards;
				}
			}
		}
		return Level.NormalRewards;
	}

	public static string ce195d62b7ed2e415d471893d74d8d9c7(int cdc9f6ace07173b95607c1a4b98439397)
	{
		string result = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 300f)
		{
			while (true)
			{
				switch (7)
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
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Anti_Addiction_5H"));
		}
		else if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 240f)
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
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Anti_Addiction_4H"));
		}
		else if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 180f)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Anti_Addiction_3H"));
		}
		else if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 120f)
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
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Anti_Addiction_2H"));
		}
		else if ((float)cdc9f6ace07173b95607c1a4b98439397 >= 60f)
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
			result = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Anti_Addiction_1H"));
		}
		return result;
	}
}
