using A;
using Core;
using UnityEngine;

public class InstanceInput : MonoBehaviour
{
	public int m_incomingLagcy = 2;

	public int m_drainWhenExceed = 3;

	public int m_drain;

	private int m_exceedCount;

	public InputFrame currentInput;

	private PlayerBehavior m_playerBehavior;

	private RingBuffer m_outgoing;

	private RingBuffer m_incoming;

	private EntityPlayer m_player;

	private int m_InputMiss;

	private int m_instanceInputCount;

	private void Awake()
	{
		m_outgoing = new RingBuffer(10, true);
		m_incoming = new RingBuffer(10, true);
	}

	private void Start()
	{
		m_player = GetComponent<EntityPlayer>();
	}

	public int ca68bf8da064f4f5c61555bc50f97f8d4()
	{
		return m_incoming.ca0dc0c335bcd7a0d16510da3a64d1c4f();
	}

	public Vector3 c7461901730f520d365b9e384aa821620()
	{
		float num = 0f;
		float num2 = 0f;
		if (currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Left))
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
			num -= 1f;
		}
		if (currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Right))
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
			num += 1f;
		}
		if (currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Forward))
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
			num2 += 1f;
		}
		if (currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Backward))
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
			num2 -= 1f;
		}
		return new Vector3(num, 0f, num2).normalized;
	}

	public bool cb261500372fa488b369e9159a002977a()
	{
		return currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Run);
	}

	public bool cdc79bb1740f1c70185840b061137dea8()
	{
		int result;
		if (!currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Forward))
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
			if (!currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Backward))
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
				if (!currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Left))
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
					result = (currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Right) ? 1 : 0);
					goto IL_006a;
				}
			}
		}
		result = 1;
		goto IL_006a;
		IL_006a:
		return (byte)result != 0;
	}

	public bool c8cc0ce1bacf416fdd879d1e63947960f()
	{
		return currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Jump);
	}

	public bool c4d927c91307ef767ba359c476291c950()
	{
		return currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Aim);
	}

	public bool c7201a6224668404b44ad10a24fe68d67()
	{
		return currentInput.c2f9647b8222028a80f7d5d8b6e2ac914(InputFrame.Flag.Crouch);
	}

	public float c0124f6c859e33c1d30d93e866a126f3f()
	{
		return currentInput.m_yaw;
	}

	public float c860b20a36d422451f98fcb15cc16813b()
	{
		return currentInput.m_pitch;
	}

	public void c3bff30866b755ede02c1825cdf526fea(InputFrame[] c37e1cf2b46ecb86ace924133d77dee40)
	{
		if (m_incoming.ca0dc0c335bcd7a0d16510da3a64d1c4f() > m_incomingLagcy)
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
			m_exceedCount++;
		}
		else
		{
			m_exceedCount = 0;
		}
		if (m_exceedCount > m_drainWhenExceed)
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
			m_exceedCount = 0;
			c3645a31a754c7fd7e41ebb9e7f91d17f(m_drain);
		}
		for (int i = 0; i < c37e1cf2b46ecb86ace924133d77dee40.Length; i++)
		{
			m_incoming.cd6aca5b3793f791cfc489609e675c90b(c37e1cf2b46ecb86ace924133d77dee40[i]);
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

	public void c0b8c911a7411887fd2c5cdb0d89fc41d(out InputFrame[] c37e1cf2b46ecb86ace924133d77dee40)
	{
		c37e1cf2b46ecb86ace924133d77dee40 = c65f63442bbfa453f3e9f60c2e845dbe7.c0a0cdf4a196914163f7334d9b0781a04(m_outgoing.ca0dc0c335bcd7a0d16510da3a64d1c4f());
		for (int i = 0; i < c37e1cf2b46ecb86ace924133d77dee40.Length; i++)
		{
			c37e1cf2b46ecb86ace924133d77dee40[i] = (InputFrame)m_outgoing.c7605b6a8df360621e4eb06fe0b47814b();
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
			return;
		}
	}

	public void ccf3411e5323c009014d6dd8d3521f827()
	{
		if (!m_player)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!m_player.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
				currentInput = ca82876d67210d7f72bc4e56f05744370();
				m_outgoing.cd6aca5b3793f791cfc489609e675c90b(currentInput);
				return;
			}
		}
	}

	private void FixedUpdate()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
			if (m_outgoing.ca0dc0c335bcd7a0d16510da3a64d1c4f() == m_outgoing.cbb9f1aee8a8e86f5765f179e98139a1e())
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Input, "outgoing buffer overflow");
			}
		}
		if (m_incoming.ca0dc0c335bcd7a0d16510da3a64d1c4f() != 0)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					m_InputMiss = 0;
					currentInput = (InputFrame)m_incoming.c7605b6a8df360621e4eb06fe0b47814b();
					return;
				}
			}
		}
		m_InputMiss++;
	}

	private void c3645a31a754c7fd7e41ebb9e7f91d17f(int cb413b63b20e71ae5c504b03471480e2a)
	{
		int num = m_incoming.ca0dc0c335bcd7a0d16510da3a64d1c4f();
		while (num > cb413b63b20e71ae5c504b03471480e2a)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (num > 1)
				{
					InputFrame inputFrame = (InputFrame)m_incoming.c588e7dbcd383d8230b2d83d7b44af23b(0);
					InputFrame inputFrame2 = (InputFrame)m_incoming.c588e7dbcd383d8230b2d83d7b44af23b(1);
					if (!inputFrame.c6eb32142ff311fc97f545f61349347a7())
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
						if (!inputFrame2.c6eb32142ff311fc97f545f61349347a7())
						{
							return;
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_0064;
							}
							continue;
							end_IL_0064:
							break;
						}
						currentInput = (InputFrame)m_incoming.c7605b6a8df360621e4eb06fe0b47814b();
						num = m_incoming.ca0dc0c335bcd7a0d16510da3a64d1c4f();
						break;
					}
					break;
				}
				while (true)
				{
					switch (4)
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

	private PlayerBehavior c17ec2ef7b478c8c7fcfb60360ea3f7a7()
	{
		if (m_playerBehavior == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerBehavior = GetComponent<PlayerBehavior>();
		}
		return m_playerBehavior;
	}

	private InputFrame ca82876d67210d7f72bc4e56f05744370()
	{
		InputFrame c36964cf41281414170f34ee68bef6c = default(InputFrame);
		c00a9bc5c4cae97aed0a9965a4dbd8fe7.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		PlayerBehavior playerBehavior = c17ec2ef7b478c8c7fcfb60360ea3f7a7();
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Forward, playerBehavior.c951140c92ca71036302f26696e18751f());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Backward, playerBehavior.c29aef5bca56d4364b401e4b0a37de51c());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Left, playerBehavior.ca25425e29e88f33176c1022724eee2bb());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Right, playerBehavior.c91579ebaaadce993ae1215fbdb24ab15());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Jump, playerBehavior.c8cc0ce1bacf416fdd879d1e63947960f());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Run, playerBehavior.cb261500372fa488b369e9159a002977a());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Aim, playerBehavior.c4d927c91307ef767ba359c476291c950());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Crouch, playerBehavior.c7201a6224668404b44ad10a24fe68d67());
		c36964cf41281414170f34ee68bef6c.m_frameNum = m_instanceInputCount;
		m_instanceInputCount++;
		c36964cf41281414170f34ee68bef6c.m_yaw = playerBehavior.c8a422b23a900df0a17ed453471c4e18a();
		c36964cf41281414170f34ee68bef6c.m_pitch = playerBehavior.c9195c80922216a5abb5ecd0564707280();
		return c36964cf41281414170f34ee68bef6c;
	}

	private InputFrame cc457262ea16d126235397af110f4204d()
	{
		InputFrame c36964cf41281414170f34ee68bef6c = default(InputFrame);
		c00a9bc5c4cae97aed0a9965a4dbd8fe7.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		PlayerBehavior playerBehavior = c17ec2ef7b478c8c7fcfb60360ea3f7a7();
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Forward, playerBehavior.c951140c92ca71036302f26696e18751f());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Backward, playerBehavior.c29aef5bca56d4364b401e4b0a37de51c());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Left, playerBehavior.ca25425e29e88f33176c1022724eee2bb());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Right, playerBehavior.c91579ebaaadce993ae1215fbdb24ab15());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Jump, playerBehavior.c8cc0ce1bacf416fdd879d1e63947960f());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Run, playerBehavior.cb261500372fa488b369e9159a002977a());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Aim, playerBehavior.c4d927c91307ef767ba359c476291c950());
		c36964cf41281414170f34ee68bef6c.ca968fc4c885049a5d802d9492edf0261(InputFrame.Flag.Crouch, playerBehavior.c7201a6224668404b44ad10a24fe68d67());
		c36964cf41281414170f34ee68bef6c.m_frameNum = m_instanceInputCount;
		c36964cf41281414170f34ee68bef6c.m_yaw = playerBehavior.c8a422b23a900df0a17ed453471c4e18a();
		c36964cf41281414170f34ee68bef6c.m_pitch = playerBehavior.c9195c80922216a5abb5ecd0564707280();
		return c36964cf41281414170f34ee68bef6c;
	}
}
