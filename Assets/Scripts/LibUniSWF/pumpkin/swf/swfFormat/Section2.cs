namespace pumpkin.swf.swfFormat
{
	internal class Section2
	{
		protected SwfBinaryReader b;

		protected long m_StartPos = 0L;

		protected int m_Type;

		protected int m_Size;

		public int type
		{
			get
			{
				return m_Type;
			}
		}

		public int size
		{
			get
			{
				return m_Size;
			}
		}

		public Section2(SwfBinaryReader b)
		{
			this.b = b;
			m_Type = b.ReadInt16();
			m_Size = b.ReadInt32();
			m_StartPos = b.getPosition();
		}

		public Section2()
		{
			b = null;
			m_Type = 0;
			m_Size = 0;
			m_StartPos = 0L;
		}

		public void initFromReader(SwfBinaryReader b)
		{
			this.b = b;
			m_Type = b.ReadInt16();
			m_Size = b.ReadInt32();
			m_StartPos = b.getPosition();
		}

		public float readFloat()
		{
			if (getDataRead() + 4 > size)
			{
				return 0f;
			}
			return b.ReadSingle();
		}

		public int readInt()
		{
			if (getDataRead() + 4 > size)
			{
				return 0;
			}
			return b.ReadInt32();
		}

		public string readString()
		{
			int num = readInt();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			if (getDataRead() + num > size)
			{
				return null;
			}
			return new string(b.ReadChars(num));
		}

		public string readStringNoSection()
		{
			int num = readInt();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			if (getDataRead() + num > size)
			{
				return null;
			}
			return new string(b.ReadChars(num));
		}

		public byte[] readByteArray()
		{
			Section1 section = new Section1(b);
			int num = readInt();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			if (getDataRead() + num > size)
			{
				section.end();
				return null;
			}
			byte[] result = b.ReadBytes(num);
			section.end();
			return result;
		}

		public int getDataRead()
		{
			return (int)(m_StartPos - b.getPosition());
		}

		public void end()
		{
			int num = 0;
			while (b.getPosition() < m_StartPos + size)
			{
				b.ReadByte();
				num++;
				if (num > 1024)
				{
					break;
				}
			}
		}
	}
}
