using System.Collections.Generic;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskEarthPikeAttack : BHVTask
	{
		private BHVTaskParamEarthPikeAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private BHVEarthPikeAttackSettings c6c68c55b2e27aa9d3fcc63afb8f5878d;

		private AnimationRadiusAttackState c2f1176477bb9f9e6348704cc5aab27ca;

		private bool cd5bcdd48cc38f1d4084e062fb2121939;

		private float ce902c639c179f2e78fd1621e43ab4593;

		private Object cae7c6c36d75327a2445b3ab3e055db31;

		private int c65edee5a363fb7a4371a0ae402616511 = 1;

		public List<PlayerInfoSync> c6fecf7c8cb00fc036bfb35364bc2f9a9;

		public BHVTaskEarthPikeAttack()
		{
			base.m_Type = BHVTaskType.EarthPikeAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamEarthPikeAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c2f1176477bb9f9e6348704cc5aab27ca = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("RadiusAttack") as AnimationRadiusAttackState;
			cd5bcdd48cc38f1d4084e062fb2121939 = false;
			ce902c639c179f2e78fd1621e43ab4593 = 0f;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c6fecf7c8cb00fc036bfb35364bc2f9a9);
			c65edee5a363fb7a4371a0ae402616511 = c6fecf7c8cb00fc036bfb35364bc2f9a9.Count;
			if (cae7c6c36d75327a2445b3ab3e055db31 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				cae7c6c36d75327a2445b3ab3e055db31 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/IcePickEarth");
			}
			c6c68c55b2e27aa9d3fcc63afb8f5878d = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVEarthPikeAttackSettings>();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.RadiusAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			if (!c2f1176477bb9f9e6348704cc5aab27ca.m_bDoDamage)
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
			if (!cd5bcdd48cc38f1d4084e062fb2121939)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						cd5bcdd48cc38f1d4084e062fb2121939 = true;
						c51a783faeaa1ca3c86d65f7ab74ef31b();
						return;
					}
				}
			}
			ce902c639c179f2e78fd1621e43ab4593 += Time.deltaTime;
			if (!(ce902c639c179f2e78fd1621e43ab4593 > 3f))
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		private void c51a783faeaa1ca3c86d65f7ab74ef31b()
		{
			if (cae7c6c36d75327a2445b3ab3e055db31 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			PlayerInfoSync c7088de59e49f7108f520cf7e0bae167e = c7cfa05fd8fe0a2d1791d3ae1202ecb42.c7088de59e49f7108f520cf7e0bae167e;
			for (int i = 0; i < c65edee5a363fb7a4371a0ae402616511; i++)
			{
				c7088de59e49f7108f520cf7e0bae167e = c6fecf7c8cb00fc036bfb35364bc2f9a9[i];
				if (c7088de59e49f7108f520cf7e0bae167e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				EntityPlayer entityPlayer = c7088de59e49f7108f520cf7e0bae167e.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
				if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				float num = 360f / (float)c6c68c55b2e27aa9d3fcc63afb8f5878d.m_pikeAmount;
				Vector3 forward = entityPlayer.transform.forward;
				for (int j = 0; j < c6c68c55b2e27aa9d3fcc63afb8f5878d.m_pikeAmount; j++)
				{
					Vector3 vector = Quaternion.Euler(0f, num * (float)j, 0f) * forward;
					Vector3 vector2 = entityPlayer.c4cf00ced2bc60ae908904eb73692869f() + vector * c6c68c55b2e27aa9d3fcc63afb8f5878d.m_distanceToPlayer;
					RaycastHit hitInfo;
					if (Physics.Raycast(vector2 + Vector3.up * 2f, -Vector3.up, out hitInfo, 5f, 1 << LayerMask.NameToLayer("Walkable")))
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
						vector2 = hitInfo.point;
					}
					vector2.y -= 4.5f;
					GameObject gameObject = (GameObject)Object.Instantiate(cae7c6c36d75327a2445b3ab3e055db31);
					if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						break;
					}
					gameObject.transform.position = vector2;
					Quaternion identity = Quaternion.identity;
					Vector3 eulerAngles = identity.eulerAngles;
					eulerAngles.x = 270f;
					eulerAngles.x = Random.Range(eulerAngles.x - 10f, eulerAngles.x + 10f);
					eulerAngles.y = Random.Range(eulerAngles.y - 10f, eulerAngles.y + 10f);
					eulerAngles.z = Random.Range(eulerAngles.z - 10f, eulerAngles.z + 10f);
					identity.eulerAngles = eulerAngles;
					gameObject.transform.rotation = identity;
					IceThorn component = gameObject.GetComponent<IceThorn>();
					if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						break;
					}
					component.m_index = AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.c963ef5d4b51a9309fa9483d743ab9b33(component);
					component.m_HP = c2227ddc7fcbe3fa329465d2fa8ffb479.c234a225e5146e18834e6facf5ee08720;
					component.m_maxHP = c2227ddc7fcbe3fa329465d2fa8ffb479.c234a225e5146e18834e6facf5ee08720;
					component.m_BHVTaskManager = cfc241af7ab51814fc074e767be1a0bb8;
					component.m_damage = c6c68c55b2e27aa9d3fcc63afb8f5878d.m_pikeDamage;
					component.m_damageRadius = c6c68c55b2e27aa9d3fcc63afb8f5878d.m_pikeDamageRadius;
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
			}
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
	}
}
