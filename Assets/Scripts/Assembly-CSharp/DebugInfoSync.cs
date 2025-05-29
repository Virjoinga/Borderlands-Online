using System.Diagnostics;
using A;
using Core;
using Photon;
using UnityEngine;

public class DebugInfoSync : Photon.MonoBehaviour
{
	public bool m_enabled;

	public float m_hostfps;

	public int m_hostmem;

	private void Awake()
	{
		DebugUtils.s_debugInfoSync = this;
	}

	[Conditional("ASSERTS")]
	public void c5eb23ece560b0a30aff24994149454c4(LogCategory c2b4f43f34e21572af6ab4414f04cee36, string c709b291ceac9f97f0c78f269054fa014, string c234559b393d74c9d27df1458e6a16b58)
	{
		if (!m_enabled)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
			array[0] = (int)c2b4f43f34e21572af6ab4414f04cee36;
			array[1] = c709b291ceac9f97f0c78f269054fa014;
			array[2] = c234559b393d74c9d27df1458e6a16b58;
			base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SendAssertInfo", PhotonTargets.Others, array);
			return;
		}
	}

	[Conditional("ASSERTS")]
	public void cdcbadd2f61a17a45e86e83c2ad2e65a3(int cc584cc0d388b61d19d26e1dcdd9be909)
	{
		if (!m_enabled)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = cc584cc0d388b61d19d26e1dcdd9be909;
			base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_IgnoreThisOne", PhotonTargets.MasterClient, array);
			return;
		}
	}

	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_IgnoreThisOne(int hashcode, PhotonMessageInfo info)
	{
		DebugUtils.c39b6c19f480c0bbbc890dd0202ecf6e2(hashcode);
	}

	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_SendAssertInfo(int type, string msg, string stackTrace, PhotonMessageInfo info)
	{
	}

	[Conditional("ASSERTS")]
	public void RPC_SetHostDebugInfoTransferingEnabled(bool enabled)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = enabled;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SetHostDebugInfoTransferingEnabled", PhotonTargets.MasterClient, array);
	}

	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_SetHostDebugInfoTransferingEnabled(bool enabled, PhotonMessageInfo info)
	{
		m_enabled = enabled;
	}

	[Conditional("ASSERTS")]
	public void RPC_DumpHostMemoryInfo()
	{
		object[] c90ecb087828ed9ceb9c00eafb6d52f4c = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0);
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_DumpHostMemoryInfo", PhotonTargets.MasterClient, c90ecb087828ed9ceb9c00eafb6d52f4c);
	}

	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_DumpHostMemoryInfo(PhotonMessageInfo info)
	{
		ResourceInfoDumper.ccfc2341b9294f74f3b204f5d1e8d2fb9(string.Empty);
	}

	[Conditional("ASSERTS")]
	public void c3ad23ed9340a6c741e3f844aed096ded(float c95c974c10b666e3eda5bb21b7fa0949b, int c10b6d7067c612d9ccdb27200246f58c7)
	{
		if (!m_enabled)
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
			array[0] = c95c974c10b666e3eda5bb21b7fa0949b;
			array[1] = c10b6d7067c612d9ccdb27200246f58c7;
			base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SendHostDebugInfoFPSMem", PhotonTargets.Others, array);
			return;
		}
	}

	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_SendHostDebugInfoFPSMem(float fps, int mem)
	{
		m_hostfps = fps;
		m_hostmem = mem;
	}
}
