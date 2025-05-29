using UnityEngine;

namespace pumpkin.swf
{
	public class BitmapAssetInfo : AssetBaseInfo
	{
		public static uint FIELDBIT_isTransparent = 1u;

		public static uint FIELDBIT_textureReadWrite = 2u;

		public Rect srcRect;

		public Rect shapeRect;

		public string textureUri;

		public bool instanceAsset = false;

		public float pixelSize = 1f;

		public bool isTransparent = true;

		public bool textureReadWrite = false;

		public byte fileFormat = 0;

		public byte[] embedeData = null;

		public Material bitmapData;

		public Rect uvRect;

		public BitmapAssetInfo()
		{
			type = AssetBaseInfo.TYPE_BITMAP_ASSET;
		}
	}
}
