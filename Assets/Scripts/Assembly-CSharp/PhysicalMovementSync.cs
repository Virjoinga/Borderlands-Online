using A;
using UnityEngine;

public class PhysicalMovementSync : MonoBehaviour, IPhotonView, IPhotonSerializeView, IPhotonEvaluate
{
	private Rigidbody m_Rigidbody;

	private bool m_settedPos = true;

	private bool m_settedVol = true;

	private Vector3 lastVelocity;

	private Vector3 lastAngelVelocity;

	private Vector3 lastPosition;

	private Quaternion lastRotation;

	public PhotonView photonView { get; set; }

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (m_Rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								stream.caf7283cc5cd9725a88a9cdfa630d92f8(base.transform.position);
								stream.caf7283cc5cd9725a88a9cdfa630d92f8(base.transform.rotation);
								stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_Rigidbody.velocity);
								stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_Rigidbody.angularVelocity);
								return;
							}
						}
					}
					return;
				}
			}
		}
		if (!(m_Rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			lastPosition = (Vector3)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			lastRotation = (Quaternion)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			lastVelocity = (Vector3)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			lastAngelVelocity = (Vector3)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_settedPos = false;
			m_settedVol = false;
			return;
		}
	}

	private void FixedUpdate()
	{
		if (!(base.rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_settedPos)
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
				m_Rigidbody.isKinematic = true;
				base.transform.position = lastPosition;
				base.transform.rotation = lastRotation;
				m_settedPos = true;
			}
			if (!m_settedPos)
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
				if (m_settedVol)
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
					m_Rigidbody.isKinematic = false;
					m_Rigidbody.velocity = lastVelocity;
					m_Rigidbody.angularVelocity = lastAngelVelocity;
					m_settedVol = true;
					return;
				}
			}
		}
	}

	public void OnPhotonEvaluate(PhotonPlayer player, ref PhotonPriority priority)
	{
	}
}
