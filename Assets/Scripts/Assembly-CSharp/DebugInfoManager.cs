using System.Collections;
using System.Collections.Generic;
using A;
using Core;

public class DebugInfoManager : c06ca0e618478c23eba3419653a19760f<DebugInfoManager>
{
	public delegate void SubmitClientDebugInfoCallback(bool success);

	private Dictionary<int, DebugInfo> m_DebugInfoSet;

	private string m_Version;

	private uint m_AddCount;

	private uint m_ErrorAddCount;

	private Utils.Timer m_SendTimer = new Utils.Timer();

	private SubmitClientDebugInfoCallback mOnSubmitClientDebugInfo;

	public string cb88230e79e2ff2cd996739455e38a008
	{
		get
		{
			return m_Version;
		}
		set
		{
			m_Version = value;
		}
	}

	public DebugInfoManager()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(61, OnRecordClientDebugInfoCallback);
		c1e29bf89768403a73c63457c54b4f952();
	}

	private void c1e29bf89768403a73c63457c54b4f952()
	{
		m_AddCount = 0u;
		m_ErrorAddCount = 0u;
		m_DebugInfoSet = new Dictionary<int, DebugInfo>();
		if (!m_SendTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			m_SendTimer.cdada4c3678c9c23c38aaf0754a94a620();
		}
		m_SendTimer.Start(300f);
	}

	private void Update()
	{
		if (!m_SendTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			c5e814f8f15050575a5ee8b58cc76c7e5();
			return;
		}
	}

	public void c08ccbf69c814c779de221ec06231054a(DebugInfo c26d3544cd8a74b56851c33d30a9dc9a7)
	{
		int hashcode = c26d3544cd8a74b56851c33d30a9dc9a7.hashcode;
		if (m_DebugInfoSet.ContainsKey(hashcode))
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
			m_DebugInfoSet[hashcode].count++;
		}
		else
		{
			m_DebugInfoSet.Add(hashcode, c26d3544cd8a74b56851c33d30a9dc9a7);
		}
		m_AddCount++;
		if (!c26d3544cd8a74b56851c33d30a9dc9a7.isWarning)
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
			m_ErrorAddCount++;
		}
		if (m_AddCount <= 30)
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
			if (m_DebugInfoSet.Count <= 20)
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
				if (m_ErrorAddCount <= 5)
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
					break;
				}
			}
		}
		c5e814f8f15050575a5ee8b58cc76c7e5();
	}

	private void OnDestroy()
	{
		c5e814f8f15050575a5ee8b58cc76c7e5();
	}

	public void c4ae3903010e195bd0d78ba8e21b58260(bool ce789f9c3fe56ee71c44c6992c4b590bb)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Default, "DebugInfo submitted: " + ce789f9c3fe56ee71c44c6992c4b590bb);
	}

	public void c5e814f8f15050575a5ee8b58cc76c7e5()
	{
		if (m_DebugInfoSet.Count > 0)
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
			ca3e7c1999ddd096b986b8d0bc9b6c44f(c4ae3903010e195bd0d78ba8e21b58260, cb88230e79e2ff2cd996739455e38a008, m_DebugInfoSet);
		}
		c1e29bf89768403a73c63457c54b4f952();
	}

	private void ca3e7c1999ddd096b986b8d0bc9b6c44f(SubmitClientDebugInfoCallback c2db84530ef366a6deb001d449d4aa151, string cfa04e693fe6a31bc10ff3d61cf06d97d, Dictionary<int, DebugInfo> c591d56a94543e3559945c497f37126c4)
	{
		mOnSubmitClientDebugInfo = c2db84530ef366a6deb001d449d4aa151;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		using (Dictionary<int, DebugInfo>.ValueCollection.Enumerator enumerator = c591d56a94543e3559945c497f37126c4.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DebugInfo current = enumerator.Current;
				dictionary[num++] = new Hashtable
				{
					{ 0, current.hashcode },
					{ 1, current.count },
					{ 2, current.isFromHost },
					{ 3, current.isWarning },
					{ 4, current.type },
					{ 5, current.callstack },
					{ 6, current.message },
					{ 7, current.gameModeName },
					{ 8, current.instanceName },
					{ 9, current.mapName }
				};
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
				break;
			}
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = cfa04e693fe6a31bc10ff3d61cf06d97d;
		array[1] = dictionary;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(61, array);
	}

	private void OnRecordClientDebugInfoCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSubmitClientDebugInfo == null)
		{
			return;
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
			if (operationResponse == 0)
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
				mOnSubmitClientDebugInfo(true);
			}
			else
			{
				mOnSubmitClientDebugInfo(false);
			}
			mOnSubmitClientDebugInfo = null;
			return;
		}
	}
}
