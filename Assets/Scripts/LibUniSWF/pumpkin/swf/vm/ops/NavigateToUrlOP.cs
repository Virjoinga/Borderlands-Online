using UnityEngine;

namespace pumpkin.swf.vm.ops
{
	public class NavigateToUrlOP : SimpleActionOP
	{
		public string url;

		public override void run(SimpleActionVM vm)
		{
			Application.OpenURL(url);
		}
	}
}
