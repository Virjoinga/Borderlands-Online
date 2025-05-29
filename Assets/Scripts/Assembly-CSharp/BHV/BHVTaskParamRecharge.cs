using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamRecharge : BHVTaskParam
	{
		public GameObject cc98ce48a9d5760a53aee7ca82e028df0;

		private int c59fdf3ecec6fb130e518a895e4ac2ff4;

		public BHVTaskParamRecharge()
		{
			base.m_Type = BHVTaskType.Recharge;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			cc98ce48a9d5760a53aee7ca82e028df0 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c59fdf3ecec6fb130e518a895e4ac2ff4);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c59fdf3ecec6fb130e518a895e4ac2ff4 = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(cc98ce48a9d5760a53aee7ca82e028df0);
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
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c59fdf3ecec6fb130e518a895e4ac2ff4;
						return;
					}
				}
			}
			c59fdf3ecec6fb130e518a895e4ac2ff4 = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
		}
	}
}
