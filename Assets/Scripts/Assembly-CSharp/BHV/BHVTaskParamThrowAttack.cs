using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamThrowAttack : BHVTaskParam
	{
		public EThrowWeaponType c9272de37e17e3c0a58c626855320e6c8;

		public GameObject c14854daae2833463b186fc5cc589a09c;

		private int c0f562bde5ff2d23731b86c07aaa322bc;

		public BHVTaskParamThrowAttack()
		{
			base.m_Type = BHVTaskType.ThrowAttack;
			c9272de37e17e3c0a58c626855320e6c8 = EThrowWeaponType.c8abc6387b4646bc71b02b90b39c13720;
			c14854daae2833463b186fc5cc589a09c = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c0f562bde5ff2d23731b86c07aaa322bc = -1;
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
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = (int)c9272de37e17e3c0a58c626855320e6c8;
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c0f562bde5ff2d23731b86c07aaa322bc;
						return;
					}
				}
			}
			c9272de37e17e3c0a58c626855320e6c8 = (EThrowWeaponType)c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			c0f562bde5ff2d23731b86c07aaa322bc = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
		}
	}
}
