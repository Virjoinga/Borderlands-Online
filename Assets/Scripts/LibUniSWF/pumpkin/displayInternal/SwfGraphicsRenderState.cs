using UnityEngine;
using pumpkin.display;

namespace pumpkin.displayInternal
{
	internal struct SwfGraphicsRenderState
	{
		public bool parentHasClipRect;

		public Color colorTransform;

		public int blendMode;

		public DisplayObject clipRectParent;

		public Rect clipRect;

		public bool clipRectCached;
	}
}
