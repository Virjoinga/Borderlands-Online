using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskHammerJumpAttack : BHVTask
	{
		private BHVTaskParamHammerJumpAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationJumpAttackState cc530d6d94b2308f1444a5849647ea42a;

		private BHVHammerJumpSettings c8cdc003a34aa398ac8a5024d78b98276;

		private AIServiceCurve.Curve c3cbf455ba458fa064c80d16602c566d0 = new AIServiceCurve.Curve();

		private bool c62dccd494e7314353f78b3ee24ce31b5;

		private float c03870392ccf131ad5269fec7ecab1084;

		private bool cf0ea1bfbe66abf5d3997176a5fcc474b;

		public BHVTaskHammerJumpAttack()
		{
			base.m_Type = BHVTaskType.HammerJumpAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamHammerJumpAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			cc530d6d94b2308f1444a5849647ea42a = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("JumpAttack") as AnimationJumpAttackState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.JumpAttack);
			c8cdc003a34aa398ac8a5024d78b98276 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVHammerJumpSettings>();
			c62dccd494e7314353f78b3ee24ce31b5 = false;
			c03870392ccf131ad5269fec7ecab1084 = 0.7f;
			cf0ea1bfbe66abf5d3997176a5fcc474b = false;
			if (!c3cbf455ba458fa064c80d16602c566d0.c77bcb24eeae986d72b2961310a2fc749(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position, c2227ddc7fcbe3fa329465d2fa8ffb479.cdd1b6074886e7345527aa6507f3c77ea, 1f))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				base.m_Status = BHVTaskStatus.FAILED;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_validateNextMovePosition = false;
			AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cc5af0a72cac219b86ee5ccc931325456(c3cbf455ba458fa064c80d16602c566d0.m_curveEndPosition, c8cdc003a34aa398ac8a5024d78b98276.m_hammerDamageRange);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.FAILED)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (base.m_Status == BHVTaskStatus.SUCCESS)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (cc530d6d94b2308f1444a5849647ea42a.c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpLoop)
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
					Vector3 newPosition;
					bool flag = c3cbf455ba458fa064c80d16602c566d0.Update(deltaTime, c8cdc003a34aa398ac8a5024d78b98276.m_jumpSpeed, out newPosition);
					cfc241af7ab51814fc074e767be1a0bb8.transform.position = newPosition;
					if (flag)
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
						cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
						cc530d6d94b2308f1444a5849647ea42a.c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLand;
						AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
					}
				}
				else if (cc530d6d94b2308f1444a5849647ea42a.c4de9959131c2e376835be9d32b952b04 == EAnimationJumpStep.JumpFinish)
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
					cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
					base.m_Status = BHVTaskStatus.SUCCESS;
				}
				if (!c62dccd494e7314353f78b3ee24ce31b5)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							if ((cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as BanditApollyonAnimationManagerFSM).m_bHammerHit = false;
										c62dccd494e7314353f78b3ee24ce31b5 = true;
										c5c0cb3532f012040b639d28d532763f0();
										return;
									}
								}
							}
							return;
						}
					}
				}
				c03870392ccf131ad5269fec7ecab1084 -= deltaTime;
				if (!(c03870392ccf131ad5269fec7ecab1084 < 0f))
				{
					return;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					if (cf0ea1bfbe66abf5d3997176a5fcc474b)
					{
						return;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						cf0ea1bfbe66abf5d3997176a5fcc474b = true;
						if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_HammerHitVFX);
							return;
						}
					}
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
			AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}

		private void c5c0cb3532f012040b639d28d532763f0()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				EntityPlayer component = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.GetComponent<EntityPlayer>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					BadAssFPSCamera badAssFPSCamera = component.cc6a7269e9ea93e537de47dc752b09a86();
					if (badAssFPSCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				switch (5)
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
