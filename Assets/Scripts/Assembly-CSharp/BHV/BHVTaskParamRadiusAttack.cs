namespace BHV
{
	public sealed class BHVTaskParamRadiusAttack : BHVTaskParamAnimationState
	{
		public float cbfe48220d0686c9350881808f74550ba;

		public BHVTaskParamRadiusAttack()
		{
			cbfe48220d0686c9350881808f74550ba = 5f;
			base.m_Type = BHVTaskType.RadiusAttack;
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = cbfe48220d0686c9350881808f74550ba;
						return;
					}
				}
			}
			cbfe48220d0686c9350881808f74550ba = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
		}
	}
}
