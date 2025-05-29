using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using XsdSettings;

public class Presence
{
	public readonly DateTime EPOCH;

	public int mCharacterId;

	public bool mIsOnline;

	public DateTime mLastOnline;

	public int mCurrentTown;

	public string mCharacterName;

	public int mCharacterLevel;

	public int mCharacterExperience;

	public int mCurrency;

	public AvatarType mAvatarType;

	public int mGroupId;

	public int mLobbyId;

	public int mMatchCount;

	public int mWinCount;

	public int mLossCount;

	public int mKillCount;

	public int mDeathCount;

	public int mHonorPoint;

	public AvatarDNA mAvatarDNA;

	[CompilerGenerated]
	private static Func<DictionaryEntry, byte> _003C_003Ef__am_0024cache13;

	[CompilerGenerated]
	private static Func<DictionaryEntry, object> _003C_003Ef__am_0024cache14;

	public Presence(Dictionary<byte, object> c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		base._002Ector();
		mCharacterId = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[0];
		mIsOnline = Convert.ToBoolean(c90ecb087828ed9ceb9c00eafb6d52f4c[1]);
		mLastOnline = EPOCH.AddSeconds((int)c90ecb087828ed9ceb9c00eafb6d52f4c[2]).ToLocalTime();
		int num;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c[3] == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			num = -1;
		}
		else
		{
			num = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[3];
		}
		mCurrentTown = num;
		mCharacterLevel = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[4];
		mCharacterExperience = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[5];
		mCurrency = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[6];
		mAvatarType = (AvatarType)(int)c90ecb087828ed9ceb9c00eafb6d52f4c[7];
		string c6b68f14f85f7cff7a7223716d1482ecd = (string)c90ecb087828ed9ceb9c00eafb6d52f4c[8];
		string cad1f12a1809d71a01e4f458971f0b77d = (string)c90ecb087828ed9ceb9c00eafb6d52f4c[9];
		uint c35f98ccbfa8c6bf09319c620b21b5dc = (uint)(int)c90ecb087828ed9ceb9c00eafb6d52f4c[10];
		mAvatarDNA = new AvatarDNA();
		mAvatarDNA.c300c4ff719a5623d8161bef607d268f1(mAvatarType, c6b68f14f85f7cff7a7223716d1482ecd, cad1f12a1809d71a01e4f458971f0b77d, c35f98ccbfa8c6bf09319c620b21b5dc);
		mCharacterName = (string)c90ecb087828ed9ceb9c00eafb6d52f4c[11];
		mGroupId = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[13];
		mLobbyId = (int)c90ecb087828ed9ceb9c00eafb6d52f4c[14];
		int num2;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.ContainsKey(15))
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
			num2 = Convert.ToInt32(c90ecb087828ed9ceb9c00eafb6d52f4c[15]);
		}
		else
		{
			num2 = 0;
		}
		mMatchCount = num2;
		int num3;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.ContainsKey(16))
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
			num3 = Convert.ToInt32(c90ecb087828ed9ceb9c00eafb6d52f4c[16]);
		}
		else
		{
			num3 = 0;
		}
		mWinCount = num3;
		int num4;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.ContainsKey(17))
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
			num4 = Convert.ToInt32(c90ecb087828ed9ceb9c00eafb6d52f4c[17]);
		}
		else
		{
			num4 = 0;
		}
		mLossCount = num4;
		int num5;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.ContainsKey(18))
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
			num5 = Convert.ToInt32(c90ecb087828ed9ceb9c00eafb6d52f4c[18]);
		}
		else
		{
			num5 = 0;
		}
		mKillCount = num5;
		int num6;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.ContainsKey(19))
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
			num6 = Convert.ToInt32(c90ecb087828ed9ceb9c00eafb6d52f4c[19]);
		}
		else
		{
			num6 = 0;
		}
		mDeathCount = num6;
		int num7;
		if (c90ecb087828ed9ceb9c00eafb6d52f4c.ContainsKey(20))
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
			num7 = Convert.ToInt32(c90ecb087828ed9ceb9c00eafb6d52f4c[20]);
		}
		else
		{
			num7 = 0;
		}
		mHonorPoint = num7;
	}

	public Presence(Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		IEnumerable<DictionaryEntry> source = c90ecb087828ed9ceb9c00eafb6d52f4c.Cast<DictionaryEntry>();
		if (_003C_003Ef__am_0024cache13 == null)
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
			_003C_003Ef__am_0024cache13 = (DictionaryEntry ca0ee14efefffcd61d83480281a6f39ab) => (byte)(int)ca0ee14efefffcd61d83480281a6f39ab.Key;
		}
		Func<DictionaryEntry, byte> keySelector = _003C_003Ef__am_0024cache13;
		if (_003C_003Ef__am_0024cache14 == null)
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
			_003C_003Ef__am_0024cache14 = (DictionaryEntry ca0ee14efefffcd61d83480281a6f39ab) => ca0ee14efefffcd61d83480281a6f39ab.Value;
		}
		this._002Ector(source.ToDictionary(keySelector, _003C_003Ef__am_0024cache14));
	}

	[CompilerGenerated]
	private static byte c4ac49420f417737bc8db374299d61999(DictionaryEntry ca0ee14efefffcd61d83480281a6f39ab)
	{
		return (byte)(int)ca0ee14efefffcd61d83480281a6f39ab.Key;
	}

	[CompilerGenerated]
	private static object c3f057f5a18a4fc0577bfbf6698c7a18f(DictionaryEntry ca0ee14efefffcd61d83480281a6f39ab)
	{
		return ca0ee14efefffcd61d83480281a6f39ab.Value;
	}
}
