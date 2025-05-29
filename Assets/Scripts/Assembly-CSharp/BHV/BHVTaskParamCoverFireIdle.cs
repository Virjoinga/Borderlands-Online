using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamCoverFireIdle : BHVTaskParam
	{
		public CoverSlot.CoverHeight c717e5cc6398513ae1b501fafdc23be53;

		public GameObject cf4a0caae0789fc3d553c1d52437db5c7;

		public float c8d6d0618a619c5377bfa2192b652bb59;

		private int c5611894dccdb85f1301ba212f2ce913a;

		public Vector3 c8a2af45a880b27fa0012457d167c4b27;

		public BHVTaskParamCoverFireIdle()
		{
			base.m_Type = BHVTaskType.CoverFireIdle;
			base.m_Layer = BHVTaskLayer.TOPBODY;
			c717e5cc6398513ae1b501fafdc23be53 = CoverSlot.CoverHeight.INVALID;
			c8d6d0618a619c5377bfa2192b652bb59 = 0f;
			cf4a0caae0789fc3d553c1d52437db5c7 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c8a2af45a880b27fa0012457d167c4b27 = Vector3.zero;
			c8a2af45a880b27fa0012457d167c4b27.ce62cd2a8f9b538cff3ad3698791f2854();
			c5611894dccdb85f1301ba212f2ce913a = -1;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			cf4a0caae0789fc3d553c1d52437db5c7 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c5611894dccdb85f1301ba212f2ce913a);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c5611894dccdb85f1301ba212f2ce913a = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(cf4a0caae0789fc3d553c1d52437db5c7);
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
						c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59 = c8d6d0618a619c5377bfa2192b652bb59;
						c90756c75001df916758775f95eee6676.c717e5cc6398513ae1b501fafdc23be53 = c717e5cc6398513ae1b501fafdc23be53;
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c5611894dccdb85f1301ba212f2ce913a;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = c8a2af45a880b27fa0012457d167c4b27;
						return;
					}
				}
			}
			c8d6d0618a619c5377bfa2192b652bb59 = c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59;
			c717e5cc6398513ae1b501fafdc23be53 = c90756c75001df916758775f95eee6676.c717e5cc6398513ae1b501fafdc23be53;
			c5611894dccdb85f1301ba212f2ce913a = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			c8a2af45a880b27fa0012457d167c4b27 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
		}
	}
}
