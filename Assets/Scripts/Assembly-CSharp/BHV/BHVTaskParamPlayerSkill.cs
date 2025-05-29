namespace BHV
{
	public sealed class BHVTaskParamPlayerSkill : BHVTaskParam
	{
		public ESkillStatePhase c6cb0ad55015fbddefd0fd66876c7d5f4;

		public BHVTaskParamPlayerSkill()
		{
			base.m_Type = BHVTaskType.PlayerSkill;
			c6cb0ad55015fbddefd0fd66876c7d5f4 = ESkillStatePhase.First;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = (int)c6cb0ad55015fbddefd0fd66876c7d5f4;
						return;
					}
				}
			}
			c6cb0ad55015fbddefd0fd66876c7d5f4 = (ESkillStatePhase)c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
		}
	}
}
