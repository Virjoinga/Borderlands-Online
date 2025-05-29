using System.Collections.Generic;
using System.Text;
using Core;
using UnityEngine;

public class MB2_TextureBakeResults : ScriptableObject
{
	public MB_AtlasesAndRects[] combinedMaterialInfo;

	public Material[] materials;

	public Rect[] prefabUVRects;

	public Material resultMaterial;

	public MB_MultiMaterial[] resultMaterials;

	public bool doMultiMaterial;

	public bool fixOutOfBoundsUVs;

	public Dictionary<Material, Rect> c745dda41192d9ccb02047a5e2f412016()
	{
		Dictionary<Material, Rect> dictionary = new Dictionary<Material, Rect>();
		if (materials != null)
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
			if (prefabUVRects != null)
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
				if (materials.Length == prefabUVRects.Length)
				{
					for (int i = 0; i < materials.Length; i++)
					{
						dictionary.Add(materials[i], prefabUVRects[i]);
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
					goto IL_0098;
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
		}
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Default, "Bad TextureBakeResults could not build mat2UVRect map");
		goto IL_0098;
		IL_0098:
		return dictionary;
	}

	public string ce3e478508e5e484d064256062bedc4a4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Shaders:\n");
		HashSet<Shader> hashSet = new HashSet<Shader>();
		if (materials != null)
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
			for (int i = 0; i < materials.Length; i++)
			{
				hashSet.Add(materials[i].shader);
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
		using (HashSet<Shader>.Enumerator enumerator = hashSet.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Shader current = enumerator.Current;
				stringBuilder.Append("  ").Append(current.name).AppendLine();
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_00af;
				}
				continue;
				end_IL_00af:
				break;
			}
		}
		stringBuilder.Append("Materials:\n");
		if (materials != null)
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
			for (int j = 0; j < materials.Length; j++)
			{
				stringBuilder.Append("  ").Append(materials[j].name).AppendLine();
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
		return stringBuilder.ToString();
	}
}
