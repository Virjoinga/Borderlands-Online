using UnityEngine;
using pumpkin.display;

namespace pumpkin.displayInternal
{
	public class MeshGenRenderGroup
	{
		public Rect screenBounds;

		internal FastList<GraphicsDrawOP> drawOps = new FastList<GraphicsDrawOP>();

		public Material material;

		public bool screenBoundsDirty = true;
	}
}
