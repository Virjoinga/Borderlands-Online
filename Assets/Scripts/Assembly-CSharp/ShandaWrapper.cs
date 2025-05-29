using System;
using System.Runtime.InteropServices;
using System.Text;
using A;
using Core;
using UnityEngine;

public class ShandaWrapper : MonoBehaviour
{
	public static int ApplicationId = 991002125;

	public static string ApplicationName = "BorderlandsOnline";

	public static int AreaID;

	public static int GroupId;

	public static string ShandaTicket;

	private bool m_isActive;

	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "Setup", SetLastError = true)]
	private static extern void c7cc9411392f033dee9802f9b9ca15b21(int c0f2c35402a8abd489481ccc7869a969c, string c0e40ef25a53ed6e30048ac0529145a18, string cfa04e693fe6a31bc10ff3d61cf06d97d, int cb139a8c0027f9fa34f51b508104e4f66, int c096e36f17994e915a6f91e11e71970d1);

	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "Run", SetLastError = true)]
	private static extern bool c54f663d031060dfb1dcd6967f5db0271(StringBuilder c00afa02ef6760e8cab5cb65b892f6255);

	[DllImport("ShandaLoginWrapper", EntryPoint = "Exit", SetLastError = true)]
	private static extern void caacc5394c9463f79848e6dba1aae8693();

	[DllImport("ShandaLoginWrapper", EntryPoint = "StartGPK", SetLastError = true)]
	private static extern void cc011895ac22e991b52cb0efba17ab57f();

	[DllImport("ShandaLoginWrapper", EntryPoint = "StopGPK", SetLastError = true)]
	private static extern void ccef3a5926581ef5e2179effcb1a346f0();

	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetDynCode", SetLastError = true)]
	private static extern bool c11d1c6ebed60544836d56fdc0ccabb91(IntPtr c7a370d40b62d33bf286d242c405e9c55, int cb413b63b20e71ae5c504b03471480e2a);

	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ProcessAuth", SetLastError = true)]
	private static extern int ca4cbfff60fdab868f4e783c190d8f45d(IntPtr c7a370d40b62d33bf286d242c405e9c55, int cb413b63b20e71ae5c504b03471480e2a);

	private void Awake()
	{
		cc011895ac22e991b52cb0efba17ab57f();
	}

	private void Start()
	{
		if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_enableSndaLogin)
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
			m_isActive = true;
			c7cc9411392f033dee9802f9b9ca15b21(ApplicationId, ApplicationName, c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_debugInfo_Version, AreaID, GroupId);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "ShandaLogin.Start Setup is done, now need to obtain Ticket.");
			StringBuilder stringBuilder = new StringBuilder(255);
			if (c54f663d031060dfb1dcd6967f5db0271(stringBuilder))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, string.Concat("ShandaLogin.Start Done [", stringBuilder, "]"));
						ShandaTicket = stringBuilder.ToString();
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c3b8d7ef091ecb61c8a7ddeaa2a74c5c0 = ShandaTicket;
						return;
					}
				}
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "ShandaLogin.Start Fail to get ticket");
			m_isActive = false;
			caacc5394c9463f79848e6dba1aae8693();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5a4ebf25aa046ef293fa9ea449fcbb09();
			return;
		}
	}

	public static void ca227271e272a3ddbfc646f54fb14ea53(byte[] cee2974c46a5e5de8cca196c64f5b096a)
	{
		int cb = Marshal.SizeOf(cee2974c46a5e5de8cca196c64f5b096a[0]) * cee2974c46a5e5de8cca196c64f5b096a.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(cb);
		try
		{
			Marshal.Copy(cee2974c46a5e5de8cca196c64f5b096a, 0, intPtr, cee2974c46a5e5de8cca196c64f5b096a.Length);
		}
		finally
		{
		}
		c11d1c6ebed60544836d56fdc0ccabb91(intPtr, cee2974c46a5e5de8cca196c64f5b096a.Length);
		Marshal.FreeHGlobal(intPtr);
	}

	public static void ca4cbfff60fdab868f4e783c190d8f45d(ref byte[] c18e550f1027ab9e606a5d720bbb84521)
	{
		int cb = Marshal.SizeOf(c18e550f1027ab9e606a5d720bbb84521[0]) * c18e550f1027ab9e606a5d720bbb84521.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(cb);
		try
		{
			Marshal.Copy(c18e550f1027ab9e606a5d720bbb84521, 0, intPtr, c18e550f1027ab9e606a5d720bbb84521.Length);
		}
		finally
		{
		}
		int num = ca4cbfff60fdab868f4e783c190d8f45d(intPtr, c18e550f1027ab9e606a5d720bbb84521.Length);
		Marshal.Copy(intPtr, c18e550f1027ab9e606a5d720bbb84521, 0, c18e550f1027ab9e606a5d720bbb84521.Length);
		Marshal.FreeHGlobal(intPtr);
	}

	private void OnDestroy()
	{
		if (m_isActive)
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
			m_isActive = false;
			caacc5394c9463f79848e6dba1aae8693();
		}
		ccef3a5926581ef5e2179effcb1a346f0();
	}
}
