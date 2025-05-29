namespace pumpkin.swf.vm.ops
{
	public class BlocEndOP : SimpleActionOP
	{
		public override void run(SimpleActionVM vm)
		{
			vm.pc = -1;
		}
	}
}
