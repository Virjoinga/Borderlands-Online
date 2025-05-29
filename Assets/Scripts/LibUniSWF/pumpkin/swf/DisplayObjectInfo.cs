using UnityEngine;

namespace pumpkin.swf
{
	public class DisplayObjectInfo
	{
		public static uint FIELDBIT_userDataJSON = 1u;

		public static uint FIELDBIT_isSimpleButton = 2u;

		public static uint FIELDBIT_maskInstanceId = 4u;

		public static uint FIELDBIT_isMask = 8u;

		public static uint FIELDBIT_blendMode = 16u;

		public static uint FIELDBIT_colorTransform = 32u;

		public static uint FIELDBIT_scale9Grid = 64u;

		public static uint FIELDBIT_textInfo = 128u;

		public static uint FIELDBIT_noChange = 256u;

		public static int TYPE_DISPLAYOBJECT_INSTANCE = 1;

		public static int TYPE_BITMAP_INSTANCE = 1;

		public static int TYPE_MOVIECLIP_INSTANCE = 2;

		public static int TYPE_DYNAMICTEXT_INSTANCE = 3;

		public int type;

		public int cid;

		public int instanceId;

		public TransformInfo tranform;

		public string name;

		public TextDisplayInfo textInfo;

		public string userDataJSON;

		public bool isSimpleButton;

		public int maskInstanceId;

		public bool isMask;

		public int blendMode;

		public Color colorTransform;
	}
}
