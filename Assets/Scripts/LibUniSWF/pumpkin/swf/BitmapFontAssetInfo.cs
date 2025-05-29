using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.swf
{
	public class BitmapFontAssetInfo : AssetBaseInfo
	{
		public Dictionary<char, BitmapFontCharInfo> characters = new Dictionary<char, BitmapFontCharInfo>();

		public float kerning;

		public float size;

		public float letterSpacing;

		public string name;

		public string style;

		public string text;

		public float spaceWidth;

		public int align;

		public bool shared;

		public float pixelSize = 1f;

		public Color color;

		public int bold;

		public int italic;

		public int underline;

		public int hasFilters;

		public string filterJson;

		public string filterHash;

		public string instanceName;

		public string parentSymbolName;

		public float cursorMinY = 0f;

		public float cursorMaxY = 0f;

		public bool isTTF = false;

		public BitmapFontAssetInfo()
		{
			type = AssetBaseInfo.TYPE_BITMAPFONT_ASSET;
		}
	}
}
