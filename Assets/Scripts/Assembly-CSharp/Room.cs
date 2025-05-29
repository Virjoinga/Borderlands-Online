using System.Collections;
using A;
using Core;
using ExitGames.Client.Photon;

public class Room : RoomInfo
{
	public int c385f1799395a60cf9a11a6eeaf29ee99
	{
		get
		{
			if (PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd != null)
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
						return PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd.Length;
					}
				}
			}
			return 0;
		}
	}

	public new string cd99af21e22e356018b8f72d4a7e4872a
	{
		get
		{
			return nameField;
		}
		internal set
		{
			nameField = value;
		}
	}

	public new int c0b46a01b8c5164654f47e46e1eeb023d
	{
		get
		{
			return maxPlayersField;
		}
		set
		{
			if (!Equals(PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0))
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
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value > 255)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: room.maxPlayers called with value " + value + ". This has been reverted to the max of 255 players, because internally a 'byte' is used.");
				value = 255;
			}
			if (value != maxPlayersField)
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
				if (!PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					PhotonNetwork.networkingPeer.c9c0b2e8af95df448eba53aabb19dcc0d(new Hashtable { 
					{
						byte.MaxValue,
						(byte)value
					} }, true, 0);
				}
			}
			maxPlayersField = (byte)value;
		}
	}

	public new bool c03aa7b834eddec9c2cc57f448c34caff
	{
		get
		{
			return openField;
		}
		set
		{
			if (!Equals(PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0))
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
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value != openField)
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
				if (!PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					PhotonNetwork.networkingPeer.c9c0b2e8af95df448eba53aabb19dcc0d(new Hashtable { 
					{
						(byte)253,
						value
					} }, true, 0);
				}
			}
			openField = value;
		}
	}

	public new bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			return visibleField;
		}
		set
		{
			if (!Equals(PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0))
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
				PhotonNetwork.networkingPeer.DebugReturn(DebugLevel.WARNING, "Can't set room properties when not in that room.");
			}
			if (value != visibleField)
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
				if (!PhotonNetwork.cb738f1c8fa2a9da52b69537c9ef77993)
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
					PhotonNetwork.networkingPeer.c9c0b2e8af95df448eba53aabb19dcc0d(new Hashtable { 
					{
						(byte)254,
						value
					} }, true, 0);
				}
			}
			visibleField = value;
		}
	}

	public string[] propertiesListedInLobby { get; private set; }

	public bool c67310dbe99bce4fde88aae0e8960d168
	{
		get
		{
			return autoCleanUpField;
		}
	}

	internal Room(string c37dc4ee4a3a694110f0e0eb7b086137a, Hashtable cc79e01f9e3ac59fac4e1629a832b9edb)
		: base(c37dc4ee4a3a694110f0e0eb7b086137a, cc79e01f9e3ac59fac4e1629a832b9edb)
	{
		propertiesListedInLobby = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);
	}

	internal Room(string c37dc4ee4a3a694110f0e0eb7b086137a, Hashtable cc79e01f9e3ac59fac4e1629a832b9edb, bool cb4040e85ef24e4c9dea5dfc714598840, bool c5168d3b88f2be16369b322f43806da6a, int c0b46a01b8c5164654f47e46e1eeb023d, bool c67310dbe99bce4fde88aae0e8960d168, string[] c1b09a32c25c3773378bddebf5c74b063)
		: base(c37dc4ee4a3a694110f0e0eb7b086137a, cc79e01f9e3ac59fac4e1629a832b9edb)
	{
		visibleField = cb4040e85ef24e4c9dea5dfc714598840;
		openField = c5168d3b88f2be16369b322f43806da6a;
		autoCleanUpField = c67310dbe99bce4fde88aae0e8960d168;
		if (c0b46a01b8c5164654f47e46e1eeb023d > 255)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: Room() called with " + c0b46a01b8c5164654f47e46e1eeb023d + " maxplayers. This has been reverted to the max of 255 players, because internally a 'byte' is used.");
			c0b46a01b8c5164654f47e46e1eeb023d = 255;
		}
		maxPlayersField = (byte)c0b46a01b8c5164654f47e46e1eeb023d;
		if (c1b09a32c25c3773378bddebf5c74b063 != null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					propertiesListedInLobby = c1b09a32c25c3773378bddebf5c74b063;
					return;
				}
			}
		}
		propertiesListedInLobby = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);
	}

	public void ccd6fde3cd72529d9bc2523ed219b2bd4(Hashtable c1c0125b5723e3afb19231248c2121312)
	{
		if (c1c0125b5723e3afb19231248c2121312 == null)
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
					return;
				}
			}
		}
		base.ce640f5adbb33c511c28e1250d8608dd4.cf7c1c7a7b045d5d6df74fc02c9a94917(c1c0125b5723e3afb19231248c2121312);
		base.ce640f5adbb33c511c28e1250d8608dd4.c028f18d8b9153b0aa6726dae9f6cd04f();
		Hashtable c409129e403832642d20f53a4226efd = c1c0125b5723e3afb19231248c2121312.c63ac2d1d584ae86a3fc3c43c687fc6b2();
		PhotonNetwork.networkingPeer.c2dba32ff655cbf794605cb992f075477(c409129e403832642d20f53a4226efd, true, 0);
	}
}
