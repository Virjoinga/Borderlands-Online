namespace BHV
{
	public sealed class BHVTaskParamEarthPikeAttack : BHVTaskParam
	{
		public int c234a225e5146e18834e6facf5ee08720;

		public BHVTaskParamEarthPikeAttack()
		{
			base.m_Type = BHVTaskType.EarthPikeAttack;
			c234a225e5146e18834e6facf5ee08720 = 0;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c = c234a225e5146e18834e6facf5ee08720;
						return;
					}
				}
			}
			c234a225e5146e18834e6facf5ee08720 = c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c;
		}
	}
}
