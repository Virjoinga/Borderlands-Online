using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskWarning : BHVTaskAnimationState
	{
		private BHVTaskParamWarning c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskWarning()
		{
			base.m_Type = BHVTaskType.Warning;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamWarning;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Warning);
			c1b2e42ae0b99637dce3a6caf9a944b18();
		}

		private void c1b2e42ae0b99637dce3a6caf9a944b18()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.ca0c376bdd2ff6a3b6ad6e051444cd3c7.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}
	}
}
