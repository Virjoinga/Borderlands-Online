using System;
using System.Collections;
using System.Threading;
using A;
using Core;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

internal class PhotonHandler : Photon.MonoBehaviour, IPhotonPeerListener
{
	public static PhotonHandler SP;

	public int updateInterval;

	public int updateIntervalOnSerialize;

	private int nextSendTickCount;

	private int nextSendTickCountOnSerialize;

	private DateTime startTimeStamp;

	private void Awake()
	{
		if (SP != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (SP != this)
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
				if (SP.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					UnityEngine.Object.DestroyImmediate(SP.gameObject);
				}
			}
		}
		SP = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		updateInterval = 1000 / PhotonNetwork.cdf9a39b9b00c5bc0c0d5701ce9fd8578;
		updateIntervalOnSerialize = 1000 / PhotonNetwork.cd70da6845185cd76f7e07c2e822481bc;
		startTimeStamp = DateTime.Now;
	}

	private void FixedUpdate()
	{
		if (PhotonNetwork.networkingPeer == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "NetworkPeer broke!");
					return;
				}
			}
		}
		if (PhotonNetwork.c900460744ca8a86df35ccfe02fc5acbd == PeerState.PeerCreated)
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
			if (PhotonNetwork.c900460744ca8a86df35ccfe02fc5acbd == PeerState.Disconnected)
			{
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
			int num = (int)(DateTime.Now - startTimeStamp).TotalMilliseconds;
			if (num > nextSendTickCountOnSerialize)
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
				nextSendTickCountOnSerialize = num / updateIntervalOnSerialize * updateIntervalOnSerialize + updateIntervalOnSerialize;
				PhotonNetwork.networkingPeer.c43a56291b587958528031d32d2c20b39();
				nextSendTickCount = 0;
			}
			if (num <= nextSendTickCount)
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
				nextSendTickCount = num / updateInterval * updateInterval + updateInterval;
				bool flag = true;
				double num2 = Time.realtimeSinceStartup;
				while (flag)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						if ((double)Time.realtimeSinceStartup - num2 <= 0.003)
						{
							flag = PhotonNetwork.networkingPeer.SendOutgoingCommands();
							break;
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
				return;
			}
		}
	}

	private void Update()
	{
		if (PhotonNetwork.networkingPeer == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "NetworkPeer broke!");
					return;
				}
			}
		}
		if (PhotonNetwork.c900460744ca8a86df35ccfe02fc5acbd == PeerState.PeerCreated)
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
			if (PhotonNetwork.c900460744ca8a86df35ccfe02fc5acbd == PeerState.Disconnected)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (!PhotonNetwork.c195baff01be84d431dc217cf68ed2569)
			{
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
					PhotonNetwork.networkingPeer.ca0ec1e9e542d79bb6f94ab88b2982b8c();
				}
			}
			PhotonNetwork.networkingPeer.ca8dab3ae6f9ebf52cc4b1fddadc882d1();
			return;
		}
	}

	private void LateUpdate()
	{
		bool flag = true;
		while (flag)
		{
			flag = PhotonNetwork.networkingPeer.SendOutgoingCommands();
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
			return;
		}
	}

	protected void OnApplicationQuit()
	{
		PhotonNetwork.c36588361fa2310a4571d2d4ff01ea51f();
	}

	protected void OnLevelWasLoaded(int level)
	{
		PhotonNetwork.networkingPeer.c27479e14c852f4d5c80f387af40d1263();
		if (!PhotonNetwork.c9bea90d20d3b9c1060b684f2bc77db82)
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
			c5e26467eab837936162c2ee66aa49218();
			return;
		}
	}

	protected void OnJoinedRoom()
	{
		PhotonNetwork.networkingPeer.ce24ae7eda88a0a7db54f496822feaa00();
	}

	protected void OnCreatedRoom()
	{
		if (!PhotonNetwork.c9bea90d20d3b9c1060b684f2bc77db82)
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
			c5e26467eab837936162c2ee66aa49218();
			return;
		}
	}

	protected internal void c5e26467eab837936162c2ee66aa49218()
	{
		if (!PhotonNetwork.ca3052869987fcf5688487de12414faab)
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
			Hashtable hashtable = new Hashtable();
			hashtable["curScn"] = Application.loadedLevelName;
			PhotonNetwork.c3202f32ecb834b115326e72e13e35ff0.ccd6fde3cd72529d9bc2523ed219b2bd4(hashtable);
			return;
		}
	}

	public static void c40ea94b900b535d69b3dc0b94566ddd4()
	{
	}

	public static void c49545a491b8d1d7fa22330e77bb1641e()
	{
		while (PhotonNetwork.networkingPeer != null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (PhotonNetwork.networkingPeer.IsSendingOnlyAcks)
				{
					while (PhotonNetwork.networkingPeer.SendAcksOnly())
					{
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
						Thread.Sleep(50);
						break;
					}
					break;
				}
				while (true)
				{
					switch (1)
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

	public void DebugReturn(DebugLevel level, string message)
	{
		if (level == DebugLevel.ERROR)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, message);
					return;
				}
			}
		}
		if (level == DebugLevel.WARNING)
		{
			while (true)
			{
				switch (5)
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
				switch (7)
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
				switch (5)
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
