using System.Reflection;
using A;
using UnityEngine;

public class ComponentHelper
{
	public static void c0bd715794203aecb6153c35217fbf4f4(GameObject c52511d1cb7a4974a8a4536d2cf3b423e, GameObject cfe2e8ee36dfb4f11f7ee1fb8d70c63dd)
	{
		Component[] components = c52511d1cb7a4974a8a4536d2cf3b423e.GetComponents<Component>();
		foreach (Component component in components)
		{
			if ((bool)cfe2e8ee36dfb4f11f7ee1fb8d70c63dd.GetComponent(component.GetType()))
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
			}
			else
			{
				Component cd6a7967330188dc1a6131ff919985c = cfe2e8ee36dfb4f11f7ee1fb8d70c63dd.AddComponent(component.GetType());
				c0bd715794203aecb6153c35217fbf4f4(component, cd6a7967330188dc1a6131ff919985c);
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

	public static void c0bd715794203aecb6153c35217fbf4f4(Component cb7c736b17bc53c850d891f1f2cf5bdb9, Component cd6a7967330188dc1a6131ff919985c04)
	{
		if (!(cb7c736b17bc53c850d891f1f2cf5bdb9 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(cd6a7967330188dc1a6131ff919985c04 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				FieldInfo[] fields = cb7c736b17bc53c850d891f1f2cf5bdb9.GetType().GetFields();
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.IsStatic)
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
					if (fieldInfo.IsInitOnly)
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
					if (fieldInfo.IsLiteral)
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
					fieldInfo.SetValue(cd6a7967330188dc1a6131ff919985c04, fieldInfo.GetValue(cb7c736b17bc53c850d891f1f2cf5bdb9));
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
	}
}
