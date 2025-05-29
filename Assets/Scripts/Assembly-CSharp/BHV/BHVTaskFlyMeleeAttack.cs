using A;
using UnityEngine;

namespace BHV
{
	public class BHVTaskFlyMeleeAttack : BHVTask
	{
		private AnimationFlyMeleeAttackState c562110919b7e2f1a33636855b5eb7a17;

		private BHVTaskParamFlyMeleeAttack c2227ddc7fcbe3fa329465d2fa8ffb479;

		private BHVFlyingSettings c67bf4151e1034b2e476b66b9598d6987;

		private BHVFlyMeleeAttackSettings c34ec7531658ed4ca60bb341fe7d983fd;

		private RakkMovementSync c2162bbddc9c2463247b736678c0c3ac9;

		private bool c2bb435b54644e4b0a7f1923d6f60a324;

		private bool c66ea3d9decd8217001c5841fd6ecd14b;

		private float ce6ba655b84ecdb1ca1745f6dd1871596;

		private float ce60af2f64d59668ecbfac17485740106;

		private float c76df01a0730c89447bc2ba53e7af7b17;

		private float c54011edd4f01064640cb5e7dedd723e3;

		private float c4c798eb0a46c61d7bc57b0ada0a4401c;

		private bool cca9ed319bea3b24fa229a06579b0fa2e;

		private Vector3 c20de22a7cfadaec03815cdf17aae0477;

		private float c028e7e078b477463aa38509dd2cc14c2 = 1f;

