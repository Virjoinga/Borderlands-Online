using UnityEngine;

namespace pumpkin.utils
{
	public class Utils
	{
		public static Vector3 randomVectorX(float fromIn, float toInt)
		{
			return new Vector3(Random.Range(fromIn, toInt), 0f, 0f);
		}

		public static Vector3 randomVectorY(float fromIn, float toInt)
		{
			return new Vector3(0f, Random.Range(fromIn, toInt), 0f);
		}

		public static Vector3 randomVectorZ(float fromIn, float toInt)
		{
			return new Vector3(0f, 0f, Random.Range(fromIn, toInt));
		}

		public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
		{
			Quaternion result = default(Quaternion);
			result.w = Mathf.Sqrt(Mathf.Max(0f, 1f + m[0, 0] + m[1, 1] + m[2, 2])) / 2f;
			result.x = Mathf.Sqrt(Mathf.Max(0f, 1f + m[0, 0] - m[1, 1] - m[2, 2])) / 2f;
			result.y = Mathf.Sqrt(Mathf.Max(0f, 1f - m[0, 0] + m[1, 1] - m[2, 2])) / 2f;
			result.z = Mathf.Sqrt(Mathf.Max(0f, 1f - m[0, 0] - m[1, 1] + m[2, 2])) / 2f;
			result.x *= Mathf.Sign(result.x * (m[2, 1] - m[1, 2]));
			result.y *= Mathf.Sign(result.y * (m[0, 2] - m[2, 0]));
			result.z *= Mathf.Sign(result.z * (m[1, 0] - m[0, 1]));
			return result;
		}

		public static Matrix4x4 MatrixFromQuaternion(Quaternion q)
		{
			float num = q.w * q.w;
			float num2 = q.x * q.x;
			float num3 = q.y * q.y;
			float num4 = q.z * q.z;
			Matrix4x4 result = default(Matrix4x4);
			float num5 = 1f / (num2 + num3 + num4 + num);
			result.m00 = (num2 - num3 - num4 + num) * num5;
			result.m11 = (0f - num2 + num3 - num4 + num) * num5;
			result.m22 = (0f - num2 - num3 + num4 + num) * num5;
			float num6 = q.x * q.y;
			float num7 = q.z * q.w;
			result.m10 = 2f * (num6 + num7) * num5;
			result.m01 = 2f * (num6 - num7) * num5;
			num6 = q.x * q.z;
			num7 = q.y * q.w;
			result.m20 = 2f * (num6 - num7) * num5;
			result.m02 = 2f * (num6 + num7) * num5;
			num6 = q.y * q.z;
			num7 = q.x * q.w;
			result.m21 = 2f * (num6 + num7) * num5;
			result.m12 = 2f * (num6 - num7) * num5;
			return result;
		}
	}
}
