using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class SubPartClassModeStore
{
	public const string AssetPath = "Assets/Resources/WeaponEditor/SubParts_ClassMode";

	public const string ResourcesAssetPath = "WeaponEditor/SubParts_ClassMode";

	public SubPartClassModeStoreSetup m_setups = new SubPartClassModeStoreSetup();

	private static SubPartClassModeStore s_subPartClassModeStore;

	public static SubPartClassModeStore c67b9adbc0ab8308ac014cfe440647a7e
	{
		get
		{
			if (s_subPartClassModeStore == null)
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
				c6171fdabcac1940c1e7ef3f68862086f();
			}
			return s_subPartClassModeStore;
		}
		protected set
		{
			s_subPartClassModeStore = value;
		}
	}

	public static string c8ecd11c7e23c8e6f0fb215603658c032()
	{
		return "Assets/Resources/WeaponEditor/SubParts_ClassMode.xml";
	}

	public static string c94d1ebb1442c5932f51f5901d0ee4b51()
	{
		return "WeaponEditor/SubParts_ClassMode";
	}

	public SubPartClassModeStoreSetup c85bde3dd9d0bd14ce4d41ef43db3f957()
	{
		return m_setups;
	}

	public SubPartClassMode cdbf696aded5fd1b462c05fbd81522f65(int cc584cc0d388b61d19d26e1dcdd9be909)
	{
		return m_setups.cdbf696aded5fd1b462c05fbd81522f65(cc584cc0d388b61d19d26e1dcdd9be909);
	}

	public SubPartClassMode cdbf696aded5fd1b462c05fbd81522f65(ClassModeType cb60928ef9d0be0bfc6010c7fcf5f6ab7, ClassModeSubPart c740fb87e58adaf9671b066d0900f1176, int c5612a459a84ffdb41c885401433cd62d)
	{
		return cdbf696aded5fd1b462c05fbd81522f65(SubPartClassMode.cab05c97ab6dee558edc49d79f6a92ed1(cb60928ef9d0be0bfc6010c7fcf5f6ab7, c740fb87e58adaf9671b066d0900f1176, c5612a459a84ffdb41c885401433cd62d));
	}

	public static void c8247be8931d105f752fb9d8392ea62dc()
	{
	}

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		s_subPartClassModeStore = new SubPartClassModeStore();
		if (s_subPartClassModeStore == null)
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
					return;
				}
			}
		}
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c94d1ebb1442c5932f51f5901d0ee4b51()) as TextAsset;
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(ca4aec06b77cceaa7165b3870b87265b7.cc1720d05c75832f704b87474932341c3()));
		Stream stream = new MemoryStream(textAsset.bytes);
		try
		{
			s_subPartClassModeStore.m_setups = (SubPartClassModeStoreSetup)xmlSerializer.Deserialize(stream);
			if (s_subPartClassModeStore.m_setups != null)
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
				s_subPartClassModeStore.m_setups.c10568ff59003f0becf08e88b8999ff8c();
			}
			stream.Close();
		}
		finally
		{
			if (stream != null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					((IDisposable)stream).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
		GC.Collect();
	}
}
