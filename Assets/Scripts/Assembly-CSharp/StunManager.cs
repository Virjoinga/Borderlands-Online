using A;
using UnityEngine;

public class StunManager : MonoBehaviour
{
	public Vector3 m_locationOffset = Vector3.zero;

	public Vector3 m_rotationOffset = Vector3.zero;

	public float m_revolveRadius;

	public float m_revolveAngularSpeed;

	public float m_randomOffset;

	public bool m_enableStun;

	protected float m_revolveAngle;

	protected ParticleSystem m_stunParticleSystem;

	private void Start()
	{
		base.transform.localPosition = m_locationOffset;
		base.transform.localRotation = Quaternion.Euler(m_rotationOffset);
		m_revolveAngle = 0f;
		m_stunParticleSystem = base.gameObject.particleSystem;
		m_stunParticleSystem.Clear();
	}

	private void Update()
	{
		if (!m_enableStun)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_stunParticleSystem.Clear();
					return;
				}
			}
		}
		if (m_stunParticleSystem != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!m_stunParticleSystem.isPlaying)
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
				m_stunParticleSystem.Play();
			}
		}
		m_revolveAngle += Time.deltaTime * m_revolveAngularSpeed;
		base.transform.localPosition = m_locationOffset + new Vector3(m_revolveRadius * Mathf.Sin(m_revolveAngle) + Random.Range(0f, m_randomOffset), Random.Range(0f, m_randomOffset), m_revolveRadius * Mathf.Cos(m_revolveAngle) + Random.Range(0f, m_randomOffset));
	}
}
