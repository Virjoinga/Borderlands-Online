using pumpkin.display;

namespace pumpkin.swf.vm.ops
{
	public class StopActionOP : SimpleActionOP
	{
		public string target;

		public override void run(SimpleActionVM vm)
		{
			if (!string.IsNullOrEmpty(target))
			{
				MovieClip childByName = vm.movieClip.getChildByName<MovieClip>(target);
				if (childByName != null)
				{
					childByName.stop();
				}
			}
			else
			{
				vm.movieClip.stop();
			}
		}
	}
}
