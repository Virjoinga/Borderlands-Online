using UnityEngine;

public class RakkMovementSync : MonoBehaviour, IPhotonSerializeView
{
	public bool m_bEnable;

	public bool m_bMelee;

	private Vector3 m_vPos;

	private void Start()
	{
		m_bEnable = false;
		m_bMelee = false;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (!m_bEnable)
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
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(base.transform.position);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_bMelee);
					return;
				}
			}
		}
		m_vPos = (Vector3)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_bMelee = (bool)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		if (m_bMelee)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			base.transform.position = m_vPos;
			return;
		}
	}
}
