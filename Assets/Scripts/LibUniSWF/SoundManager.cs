using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.events;

public class SoundManager : MonoBehaviour, ISoundResourceLoader
{
	public static int MAX_POOL = 2;

	public static int MAX_ACTIVE = 8;

	public static int MUSIC_FADE_TIME = 2;

	public static string SOUNDMANAGER_NAME = "SoundManager";

	public ArrayList sounds = new ArrayList();

	public ArrayList soundPool = new ArrayList();

	public Dictionary<string, AudioClipResource> clipCache = new Dictionary<string, AudioClipResource>();

	public static ISoundResourceLoader rootSoundResourceLoader = null;

	public static Camera listenerCamera = null;

	public SoundBehaivour music;

	public SoundBehaivour fadeOutMusic;

	public float masterVolume = 1f;

	protected static SoundManager _instance;

	protected bool m_EnableSfx = true;

	protected bool m_EnableMusic = true;

	protected int m_LastSceneId = -1;

	public static bool force2D = false;

	public string lastMusicUri;

	public string lastMutedMusicUri;

	public static SoundManager instance
	{
		get
		{
			if (!_instance)
			{
				_instance = (SoundManager)Object.FindObjectOfType(typeof(SoundManager));
			}
			return _instance;
		}
	}

	public bool enableMusic
	{
		get
		{
			return m_EnableMusic;
		}
		set
		{
			if (value == m_EnableMusic)
			{
				return;
			}
			m_EnableMusic = value;
			if (!m_EnableMusic && !string.IsNullOrEmpty(lastMusicUri))
			{
				lastMutedMusicUri = lastMusicUri;
			}
			else if (m_EnableMusic && !string.IsNullOrEmpty(lastMutedMusicUri))
			{
				fadeOutAllMusic();
				if ((bool)music)
				{
					sounds.Remove(music);
					Object.Destroy(music.gameObject, MUSIC_FADE_TIME);
					music = null;
				}
				m_EnableMusic = true;
				PlayMusicStr(lastMutedMusicUri);
				lastMutedMusicUri = null;
			}
			setMusicMuted(!m_EnableMusic);
		}
	}

	public bool enableSfx
	{
		get
		{
			return m_EnableSfx;
		}
		set
		{
			if (value != m_EnableSfx)
			{
				m_EnableSfx = value;
				setSfxMuted(!m_EnableSfx);
			}
		}
	}

	public static SoundManager create()
	{
		return create(false);
	}

	public static SoundManager create(bool persistent)
	{
		if (instance != null)
		{
			return instance;
		}
		GameObject gameObject = new GameObject();
		gameObject.name = SOUNDMANAGER_NAME;
		gameObject.AddComponent<SoundManager>();
		if (persistent)
		{
			Object.DontDestroyOnLoad(gameObject);
		}
		return instance;
	}

	private void Awake()
	{
		m_LastSceneId = Application.loadedLevel;
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (m_LastSceneId != Application.loadedLevel)
		{
			m_LastSceneId = Application.loadedLevel;
		}
		for (int i = 0; i < sounds.Count; i++)
		{
			SoundBehaivour soundBehaivour = (SoundBehaivour)sounds[i];
			if (!soundBehaivour.isMusic && soundBehaivour.clip.isReadyToPlay && !soundBehaivour.audio.isPlaying)
			{
				if (soundPool.Count < MAX_POOL && !soundBehaivour.destroyOnComplete)
				{
					soundPool.Add(soundBehaivour);
				}
				else
				{
					Object.Destroy(soundBehaivour.gameObject);
				}
				sounds.RemoveAt(i);
				i--;
			}
		}
		if (fadeOutMusic != null && fadeOutMusic.fadeComplete)
		{
			Object.Destroy(fadeOutMusic.gameObject);
			removeSound(fadeOutMusic);
		}
	}

	public void PlayMusicStr(string uri)
	{
		PlayMusicStr(uri, MUSIC_FADE_TIME, 1f);
	}

