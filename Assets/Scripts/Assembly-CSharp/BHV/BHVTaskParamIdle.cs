namespace BHV
{
	public sealed class BHVTaskParamIdle : BHVTaskParam
	{
		public BHVStance cabd31980fc78efe17153b1acf216a763;

		public BHVStressLevel c49fa7495bf59da1fbd770224875a9971;

		public float c8d6d0618a619c5377bfa2192b652bb59;

		public BHVTaskParamIdle()
		{
			base.m_Type = BHVTaskType.Idle;
			cabd31980fc78efe17153b1acf216a763 = BHVStance.STAND;
			c49fa7495bf59da1fbd770224875a9971 = BHVStressLevel.RELAX;
			c8d6d0618a619c5377bfa2192b652bb59 = -1f;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.cabd31980fc78efe17153b1acf216a763 = cabd31980fc78efe17153b1acf216a763;
						c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59 = c8d6d0618a619c5377bfa2192b652bb59;
						c90756c75001df916758775f95eee6676.c49fa7495bf59da1fbd770224875a9971 = c49fa7495bf59da1fbd770224875a9971;
						return;
					}
				}
			}
			cabd31980fc78efe17153b1acf216a763 = c90756c75001df916758775f95eee6676.cabd31980fc78efe17153b1acf216a763;
			c8d6d0618a619c5377bfa2192b652bb59 = c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59;
			c49fa7495bf59da1fbd770224875a9971 = c90756c75001df916758775f95eee6676.c49fa7495bf59da1fbd770224875a9971;
		}
	}
}
