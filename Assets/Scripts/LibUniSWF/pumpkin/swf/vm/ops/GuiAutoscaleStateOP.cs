using UnityEngine;
using pumpkin.ui;

namespace pumpkin.swf.vm.ops
{
	public class GuiAutoscaleStateOP : SimpleActionOP
	{
		public static bool forceSyncStageScalePerFrame = true;

		public float baselineWidth;

		public float baselineHeight;

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
			ensureOverlayCameraScaleSync(vm);
			layout.autoScaleStage();
		}

		public static void ensureOverlayCameraScaleSync(SimpleActionVM vm)
		{
			if (forceSyncStageScalePerFrame && vm.movieClip != null && vm.movieClip.stage != null && vm.movieClip.stage.host is MovieClipOverlayCameraBehaviour)
			{
				MovieClipOverlayCameraBehaviour movieClipOverlayCameraBehaviour = vm.movieClip.stage.host as MovieClipOverlayCameraBehaviour;
				if (movieClipOverlayCameraBehaviour.syncStageScalePerFrame)
				{
					movieClipOverlayCameraBehaviour.syncStageScalePerFrame = false;
					Debug.LogWarning("Fluid layout disabling MovieClipOverlayCameraBehaviour.syncStageScalePerFrame, to resolve this warning please disable syncStageScalePerFrame on the MovieClipOverlayCameraBehaviour");
				}
			}
		}
	}
}