	public void PlayMusicStr(string uri, float volume)
	{
		PlayMusicStr(uri, MUSIC_FADE_TIME, volume);
	}

	public void PlayMusicStr(string uri, float fadeTime, float volume)
	{
		if (!m_EnableMusic)
		{
			lastMusicUri = uri;
		}
		else
		{
			if (music != null && uri == music.clip.name)
			{
				return;
			}
			lastMusicUri = uri;
			AudioClipResource audioClipResource = getSoundResourceLoader().loadAudioClip(uri);
			if ((bool)audioClipResource.audioClip)
			{
				PlayMusicClip(audioClipResource.audioClip, fadeTime, volume);
				return;
			}
			audioClipResource.addEventListener(CEvent.COMPLETE, delegate(CEvent e)
			{
				AudioClipResource audioClipResource2 = e.currentTarget as AudioClipResource;
				if ((bool)audioClipResource2.audioClip)
				{
					PlayMusicClip(audioClipResource2.audioClip, fadeTime, volume);
				}
			});
		}
	}

	public void PlayMusicClip(AudioClip clip)
	{
		PlayMusicClip(clip, MUSIC_FADE_TIME, 1f);
	}

	public void PlayMusicClip(AudioClip clip, float volume)
	{
		PlayMusicClip(clip, MUSIC_FADE_TIME, volume);
	}

	public void PlayMusicClip(AudioClip clip, float fadeTime, float volume)
	{
		if ((music != null && clip == music.clip) || clip == null)
		{
			return;
		}
		fadeOutAllMusic(fadeTime);
		SoundBehaivour soundBehaivour = createSound(clip, Vector3.zero, volume);
		if (!(soundBehaivour != null))
		{
			return;
		}
		if (music != null)
		{
			if (fadeOutMusic != null)
			{
				Object.Destroy(fadeOutMusic.gameObject);
				removeSound(fadeOutMusic);
				fadeOutMusic = null;
			}
			fadeOutMusic = music;
			fadeOutMusic.volume(0f, fadeTime);
			soundBehaivour.volume(0f, 0f);
			soundBehaivour.volume(volume * masterVolume, fadeTime);
			soundBehaivour.destroyOnComplete = true;
			soundBehaivour.stopOnFadeToZero = true;
			soundBehaivour.isMusic = true;
			soundBehaivour.audio.loop = true;
			music = soundBehaivour;
		}
		else
		{
			soundBehaivour.volume(0f, 0f);
			soundBehaivour.volume(volume * masterVolume, fadeTime);
			soundBehaivour.destroyOnComplete = true;
			soundBehaivour.stopOnFadeToZero = true;
			soundBehaivour.isMusic = true;
			soundBehaivour.audio.loop = true;
			music = soundBehaivour;
		}
	}

	protected void removeSound(SoundBehaivour sound)
	{
		int num = sounds.IndexOf(sound);
		if (num != -1)
		{
			sounds.RemoveAt(num);
		}
	}

	public void PlaySfxStr(string uri)
	{
		PlaySfxStr(uri, 1f);
	}

	public void PlaySfxStr(string uri, float volume)
	{
		if (!m_EnableSfx)
		{
			return;
		}
		Vector3 soundPos = ((!(listenerCamera != null)) ? Camera.mainCamera.transform.position : listenerCamera.transform.position);
		AudioClipResource audioClipResource = getSoundResourceLoader().loadAudioClip(uri);
		if ((bool)audioClipResource.audioClip)
		{
			createSound(audioClipResource.audioClip, Vector3.zero, volume);
			return;
		}
		audioClipResource.addEventListener(CEvent.COMPLETE, delegate(CEvent e)
		{
			AudioClipResource audioClipResource2 = e.currentTarget as AudioClipResource;
			if ((bool)audioClipResource2.audioClip)
			{
				createSound(audioClipResource2.audioClip, soundPos, volume);
			}
		});
	}

	public SoundBehaivour PlaySfxAudioClip(AudioClip clip)
	{
		return PlaySfxAudioClip(clip, 1f);
	}

