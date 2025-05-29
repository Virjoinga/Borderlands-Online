using System;
using UnityEngine;

namespace pumpkin.geom
{
	public class Angle
	{
		protected float m_Rad = 0f;

		protected float m_Deg = 0f;

		public float radians
		{
			get
			{
				return m_Rad;
			}
			set
			{
				m_Rad = value;
				m_Deg = radiansToDegrees(value);
			}
		}

		public float degrees
		{
			get
			{
				return m_Deg;
			}
			set
			{
				m_Deg = value;
				m_Rad = degreesToRadians(value);
			}
		}

		public Angle()
		{
		}

		public Angle(float deg)
		{
			m_Rad = degreesToRadians(deg);
			m_Deg = deg;
		}

		public Vector3 projectPointVector3XZ(float len)
		{
			Vector3 result = default(Vector3);
			result.x = (float)Math.Cos(m_Rad) * len;
			result.z = (float)Math.Sin(m_Rad) * len;
			return result;
		}

		public static float degreesToRadians(float degrees)
		{
			return degrees * (float)Math.PI / 180f;
		}

		public static float radiansToDegrees(float radians)
		{
			return radians * 180f / (float)Math.PI;
		}

		public static float normaliseAngleDeg(float a)
		{
			if (a == 0f)
			{
				return 0f;
			}
			if (a == 360f)
			{
				return 360f;
			}
			if (a < 0f)
			{
				a = Math.Abs(a);
				return 360f - a % 360f;
			}
			if (a < 360f)
			{
				return a;
			}
			return a % 360f;
		}

		public static float angleBetweenDeg(Vector2 v1, Vector2 v2)
		{
			float x = v1.x;
			float y = v1.y;
			float x2 = v2.x;
			float y2 = v2.y;
			return angleBetweenDeg(x, y, x2, y2);
		}

		public static float angleBetweenDeg(float x1, float y1, float x2, float y2)
		{
			float num = (float)Math.Atan2(y2 - y1, x2 - x1);
			return radiansToDegrees(num);
		}
	}
}
