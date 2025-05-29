using A;
using UnityEngine;

public class AnimationManagerState : ce972fd150f340044b329bd2758a9cacc
{
	public AnimationManagerFSM m_AnimationManagerFSM;

	public VFXManager m_VFXManager;

	public Vector3 m_destinationFacing = Vector3.zero;

	public float m_destinationDistanceFactor;

	public Vector3 m_destinationPosition = Vector3.zero;

	public float m_turnAngle;

	public AnimationStatus m_status { get; protected set; }

	public Vector3 ce734d5ea91008df465ad3fe84ce57372
	{
		get
		{
			return m_destinationFacing;
		}
		set
		{
			m_destinationFacing = value;
		}
	}

	public Vector3 c060feea153fe2c724e32cc3b16e6bb12
	{
		get
		{
			return m_destinationPosition;
		}
		set
		{
			m_destinationPosition = value;
		}
	}

	public virtual void ccc9d3a38966dc10fedb531ea17d24611(AnimationManagerFSM c43bc1e1f3eab110f6f4fe9d6eaf8429a)
	{
		cdecc1d7a8728981e97b2a31b6b14af4e = c43bc1e1f3eab110f6f4fe9d6eaf8429a.m_animationStateMachine;
		m_AnimationManagerFSM = c43bc1e1f3eab110f6f4fe9d6eaf8429a;
		m_status = AnimationStatus.INVALID;
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		ce902c639c179f2e78fd1621e43ab4593 = 0f;
		m_status = AnimationStatus.RUNNING;
		if ((bool)m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
		{
			while (true)
			{
				switch (7)
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
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", false);
		}
		if ((bool)m_VFXManager)
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
			m_VFXManager = m_AnimationManagerFSM.m_VFXManager;
			return;
		}
	}

	public override void c07b7ce37423e253b784029efb12b608f()
	{
	}

	public virtual void FixedUpdate()
	{
	}

	public override void caeee91e34d54e1e41ab1b380f7d8c9a4()
	{
		m_status = AnimationStatus.SUCCESS;
		if (!m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bIdle", true);
			return;
		}
	}

	public bool c4d656ad63e3960e094afed8e06b599f1(AnimatorStateInfo c00bb86ffbeb6764fbe60d7b64859db7f, float c592b1b34fa6feaa20881961dad7218bf, float cc2677e8457ae923cc36d1ec213497a2a)
	{
		return c00bb86ffbeb6764fbe60d7b64859db7f.normalizedTime >= Mathf.Floor(c592b1b34fa6feaa20881961dad7218bf) + cc2677e8457ae923cc36d1ec213497a2a;
	}

	public bool c9526e0b7e1e7101fcd7bc4e2565452f6(AnimatorStateInfo c00bb86ffbeb6764fbe60d7b64859db7f, string c79124bb90958d6716b916ba358c6bea6, float caa95f0a014de56d68180d1e412a99b88)
	{
		if (!c00bb86ffbeb6764fbe60d7b64859db7f.IsTag(c79124bb90958d6716b916ba358c6bea6))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		float num = c00bb86ffbeb6764fbe60d7b64859db7f.normalizedTime - (float)Mathf.FloorToInt(c00bb86ffbeb6764fbe60d7b64859db7f.normalizedTime);
		int result;
		if (num > caa95f0a014de56d68180d1e412a99b88)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool c2e1ae09c9380e41cbb7d5735a884f922(Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900)
	{
		NavMeshHit hit;
		if (NavMesh.SamplePosition(c0b885a96d3f0d32f51ff3ec0d37d2900, out hit, 0.5f, int.MaxValue))
		{
			while (true)
			{
				switch (4)
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
			Vector3 vector = c0b885a96d3f0d32f51ff3ec0d37d2900 - hit.position;
			vector.y = 0f;
			if (vector.sqrMagnitude < 0.01f)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}
}
