using System;

[Serializable]
public class AudioObjectFolderReference<T> : AudioObjectReference<AudioObjectFolder<T>> where T : NamedUniqueAudioObject
{
}
