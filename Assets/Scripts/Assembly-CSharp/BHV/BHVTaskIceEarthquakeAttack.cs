using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskIceEarthquakeAttack : BHVTask
	{
		private BHVTaskParamIceEarthquakeAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationRadiusAttackState c2f1176477bb9f9e6348704cc5aab27ca;

		private int c979881e1b93a45bdf31fdd778c05dacc;

		private float c3bdee8d19fd5f55a2762eef4b99f592c;

		private Vector3 c592803e3800abdc0a47aaea7bfa1e2f5;

		private Vector3 c6fd618d6ef2c645fdd79a2dcd44d68ff;

		public BHVTaskIceEarthquakeAttack()
		{
			base.m_Type = BHVTaskType.IceEarthquakeAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamIceEarthquakeAttack;
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
			c979881e1b93a45bdf31fdd778c05dacc = 0;
			c592803e3800abdc0a47aaea7bfa1e2f5 = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
			c6fd618d6ef2c645fdd79a2dcd44d68ff = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.RadiusAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			cb9639a2fcbb63d05803cb6f04384c8ca();
			if (!c2f1176477bb9f9e6348704cc5aab27ca.m_bDoDamage)
			{
				while (true)
				{
					switch (4)
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
			if (c979881e1b93a45bdf31fdd778c05dacc < c2227ddc7fcbe3fa329465d2fa8ffb479.c847416d37b991d227537108be7e018d6)
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
				if (!(c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					c3bdee8d19fd5f55a2762eef4b99f592c += deltaTime;
					if (!(c3bdee8d19fd5f55a2762eef4b99f592c > c2227ddc7fcbe3fa329465d2fa8ffb479.cdf47769ad622c4e744ee790d4bce92cf))
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
						c3bdee8d19fd5f55a2762eef4b99f592c = 0f;
						Vector3 c5e7e225b05fb55975eb05045484b9e = ca5f70dc49767ef8233409ca10c8173a4(c979881e1b93a45bdf31fdd778c05dacc);
						c33da1739f49d1623515deae2e95d9a1d(c5e7e225b05fb55975eb05045484b9e);
						c592803e3800abdc0a47aaea7bfa1e2f5 = c5e7e225b05fb55975eb05045484b9e;
						c979881e1b93a45bdf31fdd778c05dacc++;
						return;
					}
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
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		private void cb9639a2fcbb63d05803cb6f04384c8ca()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						return;
					}
				}
			}
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		private Vector3 ca5f70dc49767ef8233409ca10c8173a4(int c6917a4d7136c4b7ee0d3e50bcbf6c798)
		{
			if (c6917a4d7136c4b7ee0d3e50bcbf6c798 < c2227ddc7fcbe3fa329465d2fa8ffb479.cc76de556484cafe7e7ae83c50164cffe)
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
				c6fd618d6ef2c645fdd79a2dcd44d68ff = (c2227ddc7fcbe3fa329465d2fa8ffb479.c14854daae2833463b186fc5cc589a09c.transform.position - c592803e3800abdc0a47aaea7bfa1e2f5).normalized;
				c6fd618d6ef2c645fdd79a2dcd44d68ff.y = 0f;
			}
			Vector3 vector = c592803e3800abdc0a47aaea7bfa1e2f5 + c6fd618d6ef2c645fdd79a2dcd44d68ff * c2227ddc7fcbe3fa329465d2fa8ffb479.cb04ae3d0740704306ed2b9109ba63ea1;
			RaycastHit hitInfo;
			if (Physics.Raycast(vector + Vector3.up * 2f, -Vector3.up, out hitInfo, 3f, 1 << LayerMask.NameToLayer("Walkable")))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return hitInfo.point;
					}
				}
			}
			return c592803e3800abdc0a47aaea7bfa1e2f5;
		}

		private void c33da1739f49d1623515deae2e95d9a1d(Vector3 c5e7e225b05fb55975eb05045484b9e40)
		{
			GameObject gameObject = (GameObject)Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/Object/Weapon/IceThorn"));
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c5e7e225b05fb55975eb05045484b9e40.y -= 0.6f;
				gameObject.transform.position = c5e7e225b05fb55975eb05045484b9e40;
				Quaternion identity = Quaternion.identity;
				Vector3 eulerAngles = identity.eulerAngles;
				eulerAngles.x = 270f;
				eulerAngles.x = Random.Range(eulerAngles.x - 30f, eulerAngles.x + 30f);
				eulerAngles.y = Random.Range(eulerAngles.y - 30f, eulerAngles.y + 30f);
				eulerAngles.z = Random.Range(eulerAngles.z - 30f, eulerAngles.z + 30f);
				identity.eulerAngles = eulerAngles;
				gameObject.transform.rotation = identity;
			}
			OnInstanciate(gameObject);
		}

		public void OnInstanciate(GameObject instance)
		{
			if (!(instance != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Object.Destroy(instance, 3f);
				return;
			}
		}
	}
}
