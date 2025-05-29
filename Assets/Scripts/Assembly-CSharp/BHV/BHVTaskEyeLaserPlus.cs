using System.Collections.Generic;
using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskEyeLaserPlus : BHVTask
	{
		private BHVTaskParamEyeLaserPlus c2227ddc7fcbe3fa329465d2fa8ffb479;

		private TheInsaneAnimationManagerFSM c2477797dca3dcfdda3f411d45d938632;

		private Transform c9b7d118191d1bad102a05705ccdd3899;

		private Transform c9551f019bfe5ce0851caf5f4a076f4c1;

		private float c588e32794066adce62c15ff7e74ad1e1 = 1f;

		private float ca8e64932c38c6e6fbc8e7a37caa55b3c = 4f;

		private float c562388425a3e6d47d677bfaea90f98bc = 4f;

		private bool c26a255322be84395f445260b382d4499;

		private bool ca879f9937b7330366e13158a8d756499 = true;

		private GameObject cd66a025c06c9c0a70fde180bbe7b44a1;

		private PointList c381aafe3a7da9fe4b15d943e8e22978d;

		private List<GameObject> c61c2ab6398c119599177051d093b8f50 = new List<GameObject>();

		private List<GameObject> cc298d9df0288229c24ec4a7791409c48 = new List<GameObject>();

		private List<Vector3> c22be05807a50b66557fa48b85dc14bbe = new List<Vector3>();

		public BHVTaskEyeLaserPlus()
		{
			base.m_Type = BHVTaskType.EyeLaserPlus;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamEyeLaserPlus;
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
			c562388425a3e6d47d677bfaea90f98bc = c2227ddc7fcbe3fa329465d2fa8ffb479.ca8e64932c38c6e6fbc8e7a37caa55b3c;
			c26a255322be84395f445260b382d4499 = false;
			ca879f9937b7330366e13158a8d756499 = true;
			cd66a025c06c9c0a70fde180bbe7b44a1 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			if (c381aafe3a7da9fe4b15d943e8e22978d == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				GameObject gameObject = GameObject.Find("LaserTowerList");
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
					c381aafe3a7da9fe4b15d943e8e22978d = gameObject.GetComponent<PointList>();
				}
			}
			c61c2ab6398c119599177051d093b8f50.Clear();
			cc298d9df0288229c24ec4a7791409c48.Clear();
			c22be05807a50b66557fa48b85dc14bbe.Clear();
			c2477797dca3dcfdda3f411d45d938632 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM as TheInsaneAnimationManagerFSM;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEyeLaserPlusWarning", true);
			cdfc0ce050356b731ec220569ed497bd2();
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			base.Update(deltaTime);
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
			}
			if (c9b7d118191d1bad102a05705ccdd3899 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Vector3 position = cd66a025c06c9c0a70fde180bbe7b44a1.transform.position;
				position.y += 1.5f;
				c9b7d118191d1bad102a05705ccdd3899.transform.forward = (position - c9b7d118191d1bad102a05705ccdd3899.position).normalized;
			}
			if (ca879f9937b7330366e13158a8d756499)
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
				ca8e64932c38c6e6fbc8e7a37caa55b3c -= deltaTime;
				if (!(ca8e64932c38c6e6fbc8e7a37caa55b3c < 0f))
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
					break;
				}
				if (c2477797dca3dcfdda3f411d45d938632 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c9b7d118191d1bad102a05705ccdd3899 = c2477797dca3dcfdda3f411d45d938632.cf6ccb206cd2e66d4a29dcc9b689fff12(true);
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
						c9551f019bfe5ce0851caf5f4a076f4c1 = c9b7d118191d1bad102a05705ccdd3899.parent;
						c9b7d118191d1bad102a05705ccdd3899.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
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
						}
						c9b7d118191d1bad102a05705ccdd3899.transform.forward = (cd66a025c06c9c0a70fde180bbe7b44a1.transform.position + Vector3.up * 1.5f - c9b7d118191d1bad102a05705ccdd3899.position).normalized;
					}
				}
				ca879f9937b7330366e13158a8d756499 = false;
				cf937b704503eef4030d150c120639913();
			}
			if (!c26a255322be84395f445260b382d4499)
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
				c562388425a3e6d47d677bfaea90f98bc -= deltaTime;
				if (!(c562388425a3e6d47d677bfaea90f98bc < 0f))
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
					break;
				}
				c26a255322be84395f445260b382d4499 = true;
				c8a8ff26fbbba6543d8ab8082388d1496();
			}
			c588e32794066adce62c15ff7e74ad1e1 -= deltaTime;
			if (!(c588e32794066adce62c15ff7e74ad1e1 < 0f))
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				if (!(c2477797dca3dcfdda3f411d45d938632 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					c2477797dca3dcfdda3f411d45d938632.cf6ccb206cd2e66d4a29dcc9b689fff12(false);
					return;
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bEyeLaserPlusWarning", false);
			if (base.m_Status != BHVTaskStatus.SUCCESS)
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
				base.m_Status = BHVTaskStatus.SUCCESS;
				if (c2477797dca3dcfdda3f411d45d938632 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c2477797dca3dcfdda3f411d45d938632.cf6ccb206cd2e66d4a29dcc9b689fff12(false);
				}
			}
			int count = cc298d9df0288229c24ec4a7791409c48.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				Object.Destroy(cc298d9df0288229c24ec4a7791409c48[num]);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				cc298d9df0288229c24ec4a7791409c48.Clear();
				c22be05807a50b66557fa48b85dc14bbe.Clear();
				c9b7d118191d1bad102a05705ccdd3899.parent = c9551f019bfe5ce0851caf5f4a076f4c1;
				return;
			}
		}

		private void cdfc0ce050356b731ec220569ed497bd2()
		{
			int num = c381aafe3a7da9fe4b15d943e8e22978d.m_pointList.Length;
			float num2 = float.PositiveInfinity;
			for (int i = 0; i < num; i++)
			{
				Vector3 position = c381aafe3a7da9fe4b15d943e8e22978d.m_pointList[i].transform.position;
				float sqrMagnitude = (position - c2227ddc7fcbe3fa329465d2fa8ffb479.cb9f7c51b162366e74587b2610dae6e64.transform.position).sqrMagnitude;
				if (!(sqrMagnitude < num2))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				cd66a025c06c9c0a70fde180bbe7b44a1 = c381aafe3a7da9fe4b15d943e8e22978d.m_pointList[i].gameObject;
				num2 = sqrMagnitude;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				if (cd66a025c06c9c0a70fde180bbe7b44a1 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				c61c2ab6398c119599177051d093b8f50.Add(cd66a025c06c9c0a70fde180bbe7b44a1);
				float num3 = c2227ddc7fcbe3fa329465d2fa8ffb479.c3f466c29c49a3403ee37f3f258a8d105 * c2227ddc7fcbe3fa329465d2fa8ffb479.c3f466c29c49a3403ee37f3f258a8d105;
				for (int j = 0; j < num; j++)
				{
					if (c381aafe3a7da9fe4b15d943e8e22978d.m_pointList[j].gameObject == cd66a025c06c9c0a70fde180bbe7b44a1)
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
						continue;
					}
					Vector3 position2 = c381aafe3a7da9fe4b15d943e8e22978d.m_pointList[j].transform.position;
					float sqrMagnitude2 = (position2 - cd66a025c06c9c0a70fde180bbe7b44a1.transform.position).sqrMagnitude;
					if (!(sqrMagnitude2 < num3))
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
					c61c2ab6398c119599177051d093b8f50.Add(c381aafe3a7da9fe4b15d943e8e22978d.m_pointList[j].gameObject);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					int count = c61c2ab6398c119599177051d093b8f50.Count;
					if (count > 1)
					{
						return;
					}
					while (true)
					{
						switch (5)
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

		private void cf937b704503eef4030d150c120639913()
		{
			GameObject gameObject = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_spawnObjPrefabList[1];
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			float num = 1.2f;
			int count = c61c2ab6398c119599177051d093b8f50.Count;
			for (int i = 0; i < count; i++)
			{
				for (int j = i + 1; j < count; j++)
				{
					GameObject gameObject2 = Object.Instantiate(gameObject) as GameObject;
					if (!(gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					cc298d9df0288229c24ec4a7791409c48.Add(gameObject2);
					Vector3 position = c61c2ab6398c119599177051d093b8f50[i].transform.position;
					position.y += num;
					gameObject2.GetComponent<LineRenderer>().SetPosition(0, position);
					c22be05807a50b66557fa48b85dc14bbe.Add(position);
					position = c61c2ab6398c119599177051d093b8f50[j].transform.position;
					position.y += num;
					gameObject2.GetComponent<LineRenderer>().SetPosition(1, position);
					c22be05807a50b66557fa48b85dc14bbe.Add(position);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_013d;
					}
					continue;
					end_IL_013d:
					break;
				}
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		private void c8a8ff26fbbba6543d8ab8082388d1496()
		{
			GameObject gameObject = (cfc241af7ab51814fc074e767be1a0bb8.m_entity as EntityNpc).m_spawnObjPrefabList[2];
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			int count = c22be05807a50b66557fa48b85dc14bbe.Count;
			int num = 0;
			while (num < count)
			{
				GameObject gameObject2 = Object.Instantiate(gameObject) as GameObject;
				if (!(gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				cc298d9df0288229c24ec4a7791409c48.Add(gameObject2);
				gameObject2.GetComponent<LineRenderer>().SetPosition(0, c22be05807a50b66557fa48b85dc14bbe[num++]);
				gameObject2.GetComponent<LineRenderer>().SetPosition(1, c22be05807a50b66557fa48b85dc14bbe[num++]);
			}
			while (true)
			{
				switch (7)
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
