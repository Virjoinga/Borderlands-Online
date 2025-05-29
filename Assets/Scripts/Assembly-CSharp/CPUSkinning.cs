using A;
using UnityEngine;

public class CPUSkinning
{
	public static void c2ec7b02fdcee1e679e8188ed9a48329b(SkinnedMeshRenderer c8e591d17d2202086e3c7d3a50ba6c3cf, Mesh c56b619f725ce213e27e56f775bbcb3a8)
	{
		Mesh sharedMesh = c8e591d17d2202086e3c7d3a50ba6c3cf.sharedMesh;
		if (!(sharedMesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Vector3[] c7088de59e49f7108f520cf7e0bae167e = c7e47b2227048cd3c1ab2307c7def8132.c7088de59e49f7108f520cf7e0bae167e;
			if (c56b619f725ce213e27e56f775bbcb3a8.vertices != null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (c56b619f725ce213e27e56f775bbcb3a8.vertices.Length == sharedMesh.vertices.Length)
				{
					c7088de59e49f7108f520cf7e0bae167e = c56b619f725ce213e27e56f775bbcb3a8.vertices;
					goto IL_0085;
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
			}
			c7088de59e49f7108f520cf7e0bae167e = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(sharedMesh.vertices.Length);
			goto IL_0085;
			IL_0085:
			Vector3[] vertices = sharedMesh.vertices;
			BoneWeight[] boneWeights = sharedMesh.boneWeights;
			Matrix4x4[] bindposes = sharedMesh.bindposes;
			Transform[] bones = c8e591d17d2202086e3c7d3a50ba6c3cf.bones;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < vertices.Length; i++)
			{
				c7088de59e49f7108f520cf7e0bae167e[i] = new Vector3(0f, 0f, 0f);
				BoneWeight boneWeight = boneWeights[i];
				if (boneWeight.weight0 > 0f)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					zero = bindposes[boneWeight.boneIndex0].MultiplyPoint3x4(vertices[i]);
					c7088de59e49f7108f520cf7e0bae167e[i] += bones[boneWeight.boneIndex0].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight0;
				}
				if (boneWeight.weight1 > 0f)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					zero = bindposes[boneWeight.boneIndex1].MultiplyPoint3x4(vertices[i]);
					c7088de59e49f7108f520cf7e0bae167e[i] += bones[boneWeight.boneIndex1].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight1;
				}
				if (boneWeight.weight2 > 0f)
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
					zero = bindposes[boneWeight.boneIndex2].MultiplyPoint3x4(vertices[i]);
					c7088de59e49f7108f520cf7e0bae167e[i] += bones[boneWeight.boneIndex2].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight2;
				}
				if (boneWeight.weight3 > 0f)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					zero = bindposes[boneWeight.boneIndex3].MultiplyPoint3x4(vertices[i]);
					c7088de59e49f7108f520cf7e0bae167e[i] += bones[boneWeight.boneIndex3].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight3;
				}
				c7088de59e49f7108f520cf7e0bae167e[i] = c8e591d17d2202086e3c7d3a50ba6c3cf.transform.InverseTransformPoint(c7088de59e49f7108f520cf7e0bae167e[i]);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				c56b619f725ce213e27e56f775bbcb3a8.vertices = c7088de59e49f7108f520cf7e0bae167e;
				c56b619f725ce213e27e56f775bbcb3a8.triangles = sharedMesh.triangles;
				return;
			}
		}
	}

	private static bool c2ec7b02fdcee1e679e8188ed9a48329b(SkinnedMeshRenderer c8e591d17d2202086e3c7d3a50ba6c3cf, int cfac2776a5100c0fe86492daf1c2fa2a3, out Vector3 c029a94b5942658f39272c0a375151e72, bool c3a29a39a42dc50ad3be5f7fee6ab7095)
	{
		bool result = false;
		c029a94b5942658f39272c0a375151e72 = new Vector3(0f, 0f, 0f);
		Mesh sharedMesh = c8e591d17d2202086e3c7d3a50ba6c3cf.sharedMesh;
		if (sharedMesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Vector3[] vertices = sharedMesh.vertices;
			BoneWeight[] boneWeights = sharedMesh.boneWeights;
			Matrix4x4[] bindposes = sharedMesh.bindposes;
			Transform[] bones = c8e591d17d2202086e3c7d3a50ba6c3cf.bones;
			Vector3 zero = Vector3.zero;
			Vector3 v = vertices[cfac2776a5100c0fe86492daf1c2fa2a3];
			BoneWeight boneWeight = boneWeights[cfac2776a5100c0fe86492daf1c2fa2a3];
			if (boneWeight.weight0 >= 0f)
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
				zero = bindposes[boneWeight.boneIndex0].MultiplyPoint3x4(v);
				c029a94b5942658f39272c0a375151e72 += bones[boneWeight.boneIndex0].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight0;
			}
			if (boneWeight.weight1 >= 0f)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				zero = bindposes[boneWeight.boneIndex1].MultiplyPoint3x4(v);
				c029a94b5942658f39272c0a375151e72 += bones[boneWeight.boneIndex1].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight1;
			}
			if (boneWeight.weight2 >= 0f)
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
				zero = bindposes[boneWeight.boneIndex2].MultiplyPoint3x4(v);
				c029a94b5942658f39272c0a375151e72 += bones[boneWeight.boneIndex2].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight2;
			}
			if (boneWeight.weight3 >= 0f)
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
				zero = bindposes[boneWeight.boneIndex3].MultiplyPoint3x4(v);
				c029a94b5942658f39272c0a375151e72 += bones[boneWeight.boneIndex3].localToWorldMatrix.MultiplyPoint3x4(zero) * boneWeight.weight3;
			}
			if (!c3a29a39a42dc50ad3be5f7fee6ab7095)
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
				c029a94b5942658f39272c0a375151e72 = c8e591d17d2202086e3c7d3a50ba6c3cf.transform.InverseTransformPoint(c029a94b5942658f39272c0a375151e72);
			}
			result = true;
		}
		return result;
	}

	public static bool c2ec7b02fdcee1e679e8188ed9a48329b(SkinnedMeshRenderer c8e591d17d2202086e3c7d3a50ba6c3cf, int c973775fef71792c792b3fb533709a7cb, out Vector3 c05ca50bb177e2d44c2b8e11bea8c951b, out Vector3 c84cb353d4eac2c003ebd9daa8026b3f8, out Vector3 c1af7a1b5641e3d18ab41c70b187c232b, bool c3a29a39a42dc50ad3be5f7fee6ab7095)
	{
		bool result = false;
		c05ca50bb177e2d44c2b8e11bea8c951b = new Vector3(0f, 0f, 0f);
		c84cb353d4eac2c003ebd9daa8026b3f8 = new Vector3(0f, 0f, 0f);
		c1af7a1b5641e3d18ab41c70b187c232b = new Vector3(0f, 0f, 0f);
		if (c8e591d17d2202086e3c7d3a50ba6c3cf != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c973775fef71792c792b3fb533709a7cb > 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				Mesh sharedMesh = c8e591d17d2202086e3c7d3a50ba6c3cf.sharedMesh;
				if (sharedMesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c973775fef71792c792b3fb533709a7cb < sharedMesh.triangles.Length / 3)
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
						int[] triangles = c8e591d17d2202086e3c7d3a50ba6c3cf.sharedMesh.triangles;
						if (c2ec7b02fdcee1e679e8188ed9a48329b(c8e591d17d2202086e3c7d3a50ba6c3cf, triangles[3 * c973775fef71792c792b3fb533709a7cb], out c05ca50bb177e2d44c2b8e11bea8c951b, c3a29a39a42dc50ad3be5f7fee6ab7095))
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
							if (c2ec7b02fdcee1e679e8188ed9a48329b(c8e591d17d2202086e3c7d3a50ba6c3cf, triangles[3 * c973775fef71792c792b3fb533709a7cb + 1], out c84cb353d4eac2c003ebd9daa8026b3f8, c3a29a39a42dc50ad3be5f7fee6ab7095))
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
								if (c2ec7b02fdcee1e679e8188ed9a48329b(c8e591d17d2202086e3c7d3a50ba6c3cf, triangles[3 * c973775fef71792c792b3fb533709a7cb + 2], out c1af7a1b5641e3d18ab41c70b187c232b, c3a29a39a42dc50ad3be5f7fee6ab7095))
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											continue;
										}
										break;
									}
									result = true;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}
}
