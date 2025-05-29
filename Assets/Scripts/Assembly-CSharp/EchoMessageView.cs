using A;
using Core;
using UnityEngine;

public class EchoMessageView : BaseView
{
	public static readonly float DEFAUL_DURATION = 5f;

	protected UIMessage[] m_messages;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		Rect c36964cf41281414170f34ee68bef6c = default(Rect);
		cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.alignment = TextAnchor.MiddleCenter;
		gUIStyle.fontStyle = FontStyle.Normal;
		gUIStyle.normal.textColor = Color.white;
		if (m_messages == null)
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
					return;
				}
			}
		}
		UIMessage uIMessage = m_messages[0];
		if (uIMessage != null)
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
			c36964cf41281414170f34ee68bef6c.Set(100f, 0f, 700f, 200f);
			gUIStyle.fontSize = 40;
			GUI.Label(c36964cf41281414170f34ee68bef6c, uIMessage.m_text, gUIStyle);
		}
		uIMessage = m_messages[4];
		if (uIMessage != null)
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
			c36964cf41281414170f34ee68bef6c.Set(Screen.width - 150, 100f, 80f, 30f);
			gUIStyle.fontSize = 20;
			GUI.Label(c36964cf41281414170f34ee68bef6c, uIMessage.m_text, gUIStyle);
		}
		uIMessage = m_messages[5];
		if (uIMessage != null)
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
			c36964cf41281414170f34ee68bef6c.Set(Screen.width - 150, 100f, 80f, 30f);
			gUIStyle.fontSize = 20;
			GUI.Label(c36964cf41281414170f34ee68bef6c, uIMessage.m_text, gUIStyle);
		}
		uIMessage = m_messages[3];
		if (uIMessage == null)
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
			c36964cf41281414170f34ee68bef6c.Set(Screen.width / 2, 5f, 40f, 30f);
			gUIStyle.fontSize = 30;
			if (uIMessage.m_displayCountDown)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
					{
						int num = (int)(uIMessage.m_decayDate - Time.time) + 1;
						GUI.Label(c36964cf41281414170f34ee68bef6c, uIMessage.m_text + num, gUIStyle);
						return;
					}
					}
				}
			}
			GUI.Label(c36964cf41281414170f34ee68bef6c, uIMessage.m_text, gUIStyle);
			return;
		}
	}

	public virtual void c912f6520c68c7615ec30f3a26728abc6(UIMessage c709b291ceac9f97f0c78f269054fa014)
	{
		m_messages = c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c44473a378e6c56357d01e05d2061cad5();
	}

	public virtual void c01be698909df4df10156c743f1f4a971(UIMessage c709b291ceac9f97f0c78f269054fa014)
	{
	}

	public virtual void c7e64ae2fafe55da103eb4e50d43a40ed(UIMessage c709b291ceac9f97f0c78f269054fa014)
	{
	}

	public virtual void c138a9bf6f68646f1b362f208658268f1(float c97bcd44f562f0e86731bf6c2530b8962)
	{
	}
}
