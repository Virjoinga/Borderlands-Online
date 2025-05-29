using System.Collections.Generic;
using pumpkin.swf.vm;

namespace pumpkin.swf
{
	public class FrameInfo
	{
		public List<DisplayObjectInfo> displayList = new List<DisplayObjectInfo>();

		public string frameUserActionsXML = null;

		public string label = null;

		public List<SimpleActionOP> actions = null;
	}
}
