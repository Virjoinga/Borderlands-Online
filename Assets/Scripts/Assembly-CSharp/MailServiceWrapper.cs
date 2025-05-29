using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Core;

public class MailServiceWrapper : ServiceWrapper<IMailServiceWrapper, MailServiceWrapper>
{
	public static readonly int MAILBOX_MAXVOLUME = 50;

	public static readonly TimeSpan MAIL_LIFETIME = new TimeSpan(7, 0, 0, 0);

	protected static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	protected Dictionary<int, MailInfo> m_dicMailInfo = new Dictionary<int, MailInfo>();

	protected List<MailInfo> m_redundantMailCache = new List<MailInfo>();

	protected List<IMailServiceNotificationListener> m_mailListeners = new List<IMailServiceNotificationListener>();

	protected bool m_bInited;

	protected int m_iUnreadMailCnt;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_bInited)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_wrapperOnline = new MailServiceWrapperOnline();
			base.cd93285db16841148ed53a5bbeb35cf20();
			m_bInited = true;
			return;
		}
	}

	public void OnNewMail(MailInfo newmail)
	{
		if (c523ec0dfb69bb7009ba642095a37bdb8(newmail))
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
			cb4f1e56568134f57878645d9cebdfda2();
			using (List<IMailServiceNotificationListener>.Enumerator enumerator = m_mailListeners.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IMailServiceNotificationListener current = enumerator.Current;
					current.OnGetNewMail(newmail);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0050;
					}
					continue;
					end_IL_0050:
					break;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnReceiveMail();
	}

	public void OnSendMail(short result)
	{
		using (List<IMailServiceNotificationListener>.Enumerator enumerator = m_mailListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IMailServiceNotificationListener current = enumerator.Current;
				current.OnSendMail(result == 0);
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
				return;
			}
		}
	}

	public void OnReadMail(short result, int mailID)
	{
		if (result != 0)
		{
			while (true)
			{
				switch (4)
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
		MailInfo value = ca330b29ca6c3cfd41683c3b8f4596c19.c7088de59e49f7108f520cf7e0bae167e;
		if (m_dicMailInfo.TryGetValue(mailID, out value))
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
			value.Mailstate = MailState.Read;
		}
		cb4f1e56568134f57878645d9cebdfda2();
		using (List<IMailServiceNotificationListener>.Enumerator enumerator = m_mailListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IMailServiceNotificationListener current = enumerator.Current;
				current.OnReadMail(mailID);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void OnGetMailList(List<MailInfo> mailList)
	{
		c1f54491846b3f3d082034fd599506d29(mailList);
		cb4f1e56568134f57878645d9cebdfda2();
		using (List<IMailServiceNotificationListener>.Enumerator enumerator = m_mailListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IMailServiceNotificationListener current = enumerator.Current;
				current.OnGetMailList(mailList);
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
				return;
			}
		}
	}

	public void OnDeleteMail(short result, int mailID)
	{
		if (result != 0)
		{
			while (true)
			{
				switch (1)
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
		if (m_dicMailInfo.ContainsKey(mailID))
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
			m_dicMailInfo.Remove(mailID);
		}
		cb4f1e56568134f57878645d9cebdfda2();
		using (List<IMailServiceNotificationListener>.Enumerator enumerator = m_mailListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IMailServiceNotificationListener current = enumerator.Current;
				current.OnDeleteMail(mailID);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0072;
				}
				continue;
				end_IL_0072:
				break;
			}
		}
		if (m_redundantMailCache.Count <= 0)
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
			MailInfo mailInfo = m_redundantMailCache[0];
			m_redundantMailCache.RemoveAt(0);
			if (!c523ec0dfb69bb7009ba642095a37bdb8(mailInfo))
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				cb4f1e56568134f57878645d9cebdfda2();
				using (List<IMailServiceNotificationListener>.Enumerator enumerator2 = m_mailListeners.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						IMailServiceNotificationListener current2 = enumerator2.Current;
						current2.OnGetNewMail(mailInfo);
					}
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
			}
		}
	}

	public void OnGetMailItem(short sResult, int iMailID)
	{
		cb4f1e56568134f57878645d9cebdfda2();
		using (List<IMailServiceNotificationListener>.Enumerator enumerator = m_mailListeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IMailServiceNotificationListener current = enumerator.Current;
				current.OnGetmailItem(sResult, iMailID);
			}
			while (true)
			{
				switch (3)
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
	}

	public List<MailInfo> cfd9d57231f4e8e67b5a6a492bc70a1a0()
	{
		List<MailInfo> list = new List<MailInfo>(m_dicMailInfo.Values.ToArray());
		list.Sort(c5672e2228883a74cd1be8dfe8ee6b167);
		return list;
	}

	public void c523e4a3a3feaf78d0e1c44cb5f113f7c(IMailServiceNotificationListener c09989e964911211e138c08f0f6407679)
	{
		m_mailListeners.Add(c09989e964911211e138c08f0f6407679);
	}

	public int c7115852a11d7d7b2222deb4caf2937ed()
	{
		return m_iUnreadMailCnt;
	}

	public void c92508dc6911d2386ea0db5b2e4a3f935(IMailServiceNotificationListener c09989e964911211e138c08f0f6407679)
	{
		m_mailListeners.Remove(c09989e964911211e138c08f0f6407679);
	}

	protected void c1f54491846b3f3d082034fd599506d29(List<MailInfo> ceefdd9aaa2067bc5d7f5c64d195a78f9)
	{
		if (ceefdd9aaa2067bc5d7f5c64d195a78f9 == null)
		{
			while (true)
			{
				switch (6)
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
		using (List<MailInfo>.Enumerator enumerator = ceefdd9aaa2067bc5d7f5c64d195a78f9.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MailInfo current = enumerator.Current;
				c523ec0dfb69bb7009ba642095a37bdb8(current);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0041;
				}
				continue;
				end_IL_0041:
				break;
			}
		}
		m_redundantMailCache.Sort(c5672e2228883a74cd1be8dfe8ee6b167);
	}

	protected bool c523ec0dfb69bb7009ba642095a37bdb8(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
	{
		bool result = false;
		if (m_dicMailInfo.Count < MAILBOX_MAXVOLUME)
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
			if (!m_dicMailInfo.ContainsKey(c581d1dfdd43628e29bfec127d5c010fa.MailID))
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
				m_dicMailInfo.Add(c581d1dfdd43628e29bfec127d5c010fa.MailID, c581d1dfdd43628e29bfec127d5c010fa);
				result = true;
			}
			else
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Get duplicate mail ID of " + c581d1dfdd43628e29bfec127d5c010fa.MailID);
			}
		}
		else
		{
			m_redundantMailCache.Add(c581d1dfdd43628e29bfec127d5c010fa);
		}
		return result;
	}

	protected int c5672e2228883a74cd1be8dfe8ee6b167(MailInfo cdaf667732077cb4e47e88271a5111be8, MailInfo c9be6399ffeed34be2b305daf0dda906d)
	{
		DateTime dateTime = EPOCH.AddSeconds(cdaf667732077cb4e47e88271a5111be8.Expiration).ToLocalTime();
		DateTime dateTime2 = EPOCH.AddSeconds(c9be6399ffeed34be2b305daf0dda906d.Expiration).ToLocalTime();
		return -(dateTime - dateTime2).Seconds;
	}

	protected void cb4f1e56568134f57878645d9cebdfda2()
	{
		m_iUnreadMailCnt = 0;
		using (Dictionary<int, MailInfo>.ValueCollection.Enumerator enumerator = m_dicMailInfo.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MailInfo current = enumerator.Current;
				if (current.Mailstate != 0)
				{
					continue;
				}
				while (true)
				{
					switch (5)
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
				m_iUnreadMailCnt++;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void c890613d5d5185ad6eda570654aedce91()
	{
		c9374c9e18d64e753feff5ba5622a02ad().c890613d5d5185ad6eda570654aedce91(cf5e290519fc8dbad1352379c308ffaa2.c7088de59e49f7108f520cf7e0bae167e);
	}

	public void c8c71e978b55bc1d65cffa8cba32ed71f(string c76759d33b9cb2580a3b145e1ba084675, string ca04b8fe5d43144ba3361431c00741486)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c8c71e978b55bc1d65cffa8cba32ed71f(OnSendMail, c76759d33b9cb2580a3b145e1ba084675, ca04b8fe5d43144ba3361431c00741486);
	}

	public void c576f44b3071b0b941ce913d80b32bc52(int ca5b7408e6e09760b0d233c71c059aec3)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c576f44b3071b0b941ce913d80b32bc52(OnReadMail, ca5b7408e6e09760b0d233c71c059aec3);
	}

	public void c094cd005fed2c85b5b372c1cd5d05775(int ca5b7408e6e09760b0d233c71c059aec3)
	{
		c9374c9e18d64e753feff5ba5622a02ad().c094cd005fed2c85b5b372c1cd5d05775(OnDeleteMail, ca5b7408e6e09760b0d233c71c059aec3);
	}

	public void ce7617ddfcf071c0b6b413615f347f61b(int ca5b7408e6e09760b0d233c71c059aec3)
	{
		c9374c9e18d64e753feff5ba5622a02ad().ce7617ddfcf071c0b6b413615f347f61b(OnGetMailItem, ca5b7408e6e09760b0d233c71c059aec3);
	}
}
