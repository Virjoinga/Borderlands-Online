using UnityEngine;

public class UniSWFWaterMarkLogo : MonoBehaviour
{
	public Texture m_SplashLogo;

	public float padding = 10f;

	protected float m_LastLogoClick;

	private void OnGUI()
	{
		Rect screenRect = new Rect((float)(Screen.width - m_SplashLogo.width) - padding, (float)(Screen.height - m_SplashLogo.height) - padding, m_SplashLogo.width, m_SplashLogo.height);
		if (!Event.current.type.Equals(EventType.Repaint))
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
			Graphics.DrawTexture(screenRect, m_SplashLogo, new Rect(0f, 0f, 1f, 1f), 0, 0, 0, 0, new Color(0.5f, 0.5f, 0.5f, 0.25f));
			return;
		}
	}
}
