using System.Collections.Generic;
using pumpkin.display;
using pumpkin.utils;

namespace pumpkin.swf.vm.ops
{
	public class AddEventListenerOP : SimpleActionOP
	{
		public string target;

		public string eventName;

		public string gotoLabel;

		public override void run(SimpleActionVM vm)
		{
			SimpleActionVM vmRef = vm;
			MovieClip targetRef = vm.movieClip;
			if (!string.IsNullOrEmpty(target))
			{
				targetRef = vm.movieClip.getChildByName<MovieClip>(target);
			}
			List<SimpleActionOP> opsRef = vm.ops;
			SafeHashtable globalsRef = vm.globals;
			if (targetRef != null)
			{
				targetRef.addEventListener(eventName, delegate
				{
					vmRef.runFrame(targetRef, opsRef, gotoLabel, globalsRef);
				});
			}
		}
	}
}
