using System;
using System.Reflection;
using A;
using UnityEngine;

internal class DynamicValueHelper<T>
{
	public static Func<T> cbbd483c23cdc95cb8bf738e3ce780729(UnityEngine.Object c82fcbab5e578dc3a31c1f662916bd87e, string ca57789de86459caf1b0cd284afe32a38)
	{
		Func<T> result = null;
		Type type = c82fcbab5e578dc3a31c1f662916bd87e.GetType();
		MethodInfo method = type.GetMethod(ca57789de86459caf1b0cd284afe32a38, Type.EmptyTypes, ca95f15dcddce0f9ac9ab17fc6b303700.c7088de59e49f7108f520cf7e0bae167e);
		if (method != null)
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
			if (method.ReturnType == typeof(T))
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
				if (method.IsPublic)
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
					if (!method.IsStatic)
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
						result = Delegate.CreateDelegate(typeof(Func<T>), c82fcbab5e578dc3a31c1f662916bd87e, method, false) as Func<T>;
					}
				}
			}
		}
		return result;
	}
}
