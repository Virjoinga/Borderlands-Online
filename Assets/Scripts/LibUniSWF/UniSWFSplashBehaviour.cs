using UnityEngine;

public class UniSWFSplashBehaviour : MonoBehaviour
{
	public Material m_Background;

	public Material m_SplashLogo;

	public Material m_PlatformWarn;

	private static float m_LastLogoClick = 0f;

	private float m_LogoTime;

	private float m_StartTime;

	private float m_FadeSpeed;

	private void Start()
	{
		m_Background = new Material(m_Background);
		m_SplashLogo = new Material(m_SplashLogo);
		m_FadeSpeed = 1f;
		m_LogoTime = 3f;
		m_StartTime = Time.time;
		if (Application.isEditor)
		{
			m_LogoTime = 1f;
		}
	}

	private void Update()
	{
		base.useGUILayout = true;
	}

	private void OnGUI()
	{
		Rect screenRect = new Rect(Screen.width / 2 - m_SplashLogo.mainTexture.width / 2, Screen.height / 2 - m_SplashLogo.mainTexture.height / 2, m_SplashLogo.mainTexture.width, m_SplashLogo.mainTexture.height);
		Rect screenRect2 = new Rect(-50f, -50f, Screen.width + 50, Screen.height + 50);
		if (Event.current.type.Equals(EventType.Repaint))
		{
			Color color = m_SplashLogo.color;
			if (Time.time - m_StartTime > m_LogoTime)
			{
				color.a -= Time.deltaTime * m_FadeSpeed;
				if (color.a < 0f)
				{
					color.a = 0f;
				}
			}
			else
			{
				color.a += Time.deltaTime * m_FadeSpeed;
				if (color.a > 1f)
				{
					color.a = 1f;
				}
			}
			m_Background.color = color;
			m_SplashLogo.color = color;
			Graphics.DrawTexture(screenRect2, m_Background.mainTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, color.a));
			Graphics.DrawTexture(screenRect, m_SplashLogo.mainTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, color.a));
		}
		if (Input.GetMouseButtonDown(0) && (m_SplashLogo.color.a > 0f || m_PlatformWarn.color.a > 0f) && (Time.time - m_LastLogoClick > 2.6f || m_LastLogoClick == 0f))
		{
			m_LastLogoClick = Time.time;
			if (!Application.isEditor)
			{
				Application.OpenURL("http://uniswf.com");
			}
		}
	}
}
