using System;
using System.Collections.Generic;
using System.Diagnostics;
using A;
using Core;
using UnityEngine;

public class DebugUtils : c06ca0e618478c23eba3419653a19760f<DebugUtils>
{
	public class AssertionFailure : Exception
	{
		public AssertionFailure(string caab9d8dfb7d644d03facdd28a727c15c)
			: base(caab9d8dfb7d644d03facdd28a727c15c)
		{
		}
	}

	private const int BLUE_ASSERT_MSG_BUFFER_SIZE = 8;

	public static DebugInfoSync s_debugInfoSync = ce816e47f44a3249de1e94401323b6e38.c7088de59e49f7108f520cf7e0bae167e;

	private static List<AssertInfo> s_blueAssertMsgList = new List<AssertInfo>(8);

	private static HashSet<int> s_ignoreList = new HashSet<int>();

	[Conditional("ASSERTS")]
	public static void c4b46105d009dbf1aafd94ca87d57b556(LogCategory c2b4f43f34e21572af6ab4414f04cee36, bool c71a4f9192b925ef69eb2abdd6bc6fdb3, string c01900ad1121c81d25e670954ca0fa686)
	{
		if (c71a4f9192b925ef69eb2abdd6bc6fdb3)
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
			if (c06ca0e618478c23eba3419653a19760f<c585561a7e2d1fad0661d8f890537fed4>.c5def92cf2ece25f46fbe9356a28a245b)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<c585561a7e2d1fad0661d8f890537fed4>.c5ee19dc8d4cccf5ae2de225410458b86.ce6db0d9bee52cc2eb4c88d724216d56c(c2b4f43f34e21572af6ab4414f04cee36, LogType.Assert, c01900ad1121c81d25e670954ca0fa686);
						return;
					}
				}
			}
			UnityEngine.Debug.LogException(new AssertionFailure(c2b4f43f34e21572af6ab4414f04cee36.ToString() + ": " + c01900ad1121c81d25e670954ca0fa686));
			return;
		}
	}

	[Conditional("ASSERTS")]
	public static void c4b46105d009dbf1aafd94ca87d57b556(LogCategory c2b4f43f34e21572af6ab4414f04cee36, bool c71a4f9192b925ef69eb2abdd6bc6fdb3)
	{
		if (c71a4f9192b925ef69eb2abdd6bc6fdb3)
		{
			return;
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
			if (c06ca0e618478c23eba3419653a19760f<c585561a7e2d1fad0661d8f890537fed4>.c5def92cf2ece25f46fbe9356a28a245b)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<c585561a7e2d1fad0661d8f890537fed4>.c5ee19dc8d4cccf5ae2de225410458b86.ce6db0d9bee52cc2eb4c88d724216d56c(c2b4f43f34e21572af6ab4414f04cee36, LogType.Assert, "Assert");
						return;
					}
				}
			}
			UnityEngine.Debug.LogException(new AssertionFailure(c2b4f43f34e21572af6ab4414f04cee36.ToString()));
			return;
		}
	}

	[Conditional("ASSERTS")]
	public static void cc2603722cbdfcea7b3772db97597b1d6(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c01900ad1121c81d25e670954ca0fa686)
	{
	}

	public static void c685f85e2cc0edfa0e2e605f0d9f5c843(string c01900ad1121c81d25e670954ca0fa686, bool c58e8848f549c624df6703bba5563e3ba = true)
	{
	}

	public static void cf0b3fb6bd5ca51ff80aedf8fd795fc56(float c8b071743957ea0c0c6ca2837a444f283, float c479e598be53a0ff34730ebdf38f36a51, float c8dec9f5d249eebe7fc80a3e7677ae480, float c3a91a1485df602ec90d40b81f520eafc, string c709b291ceac9f97f0c78f269054fa014, Color c34fce3bccfffc6feb3579939c6d9a057, int c302227ad8c545b0a24dabc9a8ffc7724 = 18)
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.fontSize = c302227ad8c545b0a24dabc9a8ffc7724;
		gUIStyle.normal.textColor = c34fce3bccfffc6feb3579939c6d9a057;
		float left = (float)Screen.width * Mathf.Clamp(c8b071743957ea0c0c6ca2837a444f283, 0f, 1f);
		float top = (float)Screen.height * Mathf.Clamp(c479e598be53a0ff34730ebdf38f36a51, 0f, 1f);
		float width = (float)Screen.width * Mathf.Clamp(c8dec9f5d249eebe7fc80a3e7677ae480, 0f, 1f - c8b071743957ea0c0c6ca2837a444f283);
		float height = (float)Screen.height * Mathf.Clamp(c3a91a1485df602ec90d40b81f520eafc, 0f, 1f - c479e598be53a0ff34730ebdf38f36a51);
		GUI.Label(new Rect(left, top, width, height), c709b291ceac9f97f0c78f269054fa014, gUIStyle);
	}

	public static GameObject c6d84ea4a8294eab54992c7770695143e(PrimitiveType c16d429d46571230958243dfb9a54a140, Color ca86c00a96d812a3d227b6bcad0f7fa2e)
	{
		return c6d84ea4a8294eab54992c7770695143e(c16d429d46571230958243dfb9a54a140, ca86c00a96d812a3d227b6bcad0f7fa2e, Vector3.one, Vector3.zero);
	}

	public static GameObject c6d84ea4a8294eab54992c7770695143e(PrimitiveType c16d429d46571230958243dfb9a54a140, Color ca86c00a96d812a3d227b6bcad0f7fa2e, Vector3 c52653cd226edee69dc40caf0157e2a97, Vector3 cef9712200bbe2c3873eec3ca2e18a595)
	{
		if (c16d429d46571230958243dfb9a54a140 == PrimitiveType.Plane)
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
		GameObject gameObject = GameObject.CreatePrimitive(c16d429d46571230958243dfb9a54a140);
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (gameObject.renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				gameObject.transform.localScale = c52653cd226edee69dc40caf0157e2a97;
				gameObject.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
				gameObject.renderer.material.color = ca86c00a96d812a3d227b6bcad0f7fa2e;
				if (gameObject.collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					gameObject.collider.enabled = false;
				}
				if (gameObject.rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					gameObject.rigidbody.useGravity = false;
				}
			}
		}
		return gameObject;
	}

	public static void ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014)
	{
	}

	public static void ce93ff017745857c486c984051026749f(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014)
	{
	}

	public static void ccb67deef6e071a99e91295f0b4aacc89(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014)
	{
		c9dcb1254e55b65d1a798e7fb9e087d29(c2b4f43f34e21572af6ab4414f04cee36, c709b291ceac9f97f0c78f269054fa014, Environment.StackTrace);
	}

	public static void ca041cad8077d8091bfbd7da873927657(Vector3 cef9712200bbe2c3873eec3ca2e18a595, float cb413b63b20e71ae5c504b03471480e2a, Color c2022f114954310f1130ded90da1fb8b7)
	{
		float num = cb413b63b20e71ae5c504b03471480e2a / 2f;
		UnityEngine.Debug.DrawLine(cef9712200bbe2c3873eec3ca2e18a595 - Vector3.up * num, cef9712200bbe2c3873eec3ca2e18a595 + Vector3.up * num, c2022f114954310f1130ded90da1fb8b7);
		UnityEngine.Debug.DrawLine(cef9712200bbe2c3873eec3ca2e18a595 - Vector3.right * num, cef9712200bbe2c3873eec3ca2e18a595 + Vector3.right * num, c2022f114954310f1130ded90da1fb8b7);
		UnityEngine.Debug.DrawLine(cef9712200bbe2c3873eec3ca2e18a595 - Vector3.forward * num, cef9712200bbe2c3873eec3ca2e18a595 + Vector3.forward * num, c2022f114954310f1130ded90da1fb8b7);
	}

	public static void c03c4670d916dd12d642937e0e2198517(UnityEngine.Object c2008d5793f81ed289732e3227d73f220)
	{
		Profiler.enabled = true;
		ce93ff017745857c486c984051026749f(LogCategory.System, "<<<Profile Memory Usage>>> time: " + Time.time);
		ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.System, "Used Heap Size: " + Profiler.usedHeapSize);
		ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.System, "Mono Heap Size: " + Profiler.GetMonoHeapSize());
		ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.System, "Mono Used Size: " + Profiler.GetMonoUsedSize());
		if (!(c2008d5793f81ed289732e3227d73f220 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
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
			ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.System, "[" + c2008d5793f81ed289732e3227d73f220.ToString() + "] runtime memory size: " + Profiler.GetRuntimeMemorySize(c2008d5793f81ed289732e3227d73f220));
			return;
		}
	}

	public static void c39b6c19f480c0bbbc890dd0202ecf6e2(int cc584cc0d388b61d19d26e1dcdd9be909)
	{
		s_ignoreList.Add(cc584cc0d388b61d19d26e1dcdd9be909);
		int num = 0;
		while (num < s_blueAssertMsgList.Count)
		{
			int hashCode = s_blueAssertMsgList[num].GetHashCode();
			if (s_ignoreList.Contains(hashCode))
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
				s_blueAssertMsgList.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public static void c9dcb1254e55b65d1a798e7fb9e087d29(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014, string c234559b393d74c9d27df1458e6a16b58, bool c2a4679134a8d7568dc18a3fb2e7e3ddd = false)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		if (string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_debugInfo_Version))
		{
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
		int hashcode = AssertInfo.cab05c97ab6dee558edc49d79f6a92ed1(AssertInfo.c265c495001426ebc83f0983ae99c0ead(), c2b4f43f34e21572af6ab4414f04cee36, c709b291ceac9f97f0c78f269054fa014, c234559b393d74c9d27df1458e6a16b58);
		bool isFromHost = false;
		DebugInfo debugInfo = new DebugInfo();
		debugInfo.hashcode = hashcode;
		debugInfo.isFromHost = isFromHost;
		debugInfo.isWarning = c2a4679134a8d7568dc18a3fb2e7e3ddd;
		debugInfo.type = c2b4f43f34e21572af6ab4414f04cee36;
		debugInfo.callstack = c234559b393d74c9d27df1458e6a16b58;
		debugInfo.message = c709b291ceac9f97f0c78f269054fa014;
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			debugInfo.gameModeName = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c1492faa4c1a9b76581845cee4d47d460();
			debugInfo.instanceName = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c9d8ee6a5af1e2ca6cb9e7b7a609a6d69();
			debugInfo.mapName = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650();
		}
		if (!(c06ca0e618478c23eba3419653a19760f<DebugInfoManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c06ca0e618478c23eba3419653a19760f<DebugInfoManager>.c5ee19dc8d4cccf5ae2de225410458b86.c08ccbf69c814c779de221ec06231054a(debugInfo);
			return;
		}
	}

	[Conditional("ASSERTS")]
	public static void cae0b9f33659b7fbac52dfab6504b5c17(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014, string c234559b393d74c9d27df1458e6a16b58, bool c2a4679134a8d7568dc18a3fb2e7e3ddd = false)
	{
		int item = AssertInfo.cab05c97ab6dee558edc49d79f6a92ed1(AssertInfo.c265c495001426ebc83f0983ae99c0ead(), c2b4f43f34e21572af6ab4414f04cee36, c709b291ceac9f97f0c78f269054fa014, c234559b393d74c9d27df1458e6a16b58);
		if (s_ignoreList.Contains(item))
		{
			return;
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
			if (c2a4679134a8d7568dc18a3fb2e7e3ddd)
			{
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
			if (s_blueAssertMsgList.Count >= 8)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				s_blueAssertMsgList.Add(new AssertInfo(AssertInfo.c265c495001426ebc83f0983ae99c0ead(), c2b4f43f34e21572af6ab4414f04cee36, c709b291ceac9f97f0c78f269054fa014, c234559b393d74c9d27df1458e6a16b58));
				return;
			}
		}
	}

	[Conditional("ASSERTS")]
	public static void c40e93239877f5bcf9b4f8fdbbb437029(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014, string c234559b393d74c9d27df1458e6a16b58)
	{
		if (s_blueAssertMsgList.Count >= 8)
		{
			return;
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
			AssertInfo.InfoSource cae5fea398599f41bfafc9b6bb6f4559b = AssertInfo.InfoSource.FromHost;
			s_blueAssertMsgList.Add(new AssertInfo(cae5fea398599f41bfafc9b6bb6f4559b, c2b4f43f34e21572af6ab4414f04cee36, c709b291ceac9f97f0c78f269054fa014, c234559b393d74c9d27df1458e6a16b58));
			return;
		}
	}
}
