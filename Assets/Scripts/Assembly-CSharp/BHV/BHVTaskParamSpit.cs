using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamSpit : BHVTaskParam
	{
		public int c7156b2a1d5fa4abd74f23a8857e87318;

		public GameObject c14854daae2833463b186fc5cc589a09c;

		public Vector3 cd8fb5149d22966973746da2de538bb78;

		private int c0f562bde5ff2d23731b86c07aaa322bc;

		public BHVTaskParamSpit()
		{
			base.m_Type = BHVTaskType.Spit;
			c7156b2a1d5fa4abd74f23a8857e87318 = 0;
			c14854daae2833463b186fc5cc589a09c = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c0f562bde5ff2d23731b86c07aaa322bc = -1;
			cd8fb5149d22966973746da2de538bb78 = Vector3.zero;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			c14854daae2833463b186fc5cc589a09c = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c0f562bde5ff2d23731b86c07aaa322bc);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c0f562bde5ff2d23731b86c07aaa322bc = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(c14854daae2833463b186fc5cc589a09c);
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = c7156b2a1d5fa4abd74f23a8857e87318;
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c0f562bde5ff2d23731b86c07aaa322bc;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = cd8fb5149d22966973746da2de538bb78;
						return;
					}
				}
			}
			c7156b2a1d5fa4abd74f23a8857e87318 = c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			c0f562bde5ff2d23731b86c07aaa322bc = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			cd8fb5149d22966973746da2de538bb78 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
		}
	}
}
