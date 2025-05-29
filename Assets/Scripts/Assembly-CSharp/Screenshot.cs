using UnityEngine;

public class Screenshot : MonoBehaviour
{
	public int Scale = 1;

	private void Start()
	{
	}

	private void Update()
	{
		if (!Input.GetKeyDown(KeyCode.F8))
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
			Application.CaptureScreenshot(".\\Screenshot.png", Scale);
			return;
		}
	}
}
