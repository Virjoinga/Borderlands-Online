namespace pumpkin.display
{
	public class AnimInfo
	{
		public int animId;

		public string name;

		public int[] frameIDs;

		public int totalFrames
		{
			get
			{
				return frameIDs.Length;
			}
		}
	}
}
