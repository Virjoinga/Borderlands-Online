using UnityEngine;
using pumpkin.geom;

namespace pumpkin.swf
{
	public class SimpleShapeGraphicsOP : AssetBaseInfo
	{
		public static uint FIELDBIT_pos = 1u;

		public static uint FIELDBIT_bitmapCid = 2u;

		public static uint FIELDBIT_color = 4u;

		public static uint FIELDBIT_matrix = 8u;

		public static int OP_BEGIN_FILL = 0;

		public static int OP_BEGIN_BITMAP_FILL = 1;

		public static int OP_MOVE_TO = 2;

		public static int OP_LINE_TO = 3;

		public byte opType;

		public Vector2 pos;

		public int bitmapCid = -1;

		public int color = -1;

		public Matrix matrix;
	}
}
