using UnityEngine;

public static class MathExtensionMethods
{
	public static void ce62cd2a8f9b538cff3ad3698791f2854(this Vector3 cf312a174496712827bd0ffaff85b09ea)
	{
		cf312a174496712827bd0ffaff85b09ea.x = float.NaN;
		cf312a174496712827bd0ffaff85b09ea.y = float.NaN;
		cf312a174496712827bd0ffaff85b09ea.z = float.NaN;
	}

	public static bool c943bc6a18586b3e0e6f0214717aca479(this Vector3 cf312a174496712827bd0ffaff85b09ea)
	{
		if (float.IsNaN(cf312a174496712827bd0ffaff85b09ea.x))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		if (float.IsNaN(cf312a174496712827bd0ffaff85b09ea.y))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (float.IsNaN(cf312a174496712827bd0ffaff85b09ea.z))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}

	public static Vector3 c4066eaf9ef8ccf3bd92b1eb862cae055(Vector3 cd5207bdd32246712d54a176c0daf4b45, Vector3 c92796054b53538d6ad3ca14be8d69eb0, Vector3 c330987c4414f384d6c951ab9f68460d8)
	{
		Vector3 rhs = c330987c4414f384d6c951ab9f68460d8 - cd5207bdd32246712d54a176c0daf4b45;
		rhs.y = 0f;
		if (rhs.sqrMagnitude < float.Epsilon)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return cd5207bdd32246712d54a176c0daf4b45;
				}
			}
		}
		Vector3 vector = c92796054b53538d6ad3ca14be8d69eb0 - cd5207bdd32246712d54a176c0daf4b45;
		vector.y = 0f;
		if (vector.sqrMagnitude < float.Epsilon)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return cd5207bdd32246712d54a176c0daf4b45;
				}
			}
		}
		vector.Normalize();
		float num = Vector3.Dot(vector, rhs);
		if (num <= float.Epsilon)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return cd5207bdd32246712d54a176c0daf4b45;
				}
			}
		}
		float num2 = Vector3.Distance(cd5207bdd32246712d54a176c0daf4b45, c92796054b53538d6ad3ca14be8d69eb0);
		if (num >= num2)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return c92796054b53538d6ad3ca14be8d69eb0;
				}
			}
		}
		return cd5207bdd32246712d54a176c0daf4b45 + vector * num;
	}
}
