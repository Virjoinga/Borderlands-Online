using System.Collections;
using System.Collections.Generic;
using A;

public class MailService : OnAccessSingleton<IMailService, MailService, MailServiceOffline>, IMailService
{
	private List<OnNewMail> mOnNewMail = new List<OnNewMail>();

	private List<OnGetMailList> mOnMailList = new List<OnGetMailList>();

	private OnSendMail mOnSendMail;

	private OnGotMailInfo mOnGotMailInfo;

	private OnReadMail mOnReadMail;

	private OnGetMailItem mOnGetMailItem;

	private OnDeleteMail mOnDeleteMail;

	public MailService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(95, OnGotMail);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(94, OnSendmail);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(93, OnReadMail);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(92, OnGetMailItem);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(91, OnDeleteMail);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(167, OnNewMail);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(161, OnGetMailList);
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
	}

	private void OnGotMail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMailInfo == null)
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
			if (operationResponse != 0)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void OnSendmail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSendMail == null)
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
			short result = (short)parameters[0];
			mOnSendMail(result);
			return;
		}
	}

	private void OnReadMail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnReadMail == null)
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
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						int mailID = (int)parameters[0];
						mOnReadMail(operationResponse, mailID);
						return;
					}
					}
				}
			}
			mOnReadMail(operationResponse, 0);
			return;
		}
	}

	private void OnGetMailItem(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetMailItem == null)
		{
			return;
		}
		while (true)
		{
			switch (7)
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
						break;
					default:
					{
						int mailID = (int)parameters[0];
						mOnGetMailItem(operationResponse, mailID);
						return;
					}
					}
				}
			}
			mOnGetMailItem(operationResponse, 0);
			return;
		}
	}

	private void OnDeleteMail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnDeleteMail == null)
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
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						int mailID = (int)parameters[0];
						mOnDeleteMail(operationResponse, mailID);
						return;
					}
					}
				}
			}
			mOnDeleteMail(operationResponse, 0);
			return;
		}
	}

	private void OnNewMail(Dictionary<byte, object> parameters)
	{
		Hashtable c28cf3d24e3067ef54895f824fad7fcef = (Hashtable)parameters[0];
		MailInfo info = new MailInfo(c28cf3d24e3067ef54895f824fad7fcef);
		mOnNewMail.ForEach(delegate(OnNewMail c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(info);
		});
	}

	private void OnGetMailList(Dictionary<byte, object> parameters)
	{
		List<MailInfo> mailInfolist = new List<MailInfo>();
		using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				Hashtable c28cf3d24e3067ef54895f824fad7fcef = (Hashtable)current;
				MailInfo item = new MailInfo(c28cf3d24e3067ef54895f824fad7fcef);
				mailInfolist.Add(item);
			}
			while (true)
			{
				switch (7)
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
		mOnMailList.ForEach(delegate(OnGetMailList c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(mailInfolist);
		});
	}

	public void c890613d5d5185ad6eda570654aedce91(OnGotMailInfo c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMailInfo = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(95, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void c8c71e978b55bc1d65cffa8cba32ed71f(OnSendMail c2db84530ef366a6deb001d449d4aa151, string c76759d33b9cb2580a3b145e1ba084675, string ca04b8fe5d43144ba3361431c00741486)
	{
		mOnSendMail = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c76759d33b9cb2580a3b145e1ba084675;
		array[1] = ca04b8fe5d43144ba3361431c00741486;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(94, array);
	}

	public void c576f44b3071b0b941ce913d80b32bc52(OnReadMail c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3)
	{
		mOnReadMail = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = ca5b7408e6e09760b0d233c71c059aec3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(93, array);
	}

	public void ce7617ddfcf071c0b6b413615f347f61b(OnGetMailItem c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3)
	{
		mOnGetMailItem = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = ca5b7408e6e09760b0d233c71c059aec3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(92, array);
	}

	public void c094cd005fed2c85b5b372c1cd5d05775(OnDeleteMail c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3)
	{
		mOnDeleteMail = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = ca5b7408e6e09760b0d233c71c059aec3;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(91, array);
	}

	public void ca4195be1c246aa03c15dd07642fe960a(OnNewMail c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewMail.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c628345a20aafccc8d62d7968e6c99958(OnNewMail c2db84530ef366a6deb001d449d4aa151)
	{
		mOnNewMail.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c7e0ca5da43d892747e79cf62e65ac61d(OnGetMailList c2db84530ef366a6deb001d449d4aa151)
	{
		mOnMailList.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cae05037e9d0b26b34c9aef9068b0c2f5(OnGetMailList c2db84530ef366a6deb001d449d4aa151)
	{
		mOnMailList.Remove(c2db84530ef366a6deb001d449d4aa151);
	}
}
