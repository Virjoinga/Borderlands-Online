using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class ResourcesLoader
{
	private static HashSet<UnityEngine.Object> s_objList = new HashSet<UnityEngine.Object>();

	public static UnityEngine.Object c38aeacc59bd560b59403945ae7996d79(string c8aa0e7ee156ed339de23d3fe5557b916)
	{
		UnityEngine.Object @object = Resources.Load(c8aa0e7ee156ed339de23d3fe5557b916);
		if (@object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			s_objList.Add(@object);
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Obj null with Resources.Load: " + c8aa0e7ee156ed339de23d3fe5557b916);
		}
		return @object;
	}

	public static UnityEngine.Object c38aeacc59bd560b59403945ae7996d79(string c8aa0e7ee156ed339de23d3fe5557b916, Type c46639dc0e9c4c6e2694594a50bd10679)
	{
		UnityEngine.Object @object = Resources.Load(c8aa0e7ee156ed339de23d3fe5557b916, c46639dc0e9c4c6e2694594a50bd10679);
		if (@object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			s_objList.Add(@object);
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Obj null with Resources.Load: " + c8aa0e7ee156ed339de23d3fe5557b916);
		}
		return @object;
	}

	public static UnityEngine.Object[] c6a2c96c95dbb6d94ab759d22726b0440(string c8aa0e7ee156ed339de23d3fe5557b916)
	{
		UnityEngine.Object[] array = Resources.LoadAll(c8aa0e7ee156ed339de23d3fe5557b916);
		if (array != null)
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
			s_objList.UnionWith(array);
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Obj null with Resources.Load: " + c8aa0e7ee156ed339de23d3fe5557b916);
		}
		return array;
	}

	public static UnityEngine.Object[] c6a2c96c95dbb6d94ab759d22726b0440(string c8aa0e7ee156ed339de23d3fe5557b916, Type c46639dc0e9c4c6e2694594a50bd10679)
	{
		UnityEngine.Object[] array = Resources.LoadAll(c8aa0e7ee156ed339de23d3fe5557b916, c46639dc0e9c4c6e2694594a50bd10679);
		if (array != null)
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
			s_objList.UnionWith(array);
		}
		else
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Obj null with Resources.Load: " + c8aa0e7ee156ed339de23d3fe5557b916);
		}
		return array;
	}

	public static void c9984361ac943dc8858e866d1e158927b()
	{
		using (HashSet<UnityEngine.Object>.Enumerator enumerator = s_objList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UnityEngine.Object current = enumerator.Current;
				if (!(current is Texture))
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
					if (!(current is AudioClip))
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
						if (!(current is Mesh))
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
							if (!(current is Material))
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
						}
					}
				}
				Resources.UnloadAsset(current);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_007b;
				}
				continue;
				end_IL_007b:
				break;
			}
		}
		s_objList.Clear();
	}

	public static void cc054e122aa35d5a0be5d36720b44c779(UnityEngine.Object c02b39f70e5a84931bb29f52f0b430a3e)
	{
		s_objList.Remove(c02b39f70e5a84931bb29f52f0b430a3e);
		Resources.UnloadAsset(c02b39f70e5a84931bb29f52f0b430a3e);
	}

	public static GameObject c2d63b1bf24325b01b8a5a703c64d91f2(string c9c536cdaad24471d7a448d2853440144, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0)
	{
		GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (c9c536cdaad24471d7a448d2853440144.Contains("|"))
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
			char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = '|';
			string[] array2 = c9c536cdaad24471d7a448d2853440144.Split(array);
			if (array2[0] == "BKT")
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
				BuildingKitRender buildingKitRender = new BuildingKitRender(array2[1], array2[2]);
				gameObject = buildingKitRender.c3309affdc4b59cba5f457bbaec5f0762();
				gameObject.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
				gameObject.transform.rotation = c4ea6de03c1203f2470a6677821ad93f0;
			}
		}
		else
		{
			GameObject original = c4e95594aa6d23f20094cfec50ccb1899(c9c536cdaad24471d7a448d2853440144);
			gameObject = (GameObject)UnityEngine.Object.Instantiate(original, cef9712200bbe2c3873eec3ca2e18a595, c4ea6de03c1203f2470a6677821ad93f0);
		}
		return gameObject;
	}

	public static GameObject c4e95594aa6d23f20094cfec50ccb1899(string c9c536cdaad24471d7a448d2853440144)
	{
		GameObject value = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (c9c536cdaad24471d7a448d2853440144.Contains("|"))
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
			char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = '|';
			string[] array2 = c9c536cdaad24471d7a448d2853440144.Split(array);
			if (array2[0] == "BKT")
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
				BuildingKitRender buildingKitRender = new BuildingKitRender(array2[1], array2[2]);
				value = (GameObject)buildingKitRender.c7f3e848db953bbd8ebbaec6fb47ca55d();
			}
		}
		else
		{
			if (NetworkingPeer.UsePrefabCache)
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
				if (NetworkingPeer.PrefabCache.TryGetValue(c9c536cdaad24471d7a448d2853440144, out value))
				{
					goto IL_00da;
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
			value = (GameObject)c38aeacc59bd560b59403945ae7996d79(c9c536cdaad24471d7a448d2853440144, Type.GetTypeFromHandle(cc30ad18d9004f6c9825d2221f535b10a.cc1720d05c75832f704b87474932341c3()));
			if (NetworkingPeer.UsePrefabCache)
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
				NetworkingPeer.PrefabCache.Add(c9c536cdaad24471d7a448d2853440144, value);
			}
		}
		goto IL_00da;
		IL_00da:
		return value;
	}
}
