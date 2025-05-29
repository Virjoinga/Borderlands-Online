using UnityEngine;
using pumpkin.swf;

namespace pumpkin.text
{
	public class TextFormat
	{
		public int align = TextFieldAlign.LEFT;

		public bool hasEffects = false;

		public string fontClassName = null;

		public string font = null;

		public float size = 0f;

		public bool findNearestSize = false;

		public bool isBitmap = false;

		public float letterSpacing = 0f;

		public float leading = 0f;

		public bool fitSize = false;

		public bool wordWrap = true;

		public bool charClip = false;

		public Color color = Color.white;

		public bool bold = false;

		public bool italic = false;

		public string filtersHash;

		public string exportedStyleName;

		public TextFormat()
		{
		}

		internal TextFormat(BitmapFontAssetInfo assetInfo)
		{
			font = assetInfo.name;
			size = assetInfo.size;
			align = assetInfo.align;
			isBitmap = true;
			color = assetInfo.color;
		}

		public TextFormat clone()
		{
			TextFormat textFormat = new TextFormat();
			textFormat.align = align;
			textFormat.font = font;
			textFormat.size = size;
			textFormat.findNearestSize = findNearestSize;
			textFormat.isBitmap = isBitmap;
			textFormat.letterSpacing = letterSpacing;
			textFormat.fitSize = fitSize;
			textFormat.wordWrap = wordWrap;
			textFormat.charClip = charClip;
			textFormat.color = color;
			textFormat.bold = bold;
			textFormat.italic = italic;
			textFormat.filtersHash = filtersHash;
			textFormat.exportedStyleName = exportedStyleName;
			textFormat.fontClassName = fontClassName;
			return textFormat;
		}
	}
}
