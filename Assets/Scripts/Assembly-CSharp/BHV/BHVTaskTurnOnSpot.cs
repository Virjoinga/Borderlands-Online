using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskTurnOnSpot : BHVTask
	{
		private BHVTaskParamTurnOnSpot c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationTurnOnSpotState c5ae9bc249fc03b60cae99eeef154732b;

		public BHVTaskTurnOnSpot()
		{
			base.m_Type = BHVTaskType.TurnOnSpot;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamTurnOnSpot;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c5ae9bc249fc03b60cae99eeef154732b = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("TurnOnSpot") as AnimationTurnOnSpotState;
			c5ae9bc249fc03b60cae99eeef154732b.m_finalFacing = (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.c4cf00ced2bc60ae908904eb73692869f()).normalized;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = true;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.TurnOnSpot);
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
			if (c5ae9bc249fc03b60cae99eeef154732b == null)
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
			if (c5ae9bc249fc03b60cae99eeef154732b.m_status == AnimationStatus.SUCCESS)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						base.m_Status = BHVTaskStatus.SUCCESS;
						return;
					}
				}
			}
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 == null)
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
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (cfc241af7ab51814fc074e767be1a0bb8.m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.c4cf00ced2bc60ae908904eb73692869f();
			vector.y = 0f;
			if (vector.sqrMagnitude < 0.09f)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						base.m_Status = BHVTaskStatus.SUCCESS;
						return;
					}
				}
			}
			c5ae9bc249fc03b60cae99eeef154732b.m_finalFacing = vector.normalized;
			c5ae9bc249fc03b60cae99eeef154732b.m_finalFacing.y = 0f;
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
		}
	}
}
