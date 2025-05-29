using UnityEngine;
using pumpkin.utils;

public class UniSWFLogoBehaviour : MonoBehaviour
{
	public Material m_Watermark;

	public Material m_TopLeftLogo;

	public int posId = 0;

	private static float m_LastLogoClick = 0f;

	private float m_LogoTime;

	private float m_StartTime;

	private float m_LogoTween;

	private void Start()
	{
		m_TopLeftLogo = new Material(m_TopLeftLogo);
		m_StartTime = Time.time;
		m_LogoTime = 5f;
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
		float num = 10f;
		float num2 = 10f;
		if (posId == 0)
		{
			if (m_LogoTween != 1f)
			{
				if (Time.time - m_StartTime > m_LogoTime)
				{
					m_LogoTween += Time.deltaTime * 0.5f;
					if (m_LogoTween > 1f)
					{
						m_LogoTween = 1f;
					}
				}
				num = Interpolation.lerpFloat(-200f, 10f, m_LogoTween);
			}
			Rect screenRect = new Rect(num, num2, m_TopLeftLogo.mainTexture.width, m_TopLeftLogo.mainTexture.height);
			if (Event.current.type.Equals(EventType.Repaint))
			{
				Graphics.DrawTexture(screenRect, m_TopLeftLogo.mainTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, 0.5f));
			}
			if (Input.GetMouseButtonDown(0) && screenRect.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y)) && (Time.time - m_LastLogoClick > 2.6f || m_LastLogoClick == 0f))
			{
				m_LastLogoClick = Time.time;
				if (!Application.isEditor)
				{
					Application.OpenURL("http://uniswf.com");
				}
			}
		}
		else if (posId == 3)
		{
			if (m_LogoTween != 1f)
			{
				if (Time.time - m_StartTime > m_LogoTime)
				{
					m_LogoTween += Time.deltaTime * 0.5f;
					if (m_LogoTween > 1f)
					{
						m_LogoTween = 1f;
					}
				}
				num = Interpolation.lerpFloat(-200f, 10f, m_LogoTween);
			}
			Rect screenRect2 = new Rect(num, (float)(Screen.height - m_TopLeftLogo.mainTexture.height) - num2, m_TopLeftLogo.mainTexture.width, m_TopLeftLogo.mainTexture.height);
			if (Event.current.type.Equals(EventType.Repaint))
			{
				Graphics.DrawTexture(screenRect2, m_TopLeftLogo.mainTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, 0.5f));
			}
			if (Input.GetMouseButtonDown(0) && screenRect2.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y)) && (Time.time - m_LastLogoClick > 2.6f || m_LastLogoClick == 0f))
			{
				m_LastLogoClick = Time.time;
				if (!Application.isEditor)
				{
					Application.OpenURL("http://uniswf.com");
				}
			}
		}
		else
		{
			if (posId != 4)
			{
				return;
			}
			if (m_LogoTween != 1f)
			{
				if (Time.time - m_StartTime > m_LogoTime)
				{
					m_LogoTween += Time.deltaTime * 0.5f;
					if (m_LogoTween > 1f)
					{
						m_LogoTween = 1f;
					}
				}
				num = Interpolation.lerpFloat(-200f, 10f, m_LogoTween);
			}
			Rect screenRect3 = new Rect((float)(Screen.width - m_TopLeftLogo.mainTexture.width) - num, (float)(Screen.height - m_TopLeftLogo.mainTexture.height) - num2, m_TopLeftLogo.mainTexture.width, m_TopLeftLogo.mainTexture.height);
			if (Event.current.type.Equals(EventType.Repaint))
			{
				Graphics.DrawTexture(screenRect3, m_TopLeftLogo.mainTexture, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, 0.5f));
			}
			if (Input.GetMouseButtonDown(0) && screenRect3.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y)) && (Time.time - m_LastLogoClick > 2.6f || m_LastLogoClick == 0f))
			{
				m_LastLogoClick = Time.time;
				if (!Application.isEditor)
				{
					Application.OpenURL("http://uniswf.com");
				}
			}
		}
	}
}
