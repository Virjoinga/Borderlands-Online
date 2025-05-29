using System;
using A;
using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamTutorialAction : BHVTaskParamAnimationState
	{
		public GameObject cf4a0caae0789fc3d553c1d52437db5c7;

		public ClusterAction_ResetTutorTask.TutorAction c35778562dc0ab8270da0e80176a5f9e9;

		public float ca2728538eeb75121c6ee449b6081cfd7;

		public BHVTaskParamTutorialAction()
		{
			base.m_Type = BHVTaskType.TutorialAction;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			cf4a0caae0789fc3d553c1d52437db5c7 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			c35778562dc0ab8270da0e80176a5f9e9 = ClusterAction_ResetTutorTask.TutorAction.None;
			ca2728538eeb75121c6ee449b6081cfd7 = 1f;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c = (int)c35778562dc0ab8270da0e80176a5f9e9;
						return;
					}
				}
			}
			int ced9a270aeae5659c2bbbc8d0499be56c = c90756c75001df916758775f95eee6676.ced9a270aeae5659c2bbbc8d0499be56c;
			if (Enum.IsDefined(typeof(ClusterAction_ResetTutorTask.TutorAction), ced9a270aeae5659c2bbbc8d0499be56c))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						c35778562dc0ab8270da0e80176a5f9e9 = (ClusterAction_ResetTutorTask.TutorAction)ced9a270aeae5659c2bbbc8d0499be56c;
						return;
					}
				}
			}
			c35778562dc0ab8270da0e80176a5f9e9 = ClusterAction_ResetTutorTask.TutorAction.None;
		}
	}
}
