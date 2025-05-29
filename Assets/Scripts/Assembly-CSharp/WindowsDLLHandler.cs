using System;
using System.IO;
using System.Runtime.InteropServices;

public static class WindowsDLLHandler
{
	[StructLayout(LayoutKind.Sequential, Size = 40)]
	private struct PROCESS_MEMORY_COUNTERS
	{
		public uint cb;

		public uint PageFaultCount;

		public uint PeakWorkingSetSize;

		public uint WorkingSetSize;

		public uint QuotaPeakPagedPoolUsage;

		public uint QuotaPagedPoolUsage;

		public uint QuotaPeakNonPagedPoolUsage;

		public uint QuotaNonPagedPoolUsage;

		public uint PagefileUsage;

		public uint PeakPagefileUsage;
	}

	private struct FILETIME
	{
		public uint dwLowDateTime;

		public uint dwHighDateTime;
	}

	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct PERFKIT_OUTPUT_COUNTERS
	{
		public int drawCall;
	}

	[DllImport("kernel32.dll", EntryPoint = "GetCurrentProcess")]
	private static extern IntPtr c9d01b5d2f2b993756decd10bc713f1fa();

	[DllImport("psapi.dll", EntryPoint = "GetProcessMemoryInfo")]
	private static extern bool cd5eafb1c15c2e31236ca388c75a9e9b3(IntPtr c9729d62f22bf714e0926d3a130e29ba4, out PROCESS_MEMORY_COUNTERS c1d3cabf741858e90c331b811e33da532, uint cb413b63b20e71ae5c504b03471480e2a);

	public static void c2069c18ea416ca4dbc2348f8910f5629(out uint cb427f3b34793a41fc0b9945d1a5b8bfe, out uint cd6be154afb6313aa3a63ad0f408b5db2)
	{
		cb427f3b34793a41fc0b9945d1a5b8bfe = 0u;
		cd6be154afb6313aa3a63ad0f408b5db2 = 0u;
		IntPtr c9729d62f22bf714e0926d3a130e29ba = c9d01b5d2f2b993756decd10bc713f1fa();
		PROCESS_MEMORY_COUNTERS c1d3cabf741858e90c331b811e33da = default(PROCESS_MEMORY_COUNTERS);
		c1d3cabf741858e90c331b811e33da.cb = 40u;
		if (!cd5eafb1c15c2e31236ca388c75a9e9b3(c9729d62f22bf714e0926d3a130e29ba, out c1d3cabf741858e90c331b811e33da, c1d3cabf741858e90c331b811e33da.cb))
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
			cb427f3b34793a41fc0b9945d1a5b8bfe = c1d3cabf741858e90c331b811e33da.WorkingSetSize;
			cd6be154afb6313aa3a63ad0f408b5db2 = c1d3cabf741858e90c331b811e33da.PeakWorkingSetSize;
			return;
		}
	}

	[DllImport("kernel32.dll", EntryPoint = "GetFileTime", SetLastError = true)]
	private static extern bool c3498bf0a3cbda7b32c5e67e60a810df9(IntPtr cffa8c6e7db8af55f84f3bb9448f08389, ref FILETIME cab73c5ed979666b16ab875c5e9e52738, ref FILETIME c9c4e264e7df366c0c77acbaf01d0a98c, ref FILETIME c42dc5a579c45392061c150b41fcb0152);

	public static long c18c19f46b2fe855ee57263b1ce58f738(string cb79b8911eb9af66441e604223827f9a7)
	{
		long num = 0L;
		if (File.Exists(cb79b8911eb9af66441e604223827f9a7))
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
			FileAttributes attributes = File.GetAttributes(cb79b8911eb9af66441e604223827f9a7);
			File.SetAttributes(cb79b8911eb9af66441e604223827f9a7, FileAttributes.Normal);
			FileStream fileStream = new FileStream(cb79b8911eb9af66441e604223827f9a7, FileMode.Open);
			FILETIME cab73c5ed979666b16ab875c5e9e = default(FILETIME);
			FILETIME c9c4e264e7df366c0c77acbaf01d0a98c = default(FILETIME);
			FILETIME c42dc5a579c45392061c150b41fcb = default(FILETIME);
			c3498bf0a3cbda7b32c5e67e60a810df9(fileStream.Handle, ref cab73c5ed979666b16ab875c5e9e, ref c9c4e264e7df366c0c77acbaf01d0a98c, ref c42dc5a579c45392061c150b41fcb);
			fileStream.Close();
			File.SetAttributes(cb79b8911eb9af66441e604223827f9a7, attributes);
			num |= c42dc5a579c45392061c150b41fcb.dwHighDateTime;
			num <<= 32;
			num |= c42dc5a579c45392061c150b41fcb.dwLowDateTime;
		}
		return num;
	}

	[DllImport("RenderingPlugin", EntryPoint = "GetPerfKitInfo")]
	public static extern bool c84304e2bc83bf3752276a0b4dbdb52ec(out PERFKIT_OUTPUT_COUNTERS c71436dcd42b5d2e953f73bdff98b2142);
}
