using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using A;
using UnityEngine;

public class BuildingKitBinaryLoader : BuildingKitLoader
{
	private string str;

	public BuildingKitBinaryLoader(string c3b20aeacd4dbc6ccc30bb556ab42eabd)
	{
		str = c3b20aeacd4dbc6ccc30bb556ab42eabd;
	}

	protected override object c38aeacc59bd560b59403945ae7996d79()
	{
		string c8aa0e7ee156ed339de23d3fe5557b = str;
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b) as TextAsset;
		Stream stream = new MemoryStream(textAsset.bytes);
		BinaryReader binaryReader = new BinaryReader(stream);
		ComposableCharacter composableCharacter;
		try
		{
			composableCharacter = new ComposableCharacter();
			composableCharacter.bkID = binaryReader.ReadUInt32();
			int count = binaryReader.ReadInt32() * 2;
			composableCharacter.m_sTypeName = Encoding.Unicode.GetString(binaryReader.ReadBytes(count));
			count = binaryReader.ReadInt32() * 2;
			composableCharacter.m_sCharacterName = Encoding.Unicode.GetString(binaryReader.ReadBytes(count));
			count = binaryReader.ReadInt32() * 2;
			composableCharacter.m_sSkeletonName = Encoding.Unicode.GetString(binaryReader.ReadBytes(count));
			composableCharacter.m_aParts = new List<ComposablePart>(binaryReader.ReadInt32());
			for (int i = 0; i < composableCharacter.m_aParts.Capacity; i++)
			{
				cad1f53f199488c5102afd3f15e948796(binaryReader, composableCharacter.m_aParts);
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
				if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
						composableCharacter.m_aParts.Clear();
					}
				}
				stream.Dispose();
				binaryReader.Close();
				break;
			}
		}
		finally
		{
			if (binaryReader != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					((IDisposable)binaryReader).Dispose();
					break;
				}
			}
		}
		ResourcesLoader.cc054e122aa35d5a0be5d36720b44c779(textAsset);
		return composableCharacter;
	}

	protected override uint c4cd4ae93a018bdeba99fff632cb3f04a()
	{
		return Utility.cf642a65627df2adf4e90330457651907(str);
	}

	private void cad1f53f199488c5102afd3f15e948796(BinaryReader cffaa6c92023d3015930a3f2cdd0fff46, List<ComposablePart> c6cec8ea8e5cb32da380065ffbbfa047f)
	{
		int count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		ComposablePart composablePart = new ComposablePart(Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count)));
		composablePart.m_aFbxs = new List<ComposableFBX>(cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32());
		for (int i = 0; i < composablePart.m_aFbxs.Capacity; i++)
		{
			cb38ad709c89b7ef9dd8179b0c32e5538(cffaa6c92023d3015930a3f2cdd0fff46, composablePart.m_aFbxs);
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
			c6cec8ea8e5cb32da380065ffbbfa047f.Add(composablePart);
			return;
		}
	}

	private void cb38ad709c89b7ef9dd8179b0c32e5538(BinaryReader cffaa6c92023d3015930a3f2cdd0fff46, List<ComposableFBX> c4e02c123f3436505f18aeedd1fa25d62)
	{
		int count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		ComposableFBX composableFBX = new ComposableFBX();
		composableFBX.m_sFileName = Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count));
		composableFBX.m_aMaterials = new List<ComposableMaterial>(cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32());
		for (int i = 0; i < composableFBX.m_aMaterials.Capacity; i++)
		{
			c658996323816c11a10156ec203c10815(cffaa6c92023d3015930a3f2cdd0fff46, composableFBX.m_aMaterials);
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
			c4e02c123f3436505f18aeedd1fa25d62.Add(composableFBX);
			return;
		}
	}

	private void c658996323816c11a10156ec203c10815(BinaryReader cffaa6c92023d3015930a3f2cdd0fff46, List<ComposableMaterial> c1c9974c0ef535b4b38bf8ddbb79d6700)
	{
		int count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		ComposableMaterial composableMaterial = new ComposableMaterial();
		composableMaterial.m_sMaterial = Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count));
		count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		composableMaterial.m_sShader = Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count));
		composableMaterial.m_sTexName = new List<string>(cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32());
		for (int i = 0; i < composableMaterial.m_sTexName.Capacity; i++)
		{
			count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
			composableMaterial.m_sTexName.Add(Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count)));
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			composableMaterial.m_sTexFileName = new List<string>(cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32());
			for (int j = 0; j < composableMaterial.m_sTexFileName.Capacity; j++)
			{
				count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
				composableMaterial.m_sTexFileName.Add(Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count)));
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				composableMaterial.m_sShaderProperties = new List<ShaderProperty>(cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32());
				for (int k = 0; k < composableMaterial.m_sShaderProperties.Capacity; k++)
				{
					c8ec88d5066d744cef0e51c2759f282e7(cffaa6c92023d3015930a3f2cdd0fff46, composableMaterial.m_sShaderProperties);
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					c1c9974c0ef535b4b38bf8ddbb79d6700.Add(composableMaterial);
					return;
				}
			}
		}
	}

	private void c8ec88d5066d744cef0e51c2759f282e7(BinaryReader cffaa6c92023d3015930a3f2cdd0fff46, List<ShaderProperty> c607c1382dfb8a835e49f4838e1637e04)
	{
		ShaderProperty shaderProperty = new ShaderProperty();
		shaderProperty.mType = (ShaderPropertyType)cffaa6c92023d3015930a3f2cdd0fff46.ReadByte();
		int count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		shaderProperty.mName = Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count));
		count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		shaderProperty.mDesc = Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count));
		count = cffaa6c92023d3015930a3f2cdd0fff46.ReadInt32() * 2;
		shaderProperty.mValue = Encoding.Unicode.GetString(cffaa6c92023d3015930a3f2cdd0fff46.ReadBytes(count));
		c607c1382dfb8a835e49f4838e1637e04.Add(shaderProperty);
	}
}
