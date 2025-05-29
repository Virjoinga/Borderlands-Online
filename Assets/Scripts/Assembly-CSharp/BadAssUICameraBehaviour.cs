using UnityEngine;

public class BadAssUICameraBehaviour : MovieClipOverlayCameraBehaviour
{
	private bool _bForceSync;

	public BadAssUICameraBehaviour()
	{
		m_EnableAutoSize = false;
		syncStageScalePerFrame = false;
	}

	public new void Awake()
	{
		base.Awake();
		m_EnableAutoSize = false;
		syncStageScalePerFrame = false;
	}

	public new void OnPostRender()
	{
		if (_bForceSync)
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
			stage.scaleX = stageScale.x + 0.0001f;
			stage.scaleY = stageScale.y + 0.0001f;
			_bForceSync = false;
		}
		base.OnPostRender();
		if (!syncStageScalePerFrame)
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
			syncStageScalePerFrame = false;
			return;
		}
	}

	public void c5f24a0d05e731dfa07ce87cd4b26666b(Vector2 cfe8c1235c4b74f9f73e6fdfed938ceb2, bool c1baf623a4e716e56198c5c4cf8a51c9a = false)
	{
		stageScale = cfe8c1235c4b74f9f73e6fdfed938ceb2;
		syncStageScalePerFrame = true;
		_bForceSync = c1baf623a4e716e56198c5c4cf8a51c9a;
	}
}
