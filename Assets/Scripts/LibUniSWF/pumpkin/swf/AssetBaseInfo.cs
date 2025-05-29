namespace pumpkin.swf
{
	public class AssetBaseInfo
	{
		public static int TYPE_MOVIECLIP_ASSET = 0;

		public static int TYPE_BITMAP_ASSET = 1;

		public static int TYPE_BITMAPFONT_ASSET = 2;

		public static int TYPE_SIMPLESHAPE_ASSET = 3;

		public int type = -1;

		public int cid = -1;

		public string className;

		public SwfAssetContext assetContext;
	}
}
