using System.Collections.Generic;
using pumpkin.geom;

namespace pumpkin.swf
{
	public class MovieClipAssetInfo : AssetBaseInfo
	{
		public static uint FIELDBIT_shared = 1u;

		public static uint FIELDBIT_scale9Grid = 2u;

		public List<FrameInfo> frames = new List<FrameInfo>();

		public Dictionary<string, int> labels = new Dictionary<string, int>();

		public bool shared;

		public Rectangle scale9grid;

		public bool frameLabelsCached = false;

		public MovieClipAssetInfo()
		{
			type = AssetBaseInfo.TYPE_MOVIECLIP_ASSET;
		}

		public void addFrame(FrameInfo frameInfo)
		{
			frames.Add(frameInfo);
		}

		public void _cacheFrameLabels()
		{
			if (frameLabelsCached)
			{
				return;
			}
			string label = null;
			for (int i = 0; i < frames.Count; i++)
			{
				FrameInfo frameInfo = frames[i];
				foreach (KeyValuePair<string, int> label2 in labels)
				{
					if (label2.Value == i + 1)
					{
						label = label2.Key;
					}
				}
				frameInfo.label = label;
			}
			frameLabelsCached = true;
		}
	}
}
