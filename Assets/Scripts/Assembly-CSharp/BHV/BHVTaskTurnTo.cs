using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskTurnTo : BHVTask
	{
		private BHVTaskParamTurnTo c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskTurnTo()
		{
			base.m_Type = BHVTaskType.TurnTo;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamTurnTo;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.TurnTo);
		}

		public override void Update(float deltaTime)
		{
			Vector3 normalized;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.cf4a0caae0789fc3d553c1d52437db5c7.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			}
			else
			{
				normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c2eb410f485a39fb428debf247ffd3a41 - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			}
			normalized.y = 0f;
			float num = Vector3.Angle(normalized, cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward);
			if (num < 5f)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						base.m_Status = BHVTaskStatus.SUCCESS;
						return;
					}
				}
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, deltaTime * 5f);
		}
	}
}
