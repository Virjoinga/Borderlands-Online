using System;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class SubPartShieldStore
{
	public const string AssetPath = "Assets/Resources/WeaponEditor/SubParts_Shield";

	public const string ResourcesAssetPath = "WeaponEditor/SubParts_Shield";

	public SubPartShieldStoreSetup m_setups = new SubPartShieldStoreSetup();

	private static SubPartShieldStore s_subPartShieldStore;

	public static SubPartShieldStore cae9c063cc4b210afb2878d8f360436c9
	{
		get
		{
			if (s_subPartShieldStore == null)
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
				c6171fdabcac1940c1e7ef3f68862086f();
			}
			return s_subPartShieldStore;
		}
		protected set
		{
			s_subPartShieldStore = value;
		}
	}

	public static string c8ecd11c7e23c8e6f0fb215603658c032()
	{
		return "Assets/Resources/WeaponEditor/SubParts_Shield.xml";
	}

	public static string c94d1ebb1442c5932f51f5901d0ee4b51()
	{
		return "WeaponEditor/SubParts_Shield";
	}

	public SubPartShieldStoreSetup cf99875fa8c574e8bb7bb55b14d2fa63d()
	{
		return m_setups;
	}

	public SubPartShield cdbf696aded5fd1b462c05fbd81522f65(int cc584cc0d388b61d19d26e1dcdd9be909)
	{
		return m_setups.cdbf696aded5fd1b462c05fbd81522f65(cc584cc0d388b61d19d26e1dcdd9be909);
	}

	public SubPartShield cdbf696aded5fd1b462c05fbd81522f65(ShieldSubPart c740fb87e58adaf9671b066d0900f1176, int c5612a459a84ffdb41c885401433cd62d)
	{
		return cdbf696aded5fd1b462c05fbd81522f65(SubPartShield.cab05c97ab6dee558edc49d79f6a92ed1(c740fb87e58adaf9671b066d0900f1176, c5612a459a84ffdb41c885401433cd62d));
	}

	public static void c8247be8931d105f752fb9d8392ea62dc()
	{
	}

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		s_subPartShieldStore = new SubPartShieldStore();
		if (s_subPartShieldStore == null)
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
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c8e3f1f4fae551d50a26982df6d29e80c.cc1720d05c75832f704b87474932341c3()));
		Stream stream = new MemoryStream(textAsset.bytes);
		try
		{
			s_subPartShieldStore.m_setups = (SubPartShieldStoreSetup)xmlSerializer.Deserialize(stream);
			if (s_subPartShieldStore.m_setups != null)
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
				s_subPartShieldStore.m_setups.c10568ff59003f0becf08e88b8999ff8c();
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
