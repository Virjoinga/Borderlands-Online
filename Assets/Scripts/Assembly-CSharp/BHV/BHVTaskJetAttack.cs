using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskJetAttack : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c5997b6d4f192f1ae8413f3838de9d260 = 0,
			ccb86e27d3d17a4f78948ef02f4c4412c = 1
		}

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		private BHVTaskParamJetAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AIServiceCurve.Curve c3cbf455ba458fa064c80d16602c566d0;

		private AnimationJumpAttackState cc530d6d94b2308f1444a5849647ea42a;

		private Vector3 ccc9e871cdda0f5008ee7f7d36d3d63c3;

		private NavMeshPath c0206141ee434142695b11c95ae6ec553 = new NavMeshPath();

		public BHVTaskJetAttack()
		{
			base.m_Type = BHVTaskType.JetAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamJetAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c3cbf455ba458fa064c80d16602c566d0 = null;
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.c5997b6d4f192f1ae8413f3838de9d260;
			cc530d6d94b2308f1444a5849647ea42a = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("JumpAttack") as AnimationJumpAttackState;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			EquipmentInventoryEntity equipmentInventoryEntity = cfc241af7ab51814fc074e767be1a0bb8.m_entity.c5ca38fad98337fc5c7255384b2cd1a86();
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case State.c5997b6d4f192f1ae8413f3838de9d260:
				switch (cc530d6d94b2308f1444a5849647ea42a.c4de9959131c2e376835be9d32b952b04)
				{
				case EAnimationJumpStep.JumpNull:
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.JumpAttack);
					if (cc530d6d94b2308f1444a5849647ea42a == null)
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
						c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;
					}
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationJumpStep.JumpPre:
					if (c3cbf455ba458fa064c80d16602c566d0 == null)
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
						float ceb8b3aecb62e595cd2d83736ab = 0.8f;
						bool flag2 = true;
						Vector3 position = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position;
						c3cbf455ba458fa064c80d16602c566d0 = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(c2227ddc7fcbe3fa329465d2fa8ffb479.c7c0b0bb3fcbb12184c4ba35b9a3d66b5, cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position, position, ceb8b3aecb62e595cd2d83736ab);
						if (c3cbf455ba458fa064c80d16602c566d0 == null)
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
							c3cbf455ba458fa064c80d16602c566d0 = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(c2227ddc7fcbe3fa329465d2fa8ffb479.c7c0b0bb3fcbb12184c4ba35b9a3d66b5, cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position, position, 1f);
						}
						else if (cfc241af7ab51814fc074e767be1a0bb8.m_navAgent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (c0206141ee434142695b11c95ae6ec553 != null)
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
								if (cfc241af7ab51814fc074e767be1a0bb8.m_navAgent.CalculatePath(c3cbf455ba458fa064c80d16602c566d0.m_curveEndPosition, c0206141ee434142695b11c95ae6ec553))
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
									int num;
									if (c0206141ee434142695b11c95ae6ec553.status == NavMeshPathStatus.PathComplete)
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
										num = 1;
									}
									else
									{
										num = 0;
									}
									flag2 = (byte)num != 0;
								}
							}
						}
						if (c3cbf455ba458fa064c80d16602c566d0 != null)
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
							if (flag2)
							{
								AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cc5af0a72cac219b86ee5ccc931325456(c3cbf455ba458fa064c80d16602c566d0.m_curveEndPosition, c2227ddc7fcbe3fa329465d2fa8ffb479.c74fe9e294614cfc03baaffde91421ca6);
								goto IL_0280;
							}
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						base.m_Status = BHVTaskStatus.FAILED;
						c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
						cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
						break;
					}
					goto IL_0280;
				case EAnimationJumpStep.JumpLoop:
				{
					Vector3 newPosition;
					bool flag = c3cbf455ba458fa064c80d16602c566d0.Update(deltaTime, c2227ddc7fcbe3fa329465d2fa8ffb479.c992b4ed49627f10342a70e74e25df1bc, out newPosition);
					cfc241af7ab51814fc074e767be1a0bb8.transform.position = newPosition;
					if (!flag)
					{
						break;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						c3cbf455ba458fa064c80d16602c566d0 = null;
						cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
						c5c0cb3532f012040b639d28d532763f0();
						if (equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620() <= 0)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									base.m_Status = BHVTaskStatus.SUCCESS;
									c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
									cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
									return;
								}
							}
						}
						ccc9e871cdda0f5008ee7f7d36d3d63c3 = cfc241af7ab51814fc074e767be1a0bb8.transform.position;
						cc530d6d94b2308f1444a5849647ea42a.c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLand;
						AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
						return;
					}
				}
				case EAnimationJumpStep.JumpLand:
					cfc241af7ab51814fc074e767be1a0bb8.transform.position = ccc9e871cdda0f5008ee7f7d36d3d63c3;
					if (equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620() > 0)
					{
						break;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						base.m_Status = BHVTaskStatus.SUCCESS;
						c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
						return;
					}
				case EAnimationJumpStep.JumpFinish:
					{
						cfc241af7ab51814fc074e767be1a0bb8.transform.position = ccc9e871cdda0f5008ee7f7d36d3d63c3;
						base.m_Status = BHVTaskStatus.SUCCESS;
						c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
						break;
					}
					IL_0280:
					c1b2e42ae0b99637dce3a6caf9a944b18();
					break;
				}
				break;
			case State.ccb86e27d3d17a4f78948ef02f4c4412c:
				cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			cfc241af7ab51814fc074e767be1a0bb8.transform.position = ccc9e871cdda0f5008ee7f7d36d3d63c3;
			AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
		}

		private void c1b2e42ae0b99637dce3a6caf9a944b18()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
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
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 20f);
		}

		private void c5c0cb3532f012040b639d28d532763f0()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
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
			EntityPlayer component = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.GetComponent<EntityPlayer>();
			if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				BadAssFPSCamera badAssFPSCamera = component.cc6a7269e9ea93e537de47dc752b09a86();
				if (!(badAssFPSCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					return;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.medium);
					return;
				}
			}
		}
	}
}
