using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskTutorialLesson : BHVTaskAnimationState
	{
		private BHVTaskParamTutorialLesson c2227ddc7fcbe3fa329465d2fa8ffb479;

		private ClapTrapTutorAnimationManagerFSM c0903d98f403428f871b8667c86c7895a;

		private float ca2728538eeb75121c6ee449b6081cfd7;

		private EntityPlayer c2ce7aed7199d86dcf98020c5bbee00ee;

		public BHVTaskTutorialLesson()
		{
			base.m_Type = BHVTaskType.TutorialLesson;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamTutorialLesson;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c0903d98f403428f871b8667c86c7895a = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as ClapTrapTutorAnimationManagerFSM;
			c0903d98f403428f871b8667c86c7895a.m_lessonMessage = c2227ddc7fcbe3fa329465d2fa8ffb479.cbc48769f4d8e0cbc503309d5baeb0412;
			ca2728538eeb75121c6ee449b6081cfd7 = 0f;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.TutorialLesson);
			ca2728538eeb75121c6ee449b6081cfd7 += deltaTime;
			if (!(ca2728538eeb75121c6ee449b6081cfd7 > c2227ddc7fcbe3fa329465d2fa8ffb479.ca2728538eeb75121c6ee449b6081cfd7))
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				ca2728538eeb75121c6ee449b6081cfd7 = 0f;
				c0903d98f403428f871b8667c86c7895a.m_showMessage = !c0903d98f403428f871b8667c86c7895a.m_showMessage;
				return;
			}
		}

		private void cc46841b8ed78cf172ccc816a5482cbfe()
		{
			if (c2ce7aed7199d86dcf98020c5bbee00ee == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return;
					}
				}
			}
			Vector3 to = c2ce7aed7199d86dcf98020c5bbee00ee.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position;
			to.y = 0f;
			if (to.sqrMagnitude < float.Epsilon)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			Vector3 forward = Vector3.Lerp(cfc241af7ab51814fc074e767be1a0bb8.transform.forward, to, 0.03f);
			cfc241af7ab51814fc074e767be1a0bb8.transform.forward = forward;
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			c0903d98f403428f871b8667c86c7895a.m_showMessage = false;
		}
	}
}
