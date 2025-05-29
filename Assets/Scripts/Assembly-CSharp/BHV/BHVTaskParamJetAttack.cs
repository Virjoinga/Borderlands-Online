using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamJetAttack : BHVTaskParam
	{
		public GameObject cef07c0192edda4db06f1628b4d2e6f65;

		public AIServiceCurve.ECurveType c7c0b0bb3fcbb12184c4ba35b9a3d66b5;

		public float c992b4ed49627f10342a70e74e25df1bc;

		public float c74fe9e294614cfc03baaffde91421ca6;

		private int c0f562bde5ff2d23731b86c07aaa322bc;

		public BHVTaskParamJetAttack()
		{
			base.m_Type = BHVTaskType.JetAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			cef07c0192edda4db06f1628b4d2e6f65 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c992b4ed49627f10342a70e74e25df1bc = 10f;
			c7c0b0bb3fcbb12184c4ba35b9a3d66b5 = AIServiceCurve.ECurveType.EJumpCurve;
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
					switch (3)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c0f562bde5ff2d23731b86c07aaa322bc;
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = (int)c7c0b0bb3fcbb12184c4ba35b9a3d66b5;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = c992b4ed49627f10342a70e74e25df1bc;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = c74fe9e294614cfc03baaffde91421ca6;
						return;
					}
				}
			}
			c0f562bde5ff2d23731b86c07aaa322bc = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			c7c0b0bb3fcbb12184c4ba35b9a3d66b5 = (AIServiceCurve.ECurveType)c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			c992b4ed49627f10342a70e74e25df1bc = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			c74fe9e294614cfc03baaffde91421ca6 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
		}
	}
}
