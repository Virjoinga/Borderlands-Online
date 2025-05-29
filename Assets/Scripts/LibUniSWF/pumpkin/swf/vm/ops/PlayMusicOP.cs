using UnityEngine;

namespace pumpkin.swf.vm.ops
{
	public class PlayMusicOP : SimpleActionOP
	{
		public delegate void PlaySoundCallback(string uri, float volume);

		public string uri;

		public float volume;

		public int repeat = 0;

		public static PlaySoundCallback customSoundCallback;

		public static bool enableEditorPlayback = false;

		public override void run(SimpleActionVM vm)
		{
			if (string.IsNullOrEmpty(uri))
			{
				Debug.LogWarning("PlayMusicOP uri is null");
			}
			else if (Application.isPlaying || enableEditorPlayback)
			{
				if (customSoundCallback != null)
				{
					customSoundCallback(uri, volume);
				}
				else if (SoundManager.instance == null)
				{
					Debug.LogWarning("SoundManager not found, please create and instance of the SoundManager on a GameObject");
				}
				else
				{
					SoundManager.instance.PlayMusicStr(uri, volume);
				}
			}
		}
	}
}
