using UnityEngine;

namespace pumpkin.displayInternal
{
	public class SimpleVectorShape
	{
		public bool mouseEnabled = true;

		public Vector2[] vertices;

		public Vector2[] uv;

		public Color[] colors;

		public int[] cachedTriangulatedIndex;

		public void clear()
		{
			vertices = null;
			uv = null;
			colors = null;
			cachedTriangulatedIndex = null;
		}
	}
}
