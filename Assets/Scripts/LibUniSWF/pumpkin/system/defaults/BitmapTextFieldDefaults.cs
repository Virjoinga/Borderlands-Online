using pumpkin.swf;

namespace pumpkin.system.defaults
{
	public class BitmapTextFieldDefaults
	{
		public const bool enableMissingCharacterWarning = false;

		public const int globalPixelSnapping = 1;

		public const int globalPixelSnapMinSize = 16;

		public const bool enableAssetInfoFallback = true;

		public static void restoreDefaults()
		{
			BitmapTextField.enableMissingCharacterWarning = false;
			BitmapTextField.globalPixelSnapping = 1;
			BitmapTextField.globalPixelSnapMinSize = 16;
			BitmapTextField.enableAssetInfoFallback = true;
		}
	}
}
