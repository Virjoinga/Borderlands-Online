using A;
using BHV;
using UnityEngine;
using XsdSettings;

[RequireComponent(typeof(Camera))]
public class BadAssFPSCamera : MonoBehaviour
{
	public enum ShakeType
	{
		low = 0,
		medium = 1,
		high = 2
	}

	private float m_FOVSprintFactor;

	private float m_FOVAimFactor;

	public EntityPlayer m_entityPlayer;

	private InstanceInput m_instanceInput;

	private BHVTaskManager m_taskManager;

	private Animator m_Animator_1st;

	private Vector3 m_pos;

	private Vector3 m_toPitchOffset;

	private Transform m_pitchNode;

	public void ccc9d3a38966dc10fedb531ea17d24611(EntityPlayer cc292a78271891d4e9a7145978b66846f, Transform cb8196c4056dd760a9d820765217a57c3)
	{
		m_entityPlayer = cc292a78271891d4e9a7145978b66846f;
		m_Animator_1st = m_entityPlayer.GetComponent<PlayerThirdPersonAnimationManagerFSM>().m_firstPersonAnimator;
		base.transform.parent = cb8196c4056dd760a9d820765217a57c3;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.Euler(0f, 270f, 270f);
		m_taskManager = cc292a78271891d4e9a7145978b66846f.c9b6d1d87bef7b03dad787ff0031551ee();
		base.camera.fieldOfView = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault;
		base.gameObject.AddComponent<TargetingManager>();
		m_instanceInput = cc292a78271891d4e9a7145978b66846f.GetComponent<InstanceInput>();
		m_pitchNode = m_entityPlayer.ccd8e6ea278245d0f158036267242e60f().caf8ace1abab4e578d22e1156ba53dd04();
		m_toPitchOffset = base.transform.position - m_pitchNode.position;
		m_toPitchOffset = m_pitchNode.InverseTransformDirection(m_toPitchOffset);
	}

	public bool c2cafff3f6b9dd212847534da5df7161a()
	{
		return false;
	}

	public bool c12b20bec05d226d4f0d9a354b5015f00()
	{
		return false;
	}

	private void Update()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
					return;
				}
			}
		}
		if (m_instanceInput == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		float fOVDefault = m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault;
		fOVDefault *= c11e4ff543b5bd7abe629ef6491805863();
		fOVDefault *= c97578cee79ebd8278f6fd7f753ec3136();
		base.camera.fieldOfView = fOVDefault;
	}

	private void LateUpdate()
	{
		if (m_pitchNode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Vector3 direction = base.transform.position - m_pitchNode.position;
			direction = m_pitchNode.InverseTransformDirection(direction);
			if (!direction.ce5aad699df330ff708587e4fabea8cbb(m_toPitchOffset, 0.0001f))
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
			}
			m_toPitchOffset = m_pitchNode.InverseTransformDirection(base.transform.position - m_pitchNode.position);
		}
		m_pos = base.transform.position;
	}

	public BHVFirstPersonSettings c83296771aacb04d01c8b957f0a990ece()
	{
		return m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>();
	}

	private float c11e4ff543b5bd7abe629ef6491805863()
	{
		if (m_instanceInput.cb261500372fa488b369e9159a002977a())
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
			m_FOVSprintFactor += m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefaultToSprintTransitionSpeed * Time.deltaTime;
			if (m_FOVSprintFactor > 1f)
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
				m_FOVSprintFactor = 1f;
			}
		}
		else
		{
			m_FOVSprintFactor -= m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVSprintToDefaultTransitionSpeed * Time.deltaTime;
			if (m_FOVSprintFactor <= 0f)
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
				m_FOVSprintFactor = 0f;
			}
		}
		return Mathf.Lerp(1f, m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVSprintMultiplier, m_FOVSprintFactor);
	}

	public float c97578cee79ebd8278f6fd7f753ec3136()
	{
		EntityWeapon entityWeapon = m_entityPlayer.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					float num = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(entityWeapon.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomTime) as FloatAttributeValue);
					if (m_entityPlayer.ca12cadbe7ee37d267b161a94064131c1())
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
						if (num <= 0f)
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
							m_FOVAimFactor = 1f;
						}
						else
						{
							m_FOVAimFactor += Time.deltaTime / num;
							if (m_FOVAimFactor > 1f)
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
								m_FOVAimFactor = 1f;
							}
						}
					}
					else if (num <= 0f)
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
						m_FOVAimFactor = 0f;
					}
					else
					{
						m_FOVAimFactor -= Time.deltaTime / num;
						if (m_FOVAimFactor < 0f)
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
							m_FOVAimFactor = 0f;
						}
					}
					float to = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(entityWeapon.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ZoomEndFOV) as FloatAttributeValue) / m_taskManager.cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault;
					return Mathf.Lerp(1f, to, m_FOVAimFactor);
				}
				}
			}
		}
		return 1f;
	}

	public void c19a5441553998e0c8500003947ff7737(ShakeType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (c314e71a588d611f817c7650fb7e6d36f())
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
			if (m_entityPlayer.ce003fe849cc45b85ca4570109817c796())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			c68ecea1276d3ae144d8c54668d6bfcd9((int)c2b4f43f34e21572af6ab4414f04cee36);
			return;
		}
	}

	public void c68ecea1276d3ae144d8c54668d6bfcd9(int c871c2abe060d89d29c7fc1135d1053b0)
	{
		m_Animator_1st.SetInteger("iCameraShake", c871c2abe060d89d29c7fc1135d1053b0);
	}

	private bool c314e71a588d611f817c7650fb7e6d36f()
	{
		AnimatorStateInfo currentAnimatorStateInfo = m_Animator_1st.GetCurrentAnimatorStateInfo(1);
		if (!currentAnimatorStateInfo.IsTag("CameraShake_Low"))
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
			if (!currentAnimatorStateInfo.IsTag("CameraShake_Medium"))
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
				if (!currentAnimatorStateInfo.IsTag("CameraShake_High"))
				{
					return false;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		return true;
	}

	public Vector3 c5c60ca8f56ba52fb6c16328e1d5eff52()
	{
		return m_pos;
	}
}
