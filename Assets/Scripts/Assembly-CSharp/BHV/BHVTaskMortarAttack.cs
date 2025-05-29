using System.Collections.Generic;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskMortarAttack : BHVTask
	{
		private BHVTaskParamMortarAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationMortarAttackState c5ae9bc249fc03b60cae99eeef154732b;

		private BHVMortarAttackSettings c1f288cd340d326ba57a3ac324fc679b4;

		private Transform c90f116d5c2240ad156eef21180788f58;

		private Transform cfdcb626ee03fb2c2ab8a8f16d90dc597;

		private List<PlayerInfoSync> c6fecf7c8cb00fc036bfb35364bc2f9a9;

		private Object c8526778db67380475ddee796c1ee76d4;

		private float c23144d4b849283cd12fc6407ffc6f9ec;

		private int c3684183f481031b3f6e00b645d0a8843;

		private int cda5008fdcb704f26e6973f1d3d8fe9dc;

		public BHVTaskMortarAttack()
		{
			base.m_Type = BHVTaskType.MortarAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamMortarAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c23144d4b849283cd12fc6407ffc6f9ec = 0f;
			c3684183f481031b3f6e00b645d0a8843 = 0;
			cda5008fdcb704f26e6973f1d3d8fe9dc = 0;
			c5ae9bc249fc03b60cae99eeef154732b = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("MortarAttack") as AnimationMortarAttackState;
			c5ae9bc249fc03b60cae99eeef154732b.m_attackDuration = 60f;
			c90f116d5c2240ad156eef21180788f58 = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpcKnoxx).m_lunchPointLeft;
			cfdcb626ee03fb2c2ab8a8f16d90dc597 = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpcKnoxx).m_lunchPointRight;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c6fecf7c8cb00fc036bfb35364bc2f9a9);
			c8526778db67380475ddee796c1ee76d4 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/WPN_Missile");
			c1f288cd340d326ba57a3ac324fc679b4 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVMortarAttackSettings>();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.MortarAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
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
			if (c3684183f481031b3f6e00b645d0a8843 >= c1f288cd340d326ba57a3ac324fc679b4.m_shellAmount)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						c5ae9bc249fc03b60cae99eeef154732b.m_attackDuration = 0f;
						base.m_Status = BHVTaskStatus.SUCCESS;
						return;
					}
				}
			}
			c23144d4b849283cd12fc6407ffc6f9ec += deltaTime;
			if (!(c23144d4b849283cd12fc6407ffc6f9ec > 0.5f))
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
				c23144d4b849283cd12fc6407ffc6f9ec -= 0.5f;
				c758caa5a3d1070d16331af02076dda26();
				return;
			}
		}

		private void c758caa5a3d1070d16331af02076dda26()
		{
			if (c8526778db67380475ddee796c1ee76d4 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync c7088de59e49f7108f520cf7e0bae167e = c7cfa05fd8fe0a2d1791d3ae1202ecb42.c7088de59e49f7108f520cf7e0bae167e;
			int count = c6fecf7c8cb00fc036bfb35364bc2f9a9.Count;
			for (int i = 0; i < count; i++)
			{
				c7088de59e49f7108f520cf7e0bae167e = c6fecf7c8cb00fc036bfb35364bc2f9a9[i];
				if (c7088de59e49f7108f520cf7e0bae167e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					continue;
				}
				EntityPlayer entityPlayer = c7088de59e49f7108f520cf7e0bae167e.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
				if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				Vector3 position;
				if (cda5008fdcb704f26e6973f1d3d8fe9dc % 2 == 0)
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
					position = c90f116d5c2240ad156eef21180788f58.position;
				}
				else
				{
					position = cfdcb626ee03fb2c2ab8a8f16d90dc597.position;
				}
				Vector3 position2 = position;
				GameObject gameObject = (GameObject)Object.Instantiate(c8526778db67380475ddee796c1ee76d4, position2, Quaternion.identity);
				if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					KnoxxMissile component = gameObject.GetComponent<KnoxxMissile>();
					component.m_BHVTaskManager = cfc241af7ab51814fc074e767be1a0bb8;
					component.c7c5fd2bd1c5c6f266b23bc3369b810b5(entityPlayer);
				}
				cda5008fdcb704f26e6973f1d3d8fe9dc++;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				c3684183f481031b3f6e00b645d0a8843++;
				return;
			}
		}
	}
}
