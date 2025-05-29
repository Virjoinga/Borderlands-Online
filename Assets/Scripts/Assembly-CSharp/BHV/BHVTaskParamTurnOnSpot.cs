using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamTurnOnSpot : BHVTaskParam
	{
		public GameObject ca0c376bdd2ff6a3b6ad6e051444cd3c7;

		private int c9fc37d5a59e2c8a2fc12f2db5f780aaa;

		public BHVTaskParamTurnOnSpot()
		{
			base.m_Type = BHVTaskType.TurnOnSpot;
			ca0c376bdd2ff6a3b6ad6e051444cd3c7 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c9fc37d5a59e2c8a2fc12f2db5f780aaa = -1;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			ca0c376bdd2ff6a3b6ad6e051444cd3c7 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c9fc37d5a59e2c8a2fc12f2db5f780aaa);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c9fc37d5a59e2c8a2fc12f2db5f780aaa = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(ca0c376bdd2ff6a3b6ad6e051444cd3c7);
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
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c9fc37d5a59e2c8a2fc12f2db5f780aaa;
						return;
					}
				}
			}
			c9fc37d5a59e2c8a2fc12f2db5f780aaa = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
		}
	}
}
