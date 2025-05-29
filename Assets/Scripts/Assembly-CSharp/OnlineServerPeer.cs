using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using ExitGames.Client.Photon;

internal class OnlineServerPeer : PhotonPeer, IPhotonPeerListener
{
	private struct OnlineCallParameters
	{
		public byte mOperationCode;

		public object[] mParameters;
	}

	public IPhotonPeerListener externalListener;

	public string mAppVersion;

	private string mAppId;

	public string maccount;

	public string mpwd;

	public string mToken;

	private Queue<OnlineCallParameters> mOnlineCallQueue;

	private Dictionary<byte, OperationResponseCallback> mOperationResponseCallbacks;

	private Dictionary<byte, EventCallback> mEventCallbacks;

	public PeerState State { get; internal set; }

	public bool mIsAuthenticated { get; private set; }

	public string OnlineServerAddr { get; internal set; }

	public OnlineServerPeer(IPhotonPeerListener c472a3b7c9dbd0d177f87c4386db7570d, ConnectionProtocol c1b594372809645325383c6d396811aaa)
		: base(c472a3b7c9dbd0d177f87c4386db7570d, c1b594372809645325383c6d396811aaa)
	{
		base.Listener = this;
		externalListener = c472a3b7c9dbd0d177f87c4386db7570d;
		OnlineServerAddr = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		mIsAuthenticated = false;
		mOnlineCallQueue = new Queue<OnlineCallParameters>();
		mOperationResponseCallbacks = new Dictionary<byte, OperationResponseCallback>();
		mEventCallbacks = new Dictionary<byte, EventCallback>();
	}

	private void Reset()
	{
		OnlineServerAddr = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		mIsAuthenticated = false;
	}

