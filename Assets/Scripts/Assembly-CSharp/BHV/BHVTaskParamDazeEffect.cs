namespace BHV
{
	public sealed class BHVTaskParamDazeEffect : BHVTaskParam
	{
		public float c23868d8f6b3ff373c1ea4198c761096e = 1f;

		public BHVTaskParamDazeEffect()
		{
			base.m_Type = BHVTaskType.DazeEffect;
			base.m_Layer = BHVTaskLayer.EFFECT;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = c23868d8f6b3ff373c1ea4198c761096e;
						return;
					}
				}
			}
			c23868d8f6b3ff373c1ea4198c761096e = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
		}
	}
}
