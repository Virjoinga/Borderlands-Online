namespace pumpkin.swf.vm.ops
{
	public class GotoAndStopActionOP : SimpleActionOP
	{
		public string label;

		public int frame = -1;

		public override void run(SimpleActionVM vm)
		{
			if (!string.IsNullOrEmpty(label))
			{
				vm.movieClip.gotoAndStop(label);
			}
			else if (frame != -1)
			{
				vm.movieClip.gotoAndStop(frame);
			}
		}
	}
}
