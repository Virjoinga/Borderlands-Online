using UnityEngine;

namespace BHV
{
	public class BHVTaskHoverPatrol : BHVTask
	{
		private BHVTaskParamHoverPatrol c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationHoverPatrolState c7b12fa9940ed075509ce57469cd836bd;

		private BHVFlyingSettings c5b4223b17339aa0f392e4119b11b6aab;

		private bool c107f97718a124443672c38210505dd50;

		private Vector3 c1ad78e557f29dbfb5e86c0ac6b553522;

		public BHVTaskHoverPatrol()
		{
			base.m_Type = BHVTaskType.HoverPatrol;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamHoverPatrol;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			c7b12fa9940ed075509ce57469cd836bd = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("HoverPatrol") as AnimationHoverPatrolState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.HoverPatrol);
			c5b4223b17339aa0f392e4119b11b6aab = cfc241af7ab51814fc074e767be1a0bb8.cd3d8b35d2647005675ba92178c253805<BHVFlyingSettings>();
			c107f97718a124443672c38210505dd50 = false;
			cf46f13e7bcb27a3d144d7e088b030e91();
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_validateNextMovePosition = false;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!c107f97718a124443672c38210505dd50)
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
						c900021177294a4f2bb16d02ddfa548c8(deltaTime);
						return;
					}
				}
			}
			c586b4f4d7845fc8c5df2f1a139334170(deltaTime);
		}

		private void cf46f13e7bcb27a3d144d7e088b030e91()
		{
			Vector3 normalized = (c2227ddc7fcbe3fa329465d2fa8ffb479.c9de49121b6b7cf920b8634d8371514e9 - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			normalized.y = 0f;
			c1ad78e557f29dbfb5e86c0ac6b553522 = c2227ddc7fcbe3fa329465d2fa8ffb479.c9de49121b6b7cf920b8634d8371514e9 + Vector3.Cross(normalized, Vector3.up) * c5b4223b17339aa0f392e4119b11b6aab.m_hoverPatrolRadius;
		}

		private void c900021177294a4f2bb16d02ddfa548c8(float c2002bb238c228cf502166e05c0d89311)
		{
			Vector3 vector = c1ad78e557f29dbfb5e86c0ac6b553522 - cfc241af7ab51814fc074e767be1a0bb8.m_entity.c4cf00ced2bc60ae908904eb73692869f();
			Vector3 normalized = vector.normalized;
			if (vector.sqrMagnitude < 2.25f)
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
						c107f97718a124443672c38210505dd50 = true;
						return;
					}
				}
			}
			cac316c07251cc0c5b60b3cfbd704822d(c2002bb238c228cf502166e05c0d89311, normalized);
		}

		private void c586b4f4d7845fc8c5df2f1a139334170(float c2002bb238c228cf502166e05c0d89311)
		{
			Vector3 normalized = (cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position - c2227ddc7fcbe3fa329465d2fa8ffb479.c9de49121b6b7cf920b8634d8371514e9).normalized;
			normalized.y = 0f;
			normalized = Quaternion.Euler(0f, 3f, 0f) * normalized;
			Vector3 vector = c2227ddc7fcbe3fa329465d2fa8ffb479.c9de49121b6b7cf920b8634d8371514e9 + normalized * c5b4223b17339aa0f392e4119b11b6aab.m_hoverPatrolRadius;
			Vector3 normalized2 = (vector - cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position).normalized;
			cac316c07251cc0c5b60b3cfbd704822d(c2002bb238c228cf502166e05c0d89311, normalized2);
		}

		private void cac316c07251cc0c5b60b3cfbd704822d(float c2002bb238c228cf502166e05c0d89311, Vector3 c8ce5fe64211495642c11d922565b56f1)
		{
			float num = Vector3.Angle(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, c8ce5fe64211495642c11d922565b56f1);
			float num2 = Mathf.Lerp(1f, 0.1f, num / 180f);
			float num3 = c5b4223b17339aa0f392e4119b11b6aab.m_patrolFlyingSpeed * c2002bb238c228cf502166e05c0d89311 * num2;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position += c8ce5fe64211495642c11d922565b56f1 * num3;
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward = Vector3.Slerp(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.forward, c8ce5fe64211495642c11d922565b56f1, 0.2f);
			Vector3 normalized = (cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position - c2227ddc7fcbe3fa329465d2fa8ffb479.c9de49121b6b7cf920b8634d8371514e9).normalized;
			float num4 = Vector3.Dot(normalized, c8ce5fe64211495642c11d922565b56f1);
			float num5;
			if (num4 > 0f)
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
					switch (6)
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
					switch (3)
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
			c7b12fa9940ed075509ce57469cd836bd.m_turnAngle = Mathf.Lerp(c7b12fa9940ed075509ce57469cd836bd.m_turnAngle, num4, 0.1f);
		}
	}
}
