using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamIceMeteorAttack : BHVTaskParam
	{
		public enum EAttackMode
		{
			c86188343b4fbcf4c3b94b32228d85cb3 = 0,
			c9dd26a16091dae4899b0d1592b11d591 = 1
		}

		public int c9b36e132c2f043a337fddf91e2a1d3ba;

		public int c847416d37b991d227537108be7e018d6;

		public float cbfe48220d0686c9350881808f74550ba;

		public float cb04ae3d0740704306ed2b9109ba63ea1;

		public EAttackMode cd94e3de8ae7934ce3d7def2a31f129d7;

		public GameObject c14854daae2833463b186fc5cc589a09c;

		private int c0f562bde5ff2d23731b86c07aaa322bc;

		public BHVTaskParamIceMeteorAttack()
		{
			base.m_Type = BHVTaskType.IceMeteorAttack;
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
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c0f562bde5ff2d23731b86c07aaa322bc;
						c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6 = (int)cd94e3de8ae7934ce3d7def2a31f129d7;
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = c847416d37b991d227537108be7e018d6;
						c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59 = cb04ae3d0740704306ed2b9109ba63ea1;
						return;
					}
				}
			}
			c0f562bde5ff2d23731b86c07aaa322bc = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			cd94e3de8ae7934ce3d7def2a31f129d7 = (EAttackMode)c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6;
			c847416d37b991d227537108be7e018d6 = c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			cb04ae3d0740704306ed2b9109ba63ea1 = c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59;
		}
	}
}
