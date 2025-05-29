using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskDeathStruggle : BHVTask
	{
		private BHVTaskParamDeathStruggle c2227ddc7fcbe3fa329465d2fa8ffb479;

		private bool cdbf87d71840239dcd2f34d841d0ef498;

		private bool c66d006203e7db911c1f4a265ca9628c1;

		public BHVTaskDeathStruggle()
		{
			base.m_Type = BHVTaskType.DeathStruggle;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDeathStruggle;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			cdbf87d71840239dcd2f34d841d0ef498 = false;
			c66d006203e7db911c1f4a265ca9628c1 = false;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!cdbf87d71840239dcd2f34d841d0ef498)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.c0bddf055d7ca08c09dc871e580825e72 - cfc241af7ab51814fc074e767be1a0bb8.transform.position;
						float num = 20f;
						float sqrMagnitude = vector.sqrMagnitude;
						if (sqrMagnitude < Time.deltaTime * num * Time.deltaTime * num)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position = c2227ddc7fcbe3fa329465d2fa8ffb479.c0bddf055d7ca08c09dc871e580825e72;
									cdbf87d71840239dcd2f34d841d0ef498 = true;
									return;
								}
							}
						}
						cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position += vector.normalized * num * Time.deltaTime;
						return;
					}
					}
				}
			}
			if (c66d006203e7db911c1f4a265ca9628c1)
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
				if (cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bDeathStruggle", true);
				}
				c66d006203e7db911c1f4a265ca9628c1 = true;
				int layerMask = 1 << LayerMask.NameToLayer("Walkable");
				RaycastHit hitInfo;
				if (!Physics.Raycast(c2227ddc7fcbe3fa329465d2fa8ffb479.c0bddf055d7ca08c09dc871e580825e72 + Vector3.down * 5f, Vector3.down, out hitInfo, 100f, layerMask))
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
					if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_archangelDeathStruggle, hitInfo.point);
						return;
					}
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (!(cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_VFXManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_archangelDeathStruggle);
				return;
			}
		}
	}
}
