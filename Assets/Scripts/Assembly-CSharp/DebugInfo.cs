using Core;

public class DebugInfo
{
	public int hashcode;

	public int count;

	public bool isFromHost;

	public bool isWarning;

	public LogCategory type;

	public string callstack;

	public string message;

	public string gameModeName;

	public string instanceName;

	public string mapName;

	public DebugInfo()
	{
		hashcode = 0;
		count = 1;
		isFromHost = false;
		isWarning = false;
		type = LogCategory.Default;
	}
}
