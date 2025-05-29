using A;

namespace BHV
{
	public class BHVTaskDazeEffect : BHVTask
	{
		private BHVTaskParamDazeEffect c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c3bdee8d19fd5f55a2762eef4b99f592c;

		public BHVTaskDazeEffect()
		{
			base.m_Type = BHVTaskType.DazeEffect;
			base.m_Layer = BHVTaskLayer.EFFECT;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDazeEffect;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c3bdee8d19fd5f55a2762eef4b99f592c = 0f;
			if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				NPCAnimationManagerFSM nPCAnimationManagerFSM = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM;
				if (nPCAnimationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					nPCAnimationManagerFSM.m_bInDazeEffect = true;
				}
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Stun);
				}
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c82680016189694aae7ffda7f93e20c78(cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVDazeEffectSettings>().m_speedRate);
				}
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
						return;
					}
				}
			}
			c3bdee8d19fd5f55a2762eef4b99f592c += deltaTime;
			float num = c2227ddc7fcbe3fa329465d2fa8ffb479.c23868d8f6b3ff373c1ea4198c761096e * cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVDazeEffectSettings>().m_dazeDuration;
			if (!(c3bdee8d19fd5f55a2762eef4b99f592c > num))
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
				OnSuccessOrTerminate();
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public void OnSuccessOrTerminate()
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (6)
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
			(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM).m_bInDazeEffect = false;
			if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Stun);
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c38e22188b18e8482a7c7b657c0db7eaf();
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			OnSuccessOrTerminate();
		}
	}
}
