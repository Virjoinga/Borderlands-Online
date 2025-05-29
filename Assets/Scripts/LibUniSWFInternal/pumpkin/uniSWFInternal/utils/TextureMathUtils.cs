namespace pumpkin.uniSWFInternal.utils
{
	public class TextureMathUtils
	{
		public static int UpToPower2(int inX)
		{
			int num;
			for (num = 1; num < inX; num <<= 1)
			{
			}
			return num;
		}

		public static int DownToPower2(int inX)
		{
			int num;
			for (num = UpToPower2(inX); num > inX; num >>= 1)
			{
			}
			return num;
		}
	}
}
