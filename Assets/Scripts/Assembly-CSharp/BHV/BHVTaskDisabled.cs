using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskDisabled : BHVTask
	{
		private BHVTaskParamDisabled c2227ddc7fcbe3fa329465d2fa8ffb479;

		public BHVTaskDisabled()
		{
			base.m_Type = BHVTaskType.Disabled;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamDisabled;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			Renderer[] componentsInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_entity.gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = c2227ddc7fcbe3fa329465d2fa8ffb479.c07fe8fb380346d1eece6117558fba23a;
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
				EntityNpc entityNpc = cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc;
				if (entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (entityNpc.m_subType == EntityNpc.EntitySubType.CHR_TheInsane)
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
						goto IL_0132;
					}
				}
				Collider[] componentsInChildren2 = cfc241af7ab51814fc074e767be1a0bb8.m_entity.gameObject.GetComponentsInChildren<Collider>();
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					componentsInChildren2[j].enabled = c2227ddc7fcbe3fa329465d2fa8ffb479.c07fe8fb380346d1eece6117558fba23a;
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
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.c07fe8fb380346d1eece6117558fba23a)
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
					DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cf3d2cb82d21abb0d2de84f85c25fdb49(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
				}
				else
				{
					DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd5e20c96aa545559531f1792ec0f8b61(cfc241af7ab51814fc074e767be1a0bb8.m_entity);
				}
				goto IL_0132;
				IL_0132:
				AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.m_bPlayCutScene = c2227ddc7fcbe3fa329465d2fa8ffb479.c5653506405755a849ee3fa7c77cbc359;
				return;
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}
	}
}
