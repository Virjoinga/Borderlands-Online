using System.IO;
using A;
using Photon;
using UnityEngine;

public class MarkBroadcast : Photon.MonoBehaviour
{
	private MarkManager m_markMgr;

	private void Start()
	{
		m_markMgr = GetComponent<MarkManager>();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
					return;
				}
			}
		}
		byte[] array = (byte[])stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		MemoryStream memoryStream = new MemoryStream();
		int num = array.Length / MarkManager.BroadcastMarkedInfo.c5c3c145d54edc727770887f87bea1217();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		int num2 = MarkManager.BroadcastMarkedInfo.c5c3c145d54edc727770887f87bea1217();
		for (int i = 0; i < num; i++)
		{
			byte[] array2 = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(num2);
			memoryStream.Read(array2, 0, num2);
			m_markMgr.OnGetMarkedInfo(MarkManager.BroadcastMarkedInfo.c00ae05b9ced94c9fc5f4be4892e6192b(array2));
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	[RPC]
	private void RPC_H2A_ToggleMarking(int _id, float _slowdown, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(_id);
		if (!entity)
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
			entity.cbb91e2330ed12a1942ead68e69e691a3(_slowdown);
			return;
		}
	}

	[RPC]
	private void RPC_H2A_ToggleInMarkState(int _id, bool _inMarkState, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(_id);
		if (!entity)
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
			entity.c49c490bcb316f43984756f2360518e6c(_inMarkState);
			return;
		}
	}
}
