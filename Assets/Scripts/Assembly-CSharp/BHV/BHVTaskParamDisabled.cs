namespace BHV
{
	public sealed class BHVTaskParamDisabled : BHVTaskParam
	{
		public bool c07fe8fb380346d1eece6117558fba23a;

		public bool c5653506405755a849ee3fa7c77cbc359;

		public BHVTaskParamDisabled()
		{
			base.m_Type = BHVTaskType.Disabled;
			c07fe8fb380346d1eece6117558fba23a = false;
			c5653506405755a849ee3fa7c77cbc359 = false;
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
						c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b = c07fe8fb380346d1eece6117558fba23a;
						c90756c75001df916758775f95eee6676.ccab717fa769c738ea9dcdf8b3947ebaa = c5653506405755a849ee3fa7c77cbc359;
						return;
					}
				}
			}
			c07fe8fb380346d1eece6117558fba23a = c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b;
			c5653506405755a849ee3fa7c77cbc359 = c90756c75001df916758775f95eee6676.ccab717fa769c738ea9dcdf8b3947ebaa;
		}
	}
}
