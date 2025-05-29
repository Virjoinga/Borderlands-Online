namespace BHV
{
	public sealed class BHVTaskParamEnergyMissile : BHVTaskParam
	{
		public float ce940cde6a50e3e1cb24c50e5c3f2e590;

		public float cfdc3cc82b127c5db251d86a8906d1d39;

		public int c8e1a2faec8925b9197f4fa2c974bc6e5;

		public int c5049abb54085b94d5c9e368188cf9f6e;

		public BHVTaskParamEnergyMissile()
		{
			base.m_Type = BHVTaskType.EnergyMissile;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = ce940cde6a50e3e1cb24c50e5c3f2e590;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = cfdc3cc82b127c5db251d86a8906d1d39;
						c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c = c8e1a2faec8925b9197f4fa2c974bc6e5;
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = c5049abb54085b94d5c9e368188cf9f6e;
						return;
					}
				}
			}
			ce940cde6a50e3e1cb24c50e5c3f2e590 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			cfdc3cc82b127c5db251d86a8906d1d39 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
			c8e1a2faec8925b9197f4fa2c974bc6e5 = c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c;
			c5049abb54085b94d5c9e368188cf9f6e = c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
		}
	}
}
