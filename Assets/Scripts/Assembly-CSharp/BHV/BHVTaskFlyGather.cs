using UnityEngine;

namespace BHV
{
	public class BHVTaskFlyGather : BHVTask
	{
		private BHVTaskParamFlyGather c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationFlyGatherState c91ce6d06375d1823ee619d178570b6e9;

		private BHVFlyingSettings c67bf4151e1034b2e476b66b9598d6987;

		private Vector3 cc43e085c71fed64037b1c18c8012f638;

		private float c4c798eb0a46c61d7bc57b0ada0a4401c;

		private bool cca9ed319bea3b24fa229a06579b0fa2e;

		private Vector3 c20de22a7cfadaec03815cdf17aae0477;

		public BHVTaskFlyGather()
		{
			base.m_Type = BHVTaskType.FlyGather;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamFlyGather;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c91ce6d06375d1823ee619d178570b6e9 = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("FlyGather") as AnimationFlyGatherState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.FlyGather);
			c67bf4151e1034b2e476b66b9598d6987 = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVFlyingSettings>();
			cc43e085c71fed64037b1c18c8012f638 = c2227ddc7fcbe3fa329465d2fa8ffb479.c1be32fa9250970af89c99175dfed3044;
			base.m_Status = BHVTaskStatus.RUNNING;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_validateNextMovePosition = false;
			c4c798eb0a46c61d7bc57b0ada0a4401c = -1f;
			cca9ed319bea3b24fa229a06579b0fa2e = false;
		}

		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
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
						return;
					}
				}
			}
			base.Update(deltaTime);
			ca5f4f0fd760e3317baccf75f0d32051d(deltaTime);
		}

		private void ca5f4f0fd760e3317baccf75f0d32051d(float c2002bb238c228cf502166e05c0d89311)
		{
			Vector3 c88aa4daa934851333caa876a907f0efd = cc43e085c71fed64037b1c18c8012f638 - cfc241af7ab51814fc074e767be1a0bb8.m_entity.c4cf00ced2bc60ae908904eb73692869f();
			Vector3 normalized = c88aa4daa934851333caa876a907f0efd.normalized;
			if (c88aa4daa934851333caa876a907f0efd.sqrMagnitude < 0.02f)
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
						base.m_Status = BHVTaskStatus.SUCCESS;
						return;
					}
				}
			}
			c4c798eb0a46c61d7bc57b0ada0a4401c -= c2002bb238c228cf502166e05c0d89311;
			if (c4c798eb0a46c61d7bc57b0ada0a4401c < 0f)
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
				c4c798eb0a46c61d7bc57b0ada0a4401c = 1f;
				int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
				Vector3 origin = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position + normalized * 1f;
				float distance = c67bf4151e1034b2e476b66b9598d6987.m_gatherFlyingSpeed * c2002bb238c228cf502166e05c0d89311;
				RaycastHit hitInfo;
				if (cca9ed319bea3b24fa229a06579b0fa2e = Physics.Raycast(origin, normalized, out hitInfo, distance, layerMask))
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
					c20de22a7cfadaec03815cdf17aae0477 = cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
					c20de22a7cfadaec03815cdf17aae0477.y = cc43e085c71fed64037b1c18c8012f638.y;
				}
			}
			if (cca9ed319bea3b24fa229a06579b0fa2e)
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
				c88aa4daa934851333caa876a907f0efd = c20de22a7cfadaec03815cdf17aae0477 - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position;
				normalized = c88aa4daa934851333caa876a907f0efd.normalized;
			}
			cac316c07251cc0c5b60b3cfbd704822d(c2002bb238c228cf502166e05c0d89311, normalized, c88aa4daa934851333caa876a907f0efd);
		}

		private void cac316c07251cc0c5b60b3cfbd704822d(float c2002bb238c228cf502166e05c0d89311, Vector3 c8ce5fe64211495642c11d922565b56f1, Vector3 c88aa4daa934851333caa876a907f0efd)
		{
			float num = Vector3.Angle(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, c8ce5fe64211495642c11d922565b56f1);
			float num2 = Mathf.Lerp(1f, 0.1f, num / 180f);
			float num3 = c67bf4151e1034b2e476b66b9598d6987.m_gatherFlyingSpeed * c2002bb238c228cf502166e05c0d89311 * num2;
			float magnitude = c88aa4daa934851333caa876a907f0efd.magnitude;
			if (magnitude < num3)
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
				num3 = magnitude;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position += c8ce5fe64211495642c11d922565b56f1 * num3;
			if (!cca9ed319bea3b24fa229a06579b0fa2e)
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
				cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, c8ce5fe64211495642c11d922565b56f1, 0.1f);
			}
			else
			{
				cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, c8ce5fe64211495642c11d922565b56f1, 0.8f);
			}
			Vector3 normalized = (cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position - cc43e085c71fed64037b1c18c8012f638).normalized;
			float num4 = Vector3.Dot(normalized, c8ce5fe64211495642c11d922565b56f1);
			float num5;
			if (num4 > 0f)
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
				num5 = num;
			}
			else
			{
				num5 = -1f * num;
			}
			num4 = num5;
			if (num4 < -15f)
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
				num4 = -90f;
			}
			else if (num4 > 15f)
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
				num4 = 90f;
			}
			else
			{
				num4 = 0f;
			}
			c91ce6d06375d1823ee619d178570b6e9.m_turnAngle = Mathf.Lerp(c91ce6d06375d1823ee619d178570b6e9.m_turnAngle, num4, 0.1f);
		}
	}
}
