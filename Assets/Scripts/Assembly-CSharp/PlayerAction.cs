public enum PlayerAction
{
	Move = 1,
	Run = 2,
	Jump = 4,
	Crouch = 8,
	Melee = 0x10,
	Interact = 0x20,
	SwitchWeapon = 0x40,
	Fire = 0x80,
	ReloadWeapon = 0x100,
	Aim = 0x200,
	LaunchSkill = 0x400,
	ThrowGrenade = 0x800,
	AccessInventory = 0x1000
}
