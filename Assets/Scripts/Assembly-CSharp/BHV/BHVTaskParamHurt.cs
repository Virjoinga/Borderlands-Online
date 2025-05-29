namespace BHV
{
	public sealed class BHVTaskParamHurt : BHVTaskParamAnimationState
	{
		public EDamageType cba943e9241e86ef410ecc99294660143;

		public int cb8205628bc070a20f3fb0d80dbfef005;

		public BHVTaskParamHurt()
		{
			base.m_Type = BHVTaskType.Hurt;
			cba943e9241e86ef410ecc99294660143 = EDamageType.DT_None;
			cb8205628bc070a20f3fb0d80dbfef005 = 0;
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
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = (int)cba943e9241e86ef410ecc99294660143;
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = cb8205628bc070a20f3fb0d80dbfef005;
						return;
					}
				}
			}
			cba943e9241e86ef410ecc99294660143 = (EDamageType)c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			cb8205628bc070a20f3fb0d80dbfef005 = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
		}
	}
}
