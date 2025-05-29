using Core;
using UnityEngine;

namespace Photon
{
	public class MonoBehaviour : UnityEngine.MonoBehaviour
	{
		public PhotonView photonView
		{
			get
			{
				return PhotonView.c588e7dbcd383d8230b2d83d7b44af23b(this);
			}
		}

		public new PhotonView networkView
		{
			get
			{
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "Why are you still using networkView? should be PhotonView?");
				return PhotonView.c588e7dbcd383d8230b2d83d7b44af23b(this);
			}
		}
	}
}
