using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskEyeLaser : BHVTask
	{
		private BHVTaskParamEyeLaser c2227ddc7fcbe3fa329465d2fa8ffb479;

		private TheInsaneAnimationManagerFSM c2477797dca3dcfdda3f411d45d938632;

		private Transform c9b7d118191d1bad102a05705ccdd3899;

		private Transform c9551f019bfe5ce0851caf5f4a076f4c1;

		private float c588e32794066adce62c15ff7e74ad1e1 = 1f;

		private float ca8e64932c38c6e6fbc8e7a37caa55b3c = 4f;

		private bool c26a255322be84395f445260b382d4499;

		private bool c2ae2fd59ae8da6358e07db95d57d8c69;

		public BHVTaskEyeLaser()
		{
			base.m_Type = BHVTaskType.EyeLaser;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamEyeLaser;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c588e32794066adce62c15ff7e74ad1e1 = c2227ddc7fcbe3fa329465d2fa8ffb479.c588e32794066adce62c15ff7e74ad1e1;
			ca8e64932c38c6e6fbc8e7a37caa55b3c = c2227ddc7fcbe3fa329465d2fa8ffb479.ca8e64932c38c6e6fbc8e7a37caa55b3c;
			c26a255322be84395f445260b382d4499 = false;
			c2ae2fd59ae8da6358e07db95d57d8c69 = false;
			c9b7d118191d1bad102a05705ccdd3899 = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
			c9551f019bfe5ce0851caf5f4a076f4c1 = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
			c2477797dca3dcfdda3f411d45d938632 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as TheInsaneAnimationManagerFSM;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEyeLaserWarning", true);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			float num = float.PositiveInfinity;
			if (c9b7d118191d1bad102a05705ccdd3899 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c9551f019bfe5ce0851caf5f4a076f4c1 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c9b7d118191d1bad102a05705ccdd3899.position = c9551f019bfe5ce0851caf5f4a076f4c1.position;
						Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position - c9b7d118191d1bad102a05705ccdd3899.position).normalized;
						num = Vector3.Angle(c9b7d118191d1bad102a05705ccdd3899.transform.forward, normalized);
						if (num > 0.1f)
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
							c9b7d118191d1bad102a05705ccdd3899.transform.forward = Vector3.Lerp(c9b7d118191d1bad102a05705ccdd3899.transform.forward, normalized, c2227ddc7fcbe3fa329465d2fa8ffb479.cc905ef972ddd52c1d6950923ac902265 * Time.deltaTime);
						}
					}
				}
			}
			if (ca8e64932c38c6e6fbc8e7a37caa55b3c > 0f)
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
				if (!c26a255322be84395f445260b382d4499)
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
					ca8e64932c38c6e6fbc8e7a37caa55b3c -= Time.deltaTime;
					if (ca8e64932c38c6e6fbc8e7a37caa55b3c < 1.2f)
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
						if (!c2ae2fd59ae8da6358e07db95d57d8c69)
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
							c2ae2fd59ae8da6358e07db95d57d8c69 = true;
							if (c2477797dca3dcfdda3f411d45d938632 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								c9b7d118191d1bad102a05705ccdd3899 = c2477797dca3dcfdda3f411d45d938632.ce094aed7060d8c8dd1ca9c2bd726432e(true);
								if (c9b7d118191d1bad102a05705ccdd3899 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									c9551f019bfe5ce0851caf5f4a076f4c1 = c9b7d118191d1bad102a05705ccdd3899.parent;
									c9b7d118191d1bad102a05705ccdd3899.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
								}
							}
						}
					}
					if (!(ca8e64932c38c6e6fbc8e7a37caa55b3c <= 0f))
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
						break;
					}
					c26a255322be84395f445260b382d4499 = true;
				}
			}
			c588e32794066adce62c15ff7e74ad1e1 -= Time.deltaTime;
			if (!(c588e32794066adce62c15ff7e74ad1e1 < 0f))
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

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			if (c2477797dca3dcfdda3f411d45d938632 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c2477797dca3dcfdda3f411d45d938632.ce094aed7060d8c8dd1ca9c2bd726432e(false);
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEyeLaserWarning", false);
			c9b7d118191d1bad102a05705ccdd3899.parent = c9551f019bfe5ce0851caf5f4a076f4c1;
		}
	}
}
