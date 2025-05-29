using UnityEngine;
using pumpkin.display;

namespace pumpkin.swf
{
	internal class TextGroup
	{
		public Color color = Color.white;

		public string movieClipUri;

		public float width = 0f;

		public DisplayObject clipCache;

		public bool drawMovieClip = true;

		public TextGroup clone()
		{
			TextGroup textGroup = new TextGroup();
			textGroup.color = color;
			textGroup.movieClipUri = movieClipUri;
			textGroup.width = width;
			textGroup.clipCache = clipCache;
			textGroup.drawMovieClip = drawMovieClip;
			return textGroup;
		}
	}
}
