using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class SubPartStore
{
	public const string AssetPath = "Assets/Resources/WeaponEditor/SubParts_";

	public const string ResourcesAssetPath = "WeaponEditor/SubParts_";

	public SubPartStoreSetup[] m_setups = ce095d2180681f4543e8342b6e140c2d4.c0a0cdf4a196914163f7334d9b0781a04(5);

	private static SubPartStore s_subPartStore;

	public static SubPartStore c2468dbf91d056d864da750fa5576bbef
	{
		get
		{
			if (s_subPartStore == null)
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
				c599ef15da60b8dda61f4bda7adc851b3();
			}
			return s_subPartStore;
		}
		protected set
		{
			s_subPartStore = value;
		}
	}

	public static string c8ecd11c7e23c8e6f0fb215603658c032(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		return "Assets/Resources/WeaponEditor/SubParts_" + c27b7430edc94b8f5b543605119ec4a72.ToString() + ".xml";
	}

	public static string c94d1ebb1442c5932f51f5901d0ee4b51(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		return "WeaponEditor/SubParts_" + c27b7430edc94b8f5b543605119ec4a72;
	}

	public SubPartStoreSetup c301eefb6b787d09528847049deb28a21(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		if (c27b7430edc94b8f5b543605119ec4a72 < WeaponType.SMG)
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
					return null;
				}
			}
		}
		if (c27b7430edc94b8f5b543605119ec4a72 >= WeaponType.TOTAL)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		return m_setups[(int)c27b7430edc94b8f5b543605119ec4a72];
	}

	public SubPartWpn cdbf696aded5fd1b462c05fbd81522f65(int cc584cc0d388b61d19d26e1dcdd9be909)
	{
		WeaponType c27b7430edc94b8f5b543605119ec4a = SubPartWpn.ccf6c15dffba5e0dd8c87e3162699a671(cc584cc0d388b61d19d26e1dcdd9be909);
		SubPartStoreSetup subPartStoreSetup = c301eefb6b787d09528847049deb28a21(c27b7430edc94b8f5b543605119ec4a);
		if (subPartStoreSetup == null)
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
		return subPartStoreSetup.cdbf696aded5fd1b462c05fbd81522f65(cc584cc0d388b61d19d26e1dcdd9be909);
	}

	public SubPartWpn cdbf696aded5fd1b462c05fbd81522f65(WeaponType c39409683a32e09391d094314ffeae2b5, WeaponSubPart c740fb87e58adaf9671b066d0900f1176, int c5612a459a84ffdb41c885401433cd62d)
	{
		return cdbf696aded5fd1b462c05fbd81522f65(SubPartWpn.cab05c97ab6dee558edc49d79f6a92ed1(c39409683a32e09391d094314ffeae2b5, c740fb87e58adaf9671b066d0900f1176, c5612a459a84ffdb41c885401433cd62d));
	}

	public List<SubPartWpn> c3c1ff2c867c8723c994fdc468d25c139(WeaponType c27b7430edc94b8f5b543605119ec4a72, WeaponSubPart cbc817ea23a983bd92590f4718c628968)
	{
		SubPartStoreSetup subPartStoreSetup = c301eefb6b787d09528847049deb28a21(c27b7430edc94b8f5b543605119ec4a72);
		if (subPartStoreSetup == null)
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
					return null;
				}
			}
		}
		return subPartStoreSetup.c3c1ff2c867c8723c994fdc468d25c139(cbc817ea23a983bd92590f4718c628968);
	}

	public bool c1da8bf1abc50177e367792c08bfd23f6(WeaponType c27b7430edc94b8f5b543605119ec4a72, WeaponSubPart c740fb87e58adaf9671b066d0900f1176)
	{
		if (c740fb87e58adaf9671b066d0900f1176 == WeaponSubPart.STOCK)
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
			if (c27b7430edc94b8f5b543605119ec4a72 == WeaponType.RepeaterPistol)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		if (c740fb87e58adaf9671b066d0900f1176 == WeaponSubPart.ACTION)
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
			if (c27b7430edc94b8f5b543605119ec4a72 != WeaponType.RepeaterPistol)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public byte c38e616c203dfa717c3386be3bb720a43(WeaponType c27b7430edc94b8f5b543605119ec4a72, WeaponSubPart c740fb87e58adaf9671b066d0900f1176)
	{
		byte b = 0;
		for (int i = 0; i < (int)c740fb87e58adaf9671b066d0900f1176; i++)
		{
			if (c1da8bf1abc50177e367792c08bfd23f6(c27b7430edc94b8f5b543605119ec4a72, (WeaponSubPart)i))
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
			b++;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return b;
		}
	}

	public static void c8247be8931d105f752fb9d8392ea62dc()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cc8b66103e6ab26be7636126ff0248621.cc1720d05c75832f704b87474932341c3()));
		for (int i = 0; i < 5; i++)
		{
			if (s_subPartStore.m_setups[i] == null)
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
				continue;
			}
			TextWriter textWriter = new StreamWriter(c8ecd11c7e23c8e6f0fb215603658c032((WeaponType)i));
			try
			{
				xmlSerializer.Serialize(textWriter, s_subPartStore.m_setups[i]);
				textWriter.Close();
			}
			finally
			{
				if (textWriter != null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						((IDisposable)textWriter).Dispose();
						break;
					}
				}
			}
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

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		s_subPartStore = new SubPartStore();
		if (s_subPartStore == null)
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
					return;
				}
			}
		}
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cc8b66103e6ab26be7636126ff0248621.cc1720d05c75832f704b87474932341c3()));
		for (int i = 0; i < 5; i++)
		{
			string path = c8ecd11c7e23c8e6f0fb215603658c032((WeaponType)i);
			if (!File.Exists(path))
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
				s_subPartStore.m_setups[i] = new SubPartStoreSetup();
				continue;
			}
			FileStream fileStream = File.OpenRead(path);
			try
			{
				s_subPartStore.m_setups[i] = (SubPartStoreSetup)xmlSerializer.Deserialize(fileStream);
				s_subPartStore.m_setups[i].c10568ff59003f0becf08e88b8999ff8c();
				fileStream.Close();
			}
			finally
			{
				if (fileStream != null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						((IDisposable)fileStream).Dispose();
						break;
					}
				}
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private static void c599ef15da60b8dda61f4bda7adc851b3()
	{
		s_subPartStore = new SubPartStore();
		if (s_subPartStore == null)
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
		for (int i = 0; i < 5; i++)
		{
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("WeaponEditor/Bin/SubParts_" + (WeaponType)i) as TextAsset;
			Stream stream = new MemoryStream(textAsset.bytes);
			BinaryReader binaryReader = new BinaryReader(stream);
			try
			{
				s_subPartStore.m_setups[i] = new SubPartStoreSetup();
				int num = binaryReader.ReadInt32();
				SubPartWpn[] array = c7e3a5a1f72528ee3c24f48a27a9c04ec.c0a0cdf4a196914163f7334d9b0781a04(num);
				for (int j = 0; j < num; j++)
				{
					array[j] = new SubPartWpn();
					array[j].m_Index = binaryReader.ReadInt32();
					array[j].m_weaponType = (WeaponType)binaryReader.ReadByte();
					array[j].m_partType = (WeaponSubPart)binaryReader.ReadByte();
					BuildingPart buildingPart = new BuildingPart();
					buildingPart.bkID = binaryReader.ReadUInt32();
					buildingPart.mPart = binaryReader.ReadByte();
					buildingPart.mFBX = binaryReader.ReadByte();
					buildingPart.mMat = binaryReader.ReadByte();
					array[j].m_BuildingPart = buildingPart;
					array[j].m_partName = binaryReader.ReadString();
					array[j].m_namePriority = binaryReader.ReadInt32();
					int num2 = binaryReader.ReadInt32();
					BOLAttribute[] array2 = c507bbd74718b0292bc9a38cabdac42fe.c0a0cdf4a196914163f7334d9b0781a04(num2);
					for (int k = 0; k < num2; k++)
					{
						array2[k] = new BOLAttribute();
						array2[k].m_attributeType = (AttributeType)binaryReader.ReadByte();
						AttributeValueType attributeValueType = (AttributeValueType)binaryReader.ReadByte();
						Type type = Type.GetType("XsdSettings." + attributeValueType, true);
						array2[k].m_attributeValue = (AttributeValue)Activator.CreateInstance(type);
						array2[k].m_attributeValue.m_type = attributeValueType;
						array2[k].m_attributeValue.m_affectType = (AffectType)binaryReader.ReadByte();
						array2[k].m_attributeValue.cd1109b7ea29846a9735888dcb26a97fe(binaryReader.ReadSingle());
					}
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							goto end_IL_0214;
						}
						continue;
						end_IL_0214:
						break;
					}
					array[j].m_Attributes = array2;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					s_subPartStore.m_setups[i].m_subParts = array;
					s_subPartStore.m_setups[i].c10568ff59003f0becf08e88b8999ff8c();
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
						switch (1)
						{
						case 0:
							continue;
						}
						((IDisposable)binaryReader).Dispose();
						break;
					}
				}
			}
			Resources.UnloadAsset(textAsset);
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
