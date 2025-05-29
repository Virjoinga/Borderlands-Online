using UnityEngine;
using pumpkin.display;
using pumpkin.tweener;
using pumpkin.ui;

namespace pumpkin.swf.vm.ops
{
	public class GuiPositionOP : SimpleActionOP
	{
		public string name;

		public object left;

		public object right;

		public object top;

		public object bottom;

		public object relative;

		public object relativeTo;

		public override void run(SimpleActionVM vm)
		{
			MovieClipLayout layout = GuiInitOP.getLayout(vm.movieClip);
			if (layout == null)
			{
				Debug.LogError("guiLayout == null");
				return;
			}
			if (layout.stageRef == null)
			{
				layout.stageRef = vm.movieClip.parent;
			}
			DisplayObject childByName = vm.movieClip.getChildByName(name);
			if (childByName == null)
			{
				Debug.LogError("GuiPositionOP failed to find: " + name);
				return;
			}
			DisplayObject displayObject = null;
			if (relativeTo is string)
			{
				string text = relativeTo as string;
				if (!string.IsNullOrEmpty(text))
				{
					displayObject = vm.movieClip.getChildByName(text);
					if (displayObject == null)
					{
						Debug.LogError("GuiPositionOP failed to find: '" + text + "' )");
						return;
					}
				}
			}
			bool flag = false;
			if (relative is bool)
			{
				flag = (bool)relative;
			}
			else if (relative is int)
			{
				flag = (int)relative == 1;
			}
			layout.position(childByName, Tweener.Hash("left", left, "right", right, "top", top, "bottom", bottom, "relative", flag, "relativeTo", displayObject));
		}
	}
}
