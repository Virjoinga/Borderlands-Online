using System.Collections;
using System.Collections.Generic;
using A;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;

internal class LoadbalancingPeer : PhotonPeer
{
	public LoadbalancingPeer(IPhotonPeerListener c472a3b7c9dbd0d177f87c4386db7570d, ConnectionProtocol c1b594372809645325383c6d396811aaa)
		: base(c472a3b7c9dbd0d177f87c4386db7570d, c1b594372809645325383c6d396811aaa)
	{
	}

	public virtual bool ccc5b4825f60778430d18dd8b6dc97037()
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinLobby()");
		}
		return OpCustom(229, null, true);
	}

	public virtual bool c689fd14acfdd59d1c35c12073c69a1ec()
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpLeaveLobby()");
		}
		return OpCustom(228, null, true);
	}

	public virtual bool c01fd1557d36bde4a054dbe40540eaaea(string c1f7c2fc950f696c563315e5f82d048ef, bool cb4040e85ef24e4c9dea5dfc714598840, bool c5168d3b88f2be16369b322f43806da6a, byte c0b46a01b8c5164654f47e46e1eeb023d, bool c67310dbe99bce4fde88aae0e8960d168, Hashtable c4e3a4419df98fc37d124b71bf492078b, Hashtable cdce12ac344ef2508a2f46c56f9d0b896, string[] c5ed92a08373191ba0fc23435d283a9e1)
	{
		if ((int)base.DebugOut >= 3)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.Listener.DebugReturn(DebugLevel.INFO, "OpCreateRoom()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)253] = c5168d3b88f2be16369b322f43806da6a;
		hashtable[(byte)254] = cb4040e85ef24e4c9dea5dfc714598840;
		hashtable[(byte)250] = c5ed92a08373191ba0fc23435d283a9e1;
		hashtable.cf7c1c7a7b045d5d6df74fc02c9a94917(c4e3a4419df98fc37d124b71bf492078b);
		if (c0b46a01b8c5164654f47e46e1eeb023d > 0)
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
			hashtable[byte.MaxValue] = c0b46a01b8c5164654f47e46e1eeb023d;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[248] = hashtable;
		dictionary[249] = cdce12ac344ef2508a2f46c56f9d0b896;
		dictionary[250] = true;
		if (!string.IsNullOrEmpty(c1f7c2fc950f696c563315e5f82d048ef))
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
			dictionary[byte.MaxValue] = c1f7c2fc950f696c563315e5f82d048ef;
		}
		if (c67310dbe99bce4fde88aae0e8960d168)
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
			dictionary[241] = c67310dbe99bce4fde88aae0e8960d168;
			hashtable[(byte)249] = c67310dbe99bce4fde88aae0e8960d168;
		}
		return OpCustom(227, dictionary, true);
	}

	public bool cae1b51ba9a6af8beb635eb3abce8405c(Hashtable c251ab956c5ff437437510daf6056c40d, Hashtable c9726b082c7f24a6c14abce021a367140, int cbd27e27b8828e4abd80513cb973357c9 = 50)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[237] = c251ab956c5ff437437510daf6056c40d;
		dictionary[236] = c9726b082c7f24a6c14abce021a367140;
		dictionary[235] = cbd27e27b8828e4abd80513cb973357c9;
		return OpCustom(221, dictionary, true);
	}

	public virtual bool c4a277d4f554bad523114dd245412c8e9(string c37dc4ee4a3a694110f0e0eb7b086137a, Hashtable c8c2e47dcaa928f76d9c8c2a8d9da77eb, Hashtable c409129e403832642d20f53a4226efd28)
	{
		if ((int)base.DebugOut >= 3)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[byte.MaxValue] = c37dc4ee4a3a694110f0e0eb7b086137a;
		dictionary[250] = true;
		if (c8c2e47dcaa928f76d9c8c2a8d9da77eb != null)
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
			dictionary[249] = c8c2e47dcaa928f76d9c8c2a8d9da77eb;
		}
		if (c409129e403832642d20f53a4226efd28 != null)
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
			dictionary[248] = c409129e403832642d20f53a4226efd28;
		}
		return OpCustom(226, dictionary, true);
	}

	public virtual bool c6715dd5fbd319c6fb14b86148a6be9fe(Hashtable cc216f23dc2f7b783e32208e7241b9544, byte c8dc74ab19c3c6f5ead0a1fc2cc03de95, Hashtable c8c2e47dcaa928f76d9c8c2a8d9da77eb, MatchmakingMode ccd174d743f15030d5636ccf8809f60a5)
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandomRoom()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable.cf7c1c7a7b045d5d6df74fc02c9a94917(cc216f23dc2f7b783e32208e7241b9544);
		if (c8dc74ab19c3c6f5ead0a1fc2cc03de95 > 0)
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
			hashtable[byte.MaxValue] = c8dc74ab19c3c6f5ead0a1fc2cc03de95;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (hashtable.Count > 0)
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
			dictionary[248] = hashtable;
		}
		if (c8c2e47dcaa928f76d9c8c2a8d9da77eb != null)
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
			if (c8c2e47dcaa928f76d9c8c2a8d9da77eb.Count > 0)
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
				dictionary[249] = c8c2e47dcaa928f76d9c8c2a8d9da77eb;
			}
		}
		if (ccd174d743f15030d5636ccf8809f60a5 != 0)
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
			dictionary[223] = (byte)ccd174d743f15030d5636ccf8809f60a5;
		}
		return OpCustom(225, dictionary, true);
	}

	public bool c2935569ee141e8f27fd790d08feaa41b(string cfbe80bfe797338ac909b03da7a69ef08)
	{
		PhotonNetwork.networkingPeer.mRoomToGetInto = new Room(null, cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e);
		return OpCustom(198, new Dictionary<byte, object> { { 0, cfbe80bfe797338ac909b03da7a69ef08 } }, true);
	}

	public bool c64252907630eb3dbcc25305b98437731(string cfbe80bfe797338ac909b03da7a69ef08)
	{
		PhotonNetwork.networkingPeer.mRoomToGetInto = new Room(null, cc4f48f0020e93b4626fa4d1a4676550a.c7088de59e49f7108f520cf7e0bae167e);
		return OpCustom(197, new Dictionary<byte, object> { { 0, cfbe80bfe797338ac909b03da7a69ef08 } }, true);
	}

	public bool c04cf590d114055d0bfdb8b0ac0ff5871(int c69f92abf82891a726d320565a4b46747, Hashtable c3aa9fea8c8f603f879dba8953ea14aa9, bool c046f81605d5aacb6375ca5e9ced6b5fd, byte c38308765846f10101d4b827067dd8f83)
	{
		return c3a0951743c01f7942b6400256e038385(c69f92abf82891a726d320565a4b46747, c3aa9fea8c8f603f879dba8953ea14aa9.c63ac2d1d584ae86a3fc3c43c687fc6b2(), c046f81605d5aacb6375ca5e9ced6b5fd, c38308765846f10101d4b827067dd8f83);
	}

	protected virtual bool c3a0951743c01f7942b6400256e038385(int c69f92abf82891a726d320565a4b46747, Hashtable c3aa9fea8c8f603f879dba8953ea14aa9, bool c046f81605d5aacb6375ca5e9ced6b5fd, byte c38308765846f10101d4b827067dd8f83)
	{
		if ((int)base.DebugOut >= 3)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, c3aa9fea8c8f603f879dba8953ea14aa9);
		dictionary.Add(254, c69f92abf82891a726d320565a4b46747);
		if (c046f81605d5aacb6375ca5e9ced6b5fd)
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
			dictionary.Add(250, c046f81605d5aacb6375ca5e9ced6b5fd);
		}
		return OpCustom(252, dictionary, c046f81605d5aacb6375ca5e9ced6b5fd, c38308765846f10101d4b827067dd8f83);
	}

	protected void cd0b16ae2d3ea4f3a04f3c695ac9feae2(byte c101535fe890f3b4dad982539eca895fa, object cefda2fdc3ce4e04f38bab77fc7998241)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[c101535fe890f3b4dad982539eca895fa] = cefda2fdc3ce4e04f38bab77fc7998241;
		c9c0b2e8af95df448eba53aabb19dcc0d(hashtable, true, 0);
	}

	public bool c2dba32ff655cbf794605cb992f075477(Hashtable c409129e403832642d20f53a4226efd28, bool c046f81605d5aacb6375ca5e9ced6b5fd, byte c38308765846f10101d4b827067dd8f83)
	{
		return c9c0b2e8af95df448eba53aabb19dcc0d(c409129e403832642d20f53a4226efd28.c63ac2d1d584ae86a3fc3c43c687fc6b2(), c046f81605d5aacb6375ca5e9ced6b5fd, c38308765846f10101d4b827067dd8f83);
	}

	public virtual bool c9c0b2e8af95df448eba53aabb19dcc0d(Hashtable c409129e403832642d20f53a4226efd28, bool c046f81605d5aacb6375ca5e9ced6b5fd, byte c38308765846f10101d4b827067dd8f83)
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfRoom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, c409129e403832642d20f53a4226efd28);
		if (c046f81605d5aacb6375ca5e9ced6b5fd)
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
			dictionary.Add(250, c046f81605d5aacb6375ca5e9ced6b5fd);
		}
		return OpCustom(252, dictionary, c046f81605d5aacb6375ca5e9ced6b5fd, c38308765846f10101d4b827067dd8f83);
	}

	public virtual bool c6f33dc92a2ac4dceb4bc67bd73340658(string c0f2c35402a8abd489481ccc7869a969c, string c6c1b51e64722c3393756046248a04833, string c4c413a97799e43eb07112adf9641c30e, string cb292fbb0d136ed940c5827add605879c)
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = c6c1b51e64722c3393756046248a04833;
		dictionary[224] = c0f2c35402a8abd489481ccc7869a969c;
		dictionary[104] = c4c413a97799e43eb07112adf9641c30e;
		dictionary[109] = cb292fbb0d136ed940c5827add605879c;
		dictionary[105] = (byte)1;
		return OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	public virtual bool cef1172883a0398e2b7732b3c47c7ce2b(byte[] c908877424278e67b8777768f58b51b37, byte[] c439c34a0599f27e1c487623d2bdf47e9)
	{
		if ((int)base.DebugOut >= 5)
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
			base.Listener.DebugReturn(DebugLevel.ALL, "OpChangeGroups()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (c908877424278e67b8777768f58b51b37 != null)
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
			dictionary[239] = c908877424278e67b8777768f58b51b37;
		}
		if (c439c34a0599f27e1c487623d2bdf47e9 != null)
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
			dictionary[238] = c439c34a0599f27e1c487623d2bdf47e9;
		}
		return OpCustom(248, dictionary, true, 0);
	}

	public virtual bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, byte cf3bbbff54c9fdae94b8cb8bfd3e5d14d, Hashtable c65b1f3d23c2ccefeb3722f1c39977e94, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = c65b1f3d23c2ccefeb3722f1c39977e94;
		dictionary[244] = cdf46071c2725c9ab47a01b833f484416;
		if (cf3bbbff54c9fdae94b8cb8bfd3e5d14d != 0)
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
			dictionary[240] = cf3bbbff54c9fdae94b8cb8bfd3e5d14d;
		}
		return OpCustom(253, dictionary, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83);
	}

	public virtual bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83)
	{
		return c3f632fdd31c8a3f2463924fbc1ced8b4(cdf46071c2725c9ab47a01b833f484416, c98406db696ab6ddbd25ee108c3e91e6a, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83, EventCaching.DoNotCache, ReceiverGroup.Others);
	}

	public virtual bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83, int[] c566ca11545011ee633a4806eae49c18d)
	{
		return c3f632fdd31c8a3f2463924fbc1ced8b4(cdf46071c2725c9ab47a01b833f484416, c98406db696ab6ddbd25ee108c3e91e6a, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83, c566ca11545011ee633a4806eae49c18d, EventCaching.DoNotCache);
	}

	public virtual bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83, int[] c566ca11545011ee633a4806eae49c18d, EventCaching c67915f2da62d83244da1e904f44dcc85)
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = c98406db696ab6ddbd25ee108c3e91e6a;
		dictionary[244] = cdf46071c2725c9ab47a01b833f484416;
		if (c67915f2da62d83244da1e904f44dcc85 != 0)
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
			dictionary[247] = (byte)c67915f2da62d83244da1e904f44dcc85;
		}
		if (c566ca11545011ee633a4806eae49c18d != null)
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
			dictionary[252] = c566ca11545011ee633a4806eae49c18d;
		}
		return OpCustom(253, dictionary, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83);
	}

	public virtual bool c3f632fdd31c8a3f2463924fbc1ced8b4(byte cdf46071c2725c9ab47a01b833f484416, Hashtable c98406db696ab6ddbd25ee108c3e91e6a, bool cfbe3ee1dffa93a05979d9d9ee4ef07d4, byte c38308765846f10101d4b827067dd8f83, EventCaching c67915f2da62d83244da1e904f44dcc85, ReceiverGroup c07ee15f749989c77886061e981f42097)
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = c98406db696ab6ddbd25ee108c3e91e6a;
		dictionary[244] = cdf46071c2725c9ab47a01b833f484416;
		if (c07ee15f749989c77886061e981f42097 != 0)
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
			dictionary[246] = (byte)c07ee15f749989c77886061e981f42097;
		}
		if (c67915f2da62d83244da1e904f44dcc85 != 0)
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
			dictionary[247] = (byte)c67915f2da62d83244da1e904f44dcc85;
		}
		return OpCustom(253, dictionary, cfbe3ee1dffa93a05979d9d9ee4ef07d4, c38308765846f10101d4b827067dd8f83);
	}
}
