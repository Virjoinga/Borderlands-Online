using A;
using Core;
using UnityEngine;

namespace BHV
{
	public class BHVTaskJumpAttack : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			c5997b6d4f192f1ae8413f3838de9d260 = 0,
			ccb86e27d3d17a4f78948ef02f4c4412c = 1
		}

		private BHVTaskParamJumpAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		private AIServiceCurve.Curve c3cbf455ba458fa064c80d16602c566d0;

		private Vector3 c8a2af45a880b27fa0012457d167c4b27 = Vector3.zero;

		private Entity ce1e7a598367c55ecf2058047b5bb8545;

		private Transform c2aac4ce7d70efeaf08bac378507fc955;

		private BHVJumpAttackSettings c8cdc003a34aa398ac8a5024d78b98276;

		public BHVTaskJumpAttack()
		{
			base.m_Type = BHVTaskType.JumpAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamJumpAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.c5997b6d4f192f1ae8413f3838de9d260;
			c3cbf455ba458fa064c80d16602c566d0 = null;
			ce1e7a598367c55ecf2058047b5bb8545 = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.GetComponent<Entity>();
			if (ce1e7a598367c55ecf2058047b5bb8545 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c2aac4ce7d70efeaf08bac378507fc955 = ce1e7a598367c55ecf2058047b5bb8545.GetComponentInChildren<Skeleton>().cb2362c81dda995fcf817a341a4eb3ffb();
			}
			c8cdc003a34aa398ac8a5024d78b98276 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVJumpAttackSettings>();
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			AnimationJumpAttackState animationJumpAttackState = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("JumpAttack") as AnimationJumpAttackState;
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case State.c5997b6d4f192f1ae8413f3838de9d260:
				switch (animationJumpAttackState.c4de9959131c2e376835be9d32b952b04)
				{
				case EAnimationJumpStep.JumpNull:
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.JumpAttack);
					if (animationJumpAttackState == null)
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
						c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;
					}
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationJumpStep.JumpPre:
					if (c3cbf455ba458fa064c80d16602c566d0 == null)
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
						float ceb8b3aecb62e595cd2d83736ab = 1.5f;
						if (c2227ddc7fcbe3fa329465d2fa8ffb479.c7c0b0bb3fcbb12184c4ba35b9a3d66b5 == AIServiceCurve.ECurveType.ESpiderWidommakeJumpCurve)
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
							ceb8b3aecb62e595cd2d83736ab = 1.2f;
						}
						else if (c2227ddc7fcbe3fa329465d2fa8ffb479.c7c0b0bb3fcbb12184c4ba35b9a3d66b5 == AIServiceCurve.ECurveType.EKnoxxJetAttackCurve)
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
							ceb8b3aecb62e595cd2d83736ab = 0.95f;
						}
						if (c2aac4ce7d70efeaf08bac378507fc955 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							c8a2af45a880b27fa0012457d167c4b27 = c2aac4ce7d70efeaf08bac378507fc955.position;
						}
						else
						{
							c8a2af45a880b27fa0012457d167c4b27 = ce1e7a598367c55ecf2058047b5bb8545.c4cf00ced2bc60ae908904eb73692869f();
							c8a2af45a880b27fa0012457d167c4b27.y += ce1e7a598367c55ecf2058047b5bb8545.m_entityHeight;
						}
						c3cbf455ba458fa064c80d16602c566d0 = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(c2227ddc7fcbe3fa329465d2fa8ffb479.c7c0b0bb3fcbb12184c4ba35b9a3d66b5, cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position, c8a2af45a880b27fa0012457d167c4b27, ceb8b3aecb62e595cd2d83736ab);
						if (c3cbf455ba458fa064c80d16602c566d0 == null)
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
							c3cbf455ba458fa064c80d16602c566d0 = AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86.cd440a8b2fe2065c9cd33808285d3d764(c2227ddc7fcbe3fa329465d2fa8ffb479.c7c0b0bb3fcbb12184c4ba35b9a3d66b5, cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position, c8a2af45a880b27fa0012457d167c4b27, 1f);
						}
						if (c3cbf455ba458fa064c80d16602c566d0 == null)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.AI, "Can't create Jump Curve for NPC!");
								base.m_Status = BHVTaskStatus.FAILED;
								c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
								cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
								return;
							}
						}
						if ((cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
							float cbac8b1e8ba44d23d7b3364e72446ccf = Mathf.Clamp(c8cdc003a34aa398ac8a5024d78b98276.m_warningZoneRadius, 2f, c8cdc003a34aa398ac8a5024d78b98276.m_warningZoneRadius);
							AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cc5af0a72cac219b86ee5ccc931325456(c3cbf455ba458fa064c80d16602c566d0.m_curveEndPosition, cbac8b1e8ba44d23d7b3364e72446ccf);
						}
					}
					c1b2e42ae0b99637dce3a6caf9a944b18();
					break;
				case EAnimationJumpStep.JumpLoop:
				{
					Vector3 newPosition;
					bool flag = c3cbf455ba458fa064c80d16602c566d0.Update(deltaTime, cfc241af7ab51814fc074e767be1a0bb8.cde528db37f7946caf38a2c719cf0471e(BHVMovementSpeed.JUMP, BHVStressLevel.COMBAT), out newPosition);
					cfc241af7ab51814fc074e767be1a0bb8.transform.position = newPosition;
					if (!flag)
					{
						break;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						c3cbf455ba458fa064c80d16602c566d0 = null;
						if ((cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
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
							AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
							if ((cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_subType == EntityNpc.EntitySubType.CHR_SpiderantWidowmaker)
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
								cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_JumpAttack);
							}
						}
						animationJumpAttackState.c4de9959131c2e376835be9d32b952b04 = EAnimationJumpStep.JumpLand;
						cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
						return;
					}
				}
				case EAnimationJumpStep.JumpFinish:
					base.m_Status = BHVTaskStatus.FAILED;
					c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.Idle);
					break;
				case EAnimationJumpStep.JumpLand:
					break;
				}
				break;
			case State.ccb86e27d3d17a4f78948ef02f4c4412c:
				break;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (c3cbf455ba458fa064c80d16602c566d0 != null)
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
				if (AIServiceCurve.c5ee19dc8d4cccf5ae2de225410458b86 == null)
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
					c3cbf455ba458fa064c80d16602c566d0 = null;
				}
			}
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).c90ea3a207cd50bba4ba7c81b9ff2bcb5())
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.cf26f5e09ef041b20e768bbd7e1d13f3a();
				return;
			}
		}

		private void c1b2e42ae0b99637dce3a6caf9a944b18()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 20f);
		}
	}
}
