using A;
using UnityEngine;

public class TheInsaneAnimationManagerFSM : NPCAnimationManagerFSM
{
	public Transform m_eyePrefab;

	public Transform m_backEye;

	public Transform m_frontLeftEye;

	public Transform m_frontRightEye;

	private Transform m_backEyeObj;

	private Transform m_rightEyeObj;

	private Transform m_leftEyeObj;

	private EquipmentInventoryEntityNpcBoss m_equipment;

	private bool m_bBlendEye;

	private Transform m_blendFromTransform;

	private Transform m_blendToTransform;

	public override void Start()
	{
		base.Start();
		if (m_eyePrefab != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_backEye != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				m_backEyeObj = (Transform)Object.Instantiate(m_eyePrefab, m_backEye.position, m_backEye.rotation);
				if (m_backEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					m_backEyeObj.parent = m_backEye;
				}
			}
			if (m_frontLeftEye != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_leftEyeObj = (Transform)Object.Instantiate(m_eyePrefab, m_frontLeftEye.position, m_frontLeftEye.rotation);
				if (m_leftEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					m_leftEyeObj.parent = m_frontLeftEye;
				}
			}
			if (m_frontRightEye != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_rightEyeObj = (Transform)Object.Instantiate(m_eyePrefab, m_frontRightEye.position, m_frontRightEye.rotation);
				if (m_rightEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_rightEyeObj.parent = m_frontRightEye;
				}
			}
		}
		m_equipment = GetComponent<EquipmentInventoryEntityNpcBoss>();
		m_deathLayer = 1;
	}

	public Transform ce094aed7060d8c8dd1ca9c2bd726432e(bool c22377d6dc97e35cb9538d9a7a4969755)
	{
		Transform obj;
		if (m_backEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			obj = m_backEyeObj;
		}
		else
		{
			obj = m_rightEyeObj;
		}
		Transform transform = obj;
		if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			ParticleSystem componentInChildren = transform.GetComponentInChildren<ParticleSystem>();
			if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (c22377d6dc97e35cb9538d9a7a4969755)
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
					componentInChildren.Play();
					m_AudioCtl.TriggerEventByName("Insane_Laser_Start");
					m_AudioCtl.TriggerEventByName("Insane_Laser_Loop");
				}
				else
				{
					componentInChildren.Stop();
					m_AudioCtl.ReleaseEventByName("Insane_Laser_Loop");
					m_blendFromTransform = transform;
					Transform blendToTransform;
					if (m_backEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						blendToTransform = m_backEye;
					}
					else
					{
						blendToTransform = m_frontRightEye;
					}
					m_blendToTransform = blendToTransform;
					m_bBlendEye = true;
				}
			}
		}
		return transform;
	}

	public Transform cf6ccb206cd2e66d4a29dcc9b689fff12(bool c22377d6dc97e35cb9538d9a7a4969755)
	{
		Transform leftEyeObj = m_leftEyeObj;
		if (leftEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			ParticleSystem componentInChildren = leftEyeObj.GetComponentInChildren<ParticleSystem>();
			if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c22377d6dc97e35cb9538d9a7a4969755)
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
					componentInChildren.Play();
					m_AudioCtl.TriggerEventByName("Insane_Laser_Start");
					m_AudioCtl.TriggerEventByName("Insane_Laser_Loop");
				}
				else
				{
					componentInChildren.Stop();
					m_AudioCtl.ReleaseEventByName("Insane_Laser_Loop");
					m_blendFromTransform = leftEyeObj;
					m_blendToTransform = m_frontLeftEye;
					m_bBlendEye = true;
				}
			}
		}
		return leftEyeObj;
	}

	public override void Update()
	{
		base.Update();
		if (m_equipment != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_backEyeObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (m_equipment.cd183a5dbb084bdf2992464c044efe530() == 2)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					m_backEyeObj.gameObject.SetActive(false);
					m_backEyeObj = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
					base.ccaaf181e61e5f9e050ba82237ed111a2.SetInteger("phase", 2);
					if (m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_TheInsaneEyeDestroy, null, m_backEye, Vector3.zero, Quaternion.identity, -1f);
					}
				}
			}
		}
		if (!m_bBlendEye)
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
			if (!(m_blendFromTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(m_blendToTransform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					m_blendFromTransform.position = m_blendToTransform.position;
					float num = Vector3.Angle(m_blendFromTransform.forward, m_blendToTransform.forward);
					if (num > 5f)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								m_blendFromTransform.forward = Vector3.Lerp(m_blendFromTransform.forward, m_blendToTransform.forward, Time.deltaTime);
								return;
							}
						}
					}
					m_blendFromTransform.parent = m_blendToTransform;
					m_blendFromTransform.position = m_blendToTransform.position;
					m_blendFromTransform.rotation = m_blendToTransform.rotation;
					m_blendFromTransform.localPosition = Vector3.zero;
					m_blendFromTransform.localRotation = Quaternion.identity;
					m_bBlendEye = false;
					return;
				}
			}
		}
	}
}