	public void DebugReturn(DebugLevel level, string message)
	{
		if (externalListener == null)
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
			externalListener.DebugReturn(level, message);
			return;
		}
	}

	public void cfb4b113d4d6dee3922de175866313174(string c9431b2ab295d7c2a3400b2fa319f2763, string cd74188a7969ea2c999bbfcfdd816f094, string c4ae384bbd6931efdcdcc85c03ae9aeaa = "", string cb292fbb0d136ed940c5827add605879c = "")
	{
		if (OnlineServerAddr != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					mAppVersion = cd74188a7969ea2c999bbfcfdd816f094;
					mAppId = c9431b2ab295d7c2a3400b2fa319f2763;
					maccount = c4ae384bbd6931efdcdcc85c03ae9aeaa;
					mpwd = cb292fbb0d136ed940c5827add605879c;
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Connect to online server: " + OnlineServerAddr.ToString());
					base.Connect(OnlineServerAddr, "Online");
					return;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "No online server available!");
	}

	public bool c6f33dc92a2ac4dceb4bc67bd73340658(string c0f2c35402a8abd489481ccc7869a969c, string c6c1b51e64722c3393756046248a04833, string c4c413a97799e43eb07112adf9641c30e, string cb292fbb0d136ed940c5827add605879c)
	{
		if ((int)base.DebugOut >= 3)
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
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		mOnlineCallQueue.Enqueue(new OnlineCallParameters
		{
			mOperationCode = 230
		});
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = c6c1b51e64722c3393756046248a04833;
		dictionary[224] = c0f2c35402a8abd489481ccc7869a969c;
		dictionary[105] = (byte)2;
		dictionary[110] = OnlineService.s_accountId;
		dictionary[221] = mToken;
		dictionary[103] = c88c1668c12e6dba145f315d00c324b4a();
		return OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	public int c88c1668c12e6dba145f315d00c324b4a()
	{
		return 0;
	}

	public bool c4c1ac70d53ab42afe86bbfda86212944(byte c9f7e586bb3f27d35994b3e3029d2bbce, params object[] c90ecb087828ed9ceb9c00eafb6d52f4c)
	{
		bool flag = true;
		if (State == global::PeerState.Connected)
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
			if (mOnlineCallQueue.Count == 0)
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
				flag = OpCustom(c9f7e586bb3f27d35994b3e3029d2bbce, new Dictionary<byte, object> { { 112, c90ecb087828ed9ceb9c00eafb6d52f4c } }, true);
			}
			if (flag)
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
				mOnlineCallQueue.Enqueue(new OnlineCallParameters
				{
					mOperationCode = c9f7e586bb3f27d35994b3e3029d2bbce,
					mParameters = c90ecb087828ed9ceb9c00eafb6d52f4c
				});
			}
		}
		return flag;
	}

	public void c4294d225f8ceab9e10a90a7d1239d0b1(string c1b5c0e6ca65a09e03d89484209772de2)
	{
		OnlineServerAddr = c1b5c0e6ca65a09e03d89484209772de2;
	}

	public void OnOperationResponse(OperationResponse operationResponse)
	{
		OnlineCallParameters onlineCallParameters = mOnlineCallQueue.Dequeue();
		if (onlineCallParameters.mOperationCode != operationResponse.OperationCode)
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
			if ((int)base.DebugOut >= 1)
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
				DebugReturn(DebugLevel.ERROR, string.Format("Unexpected operation response from server: {0}  Was expecting: {1}", operationResponse.ToString(), onlineCallParameters.mOperationCode));
			}
		}
		if (mOnlineCallQueue.Count >= 1)
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
			OnlineCallParameters onlineCallParameters2 = mOnlineCallQueue.Peek();
			OpCustom(onlineCallParameters2.mOperationCode, new Dictionary<byte, object> { { 112, onlineCallParameters2.mParameters } }, true);
		}
		if (operationResponse.ReturnCode != 0)
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
			if (operationResponse.OperationCode != 82)
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
				DebugReturn(DebugLevel.ERROR, string.Format("Operation {0} returned error code {1}: {2}", operationResponse.OperationCode, operationResponse.ReturnCode, operationResponse.DebugMessage));
			}
		}
		if (operationResponse.OperationCode == 230)
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
			mIsAuthenticated = true;
			if (operationResponse.ReturnCode != 0)
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
				if ((int)base.DebugOut >= 1)
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
					DebugReturn(DebugLevel.ERROR, string.Format("Authentication failed: '{0}' Code: {1}", operationResponse.DebugMessage, operationResponse.ReturnCode));
				}
				if (operationResponse.ReturnCode == -2)
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
					DebugReturn(DebugLevel.ERROR, string.Format("If you host Photon yourself, make sure to start the 'Instance LoadBalancing'", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
				}
				if (operationResponse.ReturnCode == short.MaxValue)
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
					DebugReturn(DebugLevel.ERROR, string.Format("The appId this client sent is unknown on the server (Cloud). Check settings. If using the Cloud, check account.", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
				}
				Disconnect();
				State = global::PeerState.Disconnecting;
				if (operationResponse.ReturnCode == 32757)
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
					DebugReturn(DebugLevel.ERROR, string.Format("Currently, the limit of users is reached for this title. Try again later. Disconnecting", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
				}
				else if (operationResponse.ReturnCode == 32756)
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
					DebugReturn(DebugLevel.ERROR, string.Format("The used master server address is not available with the subscription currently used. Got to Photon Cloud Dashboard or change URL. Disconnecting", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
				}
			}
			if (operationResponse.Parameters != null)
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
				if (operationResponse.Parameters.ContainsKey(0))
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
					OnlineService.s_accountId = (int)operationResponse.Parameters[0];
					PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198.ccd6fde3cd72529d9bc2523ed219b2bd4(new Hashtable { 
					{
						"AccountId",
						OnlineService.s_accountId
					} });
				}
			}
		}
		if (!mOperationResponseCallbacks.ContainsKey(operationResponse.OperationCode))
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
			mOperationResponseCallbacks[operationResponse.OperationCode](operationResponse.ReturnCode, operationResponse.Parameters);
			return;
		}
	}

	public override void Disconnect()
	{
		if (base.PeerState == PeerStateValue.Disconnected)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if ((int)base.DebugOut >= 2)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								DebugReturn(DebugLevel.WARNING, string.Format("Can't execute Online Disconnect() while not connected. Nothing changed. State: {0}", State));
								return;
							}
						}
					}
					return;
				}
			}
		}
		base.Disconnect();
		State = global::PeerState.Disconnecting;
	}

	public void OnStatusChanged(StatusCode statusCode)
	{
		if ((int)base.DebugOut >= 3)
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
		}
		switch (statusCode)
		{
		case StatusCode.Connect:
			State = global::PeerState.Connected;
			EstablishEncryption();
			break;
		case StatusCode.Disconnect:
			Reset();
			State = global::PeerState.PeerCreated;
			DebugReturn(DebugLevel.WARNING, string.Format("OnStatusChanged: {0}", statusCode.ToString()));
			PhotonNetwork.networkingPeer.Disconnect();
			break;
		case StatusCode.InternalReceiveException:
		case StatusCode.TimeoutDisconnect:
		case StatusCode.DisconnectByServer:
		case StatusCode.DisconnectByServerUserLimit:
		case StatusCode.DisconnectByServerLogic:
			if (State == global::PeerState.Connecting)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = statusCode;
				array[1] = " while connecting to: ";
				array[2] = base.ServerAddress;
				array[3] = ". Check if the server is available.";
				DebugReturn(DebugLevel.WARNING, string.Concat(array));
				State = global::PeerState.PeerCreated;
			}
			else
			{
				State = global::PeerState.PeerCreated;
			}
			Disconnect();
			break;
		case StatusCode.SendError:
			break;
		case StatusCode.QueueOutgoingReliableWarning:
		case StatusCode.QueueOutgoingUnreliableWarning:
		case StatusCode.QueueOutgoingAcksWarning:
		case StatusCode.QueueSentWarning:
			break;
		case StatusCode.EncryptionEstablished:
			if (c6f33dc92a2ac4dceb4bc67bd73340658(mAppId, mAppVersion, maccount, mpwd))
			{
				break;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				return;
			}
		case StatusCode.EncryptionFailedToEstablish:
			externalListener.DebugReturn(DebugLevel.ERROR, string.Concat("Encryption wasn't established: ", statusCode, ". Going to authenticate anyways."));
			if (c6f33dc92a2ac4dceb4bc67bd73340658(mAppId, mAppVersion, maccount, mpwd))
			{
				break;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				return;
			}
		default:
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "CommandBufferSize is " + base.CommandBufferSize);
			break;
		}
	}

	public bool c71111ea3c8afdb98963505d86a8495b6(byte c9f7e586bb3f27d35994b3e3029d2bbce, OperationResponseCallback c2db84530ef366a6deb001d449d4aa151)
	{
		if (mOperationResponseCallbacks.ContainsKey(c9f7e586bb3f27d35994b3e3029d2bbce))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		mOperationResponseCallbacks[c9f7e586bb3f27d35994b3e3029d2bbce] = c2db84530ef366a6deb001d449d4aa151;
		return true;
	}

	public void c70c342bd044a12574e7a34217617fe88(byte c9f7e586bb3f27d35994b3e3029d2bbce)
	{
		mOperationResponseCallbacks.Remove(c9f7e586bb3f27d35994b3e3029d2bbce);
	}

	public void c89f9569b4330d0286992724cb1480f55(byte cdf46071c2725c9ab47a01b833f484416, EventCallback c2db84530ef366a6deb001d449d4aa151)
	{
		if (mEventCallbacks.ContainsKey(cdf46071c2725c9ab47a01b833f484416))
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
					throw new ArgumentException(string.Format("RegisterEventCallback: Already registered a callback for event code {0}", cdf46071c2725c9ab47a01b833f484416), "eventCode");
				}
			}
		}
		mEventCallbacks[cdf46071c2725c9ab47a01b833f484416] = c2db84530ef366a6deb001d449d4aa151;
	}

	public void cd2a2d8015f4353872adfa786778b2898(byte cdf46071c2725c9ab47a01b833f484416)
	{
		mEventCallbacks.Remove(cdf46071c2725c9ab47a01b833f484416);
	}

	public void OnEvent(EventData eventData)
	{
		if (!mEventCallbacks.ContainsKey(eventData.Code))
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
			mEventCallbacks[eventData.Code](eventData.Parameters);
			return;
		}
	}
}
