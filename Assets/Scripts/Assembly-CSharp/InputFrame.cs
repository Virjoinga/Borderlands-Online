using System;
using System.IO;
using System.Runtime.CompilerServices;
using A;

[Serializable]
public struct InputFrame
{
	public enum Flag
	{
		Run = 1,
		Jump = 2,
		Forward = 4,
		Backward = 8,
		Left = 0x10,
		Right = 0x20,
		Crouch = 0x40,
		Aim = 0x80
	}

	public byte m_flags;

	private ushort m_yaw16;

	public ushort m_pitch16;

	public int m_frameNum;

	public float m_yaw
	{
		get
		{
			return (float)(int)m_yaw16 / 100f;
		}
		set
		{
			m_yaw16 = (ushort)(value * 100f);
		}
	}

	public float m_pitch
	{
		get
		{
			return (float)(int)m_pitch16 / 100f;
		}
		set
		{
			m_pitch16 = (ushort)(value * 100f);
		}
	}

	public InputFrame(InputFrame cebae66039aadeac8deb1211786332a72)
	{
		m_flags = cebae66039aadeac8deb1211786332a72.m_flags;
		m_yaw = cebae66039aadeac8deb1211786332a72.m_yaw;
		m_pitch = cebae66039aadeac8deb1211786332a72.m_pitch;
		m_frameNum = cebae66039aadeac8deb1211786332a72.m_frameNum;
	}

	public bool c2f9647b8222028a80f7d5d8b6e2ac914(Flag ca9268c8273717a78d672d706a35e3edf)
	{
		return (m_flags & (byte)ca9268c8273717a78d672d706a35e3edf) != 0;
	}

	public void ca968fc4c885049a5d802d9492edf0261(Flag ca9268c8273717a78d672d706a35e3edf, bool cefda2fdc3ce4e04f38bab77fc7998241)
	{
		if (cefda2fdc3ce4e04f38bab77fc7998241)
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
					m_flags |= (byte)ca9268c8273717a78d672d706a35e3edf;
					return;
				}
			}
		}
		m_flags &= (byte)(~(byte)ca9268c8273717a78d672d706a35e3edf);
	}

	public bool c6eb32142ff311fc97f545f61349347a7()
	{
		return m_flags << 1 == 0;
	}

	public static int c5c3c145d54edc727770887f87bea1217()
	{
		return 9;
	}

	[SpecialName]
	public static byte[] c00ae05b9ced94c9fc5f4be4892e6192b(InputFrame ca9a5505924b5223bebd6981e50a7b762)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes(ca9a5505924b5223bebd6981e50a7b762.m_flags), 0, 1);
		memoryStream.Write(BitConverter.GetBytes(ca9a5505924b5223bebd6981e50a7b762.m_yaw16), 0, 2);
		memoryStream.Write(BitConverter.GetBytes(ca9a5505924b5223bebd6981e50a7b762.m_pitch16), 0, 2);
		memoryStream.Write(BitConverter.GetBytes(ca9a5505924b5223bebd6981e50a7b762.m_frameNum), 0, 4);
		return memoryStream.ToArray();
	}

	[SpecialName]
	public static InputFrame c00ae05b9ced94c9fc5f4be4892e6192b(byte[] c591d56a94543e3559945c497f37126c4)
	{
		InputFrame c36964cf41281414170f34ee68bef6c = default(InputFrame);
		c00a9bc5c4cae97aed0a9965a4dbd8fe7.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(c591d56a94543e3559945c497f37126c4, 0, c591d56a94543e3559945c497f37126c4.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(4);
		memoryStream.Read(array, 0, 1);
		c36964cf41281414170f34ee68bef6c.m_flags = array[0];
		memoryStream.Read(array, 0, 2);
		c36964cf41281414170f34ee68bef6c.m_yaw16 = BitConverter.ToUInt16(array, 0);
		memoryStream.Read(array, 0, 2);
		c36964cf41281414170f34ee68bef6c.m_pitch16 = BitConverter.ToUInt16(array, 0);
		memoryStream.Read(array, 0, 4);
		c36964cf41281414170f34ee68bef6c.m_frameNum = BitConverter.ToInt32(array, 0);
		return c36964cf41281414170f34ee68bef6c;
	}
}
