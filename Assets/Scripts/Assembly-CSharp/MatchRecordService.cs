using System.Collections;
using System.Collections.Generic;
using A;

public class MatchRecordService : OnAccessSingleton<IMatchRecordService, MatchRecordService, MatchRecordServiceOffline>, IMatchRecordService
{
	private GetMatchRecordCallback mOnGotMatchRecord;

	public MatchRecordService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(148, OnRequestMatchRecordCallback);
	}

	public void c01213846eb5656726889fdb7be49adac(GetMatchRecordCallback c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		mOnGotMatchRecord = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(148, array);
	}

	private void OnRequestMatchRecordCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMatchRecord == null)
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
			if (operationResponse == 0)
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
				MatchRecord record = new MatchRecord((Hashtable)parameters[0]);
				mOnGotMatchRecord(record);
			}
			mOnGotMatchRecord = cf2637fa11396f94d883a1a7af67a8a9a.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}
}
