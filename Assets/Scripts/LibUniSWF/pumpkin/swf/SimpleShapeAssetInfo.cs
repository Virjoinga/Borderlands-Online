using System.Collections.Generic;
using pumpkin.display;

namespace pumpkin.swf
{
	public class SimpleShapeAssetInfo : AssetBaseInfo
	{
		public List<SimpleShapeGraphicsOP> drawOPs;

		public void applyToSprite(SwfAssetContext assetContext, Sprite sprite, DisplayObjectInfo dispInfo, MovieClipPlayer parentMoviePlayer)
		{
			GraphicsVectorGenerator graphicsVectorGenerator = new GraphicsVectorGenerator(sprite.graphics);
			for (int i = 0; i < drawOPs.Count; i++)
			{
				SimpleShapeGraphicsOP simpleShapeGraphicsOP = drawOPs[i];
				if (simpleShapeGraphicsOP.opType == SimpleShapeGraphicsOP.OP_BEGIN_BITMAP_FILL)
				{
					BitmapAssetInfo bitmapInfoByCid = assetContext.getBitmapInfoByCid(simpleShapeGraphicsOP.bitmapCid);
					if (bitmapInfoByCid.bitmapData == null)
					{
						bitmapInfoByCid.bitmapData = assetContext.resourceLoader.getMaterial(parentMoviePlayer, assetContext, dispInfo, bitmapInfoByCid);
					}
					if (bitmapInfoByCid.bitmapData == null)
					{
						break;
					}
					graphicsVectorGenerator.beginMaterialFill(bitmapInfoByCid.bitmapData, simpleShapeGraphicsOP.matrix);
				}
				else if (simpleShapeGraphicsOP.opType == SimpleShapeGraphicsOP.OP_MOVE_TO)
				{
					graphicsVectorGenerator.moveTo(simpleShapeGraphicsOP.pos.x, simpleShapeGraphicsOP.pos.y);
				}
				else if (simpleShapeGraphicsOP.opType == SimpleShapeGraphicsOP.OP_LINE_TO)
				{
					graphicsVectorGenerator.lineTo(simpleShapeGraphicsOP.pos.x, simpleShapeGraphicsOP.pos.y);
				}
			}
			graphicsVectorGenerator.flush();
		}
	}
}
