using System;
using A;
using UnityEngine;

public class HudFps : MonoBehaviour
{
	protected Rect startRect;

	protected Rect startRect2;

	protected Rect startRect3;

	protected Rect startRect4;

	protected Rect startRect5;

	public bool updateColor = true;

	public bool allowDrag = true;

	public float frequency = 0.5f;

	public int nbDecimal = 1;

	protected float accum;

	protected int frames;

	protected Color color = Color.white;

	protected string sFPS = string.Empty;

	protected GUIStyle style;

	protected uint m_memCur;

	protected uint m_memPeak;

	protected float m_fps;

	protected float m_camVel;

	protected float m_camAcc;

	protected float m_lastCamVel;

	protected Vector3 m_lastCamPos;

	protected BadAssFPSCamera m_cam;

	protected float m_lastPitch;

	protected float m_lastYaw;

	protected float m_pitchVel;

	protected float m_yawVel;

	protected float m_lastPitchVel;

	protected float m_lastYawVel;

	protected float m_pitchAcc;

	protected float m_yawAcc;

	public virtual void Start()
	{
		startRect = new Rect(Screen.width - 75, 10f, 75f, 50f);
		startRect2 = new Rect(Screen.width - 150, startRect.yMin, startRect.width, startRect.height);
	}

	public virtual void Update()
	{
		m_fps = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_fps;
	}

	public virtual void LateUpdate()
	{
	}

	public virtual void OnGUI()
	{
		if (style == null)
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
			style = new GUIStyle(GUI.skin.label);
			style.normal.textColor = Color.white;
			style.alignment = TextAnchor.MiddleCenter;
		}
		Color white;
		if (updateColor)
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
			white = color;
		}
		else
		{
			white = Color.white;
		}
		GUI.color = white;
		startRect = GUI.Window(0, startRect, ce8a81e8aac1802c0f94d86fb5d274c47, string.Empty);
		startRect2 = GUI.Window(1, startRect2, c27153bfdeaadb17171e6555aa1cd629a, string.Empty);
	}

	public virtual void ce8a81e8aac1802c0f94d86fb5d274c47(int c76b67c5dd1ed228f3f8e6f0aaaa58ef5)
	{
		sFPS = m_fps.ToString("f" + Mathf.Clamp(nbDecimal, 0, 10));
		Color obj;
		if (m_fps >= 25f)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			obj = Color.green;
		}
		else if (m_fps > 20f)
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
			obj = Color.yellow;
		}
		else
		{
			obj = Color.red;
		}
		color = obj;
		Rect position = new Rect(0f, 0f, startRect.width, startRect.height);
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = sFPS;
		array[1] = " FPS\n";
		array[2] = (int)(Time.deltaTime * 1000f);
		array[3] = "ms";
		GUI.Label(position, string.Concat(array), style);
		if (!allowDrag)
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
			GUI.DragWindow(new Rect(0f, 0f, Screen.width, Screen.height));
			return;
		}
	}

	public virtual void c27153bfdeaadb17171e6555aa1cd629a(int c76b67c5dd1ed228f3f8e6f0aaaa58ef5)
	{
		GUI.Label(new Rect(0f, 0f, startRect2.width, startRect2.height), " Ping:" + PhotonNetwork.c22e2236f573c63e3c4ebe74a77e5061a() + "ms", style);
		if (!allowDrag)
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
			GUI.DragWindow(new Rect(0f, 0f, Screen.width, Screen.height));
			return;
		}
	}

	public virtual void c5d63cf8bdcb74b741b567b0bebeaaaca(int c76b67c5dd1ed228f3f8e6f0aaaa58ef5)
	{
		int[] array = c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1866b244449989bc7ddc2674dfdef3ab();
		style.alignment = TextAnchor.MiddleCenter;
		for (int i = 0; i < array.Length; i++)
		{
			GUILayout.Label(Enum.GetNames(typeof(Entity.EntityType))[i] + ": " + array[i], style, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
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
			if (!allowDrag)
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
				GUI.DragWindow(new Rect(0f, 0f, Screen.width, Screen.height));
				return;
			}
		}
	}

	public virtual void cfefdaea3614a59b25dbc15917350394e(int c76b67c5dd1ed228f3f8e6f0aaaa58ef5)
	{
		if (allowDrag)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			GUI.DragWindow(new Rect(0f, 0f, Screen.width, Screen.height));
		}
		if (c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6d037f57d903e6bcdcc24348eeefb88c(Entity.EntityType.Player) <= 0)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		EntityPlayer entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_cam == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_cam = entityPlayer.cc6a7269e9ea93e537de47dc752b09a86();
		}
		if (m_cam == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
		gUIStyle.normal.textColor = Color.white;
		gUIStyle.alignment = TextAnchor.UpperLeft;
		GUILayout.Label("Pos:" + m_cam.transform.position, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("Rot:" + m_cam.transform.eulerAngles, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("LastCorrect:" + m_cam.m_entityPlayer.c31f5ac6f3babc0f76033c98d84c1824e(), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("Vel:" + (float)(int)(m_camVel * 1000f) / 1000f, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("Acc:" + (float)(int)(Mathf.Abs(m_camAcc) * 1000f) / 1000f, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("pVel:" + (float)(int)(m_pitchVel * 1000f) / 1000f, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("pAcc:" + (float)(int)(Mathf.Abs(m_pitchAcc) * 1000f) / 1000f, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("yVel:" + (float)(int)(m_yawVel * 1000f) / 1000f, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("yAcc:" + (float)(int)(Mathf.Abs(m_yawAcc) * 1000f) / 1000f, gUIStyle, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public virtual void c73d2e8825a9feee0ebc00f51460ee184(int c76b67c5dd1ed228f3f8e6f0aaaa58ef5)
	{
		GUILayout.Label("Cur:" + (float)m_memCur / 1048576f + "Mb", style, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label("Peak:" + (float)m_memPeak / 1048576f + "Mb", style, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		if (!allowDrag)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			GUI.DragWindow(new Rect(0f, 0f, Screen.width, Screen.height));
			return;
		}
	}
}
public class HUDFPS : MonoBehaviour
{
	public float updateInterval = 0.5f;

	private float accum;

	private int frames;

	private float timeleft;

	private string s = " ";

	private void Start()
	{
		timeleft = updateInterval;
	}

	private void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		frames++;
		if (!((double)timeleft <= 0.0))
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
			string text = accum / (float)frames + " FPS";
			s = text;
			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
			return;
		}
	}

	private void OnGUI()
	{
		GUI.TextField(new Rect(0f, Screen.height - 20, 100f, 20f), s);
	}
}
