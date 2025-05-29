namespace BHV
{
	public class BHVTaskRespawn : BHVTask
	{
		private BHVTaskParamRespawn c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c2a85d51c2f39eb0a2d661a26b084fc11;

		public BHVTaskRespawn()
		{
			base.m_Type = BHVTaskType.Respawn;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamRespawn;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c2a85d51c2f39eb0a2d661a26b084fc11 = 0f;
			BHVTaskUtils.c524eadbff83910c7600158a6c6eebcdd(cfc241af7ab51814fc074e767be1a0bb8.m_entity, false);
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
						return;
					}
				}
			}
			base.Update(deltaTime);
			c2a85d51c2f39eb0a2d661a26b084fc11 += deltaTime;
			if (c2a85d51c2f39eb0a2d661a26b084fc11 < 0.2f)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}
	}
}
