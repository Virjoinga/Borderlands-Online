using UnityEngine;

namespace pumpkin.swf.vm.ops
{
	public class SetSceneOP : SimpleActionOP
	{
		public string levelName;

		public override void run(SimpleActionVM vm)
		{
			Application.LoadLevel(levelName);
		}
	}
}
