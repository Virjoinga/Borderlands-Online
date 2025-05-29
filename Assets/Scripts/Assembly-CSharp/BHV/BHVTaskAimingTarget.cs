using A;

namespace BHV
{
	public class BHVTaskAimingTarget : BHVTask
	{
		private BHVTaskParamAimingTarget c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskAimingTarget()
		{
			base.m_Type = BHVTaskType.AimingTarget;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamAimingTarget;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			if (!(c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					return;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						return;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_animationEventController.c1e667d6f38b9e5836b1229ac7567f858(c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65);
						return;
					}
				}
			}
		}

		public override void Update(float deltaTime)
		{
			base.m_Status = BHVTaskStatus.SUCCESS;
		}
	}
}
