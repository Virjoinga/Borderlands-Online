using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.swf
{
	public class UnityTTFFontInfo : BitmapFontAssetInfo
	{
		public Dictionary<int, Dictionary<char, UnityTTFGlyph>> ttfAllCharacters = new Dictionary<int, Dictionary<char, UnityTTFGlyph>>();

		public Font font;

		public UniSWFTTFFontAssetInfo fontAssetInfo;

		public bool autoGenerateSizes = false;

		public bool fontCacheDirty = true;

		public int lastCharInfoLen = -1;

		public string allChars = "";

		public Dictionary<char, UnityTTFGlyph> getCharCacheForSize(int fontSize, bool autoCreate = false)
		{
			if (ttfAllCharacters.ContainsKey(fontSize))
			{
				return ttfAllCharacters[fontSize];
			}
			Dictionary<char, UnityTTFGlyph> dictionary = new Dictionary<char, UnityTTFGlyph>();
			ttfAllCharacters[fontSize] = dictionary;
			return dictionary;
		}
	}
}
