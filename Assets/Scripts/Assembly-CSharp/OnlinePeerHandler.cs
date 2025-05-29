using A;
using Core;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

internal class OnlinePeerHandler : Photon.MonoBehaviour, IPhotonPeerListener
{
	private static OnlinePeerHandler SP;

	private void Awake()
	{
		if (SP != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (SP != this)
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
				if (SP.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					Object.DestroyImmediate(SP.gameObject);
				}
			}
		}
		SP = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		if (PhotonNetwork.onlinePeer.State == PeerState.Disconnected)
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
		PhotonNetwork.onlinePeer.Service();
	}

	public void OnConnectedToMaster(string serveraddr)
	{
		if (!(serveraddr != string.Empty))
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, serveraddr);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, PhotonNetwork.onlinePeer.State.ToString());
			if (PhotonNetwork.onlinePeer.State != PeerState.Disconnected)
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
				if (PhotonNetwork.onlinePeer.State != PeerState.PeerCreated)
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
					if (PhotonNetwork.onlinePeer.State != 0)
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
						break;
					}
				}
			}
			PhotonNetwork.onlinePeer.c4294d225f8ceab9e10a90a7d1239d0b1(serveraddr);
			PhotonNetwork.onlinePeer.cfb4b113d4d6dee3922de175866313174(PhotonNetwork.networkingPeer.mAppId, PhotonNetwork.networkingPeer.mAppVersion, PhotonNetwork.networkingPeer.maccount, PhotonNetwork.networkingPeer.mpwd);
			return;
		}
	}

	public void DebugReturn(DebugLevel level, string message)
	{
		if (level == DebugLevel.ERROR)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, message);
					return;
				}
			}
		}
		if (level == DebugLevel.WARNING)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, message);
					return;
				}
			}
		}
		if (level == DebugLevel.INFO)
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
			if (PhotonNetwork.logLevel >= PhotonLogLevel.Informational)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, message);
						return;
					}
				}
			}
		}
		if (level != DebugLevel.ALL)
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
			if (PhotonNetwork.logLevel != PhotonLogLevel.Full)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, message);
				return;
			}
		}
	}

	public void OnOperationResponse(OperationResponse operationResponse)
	{
	}

	public void OnStatusChanged(StatusCode statusCode)
	{
	}

	public void OnEvent(EventData photonEvent)
	{
	}
}
