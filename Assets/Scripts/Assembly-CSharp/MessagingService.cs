using System;
using System.Collections;
using System.Collections.Generic;
using A;

internal class MessagingService : OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>, IMessagingService
{
	private Dictionary<string, OnRecieveMessage> mMessageListeners = new Dictionary<string, OnRecieveMessage>();

	private OnRetrieveMessages mOnRetrieveMessages;

	public MessagingService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(210, OnMessagesRetrieved);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(223, OnMessageReceived);
	}

	public void c3038b415cbe30276baad8d2aa3e51f9d(int ca8606b1ba21cbc6f2fc0045fe691e617, string c2b4f43f34e21572af6ab4414f04cee36, int c9be4474f3dd1bda719e783b821adff65 = 0)
	{
		c3038b415cbe30276baad8d2aa3e51f9d(ca8606b1ba21cbc6f2fc0045fe691e617, c2b4f43f34e21572af6ab4414f04cee36, string.Empty, c9be4474f3dd1bda719e783b821adff65);
	}

	public void c3038b415cbe30276baad8d2aa3e51f9d(int ca8606b1ba21cbc6f2fc0045fe691e617, string c2b4f43f34e21572af6ab4414f04cee36, string cc1acc7d59b8af7a10736894c2916aed9, int c9be4474f3dd1bda719e783b821adff65 = 0)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = ca8606b1ba21cbc6f2fc0045fe691e617;
		array[1] = c2b4f43f34e21572af6ab4414f04cee36;
		array[2] = cc1acc7d59b8af7a10736894c2916aed9;
		array[3] = c9be4474f3dd1bda719e783b821adff65;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(211, array);
	}

	public void cde08d917e68f9dec60dac2ce9359317f(OnRetrieveMessages c2db84530ef366a6deb001d449d4aa151, string c2b4f43f34e21572af6ab4414f04cee36, bool cddd5f08d1f91cfa8eccf5e07a53ca213, int cb9de848f0954cfda229568ddfad44033 = 1, int cbd27e27b8828e4abd80513cb973357c9 = 50)
	{
		mOnRetrieveMessages = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = c2b4f43f34e21572af6ab4414f04cee36;
		array[1] = cddd5f08d1f91cfa8eccf5e07a53ca213;
		array[2] = cb9de848f0954cfda229568ddfad44033;
		array[3] = cbd27e27b8828e4abd80513cb973357c9;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(210, array);
	}

	private void OnMessagesRetrieved(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnRetrieveMessages == null)
		{
			return;
		}
		Message c36964cf41281414170f34ee68bef6c = default(Message);
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
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				Dictionary<int, Hashtable> dictionary = (Dictionary<int, Hashtable>)parameters[0];
				Message[] array = cd359505afc6b8adae8e6647672eba86b.c0a0cdf4a196914163f7334d9b0781a04(dictionary.Count);
				int num = 0;
				using (Dictionary<int, Hashtable>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, Hashtable> current = enumerator.Current;
						ref Message reference = ref array[num++];
						c64a2c4bf2a7716138baf875621ffdb2c.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
						c36964cf41281414170f34ee68bef6c.mId = (int)current.Value["id"];
						c36964cf41281414170f34ee68bef6c.mSender = (int)current.Value["sender"];
						c36964cf41281414170f34ee68bef6c.mType = (string)current.Value["type"];
						c36964cf41281414170f34ee68bef6c.mPayload = (string)current.Value["payload"];
						c36964cf41281414170f34ee68bef6c.mRead = (int)current.Value["read"] != 0;
						reference = c36964cf41281414170f34ee68bef6c;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_013a;
						}
						continue;
						end_IL_013a:
						break;
					}
				}
				mOnRetrieveMessages(array);
			}
			else
			{
				mOnRetrieveMessages(c39d1e6080a7905c649c0530c053a3293.c7088de59e49f7108f520cf7e0bae167e);
			}
			mOnRetrieveMessages = c8b23fe5eb24d110d85f658bc4fc890b1.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c1709a1af25ca95ef1c069105964a4640(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(209, array);
	}

	public void ce4f66b66479413697c4095985f07fe73(int c93f916e26c7f7aec4117058ff8a6c39d)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c93f916e26c7f7aec4117058ff8a6c39d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(208, array);
	}

	public void c87d2b468801f2ac5185e4eea8e8cf7a3(string c2b4f43f34e21572af6ab4414f04cee36, OnRecieveMessage c2db84530ef366a6deb001d449d4aa151)
	{
		if (mMessageListeners.ContainsKey(c2b4f43f34e21572af6ab4414f04cee36))
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
					throw new ArgumentException(string.Format("RegisterMessageListener: Already registered a callback for type {0}", c2b4f43f34e21572af6ab4414f04cee36), "type");
				}
			}
		}
		mMessageListeners[c2b4f43f34e21572af6ab4414f04cee36] = c2db84530ef366a6deb001d449d4aa151;
	}

	public void cb8c223bd7f3fdc89bab4c0b9ae2448f5(string c2b4f43f34e21572af6ab4414f04cee36)
	{
		mMessageListeners.Remove(c2b4f43f34e21572af6ab4414f04cee36);
	}

	private void OnMessageReceived(Dictionary<byte, object> parameters)
	{
		Message c36964cf41281414170f34ee68bef6c = default(Message);
		c64a2c4bf2a7716138baf875621ffdb2c.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		Message message = c36964cf41281414170f34ee68bef6c;
		message.mId = (int)parameters[0];
		message.mSender = (int)parameters[1];
		message.mType = (string)parameters[2];
		message.mPayload = (string)parameters[3];
		c36964cf41281414170f34ee68bef6c = message;
		if (!mMessageListeners.ContainsKey(c36964cf41281414170f34ee68bef6c.mType))
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
			mMessageListeners[c36964cf41281414170f34ee68bef6c.mType](c36964cf41281414170f34ee68bef6c);
			return;
		}
	}
}
