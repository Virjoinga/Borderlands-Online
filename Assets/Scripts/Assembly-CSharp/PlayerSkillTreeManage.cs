using A;
using Photon;
using UnityEngine;

public class PlayerSkillTreeManage : Photon.MonoBehaviour
{
	public void OnLocalSkillUpgrade()
	{
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_L2H_RequestSyncSkill", PhotonTargets.MasterClient, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	[RPC]
	private void RPC_H2C_SkillEvent(int _target, int _networkId, int _event, float _fParam, Vector3 _vParam, PhotonMessageInfo info)
	{
		EntityPlayer entityPlayer = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(_networkId) as EntityPlayer;
		if (entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent_Local((SkillEvent)_event, _fParam, _vParam);
		}
		if (_target != 1)
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
			entityPlayer.ccaf53be8b86b7016efd6970ff8c92ad3.OnSkillEvent_Client((SkillEvent)_event, _fParam, _vParam);
			return;
		}
	}

	public void c1dbff9b95a2e82e43a33a24cd7557719(SkillItem c406fc1005cb8d71f62a75f89a24b3371)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = (int)c406fc1005cb8d71f62a75f89a24b3371.m_type;
		array[1] = c406fc1005cb8d71f62a75f89a24b3371.m_expect_grade;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_L2H_Hack_SetSkillPt", PhotonTargets.MasterClient, array);
	}

	public void c2f727c8b0dc503a67b7afc4dc8fad0f3(MarkManager.ESlowdownType c4f09c39924e70788c7b055c1d1490578)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = (int)c4f09c39924e70788c7b055c1d1490578;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_L2H_SetSlowdownType", PhotonTargets.MasterClient, array);
	}
}
