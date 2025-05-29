using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamEyeLaserPlus : BHVTaskParam
	{
		public GameObject cb9f7c51b162366e74587b2610dae6e64;

		public float ca8e64932c38c6e6fbc8e7a37caa55b3c;

		public float c588e32794066adce62c15ff7e74ad1e1 = 1f;

		public float c3f466c29c49a3403ee37f3f258a8d105 = 10f;

		public int cac690b00c0575f12f29d8afbc4f7a2d0 = 1;

		private int c5611894dccdb85f1301ba212f2ce913a;

		public BHVTaskParamEyeLaserPlus()
		{
			base.m_Type = BHVTaskType.EyeLaserPlus;
			cb9f7c51b162366e74587b2610dae6e64 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c5611894dccdb85f1301ba212f2ce913a = -1;
			ca8e64932c38c6e6fbc8e7a37caa55b3c = 0f;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			cb9f7c51b162366e74587b2610dae6e64 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c5611894dccdb85f1301ba212f2ce913a);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c5611894dccdb85f1301ba212f2ce913a = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(cb9f7c51b162366e74587b2610dae6e64);
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
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c5611894dccdb85f1301ba212f2ce913a;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = ca8e64932c38c6e6fbc8e7a37caa55b3c;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = c588e32794066adce62c15ff7e74ad1e1;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.z = c3f466c29c49a3403ee37f3f258a8d105;
						c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c = cac690b00c0575f12f29d8afbc4f7a2d0;
						return;
					}
				}
			}
			c5611894dccdb85f1301ba212f2ce913a = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			ca8e64932c38c6e6fbc8e7a37caa55b3c = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			c588e32794066adce62c15ff7e74ad1e1 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
			cac690b00c0575f12f29d8afbc4f7a2d0 = c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c;
			c3f466c29c49a3403ee37f3f258a8d105 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.z;
		}
	}
}
