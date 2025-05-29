namespace BHV
{
	public sealed class BHVTaskParamRoll : BHVTaskParamAnimationState
	{
		public bool c2709c6a07153f2c4768a8d9a4995c0cd;

		public BHVTaskParamRoll()
		{
			base.m_Type = BHVTaskType.Roll;
			c2709c6a07153f2c4768a8d9a4995c0cd = false;
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
						c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b = c2709c6a07153f2c4768a8d9a4995c0cd;
						return;
					}
				}
			}
			c2709c6a07153f2c4768a8d9a4995c0cd = c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b;
		}
	}
}
