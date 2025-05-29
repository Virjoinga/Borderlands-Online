using System.IO;
using UnityEngine;

namespace pumpkin.swf
{
	public class SwfBinaryReader : BinaryReader
	{
		public SwfBinaryReader(MemoryStream stream)
			: base(stream)
		{
		}

		public SwfBinaryReader(byte[] bytes)
			: base(new MemoryStream(bytes))
		{
		}

		public SwfBinaryReader(TextAsset textAsset)
			: base(new MemoryStream(textAsset.bytes))
		{
		}

		public long getPosition()
		{
			return BaseStream.Position;
		}
	}
}
