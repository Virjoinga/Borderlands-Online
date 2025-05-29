using A;
using UnityEngine;

public class DebugCamera : c06ca0e618478c23eba3419653a19760f<DebugCamera>
{
	private GameObject m_object;

	public Camera m_camera;

	private MouseLook m_mouseLook;

	private Vector3 m_moveDirection = Vector3.zero;

	private Vector3 m_lastTurnedAroundColliderPosition = Vector3.zero;

	public float m_cameraSpeed = 10f;

	public float m_attachmentOffset = 1f;

	public Entity m_targetedEntity;

	public Collider m_targetedCollider;

	public Entity m_attachedTo;

	public bool m_showNPCLog;

	public bool m_showPlayerLog;

	public bool m_showAimTrace;

	private void Start()
	{
		base.enabled = false;
	}

	private void Update()
	{
		if (m_attachedTo != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c9ec16eb452a86f16e331cf6d95ba3cb5();
					return;
				}
			}
		}
		if (!Screen.lockCursor)
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
			if (!m_mouseLook.enabled)
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
				if (Input.GetMouseButtonUp(1))
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
					m_mouseLook.enabled = true;
				}
				else
				{
					m_camera.transform.position += m_targetedCollider.transform.position - m_lastTurnedAroundColliderPosition;
					m_camera.transform.RotateAround(m_targetedCollider.transform.position, Vector3.Cross(Vector3.up, m_camera.transform.position - m_targetedCollider.transform.position), Input.GetAxis("Mouse Y") * 10f);
					m_camera.transform.RotateAround(m_targetedCollider.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 10f);
					m_lastTurnedAroundColliderPosition = m_targetedCollider.transform.position;
				}
			}
			else
			{
				float c85645ac328a4c6e6c17d3da3be1e11f = float.MaxValue;
				m_targetedEntity = TargetingService.cdb2b353157196638ba0e612861776113(m_camera.ScreenPointToRay(Input.mousePosition), null, out m_targetedCollider, ref c85645ac328a4c6e6c17d3da3be1e11f, ColliderType.WeakPoint, true);
				if (Input.GetMouseButtonDown(1))
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
					if (m_targetedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_mouseLook.enabled = false;
						m_camera.transform.LookAt(m_targetedCollider.transform.position);
						m_lastTurnedAroundColliderPosition = m_targetedCollider.transform.position;
					}
				}
				c2e471a7a5656f6f12f1385706a384358();
			}
			if (!Input.GetMouseButtonDown(0))
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
				if (!(m_targetedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					return;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					c6fb65fe53ff29322660f6bd30e1a8c7c();
					return;
				}
			}
		}
	}

	public bool c201e69461401637f68794a86ca99b782()
	{
		return base.enabled;
	}

	private void c9ff0f0f2e42ce6e75d98e84a884b4452(bool c5774dbf644199ba27a198318d2b320cb)
	{
		base.enabled = c5774dbf644199ba27a198318d2b320cb;
		if (c5774dbf644199ba27a198318d2b320cb)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_object = new GameObject("DebugCamera");
					m_object.transform.parent = base.gameObject.transform;
					m_camera = m_object.AddComponent<Camera>();
					m_mouseLook = m_object.AddComponent<MouseLook>();
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
					return;
				}
			}
		}
		c0f958be6a6d020768b59c9b156b90d01(false);
		if (!(m_object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Object.Destroy(m_object);
			m_object = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void c6fb65fe53ff29322660f6bd30e1a8c7c()
	{
		m_attachedTo = m_targetedEntity;
		c0f958be6a6d020768b59c9b156b90d01(false);
		m_targetedEntity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
		m_targetedCollider = cba31495600bcc560b910fdfa4123ae28.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void c1c0523e40d873f9f8791d13b3e9bff02()
	{
		m_attachedTo = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
		c0f958be6a6d020768b59c9b156b90d01(true);
	}

	private void c9ec16eb452a86f16e331cf6d95ba3cb5()
	{
		m_camera.transform.position = m_attachedTo.transform.position;
		m_camera.transform.Translate(0f, m_attachmentOffset, 0f);
		m_camera.transform.rotation = m_attachedTo.transform.rotation;
	}

	public void c2892bca6beb297898ccc3cb5f0d1bdd4(Vector3 cef9712200bbe2c3873eec3ca2e18a595)
	{
		c1c0523e40d873f9f8791d13b3e9bff02();
		m_camera.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
	}

	public void c0f958be6a6d020768b59c9b156b90d01(bool c784443508575f093718140effefad1f2)
	{
		if (c784443508575f093718140effefad1f2)
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
					m_mouseLook.enabled = true;
					c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
					return;
				}
			}
		}
		m_mouseLook.enabled = false;
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
	}

	private void OnApplicationFocus(bool focus)
	{
		if (!(m_object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (focus)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				c0f958be6a6d020768b59c9b156b90d01(false);
				return;
			}
		}
	}

	private void c2e471a7a5656f6f12f1385706a384358()
	{
		m_moveDirection.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		if (Input.GetKey(KeyCode.LeftShift))
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
			m_moveDirection *= 2f;
		}
		m_object.transform.Translate(m_moveDirection * Time.deltaTime * m_cameraSpeed);
	}

	public void c21a7023e6c96adb460d3103e16ce7000()
	{
		GUILayout.BeginArea(new Rect(0f, Screen.height - 30, Screen.width, 30f));
		GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		bool value = c201e69461401637f68794a86ca99b782();
		GUILayoutOption[] array = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = GUILayout.ExpandWidth(false);
		bool flag = GUILayout.Toggle(value, " Debug Camera", array);
		if (flag != c201e69461401637f68794a86ca99b782())
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
			c9ff0f0f2e42ce6e75d98e84a884b4452(flag);
		}
		if (c201e69461401637f68794a86ca99b782())
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
			bool showNPCLog = m_showNPCLog;
			GUILayoutOption[] array2 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = GUILayout.ExpandWidth(false);
			m_showNPCLog = GUILayout.Toggle(showNPCLog, " ShowNpcLog", array2);
			bool showPlayerLog = m_showPlayerLog;
			GUILayoutOption[] array3 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array3[0] = GUILayout.ExpandWidth(false);
			m_showPlayerLog = GUILayout.Toggle(showPlayerLog, " ShowPlayerLog", array3);
			bool showAimTrace = m_showAimTrace;
			GUILayoutOption[] array4 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array4[0] = GUILayout.ExpandWidth(false);
			m_showAimTrace = GUILayout.Toggle(showAimTrace, " ShowAimTrace", array4);
			if (m_attachedTo == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				GUILayoutOption[] array5 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
				array5[0] = GUILayout.ExpandWidth(false);
				GUILayout.Label(" | Speed: ", array5);
				float cameraSpeed = m_cameraSpeed;
				GUILayoutOption[] array6 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
				array6[0] = GUILayout.Width(80f);
				m_cameraSpeed = GUILayout.HorizontalSlider(cameraSpeed, 0.1f, 100f, array6);
				if (m_targetedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					string text = " | Left-click to attach to " + m_targetedEntity.name;
					GUILayoutOption[] array7 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
					array7[0] = GUILayout.ExpandWidth(false);
					GUILayout.Label(text, array7);
				}
			}
			else
			{
				GUILayoutOption[] array8 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
				array8[0] = GUILayout.ExpandWidth(false);
				GUILayout.Label(" | Y Offset: ", array8);
				float attachmentOffset = m_attachmentOffset;
				GUILayoutOption[] array9 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
				array9[0] = GUILayout.Width(80f);
				m_attachmentOffset = GUILayout.HorizontalSlider(attachmentOffset, 0f, 2f, array9);
				GUILayoutOption[] array10 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
				array10[0] = GUILayout.ExpandWidth(false);
				GUILayout.Label(" | ", array10);
				GUILayoutOption[] array11 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
				array11[0] = GUILayout.ExpandWidth(false);
				if (GUILayout.Button("Detach", array11))
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
					c1c0523e40d873f9f8791d13b3e9bff02();
				}
			}
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		if (!c201e69461401637f68794a86ca99b782())
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
			if (!(m_attachedTo == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height - 34));
				GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
				GUILayout.FlexibleSpace();
				GUILayout.BeginVertical(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
				GUILayout.FlexibleSpace();
				if (Screen.lockCursor)
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
					GUILayout.Label("+", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
				}
				else if (GUILayout.Button("Continue", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0)))
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
					c0f958be6a6d020768b59c9b156b90d01(true);
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndArea();
				return;
			}
		}
	}
}
