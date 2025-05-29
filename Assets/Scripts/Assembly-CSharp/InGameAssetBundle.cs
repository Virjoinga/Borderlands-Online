using System;
using A;
using Core;
using UnityEngine;

public class InGameAssetBundle : BaseAssetBundle
{
	public WWW m_www;

	public AssetBundle m_assetBundle;

	public override UnityEngine.Object cbe31762a9894d52384000afa6c237832
	{
		get
		{
			if (m_www != null)
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
				if (!(null == m_www.assetBundle))
				{
					return m_www.assetBundle.mainAsset;
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "mainAsset for failed bundle");
			return null;
		}
	}

	public InGameAssetBundle(WWW cd0d24772c2ea5a702e0061bcb03212d1)
	{
		m_www = cd0d24772c2ea5a702e0061bcb03212d1;
	}

	private bool c8a649b815b023fc7919b7528b607f7ee(string c434f2366f4803d9c9b98838db33422c8)
	{
		bool result = false;
		if (m_www == null)
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
		}
		else if (!string.IsNullOrEmpty(m_www.error))
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, c434f2366f4803d9c9b98838db33422c8 + " has WWW error: " + m_www.error);
		}
		else if (null == m_www.assetBundle)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, c434f2366f4803d9c9b98838db33422c8 + ": not an asset bundle");
		}
		else
		{
			result = true;
		}
		return result;
	}

	public override bool c1a84901a0a9ec83a0000feb026941d27(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		int result;
		if (c8a649b815b023fc7919b7528b607f7ee("Contains"))
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
			result = (m_www.assetBundle.Contains(cd99af21e22e356018b8f72d4a7e4872a) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override UnityEngine.Object c38aeacc59bd560b59403945ae7996d79(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		object result;
		if (c8a649b815b023fc7919b7528b607f7ee("Load"))
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
			result = m_www.assetBundle.Load(cd99af21e22e356018b8f72d4a7e4872a);
		}
		else
		{
			result = null;
		}
		return (UnityEngine.Object)result;
	}

	public override UnityEngine.Object c38aeacc59bd560b59403945ae7996d79(string cd99af21e22e356018b8f72d4a7e4872a, Type c2b4f43f34e21572af6ab4414f04cee36)
	{
		object result;
		if (c8a649b815b023fc7919b7528b607f7ee("Load"))
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
			result = m_www.assetBundle.Load(cd99af21e22e356018b8f72d4a7e4872a, c2b4f43f34e21572af6ab4414f04cee36);
		}
		else
		{
			result = null;
		}
		return (UnityEngine.Object)result;
	}

	public override UnityEngine.Object[] c6a2c96c95dbb6d94ab759d22726b0440()
	{
		object result;
		if (c8a649b815b023fc7919b7528b607f7ee("LoadAll"))
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
			result = m_www.assetBundle.LoadAll();
		}
		else
		{
			result = null;
		}
		return (UnityEngine.Object[])result;
	}

	public override AssetBundleRequest ce2bd12bfa7577675b369574fae296f5d(string cd99af21e22e356018b8f72d4a7e4872a, Type c2b4f43f34e21572af6ab4414f04cee36)
	{
		object result;
		if (c8a649b815b023fc7919b7528b607f7ee("LoadAsync"))
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
			result = m_www.assetBundle.LoadAsync(cd99af21e22e356018b8f72d4a7e4872a, c2b4f43f34e21572af6ab4414f04cee36);
		}
		else
		{
			result = null;
		}
		return (AssetBundleRequest)result;
	}

	public override void c023f6d02221ee56c20921f9cd2e22441(bool c533c1c1772760aeafba37f6bdb966900)
	{
		if (!c8a649b815b023fc7919b7528b607f7ee("Unload"))
		{
			return;
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
			m_www.assetBundle.Unload(c533c1c1772760aeafba37f6bdb966900);
			m_www.Dispose();
			m_www = c8a3ceff2d632251fdafc18443ed57e65.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c040ee5dc6011ac6f76e73d8f329ca070()
	{
		if (m_www == null)
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
		m_www.Dispose();
		m_www = c8a3ceff2d632251fdafc18443ed57e65.c7088de59e49f7108f520cf7e0bae167e;
	}
}
