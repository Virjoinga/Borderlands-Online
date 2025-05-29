using System.IO;
using A;
using Core;
using UnityEngine;

public class ProfilerManager
{
	private int m_startFrameCount;

	private int m_fragment;

	private string m_fileName = "Profile";

	private string m_filePath = "./";

	public void Start()
	{
		cf890dfcd41d697f8fb5e80bf11bc0865();
		ce514f575a996f9651380a6606787a61d(1);
	}

	public void Update()
	{
		if (Time.frameCount - m_startFrameCount <= 300)
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
			ce514f575a996f9651380a6606787a61d(m_fragment + 1);
			return;
		}
	}

	public void c59e178f2c7ccba5d03701b76606fdd6a()
	{
		c8e043feceb772a599d8ddc96384c0264(m_fragment + 1);
	}

	public void c8e043feceb772a599d8ddc96384c0264(int cf7e1698d61dae8c58aa7c24e35deac56)
	{
		m_fragment = cf7e1698d61dae8c58aa7c24e35deac56;
	}

	private void ce514f575a996f9651380a6606787a61d(int cf7e1698d61dae8c58aa7c24e35deac56)
	{
		Profiler.enableBinaryLog = false;
		Profiler.enabled = false;
		m_fragment = cf7e1698d61dae8c58aa7c24e35deac56;
		m_startFrameCount = Time.frameCount;
		Profiler.logFile = cf65bdac4cff432600320091eaa39a2e0(cf7e1698d61dae8c58aa7c24e35deac56);
		Profiler.enabled = true;
		Profiler.enableBinaryLog = true;
	}

	private string cf65bdac4cff432600320091eaa39a2e0(int cf7e1698d61dae8c58aa7c24e35deac56)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = m_fileName;
		array[1] = "_";
		array[2] = cf7e1698d61dae8c58aa7c24e35deac56;
		array[3] = ".txt";
		return string.Concat(array);
	}

	public void cbf99d619025619f3dd78c1d96fbce26f(string c8aa0e7ee156ed339de23d3fe5557b916)
	{
		m_filePath = c8aa0e7ee156ed339de23d3fe5557b916;
	}

	public string c6623cde42db4307c0b144942a5a8c70d()
	{
		return m_filePath;
	}

	public string cf65bdac4cff432600320091eaa39a2e0()
	{
		return m_fileName;
	}

	public void c5a009707cfc39db1700a3506239779ec(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		m_fileName = cd99af21e22e356018b8f72d4a7e4872a;
	}

	private void cf890dfcd41d697f8fb5e80bf11bc0865()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(c6623cde42db4307c0b144942a5a8c70d());
		FileInfo[] files = directoryInfo.GetFiles(cf65bdac4cff432600320091eaa39a2e0() + "*.*");
		for (int i = 0; i < files.Length; i++)
		{
			files[i].Delete();
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
			return;
		}
	}

	private void OnDestroy()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Tool, "profiler OnDestroy");
		Profiler.logFile = string.Empty;
		Profiler.enableBinaryLog = false;
		Profiler.enabled = false;
	}
}
