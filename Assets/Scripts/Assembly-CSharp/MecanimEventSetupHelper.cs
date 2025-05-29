using A;
using Core;
using UnityEngine;

public class MecanimEventSetupHelper : MonoBehaviour
{
	public const string ANIMEVENTHOLDER_ASSET_NAME_CLIENT = "Animation_Events";

	public const string ANIMEVENTHOLDER_ASSET_NAME_HOST = "Animation_Events_Host";

	public MecanimEventData dataSource;

	public MecanimEventData[] dataSources;

	private void Awake()
	{
		dataSource = (Resources.Load("Animation_Events") as GameObject).GetComponent<MecanimEventData>();
		if (dataSource == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (dataSources != null)
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
				if (dataSources.Length != 0)
				{
					goto IL_0078;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Tool, "Please setup data source of event system.");
			return;
		}
		goto IL_0078;
		IL_0078:
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Animation, "Loading animation event data");
		if (dataSource != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					MecanimEventManager.cc4e23f6e10a2b78b8eadcac95739d7cc(dataSource);
					return;
				}
			}
		}
		MecanimEventManager.cc4e23f6e10a2b78b8eadcac95739d7cc(dataSources);
	}
}
