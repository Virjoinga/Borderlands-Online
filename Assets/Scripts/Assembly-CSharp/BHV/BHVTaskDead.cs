using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskDead : BHVTask
	{
		private BHVTaskParamDead c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c588e32794066adce62c15ff7e74ad1e1 = 1f;

		public BHVTaskDead()
		{
			base.m_Type = BHVTaskType.Dead;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDead;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
			c588e32794066adce62c15ff7e74ad1e1 = c2227ddc7fcbe3fa329465d2fa8ffb479.c588e32794066adce62c15ff7e74ad1e1;
			(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM).ca63de49b82d676c4bacd5359997b3dba();
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
			c588e32794066adce62c15ff7e74ad1e1 -= deltaTime;
			if (!(c588e32794066adce62c15ff7e74ad1e1 < 0f))
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.ce674c03a24ec89ef7cb066f5795f06c8(cfc241af7ab51814fc074e767be1a0bb8, false);
				if ((bool)cfc241af7ab51814fc074e767be1a0bb8)
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
					if ((bool)cfc241af7ab51814fc074e767be1a0bb8.m_entity)
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
						if (cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							cfc241af7ab51814fc074e767be1a0bb8.m_entity.cdcf5e0592c05a681a8470f66674efd0b().c57c843f07ba0112bdf1c5808feef0bef();
						}
					}
				}
				c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
				BHVTaskUtils.c524eadbff83910c7600158a6c6eebcdd(cfc241af7ab51814fc074e767be1a0bb8.m_entity, true);
				MapObjectMark component = cfc241af7ab51814fc074e767be1a0bb8.GetComponent<MapObjectMark>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					Object.Destroy(component);
				}
				(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM).c61302ae1bd2c6402fa5cf4ba5697da7f();
				c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7().cddbb691fc8f8aca349591e50c2f98b80(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.c590aee60e79226f59f47e3e6e2d12842(cfc241af7ab51814fc074e767be1a0bb8);
		}
	}
}
