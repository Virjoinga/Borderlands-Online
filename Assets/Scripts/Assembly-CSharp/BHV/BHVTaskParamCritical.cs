namespace BHV
{
	public sealed class BHVTaskParamCritical : BHVTaskParam
	{
		public float c23144d4b849283cd12fc6407ffc6f9ec;

		public float c7f97aec003e27fbe84f9c9bdb4319b8b;

		public BHVTaskParamCritical()
		{
			base.m_Type = BHVTaskType.Critical;
			c23144d4b849283cd12fc6407ffc6f9ec = 1f;
			c7f97aec003e27fbe84f9c9bdb4319b8b = 1f;
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = c23144d4b849283cd12fc6407ffc6f9ec;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = c7f97aec003e27fbe84f9c9bdb4319b8b;
						return;
					}
				}
			}
			c23144d4b849283cd12fc6407ffc6f9ec = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			c7f97aec003e27fbe84f9c9bdb4319b8b = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
		}
	}
}
