using System;

[Serializable]
public class SwitchValue : ValueHolder<string>
{
	public AudioSwitchReference m_switch = new AudioSwitchReference();
}
