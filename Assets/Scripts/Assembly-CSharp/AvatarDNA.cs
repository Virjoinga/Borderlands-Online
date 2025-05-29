using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using XsdSettings;

[Serializable]
public class AvatarDNA : ICloneable
{
	public AvatarType m_type;

	public BuildingUnit m_buildingUnit;

	[CompilerGenerated]
	private static Func<byte, string> _003C_003Ef__am_0024cache2;

	[CompilerGenerated]
	private static Func<byte, string> _003C_003Ef__am_0024cache3;

	public AvatarDNA()
	{
		cb2dc67c96c361fca33303dac1fd10e03(8);
	}

	public void cb2dc67c96c361fca33303dac1fd10e03(int cbaa18f2c94c59e186827489ba007c223)
	{
		m_buildingUnit = new BuildingUnit(cbaa18f2c94c59e186827489ba007c223);
	}

	public object Clone()
	{
		AvatarDNA avatarDNA = (AvatarDNA)MemberwiseClone();
		avatarDNA.m_buildingUnit = (BuildingUnit)m_buildingUnit.Clone();
		return avatarDNA;
	}

	public override bool Equals(object obj)
	{
		AvatarDNA avatarDNA = obj as AvatarDNA;
		if (avatarDNA != null)
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
			if (m_type == avatarDNA.m_type)
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
				if (m_buildingUnit.Equals(avatarDNA.m_buildingUnit))
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return m_type.GetHashCode() ^ m_buildingUnit.GetHashCode();
	}

	public byte c295a7d68f6d6dc8bcf0079d20eff5fc8(byte c60344406ce11ae1fafe3cb61fcb66cf2)
	{
		return m_buildingUnit.mFBXs[c60344406ce11ae1fafe3cb61fcb66cf2];
	}

	public void ca1fe7b61e26d6fd9fe0781630e0e7bdd(byte c60344406ce11ae1fafe3cb61fcb66cf2, byte cd1505a8bc35681ef0fed8cd958a8b539)
	{
		m_buildingUnit.mFBXs[c60344406ce11ae1fafe3cb61fcb66cf2] = cd1505a8bc35681ef0fed8cd958a8b539;
	}

	public byte cb60bc56168ff5e617e854de69154bd48(byte c1989196ba5ae9cbcc92c79bdf8406dcf)
	{
		return m_buildingUnit.mMats[c1989196ba5ae9cbcc92c79bdf8406dcf];
	}

	public void cf83de9b24939a64c5b795af7d70153b4(byte c1989196ba5ae9cbcc92c79bdf8406dcf, byte c4b37d539f2c2303a31bf314f3f555bef)
	{
		m_buildingUnit.mMats[c1989196ba5ae9cbcc92c79bdf8406dcf] = c4b37d539f2c2303a31bf314f3f555bef;
	}

	public AvatarType c071244a19e2d9f70f4d2d6d38677162a()
	{
		return m_type;
	}

	public void c300c4ff719a5623d8161bef607d268f1(AvatarType c4f09c39924e70788c7b055c1d1490578)
	{
		switch (c4f09c39924e70788c7b055c1d1490578)
		{
		case AvatarType.SIREN:
			m_buildingUnit.bkID = 1242413768u;
			c300c4ff719a5623d8161bef607d268f1(0, 0, 0, 0);
			break;
		case AvatarType.SOLDIER:
			m_buildingUnit.bkID = 1267549099u;
			c300c4ff719a5623d8161bef607d268f1(1, 0, 0, 0);
			break;
		case AvatarType.BERSERKER:
			m_buildingUnit.bkID = 3556519174u;
			c300c4ff719a5623d8161bef607d268f1(2, 0, 0, 0);
			break;
		case AvatarType.HUNTER:
			m_buildingUnit.bkID = 3169502637u;
			c300c4ff719a5623d8161bef607d268f1(3, 0, 0, 0);
			break;
		}
	}

	public void c300c4ff719a5623d8161bef607d268f1(byte c2b4f43f34e21572af6ab4414f04cee36, byte ccb47f27de7c4d7fd16b48c6a8c441e7b, byte ca5a081740954f8c831b572649e7e7095, byte cdbb96ac8fdc824adf7a390c01f072806, byte cfc6901d93ba35715a71fd579a7fa7209 = 0, byte c7632551a046173f224f314526b633059 = 0, byte ca3c3ec0fd08ad7eaf1624a68a591bd21 = 0)
	{
		m_type = (AvatarType)c2b4f43f34e21572af6ab4414f04cee36;
		m_buildingUnit.mFBXs[0] = ccb47f27de7c4d7fd16b48c6a8c441e7b;
		m_buildingUnit.mFBXs[1] = ca5a081740954f8c831b572649e7e7095;
		m_buildingUnit.mFBXs[2] = cdbb96ac8fdc824adf7a390c01f072806;
	}

	public void c300c4ff719a5623d8161bef607d268f1(AvatarType c2b4f43f34e21572af6ab4414f04cee36, string c6b68f14f85f7cff7a7223716d1482ecd, string cad1f12a1809d71a01e4f458971f0b77d, uint c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		m_type = c2b4f43f34e21572af6ab4414f04cee36;
		if (m_buildingUnit == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_buildingUnit.bkID = c35f98ccbfa8c6bf09319c620b21b5dc5;
			m_buildingUnit.mFBXs.Clear();
			char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = ',';
			string[] array2 = c6b68f14f85f7cff7a7223716d1482ecd.Split(array);
			for (int i = 0; i < array2.Length; i++)
			{
				m_buildingUnit.mFBXs.Add(Convert.ToByte(array2[i]));
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				m_buildingUnit.mMats.Clear();
				char[] array3 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array3[0] = ',';
				array2 = cad1f12a1809d71a01e4f458971f0b77d.Split(array3);
				for (int j = 0; j < array2.Length; j++)
				{
					m_buildingUnit.mMats.Add(Convert.ToByte(array2[j]));
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

	public override string ToString()
	{
		return string.Format("{0} - {1} - {2}", m_type, m_buildingUnit.mFBXs.Count, m_buildingUnit.bkID);
	}

	public object[] c2a571a629882eb510fec9be3b03b14d0()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = Convert.ToInt32(m_type);
		array[1] = m_buildingUnit.bkID.ToString();
		List<byte> mFBXs = m_buildingUnit.mFBXs;
		if (_003C_003Ef__am_0024cache2 == null)
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
			_003C_003Ef__am_0024cache2 = (byte c7c80fef79e3c330ae5014832d44fcd28) => c7c80fef79e3c330ae5014832d44fcd28.ToString();
		}
		array[2] = string.Join(",", mFBXs.Select(_003C_003Ef__am_0024cache2).ToArray());
		List<byte> mMats = m_buildingUnit.mMats;
		if (_003C_003Ef__am_0024cache3 == null)
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
			_003C_003Ef__am_0024cache3 = (byte c7c80fef79e3c330ae5014832d44fcd28) => c7c80fef79e3c330ae5014832d44fcd28.ToString();
		}
		array[3] = string.Join(",", mMats.Select(_003C_003Ef__am_0024cache3).ToArray());
		return array;
	}

	[CompilerGenerated]
	private static string ca046c9614b675eb2254d422f864c47e2(byte c7c80fef79e3c330ae5014832d44fcd28)
	{
		return c7c80fef79e3c330ae5014832d44fcd28.ToString();
	}

	[CompilerGenerated]
	private static string ca7fb56560438e89b3710919d7d5e8a18(byte c7c80fef79e3c330ae5014832d44fcd28)
	{
		return c7c80fef79e3c330ae5014832d44fcd28.ToString();
	}
}
