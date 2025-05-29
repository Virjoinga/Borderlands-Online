namespace BHV
{
	public sealed class BHVTaskParamDead : BHVTaskParam
	{
		public float c588e32794066adce62c15ff7e74ad1e1 = 1f;

		public BHVTaskParamDead()
		{
			base.m_Type = BHVTaskType.Dead;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59 = c588e32794066adce62c15ff7e74ad1e1;
						return;
					}
				}
			}
			c588e32794066adce62c15ff7e74ad1e1 = c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59;
		}
	}
}
