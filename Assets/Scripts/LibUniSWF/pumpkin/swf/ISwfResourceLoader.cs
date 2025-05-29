using UnityEngine;

namespace pumpkin.swf
{
	public interface ISwfResourceLoader
	{
		SwfAssetContext loadSWF(string swfUri);

		Material getMaterial(MovieClipPlayer player, SwfAssetContext assetContext, DisplayObjectInfo dispInfo, BitmapAssetInfo bmpInfo);

		Material getCharMaterial(BitmapTextField txt, SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, BitmapFontCharInfo charInfo, BitmapAssetInfo bmpInfo);

		bool unloadSWF(string swfUri);
	}
}
