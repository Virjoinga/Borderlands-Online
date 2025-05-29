using UnityEngine;
using pumpkin.events;

public class AudioClipResource : EventDispatcher
{
	public AudioClip audioClip;

	public bool loaded = false;
}
