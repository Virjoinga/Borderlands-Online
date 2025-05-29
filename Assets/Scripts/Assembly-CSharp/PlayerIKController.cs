using UnityEngine;

public class PlayerIKController : MonoBehaviour
{
	public Animator m_animator;

	public bool m_enableAimIK;

	private Vector3 m_targetPosition = Vector3.zero;

	private bool m_hasValidTargetPosition;

	public void c1388b070a9ff180c6a0efe41ddf70e31(Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900)
	{
		m_hasValidTargetPosition = true;
		m_targetPosition = c0b885a96d3f0d32f51ff3ec0d37d2900;
	}

	public void ce40f0b6c3f7714ac1c3daa73f26d266d()
	{
		m_hasValidTargetPosition = false;
	}

	private void Start()
	{
		m_animator = GetComponent<Animator>();
	}

	private void OnAnimatorIK(int layerIndex)
	{
		if (!m_enableAimIK)
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
			if (layerIndex != 0)
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
				if (!m_hasValidTargetPosition)
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
					m_animator.SetLookAtWeight(1f, 0.6f, 0.6f, 1f, 0.5f);
					m_animator.SetLookAtPosition(m_targetPosition);
					return;
				}
			}
		}
	}
}
