namespace BHV
{
	public sealed class BHVTaskParamWarcry : BHVTaskParamAnimationState
	{
		public bool c219a696a1a78b8a7787c1c5082d9c00d;

		public int c6cb0ad55015fbddefd0fd66876c7d5f4;

		public BHVTaskParamWarcry()
		{
			base.m_Type = BHVTaskType.Warcry;
			c219a696a1a78b8a7787c1c5082d9c00d = false;
			c6cb0ad55015fbddefd0fd66876c7d5f4 = 0;
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
						c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b = c219a696a1a78b8a7787c1c5082d9c00d;
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = c6cb0ad55015fbddefd0fd66876c7d5f4;
						return;
					}
				}
			}
			c219a696a1a78b8a7787c1c5082d9c00d = c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b;
			c6cb0ad55015fbddefd0fd66876c7d5f4 = c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
		}
	}
}
