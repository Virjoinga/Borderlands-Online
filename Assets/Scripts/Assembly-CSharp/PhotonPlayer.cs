using System.Collections;
using Core;

public class PhotonPlayer
{
	private int actorID = -1;

	private string nameField = string.Empty;

	public readonly bool isLocal;

	public int c29a834d12d3895f5680e69a30e6cd9a3
	{
		get
		{
			return actorID;
		}
	}

	public string cd99af21e22e356018b8f72d4a7e4872a
	{
		get
		{
			return nameField;
		}
		set
		{
			if (!isLocal)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "Error: Cannot change the name of a remote player!");
						return;
					}
				}
			}
			nameField = value;
		}
	}

	public bool ca3052869987fcf5688487de12414faab
	{
		get
		{
			return PhotonNetwork.networkingPeer.mMasterClient == this;
		}
	}

	public Hashtable customProperties { get; private set; }

	public Hashtable c851686ef62470f37b12330382531e202
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.c4870536122cdf9c0c87c4a4301fe4e4d(customProperties);
			hashtable[byte.MaxValue] = cd99af21e22e356018b8f72d4a7e4872a;
			return hashtable;
		}
	}

	public PhotonPlayer(bool c9f86d965ca220e54c03c3844c19b202f, int c1fcca35699f8d2167a0da927444e9283, string cd99af21e22e356018b8f72d4a7e4872a)
	{
		customProperties = new Hashtable();
		isLocal = c9f86d965ca220e54c03c3844c19b202f;
		actorID = c1fcca35699f8d2167a0da927444e9283;
		nameField = cd99af21e22e356018b8f72d4a7e4872a;
	}

	protected internal PhotonPlayer(bool c9f86d965ca220e54c03c3844c19b202f, int c1fcca35699f8d2167a0da927444e9283, Hashtable cc79e01f9e3ac59fac4e1629a832b9edb)
	{
		customProperties = new Hashtable();
		isLocal = c9f86d965ca220e54c03c3844c19b202f;
		actorID = c1fcca35699f8d2167a0da927444e9283;
		cb0dbb1e66069845b8379c37136865ca4(cc79e01f9e3ac59fac4e1629a832b9edb);
	}

	internal void cb0dbb1e66069845b8379c37136865ca4(Hashtable cc79e01f9e3ac59fac4e1629a832b9edb)
	{
		if (cc79e01f9e3ac59fac4e1629a832b9edb == null)
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
			if (cc79e01f9e3ac59fac4e1629a832b9edb.Count == 0)
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
				if (customProperties.Equals(cc79e01f9e3ac59fac4e1629a832b9edb))
				{
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
				if (cc79e01f9e3ac59fac4e1629a832b9edb.ContainsKey(byte.MaxValue))
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
					nameField = (string)cc79e01f9e3ac59fac4e1629a832b9edb[byte.MaxValue];
				}
				customProperties.cf7c1c7a7b045d5d6df74fc02c9a94917(cc79e01f9e3ac59fac4e1629a832b9edb);
				customProperties.c028f18d8b9153b0aa6726dae9f6cd04f();
				return;
			}
		}
	}

	public override string ToString()
	{
		string empty;
		if (cd99af21e22e356018b8f72d4a7e4872a == null)
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
			empty = string.Empty;
		}
		else
		{
			empty = cd99af21e22e356018b8f72d4a7e4872a;
		}
		return empty;
	}

	public override bool Equals(object p)
	{
		PhotonPlayer photonPlayer = p as PhotonPlayer;
		int result;
		if (photonPlayer != null)
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
			result = ((GetHashCode() == photonPlayer.GetHashCode()) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override int GetHashCode()
	{
		return c29a834d12d3895f5680e69a30e6cd9a3;
	}

	internal void c1f4bf1012509b3cca22015d985496450(int c0bd3dfeaeba2e4f0683e462008a4d725)
	{
		if (!isLocal)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "ERROR You should never change PhotonPlayer IDs!");
					return;
				}
			}
		}
		actorID = c0bd3dfeaeba2e4f0683e462008a4d725;
	}

	public void ccd6fde3cd72529d9bc2523ed219b2bd4(Hashtable c1c0125b5723e3afb19231248c2121312)
	{
		if (c1c0125b5723e3afb19231248c2121312 == null)
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
		customProperties.cf7c1c7a7b045d5d6df74fc02c9a94917(c1c0125b5723e3afb19231248c2121312);
		customProperties.c028f18d8b9153b0aa6726dae9f6cd04f();
		Hashtable c3aa9fea8c8f603f879dba8953ea14aa = c1c0125b5723e3afb19231248c2121312.c63ac2d1d584ae86a3fc3c43c687fc6b2();
		PhotonNetwork.networkingPeer.c04cf590d114055d0bfdb8b0ac0ff5871(actorID, c3aa9fea8c8f603f879dba8953ea14aa, true, 0);
	}

	public static PhotonPlayer cc896fd68f9e2e6f38fa11555857a60c8(int c29a834d12d3895f5680e69a30e6cd9a3)
	{
		PhotonPlayer[] cfac6072a14e502241f3c58a1c87edcfd = PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd;
		foreach (PhotonPlayer photonPlayer in cfac6072a14e502241f3c58a1c87edcfd)
		{
			if (photonPlayer.c29a834d12d3895f5680e69a30e6cd9a3 != c29a834d12d3895f5680e69a30e6cd9a3)
			{
				continue;
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
				return photonPlayer;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return null;
		}
	}
}
