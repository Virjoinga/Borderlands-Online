using System.Collections.Generic;
using A;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

public class MB2_MeshBakerRoot : MonoBehaviour
{
	[HideInInspector]
	public MB2_TextureBakeResults textureBakeResults;

	public virtual List<GameObject> c1de633fcf95c62e1f3b66800c18177ab()
	{
		return null;
	}

	public static bool c369f181a8c83d841d203d3b8dd753c4d(MB2_MeshBakerRoot c3e62b263d1dc8abe383953cea7e00478, MB_ObjsToCombineTypes c96ae611fd3ca66099783bbfbab9d65a2)
	{
		if (c3e62b263d1dc8abe383953cea7e00478.textureBakeResults == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, "Need to set textureBakeResults");
					return false;
				}
			}
		}
		if (!(c3e62b263d1dc8abe383953cea7e00478 is MB2_TextureBaker))
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
			MB2_TextureBaker component = c3e62b263d1dc8abe383953cea7e00478.GetComponent<MB2_TextureBaker>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (component.textureBakeResults != c3e62b263d1dc8abe383953cea7e00478.textureBakeResults)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Tool, "textureBakeResults on this component is not the same as the textureBakeResults on the MB2_TextureBaker.");
				}
			}
		}
		List<GameObject> list = c3e62b263d1dc8abe383953cea7e00478.c1de633fcf95c62e1f3b66800c18177ab();
		int num = 0;
		while (num < list.Count)
		{
			GameObject gameObject = list[num];
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, "The list of objects to combine contains a null at position." + num + " Select and use [shift] delete to remove");
						return false;
					}
				}
			}
			for (int i = num + 1; i < list.Count; i++)
			{
				if (!(list[num] == list[i]))
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, "The list of objects to combine contains duplicates.");
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
				if (MB_Utility.GetGOMaterials(gameObject) == null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, string.Concat("Object ", gameObject, " in the list of objects to be combined does not have a material"));
							return false;
						}
					}
				}
				if (MB_Utility.GetMesh(gameObject) == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, string.Concat("Object ", gameObject, " in the list of objects to be combined does not have a mesh"));
							return false;
						}
					}
				}
				num++;
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
			if (c3e62b263d1dc8abe383953cea7e00478.textureBakeResults.doMultiMaterial)
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
				if (!c295357d76a10c94ca9f8cc07837cafd4(c3e62b263d1dc8abe383953cea7e00478))
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
			}
			List<GameObject> list2 = list;
			if (c3e62b263d1dc8abe383953cea7e00478 is MB2_MeshBaker)
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
				MB2_TextureBaker component2 = c3e62b263d1dc8abe383953cea7e00478.GetComponent<MB2_TextureBaker>();
				if (((MB2_MeshBaker)c3e62b263d1dc8abe383953cea7e00478).useObjsToMeshFromTexBaker)
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
					if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						list2 = component2.objsToMesh;
					}
				}
				if (list2 != null)
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
					if (list2.Count != 0)
					{
						goto IL_027e;
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, "No meshes to combine. Please assign some meshes to combine.");
				return false;
			}
			goto IL_027e;
			IL_027e:
			return true;
		}
	}

	private static bool c295357d76a10c94ca9f8cc07837cafd4(MB2_MeshBakerRoot c3e62b263d1dc8abe383953cea7e00478)
	{
		List<GameObject> list = c3e62b263d1dc8abe383953cea7e00478.c1de633fcf95c62e1f3b66800c18177ab();
		for (int i = 0; i < list.Count; i++)
		{
			Mesh mesh = MB_Utility.GetMesh(list[i]);
			if (MB_Utility.doSubmeshesShareVertsOrTris(mesh) == 0)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Tool, string.Concat("Object ", list[i], " in the list of objects to combine has overlapping submeshes (submeshes share vertices). If the UVs associated with the shared vertices are important then this bake may not work. If you are using multiple materials then this object can only be combined with objects that use the exact same set of textures (each atlas contains one texture). There may be other undesirable side affects as well. Mesh Master, available in the asset store can fix overlapping submeshes."));
				return true;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return true;
		}
	}
}
