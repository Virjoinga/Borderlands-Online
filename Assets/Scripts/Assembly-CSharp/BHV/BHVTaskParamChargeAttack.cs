using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamChargeAttack : BHVTaskParam
	{
		public Vector3 c8a2af45a880b27fa0012457d167c4b27;

		public BHVTaskParamChargeAttack()
		{
			base.m_Type = BHVTaskType.ChargeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			c8a2af45a880b27fa0012457d167c4b27 = Vector3.zero;
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = c8a2af45a880b27fa0012457d167c4b27;
						return;
					}
				}
			}
			c8a2af45a880b27fa0012457d167c4b27 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
		}
	}
}
