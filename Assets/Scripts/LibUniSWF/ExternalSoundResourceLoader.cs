using System.Collections;
using UnityEngine;
using pumpkin.events;

public class ExternalSoundResourceLoader : MonoBehaviour, ISoundResourceLoader
{
	public string baseAssetDir = "/Audio/";

	public string editorBaseAssetDir = "/Audio/";

	public string m_Txt = "not set";

	public IEnumerator doLoad(string uri, AudioClipResource res)
	{
		string baseDir = ((!Application.isEditor) ? baseAssetDir : editorBaseAssetDir);
		if (Application.platform == RuntimePlatform.OSXPlayer)
		{
			baseDir = "/.." + baseDir;
		}
		WWW download = new WWW(m_Txt = "file://" + Application.dataPath + baseDir + uri + ".wav");
		yield return download;
		if (download.error != null)
		{
			Debug.LogError("Failed to load audio '" + uri + "', error: " + download.error);
		}
		res.audioClip = download.audioClip;
		if ((bool)res.audioClip)
		{
			res.audioClip.name = uri;
		}
		res.dispatchEvent(new CEvent(CEvent.COMPLETE));
	}

	public void Awake()
	{
		SoundManager.rootSoundResourceLoader = this;
	}

	public AudioClipResource loadAudioClip(string uri)
	{
		if (SoundManager.instance.clipCache.ContainsKey(uri))
		{
			return SoundManager.instance.clipCache[uri];
		}
		AudioClipResource audioClipResource = new AudioClipResource();
		audioClipResource.loaded = false;
		StartCoroutine(doLoad(uri, audioClipResource));
		return audioClipResource;
	}
}
