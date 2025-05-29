namespace BHV
{
	public sealed class BHVTaskParamLightHurt : BHVTaskParam
	{
		public EDamageType cba943e9241e86ef410ecc99294660143;

		public BHVTaskParamLightHurt()
		{
			base.m_Type = BHVTaskType.LightHurt;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
			cba943e9241e86ef410ecc99294660143 = EDamageType.DT_Light;
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
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = (int)cba943e9241e86ef410ecc99294660143;
						return;
					}
				}
			}
			cba943e9241e86ef410ecc99294660143 = (EDamageType)c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
		}
	}
}
