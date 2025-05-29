namespace pumpkin.swf
{
	public class SwfURI
	{
		public string swf;

		public string linkage;

		public object label;

		public SwfURI()
		{
		}

		public SwfURI(string uri)
		{
			if (uri != null)
			{
				string[] array = uri.Split(":".ToCharArray());
				if (array.Length >= 1)
				{
					swf = array[0];
				}
				if (array.Length >= 2)
				{
					linkage = array[1];
				}
				if (array.Length >= 3)
				{
					label = array[2];
				}
			}
		}
	}
}
