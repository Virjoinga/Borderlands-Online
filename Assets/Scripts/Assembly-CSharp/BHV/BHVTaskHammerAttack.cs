using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskHammerAttack : BHVTask
	{
		private BHVTaskParamHammerAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private bool cada826f3446cfabbd8ff7b5b4b113f76;

		private float c03870392ccf131ad5269fec7ecab1084;

		private bool cf0ea1bfbe66abf5d3997176a5fcc474b;

		public BHVTaskHammerAttack()
		{
			base.m_Type = BHVTaskType.HammerAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamHammerAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.MeleeAttack);
			cada826f3446cfabbd8ff7b5b4b113f76 = false;
			c03870392ccf131ad5269fec7ecab1084 = 0.7f;
			cf0ea1bfbe66abf5d3997176a5fcc474b = false;
			(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit = false;
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
			base.Update(deltaTime);
			if (!cada826f3446cfabbd8ff7b5b4b113f76)
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
				if ((cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit)
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
					(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit = false;
					c5c0cb3532f012040b639d28d532763f0();
				}
			}
			else
			{
				c03870392ccf131ad5269fec7ecab1084 -= deltaTime;
				if (c03870392ccf131ad5269fec7ecab1084 < 0f)
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
					if (!cf0ea1bfbe66abf5d3997176a5fcc474b)
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
						cf0ea1bfbe66abf5d3997176a5fcc474b = true;
						if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_HammerHitVFX);
						}
					}
				}
			}
			AnimationStatus animationStatus = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM.MeleeAttack);
			if (animationStatus != AnimationStatus.SUCCESS)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		private void c5c0cb3532f012040b639d28d532763f0()
		{
			cada826f3446cfabbd8ff7b5b4b113f76 = true;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				EntityPlayer component = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.GetComponent<EntityPlayer>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					BadAssFPSCamera badAssFPSCamera = component.cc6a7269e9ea93e537de47dc752b09a86();
					if (badAssFPSCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.medium);
					}
				}
			}
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Vector3 position = (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_hammerVFXTransform.position;
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_HammerHitVFX, position);
				return;
			}
		}
	}
}
