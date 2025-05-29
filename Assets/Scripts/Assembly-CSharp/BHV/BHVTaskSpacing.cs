using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskSpacing : BHVTask
	{
		private enum SpacingState
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c2d86b890ced0b9b0a7b6a6bba58ddc62 = 0,
			ce9251add56fe03f45ea8af9c04dcc059 = 1,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2,
			c9d3c2ab25f15e75fe648bc9b2bb14eb7 = 3
		}

		private BHVTaskParamSpacing c2227ddc7fcbe3fa329465d2fa8ffb479;

		private SpacingState c45bb77f7ef7c0cfb4e9839ab212a467f = SpacingState.c6d1f578be4de6db437a078aa502b0284;

		private AnimationSpacingState cf1b714a62d6127c2460d8bcc916c6593;

		public BHVTaskSpacing()
		{
			base.m_Type = BHVTaskType.Spacing;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamSpacing;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = SpacingState.c2d86b890ced0b9b0a7b6a6bba58ddc62;
			cf1b714a62d6127c2460d8bcc916c6593 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("Spacing") as AnimationSpacingState;
			cf1b714a62d6127c2460d8bcc916c6593.c1a9bdac7a68b7fb9ef0734a88f1eb679(c2227ddc7fcbe3fa329465d2fa8ffb479.c4d6f246ba16683e3ea53df595ff7aa01);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case SpacingState.c2d86b890ced0b9b0a7b6a6bba58ddc62:
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cc2c8af567962955d6c13e1bff99b395d = BHVStressLevel.COMBAT;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Spacing);
				base.m_Status = BHVTaskStatus.RUNNING;
				c45bb77f7ef7c0cfb4e9839ab212a467f = SpacingState.ce9251add56fe03f45ea8af9c04dcc059;
				break;
			case SpacingState.ce9251add56fe03f45ea8af9c04dcc059:
				cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVNavAgentSettings>().m_canUseFacingLogic = true;
				break;
			case SpacingState.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			}
		}

		private void c1b2e42ae0b99637dce3a6caf9a944b18()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}
	}
}
