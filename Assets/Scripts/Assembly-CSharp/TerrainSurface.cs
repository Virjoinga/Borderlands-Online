using A;
using UnityEngine;

public class TerrainSurface
{
	public static float[] c94b96bc30ec85248bcf02bc308c4069c(Vector3 c8dcaedc408f69d1c0d517b5236596524)
	{
		Terrain activeTerrain = Terrain.activeTerrain;
		TerrainData terrainData = activeTerrain.terrainData;
		Vector3 position = activeTerrain.transform.position;
		int x = (int)((c8dcaedc408f69d1c0d517b5236596524.x - position.x) / terrainData.size.x * (float)terrainData.alphamapWidth);
		int y = (int)((c8dcaedc408f69d1c0d517b5236596524.z - position.z) / terrainData.size.z * (float)terrainData.alphamapHeight);
		float[,,] alphamaps = terrainData.GetAlphamaps(x, y, 1, 1);
		float[] array = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(alphamaps.GetUpperBound(2) + 1);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = alphamaps[0, 0, i];
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return array;
		}
	}

	public static int c6ee4b355cf805828f7629e0dceb124cd(Vector3 c8dcaedc408f69d1c0d517b5236596524)
	{
		float[] array = c94b96bc30ec85248bcf02bc308c4069c(c8dcaedc408f69d1c0d517b5236596524);
		float num = 0f;
		int result = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i] > num))
			{
				continue;
			}
			while (true)
			{
				switch (4)
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
			result = i;
			num = array[i];
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return result;
		}
	}

	public static string ceb12cfea7c4edb5e42a23bef4b595dbc(Vector3 c8dcaedc408f69d1c0d517b5236596524)
	{
		int num = c6ee4b355cf805828f7629e0dceb124cd(c8dcaedc408f69d1c0d517b5236596524);
		Terrain activeTerrain = Terrain.activeTerrain;
		TerrainData terrainData = activeTerrain.terrainData;
		return terrainData.splatPrototypes[num].texture.name;
	}
}
