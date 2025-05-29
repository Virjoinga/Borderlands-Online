using A;
using UnityEngine;

public class IcePick : MonoBehaviour
{
	[HideInInspector]
	public Vector3 m_vLandPos;

	[HideInInspector]
	public AIServiceCurve.Curve m_flyingCurve;

	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	[HideInInspector]
	public float m_damageRadius;

	[HideInInspector]
	public int m_damage;

	public float m_fSpeed = 25f;

	private bool m_bLanded;

	private void Start()
	{
		m_bLanded = false;
	}

	private void Update()
	{
		if (m_flyingCurve == null)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_BHVTaskManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_bLanded)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				Vector3 newPosition;
				m_bLanded = m_flyingCurve.Update(Time.deltaTime, m_fSpeed, out newPosition);
				base.transform.forward = (newPosition - base.transform.position).normalized;
				base.transform.position = newPosition;
				if (!m_bLanded)
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
					ObjectParticleManager component = GetComponent<ObjectParticleManager>();
					if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						component.cdb22a9a349507be00401b4d9fc80d1bb();
						component.c1ccf778419424f0f595c0d069d66e4e1(ENPCParticleType.E_IceBroken);
						component.cec482001ad991ef85e52e298f1fc3cdc();
					}
					Object.Destroy(base.gameObject, 3f);
					return;
				}
			}
		}
	}
}
