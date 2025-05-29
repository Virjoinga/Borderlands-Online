using pumpkin.swf.swfFormat.version8;

namespace pumpkin.system.defaults
{
	public class SWFReader_8Defaults
	{
		public const bool readOnlyEmbededTexture = true;

		public static void restoreDefaults()
		{
			SWFReader_8.readOnlyEmbededTexture = true;
		}
	}
}
