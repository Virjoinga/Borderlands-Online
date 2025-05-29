namespace BHV
{
	public class BHVTaskTutorialAction : BHVTaskAnimationState
	{
		private BHVTaskParamTutorialAction c2227ddc7fcbe3fa329465d2fa8ffb479;

		private ClapTrapTutorAnimationManagerFSM c0903d98f403428f871b8667c86c7895a;

		private float ca2728538eeb75121c6ee449b6081cfd7;

		public BHVTaskTutorialAction()
		{
			base.m_Type = BHVTaskType.TutorialAction;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamTutorialAction;
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
			ca2728538eeb75121c6ee449b6081cfd7 = 0f;
			AnimationTutorialActionState animationTutorialActionState = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.TutorialAction)) as AnimationTutorialActionState;
			if (animationTutorialActionState == null)
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				animationTutorialActionState.m_tutorAction = c2227ddc7fcbe3fa329465d2fa8ffb479.c35778562dc0ab8270da0e80176a5f9e9;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.TutorialAction);
			ca2728538eeb75121c6ee449b6081cfd7 += deltaTime;
			if (!(ca2728538eeb75121c6ee449b6081cfd7 > c2227ddc7fcbe3fa329465d2fa8ffb479.ca2728538eeb75121c6ee449b6081cfd7))
			{
				return;
			}
			while (true)
			{
				switch (7)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		private void cc46841b8ed78cf172ccc816a5482cbfe()
		{
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			c0903d98f403428f871b8667c86c7895a.m_showMessage = false;
		}
	}
}