	public SoundBehaivour PlaySfxAudioClip(AudioClip clip, float volume)
	{
		if (!m_EnableSfx)
		{
			return null;
		}
		return createSound(clip, Vector3.zero, volume);
	}

	public SoundBehaivour createSound(AudioClip clip, Vector3 pos, float volume)
	{
		if (clip == null)
		{
			return null;
		}
		SoundBehaivour soundBehaivour = null;
		for (int i = 0; i < soundPool.Count; i++)
		{
			SoundBehaivour soundBehaivour2 = (SoundBehaivour)soundPool[i];
			if (soundBehaivour2.name == clip.name)
			{
				soundBehaivour = soundBehaivour2;
				soundPool.RemoveAt(i);
				break;
			}
		}
		if ((bool)soundBehaivour)
		{
			sounds.Add(soundBehaivour);
			soundBehaivour.audio.volume = soundBehaivour.originalVolume * masterVolume;
			soundBehaivour.audio.Play();
			return soundBehaivour;
		}
		int num = 0;
		for (int j = 0; j < sounds.Count; j++)
		{
			SoundBehaivour soundBehaivour3 = (SoundBehaivour)sounds[j];
			if (soundBehaivour3.clip == clip)
			{
				num++;
			}
		}
		if (num > MAX_ACTIVE)
		{
			return null;
		}
		GameObject gameObject = new GameObject();
		gameObject.name = clip.name;
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = pos;
		SoundBehaivour soundBehaivour4 = gameObject.AddComponent<SoundBehaivour>();
		gameObject.AddComponent<AudioSource>();
		soundBehaivour4.clip = clip;
		soundBehaivour4.audio.clip = clip;
		soundBehaivour4.originalVolume = volume;
		soundBehaivour4.defaultVolume = volume * masterVolume;
		if (force2D)
		{
			soundBehaivour4.audio.panLevel = 0f;
			soundBehaivour4.audio.ignoreListenerVolume = true;
		}
		soundBehaivour4.audio.Play();
		sounds.Add(soundBehaivour4);
		return soundBehaivour4;
	}

	public void fadeOutAllMusic()
	{
		fadeOutAllMusic(MUSIC_FADE_TIME);
	}

	public void fadeOutAllMusic(float fadeTime)
	{
		SoundBehaivour[] array = (SoundBehaivour[])Object.FindObjectsOfType(typeof(SoundBehaivour));
		foreach (SoundBehaivour soundBehaivour in array)
		{
			if (soundBehaivour.isMusic)
			{
				soundBehaivour.volume(0f, fadeTime);
			}
		}
	}

	public ISoundResourceLoader getSoundResourceLoader()
	{
		if (rootSoundResourceLoader != null)
		{
			return rootSoundResourceLoader;
		}
		return instance;
	}

	public AudioClipResource loadAudioClip(string uri)
	{
		if (clipCache.ContainsKey(uri))
		{
			return clipCache[uri];
		}
		AudioClipResource audioClipResource = new AudioClipResource();
		audioClipResource.audioClip = (AudioClip)Resources.Load(uri, typeof(AudioClip));
		audioClipResource.loaded = true;
		clipCache[uri] = audioClipResource;
		return audioClipResource;
	}

	public void setSfxMuted(bool setting)
	{
		m_EnableSfx = !setting;
		for (int i = 0; i < sounds.Count; i++)
		{
			SoundBehaivour soundBehaivour = (SoundBehaivour)sounds[i];
			if (!soundBehaivour.isMusic)
			{
				soundBehaivour.setMuted(setting);
			}
		}
	}

	public void setMusicMuted(bool setting)
	{
		m_EnableMusic = !setting;
		for (int i = 0; i < sounds.Count; i++)
		{
			SoundBehaivour soundBehaivour = (SoundBehaivour)sounds[i];
			if (soundBehaivour.isMusic)
			{
				soundBehaivour.setMuted(setting);
			}
		}
	}
}
