namespace BHV
{
	public sealed class BHVTaskParamReload : BHVTaskParamAnimationState
	{
		public BHVTaskParamReload()
		{
			base.m_Type = BHVTaskType.Reload;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}
	}
}
