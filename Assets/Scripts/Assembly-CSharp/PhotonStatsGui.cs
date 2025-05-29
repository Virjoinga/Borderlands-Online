using System.Collections.Generic;
using A;
using Core;
using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonStatsGui : MonoBehaviour
{
	public bool statsWindowOn = true;

	public bool statsOn = true;

	public bool healthStatsVisible;

	public bool trafficStatsOn;

	public bool trafficDetailStatsOn;

	public bool showSpeed;

	public bool showRCV;

	public bool prioritySystemOn;

	private string trafficDetail;

	public bool buttonsOn;

	public Rect statsRect = new Rect(0f, 100f, 200f, 50f);

	public int WindowId = 100;

	public string lastStats;

	public void Start()
	{
		statsRect.x = (float)Screen.width - statsRect.width;
	}

	public void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Tab))
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
			if (!Input.GetKey(KeyCode.LeftShift))
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
				statsWindowOn = !statsWindowOn;
				statsOn = true;
				return;
			}
		}
	}

	public void OnGUI()
	{
		if (PhotonNetwork.c01fb44a84b234955e072426cda6b8914 != statsOn)
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
			PhotonNetwork.c01fb44a84b234955e072426cda6b8914 = statsOn;
		}
		if (!statsWindowOn)
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
		statsRect = GUILayout.Window(WindowId, statsRect, c6d9f27598225256b20b6d9b64a5416f2, "Messages (shift+tab)", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void c6d9f27598225256b20b6d9b64a5416f2(int c76b67c5dd1ed228f3f8e6f0aaaa58ef5)
	{
		bool flag = false;
		TrafficStatsGameLevel trafficStatsGameLevel = PhotonNetwork.networkingPeer.TrafficStatsGameLevel;
		long num = PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000;
		if (num == 0L)
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
			num = 1L;
		}
		GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		buttonsOn = GUILayout.Toggle(buttonsOn, "buttons", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		healthStatsVisible = GUILayout.Toggle(healthStatsVisible, "health", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		trafficStatsOn = GUILayout.Toggle(trafficStatsOn, "traffic", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		trafficDetailStatsOn = GUILayout.Toggle(trafficDetailStatsOn, "trafficDetail", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		prioritySystemOn = GUILayout.Toggle(prioritySystemOn, "prioritySystem", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.EndHorizontal();
		string text = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount, trafficStatsGameLevel.TotalIncomingMessageCount, trafficStatsGameLevel.TotalMessageCount);
		string text2 = string.Format("{0}sec average:", num);
		string text3 = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount / num, trafficStatsGameLevel.TotalIncomingMessageCount / num, trafficStatsGameLevel.TotalMessageCount / num);
		string text4 = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingByteCount / num, trafficStatsGameLevel.TotalIncomingByteCount / num, trafficStatsGameLevel.TotalByteCount / num);
		GUILayout.Label(text, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label(text2, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label(text3, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label(text4, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		if (buttonsOn)
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
			GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			statsOn = GUILayout.Toggle(statsOn, "stats on", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			if (GUILayout.Button("Reset", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0)))
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
				PhotonNetwork.c648541fb156a9d9dbca6397c4abab0ce();
				PhotonNetwork.c01fb44a84b234955e072426cda6b8914 = true;
			}
			flag = GUILayout.Button("To Log", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.EndHorizontal();
		}
		string text5 = string.Empty;
		string text6 = string.Empty;
		if (trafficStatsOn)
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
			text5 = "Incoming: " + PhotonNetwork.networkingPeer.TrafficStatsIncoming.ToString();
			text6 = "Outgoing: " + PhotonNetwork.networkingPeer.TrafficStatsOutgoing.ToString();
			GUILayout.Label(text5, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.Label(text6, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		}
		if (trafficDetailStatsOn)
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
			if (!showSpeed)
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
				num = 1L;
			}
			GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			showRCV = GUILayout.Toggle(showRCV, "RCV", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			int num2;
			if (showRCV)
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
				num2 = PhotonNetwork.networkingPeer.c56a7efd3d4c0feb181da5e6e0caccd11();
			}
			else
			{
				num2 = PhotonNetwork.networkingPeer.cd3ab481409345f82017e9a6226db4847();
			}
			int num3 = num2;
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
			array[0] = "Ingame Total";
			object obj;
			if (showRCV)
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
				obj = "Incoming";
			}
			else
			{
				obj = "Outgoing: ";
			}
			array[1] = obj;
			array[2] = num3 / num;
			array[3] = " instantiateSize:";
			int num4;
			if (showRCV)
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
				num4 = PhotonNetwork.networkingPeer.grossInstantiateDataRCV;
			}
			else
			{
				num4 = PhotonNetwork.networkingPeer.grossInstantiateData;
			}
			array[4] = num4 / num;
			array[5] = "|";
			int num5;
			if (showRCV)
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
				num5 = PhotonNetwork.networkingPeer.grossInstantiateDataRCV;
			}
			else
			{
				num5 = PhotonNetwork.networkingPeer.grossInstantiateData;
			}
			array[6] = (int)((float)num5 / (float)num3 * 100f);
			GUILayout.Label(trafficDetail = string.Concat(array), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			showSpeed = GUILayout.Toggle(showSpeed, "Speed", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.EndHorizontal();
			List<PhotonView> list;
			if (showRCV)
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
				list = PhotonNetwork.networkingPeer.cdc416e24ee3e72a003d9282736af0d86();
			}
			else
			{
				list = PhotonNetwork.networkingPeer.c37edcd428b1153e146e65b2236f4bc0f();
			}
			List<PhotonView> list2 = list;
			for (int i = 0; i < list2.Count; i++)
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
				if (i < 10)
				{
					trafficDetail += "\n";
					GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					GUILayout.BeginVertical(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					if (list2[i].observed == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						text6 = list2[i].name + list2[i].ce57f12a4f7e693a5fe0c4049dc56fa7c;
					}
					else
					{
						text6 = list2[i].name + list2[i].ce57f12a4f7e693a5fe0c4049dc56fa7c + list2[i].observed.GetType().Name;
					}
					GUILayout.Label(text6, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					trafficDetail += text6;
					GUILayout.EndVertical();
					GUILayout.BeginVertical(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					object obj2;
					if (showRCV)
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
						obj2 = "In:";
					}
					else
					{
						object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array2[0] = " Out: ";
						int num6;
						if (showRCV)
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
							num6 = list2[i].c1097797f47f6121a2daef2c9d735cf19;
						}
						else
						{
							num6 = list2[i].c82aa1e6f06bc147778156b8e1e96e1d8;
						}
						array2[1] = num6 / num;
						array2[2] = "|";
						int num7;
						if (showRCV)
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
							num7 = list2[i].c1097797f47f6121a2daef2c9d735cf19;
						}
						else
						{
							num7 = list2[i].c82aa1e6f06bc147778156b8e1e96e1d8;
						}
						array2[3] = (int)((float)num7 / (float)num3 * 100f);
						obj2 = string.Concat(array2);
					}
					text6 = (string)obj2;
					GUILayout.Label(text6, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					trafficDetail += text6;
					GUILayout.EndVertical();
					GUILayout.BeginVertical(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					object[] array3 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array3[0] = " Srlz:";
					int num8;
					if (showRCV)
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
						num8 = list2[i].grossSerializeSizeRCV;
					}
					else
					{
						num8 = list2[i].grossSerializeSize;
					}
					array3[1] = num8 / num;
					array3[2] = "|";
					int num9;
					if (showRCV)
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
						num9 = list2[i].grossSerializeSizeRCV;
					}
					else
					{
						num9 = list2[i].grossSerializeSize;
					}
					array3[3] = (int)((float)num9 / (float)num3 * 100f);
					text6 = string.Concat(array3);
					GUILayout.Label(text6, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					trafficDetail += text6;
					GUILayout.EndVertical();
					GUILayout.BeginVertical(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					object[] array4 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array4[0] = " RPC:";
					int num10;
					if (showRCV)
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
						num10 = list2[i].grossRPCSizeRCV;
					}
					else
					{
						num10 = list2[i].grossRPCSize;
					}
					array4[1] = num10 / num;
					array4[2] = "|";
					int num11;
					if (showRCV)
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
						num11 = list2[i].grossRPCSizeRCV;
					}
					else
					{
						num11 = list2[i].grossRPCSize;
					}
					array4[3] = (int)((float)num11 / (float)num3 * 100f);
					text6 = string.Concat(array4);
					GUILayout.Label(text6, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					trafficDetail += text6;
					GUILayout.EndVertical();
					GUILayout.EndHorizontal();
					Dictionary<string, int> dictionary;
					if (showRCV)
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
						dictionary = list2[i].sizePerMethodRCV;
					}
					else
					{
						dictionary = list2[i].sizePerMethod;
					}
					using (Dictionary<string, int>.Enumerator enumerator = dictionary.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, int> current = enumerator.Current;
							trafficDetail += "\n";
							GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
							object[] array5 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
							array5[0] = "    ";
							array5[1] = current.Key;
							array5[2] = ":";
							array5[3] = current.Value / num;
							array5[4] = "|";
							array5[5] = (int)((float)current.Value / (float)num3 * 100f);
							text6 = string.Concat(array5);
							GUILayout.Label(text6, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
							trafficDetail += text6;
							GUILayout.EndHorizontal();
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								goto end_IL_098f;
							}
							continue;
							end_IL_098f:
							break;
						}
					}
					continue;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				break;
			}
		}
		string text7 = string.Empty;
		if (healthStatsVisible)
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
			object[] array6 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(8);
			array6[0] = trafficStatsGameLevel.LongestDeltaBetweenSending;
			array6[1] = trafficStatsGameLevel.LongestDeltaBetweenDispatching;
			array6[2] = trafficStatsGameLevel.LongestEventCallback;
			array6[3] = trafficStatsGameLevel.LongestEventCallbackCode;
			array6[4] = trafficStatsGameLevel.LongestOpResponseCallback;
			array6[5] = trafficStatsGameLevel.LongestOpResponseCallbackOpCode;
			array6[6] = PhotonNetwork.networkingPeer.RoundTripTime;
			array6[7] = PhotonNetwork.networkingPeer.RoundTripTimeVariance;
			text7 = string.Format("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", array6);
			GUILayout.Label(text7, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		}
		object[] array7 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array7[0] = text;
		array7[1] = text2;
		array7[2] = text3;
		array7[3] = text5;
		array7[4] = text6;
		array7[5] = text7;
		string text8 = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", array7);
		if (flag)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, text8);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, trafficDetail);
		}
		if (prioritySystemOn)
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
			GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.Label("bandwidth cap:" + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.BandwidthCap, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.BandwidthCap = (int)GUILayout.HorizontalSlider(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.BandwidthCap, 0f, 300f, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.Label("Inspector:" + c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.PriorityInspector, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.PriorityInspector = (int)GUILayout.HorizontalSlider(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.PriorityInspector, 0f, PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd.Length - 1, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
			GUILayout.EndHorizontal();
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.PriorityInspector < PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd.Length)
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
				PhotonPlayer photonPlayer = PhotonNetwork.cfac6072a14e502241f3c58a1c87edcfd[c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.PriorityInspector];
				int num12 = 0;
				using (List<PhotonView>.Enumerator enumerator2 = NetworkingPriority.c5ee19dc8d4cccf5ae2de225410458b86.c19f7095c6fdcb36d0b945dd757043fbe(photonPlayer).GetEnumerator())
				{
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							PhotonView current2 = enumerator2.Current;
							if (current2.cc484401d276ed0c9292ee082b8c8fb1d(photonPlayer) >= 5000)
							{
								continue;
							}
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							num12++;
							if (num12 == 11)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										goto end_IL_0c82;
									}
									continue;
									end_IL_0c82:
									break;
								}
								break;
							}
							GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
							object[] array8 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
							array8[0] = current2.name;
							array8[1] = "-";
							array8[2] = current2.observed.GetType().ToString();
							array8[3] = ":";
							array8[4] = NetworkingPriority.c5ee19dc8d4cccf5ae2de225410458b86.c9f0427d35dc233bd7b8a42190cf6c521(current2, photonPlayer);
							GUILayout.Label(string.Concat(array8), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
							GUILayout.EndHorizontal();
							continue;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								goto end_IL_0d1b;
							}
							continue;
							end_IL_0d1b:
							break;
						}
						break;
					}
				}
			}
		}
		if (GUI.changed)
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
			statsRect.height = 100f;
		}
		lastStats = text8 + " " + trafficDetail;
		GUI.DragWindow();
	}
}
