using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamFlyMeleeAttack : BHVTaskParam
	{
		public GameObject cef07c0192edda4db06f1628b4d2e6f65;

		public bool ca2633e89d18716d27bb002d0d98040c4;

		private int c0f562bde5ff2d23731b86c07aaa322bc;

		public BHVTaskParamFlyMeleeAttack()
		{
			base.m_Type = BHVTaskType.FlyMeleeAttack;
			cef07c0192edda4db06f1628b4d2e6f65 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			ca2633e89d18716d27bb002d0d98040c4 = false;
			c0f562bde5ff2d23731b86c07aaa322bc = -1;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			cef07c0192edda4db06f1628b4d2e6f65 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c0f562bde5ff2d23731b86c07aaa322bc);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c0f562bde5ff2d23731b86c07aaa322bc = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(cef07c0192edda4db06f1628b4d2e6f65);
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
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c0f562bde5ff2d23731b86c07aaa322bc;
						c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b = ca2633e89d18716d27bb002d0d98040c4;
						return;
					}
				}
			}
			c0f562bde5ff2d23731b86c07aaa322bc = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			ca2633e89d18716d27bb002d0d98040c4 = c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b;
		}
	}
}
