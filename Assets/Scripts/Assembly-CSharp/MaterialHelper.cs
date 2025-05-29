using System.Collections.Generic;
using A;
using UnityEngine;

public static class MaterialHelper
{
	private enum ParameterType
	{
		PT_Float = 0,
		PT_Color = 1
	}

	private struct ShaderParameter
	{
		public ParameterType Type;

		public string Name;

		public float FloatValue;

		public Color ColorValue;
	}

	public static void c8aad2693bab239127d92af8c0b0b8c3c(GameObject cebae66039aadeac8deb1211786332a72)
	{
		if (cebae66039aadeac8deb1211786332a72 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		List<ShaderParameter> list = new List<ShaderParameter>();
		ShaderParameter item = default(ShaderParameter);
		item.Type = ParameterType.PT_Color;
		item.Name = "custom_ambient";
		item.ColorValue = Color.white;
		list.Add(item);
		cd7cbebb43daff39b0e58c7bdf9f1e15d(cebae66039aadeac8deb1211786332a72, "Custom/BOL_Charactor_BRDF_Ambient_NoLP", list);
	}

	private static void cc93119a4e76a01312b46b01f231dd60a(GameObject cebae66039aadeac8deb1211786332a72)
	{
		List<ShaderParameter> list = new List<ShaderParameter>();
		ShaderParameter item = default(ShaderParameter);
		item.Type = ParameterType.PT_Color;
		item.Name = "custom_ambient";
		item.ColorValue = Color.white;
		list.Add(item);
		cd7cbebb43daff39b0e58c7bdf9f1e15d(cebae66039aadeac8deb1211786332a72, "Custom/BOL_Wpn_MaskReflect_Ambient_NoLP", list);
	}

	public static void cbf1c5cf9088f25c5aeaa81c33c6af2c1(GameObject cebae66039aadeac8deb1211786332a72)
	{
		if (cebae66039aadeac8deb1211786332a72 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		cc93119a4e76a01312b46b01f231dd60a(cebae66039aadeac8deb1211786332a72);
	}

	public static void c3a3bf7ecc283c6b1f185f2ae0272a06e(GameObject cebae66039aadeac8deb1211786332a72)
	{
		if (cebae66039aadeac8deb1211786332a72 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		cc93119a4e76a01312b46b01f231dd60a(cebae66039aadeac8deb1211786332a72);
	}

	private static void cd7cbebb43daff39b0e58c7bdf9f1e15d(GameObject cebae66039aadeac8deb1211786332a72, string c2336cc2a257e72d8c14d68cb2f4fb6ad, List<ShaderParameter> c98d9ddea73215529daf95030d00d6e7d)
	{
		SkinnedMeshRenderer component = cebae66039aadeac8deb1211786332a72.GetComponent<SkinnedMeshRenderer>();
		if ((bool)component)
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
			c90b1986437e8d19e9565c4381fda7356(component, c2336cc2a257e72d8c14d68cb2f4fb6ad, c98d9ddea73215529daf95030d00d6e7d);
		}
		SkinnedMeshRenderer[] componentsInChildren = cebae66039aadeac8deb1211786332a72.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			if (!skinnedMeshRenderer)
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
			c90b1986437e8d19e9565c4381fda7356(skinnedMeshRenderer, c2336cc2a257e72d8c14d68cb2f4fb6ad, c98d9ddea73215529daf95030d00d6e7d);
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

	private static void c90b1986437e8d19e9565c4381fda7356(SkinnedMeshRenderer c8e591d17d2202086e3c7d3a50ba6c3cf, string c2336cc2a257e72d8c14d68cb2f4fb6ad, List<ShaderParameter> c98d9ddea73215529daf95030d00d6e7d)
	{
		Material[] array = cb49f36706caafb4b94436f6a37599753.c0a0cdf4a196914163f7334d9b0781a04(c8e591d17d2202086e3c7d3a50ba6c3cf.materials.Length);
		for (int i = 0; i < c8e591d17d2202086e3c7d3a50ba6c3cf.materials.Length; i++)
		{
			array[i] = new Material(Shader.Find(c2336cc2a257e72d8c14d68cb2f4fb6ad));
			using (List<ShaderParameter>.Enumerator enumerator = c98d9ddea73215529daf95030d00d6e7d.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ShaderParameter current = enumerator.Current;
					if (current.Type == ParameterType.PT_Float)
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
						array[i].SetFloat(current.Name, current.FloatValue);
					}
					else
					{
						if (current.Type != ParameterType.PT_Color)
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
						array[i].SetColor(current.Name, current.ColorValue);
					}
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00a7;
					}
					continue;
					end_IL_00a7:
					break;
				}
			}
			array[i].CopyPropertiesFromMaterial(c8e591d17d2202086e3c7d3a50ba6c3cf.materials[i]);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			c8e591d17d2202086e3c7d3a50ba6c3cf.materials = array;
			return;
		}
	}
}
