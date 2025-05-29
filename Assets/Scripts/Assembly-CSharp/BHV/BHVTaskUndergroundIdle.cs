using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskUndergroundIdle : BHVTask
	{
		private BHVTaskParamUndergroundIdle c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskUndergroundIdle()
		{
			base.m_Type = BHVTaskType.UndergroundIdle;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamUndergroundIdle;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsAlert", false);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("DrillAttackStep", 0);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIntoGround", true);
			c2d68fa3ce1da486fcd6a2efb3894d4e1(false);
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (1)
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
		}

		private void c2d68fa3ce1da486fcd6a2efb3894d4e1(bool c2db42a69e0bc3cffe8d38613f5efd506)
		{
			if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c0c5ca8f54702477a0524e764704df02c(ENPCParticleType.E_MoveDust, null, cfc241af7ab51814fc074e767be1a0bb8.transform.position, Quaternion.identity);
			}
			(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as CrabwormAnimationManagerFSM).ca29607801dff711ca70056b8b5a9c58f(c2db42a69e0bc3cffe8d38613f5efd506);
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIntoGround", false);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("IsAlert", true);
			c2d68fa3ce1da486fcd6a2efb3894d4e1(true);
		}
	}
}
