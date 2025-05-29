using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.swf
{
	public class UnityFontGeneratorCache
	{
		public Font font;

		public string charSet;

		public int[] sizes;

		public List<UnityTTFFontInfo> fontInfoList = new List<UnityTTFFontInfo>();
	}
}
