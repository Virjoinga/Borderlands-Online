namespace BHV
{
	public sealed class BHVTaskParamDestoryMissile : BHVTaskParam
	{
		public int cb0afba6c0e46440994e8d5aabeafccd4;

		public int c894d137ec42f10f37a5582cf60893357;

		public BHVTaskParamDestoryMissile()
		{
			base.m_Type = BHVTaskType.DestoryMissile;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
			cb0afba6c0e46440994e8d5aabeafccd4 = 0;
			c894d137ec42f10f37a5582cf60893357 = 0;
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
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = cb0afba6c0e46440994e8d5aabeafccd4;
						c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c = c894d137ec42f10f37a5582cf60893357;
						return;
					}
				}
			}
			cb0afba6c0e46440994e8d5aabeafccd4 = c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			c894d137ec42f10f37a5582cf60893357 = c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c;
		}
	}
}
