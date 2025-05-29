using UnityEngine;

namespace pumpkin.swf.vm.ops
{
	public class TraceOP : SimpleActionOP
	{
		public string str;

		public override void run(SimpleActionVM vm)
		{
			Debug.Log(str);
		}
	}
}
