using A;
using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonLagSimulationGui : MonoBehaviour
{
	public Rect WindowRect = new Rect(0f, 100f, 120f, 100f);

	public int WindowId = 101;

	public bool Visible = true;

	public PhotonPeer Peer { get; set; }

	public void Start()
	{
		Peer = PhotonNetwork.networkingPeer;
	}

	public void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Z))
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
			if (!Input.GetKey(KeyCode.LeftShift))
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
				Visible = !Visible;
				return;
			}
		}
	}

	public void OnGUI()
	{
		if (!Visible)
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
					return;
				}
			}
		}
		if (Peer == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					WindowRect = GUILayout.Window(WindowId, WindowRect, cca07971ba5cb1d1612af859392042f21, "Netw. Sim.", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					return;
				}
			}
		}
		WindowRect = GUILayout.Window(WindowId, WindowRect, cbac1354d27af511ac33a00d5af594c8b, "Netw. Sim.", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void cca07971ba5cb1d1612af859392042f21(int c97b150c6da90934b2c22938f6cd271c1)
	{
		GUILayout.Label("No peer to communicate with. ", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void cbac1354d27af511ac33a00d5af594c8b(int c97b150c6da90934b2c22938f6cd271c1)
	{
		GUILayout.Label(string.Format("Rtt:{0,4} +/-{1,3}", Peer.RoundTripTime, Peer.RoundTripTimeVariance), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		bool isSimulationEnabled = Peer.IsSimulationEnabled;
		bool flag = GUILayout.Toggle(isSimulationEnabled, "Simulate", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		if (flag != isSimulationEnabled)
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
			Peer.IsSimulationEnabled = flag;
		}
		float num = Peer.NetworkSimulationSettings.IncomingLag;
		GUILayout.Label("Lag " + num, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		num = GUILayout.HorizontalSlider(num, 0f, 500f, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		Peer.NetworkSimulationSettings.IncomingLag = (int)num;
		Peer.NetworkSimulationSettings.OutgoingLag = (int)num;
		float num2 = Peer.NetworkSimulationSettings.IncomingJitter;
		GUILayout.Label("Jit " + num2, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		num2 = GUILayout.HorizontalSlider(num2, 0f, 100f, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		Peer.NetworkSimulationSettings.IncomingJitter = (int)num2;
		Peer.NetworkSimulationSettings.OutgoingJitter = (int)num2;
		float num3 = Peer.NetworkSimulationSettings.IncomingLossPercentage;
		GUILayout.Label("Loss " + num3, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		num3 = GUILayout.HorizontalSlider(num3, 0f, 10f, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		Peer.NetworkSimulationSettings.IncomingLossPercentage = (int)num3;
		Peer.NetworkSimulationSettings.OutgoingLossPercentage = (int)num3;
		if (GUI.changed)
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
			WindowRect.height = 100f;
		}
		GUI.DragWindow();
	}
}
