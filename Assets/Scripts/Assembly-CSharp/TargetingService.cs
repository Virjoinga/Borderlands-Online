using System.Collections.Generic;
using A;
using BHV;
using UnityEngine;

public class TargetingService
{
	private static Ray s_ray;

	private static Entity s_lastHitEntity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;

	private static RaycastHit s_lastHitInfo;

	private static int s_staticRaycastMask = ~((1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("Charactor")) | (1 << LayerMask.NameToLayer("Ragdoll")) | (1 << LayerMask.NameToLayer("Loot")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("diegeticUI")) | (1 << LayerMask.NameToLayer("Firebird")) | (1 << LayerMask.NameToLayer("AreaDamage")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));

	private static int s_staticRaycastMask_Movement = ~((1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("Charactor")) | (1 << LayerMask.NameToLayer("Ragdoll")) | (1 << LayerMask.NameToLayer("Loot")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("diegeticUI")) | (1 << LayerMask.NameToLayer("Firebird")) | (1 << LayerMask.NameToLayer("AreaDamage")));

	public static int c766b2ad3bfeb136864b1696e7dda3d4c
	{
		get
		{
			return s_staticRaycastMask;
		}
		private set
		{
			s_staticRaycastMask = value;
		}
	}

	public static int c1d20cac39a8f2f2d40244b2db94423b7
	{
		get
		{
			return s_staticRaycastMask_Movement;
		}
		private set
		{
			s_staticRaycastMask_Movement = value;
		}
	}

