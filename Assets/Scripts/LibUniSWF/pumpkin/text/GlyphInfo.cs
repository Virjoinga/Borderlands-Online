using System;

namespace pumpkin.text
{
	public class GlyphInfo
	{
		public char c;

		public float topLine;

		public float charWidth;

		public float charHeight;

		public float charStartX;

		public float charStartY;

		public float minX;

		public KerningInfo[] kerning;

		public void setKerning(char prevChar, float offset)
		{
			if (kerning != null)
			{
				for (int i = 0; i < kerning.Length; i++)
				{
					if (kerning[i].prevChar == prevChar)
					{
						kerning[i].offset = offset;
						return;
					}
				}
			}
			if (kerning == null)
			{
				kerning = new KerningInfo[1];
			}
			else
			{
				Array.Resize(ref kerning, kerning.Length + 1);
			}
			KerningInfo kerningInfo = default(KerningInfo);
			kerningInfo.prevChar = prevChar;
			kerningInfo.offset = offset;
			kerning[kerning.Length - 1] = kerningInfo;
		}

		public float getKerning(char prevChar)
		{
			if (kerning == null)
			{
				return 0f;
			}
			for (int i = 0; i < kerning.Length; i++)
			{
				if (kerning[i].prevChar == prevChar)
				{
					return kerning[i].offset;
				}
			}
			return 0f;
		}
	}
}
