using System.Collections;
using A;
using ExitGames.Client.Photon;

public class RoomInfo
{
	private Hashtable customPropertiesField = new Hashtable();

	protected byte maxPlayersField;

	protected bool openField = true;

	protected bool visibleField = true;

	protected bool autoCleanUpField;

	protected string nameField;

	public bool removedFromList { get; internal set; }

	public Hashtable ce640f5adbb33c511c28e1250d8608dd4
	{
		get
		{
			return customPropertiesField;
		}
	}

	public string cd99af21e22e356018b8f72d4a7e4872a
	{
		get
		{
			return nameField;
		}
	}

	public int playerCount { get; private set; }

	public bool isLocalClientInside { get; set; }

	public byte c0b46a01b8c5164654f47e46e1eeb023d
	{
		get
		{
			return maxPlayersField;
		}
	}

	public bool c03aa7b834eddec9c2cc57f448c34caff
	{
		get
		{
			return openField;
		}
	}

	public bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			return visibleField;
		}
	}

	protected internal RoomInfo(string c37dc4ee4a3a694110f0e0eb7b086137a, Hashtable cc79e01f9e3ac59fac4e1629a832b9edb)
	{
		cd044c9cb28b3007bfdd98781f1a72634(cc79e01f9e3ac59fac4e1629a832b9edb);
		nameField = c37dc4ee4a3a694110f0e0eb7b086137a;
	}

	public override bool Equals(object p)
	{
		Room room = p as Room;
		int result;
		if (room != null)
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
			result = (nameField.Equals(room.nameField) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override int GetHashCode()
	{
		return nameField.GetHashCode();
	}

	public override string ToString()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = nameField;
		array[1] = visibleField;
		array[2] = openField;
		array[3] = maxPlayersField;
		array[4] = playerCount;
		array[5] = SupportClass.DictionaryToString(customPropertiesField);
		return string.Format("Room: '{0}' visible: {1} open: {2} max: {3} count: {4}\ncustomProps: {5}", array);
	}

	protected internal void cd044c9cb28b3007bfdd98781f1a72634(Hashtable c5f1aff81bde03ad6503eea7a94ee7da0)
	{
		if (c5f1aff81bde03ad6503eea7a94ee7da0 == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c5f1aff81bde03ad6503eea7a94ee7da0.Count == 0)
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
				if (customPropertiesField.Equals(c5f1aff81bde03ad6503eea7a94ee7da0))
				{
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
				if (c5f1aff81bde03ad6503eea7a94ee7da0.ContainsKey((byte)251))
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
					removedFromList = (bool)c5f1aff81bde03ad6503eea7a94ee7da0[(byte)251];
					if (removedFromList)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return;
							}
						}
					}
				}
				if (c5f1aff81bde03ad6503eea7a94ee7da0.ContainsKey(byte.MaxValue))
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
					maxPlayersField = (byte)c5f1aff81bde03ad6503eea7a94ee7da0[byte.MaxValue];
				}
				if (c5f1aff81bde03ad6503eea7a94ee7da0.ContainsKey((byte)253))
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
					openField = (bool)c5f1aff81bde03ad6503eea7a94ee7da0[(byte)253];
				}
				if (c5f1aff81bde03ad6503eea7a94ee7da0.ContainsKey((byte)254))
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
					visibleField = (bool)c5f1aff81bde03ad6503eea7a94ee7da0[(byte)254];
				}
				if (c5f1aff81bde03ad6503eea7a94ee7da0.ContainsKey((byte)252))
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
					playerCount = (byte)c5f1aff81bde03ad6503eea7a94ee7da0[(byte)252];
				}
				if (c5f1aff81bde03ad6503eea7a94ee7da0.ContainsKey((byte)249))
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
					autoCleanUpField = (bool)c5f1aff81bde03ad6503eea7a94ee7da0[(byte)249];
				}
				customPropertiesField.cf7c1c7a7b045d5d6df74fc02c9a94917(c5f1aff81bde03ad6503eea7a94ee7da0);
				return;
			}
		}
	}
}
