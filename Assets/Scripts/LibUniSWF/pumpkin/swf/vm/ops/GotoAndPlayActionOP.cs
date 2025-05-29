namespace pumpkin.swf.vm.ops
{
	public class GotoAndPlayActionOP : SimpleActionOP
	{
		public string label;

		public int frame = -1;

		public override void run(SimpleActionVM vm)
		{
			if (!string.IsNullOrEmpty(label))
			{
				vm.movieClip.gotoAndPlay(label);
			}
			else if (frame != -1)
			{
				vm.movieClip.gotoAndPlay(frame);
			}
		}
	}
}
