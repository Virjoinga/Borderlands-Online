using A;
using BHV;
using UnityEngine;

public class InterpolateManager
{
	private MovementSync m_movement;

	private RingBuffer m_timePosBuffer;

	private object m_from;

	private object m_to;

	private object m_current;

	private TimePos m_currentTP;

	private double m_currentTPTime;

	public Vector3 m_velocity;

	private float m_angleVelocity;

	private float m_straightAcceleration;

	private float m_angleAcceleration;

	private float m_actualInterpolateTime;

	public float m_recvInterval;

	private BHVTaskManager m_BHVTaskManager;

	private int catchupThreshold = 5;

	private int catchupCount;

	public InterpolateManager(MovementSync c0ba9b4031683c03ac050dcc21ebfa0db, BHVTaskManager ca5b034208c375e9f8bdb80a8043302e1 = null)
	{
		m_timePosBuffer = new RingBuffer(300, true);
		m_BHVTaskManager = ca5b034208c375e9f8bdb80a8043302e1;
		m_movement = c0ba9b4031683c03ac050dcc21ebfa0db;
	}

	private TimePos cfee6878708f67e48605c3d99e6c22f92()
	{
		return m_timePosBuffer.cef0e77f01549f5bca5df565d45cc1a90() as TimePos;
	}

	private TimePos cfed73bbbe74ae01f7409735f3bfb1a16()
	{
		return m_timePosBuffer.c8a833251dc49a102f7b1cb1c222bc04e() as TimePos;
	}

	public static float c626781f3af95678da9e24a0af671368d()
	{
		return NetworkManager.c474909384fe546f5cce7ffaeb4d12273() * 2f;
	}

	private float c3359474bdd43da30e49b3a4b851dde8c()
	{
		return Time.deltaTime / c626781f3af95678da9e24a0af671368d();
	}

	public void c93dfb7ce3d15c238cd4b633889858ffb(BHVTaskManager c9f936100770508e8acd275ff7c1d6641)
	{
		m_BHVTaskManager = c9f936100770508e8acd275ff7c1d6641;
	}

