using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.ui;
using pumpkin.utils;

namespace pumpkin.swf.vm.ops
{
	public class GuiInitOP : SimpleActionOP
	{
		public float baselineWidth;

		public float baselineHeight;

		public override void run(SimpleActionVM vm)
		{
			MovieClipLayout movieClipLayout = new MovieClipLayout();
			movieClipLayout.init(vm.movieClip.parent, new Vector2(baselineWidth, baselineHeight), new Vector2(Screen.width, Screen.height));
			if (vm.movieClip.m_VmData == null)
			{
				vm.movieClip.m_VmData = new SafeHashtable();
				vm.movieClip.m_VmData.setObject("guiLayout", movieClipLayout);
				vm.movieClip.addEventListener(CEvent.ENTER_FRAME, onDeferredFrame);
				vm.movieClip.addEventListener(CEvent.ADDED_TO_STAGE, onAddedToStage);
			}
		}

		public void onAddedToStage(CEvent e)
		{
			MovieClip target = e.currentTarget as MovieClip;
			if (target == null)
			{
				Debug.LogWarning("GuiInitOP has null target");
			}
			else
			{
				if (target.m_VmData == null)
				{
					return;
				}
				MovieClipLayout guiLayout = target.m_VmData.getObject("guiLayout") as MovieClipLayout;
				if (guiLayout == null)
				{
					return;
				}
				target.dispatchEvent(new CEvent("LayoutGUI"));
				target.addEventListener(CEvent.REMOVED_FROM_STAGE, onRemovedFromStage);
				if (target.m_VmData.isTrue("listeningStageResize") || target.stage == null)
				{
					return;
				}
				target.stage.addEventListener(CEvent.RESIZE, delegate
				{
					if (target == null)
					{
						Debug.LogWarning("target == null");
					}
					else if (target.stage == null)
					{
						Debug.LogWarning(string.Concat("GuiInitOP() RESIZE target ", target, ".stage == null"));
					}
					else if (guiLayout == null)
					{
						Debug.LogWarning("GuiInitOP() guiLayout == null");
					}
					else
					{
						guiLayout.resizeScreen(new Vector2(target.stage.screenWidth, target.stage.screenHeight));
						target.dispatchEvent(new LayoutGUIEvent());
					}
				});
			}
		}

		public void onRemovedFromStage(CEvent e)
		{
		}

		public void onDeferredFrame(CEvent e)
		{
			(e.currentTarget as EventDispatcher).removeEventListener(CEvent.ENTER_FRAME, onDeferredFrame);
			(e.currentTarget as EventDispatcher).dispatchEvent(new LayoutGUIEvent());
		}

		public static MovieClipLayout getLayout(DisplayObject mc)
		{
			if (mc.m_VmData == null)
			{
				return null;
			}
			return mc.m_VmData.getObject("guiLayout") as MovieClipLayout;
		}
	}
}
