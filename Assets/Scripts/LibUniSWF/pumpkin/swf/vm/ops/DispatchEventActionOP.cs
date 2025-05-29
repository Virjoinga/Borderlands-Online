using System.Collections;
using UnityEngine;
using pumpkin.events;

namespace pumpkin.swf.vm.ops
{
	public class DispatchEventActionOP : SimpleActionOP
	{
		public string eventClass = null;

		public IList eventClassArgs;

		public string eventName = null;

		public DispatchEventActionOP()
		{
		}

		public DispatchEventActionOP(string eventName)
		{
			this.eventName = eventName;
		}

		public override void run(SimpleActionVM vm)
		{
			if (!string.IsNullOrEmpty(eventName))
			{
				vm.movieClip.dispatchEvent(new CEvent(eventName));
			}
			else if (eventClass != null)
			{
				Debug.LogError("DispatchEventActionOP.eventClass not implemented!");
			}
		}
	}
}