		public BHVTaskFlyMeleeAttack()
		{
			base.m_Type = BHVTaskType.FlyMeleeAttack;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamFlyMeleeAttack;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c562110919b7e2f1a33636855b5eb7a17 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("FlyMeleeAttack") as AnimationFlyMeleeAttackState;
			c67bf4151e1034b2e476b66b9598d6987 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVFlyingSettings>();
			c34ec7531658ed4ca60bb341fe7d983fd = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVFlyMeleeAttackSettings>();
			c2162bbddc9c2463247b736678c0c3ac9 = cfc241af7ab51814fc074e767be1a0bb8.GetComponent<RakkMovementSync>();
			c2bb435b54644e4b0a7f1923d6f60a324 = false;
			c66ea3d9decd8217001c5841fd6ecd14b = false;
			ce6ba655b84ecdb1ca1745f6dd1871596 = 0f;
			c54011edd4f01064640cb5e7dedd723e3 = 0f;
			ce60af2f64d59668ecbfac17485740106 = Random.Range(c34ec7531658ed4ca60bb341fe7d983fd.m_meleeAttackIdleTimeMin, c34ec7531658ed4ca60bb341fe7d983fd.m_meleeAttackIdleTimeMax);
			c4c798eb0a46c61d7bc57b0ada0a4401c = -1f;
			cca9ed319bea3b24fa229a06579b0fa2e = false;
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.ca2633e89d18716d27bb002d0d98040c4)
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
				c2bb435b54644e4b0a7f1923d6f60a324 = true;
			}
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				float magnitude = (cfc241af7ab51814fc074e767be1a0bb8.m_entity.c4cf00ced2bc60ae908904eb73692869f() - c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position).magnitude;
				float num = magnitude / c67bf4151e1034b2e476b66b9598d6987.m_meleeFlyingSpeed;
				c028e7e078b477463aa38509dd2cc14c2 = num / (num - 0.1f);
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
			if (!c2bb435b54644e4b0a7f1923d6f60a324)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						ce60af2f64d59668ecbfac17485740106 -= deltaTime;
						if (ce60af2f64d59668ecbfac17485740106 < 0f)
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
							c2bb435b54644e4b0a7f1923d6f60a324 = true;
							c2162bbddc9c2463247b736678c0c3ac9.m_bEnable = true;
							cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.FlyMeleeAttack);
						}
						c1b2e42ae0b99637dce3a6caf9a944b18();
						return;
					}
				}
			}
			if (!c66ea3d9decd8217001c5841fd6ecd14b)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						float sqrMagnitude = (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).sqrMagnitude;
						float num = c34ec7531658ed4ca60bb341fe7d983fd.m_meleeAttackDistanceMax * c34ec7531658ed4ca60bb341fe7d983fd.m_meleeAttackDistanceMax;
						if (!(sqrMagnitude < num))
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
							if (!c2162bbddc9c2463247b736678c0c3ac9.m_bMelee)
							{
								cb61bd0ae60b3bdda41701e59c1c75b9c(deltaTime);
								return;
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
						}
						c0d33d753cdecb1f1d9b155d824a93552();
						return;
					}
					}
				}
			}
			c76df01a0730c89447bc2ba53e7af7b17 += deltaTime;
			if (!(c76df01a0730c89447bc2ba53e7af7b17 > 2.5f))
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
				cfc241af7ab51814fc074e767be1a0bb8.GetComponent<RakkMovementSync>().m_bEnable = false;
				c562110919b7e2f1a33636855b5eb7a17.c590cae7f6e6549e6ee43a89f05ed7141(true);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = false;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd6f933bd268aaf1967c46349307f50eb(false);
		}

		private void c1b2e42ae0b99637dce3a6caf9a944b18()
		{
			if (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position - cfc241af7ab51814fc074e767be1a0bb8.transform.position).normalized;
			normalized.y = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		private void cb61bd0ae60b3bdda41701e59c1c75b9c(float c2002bb238c228cf502166e05c0d89311)
		{
			ce6ba655b84ecdb1ca1745f6dd1871596 -= c2002bb238c228cf502166e05c0d89311;
			if (ce6ba655b84ecdb1ca1745f6dd1871596 > 2f)
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
				ce6ba655b84ecdb1ca1745f6dd1871596 = 0f;
			}
			Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position + Vector3.up * 1.6f;
			Vector3 cf30ca09410d525f5fc13bc4b5b50b7b = vector - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
			c4c798eb0a46c61d7bc57b0ada0a4401c -= c2002bb238c228cf502166e05c0d89311;
			if (c4c798eb0a46c61d7bc57b0ada0a4401c < 0f)
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
				c4c798eb0a46c61d7bc57b0ada0a4401c = 1f;
				int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
				Vector3 vector2 = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position + cf30ca09410d525f5fc13bc4b5b50b7b.normalized * 1f;
				float distance = (vector - vector2).magnitude - 1f;
				RaycastHit hitInfo;
				if (cca9ed319bea3b24fa229a06579b0fa2e = Physics.Raycast(vector2, cf30ca09410d525f5fc13bc4b5b50b7b.normalized, out hitInfo, distance, layerMask))
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
					c20de22a7cfadaec03815cdf17aae0477 = c2227ddc7fcbe3fa329465d2fa8ffb479.cef07c0192edda4db06f1628b4d2e6f65.transform.position;
					c20de22a7cfadaec03815cdf17aae0477.y = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position.y;
					c20de22a7cfadaec03815cdf17aae0477 += (c20de22a7cfadaec03815cdf17aae0477 - vector2).normalized * 5f;
				}
			}
			if (cca9ed319bea3b24fa229a06579b0fa2e)
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
				cf30ca09410d525f5fc13bc4b5b50b7b = c20de22a7cfadaec03815cdf17aae0477 - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
			}
			cac316c07251cc0c5b60b3cfbd704822d(c2002bb238c228cf502166e05c0d89311, cf30ca09410d525f5fc13bc4b5b50b7b, 0.1f);
		}

		private void cac316c07251cc0c5b60b3cfbd704822d(float c2002bb238c228cf502166e05c0d89311, Vector3 cf30ca09410d525f5fc13bc4b5b50b7b2, float c4ab217a688563fba6957734d4351f425)
		{
			Vector3 normalized = cf30ca09410d525f5fc13bc4b5b50b7b2.normalized;
			float sqrMagnitude = cf30ca09410d525f5fc13bc4b5b50b7b2.sqrMagnitude;
			c54011edd4f01064640cb5e7dedd723e3 += Time.deltaTime * 5f;
			c54011edd4f01064640cb5e7dedd723e3 = Mathf.Clamp(c54011edd4f01064640cb5e7dedd723e3, 0.1f, c67bf4151e1034b2e476b66b9598d6987.m_meleeFlyingSpeed);
			float num = Vector3.Angle(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized);
			float num2 = Mathf.Lerp(1f, 0.1f, num / 180f);
			float num3 = c54011edd4f01064640cb5e7dedd723e3 * c2002bb238c228cf502166e05c0d89311 * num2;
			num3 *= c028e7e078b477463aa38509dd2cc14c2;
			float num4 = c34ec7531658ed4ca60bb341fe7d983fd.m_meleeAttackDistanceMax + 6f;
			if (sqrMagnitude < num4 * num4)
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
				normalized.y = 0f;
				c4ab217a688563fba6957734d4351f425 *= 2f;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, normalized, c4ab217a688563fba6957734d4351f425);
		}

		private void c0d33d753cdecb1f1d9b155d824a93552()
		{
			c66ea3d9decd8217001c5841fd6ecd14b = true;
			c76df01a0730c89447bc2ba53e7af7b17 = 0f;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c4004fed08fd0ad52f8c3b650da10e9cb = true;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.cd6f933bd268aaf1967c46349307f50eb(true);
			c562110919b7e2f1a33636855b5eb7a17.c0d33d753cdecb1f1d9b155d824a93552(true);
			c5c0cb3532f012040b639d28d532763f0();
		}

		private void c5c0cb3532f012040b639d28d532763f0()
		{
		}
	}
}
