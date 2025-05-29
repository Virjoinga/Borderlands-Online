using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamMoveWithFacing : BHVTaskParam
	{
		private int c9fc37d5a59e2c8a2fc12f2db5f780aaa;

		private int c370f0a9bbc78df0907c2b8cce97a94ba;

		public Vector3 c648481d79520e4e188c2a48804bbc3de;

		public GameObject ca0c376bdd2ff6a3b6ad6e051444cd3c7;

		public GameObject c339eb87c0b06ab08302ec1c72e02a847;

		public BHVStressLevel c49fa7495bf59da1fbd770224875a9971;

		public BHVMovementSpeed c034f614b05c66464092b15f427ea086d;

		public BHVTaskParamMoveWithFacing()
		{
			base.m_Type = BHVTaskType.MoveWithFacing;
			c648481d79520e4e188c2a48804bbc3de = Vector3.zero;
			ca0c376bdd2ff6a3b6ad6e051444cd3c7 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c339eb87c0b06ab08302ec1c72e02a847 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c49fa7495bf59da1fbd770224875a9971 = BHVStressLevel.RELAX;
			c034f614b05c66464092b15f427ea086d = BHVMovementSpeed.INVALID;
			c9fc37d5a59e2c8a2fc12f2db5f780aaa = -1;
			c370f0a9bbc78df0907c2b8cce97a94ba = -1;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			ca0c376bdd2ff6a3b6ad6e051444cd3c7 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c9fc37d5a59e2c8a2fc12f2db5f780aaa);
			c339eb87c0b06ab08302ec1c72e02a847 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c370f0a9bbc78df0907c2b8cce97a94ba);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c9fc37d5a59e2c8a2fc12f2db5f780aaa = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(ca0c376bdd2ff6a3b6ad6e051444cd3c7);
			c370f0a9bbc78df0907c2b8cce97a94ba = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(c339eb87c0b06ab08302ec1c72e02a847);
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = c648481d79520e4e188c2a48804bbc3de;
						c90756c75001df916758775f95eee6676.c49fa7495bf59da1fbd770224875a9971 = c49fa7495bf59da1fbd770224875a9971;
						c90756c75001df916758775f95eee6676.c034f614b05c66464092b15f427ea086d = c034f614b05c66464092b15f427ea086d;
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c9fc37d5a59e2c8a2fc12f2db5f780aaa;
						c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6 = c370f0a9bbc78df0907c2b8cce97a94ba;
						return;
					}
				}
			}
			c648481d79520e4e188c2a48804bbc3de = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
			c49fa7495bf59da1fbd770224875a9971 = c90756c75001df916758775f95eee6676.c49fa7495bf59da1fbd770224875a9971;
			c034f614b05c66464092b15f427ea086d = c90756c75001df916758775f95eee6676.c034f614b05c66464092b15f427ea086d;
			c9fc37d5a59e2c8a2fc12f2db5f780aaa = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			c370f0a9bbc78df0907c2b8cce97a94ba = c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6;
		}
	}
}
