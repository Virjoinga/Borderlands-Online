using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

namespace BHV
{
	public sealed class BHVTaskUtils
	{
		public static float c81e9523611e0ce0e91f158d6914ee312(GameObject c82fcbab5e578dc3a31c1f662916bd87e, Entity c5d720f6d007abb0c4a21d6a654e405bb)
		{
			float result = 0f;
			if (c82fcbab5e578dc3a31c1f662916bd87e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (c5d720f6d007abb0c4a21d6a654e405bb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					float num = (c82fcbab5e578dc3a31c1f662916bd87e.transform.position - c5d720f6d007abb0c4a21d6a654e405bb.transform.position).normalized.y;
					if (num > 1f)
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
						num = 1f;
					}
					else if (num < -1f)
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
						num = -1f;
					}
					result = Mathf.Asin(num) * 57.29578f;
				}
			}
			return result;
		}

		public static float c4d8568e8355dc3342546a10728d3a1a2(Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, Entity c5d720f6d007abb0c4a21d6a654e405bb)
		{
			float result = 0f;
			if (c5d720f6d007abb0c4a21d6a654e405bb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Vector3 forward = c5d720f6d007abb0c4a21d6a654e405bb.transform.forward;
				forward.y = 0f;
				Vector3 vector = c0b885a96d3f0d32f51ff3ec0d37d2900 - c5d720f6d007abb0c4a21d6a654e405bb.transform.position;
				vector.y = 0f;
				result = cb9d402b3a18cd6eb6f306d1024377f7f(forward.normalized, vector.normalized);
			}
			return result;
		}

		public static float cdb901bc7fb6b3c7de30e9b074bfb0279(Vector3 cf6af9bfe3579d09c233445ffb83a3162, Vector3 c4de25b65ca1f6f0e25d2f62aa898f593)
		{
			float num = 2f;
			float magnitude = (c4de25b65ca1f6f0e25d2f62aa898f593 - cf6af9bfe3579d09c233445ffb83a3162).magnitude;
			if (magnitude <= num)
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
						return magnitude / num;
					}
				}
			}
			return 1f;
		}

		public static void cb9639a2fcbb63d05803cb6f04384c8ca(float ccc714c0eabb517feca15832e42c5ea24, Entity c5d720f6d007abb0c4a21d6a654e405bb, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, ref bool c4d9c933a53e9cff7c10b92e064321cd3)
		{
			EntityNpc entityNpc = c5d720f6d007abb0c4a21d6a654e405bb as EntityNpc;
			if (entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (entityNpc.m_subType == EntityNpc.EntitySubType.CHR_SoldierTurretBasic)
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
			}
			float num = 2f;
			float num2 = 5f;
			if (!c4d9c933a53e9cff7c10b92e064321cd3)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
					{
						int num3;
						if (ccc714c0eabb517feca15832e42c5ea24 > num)
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
							num3 = ((ccc714c0eabb517feca15832e42c5ea24 < 360f - num) ? 1 : 0);
						}
						else
						{
							num3 = 0;
						}
						c4d9c933a53e9cff7c10b92e064321cd3 = (byte)num3 != 0;
						return;
					}
					}
				}
			}
			Vector3 vector = c0b885a96d3f0d32f51ff3ec0d37d2900 - c5d720f6d007abb0c4a21d6a654e405bb.transform.position;
			vector.y = 0f;
			vector.Normalize();
			float num4 = Time.deltaTime * num2;
			if (!(ccc714c0eabb517feca15832e42c5ea24 < num4))
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
				if (!(ccc714c0eabb517feca15832e42c5ea24 > 360f - num4))
				{
					c5d720f6d007abb0c4a21d6a654e405bb.transform.forward = Vector3.Slerp(c5d720f6d007abb0c4a21d6a654e405bb.transform.forward, vector, num4);
					return;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			c5d720f6d007abb0c4a21d6a654e405bb.transform.forward = vector;
			c4d9c933a53e9cff7c10b92e064321cd3 = false;
		}

		public static float cb9639a2fcbb63d05803cb6f04384c8ca(Vector3 c4217bb0e17b60ec05778aef628e02ceb, Entity c5d720f6d007abb0c4a21d6a654e405bb)
		{
			if (c4217bb0e17b60ec05778aef628e02ceb.magnitude > float.Epsilon)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c5d720f6d007abb0c4a21d6a654e405bb.transform.rotation = Quaternion.LookRotation(c4217bb0e17b60ec05778aef628e02ceb);
				Vector3 cae5fea398599f41bfafc9b6bb6f4559b = AIServicePathfinding.c5ee19dc8d4cccf5ae2de225410458b86.c3a0755c94976451bf75a254edfe4aead(c5d720f6d007abb0c4a21d6a654e405bb.cb7fad43afb51f83d8698379136b46e95());
				if (cae5fea398599f41bfafc9b6bb6f4559b.magnitude > float.Epsilon)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return cb9d402b3a18cd6eb6f306d1024377f7f(cae5fea398599f41bfafc9b6bb6f4559b, c4217bb0e17b60ec05778aef628e02ceb);
						}
					}
				}
			}
			return 0f;
		}

		public static EntityPlayer c2384cf272b10687d1c388a9dbe2b7bea(Vector3 c4e03a643c2ec77eea87074ab178cd8db, Vector3 ca57283c03be55af031c0448e815af854, Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c8f27164367c8891e385133ac6325c322)
		{
			if (c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
			}
			Skeleton skeleton = c5d720f6d007abb0c4a21d6a654e405bb.ccd8e6ea278245d0f158036267242e60f();
			if (skeleton == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return null;
					}
				}
			}
			Transform transform = skeleton.cb2362c81dda995fcf817a341a4eb3ffb();
			if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return null;
					}
				}
			}
			Entity entity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
			float num = 0.3f;
			List<Entity> c0c2a548e7e20a141e7763c365a4d;
			c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Player, out c0c2a548e7e20a141e7763c365a4d);
			Vector3 vector = ca57283c03be55af031c0448e815af854 - c4e03a643c2ec77eea87074ab178cd8db;
			float num2 = vector.magnitude + num;
			Vector3 position = transform.position;
			if (c8f27164367c8891e385133ac6325c322)
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
				position.y = c4e03a643c2ec77eea87074ab178cd8db.y;
			}
			Ray cdb5cb253ef1339831696a37475f7233f = new Ray(position, vector.normalized);
			for (int i = 0; i < c0c2a548e7e20a141e7763c365a4d.Count; i++)
			{
				CollisionManager collisionManager = c0c2a548e7e20a141e7763c365a4d[i].c63f8f07320313ddc4213cb59ee025962();
				if (collisionManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				float c85645ac328a4c6e6c17d3da3be1e11f = num2;
				Debug.c01037ade1f1152c7345e14ef90726aba(cdb5cb253ef1339831696a37475f7233f.origin, cdb5cb253ef1339831696a37475f7233f.origin + cdb5cb253ef1339831696a37475f7233f.direction * c85645ac328a4c6e6c17d3da3be1e11f, Color.red);
				RaycastHit c3ced719b4780c1919017d69e82521ab;
				if (!collisionManager.ce3a634dd33744eb63234d14e7a1e099f(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f))
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!(c3ced719b4780c1919017d69e82521ab.distance < num2))
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				num2 = c3ced719b4780c1919017d69e82521ab.distance;
				entity = c0c2a548e7e20a141e7763c365a4d[i];
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				return (EntityPlayer)entity;
			}
		}

		public static void c06c56e23c3b7e29d77f14f12a000f572(Entity c5d720f6d007abb0c4a21d6a654e405bb)
		{
		}

		public static float c05f720acdd75c6e6928513766665807d(Vector3 cb7c736b17bc53c850d891f1f2cf5bdb9, Vector3 c6cb66aa8544c442eb14b92180640f843)
		{
			float num = (cb7c736b17bc53c850d891f1f2cf5bdb9 - c6cb66aa8544c442eb14b92180640f843).normalized.y;
			if (num > 1f)
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
				num = 1f;
			}
			else if (num < -1f)
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
				num = -1f;
			}
			return Mathf.Asin(num) * 57.29578f;
		}

		public static float cb9d402b3a18cd6eb6f306d1024377f7f(Vector3 cae5fea398599f41bfafc9b6bb6f4559b, Vector3 c6cb66aa8544c442eb14b92180640f843)
		{
			float num = Vector3.Dot(cae5fea398599f41bfafc9b6bb6f4559b, c6cb66aa8544c442eb14b92180640f843);
			if (num > 1f)
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
				num = 1f;
			}
			else if (num < -1f)
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
				num = -1f;
			}
			float num2 = Mathf.Acos(num) * 57.29578f;
			if (Vector3.Cross(cae5fea398599f41bfafc9b6bb6f4559b, c6cb66aa8544c442eb14b92180640f843).y < 0f)
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
				num2 = 360f - num2;
			}
			return num2;
		}

		public static AnimationStressLevel c7c52163f4fb183d8b5cdf3c75da730ad(BHVStressLevel ca9dc10511e5624ef9dde1f46bb627e03)
		{
			if (ca9dc10511e5624ef9dde1f46bb627e03 != 0)
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
						if (ca9dc10511e5624ef9dde1f46bb627e03 != BHVStressLevel.COMBAT)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									return AnimationStressLevel.CASUAL;
								}
							}
						}
						return AnimationStressLevel.COMBAT;
					}
				}
			}
			return AnimationStressLevel.CASUAL;
		}

		public static void c9910e85b3d98c0029a8824c312afef63(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			if (!(c5d720f6d007abb0c4a21d6a654e405bb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				NavMeshAgent navMeshAgent = c5d720f6d007abb0c4a21d6a654e405bb.cb7fad43afb51f83d8698379136b46e95();
				if (!navMeshAgent)
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
					if (!navMeshAgent.collider)
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
						navMeshAgent.collider.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
						return;
					}
				}
			}
		}

		public static Transform cd8c02e6fd918b4ce12d6de1a6bbfc756(Transform cf0716d947af935a83272ab5cc994133f)
		{
			for (int i = 0; i < cf0716d947af935a83272ab5cc994133f.childCount; i++)
			{
				Transform child = cf0716d947af935a83272ab5cc994133f.GetChild(i);
				if (!(child.tag == "Target"))
				{
					continue;
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
					return child;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return null;
			}
		}

		public static void c54cbf5ad145f907739a2b08e7a576b1d(Entity c0402779363a90fb1388693c197ee744a, Entity c82fcbab5e578dc3a31c1f662916bd87e, int cc5930f8c96eb42daf8487baba22c2fb3, AttackSubType c95b3f13bf1917e70e33b9c6adf641793)
		{
			if (c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c82fcbab5e578dc3a31c1f662916bd87e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			BHVTaskManager bHVTaskManager = c0402779363a90fb1388693c197ee744a.c9b6d1d87bef7b03dad787ff0031551ee();
			bHVTaskManager.m_actionParameters.m_targetEntity = c82fcbab5e578dc3a31c1f662916bd87e.cc7403315505256d19a7b92aa614a8f10();
			bHVTaskManager.m_actionParameters.m_meleeDamageAmount = cc5930f8c96eb42daf8487baba22c2fb3;
			bHVTaskManager.m_actionParameters.m_attackSubType = c95b3f13bf1917e70e33b9c6adf641793;
			bHVTaskManager.m_actionParameters.m_bIgnoreAngle = true;
			c0402779363a90fb1388693c197ee744a.m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Melee");
		}

		public static void c0eab0a5cf540f6624b0da9f08aecc6b4(Entity c0402779363a90fb1388693c197ee744a, Entity c82fcbab5e578dc3a31c1f662916bd87e, int cc5930f8c96eb42daf8487baba22c2fb3, AttackSubType c95b3f13bf1917e70e33b9c6adf641793)
		{
			if (c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c82fcbab5e578dc3a31c1f662916bd87e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			BHVTaskManager bHVTaskManager = c0402779363a90fb1388693c197ee744a.c9b6d1d87bef7b03dad787ff0031551ee();
			bHVTaskManager.m_actionParameters.m_targetEntity = c82fcbab5e578dc3a31c1f662916bd87e.cc7403315505256d19a7b92aa614a8f10();
			bHVTaskManager.m_actionParameters.m_meleeDamageAmount = cc5930f8c96eb42daf8487baba22c2fb3;
			bHVTaskManager.m_actionParameters.m_attackSubType = c95b3f13bf1917e70e33b9c6adf641793;
			c0402779363a90fb1388693c197ee744a.m_ability.ca1ca367e3e7bc5e3d1d18071c855c82f("Melee");
		}

		public static float cc741872fd80049d7cc9f4b07bad33a2b(Vector3 cc32ba4341afc1b99ed61813f99098b66, Vector3 c846548d4e24c2f610d0fd7361f32a718, Vector3 c330987c4414f384d6c951ab9f68460d8)
		{
			float sqrMagnitude = (cc32ba4341afc1b99ed61813f99098b66 - c330987c4414f384d6c951ab9f68460d8).sqrMagnitude;
			float sqrMagnitude2 = (c846548d4e24c2f610d0fd7361f32a718 - c330987c4414f384d6c951ab9f68460d8).sqrMagnitude;
			Vector3 vector;
			if (sqrMagnitude < sqrMagnitude2)
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
				vector = c330987c4414f384d6c951ab9f68460d8 - cc32ba4341afc1b99ed61813f99098b66;
			}
			else
			{
				vector = c330987c4414f384d6c951ab9f68460d8 - c846548d4e24c2f610d0fd7361f32a718;
			}
			Vector3 lhs = vector;
			Vector3 normalized;
			if (sqrMagnitude < sqrMagnitude2)
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
				normalized = (c846548d4e24c2f610d0fd7361f32a718 - cc32ba4341afc1b99ed61813f99098b66).normalized;
			}
			else
			{
				normalized = (cc32ba4341afc1b99ed61813f99098b66 - c846548d4e24c2f610d0fd7361f32a718).normalized;
			}
			Vector3 vector2 = normalized;
			float num = Vector3.Dot(lhs, vector2);
			Vector3 vector3;
			if (sqrMagnitude < sqrMagnitude2)
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
				vector3 = cc32ba4341afc1b99ed61813f99098b66;
			}
			else
			{
				vector3 = c846548d4e24c2f610d0fd7361f32a718;
			}
			Vector3 vector4 = vector3;
			if (num > 0f)
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
				vector4 += vector2 * num;
			}
			return (vector4 - c330987c4414f384d6c951ab9f68460d8).sqrMagnitude;
		}

		public static void c524eadbff83910c7600158a6c6eebcdd(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c931294945eb91e7c5c56f2a38ca1fcd9)
		{
			Renderer[] componentsInChildren = c5d720f6d007abb0c4a21d6a654e405bb.gameObject.GetComponentsInChildren<Renderer>();
			Renderer[] array = componentsInChildren;
			foreach (Renderer renderer in array)
			{
				renderer.enabled = !c931294945eb91e7c5c56f2a38ca1fcd9;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}
	}
}
