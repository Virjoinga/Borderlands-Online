namespace BHV
{
	public class BHVTaskCritical : BHVTask
	{
		private BHVTaskParamCritical c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c23144d4b849283cd12fc6407ffc6f9ec;

		private bool c76eedde54b6bf230d5ab9c5853ed351b;

		private AnimationCriticalState c2344ff7514bdaf841fe643067e57e827;

		public BHVTaskCritical()
		{
			base.m_Type = BHVTaskType.Critical;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCritical;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c23144d4b849283cd12fc6407ffc6f9ec = 0f;
			c76eedde54b6bf230d5ab9c5853ed351b = false;
			c2344ff7514bdaf841fe643067e57e827 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Critical") as AnimationCriticalState;
			base.m_Status = BHVTaskStatus.RUNNING;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Critical);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!c76eedde54b6bf230d5ab9c5853ed351b)
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
						c23144d4b849283cd12fc6407ffc6f9ec += deltaTime;
						if (c23144d4b849283cd12fc6407ffc6f9ec > c2227ddc7fcbe3fa329465d2fa8ffb479.c23144d4b849283cd12fc6407ffc6f9ec)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									c2344ff7514bdaf841fe643067e57e827.c2cb84426c1cd54153f2ec195afb13f78(true);
									c76eedde54b6bf230d5ab9c5853ed351b = true;
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (!c2344ff7514bdaf841fe643067e57e827.m_bStruggleEnd)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			c2344ff7514bdaf841fe643067e57e827.c9b705087038f2941555886d276842c8f(false);
		}
	}
}
