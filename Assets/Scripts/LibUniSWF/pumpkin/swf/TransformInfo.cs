using pumpkin.display;
using pumpkin.geom.structs;

namespace pumpkin.swf
{
	public class TransformInfo
	{
		public SMatrix matrix;

		public float width = 0f;

		public float height = 0f;

		public float alpha = 1f;

		public bool visible = true;

		public void applyToSprite(DisplayObject sprite)
		{
			if (alpha != 1f || alpha != sprite.internalAlpha)
			{
				sprite.internalAlpha = alpha;
			}
			sprite.internalVisible = visible;
			sprite.srcWidth = width;
			sprite.srcHeight = height;
			sprite.setMatrixOverride(matrix);
		}
	}
}
