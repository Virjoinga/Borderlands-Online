namespace A
{
	public class c89c54c08043729ce8a5a497efa546af3 : cac110d4f4a99811889eb5dc85c420d82, INetworkManagerListener
	{
		public virtual void OnJoinedRoom()
		{
		}

		public virtual void OnPhotonJoinRoomFailed()
		{
		}

		public virtual void OnPhotonRandomJoinFailed()
		{
		}

		public virtual void OnLeftRoom()
		{
		}

		public virtual void OnDisconnectedFromPhoton()
		{
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_Disconnected);
		}

		public override void Start()
		{
			base.Start();
			NetworkManager component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>();
			component.cc7c09df5a4a467ee40cdda5047fd18d0(this);
		}

		public override void cdada4c3678c9c23c38aaf0754a94a620()
		{
			NetworkManager component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<NetworkManager>();
			component.c31e47046c84e50120b5248468a55f966(this);
			base.cdada4c3678c9c23c38aaf0754a94a620();
		}
	}
}
