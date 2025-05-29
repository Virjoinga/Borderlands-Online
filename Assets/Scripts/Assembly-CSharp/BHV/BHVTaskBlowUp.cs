using System.Text;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskBlowUp : BHVTask
	{
		private enum State
		{
			c6d1f578be4de6db437a078aa502b0284 = -1,
			cd466a2d8b9ce98c1f7ff37e62cd37d3b = 0,
			ccb86e27d3d17a4f78948ef02f4c4412c = 2
		}

		private BHVTaskParamBlowUp c2227ddc7fcbe3fa329465d2fa8ffb479;

		private State c45bb77f7ef7c0cfb4e9839ab212a467f = State.c6d1f578be4de6db437a078aa502b0284;

		private int c1f499407d8cf54c40252cdbbbcedfd0f = 10;

		public BHVTaskBlowUp()
		{
			base.m_Type = BHVTaskType.BlowUp;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamBlowUp;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c45bb77f7ef7c0cfb4e9839ab212a467f = State.cd466a2d8b9ce98c1f7ff37e62cd37d3b;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			c1f499407d8cf54c40252cdbbbcedfd0f--;
			switch (c45bb77f7ef7c0cfb4e9839ab212a467f)
			{
			case State.c6d1f578be4de6db437a078aa502b0284:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case State.cd466a2d8b9ce98c1f7ff37e62cd37d3b:
			{
				c45bb77f7ef7c0cfb4e9839ab212a467f = State.ccb86e27d3d17a4f78948ef02f4c4412c;
				cfc241af7ab51814fc074e767be1a0bb8.GetComponent<VFXManager>().cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_Explode);
				Transform transform = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.Find("Point light");
				if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					Animation component = transform.gameObject.GetComponent<Animation>();
					if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						component.CrossFade("PTL_Grenade_Light");
					}
				}
				Renderer componentInChildren = cfc241af7ab51814fc074e767be1a0bb8.m_entity.gameObject.GetComponentInChildren<Renderer>();
				if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					componentInChildren.enabled = false;
				}
				EntityExplosive entityExplosive = cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityExplosive;
				if (!(entityExplosive != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					entityExplosive.c8f0de95b6b6a3e87162079927a1bee91();
					return;
				}
			}
			}
			if (c1f499407d8cf54c40252cdbbbcedfd0f != 0)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (c2227ddc7fcbe3fa329465d2fa8ffb479 != null)
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
				stringBuilder.Append(string.Format("        State:{0}\n", c45bb77f7ef7c0cfb4e9839ab212a467f));
			}
			return stringBuilder.ToString();
		}
	}
}
