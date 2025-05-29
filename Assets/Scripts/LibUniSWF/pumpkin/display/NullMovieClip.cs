using pumpkin.swf;

namespace pumpkin.display
{
	public class NullMovieClip : MovieClip
	{
		public NullMovieClip()
		{
		}

		public NullMovieClip(string linkage)
		{
			loadTextures = false;
			initUri(new SwfURI(linkage));
		}
	}
}
