namespace pumpkin.utils
{
	public class Interpolation
	{
		public static float lerpFloat(float startvalue, float endvalue, float l)
		{
			float num = endvalue - startvalue;
			return startvalue + num * l;
		}

		public static int lerpInt(int startvalue, int endvalue, float l)
		{
			int num = endvalue - startvalue;
			return (int)((float)startvalue + (float)num * l);
		}
	}
}
