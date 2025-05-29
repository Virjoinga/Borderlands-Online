using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.logging;
using pumpkin.text;
using pumpkin.tweener;

public class DemoOverlayCamera : MovieClipOverlayCameraBehaviour
{
	public bool displayAtTop = true;

	public float fadeAfter;

	public string title = string.Empty;

	protected TextField debug_txt;

	private void Start()
	{
		MovieClip movieClip = new MovieClip("uniSWF/Examples/common/swf/common_uniswf_overlay.swf:DemoOverlay");
		stage.addChild(movieClip);
		TextField childByName = movieClip.getChildByName<TextField>("txt");
		if (childByName != null)
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
			childByName.text = title;
		}
		MovieClip childByName2 = movieClip.getChildByName<MovieClip>("logo");
		childByName2.addEventListener(MouseEvent.CLICK, c465604428d68aa3a97030acff6f05cca);
		Logger.instance.addEventListener(LogEvent.LOGEVENT, c691dc25d5c0dc142b0252638ddddf3b9);
		debug_txt = movieClip.getChildByName<TextField>("debug_txt");
		if (!displayAtTop)
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
			movieClip.y = (float)Screen.height - movieClip.height;
		}
		if (!(fadeAfter > 0f))
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
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
			array[0] = "delay";
			array[1] = fadeAfter;
			array[2] = "time";
			array[3] = 3;
			array[4] = "alpha";
			array[5] = 0;
			Tweener.addTween(movieClip, Tweener.Hash(array));
			return;
		}
	}

	private void c465604428d68aa3a97030acff6f05cca(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
	{
		if (Application.absoluteURL.IndexOf("uniswf.com") != -1)
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
			Application.OpenURL("http://uniswf.com");
			return;
		}
	}

	private void c691dc25d5c0dc142b0252638ddddf3b9(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
	{
		LogEvent logEvent = c05f6b47f5e84359168dfe9aaf57b8a79 as LogEvent;
		debug_txt.alpha = 1f;
		debug_txt.text = logEvent.logStr;
		TextField context = debug_txt;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = "time";
		array[1] = 1;
		array[2] = "alpha";
		array[3] = 0;
		array[4] = "delay";
		array[5] = 3;
		Tweener.addTween(context, Tweener.Hash(array));
	}
}
