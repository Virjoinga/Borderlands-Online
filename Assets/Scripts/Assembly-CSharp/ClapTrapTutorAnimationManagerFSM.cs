using A;
using BHV;

public class ClapTrapTutorAnimationManagerFSM : NPCAnimationManagerFSM
{
	public string m_lessonMessage;

	public bool m_showMessage;

	public override void Update()
	{
		base.Update();
		if (!(base.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (base.cc2c8af567962955d6c13e1bff99b395d == BHVStressLevel.RELAX)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", true);
						return;
					}
				}
			}
			if (base.cc2c8af567962955d6c13e1bff99b395d != BHVStressLevel.ALERT)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				base.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsCasual", false);
				return;
			}
		}
	}
}
