using A;
using Core;
using Photon;
using UnityEngine;

public class AutoTestSync : Photon.MonoBehaviour
{
	private void Awake()
	{
		c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_autoTestSync = this;
		base.gameObject.transform.parent = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.gameObject.transform;
	}

	public void RPC_CloseCase(string caseName, bool pass)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
			array[0] = caseName;
			array[1] = pass;
			array[2] = "client";
			if (!(base.photonView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_CloseCase", PhotonTargets.All, array);
				return;
			}
		}
	}

	[RPC]
	private void RPC_CloseCase(string caseName, bool pass, string from, PhotonMessageInfo info)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = "AutoTestSync.RPC_CloseCase#RPC#";
		array[1] = caseName;
		array[2] = "#";
		array[3] = pass;
		array[4] = "#";
		array[5] = from;
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, string.Concat(array));
		c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.RPC_CloseCase(caseName, pass, from);
	}

	[RPC]
	private void RPC_SyncResourceRequested(string testCaseName, string continentName, int playerId1, int playerId2, int playerId3, int playerId4, PhotonMessageInfo info)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "AutoTestSync.RPC_SyncResourceRequested#RPC#" + testCaseName + "#" + continentName);
		c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc0e2a7e1c6dee0c1c0965b944aa5cc34(testCaseName, continentName, playerId1, playerId2, playerId3, playerId4);
	}
}
