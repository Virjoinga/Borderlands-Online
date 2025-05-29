using System.Text;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskCountDown : BHVTask
	{
		private BHVTaskParamCountDown c2227ddc7fcbe3fa329465d2fa8ffb479;

		private GameObject c8dbc49951ce73f06573e7bea8923fb2d;

		public BHVTaskCountDown()
		{
			base.m_Type = BHVTaskType.CountDown;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamCountDown;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cfc241af7ab51814fc074e767be1a0bb8.GetComponent<VFXManager>().cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Fuse);
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.GetComponent<VFXManager>().c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_Fuse);
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			Object.Destroy(c8dbc49951ce73f06573e7bea8923fb2d);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 != null)
			{
				while (true)
				{
					switch (4)
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
				stringBuilder.Append(string.Format("        State:BHVTaskCountDown\n", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
			}
			return stringBuilder.ToString();
		}
	}
}
