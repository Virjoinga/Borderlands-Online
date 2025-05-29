using A;
using XsdSettings;

public class SkillItem
{
	public ESkillType m_type;

	private int m_maxGrade;

	public int m_expect_grade;

	private EntityPlayer m_localPlayer;

	public int c1b5726f54c8d3b91eb210c6161ede742
	{
		get
		{
			if (m_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
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
				m_localPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			}
			return m_localPlayer.c02f3d4a4e7d1edee179f9bf7e16aeb82.ca019ed8e32c3f9618e8c8d060dcff0cd(m_type);
		}
	}

	public SkillItem(ESkillType c4f09c39924e70788c7b055c1d1490578, int cb192723869bc48ea5d2017bac40dcbab = 5)
	{
		m_type = c4f09c39924e70788c7b055c1d1490578;
		m_maxGrade = cb192723869bc48ea5d2017bac40dcbab;
	}

	public void OnClick()
	{
		m_expect_grade = (c1b5726f54c8d3b91eb210c6161ede742 + 1) % (m_maxGrade + 1);
	}

	public string c2835e119bf53e3745d16fb1b15f9a690()
	{
		string empty = string.Empty;
		Skill skill = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc68b2da7036261f61f86280fd6e61748((int)m_type);
		if (skill.m_effectList[0].m_type == EffectType.Invalid)
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
					return m_type.ToString();
				}
			}
		}
		return skill.m_effectList[0].m_type.ToString();
	}
}
