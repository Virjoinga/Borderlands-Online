using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using A;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class MB2_MeshCombiner
	{
		[Serializable]
		private class MB_DynamicGameObject : IComparable<MB_DynamicGameObject>
		{
			public GameObject go;

			public int vertIdx;

			public int numVerts;

			public int bonesIdx;

			public int numBones;

			public int lightmapIndex = -1;

			public Vector4 lightmapTilingOffset = new Vector4(1f, 1f, 0f, 0f);

			public bool show = true;

			public int[] submeshTriIdxs;

			public int[] submeshNumTris;

			public int[] targetSubmeshIdxs;

			public Rect[] uvRects;

			public Rect[] obUVRects;

			public List<int>[] _submeshTris;

			public Mesh sharedMesh;

			public bool _beingDeleted;

			public int _triangleIdxAdjustment;

			public int CompareTo(MB_DynamicGameObject b)
			{
				return vertIdx - b.vertIdx;
			}
		}

		private static bool VERBOSE;

		[SerializeField]
		private bool _doNorm = true;

		[SerializeField]
		private bool _doTan = true;

		[SerializeField]
		private bool _doCol = true;

		[SerializeField]
		private bool _doUV = true;

		[SerializeField]
		private bool _doUV1 = true;

		[SerializeField]
		private int lightmapIndex = -1;

		[SerializeField]
		private bool containsHiddenObjects;

		[SerializeField]
		private List<GameObject> objectsInCombinedMesh = new List<GameObject>();

		[SerializeField]
		private List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh = new List<MB_DynamicGameObject>();

		private Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map = new Dictionary<GameObject, MB_DynamicGameObject>();

		[SerializeField]
		private Vector3[] verts = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Vector3[] normals = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Vector4[] tangents = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Vector2[] uvs = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Vector2[] uv1s = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Vector2[] uv2s = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Color[] colors = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Matrix4x4[] bindPoses = c5cbcfda650d62ede569214a0ac331929.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Transform[] bones = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private Mesh _mesh;

		private int[][] submeshTris = c41f3bbc22d7b0169af0a9d6c34351add.c0a0cdf4a196914163f7334d9b0781a04(0);

		private BoneWeight[] boneWeights = c54e8ccf97efa5ea138175fa6a0d8af02.c0a0cdf4a196914163f7334d9b0781a04(0);

		private GameObject[] empty = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(0);

		[SerializeField]
		private string __name;

		[SerializeField]
		private MB2_TextureBakeResults __textureBakeResults;

		[SerializeField]
		private Renderer __targetRenderer;

		[SerializeField]
		private MB_RenderType __renderType;

		[SerializeField]
		private MB2_OutputOptions __outputOption;

		[SerializeField]
		private MB2_LightmapOptions __lightmapOption;

		[SerializeField]
		private bool __doNorm;

		[SerializeField]
		private bool __doTan;

		[SerializeField]
		private bool __doCol;

		[SerializeField]
		private bool __doUV;

		[SerializeField]
		private bool __doUV1;

		private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

		public static bool EVAL_VERSION
		{
			get
			{
				return false;
			}
		}

		public string name
		{
			get
			{
				return __name;
			}
			set
			{
				__name = value;
			}
		}

		public MB2_TextureBakeResults textureBakeResults
		{
			get
			{
				return __textureBakeResults;
			}
			set
			{
				if (objectsInCombinedMesh.Count > 0)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (__textureBakeResults != value)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						if (__textureBakeResults != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							UnityEngine.Debug.LogWarning("If material bake result is changed then objects currently in combined mesh may be invalid.");
						}
					}
				}
				__textureBakeResults = value;
			}
		}

		public Renderer targetRenderer
		{
			get
			{
				return __targetRenderer;
			}
			set
			{
				__targetRenderer = value;
			}
		}

		public MB_RenderType renderType
		{
			get
			{
				return __renderType;
			}
			set
			{
				if (value == MB_RenderType.skinnedMeshRenderer)
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
					if (__renderType == MB_RenderType.meshRenderer)
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
						if (boneWeights.Length != verts.Length)
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
							UnityEngine.Debug.LogError("Can't set the render type to SkinnedMeshRenderer without clearing the mesh first. Try deleteing the CombinedMesh scene object.");
						}
					}
				}
				__renderType = value;
			}
		}

		public MB2_OutputOptions outputOption
		{
			get
			{
				return __outputOption;
			}
			set
			{
				__outputOption = value;
			}
		}

		public MB2_LightmapOptions lightmapOption
		{
			get
			{
				return __lightmapOption;
			}
			set
			{
				if (objectsInCombinedMesh.Count > 0)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (__lightmapOption != value)
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
						UnityEngine.Debug.LogWarning("Can't change lightmap option once objects are in the combined mesh.");
					}
				}
				__lightmapOption = value;
			}
		}

		public bool doNorm
		{
			get
			{
				return __doNorm;
			}
			set
			{
				__doNorm = value;
			}
		}

		public bool doTan
		{
			get
			{
				return __doTan;
			}
			set
			{
				__doTan = value;
			}
		}

		public bool doCol
		{
			get
			{
				return __doCol;
			}
			set
			{
				__doCol = value;
			}
		}

		public bool doUV
		{
			get
			{
				return __doUV;
			}
			set
			{
				__doUV = value;
			}
		}

		public bool doUV1
		{
			get
			{
				return __doUV1;
			}
			set
			{
				__doUV1 = value;
			}
		}

		private MB_DynamicGameObject instance2Combined_MapGet(GameObject key)
		{
			return _instance2combined_map[key];
		}

		private void instance2Combined_MapAdd(GameObject key, MB_DynamicGameObject dgo)
		{
			_instance2combined_map.Add(key, dgo);
		}

		private void instance2Combined_MapRemove(GameObject key)
		{
			_instance2combined_map.Remove(key);
		}

		private bool instance2Combined_MapTryGetValue(GameObject key, out MB_DynamicGameObject dgo)
		{
			return _instance2combined_map.TryGetValue(key, out dgo);
		}

		private int instance2Combined_MapCount()
		{
			return _instance2combined_map.Count;
		}

		private void instance2Combined_MapClear()
		{
			_instance2combined_map.Clear();
		}

		private bool instance2Combined_MapContainsKey(GameObject key)
		{
			return _instance2combined_map.ContainsKey(key);
		}

		public bool doUV2()
		{
			int result;
			if (lightmapOption != MB2_LightmapOptions.copy_UV2_unchanged)
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
				result = ((lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}

		public int GetNumObjectsInCombined()
		{
			return objectsInCombinedMesh.Count;
		}

		public List<GameObject> GetObjectsInCombined()
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(objectsInCombinedMesh);
			return list;
		}

		public Mesh GetMesh()
		{
			if (_mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				_mesh = new Mesh();
			}
			return _mesh;
		}

		public Transform[] GetBones()
		{
			return bones;
		}

		public int GetLightmapIndex()
		{
			if (lightmapOption != MB2_LightmapOptions.generate_new_UV2_layout)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (lightmapOption != 0)
				{
					return -1;
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
			}
			return lightmapIndex;
		}

		public int GetNumVerticesFor(GameObject go)
		{
			MB_DynamicGameObject dgo = null;
			if (instance2Combined_MapTryGetValue(go, out dgo))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return dgo.numVerts;
					}
				}
			}
			return -1;
		}

		private void _initialize()
		{
			if (objectsInCombinedMesh.Count == 0)
			{
				while (true)
				{
					switch (1)
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
				lightmapIndex = -1;
			}
			if (_mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (VERBOSE)
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
					UnityEngine.Debug.Log("_initialize Creating new Mesh");
				}
				_mesh = new Mesh();
			}
			if (instance2Combined_MapCount() == objectsInCombinedMesh.Count)
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				instance2Combined_MapClear();
				for (int i = 0; i < objectsInCombinedMesh.Count; i++)
				{
					instance2Combined_MapAdd(objectsInCombinedMesh[i], mbDynamicObjectsInCombinedMesh[i]);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					boneWeights = _mesh.boneWeights;
					submeshTris = c41f3bbc22d7b0169af0a9d6c34351add.c0a0cdf4a196914163f7334d9b0781a04(_mesh.subMeshCount);
					for (int j = 0; j < submeshTris.Length; j++)
					{
						submeshTris[j] = _mesh.GetTriangles(j);
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}

		private bool _collectMaterialTriangles(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
		{
			int num = m.subMeshCount;
			if (sharedMaterials.Length < num)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				num = sharedMaterials.Length;
			}
			dgo._submeshTris = c714a99e199a9aa3c75870e87079471d2.c0a0cdf4a196914163f7334d9b0781a04(num);
			dgo.targetSubmeshIdxs = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
			int num2 = 0;
			while (num2 < num)
			{
				dgo._submeshTris[num2] = new List<int>();
				if (textureBakeResults.doMultiMaterial)
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
					if (!sourceMats2submeshIdx_map.Contains(sharedMaterials[num2]))
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
							array[0] = "Object ";
							array[1] = dgo.go;
							array[2] = " has a material that was not found in the result materials maping. ";
							array[3] = sharedMaterials[num2];
							UnityEngine.Debug.LogError(string.Concat(array));
							return false;
						}
					}
					dgo.targetSubmeshIdxs[num2] = (int)sourceMats2submeshIdx_map[sharedMaterials[num2]];
				}
				else
				{
					dgo.targetSubmeshIdxs[num2] = 0;
				}
				List<int> list = dgo._submeshTris[num2];
				int[] triangles = m.GetTriangles(num2);
				for (int i = 0; i < triangles.Length; i++)
				{
					list.Add(triangles[i]);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					if (VERBOSE)
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
						object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
						array2[0] = "Collecting triangles for: ";
						array2[1] = dgo.go.name;
						array2[2] = " submesh:";
						array2[3] = num2;
						array2[4] = " maps to submesh:";
						array2[5] = dgo.targetSubmeshIdxs[num2];
						array2[6] = " added:";
						array2[7] = triangles.Length;
						UnityEngine.Debug.Log(string.Concat(array2));
					}
					num2++;
					break;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return true;
			}
		}

		private bool _collectOutOfBoundsUVRects2(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
		{
			if (textureBakeResults == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						UnityEngine.Debug.LogError("Need to bake textures into combined material");
						return false;
					}
				}
			}
			int num = m.subMeshCount;
			if (sharedMaterials.Length < num)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				num = sharedMaterials.Length;
			}
			dgo.obUVRects = ceb2dc13fc3d1610632a74802c9d18d10.c0a0cdf4a196914163f7334d9b0781a04(num);
			for (int i = 0; i < dgo.obUVRects.Length; i++)
			{
				dgo.obUVRects[i] = new Rect(0f, 0f, 1f, 1f);
			}
			Rect c36964cf41281414170f34ee68bef6c = default(Rect);
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < num; j++)
				{
					cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
					MB_Utility.hasOutOfBoundsUVs(m, ref c36964cf41281414170f34ee68bef6c, j);
					dgo.obUVRects[j] = c36964cf41281414170f34ee68bef6c;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					return true;
				}
			}
		}

		private bool _validateTextureBakeResults()
		{
			if (textureBakeResults == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						UnityEngine.Debug.LogError("Material Bake Results is null. Can't combine meshes.");
						return false;
					}
				}
			}
			if (textureBakeResults.materials != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (textureBakeResults.materials.Length != 0)
				{
					if (textureBakeResults.doMultiMaterial)
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
						if (textureBakeResults.resultMaterials != null)
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
							if (textureBakeResults.resultMaterials.Length != 0)
							{
								goto IL_0101;
							}
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						UnityEngine.Debug.LogError("Material Bake Results has no result materials. Try baking materials. Can't combine meshes.");
						return false;
					}
					if (textureBakeResults.resultMaterial == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("Material Bake Results has no result material. Try baking materials. Can't combine meshes.");
								return false;
							}
						}
					}
					goto IL_0101;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			UnityEngine.Debug.LogError("Material Bake Results has no materials in material to uvRect map. Try baking materials. Can't combine meshes.");
			return false;
			IL_0101:
			return true;
		}

		private bool _validateMeshFlags()
		{
			if (objectsInCombinedMesh.Count > 0)
			{
				while (true)
				{
					switch (1)
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
				if (!_doNorm)
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
					if (doNorm)
					{
						goto IL_00ea;
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
				}
				if (!_doTan)
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
					if (doTan)
					{
						goto IL_00ea;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				if (!_doCol)
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
					if (doCol)
					{
						goto IL_00ea;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				if (!_doUV)
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
					if (doUV)
					{
						goto IL_00ea;
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
				if (!_doUV1)
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
					if (doUV1)
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
						goto IL_00ea;
					}
				}
			}
			_doNorm = doNorm;
			_doTan = doTan;
			_doCol = doCol;
			_doUV = doUV;
			_doUV1 = doUV1;
			return true;
			IL_00ea:
			UnityEngine.Debug.LogError("The channels have changed. There are already objects in the combined mesh that were added with a different set of channels.");
			return false;
		}

		private bool getIsGameObjectActive(GameObject g)
		{
			return g.activeInHierarchy;
		}

		private bool _showHide(GameObject[] goToShow, GameObject[] goToHide)
		{
			if (goToShow == null)
			{
				while (true)
				{
					switch (1)
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
				goToShow = empty;
			}
			if (goToHide == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				goToHide = empty;
			}
			for (int i = 0; i < goToHide.Length; i++)
			{
				if (instance2Combined_MapContainsKey(goToHide[i]))
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
					UnityEngine.Debug.LogWarning(string.Concat("Trying to hide an object ", goToHide[i], " that is not in combined mesh"));
					return false;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < goToShow.Length; j++)
				{
					if (instance2Combined_MapContainsKey(goToShow[j]))
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						UnityEngine.Debug.LogWarning(string.Concat("Trying to show an object ", goToShow[j], " that is not in combined mesh"));
						return false;
					}
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					for (int k = 0; k < goToHide.Length; k++)
					{
						_instance2combined_map[goToHide[k]].show = false;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						for (int l = 0; l < goToShow.Length; l++)
						{
							_instance2combined_map[goToShow[l]].show = true;
						}
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							if (goToShow.Length > 0)
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
								containsHiddenObjects = true;
							}
							return true;
						}
					}
				}
			}
		}

		private bool _addToCombined(GameObject[] goToAdd, GameObject[] goToDelete, bool disableRendererInSource)
		{
			if (!_validateTextureBakeResults())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
			if (!_validateMeshFlags())
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			if (outputOption != MB2_OutputOptions.bakeMeshAssetsInPlace)
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
				if (renderType == MB_RenderType.skinnedMeshRenderer)
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
					if (!(targetRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						if (__targetRenderer is SkinnedMeshRenderer)
						{
							goto IL_00a9;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					UnityEngine.Debug.LogError("Target renderer must be set and must be a SkinnedMeshRenderer");
					return false;
				}
			}
			goto IL_00a9;
			IL_00a9:
			GameObject[] _goToAdd;
			if (goToAdd == null)
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
				_goToAdd = empty;
			}
			else
			{
				_goToAdd = (GameObject[])goToAdd.Clone();
			}
			GameObject[] array;
			if (goToDelete == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				array = empty;
			}
			else
			{
				array = (GameObject[])goToDelete.Clone();
			}
			if (_mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				DestroyMesh();
			}
			Dictionary<Material, Rect> dictionary = textureBakeResults.c745dda41192d9ccb02047a5e2f412016();
			_initialize();
			int num = 1;
			if (textureBakeResults.doMultiMaterial)
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
				num = textureBakeResults.resultMaterials.Length;
			}
			if (VERBOSE)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
				array2[0] = "_addToCombined objs adding:";
				array2[1] = _goToAdd.Length;
				array2[2] = " objs deleting:";
				array2[3] = array.Length;
				array2[4] = " fixOutOfBounds:";
				array2[5] = textureBakeResults.fixOutOfBoundsUVs;
				array2[6] = " doMultiMaterial:";
				array2[7] = textureBakeResults.doMultiMaterial;
				array2[8] = " disableRenderersInSource:";
				array2[9] = disableRendererInSource;
				UnityEngine.Debug.Log(string.Concat(array2));
			}
			OrderedDictionary orderedDictionary = cf63262ca6764ff705c73f08c4830439f.c7088de59e49f7108f520cf7e0bae167e;
			if (textureBakeResults.doMultiMaterial)
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
				orderedDictionary = new OrderedDictionary();
				for (int j = 0; j < num; j++)
				{
					MB_MultiMaterial mB_MultiMaterial = textureBakeResults.resultMaterials[j];
					for (int k = 0; k < mB_MultiMaterial.sourceMaterials.Count; k++)
					{
						if (mB_MultiMaterial.sourceMaterials[k] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									UnityEngine.Debug.LogError("Found null material in source materials for combined mesh materials " + j);
									return false;
								}
							}
						}
						if (orderedDictionary.Contains(mB_MultiMaterial.sourceMaterials[k]))
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
						orderedDictionary.Add(mB_MultiMaterial.sourceMaterials[k], j);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_02eb;
						}
						continue;
						end_IL_02eb:
						break;
					}
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
			}
			if (submeshTris.Length != num)
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
				submeshTris = c41f3bbc22d7b0169af0a9d6c34351add.c0a0cdf4a196914163f7334d9b0781a04(num);
				for (int l = 0; l < submeshTris.Length; l++)
				{
					submeshTris[l] = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(0);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			int num2 = 0;
			int num3 = 0;
			int[] array3 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
			for (int m = 0; m < array.Length; m++)
			{
				MB_DynamicGameObject dgo;
				if (instance2Combined_MapTryGetValue(array[m], out dgo))
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
					num2 += dgo.numVerts;
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						num3 += dgo.numBones;
					}
					for (int n = 0; n < dgo.submeshNumTris.Length; n++)
					{
						array3[n] += dgo.submeshNumTris[n];
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				else
				{
					UnityEngine.Debug.LogWarning("Trying to delete an object that is not in combined mesh");
				}
			}
			Rect c36964cf41281414170f34ee68bef6c2 = default(Rect);
			Vector2 vector3 = default(Vector2);
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
				int num4 = 0;
				int num5 = 0;
				int[] array4 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
				for (int i = 0; i < _goToAdd.Length; i++)
				{
					if (instance2Combined_MapContainsKey(_goToAdd[i]))
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
						if (!Array.Find(array, (GameObject o) => o == _goToAdd[i]))
						{
							UnityEngine.Debug.LogWarning("Object " + _goToAdd[i].name + " has already been added");
							_goToAdd[i] = null;
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
					}
					MB_DynamicGameObject mB_DynamicGameObject = new MB_DynamicGameObject();
					GameObject gameObject = _goToAdd[i];
					Material[] gOMaterials = MB_Utility.GetGOMaterials(gameObject);
					if (gOMaterials == null)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("Object " + gameObject.name + " does not have a Renderer");
								_goToAdd[i] = null;
								return false;
							}
						}
					}
					Mesh mesh = MB_Utility.GetMesh(gameObject);
					if (mesh == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("Object " + gameObject.name + " MeshFilter or SkinedMeshRenderer had no mesh");
								_goToAdd[i] = null;
								return false;
							}
						}
					}
					Rect[] array5 = ceb2dc13fc3d1610632a74802c9d18d10.c0a0cdf4a196914163f7334d9b0781a04(gOMaterials.Length);
					for (int num6 = 0; num6 < gOMaterials.Length; num6++)
					{
						if (dictionary.TryGetValue(gOMaterials[num6], out array5[num6]))
						{
							continue;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
						array6[0] = "Object ";
						array6[1] = gameObject.name;
						array6[2] = " has an unknown material ";
						array6[3] = gOMaterials[num6];
						array6[4] = ". Try baking textures";
						UnityEngine.Debug.LogError(string.Concat(array6));
						_goToAdd[i] = null;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!(_goToAdd[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					mB_DynamicGameObject.go = _goToAdd[i];
					mB_DynamicGameObject.uvRects = array5;
					mB_DynamicGameObject.sharedMesh = mesh;
					mB_DynamicGameObject.numVerts = mesh.vertexCount;
					Renderer renderer = MB_Utility.GetRenderer(mB_DynamicGameObject.go);
					mB_DynamicGameObject.numBones = _getNumBones(renderer);
					if (lightmapIndex == -1)
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
						lightmapIndex = renderer.lightmapIndex;
					}
					if (lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
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
						if (lightmapIndex != renderer.lightmapIndex)
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
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " has a different lightmap index. Lightmapping will not work.");
						}
						if (!getIsGameObjectActive(mB_DynamicGameObject.go))
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
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " is inactive. Can only get lightmap index of active objects.");
						}
						if (renderer.lightmapIndex == -1)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							UnityEngine.Debug.LogWarning("Object " + gameObject.name + " does not have an index to a lightmap.");
						}
					}
					mB_DynamicGameObject.lightmapIndex = renderer.lightmapIndex;
					mB_DynamicGameObject.lightmapTilingOffset = renderer.lightmapTilingOffset;
					if (!_collectMaterialTriangles(mesh, mB_DynamicGameObject, gOMaterials, orderedDictionary))
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return false;
							}
						}
					}
					mB_DynamicGameObject.submeshNumTris = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
					mB_DynamicGameObject.submeshTriIdxs = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
					if (textureBakeResults.fixOutOfBoundsUVs)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!_collectOutOfBoundsUVRects2(mesh, mB_DynamicGameObject, gOMaterials, orderedDictionary))
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									return false;
								}
							}
						}
					}
					list.Add(mB_DynamicGameObject);
					num4 += mB_DynamicGameObject.numVerts;
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						num5 += mB_DynamicGameObject.numBones;
					}
					for (int num7 = 0; num7 < mB_DynamicGameObject._submeshTris.Length; num7++)
					{
						array4[mB_DynamicGameObject.targetSubmeshIdxs[num7]] += mB_DynamicGameObject._submeshTris[num7].Count;
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
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					for (int num8 = 0; num8 < _goToAdd.Length; num8++)
					{
						if (!(_goToAdd[num8] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
						{
							continue;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!disableRendererInSource)
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
						MB_Utility.DisableRendererInSource(_goToAdd[num8]);
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						int num9 = verts.Length + num4 - num2;
						int c36964cf41281414170f34ee68bef6c = bindPoses.Length + num5 - num3;
						int[] array7 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
						if (VERBOSE)
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
							object[] array8 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
							array8[0] = "Verts adding:";
							array8[1] = num4;
							array8[2] = " deleting:";
							array8[3] = num2;
							UnityEngine.Debug.Log(string.Concat(array8));
						}
						if (VERBOSE)
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
							UnityEngine.Debug.Log("Submeshes:" + array7.Length);
						}
						for (int num10 = 0; num10 < array7.Length; num10++)
						{
							array7[num10] = submeshTris[num10].Length + array4[num10] - array3[num10];
							if (!VERBOSE)
							{
								continue;
							}
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							object[] array9 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
							array9[0] = "    submesh :";
							array9[1] = num10;
							array9[2] = " already contains:";
							array9[3] = submeshTris[num10].Length;
							array9[4] = " trisAdded:";
							array9[5] = array4[num10];
							array9[6] = " trisDeleted:";
							array9[7] = array3[num10];
							UnityEngine.Debug.Log(string.Concat(array9));
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							if (num9 > 65534)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										continue;
									}
									UnityEngine.Debug.LogError("Cannot add objects. Resulting mesh will have more than 64k vertices. Try using a Multi-MeshBaker component. This will split the combined mesh into several meshes. You don't have to re-configure the MB2_TextureBaker. Just remove the MB2_MeshBaker component and add a MB2_MultiMeshBaker component.");
									return false;
								}
							}
							Vector3[] destinationArray = c7e47b2227048cd3c1ab2307c7def8132.c7088de59e49f7108f520cf7e0bae167e;
							Vector4[] destinationArray2 = c0e552405175bc23f27c9b62d54b104ac.c7088de59e49f7108f520cf7e0bae167e;
							Vector2[] destinationArray3 = c8019296767fe7de67f2eb557d400d5bb.c7088de59e49f7108f520cf7e0bae167e;
							Vector2[] destinationArray4 = c8019296767fe7de67f2eb557d400d5bb.c7088de59e49f7108f520cf7e0bae167e;
							Vector2[] destinationArray5 = c8019296767fe7de67f2eb557d400d5bb.c7088de59e49f7108f520cf7e0bae167e;
							Color[] destinationArray6 = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
							Vector3[] destinationArray7 = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(num9);
							if (_doNorm)
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
								destinationArray = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(num9);
							}
							if (_doTan)
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
								destinationArray2 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(num9);
							}
							if (_doUV)
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
								destinationArray3 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(num9);
							}
							if (_doUV1)
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
								destinationArray4 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(num9);
							}
							if (lightmapOption != MB2_LightmapOptions.copy_UV2_unchanged)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								if (lightmapOption != 0)
								{
									goto IL_0b8f;
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
							}
							destinationArray5 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(num9);
							goto IL_0b8f;
							IL_0b8f:
							if (_doCol)
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
								destinationArray6 = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(num9);
							}
							BoneWeight[] destinationArray8 = c54e8ccf97efa5ea138175fa6a0d8af02.c0a0cdf4a196914163f7334d9b0781a04(num9);
							Matrix4x4[] array10 = c5cbcfda650d62ede569214a0ac331929.c0a0cdf4a196914163f7334d9b0781a04(c36964cf41281414170f34ee68bef6c);
							Transform[] destinationArray9 = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(c36964cf41281414170f34ee68bef6c);
							int[][] c7088de59e49f7108f520cf7e0bae167e = cef503256561bbc9e326c6458f4ed633f.c7088de59e49f7108f520cf7e0bae167e;
							c7088de59e49f7108f520cf7e0bae167e = c41f3bbc22d7b0169af0a9d6c34351add.c0a0cdf4a196914163f7334d9b0781a04(num);
							for (int num11 = 0; num11 < c7088de59e49f7108f520cf7e0bae167e.Length; num11++)
							{
								c7088de59e49f7108f520cf7e0bae167e[num11] = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(array7[num11]);
							}
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								for (int num12 = 0; num12 < array.Length; num12++)
								{
									MB_DynamicGameObject dgo2 = null;
									if (!instance2Combined_MapTryGetValue(array[num12], out dgo2))
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
									dgo2._beingDeleted = true;
								}
								while (true)
								{
									switch (6)
									{
									case 0:
										continue;
									}
									mbDynamicObjectsInCombinedMesh.Sort();
									int num13 = 0;
									int num14 = 0;
									int[] array11 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(num);
									int num15 = 0;
									int num16 = 0;
									containsHiddenObjects = false;
									for (int num17 = 0; num17 < mbDynamicObjectsInCombinedMesh.Count; num17++)
									{
										MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[num17];
										if (!mB_DynamicGameObject2._beingDeleted)
										{
											while (true)
											{
												switch (1)
												{
												case 0:
													continue;
												}
												break;
											}
											if (VERBOSE)
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
												UnityEngine.Debug.Log("Copying obj in combined arrays idx:" + num17);
											}
											if (!mB_DynamicGameObject2.show)
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
												containsHiddenObjects = true;
											}
											Array.Copy(verts, mB_DynamicGameObject2.vertIdx, destinationArray7, num13, mB_DynamicGameObject2.numVerts);
											if (_doNorm)
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
												Array.Copy(normals, mB_DynamicGameObject2.vertIdx, destinationArray, num13, mB_DynamicGameObject2.numVerts);
											}
											if (_doTan)
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
												Array.Copy(tangents, mB_DynamicGameObject2.vertIdx, destinationArray2, num13, mB_DynamicGameObject2.numVerts);
											}
											if (_doUV)
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
												Array.Copy(uvs, mB_DynamicGameObject2.vertIdx, destinationArray3, num13, mB_DynamicGameObject2.numVerts);
											}
											if (_doUV1)
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
												Array.Copy(uv1s, mB_DynamicGameObject2.vertIdx, destinationArray4, num13, mB_DynamicGameObject2.numVerts);
											}
											if (doUV2())
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
												Array.Copy(uv2s, mB_DynamicGameObject2.vertIdx, destinationArray5, num13, mB_DynamicGameObject2.numVerts);
											}
											if (_doCol)
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
												Array.Copy(colors, mB_DynamicGameObject2.vertIdx, destinationArray6, num13, mB_DynamicGameObject2.numVerts);
											}
											if (renderType == MB_RenderType.skinnedMeshRenderer)
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
												for (int num18 = mB_DynamicGameObject2.vertIdx; num18 < mB_DynamicGameObject2.vertIdx + mB_DynamicGameObject2.numVerts; num18++)
												{
													boneWeights[num18].boneIndex0 = boneWeights[num18].boneIndex0 - num16;
													boneWeights[num18].boneIndex1 = boneWeights[num18].boneIndex1 - num16;
													boneWeights[num18].boneIndex2 = boneWeights[num18].boneIndex2 - num16;
													boneWeights[num18].boneIndex3 = boneWeights[num18].boneIndex3 - num16;
												}
												while (true)
												{
													switch (5)
													{
													case 0:
														continue;
													}
													break;
												}
												Array.Copy(boneWeights, mB_DynamicGameObject2.vertIdx, destinationArray8, num13, mB_DynamicGameObject2.numVerts);
											}
											Array.Copy(bindPoses, mB_DynamicGameObject2.bonesIdx, array10, num14, mB_DynamicGameObject2.numBones);
											Array.Copy(bones, mB_DynamicGameObject2.bonesIdx, destinationArray9, num14, mB_DynamicGameObject2.numBones);
											for (int num19 = 0; num19 < num; num19++)
											{
												int[] array12 = submeshTris[num19];
												int num20 = mB_DynamicGameObject2.submeshTriIdxs[num19];
												int num21 = mB_DynamicGameObject2.submeshNumTris[num19];
												if (VERBOSE)
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
													object[] array13 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
													array13[0] = "    Adjusting submesh triangles submesh:";
													array13[1] = num19;
													array13[2] = " startIdx:";
													array13[3] = num20;
													array13[4] = " num:";
													array13[5] = num21;
													UnityEngine.Debug.Log(string.Concat(array13));
												}
												for (int num22 = num20; num22 < num20 + num21; num22++)
												{
													array12[num22] -= num15;
												}
												while (true)
												{
													switch (2)
													{
													case 0:
														break;
													default:
														goto end_IL_100f;
													}
													continue;
													end_IL_100f:
													break;
												}
												Array.Copy(array12, num20, c7088de59e49f7108f520cf7e0bae167e[num19], array11[num19], num21);
											}
											while (true)
											{
												switch (5)
												{
												case 0:
													continue;
												}
												break;
											}
											mB_DynamicGameObject2.bonesIdx = num14;
											mB_DynamicGameObject2.vertIdx = num13;
											for (int num23 = 0; num23 < array11.Length; num23++)
											{
												mB_DynamicGameObject2.submeshTriIdxs[num23] = array11[num23];
												array11[num23] += mB_DynamicGameObject2.submeshNumTris[num23];
											}
											while (true)
											{
												switch (3)
												{
												case 0:
													continue;
												}
												break;
											}
											num14 += mB_DynamicGameObject2.numBones;
											num13 += mB_DynamicGameObject2.numVerts;
											continue;
										}
										if (VERBOSE)
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
											UnityEngine.Debug.Log("Not copying obj: " + num17);
										}
										num15 += mB_DynamicGameObject2.numVerts;
										num16 += mB_DynamicGameObject2.numBones;
									}
									while (true)
									{
										switch (4)
										{
										case 0:
											continue;
										}
										for (int num24 = mbDynamicObjectsInCombinedMesh.Count - 1; num24 >= 0; num24--)
										{
											if (mbDynamicObjectsInCombinedMesh[num24]._beingDeleted)
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
												instance2Combined_MapRemove(mbDynamicObjectsInCombinedMesh[num24].go);
												objectsInCombinedMesh.RemoveAt(num24);
												mbDynamicObjectsInCombinedMesh.RemoveAt(num24);
											}
										}
										while (true)
										{
											switch (7)
											{
											case 0:
												continue;
											}
											verts = destinationArray7;
											if (_doNorm)
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
												normals = destinationArray;
											}
											if (_doTan)
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
												tangents = destinationArray2;
											}
											if (_doUV)
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
												uvs = destinationArray3;
											}
											if (_doUV1)
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
												uv1s = destinationArray4;
											}
											if (doUV2())
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
												uv2s = destinationArray5;
											}
											if (_doCol)
											{
												while (true)
												{
													switch (1)
													{
													case 0:
														continue;
													}
													break;
												}
												colors = destinationArray6;
											}
											if (renderType == MB_RenderType.skinnedMeshRenderer)
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
												boneWeights = destinationArray8;
											}
											bindPoses = array10;
											bones = destinationArray9;
											submeshTris = c7088de59e49f7108f520cf7e0bae167e;
											int num25 = 0;
											while (num25 < list.Count)
											{
												MB_DynamicGameObject mB_DynamicGameObject3 = list[num25];
												GameObject go = mB_DynamicGameObject3.go;
												int num26 = num13;
												int num27 = num14;
												Mesh sharedMesh = mB_DynamicGameObject3.sharedMesh;
												Matrix4x4 localToWorldMatrix = go.transform.localToWorldMatrix;
												Quaternion rotation = go.transform.rotation;
												destinationArray7 = sharedMesh.vertices;
												Vector3[] array14 = c7e47b2227048cd3c1ab2307c7def8132.c7088de59e49f7108f520cf7e0bae167e;
												Vector4[] array15 = c0e552405175bc23f27c9b62d54b104ac.c7088de59e49f7108f520cf7e0bae167e;
												if (_doNorm)
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
													array14 = _getMeshNormals(sharedMesh);
												}
												if (_doTan)
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
													array15 = _getMeshTangents(sharedMesh);
												}
												if (renderType != MB_RenderType.skinnedMeshRenderer)
												{
													while (true)
													{
														switch (1)
														{
														case 0:
															continue;
														}
														break;
													}
													for (int num28 = 0; num28 < destinationArray7.Length; num28++)
													{
														destinationArray7[num28] = localToWorldMatrix.MultiplyPoint(destinationArray7[num28]);
														if (_doNorm)
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
															array14[num28] = rotation * array14[num28];
														}
														if (!_doTan)
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
														float w = array15[num28].w;
														array15[num28] = rotation * array15[num28];
														array15[num28].w = w;
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
												}
												if (_doNorm)
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
													array14.CopyTo(normals, num26);
												}
												if (_doTan)
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
													array15.CopyTo(tangents, num26);
												}
												destinationArray7.CopyTo(verts, num26);
												int subMeshCount = sharedMesh.subMeshCount;
												if (mB_DynamicGameObject3.uvRects.Length < subMeshCount)
												{
													while (true)
													{
														switch (1)
														{
														case 0:
															continue;
														}
														break;
													}
													UnityEngine.Debug.LogWarning("Mesh " + mB_DynamicGameObject3.go.name + " has more submeshes than materials");
													subMeshCount = mB_DynamicGameObject3.uvRects.Length;
												}
												else if (mB_DynamicGameObject3.uvRects.Length > subMeshCount)
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
													UnityEngine.Debug.LogWarning("Mesh " + mB_DynamicGameObject3.go.name + " has fewer submeshes than materials");
												}
												if (_doUV)
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
													destinationArray3 = _getMeshUVs(sharedMesh);
													int[] array16 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(destinationArray3.Length);
													for (int num29 = 0; num29 < array16.Length; num29++)
													{
														array16[num29] = -1;
													}
													while (true)
													{
														switch (7)
														{
														case 0:
															continue;
														}
														break;
													}
													bool flag = false;
													cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c2);
													for (int num30 = 0; num30 < mB_DynamicGameObject3._submeshTris.Length; num30++)
													{
														List<int> list2 = mB_DynamicGameObject3._submeshTris[num30];
														Rect rect = mB_DynamicGameObject3.uvRects[num30];
														if (textureBakeResults.fixOutOfBoundsUVs)
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
															c36964cf41281414170f34ee68bef6c2 = mB_DynamicGameObject3.obUVRects[num30];
														}
														for (int num31 = 0; num31 < list2.Count; num31++)
														{
															int num32 = list2[num31];
															if (array16[num32] == -1)
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
																array16[num32] = num30;
																if (textureBakeResults.fixOutOfBoundsUVs)
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
																	destinationArray3[num32].x = destinationArray3[num32].x / c36964cf41281414170f34ee68bef6c2.width - c36964cf41281414170f34ee68bef6c2.x / c36964cf41281414170f34ee68bef6c2.width;
																	destinationArray3[num32].y = destinationArray3[num32].y / c36964cf41281414170f34ee68bef6c2.height - c36964cf41281414170f34ee68bef6c2.y / c36964cf41281414170f34ee68bef6c2.height;
																}
																destinationArray3[num32].x = rect.x + destinationArray3[num32].x * rect.width;
																destinationArray3[num32].y = rect.y + destinationArray3[num32].y * rect.height;
															}
															if (array16[num32] == num30)
															{
																continue;
															}
															while (true)
															{
																switch (3)
																{
																case 0:
																	continue;
																}
																break;
															}
															flag = true;
														}
														while (true)
														{
															switch (6)
															{
															case 0:
																break;
															default:
																goto end_IL_16f0;
															}
															continue;
															end_IL_16f0:
															break;
														}
													}
													while (true)
													{
														switch (3)
														{
														case 0:
															continue;
														}
														break;
													}
													if (flag)
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
														UnityEngine.Debug.LogWarning(mB_DynamicGameObject3.go.name + "has submeshes which share verticies. Adjusted uvs may not map correctly in combined atlas.");
													}
													destinationArray3.CopyTo(uvs, num26);
												}
												if (doUV2())
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
													destinationArray5 = _getMeshUV2s(sharedMesh);
													if (lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
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
														Vector4 lightmapTilingOffset = mB_DynamicGameObject3.lightmapTilingOffset;
														Vector2 vector = new Vector2(lightmapTilingOffset.x, lightmapTilingOffset.y);
														Vector2 vector2 = new Vector2(lightmapTilingOffset.z, lightmapTilingOffset.w);
														for (int num33 = 0; num33 < destinationArray5.Length; num33++)
														{
															vector3.x = vector.x * destinationArray5[num33].x;
															vector3.y = vector.y * destinationArray5[num33].y;
															destinationArray5[num33] = vector2 + vector3;
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
													destinationArray5.CopyTo(uv2s, num26);
												}
												if (_doUV1)
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
													destinationArray4 = _getMeshUV1s(sharedMesh);
													destinationArray4.CopyTo(uv1s, num26);
												}
												if (_doCol)
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
													destinationArray6 = _getMeshColors(sharedMesh);
													destinationArray6.CopyTo(colors, num26);
												}
												if (renderType == MB_RenderType.skinnedMeshRenderer)
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
													Renderer renderer2 = MB_Utility.GetRenderer(mB_DynamicGameObject3.go);
													destinationArray9 = _getBones(renderer2);
													destinationArray9.CopyTo(bones, num27);
													array10 = _getBindPoses(renderer2);
													array10.CopyTo(bindPoses, num27);
													destinationArray8 = _getBoneWeights(renderer2, mB_DynamicGameObject3.numVerts);
													for (int num34 = 0; num34 < destinationArray8.Length; num34++)
													{
														destinationArray8[num34].boneIndex0 = destinationArray8[num34].boneIndex0 + num27;
														destinationArray8[num34].boneIndex1 = destinationArray8[num34].boneIndex1 + num27;
														destinationArray8[num34].boneIndex2 = destinationArray8[num34].boneIndex2 + num27;
														destinationArray8[num34].boneIndex3 = destinationArray8[num34].boneIndex3 + num27;
													}
													while (true)
													{
														switch (3)
														{
														case 0:
															continue;
														}
														break;
													}
													destinationArray8.CopyTo(boneWeights, num26);
												}
												for (int num35 = 0; num35 < array11.Length; num35++)
												{
													mB_DynamicGameObject3.submeshTriIdxs[num35] = array11[num35];
												}
												while (true)
												{
													switch (2)
													{
													case 0:
														continue;
													}
													for (int num36 = 0; num36 < mB_DynamicGameObject3._submeshTris.Length; num36++)
													{
														List<int> list3 = mB_DynamicGameObject3._submeshTris[num36];
														for (int num37 = 0; num37 < list3.Count; num37++)
														{
															list3[num37] += num26;
														}
														while (true)
														{
															switch (6)
															{
															case 0:
																break;
															default:
																goto end_IL_1a32;
															}
															continue;
															end_IL_1a32:
															break;
														}
														int num38 = mB_DynamicGameObject3.targetSubmeshIdxs[num36];
														list3.CopyTo(submeshTris[num38], array11[num38]);
														mB_DynamicGameObject3.submeshNumTris[num38] += list3.Count;
														array11[num38] += list3.Count;
													}
													while (true)
													{
														switch (6)
														{
														case 0:
															continue;
														}
														mB_DynamicGameObject3.vertIdx = num13;
														mB_DynamicGameObject3.bonesIdx = num14;
														instance2Combined_MapAdd(go, mB_DynamicGameObject3);
														objectsInCombinedMesh.Add(go);
														mbDynamicObjectsInCombinedMesh.Add(mB_DynamicGameObject3);
														num13 += destinationArray7.Length;
														num14 += array10.Length;
														for (int num39 = 0; num39 < mB_DynamicGameObject3._submeshTris.Length; num39++)
														{
															mB_DynamicGameObject3._submeshTris[num39].Clear();
														}
														while (true)
														{
															switch (4)
															{
															case 0:
																continue;
															}
															mB_DynamicGameObject3._submeshTris = cc902576e473ed325d4419ec13396f500.c7088de59e49f7108f520cf7e0bae167e;
															if (VERBOSE)
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
																object[] array17 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
																array17[0] = "Added to combined:";
																array17[1] = mB_DynamicGameObject3.go.name;
																array17[2] = " verts:";
																array17[3] = destinationArray7.Length;
																UnityEngine.Debug.Log(string.Concat(array17));
															}
															num25++;
															break;
														}
														break;
													}
													break;
												}
											}
											while (true)
											{
												switch (6)
												{
												case 0:
													continue;
												}
												return true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private Color[] _getMeshColors(Mesh m)
		{
			Color[] array = m.colors;
			if (array.Length == 0)
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
				if (VERBOSE)
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
					UnityEngine.Debug.Log(string.Concat("Mesh ", m, " has no colors. Generating"));
				}
				if (_doCol)
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
					UnityEngine.Debug.LogWarning(string.Concat("Mesh ", m, " didn't have colors. Generating an array of white colors"));
				}
				array = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(m.vertexCount);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Color.white;
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
			}
			return array;
		}

		private Vector3[] _getMeshNormals(Mesh m)
		{
			Vector3[] array = m.normals;
			if (array.Length == 0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (VERBOSE)
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
					UnityEngine.Debug.Log(string.Concat("Mesh ", m, " has no normals. Generating"));
				}
				UnityEngine.Debug.LogWarning(string.Concat("Mesh ", m, " didn't have normals. Generating normals."));
				Mesh mesh = (Mesh)UnityEngine.Object.Instantiate(m);
				mesh.RecalculateNormals();
				array = mesh.normals;
				MB_Utility.Destroy(mesh);
			}
			return array;
		}

		private Vector4[] _getMeshTangents(Mesh m)
		{
			Vector4[] array = m.tangents;
			if (array.Length == 0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (VERBOSE)
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
					UnityEngine.Debug.Log(string.Concat("Mesh ", m, " has no tangents. Generating"));
				}
				UnityEngine.Debug.LogWarning(string.Concat("Mesh ", m, " didn't have tangents. Generating tangents."));
				Vector3[] vertices = m.vertices;
				Vector2[] array2 = _getMeshUVs(m);
				Vector3[] array3 = _getMeshNormals(m);
				array = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(m.vertexCount);
				for (int i = 0; i < m.subMeshCount; i++)
				{
					int[] triangles = m.GetTriangles(i);
					_generateTangents(triangles, vertices, array2, array3, array);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return array;
		}

		private Vector2[] _getMeshUVs(Mesh m)
		{
			Vector2[] array = m.uv;
			if (array.Length == 0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (VERBOSE)
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
					UnityEngine.Debug.Log(string.Concat("Mesh ", m, " has no uvs. Generating"));
				}
				UnityEngine.Debug.LogWarning(string.Concat("Mesh ", m, " didn't have uvs. Generating uvs."));
				array = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(m.vertexCount);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return array;
		}

		private Vector2[] _getMeshUV1s(Mesh m)
		{
			Vector2[] array = m.uv1;
			if (array.Length == 0)
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
				if (VERBOSE)
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
					UnityEngine.Debug.Log(string.Concat("Mesh ", m, " has no uv1s. Generating"));
				}
				UnityEngine.Debug.LogWarning(string.Concat("Mesh ", m, " didn't have uv1s. Generating uv1s."));
				array = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(m.vertexCount);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return array;
		}

		private Vector2[] _getMeshUV2s(Mesh m)
		{
			Vector2[] array = m.uv2;
			if (array.Length == 0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (VERBOSE)
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
					UnityEngine.Debug.Log(string.Concat("Mesh ", m, " has no uv2s. Generating"));
				}
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
				array2[0] = "Mesh ";
				array2[1] = m;
				array2[2] = " didn't have uv2s. Lightmapping option was set to ";
				array2[3] = lightmapOption;
				array2[4] = " Generating uv2s.";
				UnityEngine.Debug.LogWarning(string.Concat(array2));
				array = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(m.vertexCount);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
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
			return array;
		}

		public void UpdateSkinnedMeshApproximateBounds()
		{
			if (outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBounds when output type is bakeMeshAssetsInPlace");
						return;
					}
				}
			}
			if (bones.Length == 0)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogWarning("No bones in SkinnedMeshRenderer. Could not UpdateSkinnedMeshApproximateBounds.");
						return;
					}
				}
			}
			if (targetRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogWarning("Target Renderer is not set. No point in calling UpdateSkinnedMeshApproximateBounds.");
						return;
					}
				}
			}
			if (!__targetRenderer.GetType().Equals(Type.GetTypeFromHandle(cefddc9ae252afb84084ead2b0a04d70e.cc1720d05c75832f704b87474932341c3())))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogWarning("Target Renderer is not a SkinnedMeshRenderer. No point in calling UpdateSkinnedMeshApproximateBounds.");
						return;
					}
				}
			}
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)targetRenderer;
			Vector3 position = bones[0].position;
			Vector3 position2 = bones[0].position;
			for (int i = 1; i < bones.Length; i++)
			{
				Vector3 position3 = bones[i].position;
				if (position3.x < position2.x)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					position2.x = position3.x;
				}
				if (position3.y < position2.y)
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
					position2.y = position3.y;
				}
				if (position3.z < position2.z)
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
					position2.z = position3.z;
				}
				if (position3.x > position.x)
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
					position.x = position3.x;
				}
				if (position3.y > position.y)
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
					position.y = position3.y;
				}
				if (!(position3.z > position.z))
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
				position.z = position3.z;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				Vector3 vector = (position + position2) / 2f;
				Vector3 vector2 = position - position2;
				Matrix4x4 worldToLocalMatrix = skinnedMeshRenderer.worldToLocalMatrix;
				Bounds localBounds = new Bounds(worldToLocalMatrix * vector, worldToLocalMatrix * vector2);
				skinnedMeshRenderer.localBounds = localBounds;
				return;
			}
		}

		private int _getNumBones(Renderer r)
		{
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (r is SkinnedMeshRenderer)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									return ((SkinnedMeshRenderer)r).bones.Length;
								}
							}
						}
						if (r is MeshRenderer)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									return 1;
								}
							}
						}
						UnityEngine.Debug.LogError("Could not _getNumBones. Object does not have a renderer");
						return 0;
					}
				}
			}
			return 0;
		}

		private Transform[] _getBones(Renderer r)
		{
			if (r is SkinnedMeshRenderer)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return ((SkinnedMeshRenderer)r).bones;
					}
				}
			}
			if (r is MeshRenderer)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						Transform[] array = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(1);
						array[0] = r.transform;
						return array;
					}
					}
				}
			}
			UnityEngine.Debug.LogError("Could not getBones. Object does not have a renderer");
			return null;
		}

		private Matrix4x4[] _getBindPoses(Renderer r)
		{
			if (r is SkinnedMeshRenderer)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return ((SkinnedMeshRenderer)r).sharedMesh.bindposes;
					}
				}
			}
			if (r is MeshRenderer)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
					{
						Matrix4x4 identity = Matrix4x4.identity;
						Matrix4x4[] array = c5cbcfda650d62ede569214a0ac331929.c0a0cdf4a196914163f7334d9b0781a04(1);
						array[0] = identity;
						return array;
					}
					}
				}
			}
			UnityEngine.Debug.LogError("Could not _getBindPoses. Object does not have a renderer");
			return null;
		}

		private BoneWeight[] _getBoneWeights(Renderer r, int numVerts)
		{
			if (r is SkinnedMeshRenderer)
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
						return ((SkinnedMeshRenderer)r).sharedMesh.boneWeights;
					}
				}
			}
			BoneWeight c36964cf41281414170f34ee68bef6c = default(BoneWeight);
			if (r is MeshRenderer)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
					{
						c991d558a9132dbb1ca98e70401827cec.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
						int num2 = (c36964cf41281414170f34ee68bef6c.boneIndex3 = 0);
						num2 = (c36964cf41281414170f34ee68bef6c.boneIndex2 = num2);
						num2 = (c36964cf41281414170f34ee68bef6c.boneIndex1 = num2);
						c36964cf41281414170f34ee68bef6c.boneIndex0 = num2;
						c36964cf41281414170f34ee68bef6c.weight0 = 1f;
						float num6 = (c36964cf41281414170f34ee68bef6c.weight3 = 0f);
						num6 = (c36964cf41281414170f34ee68bef6c.weight2 = num6);
						c36964cf41281414170f34ee68bef6c.weight1 = num6;
						BoneWeight[] array = c54e8ccf97efa5ea138175fa6a0d8af02.c0a0cdf4a196914163f7334d9b0781a04(numVerts);
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = c36964cf41281414170f34ee68bef6c;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return array;
							}
						}
					}
					}
				}
			}
			UnityEngine.Debug.LogError("Could not _getBoneWeights. Object does not have a renderer");
			return null;
		}

		public void Apply()
		{
			bool flag = false;
			if (renderType == MB_RenderType.skinnedMeshRenderer)
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
				flag = true;
			}
			Apply(true, true, _doNorm, _doTan, _doUV, _doCol, _doUV1, doUV2(), flag);
		}

		public void ApplyShowHide()
		{
			if (_mesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						_mesh.Clear(true);
						_mesh.vertices = verts;
						int[][] submeshTrisWithShowHideApplied = GetSubmeshTrisWithShowHideApplied();
						if (textureBakeResults.doMultiMaterial)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
								{
									_mesh.subMeshCount = submeshTrisWithShowHideApplied.Length;
									for (int i = 0; i < submeshTrisWithShowHideApplied.Length; i++)
									{
										_mesh.SetTriangles(submeshTrisWithShowHideApplied[i], i);
									}
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											return;
										}
									}
								}
								}
							}
						}
						_mesh.triangles = submeshTrisWithShowHideApplied[0];
						return;
					}
					}
				}
			}
			UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling ApplyShowHide");
		}

		[Obsolete("ApplyAll is deprecated, please use Apply instead.")]
		public void ApplyAll()
		{
			Apply(true, true, _doNorm, _doTan, _doUV, _doCol, _doUV1, doUV2(), true);
		}

		public void Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool colors, bool uv1, bool uv2, bool bones = false)
		{
			if (_mesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					bool flag;
					switch (3)
					{
					case 0:
						break;
					default:
						{
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							if (!triangles)
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
								if (_mesh.vertexCount == verts.Length)
								{
									goto IL_00f9;
								}
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
							}
							if (triangles)
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
								if (!vertices)
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
									if (!normals)
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
										if (!tangents)
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
											if (!uvs)
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
												if (!colors)
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
													if (!uv1)
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
														if (!uv2)
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
															if (!bones)
															{
																while (true)
																{
																	switch (1)
																	{
																	case 0:
																		continue;
																	}
																	break;
																}
																_mesh.Clear(true);
																goto IL_00f9;
															}
														}
													}
												}
											}
										}
									}
								}
							}
							_mesh.Clear(false);
							goto IL_00f9;
						}
						IL_00f9:
						if (vertices)
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
							_mesh.vertices = verts;
						}
						if (triangles)
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
							int[][] submeshTrisWithShowHideApplied = GetSubmeshTrisWithShowHideApplied();
							if (textureBakeResults.doMultiMaterial)
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
								_mesh.subMeshCount = submeshTrisWithShowHideApplied.Length;
								for (int i = 0; i < submeshTrisWithShowHideApplied.Length; i++)
								{
									_mesh.SetTriangles(submeshTrisWithShowHideApplied[i], i);
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
							else
							{
								_mesh.triangles = submeshTrisWithShowHideApplied[0];
							}
						}
						if (normals)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							if (_doNorm)
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
								_mesh.normals = this.normals;
							}
							else
							{
								UnityEngine.Debug.LogError("normal flag was set in Apply but MeshBaker didn't generate normals");
							}
						}
						if (tangents)
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
							if (_doTan)
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
								_mesh.tangents = this.tangents;
							}
							else
							{
								UnityEngine.Debug.LogError("tangent flag was set in Apply but MeshBaker didn't generate tangents");
							}
						}
						if (uvs)
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
							if (_doUV)
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
								_mesh.uv = this.uvs;
							}
							else
							{
								UnityEngine.Debug.LogError("uv flag was set in Apply but MeshBaker didn't generate uvs");
							}
						}
						if (colors)
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
							if (_doCol)
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
								_mesh.colors = this.colors;
							}
							else
							{
								UnityEngine.Debug.LogError("color flag was set in Apply but MeshBaker didn't generate colors");
							}
						}
						if (uv1)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							if (_doUV1)
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
								_mesh.uv1 = uv1s;
							}
							else
							{
								UnityEngine.Debug.LogError("uv1 flag was set in Apply but MeshBaker didn't generate uv1s");
							}
						}
						if (uv2)
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
							if (doUV2())
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
								_mesh.uv2 = uv2s;
							}
							else
							{
								UnityEngine.Debug.LogError("uv2 flag was set in Apply but lightmapping option was set to " + lightmapOption);
							}
						}
						flag = false;
						if (renderType != MB_RenderType.skinnedMeshRenderer)
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
							if (lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
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
								if (!flag)
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
									UnityEngine.Debug.LogError("Failed to generate new UV2 layout. Only works in editor.");
								}
							}
						}
						if (renderType == MB_RenderType.skinnedMeshRenderer)
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
							if (verts.Length == 0)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								targetRenderer.enabled = false;
							}
							else
							{
								targetRenderer.enabled = true;
							}
						}
						if (bones)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							_mesh.bindposes = bindPoses;
							_mesh.boneWeights = boneWeights;
						}
						if (!triangles)
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
							if (!vertices)
							{
								return;
							}
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						_mesh.RecalculateBounds();
						return;
					}
				}
			}
			UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling Apply or ApplyAll");
		}

		public int[][] GetSubmeshTrisWithShowHideApplied()
		{
			if (containsHiddenObjects)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(submeshTris.Length);
						int[][] array2 = c41f3bbc22d7b0169af0a9d6c34351add.c0a0cdf4a196914163f7334d9b0781a04(submeshTris.Length);
						for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
						{
							MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[i];
							if (mB_DynamicGameObject.show)
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
								for (int j = 0; j < mB_DynamicGameObject.submeshNumTris.Length; j++)
								{
									array[j] += mB_DynamicGameObject.submeshNumTris[j];
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
							}
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
							{
								for (int k = 0; k < array2.Length; k++)
								{
									array2[k] = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(array[k]);
								}
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
									{
										int[] array3 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(array2.Length);
										for (int l = 0; l < mbDynamicObjectsInCombinedMesh.Count; l++)
										{
											MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[l];
											if (mB_DynamicGameObject2.show)
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
												for (int m = 0; m < submeshTris.Length; m++)
												{
													int[] array4 = submeshTris[m];
													int num = mB_DynamicGameObject2.submeshTriIdxs[m];
													int num2 = num + mB_DynamicGameObject2.submeshNumTris[m];
													for (int n = num; n < num2; n++)
													{
														array2[m][array3[m]] = array4[n];
														array3[m]++;
													}
													while (true)
													{
														switch (6)
														{
														case 0:
															break;
														default:
															goto end_IL_0175;
														}
														continue;
														end_IL_0175:
														break;
													}
												}
												while (true)
												{
													switch (1)
													{
													case 0:
														continue;
													}
													break;
												}
											}
										}
										while (true)
										{
											switch (5)
											{
											case 0:
												break;
											default:
												return array2;
											}
										}
									}
									}
								}
							}
							}
						}
					}
					}
				}
			}
			return submeshTris;
		}

		public void UpdateGameObjects(GameObject[] gos, bool recalcBounds = true)
		{
			_updateGameObjects(gos, recalcBounds);
		}

		private void _updateGameObjects(GameObject[] gos, bool recalcBounds)
		{
			_initialize();
			for (int i = 0; i < gos.Length; i++)
			{
				_updateGameObject(gos[i], false);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!recalcBounds)
				{
					return;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					_mesh.RecalculateBounds();
					return;
				}
			}
		}

		private void _updateGameObject(GameObject go, bool recalcBounds)
		{
			MB_DynamicGameObject dgo = null;
			if (!instance2Combined_MapTryGetValue(go, out dgo))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						UnityEngine.Debug.LogError("Object " + go.name + " has not been added");
						return;
					}
				}
			}
			Mesh sharedMesh = dgo.sharedMesh;
			if (dgo.numVerts != sharedMesh.vertexCount)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogError("Object " + go.name + " source mesh has been modified since being added");
						return;
					}
				}
			}
			Matrix4x4 localToWorldMatrix = go.transform.localToWorldMatrix;
			Quaternion rotation = go.transform.rotation;
			Vector3[] vertices = sharedMesh.vertices;
			Vector3[] array = sharedMesh.normals;
			Vector4[] array2 = sharedMesh.tangents;
			for (int i = 0; i < vertices.Length; i++)
			{
				int num = dgo.vertIdx + i;
				verts[num] = localToWorldMatrix.MultiplyPoint3x4(vertices[i]);
				if (_doNorm)
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
					normals[num] = rotation * array[i];
				}
				if (!_doTan)
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				float w = array2[i].w;
				tangents[num] = rotation * array2[i];
				tangents[num].w = w;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}

		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs)
		{
			return AddDeleteGameObjects(gos, deleteGOs, true, textureBakeResults.fixOutOfBoundsUVs);
		}

		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource)
		{
			return AddDeleteGameObjects(gos, deleteGOs, disableRendererInSource, textureBakeResults.fixOutOfBoundsUVs);
		}

		public bool ShowHideGameObjects(GameObject[] toShow, GameObject[] toHide)
		{
			return _showHide(toShow, toHide);
		}

		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource, bool fixOutOfBoundUVs)
		{
			if (gos != null)
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
				for (int i = 0; i < gos.Length; i++)
				{
					if (gos[i] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
								return null;
							}
						}
					}
					for (int j = i + 1; j < gos.Length; j++)
					{
						if (!(gos[i] == gos[j]))
						{
							continue;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							UnityEngine.Debug.LogError(string.Concat("GameObject ", gos[i], "appears twice in list of game objects to add"));
							return null;
						}
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_009d;
						}
						continue;
						end_IL_009d:
						break;
					}
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
			}
			if (deleteGOs != null)
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
				for (int k = 0; k < deleteGOs.Length; k++)
				{
					for (int l = k + 1; l < deleteGOs.Length; l++)
					{
						if (!(deleteGOs[k] == deleteGOs[l]))
						{
							continue;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!(deleteGOs[k] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
						{
							continue;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							UnityEngine.Debug.LogError(string.Concat("GameObject ", deleteGOs[k], "appears twice in list of game objects to delete"));
							return null;
						}
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_0131;
						}
						continue;
						end_IL_0131:
						break;
					}
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
			}
			if (!_addToCombined(gos, deleteGOs, disableRendererInSource))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						UnityEngine.Debug.LogError("Failed to add/delete objects to combined mesh");
						return null;
					}
				}
			}
			if (targetRenderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (outputOption != MB2_OutputOptions.bakeMeshAssetsInPlace)
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
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)targetRenderer;
						skinnedMeshRenderer.bones = bones;
						UpdateSkinnedMeshApproximateBounds();
					}
					targetRenderer.lightmapIndex = GetLightmapIndex();
				}
			}
			return _mesh;
		}

		public bool CombinedMeshContains(GameObject go)
		{
			return objectsInCombinedMesh.Contains(go);
		}

		private void _clearArrays()
		{
			verts = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(0);
			normals = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(0);
			tangents = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(0);
			uvs = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(0);
			uv1s = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(0);
			uv2s = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(0);
			colors = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(0);
			bones = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(0);
			bindPoses = c5cbcfda650d62ede569214a0ac331929.c0a0cdf4a196914163f7334d9b0781a04(0);
			boneWeights = c54e8ccf97efa5ea138175fa6a0d8af02.c0a0cdf4a196914163f7334d9b0781a04(0);
			submeshTris = c41f3bbc22d7b0169af0a9d6c34351add.c0a0cdf4a196914163f7334d9b0781a04(0);
			mbDynamicObjectsInCombinedMesh.Clear();
			objectsInCombinedMesh.Clear();
			instance2Combined_MapClear();
		}

		public void ClearMesh()
		{
			if (_mesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				_mesh.Clear(false);
			}
			else
			{
				_mesh = new Mesh();
			}
			_clearArrays();
		}

		public void DestroyMesh()
		{
			if (_mesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (VERBOSE)
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
					UnityEngine.Debug.Log("Destroying Mesh");
				}
				MB_Utility.Destroy(_mesh);
			}
			_mesh = new Mesh();
			_clearArrays();
		}

		private void _generateTangents(int[] triangles, Vector3[] verts, Vector2[] uvs, Vector3[] normals, Vector4[] outTangents)
		{
			int num = triangles.Length;
			int num2 = verts.Length;
			Vector3[] array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(num2);
			Vector3[] array2 = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(num2);
			for (int i = 0; i < num; i += 3)
			{
				int num3 = triangles[i];
				int num4 = triangles[i + 1];
				int num5 = triangles[i + 2];
				Vector3 vector = verts[num3];
				Vector3 vector2 = verts[num4];
				Vector3 vector3 = verts[num5];
				Vector2 vector4 = uvs[num3];
				Vector2 vector5 = uvs[num4];
				Vector2 vector6 = uvs[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = num12 * num15 - num13 * num14;
				if (num16 == 0f)
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
							UnityEngine.Debug.LogError("Could not compute tangents. All UVs need to form a valid triangles in UV space. If any UV triangles are collapsed, tangents cannot be generated.");
							return;
						}
					}
				}
				float num17 = 1f / num16;
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num17, (num15 * num8 - num14 * num9) * num17, (num15 * num10 - num14 * num11) * num17);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num17, (num12 * num9 - num13 * num8) * num17, (num12 * num11 - num13 * num10) * num17);
				array[num3] += vector7;
				array[num4] += vector7;
				array[num5] += vector7;
				array2[num3] += vector8;
				array2[num4] += vector8;
				array2[num5] += vector8;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < num2; j++)
				{
					Vector3 vector9 = normals[j];
					Vector3 vector10 = array[j];
					Vector3 normalized = (vector10 - vector9 * Vector3.Dot(vector9, vector10)).normalized;
					outTangents[j] = new Vector4(normalized.x, normalized.y, normalized.z);
					ref Vector4 reference = ref outTangents[j];
					float w;
					if (Vector3.Dot(Vector3.Cross(vector9, vector10), array2[j]) < 0f)
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
						w = -1f;
					}
					else
					{
						w = 1f;
					}
					reference.w = w;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}

		public void SaveMeshsToAssetDatabase(string folderPath, string newFileNameBase)
		{
			UnityEngine.Debug.LogError("Can only save meshes in the editor");
		}

		public void RebuildPrefab(GameObject prefabRoot)
		{
			UnityEngine.Debug.LogError("Can only rebuild prefabs in the editor");
		}

		public GameObject buildSceneMeshObject(GameObject root, Mesh m, bool createNewChild = false)
		{
			MeshFilter meshFilter = ceb818a1094a464895f2a2c75328c4cf1.c7088de59e49f7108f520cf7e0bae167e;
			MeshRenderer meshRenderer = c11f3712881df62bdf6719d3e03ad124b.c7088de59e49f7108f520cf7e0bae167e;
			SkinnedMeshRenderer skinnedMeshRenderer = c2940a3364e5bd052ea1b87d21d45953e.c7088de59e49f7108f520cf7e0bae167e;
			Transform transform = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
			if (!createNewChild)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				IEnumerator enumerator = root.transform.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Transform transform2 = (Transform)enumerator.Current;
						if (!transform2.name.EndsWith("-mesh"))
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
						transform = transform2;
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							goto end_IL_0088;
						}
						continue;
						end_IL_0088:
						break;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable == null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_00a1;
							}
							continue;
							end_IL_00a1:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
			GameObject gameObject;
			if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				gameObject = new GameObject(name + "-mesh");
			}
			else
			{
				gameObject = transform.gameObject;
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				}
			}
			else
			{
				meshFilter = gameObject.GetComponent<MeshFilter>();
				if (meshFilter == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					meshFilter = gameObject.AddComponent<MeshFilter>();
				}
				meshRenderer = gameObject.GetComponent<MeshRenderer>();
				if (meshRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					meshRenderer = gameObject.AddComponent<MeshRenderer>();
				}
			}
			if (textureBakeResults.doMultiMaterial)
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
				Material[] array = cb49f36706caafb4b94436f6a37599753.c0a0cdf4a196914163f7334d9b0781a04(textureBakeResults.resultMaterials.Length);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = textureBakeResults.resultMaterials[i].combinedMaterial;
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
				if (renderType == MB_RenderType.skinnedMeshRenderer)
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
					skinnedMeshRenderer.materials = array;
					skinnedMeshRenderer.bones = GetBones();
					skinnedMeshRenderer.updateWhenOffscreen = true;
				}
				else
				{
					meshRenderer.sharedMaterials = array;
				}
			}
			else if (renderType == MB_RenderType.skinnedMeshRenderer)
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
				skinnedMeshRenderer.material = textureBakeResults.resultMaterial;
				skinnedMeshRenderer.bones = GetBones();
			}
			else
			{
				meshRenderer.material = textureBakeResults.resultMaterial;
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer)
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
				skinnedMeshRenderer.sharedMesh = m;
				skinnedMeshRenderer.lightmapIndex = GetLightmapIndex();
			}
			else
			{
				meshFilter.sharedMesh = m;
				meshRenderer.lightmapIndex = GetLightmapIndex();
			}
			if (lightmapOption != 0)
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
				if (lightmapOption != MB2_LightmapOptions.generate_new_UV2_layout)
				{
					goto IL_02fb;
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
			gameObject.isStatic = true;
			goto IL_02fb;
			IL_02fb:
			List<GameObject> objectsInCombined = GetObjectsInCombined();
			if (objectsInCombined.Count > 0)
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
				if (objectsInCombined[0] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					bool flag = true;
					bool flag2 = true;
					string tag = objectsInCombined[0].tag;
					int layer = objectsInCombined[0].layer;
					for (int j = 0; j < objectsInCombined.Count; j++)
					{
						if (!(objectsInCombined[j] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
						{
							continue;
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!objectsInCombined[j].tag.Equals(tag))
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							flag = false;
						}
						if (objectsInCombined[j].layer == layer)
						{
							continue;
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						flag2 = false;
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
					if (flag)
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
						root.tag = tag;
						gameObject.tag = tag;
					}
					if (flag2)
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
						root.layer = layer;
						gameObject.layer = layer;
					}
				}
			}
			gameObject.transform.parent = root.transform;
			return gameObject;
		}
	}
}
