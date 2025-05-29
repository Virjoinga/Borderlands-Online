namespace BHV
{
	public sealed class BHVTaskParamSuicide : BHVTaskParam
	{
		public float c6eec9c03360117ad1f3f68c77abdce44;

		public BHVTaskParamSuicide()
		{
			base.m_Type = BHVTaskType.Suicide;
			c6eec9c03360117ad1f3f68c77abdce44 = 2f;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59 = c6eec9c03360117ad1f3f68c77abdce44;
						return;
					}
				}
			}
			c6eec9c03360117ad1f3f68c77abdce44 = c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59;
		}
	}
}
