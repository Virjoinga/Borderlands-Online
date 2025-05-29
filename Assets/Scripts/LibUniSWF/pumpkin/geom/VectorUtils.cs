using UnityEngine;

namespace pumpkin.geom
{
	public class VectorUtils
	{
		public static Vector3 RandomClone(Vector3 targetPos, float ex, float ey, float ez)
		{
			return new Vector3(targetPos.x + Random.Range(0f - ex, ex), targetPos.y + Random.Range(0f - ey, ey), targetPos.z + Random.Range(0f - ez, ez));
		}

		public static Vector3 AddToVec(Vector3 origPos, Vector3 other)
		{
			origPos.x += other.x;
			origPos.y += other.y;
			origPos.z += other.z;
			return new Vector3(origPos.x, 0f, origPos.z);
		}

		public static Vector3 Interpolate(Vector3 param1, Vector3 param2, float param3)
		{
			return new Vector3(param2.x + (param1.x - param2.x) * param3, 0f, param2.y + (param1.y - param2.y) * param3);
		}
	}
}
