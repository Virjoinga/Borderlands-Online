using System.Collections;
using UnityEngine;
using pumpkin.tweener;
using pumpkin.ui;

namespace pumpkin.swf.vm.ops
{
	public class GuiAutoRelativeOP : SimpleActionOP
	{
		public float autoScaleStage;

		public float detectBackground;

		public float detectEdges;

		public float detectEdgeBorder;

		public IList ignoreList;

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
			if (vm.movieClip.stage != null)
			{
				layout.resizeScreen(new Vector2(vm.movieClip.stage.screenWidth, vm.movieClip.stage.screenHeight));
				if (autoScaleStage == 1f)
				{
					GuiAutoscaleStateOP.ensureOverlayCameraScaleSync(vm);
				}
				layout.autoRelative(vm.movieClip, Tweener.Hash("autoScaleStage", autoScaleStage == 1f, "detectBackground", detectBackground == 1f, "detectEdges", detectEdges == 1f, "detectEdgeBorder", detectEdgeBorder, "ignoreList", ignoreList));
			}
		}
	}
}
