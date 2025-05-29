using System;

[Flags]
public enum EffectTriggerType
{
	Start = 1,
	Destroy = 2,
	Update = 4,
	Enable = 8,
	Disable = 0x10,
	TriggerEnter = 0x20,
	TriggerExit = 0x40,
	CollisionEnter = 0x80,
	CollisionExit = 0x100,
	MouseUp = 0x200,
	MouseDown = 0x400,
	TriggerOnUpdate = 0x800,
	KeyDown = 0x1000
}
