using Photon;
using UnityEngine;

[RequireComponent(typeof(BadAssNetworkView))]
public class EventSyncBloodWing : Photon.MonoBehaviour
{
	[RPC]
	private void RPC_RemoteTarget_Back()
	{
	}
}
