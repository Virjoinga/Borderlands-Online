using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamMoveTo : BHVTaskParam
	{
		private Vector3 c648481d79520e4e188c2a48804bbc3de;

		private int c370f0a9bbc78df0907c2b8cce97a94ba;

		private GameObject c339eb87c0b06ab08302ec1c72e02a847;

		public BHVStressLevel c49fa7495bf59da1fbd770224875a9971;

		public BHVMovementSpeed c034f614b05c66464092b15f427ea086d;

		public bool ce16937d8aca427101b7ddcbda8a6f2e5;

		public Vector3 c75bb13b321fa8ddcc40591ac3c482642
		{
			get
			{
				return c648481d79520e4e188c2a48804bbc3de;
			}
			set
			{
				c648481d79520e4e188c2a48804bbc3de = value;
			}
		}

		public GameObject c969ced5e29082e1780d7af4e5304c2bc
		{
			get
			{
				return c339eb87c0b06ab08302ec1c72e02a847;
			}
			set
			{
				c339eb87c0b06ab08302ec1c72e02a847 = value;
			}
		}

		public BHVTaskParamMoveTo()
		{
			base.m_Type = BHVTaskType.MoveTo;
			c75bb13b321fa8ddcc40591ac3c482642 = Vector3.zero;
			c49fa7495bf59da1fbd770224875a9971 = BHVStressLevel.RELAX;
			c034f614b05c66464092b15f427ea086d = BHVMovementSpeed.INVALID;
			c370f0a9bbc78df0907c2b8cce97a94ba = -1;
			ce16937d8aca427101b7ddcbda8a6f2e5 = true;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			c969ced5e29082e1780d7af4e5304c2bc = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c370f0a9bbc78df0907c2b8cce97a94ba);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c370f0a9bbc78df0907c2b8cce97a94ba = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(c969ced5e29082e1780d7af4e5304c2bc);
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = c75bb13b321fa8ddcc40591ac3c482642;
						c90756c75001df916758775f95eee6676.c49fa7495bf59da1fbd770224875a9971 = c49fa7495bf59da1fbd770224875a9971;
						c90756c75001df916758775f95eee6676.c034f614b05c66464092b15f427ea086d = c034f614b05c66464092b15f427ea086d;
						c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6 = c370f0a9bbc78df0907c2b8cce97a94ba;
						return;
					}
				}
			}
			c75bb13b321fa8ddcc40591ac3c482642 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
			c49fa7495bf59da1fbd770224875a9971 = c90756c75001df916758775f95eee6676.c49fa7495bf59da1fbd770224875a9971;
			c034f614b05c66464092b15f427ea086d = c90756c75001df916758775f95eee6676.c034f614b05c66464092b15f427ea086d;
			c370f0a9bbc78df0907c2b8cce97a94ba = c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6;
		}
	}
}
