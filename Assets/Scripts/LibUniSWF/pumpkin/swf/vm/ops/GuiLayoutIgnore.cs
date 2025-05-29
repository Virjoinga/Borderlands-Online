using UnityEngine;
using pumpkin.display;
using pumpkin.ui;

namespace pumpkin.swf.vm.ops
{
	public class GuiLayoutIgnore : SimpleActionOP
	{
		public string name;

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
			}
			else
			{
				layout.layoutIgnore(childByName);
			}
		}
	}
}
