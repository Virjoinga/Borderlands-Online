using UnityEngine;

public class HostHudFps : HudFps
{
	public override void Start()
	{
		startRect = new Rect(Screen.width - 75, 350f, 75f, 50f);
		startRect2 = new Rect(Screen.width - 150, startRect.yMin, startRect.width, startRect.height);
		startRect5 = new Rect(Screen.width - 150, startRect.yMin + 80f, 150f, 80f);
	}

	public override void Update()
	{
		m_memCur = (uint)DebugUtils.s_debugInfoSync.m_hostmem;
		m_memPeak = 0u;
		m_fps = DebugUtils.s_debugInfoSync.m_hostfps;
	}
}
