using Photon;
using UnityEngine;

public class HunterDroid : Photon.MonoBehaviour
{
	private EntityPlayer m_playerOwner;

	private HunterManage m_skillMgr;

	private void Start()
	{
		ccc9d3a38966dc10fedb531ea17d24611();
	}

	private void ccc9d3a38966dc10fedb531ea17d24611()
	{
		int c35f98ccbfa8c6bf09319c620b21b5dc = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[0];
		m_playerOwner = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c35f98ccbfa8c6bf09319c620b21b5dc) as EntityPlayer;
		m_skillMgr = m_playerOwner.ccaf53be8b86b7016efd6970ff8c92ad3 as HunterManage;
		base.transform.position = m_playerOwner.transform.position + m_playerOwner.transform.TransformDirection(m_skillMgr.cfef58f1c4809b15e4f65eab00b461e41());
		base.transform.rotation = m_playerOwner.transform.rotation * Quaternion.Euler(m_skillMgr.m_settings.m_pitch_droid, m_skillMgr.m_settings.m_yaw_droid, 0f);
		base.transform.parent = m_playerOwner.transform;
		m_skillMgr.cde5dfac4b028730e95b33872d6b077b2(this);
	}
}
