using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskTeleport : BHVTask
	{
		private BHVTaskParamTeleport c2227ddc7fcbe3fa329465d2fa8ffb479;

		private float c3bdee8d19fd5f55a2762eef4b99f592c;

		private float c13e4fe96924759125055f38345972df3;

		private Vector3 c0a2f64beed7b243fd9dcc609899d2285;

		private bool ce8c01ae563c3587c7f17bf6d7cf443a1;

		public BHVTaskTeleport()
		{
			base.m_Type = BHVTaskType.Teleport;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamTeleport;
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
			c0a2f64beed7b243fd9dcc609899d2285.x = 0f;
			c0a2f64beed7b243fd9dcc609899d2285.y = 1f;
			c0a2f64beed7b243fd9dcc609899d2285.z = 0f;
			ce8c01ae563c3587c7f17bf6d7cf443a1 = false;
			c13e4fe96924759125055f38345972df3 = Random.Range(c2227ddc7fcbe3fa329465d2fa8ffb479.ce603272242c63e7a2434f5103a7345bc, c2227ddc7fcbe3fa329465d2fa8ffb479.c594bb07e142a1dd16741953c76325d6b);
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM).c6d990a8ab1adfc44722a078a44954178();
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				while (true)
				{
					switch (3)
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
			if (!ce8c01ae563c3587c7f17bf6d7cf443a1)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (c3bdee8d19fd5f55a2762eef4b99f592c > c2227ddc7fcbe3fa329465d2fa8ffb479.ca4dcddde017e1f3c4febaf10ce176ff7)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd295c889c81e8823ba501a609b868079(true);
									c524eadbff83910c7600158a6c6eebcdd(true);
									c3bdee8d19fd5f55a2762eef4b99f592c = 0f;
									RPC_TeleportMe();
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (!(c3bdee8d19fd5f55a2762eef4b99f592c > c13e4fe96924759125055f38345972df3))
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
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM).cdd2f24f8d58571ac78fbd3493e1022b2();
				}
				c524eadbff83910c7600158a6c6eebcdd(false);
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd295c889c81e8823ba501a609b868079(false);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (!ce8c01ae563c3587c7f17bf6d7cf443a1)
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
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as NPCAnimationManagerFSM).cdd2f24f8d58571ac78fbd3493e1022b2();
				}
				c524eadbff83910c7600158a6c6eebcdd(false);
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd295c889c81e8823ba501a609b868079(false);
				return;
			}
		}

		private void c524eadbff83910c7600158a6c6eebcdd(bool c931294945eb91e7c5c56f2a38ca1fcd9)
		{
			Renderer[] componentsInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_entity.gameObject.GetComponentsInChildren<Renderer>();
			Renderer[] array = componentsInChildren;
			foreach (Renderer renderer in array)
			{
				renderer.enabled = !c931294945eb91e7c5c56f2a38ca1fcd9;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				ce8c01ae563c3587c7f17bf6d7cf443a1 = c931294945eb91e7c5c56f2a38ca1fcd9;
				return;
			}
		}

		private void RPC_TeleportMe()
		{
		}
	}
}
