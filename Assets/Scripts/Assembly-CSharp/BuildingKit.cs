using System.Collections.Generic;
using A;
using Core;

public class BuildingKit
{
	public static string emptyPart = "empty";

	private ComposableCharacter m_Character;

	public BuildingKit()
	{
	}

	public BuildingKit(string c8aa0e7ee156ed339de23d3fe5557b916)
	{
		c3dfd74c5697530471392eaa9296b9d36(c8aa0e7ee156ed339de23d3fe5557b916);
	}

	public uint c06dee53a8ffacfe3c3e5815489a62508()
	{
		return m_Character.bkID;
	}

	public string cbb732e063b58a30b5dc6ec326627d01e()
	{
		return m_Character.m_sTypeName;
	}

	public string c47e99b30b26b61d5866d7266a2e73bc8()
	{
		return m_Character.m_sCharacterName;
	}

	public string cbad6b7872303e8588e52c4883a173115()
	{
		return m_Character.m_sSkeletonName;
	}

	public string c8a776141b9026555e9e5009d8f6c57e7()
	{
		return Utility.cf642a65627df2adf4e90330457651907(cbad6b7872303e8588e52c4883a173115()) + ".assetbundle";
	}

	public int caa0fdc2398c34830d3d15f05bcff2020()
	{
		return m_Character.m_aParts.Count;
	}

	public string ca913b520ff8d58edc1ad8cddd5eba04e(int c5ecf39c31cb10d10fc229bf29ed52790)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 >= caa0fdc2398c34830d3d15f05bcff2020())
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
					return string.Empty;
				}
			}
		}
		return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_sPartName;
	}

	public int c6ff6428f3ff765ca80c712124c47e83c(int c5ecf39c31cb10d10fc229bf29ed52790)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 >= caa0fdc2398c34830d3d15f05bcff2020())
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
					return 0;
				}
			}
		}
		return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs.Count;
	}

	public string cc985d3ce3968b538b964e683c1676ef0(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 >= caa0fdc2398c34830d3d15f05bcff2020())
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
					return string.Empty;
				}
			}
		}
		if (c21465c80ff0e7018b4dc31504d3756be >= m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs.Count)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
					array[0] = "part";
					array[1] = c5ecf39c31cb10d10fc229bf29ed52790;
					array[2] = " fbx+";
					array[3] = c21465c80ff0e7018b4dc31504d3756be;
					array[4] = "name";
					array[5] = m_Character.m_sCharacterName;
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, string.Concat(array));
					return string.Empty;
				}
				}
			}
		}
		return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName;
	}

	public string c702db42bc09810f190028fd685ba6ee8(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return Utility.cf642a65627df2adf4e90330457651907(cc985d3ce3968b538b964e683c1676ef0(c5ecf39c31cb10d10fc229bf29ed52790, c21465c80ff0e7018b4dc31504d3756be)) + ".assetbundle";
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
		return string.Empty;
	}

	public int c627db55a4773c34acc049b18a3e399a6(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials.Count;
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
		return 0;
	}

	public bool c93d7648c5590fbfe3348f6f4056ad42a()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < m_Character.m_aParts[0].m_aFbxs[0].m_aMaterials.Count; i++)
		{
			list.Add(m_Character.m_aParts[0].m_aFbxs[0].m_aMaterials[i].m_sMaterial);
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
			bool result = true;
			for (int j = 0; j < m_Character.m_aParts.Count; j++)
			{
				for (int k = 0; k < m_Character.m_aParts[j].m_aFbxs.Count; k++)
				{
					for (int l = 0; l < m_Character.m_aParts[j].m_aFbxs[k].m_aMaterials.Count; l++)
					{
						if (!(m_Character.m_aParts[j].m_aFbxs[k].m_aMaterials[l].m_sMaterial != list[l]))
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
						result = false;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_012b;
						}
						continue;
						end_IL_012b:
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
						goto end_IL_0161;
					}
					continue;
					end_IL_0161:
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
				return result;
			}
		}
	}

	public List<ShaderProperty> c84559f6c218ebf5091e0a7143018af1f(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials[c1ba84ba0939b132fbff850ff287f7919].m_sShaderProperties;
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
		return null;
	}

	public string c87398697eafbdb76016c70cdc182e3ab(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials[c1ba84ba0939b132fbff850ff287f7919].m_sMaterial;
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
		return string.Empty;
	}

	public string ce53f057551dc40db40d79611a545cbea(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return Utility.cf642a65627df2adf4e90330457651907(c87398697eafbdb76016c70cdc182e3ab(c5ecf39c31cb10d10fc229bf29ed52790, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f7919)) + ".assetbundle";
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
		return string.Empty;
	}

	public string c2a30bd8e2a872b7c49ecb5686a6719ce(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials[c1ba84ba0939b132fbff850ff287f7919].m_sShader;
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
		return string.Empty;
	}

	public int c19986b1d5c10a3b1e3d663ea11d99381(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials[c1ba84ba0939b132fbff850ff287f7919].m_sTexName.Count;
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
		return 0;
	}

	public string cdd4910030dccaceb24cee2b201ce1ea8(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919, int c57106e48513fd03bded10efe84bc5310)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials[c1ba84ba0939b132fbff850ff287f7919].m_sTexName[c57106e48513fd03bded10efe84bc5310];
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
		return string.Empty;
	}

	public string cde9f5a234249ce753831178fa2cc0648(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919, int c57106e48513fd03bded10efe84bc5310)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_aMaterials[c1ba84ba0939b132fbff850ff287f7919].m_sTexFileName[c57106e48513fd03bded10efe84bc5310];
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
		return string.Empty;
	}

	public string cdc42c79663ca79a71f3537492abcec13(int c5ecf39c31cb10d10fc229bf29ed52790, int c21465c80ff0e7018b4dc31504d3756be, int c1ba84ba0939b132fbff850ff287f7919, int c57106e48513fd03bded10efe84bc5310)
	{
		if (c5ecf39c31cb10d10fc229bf29ed52790 < caa0fdc2398c34830d3d15f05bcff2020())
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
			if (!(m_Character.m_aParts[c5ecf39c31cb10d10fc229bf29ed52790].m_aFbxs[c21465c80ff0e7018b4dc31504d3756be].m_sFileName == emptyPart))
			{
				return Utility.cf642a65627df2adf4e90330457651907(cde9f5a234249ce753831178fa2cc0648(c5ecf39c31cb10d10fc229bf29ed52790, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f7919, c57106e48513fd03bded10efe84bc5310)) + ".assetbundle";
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
		return string.Empty;
	}

	public void c3dfd74c5697530471392eaa9296b9d36(string c8aa0e7ee156ed339de23d3fe5557b916)
	{
		string c3b20aeacd4dbc6ccc30bb556ab42eabd = c8aa0e7ee156ed339de23d3fe5557b916.ToLower();
		m_Character = (ComposableCharacter)new BuildingKitBinaryLoader(c3b20aeacd4dbc6ccc30bb556ab42eabd).c588e7dbcd383d8230b2d83d7b44af23b();
	}
}