	public static bool ceb7024b0ac2095af18b7cc6cf1ff929d(Ray cdb5cb253ef1339831696a37475f7233f, float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		RaycastHit[] array = Physics.RaycastAll(cdb5cb253ef1339831696a37475f7233f, c85645ac328a4c6e6c17d3da3be1e11f0, s_staticRaycastMask);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].collider.isTrigger)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return true;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public static Entity cdb2b353157196638ba0e612861776113(Vector3 c6fbf9bf303de8f447f09fde3a44278f2, Vector3 cd74e1657fe33d2ee7ef19f6bb00c943e, Entity c0402779363a90fb1388693c197ee744a, out Collider c5c049386ad279173b227358fda3eaaf6, ref float c85645ac328a4c6e6c17d3da3be1e11f0, ColliderType cf46d44a3eb69e572ff7737ca46f2d203 = ColliderType.WeakPoint, bool cd4bb9d2c70adcce7c26322442df90264 = false)
	{
		s_ray.origin = c6fbf9bf303de8f447f09fde3a44278f2;
		s_ray.direction = cd74e1657fe33d2ee7ef19f6bb00c943e.normalized;
		return cdb2b353157196638ba0e612861776113(s_ray, c0402779363a90fb1388693c197ee744a, out c5c049386ad279173b227358fda3eaaf6, ref c85645ac328a4c6e6c17d3da3be1e11f0, cf46d44a3eb69e572ff7737ca46f2d203, cd4bb9d2c70adcce7c26322442df90264);
	}

	public static Entity cdb2b353157196638ba0e612861776113(Ray cdb5cb253ef1339831696a37475f7233f, Entity c0402779363a90fb1388693c197ee744a, out Collider c5c049386ad279173b227358fda3eaaf6, ref float c85645ac328a4c6e6c17d3da3be1e11f0, ColliderType cf46d44a3eb69e572ff7737ca46f2d203 = ColliderType.WeakPoint, bool cd4bb9d2c70adcce7c26322442df90264 = false)
	{
		float c85645ac328a4c6e6c17d3da3be1e11f = c85645ac328a4c6e6c17d3da3be1e11f0;
		Entity entity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
		c5c049386ad279173b227358fda3eaaf6 = null;
		RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
		cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		if ((bool)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			DamageManager c5ee19dc8d4cccf5ae2de225410458b = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86;
			if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				List<Entity> list = c5ee19dc8d4cccf5ae2de225410458b.cb8a72c40c1b6db1b4a333f6af978a477();
				for (int i = 0; i < list.Count; i++)
				{
					Entity entity2 = list[i];
					if (c0402779363a90fb1388693c197ee744a != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entity2.ceb10167333758220ffb9bc66317ad763() == c0402779363a90fb1388693c197ee744a.ceb10167333758220ffb9bc66317ad763())
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
							if (!cd4bb9d2c70adcce7c26322442df90264)
							{
								goto IL_00d6;
							}
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						if (entity2 != c0402779363a90fb1388693c197ee744a)
						{
							goto IL_010b;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					goto IL_00d6;
					IL_010b:
					Vector3 lhs = entity2.transform.position - cdb5cb253ef1339831696a37475f7233f.origin;
					Vector3 direction = cdb5cb253ef1339831696a37475f7233f.direction;
					lhs.y = 0f;
					direction.y = 0f;
					if (!(Vector3.Dot(lhs, direction) > 0f))
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					CollisionManager collisionManager = entity2.c63f8f07320313ddc4213cb59ee025962();
					if (!(collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					switch (cf46d44a3eb69e572ff7737ca46f2d203)
					{
					case ColliderType.WeakPoint:
					{
						Collider collider = collisionManager.c1ce44495f53aa451cfab609bd34340d2();
						if (collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (collider.bounds.Contains(cdb5cb253ef1339831696a37475f7233f.origin))
							{
								goto IL_021b;
							}
							while (true)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						if (!collisionManager.c3b718f1007bb58e0bf2ca151b7d08786(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f))
						{
							break;
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
						goto IL_021b;
					}
					case ColliderType.BoundingBox:
						if (!collisionManager.c3b718f1007bb58e0bf2ca151b7d08786(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f))
						{
							break;
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
						s_lastHitInfo = c36964cf41281414170f34ee68bef6c;
						entity = entity2;
						c5c049386ad279173b227358fda3eaaf6 = c36964cf41281414170f34ee68bef6c.collider;
						c85645ac328a4c6e6c17d3da3be1e11f0 = c36964cf41281414170f34ee68bef6c.distance;
						break;
					case ColliderType.MovementBounding:
						{
							if (!collisionManager.c9e8c231a5bbbe15568687fd781ca9b0f(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f))
							{
								break;
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
							s_lastHitInfo = c36964cf41281414170f34ee68bef6c;
							entity = entity2;
							c5c049386ad279173b227358fda3eaaf6 = c36964cf41281414170f34ee68bef6c.collider;
							c85645ac328a4c6e6c17d3da3be1e11f0 = c36964cf41281414170f34ee68bef6c.distance;
							break;
						}
						IL_021b:
						c85645ac328a4c6e6c17d3da3be1e11f = c85645ac328a4c6e6c17d3da3be1e11f0;
						if (!entity2.c63f8f07320313ddc4213cb59ee025962().ce3a634dd33744eb63234d14e7a1e099f(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f))
						{
							break;
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
						s_lastHitInfo = c36964cf41281414170f34ee68bef6c;
						entity = entity2;
						c5c049386ad279173b227358fda3eaaf6 = c36964cf41281414170f34ee68bef6c.collider;
						c85645ac328a4c6e6c17d3da3be1e11f0 = c36964cf41281414170f34ee68bef6c.distance;
						break;
					}
					continue;
					IL_00d6:
					if (!(c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						continue;
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
					if (!(entity2 != c0402779363a90fb1388693c197ee744a))
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					goto IL_010b;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if ((bool)entity)
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
					if (ceb7024b0ac2095af18b7cc6cf1ff929d(cdb5cb253ef1339831696a37475f7233f, c85645ac328a4c6e6c17d3da3be1e11f0))
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
						entity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
						c5c049386ad279173b227358fda3eaaf6 = null;
					}
				}
			}
		}
		return entity;
	}

	public static bool cfc7875e612739018821cc55abbe376ab(Ray cdb5cb253ef1339831696a37475f7233f, Entity c0402779363a90fb1388693c197ee744a, Entity c82fcbab5e578dc3a31c1f662916bd87e, out Collider c5c049386ad279173b227358fda3eaaf6, ref float c85645ac328a4c6e6c17d3da3be1e11f0, ColliderType cf46d44a3eb69e572ff7737ca46f2d203 = ColliderType.WeakPoint)
	{
		c5c049386ad279173b227358fda3eaaf6 = null;
		RaycastHit c36964cf41281414170f34ee68bef6c = default(RaycastHit);
		cf64d0536c25365fcd13a5b7fc17ba508.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		bool flag = false;
		CollisionManager collisionManager = c82fcbab5e578dc3a31c1f662916bd87e.c63f8f07320313ddc4213cb59ee025962();
		if ((bool)collisionManager)
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
			switch (cf46d44a3eb69e572ff7737ca46f2d203)
			{
			case ColliderType.WeakPoint:
				if (!collisionManager.ce3a634dd33744eb63234d14e7a1e099f(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f0))
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
					break;
				}
				flag = true;
				c5c049386ad279173b227358fda3eaaf6 = c36964cf41281414170f34ee68bef6c.collider;
				c85645ac328a4c6e6c17d3da3be1e11f0 = c36964cf41281414170f34ee68bef6c.distance;
				break;
			case ColliderType.BoundingBox:
				if (!collisionManager.c3b718f1007bb58e0bf2ca151b7d08786(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f0))
				{
					break;
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
				flag = true;
				c5c049386ad279173b227358fda3eaaf6 = c36964cf41281414170f34ee68bef6c.collider;
				c85645ac328a4c6e6c17d3da3be1e11f0 = c36964cf41281414170f34ee68bef6c.distance;
				break;
			case ColliderType.MovementBounding:
				if (!collisionManager.c9e8c231a5bbbe15568687fd781ca9b0f(cdb5cb253ef1339831696a37475f7233f, out c36964cf41281414170f34ee68bef6c, ref c85645ac328a4c6e6c17d3da3be1e11f0))
				{
					break;
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
				flag = true;
				c5c049386ad279173b227358fda3eaaf6 = c36964cf41281414170f34ee68bef6c.collider;
				c85645ac328a4c6e6c17d3da3be1e11f0 = c36964cf41281414170f34ee68bef6c.distance;
				break;
			}
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
				if (!ceb7024b0ac2095af18b7cc6cf1ff929d(cdb5cb253ef1339831696a37475f7233f, c85645ac328a4c6e6c17d3da3be1e11f0))
				{
					return true;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				c5c049386ad279173b227358fda3eaaf6 = null;
			}
		}
		return false;
	}

	public static void c760d3f1e0187364b0fdafcaa9ea76863(Entity cd4c135a94cebad210bb03671638305df, out Vector3 c71901ec11266e4ff3ff61e7a7c65e978, out Vector3 c53e28ddc28cda4d72c55c784c38a6f65)
	{
		c71901ec11266e4ff3ff61e7a7c65e978 = Vector3.zero;
		c53e28ddc28cda4d72c55c784c38a6f65 = Vector3.zero;
		if (!s_lastHitEntity)
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
			c71901ec11266e4ff3ff61e7a7c65e978 = cd4c135a94cebad210bb03671638305df.transform.InverseTransformPoint(s_lastHitInfo.point);
			c53e28ddc28cda4d72c55c784c38a6f65 = cd4c135a94cebad210bb03671638305df.transform.InverseTransformDirection(s_lastHitInfo.normal);
			return;
		}
	}

	public static bool cf2ad040936dbdf83d69a76dd5ef494f5(Entity c0402779363a90fb1388693c197ee744a, Entity c82fcbab5e578dc3a31c1f662916bd87e)
	{
		if (!(c82fcbab5e578dc3a31c1f662916bd87e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				BHVTaskManager bHVTaskManager = c0402779363a90fb1388693c197ee744a.c9b6d1d87bef7b03dad787ff0031551ee();
				if (bHVTaskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				if (c0402779363a90fb1388693c197ee744a.ceb10167333758220ffb9bc66317ad763() == c82fcbab5e578dc3a31c1f662916bd87e.ceb10167333758220ffb9bc66317ad763())
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				float num = 0f;
				BHVMeleeAttackSettings bHVMeleeAttackSettings = bHVTaskManager.cd3d8b35d2647005675ba92178c253805<BHVMeleeAttackSettings>();
				if (bHVMeleeAttackSettings == null)
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
					BHVFlyMeleeAttackSettings bHVFlyMeleeAttackSettings = bHVTaskManager.cd3d8b35d2647005675ba92178c253805<BHVFlyMeleeAttackSettings>();
					if (bHVFlyMeleeAttackSettings == null)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							return false;
						}
					}
					num = bHVFlyMeleeAttackSettings.m_meleeAttackDistanceMax;
				}
				else
				{
					num = bHVMeleeAttackSettings.m_attackRange;
				}
				float sqrMagnitude = (c82fcbab5e578dc3a31c1f662916bd87e.c4cf00ced2bc60ae908904eb73692869f() - c0402779363a90fb1388693c197ee744a.c4cf00ced2bc60ae908904eb73692869f()).sqrMagnitude;
				if (sqrMagnitude < num * num + 1f)
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
					if (bHVTaskManager.m_actionParameters.m_bIgnoreAngle)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							return true;
						}
					}
					Vector3 normalized = (c82fcbab5e578dc3a31c1f662916bd87e.c4cf00ced2bc60ae908904eb73692869f() - c0402779363a90fb1388693c197ee744a.c4cf00ced2bc60ae908904eb73692869f()).normalized;
					if ((double)Vector3.Angle(c0402779363a90fb1388693c197ee744a.c06a97336d66561bdcc24dede6e251a09().forward, normalized) < (double)bHVMeleeAttackSettings.m_attackAngle * 0.5)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
				}
				return false;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return false;
	}

	public static Entity cb7a1ac349774c08a809d1019e54d3abd(Entity c0402779363a90fb1388693c197ee744a)
	{
		List<Entity> list = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cb8a72c40c1b6db1b4a333f6af978a477();
		Entity result = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
		float num = float.PositiveInfinity;
		for (int i = 0; i < list.Count; i++)
		{
			if (!cf2ad040936dbdf83d69a76dd5ef494f5(c0402779363a90fb1388693c197ee744a, list[i]))
			{
				continue;
			}
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
			Vector3 normalized = (list[i].c4cf00ced2bc60ae908904eb73692869f() - c0402779363a90fb1388693c197ee744a.c4cf00ced2bc60ae908904eb73692869f()).normalized;
			float num2 = Vector3.Angle(c0402779363a90fb1388693c197ee744a.c06a97336d66561bdcc24dede6e251a09().forward, normalized);
			if (!(num > num2))
			{
				continue;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			num = num2;
			result = list[i];
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return result;
		}
	}
}
