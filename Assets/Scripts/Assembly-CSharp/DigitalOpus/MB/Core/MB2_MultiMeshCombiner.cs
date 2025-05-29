using System;
using System.Collections.Generic;
using A;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	[Serializable]
	public class MB2_MultiMeshCombiner
	{
		[Serializable]
		public class CombinedMesh
		{
			public MB2_MeshCombiner combinedMesh;

			public int extraSpace = -1;

			public int numVertsInListToDelete;

			public int numVertsInListToAdd;

			public List<GameObject> gosToAdd;

			public List<GameObject> gosToDelete;

			public List<GameObject> gosToUpdate;

			public bool isDirty;

			public CombinedMesh(int maxNumVertsInMesh)
			{
				combinedMesh = new MB2_MeshCombiner();
				extraSpace = maxNumVertsInMesh;
				numVertsInListToDelete = 0;
				numVertsInListToAdd = 0;
				gosToAdd = new List<GameObject>();
				gosToDelete = new List<GameObject>();
				gosToUpdate = new List<GameObject>();
			}

			public bool isEmpty()
			{
				List<GameObject> list = new List<GameObject>();
				list.AddRange(combinedMesh.GetObjectsInCombined());
				for (int i = 0; i < gosToDelete.Count; i++)
				{
					list.Remove(gosToDelete[i]);
				}
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
					if (list.Count == 0)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return true;
							}
						}
					}
					return false;
				}
			}
		}

		private static bool VERBOSE = false;

		private static GameObject[] empty = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(0);

		private Dictionary<GameObject, CombinedMesh> obj2MeshCombinerMap = new Dictionary<GameObject, CombinedMesh>();

		private List<CombinedMesh> meshCombiners = new List<CombinedMesh>();

		[SerializeField]
		private int _maxVertsInMesh = 65535;

		[SerializeField]
		private string __name;

		[SerializeField]
		private MB2_TextureBakeResults __textureBakeResults;

		[SerializeField]
		private GameObject __resultSceneObject;

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

		public int maxVertsInMesh
		{
			get
			{
				return _maxVertsInMesh;
			}
			set
			{
				if (obj2MeshCombinerMap.Count > 0)
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
							UnityEngine.Debug.LogError("Can't set the max verts in meshes once there are objects in the mesh.");
							return;
						}
					}
				}
				_maxVertsInMesh = value;
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
				__textureBakeResults = value;
			}
		}

		public GameObject resultSceneObject
		{
			get
			{
				return __resultSceneObject;
			}
			set
			{
				__resultSceneObject = value;
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
				if (obj2MeshCombinerMap.Count > 0)
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

		public int GetNumObjectsInCombined()
		{
			return obj2MeshCombinerMap.Count;
		}

		public int GetNumVerticesFor(GameObject go)
		{
			CombinedMesh value = null;
			if (obj2MeshCombinerMap.TryGetValue(go, out value))
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
						return value.combinedMesh.GetNumVerticesFor(go);
					}
				}
			}
			return -1;
		}

		public List<GameObject> GetObjectsInCombined()
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				list.AddRange(meshCombiners[i].combinedMesh.GetObjectsInCombined());
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return list;
			}
		}

		public int GetLightmapIndex()
		{
			if (meshCombiners.Count > 0)
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
						return meshCombiners[0].combinedMesh.GetLightmapIndex();
					}
				}
			}
			return -1;
		}

		public bool CombinedMeshContains(GameObject go)
		{
			return obj2MeshCombinerMap.ContainsKey(go);
		}

		private bool _validateTextureBakeResults()
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
						UnityEngine.Debug.LogError("Material Bake Results is null. Can't combine meshes.");
						return false;
					}
				}
			}
			if (textureBakeResults.materials != null)
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
				if (textureBakeResults.materials.Length != 0)
				{
					if (textureBakeResults.doMultiMaterial)
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
						if (textureBakeResults.resultMaterials != null)
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
							switch (4)
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
					switch (5)
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

		public void Apply()
		{
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				if (!meshCombiners[i].isDirty)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				meshCombiners[i].combinedMesh.Apply();
				meshCombiners[i].isDirty = false;
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

		public void Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool colors, bool uv1, bool uv2, bool bones = false)
		{
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				if (!meshCombiners[i].isDirty)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				meshCombiners[i].combinedMesh.Apply(triangles, vertices, normals, tangents, uvs, colors, uv1, uv2, bones);
				meshCombiners[i].isDirty = false;
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

		public void UpdateGameObjects(GameObject[] gos, bool recalcBounds = true)
		{
			if (gos == null)
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
						UnityEngine.Debug.LogError("list of game objects cannot be null");
						return;
					}
				}
			}
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				meshCombiners[i].gosToUpdate.Clear();
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < gos.Length; j++)
				{
					CombinedMesh value = null;
					obj2MeshCombinerMap.TryGetValue(gos[j], out value);
					if (value != null)
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
						value.gosToUpdate.Add(gos[j]);
					}
					else
					{
						UnityEngine.Debug.LogWarning(string.Concat("Object ", gos[j], " is not in the combined mesh."));
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					for (int k = 0; k < meshCombiners.Count; k++)
					{
						if (meshCombiners[k].gosToUpdate.Count <= 0)
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
						GameObject[] gos2 = meshCombiners[k].gosToUpdate.ToArray();
						meshCombiners[k].combinedMesh.UpdateGameObjects(gos2, recalcBounds);
					}
					while (true)
					{
						switch (1)
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

		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs)
		{
			return AddDeleteGameObjects(gos, deleteGOs, true, textureBakeResults.fixOutOfBoundsUVs);
		}

		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource)
		{
			return AddDeleteGameObjects(gos, deleteGOs, disableRendererInSource, textureBakeResults.fixOutOfBoundsUVs);
		}

		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource, bool fixOutOfBoundUVs)
		{
			if (!_validate(gos, deleteGOs))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return null;
					}
				}
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
				array[0] = "AddDeleteGameObjects adding:";
				array[1] = gos.Length;
				array[2] = " deleting:";
				array[3] = deleteGOs.Length;
				array[4] = " disableRendererInSource:";
				array[5] = disableRendererInSource;
				array[6] = " fixOutOfBoundUVs:";
				array[7] = fixOutOfBoundUVs;
				UnityEngine.Debug.Log(string.Concat(array));
			}
			_distributeAmongBakers(gos, deleteGOs);
			return _bakeStep1(gos, deleteGOs, disableRendererInSource, fixOutOfBoundUVs);
		}

		private bool _validate(GameObject[] gos, GameObject[] deleteGOs)
		{
			_validateTextureBakeResults();
			if (gos != null)
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
				int num = 0;
				while (num < gos.Length)
				{
					if (gos[num] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								UnityEngine.Debug.LogError("The " + num + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
								return false;
							}
						}
					}
					for (int i = num + 1; i < gos.Length; i++)
					{
						if (!(gos[num] == gos[i]))
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
							UnityEngine.Debug.LogError(string.Concat("GameObject ", gos[num], "appears twice in list of game objects to add"));
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
						if (obj2MeshCombinerMap.ContainsKey(gos[num]))
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
							bool flag = false;
							if (deleteGOs != null)
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
								for (int j = 0; j < deleteGOs.Length; j++)
								{
									if (!(deleteGOs[j] == gos[num]))
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
									switch (3)
									{
									case 0:
										continue;
									}
									break;
								}
							}
							if (!flag)
							{
								while (true)
								{
									switch (6)
									{
									case 0:
										break;
									default:
										UnityEngine.Debug.LogError(string.Concat("GameObject ", gos[num], " is already in the combined mesh"));
										return false;
									}
								}
							}
						}
						num++;
						break;
					}
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
			if (deleteGOs != null)
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
				int num2 = 0;
				while (num2 < deleteGOs.Length)
				{
					for (int k = num2 + 1; k < deleteGOs.Length; k++)
					{
						if (!(deleteGOs[num2] == deleteGOs[k]))
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
						if (!(deleteGOs[num2] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							UnityEngine.Debug.LogError(string.Concat("GameObject ", deleteGOs[num2], "appears twice in list of game objects to delete"));
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
						if (!obj2MeshCombinerMap.ContainsKey(deleteGOs[num2]))
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
							UnityEngine.Debug.LogWarning(string.Concat("GameObject ", deleteGOs[num2], " on the list of objects to delete is not in the combined mesh."));
						}
						num2++;
						break;
					}
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
			return true;
		}

		private void _distributeAmongBakers(GameObject[] gos, GameObject[] deleteGOs)
		{
			if (gos == null)
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
				gos = empty;
			}
			if (deleteGOs == null)
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
				deleteGOs = empty;
			}
			if (resultSceneObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				resultSceneObject = new GameObject("CombinedMesh-" + name);
			}
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				meshCombiners[i].extraSpace = _maxVertsInMesh - meshCombiners[i].combinedMesh.GetMesh().vertexCount;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < deleteGOs.Length; j++)
				{
					CombinedMesh value = null;
					if (obj2MeshCombinerMap.TryGetValue(deleteGOs[j], out value))
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
							object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
							array[0] = "Removing ";
							array[1] = deleteGOs[j];
							array[2] = " from meshCombiner ";
							array[3] = meshCombiners.IndexOf(value);
							UnityEngine.Debug.Log(string.Concat(array));
						}
						value.numVertsInListToDelete += value.combinedMesh.GetNumVerticesFor(deleteGOs[j]);
						value.gosToDelete.Add(deleteGOs[j]);
					}
					else
					{
						UnityEngine.Debug.LogWarning(string.Concat("Object ", deleteGOs[j], " in the list of objects to delete is not in the combined mesh."));
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					for (int k = 0; k < gos.Length; k++)
					{
						GameObject gameObject = gos[k];
						int vertexCount = MB_Utility.GetMesh(gameObject).vertexCount;
						CombinedMesh combinedMesh = null;
						int num = 0;
						while (true)
						{
							if (num < meshCombiners.Count)
							{
								if (meshCombiners[num].extraSpace + meshCombiners[num].numVertsInListToDelete - meshCombiners[num].numVertsInListToAdd > vertexCount)
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
									combinedMesh = meshCombiners[num];
									if (!VERBOSE)
									{
										break;
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
									object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
									array2[0] = "Added ";
									array2[1] = gos[k];
									array2[2] = " to combinedMesh ";
									array2[3] = num;
									UnityEngine.Debug.Log(string.Concat(array2));
									break;
								}
								num++;
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
							break;
						}
						if (combinedMesh == null)
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
							combinedMesh = new CombinedMesh(maxVertsInMesh);
							_setMBValues(combinedMesh.combinedMesh);
							meshCombiners.Add(combinedMesh);
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
								UnityEngine.Debug.Log("Created new combinedMesh");
							}
						}
						combinedMesh.gosToAdd.Add(gameObject);
						combinedMesh.numVertsInListToAdd += vertexCount;
					}
					while (true)
					{
						switch (1)
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

		private Mesh _bakeStep1(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource, bool fixOutOfBoundUVs)
		{
			for (int num = 0; num < meshCombiners.Count; num++)
			{
				CombinedMesh combinedMesh = meshCombiners[num];
				if (combinedMesh.combinedMesh.targetRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					GameObject gameObject = combinedMesh.combinedMesh.buildSceneMeshObject(resultSceneObject, combinedMesh.combinedMesh.GetMesh(), true);
					combinedMesh.combinedMesh.targetRenderer = gameObject.GetComponent<Renderer>();
				}
				else if (combinedMesh.combinedMesh.targetRenderer.transform.parent != resultSceneObject.transform)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							UnityEngine.Debug.LogError("targetRender objects must be children of resultSceneObject");
							return null;
						}
					}
				}
				if (combinedMesh.gosToAdd.Count <= 0)
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
					if (combinedMesh.gosToDelete.Count <= 0)
					{
						goto IL_0130;
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
				combinedMesh.combinedMesh.AddDeleteGameObjects(combinedMesh.gosToAdd.ToArray(), combinedMesh.gosToDelete.ToArray(), disableRendererInSource, textureBakeResults.fixOutOfBoundsUVs);
				goto IL_0130;
				IL_0130:
				Renderer targetRenderer = combinedMesh.combinedMesh.targetRenderer;
				if (targetRenderer is MeshRenderer)
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
					MeshFilter component = targetRenderer.gameObject.GetComponent<MeshFilter>();
					component.sharedMesh = combinedMesh.combinedMesh.GetMesh();
				}
				else
				{
					SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)targetRenderer;
					skinnedMeshRenderer.sharedMesh = combinedMesh.combinedMesh.GetMesh();
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				for (int i = 0; i < meshCombiners.Count; i++)
				{
					CombinedMesh combinedMesh2 = meshCombiners[i];
					for (int j = 0; j < combinedMesh2.gosToDelete.Count; j++)
					{
						obj2MeshCombinerMap.Remove(combinedMesh2.gosToDelete[j]);
						if (!(combinedMesh2.gosToDelete[j] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_0230;
						}
						continue;
						end_IL_0230:
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
					int num2 = 0;
					while (num2 < meshCombiners.Count)
					{
						CombinedMesh combinedMesh3 = meshCombiners[num2];
						for (int k = 0; k < combinedMesh3.gosToAdd.Count; k++)
						{
							obj2MeshCombinerMap.Add(combinedMesh3.gosToAdd[k], combinedMesh3);
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							if (combinedMesh3.gosToAdd.Count <= 0)
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
								if (combinedMesh3.gosToDelete.Count <= 0)
								{
									goto IL_0321;
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
							combinedMesh3.gosToDelete.Clear();
							combinedMesh3.gosToAdd.Clear();
							combinedMesh3.numVertsInListToDelete = 0;
							combinedMesh3.numVertsInListToAdd = 0;
							combinedMesh3.isDirty = true;
							goto IL_0321;
							IL_0321:
							num2++;
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
							string text = "Meshes in combined:";
							for (int l = 0; l < meshCombiners.Count; l++)
							{
								string text2 = text;
								object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
								array[0] = text2;
								array[1] = " mesh";
								array[2] = l;
								array[3] = "(";
								array[4] = meshCombiners[l].combinedMesh.GetObjectsInCombined().Count;
								array[5] = ")\n";
								text = string.Concat(array);
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
							text = text + "children in result: " + resultSceneObject.transform.childCount;
							UnityEngine.Debug.Log(text);
						}
						if (meshCombiners.Count > 0)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									return meshCombiners[0].combinedMesh.GetMesh();
								}
							}
						}
						return null;
					}
				}
			}
		}

		public void ClearMesh()
		{
			DestroyMesh();
		}

		public void DestroyMesh()
		{
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				if (meshCombiners[i].combinedMesh.targetRenderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					UnityEngine.Object.Destroy(meshCombiners[i].combinedMesh.targetRenderer.gameObject);
				}
				meshCombiners[i].combinedMesh.ClearMesh();
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				obj2MeshCombinerMap.Clear();
				meshCombiners.Clear();
				return;
			}
		}

		private void _setMBValues(MB2_MeshCombiner targ)
		{
			targ.renderType = renderType;
			targ.outputOption = MB2_OutputOptions.bakeIntoSceneObject;
			targ.lightmapOption = lightmapOption;
			targ.textureBakeResults = textureBakeResults;
			targ.doNorm = doNorm;
			targ.doTan = doTan;
			targ.doCol = doCol;
			targ.doUV = doUV;
			targ.doUV1 = doUV1;
		}

		public void SaveMeshsToAssetDatabase(string folderPath, string newFileNameBase)
		{
		}

		public void RebuildPrefab(GameObject prefabRoot)
		{
		}
	}
}
