namespace BHV
{
	public sealed class BHVTaskParamDeployAidStation : BHVTaskParam
	{
		public float c4b415c55c2a1d3c1ec298e8162d26a19;

		public float c77dfedaf68b01ed948a128b736340136;

		public int c1fc503d62a75dd58929c053e4dc11c43;

		public BHVTaskParamDeployAidStation()
		{
			base.m_Type = BHVTaskType.DeployAidStation;
			c4b415c55c2a1d3c1ec298e8162d26a19 = 10f;
			c77dfedaf68b01ed948a128b736340136 = 10f;
			c1fc503d62a75dd58929c053e4dc11c43 = 300;
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = c4b415c55c2a1d3c1ec298e8162d26a19;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = c77dfedaf68b01ed948a128b736340136;
						return;
					}
				}
			}
			c4b415c55c2a1d3c1ec298e8162d26a19 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			c77dfedaf68b01ed948a128b736340136 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
		}
	}
}
