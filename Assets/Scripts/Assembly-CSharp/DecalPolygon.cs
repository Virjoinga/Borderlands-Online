using System;
using A;
using UnityEngine;

public class DecalPolygon
{
	public int verticeCount;

	public Vector3[] normal;

	public Vector3[] vertice;

	public Vector4[] tangent;

	public DecalPolygon()
	{
		verticeCount = 0;
		vertice = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(9);
		normal = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(9);
		tangent = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(9);
	}

	public DecalPolygon cec9cb9cf17a528b9795669bbc8fc8b30()
	{
		DecalPolygon decalPolygon = new DecalPolygon();
		decalPolygon.verticeCount = verticeCount;
		Array.Copy(normal, decalPolygon.normal, normal.Length);
		Array.Copy(vertice, decalPolygon.vertice, vertice.Length);
		Array.Copy(tangent, decalPolygon.tangent, tangent.Length);
		return decalPolygon;
	}

	public static DecalPolygon cf0a9a3bfee56e76a71a93f682acff18d(DecalPolygon c5d248c0da5c043a398db7fcfdbc7a17d, Vector4 c2f37a802c4a5cf0c05b501206c58800d)
	{
		bool[] array = c35c14691f1fcf4fa571c950aa6395b14.c0a0cdf4a196914163f7334d9b0781a04(10);
		int num = 0;
		Vector3 vector = new Vector3(c2f37a802c4a5cf0c05b501206c58800d.x, c2f37a802c4a5cf0c05b501206c58800d.y, c2f37a802c4a5cf0c05b501206c58800d.z);
		for (int i = 0; i < c5d248c0da5c043a398db7fcfdbc7a17d.verticeCount; i++)
		{
			array[i] = Vector3.Dot(c5d248c0da5c043a398db7fcfdbc7a17d.vertice[i], vector) + c2f37a802c4a5cf0c05b501206c58800d.w < 0f;
			if (!array[i])
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num++;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (num == c5d248c0da5c043a398db7fcfdbc7a17d.verticeCount)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return null;
					}
				}
			}
			if (num == 0)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return c5d248c0da5c043a398db7fcfdbc7a17d;
					}
				}
			}
			DecalPolygon decalPolygon = new DecalPolygon();
			decalPolygon.verticeCount = 0;
			for (int j = 0; j < c5d248c0da5c043a398db7fcfdbc7a17d.verticeCount; j++)
			{
				int num2;
				if (j == 0)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					num2 = c5d248c0da5c043a398db7fcfdbc7a17d.verticeCount - 1;
				}
				else
				{
					num2 = j - 1;
				}
				int num3 = num2;
				if (array[j])
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					if (array[num3])
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					Vector3 vector2 = c5d248c0da5c043a398db7fcfdbc7a17d.vertice[j];
					Vector3 vector3 = c5d248c0da5c043a398db7fcfdbc7a17d.vertice[num3];
					Vector3 normalized = (vector3 - vector2).normalized;
					float num4 = (0f - (Vector3.Dot(vector, vector2) + c2f37a802c4a5cf0c05b501206c58800d.w)) / Vector3.Dot(vector, normalized);
					decalPolygon.tangent[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.tangent[j] + (c5d248c0da5c043a398db7fcfdbc7a17d.tangent[num3] - c5d248c0da5c043a398db7fcfdbc7a17d.tangent[j]).normalized * num4;
					decalPolygon.vertice[decalPolygon.verticeCount] = vector2 + (vector3 - vector2).normalized * num4;
					decalPolygon.normal[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.normal[j] + (c5d248c0da5c043a398db7fcfdbc7a17d.normal[num3] - c5d248c0da5c043a398db7fcfdbc7a17d.normal[j]).normalized * num4;
					decalPolygon.verticeCount++;
					continue;
				}
				if (array[num3])
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					Vector3 vector2 = c5d248c0da5c043a398db7fcfdbc7a17d.vertice[num3];
					Vector3 vector3 = c5d248c0da5c043a398db7fcfdbc7a17d.vertice[j];
					Vector3 normalized = (vector3 - vector2).normalized;
					float num4 = (0f - (Vector3.Dot(vector, vector2) + c2f37a802c4a5cf0c05b501206c58800d.w)) / Vector3.Dot(vector, normalized);
					decalPolygon.tangent[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.tangent[num3] + (c5d248c0da5c043a398db7fcfdbc7a17d.tangent[j] - c5d248c0da5c043a398db7fcfdbc7a17d.tangent[num3]).normalized * num4;
					decalPolygon.vertice[decalPolygon.verticeCount] = vector2 + (vector3 - vector2).normalized * num4;
					decalPolygon.normal[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.normal[num3] + (c5d248c0da5c043a398db7fcfdbc7a17d.normal[j] - c5d248c0da5c043a398db7fcfdbc7a17d.normal[num3]).normalized * num4;
					decalPolygon.verticeCount++;
				}
				decalPolygon.tangent[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.tangent[j];
				decalPolygon.vertice[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.vertice[j];
				decalPolygon.normal[decalPolygon.verticeCount] = c5d248c0da5c043a398db7fcfdbc7a17d.normal[j];
				decalPolygon.verticeCount++;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return decalPolygon;
			}
		}
	}
}