	public void OnNewTPArrived(TimePos tp)
	{
		m_timePosBuffer.cd6aca5b3793f791cfc489609e675c90b(tp);
		TimePos timePos = m_timePosBuffer.cef0e77f01549f5bca5df565d45cc1a90() as TimePos;
		if (m_timePosBuffer.c8a833251dc49a102f7b1cb1c222bc04e() == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			TimePos timePos2 = m_timePosBuffer.c8a833251dc49a102f7b1cb1c222bc04e() as TimePos;
			float num = (float)(timePos.m_networkTimeStamp - timePos2.m_networkTimeStamp);
			Vector3 velocity = (timePos.m_position - timePos2.m_position) / num;
			m_straightAcceleration = (velocity.magnitude - m_velocity.magnitude) / 2f * num;
			m_velocity = velocity;
			float num2 = timePos.m_rotation.eulerAngles.y - timePos2.m_rotation.eulerAngles.y;
			if (num2 > 180f)
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
				num2 = 360f - num2;
			}
			if (num2 < -180f)
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
				num2 = -360f + num2;
			}
			num2 /= num;
			m_angleAcceleration = (num2 - m_angleVelocity) / 2f * num;
			m_angleVelocity = num2;
			m_recvInterval = Mathf.Lerp(m_recvInterval, num, 0.3f);
			Debug.cd311b36270223e532813522a1f24cc90(timePos2.m_position, m_velocity);
			return;
		}
	}

	public float c301abaf24d40e2b3ae13b805bee85325()
	{
		if (m_movement.lastEvaluatedPriority <= 66)
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return c626781f3af95678da9e24a0af671368d();
					}
				}
			}
		}
		return 2f * m_recvInterval;
	}

	public bool ca4fc83532a6c52f344916ec7e089bf68(ref Vector3 c1ee6942d87425aaba61e92e238828f3b, ref Quaternion cd5176331b6ee3998bc728ffe1f99f831)
	{
		bool result = true;
		TimePos timePos = m_timePosBuffer.cef0e77f01549f5bca5df565d45cc1a90() as TimePos;
		double num;
		bool flag;
		if (timePos != null)
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
			if (m_currentTP == null)
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
				m_currentTP = new TimePos(Time.time, c1ee6942d87425aaba61e92e238828f3b, cd5176331b6ee3998bc728ffe1f99f831, timePos.m_networkTimeStamp - (double)c626781f3af95678da9e24a0af671368d(), 0);
				m_currentTPTime = Time.time;
				if (!c85e4aba6d728bf44d008cd016d298402(m_timePosBuffer, ref m_currentTP))
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
					m_currentTP.m_position = timePos.m_position;
					m_currentTP.m_rotation = timePos.m_rotation;
				}
				result = true;
				goto IL_0469;
			}
			num = (double)Time.time - m_currentTPTime + m_currentTP.m_networkTimeStamp;
			m_actualInterpolateTime = (float)((double)Time.time - timePos.m_time + timePos.m_networkTimeStamp - num);
			float num2 = m_actualInterpolateTime - c301abaf24d40e2b3ae13b805bee85325();
			if ((double)Mathf.Abs(num2) > 0.016)
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
				catchupCount++;
			}
			else
			{
				catchupCount = 0;
			}
			if (catchupCount >= catchupThreshold)
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
				num += (double)num2;
				if (num < m_currentTP.m_networkTimeStamp)
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
					num = m_currentTP.m_networkTimeStamp;
				}
				if (num > timePos.m_networkTimeStamp)
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
					num = timePos.m_networkTimeStamp - (double)c301abaf24d40e2b3ae13b805bee85325();
				}
			}
			flag = false;
			if (m_BHVTaskManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_BHVTaskManager.c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY) != null)
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
					flag = m_BHVTaskManager.c3fceb6126c0a4863b41f07601abc0456();
					if (!flag)
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
						c29e851d0be00ad18cb6ae70fffb7aab6();
					}
					goto IL_0233;
				}
			}
			flag = num - timePos.m_networkTimeStamp < (double)m_recvInterval;
			goto IL_0233;
		}
		goto IL_049d;
		IL_0233:
		if (num > timePos.m_networkTimeStamp)
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
			if (flag)
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
				float num3 = (m_angleVelocity + m_angleAcceleration * (float)(num - m_currentTP.m_networkTimeStamp)) * (float)(num - m_currentTP.m_networkTimeStamp);
				Quaternion quaternion = Quaternion.identity;
				if (!num3.ce5aad699df330ff708587e4fabea8cbb(0f, 0.0001f))
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
					quaternion = Quaternion.Euler(0f, num3, 0f);
				}
				m_velocity = m_velocity.normalized * (m_velocity.magnitude + m_straightAcceleration * (float)(num - m_currentTP.m_networkTimeStamp));
				Vector3 position = m_currentTP.m_position;
				Vector3 vector = m_velocity * (float)(num - m_currentTP.m_networkTimeStamp);
				Ray ray = new Ray(m_currentTP.m_position, vector);
				RaycastHit hitInfo;
				if (Physics.Raycast(ray, out hitInfo, vector.magnitude, TargetingService.c766b2ad3bfeb136864b1696e7dda3d4c))
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
					position = m_currentTP.m_position + (hitInfo.point - m_currentTP.m_position) * 0.5f;
				}
				else
				{
					position = m_currentTP.m_position + vector;
				}
				m_currentTP = new TimePos(Time.time, position, m_currentTP.m_rotation * quaternion, num, 0);
				m_currentTPTime = Time.time;
				m_timePosBuffer.cd6aca5b3793f791cfc489609e675c90b(m_currentTP);
				result = false;
			}
		}
		else
		{
			m_currentTP = new TimePos(Time.time, c1ee6942d87425aaba61e92e238828f3b, cd5176331b6ee3998bc728ffe1f99f831, num, 0);
			m_currentTPTime = Time.time;
			if (c85e4aba6d728bf44d008cd016d298402(m_timePosBuffer, ref m_currentTP))
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
			}
			result = true;
		}
		goto IL_0469;
		IL_0469:
		if (m_currentTP != null)
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
			c1ee6942d87425aaba61e92e238828f3b = m_currentTP.m_position;
			cd5176331b6ee3998bc728ffe1f99f831 = m_currentTP.m_rotation;
		}
		goto IL_049d;
		IL_049d:
		return result;
	}

	private void c29e851d0be00ad18cb6ae70fffb7aab6()
	{
		m_velocity = Vector3.zero;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_timePosBuffer.cac7688b05e921e2be3f92479ba44b4a8();
		c29e851d0be00ad18cb6ae70fffb7aab6();
		m_currentTP = ccce271d6a1498f3fd505c1bacbc33a92.c7088de59e49f7108f520cf7e0bae167e;
	}

	private bool c85e4aba6d728bf44d008cd016d298402(RingBuffer c41ec38993d2186bd5a591d7f4358f6e4, ref TimePos cbf4cd97b0f58f053f664085b1b089723)
	{
		bool flag = false;
		Vector3 position = cbf4cd97b0f58f053f664085b1b089723.m_position;
		Quaternion rotation = cbf4cd97b0f58f053f664085b1b089723.m_rotation;
		int num = c41ec38993d2186bd5a591d7f4358f6e4.ca0dc0c335bcd7a0d16510da3a64d1c4f();
		while (true)
		{
			if (num >= 2)
			{
				TimePos timePos = (TimePos)c41ec38993d2186bd5a591d7f4358f6e4.c588e7dbcd383d8230b2d83d7b44af23b(num - 1);
				TimePos timePos2 = (TimePos)c41ec38993d2186bd5a591d7f4358f6e4.c588e7dbcd383d8230b2d83d7b44af23b(num - 2);
				if (timePos != null)
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
					if (timePos2 != null)
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
						if (Mathf.Abs((float)(timePos.m_networkTimeStamp - cbf4cd97b0f58f053f664085b1b089723.m_networkTimeStamp)) < 0.001f)
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
							position = timePos.m_position;
							rotation = timePos.m_rotation;
							flag = true;
							break;
						}
						if (timePos.m_networkTimeStamp > cbf4cd97b0f58f053f664085b1b089723.m_networkTimeStamp)
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
							if (timePos2.m_networkTimeStamp < cbf4cd97b0f58f053f664085b1b089723.m_networkTimeStamp)
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
								position = Vector3.Lerp(timePos2.m_position, timePos.m_position, (float)((cbf4cd97b0f58f053f664085b1b089723.m_networkTimeStamp - timePos2.m_networkTimeStamp) / (timePos.m_networkTimeStamp - timePos2.m_networkTimeStamp)));
								rotation = Quaternion.Lerp(timePos2.m_rotation, timePos.m_rotation, (float)((cbf4cd97b0f58f053f664085b1b089723.m_networkTimeStamp - timePos2.m_networkTimeStamp) / (timePos.m_networkTimeStamp - timePos2.m_networkTimeStamp)));
								flag = true;
								break;
							}
						}
					}
				}
				num--;
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
			break;
		}
		if (flag)
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
			cbf4cd97b0f58f053f664085b1b089723.m_position = position;
			cbf4cd97b0f58f053f664085b1b089723.m_rotation = rotation;
		}
		return flag;
	}

	public Vector3 cf2401d2b4bbb3c183866f9133a022812(Vector3 cae5fea398599f41bfafc9b6bb6f4559b, Vector3 c6cb66aa8544c442eb14b92180640f843)
	{
		if (Utils.cf2dc852cbf0274577dab9b8d1236b7a7(m_current, c6cb66aa8544c442eb14b92180640f843))
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
					return (Vector3)m_current;
				}
			}
		}
		if (!Utils.cf2dc852cbf0274577dab9b8d1236b7a7(c6cb66aa8544c442eb14b92180640f843, m_to))
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
			m_to = c6cb66aa8544c442eb14b92180640f843;
			m_from = cae5fea398599f41bfafc9b6bb6f4559b;
			m_current = m_from;
		}
		float t = c3359474bdd43da30e49b3a4b851dde8c();
		m_current = Vector3.Lerp((Vector3)m_current, (Vector3)m_to, t);
		return (Vector3)m_current;
	}

	public Quaternion cf2401d2b4bbb3c183866f9133a022812(Quaternion cae5fea398599f41bfafc9b6bb6f4559b, Quaternion c6cb66aa8544c442eb14b92180640f843)
	{
		if (Utils.cf2dc852cbf0274577dab9b8d1236b7a7(m_current, c6cb66aa8544c442eb14b92180640f843))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return (Quaternion)m_current;
				}
			}
		}
		if (!Utils.cf2dc852cbf0274577dab9b8d1236b7a7(c6cb66aa8544c442eb14b92180640f843, m_to))
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
			m_to = c6cb66aa8544c442eb14b92180640f843;
			m_from = cae5fea398599f41bfafc9b6bb6f4559b;
			m_current = m_from;
		}
		float t = c3359474bdd43da30e49b3a4b851dde8c();
		m_current = Quaternion.Lerp((Quaternion)m_current, (Quaternion)m_to, t);
		return (Quaternion)m_current;
	}

	public float cf2401d2b4bbb3c183866f9133a022812(float cae5fea398599f41bfafc9b6bb6f4559b, float c6cb66aa8544c442eb14b92180640f843)
	{
		if (Utils.cf2dc852cbf0274577dab9b8d1236b7a7(m_current, c6cb66aa8544c442eb14b92180640f843))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return (float)m_current;
				}
			}
		}
		if (!Utils.cf2dc852cbf0274577dab9b8d1236b7a7(c6cb66aa8544c442eb14b92180640f843, m_to))
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
			m_to = c6cb66aa8544c442eb14b92180640f843;
			m_from = cae5fea398599f41bfafc9b6bb6f4559b;
			m_current = m_from;
		}
		float t = c3359474bdd43da30e49b3a4b851dde8c();
		m_current = Mathf.Lerp((float)m_current, (float)m_to, t);
		return (float)m_current;
	}
}
