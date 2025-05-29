using System;
using System.Collections.Generic;
using pumpkin.display;
using pumpkin.swf.vm.ops;
using pumpkin.utils;

namespace pumpkin.swf.vm
{
	public class SimpleActionVM
	{
		public static Dictionary<string, Type> registry = new Dictionary<string, Type>();

		private static SimpleActionVM g_VM = null;

		public MovieClip movieClip;

		public int pc;

		public List<SimpleActionOP> ops;

		public SafeHashtable globals = new SafeHashtable();

		public static SimpleActionVM getGlobalVM()
		{
			if (g_VM == null)
			{
				g_VM = new SimpleActionVM();
				registry["PlayActionOP"] = typeof(PlayActionOP);
				SimpleActionOP simpleActionOP = new PlayActionOP();
				registry["StopActionOP"] = typeof(StopActionOP);
				simpleActionOP = new StopActionOP();
				registry["GotoAndStopActionOP"] = typeof(GotoAndStopActionOP);
				simpleActionOP = new GotoAndStopActionOP();
				registry["GotoAndPlayActionOP"] = typeof(GotoAndPlayActionOP);
				simpleActionOP = new GotoAndPlayActionOP();
				registry["DispatchEventActionOP"] = typeof(DispatchEventActionOP);
				simpleActionOP = new DispatchEventActionOP();
				registry["SetDisplayObjectPropOP"] = typeof(SetDisplayObjectPropOP);
				simpleActionOP = new SetDisplayObjectPropOP();
				registry["TraceOP"] = typeof(TraceOP);
				simpleActionOP = new TraceOP();
				registry["AddEventListenerOP"] = typeof(AddEventListenerOP);
				simpleActionOP = new AddEventListenerOP();
				registry["BlocEndOP"] = typeof(BlocEndOP);
				simpleActionOP = new BlocEndOP();
				registry["LabelBlockOP"] = typeof(LabelBlockOP);
				simpleActionOP = new LabelBlockOP();
				registry["LabelOP"] = typeof(LabelOP);
				simpleActionOP = new LabelOP();
				registry["BlockEndOP"] = typeof(BlocEndOP);
				simpleActionOP = new BlocEndOP();
				registry["AddTweenOP"] = typeof(AddTweenOP);
				simpleActionOP = new AddTweenOP();
				registry["SetSceneOP"] = typeof(SetSceneOP);
				simpleActionOP = new SetSceneOP();
				registry["NavigateToUrlOP"] = typeof(NavigateToUrlOP);
				simpleActionOP = new NavigateToUrlOP();
				registry["PlaySoundOP"] = typeof(PlaySoundOP);
				simpleActionOP = new PlaySoundOP();
				registry["PlayMusicOP"] = typeof(PlayMusicOP);
				simpleActionOP = new PlayMusicOP();
				registry["GuiInitOP"] = typeof(GuiInitOP);
				simpleActionOP = new GuiInitOP();
				registry["GuiAutoscaleStateOP"] = typeof(GuiAutoscaleStateOP);
				simpleActionOP = new GuiAutoscaleStateOP();
				registry["GuiAutoRelativeOP"] = typeof(GuiAutoRelativeOP);
				simpleActionOP = new GuiAutoRelativeOP();
				registry["GuiPositionOP"] = typeof(GuiPositionOP);
				simpleActionOP = new GuiPositionOP();
				registry["GuiAutoscaleBackgroundOP"] = typeof(GuiAutoscaleBackgroundOP);
				simpleActionOP = new GuiAutoscaleBackgroundOP();
				registry["GuiLayoutIgnore"] = typeof(GuiLayoutIgnore);
				simpleActionOP = new GuiLayoutIgnore();
			}
			return g_VM;
		}

		public void runFrame(MovieClip movieClip, List<SimpleActionOP> ops, string gotoLabel, SafeHashtable globals)
		{
			resetVM();
			this.movieClip = movieClip;
			this.ops = ops;
			this.globals = ((globals == null) ? this.globals : globals);
			if (gotoLabel != null)
			{
				pc = getPcForLabel(ops, gotoLabel);
			}
			int num = 1024;
			while (pc >= 0 && pc < ops.Count)
			{
				num--;
				if (num <= 0)
				{
					throw new Exception("Max VM runtime");
				}
				SimpleActionOP simpleActionOP = ops[pc];
				int num2 = pc;
				simpleActionOP.run(this);
				if (pc == num2)
				{
					pc++;
				}
			}
			resetVM();
		}

		public void resetVM()
		{
			pc = 0;
			movieClip = null;
		}

		public int getPcForLabel(List<SimpleActionOP> ops, string label)
		{
			for (int i = 0; i < ops.Count; i++)
			{
				if (ops[i] is LabelBlockOP)
				{
					LabelBlockOP labelBlockOP = (LabelBlockOP)ops[i];
					if (labelBlockOP.name == label)
					{
						return i;
					}
				}
			}
			return -1;
		}
	}
}
