using System.Collections;
using UnityEngine;

public class SoundBehaivour : MonoBehaviour
{
	public AudioClip clip;

	public bool destroyOnComplete = false;

	public bool stopOnFadeToZero = false;

	public bool isMusic = false;

	private float m_FromVolume;

	public float defaultVolume = 1f;

	public float originalVolume = 1f;

	public bool isMuted = false;

	public bool isFading = false;

	public bool m_On;

	public float m_FadeT;

	public float m_FadeF;

	public bool fadeComplete = true;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void setMuted(bool setting)
	{
		isMuted = setting;
		if (setting)
		{
			volume(0f, 1f);
			isMuted = true;
		}
		else
		{
			volume(defaultVolume, 1f);
			isMuted = false;
		}
	}

	public float volume(float v, float t)
	{
		float num = base.audio.volume;
		bool flag = v > num;
		m_FromVolume = v;
		if (t > 0f)
		{
			m_On = flag;
			m_FadeT = t;
			m_FadeF = ((!flag) ? v : num);
			fadeComplete = false;
			StopCoroutine("fade");
			StartCoroutine("fade");
		}
		else
		{
			base.audio.volume = v;
			onVolumeChange();
		}
		return t;
	}

	private IEnumerator fade()
	{
		bool on = m_On;
		float time = m_FadeT;
		float f = m_FadeF;
		float volume = m_FromVolume;
		if (on)
		{
			base.audio.volume = f;
			while (base.audio.volume < volume)
			{
				base.audio.volume += Time.deltaTime / time;
				onVolumeChange();
				yield return new WaitForFixedUpdate();
			}
		}
		else
		{
			while (base.audio.volume > f)
			{
				base.audio.volume -= Time.deltaTime / time;
				onVolumeChange();
				yield return new WaitForFixedUpdate();
			}
		}
		fadeComplete = true;
	}

	private void onVolumeChange()
	{
		if (stopOnFadeToZero && base.audio.volume <= 0f)
		{
			base.audio.Stop();
		}
	}
}
