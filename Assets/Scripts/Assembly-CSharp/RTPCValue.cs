using System;

[Serializable]
public class RTPCValue : ValueHolder<float>
{
	public AudioRTPCobjReference m_rtpc = new AudioRTPCobjReference();
}
