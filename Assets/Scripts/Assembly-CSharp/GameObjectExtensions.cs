using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public static class GameObjectExtensions
{
	public static c272566d4edbf24bb8c4df6114a524ac9 c4028bbdf0ec64d2d9272b3985ad048f9<c272566d4edbf24bb8c4df6114a524ac9>(this GameObject c80822505abd04406a7a821211bd77371) where c272566d4edbf24bb8c4df6114a524ac9 : Component
	{
		Transform transform = c80822505abd04406a7a821211bd77371.transform;
		while (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			c272566d4edbf24bb8c4df6114a524ac9 component = transform.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return component;
					}
				}
			}
			transform = transform.parent;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return (c272566d4edbf24bb8c4df6114a524ac9)null;
		}
	}

	public static c272566d4edbf24bb8c4df6114a524ac9[] c81f00c3c87e0357a87c2c8ac9d40f9fc<c272566d4edbf24bb8c4df6114a524ac9>(this GameObject c80822505abd04406a7a821211bd77371) where c272566d4edbf24bb8c4df6114a524ac9 : Component
	{
		List<c272566d4edbf24bb8c4df6114a524ac9> list = new List<c272566d4edbf24bb8c4df6114a524ac9>();
		Transform transform = c80822505abd04406a7a821211bd77371.transform;
		while (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			c272566d4edbf24bb8c4df6114a524ac9 component = transform.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				list.Add(component);
			}
			transform = transform.parent;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			return list.ToArray();
		}
	}

	public static c272566d4edbf24bb8c4df6114a524ac9[] c3ff6e1ad0a2eefa718d66caae1cb472b<c272566d4edbf24bb8c4df6114a524ac9>(this GameObject c80822505abd04406a7a821211bd77371, string c8418a34814ffcac4d2abf8fab03fdec6) where c272566d4edbf24bb8c4df6114a524ac9 : Component
	{
		List<c272566d4edbf24bb8c4df6114a524ac9> list = new List<c272566d4edbf24bb8c4df6114a524ac9>();
		if (c80822505abd04406a7a821211bd77371.CompareTag(c8418a34814ffcac4d2abf8fab03fdec6))
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
			if (c80822505abd04406a7a821211bd77371.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				list.Add(c80822505abd04406a7a821211bd77371.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>());
			}
		}
		IEnumerator enumerator = c80822505abd04406a7a821211bd77371.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				list.AddRange(transform.gameObject.c3ff6e1ad0a2eefa718d66caae1cb472b<c272566d4edbf24bb8c4df6114a524ac9>(c8418a34814ffcac4d2abf8fab03fdec6));
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_0097;
				}
				continue;
				end_IL_0097:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_00ad;
					}
					continue;
					end_IL_00ad:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		return list.ToArray();
	}

	public static c272566d4edbf24bb8c4df6114a524ac9[] cc99fe12af9abe2806dbd2bcea065b24f<c272566d4edbf24bb8c4df6114a524ac9>(this GameObject c80822505abd04406a7a821211bd77371, int c5e08b87896fbbb40d17a3a54c8c33b79) where c272566d4edbf24bb8c4df6114a524ac9 : Component
	{
		List<c272566d4edbf24bb8c4df6114a524ac9> list = new List<c272566d4edbf24bb8c4df6114a524ac9>();
		if (c80822505abd04406a7a821211bd77371.layer == c5e08b87896fbbb40d17a3a54c8c33b79)
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
			if (c80822505abd04406a7a821211bd77371.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				list.Add(c80822505abd04406a7a821211bd77371.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>());
			}
		}
		IEnumerator enumerator = c80822505abd04406a7a821211bd77371.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				list.AddRange(transform.gameObject.cc99fe12af9abe2806dbd2bcea065b24f<c272566d4edbf24bb8c4df6114a524ac9>(c5e08b87896fbbb40d17a3a54c8c33b79));
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_0097;
				}
				continue;
				end_IL_0097:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_00ad;
					}
					continue;
					end_IL_00ad:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		return list.ToArray();
	}

	public static void ca4c102ce7af3879ff10c38f45b1ebdda<c272566d4edbf24bb8c4df6114a524ac9>(this GameObject c80822505abd04406a7a821211bd77371, bool c8f7bb1098b05790db33e0fccbf49275b) where c272566d4edbf24bb8c4df6114a524ac9 : MonoBehaviour
	{
		if (c80822505abd04406a7a821211bd77371.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c272566d4edbf24bb8c4df6114a524ac9 component = c80822505abd04406a7a821211bd77371.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>();
			component.enabled = c8f7bb1098b05790db33e0fccbf49275b;
		}
		IEnumerator enumerator = c80822505abd04406a7a821211bd77371.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				transform.gameObject.ca4c102ce7af3879ff10c38f45b1ebdda<c272566d4edbf24bb8c4df6114a524ac9>(c8f7bb1098b05790db33e0fccbf49275b);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0093;
					}
					continue;
					end_IL_0093:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public static void cf49a0ae0b7dc5f1a07f3194f5c12c134(this GameObject c80822505abd04406a7a821211bd77371, int c5e08b87896fbbb40d17a3a54c8c33b79)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "SetLayerRecursively");
		c80822505abd04406a7a821211bd77371.layer = c5e08b87896fbbb40d17a3a54c8c33b79;
		IEnumerator enumerator = c80822505abd04406a7a821211bd77371.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				transform.gameObject.cf49a0ae0b7dc5f1a07f3194f5c12c134(c5e08b87896fbbb40d17a3a54c8c33b79);
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
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0069;
					}
					continue;
					end_IL_0069:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public static void c052fcc480669a1cc86f8ab2fab5dd096(this GameObject c80822505abd04406a7a821211bd77371, bool c2f1f0f3c09f9a54c9c7bc74f7e080396)
	{
		Collider[] componentsInChildren = c80822505abd04406a7a821211bd77371.GetComponentsInChildren<Collider>();
		Collider[] array = componentsInChildren;
		foreach (Collider collider in array)
		{
			collider.enabled = c2f1f0f3c09f9a54c9c7bc74f7e080396;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public static int ca74f9f3e187d77aa0eda8323549aa4f1(this GameObject c80822505abd04406a7a821211bd77371, int cb1a5972b1dd78e6e559173bb63963122 = -1)
	{
		if (cb1a5972b1dd78e6e559173bb63963122 == -1)
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
			cb1a5972b1dd78e6e559173bb63963122 = c80822505abd04406a7a821211bd77371.layer;
		}
		int num = 0;
		for (int i = 0; i < 32; i++)
		{
			int num2 = num;
			int num3;
			if (Physics.GetIgnoreLayerCollision(cb1a5972b1dd78e6e559173bb63963122, i))
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
				num3 = 0;
			}
			else
			{
				num3 = 1;
			}
			num = num2 | (num3 << i);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return num;
		}
	}
}
