using UnityEngine;

namespace pumpkin.swf.vm.ops
{
	public class PlaySoundOP : SimpleActionOP
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
				Debug.LogWarning("PlaySoundOP uri is null");
			}
			else if (Application.isPlaying || enableEditorPlayback)
			{
				if (customSoundCallback != null)
				{
					customSoundCallback(uri, volume);
				}
				else if (SoundManager.instance == null)
				{
					Debug.LogWarning("SoundManager not found, please create and instance of the Components->uniSWF->SoundManager component on a GameObject in the scene.");
				}
				else
				{
					SoundManager.instance.PlaySfxStr(uri, volume);
				}
			}
		}
	}
}
