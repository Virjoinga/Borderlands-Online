using UnityEngine;

namespace BHV
{
	public class BHVTaskDeployAidStation : BHVTask, InstantiateManager.InstanciationClient
	{
		private BHVTaskParamDeployAidStation c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationDeployAidStationState ca7a50a587fc91b1d654e909960749e1d;

		public BHVTaskDeployAidStation()
		{
			base.m_Type = BHVTaskType.DeployAidStation;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDeployAidStation;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			ca7a50a587fc91b1d654e909960749e1d = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM.DeployAidStation)) as AnimationDeployAidStationState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.DeployAidStation);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (ca7a50a587fc91b1d654e909960749e1d == null)
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
				if (ca7a50a587fc91b1d654e909960749e1d.m_status != AnimationStatus.SUCCESS)
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
					base.m_Status = BHVTaskStatus.SUCCESS;
					return;
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
		}

		public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
		{
		}
	}
}
