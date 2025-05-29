using A;
using UnityEngine;

public class LoadingPageBehavior : MonoBehaviour
{
	private bool m_startBootStrapLoading;

	private Animator m_introAnimator;

	private float m_duration = 1f;

	private float m_startTime;

	private void Start()
	{
		m_startTime = Time.time;
		m_introAnimator = Object.FindObjectOfType<Animator>();
		Application.backgroundLoadingPriority = ThreadPriority.Low;
	}

	private void Update()
	{
		AnimationInfo[] currentAnimationClipState = m_introAnimator.GetCurrentAnimationClipState(0);
		for (int i = 0; i < currentAnimationClipState.Length; i++)
		{
			AnimationClip clip = currentAnimationClipState[i].clip;
			if (!(clip != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
			}
			while (true)
			{
				switch (7)
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
			m_duration = Mathf.Max(clip.length, m_duration);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			bool flag = Time.time - m_startTime > m_duration;
			if (m_startBootStrapLoading)
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
				if (!flag)
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
					if (!Application.CanStreamedLevelBeLoaded("Bootstrap"))
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
						Application.LoadLevelAdditiveAsync("Bootstrap");
						m_startBootStrapLoading = true;
						return;
					}
				}
			}
		}
	}
}
