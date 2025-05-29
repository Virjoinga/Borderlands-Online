using System;
using A;

internal class StatsService : OnAccessSingleton<IStatsService, StatsService, StatsService>, IStatsService
{
	private string mGameServerName;

	private string mAddress;

	private bool mEnabled;

	public StatsService()
	{
		int num;
		if (!string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_gameServerName))
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
			num = ((!string.IsNullOrEmpty(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_statsDBAddress)) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		mEnabled = (byte)num != 0;
		if (!mEnabled)
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
			mGameServerName = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_gameServerName;
			mAddress = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_statsDBAddress;
			return;
		}
	}

	public void cf76434d43128d0c642b22989c9bd835d(string c7c285f21497bec76d425ba4a0a524b46, int ca1fe61abde52868f679caf67108b2858, int c24a23635a8b6b95d7730eefdf77f7b9e, int c5dfde30d8784694fb9999709d290e6c4, string cf02cbedfd63c343e590df85de90aed56)
	{
		if (!mEnabled)
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
			JSONObject jSONObject = cc89c11f400ed039616be4b71002341d4();
			jSONObject.AddField("game_mode", c7c285f21497bec76d425ba4a0a524b46);
			jSONObject.AddField("playlist_id", ca1fe61abde52868f679caf67108b2858);
			jSONObject.AddField("account_id", c24a23635a8b6b95d7730eefdf77f7b9e);
			jSONObject.AddField("character_id", c5dfde30d8784694fb9999709d290e6c4);
			jSONObject.AddField("character_name", cf02cbedfd63c343e590df85de90aed56);
			HttpHelper.c5ee19dc8d4cccf5ae2de225410458b86.c792f1c0f8c1b48739428cedef1acbe53(mAddress, "/py/enter", jSONObject);
			return;
		}
	}

	public void c92e26b4ee182d64071fc2b885c172e51(string c7c285f21497bec76d425ba4a0a524b46, int ca1fe61abde52868f679caf67108b2858, int c24a23635a8b6b95d7730eefdf77f7b9e, int c5dfde30d8784694fb9999709d290e6c4, string cf02cbedfd63c343e590df85de90aed56)
	{
		if (!mEnabled)
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
			JSONObject jSONObject = cc89c11f400ed039616be4b71002341d4();
			jSONObject.AddField("game_mode", c7c285f21497bec76d425ba4a0a524b46);
			jSONObject.AddField("playlist_id", ca1fe61abde52868f679caf67108b2858);
			jSONObject.AddField("account_id", c24a23635a8b6b95d7730eefdf77f7b9e);
			jSONObject.AddField("character_id", c5dfde30d8784694fb9999709d290e6c4);
			jSONObject.AddField("character_name", cf02cbedfd63c343e590df85de90aed56);
			HttpHelper.c5ee19dc8d4cccf5ae2de225410458b86.c792f1c0f8c1b48739428cedef1acbe53(mAddress, "/py/leave", jSONObject);
			return;
		}
	}

	private JSONObject cc89c11f400ed039616be4b71002341d4()
	{
		JSONObject jSONObject = new JSONObject(JSONObject.Type.OBJECT);
		jSONObject.AddField("server_name", mGameServerName);
		jSONObject.AddField("ts", (float)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
		jSONObject.AddField("account_id", OnlineService.s_accountId);
		jSONObject.AddField("character_id", OnlineService.s_characterId);
		jSONObject.AddField("character_name", OnlineService.s_userName);
		return jSONObject;
	}
}
